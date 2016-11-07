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
                //_form1.setOverlayColor(color);

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
    }
}
