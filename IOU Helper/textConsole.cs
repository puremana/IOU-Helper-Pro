using System;
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
        List<Spawn> spawnList = new List<Spawn>();
        DateTime spawnDifference = new DateTime(2010);
        DateTime checkDifference = new DateTime(2010);

        //Statistic variables
        double totalTime;
        string min_hour = "minute";

        private readonly Plexiglass _plexiglass;

        public TextConsole(Plexiglass plexiglass)
        {
            _plexiglass = plexiglass;
        }

        /// <summary>
        /// Start listening to a device
        /// </summary>
        /// <param name="device"></param>
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
            this.Process(e.Packet);
            //var len = e.Packet.Data.Length;
            //Console.WriteLine("{0}:{1}:{2},{3} Len={4}",
            //    time.Hour, time.Minute, time.Second, time.Millisecond, len);
            //Console.WriteLine(e.Packet.ToString());
        }

        private byte[] findFishGroup = { 0x00, 0x04, 0x66, 0x73, 0x68, 0x70, 0x00 };
        // another failed private byte[] findSpawnInfo = { 0x00, 0x04, 0x32, 0x35, 0x39, 0x30, 0x00 };
        // failed xp private byte[] findSpawnInfo = { 0x00, 0x05, 0x31, 0x37, 0x38, 0x34, 0x31 };
        private byte[] findSpawnInfo = { 0x00, 0x05, 0x73, 0x70, 0x61, 0x77, 0x6e, 0x00 };
        private Regex regex = new Regex(@"^(\d+)(,\d+)*$");
        //variables for spawn
        double time;
        ulong hp = 0;
        ulong xp = 0;
        ulong gold = 0;

        /// <summary>
        /// Look at packet data and write/ignore
        /// </summary>
        /// <param name="data"></param>
        private void Process(RawCapture packet)
        {
            byte[] data = packet.Data;
            try
            {
                bool write = false;
                var sb = new StringBuilder();

                for (int i = 0; i < data.Length; ++i)
                {
                    //Fish Group
                    if (data[i] == findFishGroup[0] && (i + findFishGroup.Length) < data.Length)
                    {
                        log = "fishGroup";
                        write = true;
                        for (int j = 0; j < findFishGroup.Length; ++j)
                        {
                            if (data[i + j] != findFishGroup[j])
                            {
                                write = false;
                                i += j;
                                break;
                            }
                        }

                        if (write == true)
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
                for (int i = 0; i < data.Length; ++i)
                {
                    //Spawn Information
                    if (data[i] == findSpawnInfo[0] && (i + findSpawnInfo.Length) < data.Length)
                    {
                        log = "spawnGroup";
                        write = true;
                        for (int j = 0; j < findSpawnInfo.Length; ++j)
                        {
                            if (data[i + j] != findSpawnInfo[j])
                            {
                                write = false;
                                i += j;
                                break;
                            }
                        }

                        if (write == true)
                        {
                            i += findSpawnInfo.Length;
                            var toRead = data[i++] - 1;

                            while (toRead-- > 0)
                            {
                                sb.Append((char)data[i++]);
                            }
                            if (spawnDifference.Year == checkDifference.Year)
                            {
                                spawnDifference = packet.Timeval.Date;
                            }
                            else
                            {
                                DateTime tempTime = packet.Timeval.Date;
                                TimeSpan difference = tempTime.Subtract(spawnDifference);
                                double ddif = difference.TotalSeconds;
                                Console.WriteLine("Kill + Spawn time : " + ddif.ToString() + " seconds");
                                totalTime = totalTime + ddif;
                                time = ddif;
                                spawnDifference = packet.Timeval.Date;
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

        /// <summary>
        /// Write data to console
        /// </summary>
        /// <param name="data"></param>
        private void logNewLine(string data)
        {
            //if (!regex.IsMatch(data))
            //{
            //    Console.WriteLine("" + data);
            //    return;
            //}

            if (log == "fishGroup")
            {
                Console.WriteLine("Fish Group : " + data);
            }
            else if (log == "spawnGroup")
            {
                Console.WriteLine("Spawn Info : " + data);
                string[] values = data.Split(',');
                hp = ulong.Parse(values[4]);
                Spawn newSpawn = new Spawn(time, hp, xp, gold);
                spawnList.Add(newSpawn);
            }
            else
            {
                Console.WriteLine(data);
            }
        }

        /// <summary>
        /// Allows to write to console in other forms
        /// </summary>
        /// <param name="message"></param>
        public void Write(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Updates spawn information
        /// </summary>
        public void updateSpawn()
        {
            ulong pDamagePerMinute = 0;
            double ptotalTime = 0;
            double averageTime = 0;
            if (min_hour == "minute")
            {

                ulong totalHP = 0;
                foreach (Spawn s in spawnList)
                {
                    ptotalTime = totalTime + s.getTime();
                    totalHP = totalHP + s.getHp();
                }
                ulong pDamagePerSecond;
                averageTime = ptotalTime / spawnList.Count;
                pDamagePerSecond = ((ulong)totalHP / (ulong)spawnList.Count) / ((ulong)averageTime);
                pDamagePerMinute = pDamagePerSecond * 60;
            }
            else if (min_hour == "hour")
            {

            }

            _plexiglass.updateLabels("username", "xp", "gold", pDamagePerMinute.ToString(), averageTime.ToString(), spawnList.Count.ToString(), totalTime.ToString());
        }

        /// <summary>
        /// Stop listening to device
        /// </summary>
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
                    Console.WriteLine("Stop listening error: " + ex.Message);
                }
            }         
        }

        public void resetStats()
        {
            spawnList.Clear();
        }
    }
}
