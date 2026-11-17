namespace Sun6502IDE
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.mFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.miFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.miFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.miFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.sepFile = new System.Windows.Forms.ToolStripSeparator();
            this.miFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mOpt = new System.Windows.Forms.ToolStripMenuItem();
            this.miAutoNum = new System.Windows.Forms.ToolStripMenuItem();
            this.miUpper = new System.Windows.Forms.ToolStripMenuItem();
            this.miNew = new System.Windows.Forms.ToolStripMenuItem();
            this.miRun = new System.Windows.Forms.ToolStripMenuItem();
            this.sepOpt = new System.Windows.Forms.ToolStripSeparator();
            this.miCrNl = new System.Windows.Forms.ToolStripMenuItem();
            this.miBsDel = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miHelpBasic = new System.Windows.Forms.ToolStripMenuItem();
            this.miHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.lblPortCap = new System.Windows.Forms.ToolStripLabel();
            this.cmbPort = new System.Windows.Forms.ToolStripComboBox();
            this.lblBaudCap = new System.Windows.Forms.ToolStripLabel();
            this.cmbBaud = new System.Windows.Forms.ToolStripComboBox();
            this.cmbFlow = new System.Windows.Forms.ToolStripComboBox();
            this.btnConnect = new System.Windows.Forms.ToolStripButton();
            this.sep1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSend = new System.Windows.Forms.ToolStripButton();
            this.btnSendSel = new System.Windows.Forms.ToolStripButton();
            this.btnStop = new System.Windows.Forms.ToolStripButton();
            this.btnBreak = new System.Windows.Forms.ToolStripButton();
            this.sep2 = new System.Windows.Forms.ToolStripSeparator();
            this.lblEolCap = new System.Windows.Forms.ToolStripLabel();
            this.cmbEol = new System.Windows.Forms.ToolStripComboBox();
            this.lblLineCap = new System.Windows.Forms.ToolStripLabel();
            this.txtLineDelay = new System.Windows.Forms.ToolStripTextBox();
            this.lblCharCap = new System.Windows.Forms.ToolStripLabel();
            this.txtCharDelay = new System.Windows.Forms.ToolStripTextBox();
            this.sep3 = new System.Windows.Forms.ToolStripSeparator();
            this.status = new System.Windows.Forms.StatusStrip();
            this.lblConn = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblPos = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSend = new System.Windows.Forms.ToolStripStatusLabel();
            this.bar = new System.Windows.Forms.ToolStripProgressBar();
            this.split = new System.Windows.Forms.SplitContainer();
            this.editor = new System.Windows.Forms.TextBox();
            this.hCode = new System.Windows.Forms.Label();
            this.term = new System.Windows.Forms.TextBox();
            this.termMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miCtxCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.miCtxClear = new System.Windows.Forms.ToolStripMenuItem();
            this.hTerm = new System.Windows.Forms.Label();
            this.worker = new System.ComponentModel.BackgroundWorker();
            this.menu.SuspendLayout();
            this.toolbar.SuspendLayout();
            this.status.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split)).BeginInit();
            this.split.Panel1.SuspendLayout();
            this.split.Panel2.SuspendLayout();
            this.split.SuspendLayout();
            this.termMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mFile,
            this.mOpt,
            this.helpToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1100, 24);
            this.menu.TabIndex = 0;
            // 
            // mFile
            // 
            this.mFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFileNew,
            this.miFileOpen,
            this.miFileSave,
            this.miFileSaveAs,
            this.sepFile,
            this.miFileExit});
            this.mFile.Name = "mFile";
            this.mFile.Size = new System.Drawing.Size(37, 20);
            this.mFile.Text = "&File";
            // 
            // miFileNew
            // 
            this.miFileNew.Name = "miFileNew";
            this.miFileNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.miFileNew.Size = new System.Drawing.Size(195, 22);
            this.miFileNew.Text = "&New";
            this.miFileNew.Click += new System.EventHandler(this.miFileNew_Click);
            // 
            // miFileOpen
            // 
            this.miFileOpen.Name = "miFileOpen";
            this.miFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.miFileOpen.Size = new System.Drawing.Size(195, 22);
            this.miFileOpen.Text = "&Open...";
            this.miFileOpen.Click += new System.EventHandler(this.miFileOpen_Click);
            // 
            // miFileSave
            // 
            this.miFileSave.Name = "miFileSave";
            this.miFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.miFileSave.Size = new System.Drawing.Size(195, 22);
            this.miFileSave.Text = "&Save";
            this.miFileSave.Click += new System.EventHandler(this.miFileSave_Click);
            // 
            // miFileSaveAs
            // 
            this.miFileSaveAs.Name = "miFileSaveAs";
            this.miFileSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.S)));
            this.miFileSaveAs.Size = new System.Drawing.Size(195, 22);
            this.miFileSaveAs.Text = "Save &As...";
            this.miFileSaveAs.Click += new System.EventHandler(this.miFileSaveAs_Click);
            // 
            // sepFile
            // 
            this.sepFile.Name = "sepFile";
            this.sepFile.Size = new System.Drawing.Size(192, 6);
            // 
            // miFileExit
            // 
            this.miFileExit.Name = "miFileExit";
            this.miFileExit.Size = new System.Drawing.Size(195, 22);
            this.miFileExit.Text = "E&xit";
            this.miFileExit.Click += new System.EventHandler(this.miFileExit_Click);
            // 
            // mOpt
            // 
            this.mOpt.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAutoNum,
            this.miUpper,
            this.miNew,
            this.miRun,
            this.sepOpt,
            this.miCrNl,
            this.miBsDel});
            this.mOpt.Name = "mOpt";
            this.mOpt.Size = new System.Drawing.Size(61, 20);
            this.mOpt.Text = "&Options";
            // 
            // miAutoNum
            // 
            this.miAutoNum.CheckOnClick = true;
            this.miAutoNum.Name = "miAutoNum";
            this.miAutoNum.Size = new System.Drawing.Size(297, 22);
            this.miAutoNum.Text = "Auto line &numbers (step 10) when sending";
            // 
            // miUpper
            // 
            this.miUpper.CheckOnClick = true;
            this.miUpper.Name = "miUpper";
            this.miUpper.Size = new System.Drawing.Size(297, 22);
            this.miUpper.Text = "Send in &UPPERCASE (except inside quotes)";
            // 
            // miNew
            // 
            this.miNew.CheckOnClick = true;
            this.miNew.Name = "miNew";
            this.miNew.Size = new System.Drawing.Size(297, 22);
            this.miNew.Text = "Send &NEW before program";
            // 
            // miRun
            // 
            this.miRun.Checked = true;
            this.miRun.CheckOnClick = true;
            this.miRun.CheckState = System.Windows.Forms.CheckState.Checked;
            this.miRun.Name = "miRun";
            this.miRun.Size = new System.Drawing.Size(297, 22);
            this.miRun.Text = "Send &RUN after program";
            // 
            // sepOpt
            // 
            this.sepOpt.Name = "sepOpt";
            this.sepOpt.Size = new System.Drawing.Size(294, 6);
            // 
            // miCrNl
            // 
            this.miCrNl.CheckOnClick = true;
            this.miCrNl.Name = "miCrNl";
            this.miCrNl.Size = new System.Drawing.Size(297, 22);
            this.miCrNl.Text = "Received CR = &new line";
            // 
            // miBsDel
            // 
            this.miBsDel.CheckOnClick = true;
            this.miBsDel.Name = "miBsDel";
            this.miBsDel.Size = new System.Drawing.Size(297, 22);
            this.miBsDel.Text = "Backspace key sends &DEL ($7F)";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miHelpBasic,
            this.miHelpAbout});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // miHelpBasic
            // 
            this.miHelpBasic.Name = "miHelpBasic";
            this.miHelpBasic.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.miHelpBasic.Size = new System.Drawing.Size(180, 22);
            this.miHelpBasic.Text = "&BASIC Reference";
            this.miHelpBasic.Click += new System.EventHandler(this.miHelpBasic_Click);
            // 
            // miHelpAbout
            // 
            this.miHelpAbout.Name = "miHelpAbout";
            this.miHelpAbout.Size = new System.Drawing.Size(180, 22);
            this.miHelpAbout.Text = "&About";
            this.miHelpAbout.Click += new System.EventHandler(this.miHelpAbout_Click);
            // 
            // toolbar
            // 
            this.toolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblPortCap,
            this.cmbPort,
            this.lblBaudCap,
            this.cmbBaud,
            this.cmbFlow,
            this.btnConnect,
            this.sep1,
            this.btnSend,
            this.btnSendSel,
            this.btnStop,
            this.btnBreak,
            this.sep2,
            this.lblEolCap,
            this.cmbEol,
            this.lblLineCap,
            this.txtLineDelay,
            this.lblCharCap,
            this.txtCharDelay,
            this.sep3});
            this.toolbar.Location = new System.Drawing.Point(0, 24);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(1100, 25);
            this.toolbar.TabIndex = 1;
            // 
            // lblPortCap
            // 
            this.lblPortCap.Name = "lblPortCap";
            this.lblPortCap.Size = new System.Drawing.Size(29, 22);
            this.lblPortCap.Text = "Port";
            // 
            // cmbPort
            // 
            this.cmbPort.Name = "cmbPort";
            this.cmbPort.Size = new System.Drawing.Size(75, 25);
            this.cmbPort.DropDown += new System.EventHandler(this.cmbPort_DropDown);
            // 
            // lblBaudCap
            // 
            this.lblBaudCap.Name = "lblBaudCap";
            this.lblBaudCap.Size = new System.Drawing.Size(34, 22);
            this.lblBaudCap.Text = "Baud";
            // 
            // cmbBaud
            // 
            this.cmbBaud.Items.AddRange(new object[] {
            "300",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cmbBaud.Name = "cmbBaud";
            this.cmbBaud.Size = new System.Drawing.Size(75, 25);
            this.cmbBaud.Text = "19200";
            // 
            // cmbFlow
            // 
            this.cmbFlow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFlow.Items.AddRange(new object[] {
            "No flow",
            "RTS/CTS",
            "XON/XOFF"});
            this.cmbFlow.Name = "cmbFlow";
            this.cmbFlow.Size = new System.Drawing.Size(85, 25);
            // 
            // btnConnect
            // 
            this.btnConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(56, 22);
            this.btnConnect.Text = "Connect";
            this.btnConnect.ToolTipText = "Open / close the serial port";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // sep1
            // 
            this.sep1.Name = "sep1";
            this.sep1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSend
            // 
            this.btnSend.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(99, 22);
            this.btnSend.Text = "▶ Send program";
            this.btnSend.ToolTipText = "Send the whole editor to the computer (F5)";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnSendSel
            // 
            this.btnSendSel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSendSel.Name = "btnSendSel";
            this.btnSendSel.Size = new System.Drawing.Size(87, 22);
            this.btnSendSel.Text = "Send selection";
            this.btnSendSel.ToolTipText = "Send only the selected lines";
            this.btnSendSel.Click += new System.EventHandler(this.btnSendSel_Click);
            // 
            // btnStop
            // 
            this.btnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(35, 22);
            this.btnStop.Text = "Stop";
            this.btnStop.ToolTipText = "Abort sending";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnBreak
            // 
            this.btnBreak.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnBreak.Name = "btnBreak";
            this.btnBreak.Size = new System.Drawing.Size(89, 22);
            this.btnBreak.Text = "Break Program";
            this.btnBreak.ToolTipText = "Send Ctrl-C to interrupt a running program";
            this.btnBreak.Click += new System.EventHandler(this.btnBreak_Click);
            // 
            // sep2
            // 
            this.sep2.Name = "sep2";
            this.sep2.Size = new System.Drawing.Size(6, 25);
            // 
            // lblEolCap
            // 
            this.lblEolCap.Name = "lblEolCap";
            this.lblEolCap.Size = new System.Drawing.Size(52, 22);
            this.lblEolCap.Text = "Line end";
            // 
            // cmbEol
            // 
            this.cmbEol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEol.DropDownWidth = 75;
            this.cmbEol.Items.AddRange(new object[] {
            "CR",
            "LF",
            "CR+LF"});
            this.cmbEol.Name = "cmbEol";
            this.cmbEol.Size = new System.Drawing.Size(75, 25);
            // 
            // lblLineCap
            // 
            this.lblLineCap.Name = "lblLineCap";
            this.lblLineCap.Size = new System.Drawing.Size(88, 22);
            this.lblLineCap.Text = "Line Delay (ms)";
            // 
            // txtLineDelay
            // 
            this.txtLineDelay.Name = "txtLineDelay";
            this.txtLineDelay.Size = new System.Drawing.Size(40, 25);
            this.txtLineDelay.Text = "100";
            // 
            // lblCharCap
            // 
            this.lblCharCap.Name = "lblCharCap";
            this.lblCharCap.Size = new System.Drawing.Size(91, 22);
            this.lblCharCap.Text = "Char Delay (ms)";
            // 
            // txtCharDelay
            // 
            this.txtCharDelay.Name = "txtCharDelay";
            this.txtCharDelay.Size = new System.Drawing.Size(35, 25);
            this.txtCharDelay.Text = "0";
            // 
            // sep3
            // 
            this.sep3.Name = "sep3";
            this.sep3.Size = new System.Drawing.Size(6, 25);
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblConn,
            this.lblPos,
            this.lblSend,
            this.bar});
            this.status.Location = new System.Drawing.Point(0, 658);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(1100, 22);
            this.status.TabIndex = 3;
            // 
            // lblConn
            // 
            this.lblConn.AutoSize = false;
            this.lblConn.Name = "lblConn";
            this.lblConn.Size = new System.Drawing.Size(190, 17);
            this.lblConn.Text = "Disconnected";
            this.lblConn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPos
            // 
            this.lblPos.AutoSize = false;
            this.lblPos.Name = "lblPos";
            this.lblPos.Size = new System.Drawing.Size(100, 17);
            this.lblPos.Text = "Ln 1, Col 1";
            this.lblPos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSend
            // 
            this.lblSend.Name = "lblSend";
            this.lblSend.Size = new System.Drawing.Size(795, 17);
            this.lblSend.Spring = true;
            this.lblSend.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bar
            // 
            this.bar.Name = "bar";
            this.bar.Size = new System.Drawing.Size(150, 16);
            this.bar.Visible = false;
            // 
            // split
            // 
            this.split.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split.Location = new System.Drawing.Point(0, 49);
            this.split.Name = "split";
            // 
            // split.Panel1
            // 
            this.split.Panel1.Controls.Add(this.editor);
            this.split.Panel1.Controls.Add(this.hCode);
            // 
            // split.Panel2
            // 
            this.split.Panel2.Controls.Add(this.term);
            this.split.Panel2.Controls.Add(this.hTerm);
            this.split.Size = new System.Drawing.Size(1100, 609);
            this.split.SplitterDistance = 600;
            this.split.TabIndex = 2;
            // 
            // editor
            // 
            this.editor.AcceptsReturn = true;
            this.editor.AcceptsTab = true;
            this.editor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(34)))));
            this.editor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editor.ForeColor = System.Drawing.Color.Gainsboro;
            this.editor.Location = new System.Drawing.Point(0, 20);
            this.editor.MaxLength = 0;
            this.editor.Multiline = true;
            this.editor.Name = "editor";
            this.editor.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.editor.Size = new System.Drawing.Size(600, 589);
            this.editor.TabIndex = 1;
            this.editor.WordWrap = false;
            this.editor.TextChanged += new System.EventHandler(this.editor_TextChanged);
            this.editor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.editor_KeyDown);
            this.editor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.editor_KeyUp);
            this.editor.MouseUp += new System.Windows.Forms.MouseEventHandler(this.editor_MouseUp);
            // 
            // hCode
            // 
            this.hCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(54)))), ((int)(((byte)(62)))));
            this.hCode.Dock = System.Windows.Forms.DockStyle.Top;
            this.hCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(170)))), ((int)(((byte)(100)))));
            this.hCode.Location = new System.Drawing.Point(0, 0);
            this.hCode.Name = "hCode";
            this.hCode.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.hCode.Size = new System.Drawing.Size(600, 20);
            this.hCode.TabIndex = 0;
            this.hCode.Text = "CODE (MS BASIC)";
            this.hCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // term
            // 
            this.term.AcceptsTab = true;
            this.term.BackColor = System.Drawing.Color.Black;
            this.term.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.term.ContextMenuStrip = this.termMenu;
            this.term.Dock = System.Windows.Forms.DockStyle.Fill;
            this.term.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.term.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(240)))), ((int)(((byte)(130)))));
            this.term.Location = new System.Drawing.Point(0, 20);
            this.term.MaxLength = 0;
            this.term.Multiline = true;
            this.term.Name = "term";
            this.term.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.term.Size = new System.Drawing.Size(496, 589);
            this.term.TabIndex = 1;
            this.term.KeyDown += new System.Windows.Forms.KeyEventHandler(this.term_KeyDown);
            this.term.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.term_KeyPress);
            // 
            // termMenu
            // 
            this.termMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miCtxCopy,
            this.miCtxClear});
            this.termMenu.Name = "termMenu";
            this.termMenu.Size = new System.Drawing.Size(103, 48);
            // 
            // miCtxCopy
            // 
            this.miCtxCopy.Name = "miCtxCopy";
            this.miCtxCopy.Size = new System.Drawing.Size(102, 22);
            this.miCtxCopy.Text = "Copy";
            this.miCtxCopy.Click += new System.EventHandler(this.miCtxCopy_Click);
            // 
            // miCtxClear
            // 
            this.miCtxClear.Name = "miCtxClear";
            this.miCtxClear.Size = new System.Drawing.Size(102, 22);
            this.miCtxClear.Text = "Clear";
            this.miCtxClear.Click += new System.EventHandler(this.miCtxClear_Click);
            // 
            // hTerm
            // 
            this.hTerm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(54)))), ((int)(((byte)(62)))));
            this.hTerm.Dock = System.Windows.Forms.DockStyle.Top;
            this.hTerm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(170)))), ((int)(((byte)(100)))));
            this.hTerm.Location = new System.Drawing.Point(0, 0);
            this.hTerm.Name = "hTerm";
            this.hTerm.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.hTerm.Size = new System.Drawing.Size(496, 20);
            this.hTerm.TabIndex = 0;
            this.hTerm.Text = "TERMINAL (RS232) - click here and type";
            this.hTerm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // worker
            // 
            this.worker.WorkerReportsProgress = true;
            this.worker.WorkerSupportsCancellation = true;
            this.worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.worker_DoWork);
            this.worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.worker_ProgressChanged);
            this.worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.worker_RunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 680);
            this.Controls.Add(this.split);
            this.Controls.Add(this.toolbar);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.status);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menu;
            this.MinimumSize = new System.Drawing.Size(700, 450);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SunshineLink (Sun6502 Mini IDE & CMD)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.split.Panel1.ResumeLayout(false);
            this.split.Panel1.PerformLayout();
            this.split.Panel2.ResumeLayout(false);
            this.split.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split)).EndInit();
            this.split.ResumeLayout(false);
            this.termMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem mFile;
        private System.Windows.Forms.ToolStripMenuItem miFileNew;
        private System.Windows.Forms.ToolStripMenuItem miFileOpen;
        private System.Windows.Forms.ToolStripMenuItem miFileSave;
        private System.Windows.Forms.ToolStripMenuItem miFileSaveAs;
        private System.Windows.Forms.ToolStripSeparator sepFile;
        private System.Windows.Forms.ToolStripMenuItem miFileExit;
        private System.Windows.Forms.ToolStripMenuItem mOpt;
        private System.Windows.Forms.ToolStripMenuItem miAutoNum;
        private System.Windows.Forms.ToolStripMenuItem miUpper;
        private System.Windows.Forms.ToolStripMenuItem miNew;
        private System.Windows.Forms.ToolStripMenuItem miRun;
        private System.Windows.Forms.ToolStripSeparator sepOpt;
        private System.Windows.Forms.ToolStripMenuItem miCrNl;
        private System.Windows.Forms.ToolStripMenuItem miBsDel;
        private System.Windows.Forms.ToolStrip toolbar;
        private System.Windows.Forms.ToolStripLabel lblPortCap;
        private System.Windows.Forms.ToolStripComboBox cmbPort;
        private System.Windows.Forms.ToolStripLabel lblBaudCap;
        private System.Windows.Forms.ToolStripComboBox cmbBaud;
        private System.Windows.Forms.ToolStripComboBox cmbFlow;
        private System.Windows.Forms.ToolStripButton btnConnect;
        private System.Windows.Forms.ToolStripSeparator sep1;
        private System.Windows.Forms.ToolStripButton btnSend;
        private System.Windows.Forms.ToolStripButton btnSendSel;
        private System.Windows.Forms.ToolStripButton btnStop;
        private System.Windows.Forms.ToolStripButton btnBreak;
        private System.Windows.Forms.ToolStripSeparator sep2;
        private System.Windows.Forms.ToolStripLabel lblEolCap;
        private System.Windows.Forms.ToolStripComboBox cmbEol;
        private System.Windows.Forms.ToolStripLabel lblLineCap;
        private System.Windows.Forms.ToolStripTextBox txtLineDelay;
        private System.Windows.Forms.ToolStripLabel lblCharCap;
        private System.Windows.Forms.ToolStripTextBox txtCharDelay;
        private System.Windows.Forms.ToolStripSeparator sep3;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripStatusLabel lblConn;
        private System.Windows.Forms.ToolStripStatusLabel lblPos;
        private System.Windows.Forms.ToolStripStatusLabel lblSend;
        private System.Windows.Forms.ToolStripProgressBar bar;
        private System.Windows.Forms.SplitContainer split;
        private System.Windows.Forms.TextBox editor;
        private System.Windows.Forms.Label hCode;
        private System.Windows.Forms.TextBox term;
        private System.Windows.Forms.Label hTerm;
        private System.Windows.Forms.ContextMenuStrip termMenu;
        private System.Windows.Forms.ToolStripMenuItem miCtxCopy;
        private System.Windows.Forms.ToolStripMenuItem miCtxClear;
        private System.ComponentModel.BackgroundWorker worker;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miHelpBasic;
        private System.Windows.Forms.ToolStripMenuItem miHelpAbout;
    }
}
