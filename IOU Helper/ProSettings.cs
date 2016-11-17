using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IOU_Helper
{
    public partial class ProSettings : Form
    {
        private readonly Form1 _form1;
        public ProSettings(Form1 form1)
        {
            InitializeComponent();
            _form1 = form1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            colorDlg.AllowFullOpen = true;
            colorDlg.AnyColor = true;
            colorDlg.SolidColorOnly = false;
            colorDlg.Color = Color.Red;

            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                Color color = colorDlg.Color;

                labelColor.Text = color.ToString();
                labelColor.BackColor = color;
            }
        }

        private void ProSettings_Load(object sender, EventArgs e)
        {
            comboBoxUnitXpGold.SelectedIndex = comboBoxUnitXpGold.FindString(Properties.Settings.Default.unitXpGold);
            comboBoxCardDrop.SelectedIndex = comboBoxCardDrop.FindString(Properties.Settings.Default.cardDropTime);
            textBoxRefreshTimer.Text = Properties.Settings.Default.refreshTimer.ToString();
            comboBoxSigFig.SelectedIndex = comboBoxSigFig.FindString(Properties.Settings.Default.sigFigures.ToString());
            if (Properties.Settings.Default.doubleCards == true)
            {
                radioButtonDCYes.Checked = true;
            }
            else
            {
                radioButtonDCNo.Checked = true;
            }

            comboBoxAscTier.SelectedIndex = comboBoxAscTier.FindString(Properties.Settings.Default.ascTier);

            if (Properties.Settings.Default.moveOverlay == true)
            {
                radioButtonMOYes.Checked = true;
            }
            else
            {
                radioButtonMONo.Checked = true;
            }

            labelColor.BackColor = Properties.Settings.Default.overlayColor;
            labelColor.Text = Properties.Settings.Default.overlayColor.ToString();

            textBoxGoldAdd.Text = Properties.Settings.Default.goldAdd.ToString();
            textBoxXpAdd.Text = Properties.Settings.Default.xpAdd.ToString();
            comboBoxGoldOrb.SelectedIndex = comboBoxGoldOrb.FindString(Properties.Settings.Default.goldOrb.ToString());
            comboBoxXpOrb.SelectedIndex = comboBoxXpOrb.FindString(Properties.Settings.Default.xpOrb.ToString());
            double partyBoost = Properties.Settings.Default.partyBoost * 10;
            int pBoost = (int)partyBoost;
            comboBoxPartyBoost.SelectedIndex = comboBoxPartyBoost.FindString(pBoost.ToString());
            comboBoxPlayers.SelectedIndex = comboBoxPlayers.FindString(Properties.Settings.Default.players.ToString());
            textBoxGlobalXp.Text = Properties.Settings.Default.globalXp.ToString();
            textBoxGlobalGold.Text = Properties.Settings.Default.globalGold.ToString();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonRestore_Click(object sender, EventArgs e)
        {
            comboBoxUnitXpGold.SelectedIndex = comboBoxUnitXpGold.FindString("Minute");
            comboBoxCardDrop.SelectedIndex = comboBoxCardDrop.FindString("Day");
            textBoxRefreshTimer.Text = "30";
            comboBoxSigFig.SelectedIndex = comboBoxSigFig.FindString("10");
            if (radioButtonDCNo.Checked != true)
            {
                radioButtonDCNo.Checked = true;
            }

            comboBoxAscTier.SelectedIndex = comboBoxAscTier.FindString("AT3");

            if (radioButtonMOYes.Checked != true)
            {
                radioButtonMOYes.Checked = true;
            }

            labelColor.BackColor = Color.White;
            labelColor.Text = Color.White.ToString();

            textBoxGoldAdd.Text = "0";
            textBoxXpAdd.Text = "0";
            comboBoxGoldOrb.SelectedIndex = comboBoxGoldOrb.FindString("0");
            comboBoxXpOrb.SelectedIndex = comboBoxXpOrb.FindString("0");
            comboBoxPartyBoost.SelectedIndex = comboBoxPartyBoost.FindString("5");
            comboBoxPlayers.SelectedIndex = comboBoxPlayers.FindString("4");

            textBoxGlobalGold.Text = "0";
            textBoxGlobalXp.Text = "0";
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            int time = int.Parse(textBoxRefreshTimer.Text);

            //Apply Properties
            Properties.Settings.Default.unitXpGold = comboBoxUnitXpGold.SelectedItem.ToString();

            Properties.Settings.Default.cardDropTime = comboBoxCardDrop.SelectedItem.ToString();
            Properties.Settings.Default.refreshTimer = int.Parse(textBoxRefreshTimer.Text);
            Properties.Settings.Default.sigFigures = int.Parse(comboBoxSigFig.SelectedItem.ToString());
            if (radioButtonDCYes.Checked == true)
            {
                Properties.Settings.Default.doubleCards = true;
            }
            else
            {
                Properties.Settings.Default.doubleCards = false;
            }

            Properties.Settings.Default.ascTier = comboBoxAscTier.SelectedItem.ToString();

            if (radioButtonMOYes.Checked == true)
            {
                Properties.Settings.Default.moveOverlay = true;
            }
            else
            {
                Properties.Settings.Default.moveOverlay = false;
            }

            Properties.Settings.Default.overlayColor = labelColor.BackColor;

            //Gold and XP Settings
            Properties.Settings.Default.goldAdd = int.Parse(textBoxGoldAdd.Text);
            Properties.Settings.Default.xpAdd = int.Parse(textBoxXpAdd.Text);
            Properties.Settings.Default.goldOrb = int.Parse(comboBoxGoldOrb.SelectedItem.ToString());
            Properties.Settings.Default.xpOrb = int.Parse(comboBoxXpOrb.SelectedItem.ToString());
            double partyBoost = double.Parse(comboBoxPartyBoost.SelectedItem.ToString());
            partyBoost = partyBoost / 10;
            Properties.Settings.Default.partyBoost = partyBoost;
            Properties.Settings.Default.players = int.Parse(comboBoxPlayers.SelectedItem.ToString());
            Properties.Settings.Default.globalXp = int.Parse(textBoxGlobalXp.Text);
            Properties.Settings.Default.globalGold = int.Parse(textBoxGlobalGold.Text);

            _form1.setOverlayColor(labelColor.BackColor);
            _form1.applyProSettings(time);
            Properties.Settings.Default.Save();
            MessageBox.Show("IOU Helper Pro settings have been applied.");
            this.Close();
        }

        private void textBoxGoldAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.')
            {
                e.Handled = true;
            }
        }

        private void textBoxXpAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.')
            {
                e.Handled = true;
            }
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            textBoxHelp.Text = "Xp, Gold, Party Damage Unit: This refers to the statistics of the xp, gold and party damage are displayed on the statistics panel. You can choose the option of display per minute or per hour.";
        }

        private void comboBoxUnitXpGold_MouseHover(object sender, EventArgs e)
        {
            textBoxHelp.Text = "Xp, Gold, Party Damage Unit: This refers to the statistics of the xp, gold and party damage are displayed on the statistics panel. You can choose the option of display per minute or per hour.";
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            textBoxHelp.Text = "Card Drop Time: This refers to the rate at which you want to estimate how many cards are dropped. This is displayed on the statistics panel. You can choose between per minute, per hour or per day.";
        }

        private void comboBoxCardDrop_MouseHover(object sender, EventArgs e)
        {
            textBoxHelp.Text = "Card Drop Time: This refers to the rate at which you want to estimate how many cards are dropped. This is displayed on the statistics panel. You can choose between per minute, per hour or per day.";
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            textBoxHelp.Text = "Refresh Timer: This refers to the interval (in seconds) you wish the statistics panel to refresh/update at. It should be noted there is a manual refresh stats option under the pro tools dropdown.";
        }

        private void textBoxRefreshTimer_MouseHover(object sender, EventArgs e)
        {
            textBoxHelp.Text = "Refresh Timer: This refers to the interval (in seconds) you wish the statistics panel to refresh/update at. It should be noted there is a manual refresh stats option under the pro tools dropdown.";
        }

        private void label4_MouseHover(object sender, EventArgs e)
        {
            textBoxHelp.Text = "Round to # Decimals: This refers to the number of decimal places you wish to see on the statistics panel.";
        }

        private void comboBoxSigFig_MouseHover(object sender, EventArgs e)
        {
            textBoxHelp.Text = "Round to # Decimals: This refers to the number of decimal places you wish to see on the statistics panel.";
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            textBoxHelp.Text = "Hover over something to learn more information.";
        }

        private void label5_MouseHover(object sender, EventArgs e)
        {
            textBoxHelp.Text = "Total Gold Additive Bonus: This refers to all of your character upgrades in game that are additive. This includes your gold upgrades, guild upgrades, account upgrades, support and lineage level bonuses.";
        }

        private void textBoxGoldAdd_MouseHover(object sender, EventArgs e)
        {
            textBoxHelp.Text = "Total Gold Additive Bonus: This refers to all of your character upgrades in game that are additive. This includes your gold upgrades, guild upgrades, account upgrades, support and lineage level bonuses.";
        }

        private void label13_MouseHover(object sender, EventArgs e)
        {
            textBoxHelp.Text = "Total Xp Additive Bonus: This refers to all of your character upgrades in game that are additive. This includes your guild upgrades, account upgrades, support and lineage level bonuses.";
        }

        private void textBoxXpAdd_MouseHover(object sender, EventArgs e)
        {
            textBoxHelp.Text = "Total Xp Additive Bonus: This refers to all of your character upgrades in game that are additive. This includes your guild upgrades, account upgrades, support and lineage level bonuses.";
        }

        private void label9_MouseHover(object sender, EventArgs e)
        {
            textBoxHelp.Text = "Gold Orb Tier: This refers to the tier of your gold orb in game. At this point IOU Helper Pro only takes the tier of the orb and not the level as well.";
        }

        private void comboBoxGoldOrb_MouseHover(object sender, EventArgs e)
        {
            textBoxHelp.Text = "Gold Orb Tier: This refers to the tier of your gold orb in game. At this point IOU Helper Pro only takes the tier of the orb and not the level as well.";
        }

        private void label10_MouseHover(object sender, EventArgs e)
        {
            textBoxHelp.Text = "Xp Orb Tier: This refers to the tier of your xp orb in game. At this point IOU Helper Pro only takes the tier of the orb and not the level as well.";
        }

        private void comboBoxXpOrb_MouseHover(object sender, EventArgs e)
        {
            textBoxHelp.Text = "Xp Orb Tier: This refers to the tier of your xp orb in game. At this point IOU Helper Pro only takes the tier of the orb and not the level as well.";
        }

        private void label15_MouseHover(object sender, EventArgs e)
        {
            textBoxHelp.Text = "Global Gold: This refers to the current gold event bonus. i.e 20%";
        }

        private void textBox1_MouseHover(object sender, EventArgs e)
        {
            textBoxHelp.Text = "Global Gold: This refers to the current gold event bonus. i.e 20%";
        }

        private void label18_MouseHover(object sender, EventArgs e)
        {
            textBoxHelp.Text = "Global Xp: This refers to the current xp event bonus. i.e 20%";
        }

        private void textBox2_MouseHover(object sender, EventArgs e)
        {
            textBoxHelp.Text = "Global Xp: This refers to the current xp event bonus. i.e 20%";
        }

        private void label11_MouseHover(object sender, EventArgs e)
        {
            textBoxHelp.Text = "Players in Party: This refers to the total number of players in your current party.";
        }

        private void comboBoxPlayers_MouseHover(object sender, EventArgs e)
        {
            textBoxHelp.Text = "Players in Party: This refers to the total number of players in your current party.";
        }

        private void label8_MouseHover(object sender, EventArgs e)
        {
            textBoxHelp.Text = "Party Boost: This refers to your current ascension level upgrade in party boost.";
        }

        private void comboBoxPartyBoost_MouseHover(object sender, EventArgs e)
        {
            textBoxHelp.Text = "Party Boost: This refers to your current ascension level upgrade in party boost.";
        }

        private void radioButtonDCYes_MouseHover(object sender, EventArgs e)
        {
            textBoxHelp.Text = "Double Cards, Yes: This displays double the number of cards estimated on the statistics panel.";
        }

        private void radioButtonDCNo_MouseHover(object sender, EventArgs e)
        {
            textBoxHelp.Text = "Double Cards, No: This displays the normal number of cards estimated on the statistics panel.";
        }

        private void label6_MouseHover(object sender, EventArgs e)
        {
            textBoxHelp.Text = "Ascension Tier: This refers to the current ascension tier you are on. If you do not know what ascension tier you are on, if you are from level 1-40, pick AT0, if you are 40-75 pick AT1, if you are 75-130, pick AT2 and if you are above level 130, pick AT3.";
        }

        private void comboBoxAscTier_MouseHover(object sender, EventArgs e)
        {
            textBoxHelp.Text = "Ascension Tier: This refers to the current ascension tier you are on. If you do not know what ascension tier you are on, if you are from level 1-40, pick AT0, if you are 40-75 pick AT1, if you are 75-130, pick AT2 and if you are above level 130, pick AT3.";
        }

        private void radioButtonMOYes_MouseHover(object sender, EventArgs e)
        {
            textBoxHelp.Text = "Move Overlay on Resize, Yes: Checking this option will mean that the Console and Statistics panels will resize and restore their default locaion whenever the client is resized. This overrides your custom panel placements.";
        }

        private void radioButtonMONo_MouseHover(object sender, EventArgs e)
        {
            textBoxHelp.Text = "Move Overlay on Resize, No: Checking this option will mean that the Console and Statistics panels will not be resized or change location when the client is resized, excluding when the packet listener is started.";
        }

        private void buttonOverlayColor_MouseHover(object sender, EventArgs e)
        {
            textBoxHelp.Text = "Overlay Color: This allows you to change the color of the Console and Statistics panels to a color of your choosing.";
        }

        private void labelColor_MouseHover(object sender, EventArgs e)
        {
            textBoxHelp.Text = "Overlay Color: This allows you to change the color of the Console and Statistics panels to a color of your choosing.";
        }

        private void buttonRestore_MouseHover(object sender, EventArgs e)
        {
            textBoxHelp.Text = "Restore Default: This will restore the default pro settings. Note this will not automatically apply these settings.";
        }

        private void buttonCancel_MouseHover(object sender, EventArgs e)
        {
            textBoxHelp.Text = "Cancel: This will close the Pro Settings interface.";
        }

        private void buttonApply_MouseHover(object sender, EventArgs e)
        {
            textBoxHelp.Text = "Apply: This will apply the currently set settings and save them within the application for the future. These settings will be loaded on startup of IOU Helper Pro.";
        }

        private void textBoxGlobalGold_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.')
            {
                e.Handled = true;
            }
        }

        private void textBoxGlobalXp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.')
            {
                e.Handled = true;
            }
        }
    }
}
