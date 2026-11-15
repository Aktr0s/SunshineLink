using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Sun6502IDE
{
    public partial class HelpForm : Form
    {
        private class Entry
        {
            public string Command = "";
            public string Syntax = "";
            public string Description = "";
        }

        private readonly List<Entry> entries = new List<Entry>();

        public HelpForm()
        {
            InitializeComponent();
        }

        private void HelpForm_Load(object sender, EventArgs e)
        {
            LoadIni();
            ApplyFilter();
            txtSearch.Focus();
        }

        private void LoadIni()
        {
            entries.Clear();
            string path = Path.Combine(Application.StartupPath, "commands.ini");
            if (!File.Exists(path))
            {
                Entry n = new Entry();
                n.Command = "commands.ini missing";
                n.Syntax = path;
                n.Description = "Put commands.ini next to SunshineLink.exe. If building in Visual Studio set its property 'Copy to Output Directory' to 'Copy if newer'.";
                entries.Add(n);
                return;
            }

            try
            {
                Entry cur = null;
                foreach (string raw in File.ReadAllLines(path, Encoding.UTF8))
                {
                    string line = raw.Trim();
                    if (line.Length == 0 || line[0] == ';' || line[0] == '#') continue;

                    if (line[0] == '[' && line[line.Length - 1] == ']')
                    {
                        cur = new Entry();
                        cur.Command = line.Substring(1, line.Length - 2).Trim();
                        entries.Add(cur);
                        continue;
                    }

                    if (cur == null) continue;
                    int eq = line.IndexOf('=');
                    if (eq <= 0) continue;

                    string key = line.Substring(0, eq).Trim().ToLowerInvariant();
                    string val = line.Substring(eq + 1).Trim().Replace("\\n", "\r\n");
                    if (key == "syntax") cur.Syntax = val;
                    else if (key == "description") cur.Description = val;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cannot read commands.ini", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFilter()
        {
            string text = txtSearch.Text.Trim().ToLowerInvariant();

            lvCommands.BeginUpdate();
            lvCommands.Items.Clear();
            foreach (Entry en in entries)
            {
                if (text.Length > 0)
                {
                    string hay = (en.Command + " " + en.Syntax + " " + en.Description).ToLowerInvariant();
                    if (!hay.Contains(text)) continue;
                }
                ListViewItem it = new ListViewItem(en.Command);
                it.SubItems.Add(en.Syntax.Replace("\r\n", "  /  "));
                it.Tag = en;
                lvCommands.Items.Add(it);
            }
            lvCommands.EndUpdate();

            if (lvCommands.Items.Count > 0) lvCommands.Items[0].Selected = true;
            else txtDetail.Text = "";
        }

        private void ShowDetail()
        {
            if (lvCommands.SelectedItems.Count == 0) return;
            Entry en = lvCommands.SelectedItems[0].Tag as Entry;
            if (en == null) return;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(en.Command);
            sb.AppendLine();
            if (en.Syntax.Length > 0) { sb.AppendLine("Syntax:"); sb.AppendLine(en.Syntax); sb.AppendLine(); }
            if (en.Description.Length > 0) sb.AppendLine(en.Description);
            txtDetail.Text = sb.ToString();
            txtDetail.SelectionStart = 0;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) { ApplyFilter(); }
        private void lvCommands_SelectedIndexChanged(object sender, EventArgs e) { ShowDetail(); }

        private void HelpForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) { Close(); e.Handled = true; }
            else if (e.Control && e.KeyCode == Keys.F) { txtSearch.Focus(); txtSearch.SelectAll(); e.Handled = true; }
        }
    }
}