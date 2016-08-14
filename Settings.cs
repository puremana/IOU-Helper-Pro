using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.IO;

namespace IOU_Helper
{
    public partial class Settings : Form
    {
        private readonly Form1 _form1;
        public Settings(Form1 form1)
        {
            InitializeComponent();
            _form1 = form1;
        }

        /// <summary>
        /// Cancel current settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Restore to the defualt settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDefault_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to restore default settings?",
            "Restore Defaults",
            MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                if (radioButtonMedium.Checked != true)
                {
                    radioButtonMedium.Checked = true;
                }
                textBoxWidth.Text = "757";
                textBoxHeight.Text = "600";
                if (checkBoxRefresh.Checked == true)
                {
                    checkBoxRefresh.Checked = false;
                }
                textBoxRefresh.Text = "40";
                if (radioButtonRefreshMinutes.Checked != true)
                {
                    radioButtonRefreshMinutes.Checked = true;
                }
                textBoxAutoClicker.Text = "100";

                if (radioButtonClickMilliseconds.Checked != true)
                {
                    radioButtonClickMilliseconds.Checked = true;
                }
            }

        }

        /// <summary>
        /// Applies settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonApply_Click(object sender, EventArgs e)
        {
            try
            {
                int clicker = int.Parse(textBoxAutoClicker.Text);
                if (radioButtonClickMilliseconds.Checked == false)
                {
                    clicker = 50;
                }

                if (textBoxWidth.Text != "" && textBoxHeight.Text != "" && clicker > 49)
                {
                    int milSeconds = 0;

                    //Refresh Settings
                    if (textBoxRefresh.Text != "")
                    {
                        if (checkBoxRefresh.Checked == true)
                        {
                            if (radioButtonRefreshSeconds.Checked == true)
                            {
                                milSeconds = (int.Parse(textBoxRefresh.Text) * 1000);
                            }
                            else if (radioButtonRefreshMinutes.Checked == true)
                            {
                                milSeconds = (int.Parse(textBoxRefresh.Text) * 60000);
                            }
                            //MessageBox.Show(milSeconds.ToString());
                            _form1.enableTimer(milSeconds, true);
                        }
                        else if (checkBoxRefresh.Checked == false)
                        {
                            if (radioButtonRefreshSeconds.Checked == true)
                            {
                                milSeconds = (int.Parse(textBoxRefresh.Text) * 1000);
                            }
                            else if (radioButtonRefreshMinutes.Checked == true)
                            {
                                milSeconds = (int.Parse(textBoxRefresh.Text) * 60000);
                            }
                            //MessageBox.Show(milSeconds.ToString());
                            _form1.enableTimer(milSeconds, false);
                        }
                    }     
                    //Auto Clicker settings
                    if (textBoxAutoClicker.Text != null)
                    {
                        if (radioButtonClickMilliseconds.Checked == true)
                        {
                            int milliSeconds = int.Parse(textBoxAutoClicker.Text);
                            //MessageBox.Show(milliSeconds.ToString());
                            _form1.autoClicker(milliSeconds);
                        }
                        else if (radioButtonClickSeconds.Checked == true)
                        {
                            int milliSeconds = (int.Parse(textBoxAutoClicker.Text) * 1000);
                            //MessageBox.Show(milliSeconds.ToString());
                            _form1.autoClicker(milliSeconds);
                        }
                    }

                    MessageBox.Show("Settings applied.");
                }
                else
                {
                    MessageBox.Show("Please enter a width and height with a minimum click interval of 50 milliseconds.");
                }
            }
            catch
            {
                MessageBox.Show("Please enter a width and height with a minimum click interval of 50 milliseconds.");
            }
           
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            //Form Settings
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            string[] lineRead = null;
            string lineReadFull = "";
            string clientWidth = "";
            string clientHeight = "";
            string refreshTimer = "";
            string refreshChecked = "";
            string refreshRadio = "";
            string autoClicker = "";
            string autoRadio = "";

            try
            {
                StreamReader reader = File.OpenText(Application.StartupPath + @"\SaveSettings.CSV");

                while (!reader.EndOfStream)
                {
                    lineReadFull = reader.ReadLine();
                    lineRead = lineReadFull.Split(',');

                        try
                        {
                            if (lineRead[0] != null)
                            {
                                clientWidth = lineRead[0];
                            }
                            if (lineRead[1] != null)
                            {
                                clientHeight = lineRead[1];
                            }
                            if (lineRead[2] != null)
                            {
                               refreshChecked = lineRead[2];
                            }
                            if (lineRead[3] != null)
                            {
                                refreshTimer = lineRead[3];
                            }
                            if (lineRead[4] != null)
                            {
                                refreshRadio = lineRead[4];
                            }
                            if (lineRead[5] != null)
                            {
                                autoClicker = lineRead[5];
                            }
                            if (lineRead[6] != null)
                            {
                                autoRadio = lineRead[6];

                                textBoxWidth.Text = clientWidth;
                                textBoxHeight.Text = clientHeight;
                                if (refreshChecked == "checked")
                                {
                                    checkBoxRefresh.Checked = true;
                                }
                                else if (refreshChecked == "unchecked")
                                {
                                    checkBoxRefresh.Checked = false;
                                }
                                textBoxRefresh.Text = refreshTimer;
                                if (refreshRadio == "seconds")
                                {
                                    radioButtonRefreshSeconds.Checked = true;
                                }
                                else if (refreshRadio == "minutes")
                                {
                                    radioButtonRefreshMinutes.Checked = true;
                                }
                                textBoxAutoClicker.Text = autoClicker;
                                if (autoRadio == "milliseconds")
                                {
                                    radioButtonClickMilliseconds.Checked = true;
                                }
                                else if (autoRadio == "seconds")
                                {
                                    radioButtonClickSeconds.Checked = true;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                        catch (Exception ex)
                        {
                            //MessageBox.Show(ex.ToString());
                            if (textBoxWidth.Text == "757" && textBoxHeight.Text == "600")
                            {
                                radioButtonMedium.Checked = true;
                            }
                        }
                    }

                reader.Close();
            }
            catch (FileNotFoundException ex)
            {
                //MessageBox.Show(ex.Message);
            }

            //textBoxWidth.Text = _form1.Width.ToString();
            //textBoxHeight.Text = _form1.Height.ToString();
            //if ((_form1.Width == 757) && _form1.Height == 600)
            //{
            //    radioButtonMedium.Checked = true;
            //}
        }

        private void textBoxWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBoxHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBoxRefresh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBoxAutoClicker_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
               (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void buttonSaveSettings_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter writer = File.CreateText(Application.StartupPath + @"\SaveSettings.CSV");
                string refreshChecked = " ";
                string refreshRadio = " ";
                string autoRadio = " ";

                if (checkBoxRefresh.Checked == true)
                {
                    refreshChecked = "checked";
                }
                else
                {
                    refreshChecked = "unchecked";
                }

                if (radioButtonRefreshSeconds.Checked == true)
                {
                    refreshRadio = "seconds";
                }
                else
                {
                    refreshRadio = "minutes";
                }

                if (radioButtonClickMilliseconds.Checked == true)
                {
                    autoRadio = "milliseconds";
                }
                else
                {
                    autoRadio = "seconds";
                }

                writer.WriteLine(textBoxWidth.Text + "," + textBoxHeight.Text + "," + refreshChecked + "," + 
                   textBoxRefresh.Text + "," + refreshRadio + "," + textBoxAutoClicker.Text + "," + autoRadio);

                writer.Close();
                MessageBox.Show("Settings saved to Auto Save File.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonLoadSettings_Click(object sender, EventArgs e)
        {
            const string FILTER = "CSV Files|*.csv|TXT FILES|*.txt|All Files|*.*";
            string[] lineRead = null;
            string lineReadFull = "";

            string clientWidth = "";
            string clientHeight = "";
            string refreshTimer = "";
            string refreshChecked = "";
            string refreshRadio = "";
            string autoClicker = "";
            string autoRadio = "";

            openFileDialog1.Filter = FILTER;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                try
                {
                    StreamReader reader = File.OpenText(openFileDialog1.FileName);

                    while (!reader.EndOfStream)
                    {
                        lineReadFull = reader.ReadLine();
                        lineRead = lineReadFull.Split(',');

                        try
                        {
                            //Set the textboxes equal to data
                            if (lineRead[0] != null)
                            {
                                clientWidth = lineRead[0];
                            }
                            if (lineRead[1] != null)
                            {
                                clientHeight = lineRead[1];
                            }
                            if (lineRead[2] != null)
                            {
                                refreshChecked = lineRead[2];
                            }
                            if (lineRead[3] != null)
                            {
                                refreshTimer = lineRead[3];
                            }
                            if (lineRead[4] != null)
                            {
                                refreshRadio = lineRead[4];
                            }
                            if (lineRead[5] != null)
                            {
                                autoClicker = lineRead[5];
                            }
                            if (lineRead[6] != null)
                            {
                                autoRadio = lineRead[6];

                                textBoxWidth.Text = clientWidth;
                                textBoxHeight.Text = clientHeight;
                                if (refreshChecked == "checked")
                                {
                                    checkBoxRefresh.Checked = true;
                                }
                                else if (refreshChecked == "unchecked")
                                {
                                    checkBoxRefresh.Checked = false;
                                }
                                textBoxRefresh.Text = refreshTimer;
                                if (refreshRadio == "seconds")
                                {
                                    radioButtonRefreshSeconds.Checked = true;
                                }
                                else if (refreshRadio == "minutes")
                                {
                                    radioButtonRefreshMinutes.Checked = true;
                                }
                                textBoxAutoClicker.Text = autoClicker;
                                if (autoRadio == "milliseconds")
                                {
                                    radioButtonClickMilliseconds.Checked = true;
                                }
                                else if (autoRadio == "seconds")
                                {
                                    radioButtonClickSeconds.Checked = true;
                                }
                            }
                            else
                            {
                                break;
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

        private void radioButtonMedium_CheckedChanged(object sender, EventArgs e)
        {
            textBoxWidth.Text = "757";
            textBoxHeight.Text = "600";
        }

        private void buttonSaveAsSettings_Click(object sender, EventArgs e)
        {
            const string FILTER = "CSV Files|*.csv|All Files|*.*";
            saveFileDialog1.Filter = FILTER;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamWriter writer = File.CreateText(saveFileDialog1.FileName);

                    string refreshChecked = " ";
                    string refreshRadio = " ";
                    string autoRadio = " ";

                    if (checkBoxRefresh.Checked == true)
                    {
                        refreshChecked = "checked";
                    }
                    else
                    {
                        refreshChecked = "unchecked";
                    }

                    if (radioButtonRefreshSeconds.Checked == true)
                    {
                        refreshRadio = "seconds";
                    }
                    else
                    {
                        refreshRadio = "minutes";
                    }

                    if (radioButtonClickMilliseconds.Checked == true)
                    {
                        autoRadio = "milliseconds";
                    }
                    else
                    {
                        autoRadio = "seconds";
                    }

                    writer.WriteLine(textBoxWidth.Text + "," + textBoxHeight.Text + "," + refreshChecked + "," +
                       textBoxRefresh.Text + "," + refreshRadio + "," + textBoxAutoClicker.Text + "," + autoRadio);

                    writer.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
