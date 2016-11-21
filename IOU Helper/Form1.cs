using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Timers;

namespace IOU_Helper
{
    public partial class Form1 : Form
    {
        // import the necessary API function so .NET can
        // marshall parameters appropriately
        // For auto clicker
        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        //Current version number
        private string version = "1.0";
        private string check = "";

        //Single Overlay
        Plexiglass overlay;

        // constants for the mouse_input() API function
        private const int MOUSEEVENTF_MOVE = 0x0001;
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const int MOUSEEVENTF_RIGHTUP = 0x0010;
        private const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        private const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        private const int MOUSEEVENTF_ABSOLUTE = 0x8000;

        List<Tab> tabList = new List<Tab>();
        List<Tab> testTabList = new List<Tab>();
        List<Tab> IOURPGtabList = new List<Tab>();
        List<TextBox> textboxes = new List<TextBox>();
        public Dictionary<System.Timers.Timer, Tab> timerDictionary = new Dictionary<System.Timers.Timer, Tab>();
        
        public int tabNumber = 1;
        private string size = "medium";
        WebKit.WebKitBrowser browser = new WebKit.WebKitBrowser();
        Label tempLabel;
        GroupBox tempBox;
        Button tempButton;

        //Global Variables
        private string kongUsername;
        private string code;
        private string gameVersion;
        private int tabSmallWidth = 596;
        private int tabSmallHeight = 493;
        private int iouSmallHeight = 468;
        private int iouSmallWidth = 589;
        private int formSmallWidth = 613;
        private int formSmallHeight = 537;

        private int tabMediumWidth = 746;
        private int tabMediumHeight = 600;
        private int iouMediumHeight = 570;
        private int iouMediumWidth = 736;
        private int formMediumWidth = 758;
        private int formMediumHeight = 652;

        private int tabLargeWidth = 922;
        private int tabLargeHeight = 740;
        private int iouLargeHeight = 715;
        private int iouLargeWidth = 920;
        private int formLargeWidth = 939;
        private int formLargeHeight = 795;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load the Account Details from a CSV File
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string FILTER = "CSV Files|*.csv|TXT FILES|*.txt|All Files|*.*";
            string[] lineRead = null;
            string lineReadFull = "";

            AutoSave.Filter = FILTER;

            if (AutoSave.ShowDialog() == DialogResult.OK)
            {

                try
                {
                    StreamReader reader = File.OpenText(AutoSave.FileName);

                    while (!reader.EndOfStream)
                    {
                        lineReadFull = reader.ReadLine();
                        lineRead = lineReadFull.Split(',');

                        try
                        {
                            for (int i = 0; i < lineRead.Length - 2; i++)
                            {
                                //Set the textboxes equal to data
                                if (lineRead[i] != null)
                                {
                                    kongUsername = lineRead[i];
                                    textBoxKongUser.Text = lineRead[i];
                                    i++;
                                }
                                if (lineRead[i] != null)
                                {
                                    textBoxKongID.Text = lineRead[i];
                                    i++;
                                }
                                if (lineRead[i] != null)
                                {
                                    textBoxKongToken.Text = lineRead[i];
                                }
                                if (tabPage1.Text == "Client")
                                {
                                    Tab tab = new Tab(lineRead[i - 2], lineRead[i - 1], lineRead[i], IOUclient);
                                    //Set the IOU Client to its approiate sizing
                                    setClient(tabControl, IOUclient);
                                    updateClient(tab);
                                    tabList.Add(tab);
                                }

                                else
                                {
                                    string title = "TabPage " + (tabControl.TabCount + 1).ToString();
                                    TabPage myTabPage = new TabPage(title);
                                    tabControl.TabPages.Add(myTabPage);
                                    myTabPage.Text = kongUsername;
                                    myTabPage.Name = title;
                                    tabControl.SelectedTab = myTabPage;
                                    WebKit.WebKitBrowser IOUclient2 = new WebKit.WebKitBrowser();
                                    IOUclient2.Navigated += IOUclient2_Navigated;
                                    IOUclient2.DocumentCompleted += IOUclient2_DocumentCompleted;
                                    myTabPage.Controls.Add(IOUclient2);
                                    Tab tab = new Tab(lineRead[i - 2], lineRead[i - 1], lineRead[i], IOUclient2);
                                    //Set the IOU Client to its approiate sizing
                                    setClient(tabControl, IOUclient2);
                                    //Update the client
                                    updateClient(tab);
                                    tabList.Add(tab);
                                }
                            }                        
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                    reader.Close();
                }
                catch (FileNotFoundException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void setClient(TabControl tabControl, WebKit.WebKitBrowser IOUclient)
        {
            if (size == "small")
            {
                tabControl.Width = tabSmallWidth;
                tabControl.Height = tabSmallHeight;
                IOUclient.Height = iouSmallHeight;
                IOUclient.Width = iouSmallWidth;
                this.Width = formSmallWidth;
                this.Height = formSmallHeight;
                IOUclient.Location = new Point(0, 0);
            }
            else if (size == "medium")
            {
                tabControl.Width = tabMediumWidth;
                tabControl.Height = tabMediumHeight;
                IOUclient.Height = iouMediumHeight;
                IOUclient.Width = iouMediumWidth;
                this.Width = formMediumWidth;
                this.Height = formMediumHeight;

                IOUclient.Location = new Point(0, 0);
            }
            else if (size == "large")
            {
                tabControl.Width = tabLargeWidth;
                tabControl.Height = tabLargeHeight;
                IOUclient.Height = iouLargeHeight;
                IOUclient.Width = iouLargeWidth;
                this.Width = formLargeWidth;
                this.Height = formLargeHeight;
                IOUclient.Location = new Point(0, 0);
            }
        }

        /// <summary>
        /// Run the IOU Client
        /// </summary>
        public void updateClient(Tab tab)
        {
            if (tabControl.SelectedTab.Text == "Client")
            {
                tabControl.SelectedTab.Text = tab.getUsername();
            }
            //Take out all other form elements
            IOUtitle.Visible = false;
            groupBoxAccount.Visible = false;
            buttonStartClient.Visible = false;

            tab.getClient().Visible = true;
            try
            {
                tab.getClient().Url = tab.URL();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }         
        }

        /// <summary>
        /// Save the current account details to the Auto Save file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveDetails(true);
        }

        /// <summary>
        /// Saves the details into the AutoSave CSV
        /// </summary>
        public void saveDetails(Boolean message) {
            try
            {
                string details = "";
                foreach (Tab tab in tabList)
                {
                    details = details + tab.ToString() + ",";
                }
                StreamWriter writer = File.CreateText(Application.StartupPath + @"\AutoSave.CSV");
                writer.WriteLine(details);
                writer.Close();
                if (message == true)
                {
                    MessageBox.Show("Your account/s details have been saved to the AutoSave.CSV File.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Save a new CSV including the current Account Details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string FILTER = "CSV Files|*.csv|All Files|*.*";
            saveFileDialog1.Filter = FILTER;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamWriter writer = File.CreateText(saveFileDialog1.FileName);
                    string details = "";
                    foreach (Tab tab in tabList)
                    {
                        details = details + tab.ToString() + ",";
                    }

                    writer.WriteLine(details);
                    writer.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        /// <summary>
        /// Run the IOU Client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStartClient_Click(object sender, EventArgs e)
        {
            if (textBoxKongUser.Text != "" && textBoxKongID.Text != "" && textBoxKongToken.Text != "")
            {
                Tab tab = new Tab(textBoxKongUser.Text, textBoxKongID.Text, textBoxKongToken.Text, IOUclient);
                this.Size = new Size(iouMediumWidth, 538);
                //Set the IOU Client to its approiate sizing
                setClient(tabControl, IOUclient);
                updateClient(tab);
                tabList.Add(tab);
                saveDetails(true);
            }
            else
            {
                MessageBox.Show("Please fill out the textboxes provided.");
            }
        }

        /// <summary>
        /// Close the client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// On Form Load, check if AutoSave has data, if so run client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //Form Settings
            //this.FormBorderStyle = FormBorderStyle.FixedSingle; <--- Makes not resizeable
            tabControl.Width = this.Width;
            tabControl.Height = this.Height;

            overlay = new Plexiglass(this);
            timerProStats.Interval = Properties.Settings.Default.refreshTimer;

            string[] lineRead = null;
            string lineReadFull = "";

            try
            {
                //Download the iou client code online
                System.Net.WebClient wc = new System.Net.WebClient();
                try
                {
                    string rawCode = wc.DownloadString("http://www.kongregate.com/games/iouRPG/idle-online-universe");
                    string[] codeWords = rawCode.Split(new string[] { "FAPI_AS3_", ".swf" }, StringSplitOptions.None);
                    string[] gameWords = rawCode.Split(new string[] {"kongregate_game_version=", "\";" }, StringSplitOptions.None);

                    string raw = wc.DownloadString("http://iouhelper.com/procode.html");
                    string[] words = raw.Split('|');

                    code = codeWords[3];
                    gameVersion = gameWords[8];
                    Tab.setCodes(code, gameVersion);
                    check = words[2];
                    //UPDATE CHECKER
                    if (check != version)
                    {
                        Image red = Image.FromFile("imgs/red.jpg");
                        versionCheckToolStripMenuItem.Image = red;
                    }
                }
                catch
                {
                    MessageBox.Show("Cannot load the current IOU version code from http://www.iouhelper.com/code.html");
                    this.Close();
                }

                StreamReader reader = File.OpenText(Application.StartupPath + @"\SaveSettings.CSV");

                while (!reader.EndOfStream)
                {
                    lineReadFull = reader.ReadLine();
                    lineRead = lineReadFull.Split(',');

                    try
                    {
                        if (lineRead[0] != null)
                        {
                            if (lineRead[0] == "small") {
                                size = "small";
                            }
                            else if (lineRead[0] == "large") {
                                size = "large";
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                       
                    }
                }

                reader.Close();
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            try
            {
                StreamReader reader = File.OpenText(Application.StartupPath + @"\AutoSave.CSV");

                while (!reader.EndOfStream)
                {
                    lineReadFull = reader.ReadLine();
                    lineRead = lineReadFull.Split(',');

                        try
                        {
                             for (int i = 0; i < lineRead.Length - 2; i++)
                            {
                                //Set the textboxes equal to data
                                if (lineRead[i] != null)
                                {
                                    kongUsername = lineRead[i];
                                    i++;
                                }
                                if (lineRead[i] != null)
                                {
                                    i++;
                                }
                                if (lineRead[i] != null)
                                {
                                }
                                if (tabPage1.Text == "Client")
                                {
                                    Tab tab = new Tab(lineRead[i - 2], lineRead[i - 1], lineRead[i], IOUclient);
                                    //Set the IOU Client to its approiate sizing
                                    setClient(tabControl, IOUclient);
                                    updateClient(tab);
                                    tabList.Add(tab);
                                }

                                else
                                {
                                    string title = "TabPage " + (tabControl.TabCount + 1).ToString();
                                    TabPage myTabPage = new TabPage(title);
                                    tabControl.TabPages.Add(myTabPage);
                                    myTabPage.Text = kongUsername;
                                    myTabPage.Name = title;
                                    tabControl.SelectedTab = myTabPage;
                                    WebKit.WebKitBrowser IOUclient2 = new WebKit.WebKitBrowser();
                                    IOUclient2.Navigated += IOUclient2_Navigated;
                                    IOUclient2.DocumentCompleted += IOUclient2_DocumentCompleted;
                                    myTabPage.Controls.Add(IOUclient2);
                                    Tab tab = new Tab(lineRead[i - 2], lineRead[i - 1], lineRead[i], IOUclient2);
                                    //Set the IOU Client to its approiate sizing
                                    setClient(tabControl, IOUclient2);
                                    //Update the client
                                    updateClient(tab);
                                    tabList.Add(tab);
                                }
                            }                        
                        }
                        catch (Exception ex)
                        {
                            //MessageBox.Show(ex.ToString());
                        }
                    }

                reader.Close();
            }
            catch (FileNotFoundException ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Links to different URL's 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iOUHelperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.iouhelper.com/");
        }

        private void iOUChatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://discordapp.com/channels/14600738tabMediumWidth6235905/14600738tabMediumWidth6235905");
        }

        private void iOUForumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://iourpg.com/forum/");
        }

        private void iOUWikiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://iourpg.wikia.com/wiki/Idle_Online_Universe_Wiki");
        }


        private void startAutoClickerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("hi");
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateClient(tabList[tabNumber - 1]);
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settingsForm = new Settings(this);
            settingsForm.Show();
        }

        private void refreshToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            singleRefresh();
        }

        private void singleRefresh()
        {
            if (tabControl.SelectedTab.Text == "IOURPG")
            {
                foreach (Tab tab in IOURPGtabList)
                {
                    if (tabControl.SelectedTab == tab.getTabPage())
                    {
                        if (tab.getIsTest() == true)
                        {
                            tab.reloadTestIOURPG();
                        }
                        else
                        {
                            tab.reloadIOURPG();
                        }
                    }
                }
            }
            else if (tabList.Count > 0 && tabControl.SelectedTab.Text != "Client")
            {
                string username;
                string tabUser = tabControl.SelectedTab.Text;
                Boolean found = false;

                try
                {
                    foreach (Tab tab in tabList)
                    {
                        username = tab.getUsername();
                        if (username == tabUser)
                        {
                            updateClient(tab);
                            found = true;
                            break;
                        }
                    }
                    if (found == false)
                    {
                        foreach (Tab tab in testTabList)
                        {
                            username = tab.getUsername() + " test";
                            if (username == tabUser)
                            {
                                tab.getClient().Url = tab.getTestURL();
                                break;
                            }
                        }
                    }                
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        /// <summary>
        /// Start AutoClicker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startAutoClickerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (autoClickTimer.Enabled == false) {
                autoClickTimer.Enabled = true;
                startAutoClickerToolStripMenuItem1.Text = "Stop AutoClicker (F2)";
            }
            else if (autoClickTimer.Enabled == true)
            {
                autoClickTimer.Enabled = false;
                startAutoClickerToolStripMenuItem1.Text = "Start AutoClicker (F1)";
            }
        }

        public void enableTimer(int milSeconds, bool isEnabled)
        {
            try
            {
                refreshTimer.Interval = milSeconds;
                refreshTimer.Enabled = isEnabled;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            refreshAll();
        }

        /// <summary>
        /// simulates a click-and-release action of the left mouse
        /// button at its current position
        /// </summary>
        public static void LeftClick()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, Control.MousePosition.X, Control.MousePosition.Y, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, Control.MousePosition.X, Control.MousePosition.Y, 0, 0);
        }

        private void autoClickTimer_Tick(object sender, EventArgs e)
        {
            LeftClick();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if ((keyData == Keys.F1) && (autoClickTimer.Enabled == false))
            {
                autoClickTimer.Enabled = true;
                startAutoClickerToolStripMenuItem1.Text = "Stop AutoClicker (F2)";
                return true;
            }
            else if ((keyData == Keys.F2) && (autoClickTimer.Enabled == true))
            {
                autoClickTimer.Enabled = false;
                startAutoClickerToolStripMenuItem1.Text = "Start AutoClicker (F1)";
                return true;
            }
            else if (keyData == Keys.F3)
            {
                if (abilityTimer.Enabled == false)
                {
                    abilityTimer.Enabled = true;
                    abilitesToolStripMenuItem.Text = "Stop Abilities (F4)";
                }
                return true;
            }
            else if (keyData == Keys.F4)
            {
                if (abilityTimer.Enabled == true)
                {
                    abilityTimer.Enabled = false;
                    abilitesToolStripMenuItem.Text = "Start Abilities (F3)";
                }
                return true;
            }
            else if (keyData == Keys.F5)
            {
                singleRefresh();
                return true;
            }
            else if (keyData == Keys.F6)
            {
                refreshAll();
                return true;
            }
            else if (keyData == Keys.F7) {
                captureScreenshot();
                return true;
            }
            else if (keyData == Keys.F8)
            {
                closeTab();
                return true;
            }
            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void autoClicker(int milSeconds)
        {
            try
            {
                autoClickTimer.Interval = milSeconds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void newTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (TabPage page in tabControl.TabPages)
            {
                if (page.Text.Equals("Client"))
                {
                    tabControl.SelectedTab = page;
                    return;
                }
            }
            //Tab
            string title = "TabPage " + (tabControl.TabCount + 1).ToString();
            TabPage myTabPage = new TabPage(title);
            tabControl.TabPages.Add(myTabPage);
            myTabPage.Name = title;
            myTabPage.Text = "Client";
            tabControl.SelectedTab = myTabPage;
            myTabPage.BackColor = System.Drawing.ColorTranslator.FromHtml("#222222");

            int c = tabControl.TabCount;

            //Label          
            Label label = new Label();
            //label.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
            label.Location = new System.Drawing.Point(144, 17);
            label.Parent = myTabPage;
            label.Name = "IOUtitle" + c.ToString();
            label.Text = "IOU Helper";
            label.ForeColor = System.Drawing.ColorTranslator.FromHtml("#B92E2E");
            label.Size = new System.Drawing.Size(209, 44);
            label.Font = new Font("Microsoft Sans Serif", 28);
            myTabPage.Controls.Add(label);
            tempLabel = label;

            //GroupBox
            GroupBox groupBox = new GroupBox();
            //groupBox.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
            groupBox.Location = new System.Drawing.Point(66, 76);
            groupBox.Parent = myTabPage;
            groupBox.Name = "groupBoxAccount" + c.ToString();
            groupBox.Text = "Account Details";
            groupBox.ForeColor = System.Drawing.ColorTranslator.FromHtml("#B4B4B4");
            groupBox.Size = new System.Drawing.Size(341, 137);
            myTabPage.Controls.Add(groupBox);
            tempBox = groupBox;

            Label label1 = new Label();
            label1.Location = new System.Drawing.Point(12, 36);
            label1.Parent = myTabPage;
            label1.Name = "label1" + c.ToString();
            label1.Text = "Kongregate Username : ";
            label1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#B4B4B4");
            label1.Size = new System.Drawing.Size(122, 13);
            label1.Font = new Font("Microsoft Sans Serif", 8);
            groupBox.Controls.Add(label1);

            Label label2 = new Label();
            label2.Location = new System.Drawing.Point(12, 63);
            label2.Parent = myTabPage;
            label2.Name = "label2" + c.ToString();
            label2.Text = "Kongregate ID : ";
            label2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#B4B4B4");
            label2.Size = new System.Drawing.Size(85, 13);
            label2.Font = new Font("Microsoft Sans Serif", 8);
            groupBox.Controls.Add(label2);

            Label label3 = new Label();
            label3.Location = new System.Drawing.Point(12, 90);
            label3.Parent = myTabPage;
            label3.Name = "label3" + c.ToString();
            label3.Text = "Kongregate Token : ";
            label3.ForeColor = System.Drawing.ColorTranslator.FromHtml("#B4B4B4");
            label3.Size = new System.Drawing.Size(102, 13);
            label3.Font = new Font("Microsoft Sans Serif", 8);
            groupBox.Controls.Add(label3);

            TextBox textBox1 = new TextBox();
            textBox1.Location = new System.Drawing.Point(154, 36);
            textBox1.Parent = myTabPage;
            textBox1.Name = "textBoxKongUser" + c.ToString();
            textBox1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#B4B4B4");
            textBox1.BackColor = System.Drawing.ColorTranslator.FromHtml("#161616");
            textBox1.Size = new System.Drawing.Size(164, 20);
            textBox1.Font = new Font("Microsoft Sans Serif", 8);
            groupBox.Controls.Add(textBox1);
            textboxes.Add(textBox1);

            TextBox textBox2 = new TextBox();
            textBox2.Location = new System.Drawing.Point(154, 63);
            textBox2.Parent = myTabPage;
            textBox2.Name = "textBoxKongID" + c.ToString();
            textBox2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#B4B4B4");
            textBox2.BackColor = System.Drawing.ColorTranslator.FromHtml("#161616");
            textBox2.Size = new System.Drawing.Size(164, 20);
            textBox2.Font = new Font("Microsoft Sans Serif", 8);
            groupBox.Controls.Add(textBox2);
            textboxes.Add(textBox2);

            TextBox textBox3 = new TextBox();
            textBox3.Location = new System.Drawing.Point(154, 90);
            textBox3.Parent = myTabPage;
            textBox3.Name = "textBoxKongToken" + c.ToString();
            textBox3.ForeColor = System.Drawing.ColorTranslator.FromHtml("#B4B4B4");
            textBox3.BackColor = System.Drawing.ColorTranslator.FromHtml("#161616");
            textBox3.Size = new System.Drawing.Size(164, 20);
            textBox3.Font = new Font("Microsoft Sans Serif", 8);
            groupBox.Controls.Add(textBox3);
            textboxes.Add(textBox3);

            //Button
            Button button = new Button();
            //button.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
            button.Location = new System.Drawing.Point(151, 245);
            button.Parent = myTabPage;
            button.Name = "buttonStartClient" + c.ToString();
            button.Text = "Start Client";
            button.BackColor = System.Drawing.ColorTranslator.FromHtml("#161616");
            button.ForeColor = System.Drawing.ColorTranslator.FromHtml("#B4B4B4");
            button.Size = new System.Drawing.Size(186, 60);
            button.Font = new Font("Microsoft Sans Serif", 10);
            button.Click += new EventHandler(button_Click);
            tempButton = button;

            //Browser
            WebKit.WebKitBrowser IOUclient2 = new WebKit.WebKitBrowser();
            IOUclient2.Navigated += IOUclient2_Navigated;
            IOUclient2.DocumentCompleted += IOUclient2_DocumentCompleted;
            myTabPage.Controls.Add(IOUclient2);
            IOUclient2.Visible = false;

            if (this.Height == 642)
            {
                label.Location = new System.Drawing.Point(278, 123);
                groupBox.Location = new System.Drawing.Point(200, 182);
                button.Location = new System.Drawing.Point(285, 351);
            }
            browser = IOUclient2;

            myTabPage.Controls.Add(button);
        }

        protected void button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int tc = textboxes.Count();
            if ((textboxes[tc - 3].Text != "") && (textboxes[tc - 2].Text != "") && (textboxes[tc - 1].Text != ""))
            {

                if (tabList.Count >= 1)
                {
                    Tab tab = new Tab(textboxes[tc - 3].Text, textboxes[tc - 2].Text, textboxes[tc - 1].Text, browser);
                    tempLabel.Visible = false;
                    tempBox.Visible = false;
                    tempButton.Visible = false;
                    browser.Location = new Point(0, 0);

                    //Set the IOU Client to its approiate sizing
                    if (size == "small")
                    {
                        browser.Height = iouSmallHeight;
                        browser.Width = iouSmallWidth;
                    }
                    else if (size == "medium")
                    {
                        browser.Height = iouMediumHeight;
                        browser.Width = iouMediumWidth;
                    }
                    else if (size == "large")
                    {
                        browser.Height = iouLargeHeight;
                        browser.Width = iouLargeWidth;
                    }
                    //Update the client
                    updateClient(tab);
                    tabList.Add(tab);
                    saveDetails(false);
                    browser = null;
                }
                else
                {
                    MessageBox.Show("Error test");
                }
            }
            else
            {
                MessageBox.Show("Please fill out the textboxes provided.");
            }
        }

        private void closeTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeTab();
        }

        private void closeTab()
        {
            if (tabControl.TabCount == 1)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to close your only active tab?", "Close tab",
               MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                string username;
                string tabUser = tabControl.SelectedTab.Text;
                Tab tempTab = new Tab(null, null);
                bool found = false;

                if (tabUser == "Client")
                {
                    textboxes.Clear();
                    tabControl.TabPages.Remove(tabControl.SelectedTab);
                }
                else if (tabUser == "IOURPG")
                {
                    foreach (Tab tab in IOURPGtabList)
                    {
                        if (tabControl.SelectedTab == tab.getTabPage())
                        {
                            tab.getClient().Dispose();
                            tempTab = tab;
                            tabControl.TabPages.Remove(tabControl.SelectedTab);
                        }
                    }
                    IOURPGtabList.Remove(tempTab);
                }
                try
                {
                    foreach (Tab tab in tabList)
                    {
                        username = tab.getUsername();
                        if (username == tabUser)
                        {
                            tab.getClient().Dispose();
                            tabList.Remove(tab);
                            tabControl.TabPages.Remove(tabControl.SelectedTab);
                            found = true;
                            break;
                        }
                    }
                    if (found == false)
                    {
                        foreach (Tab tab in testTabList)
                        {
                            username = tab.getUsername() + " test";
                            if (username == tabUser)
                            {
                                tab.getClient().Dispose();
                                tabList.Remove(tab);
                                tabControl.TabPages.Remove(tabControl.SelectedTab);
                                break;
                            }
                        }
                    }                
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void iOUSpreadsheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://docs.google.com/spreadsheets/d/1QGBm6KtcOZraqSkLWVuqTF16vUD7rrOvIpdh59bFLmg/edit#gid=357923173");
        }

        private void abilitesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (abilityTimer.Enabled == false)
            {
                abilityTimer.Enabled = true;
                abilitesToolStripMenuItem.Text = "Stop Abilities (F4)";
            }
            else if (abilityTimer.Enabled == true)
            {
                abilityTimer.Enabled = false;
                abilitesToolStripMenuItem.Text = "Start Abilities (F3)";
            }
        }

        private void abilityTimer_Tick(object sender, EventArgs e)
        {
            SendKeys.Send("{1}");
            SendKeys.Send("{2}");
            SendKeys.Send("{3}");
            SendKeys.Send("{4}");
            SendKeys.Send("{5}");
            SendKeys.Send("{6}");
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.TabCount != 0)
            {
                if (tabControl.SelectedTab.Name == "tabPage1")
                {
                    tabNumber = 1;
                }
                else
                {
                    try
                    {
                        string t = tabControl.SelectedTab.Name;
                        string[] words = t.Split(' ');
                        tabNumber = int.Parse(words[1]);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }        
        }

        private void refreshAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            refreshAll();
        }

        private void refreshAll()
        {
            try
            {
                if (IOURPGtabList.Count != 0)
                {
                    foreach (Tab tab in IOURPGtabList)
                    {
                        if (tab.getIsTest() == true)
                        {
                            tab.reloadTestIOURPG();
                        }
                        else
                        {
                            tab.reloadIOURPG();
                        }
                    }
                }
                if (tabList.Count != 0)
                {
                    foreach (Tab tab in tabList)
                    {
                        updateClient(tab);
                    }
                }
                if (testTabList.Count != 0)
                {
                    foreach (Tab tab in testTabList)
                    {
                        tab.getClient().Url = tab.getTestURL();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void hardRefreshAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hardRefreshAll();
        }

        private void hardRefreshAll()
        {
            //Download the iou client code online
            System.Net.WebClient wc = new System.Net.WebClient();
            try
            {
                string rawCode = wc.DownloadString("http://www.kongregate.com/games/iouRPG/idle-online-universe");
                string[] codeWords = rawCode.Split(new string[] { "FAPI_AS3_", ".swf" }, StringSplitOptions.None);
                string[] gameWords = rawCode.Split(new string[] {"kongregate_game_version=", "\";" }, StringSplitOptions.None);

                string raw = wc.DownloadString("http://iouhelper.com/code.html");
                string[] words = raw.Split('|');

                code = codeWords[3];
                gameVersion = gameWords[8];
                Tab.setCodes(code, gameVersion);
            }
            catch
            {
                
            }

            try
            {
                if (IOURPGtabList.Count != 0)
                {
                    foreach (Tab tab in IOURPGtabList)
                    {
                        if (tab.getIsTest() == true)
                        {
                            tab.reloadTestIOURPG();
                        }
                        else
                        {
                            tab.reloadIOURPG();
                        }
                    }
                }
                if (tabList.Count != 0)
                {
                    foreach (Tab tab in tabList)
                    {
                        updateClient(tab);
                    }
                }
                if (testTabList.Count != 0)
                {
                    foreach (Tab tab in testTabList)
                    {
                        tab.getClient().Url = tab.getTestURL();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void setSize(string theSize)
        {
            if (theSize == "small")
            {
                size = "small";
                if (tabList.Count != 0)
                {
                    internalLoad();
                }

                if (IOURPGtabList.Count != 0)
                {
                    IOURPGinternalLoad();
                }
                tabControl.Width = tabSmallWidth;
                tabControl.Height = tabSmallHeight;
                this.Size = new Size(tabSmallWidth, tabSmallHeight);
            }
            else if (theSize == "medium")
            {
                size = "medium";
                if (tabList.Count != 0)
                {
                    internalLoad();
                }

                if (IOURPGtabList.Count != 0)
                {
                    IOURPGinternalLoad();
                }
                tabControl.Width = tabMediumWidth;
                tabControl.Height = tabMediumHeight;
                this.Size = new Size(tabMediumWidth, tabMediumHeight);
            }
            else if (theSize == "large")
            {
                size = "large";
                if (tabList.Count != 0)
                {
                    internalLoad();
                }

                if (IOURPGtabList.Count != 0)
                {
                    IOURPGinternalLoad();
                }
                tabControl.Width = tabLargeWidth;
                tabControl.Height = tabLargeHeight;
                this.Size = new Size(tabLargeWidth, tabLargeHeight);
            }
        }
        private void internalLoad()
        {
            string[] lineRead = null;
            string details = "";
            foreach (Tab tab in tabList)
            {
                details = details + tab.ToString() + ",";
            }
            tabList.Clear();
            tabControl.TabPages.Clear();
            lineRead = details.Split(',');
            for (int i = 0; i < lineRead.Length - 2; i++)
            {
                //Set the textboxes equal to data
                if (lineRead[i] != null)
                {
                    kongUsername = lineRead[i];
                    i++;
                }
                if (lineRead[i] != null)
                {
                    i++;
                }
                if (lineRead[i] != null)
                {
                }
                if (tabPage1.Text == "Client")
                {
                    Tab tab = new Tab(lineRead[i - 2], lineRead[i - 1], lineRead[i], IOUclient);
                    //Set the IOU Client to its approiate sizing
                    setClient(tabControl, IOUclient);
                    updateClient(tab);
                    tabList.Add(tab);
                }
                else
                {
                    string title = "TabPage " + (tabControl.TabCount + 1).ToString();
                    TabPage myTabPage = new TabPage(title);
                    tabControl.TabPages.Add(myTabPage);
                    myTabPage.Text = kongUsername;
                    myTabPage.Name = title;
                    tabControl.SelectedTab = myTabPage;
                    WebKit.WebKitBrowser IOUclient2 = new WebKit.WebKitBrowser();
                    IOUclient2.Navigated += IOUclient2_Navigated;
                    IOUclient2.DocumentCompleted += IOUclient2_DocumentCompleted;
                    myTabPage.Controls.Add(IOUclient2);
                    Tab tab = new Tab(lineRead[i - 2], lineRead[i - 1], lineRead[i], IOUclient2);
                    //Set the IOU Client to its approiate sizing
                    setClient(tabControl, IOUclient2);
                    //Update the client
                    updateClient(tab);
                    tabList.Add(tab);
                }
            }         
        }

        private void IOURPGinternalLoad()
        {
            int iourpgCount = IOURPGtabList.Count();
            IOURPGtabList.Clear();
            for (int i = 0; i < iourpgCount; i++)
            {
                startIOURPG();
            }  
        }
        public void createTimer(int interval, Tab tab)
        {
            var timer = new System.Timers.Timer();
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Interval = interval;
            timer.Enabled = true;
            timerDictionary.Add(timer, tab);
        }
        public void createIOUTimer(int interval)
        {
            var timer = new System.Timers.Timer();
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent2);
            timer.Interval = interval;
            timer.Enabled = true;
            timerDictionary.Add(timer, IOURPGtabList[0]);
        }

        public void OnTimedEvent2(object sender, ElapsedEventArgs e)
        {
            var tempTimer = new System.Timers.Timer();
            //Play a sound?!@#!@#
            System.Media.SystemSounds.Exclamation.Play();
            MessageBox.Show("IOURPG's, timer has just completed");
            tempTimer.Stop();
        }

        public void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            string name = "";
            var tempTimer = new System.Timers.Timer();
            foreach (KeyValuePair<System.Timers.Timer, Tab> entry in timerDictionary)
            {
                if (entry.Key == sender)
                {
                    name = entry.Value.getUsername();
                    tempTimer = entry.Key;
                }
            }
            //Play a sound?!@#!@#
            System.Media.SystemSounds.Exclamation.Play();
            MessageBox.Show(name + "'s, timer has just completed");
            tempTimer.Stop();
        }

        private void timersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Timers timersForm = new Timers(tabList, IOURPGtabList, this);
            timersForm.Show();
        }

        private void screenshotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            captureScreenshot();         
        }

        private void captureScreenshot()
        {
            foreach (Tab tab in tabList)
            {
                if (tabControl.SelectedTab.Text == tab.getUsername())
                {
                    using (Bitmap bmp = new Bitmap(tab.getClient().Width, tab.getClient().ClientSize.Height))
                    {
                        tab.getClient().DrawToBitmap(bmp, tab.getClient().ClientRectangle);
                        //string fName = "Screenshots" + tab.getUsername() + DateTime.Today + ".png";
                        var fName = string.Format(@"Screenshots/{0}.png", DateTime.Now.Ticks);
                        bmp.Save(fName);
                        MessageBox.Show("Screenshot of " + tab.getUsername() + " taken.");
                    }
                }
            }
        }

        private void petAnalyzerFerretToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://iourpg.com/forum/showthread.php?tid=2186");       
        }

        private void iOUHelperChatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/wczWVmZ");
        }

        private void versionCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "";
            if (check != version)
            {
                message = "currently out of date as the latest version is v" + check + "." + Environment.NewLine + 
                    "Please download the latest version at http://www.iouhelper.com/";
            }
            else {
                message = "the latest version of IOU Helper.";
            }
            MessageBox.Show("You are currently using version " + version.ToString() + " of IOU Helper." + Environment.NewLine + "This version is " +
            message);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tabList.Count != 0)
            {
                saveDetails(false);
            }

            if (startToolStripMenuItem.Text == "Stop")
            {
                overlay.getConsole().StopListening();
                overlay.stopWriter();
            }
        }

        private void newIourpgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startIOURPG();
        }

        private void startIOURPG()
        {
            string title = "TabPage " + (tabControl.TabCount + 1).ToString();
            TabPage myTabPage = new TabPage(title);
            tabControl.TabPages.Add(myTabPage);
            myTabPage.Name = title;
            myTabPage.Text = "IOURPG";
            tabControl.SelectedTab = myTabPage;
            myTabPage.BackColor = System.Drawing.ColorTranslator.FromHtml("#222222");

            //IOURPG Client
            WebKit.WebKitBrowser IOUclient2 = new WebKit.WebKitBrowser();
            IOUclient2.Navigated += IOUclient2_Navigated;
            IOUclient2.DocumentCompleted += IOUclient2_DocumentCompleted;
            myTabPage.Controls.Add(IOUclient2);
            IOUclient2.Visible = true;
            setClient(tabControl, IOUclient2);
            IOUclient2.Url = new System.Uri("http://scripts.iouscripts.com/iou.swf");
            Tab tab = new Tab(IOUclient2, myTabPage);
            IOURPGtabList.Add(tab);
        }

        private void IOUclient_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            this.Text = "Loading...";
        }

        private void IOUclient2_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            this.Text = "Loading...";
        }

        private void IOUclient_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.Text = "IOU Helper v" + version + " - Pro";
        }

        private void IOUclient2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.Text = "IOU Helper v" + version + " - Pro";
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            tabControl.Width = this.Width;
            tabControl.Height = this.Height;

            foreach (Tab tab in tabList)
            {
                tab.getClient().Width = this.Width;
                tab.getClient().Height = this.Height;

                tab.getClient().Location = new Point(-10, -40);
            }
            foreach (Tab tab in IOURPGtabList)
            {
                tab.getClient().Width = this.Width;
                tab.getClient().Height = this.Height;

                tab.getClient().Location = new Point(0, -40);
            }
            foreach (Tab tab in testTabList)
            {
                tab.getClient().Width = this.Width;
                tab.getClient().Height = this.Height;

                tab.getClient().Location = new Point(-10, -40);
            }
        }

        private void runTestClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabList.Count > 0 && tabControl.SelectedTab.Text != "Client" && tabControl.SelectedTab.Text != "IOURPG")
            {
                string username;
                string tabUser = tabControl.SelectedTab.Text;
                System.Uri uri;

                try
                {
                    foreach (Tab tab in tabList)
                    {
                        username = tab.getUsername();
                        if (username == tabUser)
                        {
                            //get all the details
                            Tab newTab = (Tab)tab.Clone();
                            newTab.setIsTest(true);
                            string title = "TabPage " + (tabControl.TabCount + 1).ToString();
                            TabPage myTabPage = new TabPage(title);
                            tabControl.TabPages.Add(myTabPage);
                            myTabPage.Text = tab.getUsername() + " test";
                            myTabPage.Name = title;
                            tabControl.SelectedTab = myTabPage;
                            WebKit.WebKitBrowser IOUclient2 = new WebKit.WebKitBrowser();
                            newTab.setClient(IOUclient2);
                            newTab.getClient().Url = newTab.getTestURL();
                            IOUclient2.Navigated += IOUclient2_Navigated;
                            IOUclient2.DocumentCompleted += IOUclient2_DocumentCompleted;
                            myTabPage.Controls.Add(IOUclient2);
                            //Set the IOU Client to its approiate sizing
                            setClient(tabControl, IOUclient2);
                            testTabList.Add(newTab);

                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                string title = "TabPage " + (tabControl.TabCount + 1).ToString();
                TabPage myTabPage = new TabPage(title);
                tabControl.TabPages.Add(myTabPage);
                myTabPage.Name = title;
                myTabPage.Text = "IOURPG";
                tabControl.SelectedTab = myTabPage;
                myTabPage.BackColor = System.Drawing.ColorTranslator.FromHtml("#222222");

                //IOURPG Client
                WebKit.WebKitBrowser IOUclient2 = new WebKit.WebKitBrowser();
                IOUclient2.Navigated += IOUclient2_Navigated;
                IOUclient2.DocumentCompleted += IOUclient2_DocumentCompleted;
                myTabPage.Controls.Add(IOUclient2);
                IOUclient2.Visible = true;
                setClient(tabControl, IOUclient2);
                IOUclient2.Url = new System.Uri("http://iourpg.com/test.swf");
                Tab tab = new Tab(IOUclient2, myTabPage);
                tab.setIsTest(true);
                IOURPGtabList.Add(tab);
            }
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (startToolStripMenuItem.Text == "Start")
            {
                FormDevices deviceForm = new FormDevices(overlay.getConsole(), this);
                deviceForm.Show();
            }
            else if (startToolStripMenuItem.Text == "Stop")
            {
                Image green = Image.FromFile("imgs/green.jpg");
                startToolStripMenuItem.Image = green;
                startToolStripMenuItem.Text = "Start";
                overlay.getConsole().StopListening();
                timerProStats.Enabled = false;
            }
        }

        public void started()
        {
            Image red = Image.FromFile("imgs/red.jpg");
            startToolStripMenuItem.Image = red;
            startToolStripMenuItem.Text = "Stop";
            timerProStats.Interval = (Properties.Settings.Default.refreshTimer * 1000);
            timerProStats.Enabled = true;
            overlay.setPanelSizes();

        }

        private void hideOverlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (hideOverlayToolStripMenuItem.Text == "Hide Overlay")
            {
                overlay.Hide();
                overlay.getConsole().Write("Overlay hidden.");
                hideOverlayToolStripMenuItem.Text = "Show Overlay";
            }
            else if (hideOverlayToolStripMenuItem.Text == "Show Overlay")
            {
                overlay.Show();
                overlay.getConsole().Write("Overlay shown.");
                hideOverlayToolStripMenuItem.Text = "Hide Overlay";
            }
        }

        private void hideConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (hideConsoleToolStripMenuItem.Text == "Hide Console")
            {
                overlay.getPanelConsole().Hide();
                overlay.getConsole().Write("Console hidden.");
                hideConsoleToolStripMenuItem.Text = "Show Console";
            }
            else if (hideConsoleToolStripMenuItem.Text == "Show Console")
            {
                overlay.getPanelConsole().Show();
                overlay.getConsole().Write("Console shown.");
                hideConsoleToolStripMenuItem.Text = "Hide Console";
            }
        }

        private void overlayColorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public void setOverlayColor(Color color)
        {
            overlay.setColor(color);
        }

        private void moveOverlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            overlay.moveOverlay();         
        }

        private void refreshStatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (startToolStripMenuItem.Text == "Stop")
            {
                overlay.updateStats();
            }
        }

        private void resetStatsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (startToolStripMenuItem.Text == "Stop")
            {
                DialogResult result1 = MessageBox.Show("Are you sure you want to reset statistics?",
                "Reset Statistics",
                MessageBoxButtons.YesNo);
                if (result1 == DialogResult.Yes)
                {
                    overlay.resetStats();
                }
            }
        }

        private void copyStatsToClipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            overlay.copyStats();
        }

        private void proSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProSettings proSettings = new ProSettings(this);
            proSettings.Show();
        }

        private void timerProStats_Tick(object sender, EventArgs e)
        {
            if (startToolStripMenuItem.Text == "Stop")
            {
                overlay.updateStats();
            }
        }

        public void applyProSettings(int time)
        {
            timerProStats.Interval = (time * 1000);
            overlay.refreshLabels();
        }

        //Property Getter Methods

        public string getUnitXPGold()
        {
            return Properties.Settings.Default.unitXpGold;
        }

        public string getCardDropTime()
        {
            return Properties.Settings.Default.cardDropTime;
        }

        public int getRefreshTimer()
        {
            return Properties.Settings.Default.refreshTimer;
        }

        public int getSigFigures()
        {
            return Properties.Settings.Default.sigFigures;
        }

        public bool getDoubleCards()
        {
            return Properties.Settings.Default.doubleCards;
        }

        public string getAscTier()
        {
            return Properties.Settings.Default.ascTier;
        }

        public bool getMoveOverlay()
        {
            return Properties.Settings.Default.moveOverlay;
        }

        public System.Drawing.Color getOverlayColor()
        {
            return Properties.Settings.Default.overlayColor;
        }

        public decimal getGoldAdd()
        {
            return Properties.Settings.Default.goldAdd;
        }

        public decimal getXpAdd()
        {
            return Properties.Settings.Default.xpAdd;
        }

        public int getGoldOrb()
        {
            return Properties.Settings.Default.goldOrb;
        }

        public int getXpOrb()
        {
            return Properties.Settings.Default.xpOrb;
        }

        public double getPartyBoost()
        {
            return Properties.Settings.Default.partyBoost;
        }

        public int getPlayers()
        {
            return Properties.Settings.Default.players;
        }

        public int getGlobalGold()
        {
            return Properties.Settings.Default.globalGold;
        }

        public int getGlobalXp()
        {
            return Properties.Settings.Default.globalXp;
        }

        public int getPlayerLevel()
        {
            return Properties.Settings.Default.playerLevel;
        }

        public uint getMobFilter()
        {
            return Properties.Settings.Default.filterMob;
        }

        public string getUsername()
        {
            if (tabControl.SelectedTab.Text == "IOURPG")
            {
                return "IOURPG";
            }
            else if (tabList.Count > 0 && tabControl.SelectedTab.Text != "Client")
            {
                string username = "NOT FOUND";
                string tabUser = tabControl.SelectedTab.Text;

                try
                {
                    foreach (Tab tab in tabList)
                    {
                        username = tab.getUsername();
                        if (username == tabUser)
                        {
                            return username;
                        }
                    }
                    foreach (Tab tab in testTabList)
                    {
                        username = tab.getUsername() + " test";
                        if (username == tabUser)
                        {
                            return username;
                        }
                    }        
                }
                catch (Exception ex)
                {
                    return "NOT FOUND";
                }
            }
            return "NOT FOUND";
        }

        public void showPcapError()
        {
            MessageBox.Show("Make sure to have latest version of WinPcap: https://www.winpcap.org/");
        }

        private void helpGuideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://iouhelper.com/guide.html");
        }
    }
}
