namespace IOU_Helper
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newIourpgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runTestClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iOUHelperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iOUHelperChatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iOUSpreadsheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iOUChatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iOUForumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iOUWikiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.petAnalyzerFerretToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionCheckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startAutoClickerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.abilitesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hardRefreshAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.screenshotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideOverlayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveOverlayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpGuideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshStatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetStatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyStatsToClipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxKongUser = new System.Windows.Forms.TextBox();
            this.groupBoxAccount = new System.Windows.Forms.GroupBox();
            this.textBoxKongToken = new System.Windows.Forms.TextBox();
            this.textBoxKongID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonStartClient = new System.Windows.Forms.Button();
            this.IOUtitle = new System.Windows.Forms.Label();
            this.AutoSave = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.startAutoClickerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.autoClickTimer = new System.Windows.Forms.Timer(this.components);
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.IOUclient = new WebKit.WebKitBrowser();
            this.abilityTimer = new System.Windows.Forms.Timer(this.components);
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.timerProStats = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.groupBoxAccount.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.linksToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.proToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1264, 52);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTabToolStripMenuItem,
            this.newIourpgToolStripMenuItem,
            this.runTestClientToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(75, 48);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newTabToolStripMenuItem
            // 
            this.newTabToolStripMenuItem.Name = "newTabToolStripMenuItem";
            this.newTabToolStripMenuItem.Size = new System.Drawing.Size(366, 46);
            this.newTabToolStripMenuItem.Text = "New";
            this.newTabToolStripMenuItem.Click += new System.EventHandler(this.newTabToolStripMenuItem_Click);
            // 
            // newIourpgToolStripMenuItem
            // 
            this.newIourpgToolStripMenuItem.Name = "newIourpgToolStripMenuItem";
            this.newIourpgToolStripMenuItem.Size = new System.Drawing.Size(366, 46);
            this.newIourpgToolStripMenuItem.Text = "Run IOURPG.com";
            this.newIourpgToolStripMenuItem.Click += new System.EventHandler(this.newIourpgToolStripMenuItem_Click);
            // 
            // runTestClientToolStripMenuItem
            // 
            this.runTestClientToolStripMenuItem.Name = "runTestClientToolStripMenuItem";
            this.runTestClientToolStripMenuItem.Size = new System.Drawing.Size(366, 46);
            this.runTestClientToolStripMenuItem.Text = "Run Test Client";
            this.runTestClientToolStripMenuItem.Click += new System.EventHandler(this.runTestClientToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(366, 46);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(366, 46);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(366, 46);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(363, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(366, 46);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(137, 48);
            this.optionsToolStripMenuItem.Text = "Settings";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // linksToolStripMenuItem
            // 
            this.linksToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iOUHelperToolStripMenuItem,
            this.iOUHelperChatToolStripMenuItem,
            this.iOUSpreadsheetToolStripMenuItem,
            this.iOUChatToolStripMenuItem,
            this.iOUForumToolStripMenuItem,
            this.iOUWikiToolStripMenuItem,
            this.petAnalyzerFerretToolStripMenuItem,
            this.versionCheckToolStripMenuItem});
            this.linksToolStripMenuItem.Name = "linksToolStripMenuItem";
            this.linksToolStripMenuItem.Size = new System.Drawing.Size(96, 48);
            this.linksToolStripMenuItem.Text = "Links";
            // 
            // iOUHelperToolStripMenuItem
            // 
            this.iOUHelperToolStripMenuItem.Name = "iOUHelperToolStripMenuItem";
            this.iOUHelperToolStripMenuItem.Size = new System.Drawing.Size(409, 46);
            this.iOUHelperToolStripMenuItem.Text = "IOU Helper";
            this.iOUHelperToolStripMenuItem.Click += new System.EventHandler(this.iOUHelperToolStripMenuItem_Click);
            // 
            // iOUHelperChatToolStripMenuItem
            // 
            this.iOUHelperChatToolStripMenuItem.Name = "iOUHelperChatToolStripMenuItem";
            this.iOUHelperChatToolStripMenuItem.Size = new System.Drawing.Size(409, 46);
            this.iOUHelperChatToolStripMenuItem.Text = "IOU Helper Chat";
            this.iOUHelperChatToolStripMenuItem.Click += new System.EventHandler(this.iOUHelperChatToolStripMenuItem_Click);
            // 
            // iOUSpreadsheetToolStripMenuItem
            // 
            this.iOUSpreadsheetToolStripMenuItem.Name = "iOUSpreadsheetToolStripMenuItem";
            this.iOUSpreadsheetToolStripMenuItem.Size = new System.Drawing.Size(409, 46);
            this.iOUSpreadsheetToolStripMenuItem.Text = "Pad/Zilla\'s Sheet";
            this.iOUSpreadsheetToolStripMenuItem.Click += new System.EventHandler(this.iOUSpreadsheetToolStripMenuItem_Click);
            // 
            // iOUChatToolStripMenuItem
            // 
            this.iOUChatToolStripMenuItem.Name = "iOUChatToolStripMenuItem";
            this.iOUChatToolStripMenuItem.Size = new System.Drawing.Size(409, 46);
            this.iOUChatToolStripMenuItem.Text = "IOU Chat";
            this.iOUChatToolStripMenuItem.Click += new System.EventHandler(this.iOUChatToolStripMenuItem_Click);
            // 
            // iOUForumToolStripMenuItem
            // 
            this.iOUForumToolStripMenuItem.Name = "iOUForumToolStripMenuItem";
            this.iOUForumToolStripMenuItem.Size = new System.Drawing.Size(409, 46);
            this.iOUForumToolStripMenuItem.Text = "IOU Forum";
            this.iOUForumToolStripMenuItem.Click += new System.EventHandler(this.iOUForumToolStripMenuItem_Click);
            // 
            // iOUWikiToolStripMenuItem
            // 
            this.iOUWikiToolStripMenuItem.Name = "iOUWikiToolStripMenuItem";
            this.iOUWikiToolStripMenuItem.Size = new System.Drawing.Size(409, 46);
            this.iOUWikiToolStripMenuItem.Text = "IOU Wiki";
            this.iOUWikiToolStripMenuItem.Click += new System.EventHandler(this.iOUWikiToolStripMenuItem_Click);
            // 
            // petAnalyzerFerretToolStripMenuItem
            // 
            this.petAnalyzerFerretToolStripMenuItem.Name = "petAnalyzerFerretToolStripMenuItem";
            this.petAnalyzerFerretToolStripMenuItem.Size = new System.Drawing.Size(409, 46);
            this.petAnalyzerFerretToolStripMenuItem.Text = "Pet Analyzer (Indigo)";
            this.petAnalyzerFerretToolStripMenuItem.Click += new System.EventHandler(this.petAnalyzerFerretToolStripMenuItem_Click);
            // 
            // versionCheckToolStripMenuItem
            // 
            this.versionCheckToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("versionCheckToolStripMenuItem.Image")));
            this.versionCheckToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.versionCheckToolStripMenuItem.Name = "versionCheckToolStripMenuItem";
            this.versionCheckToolStripMenuItem.Size = new System.Drawing.Size(409, 46);
            this.versionCheckToolStripMenuItem.Text = "Version Check";
            this.versionCheckToolStripMenuItem.Click += new System.EventHandler(this.versionCheckToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startAutoClickerToolStripMenuItem1,
            this.abilitesToolStripMenuItem,
            this.refreshToolStripMenuItem1,
            this.refreshAllToolStripMenuItem,
            this.hardRefreshAllToolStripMenuItem,
            this.timersToolStripMenuItem,
            this.screenshotToolStripMenuItem,
            this.closeTabToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(102, 48);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // startAutoClickerToolStripMenuItem1
            // 
            this.startAutoClickerToolStripMenuItem1.Name = "startAutoClickerToolStripMenuItem1";
            this.startAutoClickerToolStripMenuItem1.Size = new System.Drawing.Size(411, 46);
            this.startAutoClickerToolStripMenuItem1.Text = "Start AutoClicker (F1)";
            this.startAutoClickerToolStripMenuItem1.Click += new System.EventHandler(this.startAutoClickerToolStripMenuItem1_Click);
            // 
            // abilitesToolStripMenuItem
            // 
            this.abilitesToolStripMenuItem.Name = "abilitesToolStripMenuItem";
            this.abilitesToolStripMenuItem.Size = new System.Drawing.Size(411, 46);
            this.abilitesToolStripMenuItem.Text = "Start Abilities (F3)";
            this.abilitesToolStripMenuItem.Click += new System.EventHandler(this.abilitesToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem1
            // 
            this.refreshToolStripMenuItem1.Name = "refreshToolStripMenuItem1";
            this.refreshToolStripMenuItem1.Size = new System.Drawing.Size(411, 46);
            this.refreshToolStripMenuItem1.Text = "Refresh (F5)";
            this.refreshToolStripMenuItem1.Click += new System.EventHandler(this.refreshToolStripMenuItem1_Click);
            // 
            // refreshAllToolStripMenuItem
            // 
            this.refreshAllToolStripMenuItem.Name = "refreshAllToolStripMenuItem";
            this.refreshAllToolStripMenuItem.Size = new System.Drawing.Size(411, 46);
            this.refreshAllToolStripMenuItem.Text = "Refresh All (F6)";
            this.refreshAllToolStripMenuItem.Click += new System.EventHandler(this.refreshAllToolStripMenuItem_Click);
            // 
            // hardRefreshAllToolStripMenuItem
            // 
            this.hardRefreshAllToolStripMenuItem.Name = "hardRefreshAllToolStripMenuItem";
            this.hardRefreshAllToolStripMenuItem.Size = new System.Drawing.Size(411, 46);
            this.hardRefreshAllToolStripMenuItem.Text = "Hard Refresh All";
            this.hardRefreshAllToolStripMenuItem.Click += new System.EventHandler(this.hardRefreshAllToolStripMenuItem_Click);
            // 
            // timersToolStripMenuItem
            // 
            this.timersToolStripMenuItem.Name = "timersToolStripMenuItem";
            this.timersToolStripMenuItem.Size = new System.Drawing.Size(411, 46);
            this.timersToolStripMenuItem.Text = "Timers";
            this.timersToolStripMenuItem.Click += new System.EventHandler(this.timersToolStripMenuItem_Click);
            // 
            // screenshotToolStripMenuItem
            // 
            this.screenshotToolStripMenuItem.Name = "screenshotToolStripMenuItem";
            this.screenshotToolStripMenuItem.Size = new System.Drawing.Size(411, 46);
            this.screenshotToolStripMenuItem.Text = "Take Screenshot (F7)";
            this.screenshotToolStripMenuItem.Click += new System.EventHandler(this.screenshotToolStripMenuItem_Click);
            // 
            // closeTabToolStripMenuItem
            // 
            this.closeTabToolStripMenuItem.Name = "closeTabToolStripMenuItem";
            this.closeTabToolStripMenuItem.Size = new System.Drawing.Size(411, 46);
            this.closeTabToolStripMenuItem.Text = "Close Tab (F8)";
            this.closeTabToolStripMenuItem.Click += new System.EventHandler(this.closeTabToolStripMenuItem_Click);
            // 
            // proToolStripMenuItem
            // 
            this.proToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.proSettingsToolStripMenuItem,
            this.hideOverlayToolStripMenuItem,
            this.hideConsoleToolStripMenuItem,
            this.moveOverlayToolStripMenuItem,
            this.helpGuideToolStripMenuItem,
            this.refreshStatsToolStripMenuItem,
            this.resetStatsToolStripMenuItem,
            this.copyStatsToClipToolStripMenuItem});
            this.proToolStripMenuItem.Name = "proToolStripMenuItem";
            this.proToolStripMenuItem.Size = new System.Drawing.Size(195, 48);
            this.proToolStripMenuItem.Text = "Pro Features";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("startToolStripMenuItem.Image")));
            this.startToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(327, 46);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // proSettingsToolStripMenuItem
            // 
            this.proSettingsToolStripMenuItem.Name = "proSettingsToolStripMenuItem";
            this.proSettingsToolStripMenuItem.Size = new System.Drawing.Size(327, 46);
            this.proSettingsToolStripMenuItem.Text = "Pro Settings";
            this.proSettingsToolStripMenuItem.Click += new System.EventHandler(this.proSettingsToolStripMenuItem_Click);
            // 
            // hideOverlayToolStripMenuItem
            // 
            this.hideOverlayToolStripMenuItem.Name = "hideOverlayToolStripMenuItem";
            this.hideOverlayToolStripMenuItem.Size = new System.Drawing.Size(327, 46);
            this.hideOverlayToolStripMenuItem.Text = "Hide Overlay";
            this.hideOverlayToolStripMenuItem.Click += new System.EventHandler(this.hideOverlayToolStripMenuItem_Click);
            // 
            // hideConsoleToolStripMenuItem
            // 
            this.hideConsoleToolStripMenuItem.Name = "hideConsoleToolStripMenuItem";
            this.hideConsoleToolStripMenuItem.Size = new System.Drawing.Size(327, 46);
            this.hideConsoleToolStripMenuItem.Text = "Show Console";
            this.hideConsoleToolStripMenuItem.Click += new System.EventHandler(this.hideConsoleToolStripMenuItem_Click);
            // 
            // moveOverlayToolStripMenuItem
            // 
            this.moveOverlayToolStripMenuItem.Name = "moveOverlayToolStripMenuItem";
            this.moveOverlayToolStripMenuItem.Size = new System.Drawing.Size(327, 46);
            this.moveOverlayToolStripMenuItem.Text = "Move Overlay";
            this.moveOverlayToolStripMenuItem.Click += new System.EventHandler(this.moveOverlayToolStripMenuItem_Click);
            // 
            // helpGuideToolStripMenuItem
            // 
            this.helpGuideToolStripMenuItem.Name = "helpGuideToolStripMenuItem";
            this.helpGuideToolStripMenuItem.Size = new System.Drawing.Size(327, 46);
            this.helpGuideToolStripMenuItem.Text = "Help Guide";
            // 
            // refreshStatsToolStripMenuItem
            // 
            this.refreshStatsToolStripMenuItem.Name = "refreshStatsToolStripMenuItem";
            this.refreshStatsToolStripMenuItem.Size = new System.Drawing.Size(327, 46);
            this.refreshStatsToolStripMenuItem.Text = "Refresh Stats";
            this.refreshStatsToolStripMenuItem.Click += new System.EventHandler(this.refreshStatsToolStripMenuItem_Click);
            // 
            // resetStatsToolStripMenuItem
            // 
            this.resetStatsToolStripMenuItem.Name = "resetStatsToolStripMenuItem";
            this.resetStatsToolStripMenuItem.Size = new System.Drawing.Size(327, 46);
            this.resetStatsToolStripMenuItem.Text = "Reset Stats";
            this.resetStatsToolStripMenuItem.Click += new System.EventHandler(this.resetStatsToolStripMenuItem_Click);
            // 
            // copyStatsToClipToolStripMenuItem
            // 
            this.copyStatsToClipToolStripMenuItem.Name = "copyStatsToClipToolStripMenuItem";
            this.copyStatsToClipToolStripMenuItem.Size = new System.Drawing.Size(327, 46);
            this.copyStatsToClipToolStripMenuItem.Text = "Copy Stats";
            this.copyStatsToClipToolStripMenuItem.Click += new System.EventHandler(this.copyStatsToClipToolStripMenuItem_Click);
            // 
            // textBoxKongUser
            // 
            this.textBoxKongUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.textBoxKongUser.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.textBoxKongUser.Location = new System.Drawing.Point(412, 87);
            this.textBoxKongUser.Name = "textBoxKongUser";
            this.textBoxKongUser.Size = new System.Drawing.Size(432, 38);
            this.textBoxKongUser.TabIndex = 2;
            // 
            // groupBoxAccount
            // 
            this.groupBoxAccount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBoxAccount.Controls.Add(this.textBoxKongToken);
            this.groupBoxAccount.Controls.Add(this.textBoxKongID);
            this.groupBoxAccount.Controls.Add(this.label3);
            this.groupBoxAccount.Controls.Add(this.label2);
            this.groupBoxAccount.Controls.Add(this.label1);
            this.groupBoxAccount.Controls.Add(this.textBoxKongUser);
            this.groupBoxAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.groupBoxAccount.Location = new System.Drawing.Point(182, 190);
            this.groupBoxAccount.Name = "groupBoxAccount";
            this.groupBoxAccount.Size = new System.Drawing.Size(910, 326);
            this.groupBoxAccount.TabIndex = 3;
            this.groupBoxAccount.TabStop = false;
            this.groupBoxAccount.Text = "Account Details";
            // 
            // textBoxKongToken
            // 
            this.textBoxKongToken.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.textBoxKongToken.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.textBoxKongToken.Location = new System.Drawing.Point(412, 215);
            this.textBoxKongToken.Name = "textBoxKongToken";
            this.textBoxKongToken.Size = new System.Drawing.Size(432, 38);
            this.textBoxKongToken.TabIndex = 7;
            // 
            // textBoxKongID
            // 
            this.textBoxKongID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.textBoxKongID.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.textBoxKongID.Location = new System.Drawing.Point(412, 151);
            this.textBoxKongID.Name = "textBoxKongID";
            this.textBoxKongID.Size = new System.Drawing.Size(432, 38);
            this.textBoxKongID.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.label3.Location = new System.Drawing.Point(32, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(264, 32);
            this.label3.TabIndex = 5;
            this.label3.Text = "Kongregate Token :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.label2.Location = new System.Drawing.Point(32, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "Kongregate ID : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.label1.Location = new System.Drawing.Point(32, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(322, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Kongregate Username : ";
            // 
            // buttonStartClient
            // 
            this.buttonStartClient.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonStartClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.buttonStartClient.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.buttonStartClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStartClient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.buttonStartClient.Location = new System.Drawing.Point(407, 593);
            this.buttonStartClient.Name = "buttonStartClient";
            this.buttonStartClient.Size = new System.Drawing.Size(495, 143);
            this.buttonStartClient.TabIndex = 4;
            this.buttonStartClient.Text = "Start Client";
            this.buttonStartClient.UseVisualStyleBackColor = false;
            this.buttonStartClient.Click += new System.EventHandler(this.buttonStartClient_Click);
            // 
            // IOUtitle
            // 
            this.IOUtitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.IOUtitle.AutoSize = true;
            this.IOUtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IOUtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.IOUtitle.Location = new System.Drawing.Point(389, 50);
            this.IOUtitle.Name = "IOUtitle";
            this.IOUtitle.Size = new System.Drawing.Size(510, 105);
            this.IOUtitle.TabIndex = 5;
            this.IOUtitle.Text = "IOU Helper";
            // 
            // AutoSave
            // 
            this.AutoSave.FileName = "openFileDialog1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startAutoClickerToolStripMenuItem,
            this.refreshToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextMenuStrip1.Size = new System.Drawing.Size(355, 96);
            // 
            // startAutoClickerToolStripMenuItem
            // 
            this.startAutoClickerToolStripMenuItem.Name = "startAutoClickerToolStripMenuItem";
            this.startAutoClickerToolStripMenuItem.Size = new System.Drawing.Size(354, 46);
            this.startAutoClickerToolStripMenuItem.Text = "Start AutoClicker";
            this.startAutoClickerToolStripMenuItem.Click += new System.EventHandler(this.startAutoClickerToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(354, 46);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // refreshTimer
            // 
            this.refreshTimer.Interval = 1800;
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // autoClickTimer
            // 
            this.autoClickTimer.Tick += new System.EventHandler(this.autoClickTimer_Tick);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Location = new System.Drawing.Point(0, 52);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1274, 881);
            this.tabControl.TabIndex = 7;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.tabPage1.Controls.Add(this.IOUclient);
            this.tabPage1.Controls.Add(this.IOUtitle);
            this.tabPage1.Controls.Add(this.buttonStartClient);
            this.tabPage1.Controls.Add(this.groupBoxAccount);
            this.tabPage1.Location = new System.Drawing.Point(4, 40);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1266, 837);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Client";
            // 
            // IOUclient
            // 
            this.IOUclient.BackColor = System.Drawing.Color.White;
            this.IOUclient.Location = new System.Drawing.Point(-4, 0);
            this.IOUclient.Name = "IOUclient";
            this.IOUclient.Size = new System.Drawing.Size(305, 214);
            this.IOUclient.TabIndex = 7;
            this.IOUclient.Url = null;
            this.IOUclient.Visible = false;
            this.IOUclient.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.IOUclient_DocumentCompleted);
            this.IOUclient.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.IOUclient_Navigated);
            // 
            // abilityTimer
            // 
            this.abilityTimer.Tick += new System.EventHandler(this.abilityTimer_Tick);
            // 
            // timerProStats
            // 
            this.timerProStats.Interval = 30000;
            this.timerProStats.Tick += new System.EventHandler(this.timerProStats_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(1264, 926);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IOU Helper v1.0 - Pro";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBoxAccount.ResumeLayout(false);
            this.groupBoxAccount.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iOUHelperToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iOUForumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iOUChatToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxKongUser;
        private System.Windows.Forms.GroupBox groupBoxAccount;
        private System.Windows.Forms.TextBox textBoxKongToken;
        private System.Windows.Forms.TextBox textBoxKongID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonStartClient;
        private System.Windows.Forms.Label IOUtitle;
        private System.Windows.Forms.OpenFileDialog AutoSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem iOUWikiToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem startAutoClickerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem startAutoClickerToolStripMenuItem1;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.Timer autoClickTimer;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ToolStripMenuItem newTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeTabToolStripMenuItem;
        private WebKit.WebKitBrowser IOUclient;
        private System.Windows.Forms.ToolStripMenuItem iOUSpreadsheetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abilitesToolStripMenuItem;
        private System.Windows.Forms.Timer abilityTimer;
        private System.Windows.Forms.ToolStripMenuItem refreshAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem screenshotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iOUHelperChatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem petAnalyzerFerretToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newIourpgToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versionCheckToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hardRefreshAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runTestClientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpGuideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideOverlayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideConsoleToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripMenuItem moveOverlayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshStatsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetStatsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyStatsToClipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proSettingsToolStripMenuItem;
        private System.Windows.Forms.Timer timerProStats;
    }
}

