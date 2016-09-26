using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpPcap;
using SharpPcap.LibPcap;
using SharpPcap.AirPcap;
using SharpPcap.WinPcap;

namespace IOU_Helper
{
    public partial class FormDevices : Form
    {
        private readonly TextConsole _console;
        private readonly Form1 _form1;
        private CaptureDeviceList devices;

        public FormDevices(TextConsole console, Form1 form)
        {
            InitializeComponent();
            _console = console;
            _form1 = form;
        }

        private void FormDevices_Load(object sender, EventArgs e)
        {
            // Retrieve the device list
            devices = CaptureDeviceList.Instance;

            int i = 0;

            // Print out the devices
            foreach (var dev in devices)
            {
                /* Description */
                comboBoxDevices.Items.Add(i + ": " + dev.Name + dev.Description);
                i++;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            _console.Listen(devices[comboBoxDevices.SelectedIndex]);
            _form1.started();
            this.Close();
        }
    }
}
