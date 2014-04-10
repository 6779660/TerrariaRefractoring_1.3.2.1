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
namespace Terraria
{
    public partial class Main
    {
        public const int maxItemTypes = 2289;
        public const int maxProjectileTypes = 360;
        public const int maxNPCTypes = 369;
        public const int maxTileSets = 314;
        public const int maxWallTypes = 145;
        public const int maxGoreTypes = 573;
        public const int numArmorHead = 160;
        public const int numArmorBody = 168;
        public const int numArmorLegs = 103;
        public const int numAccHandsOn = 18;
        public const int numAccHandsOff = 11;
        public const int numAccNeck = 7;
        public const int numAccBack = 8;
        public const int numAccFront = 5;
        public const int numAccShoes = 15;
        public const int numAccWaist = 11;
        public const int numAccShield = 5;
        public const int numAccFace = 8;
        public const int numAccBalloon = 11;
        public const int maxBuffs = 104;
        public const int maxWings = 25;
        public const int maxBackgrounds = 185;
        private const int MF_BYPOSITION = 1024;
        public const int sectionWidth = 200;
        public const int sectionHeight = 150;
        public const int maxDust = 6000;
        public const int maxCombatText = 100;
        public const int maxItemText = 20;
        public const int maxPlayers = 255;
        public const int maxChests = 1000;
        public const int maxItems = 400;
        public const int maxProjectiles = 1000;
        public const int maxNPCs = 200;
        public const int maxGore = 500;
        public const int realInventory = 50;
        public const int maxInventory = 58;
        public const int maxItemSounds = 51;
        public const int maxNPCHitSounds = 13;
        public const int maxNPCKilledSounds = 19;
        public const int maxLiquidTypes = 12;
        public const int maxMusic = 33;
        public const double dayLength = 54000.0;
        public const double nightLength = 32400.0;
        public const int maxStars = 130;
        public const int maxStarTypes = 5;
        public const int maxClouds = 200;
        public const int maxCloudTypes = 22;
        public const int maxHair = 123;
        public const int maxCharSelectHair = 51;
    }
}
