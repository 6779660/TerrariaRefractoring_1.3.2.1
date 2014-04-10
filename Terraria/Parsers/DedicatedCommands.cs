using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terraria.Terraria.Parsers
{
    /**
    * Prototype
    **/
    public abstract class DedicatedCommandParser
    {
        public string optionName
        {
            get;
            protected set;
        }
        public string description
        {
            get;
            private set;
        }
        public DedicatedCommandParser(string description)
        {
            this.optionName = this.GetType().Name.ToLower();
            this.optionName = this.optionName.Remove(this.optionName.Length - 7);
            this.description = description;
        }

        public abstract void execute(params string[] parameters);
    }
    /**
     * Static access
     **/
    public class DedicatedCommands
    {
        public static readonly Dictionary<string, DedicatedCommandParser> dedicatedCommandParsers = new Dictionary<string, DedicatedCommandParser>();
        public static void Register(DedicatedCommandParser optionParser)
        {
            dedicatedCommandParsers.Add(optionParser.optionName, optionParser);
        }

        static DedicatedCommands()
        {
            Register(new HelpCommand());
            Register(new SettleCommand());
            Register(new DawnCommand());
            Register(new DuskCommand());
            Register(new NoonCommand());
            Register(new MidnightCommand());
            Register(new ExitCommand());
            Register(new ExitNoSaveCommand());
            Register(new FPSCommand());
            Register(new SaveCommand());
            Register(new TimeCommand());
            Register(new MaxPlayersCommand());
            Register(new PortCommand());
            Register(new VersionCommand());
            Register(new ClearCommand());
            Register(new PlayingCommand());
            Register(new MOTDCommand());
            Register(new PasswordCommand());
            Register(new SayCommand());
            Register(new KickCommand());
            Register(new BanCommand());
        }

        public static void load()
        {

        }

        public static void ParseCommand(string commandLine)
        {
            try
            {
                string[] parameters = commandLine.Split(' ');
                string command = parameters[0].ToLower();
                if (dedicatedCommandParsers.ContainsKey(command))
                {
                    string[] commandParams = new string[0];
                    try { 
                        commandParams = new string[parameters.Length - 1];
                        Array.Copy(parameters, 1, commandParams, 0, parameters.Length - 1); 
                    }
                    catch { }
                    dedicatedCommandParsers[command].execute(commandParams);
                }
                else Console.WriteLine("Command not found.");
            }
            catch { }
        }
    }
    /**
     * Commands
     **/
    class HelpCommand : DedicatedCommandParser
    {
        private const string leftAlignFormat = "{0,15}  {1,50}";
        public HelpCommand() : base("Displays a list of commands.") { }
        public override void execute(params string[] parameters)
        {
            Console.WriteLine("Available commands:");
            Console.WriteLine("");
            foreach (DedicatedCommandParser command in DedicatedCommands.dedicatedCommandParsers.Values)
            {
                Console.WriteLine(leftAlignFormat,
                    command.optionName,
                    command.description
                );
            }
        }
    }

    class SettleCommand : DedicatedCommandParser
    {
        public SettleCommand() : base("Settle all water.") { }
        public override void execute(params string[] parameters)
        {
            if (!Liquid.panicMode) Liquid.StartPanic();
            else Console.WriteLine("Water is already settling");
        }
    }

    class DawnCommand : DedicatedCommandParser
    {
        public DawnCommand() : base("Change time to dawn.") { }
        public override void execute(params string[] parameters)
        {
            Main.dayTime = true;
            Main.time = 0.0;
            NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
        }
    }

    class DuskCommand : DedicatedCommandParser
    {
        public DuskCommand() : base("Change time to dusk.") { }
        public override void execute(params string[] parameters)
        {
            Main.dayTime = false;
            Main.time = 0.0;
            NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
        }
    }

    class NoonCommand : DedicatedCommandParser
    {
        public NoonCommand() : base("Change time to noon.") { }
        public override void execute(params string[] parameters)
        {
            Main.dayTime = true;
            Main.time = 27000.0;
            NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
        }
    }

    class MidnightCommand : DedicatedCommandParser
    {
        public MidnightCommand() : base("Change time to midnight.") { }
        public override void execute(params string[] parameters)
        {
            Main.dayTime = false;
            Main.time = 16200.0;
            NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
        }
    }

    class ExitCommand : DedicatedCommandParser
    {
        public ExitCommand() : base("Save the world and shutdown the server.") { }
        public override void execute(params string[] parameters)
        {
            WorldFile.saveWorld(false);
            Netplay.disconnect = true;
        }
    }

    class ExitNoSaveCommand : DedicatedCommandParser
    {
        public ExitNoSaveCommand() : base("Shutdown the server.") {
            this.optionName = "exit-nosave";
        }
        public override void execute(params string[] parameters)
        {
            Netplay.disconnect = true;
        }
    }

    class FPSCommand : DedicatedCommandParser
    {
        public FPSCommand() : base("Toggle FPS mode."){}
        public override void execute(params string[] parameters)
        {
            if (!Main.dedServFPS)
            {
                Main.dedServFPS = true;
                Main.fpsTimer.Reset();
            }
            else
            {
                Main.dedServCount1 = 0;
                Main.dedServCount2 = 0;
                Main.dedServFPS = false;
            }
        }
    }

    class SaveCommand : DedicatedCommandParser
    {
        public SaveCommand() : base("Save the world."){}
        public override void execute(params string[] parameters)
        {
            WorldFile.saveWorld(false);
        }
    }

    class TimeCommand : DedicatedCommandParser
    {
        public TimeCommand() : base("Show current time.") { }
        public override void execute(params string[] parameters)
        {
            string text3 = "AM";
            double num = Main.time;
            if (!Main.dayTime) num += 54000.0;
            num = num / 86400.0 * 24.0;
            double num2 = 7.5;
            num = num - num2 - 12.0;
            if (num < 0.0) num += 24.0;
            if (num >= 12.0) text3 = "PM";
            int num3 = (int)num;
            double num4 = num - (double)num3;
            num4 = (double)((int)(num4 * 60.0));
            string text4 = string.Concat(num4);

            if (num4 < 10.0) text4 = "0" + text4;
            if (num3 > 12) num3 -= 12;
            if (num3 == 0) num3 = 12;

            Console.WriteLine(string.Concat(new object[]{
                "Time: ",
                num3,
                ":",
                text4,
                " ",
                text3
			}));
        }
    }

    class MaxPlayersCommand : DedicatedCommandParser
    {
        public MaxPlayersCommand() : base("Show the players limit.") { }
        public override void execute(params string[] parameters)
        {
            Console.WriteLine("Player limit: " + Main.maxNetPlayers);
        }
    }

    class PortCommand : DedicatedCommandParser
    {
        public PortCommand() : base("Show the server port.") { }
        public override void execute(params string[] parameters)
        {
            Console.WriteLine("Port: " + Netplay.serverPort);
        }
    }

    class VersionCommand : DedicatedCommandParser
    {
        public VersionCommand() : base("Show the server version.") { }
        public override void execute(params string[] parameters)
        {
            Console.WriteLine("Terraria Server " + Main.versionNumber);
        }
    }

    class ClearCommand : DedicatedCommandParser
    {
        public ClearCommand() : base("Clear the console.") { }

        public override void execute(params string[] parameters)
        {
            Console.Clear();
        }
    }
    
    class PlayingCommand : DedicatedCommandParser
    {
        public PlayingCommand() : base("List active players.") { }
        public override void execute(params string[] parameters)
        {
            int playersCount = 0;
            for (int i = 0; i < 255; i++)
            {
                if (Main.player[i].active)
                {
                    playersCount++;
                    Console.WriteLine(string.Concat(new object[]{
                        Main.player[i].name,
                        " (",
                        Netplay.serverSock[i].tcpClient.Client.RemoteEndPoint,
                        ")"
                    }));
                }
            }
            switch (playersCount)
            {
                case 0:
                    Console.WriteLine("No players connected.");
                    break;
                case 1:
                    Console.WriteLine("1 player connected.");
                    break;
                default:
                    Console.WriteLine(playersCount + " players connected.");
                    break;
            }
        }
    }
   
    class MOTDCommand : DedicatedCommandParser
    {
        public MOTDCommand() : base("Show or set the MOTD.") { }
        public override void execute(params string[] parameters)
        {
            if (parameters.Length == 0)
            {
                if (Main.motd.Trim() == "") Console.WriteLine("Welcome to " + Main.worldName + "!");
                else Console.WriteLine("MOTD: " + Main.motd);
            }
            else Main.motd = string.Join(" ", parameters);
        }
    }

    class PasswordCommand : DedicatedCommandParser
    {
        public PasswordCommand() : base("Show or set the Password.") { }
        public override void execute(params string[] parameters)
        {
            if (parameters.Length == 0)
            {
                if (Netplay.password == "") Console.WriteLine("No password set.");
                else Console.WriteLine("Password: " + Netplay.password);
            }
            else
            {
                string password = string.Join(" ", parameters);
                if (password == "")
                {
                    Netplay.password = "";
                    Console.WriteLine("Password disabled.");
                }
                else
                {
                    Netplay.password = password;
                    Console.WriteLine("Password: " + Netplay.password);
                }
            }
        }
    }

    class SayCommand : DedicatedCommandParser
    {
        public SayCommand() : base("Say something to active players.") { }
        public override void execute(params string[] parameters)
        {
            if (parameters.Length == 0 || string.Concat(parameters).Trim() == "") Console.WriteLine("Usage: say <words>");
            else
            {
                string message = string.Join(" ", parameters);
                Console.WriteLine("<Server> " + message);
                NetMessage.SendData(25, -1, -1, "<Server> " + message, 255, 255f, 240f, 20f, 0);
            }
        }
    }

    class KickCommand : DedicatedCommandParser
    {
        public KickCommand() : base("Kick a player from the server.") { }
        public override void execute(params string[] parameters)
        {
            if (parameters.Length == 0 || string.Concat(parameters).Trim() == "") Console.WriteLine("Usage: kick <player>");
            else
            {
                 string target = string.Join(" ", parameters).ToLower();
                 for (int j = 0; j < 255; j++)
                 {
                    if (Main.player[j].active && Main.player[j].name.ToLower() == target)
                    {
                        NetMessage.SendData(2, j, -1, "Kicked from server.", 0, 0f, 0f, 0f, 0);
                    }
                 }   
            }
        }
    }

    class BanCommand : DedicatedCommandParser
    {
        public BanCommand() : base("Ban a player from the server.") { }
        public override void execute(params string[] parameters)
        {
            if (parameters.Length == 0 || string.Concat(parameters).Trim() == "") Console.WriteLine("Usage: ban <player>");
            else
            {
                string target = string.Join(" ", parameters).ToLower();
                for (int k = 0; k < 255; k++)
                {
                    if (Main.player[k].active && Main.player[k].name.ToLower() == target)
                    {
                        Netplay.AddBan(k);
                        NetMessage.SendData(2, k, -1, "Banned from server.", 0, 0f, 0f, 0f, 0);
                    }
                }
            }
        }
    }
}
