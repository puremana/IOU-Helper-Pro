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

namespace IOU_Helper
{
    public partial class Form1 : Form
    {
        // import the necessary API function so .NET can
        // marshall parameters appropriately
        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        // constants for the mouse_input() API function
        private const int MOUSEEVENTF_MOVE = 0x0001;
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const int MOUSEEVENTF_RIGHTUP = 0x0010;
        private const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        private const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        private const int MOUSEEVENTF_ABSOLUTE = 0x8000;
        private int count = 0;


        public Form1()
        {
            InitializeComponent();

        }

        //Global Variables
        string kongUsername;
        string kongID;
        string kongToken;

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

                        if (lineReadFull == "<!DOCTYPE html PUBLIC")
                        {

                        }
                        else
                        {
                            try
                            {
                                //Set the textboxes equal to data
                                if (lineRead[0] != null)
                                {
                                    kongUsername = lineRead[0];
                                    textBoxKongUser.Text = lineRead[0];
                                }
                                if (lineRead[1] != null)
                                {
                                    kongID = lineRead[1];
                                    textBoxKongID.Text = lineRead[1];
                                }
                                if (lineRead[2] != null)
                                {
                                    kongToken = lineRead[2];
                                    textBoxKongToken.Text = lineRead[2];
                                }
                                if (tabPage1.Text == "Client")
                                {
                                    this.Size = new Size(736, 538);
                                    //Set the IOU Client to its approiate sizing
                                    tabControl.Width = 746;
                                    tabControl.Height = 580;
                                    this.Size = new Size(756, 600);
                                    //this.Size = new Size(1052, 768);
                                    oldIOUclient.Height = 550;
                                    oldIOUclient.Width = 736;
                                    //Get the black cut off
                                    oldIOUclient.Location = new Point(0, 0);
                                    updateClient(oldIOUclient);
                                }
                                else
                                {
                                    string title = "TabPage " + (tabControl.TabCount + 1).ToString();
                                    TabPage myTabPage = new TabPage(title);
                                    tabControl.TabPages.Add(myTabPage);
                                    myTabPage.Text = kongUsername;
                                    tabControl.SelectedTab = myTabPage;

                                    WebBrowser IOUclient2 = new WebBrowser();
                                    myTabPage.Controls.Add(IOUclient2);
                                    IOUclient2.Height = 550;
                                    IOUclient2.Width = 736;
                                    //Update the client
                                    updateClient(IOUclient2);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
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

        /// <summary>
        /// Run the IOU Client
        /// </summary>
        public void updateClient(WebBrowser client)
        {
            //Change the Form Title
            if (kongUsername != "")
            {
                tabControl.SelectedTab.Text = kongUsername;
            }
            else
            {
                tabControl.SelectedTab.Text = textBoxKongUser.Text;
            }
            //Take out all other form elements
            IOUtitle.Visible = false;
            groupBoxAccount.Visible = false;
            buttonStartClient.Visible = false;

            client.Visible = true;
            //System.Uri uri = new System.Uri("http://chat.kongregate.com/gamez/0022/7576/live/iou.swf?kongregate_username=" + kongUsername + "&kongregate_user_id=" + kongID + "&kongregate_game_auth_token=" + kongToken + "&kongregate_api_path=http%3A%2F%2Fchat.kongregate.com%2Fflash%2FAPI_AS3_20fff5ba92ad2028adf76a275de69d65.swf");
            System.Uri uri = new System.Uri("http://chat.kongregate.com/gamez/0022/7576/live/iou.swf?kongregate_username=" + kongUsername + "&kongregate_user_id=" + kongID + "&kongregate_game_auth_token=" + kongToken + "&kongregate_api_path=http%3A%2F%2Fchat.kongregate.com%2Fflash%2FAPI_AS3_20fff5ba92ad2028adf76a275de69d65.swf");
            //Before pet ^^^^^^^^^^
            System.Windows.Forms.Clipboard.SetText("http://chat.kongregate.com/gamez/0022/7576/live/iou.swf?kongregate_username=" + textBoxKongUser.Text + "&kongregate_user_id=" + textBoxKongID.Text + "&kongregate_game_auth_token=" + textBoxKongToken.Text + "&kongregate_api_path=http%3A%2F%2Fchat.kongregate.com%2Fflash%2FAPI_AS3_20fff5ba92ad2028adf76a275de69d65.swf");
            //System.Uri official = new System.Uri("http://chat.kongregate.com/gamez/0022/7576/live/iou.swf?kongregate_username=<YOUR_USERNAME>&kongregate_user_id=<YOUR_KONG_ID>&kongregate_game_auth_token=<YOUR_AUTH_TOKEN>&kongregate_api_path=http%3A%2F%2Fchat.kongregate.com%2Fflash%2FAPI_AS3_3b998fc2df3d80d02b78142e0fd8ad7e.swf");
            //System.Uri uri = new System.Uri("http://chat.kongregate.com/gamez/0022/7576/live/iou.swf?kongregate_username=" + textBoxKongUser.Text + "&kongregate_user_id=" + textBoxKongID.Text + "&kongregate_game_auth_token=" + textBoxKongToken.Text + "&kongregate_api_path=http%3A%2F%2Fchat.kongregate.com%2Fflash%2FAPI_AS3_3b998fc2df3d80d02b78142e0fd8ad7e.swf");
            //System.Uri uri = new System.Uri("https://www.google.co.nz/?gws_rd=cr,ssl&ei=3uZGV4rKFMKq0ASUiL3oCw");
            client.Url = uri;

        }

        /// <summary>
        /// Save the current account details to the Auto Save file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveDetails();
        }

        /// <summary>
        /// Saves the details into the AutoSave CSV
        /// </summary>
        public void saveDetails() {

            try
            {
                StreamWriter writer = File.CreateText(Application.StartupPath + @"\AutoSave.CSV");

                writer.WriteLine(textBoxKongUser.Text + "," + textBoxKongID.Text + "," + textBoxKongToken.Text);

                writer.Close();
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

                    writer.WriteLine(textBoxKongUser.Text + "," + textBoxKongID.Text + "," + textBoxKongToken.Text);

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
            //MessageBox.Show(label1.Location.ToString());
            if (textBoxKongUser.Text != "" && textBoxKongID.Text != "" && textBoxKongToken.Text != "")
            {
                //Set the IOU Client to its approiate sizing
                tabControl.Width = 746;
                tabControl.Height = 580;
                this.Size = new Size(756, 600);
                //this.Size = new Size(1052, 768);
                oldIOUclient.Height = 550;
                oldIOUclient.Width = 736;
                //Get the black cut off
                oldIOUclient.Location = new Point(0, 0);
                updateClient(oldIOUclient);
                saveDetails();
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
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            string[] lineRead = null;
            string lineReadFull = "";

            try
            {
                StreamReader reader = File.OpenText(Application.StartupPath + @"\AutoSave.CSV");

                while (!reader.EndOfStream)
                {
                    lineReadFull = reader.ReadLine();
                    lineRead = lineReadFull.Split(',');

                        try
                        {
                            if (lineRead[0] != null)
                            {
                                kongUsername = lineRead[0];
                                textBoxKongUser.Text = lineRead[0];
                            }
                            if (lineRead[1] != null)
                            {
                                kongID = lineRead[1];
                                textBoxKongID.Text = lineRead[1];
                            }
                            if (lineRead[2] != null)
                            {
                                kongToken = lineRead[2];
                                textBoxKongToken.Text = lineRead[2];
                                //Set the IOU Client to its approiate sizing
                                tabControl.Width = 746;
                                tabControl.Height = 580;
                                this.Size = new Size(756, 600);
                                //this.Size = new Size(1052, 768);
                                oldIOUclient.Height = 550;
                                oldIOUclient.Width = 736;
                                //Get the black cut off
                                oldIOUclient.Location = new Point(0, 0);
                                updateClient(oldIOUclient);
                            }
                            else
                            {
                                break;
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
            Process.Start("https://discordapp.com/channels/146007387466235905/146007387466235905");
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
            updateClient(oldIOUclient);
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settingsForm = new Settings(this);
            settingsForm.Show();
        }

        private void refreshToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            updateClient(oldIOUclient);
        }

        /// <summary>
        /// Start AutoClicker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startAutoClickerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (startAutoClickerToolStripMenuItem1.Text == "Start AutoClicker") {
                autoClickTimer.Enabled = true;
                startAutoClickerToolStripMenuItem1.Text = "Stop AutoClicker";
            }
            else if (startAutoClickerToolStripMenuItem1.Text == "Stop AutoClicker")
            {
                autoClickTimer.Enabled = false;
                startAutoClickerToolStripMenuItem1.Text = "Start AutoClicker";
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
            updateClient(oldIOUclient);
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
                startAutoClickerToolStripMenuItem1.Text = "Stop AutoClicker";
                return true;
            }
            else if ((keyData == Keys.F3) && (autoClickTimer.Enabled == true))
            {
                autoClickTimer.Enabled = false;
                startAutoClickerToolStripMenuItem1.Text = "Start AutoClicker";
                return true;
            }
            else if (keyData == Keys.F5)
            {
                updateClient(oldIOUclient);
                return true;
            }
            else if (keyData == Keys.F6)
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
                    tabControl.TabPages.Remove(tabControl.SelectedTab);
                }
            }
            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oldIOUclient.Visible = false;
            this.Size = new Size(490, 392);
            groupBoxAccount.Visible = true;
            buttonStartClient.Visible = true;
            IOUtitle.Visible = true;
            this.Text = "IOU Client v1.0";
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
            //Tab
            string title = "TabPage " + (tabControl.TabCount + 1).ToString();
            TabPage myTabPage = new TabPage(title);
            tabControl.TabPages.Add(myTabPage);
            myTabPage.Text = "Client";
            tabControl.SelectedTab = myTabPage;
            myTabPage.BackColor = System.Drawing.ColorTranslator.FromHtml("#222222");

            int c = tabControl.TabCount;

            //Label          
            Label label = new Label();
            label.Location = new System.Drawing.Point(144, 17);
            label.Parent = myTabPage;
            label.Name = "IOUtitle" + c.ToString();
            label.Text = "IOU Helper";
            label.ForeColor = System.Drawing.ColorTranslator.FromHtml("#B92E2E");
            label.Size = new System.Drawing.Size(209, 44);
            label.Font = new Font("Microsoft Sans Serif", 28);
            myTabPage.Controls.Add(label);


            //GroupBox
            GroupBox groupBox = new GroupBox();
            groupBox.Location = new System.Drawing.Point(66, 76);
            groupBox.Parent = myTabPage;
            groupBox.Name = "groupBoxAccount" + c.ToString();
            groupBox.Text = "Account Details";
            groupBox.ForeColor = System.Drawing.ColorTranslator.FromHtml("#B4B4B4");
            groupBox.Size = new System.Drawing.Size(341, 137);
            myTabPage.Controls.Add(groupBox);

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
            textBox1.Location = new System.Drawing.Point(12, 90);
            textBox1.Parent = myTabPage;
            textBox1.Name = "label3" + c.ToString();
            label3.ForeColor = System.Drawing.ColorTranslator.FromHtml("#B4B4B4");
            textBox1.BackColor = System.Drawing.ColorTranslator.FromHtml("#B4B4B4");
            textBox1.Size = new System.Drawing.Size(102, 13);
            textBox1.Font = new Font("Microsoft Sans Serif", 8);
            groupBox.Controls.Add(textBox1);


            //Button
            Button button = new Button();
            button.Location = new System.Drawing.Point(151, 245);
            button.Parent = myTabPage;
            button.Name = "buttonStartClient" + c.ToString();
            button.Text = "Start Client";
            button.BackColor = System.Drawing.ColorTranslator.FromHtml("#161616");
            button.ForeColor = System.Drawing.ColorTranslator.FromHtml("#B4B4B4");
            button.Size = new System.Drawing.Size(186, 60);
            button.Font = new Font("Microsoft Sans Serif", 10);

            myTabPage.Controls.Add(button);
        }

        private void closeTabToolStripMenuItem_Click(object sender, EventArgs e)
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
                tabControl.TabPages.Remove(tabControl.SelectedTab);
            }
        }
    }
}
