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
    }
}
