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
        public static void OpenHairWindow()
        {
            Main.hBar = -1f;
            Main.lBar = -1f;
            Main.sBar = -1f;
            Main.playerInventory = false;
            Main.npcChatText = "";
            Main.oldHairStyle = Main.player[Main.myPlayer].hair;
            Main.oldHairColor = Main.player[Main.myPlayer].hairColor;
            Main.hairWindow = true;
            Main.PlaySound(SoundTypeID.MENU_OPEN, -1, -1, 1);
        }
        public static void CancelHairWindow()
        {
            if (!Main.hairWindow)
            {
                return;
            }
            Main.player[Main.myPlayer].hair = Main.oldHairStyle;
            Main.player[Main.myPlayer].hairColor = Main.oldHairColor;
            Main.hairWindow = false;
            if (Main.player[Main.myPlayer].talkNPC > -1 && Main.npc[Main.player[Main.myPlayer].talkNPC].type == 353)
            {
                Main.player[Main.myPlayer].talkNPC = -1;
            }
            Main.PlaySound(SoundTypeID.MENU_CLOSE, -1, -1, 1);
        }
        public static void BuyHairWindow()
        {
            Main.PlaySound(SoundTypeID.COINS, -1, -1, 1);
            Main.hairWindow = false;
            Main.player[Main.myPlayer].talkNPC = -1;
            NetMessage.SendData(4, -1, -1, Main.player[Main.myPlayer].name, Main.myPlayer, 0f, 0f, 0f, 0);
        }

        public static void OpenClothesWindow()
        {
            Main.hBar = -1f;
            Main.lBar = -1f;
            Main.sBar = -1f;
            Main.playerInventory = false;
            Main.npcChatText = "";
            Main.clothesWindow = true;
            Main.PlaySound(SoundTypeID.MENU_OPEN, -1, -1, 1);
            Main.selClothes = 0;
            Main.oldClothesColor[0] = Main.player[Main.myPlayer].shirtColor;
            Main.oldClothesColor[1] = Main.player[Main.myPlayer].underShirtColor;
            Main.oldClothesColor[2] = Main.player[Main.myPlayer].pantsColor;
            Main.oldClothesColor[3] = Main.player[Main.myPlayer].shoeColor;
        }
        public static void CancelClothesWindow()
        {
            if (!Main.clothesWindow)
            {
                return;
            }
            Main.clothesWindow = false;
            Main.PlaySound(SoundTypeID.MENU_CLOSE, -1, -1, 1);
            Main.player[Main.myPlayer].shirtColor = Main.oldClothesColor[0];
            Main.player[Main.myPlayer].underShirtColor = Main.oldClothesColor[1];
            Main.player[Main.myPlayer].pantsColor = Main.oldClothesColor[2];
            Main.player[Main.myPlayer].shoeColor = Main.oldClothesColor[3];
        }
        public static void SaveClothesWindow()
        {
            Main.PlaySound(SoundTypeID.GRAB, -1, -1, 1);
            Main.clothesWindow = false;
            NetMessage.SendData(4, -1, -1, Main.player[Main.myPlayer].name, Main.myPlayer, 0f, 0f, 0f, 0);
        }

        public static Color hslToRgb(float Hue, float Saturation, float Luminosity)
        {
            byte r;
            byte g;
            byte b;
            if (Saturation == 0f)
            {
                r = (byte)Math.Round((double)Luminosity * 255.0);
                g = (byte)Math.Round((double)Luminosity * 255.0);
                b = (byte)Math.Round((double)Luminosity * 255.0);
            }
            else
            {
                double num = (double)Hue;
                double num2;
                if ((double)Luminosity < 0.5)
                {
                    num2 = (double)Luminosity * (1.0 + (double)Saturation);
                }
                else
                {
                    num2 = (double)(Luminosity + Saturation - Luminosity * Saturation);
                }
                double t = 2.0 * (double)Luminosity - num2;
                double num3 = num + 0.33333333333333331;
                double num4 = num;
                double num5 = num - 0.33333333333333331;
                num3 = Main.hue2rgb(num3, t, num2);
                num4 = Main.hue2rgb(num4, t, num2);
                num5 = Main.hue2rgb(num5, t, num2);
                r = (byte)Math.Round(num3 * 255.0);
                g = (byte)Math.Round(num4 * 255.0);
                b = (byte)Math.Round(num5 * 255.0);
            }
            return new Color((int)r, (int)g, (int)b);
        }
        public static double hue2rgb(double c, double t1, double t2)
        {
            if (c < 0.0)
            {
                c += 1.0;
            }
            if (c > 1.0)
            {
                c -= 1.0;
            }
            if (6.0 * c < 1.0)
            {
                return t1 + (t2 - t1) * 6.0 * c;
            }
            if (2.0 * c < 1.0)
            {
                return t2;
            }
            if (3.0 * c < 2.0)
            {
                return t1 + (t2 - t1) * (0.66666666666666663 - c) * 6.0;
            }
            return t1;
        }
        public static Vector3 rgbToHsl(Color newColor)
        {
            float num = (float)newColor.R;
            float num2 = (float)newColor.G;
            float num3 = (float)newColor.B;
            num /= 255f;
            num2 /= 255f;
            num3 /= 255f;
            float num4 = Math.Max(num, num2);
            num4 = Math.Max(num4, num3);
            float num5 = Math.Min(num, num2);
            num5 = Math.Min(num5, num3);
            float num6 = 0f;
            float num7 = (num4 + num5) / 2f;
            float y;
            if (num4 == num5)
            {
                y = (num6 = 0f);
            }
            else
            {
                float num8 = num4 - num5;
                y = (((double)num7 > 0.5) ? (num8 / (2f - num4 - num5)) : (num8 / (num4 + num5)));
                if (num4 == num)
                {
                    num6 = (num2 - num3) / num8 + (float)((num2 < num3) ? 6 : 0);
                }
                if (num4 == num2)
                {
                    num6 = (num3 - num) / num8 + 2f;
                }
                if (num4 == num3)
                {
                    num6 = (num - num2) / num8 + 4f;
                }
                num6 /= 6f;
            }
            return new Vector3(num6, y, num7);
        }

        public static void CursorColor()
        {
            Main.cursorAlpha += (float)Main.cursorColorDirection * 0.015f;
            if (Main.cursorAlpha >= 1f)
            {
                Main.cursorAlpha = 1f;
                Main.cursorColorDirection = -1;
            }
            if ((double)Main.cursorAlpha <= 0.6)
            {
                Main.cursorAlpha = 0.6f;
                Main.cursorColorDirection = 1;
            }
            float num = Main.cursorAlpha * 0.3f + 0.7f;
            byte r = (byte)((float)Main.mouseColor.R * Main.cursorAlpha);
            byte g = (byte)((float)Main.mouseColor.G * Main.cursorAlpha);
            byte b = (byte)((float)Main.mouseColor.B * Main.cursorAlpha);
            byte b2 = (byte)(255f * num);
            Main.cursorColor = new Color((int)r, (int)g, (int)b, (int)b2);
            Main.cursorScale = Main.cursorAlpha * 0.3f + 0.7f + 0.1f;
        }

        public static int GetTreeStyle(int X)
        {
            int num;
            if (X <= Main.treeX[0])
            {
                num = Main.treeStyle[0];
            }
            else
            {
                if (X <= Main.treeX[1])
                {
                    num = Main.treeStyle[1];
                }
                else
                {
                    if (X <= Main.treeX[2])
                    {
                        num = Main.treeStyle[2];
                    }
                    else
                    {
                        num = Main.treeStyle[3];
                    }
                }
            }
            if (num == 0)
            {
                return 0;
            }
            if (num == 5)
            {
                return 10;
            }
            return 5 + num;
        }

        protected void DrawChat()
        {
            if (Main.player[Main.myPlayer].talkNPC < 0 && Main.player[Main.myPlayer].sign == -1)
            {
                Main.npcChatText = "";
                return;
            }
            if (Main.netMode == 0 && Main.autoPause && Main.player[Main.myPlayer].talkNPC >= 0)
            {
                if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 105)
                {
                    Main.npc[Main.player[Main.myPlayer].talkNPC].Transform(107);
                }
                if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 106)
                {
                    Main.npc[Main.player[Main.myPlayer].talkNPC].Transform(108);
                }
                if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 123)
                {
                    Main.npc[Main.player[Main.myPlayer].talkNPC].Transform(124);
                }
                if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 354)
                {
                    Main.npc[Main.player[Main.myPlayer].talkNPC].Transform(353);
                }
            }
            Color color = new Color(200, 200, 200, 200);
            int num = (int)((Main.mouseTextColor * 2 + 255) / 3);
            Color textColor = new Color(num, num, num, num);
            int num2;
            string[] array = Utils.WordwrapString(Main.npcChatText, Main.fontMouseText, 470, 10, out num2);
            if (Main.editSign)
            {
                this.textBlinkerCount++;
                if (this.textBlinkerCount >= 20)
                {
                    if (this.textBlinkerState == 0)
                    {
                        this.textBlinkerState = 1;
                    }
                    else
                    {
                        this.textBlinkerState = 0;
                    }
                    this.textBlinkerCount = 0;
                }
                if (this.textBlinkerState == 1)
                {
                    string[] array2;
                    IntPtr intPtr;
                    (array2 = array)[(int)(intPtr = (IntPtr)num2)] = array2[(int)intPtr] + "|";
                }
            }
            num2++;
            Main.spriteBatch.Draw(Main.chatBackTexture, new Vector2((float)(Main.screenWidth / 2 - Main.chatBackTexture.Width / 2), 100f), new Rectangle?(new Rectangle(0, 0, Main.chatBackTexture.Width, (num2 + 1) * 30)), color, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
            Main.spriteBatch.Draw(Main.chatBackTexture, new Vector2((float)(Main.screenWidth / 2 - Main.chatBackTexture.Width / 2), (float)(100 + (num2 + 1) * 30)), new Rectangle?(new Rectangle(0, Main.chatBackTexture.Height - 30, Main.chatBackTexture.Width, 30)), color, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
            for (int i = 0; i < num2; i++)
            {
                Utils.DrawBorderStringFourWay(Main.spriteBatch, Main.fontMouseText, array[i], (float)(170 + (Main.screenWidth - 800) / 2), (float)(120 + i * 30), textColor, Color.Black, Vector2.Zero, 1f);
            }
            num = (int)Main.mouseTextColor;
            textColor = new Color(num, (int)((double)num / 1.1), num / 2, num);
            string text = "";
            string text2 = "";
            int num3 = Main.player[Main.myPlayer].statLifeMax - Main.player[Main.myPlayer].statLife;
            for (int j = 0; j < 22; j++)
            {
                int num4 = Main.player[Main.myPlayer].buffType[j];
                if (Main.debuff[num4] && Main.player[Main.myPlayer].buffTime[j] > 0 && num4 != 28 && num4 != 34 && num4 != 87 && num4 != 89 && num4 != 21 && num4 != 86)
                {
                    num3 += 1000;
                }
            }
            if (Main.player[Main.myPlayer].sign > -1)
            {
                if (Main.editSign)
                {
                    text = Lang.inter[47];
                }
                else
                {
                    text = Lang.inter[48];
                }
            }
            else
            {
                if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 20)
                {
                    text = Lang.inter[28];
                    text2 = Lang.inter[49];
                }
                else
                {
                    if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 353)
                    {
                        text = Lang.inter[28];
                        text2 = "Hair Style";
                    }
                    else
                    {
                        if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 368)
                        {
                            text = Lang.inter[28];
                        }
                        else
                        {
                            if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 17 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 19 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 38 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 54 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 107 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 108 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 124 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 142 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 160 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 178 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 207 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 208 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 209 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 227 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 228 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 229)
                            {
                                text = Lang.inter[28];
                                if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 107)
                                {
                                    text2 = Lang.inter[19];
                                }
                            }
                            else
                            {
                                if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 37)
                                {
                                    if (!Main.dayTime)
                                    {
                                        text = Lang.inter[50];
                                    }
                                }
                                else
                                {
                                    if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 22)
                                    {
                                        text = Lang.inter[51];
                                        text2 = Lang.inter[25];
                                    }
                                    else
                                    {
                                        if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 18)
                                        {
                                            string text3 = "";
                                            int num5 = 0;
                                            int num6 = 0;
                                            int num7 = 0;
                                            int num8 = 0;
                                            int num9 = num3;
                                            if (num9 > 0)
                                            {
                                                num9 = (int)((double)num9 * 0.75);
                                                if (num9 < 1)
                                                {
                                                    num9 = 1;
                                                }
                                            }
                                            if (num9 < 0)
                                            {
                                                num9 = 0;
                                            }
                                            num3 = num9;
                                            if (num9 >= 1000000)
                                            {
                                                num5 = num9 / 1000000;
                                                num9 -= num5 * 1000000;
                                            }
                                            if (num9 >= 10000)
                                            {
                                                num6 = num9 / 10000;
                                                num9 -= num6 * 10000;
                                            }
                                            if (num9 >= 100)
                                            {
                                                num7 = num9 / 100;
                                                num9 -= num7 * 100;
                                            }
                                            if (num9 >= 1)
                                            {
                                                num8 = num9;
                                            }
                                            if (num5 > 0)
                                            {
                                                object obj = text3;
                                                text3 = string.Concat(new object[]
												{
													obj,
													num5,
													" ",
													Lang.inter[15],
													" "
												});
                                            }
                                            if (num6 > 0)
                                            {
                                                object obj2 = text3;
                                                text3 = string.Concat(new object[]
												{
													obj2,
													num6,
													" ",
													Lang.inter[16],
													" "
												});
                                            }
                                            if (num7 > 0)
                                            {
                                                object obj3 = text3;
                                                text3 = string.Concat(new object[]
												{
													obj3,
													num7,
													" ",
													Lang.inter[17],
													" "
												});
                                            }
                                            if (num8 > 0)
                                            {
                                                object obj4 = text3;
                                                text3 = string.Concat(new object[]
												{
													obj4,
													num8,
													" ",
													Lang.inter[18],
													" "
												});
                                            }
                                            float num10 = (float)Main.mouseTextColor / 255f;
                                            if (num5 > 0)
                                            {
                                                textColor = new Color((int)((byte)(220f * num10)), (int)((byte)(220f * num10)), (int)((byte)(198f * num10)), (int)Main.mouseTextColor);
                                            }
                                            else
                                            {
                                                if (num6 > 0)
                                                {
                                                    textColor = new Color((int)((byte)(224f * num10)), (int)((byte)(201f * num10)), (int)((byte)(92f * num10)), (int)Main.mouseTextColor);
                                                }
                                                else
                                                {
                                                    if (num7 > 0)
                                                    {
                                                        textColor = new Color((int)((byte)(181f * num10)), (int)((byte)(192f * num10)), (int)((byte)(193f * num10)), (int)Main.mouseTextColor);
                                                    }
                                                    else
                                                    {
                                                        if (num8 > 0)
                                                        {
                                                            textColor = new Color((int)((byte)(246f * num10)), (int)((byte)(138f * num10)), (int)((byte)(96f * num10)), (int)Main.mouseTextColor);
                                                        }
                                                    }
                                                }
                                            }
                                            text = Lang.inter[54] + " (" + text3 + ")";
                                            if (num9 == 0)
                                            {
                                                text = Lang.inter[54];
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            int num11 = 180 + (Main.screenWidth - 800) / 2;
            int num12 = 130 + num2 * 30;
            float scale = 0.9f;
            if (Main.mouseX > num11 && (float)Main.mouseX < (float)num11 + Main.fontMouseText.MeasureString(text).X && Main.mouseY > num12 && (float)Main.mouseY < (float)num12 + Main.fontMouseText.MeasureString(text).Y)
            {
                Main.player[Main.myPlayer].mouseInterface = true;
                scale = 1.1f;
                if (!Main.npcChatFocus2)
                {
                    Main.PlaySound(SoundTypeID.MENU_TICK, -1, -1, 1);
                }
                Main.npcChatFocus2 = true;
                Main.player[Main.myPlayer].releaseUseItem = false;
            }
            else
            {
                if (Main.npcChatFocus2)
                {
                    Main.PlaySound(SoundTypeID.MENU_TICK, -1, -1, 1);
                }
                Main.npcChatFocus2 = false;
            }
            Vector2 origin = Main.fontMouseText.MeasureString(text) * 0.5f;
            Utils.DrawBorderStringFourWay(Main.spriteBatch, Main.fontMouseText, text, (float)num11 + origin.X, (float)num12 + origin.Y, textColor, Color.Black, origin, scale);
            string text4 = Lang.inter[52];
            textColor = new Color(num, (int)((double)num / 1.1), num / 2, num);
            num11 = num11 + (int)Main.fontMouseText.MeasureString(text).X + 20;
            int num13 = num11 + (int)Main.fontMouseText.MeasureString(text4).X;
            num12 = 130 + num2 * 30;
            scale = 0.9f;
            if (Main.mouseX > num11 && (float)Main.mouseX < (float)num11 + Main.fontMouseText.MeasureString(text4).X && Main.mouseY > num12 && (float)Main.mouseY < (float)num12 + Main.fontMouseText.MeasureString(text4).Y)
            {
                scale = 1.1f;
                if (!Main.npcChatFocus1)
                {
                    Main.PlaySound(SoundTypeID.MENU_TICK, -1, -1, 1);
                }
                Main.npcChatFocus1 = true;
                Main.player[Main.myPlayer].releaseUseItem = false;
                Main.player[Main.myPlayer].controlUseItem = false;
            }
            else
            {
                if (Main.npcChatFocus1)
                {
                    Main.PlaySound(SoundTypeID.MENU_TICK, -1, -1, 1);
                }
                Main.npcChatFocus1 = false;
            }
            origin = Main.fontMouseText.MeasureString(text4) * 0.5f;
            Utils.DrawBorderStringFourWay(Main.spriteBatch, Main.fontMouseText, text4, (float)num11 + origin.X, (float)num12 + origin.Y, textColor, Color.Black, origin, scale);
            if (text2 != "")
            {
                num11 = num13 + (int)Main.fontMouseText.MeasureString(text2).X / 3;
                num12 = 130 + num2 * 30;
                scale = 0.9f;
                if (Main.mouseX > num11 && (float)Main.mouseX < (float)num11 + Main.fontMouseText.MeasureString(text2).X && Main.mouseY > num12 && (float)Main.mouseY < (float)num12 + Main.fontMouseText.MeasureString(text2).Y)
                {
                    Main.player[Main.myPlayer].mouseInterface = true;
                    scale = 1.1f;
                    if (!Main.npcChatFocus3)
                    {
                        Main.PlaySound(SoundTypeID.MENU_TICK, -1, -1, 1);
                    }
                    Main.npcChatFocus3 = true;
                    Main.player[Main.myPlayer].releaseUseItem = false;
                }
                else
                {
                    if (Main.npcChatFocus3)
                    {
                        Main.PlaySound(SoundTypeID.MENU_TICK, -1, -1, 1);
                    }
                    Main.npcChatFocus3 = false;
                }
                origin = Main.fontMouseText.MeasureString(text2) * 0.5f;
                Utils.DrawBorderStringFourWay(Main.spriteBatch, Main.fontMouseText, text2, (float)num11 + origin.X, (float)num12 + origin.Y, textColor, Color.Black, origin, scale);
            }
            if (Main.mouseLeft && Main.mouseLeftRelease)
            {
                Main.mouseLeftRelease = false;
                Main.player[Main.myPlayer].releaseUseItem = false;
                Main.player[Main.myPlayer].mouseInterface = true;
                if (Main.npcChatFocus1)
                {
                    Main.player[Main.myPlayer].talkNPC = -1;
                    Main.player[Main.myPlayer].sign = -1;
                    Main.editSign = false;
                    Main.npcChatText = "";
                    Main.PlaySound(SoundTypeID.MENU_CLOSE, -1, -1, 1);
                    return;
                }
                if (Main.npcChatFocus2)
                {
                    if (Main.player[Main.myPlayer].sign != -1)
                    {
                        if (!Main.editSign)
                        {
                            Main.PlaySound(SoundTypeID.MENU_TICK, -1, -1, 1);
                            Main.editSign = true;
                            Main.clrInput();
                            return;
                        }
                        Main.PlaySound(SoundTypeID.MENU_TICK, -1, -1, 1);
                        int num14 = Main.player[Main.myPlayer].sign;
                        Sign.TextSign(num14, Main.npcChatText);
                        Main.editSign = false;
                        if (Main.netMode == 1)
                        {
                            NetMessage.SendData(47, -1, -1, "", num14, 0f, 0f, 0f, 0);
                            return;
                        }
                    }
                    else
                    {
                        if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 17)
                        {
                            Main.playerInventory = true;
                            Main.npcChatText = "";
                            Main.npcShop = 1;
                            this.shop[Main.npcShop].SetupShop(Main.npcShop);
                            Main.PlaySound(SoundTypeID.MENU_TICK, -1, -1, 1);
                            return;
                        }
                        if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 19)
                        {
                            Main.playerInventory = true;
                            Main.npcChatText = "";
                            Main.npcShop = 2;
                            this.shop[Main.npcShop].SetupShop(Main.npcShop);
                            Main.PlaySound(SoundTypeID.MENU_TICK, -1, -1, 1);
                            return;
                        }
                        if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 124)
                        {
                            Main.playerInventory = true;
                            Main.npcChatText = "";
                            Main.npcShop = 8;
                            this.shop[Main.npcShop].SetupShop(Main.npcShop);
                            Main.PlaySound(SoundTypeID.MENU_TICK, -1, -1, 1);
                            return;
                        }
                        if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 142)
                        {
                            Main.playerInventory = true;
                            Main.npcChatText = "";
                            Main.npcShop = 9;
                            this.shop[Main.npcShop].SetupShop(Main.npcShop);
                            Main.PlaySound(SoundTypeID.MENU_TICK, -1, -1, 1);
                            return;
                        }
                        if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 353)
                        {
                            Main.playerInventory = true;
                            Main.npcChatText = "";
                            Main.npcShop = 18;
                            this.shop[Main.npcShop].SetupShop(Main.npcShop);
                            Main.PlaySound(SoundTypeID.MENU_TICK, -1, -1, 1);
                            return;
                        }
                        if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 368)
                        {
                            Main.playerInventory = true;
                            Main.npcChatText = "";
                            Main.npcShop = 19;
                            this.shop[Main.npcShop].SetupShop(Main.npcShop);
                            Main.PlaySound(SoundTypeID.MENU_TICK, -1, -1, 1);
                            return;
                        }
                        if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 37)
                        {
                            if (Main.netMode == 0)
                            {
                                NPC.SpawnSkeletron();
                            }
                            else
                            {
                                NetMessage.SendData(51, -1, -1, "", Main.myPlayer, 1f, 0f, 0f, 0);
                            }
                            Main.npcChatText = "";
                            return;
                        }
                        if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 20)
                        {
                            Main.playerInventory = true;
                            Main.npcChatText = "";
                            Main.npcShop = 3;
                            this.shop[Main.npcShop].SetupShop(Main.npcShop);
                            Main.PlaySound(SoundTypeID.MENU_TICK, -1, -1, 1);
                            return;
                        }
                        if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 38)
                        {
                            Main.playerInventory = true;
                            Main.npcChatText = "";
                            Main.npcShop = 4;
                            this.shop[Main.npcShop].SetupShop(Main.npcShop);
                            Main.PlaySound(SoundTypeID.MENU_TICK, -1, -1, 1);
                            return;
                        }
                        if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 54)
                        {
                            Main.playerInventory = true;
                            Main.npcChatText = "";
                            Main.npcShop = 5;
                            this.shop[Main.npcShop].SetupShop(Main.npcShop);
                            Main.PlaySound(SoundTypeID.MENU_TICK, -1, -1, 1);
                            return;
                        }
                        if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 107)
                        {
                            Main.playerInventory = true;
                            Main.npcChatText = "";
                            Main.npcShop = 6;
                            this.shop[Main.npcShop].SetupShop(Main.npcShop);
                            Main.PlaySound(SoundTypeID.MENU_TICK, -1, -1, 1);
                            return;
                        }
                        if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 108)
                        {
                            Main.playerInventory = true;
                            Main.npcChatText = "";
                            Main.npcShop = 7;
                            this.shop[Main.npcShop].SetupShop(Main.npcShop);
                            Main.PlaySound(SoundTypeID.MENU_TICK, -1, -1, 1);
                            return;
                        }
                        if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 160)
                        {
                            Main.playerInventory = true;
                            Main.npcChatText = "";
                            Main.npcShop = 10;
                            this.shop[Main.npcShop].SetupShop(Main.npcShop);
                            Main.PlaySound(SoundTypeID.MENU_TICK, -1, -1, 1);
                            return;
                        }
                        if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 178)
                        {
                            Main.playerInventory = true;
                            Main.npcChatText = "";
                            Main.npcShop = 11;
                            this.shop[Main.npcShop].SetupShop(Main.npcShop);
                            Main.PlaySound(SoundTypeID.MENU_TICK, -1, -1, 1);
                            return;
                        }
                        if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 207)
                        {
                            Main.playerInventory = true;
                            Main.npcChatText = "";
                            Main.npcShop = 12;
                            this.shop[Main.npcShop].SetupShop(Main.npcShop);
                            Main.PlaySound(SoundTypeID.MENU_TICK, -1, -1, 1);
                            return;
                        }
                        if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 208)
                        {
                            Main.playerInventory = true;
                            Main.npcChatText = "";
                            Main.npcShop = 13;
                            this.shop[Main.npcShop].SetupShop(Main.npcShop);
                            Main.PlaySound(SoundTypeID.MENU_TICK, -1, -1, 1);
                            return;
                        }
                        if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 209)
                        {
                            Main.playerInventory = true;
                            Main.npcChatText = "";
                            Main.npcShop = 14;
                            this.shop[Main.npcShop].SetupShop(Main.npcShop);
                            Main.PlaySound(SoundTypeID.MENU_TICK, -1, -1, 1);
                            return;
                        }
                        if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 227)
                        {
                            Main.playerInventory = true;
                            Main.npcChatText = "";
                            Main.npcShop = 15;
                            this.shop[Main.npcShop].SetupShop(Main.npcShop);
                            Main.PlaySound(SoundTypeID.MENU_TICK, -1, -1, 1);
                            return;
                        }
                        if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 228)
                        {
                            Main.playerInventory = true;
                            Main.npcChatText = "";
                            Main.npcShop = 16;
                            this.shop[Main.npcShop].SetupShop(Main.npcShop);
                            Main.PlaySound(SoundTypeID.MENU_TICK, -1, -1, 1);
                            return;
                        }
                        if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 229)
                        {
                            Main.playerInventory = true;
                            Main.npcChatText = "";
                            Main.npcShop = 17;
                            this.shop[Main.npcShop].SetupShop(Main.npcShop);
                            Main.PlaySound(SoundTypeID.MENU_TICK, -1, -1, 1);
                            return;
                        }
                        if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 22)
                        {
                            Main.PlaySound(SoundTypeID.MENU_TICK, -1, -1, 1);
                            Main.HelpText();
                            return;
                        }
                        if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 18)
                        {
                            Main.PlaySound(SoundTypeID.MENU_TICK, -1, -1, 1);
                            if (num3 > 0)
                            {
                                if (Main.player[Main.myPlayer].BuyItem(num3))
                                {
                                    Main.PlaySound(SoundTypeID.ITEM,-1, -1, 4);
                                    Main.player[Main.myPlayer].HealEffect(Main.player[Main.myPlayer].statLifeMax - Main.player[Main.myPlayer].statLife, true);
                                    if ((double)Main.player[Main.myPlayer].statLife < (double)Main.player[Main.myPlayer].statLifeMax * 0.25)
                                    {
                                        Main.npcChatText = Lang.dialog(227, false);
                                    }
                                    else
                                    {
                                        if ((double)Main.player[Main.myPlayer].statLife < (double)Main.player[Main.myPlayer].statLifeMax * 0.5)
                                        {
                                            Main.npcChatText = Lang.dialog(228, false);
                                        }
                                        else
                                        {
                                            if ((double)Main.player[Main.myPlayer].statLife < (double)Main.player[Main.myPlayer].statLifeMax * 0.75)
                                            {
                                                Main.npcChatText = Lang.dialog(229, false);
                                            }
                                            else
                                            {
                                                Main.npcChatText = Lang.dialog(230, false);
                                            }
                                        }
                                    }
                                    Main.player[Main.myPlayer].statLife = Main.player[Main.myPlayer].statLifeMax;
                                    for (int k = 0; k < 22; k++)
                                    {
                                        int num15 = Main.player[Main.myPlayer].buffType[k];
                                        if (Main.debuff[num15] && Main.player[Main.myPlayer].buffTime[k] > 0 && num15 != 28 && num15 != 34 && num15 != 87 && num15 != 89 && num15 != 21 && num15 != 86)
                                        {
                                            Main.player[Main.myPlayer].DelBuff(k);
                                        }
                                    }
                                    return;
                                }
                                int num16 = Main.rand.Next(3);
                                if (num16 == 0)
                                {
                                    Main.npcChatText = Lang.dialog(52, false);
                                }
                                if (num16 == 1)
                                {
                                    Main.npcChatText = Lang.dialog(53, false);
                                }
                                if (num16 == 2)
                                {
                                    Main.npcChatText = Lang.dialog(54, false);
                                    return;
                                }
                            }
                            else
                            {
                                int num17 = Main.rand.Next(3);
                                if (num17 == 0)
                                {
                                    Main.npcChatText = Lang.dialog(55, false);
                                }
                                if (num17 == 1)
                                {
                                    Main.npcChatText = Lang.dialog(56, false);
                                }
                                if (num17 == 2)
                                {
                                    Main.npcChatText = Lang.dialog(57, false);
                                    return;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (Main.npcChatFocus3 && Main.player[Main.myPlayer].talkNPC >= 0)
                    {
                        if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 20)
                        {
                            Main.PlaySound(SoundTypeID.MENU_TICK, -1, -1, 1);
                            Main.npcChatText = Lang.evilGood();
                            return;
                        }
                        if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 22)
                        {
                            Main.playerInventory = true;
                            Main.npcChatText = "";
                            Main.PlaySound(SoundTypeID.MENU_TICK, -1, -1, 1);
                            Main.craftGuide = true;
                            return;
                        }
                        if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 107)
                        {
                            Main.playerInventory = true;
                            Main.npcChatText = "";
                            Main.PlaySound(SoundTypeID.MENU_TICK, -1, -1, 1);
                            Main.reforge = true;
                            return;
                        }
                        if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 353)
                        {
                            Main.OpenHairWindow();
                        }
                    }
                }
            }
        }

        public static Color shine(Color newColor, int type)
        {
            int num = (int)newColor.R;
            int num2 = (int)newColor.G;
            int num3 = (int)newColor.B;
            float num4 = 0.6f;
            if (type == 25)
            {
                num = (int)((float)newColor.R * 0.95f);
                num2 = (int)((float)newColor.G * 0.85f);
                num3 = (int)((double)((float)newColor.B) * 1.1);
            }
            else
            {
                if (type == 117)
                {
                    num = (int)((float)newColor.R * 1.1f);
                    num2 = (int)((float)newColor.G * 1f);
                    num3 = (int)((double)((float)newColor.B) * 1.2);
                }
                else
                {
                    if (type == 204)
                    {
                        num4 = 0.3f + (float)Main.mouseTextColor / 300f;
                        num = (int)((float)newColor.R * (1.3f * num4));
                        if (num > 255)
                        {
                            num = 255;
                        }
                        return new Color(num, num2, num3, 255);
                    }
                    if (type == 211)
                    {
                        num4 = 0.3f + (float)Main.mouseTextColor / 300f;
                        num2 = (int)((float)newColor.G * (1.5f * num4));
                        num3 = (int)((float)newColor.B * (1.1f * num4));
                    }
                    else
                    {
                        if (type == 147 || type == 161)
                        {
                            num = (int)((float)newColor.R * 1.1f);
                            num2 = (int)((float)newColor.G * 1.12f);
                            num3 = (int)((double)((float)newColor.B) * 1.15);
                        }
                        else
                        {
                            if (type == 163)
                            {
                                num = (int)((float)newColor.R * 1.05f);
                                num2 = (int)((float)newColor.G * 1.1f);
                                num3 = (int)((double)((float)newColor.B) * 1.15);
                            }
                            else
                            {
                                if (type == 164)
                                {
                                    num = (int)((float)newColor.R * 1.1f);
                                    num2 = (int)((float)newColor.G * 1.1f);
                                    num3 = (int)((double)((float)newColor.B) * 1.2);
                                }
                                else
                                {
                                    if (type == 178)
                                    {
                                        num4 = 0.5f;
                                        num = (int)((float)newColor.R * (1f + num4));
                                        num2 = (int)((float)newColor.G * (1f + num4));
                                        num3 = (int)((float)newColor.B * (1f + num4));
                                    }
                                    else
                                    {
                                        if (type == 185 || type == 186)
                                        {
                                            num4 = 0.3f;
                                            num = (int)((float)newColor.R * (1f + num4));
                                            num2 = (int)((float)newColor.G * (1f + num4));
                                            num3 = (int)((float)newColor.B * (1f + num4));
                                        }
                                        else
                                        {
                                            if (type >= 262 && type <= 268)
                                            {
                                                num3 += 100;
                                                num += 100;
                                                num2 += 100;
                                            }
                                            else
                                            {
                                                num = (int)((float)newColor.R * (1f + num4));
                                                num2 = (int)((float)newColor.G * (1f + num4));
                                                num3 = (int)((float)newColor.B * (1f + num4));
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (num > 255)
            {
                num = 255;
            }
            if (num2 > 255)
            {
                num2 = 255;
            }
            if (num3 > 255)
            {
                num3 = 255;
            }
            newColor.R = (byte)num;
            newColor.G = (byte)num2;
            newColor.B = (byte)num3;
            return new Color((int)((byte)num), (int)((byte)num2), (int)((byte)num3), (int)newColor.A);
        }
        public static bool canDrawColorTile(int i, int j)
        {
            return Main.tile[i, j] != null && Main.tile[i, j].color() > 0 && (int)Main.tile[i, j].color() < Main.numTileColors && Main.tileAltTextureDrawn[(int)Main.tile[i, j].type, (int)Main.tile[i, j].color()] && Main.tileAltTextureInit[(int)Main.tile[i, j].type, (int)Main.tile[i, j].color()];
        }
        public static bool canDrawColorWall(int i, int j)
        {
            return Main.tile[i, j] != null && Main.tile[i, j].wallColor() > 0 && Main.wallAltTextureDrawn[(int)Main.tile[i, j].wall, (int)Main.tile[i, j].wallColor()] && Main.wallAltTextureInit[(int)Main.tile[i, j].wall, (int)Main.tile[i, j].wallColor()];
        }
    }
}
