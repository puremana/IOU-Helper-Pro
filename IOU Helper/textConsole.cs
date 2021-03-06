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
using System.Threading;
using PacketDotNet;
using System.IO;

namespace IOU_Helper
{
    public class TextConsole : System.Windows.Forms.TextBox
    {

        ICaptureDevice _device;
        TextConsole _console;
        string log;
        List<Spawn> spawnList = new List<Spawn>();
        DateTime spawnDifference = new DateTime(2010);
        DateTime checkDifference = new DateTime(2010);
        ConsoleRedirection.TextBoxStreamWriter writer = null;

        //Statistic variables
        double totalTime;

        private readonly Plexiglass _plexiglass;
        private readonly Form1 _form1;

        public TextConsole(Plexiglass plexiglass, Form1 form1)
        {
            _plexiglass = plexiglass;
            _form1 = form1;
        }

        /// <summary>
        /// Start listening to a device
        /// </summary>
        /// <param name="device"></param>
        public void Listen(ICaptureDevice device)
        {
            try
            {
                _device = device;
                consoleWrite("Listening to " + device.Name);

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
            catch
            {
                _form1.showPcapError();
            }         
        }

        public void consoleWrite(string str)
        {
            Thread thread = new Thread(() => Console.WriteLine(str));
            thread.IsBackground = true;
            thread.Start();
        }
            
        public void Start(TextConsole console)
        {
            _console = console;
            
            // Instantiate the writer
            ConsoleRedirection.TextBoxStreamWriter _writer = new ConsoleRedirection.TextBoxStreamWriter(console);
            writer = _writer;
            // Redirect the out Console stream
            Console.SetOut(_writer);

            // Print SharpPcap version
            string ver = SharpPcap.Version.VersionString;
            consoleWrite("Welcome to the IOU Helper Pro Console!");
            consoleWrite("SharpPcap Version " + ver);

            consoleWrite("");
        }

        public void stopWriter(bool forGood)
        {
            if (writer != null)
            {
                if (forGood == true) {
                    writer.FlushAsync();
                    writer.Dispose();
                }
                else {
                    writer.FlushAsync();
                    writer.Close();
                }   
            }
        }

        /// <summary>
        /// Prints the time and length of each received packet
        /// </summary>
        private void device_OnPacketArrival(object sender, CaptureEventArgs e)
        {
            this.Process(e.Packet);
            //var len = e.Packet.Data.Length;
            //consoleWrite("{0}:{1}:{2},{3} Len={4}",
            //    time.Hour, time.Minute, time.Second, time.Millisecond, len);
            //consoleWrite(e.Packet.ToString());
        }

        private byte[] findFishGroup = { 0x00, 0x04, 0x66, 0x73, 0x68, 0x70, 0x00 };
        // another failed private byte[] findSpawnInfo = { 0x00, 0x04, 0x32, 0x35, 0x39, 0x30, 0x00 };
        // failed xp private byte[] findSpawnInfo = { 0x00, 0x05, 0x31, 0x37, 0x38, 0x34, 0x31 };
        private byte[] findSpawnInfo = { 0x00, 0x05, 0x73, 0x70, 0x61, 0x77, 0x6e, 0x00 };
        //private byte[] goldXpInfo = { 0x00, 0x02, 0x64, 0x72, 0x00 };
        private Regex regex = new Regex(@"^(\d+)(,\d+)*$");
        //variables for spawn
        double time;
        ulong hp = 0;
        ulong xp = 0;
        ulong gold = 0;
        double infernoLevel = 0;
        uint pmobLevel = 0;

        /// <summary>
        /// Look at packet data and write/ignore
        /// </summary>
        /// <param name="data"></param>
        private void Process(RawCapture packet)
        {
            byte[] data = packet.Data;
            // Open the file to read from. 
            //string readText = File.ReadAllText("log.txt");

            //// Create a file to write to. 
            //string createText = readText + Convert.ToBase64String(data) + Environment.NewLine;
            //File.WriteAllText("log.txt", createText);

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
                                consoleWrite("Kill + Spawn time : " + ddif.ToString() + " seconds");
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
                //for (int i = 0; i < data.Length; ++i)
                //{
                //    //Gold/XP Information
                //    if (data[i] == goldXpInfo[0] && (i + goldXpInfo.Length) < data.Length)
                //    {
                //        log = "gold/xp";

                //        string result = System.Text.Encoding.UTF8.GetString(data);
                //        write = true;
                //        for (int j = 0; j < goldXpInfo.Length; ++j)
                //        {
                //            if (data[i + j] != goldXpInfo[j])
                //            {
                //                write = false;
                //                i += j;
                //                break;
                //            }
                //        }

                //        if (write == true)
                //        {
                //            consoleWrite(result);
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                consoleWrite(ex.Message);
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
            //    consoleWrite("" + data);
            //    return;
            //}

            if (log == "fishGroup")
            {
                consoleWrite("Fish Group : " + data);
            }
            else if (log == "spawnGroup")
            {
                consoleWrite("Spawn Info : " + data);
                string[] values = data.Split(',');
                hp = ulong.Parse(values[4]);
                uint mobLevel = uint.Parse(values[2]);
                pmobLevel = mobLevel;
                if (mobLevel > 250)
                {
                    infernoLevel = Math.Floor((((double)mobLevel - 100) / 150));
                }
                Spawn newSpawn = new Spawn(time, hp, xp, gold, mobLevel);
                spawnList.Add(newSpawn);
            }
            else
            {
                consoleWrite(data);
            }
        }

        /// <summary>
        /// Allows to write to console in other forms
        /// </summary>
        /// <param name="message"></param>
        public void Write(string message)
        {
            //consoleWrite(message);
        }

        /// <summary>
        /// Updates spawn information
        /// </summary>
        public void updateSpawn()
        {
            ulong pDamagePerMinute = 0;
            double ptotalTime = 0;
            double averageTime = 0;
            ulong totalHP = 0;
            ulong pDamagePerSecond;
            int sigFig = _form1.getSigFigures();
            uint mobFilter = _form1.getMobFilter();
            string filterString = mobFilter.ToString();
            int spawnCounter = 0;
            string cardDrop = _form1.getCardDropTime();

            if (mobFilter == 0)
            {
                if (spawnList.Count != 0)
                {
                    foreach (Spawn s in spawnList)
                    {
                        ptotalTime = ptotalTime + s.getTime();
                        totalHP = totalHP + s.getHp();
                    }
                    averageTime = ptotalTime / spawnList.Count;
                    filterString = "None";
                }
                else
                {
                    _plexiglass.updateLabels(filterString, "0", "0", "0", "0", "0", "0, 0");
                    return;
                }
            }
            else
            {
                if (spawnList.Count != 0)
                {
                    foreach (Spawn s in spawnList)
                    {
                        if (mobFilter == s.getMobLevel())
                        {
                            ptotalTime = ptotalTime + s.getTime();
                            totalHP = totalHP + s.getHp();
                            spawnCounter++;
                        }
                    }
                    averageTime = ptotalTime / spawnCounter;
                    pmobLevel = mobFilter;
                    if (mobFilter > 250)
                    {
                        infernoLevel = Math.Floor((((double)mobFilter - 100) / 150));
                    }
                    if (spawnCounter == 0)
                    {
                        _plexiglass.updateLabels(filterString, "0", "0", "0", "0", "0", "0, 0");
                        return;
                    }
                }
                else
                {
                    _plexiglass.updateLabels(filterString, "0", "0", "0", "0", "0", "0, 0");
                    return;
                }    
            }
            
            try
            {
                if (mobFilter == 0)
                {
                    pDamagePerSecond = ((ulong)totalHP / (ulong)spawnList.Count) / ((ulong)averageTime);
                }
                else
                {
                    pDamagePerSecond = ((ulong)totalHP / (ulong)spawnCounter) / ((ulong)averageTime);
                }

                if (_form1.getUnitXPGold() == "Minute")
                {
                    pDamagePerMinute = pDamagePerSecond * 60;
                }
                else if (_form1.getUnitXPGold() == "Hour")
                {
                    pDamagePerMinute = pDamagePerSecond * 3600;
                }

                //Convert to Million
                double pDamage = pDamagePerMinute;
                pDamage = pDamage / 1000000;

                //Kills per minute
                double kPerMin = (60 / averageTime);
                //Cards
                double estCards = 0;
                if (cardDrop == "Minute")
                {
                    estCards = ((1 + (infernoLevel / 2)) * kPerMin);
                }
                else if (cardDrop == "Hour")
                {
                    estCards = ((1 + (infernoLevel / 2)) * kPerMin) * 60;
                }
                else if (cardDrop == "Day")
                {
                    estCards = (((1 + (infernoLevel / 2)) * kPerMin) * 60) * 24;
                }
                estCards = estCards * 0.002;
                if (_form1.getDoubleCards() == true)
                {
                    estCards = estCards * 2;
                }

                //Round down to whatever significant figures
                //Math.Round(pDamage, sigFig);
                averageTime = Math.Round(averageTime, sigFig);
                estCards = Math.Round(estCards, sigFig);
                pDamage = Math.Round(pDamage, sigFig);
                ptotalTime = Math.Round(ptotalTime, sigFig);

                string pDamageString = pDamage.ToString() + "M";
                string totalStats = "";
                if (mobFilter == 0)
                {
                    totalStats = spawnList.Count.ToString() + ", " + ptotalTime.ToString() + "s";
                }
                else
                {
                    totalStats = spawnCounter + ", " + ptotalTime.ToString() + "s";
                }

                //Gold and XP calculations
                //BaseXP = MobLevel*(1+(MobLevel*0.003)) XP/Kill = Round((1+%XPBonus)*BaseXP*PartyModifier*(1+(infTier*0.003))*(1+Floor(infTier*0.001,1)*0.03))*(1+%XPOrb))
                int playerLevel = _form1.getPlayerLevel();
                //Otherwise will multiply negatively
                if (playerLevel < 200) {
                    playerLevel = 200;
                }
                int xpOrb = _form1.getXpOrb();
                int goldOrb = _form1.getGoldOrb();
                double partyBoost = _form1.getPartyBoost();
                int players = _form1.getPlayers();
                double playerBonus = 1;
                int globalXp = _form1.getGlobalXp();
                int globalGold = _form1.getGlobalGold();
                if (players == 2)
                {
                    playerBonus = 0.7;
                }
                else if (players == 3)
                {
                    playerBonus = 0.5;
                }
                else if (players == 4)
                {
                    playerBonus = 0.4;
                }
                double partyModifier = (playerBonus) * (1 + partyBoost);
                double xpOrbBonus = Math.Pow(xpOrb, 2) * 2;
                double goldOrbBonus = Math.Pow(goldOrb, 2) * 2;
                xpOrbBonus = xpOrbBonus / 100;
                goldOrbBonus = goldOrbBonus / 100;
                double xpBonus = ((double)_form1.getXpAdd() * (1 + ((double)globalXp / 100))) / 100;
                double goldBonus = ((((double)_form1.getGoldAdd()) + (0.03 * (playerLevel - 200) + 0.25)) * (1 + ((double)globalGold / 100))) / 100;

                double baseXp = pmobLevel * (1 + (pmobLevel * 0.003));
                double xpPerKill = Math.Round((1 + xpBonus)*baseXp*partyModifier*(1 + (infernoLevel*0.003))*(1 + Math.Floor(infernoLevel*0.01)*0.03))*(1 + xpOrbBonus);

                double baseCoin = Math.Pow(pmobLevel, (1.3 + 0.18));
                double coinValue = Math.Round((baseCoin * (1 + goldBonus) * partyModifier) * (1 + goldOrbBonus));
                if (players == 1)
                {
                    coinValue = coinValue * 1.5;
                }

                string unitXpGold = _form1.getUnitXPGold();
                double gold = 0;
                double xp = 0;

                if (unitXpGold == "Minute")
                {
                    //4.13 is average number of coins for max. - (1 - triplesize%) * (1 + coincount/2) + triplesize% * 3 *  (1 + coincount/2)
                    gold = kPerMin * (coinValue * 4.13);
                    xp = (xpPerKill * kPerMin);
                }
                else if (unitXpGold == "Hour")
                {
                    gold = (kPerMin * (coinValue * 4.13)) * 60;
                    xp = (xpPerKill * kPerMin) * 60;
                }

                gold = gold / 1000000;
                xp = xp / 1000000;
                gold = Math.Round(gold, sigFig);
                xp = Math.Round(xp, sigFig);

                string goldString = gold.ToString() + "M";
                string xpString = xp.ToString() + "M";

                _plexiglass.updateLabels(filterString, xpString, goldString, pDamageString, averageTime.ToString() + "s", estCards.ToString(), totalStats);
        
            }
            catch
            {

            }
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
                    consoleWrite("Stopped listening.");
                    consoleWrite(_device.Statistics.ToString());

                    _device.Close();
                    writer.Close();
                }
                catch (Exception ex)
                {
                    consoleWrite("Stop listening error: " + ex.Message);
                }
            }         
        }

        public void resetStats()
        {
            spawnList.Clear();
            totalTime = 0;
        }
    }
}
