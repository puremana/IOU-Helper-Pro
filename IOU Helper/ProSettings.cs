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

            _form1.setOverlayColor(labelColor.BackColor);
            _form1.applyProSettings(time);
            Properties.Settings.Default.Save();
            MessageBox.Show("IOU Helper Pro settings have been applied.");
            this.Close();
        }
    }
}
