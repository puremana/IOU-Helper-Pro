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

namespace IOU_Helper
{
    public partial class Timers : Form
    {
        List<Tab> _tabList = new List<Tab>();
        List<Tab> _IOURPGtabList = new List<Tab>();
        private readonly Form1 _form1;

        public Timers(List<Tab> tabList, List<Tab> IOURPGtabList, Form1 form1)
        {
            InitializeComponent();
            _tabList = tabList;
            _form1 = form1;
            _IOURPGtabList = IOURPGtabList;
        }

        private void Timers_Load(object sender, EventArgs e)
        {
            try {
                foreach (Tab tab in _tabList)
                {
                    comboBoxUsers.Items.Add(tab.getUsername());
                }
                foreach (Tab tab in _IOURPGtabList)
                {
                    comboBoxUsers.Items.Add("IOURPG");
                }
                refreshtimerListBox();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }

        }

        private void buttonCreateTimer_Click(object sender, EventArgs e)
        {
            int totalTime = 0;
            //Tab tempTab = new Tab(null, null, null, null);
            if (comboBoxUsers.Text != "" && (textBoxHours.Text != "" || textBoxMinutes.Text != "")) {
                
                if (textBoxHours.Text != "") {
                    totalTime = int.Parse(textBoxHours.Text) * 3600 * 1000;
                }
                
                if (textBoxMinutes.Text != "") {
                    totalTime = totalTime + (int.Parse(textBoxMinutes.Text) * 60 * 1000);
                }
                if (comboBoxUsers.Text == "IOURPG")
                {
                    _form1.createIOUTimer(totalTime);
                    MessageBox.Show("Timer for IOURPG created.");
                    listBoxTimers.Items.Clear();
                    refreshtimerListBox();
                }
                else
                {
                    foreach (Tab tab in _tabList)
                    {
                        if (comboBoxUsers.Text == tab.getUsername())
                        {
                            _form1.createTimer(totalTime, tab);
                            MessageBox.Show("Timer for " + tab.getUsername() + " created.");
                            listBoxTimers.Items.Clear();
                            refreshtimerListBox();
                        }
                    }
                }             
            }
            else {
                MessageBox.Show("Please select a user from the dropdown box and input a time.");
            }
        }

        private void refreshtimerListBox()
        {
            listBoxTimers.Items.Clear();
            string enabled = "";
            foreach (KeyValuePair<System.Timers.Timer, Tab> entry in _form1.timerDictionary)
            {
                if (entry.Key.Enabled == true)
                {
                    enabled = "Enabled";
                }
                else
                {
                    enabled = "Disabled";
                }
                listBoxTimers.Items.Add(entry.Value.getUsername() + " " + (entry.Key.Interval / 60000).ToString() + " minutes | " + enabled);
            }
        }

        private void buttonDeleteAll_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete all timers?", "Delete All Timers",
              MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                _form1.timerDictionary.Clear();
                listBoxTimers.Items.Clear();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string username = "";
                int minutes = 0;

                string raw = listBoxTimers.SelectedItem.ToString();
                string[] words = raw.Split(' ');
                username = words[0];
                minutes = int.Parse(words[1]);
                minutes = minutes * 60000;
                MessageBox.Show(username + "'s timer has been deleted.");               

                foreach (KeyValuePair<System.Timers.Timer, Tab> entry in _form1.timerDictionary)
                {
                    if ((entry.Key.Interval == minutes) && (entry.Value.getUsername() == username))
                    {
                        _form1.timerDictionary.Remove(entry.Key);
                        listBoxTimers.Items.Clear();
                        break;
                    }
                }
                refreshtimerListBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void textBoxHours_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBoxMinutes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void buttonEnable_Click(object sender, EventArgs e)
        {
            try
            {
                string username = "";
                int minutes = 0;

                string raw = listBoxTimers.SelectedItem.ToString();
                string[] words = raw.Split(' ');
                username = words[0];
                minutes = int.Parse(words[1]);
                minutes = minutes * 60000;

                foreach (KeyValuePair<System.Timers.Timer, Tab> entry in _form1.timerDictionary)
                {
                    if ((entry.Key.Interval == minutes) && (entry.Value.getUsername() == username))
                    {
                        if (entry.Key.Enabled != true) {
                            entry.Key.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("This timer is already enabled.");
                        }
                    }
                    else if ((entry.Key.Interval == minutes) && (entry.Value.getUsername() == username)) {
                        if (entry.Key.Enabled != true)
                        {
                            entry.Key.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("This timer is already enabled.");
                        }
                    }
                }
                refreshtimerListBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonDisable_Click(object sender, EventArgs e)
        {
            try
            {
                string username = "";
                int minutes = 0;

                string raw = listBoxTimers.SelectedItem.ToString();
                string[] words = raw.Split(' ');
                username = words[0];
                minutes = int.Parse(words[1]);
                minutes = minutes * 60000;

                foreach (KeyValuePair<System.Timers.Timer, Tab> entry in _form1.timerDictionary)
                {
                    if ((entry.Key.Interval == minutes) && (entry.Value.getUsername() == username))
                    {
                        if (entry.Key.Enabled != false)
                        {
                            entry.Key.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("This timer is already disabled.");
                        }
                    }
                    else if ((entry.Key.Interval == minutes) && (entry.Value.getUsername() == username)) {
                        if (entry.Key.Enabled != false)
                        {
                            entry.Key.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("This timer is already disabled.");
                        }
                    }
                }
                refreshtimerListBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
