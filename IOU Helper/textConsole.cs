﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpPcap;
using SharpPcap.LibPcap;
using SharpPcap.AirPcap;
using SharpPcap.WinPcap;
using System.Text.RegularExpressions;

namespace IOU_Helper
{
    public class TextConsole : System.Windows.Forms.TextBox
    {
        ICaptureDevice _device;
        TextConsole _console;
        String log;

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

            device.Filter = "src port 9000";

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
        private void device_OnPacketArrival(object sender, CaptureEventArgs e)
        {
            this.Process(e.Packet.Data);
        }

        private byte[] findFishGroup = { 0x00, 0x04, 0x66, 0x73, 0x68, 0x70, 0x00 };
        private Regex regex = new Regex(@"^(\d+)(,\d+)*$");

        private void Process(byte[] data)
        {
            try
            {
                bool ok = false;
                var sb = new StringBuilder();

                for (int i = 0; i < data.Length; ++i)
                {

                    if (data[i] == findFishGroup[0] && (i + findFishGroup.Length) < data.Length)
                    {
                        log = "fishGroup";
                        ok = true;
                        for (int j = 0; j < findFishGroup.Length; ++j)
                        {
                            if (data[i + j] != findFishGroup[j])
                            {
                                ok = false;
                                i += j;
                                break;
                            }
                        }

                        if (ok)
                        {
                            i += findFishGroup.Length;
                            var toRead = data[i++] - 1;

                            while (toRead-- > 0)
                            {
                                sb.Append((char)data[i++]);

                            }
                            logNewLine(sb.ToString());

                            sb.Length = 0;

                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void logNewLine(string data)
        {
            if (!regex.IsMatch(data))
            {
                Console.WriteLine("INVALID STRING: " + data);
                return;
            }

            if (log == "fishGroup")
            {
                Console.WriteLine("Fish Group : " + data);
            }
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
