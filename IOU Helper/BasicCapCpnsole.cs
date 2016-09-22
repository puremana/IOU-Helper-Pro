//using System;
//using System.Collections.Generic;
//using System.Collections.Concurrent;
//using SharpPcap;
//using SharpPcap.LibPcap;
//using SharpPcap.AirPcap;
//using SharpPcap.WinPcap;
//using System.Text.RegularExpressions;
//using System.Linq;
//using System.Text;
//using System.Windows.Forms;
//using System.Threading;

//namespace Example3
//{
//    /// <summary>
//    /// Basic capture example
//    /// </summary>
//    public class BasicCapCpnsole
//    {
//        public static void Main(string[] args)
//        {
//            // Print SharpPcap version
//            string ver = SharpPcap.Version.VersionString;
//            Console.WriteLine("SharpPcap {0}, Example3.BasicCap.cs", ver);

//            // Retrieve the device list
//            var devices = CaptureDeviceList.Instance;

//            // If no devices were found print an error
//            if (devices.Count < 1)
//            {
//                Console.WriteLine("No devices were found on this machine");
//                return;
//            }

//            Console.WriteLine();
//            Console.WriteLine("The following devices are available on this machine:");
//            Console.WriteLine("----------------------------------------------------");
//            Console.WriteLine();

//            int i = 0;

//            // Print out the devices
//            foreach (var dev in devices)
//            {
//                /* Description */
//                Console.WriteLine("{0}) {1} {2}", i, dev.Name, dev.Description);
//                i++;
//            }

//            Console.WriteLine();
//            Console.Write("-- Please choose a device to capture: ");
//            i = int.Parse(Console.ReadLine());

//            var device = devices[i];

//            // Register our handler function to the 'packet arrival' event
//            device.OnPacketArrival +=
//                new PacketArrivalEventHandler(device_OnPacketArrival);

//            // Open the device for capturing
//            int readTimeoutMilliseconds = 1000;
//            if (device is AirPcapDevice)
//            {
//                // NOTE: AirPcap devices cannot disable local capture
//                var airPcap = device as AirPcapDevice;
//                airPcap.Open(SharpPcap.WinPcap.OpenFlags.DataTransferUdp, readTimeoutMilliseconds);
//            }
//            else if (device is WinPcapDevice)
//            {
//                var winPcap = device as WinPcapDevice;
//                winPcap.Open(SharpPcap.WinPcap.OpenFlags.DataTransferUdp | SharpPcap.WinPcap.OpenFlags.NoCaptureLocal, readTimeoutMilliseconds);
//            }
//            else if (device is LibPcapLiveDevice)
//            {
//                var livePcapDevice = device as LibPcapLiveDevice;
//                livePcapDevice.Open(DeviceMode.Promiscuous, readTimeoutMilliseconds);
//            }
//            else
//            {
//                throw new System.InvalidOperationException("unknown device type of " + device.GetType().ToString());
//            }

//            device.Filter = "src port 9000";
//            Console.WriteLine();
//            Console.WriteLine("-- Listening on {0} {1}, hit 'Enter' to stop...",
//                device.Name, device.Description);

//            // Start the capturing process
//            device.StartCapture();

//            //Application.EnableVisualStyles();
//            //Application.Run(frm); // or whatever
//            Console.WriteLine("Wait for 'Enter' from the user. DO NOT PRESS ENTER. Unless you want to stop the APP!");
//            Console.ReadLine();

//            // Stop the capturing process
//            device.StopCapture();

//            Console.WriteLine("-- Capture stopped.");

//            // Print out the device statistics
//            Console.WriteLine(device.Statistics.ToString());

//            // Close the pcap device
//            device.Close();
//        }


//        //private static BasicCap.frmFishing frm = new BasicCap.frmFishing();

//        //private static ConcurrentDictionary<int, BasicCap.frmFishing> frms = new ConcurrentDictionary<int, BasicCap.frmFishing>();
//        private static byte[] find = { 0x00, 0x04, 0x66, 0x73, 0x68, 0x70, 0x00 };
//        private static Regex regex = new Regex(@"^(\d+)(,\d+)*$");
//        private static int frmCount = 0;


//        //private static void StartForm(int port, BasicCap.frmFishing myFrm)
//        //{
//        //    (new Thread(() =>
//        //        {
//        //            Application.EnableVisualStyles();
//        //            Application.Run(myFrm);
//        //            for (int i = 0; i < 5; ++i)
//        //            {
//        //                if (frms.TryRemove(port, out myFrm))
//        //                {
//        //                    break;
//        //                }
//        //            }
//        //        }
//        //        )).Start();

//        //}

//        /// <summary>
//        /// Prints the time and length of each received packet
//        /// </summary>
//        private static void device_OnPacketArrival(object sender, CaptureEventArgs e)
//        {
//            //BasicCap.frmFishing myFrm;
//            IOU_Helper.Form1 form;
//            Plexiglass drawForm = form.getOverlay();

//            string fish;
//            if (process(e.Packet.Data, out fish))
//            {
//                var packet = PacketDotNet.Packet.ParsePacket(e.Packet.LinkLayerType, e.Packet.Data);


//                var tcpPacket = PacketDotNet.TcpPacket.GetEncapsulated(packet);
//                if (tcpPacket != null)
//                {
//                    var ipPacket = (PacketDotNet.IpPacket)tcpPacket.ParentPacket;
//                    System.Net.IPAddress srcIp = ipPacket.SourceAddress;
//                    System.Net.IPAddress dstIp = ipPacket.DestinationAddress;
//                    int srcPort = tcpPacket.SourcePort;
//                    int dstPort = tcpPacket.DestinationPort;

//                    if (!frms.TryGetValue(dstPort, out myFrm))
//                    {
//                        frms.TryAdd(dstPort, new BasicCap.frmFishing());

//                        if (!frms.TryGetValue(dstPort, out myFrm))
//                        {
//                            throw new Exception("hmm stupid ConcurrentDictionary");
//                        }

//                        myFrm.Text = myFrm.Text + " Client " + Interlocked.Increment(ref frmCount).ToString();
//                        StartForm(dstPort, myFrm);
//                    }


//                    logNewLine(fish, myFrm);
//                }
//            }

//        }
//        private static bool process(byte[] data, out string fish)
//        {
//            fish = "";
//            bool ok = false;

//            try
//            {

//                var sb = new StringBuilder();

//                for (int i = 0; i < data.Length; ++i)
//                {

//                    if (data[i] == find[0] && (i + find.Length) < data.Length)
//                    {
//                        ok = true;
//                        for (int j = 0; j < find.Length; ++j)
//                        {
//                            if (data[i + j] != find[j])
//                            {
//                                ok = false;
//                                i += j;
//                                break;
//                            }
//                        }

//                        if (ok)
//                        {
//                            i += find.Length;
//                            var toRead = data[i++] - 1;

//                            while (toRead-- > 0)
//                            {
//                                sb.Append((char)data[i++]);

//                            }

//                            fish = sb.ToString();
//                            sb.Length = 0;

//                            break;
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                ok = false;
//                Console.WriteLine(ex.Message);
//            }

//            return ok;
//        }

//        private static void logNewLine(string data, BasicCap.frmFishing myFrm)
//        {
//            if (!regex.IsMatch(data))
//            {
//                Console.WriteLine("INVALID STRING: " + data);
//                if (myFrm.Log) System.IO.File.AppendAllText(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\ioufish.log", myFrm.Text + " " + data + Environment.NewLine);
//                return;
//            }

//            var lookingMust = myFrm.lookingMust;
//            var lookingFor = myFrm.lookingFor;
//            var lookingForOne = myFrm.lookingOneOnly;
//            var ShowCatchConsole = myFrm.ShowCatchConsole;

//            var lookingAll = lookingFor.Concat(lookingMust).Concat(lookingForOne).Distinct();

//            var fish = data.Split(',');
//            double howMany = fish.Count();

//            var one = from f in fish join o in lookingForOne on f equals o select f;

//            var must = from f in fish join m in lookingMust on f equals m select f;

//            var forbid = fish.Except(lookingAll);

//            if (!forbid.Any() && //pool only have fish in "only one" look and must
//                must.Any() &&  //pool must have one or more from must
//                one.Count() <= 1 //pool should have at max one fish from "only one", zero is ok too
//                )
//            {
//                if (ShowCatchConsole) data = "CATCH ---- " + data;
//                myFrm.CatchMe();
//            }
//            else if (must.Any() && // must have at least one or more from must
//                   (must.Count() / howMany) >= 0.60 //  must be 2/3 or 3/4 from must
//                   )
//            {
//                if (!forbid.Any() || forbid.Select(x => int.Parse(x)).Min() >= myFrm.MinMust) //last fish must be equal or above level
//                {
//                    if (ShowCatchConsole) data = "CATCH -##- " + data;
//                    myFrm.CatchMe();
//                }
//                else
//                {
//                    if (ShowCatchConsole) data = "CATCH -##- " + data + " under minimum level";
//                }
//            }

//            Console.WriteLine((myFrm.ShowClientNumber ? myFrm.Text + " " : "") + data);
//            if (myFrm.Log) System.IO.File.AppendAllText(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\ioufish.csv", (myFrm.ShowClientNumber ? myFrm.Text + " " : "") + data + Environment.NewLine);
//        }
//    }
//}

