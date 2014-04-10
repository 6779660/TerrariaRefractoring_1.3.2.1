using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace Terraria.Terraria.Entities
{    

    public class PlayerStates
    {
        private Player player;
         
        public bool test;

        public PlayerStates(Player Ref)
        {
            
        }
    }
    public class Player : EntityBase
    {
        public const int maxBuffs = 22;
        public static int manaSickTime = 300;
        public static int manaSickTimeMax = 600;
        public static float manaSickLessDmg = 0.25f;
        /*
         * Loading values
         */
        public int loadStatus;
        public string name = "";
        public byte difficulty;
        public int hair;
        public byte hairDye;
        public BitsByte hideVisual = 0;
        public bool male = true;
        public int statLifeMax = 100;
        public int statLife = 100;
        public int statMana;
        public int statManaMax;
        public Color hairColor = new Color(215, 90, 55);
        public Color skinColor = new Color(255, 125, 90);
        public Color eyeColor = new Color(105, 90, 75);
        public Color shirtColor = new Color(175, 165, 140);
        public Color underShirtColor = new Color(160, 180, 215);
        public Color pantsColor = new Color(255, 230, 175);
        public Color shoeColor = new Color(160, 105, 60);
        public Item[] armor = new Item[16];
        public Item[] dye = new Item[8];
        public Item[] inventory = new Item[59];
        public Chest bank = new Chest(true);
        public Chest bank2 = new Chest(true);
        public int[] buffType = new int[22];
        public int[] buffTime = new int[22];
        public int[] spX = new int[200];
        public int[] spY = new int[200];
        public string[] spN = new string[200];
        public int[] spI = new int[200];
        public bool hbLocked;
         
        //beetle Values
        public int beetleOrbs, beetleCountdown, beetleFrame, beetleFrameCounter;
        public float beetleCounter;
        public bool beetleDefense, beetleOffense, beetleBuff;
        public Vector2[] beetlePos = new Vector2[3], beetleVel = new Vector2[3];
        //Mana values
        public bool manaMagnet, netMana, netLife, manaSick;
        public int netManaTime, netLifeTime;
        public float manaSickReduction;
        //States values
        public bool sloping;
        public bool chilled;
        public bool frozen;
        public bool ichor;
        public bool teleporting;
        public bool outOfRange;
        public bool blackBelt;
        public bool sliding;
        public bool sandStorm;
        public bool crimsonRegen;
        public bool ghostHeal;
        public bool ghostHurt;
        public bool sticky;
        public bool slippy;
        public bool slippy2;
        public bool powerrun;
        public bool flapSound;
        public bool iceBarrier;
        public bool panic;
        public bool pulley;
        public bool iceSkate;
        public bool carpet;
        public bool canCarpet;
        public bool shadowDodge;
        public bool onHitDodge;
        public bool onHitRegen;
        public bool onHitPetal;
        public bool pygmy;
        public bool raven;
        public bool slime;
        public bool stairFall;
        public bool palladiumRegen;
        public bool ghost;
        public bool pvpDeath;
        public bool zoneDungeon;
        public bool zoneEvil;
        public bool zoneHoly;
        public bool zoneMeteor;
        public bool zoneJungle;
        public bool zoneSnow;
        public bool zoneBlood;
        public bool zoneCandle;
        public bool boneArmor;
        public bool frostArmor;
        public bool honey;
        public bool crystalLeaf;
        public bool paladinBuff;
        public bool paladinGive;
        //Items values
        public Vector2[] itemFlamePos = new Vector2[7];
        public int itemFlameCount;
        public float lifeSteal = 99999f;
        public float ghostDmg;
        public float teleportTime;
        public int teleportStyle;
        public int ropeCount;
        public int manaRegenBonus;
        public int manaRegenDelayBonus;
        public int dash;
        public int dashTime;
        public int dashDelay;
        public float accRunSpeed;
        public int gem = -1;
        public int gemCount;
        public byte meleeEnchant;
        public byte pulleyDir;
        
        public int pulleyFrame;
        public float pulleyFrameCounter;
        
        public int slideDir;
        public int launcherWait;
        
        public int spikedBoots;
        public int carpetFrame = -1;
        public float carpetFrameCounter;
       
        public int carpetTime;
        public int miscCounter;
       
        public byte iceBarrierFrame;
        public byte iceBarrierFrameCounter;
      
        public float shadowDodgeCount;
      

        
        public int petalTimer;
        public int shadowDodgeTimer;
        public int maxMinions = 1;
        public int numMinions;
        public float wingTime;
        public int wings;
        public int wingsLogic;
        public int wingTimeMax;
        public int wingFrame;
        public int wingFrameCounter;
       
        public int ghostFrame;
        public int ghostFrameCounter;
        public int miscTimer;

        
        public float townNPCs;
        public Vector2 position;
        public Vector2 oldPosition;
        public Vector2 velocity;
        public Vector2 oldVelocity;
        public double headFrameCounter;
        public double bodyFrameCounter;
        public double legFrameCounter;
        public int netSkip;
        public int oldSelectItem;
        public bool immune;
        public int immuneTime;
        public int immuneAlphaDirection;
        public int immuneAlpha;
        public int team;
        public static int nameLen = 20;
        private float maxRegenDelay;
        public string chatText = "";
        public int sign = -1;
        public bool editedChestName;
        public int chatShowTime;
        public int reuseDelay;
        public int aggro;
        public float activeNPCs;
        public bool mouseInterface;
        public bool lastMouseInterface;
        public int noThrow;
        public int changeItem = -1;
        public int selectedItem;
        
        
        public int itemAnimation;
        public int itemAnimationMax;
        public int itemTime;
        public int toolTime;
        public float itemRotation;
        public int itemWidth;
        public int itemHeight;
        public Vector2 itemLocation;
        public bool poundRelease;
        public float ghostFade;
        public float ghostDir = 1f;
        
        public bool[] buffImmune = new bool[104];
        public int heldProj = -1;
        public int breathCD;
        public int breathMax = 200;
        public int breath = 200;
        public int lavaCD;
        public int lavaMax;
        public int lavaTime;
        public bool socialShadow;
        public bool socialGhost;
        public bool armorSteath;
        public int stealthTimer;
        public float stealth = 1f;
        public string setBonus = "";
        
        
        public float headRotation;
        public float bodyRotation;
        public float legRotation;
        public Vector2 headPosition;
        public Vector2 bodyPosition;
        public Vector2 legPosition;
        public Vector2 headVelocity;
        public Vector2 bodyVelocity;
        public Vector2 legVelocity;
        public int nonTorch = -1;
        public float gfxOffY;
        public float stepSpeed = 1f;
        public static bool deadForGood = false;
        public bool dead;
        public int respawnTimer;
        
        public int attackCD;
        public int potionDelay;
        
        public bool wet;
        public byte wetCount;
        public bool lavaWet;
        public bool honeyWet;
        public HitTile hitTile;
        public int jump;
        public int head = -1;
        public int body = -1;
        public int legs = -1;
        public sbyte handon = -1;
        public sbyte handoff = -1;
        public sbyte back = -1;
        public sbyte front = -1;
        public sbyte shoe = -1;
        public sbyte waist = -1;
        public sbyte shield = -1;
        public sbyte neck = -1;
        public sbyte face = -1;
        public sbyte balloon = -1;
        
        public Rectangle headFrame;
        public Rectangle bodyFrame;
        public Rectangle legFrame;
        public Rectangle hairFrame;
        public bool controlLeft;
        public bool controlRight;
        public bool controlUp;
        public bool controlDown;
        public bool controlJump;
        public bool controlUseItem;
        public bool controlUseTile;
        public bool controlThrow;
        public bool controlInv;
        public bool controlHook;
        public bool controlTorch;
        public bool controlMap;
        public bool releaseJump;
        public bool releaseUp;
        public bool releaseUseItem;
        public bool releaseUseTile;
        public bool releaseInventory;
        public bool releaseHook;
        public bool releaseThrow;
        public bool releaseQuickMana;
        public bool releaseQuickHeal;
        public bool releaseLeft;
        public bool releaseRight;
        public bool mapZoomIn;
        public bool mapZoomOut;
        public bool mapAlphaUp;
        public bool mapAlphaDown;
        public bool mapFullScreen;
        public bool mapStyle;
        public bool releaseMapFullscreen;
        public bool releaseMapStyle;
        public int leftTimer;
        public int rightTimer;
        public bool delayUseItem;
        public bool active;
        public int width = 20;
        public int height = 42;
        public int direction = 1;
        public bool showItemIcon;
        public bool showItemIconR;
        public int showItemIcon2;
        public string showItemIconText = "";
        public int whoAmi;
        public int runSoundDelay;
        public float shadow;
        public float manaCost = 1f;
        public bool fireWalk;
        public Vector2[] shadowPos = new Vector2[3];
        public int shadowCount;
        public bool channel;
        public int step = -1;
        public int statDefense;
        public int statAttack;
        
        public int statManaMax2;
        public int lifeRegen;
        public int lifeRegenCount;
        public int lifeRegenTime;
        public int manaRegen;
        public int manaRegenCount;
        public int manaRegenDelay;
        public bool manaRegenBuff;
        public bool noKnockback;
        public bool spaceGun;
        public float gravDir = 1f;
        public bool ammoCost80;
        public bool ammoCost75;
        public int stickyBreak;
        public bool magicQuiver;
        public bool magmaStone;
        public bool lavaRose;
        public bool ammoBox;
        public bool chaosState;
        public bool lightOrb;
        public bool blueFairy;
        public bool redFairy;
        public bool greenFairy;
        public bool bunny;
        public bool turtle;
        public bool eater;
        public bool penguin;
        public bool puppy;
        public bool grinch;
        public bool wearsRobe;
        public int mount;
        public int mountFrame;
        public float mountFrameCounter;
        public int mountFlyTime;
        public bool blackCat;
        public bool spider;
        public bool squashling;
        public bool magicCuffs;
        public bool coldDash;
        public bool eyeSpring;
        public bool snowman;
        public bool scope;
        public bool dino;
        public bool skeletron;
        public bool hornet;
        public bool tiki;
        public bool parrot;
        public bool truffle;
        public bool sapling;
        public bool cSapling;
        public bool wisp;
        public bool lizard;
        public bool archery;
        public bool poisoned;
        public bool venom;
        public bool blind;
        public bool blackout;
        public bool frostBurn;
        public bool onFrostBurn;
        public bool burned;
        public bool suffocating;
        public byte suffocateDelay;
        public bool dripping;
        public bool onFire;
        public bool onFire2;
        public bool noItems;
        public bool wereWolf;
        public bool wolfAcc;
        public bool rulerAcc;
        public bool bleed;
        public bool confused;
        public bool accMerman;
        public bool merman;
        public bool brokenArmor;
        public bool silence;
        public bool slow;
        public bool gross;
        public bool tongued;
        public bool kbGlove;
        public bool starCloak;
        public bool longInvince;
        public bool pStone;
        public bool manaFlower;
        public int meleeCrit = 4;
        public int rangedCrit = 4;
        public int magicCrit = 4;
        public float meleeDamage = 1f;
        public float rangedDamage = 1f;
        public float bulletDamage = 1f;
        public float arrowDamage = 1f;
        public float rocketDamage = 1f;
        public float magicDamage = 1f;
        public float minionDamage = 1f;
        public float minionKB;
        public float meleeSpeed = 1f;
        public float moveSpeed = 1f;
        public float pickSpeed = 1f;
        public float wallSpeed = 1f;
        public float tileSpeed = 1f;
        public bool autoPaint;
        public int SpawnX = -1;
        public int SpawnY = -1;
        
        public static int tileRangeX = 5;
        public static int tileRangeY = 4;
        private static int tileTargetX;
        private static int tileTargetY;
        private static int jumpHeight = 15;
        private static float jumpSpeed = 5.01f;
        public bool adjWater;
        public bool adjHoney;
        public bool adjLava;
        public bool oldAdjWater;
        public bool oldAdjHoney;
        public bool oldAdjLava;
        public bool[] adjTile = new bool[314];
        public bool[] oldAdjTile = new bool[314];
        private static int defaultItemGrabRange = 38;
        private static float itemGrabSpeed = 0.45f;
        private static float itemGrabSpeedMax = 4f;
       
        public Color hairDyeColor = new Color(0, 0, 0, 0);
        public float hairDyeVar;
        
        
        public bool hostile;
        public int accCompass;
        public int accWatch;
        public int accDepthMeter;
        public bool discount;
        public bool coins;
        public bool accDivingHelm;
        public bool accFlipper;
        public bool doubleJump;
        public bool jumpAgain;
        public bool dJumpEffect;
        public bool doubleJump2;
        public bool jumpAgain2;
        public bool dJumpEffect2;
        public bool doubleJump3;
        public bool jumpAgain3;
        public bool dJumpEffect3;
        public bool doubleJump4;
        public bool jumpAgain4;
        public bool dJumpEffect4;
        public bool spawnMax;
        public int blockRange;
        public int[] grappling = new int[20];
        public int grapCount;
        public int rocketTime;
        public int rocketTimeMax = 7;
        public int rocketDelay;
        public int rocketDelay2;
        public bool rocketRelease;
        public bool rocketFrame;
        public int rocketBoots;
        public bool canRocket;
        public bool jumpBoost;
        public bool noFallDmg;
        public int swimTime;
        public bool killGuide;
        public bool killClothier;
        public bool lavaImmune;
        public bool gills;
        public bool slowFall;
        public bool findTreasure;
        public bool invis;
        public bool detectCreature;
        public bool nightVision;
        public bool enemySpawns;
        public bool thorns;
        public bool turtleArmor;
        public bool turtleThorns;
        public bool waterWalk;
        public bool waterWalk2;
        public bool gravControl;
        public bool gravControl2;
        public bool bee;
        public int chest = -1;
        public int chestX;
        public int chestY;
        public int talkNPC = -1;
        public int fallStart;
        public int slowCount;
        public int potionDelayTime = Item.potionDelay;

        public override void load(System.IO.BinaryReader Data)
        {
            
        }

        public override void save(System.IO.BinaryWriter Data)
        {
            throw new NotImplementedException();
        }
    }
}
