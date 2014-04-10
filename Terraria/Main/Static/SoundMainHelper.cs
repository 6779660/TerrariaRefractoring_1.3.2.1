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
        public static SoundEffect[] soundLiquid = new SoundEffect[2];
        public static SoundEffectInstance[] soundInstanceLiquid = new SoundEffectInstance[2];
        public static SoundEffect[] soundMech = new SoundEffect[1];
        public static SoundEffectInstance[] soundInstanceMech = new SoundEffectInstance[1];
        public static SoundEffect[] soundDig = new SoundEffect[3];
        public static SoundEffectInstance[] soundInstanceDig = new SoundEffectInstance[3];
        public static SoundEffect[] soundTink = new SoundEffect[3];
        public static SoundEffectInstance[] soundInstanceTink = new SoundEffectInstance[3];
        public static SoundEffect[] soundPlayerHit = new SoundEffect[3];
        public static SoundEffectInstance[] soundInstancePlayerHit = new SoundEffectInstance[3];
        public static SoundEffect[] soundFemaleHit = new SoundEffect[3];
        public static SoundEffectInstance[] soundInstanceFemaleHit = new SoundEffectInstance[3];
        public static SoundEffect soundPlayerKilled;
        public static SoundEffectInstance soundInstancePlayerKilled;
        public static SoundEffect soundGrass;
        public static SoundEffectInstance soundInstanceGrass;
        public static SoundEffect soundGrab;
        public static SoundEffectInstance soundInstanceGrab;
        public static SoundEffect soundPixie;
        public static SoundEffectInstance soundInstancePixie;
        public static SoundEffect[] soundItem = new SoundEffect[52];
        public static SoundEffectInstance[] soundInstanceItem = new SoundEffectInstance[52];
        public static SoundEffect[] soundNPCHit = new SoundEffect[14];
        public static SoundEffectInstance[] soundInstanceNPCHit = new SoundEffectInstance[14];
        public static SoundEffect[] soundNPCKilled = new SoundEffect[20];
        public static SoundEffectInstance[] soundInstanceNPCKilled = new SoundEffectInstance[20];
        public static SoundEffect soundDoorOpen;
        public static SoundEffectInstance soundInstanceDoorOpen;
        public static SoundEffect soundDoorClosed;
        public static SoundEffectInstance soundInstanceDoorClosed;
        public static SoundEffect soundMenuOpen;
        public static SoundEffectInstance soundInstanceMenuOpen;
        public static SoundEffect soundMenuClose;
        public static SoundEffectInstance soundInstanceMenuClose;
        public static SoundEffect soundMenuTick;
        public static SoundEffectInstance soundInstanceMenuTick;
        public static SoundEffect soundShatter;
        public static SoundEffectInstance soundInstanceShatter;
        public static SoundEffect[] soundZombie = new SoundEffect[20];
        public static SoundEffectInstance[] soundInstanceZombie = new SoundEffectInstance[20];
        public static SoundEffect[] soundRoar = new SoundEffect[2];
        public static SoundEffectInstance[] soundInstanceRoar = new SoundEffectInstance[2];
        public static SoundEffect[] soundSplash = new SoundEffect[2];
        public static SoundEffectInstance[] soundInstanceSplash = new SoundEffectInstance[2];
        public static SoundEffect soundDoubleJump;
        public static SoundEffectInstance soundInstanceDoubleJump;
        public static SoundEffect soundRun;
        public static SoundEffectInstance soundInstanceRun;
        public static SoundEffect soundCoins;
        public static SoundEffectInstance soundInstanceCoins;
        public static SoundEffect soundUnlock;
        public static SoundEffectInstance soundInstanceUnlock;
        public static SoundEffect soundChat;
        public static SoundEffectInstance soundInstanceChat;
        public static SoundEffect soundMaxMana;
        public static SoundEffectInstance soundInstanceMaxMana;
        public static SoundEffect soundDrown;
        public static SoundEffectInstance soundInstanceDrown;
        public static AudioEngine engine;
        public static SoundBank soundBank;
        public static WaveBank waveBank;
        public static Cue[] music = new Cue[33];
        public static float[] musicFade = new float[33];
        public static float musicVolume = 0.75f;
        public static float ambientVolume = 0.75f;
        public static float soundVolume = 1f;

        public static void Ambience()
        {
            Main.ambientCounter++;
            if (Main.ambientCounter >= 15)
            {
                Main.ambientCounter = 0;
                Main.PlaySound(SoundTypeID.LIQUID_I, (int)Main.ambientWaterfallX, (int)Main.ambientWaterfallY, (int)Main.ambientWaterfallStrength);
                float num = Math.Abs(Main.ambientLavaX - (Main.screenPosition.X + (float)(Main.screenWidth / 2))) + Math.Abs(Main.ambientLavaY - (Main.screenPosition.Y + (float)(Main.screenHeight / 2)));
                float num2 = Math.Abs(Main.ambientLavafallX - (Main.screenPosition.X + (float)(Main.screenWidth / 2))) + Math.Abs(Main.ambientLavafallY - (Main.screenPosition.Y + (float)(Main.screenHeight / 2)));
                float num3 = Main.ambientLavaX;
                float num4 = Main.ambientLavaY;
                if (num2 < num)
                {
                    num3 = Main.ambientLavafallX;
                    num4 = Main.ambientLavafallY;
                }
                float num5 = Main.ambientLavafallStrength + Main.ambientLavaStrength;
                Main.PlaySound(SoundTypeID.LIQUID_II, (int)num3, (int)num4, (int)num5);
            }
        }

        public static void PlaySound(SoundTypeID typeID, int x = -1, int y = -1, int Style = 1)
        {
            int num = Style;
            int type = (int)typeID;
            try
            {
                if (!Main.dedServ)
                {
                    if (Main.soundVolume != 0f || (type >= 30 && type <= 35))
                    {
                        bool flag = false;
                        float num2 = 1f;
                        float num3 = 0f;
                        if (x == -1 || y == -1) flag = true;
                        else
                        {
                            if (WorldGen.gen) return;
                            if (Main.netMode == 2) return;
                            Rectangle value = new Rectangle((int)(Main.screenPosition.X - (float)(Main.screenWidth * 2)), (int)(Main.screenPosition.Y - (float)(Main.screenHeight * 2)), Main.screenWidth * 5, Main.screenHeight * 5);
                            Rectangle rectangle = new Rectangle(x, y, 1, 1);
                            Vector2 vector = new Vector2(Main.screenPosition.X + (float)Main.screenWidth * 0.5f, Main.screenPosition.Y + (float)Main.screenHeight * 0.5f);
                            if (rectangle.Intersects(value)) flag = true;
                            if (flag)
                            {
                                num3 = ((float)x - vector.X) / ((float)Main.screenWidth * 0.5f);
                                float num4 = Math.Abs((float)x - vector.X);
                                float num5 = Math.Abs((float)y - vector.Y);
                                float num6 = (float)Math.Sqrt((double)(num4 * num4 + num5 * num5));
                                num2 = 1f - num6 / ((float)Main.screenWidth * 1.5f);
                            }
                        }
                        if (num3 < -1f) num3 = -1f;
                        if (num3 > 1f) num3 = 1f;
                        if (num2 > 1f) num2 = 1f;
                        if (num2 > 0f || (type >= 34 && type <= 35))
                        {
                            if (flag)
                            {
                                if (type >= 30 && type <= 35) num2 *= Main.ambientVolume * (float)(Main.gameInactive ? 0 : 1);
                                else num2 *= Main.soundVolume;
                                if (num2 > 1f) num2 = 1f;
                                if (num2 > 0f || (type >= 30 && type <= 35))
                                {
                                    switch (typeID)
                                    {
                                        case SoundTypeID.DIG:
                                            {
                                                int num7 = Main.rand.Next(3);
                                                Main.soundInstanceDig[num7].Stop();
                                                Main.soundInstanceDig[num7] = Main.soundDig[num7].CreateInstance();
                                                Main.soundInstanceDig[num7].Volume = num2;
                                                Main.soundInstanceDig[num7].Pan = num3;
                                                Main.soundInstanceDig[num7].Pitch = (float)Main.rand.Next(-10, 11) * 0.01f;
                                                Main.soundInstanceDig[num7].Play();
                                            }
                                            break;
                                        case SoundTypeID.PLAYER_HIT:
                                            {
                                                int num8 = Main.rand.Next(3);
                                                Main.soundInstancePlayerHit[num8].Stop();
                                                Main.soundInstancePlayerHit[num8] = Main.soundPlayerHit[num8].CreateInstance();
                                                Main.soundInstancePlayerHit[num8].Volume = num2;
                                                Main.soundInstancePlayerHit[num8].Pan = num3;
                                                Main.soundInstancePlayerHit[num8].Play();
                                            }
                                            break;
                                        case SoundTypeID.ITEM:
                                            {
                                                if (num == 1)
                                                {
                                                    int num9 = Main.rand.Next(3);
                                                    if (num9 == 1) num = 18;
                                                    if (num9 == 2) num = 19;
                                                }
                                                if (num != 9 && num != 10 && num != 24 && num != 26 && num != 34) Main.soundInstanceItem[num].Stop();
                                                Main.soundInstanceItem[num] = Main.soundItem[num].CreateInstance();
                                                Main.soundInstanceItem[num].Volume = num2;
                                                Main.soundInstanceItem[num].Pan = num3;
                                                if (num == 47) Main.soundInstanceItem[num].Pitch = (float)Main.rand.Next(-5, 6) * 0.19f;
                                                else Main.soundInstanceItem[num].Pitch = (float)Main.rand.Next(-6, 7) * 0.01f;
                                                if (num == 26 || num == 35)
                                                {
                                                    Main.soundInstanceItem[num].Volume = num2 * 0.75f;
                                                    Main.soundInstanceItem[num].Pitch = Main.harpNote;
                                                }
                                                Main.soundInstanceItem[num].Play();
                                            }
                                            break;
                                        case SoundTypeID.NPC_HIT:
                                            {
                                                Main.soundInstanceNPCHit[num].Stop();
                                                Main.soundInstanceNPCHit[num] = Main.soundNPCHit[num].CreateInstance();
                                                Main.soundInstanceNPCHit[num].Volume = num2;
                                                Main.soundInstanceNPCHit[num].Pan = num3;
                                                Main.soundInstanceNPCHit[num].Pitch = (float)Main.rand.Next(-10, 11) * 0.01f;
                                                Main.soundInstanceNPCHit[num].Play();
                                            }
                                            break;
                                        case SoundTypeID.NPC_KILLED:
                                            {
                                                if (num != 10 || Main.soundInstanceNPCKilled[num].State != SoundState.Playing)
                                                {
                                                    Main.soundInstanceNPCKilled[num] = Main.soundNPCKilled[num].CreateInstance();
                                                    Main.soundInstanceNPCKilled[num].Volume = num2;
                                                    Main.soundInstanceNPCKilled[num].Pan = num3;
                                                    Main.soundInstanceNPCKilled[num].Pitch = (float)Main.rand.Next(-10, 11) * 0.01f;
                                                    Main.soundInstanceNPCKilled[num].Play();
                                                }
                                            }
                                            break;
                                        case SoundTypeID.PLAYER_KILLED:
                                            {
                                                Main.soundInstancePlayerKilled.Stop();
                                                Main.soundInstancePlayerKilled = Main.soundPlayerKilled.CreateInstance();
                                                Main.soundInstancePlayerKilled.Volume = num2;
                                                Main.soundInstancePlayerKilled.Pan = num3;
                                                Main.soundInstancePlayerKilled.Play();
                                            }
                                            break;
                                        case SoundTypeID.GRASS:
                                            {
                                                Main.soundInstanceGrass.Stop();
                                                Main.soundInstanceGrass = Main.soundGrass.CreateInstance();
                                                Main.soundInstanceGrass.Volume = num2;
                                                Main.soundInstanceGrass.Pan = num3;
                                                Main.soundInstanceGrass.Pitch = (float)Main.rand.Next(-30, 31) * 0.01f;
                                                Main.soundInstanceGrass.Play();
                                            }
                                            break;
                                        case SoundTypeID.GRAB:
                                            {
                                                Main.soundInstanceGrab.Stop();
                                                Main.soundInstanceGrab = Main.soundGrab.CreateInstance();
                                                Main.soundInstanceGrab.Volume = num2;
                                                Main.soundInstanceGrab.Pan = num3;
                                                Main.soundInstanceGrab.Pitch = (float)Main.rand.Next(-10, 11) * 0.01f;
                                                Main.soundInstanceGrab.Play();
                                            }
                                            break;
                                        case SoundTypeID.DOOR_OPEN:
                                            {
                                                Main.soundInstanceDoorOpen.Stop();
                                                Main.soundInstanceDoorOpen = Main.soundDoorOpen.CreateInstance();
                                                Main.soundInstanceDoorOpen.Volume = num2;
                                                Main.soundInstanceDoorOpen.Pan = num3;
                                                Main.soundInstanceDoorOpen.Pitch = (float)Main.rand.Next(-20, 21) * 0.01f;
                                                Main.soundInstanceDoorOpen.Play();
                                            }
                                            break;
                                        case SoundTypeID.DOOR_CLOSE:
                                            {
                                                Main.soundInstanceDoorClosed.Stop();
                                                Main.soundInstanceDoorClosed = Main.soundDoorClosed.CreateInstance();
                                                Main.soundInstanceDoorClosed.Volume = num2;
                                                Main.soundInstanceDoorClosed.Pan = num3;
                                                Main.soundInstanceDoorOpen.Pitch = (float)Main.rand.Next(-20, 21) * 0.01f;
                                                Main.soundInstanceDoorClosed.Play();
                                            }
                                            break;
                                        case SoundTypeID.MENU_OPEN:
                                            {
                                                Main.soundInstanceMenuOpen.Stop();
                                                Main.soundInstanceMenuOpen = Main.soundMenuOpen.CreateInstance();
                                                Main.soundInstanceMenuOpen.Volume = num2;
                                                Main.soundInstanceMenuOpen.Pan = num3;
                                                Main.soundInstanceMenuOpen.Play();
                                            }
                                            break;
                                        case SoundTypeID.MENU_CLOSE:
                                            {
                                                Main.soundInstanceMenuClose.Stop();
                                                Main.soundInstanceMenuClose = Main.soundMenuClose.CreateInstance();
                                                Main.soundInstanceMenuClose.Volume = num2;
                                                Main.soundInstanceMenuClose.Pan = num3;
                                                Main.soundInstanceMenuClose.Play();
                                            }
                                            break;
                                        case SoundTypeID.MENU_TICK:
                                            {
                                                Main.soundInstanceMenuTick.Stop();
                                                Main.soundInstanceMenuTick = Main.soundMenuTick.CreateInstance();
                                                Main.soundInstanceMenuTick.Volume = num2;
                                                Main.soundInstanceMenuTick.Pan = num3;
                                                Main.soundInstanceMenuTick.Play();
                                            }
                                            break;
                                        case SoundTypeID.SHATTER:
                                            {
                                                Main.soundInstanceShatter.Stop();
                                                Main.soundInstanceShatter = Main.soundShatter.CreateInstance();
                                                Main.soundInstanceShatter.Volume = num2;
                                                Main.soundInstanceShatter.Pan = num3;
                                                Main.soundInstanceShatter.Play();
                                            }
                                            break;
                                        case SoundTypeID.ZOMBIE:
                                            {
                                                int num10 = Main.rand.Next(3);
                                                Main.soundInstanceZombie[num10] = Main.soundZombie[num10].CreateInstance();
                                                Main.soundInstanceZombie[num10].Volume = num2 * 0.4f;
                                                Main.soundInstanceZombie[num10].Pan = num3;
                                                Main.soundInstanceZombie[num10].Play();
                                            }
                                            break;
                                        case SoundTypeID.ROAR:
                                            {
                                                if (Main.soundInstanceRoar[num].State == SoundState.Stopped)
                                                {
                                                    Main.soundInstanceRoar[num] = Main.soundRoar[num].CreateInstance();
                                                    Main.soundInstanceRoar[num].Volume = num2;
                                                    Main.soundInstanceRoar[num].Pan = num3;
                                                    Main.soundInstanceRoar[num].Play();
                                                }
                                            }
                                            break;
                                        case SoundTypeID.DOUBLE_JUMP:
                                            {
                                                Main.soundInstanceDoubleJump.Stop();
                                                Main.soundInstanceDoubleJump = Main.soundDoubleJump.CreateInstance();
                                                Main.soundInstanceDoubleJump.Volume = num2;
                                                Main.soundInstanceDoubleJump.Pan = num3;
                                                Main.soundInstanceDoubleJump.Pitch = (float)Main.rand.Next(-10, 11) * 0.01f;
                                                Main.soundInstanceDoubleJump.Play();
                                            }
                                            break;
                                        case SoundTypeID.RUN:
                                            {
                                                Main.soundInstanceRun.Stop();
                                                Main.soundInstanceRun = Main.soundRun.CreateInstance();
                                                Main.soundInstanceRun.Volume = num2;
                                                Main.soundInstanceRun.Pan = num3;
                                                Main.soundInstanceRun.Pitch = (float)Main.rand.Next(-10, 11) * 0.01f;
                                                Main.soundInstanceRun.Play();
                                            }
                                            break;
                                        case SoundTypeID.COINS:
                                            {
                                                Main.soundInstanceCoins = Main.soundCoins.CreateInstance();
                                                Main.soundInstanceCoins.Volume = num2;
                                                Main.soundInstanceCoins.Pan = num3;
                                                Main.soundInstanceCoins.Play();
                                            }
                                            break;
                                        case SoundTypeID.SPLASH:
                                            {
                                                if (Main.soundInstanceSplash[num].State == SoundState.Stopped)
                                                {
                                                    Main.soundInstanceSplash[num] = Main.soundSplash[num].CreateInstance();
                                                    Main.soundInstanceSplash[num].Volume = num2;
                                                    Main.soundInstanceSplash[num].Pan = num3;
                                                    Main.soundInstanceSplash[num].Pitch = (float)Main.rand.Next(-10, 11) * 0.01f;
                                                    Main.soundInstanceSplash[num].Play();
                                                }
                                            }
                                            break;
                                        case SoundTypeID.FEMALE_HIT:
                                            {
                                                int num11 = Main.rand.Next(3);
                                                Main.soundInstanceFemaleHit[num11].Stop();
                                                Main.soundInstanceFemaleHit[num11] = Main.soundFemaleHit[num11].CreateInstance();
                                                Main.soundInstanceFemaleHit[num11].Volume = num2;
                                                Main.soundInstanceFemaleHit[num11].Pan = num3;
                                                Main.soundInstanceFemaleHit[num11].Play();
                                            }
                                            break;
                                        case SoundTypeID.TINK:
                                            {
                                                int num12 = Main.rand.Next(3);
                                                Main.soundInstanceTink[num12].Stop();
                                                Main.soundInstanceTink[num12] = Main.soundTink[num12].CreateInstance();
                                                Main.soundInstanceTink[num12].Volume = num2;
                                                Main.soundInstanceTink[num12].Pan = num3;
                                                Main.soundInstanceTink[num12].Play();
                                            }
                                            break;
                                        case SoundTypeID.UNLOCK:
                                            {
                                                Main.soundInstanceUnlock.Stop();
                                                Main.soundInstanceUnlock = Main.soundUnlock.CreateInstance();
                                                Main.soundInstanceUnlock.Volume = num2;
                                                Main.soundInstanceUnlock.Pan = num3;
                                                Main.soundInstanceUnlock.Play();
                                            }
                                            break;
                                        case SoundTypeID.DROWN:
                                            {
                                                Main.soundInstanceDrown.Stop();
                                                Main.soundInstanceDrown = Main.soundDrown.CreateInstance();
                                                Main.soundInstanceDrown.Volume = num2;
                                                Main.soundInstanceDrown.Pan = num3;
                                                Main.soundInstanceDrown.Play();
                                            }
                                            break;
                                        case SoundTypeID.CHAT:
                                            {
                                                Main.soundInstanceChat = Main.soundChat.CreateInstance();
                                                Main.soundInstanceChat.Volume = num2;
                                                Main.soundInstanceChat.Pan = num3;
                                                Main.soundInstanceChat.Play();
                                            }
                                            break;
                                        case SoundTypeID.MAX_MANA:
                                            {
                                                Main.soundInstanceMaxMana = Main.soundMaxMana.CreateInstance();
                                                Main.soundInstanceMaxMana.Volume = num2;
                                                Main.soundInstanceMaxMana.Pan = num3;
                                                Main.soundInstanceMaxMana.Play();
                                            }
                                            break;
                                        case SoundTypeID.ZOMBIE_I:
                                            {
                                                int num13 = Main.rand.Next(3, 5);
                                                Main.soundInstanceZombie[num13] = Main.soundZombie[num13].CreateInstance();
                                                Main.soundInstanceZombie[num13].Volume = num2 * 0.9f;
                                                Main.soundInstanceZombie[num13].Pan = num3;
                                                Main.soundInstanceSplash[num].Pitch = (float)Main.rand.Next(-10, 11) * 0.01f;
                                                Main.soundInstanceZombie[num13].Play();
                                            }
                                            break;
                                        case SoundTypeID.PIXIE:
                                            {
                                                if (Main.soundInstancePixie.State == SoundState.Playing)
                                                {
                                                    Main.soundInstancePixie.Volume = num2;
                                                    Main.soundInstancePixie.Pan = num3;
                                                    Main.soundInstancePixie.Pitch = (float)Main.rand.Next(-10, 11) * 0.01f;
                                                }
                                                else
                                                {
                                                    Main.soundInstancePixie.Stop();
                                                    Main.soundInstancePixie = Main.soundPixie.CreateInstance();
                                                    Main.soundInstancePixie.Volume = num2;
                                                    Main.soundInstancePixie.Pan = num3;
                                                    Main.soundInstancePixie.Pitch = (float)Main.rand.Next(-10, 11) * 0.01f;
                                                    Main.soundInstancePixie.Play();
                                                }
                                            }
                                            break;
                                        case SoundTypeID.MECH:
                                            {
                                                if (Main.soundInstanceMech[num].State != SoundState.Playing)
                                                {
                                                    Main.soundInstanceMech[num] = Main.soundMech[num].CreateInstance();
                                                    Main.soundInstanceMech[num].Volume = num2;
                                                    Main.soundInstanceMech[num].Pan = num3;
                                                    Main.soundInstanceMech[num].Pitch = (float)Main.rand.Next(-10, 11) * 0.01f;
                                                    Main.soundInstanceMech[num].Play();
                                                }
                                            }
                                            break;
                                        case SoundTypeID.ZOMBIE_II:
                                            {
                                                if (Main.soundInstanceZombie[num].State != SoundState.Playing)
                                                {
                                                    Main.soundInstanceZombie[num] = Main.soundZombie[num].CreateInstance();
                                                    Main.soundInstanceZombie[num].Volume = num2;
                                                    Main.soundInstanceZombie[num].Pan = num3;
                                                    Main.soundInstanceZombie[num].Pitch = (float)Main.rand.Next(-10, 11) * 0.01f;
                                                    Main.soundInstanceZombie[num].Play();
                                                }
                                            }
                                            break;
                                        case SoundTypeID.ZOMBIE_III:
                                            {
                                                num = Main.rand.Next(10, 12);
                                                if (Main.rand.Next(300) == 0)
                                                {
                                                    num = 12;
                                                    if (Main.soundInstanceZombie[num].State == SoundState.Playing) return;
                                                }
                                                Main.soundInstanceZombie[num] = Main.soundZombie[num].CreateInstance();
                                                Main.soundInstanceZombie[num].Volume = num2 * 0.75f;
                                                Main.soundInstanceZombie[num].Pan = num3;
                                                if (num != 12) Main.soundInstanceZombie[num].Pitch = (float)Main.rand.Next(-70, 1) * 0.01f;
                                                else Main.soundInstanceZombie[num].Pitch = (float)Main.rand.Next(-40, 21) * 0.01f;
                                                Main.soundInstanceZombie[num].Play();
                                            }
                                            break;
                                        case SoundTypeID.ZOMBIE_IV:
                                            {
                                                num = 13;
                                                Main.soundInstanceZombie[num] = Main.soundZombie[num].CreateInstance();
                                                Main.soundInstanceZombie[num].Volume = num2 * 0.35f;
                                                Main.soundInstanceZombie[num].Pan = num3;
                                                Main.soundInstanceZombie[num].Pitch = (float)Main.rand.Next(-40, 21) * 0.01f;
                                                Main.soundInstanceZombie[num].Play();
                                            }
                                            break;
                                        case SoundTypeID.ZOMBIE_V:
                                            {
                                                if (Main.soundInstanceZombie[num].State != SoundState.Playing)
                                                {
                                                    Main.soundInstanceZombie[num] = Main.soundZombie[num].CreateInstance();
                                                    Main.soundInstanceZombie[num].Volume = num2 * 0.15f;
                                                    Main.soundInstanceZombie[num].Pan = num3;
                                                    Main.soundInstanceZombie[num].Pitch = (float)Main.rand.Next(-70, 26) * 0.01f;
                                                    Main.soundInstanceZombie[num].Play();
                                                }
                                            }
                                            break;
                                        case SoundTypeID.ZOMBIE_VI:
                                            {
                                                num = 15;
                                                if (Main.soundInstanceZombie[num].State != SoundState.Playing)
                                                {
                                                    Main.soundInstanceZombie[num] = Main.soundZombie[num].CreateInstance();
                                                    Main.soundInstanceZombie[num].Volume = num2 * 0.2f;
                                                    Main.soundInstanceZombie[num].Pan = num3;
                                                    Main.soundInstanceZombie[num].Pitch = (float)Main.rand.Next(-10, 31) * 0.01f;
                                                    Main.soundInstanceZombie[num].Play();
                                                }
                                            }
                                            break;
                                        case SoundTypeID.LIQUID_I:
                                            {
                                                float num14 = (float)num / 50f;
                                                if (num14 > 1f) num14 = 1f;
                                                num2 *= num14;
                                                num2 *= 0.2f;
                                                if ((num2 <= 0f || x == -1 || y == -1)
                                                    && Main.soundInstanceLiquid[0].State == SoundState.Playing)
                                                    Main.soundInstanceLiquid[0].Stop();
                                                else
                                                {
                                                    if (Main.soundInstanceLiquid[0].State == SoundState.Playing)
                                                    {
                                                        Main.soundInstanceLiquid[0].Volume = num2;
                                                        Main.soundInstanceLiquid[0].Pan = num3;
                                                        Main.soundInstanceLiquid[0].Pitch = -0.2f;
                                                    }
                                                    else
                                                    {
                                                        Main.soundInstanceLiquid[0] = Main.soundLiquid[0].CreateInstance();
                                                        Main.soundInstanceLiquid[0].Volume = num2;
                                                        Main.soundInstanceLiquid[0].Pan = num3;
                                                        Main.soundInstanceLiquid[0].Play();
                                                    }
                                                }
                                            }
                                            break;
                                        case SoundTypeID.LIQUID_II:
                                            {
                                                float num15 = (float)num / 50f;
                                                if (num15 > 1f) num15 = 1f;
                                                num2 *= num15;
                                                num2 *= 0.65f;
                                                if ((num2 <= 0f || x == -1 || y == -1)
                                                    && Main.soundInstanceLiquid[1].State == SoundState.Playing)
                                                        Main.soundInstanceLiquid[1].Stop();
                                                else
                                                {
                                                    if (Main.soundInstanceLiquid[1].State == SoundState.Playing)
                                                    {
                                                        Main.soundInstanceLiquid[1].Volume = num2;
                                                        Main.soundInstanceLiquid[1].Pan = num3;
                                                        Main.soundInstanceLiquid[1].Pitch = 0f;
                                                    }
                                                    else
                                                    {
                                                        Main.soundInstanceLiquid[1] = Main.soundLiquid[1].CreateInstance();
                                                        Main.soundInstanceLiquid[1].Volume = num2;
                                                        Main.soundInstanceLiquid[1].Pan = num3;
                                                        Main.soundInstanceLiquid[1].Play();
                                                    }
                                                }
                                            }
                                            break;
                                        default:
                                            break;
                                    };
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }
    }
}
