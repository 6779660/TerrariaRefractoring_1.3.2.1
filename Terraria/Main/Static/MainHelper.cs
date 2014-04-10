using Microsoft.Win32;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Terraria.Terraria.Constants;
using Terraria.Terraria.ID;
namespace Terraria
{
    public partial class Main
    {
       
        public static void SaveRecent()
        {
            Directory.CreateDirectory(Main.SavePath);
            try
            {
                File.SetAttributes(Main.SavePath + Path.DirectorySeparatorChar + "servers.dat", FileAttributes.Normal);
            }
            catch
            {
            }
            try
            {
                using (FileStream fileStream = new FileStream(Main.SavePath + Path.DirectorySeparatorChar + "servers.dat", FileMode.Create))
                {
                    using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
                    {
                        binaryWriter.Write(Main.curRelease);
                        for (int i = 0; i < 10; i++)
                        {
                            binaryWriter.Write(Main.recentWorld[i]);
                            binaryWriter.Write(Main.recentIP[i]);
                            binaryWriter.Write(Main.recentPort[i]);
                        }
                    }
                }
            }
            catch
            {
            }
        }
        public static void SaveSettings()
        {
            Directory.CreateDirectory(Main.SavePath);
            try { File.SetAttributes(Main.SavePath + Path.DirectorySeparatorChar + "config.dat", FileAttributes.Normal); }
            catch { }
            try
            {
                using (FileStream fileStream = new FileStream(Main.SavePath + Path.DirectorySeparatorChar + "config.dat", FileMode.Create))
                {
                    using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
                    {
                        binaryWriter.Write(Main.curRelease);
                        binaryWriter.Write(Main.clientUUID);
                        binaryWriter.Write(Main.graphics.IsFullScreen);
                        binaryWriter.Write(Main.mouseColor.R);
                        binaryWriter.Write(Main.mouseColor.G);
                        binaryWriter.Write(Main.mouseColor.B);
                        binaryWriter.Write(Main.soundVolume);
                        binaryWriter.Write(Main.ambientVolume);
                        binaryWriter.Write(Main.musicVolume);
                        binaryWriter.Write(KeyBoardDefinitions.cUp);
                        binaryWriter.Write(KeyBoardDefinitions.cDown);
                        binaryWriter.Write(KeyBoardDefinitions.cLeft);
                        binaryWriter.Write(KeyBoardDefinitions.cRight);
                        binaryWriter.Write(KeyBoardDefinitions.cJump);
                        binaryWriter.Write(KeyBoardDefinitions.cThrowItem);
                        binaryWriter.Write(KeyBoardDefinitions.cInv);
                        binaryWriter.Write(KeyBoardDefinitions.cHeal);
                        binaryWriter.Write(KeyBoardDefinitions.cMana);
                        binaryWriter.Write(KeyBoardDefinitions.cBuff);
                        binaryWriter.Write(KeyBoardDefinitions.cHook);
                        binaryWriter.Write(Main.caveParrallax);
                        binaryWriter.Write(Main.fixedTiming);
                        binaryWriter.Write(Main.screenMaximized);
                        binaryWriter.Write(Main.graphics.PreferredBackBufferWidth);
                        binaryWriter.Write(Main.graphics.PreferredBackBufferHeight);
                        binaryWriter.Write(Main.autoSave);
                        binaryWriter.Write(Main.autoPause);
                        binaryWriter.Write(Main.showItemText);
                        binaryWriter.Write(KeyBoardDefinitions.cTorch);
                        binaryWriter.Write((byte)Lighting.lightMode);
                        binaryWriter.Write((byte)Main.qaStyle);
                        binaryWriter.Write(Main.owBack);
                        binaryWriter.Write((byte)Lang.lang);
                        binaryWriter.Write(Main.mapEnabled);
                        binaryWriter.Write(KeyBoardDefinitions.cMapStyle);
                        binaryWriter.Write(KeyBoardDefinitions.cMapFull);
                        binaryWriter.Write(KeyBoardDefinitions.cMapZoomIn);
                        binaryWriter.Write(KeyBoardDefinitions.cMapZoomOut);
                        binaryWriter.Write(KeyBoardDefinitions.cMapAlphaUp);
                        binaryWriter.Write(KeyBoardDefinitions.cMapAlphaDown);
                        binaryWriter.Write(Lighting.LightingThreads);
                        binaryWriter.Close();
                    }
                }
            }
            catch { }
        }

        private static string getPlayerPathName(string playerName)
        {
            string text = "";
            for (int i = 0; i < playerName.Length; i++)
            {
                string text2 = playerName.Substring(i, 1);
                string str;
                if (text2 == "a" || text2 == "b" || text2 == "c" || text2 == "d" || text2 == "e" || text2 == "f" || text2 == "g" || text2 == "h" || text2 == "i" || text2 == "j" || text2 == "k" || text2 == "l" || text2 == "m" || text2 == "n" || text2 == "o" || text2 == "p" || text2 == "q" || text2 == "r" || text2 == "s" || text2 == "t" || text2 == "u" || text2 == "v" || text2 == "w" || text2 == "x" || text2 == "y" || text2 == "z" || text2 == "A" || text2 == "B" || text2 == "C" || text2 == "D" || text2 == "E" || text2 == "F" || text2 == "G" || text2 == "H" || text2 == "I" || text2 == "J" || text2 == "K" || text2 == "L" || text2 == "M" || text2 == "N" || text2 == "O" || text2 == "P" || text2 == "Q" || text2 == "R" || text2 == "S" || text2 == "T" || text2 == "U" || text2 == "V" || text2 == "W" || text2 == "X" || text2 == "Y" || text2 == "Z" || text2 == "1" || text2 == "2" || text2 == "3" || text2 == "4" || text2 == "5" || text2 == "6" || text2 == "7" || text2 == "8" || text2 == "9" || text2 == "0")
                {
                    str = text2;
                }
                else
                {
                    if (text2 == " ")
                    {
                        str = "_";
                    }
                    else
                    {
                        str = "-";
                    }
                }
                text += str;
            }
            if (File.Exists(string.Concat(new object[]
			{
				Main.PlayerPath,
				Path.DirectorySeparatorChar,
				text,
				".plr"
			})))
            {
                int num = 2;
                while (File.Exists(string.Concat(new object[]
				{
					Main.PlayerPath,
					Path.DirectorySeparatorChar,
					text,
					num,
					".plr"
				})))
                {
                    num++;
                }
                text += num;
            }
            return string.Concat(new object[]
			{
				Main.PlayerPath,
				Path.DirectorySeparatorChar,
				text,
				".plr"
			});
        }
        private static string getWorldPathName(string worldName)
        {
            string text = "";
            for (int i = 0; i < worldName.Length; i++)
            {
                string text2 = worldName.Substring(i, 1);
                string str;
                if (text2 == "a" || text2 == "b" || text2 == "c" || text2 == "d" || text2 == "e" || text2 == "f" || text2 == "g" || text2 == "h" || text2 == "i" || text2 == "j" || text2 == "k" || text2 == "l" || text2 == "m" || text2 == "n" || text2 == "o" || text2 == "p" || text2 == "q" || text2 == "r" || text2 == "s" || text2 == "t" || text2 == "u" || text2 == "v" || text2 == "w" || text2 == "x" || text2 == "y" || text2 == "z" || text2 == "A" || text2 == "B" || text2 == "C" || text2 == "D" || text2 == "E" || text2 == "F" || text2 == "G" || text2 == "H" || text2 == "I" || text2 == "J" || text2 == "K" || text2 == "L" || text2 == "M" || text2 == "N" || text2 == "O" || text2 == "P" || text2 == "Q" || text2 == "R" || text2 == "S" || text2 == "T" || text2 == "U" || text2 == "V" || text2 == "W" || text2 == "X" || text2 == "Y" || text2 == "Z" || text2 == "1" || text2 == "2" || text2 == "3" || text2 == "4" || text2 == "5" || text2 == "6" || text2 == "7" || text2 == "8" || text2 == "9" || text2 == "0")
                {
                    str = text2;
                }
                else
                {
                    if (text2 == " ")
                    {
                        str = "_";
                    }
                    else
                    {
                        str = "-";
                    }
                }
                text += str;
            }
            if (File.Exists(string.Concat(new object[]
			{
				Main.WorldPath,
				Path.DirectorySeparatorChar,
				text,
				".wld"
			})))
            {
                int num = 2;
                while (File.Exists(string.Concat(new object[]
				{
					Main.WorldPath,
					Path.DirectorySeparatorChar,
					text,
					num,
					".wld"
				})))
                {
                    num++;
                }
                text += num;
            }
            return string.Concat(new object[]
			{
				Main.WorldPath,
				Path.DirectorySeparatorChar,
				text,
				".wld"
			});
        }

        public static void startDedInput()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(Main.startDedInputCallBack), 1);
        }
        public static void startDedInputCallBack(object threadContext)
        {
            while (!Netplay.disconnect)
            {
                Console.Write(": ");
                string text = Console.ReadLine();
                string text2 = text;
                text = text.ToLower();
                try
                {
                    if (text == "help")
                    {
                        Console.WriteLine("Available commands:");
                        Console.WriteLine("");
                        Console.WriteLine(string.Concat(new object[]
						{
							"help ",
							'\t',
							'\t',
							" Displays a list of commands."
						}));
                        Console.WriteLine("playing " + '\t' + " Shows the list of players");
                        Console.WriteLine(string.Concat(new object[]
						{
							"clear ",
							'\t',
							'\t',
							" Clear the console window."
						}));
                        Console.WriteLine(string.Concat(new object[]
						{
							"exit ",
							'\t',
							'\t',
							" Shutdown the server and save."
						}));
                        Console.WriteLine("exit-nosave " + '\t' + " Shutdown the server without saving.");
                        Console.WriteLine(string.Concat(new object[]
						{
							"save ",
							'\t',
							'\t',
							" Save the game world."
						}));
                        Console.WriteLine("kick <player> " + '\t' + " Kicks a player from the server.");
                        Console.WriteLine("ban <player> " + '\t' + " Bans a player from the server.");
                        Console.WriteLine("password" + '\t' + " Show password.");
                        Console.WriteLine("password <pass>" + '\t' + " Change password.");
                        Console.WriteLine(string.Concat(new object[]
						{
							"version",
							'\t',
							'\t',
							" Print version number."
						}));
                        Console.WriteLine(string.Concat(new object[]
						{
							"time",
							'\t',
							'\t',
							" Display game time."
						}));
                        Console.WriteLine(string.Concat(new object[]
						{
							"port",
							'\t',
							'\t',
							" Print the listening port."
						}));
                        Console.WriteLine("maxplayers" + '\t' + " Print the max number of players.");
                        Console.WriteLine("say <words>" + '\t' + " Send a message.");
                        Console.WriteLine(string.Concat(new object[]
						{
							"motd",
							'\t',
							'\t',
							" Print MOTD."
						}));
                        Console.WriteLine("motd <words>" + '\t' + " Change MOTD.");
                        Console.WriteLine(string.Concat(new object[]
						{
							"dawn",
							'\t',
							'\t',
							" Change time to dawn."
						}));
                        Console.WriteLine(string.Concat(new object[]
						{
							"noon",
							'\t',
							'\t',
							" Change time to noon."
						}));
                        Console.WriteLine(string.Concat(new object[]
						{
							"dusk",
							'\t',
							'\t',
							" Change time to dusk."
						}));
                        Console.WriteLine("midnight" + '\t' + " Change time to midnight.");
                        Console.WriteLine(string.Concat(new object[]
						{
							"settle",
							'\t',
							'\t',
							" Settle all water."
						}));
                    }
                    else
                    {
                        if (text == "settle")
                        {
                            if (!Liquid.panicMode)
                            {
                                Liquid.StartPanic();
                            }
                            else
                            {
                                Console.WriteLine("Water is already settling");
                            }
                        }
                        else
                        {
                            if (text == "dawn")
                            {
                                Main.dayTime = true;
                                Main.time = 0.0;
                                NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
                            }
                            else
                            {
                                if (text == "dusk")
                                {
                                    Main.dayTime = false;
                                    Main.time = 0.0;
                                    NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
                                }
                                else
                                {
                                    if (text == "noon")
                                    {
                                        Main.dayTime = true;
                                        Main.time = 27000.0;
                                        NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
                                    }
                                    else
                                    {
                                        if (text == "midnight")
                                        {
                                            Main.dayTime = false;
                                            Main.time = 16200.0;
                                            NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
                                        }
                                        else
                                        {
                                            if (text == "exit-nosave")
                                            {
                                                Netplay.disconnect = true;
                                            }
                                            else
                                            {
                                                if (text == "exit")
                                                {
                                                    WorldFile.saveWorld(false);
                                                    Netplay.disconnect = true;
                                                }
                                                else
                                                {
                                                    if (text == "fps")
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
                                                    else
                                                    {
                                                        if (text == "save")
                                                        {
                                                            WorldFile.saveWorld(false);
                                                        }
                                                        else
                                                        {
                                                            if (text == "time")
                                                            {
                                                                string text3 = "AM";
                                                                double num = Main.time;
                                                                if (!Main.dayTime)
                                                                {
                                                                    num += 54000.0;
                                                                }
                                                                num = num / 86400.0 * 24.0;
                                                                double num2 = 7.5;
                                                                num = num - num2 - 12.0;
                                                                if (num < 0.0)
                                                                {
                                                                    num += 24.0;
                                                                }
                                                                if (num >= 12.0)
                                                                {
                                                                    text3 = "PM";
                                                                }
                                                                int num3 = (int)num;
                                                                double num4 = num - (double)num3;
                                                                num4 = (double)((int)(num4 * 60.0));
                                                                string text4 = string.Concat(num4);
                                                                if (num4 < 10.0)
                                                                {
                                                                    text4 = "0" + text4;
                                                                }
                                                                if (num3 > 12)
                                                                {
                                                                    num3 -= 12;
                                                                }
                                                                if (num3 == 0)
                                                                {
                                                                    num3 = 12;
                                                                }
                                                                Console.WriteLine(string.Concat(new object[]
																{
																	"Time: ",
																	num3,
																	":",
																	text4,
																	" ",
																	text3
																}));
                                                            }
                                                            else
                                                            {
                                                                if (text == "maxplayers")
                                                                {
                                                                    Console.WriteLine("Player limit: " + Main.maxNetPlayers);
                                                                }
                                                                else
                                                                {
                                                                    if (text == "port")
                                                                    {
                                                                        Console.WriteLine("Port: " + Netplay.serverPort);
                                                                    }
                                                                    else
                                                                    {
                                                                        if (text == "version")
                                                                        {
                                                                            Console.WriteLine("Terraria Server " + Main.versionNumber);
                                                                        }
                                                                        else
                                                                        {
                                                                            if (text == "clear")
                                                                            {
                                                                                try
                                                                                {
                                                                                    Console.Clear();
                                                                                    continue;
                                                                                }
                                                                                catch
                                                                                {
                                                                                    continue;
                                                                                }
                                                                            }
                                                                            if (text == "playing")
                                                                            {
                                                                                int num5 = 0;
                                                                                for (int i = 0; i < 255; i++)
                                                                                {
                                                                                    if (Main.player[i].active)
                                                                                    {
                                                                                        num5++;
                                                                                        Console.WriteLine(string.Concat(new object[]
																						{
																							Main.player[i].name,
																							" (",
																							Netplay.serverSock[i].tcpClient.Client.RemoteEndPoint,
																							")"
																						}));
                                                                                    }
                                                                                }
                                                                                if (num5 == 0)
                                                                                {
                                                                                    Console.WriteLine("No players connected.");
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (num5 == 1)
                                                                                    {
                                                                                        Console.WriteLine("1 player connected.");
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        Console.WriteLine(num5 + " players connected.");
                                                                                    }
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                if (!(text == ""))
                                                                                {
                                                                                    if (text == "motd")
                                                                                    {
                                                                                        if (Main.motd == "")
                                                                                        {
                                                                                            Console.WriteLine("Welcome to " + Main.worldName + "!");
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            Console.WriteLine("MOTD: " + Main.motd);
                                                                                        }
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (text.Length >= 5 && text.Substring(0, 5) == "motd ")
                                                                                        {
                                                                                            string text5 = text2.Substring(5);
                                                                                            Main.motd = text5;
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if (text.Length == 8 && text.Substring(0, 8) == "password")
                                                                                            {
                                                                                                if (Netplay.password == "")
                                                                                                {
                                                                                                    Console.WriteLine("No password set.");
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    Console.WriteLine("Password: " + Netplay.password);
                                                                                                }
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                if (text.Length >= 9 && text.Substring(0, 9) == "password ")
                                                                                                {
                                                                                                    string password = text2.Substring(9);
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
                                                                                                else
                                                                                                {
                                                                                                    if (text == "say")
                                                                                                    {
                                                                                                        Console.WriteLine("Usage: say <words>");
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        if (text.Length >= 4 && text.Substring(0, 4) == "say ")
                                                                                                        {
                                                                                                            string str = text2.Substring(4);
                                                                                                            if (str == "")
                                                                                                            {
                                                                                                                Console.WriteLine("Usage: say <words>");
                                                                                                            }
                                                                                                            else
                                                                                                            {
                                                                                                                Console.WriteLine("<Server> " + str);
                                                                                                                NetMessage.SendData(25, -1, -1, "<Server> " + str, 255, 255f, 240f, 20f, 0);
                                                                                                            }
                                                                                                        }
                                                                                                        else
                                                                                                        {
                                                                                                            if (text.Length == 4 && text.Substring(0, 4) == "kick")
                                                                                                            {
                                                                                                                Console.WriteLine("Usage: kick <player>");
                                                                                                            }
                                                                                                            else
                                                                                                            {
                                                                                                                if (text.Length >= 5 && text.Substring(0, 5) == "kick ")
                                                                                                                {
                                                                                                                    string text6 = text.Substring(5);
                                                                                                                    text6 = text6.ToLower();
                                                                                                                    if (text6 == "")
                                                                                                                    {
                                                                                                                        Console.WriteLine("Usage: kick <player>");
                                                                                                                    }
                                                                                                                    else
                                                                                                                    {
                                                                                                                        for (int j = 0; j < 255; j++)
                                                                                                                        {
                                                                                                                            if (Main.player[j].active && Main.player[j].name.ToLower() == text6)
                                                                                                                            {
                                                                                                                                NetMessage.SendData(2, j, -1, "Kicked from server.", 0, 0f, 0f, 0f, 0);
                                                                                                                            }
                                                                                                                        }
                                                                                                                    }
                                                                                                                }
                                                                                                                else
                                                                                                                {
                                                                                                                    if (text.Length == 3 && text.Substring(0, 3) == "ban")
                                                                                                                    {
                                                                                                                        Console.WriteLine("Usage: ban <player>");
                                                                                                                    }
                                                                                                                    else
                                                                                                                    {
                                                                                                                        if (text.Length >= 4 && text.Substring(0, 4) == "ban ")
                                                                                                                        {
                                                                                                                            string text7 = text.Substring(4);
                                                                                                                            text7 = text7.ToLower();
                                                                                                                            if (text7 == "")
                                                                                                                            {
                                                                                                                                Console.WriteLine("Usage: ban <player>");
                                                                                                                            }
                                                                                                                            else
                                                                                                                            {
                                                                                                                                for (int k = 0; k < 255; k++)
                                                                                                                                {
                                                                                                                                    if (Main.player[k].active && Main.player[k].name.ToLower() == text7)
                                                                                                                                    {
                                                                                                                                        Netplay.AddBan(k);
                                                                                                                                        NetMessage.SendData(2, k, -1, "Banned from server.", 0, 0f, 0f, 0f, 0);
                                                                                                                                    }
                                                                                                                                }
                                                                                                                            }
                                                                                                                        }
                                                                                                                        else
                                                                                                                        {
                                                                                                                            Console.WriteLine("Invalid command.");
                                                                                                                        }
                                                                                                                    }
                                                                                                                }
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid command.");
                }
            }
        }
       
        public static void checkXMas()
        {
            DateTime now = DateTime.Now;
            int day = now.Day;
            int month = now.Month;
            if (day >= 15 && month == 12)
            {
                Main.xMas = true;
                return;
            }
            Main.xMas = false;
        }
        public static void checkHalloween()
        {
            DateTime now = DateTime.Now;
            int day = now.Day;
            int month = now.Month;
            if (day >= 20 && month == 10)
            {
                Main.halloween = true;
                return;
            }
            if (day <= 10 && month == 11)
            {
                Main.halloween = true;
                return;
            }
            Main.halloween = false;
        }

        public static void TeleportEffect(Rectangle effectRect, int Style)
        {
            if (Style == 1)
            {
                Main.PlaySound(SoundTypeID.ITEM, effectRect.X + effectRect.Width / 2, effectRect.Y + effectRect.Height / 2, 8);
                int num = effectRect.Width * effectRect.Height / 5;
                for (int i = 0; i < num; i++)
                {
                    int num2 = Dust.NewDust(new Vector2((float)effectRect.X, (float)effectRect.Y), effectRect.Width, effectRect.Height, 164, 0f, 0f, 0, default(Color), 1f);
                    Main.dust[num2].scale = (float)Main.rand.Next(20, 70) * 0.01f;
                    if (i < 10)
                    {
                        Main.dust[num2].scale += 0.25f;
                    }
                    if (i < 5)
                    {
                        Main.dust[num2].scale += 0.25f;
                    }
                }
                return;
            }
            Main.PlaySound(SoundTypeID.ITEM, effectRect.X + effectRect.Width / 2, effectRect.Y + effectRect.Height / 2, 6);
            int num3 = effectRect.Width * effectRect.Height / 5;
            for (int j = 0; j < num3; j++)
            {
                int num4 = Dust.NewDust(new Vector2((float)effectRect.X, (float)effectRect.Y), effectRect.Width, effectRect.Height, 159, 0f, 0f, 0, default(Color), 1f);
                Main.dust[num4].scale = (float)Main.rand.Next(20, 70) * 0.01f;
                if (j < 10)
                {
                    Main.dust[num4].scale += 0.25f;
                }
                if (j < 5)
                {
                    Main.dust[num4].scale += 0.25f;
                }
            }
        }
        
        #region CritterCages

        public static void CritterCages()
        {
            if (Main.critterCage)
            {
                for (int i = 0; i < Main.cageFrames; i++)
                {
                    if (Main.bunnyCageFrame[i] == 0)
                    {
                        Main.bunnyCageFrameCounter[i]++;
                        if (Main.bunnyCageFrameCounter[i] > Main.rand.Next(30, 900))
                        {
                            if (Main.rand.Next(3) != 0)
                            {
                                int num = Main.rand.Next(7);
                                if (num == 0)
                                {
                                    Main.bunnyCageFrame[i] = 4;
                                }
                                else
                                {
                                    if (num <= 2)
                                    {
                                        Main.bunnyCageFrame[i] = 2;
                                    }
                                    else
                                    {
                                        Main.bunnyCageFrame[i] = 1;
                                    }
                                }
                            }
                            Main.bunnyCageFrameCounter[i] = 0;
                        }
                    }
                    else
                    {
                        if (Main.bunnyCageFrame[i] == 1)
                        {
                            Main.bunnyCageFrameCounter[i]++;
                            if (Main.bunnyCageFrameCounter[i] >= 10)
                            {
                                Main.bunnyCageFrameCounter[i] = 0;
                                Main.bunnyCageFrame[i] = 0;
                            }
                        }
                        else
                        {
                            if (Main.bunnyCageFrame[i] >= 2 && Main.bunnyCageFrame[i] <= 3)
                            {
                                Main.bunnyCageFrameCounter[i]++;
                                if (Main.bunnyCageFrameCounter[i] >= 10)
                                {
                                    Main.bunnyCageFrameCounter[i] = 0;
                                    Main.bunnyCageFrame[i]++;
                                }
                                if (Main.bunnyCageFrame[i] > 3)
                                {
                                    Main.bunnyCageFrame[i] = 0;
                                }
                            }
                            else
                            {
                                if (Main.bunnyCageFrame[i] >= 4 && Main.bunnyCageFrame[i] <= 10)
                                {
                                    Main.bunnyCageFrameCounter[i]++;
                                    if (Main.bunnyCageFrameCounter[i] >= 5)
                                    {
                                        Main.bunnyCageFrameCounter[i] = 0;
                                        Main.bunnyCageFrame[i]++;
                                    }
                                }
                                else
                                {
                                    if (Main.bunnyCageFrame[i] == 11)
                                    {
                                        Main.bunnyCageFrameCounter[i]++;
                                        if (Main.bunnyCageFrameCounter[i] > Main.rand.Next(30, 900))
                                        {
                                            if (Main.rand.Next(3) != 0)
                                            {
                                                if (Main.rand.Next(7) == 0)
                                                {
                                                    Main.bunnyCageFrame[i] = 13;
                                                }
                                                else
                                                {
                                                    Main.bunnyCageFrame[i] = 12;
                                                }
                                            }
                                            Main.bunnyCageFrameCounter[i] = 0;
                                        }
                                    }
                                    else
                                    {
                                        if (Main.bunnyCageFrame[i] == 12)
                                        {
                                            Main.bunnyCageFrameCounter[i]++;
                                            if (Main.bunnyCageFrameCounter[i] >= 10)
                                            {
                                                Main.bunnyCageFrameCounter[i] = 0;
                                                Main.bunnyCageFrame[i] = 11;
                                            }
                                        }
                                        else
                                        {
                                            if (Main.bunnyCageFrame[i] >= 13)
                                            {
                                                Main.bunnyCageFrameCounter[i]++;
                                                if (Main.bunnyCageFrameCounter[i] >= 5)
                                                {
                                                    Main.bunnyCageFrameCounter[i] = 0;
                                                    Main.bunnyCageFrame[i]++;
                                                }
                                                if (Main.bunnyCageFrame[i] > 21)
                                                {
                                                    Main.bunnyCageFrame[i] = 0;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                for (int j = 0; j < Main.cageFrames; j++)
                {
                    if (Main.squirrelCageFrame[j] == 0)
                    {
                        Main.squirrelCageFrameCounter[j]++;
                        if (Main.squirrelCageFrameCounter[j] > Main.rand.Next(30, 900))
                        {
                            if (Main.rand.Next(3) != 0)
                            {
                                int num = Main.rand.Next(7);
                                if (num == 0)
                                {
                                    Main.squirrelCageFrame[j] = 4;
                                }
                                else
                                {
                                    if (num <= 2)
                                    {
                                        Main.squirrelCageFrame[j] = 2;
                                    }
                                    else
                                    {
                                        Main.squirrelCageFrame[j] = 1;
                                    }
                                }
                            }
                            Main.squirrelCageFrameCounter[j] = 0;
                        }
                    }
                    else
                    {
                        if (Main.squirrelCageFrame[j] == 1)
                        {
                            Main.squirrelCageFrameCounter[j]++;
                            if (Main.squirrelCageFrameCounter[j] >= 10)
                            {
                                Main.squirrelCageFrameCounter[j] = 0;
                                Main.squirrelCageFrame[j] = 0;
                            }
                        }
                        else
                        {
                            if (Main.squirrelCageFrame[j] >= 2 && Main.squirrelCageFrame[j] <= 3)
                            {
                                Main.squirrelCageFrameCounter[j]++;
                                if (Main.squirrelCageFrameCounter[j] >= 5)
                                {
                                    Main.squirrelCageFrameCounter[j] = 0;
                                    Main.squirrelCageFrame[j]++;
                                }
                                if (Main.squirrelCageFrame[j] > 3)
                                {
                                    if (Main.rand.Next(5) == 0)
                                    {
                                        Main.squirrelCageFrame[j] = 0;
                                    }
                                    else
                                    {
                                        Main.squirrelCageFrame[j] = 2;
                                    }
                                }
                            }
                            else
                            {
                                if (Main.squirrelCageFrame[j] >= 4 && Main.squirrelCageFrame[j] <= 8)
                                {
                                    Main.squirrelCageFrameCounter[j]++;
                                    if (Main.squirrelCageFrameCounter[j] >= 5)
                                    {
                                        Main.squirrelCageFrameCounter[j] = 0;
                                        Main.squirrelCageFrame[j]++;
                                    }
                                }
                                else
                                {
                                    if (Main.squirrelCageFrame[j] == 9)
                                    {
                                        Main.squirrelCageFrameCounter[j]++;
                                        if (Main.squirrelCageFrameCounter[j] > Main.rand.Next(30, 900))
                                        {
                                            if (Main.rand.Next(3) != 0)
                                            {
                                                int num = Main.rand.Next(7);
                                                if (num == 0)
                                                {
                                                    Main.squirrelCageFrame[j] = 13;
                                                }
                                                else
                                                {
                                                    if (num <= 2)
                                                    {
                                                        Main.squirrelCageFrame[j] = 11;
                                                    }
                                                    else
                                                    {
                                                        Main.squirrelCageFrame[j] = 10;
                                                    }
                                                }
                                            }
                                            Main.squirrelCageFrameCounter[j] = 0;
                                        }
                                    }
                                    else
                                    {
                                        if (Main.squirrelCageFrame[j] == 10)
                                        {
                                            Main.squirrelCageFrameCounter[j]++;
                                            if (Main.squirrelCageFrameCounter[j] >= 10)
                                            {
                                                Main.squirrelCageFrameCounter[j] = 0;
                                                Main.squirrelCageFrame[j] = 9;
                                            }
                                        }
                                        else
                                        {
                                            if (Main.squirrelCageFrame[j] == 11 || Main.squirrelCageFrame[j] == 12)
                                            {
                                                Main.squirrelCageFrameCounter[j]++;
                                                if (Main.squirrelCageFrameCounter[j] >= 5)
                                                {
                                                    Main.squirrelCageFrame[j]++;
                                                    if (Main.squirrelCageFrame[j] > 12)
                                                    {
                                                        if (Main.rand.Next(5) != 0)
                                                        {
                                                            Main.squirrelCageFrame[j] = 11;
                                                        }
                                                        else
                                                        {
                                                            Main.squirrelCageFrame[j] = 9;
                                                        }
                                                    }
                                                    Main.squirrelCageFrameCounter[j] = 0;
                                                }
                                            }
                                            else
                                            {
                                                if (Main.squirrelCageFrame[j] >= 13)
                                                {
                                                    Main.squirrelCageFrameCounter[j]++;
                                                    if (Main.squirrelCageFrameCounter[j] >= 5)
                                                    {
                                                        Main.squirrelCageFrameCounter[j] = 0;
                                                        Main.squirrelCageFrame[j]++;
                                                    }
                                                    if (Main.squirrelCageFrame[j] > 17)
                                                    {
                                                        Main.squirrelCageFrame[j] = 0;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                for (int k = 0; k < Main.cageFrames; k++)
                {
                    if (Main.mallardCageFrame[k] == 0 || Main.mallardCageFrame[k] == 4)
                    {
                        Main.mallardCageFrameCounter[k]++;
                        if (Main.mallardCageFrameCounter[k] > Main.rand.Next(45, 2700))
                        {
                            if ((Main.mallardCageFrame[k] == 0 && Main.rand.Next(3) != 0) || (Main.mallardCageFrame[k] == 4 && Main.rand.Next(5) == 0))
                            {
                                if (Main.rand.Next(6) == 0)
                                {
                                    Main.mallardCageFrame[k] = 5;
                                }
                                else
                                {
                                    if (Main.rand.Next(3) == 0)
                                    {
                                        if (Main.mallardCageFrame[k] == 4)
                                        {
                                            Main.mallardCageFrame[k] = 0;
                                        }
                                        else
                                        {
                                            Main.mallardCageFrame[k] = 4;
                                        }
                                    }
                                    else
                                    {
                                        Main.mallardCageFrame[k] = 1;
                                    }
                                }
                            }
                            Main.mallardCageFrameCounter[k] = 0;
                        }
                    }
                    else
                    {
                        if (Main.mallardCageFrame[k] >= 1 && Main.mallardCageFrame[k] <= 3)
                        {
                            Main.mallardCageFrameCounter[k]++;
                            if (Main.mallardCageFrameCounter[k] >= 5)
                            {
                                Main.mallardCageFrameCounter[k] = 0;
                                Main.mallardCageFrame[k]++;
                            }
                            if (Main.mallardCageFrame[k] > 3)
                            {
                                if (Main.rand.Next(5) == 0)
                                {
                                    Main.mallardCageFrame[k] = 0;
                                }
                                else
                                {
                                    Main.mallardCageFrame[k] = 1;
                                }
                            }
                        }
                        else
                        {
                            if (Main.mallardCageFrame[k] >= 5 && Main.mallardCageFrame[k] <= 11)
                            {
                                Main.mallardCageFrameCounter[k]++;
                                if (Main.mallardCageFrameCounter[k] >= 5)
                                {
                                    Main.mallardCageFrameCounter[k] = 0;
                                    Main.mallardCageFrame[k]++;
                                }
                            }
                            else
                            {
                                if (Main.mallardCageFrame[k] == 12 || Main.mallardCageFrame[k] == 16)
                                {
                                    Main.mallardCageFrameCounter[k]++;
                                    if (Main.mallardCageFrameCounter[k] > Main.rand.Next(45, 2700))
                                    {
                                        if ((Main.mallardCageFrame[k] == 12 && Main.rand.Next(3) != 0) || (Main.mallardCageFrame[k] == 16 && Main.rand.Next(5) == 0))
                                        {
                                            if (Main.rand.Next(6) == 0)
                                            {
                                                Main.mallardCageFrame[k] = 17;
                                            }
                                            else
                                            {
                                                if (Main.rand.Next(3) == 0)
                                                {
                                                    if (Main.mallardCageFrame[k] == 16)
                                                    {
                                                        Main.mallardCageFrame[k] = 12;
                                                    }
                                                    else
                                                    {
                                                        Main.mallardCageFrame[k] = 16;
                                                    }
                                                }
                                                else
                                                {
                                                    Main.mallardCageFrame[k] = 13;
                                                }
                                            }
                                        }
                                        Main.mallardCageFrameCounter[k] = 0;
                                    }
                                }
                                else
                                {
                                    if (Main.mallardCageFrame[k] >= 13 && Main.mallardCageFrame[k] <= 15)
                                    {
                                        Main.mallardCageFrameCounter[k]++;
                                        if (Main.mallardCageFrameCounter[k] >= 5)
                                        {
                                            Main.mallardCageFrame[k]++;
                                            if (Main.mallardCageFrame[k] > 15)
                                            {
                                                if (Main.rand.Next(5) != 0)
                                                {
                                                    Main.mallardCageFrame[k] = 12;
                                                }
                                                else
                                                {
                                                    Main.mallardCageFrame[k] = 13;
                                                }
                                            }
                                            Main.mallardCageFrameCounter[k] = 0;
                                        }
                                    }
                                    else
                                    {
                                        if (Main.mallardCageFrame[k] >= 17)
                                        {
                                            Main.mallardCageFrameCounter[k]++;
                                            if (Main.mallardCageFrameCounter[k] >= 5)
                                            {
                                                Main.mallardCageFrameCounter[k] = 0;
                                                Main.mallardCageFrame[k]++;
                                            }
                                            if (Main.mallardCageFrame[k] > 23)
                                            {
                                                Main.mallardCageFrame[k] = 0;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                for (int l = 0; l < Main.cageFrames; l++)
                {
                    if (Main.duckCageFrame[l] == 0 || Main.duckCageFrame[l] == 4)
                    {
                        Main.duckCageFrameCounter[l]++;
                        if (Main.duckCageFrameCounter[l] > Main.rand.Next(45, 2700))
                        {
                            if ((Main.duckCageFrame[l] == 0 && Main.rand.Next(3) != 0) || (Main.duckCageFrame[l] == 4 && Main.rand.Next(5) == 0))
                            {
                                if (Main.rand.Next(6) == 0)
                                {
                                    Main.duckCageFrame[l] = 5;
                                }
                                else
                                {
                                    if (Main.rand.Next(3) == 0)
                                    {
                                        if (Main.duckCageFrame[l] == 4)
                                        {
                                            Main.duckCageFrame[l] = 0;
                                        }
                                        else
                                        {
                                            Main.duckCageFrame[l] = 4;
                                        }
                                    }
                                    else
                                    {
                                        Main.duckCageFrame[l] = 1;
                                    }
                                }
                            }
                            Main.duckCageFrameCounter[l] = 0;
                        }
                    }
                    else
                    {
                        if (Main.duckCageFrame[l] >= 1 && Main.duckCageFrame[l] <= 3)
                        {
                            Main.duckCageFrameCounter[l]++;
                            if (Main.duckCageFrameCounter[l] >= 5)
                            {
                                Main.duckCageFrameCounter[l] = 0;
                                Main.duckCageFrame[l]++;
                            }
                            if (Main.duckCageFrame[l] > 3)
                            {
                                if (Main.rand.Next(5) == 0)
                                {
                                    Main.duckCageFrame[l] = 0;
                                }
                                else
                                {
                                    Main.duckCageFrame[l] = 1;
                                }
                            }
                        }
                        else
                        {
                            if (Main.duckCageFrame[l] >= 5 && Main.duckCageFrame[l] <= 11)
                            {
                                Main.duckCageFrameCounter[l]++;
                                if (Main.duckCageFrameCounter[l] >= 5)
                                {
                                    Main.duckCageFrameCounter[l] = 0;
                                    Main.duckCageFrame[l]++;
                                }
                            }
                            else
                            {
                                if (Main.duckCageFrame[l] == 12 || Main.duckCageFrame[l] == 16)
                                {
                                    Main.duckCageFrameCounter[l]++;
                                    if (Main.duckCageFrameCounter[l] > Main.rand.Next(45, 2700))
                                    {
                                        if ((Main.duckCageFrame[l] == 12 && Main.rand.Next(3) != 0) || (Main.duckCageFrame[l] == 16 && Main.rand.Next(5) == 0))
                                        {
                                            if (Main.rand.Next(6) == 0)
                                            {
                                                Main.duckCageFrame[l] = 17;
                                            }
                                            else
                                            {
                                                if (Main.rand.Next(3) == 0)
                                                {
                                                    if (Main.duckCageFrame[l] == 16)
                                                    {
                                                        Main.duckCageFrame[l] = 12;
                                                    }
                                                    else
                                                    {
                                                        Main.duckCageFrame[l] = 16;
                                                    }
                                                }
                                                else
                                                {
                                                    Main.duckCageFrame[l] = 13;
                                                }
                                            }
                                        }
                                        Main.duckCageFrameCounter[l] = 0;
                                    }
                                }
                                else
                                {
                                    if (Main.duckCageFrame[l] >= 13 && Main.duckCageFrame[l] <= 15)
                                    {
                                        Main.duckCageFrameCounter[l]++;
                                        if (Main.duckCageFrameCounter[l] >= 5)
                                        {
                                            Main.duckCageFrame[l]++;
                                            if (Main.duckCageFrame[l] > 15)
                                            {
                                                if (Main.rand.Next(5) != 0)
                                                {
                                                    Main.duckCageFrame[l] = 12;
                                                }
                                                else
                                                {
                                                    Main.duckCageFrame[l] = 13;
                                                }
                                            }
                                            Main.duckCageFrameCounter[l] = 0;
                                        }
                                    }
                                    else
                                    {
                                        if (Main.duckCageFrame[l] >= 17)
                                        {
                                            Main.duckCageFrameCounter[l]++;
                                            if (Main.duckCageFrameCounter[l] >= 5)
                                            {
                                                Main.duckCageFrameCounter[l] = 0;
                                                Main.duckCageFrame[l]++;
                                            }
                                            if (Main.duckCageFrame[l] > 23)
                                            {
                                                Main.duckCageFrame[l] = 0;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                for (int m = 0; m < Main.cageFrames; m++)
                {
                    if (Main.birdCageFrame[m] == 0)
                    {
                        Main.birdCageFrameCounter[m]++;
                        if (Main.birdCageFrameCounter[m] > Main.rand.Next(30, 2700))
                        {
                            if (Main.rand.Next(3) != 0)
                            {
                                if (Main.rand.Next(3) != 0)
                                {
                                    Main.birdCageFrame[m] = 2;
                                }
                                else
                                {
                                    Main.birdCageFrame[m] = 1;
                                }
                            }
                            Main.birdCageFrameCounter[m] = 0;
                        }
                    }
                    else
                    {
                        if (Main.birdCageFrame[m] == 1)
                        {
                            Main.birdCageFrameCounter[m]++;
                            if (Main.birdCageFrameCounter[m] > Main.rand.Next(900, 18000) && Main.rand.Next(3) == 0)
                            {
                                Main.birdCageFrameCounter[m] = 0;
                                Main.birdCageFrame[m] = 0;
                            }
                        }
                        else
                        {
                            if (Main.birdCageFrame[m] >= 2 && Main.birdCageFrame[m] <= 5)
                            {
                                Main.birdCageFrameCounter[m]++;
                                if (Main.birdCageFrameCounter[m] >= 5)
                                {
                                    Main.birdCageFrameCounter[m] = 0;
                                    if (Main.birdCageFrame[m] == 3 && Main.rand.Next(3) == 0)
                                    {
                                        Main.birdCageFrame[m] = 13;
                                    }
                                    else
                                    {
                                        Main.birdCageFrame[m]++;
                                    }
                                }
                            }
                            else
                            {
                                if (Main.birdCageFrame[m] == 6)
                                {
                                    Main.birdCageFrameCounter[m]++;
                                    if (Main.birdCageFrameCounter[m] > Main.rand.Next(45, 2700))
                                    {
                                        if (Main.rand.Next(3) != 0)
                                        {
                                            if (Main.rand.Next(6) == 0)
                                            {
                                                Main.birdCageFrame[m] = 7;
                                            }
                                            else
                                            {
                                                if (Main.rand.Next(6) == 0)
                                                {
                                                    Main.birdCageFrame[m] = 11;
                                                }
                                            }
                                        }
                                        Main.birdCageFrameCounter[m] = 0;
                                    }
                                }
                                else
                                {
                                    if (Main.birdCageFrame[m] >= 7 && Main.birdCageFrame[m] <= 10)
                                    {
                                        Main.birdCageFrameCounter[m]++;
                                        if (Main.birdCageFrameCounter[m] >= 5)
                                        {
                                            Main.birdCageFrame[m]++;
                                            if (Main.birdCageFrame[m] > 10)
                                            {
                                                Main.birdCageFrame[m] = 0;
                                            }
                                            Main.birdCageFrameCounter[m] = 0;
                                        }
                                    }
                                    else
                                    {
                                        if (Main.birdCageFrame[m] >= 11 && Main.birdCageFrame[m] <= 13)
                                        {
                                            Main.birdCageFrameCounter[m]++;
                                            if (Main.birdCageFrameCounter[m] >= 5)
                                            {
                                                Main.birdCageFrame[m]++;
                                                Main.birdCageFrameCounter[m] = 0;
                                            }
                                        }
                                        else
                                        {
                                            if (Main.birdCageFrame[m] == 14)
                                            {
                                                Main.birdCageFrameCounter[m]++;
                                                if (Main.birdCageFrameCounter[m] > Main.rand.Next(5, 600))
                                                {
                                                    if (Main.rand.Next(20) == 0)
                                                    {
                                                        Main.birdCageFrame[m] = 16;
                                                    }
                                                    else
                                                    {
                                                        if (Main.rand.Next(20) == 0)
                                                        {
                                                            Main.birdCageFrame[m] = 4;
                                                        }
                                                        else
                                                        {
                                                            Main.birdCageFrame[m] = 15;
                                                        }
                                                    }
                                                    Main.birdCageFrameCounter[m] = 0;
                                                }
                                            }
                                            else
                                            {
                                                if (Main.birdCageFrame[m] == 15)
                                                {
                                                    Main.birdCageFrameCounter[m]++;
                                                    if (Main.birdCageFrameCounter[m] >= 10)
                                                    {
                                                        Main.birdCageFrameCounter[m] = 0;
                                                        Main.birdCageFrame[m] = 14;
                                                    }
                                                }
                                                else
                                                {
                                                    if (Main.birdCageFrame[m] >= 16 && Main.birdCageFrame[m] <= 18)
                                                    {
                                                        Main.birdCageFrameCounter[m]++;
                                                        if (Main.birdCageFrameCounter[m] >= 5)
                                                        {
                                                            Main.birdCageFrame[m]++;
                                                            if (Main.birdCageFrame[m] > 18)
                                                            {
                                                                Main.birdCageFrame[m] = 0;
                                                            }
                                                            Main.birdCageFrameCounter[m] = 0;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                for (int n = 0; n < Main.cageFrames; n++)
                {
                    if (Main.blueBirdCageFrame[n] == 0)
                    {
                        Main.blueBirdCageFrameCounter[n]++;
                        if (Main.blueBirdCageFrameCounter[n] > Main.rand.Next(30, 2700))
                        {
                            if (Main.rand.Next(3) != 0)
                            {
                                if (Main.rand.Next(3) != 0)
                                {
                                    Main.blueBirdCageFrame[n] = 2;
                                }
                                else
                                {
                                    Main.blueBirdCageFrame[n] = 1;
                                }
                            }
                            Main.blueBirdCageFrameCounter[n] = 0;
                        }
                    }
                    else
                    {
                        if (Main.blueBirdCageFrame[n] == 1)
                        {
                            Main.blueBirdCageFrameCounter[n]++;
                            if (Main.blueBirdCageFrameCounter[n] > Main.rand.Next(900, 18000) && Main.rand.Next(3) == 0)
                            {
                                Main.blueBirdCageFrameCounter[n] = 0;
                                Main.blueBirdCageFrame[n] = 0;
                            }
                        }
                        else
                        {
                            if (Main.blueBirdCageFrame[n] >= 2 && Main.blueBirdCageFrame[n] <= 5)
                            {
                                Main.blueBirdCageFrameCounter[n]++;
                                if (Main.blueBirdCageFrameCounter[n] >= 5)
                                {
                                    Main.blueBirdCageFrameCounter[n] = 0;
                                    if (Main.blueBirdCageFrame[n] == 3 && Main.rand.Next(3) == 0)
                                    {
                                        Main.blueBirdCageFrame[n] = 13;
                                    }
                                    else
                                    {
                                        Main.blueBirdCageFrame[n]++;
                                    }
                                }
                            }
                            else
                            {
                                if (Main.blueBirdCageFrame[n] == 6)
                                {
                                    Main.blueBirdCageFrameCounter[n]++;
                                    if (Main.blueBirdCageFrameCounter[n] > Main.rand.Next(45, 2700))
                                    {
                                        if (Main.rand.Next(3) != 0)
                                        {
                                            if (Main.rand.Next(6) == 0)
                                            {
                                                Main.blueBirdCageFrame[n] = 7;
                                            }
                                            else
                                            {
                                                if (Main.rand.Next(6) == 0)
                                                {
                                                    Main.blueBirdCageFrame[n] = 11;
                                                }
                                            }
                                        }
                                        Main.blueBirdCageFrameCounter[n] = 0;
                                    }
                                }
                                else
                                {
                                    if (Main.blueBirdCageFrame[n] >= 7 && Main.blueBirdCageFrame[n] <= 10)
                                    {
                                        Main.blueBirdCageFrameCounter[n]++;
                                        if (Main.blueBirdCageFrameCounter[n] >= 5)
                                        {
                                            Main.blueBirdCageFrame[n]++;
                                            if (Main.blueBirdCageFrame[n] > 10)
                                            {
                                                Main.blueBirdCageFrame[n] = 0;
                                            }
                                            Main.blueBirdCageFrameCounter[n] = 0;
                                        }
                                    }
                                    else
                                    {
                                        if (Main.blueBirdCageFrame[n] >= 11 && Main.blueBirdCageFrame[n] <= 13)
                                        {
                                            Main.blueBirdCageFrameCounter[n]++;
                                            if (Main.blueBirdCageFrameCounter[n] >= 5)
                                            {
                                                Main.blueBirdCageFrame[n]++;
                                                Main.blueBirdCageFrameCounter[n] = 0;
                                            }
                                        }
                                        else
                                        {
                                            if (Main.blueBirdCageFrame[n] == 14)
                                            {
                                                Main.blueBirdCageFrameCounter[n]++;
                                                if (Main.blueBirdCageFrameCounter[n] > Main.rand.Next(5, 600))
                                                {
                                                    if (Main.rand.Next(20) == 0)
                                                    {
                                                        Main.blueBirdCageFrame[n] = 16;
                                                    }
                                                    else
                                                    {
                                                        if (Main.rand.Next(20) == 0)
                                                        {
                                                            Main.blueBirdCageFrame[n] = 4;
                                                        }
                                                        else
                                                        {
                                                            Main.blueBirdCageFrame[n] = 15;
                                                        }
                                                    }
                                                    Main.blueBirdCageFrameCounter[n] = 0;
                                                }
                                            }
                                            else
                                            {
                                                if (Main.blueBirdCageFrame[n] == 15)
                                                {
                                                    Main.blueBirdCageFrameCounter[n]++;
                                                    if (Main.blueBirdCageFrameCounter[n] >= 10)
                                                    {
                                                        Main.blueBirdCageFrameCounter[n] = 0;
                                                        Main.blueBirdCageFrame[n] = 14;
                                                    }
                                                }
                                                else
                                                {
                                                    if (Main.blueBirdCageFrame[n] >= 16 && Main.blueBirdCageFrame[n] <= 18)
                                                    {
                                                        Main.blueBirdCageFrameCounter[n]++;
                                                        if (Main.blueBirdCageFrameCounter[n] >= 5)
                                                        {
                                                            Main.blueBirdCageFrame[n]++;
                                                            if (Main.blueBirdCageFrame[n] > 18)
                                                            {
                                                                Main.blueBirdCageFrame[n] = 0;
                                                            }
                                                            Main.blueBirdCageFrameCounter[n] = 0;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                for (int num2 = 0; num2 < Main.cageFrames; num2++)
                {
                    if (Main.redBirdCageFrame[num2] == 0)
                    {
                        Main.redBirdCageFrameCounter[num2]++;
                        if (Main.redBirdCageFrameCounter[num2] > Main.rand.Next(30, 2700))
                        {
                            if (Main.rand.Next(3) != 0)
                            {
                                if (Main.rand.Next(3) != 0)
                                {
                                    Main.redBirdCageFrame[num2] = 2;
                                }
                                else
                                {
                                    Main.redBirdCageFrame[num2] = 1;
                                }
                            }
                            Main.redBirdCageFrameCounter[num2] = 0;
                        }
                    }
                    else
                    {
                        if (Main.redBirdCageFrame[num2] == 1)
                        {
                            Main.redBirdCageFrameCounter[num2]++;
                            if (Main.redBirdCageFrameCounter[num2] > Main.rand.Next(900, 18000) && Main.rand.Next(3) == 0)
                            {
                                Main.redBirdCageFrameCounter[num2] = 0;
                                Main.redBirdCageFrame[num2] = 0;
                            }
                        }
                        else
                        {
                            if (Main.redBirdCageFrame[num2] >= 2 && Main.redBirdCageFrame[num2] <= 5)
                            {
                                Main.redBirdCageFrameCounter[num2]++;
                                if (Main.redBirdCageFrameCounter[num2] >= 5)
                                {
                                    Main.redBirdCageFrameCounter[num2] = 0;
                                    if (Main.redBirdCageFrame[num2] == 3 && Main.rand.Next(3) == 0)
                                    {
                                        Main.redBirdCageFrame[num2] = 13;
                                    }
                                    else
                                    {
                                        Main.redBirdCageFrame[num2]++;
                                    }
                                }
                            }
                            else
                            {
                                if (Main.redBirdCageFrame[num2] == 6)
                                {
                                    Main.redBirdCageFrameCounter[num2]++;
                                    if (Main.redBirdCageFrameCounter[num2] > Main.rand.Next(45, 2700))
                                    {
                                        if (Main.rand.Next(3) != 0)
                                        {
                                            if (Main.rand.Next(6) == 0)
                                            {
                                                Main.redBirdCageFrame[num2] = 7;
                                            }
                                            else
                                            {
                                                if (Main.rand.Next(6) == 0)
                                                {
                                                    Main.redBirdCageFrame[num2] = 11;
                                                }
                                            }
                                        }
                                        Main.redBirdCageFrameCounter[num2] = 0;
                                    }
                                }
                                else
                                {
                                    if (Main.redBirdCageFrame[num2] >= 7 && Main.redBirdCageFrame[num2] <= 10)
                                    {
                                        Main.redBirdCageFrameCounter[num2]++;
                                        if (Main.redBirdCageFrameCounter[num2] >= 5)
                                        {
                                            Main.redBirdCageFrame[num2]++;
                                            if (Main.redBirdCageFrame[num2] > 10)
                                            {
                                                Main.redBirdCageFrame[num2] = 0;
                                            }
                                            Main.redBirdCageFrameCounter[num2] = 0;
                                        }
                                    }
                                    else
                                    {
                                        if (Main.redBirdCageFrame[num2] >= 11 && Main.redBirdCageFrame[num2] <= 13)
                                        {
                                            Main.redBirdCageFrameCounter[num2]++;
                                            if (Main.redBirdCageFrameCounter[num2] >= 5)
                                            {
                                                Main.redBirdCageFrame[num2]++;
                                                Main.redBirdCageFrameCounter[num2] = 0;
                                            }
                                        }
                                        else
                                        {
                                            if (Main.redBirdCageFrame[num2] == 14)
                                            {
                                                Main.redBirdCageFrameCounter[num2]++;
                                                if (Main.redBirdCageFrameCounter[num2] > Main.rand.Next(5, 600))
                                                {
                                                    if (Main.rand.Next(20) == 0)
                                                    {
                                                        Main.redBirdCageFrame[num2] = 16;
                                                    }
                                                    else
                                                    {
                                                        if (Main.rand.Next(20) == 0)
                                                        {
                                                            Main.redBirdCageFrame[num2] = 4;
                                                        }
                                                        else
                                                        {
                                                            Main.redBirdCageFrame[num2] = 15;
                                                        }
                                                    }
                                                    Main.redBirdCageFrameCounter[num2] = 0;
                                                }
                                            }
                                            else
                                            {
                                                if (Main.redBirdCageFrame[num2] == 15)
                                                {
                                                    Main.redBirdCageFrameCounter[num2]++;
                                                    if (Main.redBirdCageFrameCounter[num2] >= 10)
                                                    {
                                                        Main.redBirdCageFrameCounter[num2] = 0;
                                                        Main.redBirdCageFrame[num2] = 14;
                                                    }
                                                }
                                                else
                                                {
                                                    if (Main.redBirdCageFrame[num2] >= 16 && Main.redBirdCageFrame[num2] <= 18)
                                                    {
                                                        Main.redBirdCageFrameCounter[num2]++;
                                                        if (Main.redBirdCageFrameCounter[num2] >= 5)
                                                        {
                                                            Main.redBirdCageFrame[num2]++;
                                                            if (Main.redBirdCageFrame[num2] > 18)
                                                            {
                                                                Main.redBirdCageFrame[num2] = 0;
                                                            }
                                                            Main.redBirdCageFrameCounter[num2] = 0;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                for (int num3 = 0; num3 < 2; num3++)
                {
                    for (int num4 = 0; num4 < Main.cageFrames; num4++)
                    {
                        if (Main.scorpionCageFrame[num3, num4] == 0 || Main.scorpionCageFrame[num3, num4] == 7)
                        {
                            Main.scorpionCageFrameCounter[num3, num4]++;
                            if (Main.scorpionCageFrameCounter[num3, num4] > Main.rand.Next(30, 3600))
                            {
                                if (Main.scorpionCageFrame[num3, num4] == 7)
                                {
                                    Main.scorpionCageFrame[num3, num4] = 0;
                                }
                                else
                                {
                                    if (Main.rand.Next(3) == 0)
                                    {
                                        if (Main.rand.Next(7) == 0)
                                        {
                                            Main.scorpionCageFrame[num3, num4] = 1;
                                        }
                                        else
                                        {
                                            if (Main.rand.Next(4) == 0)
                                            {
                                                Main.scorpionCageFrame[num3, num4] = 8;
                                            }
                                            else
                                            {
                                                if (Main.rand.Next(3) == 0)
                                                {
                                                    Main.scorpionCageFrame[num3, num4] = 7;
                                                }
                                                else
                                                {
                                                    Main.scorpionCageFrame[num3, num4] = 14;
                                                }
                                            }
                                        }
                                    }
                                }
                                Main.scorpionCageFrameCounter[num3, num4] = 0;
                            }
                        }
                        else
                        {
                            if (Main.scorpionCageFrame[num3, num4] >= 1 && Main.scorpionCageFrame[num3, num4] <= 2)
                            {
                                Main.scorpionCageFrameCounter[num3, num4]++;
                                if (Main.scorpionCageFrameCounter[num3, num4] >= 10)
                                {
                                    Main.scorpionCageFrameCounter[num3, num4] = 0;
                                    Main.scorpionCageFrame[num3, num4]++;
                                }
                            }
                            else
                            {
                                if (Main.scorpionCageFrame[num3, num4] >= 8 && Main.scorpionCageFrame[num3, num4] <= 10)
                                {
                                    Main.scorpionCageFrameCounter[num3, num4]++;
                                    if (Main.scorpionCageFrameCounter[num3, num4] >= 10)
                                    {
                                        Main.scorpionCageFrameCounter[num3, num4] = 0;
                                        Main.scorpionCageFrame[num3, num4]++;
                                    }
                                }
                                else
                                {
                                    if (Main.scorpionCageFrame[num3, num4] == 11)
                                    {
                                        Main.scorpionCageFrameCounter[num3, num4]++;
                                        if (Main.scorpionCageFrameCounter[num3, num4] > Main.rand.Next(45, 5400))
                                        {
                                            if (Main.rand.Next(6) == 0)
                                            {
                                                Main.scorpionCageFrame[num3, num4] = 12;
                                            }
                                            Main.scorpionCageFrameCounter[num3, num4] = 0;
                                        }
                                    }
                                    else
                                    {
                                        if (Main.scorpionCageFrame[num3, num4] >= 12 && Main.scorpionCageFrame[num3, num4] <= 13)
                                        {
                                            Main.scorpionCageFrameCounter[num3, num4]++;
                                            if (Main.scorpionCageFrameCounter[num3, num4] >= 10)
                                            {
                                                Main.scorpionCageFrameCounter[num3, num4] = 0;
                                                Main.scorpionCageFrame[num3, num4]++;
                                                if (Main.scorpionCageFrame[num3, num4] > 13)
                                                {
                                                    Main.scorpionCageFrame[num3, num4] = 0;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (Main.scorpionCageFrame[num3, num4] >= 14 && Main.scorpionCageFrame[num3, num4] <= 15)
                                            {
                                                Main.scorpionCageFrameCounter[num3, num4]++;
                                                if (Main.scorpionCageFrameCounter[num3, num4] >= 5)
                                                {
                                                    Main.scorpionCageFrameCounter[num3, num4] = 0;
                                                    Main.scorpionCageFrame[num3, num4]++;
                                                    if (Main.scorpionCageFrame[num3, num4] > 15)
                                                    {
                                                        Main.scorpionCageFrame[num3, num4] = 14;
                                                    }
                                                    if (Main.rand.Next(5) == 0)
                                                    {
                                                        Main.scorpionCageFrame[num3, num4] = 0;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if (Main.scorpionCageFrame[num3, num4] == 4 || Main.scorpionCageFrame[num3, num4] == 3)
                                                {
                                                    Main.scorpionCageFrameCounter[num3, num4]++;
                                                    if (Main.scorpionCageFrameCounter[num3, num4] > Main.rand.Next(30, 3600))
                                                    {
                                                        if (Main.scorpionCageFrame[num3, num4] == 3)
                                                        {
                                                            Main.scorpionCageFrame[num3, num4] = 4;
                                                        }
                                                        else
                                                        {
                                                            if (Main.rand.Next(3) == 0)
                                                            {
                                                                if (Main.rand.Next(5) == 0)
                                                                {
                                                                    Main.scorpionCageFrame[num3, num4] = 5;
                                                                }
                                                                else
                                                                {
                                                                    if (Main.rand.Next(3) == 0)
                                                                    {
                                                                        Main.scorpionCageFrame[num3, num4] = 3;
                                                                    }
                                                                    else
                                                                    {
                                                                        Main.scorpionCageFrame[num3, num4] = 16;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        Main.scorpionCageFrameCounter[num3, num4] = 0;
                                                    }
                                                }
                                                else
                                                {
                                                    if (Main.scorpionCageFrame[num3, num4] >= 5 && Main.scorpionCageFrame[num3, num4] <= 6)
                                                    {
                                                        Main.scorpionCageFrameCounter[num3, num4]++;
                                                        if (Main.scorpionCageFrameCounter[num3, num4] >= 10)
                                                        {
                                                            Main.scorpionCageFrameCounter[num3, num4] = 0;
                                                            Main.scorpionCageFrame[num3, num4]++;
                                                            if (Main.scorpionCageFrame[num3, num4] > 7)
                                                            {
                                                                Main.scorpionCageFrame[num3, num4] = 0;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Main.scorpionCageFrame[num3, num4] >= 16 && Main.scorpionCageFrame[num3, num4] <= 17)
                                                        {
                                                            Main.scorpionCageFrameCounter[num3, num4]++;
                                                            if (Main.scorpionCageFrameCounter[num3, num4] >= 5)
                                                            {
                                                                Main.scorpionCageFrameCounter[num3, num4] = 0;
                                                                Main.scorpionCageFrame[num3, num4]++;
                                                                if (Main.scorpionCageFrame[num3, num4] > 17)
                                                                {
                                                                    Main.scorpionCageFrame[num3, num4] = 16;
                                                                }
                                                                if (Main.rand.Next(5) == 0)
                                                                {
                                                                    Main.scorpionCageFrame[num3, num4] = 4;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                for (int num5 = 0; num5 < Main.cageFrames; num5++)
                {
                    if (Main.penguinCageFrame[num5] == 0)
                    {
                        Main.penguinCageFrameCounter[num5]++;
                        if (Main.penguinCageFrameCounter[num5] > Main.rand.Next(30, 1800))
                        {
                            if (Main.rand.Next(2) == 0)
                            {
                                if (Main.rand.Next(10) == 0)
                                {
                                    Main.penguinCageFrame[num5] = 4;
                                }
                                else
                                {
                                    if (Main.rand.Next(7) == 0)
                                    {
                                        Main.penguinCageFrame[num5] = 15;
                                    }
                                    else
                                    {
                                        if (Main.rand.Next(3) == 0)
                                        {
                                            Main.penguinCageFrame[num5] = 2;
                                        }
                                        else
                                        {
                                            Main.penguinCageFrame[num5] = 1;
                                        }
                                    }
                                }
                            }
                            Main.penguinCageFrameCounter[num5] = 0;
                        }
                    }
                    else
                    {
                        if (Main.penguinCageFrame[num5] == 1)
                        {
                            Main.penguinCageFrameCounter[num5]++;
                            if (Main.penguinCageFrameCounter[num5] >= 10)
                            {
                                Main.penguinCageFrameCounter[num5] = 0;
                                Main.penguinCageFrame[num5] = 0;
                            }
                        }
                        else
                        {
                            if (Main.penguinCageFrame[num5] >= 2 && Main.penguinCageFrame[num5] <= 3)
                            {
                                Main.penguinCageFrameCounter[num5]++;
                                if (Main.penguinCageFrameCounter[num5] >= 5)
                                {
                                    Main.penguinCageFrameCounter[num5] = 0;
                                    Main.penguinCageFrame[num5]++;
                                    if (Main.penguinCageFrame[num5] > 3)
                                    {
                                        if (Main.rand.Next(3) == 0)
                                        {
                                            Main.penguinCageFrame[num5] = 0;
                                        }
                                        else
                                        {
                                            Main.penguinCageFrame[num5] = 2;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (Main.penguinCageFrame[num5] >= 4 && Main.penguinCageFrame[num5] <= 6)
                                {
                                    Main.penguinCageFrameCounter[num5]++;
                                    if (Main.penguinCageFrameCounter[num5] >= 10)
                                    {
                                        Main.penguinCageFrameCounter[num5] = 0;
                                        Main.penguinCageFrame[num5]++;
                                    }
                                }
                                else
                                {
                                    if (Main.penguinCageFrame[num5] == 15)
                                    {
                                        Main.penguinCageFrameCounter[num5]++;
                                        if (Main.penguinCageFrameCounter[num5] > Main.rand.Next(10, 1800))
                                        {
                                            if (Main.rand.Next(2) == 0)
                                            {
                                                Main.penguinCageFrame[num5] = 0;
                                            }
                                            Main.penguinCageFrameCounter[num5] = 0;
                                        }
                                    }
                                    else
                                    {
                                        if (Main.penguinCageFrame[num5] == 8)
                                        {
                                            Main.penguinCageFrameCounter[num5]++;
                                            if (Main.penguinCageFrameCounter[num5] > Main.rand.Next(30, 3600))
                                            {
                                                if (Main.rand.Next(2) == 0)
                                                {
                                                    if (Main.rand.Next(10) == 0)
                                                    {
                                                        Main.penguinCageFrame[num5] = 12;
                                                    }
                                                    else
                                                    {
                                                        if (Main.rand.Next(7) == 0)
                                                        {
                                                            Main.penguinCageFrame[num5] = 7;
                                                        }
                                                        else
                                                        {
                                                            if (Main.rand.Next(3) == 0)
                                                            {
                                                                Main.penguinCageFrame[num5] = 10;
                                                            }
                                                            else
                                                            {
                                                                Main.penguinCageFrame[num5] = 9;
                                                            }
                                                        }
                                                    }
                                                }
                                                Main.penguinCageFrameCounter[num5] = 0;
                                            }
                                        }
                                        else
                                        {
                                            if (Main.penguinCageFrame[num5] == 9)
                                            {
                                                Main.penguinCageFrameCounter[num5]++;
                                                if (Main.penguinCageFrameCounter[num5] >= 10)
                                                {
                                                    Main.penguinCageFrameCounter[num5] = 0;
                                                    Main.penguinCageFrame[num5] = 8;
                                                }
                                            }
                                            else
                                            {
                                                if (Main.penguinCageFrame[num5] >= 10 && Main.penguinCageFrame[num5] <= 11)
                                                {
                                                    Main.penguinCageFrameCounter[num5]++;
                                                    if (Main.penguinCageFrameCounter[num5] >= 5)
                                                    {
                                                        Main.penguinCageFrameCounter[num5] = 0;
                                                        Main.penguinCageFrame[num5]++;
                                                        if (Main.penguinCageFrame[num5] > 3)
                                                        {
                                                            if (Main.rand.Next(3) == 0)
                                                            {
                                                                Main.penguinCageFrame[num5] = 8;
                                                            }
                                                            else
                                                            {
                                                                Main.penguinCageFrame[num5] = 10;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (Main.penguinCageFrame[num5] >= 12 && Main.penguinCageFrame[num5] <= 14)
                                                    {
                                                        Main.penguinCageFrameCounter[num5]++;
                                                        if (Main.penguinCageFrameCounter[num5] >= 10)
                                                        {
                                                            Main.penguinCageFrameCounter[num5] = 0;
                                                            Main.penguinCageFrame[num5]++;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Main.penguinCageFrame[num5] == 7)
                                                        {
                                                            Main.penguinCageFrameCounter[num5]++;
                                                            if (Main.penguinCageFrameCounter[num5] > Main.rand.Next(10, 3600))
                                                            {
                                                                if (Main.rand.Next(2) == 0)
                                                                {
                                                                    Main.penguinCageFrame[num5] = 8;
                                                                }
                                                                Main.penguinCageFrameCounter[num5] = 0;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                for (int num6 = 0; num6 < Main.cageFrames; num6++)
                {
                    if (Main.snailCageFrame[num6] >= 0 && Main.snailCageFrame[num6] <= 13)
                    {
                        Main.snailCageFrameCounter[num6]++;
                        if (Main.snailCageFrameCounter[num6] > Main.rand.Next(45, 3600))
                        {
                            if (Main.snailCageFrame[num6] == 8 && Main.rand.Next(2) == 0)
                            {
                                Main.snailCageFrame[num6] = 14;
                            }
                            else
                            {
                                if (Main.snailCageFrame[num6] == 1 && Main.rand.Next(3) == 0)
                                {
                                    Main.snailCageFrame[num6] = 19;
                                }
                                else
                                {
                                    if (Main.snailCageFrame[num6] == 1 && Main.rand.Next(3) == 0)
                                    {
                                        Main.snailCageFrame[num6] = 20;
                                    }
                                    else
                                    {
                                        Main.snailCageFrame[num6]++;
                                        if (Main.snailCageFrame[num6] > 13)
                                        {
                                            Main.snailCageFrame[num6] = 0;
                                        }
                                    }
                                }
                            }
                            Main.snailCageFrameCounter[num6] = 0;
                        }
                    }
                    else
                    {
                        if (Main.snailCageFrame[num6] >= 14 && Main.snailCageFrame[num6] <= 18)
                        {
                            Main.snailCageFrameCounter[num6]++;
                            if (Main.snailCageFrameCounter[num6] >= 5)
                            {
                                Main.snailCageFrameCounter[num6] = 0;
                                Main.snailCageFrame[num6]++;
                            }
                            if (Main.snailCageFrame[num6] > 18)
                            {
                                Main.snailCageFrame[num6] = 20;
                            }
                        }
                        else
                        {
                            if (Main.snailCageFrame[num6] == 19 || Main.snailCageFrame[num6] == 20)
                            {
                                Main.snailCageFrameCounter[num6]++;
                                if (Main.snailCageFrameCounter[num6] > Main.rand.Next(60, 7200))
                                {
                                    Main.snailCageFrameCounter[num6] = 0;
                                    if (Main.rand.Next(4) == 0)
                                    {
                                        if (Main.rand.Next(3) == 0)
                                        {
                                            Main.snailCageFrame[num6] = 2;
                                        }
                                        else
                                        {
                                            if (Main.snailCageFrame[num6] == 19)
                                            {
                                                Main.snailCageFrame[num6] = 20;
                                            }
                                            else
                                            {
                                                Main.snailCageFrame[num6] = 19;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                for (int num7 = 0; num7 < Main.cageFrames; num7++)
                {
                    if (Main.snail2CageFrame[num7] >= 0 && Main.snail2CageFrame[num7] <= 13)
                    {
                        Main.snail2CageFrameCounter[num7]++;
                        if (Main.snail2CageFrameCounter[num7] > Main.rand.Next(30, 2700))
                        {
                            if (Main.snail2CageFrame[num7] == 8 && Main.rand.Next(2) == 0)
                            {
                                Main.snail2CageFrame[num7] = 14;
                            }
                            else
                            {
                                if (Main.snail2CageFrame[num7] == 1 && Main.rand.Next(3) == 0)
                                {
                                    Main.snail2CageFrame[num7] = 19;
                                }
                                else
                                {
                                    if (Main.snail2CageFrame[num7] == 1 && Main.rand.Next(3) == 0)
                                    {
                                        Main.snail2CageFrame[num7] = 20;
                                    }
                                    else
                                    {
                                        Main.snail2CageFrame[num7]++;
                                        if (Main.snail2CageFrame[num7] > 13)
                                        {
                                            Main.snail2CageFrame[num7] = 0;
                                        }
                                    }
                                }
                            }
                            Main.snail2CageFrameCounter[num7] = 0;
                        }
                    }
                    else
                    {
                        if (Main.snail2CageFrame[num7] >= 14 && Main.snail2CageFrame[num7] <= 18)
                        {
                            Main.snail2CageFrameCounter[num7]++;
                            if (Main.snail2CageFrameCounter[num7] >= 5)
                            {
                                Main.snail2CageFrameCounter[num7] = 0;
                                Main.snail2CageFrame[num7]++;
                            }
                            if (Main.snail2CageFrame[num7] > 18)
                            {
                                Main.snail2CageFrame[num7] = 20;
                            }
                        }
                        else
                        {
                            if (Main.snail2CageFrame[num7] == 19 || Main.snail2CageFrame[num7] == 20)
                            {
                                Main.snail2CageFrameCounter[num7]++;
                                if (Main.snail2CageFrameCounter[num7] > Main.rand.Next(45, 5400))
                                {
                                    Main.snail2CageFrameCounter[num7] = 0;
                                    if (Main.rand.Next(4) == 0)
                                    {
                                        if (Main.rand.Next(3) == 0)
                                        {
                                            Main.snail2CageFrame[num7] = 2;
                                        }
                                        else
                                        {
                                            if (Main.snail2CageFrame[num7] == 19)
                                            {
                                                Main.snail2CageFrame[num7] = 20;
                                            }
                                            else
                                            {
                                                Main.snail2CageFrame[num7] = 19;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                for (int num8 = 0; num8 < Main.cageFrames; num8++)
                {
                    if (Main.frogCageFrame[num8] == 0)
                    {
                        Main.frogCageFrameCounter[num8]++;
                        if (Main.frogCageFrameCounter[num8] > Main.rand.Next(45, 3600))
                        {
                            if (Main.rand.Next(10) == 0)
                            {
                                Main.frogCageFrame[num8] = 1;
                            }
                            else
                            {
                                Main.frogCageFrame[num8] = 12;
                            }
                            Main.frogCageFrameCounter[num8] = 0;
                        }
                    }
                    else
                    {
                        if (Main.frogCageFrame[num8] >= 1 && Main.frogCageFrame[num8] <= 5)
                        {
                            Main.frogCageFrameCounter[num8]++;
                            if (Main.frogCageFrameCounter[num8] >= 5)
                            {
                                Main.frogCageFrame[num8]++;
                                Main.frogCageFrameCounter[num8] = 0;
                            }
                        }
                        else
                        {
                            if (Main.frogCageFrame[num8] >= 12 && Main.frogCageFrame[num8] <= 17)
                            {
                                Main.frogCageFrameCounter[num8]++;
                                if (Main.frogCageFrameCounter[num8] >= 5)
                                {
                                    Main.frogCageFrameCounter[num8] = 0;
                                    Main.frogCageFrame[num8]++;
                                }
                                if (Main.frogCageFrame[num8] > 17)
                                {
                                    if (Main.rand.Next(3) == 0)
                                    {
                                        Main.frogCageFrame[num8] = 0;
                                    }
                                    else
                                    {
                                        Main.frogCageFrame[num8] = 12;
                                    }
                                }
                            }
                            else
                            {
                                if (Main.frogCageFrame[num8] == 6)
                                {
                                    Main.frogCageFrameCounter[num8]++;
                                    if (Main.frogCageFrameCounter[num8] > Main.rand.Next(45, 3600))
                                    {
                                        if (Main.rand.Next(10) == 0)
                                        {
                                            Main.frogCageFrame[num8] = 7;
                                        }
                                        else
                                        {
                                            Main.frogCageFrame[num8] = 18;
                                        }
                                        Main.frogCageFrameCounter[num8] = 0;
                                    }
                                }
                                else
                                {
                                    if (Main.frogCageFrame[num8] >= 7 && Main.frogCageFrame[num8] <= 11)
                                    {
                                        Main.frogCageFrameCounter[num8]++;
                                        if (Main.frogCageFrameCounter[num8] >= 5)
                                        {
                                            Main.frogCageFrame[num8]++;
                                            Main.frogCageFrameCounter[num8] = 0;
                                            if (Main.frogCageFrame[num8] > 11)
                                            {
                                                Main.frogCageFrame[num8] = 0;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (Main.frogCageFrame[num8] >= 18 && Main.frogCageFrame[num8] <= 23)
                                        {
                                            Main.frogCageFrameCounter[num8]++;
                                            if (Main.frogCageFrameCounter[num8] >= 5)
                                            {
                                                Main.frogCageFrameCounter[num8] = 0;
                                                Main.frogCageFrame[num8]++;
                                            }
                                            if (Main.frogCageFrame[num8] > 17)
                                            {
                                                if (Main.rand.Next(3) == 0)
                                                {
                                                    Main.frogCageFrame[num8] = 6;
                                                }
                                                else
                                                {
                                                    Main.frogCageFrame[num8] = 18;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                for (int num9 = 0; num9 < Main.cageFrames; num9++)
                {
                    if (Main.mouseCageFrame[num9] >= 0 && Main.mouseCageFrame[num9] <= 1)
                    {
                        Main.mouseCageFrameCounter[num9]++;
                        if (Main.mouseCageFrameCounter[num9] >= 5)
                        {
                            Main.mouseCageFrame[num9]++;
                            if (Main.mouseCageFrame[num9] > 1)
                            {
                                Main.mouseCageFrame[num9] = 0;
                            }
                            Main.mouseCageFrameCounter[num9] = 0;
                            if (Main.rand.Next(15) == 0)
                            {
                                Main.mouseCageFrame[num9] = 4;
                            }
                        }
                    }
                    else
                    {
                        if (Main.mouseCageFrame[num9] >= 4 && Main.mouseCageFrame[num9] <= 7)
                        {
                            Main.mouseCageFrameCounter[num9]++;
                            if (Main.mouseCageFrameCounter[num9] >= 5)
                            {
                                Main.mouseCageFrameCounter[num9] = 0;
                                Main.mouseCageFrame[num9]++;
                            }
                            if (Main.mouseCageFrame[num9] > 7)
                            {
                                Main.mouseCageFrame[num9] = 2;
                            }
                        }
                        else
                        {
                            if (Main.mouseCageFrame[num9] >= 2 && Main.mouseCageFrame[num9] <= 3)
                            {
                                Main.mouseCageFrameCounter[num9]++;
                                if (Main.mouseCageFrameCounter[num9] >= 5)
                                {
                                    Main.mouseCageFrame[num9]++;
                                    if (Main.mouseCageFrame[num9] > 3)
                                    {
                                        Main.mouseCageFrame[num9] = 2;
                                    }
                                    Main.mouseCageFrameCounter[num9] = 0;
                                    if (Main.rand.Next(15) == 0)
                                    {
                                        Main.mouseCageFrame[num9] = 8;
                                    }
                                    else
                                    {
                                        if (Main.rand.Next(15) == 0)
                                        {
                                            Main.mouseCageFrame[num9] = 12;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (Main.mouseCageFrame[num9] >= 8 && Main.mouseCageFrame[num9] <= 11)
                                {
                                    Main.mouseCageFrameCounter[num9]++;
                                    if (Main.mouseCageFrameCounter[num9] >= 5)
                                    {
                                        Main.mouseCageFrameCounter[num9] = 0;
                                        Main.mouseCageFrame[num9]++;
                                    }
                                    if (Main.mouseCageFrame[num9] > 11)
                                    {
                                        Main.mouseCageFrame[num9] = 0;
                                    }
                                }
                                else
                                {
                                    if (Main.mouseCageFrame[num9] >= 12 && Main.mouseCageFrame[num9] <= 13)
                                    {
                                        Main.mouseCageFrameCounter[num9]++;
                                        if (Main.mouseCageFrameCounter[num9] >= 5)
                                        {
                                            Main.mouseCageFrameCounter[num9] = 0;
                                            Main.mouseCageFrame[num9]++;
                                        }
                                    }
                                    else
                                    {
                                        if (Main.mouseCageFrame[num9] >= 14 && Main.mouseCageFrame[num9] <= 17)
                                        {
                                            Main.mouseCageFrameCounter[num9]++;
                                            if (Main.mouseCageFrameCounter[num9] >= 5)
                                            {
                                                Main.mouseCageFrameCounter[num9] = 0;
                                                Main.mouseCageFrame[num9]++;
                                                if (Main.mouseCageFrame[num9] > 17 && Main.rand.Next(20) != 0)
                                                {
                                                    Main.mouseCageFrame[num9] = 14;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (Main.mouseCageFrame[num9] >= 18 && Main.mouseCageFrame[num9] <= 19)
                                            {
                                                Main.mouseCageFrameCounter[num9]++;
                                                if (Main.mouseCageFrameCounter[num9] >= 5)
                                                {
                                                    Main.mouseCageFrameCounter[num9] = 0;
                                                    Main.mouseCageFrame[num9]++;
                                                    if (Main.mouseCageFrame[num9] > 19)
                                                    {
                                                        Main.mouseCageFrame[num9] = 0;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                for (int num10 = 0; num10 < Main.cageFrames; num10++)
                {
                    Main.wormCageFrameCounter[num10]++;
                    if (Main.wormCageFrameCounter[num10] >= Main.rand.Next(30, 91))
                    {
                        Main.wormCageFrameCounter[num10] = 0;
                        if (Main.rand.Next(4) == 0)
                        {
                            Main.wormCageFrame[num10]++;
                            if (Main.wormCageFrame[num10] == 9 && Main.rand.Next(2) == 0)
                            {
                                Main.wormCageFrame[num10] = 0;
                            }
                            if (Main.wormCageFrame[num10] > 18)
                            {
                                if (Main.rand.Next(2) == 0)
                                {
                                    Main.wormCageFrame[num10] = 9;
                                }
                                else
                                {
                                    Main.wormCageFrame[num10] = 0;
                                }
                            }
                        }
                    }
                }
                for (int num11 = 0; num11 < Main.cageFrames; num11++)
                {
                    byte maxValue = 5;
                    if (Main.fishBowlFrameMode[num11] == 1)
                    {
                        if (Main.rand.Next(900) == 0)
                        {
                            Main.fishBowlFrameMode[num11] = (byte)Main.rand.Next((int)maxValue);
                        }
                        Main.fishBowlFrameCounter[num11]++;
                        if (Main.fishBowlFrameCounter[num11] >= 5)
                        {
                            Main.fishBowlFrameCounter[num11] = 0;
                            if (Main.fishBowlFrame[num11] == 10)
                            {
                                if (Main.rand.Next(20) == 0)
                                {
                                    Main.fishBowlFrame[num11] = 11;
                                    Main.fishBowlFrameMode[num11] = 0;
                                }
                                else
                                {
                                    Main.fishBowlFrame[num11] = 1;
                                }
                            }
                            else
                            {
                                Main.fishBowlFrame[num11]++;
                            }
                        }
                    }
                    else
                    {
                        if (Main.fishBowlFrameMode[num11] == 2)
                        {
                            if (Main.rand.Next(3600) == 0)
                            {
                                Main.fishBowlFrameMode[num11] = (byte)Main.rand.Next((int)maxValue);
                            }
                            Main.fishBowlFrameCounter[num11]++;
                            if (Main.fishBowlFrameCounter[num11] >= 20)
                            {
                                Main.fishBowlFrameCounter[num11] = 0;
                                if (Main.fishBowlFrame[num11] == 10)
                                {
                                    if (Main.rand.Next(20) == 0)
                                    {
                                        Main.fishBowlFrame[num11] = 11;
                                        Main.fishBowlFrameMode[num11] = 0;
                                    }
                                    else
                                    {
                                        Main.fishBowlFrame[num11] = 1;
                                    }
                                }
                                else
                                {
                                    Main.fishBowlFrame[num11]++;
                                }
                            }
                        }
                        else
                        {
                            if (Main.fishBowlFrameMode[num11] == 3)
                            {
                                if (Main.rand.Next(3600) == 0)
                                {
                                    Main.fishBowlFrameMode[num11] = (byte)Main.rand.Next((int)maxValue);
                                }
                                Main.fishBowlFrameCounter[num11]++;
                                if (Main.fishBowlFrameCounter[num11] >= Main.rand.Next(5, 3600))
                                {
                                    Main.fishBowlFrameCounter[num11] = 0;
                                    if (Main.fishBowlFrame[num11] == 10)
                                    {
                                        if (Main.rand.Next(20) == 0)
                                        {
                                            Main.fishBowlFrame[num11] = 11;
                                            Main.fishBowlFrameMode[num11] = 0;
                                        }
                                        else
                                        {
                                            Main.fishBowlFrame[num11] = 1;
                                        }
                                    }
                                    else
                                    {
                                        Main.fishBowlFrame[num11]++;
                                    }
                                }
                            }
                            else
                            {
                                if (Main.fishBowlFrame[num11] <= 10)
                                {
                                    if (Main.rand.Next(3600) == 0)
                                    {
                                        Main.fishBowlFrameMode[num11] = (byte)Main.rand.Next((int)maxValue);
                                    }
                                    Main.fishBowlFrameCounter[num11]++;
                                    if (Main.fishBowlFrameCounter[num11] >= 10)
                                    {
                                        Main.fishBowlFrameCounter[num11] = 0;
                                        if (Main.fishBowlFrame[num11] == 10)
                                        {
                                            if (Main.rand.Next(12) == 0)
                                            {
                                                Main.fishBowlFrame[num11] = 11;
                                            }
                                            else
                                            {
                                                Main.fishBowlFrame[num11] = 1;
                                            }
                                        }
                                        else
                                        {
                                            Main.fishBowlFrame[num11]++;
                                        }
                                    }
                                }
                                else
                                {
                                    if (Main.fishBowlFrame[num11] == 12 || Main.fishBowlFrame[num11] == 13)
                                    {
                                        Main.fishBowlFrameCounter[num11]++;
                                        if (Main.fishBowlFrameCounter[num11] >= 10)
                                        {
                                            Main.fishBowlFrameCounter[num11] = 0;
                                            Main.fishBowlFrame[num11]++;
                                            if (Main.fishBowlFrame[num11] > 13)
                                            {
                                                if (Main.rand.Next(20) == 0)
                                                {
                                                    Main.fishBowlFrame[num11] = 14;
                                                }
                                                else
                                                {
                                                    Main.fishBowlFrame[num11] = 12;
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (Main.fishBowlFrame[num11] >= 11)
                                        {
                                            Main.fishBowlFrameCounter[num11]++;
                                            if (Main.fishBowlFrameCounter[num11] >= 10)
                                            {
                                                Main.fishBowlFrameCounter[num11] = 0;
                                                Main.fishBowlFrame[num11]++;
                                                if (Main.fishBowlFrame[num11] > 16)
                                                {
                                                    Main.fishBowlFrame[num11] = 4;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                for (int num12 = 0; num12 < 8; num12++)
                {
                    for (int num13 = 0; num13 < Main.cageFrames; num13++)
                    {
                        Main.butterflyCageFrameCounter[num12, num13]++;
                        if (Main.rand.Next(3600) == 0)
                        {
                            Main.butterflyCageMode[num12, num13] = (byte)Main.rand.Next(5);
                            if (Main.rand.Next(2) == 0)
                            {
                                Main.butterflyCageMode[num12, num13] = (byte)(Main.butterflyCageMode[num12, num13] + 10);
                            }
                        }
                        int num14 = Main.rand.Next(3, 16);
                        if (Main.butterflyCageMode[num12, num13] == 1 || Main.butterflyCageMode[num12, num13] == 11)
                        {
                            num14 = 3;
                        }
                        if (Main.butterflyCageMode[num12, num13] == 2 || Main.butterflyCageMode[num12, num13] == 12)
                        {
                            num14 = 5;
                        }
                        if (Main.butterflyCageMode[num12, num13] == 3 || Main.butterflyCageMode[num12, num13] == 13)
                        {
                            num14 = 10;
                        }
                        if (Main.butterflyCageMode[num12, num13] == 4 || Main.butterflyCageMode[num12, num13] == 14)
                        {
                            num14 = 15;
                        }
                        if (Main.butterflyCageMode[num12, num13] >= 10)
                        {
                            if (Main.butterflyCageFrame[num12, num13] <= 7)
                            {
                                if (Main.butterflyCageFrameCounter[num12, num13] >= num14)
                                {
                                    Main.butterflyCageFrameCounter[num12, num13] = 0;
                                    Main.butterflyCageFrame[num12, num13]--;
                                    if (Main.butterflyCageFrame[num12, num13] < 0)
                                    {
                                        Main.butterflyCageFrame[num12, num13] = 7;
                                    }
                                    if (Main.butterflyCageFrame[num12, num13] == 1 || Main.butterflyCageFrame[num12, num13] == 4 || Main.butterflyCageFrame[num12, num13] == 6)
                                    {
                                        if (Main.rand.Next(20) == 0)
                                        {
                                            Main.butterflyCageFrame[num12, num13] += 8;
                                        }
                                        else
                                        {
                                            if (Main.rand.Next(6) == 0)
                                            {
                                                if (Main.butterflyCageMode[num12, num13] >= 10)
                                                {
                                                    Main.butterflyCageMode[num12, num13] = (byte)(Main.butterflyCageMode[num12, num13] - 10);
                                                }
                                                else
                                                {
                                                    Main.butterflyCageMode[num12, num13] = (byte)(Main.butterflyCageMode[num12, num13] + 10);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (Main.butterflyCageFrameCounter[num12, num13] >= num14)
                                {
                                    Main.butterflyCageFrameCounter[num12, num13] = 0;
                                    Main.butterflyCageFrame[num12, num13]--;
                                    if (Main.butterflyCageFrame[num12, num13] < 8)
                                    {
                                        Main.butterflyCageFrame[num12, num13] = 14;
                                    }
                                    if (Main.butterflyCageFrame[num12, num13] == 9 || Main.butterflyCageFrame[num12, num13] == 12 || Main.butterflyCageFrame[num12, num13] == 14)
                                    {
                                        if (Main.rand.Next(20) == 0)
                                        {
                                            Main.butterflyCageFrame[num12, num13] -= 8;
                                        }
                                        else
                                        {
                                            if (Main.rand.Next(6) == 0)
                                            {
                                                if (Main.butterflyCageMode[num12, num13] >= 10)
                                                {
                                                    Main.butterflyCageMode[num12, num13] = (byte)(Main.butterflyCageMode[num12, num13] - 10);
                                                }
                                                else
                                                {
                                                    Main.butterflyCageMode[num12, num13] = (byte)(Main.butterflyCageMode[num12, num13] + 10);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (Main.butterflyCageFrame[num12, num13] <= 7)
                            {
                                if (Main.butterflyCageFrameCounter[num12, num13] >= num14)
                                {
                                    Main.butterflyCageFrameCounter[num12, num13] = 0;
                                    Main.butterflyCageFrame[num12, num13]++;
                                    if (Main.butterflyCageFrame[num12, num13] > 7)
                                    {
                                        Main.butterflyCageFrame[num12, num13] = 0;
                                    }
                                    if ((Main.butterflyCageFrame[num12, num13] == 1 || Main.butterflyCageFrame[num12, num13] == 4 || Main.butterflyCageFrame[num12, num13] == 6) && Main.rand.Next(10) == 0)
                                    {
                                        Main.butterflyCageFrame[num12, num13] += 8;
                                    }
                                }
                            }
                            else
                            {
                                if (Main.butterflyCageFrameCounter[num12, num13] >= num14)
                                {
                                    Main.butterflyCageFrameCounter[num12, num13] = 0;
                                    Main.butterflyCageFrame[num12, num13]++;
                                    if (Main.butterflyCageFrame[num12, num13] > 15)
                                    {
                                        Main.butterflyCageFrame[num12, num13] = 8;
                                    }
                                    if ((Main.butterflyCageFrame[num12, num13] == 9 || Main.butterflyCageFrame[num12, num13] == 12 || Main.butterflyCageFrame[num12, num13] == 14) && Main.rand.Next(10) == 0)
                                    {
                                        Main.butterflyCageFrame[num12, num13] -= 8;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        
        #endregion

        public static void clrInput()
        {
            Main.keyCount = 0;
        }
        public static string GetInputText(string oldString)
        {
            if (!Main.hasFocus)
            {
                return oldString;
            }
            Main.inputTextEnter = false;
            Main.inputTextEscape = false;
            string str = oldString;
            string str1 = "";
            if (str == null)
            {
                str = "";
            }
            bool flag = false;
            if (!Main.inputText.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftControl) && !Main.inputText.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.RightControl))
            {
                if (Main.inputText.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftShift) || Main.inputText.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.RightShift))
                {
                    if (Main.inputText.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Delete) && !Main.oldInputText.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Delete))
                    {
                        Thread thread = new Thread(() =>
                        {
                            if (oldString.Length > 0)
                            {
                                Clipboard.SetText(oldString);
                            }
                        });
                        thread.SetApartmentState(ApartmentState.STA);
                        thread.Start();
                        while (thread.IsAlive)
                        {
                        }
                        str = "";
                    }
                    if (Main.inputText.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Insert) && !Main.oldInputText.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Insert))
                    {
                        Thread thread1 = new Thread(() =>
                        {
                            string text = Clipboard.GetText();
                            for (int i = 0; i < text.Length; i++)
                            {
                                if (text[i] < ' ' || text[i] == '\u007F')
                                {
                                    int num = i;
                                    i = num - 1;
                                    text = text.Replace(string.Concat(text[num]), "");
                                }
                            }
                            str1 = string.Concat(str1, text);
                        });
                        thread1.SetApartmentState(ApartmentState.STA);
                        thread1.Start();
                        while (thread1.IsAlive)
                        {
                        }
                    }
                }
                for (int i1 = 0; i1 < Main.keyCount; i1++)
                {
                    int num1 = Main.keyInt[i1];
                    string str2 = Main.keyString[i1];
                    if (num1 == 13)
                    {
                        Main.inputTextEnter = true;
                    }
                    else if (num1 == 27)
                    {
                        Main.inputTextEscape = true;
                    }
                    else if (num1 >= 32 && num1 != 127)
                    {
                        str1 = string.Concat(str1, str2);
                    }
                }
            }
            else if (Main.inputText.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Z) && !Main.oldInputText.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Z))
            {
                str = "";
            }
            else if (Main.inputText.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.X) && !Main.oldInputText.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.X))
            {
                Thread thread2 = new Thread(() =>
                {
                    if (oldString.Length > 0)
                    {
                        Clipboard.SetText(oldString);
                    }
                });
                thread2.SetApartmentState(ApartmentState.STA);
                thread2.Start();
                while (thread2.IsAlive)
                {
                }
                str = "";
            }
            else if (Main.inputText.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.C) && !Main.oldInputText.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.C) || Main.inputText.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Insert) && !Main.oldInputText.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Insert))
            {
                Thread thread3 = new Thread(() =>
                {
                    if (oldString.Length > 0)
                    {
                        Clipboard.SetText(oldString);
                    }
                });
                thread3.SetApartmentState(ApartmentState.STA);
                thread3.Start();
                while (thread3.IsAlive)
                {
                }
            }
            else if (Main.inputText.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.V) && !Main.oldInputText.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.V))
            {
                Thread thread4 = new Thread(() =>
                {
                    string text = Clipboard.GetText();
                    for (int i = 0; i < text.Length; i++)
                    {
                        if (text[i] < ' ' || text[i] == '\u007F')
                        {
                            int num = i;
                            i = num - 1;
                            text = text.Replace(string.Concat(text[num]), "");
                        }
                    }
                    str1 = string.Concat(str1, text);
                });
                thread4.SetApartmentState(ApartmentState.STA);
                thread4.Start();
                while (thread4.IsAlive)
                {
                }
            }
            Main.keyCount = 0;
            str = string.Concat(str, str1);
            Main.oldInputText = Main.inputText;
            Main.inputText = Keyboard.GetState();
            Microsoft.Xna.Framework.Input.Keys[] pressedKeys = Main.inputText.GetPressedKeys();
            Microsoft.Xna.Framework.Input.Keys[] keysArray = Main.oldInputText.GetPressedKeys();
            if (!Main.inputText.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Back) || !Main.oldInputText.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Back))
            {
                Main.backSpaceCount = 15;
            }
            else
            {
                if (Main.backSpaceCount == 0)
                {
                    Main.backSpaceCount = 7;
                    flag = true;
                }
                Main.backSpaceCount = Main.backSpaceCount - 1;
            }
            for (int j = 0; j < (int)pressedKeys.Length; j++)
            {
                bool flag1 = true;
                for (int k = 0; k < (int)keysArray.Length; k++)
                {
                    if (pressedKeys[j] == keysArray[k])
                    {
                        flag1 = false;
                    }
                }
                if (string.Concat(pressedKeys[j]) == "Back" && (flag1 || flag) && str.Length > 0)
                {
                    str = str.Substring(0, str.Length - 1);
                }
            }
            return str;
        }

        public static float NPCAddHeight(int i)
        {
            float num = 0f;
            if (Main.npc[i].type == 125)
            {
                num = 30f;
            }
            else
            {
                if (Main.npc[i].type == 205)
                {
                    num = 8f;
                }
                else
                {
                    if (Main.npc[i].type == 182)
                    {
                        num = 24f;
                    }
                    else
                    {
                        if (Main.npc[i].type == 178)
                        {
                            num = 2f;
                        }
                        else
                        {
                            if (Main.npc[i].type == 126)
                            {
                                num = 30f;
                            }
                            else
                            {
                                if (Main.npc[i].type == 6 || Main.npc[i].type == 173)
                                {
                                    num = 26f;
                                }
                                else
                                {
                                    if (Main.npc[i].type == 94)
                                    {
                                        num = 14f;
                                    }
                                    else
                                    {
                                        if (Main.npc[i].type == 7 || Main.npc[i].type == 8 || Main.npc[i].type == 9)
                                        {
                                            num = 13f;
                                        }
                                        else
                                        {
                                            if (Main.npc[i].type == 98 || Main.npc[i].type == 99 || Main.npc[i].type == 100)
                                            {
                                                num = 13f;
                                            }
                                            else
                                            {
                                                if (Main.npc[i].type == 95 || Main.npc[i].type == 96 || Main.npc[i].type == 97)
                                                {
                                                    num = 13f;
                                                }
                                                else
                                                {
                                                    if (Main.npc[i].type == 10 || Main.npc[i].type == 11 || Main.npc[i].type == 12)
                                                    {
                                                        num = 8f;
                                                    }
                                                    else
                                                    {
                                                        if (Main.npc[i].type == 13 || Main.npc[i].type == 14 || Main.npc[i].type == 15)
                                                        {
                                                            num = 26f;
                                                        }
                                                        else
                                                        {
                                                            if (Main.npc[i].type == 175)
                                                            {
                                                                num = 4f;
                                                            }
                                                            else
                                                            {
                                                                if (Main.npc[i].type == 48)
                                                                {
                                                                    num = 32f;
                                                                }
                                                                else
                                                                {
                                                                    if (Main.npc[i].type == 49 || Main.npc[i].type == 51)
                                                                    {
                                                                        num = 4f;
                                                                    }
                                                                    else
                                                                    {
                                                                        if (Main.npc[i].type == 60)
                                                                        {
                                                                            num = 10f;
                                                                        }
                                                                        else
                                                                        {
                                                                            if (Main.npc[i].type == 62 || Main.npc[i].type == 66 || Main.npc[i].type == 156)
                                                                            {
                                                                                num = 14f;
                                                                            }
                                                                            else
                                                                            {
                                                                                if (Main.npc[i].type == 63 || Main.npc[i].type == 64 || Main.npc[i].type == 103)
                                                                                {
                                                                                    num = 4f;
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (Main.npc[i].type == 65)
                                                                                    {
                                                                                        num = 14f;
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (Main.npc[i].type == 69)
                                                                                        {
                                                                                            num = 4f;
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if (Main.npc[i].type == 70)
                                                                                            {
                                                                                                num = -4f;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                if (Main.npc[i].type == 72)
                                                                                                {
                                                                                                    num = -2f;
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    if (Main.npc[i].type == 83 || Main.npc[i].type == 84)
                                                                                                    {
                                                                                                        num = 20f;
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        if (Main.npc[i].type == 150 || Main.npc[i].type == 151 || Main.npc[i].type == 158)
                                                                                                        {
                                                                                                            num = 10f;
                                                                                                        }
                                                                                                        else
                                                                                                        {
                                                                                                            if (Main.npc[i].type == 152)
                                                                                                            {
                                                                                                                num = 6f;
                                                                                                            }
                                                                                                            else
                                                                                                            {
                                                                                                                if (Main.npc[i].type == 153 || Main.npc[i].type == 154)
                                                                                                                {
                                                                                                                    num = 4f;
                                                                                                                }
                                                                                                                else
                                                                                                                {
                                                                                                                    if (Main.npc[i].type == 165 || Main.npc[i].type == 237 || Main.npc[i].type == 238 || Main.npc[i].type == 240)
                                                                                                                    {
                                                                                                                        num = 10f;
                                                                                                                    }
                                                                                                                    else
                                                                                                                    {
                                                                                                                        if (Main.npc[i].type == 39 || Main.npc[i].type == 40 || Main.npc[i].type == 41)
                                                                                                                        {
                                                                                                                            num = 26f;
                                                                                                                        }
                                                                                                                        else
                                                                                                                        {
                                                                                                                            if (Main.npc[i].type >= 87 && Main.npc[i].type <= 92)
                                                                                                                            {
                                                                                                                                num = 56f;
                                                                                                                            }
                                                                                                                            else
                                                                                                                            {
                                                                                                                                if (Main.npc[i].type >= 134 && Main.npc[i].type <= 136)
                                                                                                                                {
                                                                                                                                    num = 30f;
                                                                                                                                }
                                                                                                                                else
                                                                                                                                {
                                                                                                                                    if (Main.npc[i].type == 169)
                                                                                                                                    {
                                                                                                                                        num = 8f;
                                                                                                                                    }
                                                                                                                                    else
                                                                                                                                    {
                                                                                                                                        if (Main.npc[i].type == 174)
                                                                                                                                        {
                                                                                                                                            num = 6f;
                                                                                                                                        }
                                                                                                                                    }
                                                                                                                                }
                                                                                                                            }
                                                                                                                        }
                                                                                                                    }
                                                                                                                }
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return num * Main.npc[i].scale;
        }

        private static Color buffColor(Color newColor, float R, float G, float B, float A)
        {
            newColor.R = (byte)((float)newColor.R * R);
            newColor.G = (byte)((float)newColor.G * G);
            newColor.B = (byte)((float)newColor.B * B);
            newColor.A = (byte)((float)newColor.A * A);
            return newColor;
        }

        private static void HelpText()
        {
            bool flag = false;
            if (Main.player[Main.myPlayer].statLifeMax > 100)
            {
                flag = true;
            }
            bool flag2 = false;
            if (Main.player[Main.myPlayer].statManaMax > 0)
            {
                flag2 = true;
            }
            bool flag3 = true;
            bool flag4 = false;
            bool flag5 = false;
            bool flag6 = false;
            bool flag7 = false;
            bool flag8 = false;
            bool flag9 = false;
            for (int i = 0; i < 58; i++)
            {
                if (Main.player[Main.myPlayer].inventory[i].pick > 0 && Main.player[Main.myPlayer].inventory[i].name != "Copper Pickaxe")
                {
                    flag3 = false;
                }
                if (Main.player[Main.myPlayer].inventory[i].axe > 0 && Main.player[Main.myPlayer].inventory[i].name != "Copper Axe")
                {
                    flag3 = false;
                }
                if (Main.player[Main.myPlayer].inventory[i].hammer > 0)
                {
                    flag3 = false;
                }
                if (Main.player[Main.myPlayer].inventory[i].type == 11 || Main.player[Main.myPlayer].inventory[i].type == 12 || Main.player[Main.myPlayer].inventory[i].type == 13 || Main.player[Main.myPlayer].inventory[i].type == 14)
                {
                    flag4 = true;
                }
                if (Main.player[Main.myPlayer].inventory[i].type == 19 || Main.player[Main.myPlayer].inventory[i].type == 20 || Main.player[Main.myPlayer].inventory[i].type == 21 || Main.player[Main.myPlayer].inventory[i].type == 22)
                {
                    flag5 = true;
                }
                if (Main.player[Main.myPlayer].inventory[i].type == 75)
                {
                    flag6 = true;
                }
                if (Main.player[Main.myPlayer].inventory[i].type == 38)
                {
                    flag7 = true;
                }
                if (Main.player[Main.myPlayer].inventory[i].type == 68 || Main.player[Main.myPlayer].inventory[i].type == 70)
                {
                    flag8 = true;
                }
                if (Main.player[Main.myPlayer].inventory[i].type == 84)
                {
                    flag9 = true;
                }
            }
            bool flag10 = false;
            bool flag11 = false;
            bool flag12 = false;
            bool flag13 = false;
            bool flag14 = false;
            bool flag15 = false;
            bool flag16 = false;
            bool flag17 = false;
            bool flag18 = false;
            for (int j = 0; j < 200; j++)
            {
                if (Main.npc[j].active)
                {
                    if (Main.npc[j].type == 17)
                    {
                        flag10 = true;
                    }
                    if (Main.npc[j].type == 18)
                    {
                        flag11 = true;
                    }
                    if (Main.npc[j].type == 19)
                    {
                        flag13 = true;
                    }
                    if (Main.npc[j].type == 20)
                    {
                        flag12 = true;
                    }
                    if (Main.npc[j].type == 54)
                    {
                        flag18 = true;
                    }
                    if (Main.npc[j].type == 124)
                    {
                        flag15 = true;
                    }
                    if (Main.npc[j].type == 107)
                    {
                        flag14 = true;
                    }
                    if (Main.npc[j].type == 108)
                    {
                        flag16 = true;
                    }
                    if (Main.npc[j].type == 38)
                    {
                        flag17 = true;
                    }
                }
            }
            while (true)
            {
                Main.helpText++;
                if (flag3)
                {
                    if (Main.helpText == 1)
                    {
                        break;
                    }
                    if (Main.helpText == 2)
                    {
                        goto Block_31;
                    }
                    if (Main.helpText == 3)
                    {
                        goto Block_32;
                    }
                    if (Main.helpText == 4)
                    {
                        goto Block_33;
                    }
                    if (Main.helpText == 5)
                    {
                        goto Block_34;
                    }
                    if (Main.helpText == 6)
                    {
                        goto Block_35;
                    }
                }
                if (flag3 && !flag4 && !flag5 && Main.helpText == 11)
                {
                    goto Block_39;
                }
                if (flag3 && flag4 && !flag5)
                {
                    if (Main.helpText == 21)
                    {
                        goto Block_43;
                    }
                    if (Main.helpText == 22)
                    {
                        goto Block_44;
                    }
                }
                if (flag3 && flag5)
                {
                    if (Main.helpText == 31)
                    {
                        goto Block_47;
                    }
                    if (Main.helpText == 32)
                    {
                        goto Block_48;
                    }
                }
                if (!flag && Main.helpText == 41)
                {
                    goto Block_50;
                }
                if (!flag2 && Main.helpText == 42)
                {
                    goto Block_52;
                }
                if (!flag2 && !flag6 && Main.helpText == 43)
                {
                    goto Block_55;
                }
                if (!flag10 && !flag11)
                {
                    if (Main.helpText == 51)
                    {
                        goto Block_58;
                    }
                    if (Main.helpText == 52)
                    {
                        goto Block_59;
                    }
                    if (Main.helpText == 53)
                    {
                        goto Block_60;
                    }
                    if (Main.helpText == 54)
                    {
                        goto Block_61;
                    }
                }
                if (!flag10 && Main.helpText == 61)
                {
                    goto Block_63;
                }
                if (!flag11 && Main.helpText == 62)
                {
                    goto Block_65;
                }
                if (!flag13 && Main.helpText == 63)
                {
                    goto Block_67;
                }
                if (!flag12 && Main.helpText == 64)
                {
                    goto Block_69;
                }
                if (!flag15 && Main.helpText == 65 && NPC.downedBoss3)
                {
                    goto Block_72;
                }
                if (!flag18 && Main.helpText == 66 && NPC.downedBoss3)
                {
                    goto Block_75;
                }
                if (!flag14 && Main.helpText == 67)
                {
                    goto Block_77;
                }
                if (!flag17 && NPC.downedBoss2 && Main.helpText == 68)
                {
                    goto Block_80;
                }
                if (!flag16 && Main.hardMode && Main.helpText == 69)
                {
                    goto Block_83;
                }
                if (flag7 && Main.helpText == 71)
                {
                    goto Block_85;
                }
                if (flag8 && Main.helpText == 72)
                {
                    goto Block_87;
                }
                if ((flag7 || flag8) && Main.helpText == 80)
                {
                    goto Block_89;
                }
                if (!flag9 && Main.helpText == 201 && !Main.hardMode && !NPC.downedBoss3 && !NPC.downedBoss2)
                {
                    goto Block_94;
                }
                if (Main.helpText == 1000 && !NPC.downedBoss1 && !NPC.downedBoss2)
                {
                    goto Block_97;
                }
                if (Main.helpText == 1001 && !NPC.downedBoss1 && !NPC.downedBoss2)
                {
                    goto Block_100;
                }
                if (Main.helpText == 1002 && !NPC.downedBoss2)
                {
                    goto Block_102;
                }
                if (Main.helpText == 1050 && !NPC.downedBoss1 && Main.player[Main.myPlayer].statLifeMax < 200)
                {
                    goto Block_106;
                }
                if (Main.helpText == 1051 && !NPC.downedBoss1 && Main.player[Main.myPlayer].statDefense <= 10)
                {
                    goto Block_109;
                }
                if (Main.helpText == 1052 && !NPC.downedBoss1 && Main.player[Main.myPlayer].statLifeMax >= 200 && Main.player[Main.myPlayer].statDefense > 10)
                {
                    goto Block_113;
                }
                if (Main.helpText == 1053 && NPC.downedBoss1 && !NPC.downedBoss2 && Main.player[Main.myPlayer].statLifeMax < 300)
                {
                    goto Block_117;
                }
                if (Main.helpText == 1054 && NPC.downedBoss1 && !NPC.downedBoss2 && Main.player[Main.myPlayer].statLifeMax >= 300)
                {
                    goto Block_121;
                }
                if (Main.helpText == 1055 && NPC.downedBoss1 && !NPC.downedBoss2 && Main.player[Main.myPlayer].statLifeMax >= 300)
                {
                    goto Block_125;
                }
                if (Main.helpText == 1056 && NPC.downedBoss1 && NPC.downedBoss2 && !NPC.downedBoss3)
                {
                    goto Block_129;
                }
                if (Main.helpText == 1057 && NPC.downedBoss1 && NPC.downedBoss2 && NPC.downedBoss3 && !Main.hardMode && Main.player[Main.myPlayer].statLifeMax < 400)
                {
                    goto Block_135;
                }
                if (Main.helpText == 1058 && NPC.downedBoss1 && NPC.downedBoss2 && NPC.downedBoss3 && !Main.hardMode && Main.player[Main.myPlayer].statLifeMax >= 400)
                {
                    goto Block_141;
                }
                if (Main.helpText == 1059 && NPC.downedBoss1 && NPC.downedBoss2 && NPC.downedBoss3 && !Main.hardMode && Main.player[Main.myPlayer].statLifeMax >= 400)
                {
                    goto Block_147;
                }
                if (Main.helpText == 1060 && NPC.downedBoss1 && NPC.downedBoss2 && NPC.downedBoss3 && !Main.hardMode && Main.player[Main.myPlayer].statLifeMax >= 400)
                {
                    goto Block_153;
                }
                if (Main.helpText == 1061 && Main.hardMode)
                {
                    goto Block_155;
                }
                if (Main.helpText == 1062 && Main.hardMode)
                {
                    goto Block_157;
                }
                if (Main.helpText > 1100)
                {
                    Main.helpText = 0;
                }
            }
            Main.npcChatText = Lang.dialog(177, false);
            return;
        Block_31:
            Main.npcChatText = Lang.dialog(178, false);
            return;
        Block_32:
            Main.npcChatText = Lang.dialog(179, false);
            return;
        Block_33:
            Main.npcChatText = Lang.dialog(180, false);
            return;
        Block_34:
            Main.npcChatText = Lang.dialog(181, false);
            return;
        Block_35:
            Main.npcChatText = Lang.dialog(182, false);
            return;
        Block_39:
            Main.npcChatText = Lang.dialog(183, false);
            return;
        Block_43:
            Main.npcChatText = Lang.dialog(184, false);
            return;
        Block_44:
            Main.npcChatText = Lang.dialog(185, false);
            return;
        Block_47:
            Main.npcChatText = Lang.dialog(186, false);
            return;
        Block_48:
            Main.npcChatText = Lang.dialog(187, false);
            return;
        Block_50:
            Main.npcChatText = Lang.dialog(188, false);
            return;
        Block_52:
            Main.npcChatText = Lang.dialog(189, false);
            return;
        Block_55:
            Main.npcChatText = Lang.dialog(190, false);
            return;
        Block_58:
            Main.npcChatText = Lang.dialog(191, false);
            return;
        Block_59:
            Main.npcChatText = Lang.dialog(192, false);
            return;
        Block_60:
            Main.npcChatText = Lang.dialog(193, false);
            return;
        Block_61:
            Main.npcChatText = Lang.dialog(194, false);
            return;
        Block_63:
            Main.npcChatText = Lang.dialog(195, false);
            return;
        Block_65:
            Main.npcChatText = Lang.dialog(196, false);
            return;
        Block_67:
            Main.npcChatText = Lang.dialog(197, false);
            return;
        Block_69:
            Main.npcChatText = Lang.dialog(198, false);
            return;
        Block_72:
            Main.npcChatText = Lang.dialog(199, false);
            return;
        Block_75:
            Main.npcChatText = Lang.dialog(200, false);
            return;
        Block_77:
            Main.npcChatText = Lang.dialog(201, false);
            return;
        Block_80:
            Main.npcChatText = Lang.dialog(202, false);
            return;
        Block_83:
            Main.npcChatText = Lang.dialog(203, false);
            return;
        Block_85:
            Main.npcChatText = Lang.dialog(204, false);
            return;
        Block_87:
            Main.npcChatText = Lang.dialog(205, false);
            return;
        Block_89:
            Main.npcChatText = Lang.dialog(206, false);
            return;
        Block_94:
            Main.npcChatText = Lang.dialog(207, false);
            return;
        Block_97:
            Main.npcChatText = Lang.dialog(208, false);
            return;
        Block_100:
            Main.npcChatText = Lang.dialog(209, false);
            return;
        Block_102:
            if (WorldGen.crimson)
            {
                Main.npcChatText = Lang.dialog(331, false);
                return;
            }
            Main.npcChatText = Lang.dialog(210, false);
            return;
        Block_106:
            Main.npcChatText = Lang.dialog(211, false);
            return;
        Block_109:
            Main.npcChatText = Lang.dialog(212, false);
            return;
        Block_113:
            Main.npcChatText = Lang.dialog(213, false);
            return;
        Block_117:
            Main.npcChatText = Lang.dialog(214, false);
            return;
        Block_121:
            Main.npcChatText = Lang.dialog(215, false);
            return;
        Block_125:
            Main.npcChatText = Lang.dialog(216, false);
            return;
        Block_129:
            Main.npcChatText = Lang.dialog(217, false);
            return;
        Block_135:
            Main.npcChatText = Lang.dialog(218, false);
            return;
        Block_141:
            Main.npcChatText = Lang.dialog(219, false);
            return;
        Block_147:
            Main.npcChatText = Lang.dialog(220, false);
            return;
        Block_153:
            Main.npcChatText = Lang.dialog(221, false);
            return;
        Block_155:
            Main.npcChatText = Lang.dialog(222, false);
            return;
        Block_157:
            Main.npcChatText = Lang.dialog(223, false);
        }
      
        private static bool AccCheck(Item newItem, int slot)
        {
            if (Main.player[Main.myPlayer].armor[slot].IsTheSameAs(newItem))
            {
                return false;
            }
            if (Main.player[Main.myPlayer].armor[slot].wingSlot > 0 && newItem.wingSlot > 0)
            {
                return false;
            }
            for (int i = 0; i < Main.player[Main.myPlayer].armor.Length; i++)
            {
                if (slot < 8 && i < 8)
                {
                    if (newItem.wingSlot > 0 && Main.player[Main.myPlayer].armor[i].wingSlot > 0)
                    {
                        return true;
                    }
                }
                else
                {
                    if (slot >= 8 && i >= 8 && newItem.wingSlot > 0 && Main.player[Main.myPlayer].armor[i].wingSlot > 0)
                    {
                        return true;
                    }
                }
                if (newItem.IsTheSameAs(Main.player[Main.myPlayer].armor[i]))
                {
                    return true;
                }
            }
            return false;
        }
        public static Item dyeSwap(Item newItem)
        {
            if (newItem.dye <= 0)
            {
                return newItem;
            }
            for (int i = 0; i < 8; i++)
            {
                if (Main.player[Main.myPlayer].dye[i].type == 0)
                {
                    Main.dyeSlotCount = i;
                    break;
                }
            }
            if (Main.dyeSlotCount >= 8)
            {
                Main.dyeSlotCount = 0;
            }
            if (Main.dyeSlotCount < 0)
            {
                Main.dyeSlotCount = 7;
            }
            Item result = Main.player[Main.myPlayer].dye[Main.dyeSlotCount].Clone();
            Main.player[Main.myPlayer].dye[Main.dyeSlotCount] = newItem.Clone();
            Main.dyeSlotCount++;
            if (Main.dyeSlotCount >= 8)
            {
                Main.accSlotCount = 0;
            }
            Main.PlaySound(SoundTypeID.GRAB, -1, -1, 1);
            Recipe.FindRecipes();
            return result;
        }
        public static Item armorSwap(Item newItem)
        {
            for (int i = 0; i < Main.player[Main.myPlayer].armor.Length; i++)
            {
                if (newItem.IsTheSameAs(Main.player[Main.myPlayer].armor[i]))
                {
                    Main.accSlotCount = i;
                }
            }
            if (newItem.headSlot == -1 && newItem.bodySlot == -1 && newItem.legSlot == -1 && !newItem.accessory)
            {
                return newItem;
            }
            Item result = newItem;
            if (newItem.headSlot != -1)
            {
                result = Main.player[Main.myPlayer].armor[0].Clone();
                Main.player[Main.myPlayer].armor[0] = newItem.Clone();
            }
            else
            {
                if (newItem.bodySlot != -1)
                {
                    result = Main.player[Main.myPlayer].armor[1].Clone();
                    Main.player[Main.myPlayer].armor[1] = newItem.Clone();
                }
                else
                {
                    if (newItem.legSlot != -1)
                    {
                        result = Main.player[Main.myPlayer].armor[2].Clone();
                        Main.player[Main.myPlayer].armor[2] = newItem.Clone();
                    }
                    else
                    {
                        if (newItem.accessory)
                        {
                            for (int j = 3; j < 8; j++)
                            {
                                if (Main.player[Main.myPlayer].armor[j].type == 0)
                                {
                                    Main.accSlotCount = j - 3;
                                    break;
                                }
                            }
                            for (int k = 0; k < Main.player[Main.myPlayer].armor.Length; k++)
                            {
                                if (newItem.IsTheSameAs(Main.player[Main.myPlayer].armor[k]))
                                {
                                    Main.accSlotCount = k - 3;
                                }
                                if (k < 8 && newItem.wingSlot > 0 && Main.player[Main.myPlayer].armor[k].wingSlot > 0)
                                {
                                    Main.accSlotCount = k - 3;
                                }
                            }
                            if (Main.accSlotCount >= 5)
                            {
                                Main.accSlotCount = 0;
                            }
                            if (Main.accSlotCount < 0)
                            {
                                Main.accSlotCount = 4;
                            }
                            result = Main.player[Main.myPlayer].armor[3 + Main.accSlotCount].Clone();
                            Main.player[Main.myPlayer].armor[3 + Main.accSlotCount] = newItem.Clone();
                            Main.accSlotCount++;
                            if (Main.accSlotCount >= 5)
                            {
                                Main.accSlotCount = 0;
                            }
                        }
                    }
                }
            }
            Main.PlaySound(SoundTypeID.GRAB, -1, -1, 1);
            Recipe.FindRecipes();
            return result;
        }
        public static void MoveCoins(Item[] pInv, Item[] cInv)
        {
            int[] array = new int[4];
            List<int> list = new List<int>();
            List<int> list2 = new List<int>();
            bool flag = false;
            int[] array2 = new int[Chest.maxItems];
            for (int i = 0; i < cInv.Length; i++)
            {
                array2[i] = -1;
                if (cInv[i].stack < 1 || cInv[i].type < 1)
                {
                    list2.Add(i);
                    cInv[i] = new Item();
                }
                if (cInv[i] != null && cInv[i].stack > 0)
                {
                    int num = 0;
                    if (cInv[i].type == 71)
                    {
                        num = 1;
                    }
                    if (cInv[i].type == 72)
                    {
                        num = 2;
                    }
                    if (cInv[i].type == 73)
                    {
                        num = 3;
                    }
                    if (cInv[i].type == 74)
                    {
                        num = 4;
                    }
                    array2[i] = num - 1;
                    if (num > 0)
                    {
                        array[num - 1] += cInv[i].stack;
                        list2.Add(i);
                        cInv[i] = new Item();
                        flag = true;
                    }
                }
            }
            if (!flag)
            {
                return;
            }
            Main.PlaySound(SoundTypeID.GRAB, -1, -1, 1);
            for (int j = 0; j < pInv.Length; j++)
            {
                if (j != 58 && pInv[j] != null && pInv[j].stack > 0)
                {
                    int num2 = 0;
                    if (pInv[j].type == 71)
                    {
                        num2 = 1;
                    }
                    if (pInv[j].type == 72)
                    {
                        num2 = 2;
                    }
                    if (pInv[j].type == 73)
                    {
                        num2 = 3;
                    }
                    if (pInv[j].type == 74)
                    {
                        num2 = 4;
                    }
                    if (num2 > 0)
                    {
                        array[num2 - 1] += pInv[j].stack;
                        list.Add(j);
                        pInv[j] = new Item();
                    }
                }
            }
            for (int k = 0; k < 3; k++)
            {
                while (array[k] >= 100)
                {
                    array[k] -= 100;
                    array[k + 1]++;
                }
            }
            for (int l = 0; l < Chest.maxItems; l++)
            {
                if (array2[l] >= 0 && cInv[l].type == 0)
                {
                    int num3 = l;
                    int num4 = array2[l];
                    if (array[num4] > 0)
                    {
                        cInv[num3].SetDefaults(71 + num4, false);
                        cInv[num3].stack = array[num4];
                        if (cInv[num3].stack > cInv[num3].maxStack)
                        {
                            cInv[num3].stack = cInv[num3].maxStack;
                        }
                        array[num4] -= cInv[num3].stack;
                        array2[l] = -1;
                    }
                    if (Main.netMode == 1 && Main.player[Main.myPlayer].chest > -1)
                    {
                        NetMessage.SendData(32, -1, -1, "", Main.player[Main.myPlayer].chest, (float)num3, 0f, 0f, 0);
                    }
                    list2.Remove(num3);
                }
            }
            for (int m = 0; m < Chest.maxItems; m++)
            {
                if (array2[m] >= 0 && cInv[m].type == 0)
                {
                    int num5 = m;
                    for (int n = 3; n >= 0; n--)
                    {
                        if (array[n] > 0)
                        {
                            cInv[num5].SetDefaults(71 + n, false);
                            cInv[num5].stack = array[n];
                            if (cInv[num5].stack > cInv[num5].maxStack)
                            {
                                cInv[num5].stack = cInv[num5].maxStack;
                            }
                            array[n] -= cInv[num5].stack;
                            array2[m] = -1;
                            break;
                        }
                    }
                    if (Main.netMode == 1 && Main.player[Main.myPlayer].chest > -1)
                    {
                        NetMessage.SendData(32, -1, -1, "", Main.player[Main.myPlayer].chest, (float)num5, 0f, 0f, 0);
                    }
                    list2.Remove(num5);
                }
            }
            while (list2.Count > 0)
            {
                int num6 = list2[0];
                for (int num7 = 3; num7 >= 0; num7--)
                {
                    if (array[num7] > 0)
                    {
                        cInv[num6].SetDefaults(71 + num7, false);
                        cInv[num6].stack = array[num7];
                        if (cInv[num6].stack > cInv[num6].maxStack)
                        {
                            cInv[num6].stack = cInv[num6].maxStack;
                        }
                        array[num7] -= cInv[num6].stack;
                        break;
                    }
                }
                if (Main.netMode == 1 && Main.player[Main.myPlayer].chest > -1)
                {
                    NetMessage.SendData(32, -1, -1, "", Main.player[Main.myPlayer].chest, (float)list2[0], 0f, 0f, 0);
                }
                list2.RemoveAt(0);
            }
            while (list.Count > 0)
            {
                int num8 = list[0];
                for (int num9 = 3; num9 >= 0; num9--)
                {
                    if (array[num9] > 0)
                    {
                        pInv[num8].SetDefaults(71 + num9, false);
                        pInv[num8].stack = array[num9];
                        if (pInv[num8].stack > pInv[num8].maxStack)
                        {
                            pInv[num8].stack = pInv[num8].maxStack;
                        }
                        array[num9] -= pInv[num8].stack;
                    }
                }
                list.RemoveAt(0);
            }
        }

        
        public static void NewText(string newText, byte R = 255, byte G = 255, byte B = 255, bool force = false)
        {
            int num = 80;
            if (!force && newText.Length > num)
            {
                string text = newText;
                while (text.Length > num)
                {
                    int num2 = num;
                    int num3 = num2;
                    while (text.Substring(num3, 1) != " ")
                    {
                        num3--;
                        if (num3 < 1)
                        {
                            break;
                        }
                    }
                    if (num3 == 0)
                    {
                        while (text.Substring(num2, 1) != " ")
                        {
                            num2++;
                            if (num2 >= text.Length - 1)
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        num2 = num3;
                    }
                    if (num2 >= text.Length - 1)
                    {
                        num2 = text.Length;
                    }
                    string newText2 = text.Substring(0, num2);
                    Main.NewText(newText2, R, G, B, true);
                    text = text.Substring(num2);
                    if (text.Length > 0)
                    {
                        while (text.Substring(0, 1) == " ")
                        {
                            text = text.Substring(1);
                        }
                    }
                }
                if (text.Length > 0)
                {
                    Main.NewText(text, R, G, B, true);
                }
                return;
            }
            for (int i = Main.numChatLines - 1; i > 0; i--)
            {
                Main.chatLine[i].text = Main.chatLine[i - 1].text;
                Main.chatLine[i].showTime = Main.chatLine[i - 1].showTime;
                Main.chatLine[i].color = Main.chatLine[i - 1].color;
            }
            if (R == 0 && G == 0 && B == 0)
            {
                Main.chatLine[0].color = Color.White;
            }
            else
            {
                Main.chatLine[0].color = new Color((int)R, (int)G, (int)B);
            }
            Main.chatLine[0].text = newText;
            Main.chatLine[0].showTime = Main.chatLength;
            Main.PlaySound(SoundTypeID.MENU_TICK, -1, -1, 1);
        }
       
        public static int DamageVar(float dmg)
        {
            float num = dmg * (1f + (float)Main.rand.Next(-15, 16) * 0.01f);
            return (int)Math.Round((double)num);
        }
        public static double CalculateDamage(int Damage, int Defense)
        {
            double num = (double)Damage - (double)Defense * 0.5;
            if (num < 1.0)
            {
                num = 1.0;
            }
            return num;
        }
       
    }
}
