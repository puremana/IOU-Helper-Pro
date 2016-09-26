using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpPcap;
using SharpPcap.LibPcap;
using SharpPcap.AirPcap;
using SharpPcap.WinPcap;

namespace IOU_Helper
{
    public class TextConsole : System.Windows.Forms.TextBox
    {
        ICaptureDevice _device;
        TextConsole _console;
        public void Listen(ICaptureDevice device)
        {
            _device = device;
            Console.WriteLine("Listening to " + device.Name);

            // Register our handler function to the 'packet arrival' event
            device.OnPacketArrival +=
                new PacketArrivalEventHandler(device_OnPacketArrival);

            // Open the device for capturing
            int readTimeoutMilliseconds = 1000;
            if (device is AirPcapDevice)
            {
                // NOTE: AirPcap devices cannot disable local capture
                var airPcap = device as AirPcapDevice;
                airPcap.Open(SharpPcap.WinPcap.OpenFlags.DataTransferUdp, readTimeoutMilliseconds);
            }
            else if (device is WinPcapDevice)
            {
                var winPcap = device as WinPcapDevice;
                winPcap.Open(SharpPcap.WinPcap.OpenFlags.DataTransferUdp | SharpPcap.WinPcap.OpenFlags.NoCaptureLocal, readTimeoutMilliseconds);
            }
            else if (device is LibPcapLiveDevice)
            {
                var livePcapDevice = device as LibPcapLiveDevice;
                livePcapDevice.Open(DeviceMode.Promiscuous, readTimeoutMilliseconds);
            }
            else
            {
                throw new System.InvalidOperationException("unknown device type of " + device.GetType().ToString());
            }

            // Start the capturing process
            device.StartCapture();
        }

        public void Start(TextConsole console)
        {
            _console = console;

            // Instantiate the writer
            ConsoleRedirection.TextBoxStreamWriter _writer = new ConsoleRedirection.TextBoxStreamWriter(console);
            // Redirect the out Console stream
            Console.SetOut(_writer);

            // Print SharpPcap version
            string ver = SharpPcap.Version.VersionString;
            Console.WriteLine("Welcome to the IOU Helper Pro Console!");
            Console.WriteLine("SharpPcap Version " + ver);

            Console.WriteLine();
        }

        /// <summary>
        /// Prints the time and length of each received packet
        /// </summary>
        private static void device_OnPacketArrival(object sender, CaptureEventArgs e)
        {
            var time = e.Packet.Timeval.Date;
            var len = e.Packet.Data.Length;
            //string line = ("{0}:{1}:{2},{3} Len={4}" +
            //    time.Hour + time.Minute + time.Second + time.Millisecond + len);

            Console.WriteLine("{0}:{1}:{2},{3} Len={4}" +
                time.Hour + time.Minute + time.Second + time.Millisecond + len);
            Console.WriteLine("{0}:{1}:{2},{3} Len={4}",
                time.Hour, time.Minute, time.Second, time.Millisecond, len);
            Console.WriteLine(e.Packet.ToString());
        }

        public void Write(string message)
        {
            Console.WriteLine(message);
        }

        public void StopListening()
        {
            if (_device != null)
            {
                try
                {
                    _device.StopCapture();
                    Console.WriteLine("Stopped listening.");
                    Console.WriteLine(_device.Statistics.ToString());

                    _device.Close();
                }
                catch (Exception ex)
                {
                    
                }
            }         
        }
    }
}
