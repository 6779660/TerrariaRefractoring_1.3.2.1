using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Terraria.Terraria.Parsers
{

    /**
     * Prototype
     **/
    public abstract class DedicatedOptionParser
    {
        public string optionName
        {
            get;
            private set;
        }
        public DedicatedOptionParser()
        {
            this.optionName = this.GetType().Name.ToLower();
            this.optionName = this.optionName.Remove(this.optionName.Length - 6);
        }
        public abstract void set(string value);
    }
    /**
     * Static access
     **/
    public class DedicatedConfig
    {
        private static Dictionary<string, DedicatedOptionParser> optionParsers = new Dictionary<string, DedicatedOptionParser>();
        public static void Register(DedicatedOptionParser optionParser)
        {
            optionParsers.Add(optionParser.optionName, optionParser);
        }

        public static void ParseLine(string line)
        {
            try
            {
                string[] parameters = line.Split('=');
                string option = parameters[0].ToLower();
                if (optionParsers.ContainsKey(option))
                {
                    optionParsers[option].set(string.Join("=", parameters, 1, parameters.Length - 1));
                }
            }
            catch { }
        }

        public static void ParseFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (StreamReader streamReader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        ParseLine(line);
                    }
                }
            }
        }

        static DedicatedConfig()
        {
            Register(new WorldOption());
            Register(new PortOption());
            Register(new MaxPlayersOption());
            Register(new PriorityOption());
            Register(new PasswordOption());
            Register(new MotdOption());
            Register(new LangOption());
            Register(new WorldPathOption());
            Register(new WorldNameOption());
            Register(new BanListOption());
            Register(new AutoCreateOption());
            Register(new SecureOption());
            Register(new UPNPOption());
            Register(new NpcStreamOption());
        }

    }
    /**
     * Options
     **/
    class WorldOption : DedicatedOptionParser{

        public override void set(string value)
        {
            Main.worldPathName = value;
        }
    }

    class PortOption : DedicatedOptionParser
    {
        public override void set(string value)
        {
            Netplay.serverPort = Convert.ToInt32(value);
        }
    }

    class MaxPlayersOption : DedicatedOptionParser
    {

        public override void set(string value)
        {
            Main.maxNetPlayers = Convert.ToInt32(value);
        }
    }

    class PriorityOption : DedicatedOptionParser
    {

        public override void set(string value)
        {
            int priorityLevel = Convert.ToInt32(value);
            Process currentProcess = Process.GetCurrentProcess();
            switch (priorityLevel)
            {
                case 0:
                    currentProcess.PriorityClass = ProcessPriorityClass.RealTime;
                    break;
                case 1:
                    currentProcess.PriorityClass = ProcessPriorityClass.High;
                    break;
                case 2:
                    currentProcess.PriorityClass = ProcessPriorityClass.AboveNormal;
                    break;
                case 3:
                    currentProcess.PriorityClass = ProcessPriorityClass.Normal;
                    break;
                case 4:
                    currentProcess.PriorityClass = ProcessPriorityClass.BelowNormal;
                    break;
                case 5:
                    currentProcess.PriorityClass = ProcessPriorityClass.Idle;
                    break;
            };
        }
    }

    class PasswordOption : DedicatedOptionParser
    {

        public override void set(string value)
        {
            Netplay.password = value;
        }
    }

    class MotdOption : DedicatedOptionParser
    {

        public override void set(string value)
        {
             Main.motd = value;
        }
    }

    class LangOption : DedicatedOptionParser
    {
        public override void set(string value)
        {
            Lang.lang = Convert.ToInt32(value);
        }
    }

    class WorldPathOption : DedicatedOptionParser
    {
        public override void set(string value)
        {
            Main.WorldPath = value;
        }
    }

    class WorldNameOption : DedicatedOptionParser
    {
        public override void set(string value)
        {
            Main.worldName = value;
        }
    }

    class BanListOption : DedicatedOptionParser
    {
        public override void set(string value)
        {
            Netplay.banFile = value;
        }
    }

    class AutoCreateOption : DedicatedOptionParser
    {

        public override void set(string value)
        {
            switch (value)
            {
                case "0":
                    Main.autoGen = false;
                    break;
                case "1":
                    Main.maxTilesX = 4200;
                    Main.maxTilesY = 1200;
                    Main.autoGen = true;
                    break;
                case "2":
                    Main.maxTilesX = 6300;
                    Main.maxTilesY = 1800;
                    Main.autoGen = true;
                    break;
                case "3":
                    Main.maxTilesX = 8400;
                    Main.maxTilesY = 2400;
                    Main.autoGen = true;
                    break;
                default:
                    Main.maxTilesX = 6300;
                    Main.maxTilesY = 1800;
                    Main.autoGen = true;
                    break;
            };
        }
    }

    class SecureOption : DedicatedOptionParser
    {
        public override void set(string value)
        {
            Netplay.spamCheck = value.Trim() == "1";
        }
    }

    class UPNPOption : DedicatedOptionParser
    {
        public override void set(string value)
        {
            Netplay.uPNP = value.Trim() == "1";
        }
    }

    class NpcStreamOption : DedicatedOptionParser
    {
        public override void set(string value)
        {
            Main.npcStreamSpeed = Convert.ToInt32(value);
        }
    }
}
