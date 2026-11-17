using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Sun6502IDE
{
    // The layout lives in MainForm.Designer.cs - edit it visually in the Designer
    // (double-click MainForm.cs). This file contains only the behaviour.
    public partial class MainForm : Form
    {
        private static readonly Encoding Latin1 = Encoding.GetEncoding(28591);
        private const string FileFilter = "BASIC programs (*.bas;*.txt)|*.bas;*.txt|All files (*.*)|*.*";

        private SerialPort port;
        private HelpForm helpForm;
        private string filePath;
        private bool dirty;
        private bool sending;
        private bool lastWasCR;

        private class SendArgs
        {
            public string[] Lines;
            public string Eol;
            public int LineDelay;
            public int CharDelay;
        }

        public MainForm()
        {
            InitializeComponent();
        }

        // =====================================================================
        //  Form events
        // =====================================================================
        private void MainForm_Load(object sender, EventArgs e)
        {
            cmbFlow.SelectedIndex = 1;
            cmbEol.SelectedIndex = 0;
            RefreshPorts();

            editor.Text = "10 REM SUN6502 TEST\r\n20 PRINT \"HELLO FROM SUN6502\"\r\n30 GOTO 20\r\n";
            dirty = false;
            UpdateTitle();
            UpdateConnState();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ConfirmDiscard()) { e.Cancel = true; return; }
            Disconnect();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                SendProgram();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Pause || e.KeyCode == Keys.Cancel)
            {
                SendBreak();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        // =====================================================================
        //  Menu / toolbar events
        // =====================================================================
        private void miFileNew_Click(object sender, EventArgs e) { DoNew(); }
        private void miFileOpen_Click(object sender, EventArgs e) { DoOpen(); }
        private void miFileSave_Click(object sender, EventArgs e) { DoSave(false); }
        private void miFileSaveAs_Click(object sender, EventArgs e) { DoSave(true); }
        private void miFileExit_Click(object sender, EventArgs e) { Close(); }

        private void cmbPort_DropDown(object sender, EventArgs e) { RefreshPorts(); }
        private void btnConnect_Click(object sender, EventArgs e) { ToggleConnection(); }
        private void btnSend_Click(object sender, EventArgs e) { SendProgram(); }
        private void btnSendSel_Click(object sender, EventArgs e) { SendSelection(); }
        private void btnStop_Click(object sender, EventArgs e) { worker.CancelAsync(); }
        private void btnBreak_Click(object sender, EventArgs e) { SendBreak(); }
        private void btnGrab_Click(object sender, EventArgs e) { GrabTerminal(); }
        private void btnClear_Click(object sender, EventArgs e) { term.Clear(); }

        private void miCtxCopy_Click(object sender, EventArgs e)
        {
            if (term.SelectionLength > 0) term.Copy();
        }

        private void miCtxClear_Click(object sender, EventArgs e) { term.Clear(); }

        // =====================================================================
        //  Editor events
        // =====================================================================
        private void editor_TextChanged(object sender, EventArgs e)
        {
            dirty = true;
            UpdateTitle();
            UpdatePos();
        }

        private void editor_KeyUp(object sender, KeyEventArgs e) { UpdatePos(); }
        private void editor_MouseUp(object sender, MouseEventArgs e) { UpdatePos(); }

        private void editor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                editor.SelectAll();
                e.SuppressKeyPress = true;
            }
        }

        private void UpdateTitle()
        {
            string name = filePath == null ? "untitled" : Path.GetFileName(filePath);
            Text = "SunshineLink - " + name + (dirty ? " *" : "");
        }

        private void UpdatePos()
        {
            int idx = editor.SelectionStart;
            int line = editor.GetLineFromCharIndex(idx);
            int col = idx - editor.GetFirstCharIndexFromLine(line);
            lblPos.Text = "Ln " + (line + 1) + ", Col " + (col + 1);
        }

        // =====================================================================
        //  Files
        // =====================================================================
        private bool ConfirmDiscard()
        {
            if (!dirty) return true;
            string name = filePath == null ? "untitled" : Path.GetFileName(filePath);
            DialogResult r = MessageBox.Show("Save changes to " + name + "?", "SunshineLink",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (r == DialogResult.Cancel) return false;
            if (r == DialogResult.Yes) return DoSave(false);
            return true;
        }

        private void DoNew()
        {
            if (!ConfirmDiscard()) return;
            editor.Text = "";
            filePath = null;
            dirty = false;
            UpdateTitle();
        }

        private void DoOpen()
        {
            if (!ConfirmDiscard()) return;
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = FileFilter;
                if (dlg.ShowDialog(this) != DialogResult.OK) return;
                try
                {
                    editor.Text = File.ReadAllText(dlg.FileName, Latin1);
                    filePath = dlg.FileName;
                    dirty = false;
                    UpdateTitle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Cannot open file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool DoSave(bool saveAs)
        {
            string path = filePath;
            if (saveAs || path == null)
            {
                using (SaveFileDialog dlg = new SaveFileDialog())
                {
                    dlg.Filter = FileFilter;
                    dlg.DefaultExt = "bas";
                    if (path != null) dlg.FileName = Path.GetFileName(path);
                    if (dlg.ShowDialog(this) != DialogResult.OK) return false;
                    path = dlg.FileName;
                }
            }
            try
            {
                File.WriteAllText(path, editor.Text, Latin1);
                filePath = path;
                dirty = false;
                UpdateTitle();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cannot save file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // =====================================================================
        //  Serial port
        // =====================================================================
        private bool PortOpen
        {
            get { return port != null && port.IsOpen; }
        }

        private void RefreshPorts()
        {
            string current = cmbPort.Text;
            string[] names = SerialPort.GetPortNames();
            Array.Sort(names);
            cmbPort.Items.Clear();
            cmbPort.Items.AddRange(names);
            if (current.Length > 0) cmbPort.Text = current;
            else if (names.Length > 0) cmbPort.Text = names[0];
        }

        private void ToggleConnection()
        {
            if (PortOpen) Disconnect(); else Connect();
        }

        private void Connect()
        {
            string name = cmbPort.Text.Trim();
            if (name.Length == 0)
            {
                MessageBox.Show("Select a COM port first.", "SunshineLink");
                return;
            }
            int baud;
            if (!int.TryParse(cmbBaud.Text.Trim(), out baud) || baud <= 0)
            {
                MessageBox.Show("Invalid baud rate.", "SunshineLink");
                return;
            }

            SerialPort p = null;
            try
            {
                p = new SerialPort(name, baud, Parity.None, 8, StopBits.One);
                p.Encoding = Latin1;
                p.WriteTimeout = 3000;
                switch (cmbFlow.SelectedIndex)
                {
                    case 1: p.Handshake = Handshake.RequestToSend; break;
                    case 2: p.Handshake = Handshake.XOnXOff; break;
                    default: p.Handshake = Handshake.None; break;
                }
                p.DtrEnable = true;
                if (p.Handshake == Handshake.None || p.Handshake == Handshake.XOnXOff)
                    p.RtsEnable = true;
                p.DataReceived += Port_DataReceived;
                p.Open();
                port = p;
                term.Focus();
            }
            catch (Exception ex)
            {
                if (p != null) { try { p.Dispose(); } catch (Exception) { } }
                port = null;
                MessageBox.Show(ex.Message, "Cannot open " + name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UpdateConnState();
        }

        private void Disconnect()
        {
            if (sending) worker.CancelAsync();
            SerialPort p = port;
            port = null;
            if (p != null)
            {
                p.DataReceived -= Port_DataReceived;
                try { if (p.IsOpen) p.Close(); } catch (Exception) { }
                try { p.Dispose(); } catch (Exception) { }
            }
            UpdateConnState();
        }

        private void UpdateConnState()
        {
            bool on = PortOpen;
            btnConnect.Text = on ? "Disconnect" : "Connect";
            cmbPort.Enabled = !on;
            cmbBaud.Enabled = !on;
            cmbFlow.Enabled = !on;
            btnSend.Enabled = on && !sending;
            btnSendSel.Enabled = on && !sending;
            btnStop.Enabled = sending;
            btnBreak.Enabled = on;
            lblConn.Text = on
                ? "Connected: " + port.PortName + " " + port.BaudRate + " 8N1"
                : "Disconnected";
        }

        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                SerialPort p = (SerialPort)sender;
                string data = p.ReadExisting();
                if (data.Length > 0 && IsHandleCreated)
                    BeginInvoke(new MethodInvoker(delegate { AppendTerm(data); }));
            }
            catch (Exception) { }
        }

        private void SendRaw(string s)
        {
            if (!PortOpen) return;
            try { port.Write(s); }
            catch (Exception ex) { lblSend.Text = "Write error: " + ex.Message; }
        }

        private string Eol()
        {
            switch (cmbEol.SelectedIndex)
            {
                case 1: return "\n";
                case 2: return "\r\n";
                default: return "\r";
            }
        }

        // =====================================================================
        //  Terminal
        // =====================================================================
        private void AppendTerm(string s)
        {
            bool crNl = miCrNl.Checked;
            StringBuilder sb = new StringBuilder();
            foreach (char ch in s)
            {
                if (ch == '\r')
                {
                    if (crNl) { sb.Append("\r\n"); lastWasCR = true; }
                }
                else if (ch == '\n')
                {
                    if (lastWasCR && crNl) lastWasCR = false;
                    else sb.Append("\r\n");
                }
                else if (ch == '\b' || ch == (char)127)
                {
                    lastWasCR = false;
                    if (sb.Length > 0)
                    {
                        if (sb[sb.Length - 1] != '\n') sb.Length--;
                    }
                    else if (term.TextLength > 0)
                    {
                        if (term.Text[term.TextLength - 1] != '\n')
                        {
                            term.Select(term.TextLength - 1, 1);
                            term.SelectedText = "";
                        }
                    }
                }
                else if (ch >= ' ' || ch == '\t')
                {
                    lastWasCR = false;
                    sb.Append(ch);
                }
                else
                {
                    lastWasCR = false; // other control chars ignored (bell, NUL, ...)
                }
            }

            if (term.TextLength > 100000)
            {
                term.Select(0, 50000);
                term.SelectedText = "";
            }
            if (sb.Length > 0) term.AppendText(sb.ToString());
        }

        private void term_KeyDown(object sender, KeyEventArgs e)
        {
            Keys k = e.KeyCode;
            if (k == Keys.ShiftKey || k == Keys.ControlKey || k == Keys.Menu || k == Keys.CapsLock)
                return;

            // Copy
            if ((e.Control && k == Keys.C && term.SelectionLength > 0) || (e.Control && k == Keys.Insert))
            {
                if (term.SelectionLength > 0) term.Copy();
                e.SuppressKeyPress = true;
                return;
            }

            if (e.Control && !e.Alt && k == Keys.X)
            {
                e.SuppressKeyPress = true;
                SendBreak();
                return;
            }

            bool special = false;
            string toSend = null;
            string echo = null;

            if (e.Control && !e.Alt)
            {
                if (k == Keys.V)
                {
                    if (PortOpen && !sending && Clipboard.ContainsText())
                        StartSend(SplitLines(Clipboard.GetText()));
                    e.SuppressKeyPress = true;
                    return;
                }
                if (k >= Keys.A && k <= Keys.Z)
                {
                    special = true;
                    toSend = ((char)((int)k - (int)Keys.A + 1)).ToString();
                }
            }
            else
            {
                switch (k)
                {
                    case Keys.Enter: special = true; toSend = Eol(); echo = "\r"; break;
                    case Keys.Back: special = true; toSend = miBsDel.Checked ? ((char)127).ToString() : "\b"; echo = "\b"; break;
                    case Keys.Escape: special = true; toSend = ((char)27).ToString(); break;
                    case Keys.Tab: special = true; toSend = "\t"; echo = "\t"; break;
                    case Keys.Delete: special = true; break;
                }
            }

            if (!special) return; // printable keys are handled in KeyPress

            e.SuppressKeyPress = true;
            if (toSend == null || !PortOpen || sending) return;
            SendRaw(toSend);
        }

        private void term_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true; // never type into the terminal window itself
            char c = e.KeyChar;
            if (c < ' ' || c == (char)127) return;
            if (!PortOpen || sending) return;
            SendRaw(c.ToString());
        }

        private void GrabTerminal()
        {
            string t = term.SelectionLength > 0 ? term.SelectedText : term.Text;
            if (t.Length == 0) return;
            if (editor.TextLength > 0)
            {
                DialogResult r = MessageBox.Show("Replace the editor contents with the terminal text?",
                    "Grab from terminal", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r != DialogResult.Yes) return;
            }
            editor.Text = t;
        }

        // =====================================================================
        //  Sending
        // =====================================================================
        private static string[] SplitLines(string text)
        {
            string t = text.Replace("\r\n", "\n").Replace('\r', '\n');
            List<string> res = new List<string>(t.Split('\n'));
            if (res.Count > 0 && res[res.Count - 1].Length == 0) res.RemoveAt(res.Count - 1);
            return res.ToArray();
        }

        private static string UpperOutsideQuotes(string s)
        {
            StringBuilder sb = new StringBuilder(s.Length);
            bool inQuote = false;
            foreach (char c in s)
            {
                if (c == '"') { inQuote = !inQuote; sb.Append(c); }
                else sb.Append(inQuote ? c : char.ToUpperInvariant(c));
            }
            return sb.ToString();
        }

        private string[] PrepareProgram(string text, bool wrap)
        {
            List<string> res = new List<string>();
            if (wrap && miNew.Checked) res.Add("NEW");

            int next = 10;
            foreach (string raw in SplitLines(text))
            {
                string line = raw.Trim();
                if (line.Length == 0) continue;

                if (char.IsDigit(line[0]))
                {
                    int n = 0, i = 0;
                    while (i < line.Length && char.IsDigit(line[i]) && i < 6)
                    {
                        n = n * 10 + (line[i] - '0');
                        i++;
                    }
                    next = n + 10;
                }
                else if (miAutoNum.Checked)
                {
                    line = next + " " + line;
                    next += 10;
                }

                if (miUpper.Checked) line = UpperOutsideQuotes(line);
                res.Add(line);
            }

            if (wrap && miRun.Checked) res.Add("RUN");
            return res.ToArray();
        }

        private void SendProgram()
        {
            if (!PortOpen) { lblSend.Text = "Not connected"; return; }
            StartSend(PrepareProgram(editor.Text, true));
        }

        private void SendSelection()
        {
            if (!PortOpen) { lblSend.Text = "Not connected"; return; }
            if (editor.SelectionLength == 0) { lblSend.Text = "Nothing selected"; return; }
            StartSend(PrepareProgram(editor.SelectedText, false));
        }

        private static int ParseInt(string s, int max)
        {
            int v;
            if (!int.TryParse(s.Trim(), out v) || v < 0) return 0;
            return v > max ? max : v;
        }

        private void StartSend(string[] lines)
        {
            if (!PortOpen || worker.IsBusy || lines.Length == 0) return;

            SendArgs a = new SendArgs();
            a.Lines = lines;
            a.Eol = Eol();
            a.LineDelay = ParseInt(txtLineDelay.Text, 10000);
            a.CharDelay = ParseInt(txtCharDelay.Text, 1000);

            sending = true;
            bar.Value = 0;
            bar.Visible = true;
            UpdateConnState();
            worker.RunWorkerAsync(a);
        }

        private bool SleepCancelable(int ms)
        {
            // returns false if cancelled
            while (ms > 0)
            {
                if (worker.CancellationPending) return false;
                int step = ms > 20 ? 20 : ms;
                Thread.Sleep(step);
                ms -= step;
            }
            return !worker.CancellationPending;
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            SendArgs a = (SendArgs)e.Argument;
            SerialPort p = port;
            int total = a.Lines.Length;

            for (int i = 0; i < total; i++)
            {
                if (worker.CancellationPending) { e.Cancel = true; return; }
                string line = a.Lines[i] + a.Eol;

                if (a.CharDelay > 0)
                {
                    foreach (char c in line)
                    {
                        if (worker.CancellationPending) { e.Cancel = true; return; }
                        p.Write(c.ToString());
                        if (!SleepCancelable(a.CharDelay)) { e.Cancel = true; return; }
                    }
                }
                else
                {
                    p.Write(line);
                }

                worker.ReportProgress((i + 1) * 100 / total, new object[] { i + 1, total, a.Lines[i] });

                if (a.LineDelay > 0 && !SleepCancelable(a.LineDelay)) { e.Cancel = true; return; }
            }
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            bar.Value = Math.Min(100, e.ProgressPercentage);
            object[] st = e.UserState as object[];
            if (st != null)
            {
                lblSend.Text = "Sending line " + st[0] + " of " + st[1];
            }
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            sending = false;
            bar.Visible = false;
            if (e.Error != null) lblSend.Text = "Send error: " + e.Error.Message;
            else if (e.Cancelled) lblSend.Text = "Send stopped";
            else lblSend.Text = "Send complete";
            UpdateConnState();
        }

        private void SendBreak()
        {
            if (sending) worker.CancelAsync();
            SendRaw(((char)3).ToString());
        
        }

        private void miHelpBasic_Click(object sender, EventArgs e)
        {
            if (helpForm == null || helpForm.IsDisposed)
                helpForm = new HelpForm();
            if (!helpForm.Visible) helpForm.Show(this);
            helpForm.Activate();
        }

        private void miHelpAbout_Click(object sender, EventArgs e)
        {
            using (AboutForm f = new AboutForm())
            {
                f.ShowDialog(this);
            }
        }

    }
}
