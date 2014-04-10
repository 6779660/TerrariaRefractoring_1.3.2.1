using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
namespace Terraria
{
	public class Player
	{
		public const int maxBuffs = 22;
		public int beetleOrbs;
		public float beetleCounter;
		public int beetleCountdown;
		public bool beetleDefense;
		public bool beetleOffense;
		public bool beetleBuff;
		public bool manaMagnet;
		public int netManaTime;
		public int netLifeTime;
		public bool netMana;
		public bool netLife;
		public Vector2[] beetlePos = new Vector2[3];
		public Vector2[] beetleVel = new Vector2[3];
		public int beetleFrame;
		public int beetleFrameCounter;
		public static int manaSickTime = 300;
		public static int manaSickTimeMax = 600;
		public static float manaSickLessDmg = 0.25f;
		public float manaSickReduction;
		public bool manaSick;
		public bool stairFall;
		public int loadStatus;
		public Vector2[] itemFlamePos = new Vector2[7];
		public int itemFlameCount;
		public bool outOfRange;
		public float lifeSteal = 99999f;
		public float ghostDmg;
		public bool teleporting;
		public float teleportTime;
		public int teleportStyle;
		public bool sloping;
		public bool chilled;
		public bool frozen;
		public bool ichor;
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
		public bool pulley;
		public int pulleyFrame;
		public float pulleyFrameCounter;
		public bool blackBelt;
		public bool sliding;
		public int slideDir;
		public int launcherWait;
		public bool iceSkate;
		public bool carpet;
		public int spikedBoots;
		public int carpetFrame = -1;
		public float carpetFrameCounter;
		public bool canCarpet;
		public int carpetTime;
		public int miscCounter;
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
		public byte iceBarrierFrame;
		public byte iceBarrierFrameCounter;
		public bool shadowDodge;
		public float shadowDodgeCount;
		public bool palladiumRegen;
		public bool onHitDodge;
		public bool onHitRegen;
		public bool onHitPetal;
		public int petalTimer;
		public int shadowDodgeTimer;
		public int maxMinions = 1;
		public int numMinions;
		public bool pygmy;
		public bool raven;
		public bool slime;
		public float wingTime;
		public int wings;
		public int wingsLogic;
		public int wingTimeMax;
		public int wingFrame;
		public int wingFrameCounter;
		public bool male = true;
		public bool ghost;
		public int ghostFrame;
		public int ghostFrameCounter;
		public int miscTimer;
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
		public bool hbLocked;
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
		public Item[] armor = new Item[16];
		public Item[] dye = new Item[8];
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
		public int[] buffType = new int[22];
		public int[] buffTime = new int[22];
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
		public Item[] inventory = new Item[59];
		public Chest bank = new Chest(true);
		public Chest bank2 = new Chest(true);
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
		public string name = "";
		public int attackCD;
		public int potionDelay;
		public byte difficulty;
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
		public BitsByte hideVisual = 0;
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
		public int statLifeMax = 100;
		public int statLife = 100;
		public int statMana;
		public int statManaMax;
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
		public int[] spX = new int[200];
		public int[] spY = new int[200];
		public string[] spN = new string[200];
		public int[] spI = new int[200];
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
		public byte hairDye;
		public Color hairDyeColor = new Color(0, 0, 0, 0);
		public float hairDyeVar;
		public Color hairColor = new Color(215, 90, 55);
		public Color skinColor = new Color(255, 125, 90);
		public Color eyeColor = new Color(105, 90, 75);
		public Color shirtColor = new Color(175, 165, 140);
		public Color underShirtColor = new Color(160, 180, 215);
		public Color pantsColor = new Color(255, 230, 175);
		public Color shoeColor = new Color(160, 105, 60);
		public int hair;
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
		public void HealEffect(int healAmount, bool broadcast = true)
		{
			CombatText.NewText(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height), new Color(100, 255, 100, 255), string.Concat(healAmount), false, false);
			if (broadcast && Main.netMode == 1 && this.whoAmi == Main.myPlayer)
			{
				NetMessage.SendData(35, -1, -1, "", this.whoAmi, (float)healAmount, 0f, 0f, 0);
			}
		}
		public void ManaEffect(int manaAmount)
		{
			CombatText.NewText(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height), new Color(100, 100, 255, 255), string.Concat(manaAmount), false, false);
			if (Main.netMode == 1 && this.whoAmi == Main.myPlayer)
			{
				NetMessage.SendData(43, -1, -1, "", this.whoAmi, (float)manaAmount, 0f, 0f, 0);
			}
		}
		public static byte FindClosest(Vector2 Position, int Width, int Height)
		{
			byte result = 0;
			for (int i = 0; i < 255; i++)
			{
				if (Main.player[i].active)
				{
					result = (byte)i;
					break;
				}
			}
			float num = -1f;
			for (int j = 0; j < 255; j++)
			{
				if (Main.player[j].active && !Main.player[j].dead)
				{
					float num2 = Math.Abs(Main.player[j].position.X + (float)(Main.player[j].width / 2) - (Position.X + (float)(Width / 2))) + Math.Abs(Main.player[j].position.Y + (float)(Main.player[j].height / 2) - (Position.Y + (float)(Height / 2)));
					if (num == -1f || num2 < num)
					{
						num = num2;
						result = (byte)j;
					}
				}
			}
			return result;
		}
		public void checkArmor()
		{
		}
		public void toggleInv()
		{
			if (Main.ingameOptionsWindow)
			{
				IngameOptions.Close();
				return;
			}
			if (this.talkNPC >= 0)
			{
				this.talkNPC = -1;
				Main.npcChatText = "";
				Main.PlaySound(11, -1, -1, 1);
				return;
			}
			if (this.sign >= 0)
			{
				this.sign = -1;
				Main.editSign = false;
				Main.npcChatText = "";
				Main.PlaySound(11, -1, -1, 1);
				return;
			}
			if (Main.clothesWindow)
			{
				Main.CancelClothesWindow();
				return;
			}
			if (!Main.playerInventory)
			{
				Recipe.FindRecipes();
				Main.playerInventory = true;
				Main.PlaySound(10, -1, -1, 1);
				return;
			}
			Main.playerInventory = false;
			Main.PlaySound(11, -1, -1, 1);
		}
		public void dropItemCheck()
		{
			if (!Main.playerInventory)
			{
				this.noThrow = 0;
			}
			if (this.noThrow > 0)
			{
				this.noThrow--;
			}
			if (!Main.craftGuide && Main.guideItem.type > 0)
			{
				int num = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, Main.guideItem.type, 1, false, 0, false);
				Main.guideItem.position = Main.item[num].position;
				Main.item[num] = Main.guideItem;
				Main.guideItem = new Item();
				if (Main.netMode == 0)
				{
					Main.item[num].noGrabDelay = 100;
				}
				Main.item[num].velocity.Y = -2f;
				Main.item[num].velocity.X = (float)(4 * this.direction) + this.velocity.X;
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", num, 0f, 0f, 0f, 0);
				}
			}
			if (!Main.reforge && Main.reforgeItem.type > 0)
			{
				int num2 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, Main.reforgeItem.type, 1, false, 0, false);
				Main.reforgeItem.position = Main.item[num2].position;
				Main.item[num2] = Main.reforgeItem;
				Main.reforgeItem = new Item();
				if (Main.netMode == 0)
				{
					Main.item[num2].noGrabDelay = 100;
				}
				Main.item[num2].velocity.Y = -2f;
				Main.item[num2].velocity.X = (float)(4 * this.direction) + this.velocity.X;
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", num2, 0f, 0f, 0f, 0);
				}
			}
			if (Main.myPlayer == this.whoAmi)
			{
				this.inventory[58] = Main.mouseItem.Clone();
			}
			bool flag = true;
			if (Main.mouseItem.type > 0 && Main.mouseItem.stack > 0 && !Main.gamePaused)
			{
				Player.tileTargetX = (int)(((float)Main.mouseX + Main.screenPosition.X) / 16f);
				Player.tileTargetY = (int)(((float)Main.mouseY + Main.screenPosition.Y) / 16f);
				if (this.gravDir == -1f)
				{
					Player.tileTargetY = (int)((Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY) / 16f);
				}
				if (this.selectedItem != 58)
				{
					this.oldSelectItem = this.selectedItem;
				}
				this.selectedItem = 58;
				flag = false;
			}
			if (flag && this.selectedItem == 58)
			{
				this.selectedItem = this.oldSelectItem;
			}
			if (((this.controlThrow && this.releaseThrow && this.inventory[this.selectedItem].type > 0 && !Main.chatMode) || (((Main.mouseRight && !this.mouseInterface && Main.mouseRightRelease) || !Main.playerInventory) && Main.mouseItem.type > 0 && Main.mouseItem.stack > 0)) && this.noThrow <= 0)
			{
				Item item = new Item();
				bool flag2 = false;
				if (((Main.mouseRight && !this.mouseInterface && Main.mouseRightRelease) || !Main.playerInventory) && Main.mouseItem.type > 0 && Main.mouseItem.stack > 0)
				{
					item = this.inventory[this.selectedItem];
					this.inventory[this.selectedItem] = Main.mouseItem;
					this.delayUseItem = true;
					this.controlUseItem = false;
					flag2 = true;
				}
				int num3 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, this.inventory[this.selectedItem].type, 1, false, 0, false);
				if (!flag2 && this.inventory[this.selectedItem].type == 8 && this.inventory[this.selectedItem].stack > 1)
				{
					this.inventory[this.selectedItem].stack--;
				}
				else
				{
					this.inventory[this.selectedItem].position = Main.item[num3].position;
					Main.item[num3] = this.inventory[this.selectedItem];
					this.inventory[this.selectedItem] = new Item();
				}
				if (Main.netMode == 0)
				{
					Main.item[num3].noGrabDelay = 100;
				}
				Main.item[num3].velocity.Y = -2f;
				Main.item[num3].velocity.X = (float)(4 * this.direction) + this.velocity.X;
				if (((Main.mouseRight && !this.mouseInterface) || !Main.playerInventory) && Main.mouseItem.type > 0)
				{
					this.inventory[this.selectedItem] = item;
					Main.mouseItem = new Item();
				}
				else
				{
					this.itemAnimation = 10;
					this.itemAnimationMax = 10;
				}
				Recipe.FindRecipes();
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", num3, 0f, 0f, 0f, 0);
				}
			}
		}
		public void AddBuff(int type, int time, bool quiet = true)
		{
			if (this.buffImmune[type])
			{
				return;
			}
			if (!quiet && Main.netMode == 1)
			{
				bool flag = true;
				for (int i = 0; i < 22; i++)
				{
					if (this.buffType[i] == type)
					{
						flag = false;
					}
				}
				if (flag)
				{
					NetMessage.SendData(55, -1, -1, "", this.whoAmi, (float)type, (float)time, 0f, 0);
				}
			}
			int num = -1;
			for (int j = 0; j < 22; j++)
			{
				if (this.buffType[j] == type)
				{
					if (type == 94)
					{
						this.buffTime[j] += time;
						if (this.buffTime[j] > Player.manaSickTimeMax)
						{
							this.buffTime[j] = Player.manaSickTimeMax;
							return;
						}
					}
					else
					{
						if (this.buffTime[j] < time)
						{
							this.buffTime[j] = time;
						}
					}
					return;
				}
			}
			if (Main.vanityPet[type] || Main.lightPet[type])
			{
				for (int k = 0; k < 22; k++)
				{
					if (Main.vanityPet[type] && Main.vanityPet[this.buffType[k]])
					{
						this.DelBuff(k);
					}
					if (Main.lightPet[type] && Main.lightPet[this.buffType[k]])
					{
						this.DelBuff(k);
					}
				}
			}
			while (num == -1)
			{
				int num2 = -1;
				for (int l = 0; l < 22; l++)
				{
					if (!Main.debuff[this.buffType[l]])
					{
						num2 = l;
						break;
					}
				}
				if (num2 == -1)
				{
					return;
				}
				for (int m = num2; m < 22; m++)
				{
					if (this.buffType[m] == 0)
					{
						num = m;
						break;
					}
				}
				if (num == -1)
				{
					this.DelBuff(num2);
				}
			}
			this.buffType[num] = type;
			this.buffTime[num] = time;
			if (Main.meleeBuff[type])
			{
				for (int n = 0; n < 22; n++)
				{
					if (n != num && Main.meleeBuff[this.buffType[n]])
					{
						this.DelBuff(n);
					}
				}
			}
		}
		public void DelBuff(int b)
		{
			this.buffTime[b] = 0;
			this.buffType[b] = 0;
			for (int i = 0; i < 21; i++)
			{
				if (this.buffTime[i] == 0 || this.buffType[i] == 0)
				{
					for (int j = i + 1; j < 22; j++)
					{
						this.buffTime[j - 1] = this.buffTime[j];
						this.buffType[j - 1] = this.buffType[j];
						this.buffTime[j] = 0;
						this.buffType[j] = 0;
					}
				}
			}
		}
		public void QuickHeal()
		{
			if (this.noItems)
			{
				return;
			}
			if (this.statLife == this.statLifeMax || this.potionDelay > 0)
			{
				return;
			}
			for (int i = 0; i < 58; i++)
			{
				if (this.inventory[i].stack > 0 && this.inventory[i].type > 0 && this.inventory[i].potion && this.inventory[i].healLife > 0)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, this.inventory[i].useSound);
					if (this.inventory[i].potion)
					{
						this.potionDelay = this.potionDelayTime;
						this.AddBuff(21, this.potionDelay, true);
					}
					this.statLife += this.inventory[i].healLife;
					this.statMana += this.inventory[i].healMana;
					if (this.statLife > this.statLifeMax)
					{
						this.statLife = this.statLifeMax;
					}
					if (this.statMana > this.statManaMax2)
					{
						this.statMana = this.statManaMax2;
					}
					if (this.inventory[i].healLife > 0 && Main.myPlayer == this.whoAmi)
					{
						this.HealEffect(this.inventory[i].healLife, true);
					}
					if (this.inventory[i].healMana > 0 && Main.myPlayer == this.whoAmi)
					{
						this.ManaEffect(this.inventory[i].healMana);
					}
					this.inventory[i].stack--;
					if (this.inventory[i].stack <= 0)
					{
						this.inventory[i].type = 0;
						this.inventory[i].name = "";
					}
					Recipe.FindRecipes();
					return;
				}
			}
		}
		public void QuickMana()
		{
			if (this.noItems)
			{
				return;
			}
			if (this.statMana == this.statManaMax2)
			{
				return;
			}
			for (int i = 0; i < 58; i++)
			{
				if (this.inventory[i].stack > 0 && this.inventory[i].type > 0 && this.inventory[i].healMana > 0 && (this.potionDelay == 0 || !this.inventory[i].potion))
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, this.inventory[i].useSound);
					if (this.inventory[i].potion)
					{
						this.potionDelay = this.potionDelayTime;
						this.AddBuff(21, this.potionDelay, true);
					}
					this.statLife += this.inventory[i].healLife;
					this.statMana += this.inventory[i].healMana;
					if (this.statLife > this.statLifeMax)
					{
						this.statLife = this.statLifeMax;
					}
					if (this.statMana > this.statManaMax2)
					{
						this.statMana = this.statManaMax2;
					}
					if (this.inventory[i].healLife > 0 && Main.myPlayer == this.whoAmi)
					{
						this.HealEffect(this.inventory[i].healLife, true);
					}
					if (this.inventory[i].healMana > 0)
					{
						this.AddBuff(94, Player.manaSickTime, true);
						if (Main.myPlayer == this.whoAmi)
						{
							this.ManaEffect(this.inventory[i].healMana);
						}
					}
					this.inventory[i].stack--;
					if (this.inventory[i].stack <= 0)
					{
						this.inventory[i].type = 0;
						this.inventory[i].name = "";
					}
					Recipe.FindRecipes();
					return;
				}
			}
		}
		public int countBuffs()
		{
			int num = 0;
			for (int i = 0; i < 22; i++)
			{
				if (this.buffType[num] > 0)
				{
					num++;
				}
			}
			return num;
		}
		public void QuickBuff()
		{
			if (this.noItems)
			{
				return;
			}
			int num = 0;
			for (int i = 0; i < 58; i++)
			{
				if (this.countBuffs() == 22)
				{
					return;
				}
				if (this.inventory[i].stack > 0 && this.inventory[i].type > 0 && this.inventory[i].buffType > 0 && !this.inventory[i].summon && this.inventory[i].buffType != 90)
				{
					int num2 = this.inventory[i].buffType;
					bool flag = true;
					for (int j = 0; j < 22; j++)
					{
						if (num2 == 27 && (this.buffType[j] == num2 || this.buffType[j] == 101 || this.buffType[j] == 102))
						{
							flag = false;
							break;
						}
						if (this.buffType[j] == num2)
						{
							flag = false;
							break;
						}
						if (Main.meleeBuff[num2] && Main.meleeBuff[this.buffType[j]])
						{
							flag = false;
							break;
						}
					}
					if (Main.lightPet[this.inventory[i].buffType] || Main.vanityPet[this.inventory[i].buffType])
					{
						for (int k = 0; k < 22; k++)
						{
							if (Main.lightPet[this.buffType[k]] && Main.lightPet[this.inventory[i].buffType])
							{
								flag = false;
							}
							if (Main.vanityPet[this.buffType[k]] && Main.vanityPet[this.inventory[i].buffType])
							{
								flag = false;
							}
						}
					}
					if (this.inventory[i].mana > 0 && flag)
					{
						if (this.statMana >= (int)((float)this.inventory[i].mana * this.manaCost))
						{
							this.manaRegenDelay = (int)this.maxRegenDelay;
							this.statMana -= (int)((float)this.inventory[i].mana * this.manaCost);
						}
						else
						{
							flag = false;
						}
					}
					if (this.whoAmi == Main.myPlayer && this.inventory[i].type == 603 && !Main.cEd)
					{
						flag = false;
					}
					if (num2 == 27)
					{
						num2 = Main.rand.Next(3);
						if (num2 == 0)
						{
							num2 = 27;
						}
						if (num2 == 1)
						{
							num2 = 101;
						}
						if (num2 == 2)
						{
							num2 = 102;
						}
					}
					if (flag)
					{
						num = this.inventory[i].useSound;
						int num3 = this.inventory[i].buffTime;
						if (num3 == 0)
						{
							num3 = 3600;
						}
						this.AddBuff(num2, num3, true);
						if (this.inventory[i].consumable)
						{
							this.inventory[i].stack--;
							if (this.inventory[i].stack <= 0)
							{
								this.inventory[i].type = 0;
								this.inventory[i].name = "";
							}
						}
					}
				}
			}
			if (num > 0)
			{
				Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, num);
				Recipe.FindRecipes();
			}
		}
		public void StatusNPC(int type, int i)
		{
			if (this.meleeEnchant > 0)
			{
				if (this.meleeEnchant == 1)
				{
					Main.npc[i].AddBuff(70, 60 * Main.rand.Next(5, 10), false);
				}
				if (this.meleeEnchant == 2)
				{
					Main.npc[i].AddBuff(39, 60 * Main.rand.Next(3, 7), false);
				}
				if (this.meleeEnchant == 3)
				{
					Main.npc[i].AddBuff(24, 60 * Main.rand.Next(3, 7), false);
				}
				if (this.meleeEnchant == 5)
				{
					Main.npc[i].AddBuff(69, 60 * Main.rand.Next(10, 20), false);
				}
				if (this.meleeEnchant == 6)
				{
					Main.npc[i].AddBuff(31, 60 * Main.rand.Next(1, 4), false);
				}
				if (this.meleeEnchant == 8)
				{
					Main.npc[i].AddBuff(20, 60 * Main.rand.Next(5, 10), false);
				}
				if (this.meleeEnchant == 4)
				{
					Main.npc[i].AddBuff(69, 120, false);
				}
			}
			if (this.frostBurn)
			{
				Main.npc[i].AddBuff(44, 60 * Main.rand.Next(5, 15), false);
			}
			if (this.magmaStone)
			{
				if (Main.rand.Next(7) == 0)
				{
					Main.npc[i].AddBuff(24, 360, false);
				}
				else
				{
					if (Main.rand.Next(3) == 0)
					{
						Main.npc[i].AddBuff(24, 120, false);
					}
					else
					{
						Main.npc[i].AddBuff(24, 60, false);
					}
				}
			}
			if (type == 121)
			{
				if (Main.rand.Next(2) == 0)
				{
					Main.npc[i].AddBuff(24, 180, false);
					return;
				}
			}
			else
			{
				if (type == 122)
				{
					if (Main.rand.Next(10) == 0)
					{
						Main.npc[i].AddBuff(24, 180, false);
						return;
					}
				}
				else
				{
					if (type == 190)
					{
						if (Main.rand.Next(4) == 0)
						{
							Main.npc[i].AddBuff(20, 420, false);
							return;
						}
					}
					else
					{
						if (type == 217)
						{
							if (Main.rand.Next(5) == 0)
							{
								Main.npc[i].AddBuff(24, 180, false);
								return;
							}
						}
						else
						{
							if (type == 1123 && Main.rand.Next(10) != 0)
							{
								Main.npc[i].AddBuff(31, 120, false);
							}
						}
					}
				}
			}
		}
		public void StatusPvP(int type, int i)
		{
			if (this.meleeEnchant > 0)
			{
				if (this.meleeEnchant == 1)
				{
					Main.player[i].AddBuff(70, 60 * Main.rand.Next(5, 10), true);
				}
				if (this.meleeEnchant == 2)
				{
					Main.player[i].AddBuff(39, 60 * Main.rand.Next(3, 7), true);
				}
				if (this.meleeEnchant == 3)
				{
					Main.player[i].AddBuff(24, 60 * Main.rand.Next(3, 7), true);
				}
				if (this.meleeEnchant == 5)
				{
					Main.player[i].AddBuff(69, 60 * Main.rand.Next(10, 20), true);
				}
				if (this.meleeEnchant == 6)
				{
					Main.player[i].AddBuff(31, 60 * Main.rand.Next(1, 4), true);
				}
				if (this.meleeEnchant == 8)
				{
					Main.player[i].AddBuff(20, 60 * Main.rand.Next(5, 10), true);
				}
			}
			if (this.frostBurn)
			{
				Main.player[i].AddBuff(44, 60 * Main.rand.Next(1, 8), true);
			}
			if (this.magmaStone)
			{
				if (Main.rand.Next(7) == 0)
				{
					Main.player[i].AddBuff(24, 360, true);
				}
				else
				{
					if (Main.rand.Next(3) == 0)
					{
						Main.player[i].AddBuff(24, 120, true);
					}
					else
					{
						Main.player[i].AddBuff(24, 60, true);
					}
				}
			}
			if (type == 121)
			{
				if (Main.rand.Next(2) == 0)
				{
					Main.player[i].AddBuff(24, 180, false);
					return;
				}
			}
			else
			{
				if (type == 122)
				{
					if (Main.rand.Next(10) == 0)
					{
						Main.player[i].AddBuff(24, 180, false);
						return;
					}
				}
				else
				{
					if (type == 190)
					{
						if (Main.rand.Next(4) == 0)
						{
							Main.player[i].AddBuff(20, 420, false);
							return;
						}
					}
					else
					{
						if (type == 217)
						{
							if (Main.rand.Next(5) == 0)
							{
								Main.player[i].AddBuff(24, 180, false);
								return;
							}
						}
						else
						{
							if (type == 1123 && Main.rand.Next(9) != 0)
							{
								Main.player[i].AddBuff(31, 120, false);
							}
						}
					}
				}
			}
		}
		public void Ghost()
		{
			this.immune = false;
			this.immuneAlpha = 0;
			this.controlUp = false;
			this.controlLeft = false;
			this.controlDown = false;
			this.controlRight = false;
			this.controlJump = false;
			if (Main.hasFocus && !Main.chatMode && !Main.editSign && !Main.editChest && !Main.blockInput)
			{
				Keys[] pressedKeys = Main.keyState.GetPressedKeys();
				if (Main.blockKey != Keys.None)
				{
					bool flag = false;
					for (int i = 0; i < pressedKeys.Length; i++)
					{
						if (pressedKeys[i] == Main.blockKey)
						{
							pressedKeys[i] = Keys.None;
							flag = true;
						}
					}
					if (!flag)
					{
						Main.blockKey = Keys.None;
					}
				}
				for (int j = 0; j < pressedKeys.Length; j++)
				{
					string a = string.Concat(pressedKeys[j]);
					if (a == Main.cUp)
					{
						this.controlUp = true;
					}
					if (a == Main.cLeft)
					{
						this.controlLeft = true;
					}
					if (a == Main.cDown)
					{
						this.controlDown = true;
					}
					if (a == Main.cRight)
					{
						this.controlRight = true;
					}
					if (a == Main.cJump)
					{
						this.controlJump = true;
					}
				}
			}
			if (this.controlUp || this.controlJump)
			{
				if (this.velocity.Y > 0f)
				{
					this.velocity.Y = this.velocity.Y * 0.9f;
				}
				this.velocity.Y = this.velocity.Y - 0.1f;
				if (this.velocity.Y < -3f)
				{
					this.velocity.Y = -3f;
				}
			}
			else
			{
				if (this.controlDown)
				{
					if (this.velocity.Y < 0f)
					{
						this.velocity.Y = this.velocity.Y * 0.9f;
					}
					this.velocity.Y = this.velocity.Y + 0.1f;
					if (this.velocity.Y > 3f)
					{
						this.velocity.Y = 3f;
					}
				}
				else
				{
					if ((double)this.velocity.Y < -0.1 || (double)this.velocity.Y > 0.1)
					{
						this.velocity.Y = this.velocity.Y * 0.9f;
					}
					else
					{
						this.velocity.Y = 0f;
					}
				}
			}
			if (this.controlLeft && !this.controlRight)
			{
				if (this.velocity.X > 0f)
				{
					this.velocity.X = this.velocity.X * 0.9f;
				}
				this.velocity.X = this.velocity.X - 0.1f;
				if (this.velocity.X < -3f)
				{
					this.velocity.X = -3f;
				}
			}
			else
			{
				if (this.controlRight && !this.controlLeft)
				{
					if (this.velocity.X < 0f)
					{
						this.velocity.X = this.velocity.X * 0.9f;
					}
					this.velocity.X = this.velocity.X + 0.1f;
					if (this.velocity.X > 3f)
					{
						this.velocity.X = 3f;
					}
				}
				else
				{
					if ((double)this.velocity.X < -0.1 || (double)this.velocity.X > 0.1)
					{
						this.velocity.X = this.velocity.X * 0.9f;
					}
					else
					{
						this.velocity.X = 0f;
					}
				}
			}
			this.position += this.velocity;
			this.ghostFrameCounter++;
			if (this.velocity.X < 0f)
			{
				this.direction = -1;
			}
			else
			{
				if (this.velocity.X > 0f)
				{
					this.direction = 1;
				}
			}
			if (this.ghostFrameCounter >= 8)
			{
				this.ghostFrameCounter = 0;
				this.ghostFrame++;
				if (this.ghostFrame >= 4)
				{
					this.ghostFrame = 0;
				}
			}
			if (this.position.X < Main.leftWorld + (float)(Lighting.offScreenTiles * 16) + 16f)
			{
				this.position.X = Main.leftWorld + (float)(Lighting.offScreenTiles * 16) + 16f;
				this.velocity.X = 0f;
			}
			if (this.position.X + (float)this.width > Main.rightWorld - (float)(Lighting.offScreenTiles * 16) - 32f)
			{
				this.position.X = Main.rightWorld - (float)(Lighting.offScreenTiles * 16) - 32f - (float)this.width;
				this.velocity.X = 0f;
			}
			if (this.position.Y < Main.topWorld + (float)(Lighting.offScreenTiles * 16) + 16f)
			{
				this.position.Y = Main.topWorld + (float)(Lighting.offScreenTiles * 16) + 16f;
				if ((double)this.velocity.Y < -0.1)
				{
					this.velocity.Y = -0.1f;
				}
			}
			if (this.position.Y > Main.bottomWorld - (float)(Lighting.offScreenTiles * 16) - 32f - (float)this.height)
			{
				this.position.Y = Main.bottomWorld - (float)(Lighting.offScreenTiles * 16) - 32f - (float)this.height;
				this.velocity.Y = 0f;
			}
		}
		public Vector2 Center()
		{
			return new Vector2(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2));
		}
		public void onHit(float x, float y)
		{
			if (Main.myPlayer != this.whoAmi)
			{
				return;
			}
			if (this.onHitDodge && this.shadowDodgeTimer == 0 && Main.rand.Next(4) == 0)
			{
				if (!this.shadowDodge)
				{
					this.shadowDodgeTimer = 1200;
				}
				this.AddBuff(59, 1200, true);
			}
			if (this.onHitRegen)
			{
				this.AddBuff(58, 300, true);
			}
			if (this.onHitPetal && this.petalTimer == 0)
			{
				this.petalTimer = 20;
				if (x < this.position.X + (float)(this.width / 2))
				{
				}
				int num = this.direction;
				float num2 = Main.screenPosition.X;
				if (num < 0)
				{
					num2 += (float)Main.screenWidth;
				}
				float num3 = Main.screenPosition.Y;
				num3 += (float)Main.rand.Next(Main.screenHeight);
				Vector2 vector = new Vector2(num2, num3);
				float num4 = x - vector.X;
				float num5 = y - vector.Y;
				num4 += (float)Main.rand.Next(-50, 51) * 0.1f;
				num5 += (float)Main.rand.Next(-50, 51) * 0.1f;
				int num6 = 24;
				float num7 = (float)Math.Sqrt((double)(num4 * num4 + num5 * num5));
				num7 = (float)num6 / num7;
				num4 *= num7;
				num5 *= num7;
				Projectile.NewProjectile(num2, num3, num4, num5, 221, 36, 0f, this.whoAmi, 0f, 0f);
			}
			if (this.crystalLeaf && this.petalTimer == 0)
			{
				int arg_1AA_0 = this.inventory[this.selectedItem].type;
				for (int i = 0; i < 1000; i++)
				{
					if (Main.projectile[i].owner == this.whoAmi && Main.projectile[i].type == 226)
					{
						this.petalTimer = 50;
						float num8 = 12f;
						Vector2 vector2 = new Vector2(Main.projectile[i].position.X + (float)this.width * 0.5f, Main.projectile[i].position.Y + (float)this.height * 0.5f);
						float num9 = x - vector2.X;
						float num10 = y - vector2.Y;
						float num11 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
						num11 = num8 / num11;
						num9 *= num11;
						num10 *= num11;
						Projectile.NewProjectile(Main.projectile[i].center().X - 4f, Main.projectile[i].center().Y, num9, num10, 227, 50, 5f, this.whoAmi, 0f, 0f);
						return;
					}
				}
			}
		}
		public void openPresent()
		{
			if (Main.rand.Next(15) == 0 && Main.hardMode)
			{
				int number = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 602, 1, false, 0, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number, 1f, 0f, 0f, 0);
					return;
				}
			}
			else
			{
				if (Main.rand.Next(400) == 0)
				{
					int number2 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1927, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number2, 1f, 0f, 0f, 0);
						return;
					}
				}
				else
				{
					if (Main.rand.Next(150) == 0)
					{
						int number3 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1870, 1, false, 0, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number3, 1f, 0f, 0f, 0);
						}
						number3 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 97, Main.rand.Next(30, 61), false, 0, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number3, 1f, 0f, 0f, 0);
							return;
						}
					}
					else
					{
						if (Main.rand.Next(150) == 0)
						{
							int number4 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1909, 1, false, 0, false);
							if (Main.netMode == 1)
							{
								NetMessage.SendData(21, -1, -1, "", number4, 1f, 0f, 0f, 0);
								return;
							}
						}
						else
						{
							if (Main.rand.Next(150) == 0)
							{
								int number5 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1917, 1, false, 0, false);
								if (Main.netMode == 1)
								{
									NetMessage.SendData(21, -1, -1, "", number5, 1f, 0f, 0f, 0);
									return;
								}
							}
							else
							{
								if (Main.rand.Next(150) == 0)
								{
									int number6 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1918, 1, false, 0, false);
									if (Main.netMode == 1)
									{
										NetMessage.SendData(21, -1, -1, "", number6, 1f, 0f, 0f, 0);
										return;
									}
								}
								else
								{
									if (Main.rand.Next(150) == 0)
									{
										int number7 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1921, 1, false, 0, false);
										if (Main.netMode == 1)
										{
											NetMessage.SendData(21, -1, -1, "", number7, 1f, 0f, 0f, 0);
											return;
										}
									}
									else
									{
										if (Main.rand.Next(300) == 0)
										{
											int number8 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1923, 1, false, 0, false);
											if (Main.netMode == 1)
											{
												NetMessage.SendData(21, -1, -1, "", number8, 1f, 0f, 0f, 0);
												return;
											}
										}
										else
										{
											if (Main.rand.Next(40) == 0)
											{
												int number9 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1907, 1, false, 0, false);
												if (Main.netMode == 1)
												{
													NetMessage.SendData(21, -1, -1, "", number9, 1f, 0f, 0f, 0);
													return;
												}
											}
											else
											{
												if (Main.rand.Next(10) == 0)
												{
													int number10 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1908, 1, false, 0, false);
													if (Main.netMode == 1)
													{
														NetMessage.SendData(21, -1, -1, "", number10, 1f, 0f, 0f, 0);
														return;
													}
												}
												else
												{
													if (Main.rand.Next(15) == 0)
													{
														int num = Main.rand.Next(5);
														if (num == 0)
														{
															int number11 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1932, 1, false, 0, false);
															if (Main.netMode == 1)
															{
																NetMessage.SendData(21, -1, -1, "", number11, 1f, 0f, 0f, 0);
															}
															number11 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1933, 1, false, 0, false);
															if (Main.netMode == 1)
															{
																NetMessage.SendData(21, -1, -1, "", number11, 1f, 0f, 0f, 0);
															}
															number11 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1934, 1, false, 0, false);
															if (Main.netMode == 1)
															{
																NetMessage.SendData(21, -1, -1, "", number11, 1f, 0f, 0f, 0);
																return;
															}
														}
														else
														{
															if (num == 1)
															{
																int number12 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1935, 1, false, 0, false);
																if (Main.netMode == 1)
																{
																	NetMessage.SendData(21, -1, -1, "", number12, 1f, 0f, 0f, 0);
																}
																number12 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1936, 1, false, 0, false);
																if (Main.netMode == 1)
																{
																	NetMessage.SendData(21, -1, -1, "", number12, 1f, 0f, 0f, 0);
																}
																number12 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1937, 1, false, 0, false);
																if (Main.netMode == 1)
																{
																	NetMessage.SendData(21, -1, -1, "", number12, 1f, 0f, 0f, 0);
																	return;
																}
															}
															else
															{
																if (num == 2)
																{
																	int number13 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1940, 1, false, 0, false);
																	if (Main.netMode == 1)
																	{
																		NetMessage.SendData(21, -1, -1, "", number13, 1f, 0f, 0f, 0);
																	}
																	number13 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1941, 1, false, 0, false);
																	if (Main.netMode == 1)
																	{
																		NetMessage.SendData(21, -1, -1, "", number13, 1f, 0f, 0f, 0);
																	}
																	number13 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1942, 1, false, 0, false);
																	if (Main.netMode == 1)
																	{
																		NetMessage.SendData(21, -1, -1, "", number13, 1f, 0f, 0f, 0);
																		return;
																	}
																}
																else
																{
																	if (num == 3)
																	{
																		int number14 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1938, 1, false, 0, false);
																		if (Main.netMode == 1)
																		{
																			NetMessage.SendData(21, -1, -1, "", number14, 1f, 0f, 0f, 0);
																			return;
																		}
																	}
																	else
																	{
																		if (num == 4)
																		{
																			int number15 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1939, 1, false, 0, false);
																			if (Main.netMode == 1)
																			{
																				NetMessage.SendData(21, -1, -1, "", number15, 1f, 0f, 0f, 0);
																				return;
																			}
																		}
																	}
																}
															}
														}
													}
													else
													{
														if (Main.rand.Next(7) == 0)
														{
															int num2 = Main.rand.Next(3);
															if (num2 == 0)
															{
																num2 = 1911;
															}
															if (num2 == 1)
															{
																num2 = 1919;
															}
															if (num2 == 2)
															{
																num2 = 1920;
															}
															int number16 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num2, 1, false, 0, false);
															if (Main.netMode == 1)
															{
																NetMessage.SendData(21, -1, -1, "", number16, 1f, 0f, 0f, 0);
																return;
															}
														}
														else
														{
															if (Main.rand.Next(8) == 0)
															{
																int number17 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1912, Main.rand.Next(1, 4), false, 0, false);
																if (Main.netMode == 1)
																{
																	NetMessage.SendData(21, -1, -1, "", number17, 1f, 0f, 0f, 0);
																	return;
																}
															}
															else
															{
																if (Main.rand.Next(9) == 0)
																{
																	int number18 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1913, Main.rand.Next(20, 41), false, 0, false);
																	if (Main.netMode == 1)
																	{
																		NetMessage.SendData(21, -1, -1, "", number18, 1f, 0f, 0f, 0);
																		return;
																	}
																}
																else
																{
																	int num3 = Main.rand.Next(3);
																	if (num3 == 0)
																	{
																		int number19 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1872, Main.rand.Next(20, 50), false, 0, false);
																		if (Main.netMode == 1)
																		{
																			NetMessage.SendData(21, -1, -1, "", number19, 1f, 0f, 0f, 0);
																			return;
																		}
																	}
																	else
																	{
																		if (num3 == 1)
																		{
																			int number20 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 586, Main.rand.Next(20, 50), false, 0, false);
																			if (Main.netMode == 1)
																			{
																				NetMessage.SendData(21, -1, -1, "", number20, 1f, 0f, 0f, 0);
																				return;
																			}
																		}
																		else
																		{
																			int number21 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 591, Main.rand.Next(20, 50), false, 0, false);
																			if (Main.netMode == 1)
																			{
																				NetMessage.SendData(21, -1, -1, "", number21, 1f, 0f, 0f, 0);
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
		public void openGoodieBag()
		{
			if (Main.rand.Next(150) == 0)
			{
				int number = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1810, 1, false, 0, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number, 1f, 0f, 0f, 0);
					return;
				}
			}
			else
			{
				if (Main.rand.Next(150) == 0)
				{
					int number2 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1800, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number2, 1f, 0f, 0f, 0);
						return;
					}
				}
				else
				{
					if (Main.rand.Next(3) == 1)
					{
						int number3 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1809, Main.rand.Next(10, 41), false, 0, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number3, 1f, 0f, 0f, 0);
							return;
						}
					}
					else
					{
						if (Main.rand.Next(10) == 0)
						{
							int number4 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, Main.rand.Next(1846, 1851), 1, false, 0, false);
							if (Main.netMode == 1)
							{
								NetMessage.SendData(21, -1, -1, "", number4, 1f, 0f, 0f, 0);
								return;
							}
						}
						else
						{
							int num = Main.rand.Next(19);
							if (num == 0)
							{
								int number5 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1749, 1, false, 0, false);
								if (Main.netMode == 1)
								{
									NetMessage.SendData(21, -1, -1, "", number5, 1f, 0f, 0f, 0);
								}
								number5 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1750, 1, false, 0, false);
								if (Main.netMode == 1)
								{
									NetMessage.SendData(21, -1, -1, "", number5, 1f, 0f, 0f, 0);
								}
								number5 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1751, 1, false, 0, false);
								if (Main.netMode == 1)
								{
									NetMessage.SendData(21, -1, -1, "", number5, 1f, 0f, 0f, 0);
									return;
								}
							}
							else
							{
								if (num == 1)
								{
									int number6 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1746, 1, false, 0, false);
									if (Main.netMode == 1)
									{
										NetMessage.SendData(21, -1, -1, "", number6, 1f, 0f, 0f, 0);
									}
									number6 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1747, 1, false, 0, false);
									if (Main.netMode == 1)
									{
										NetMessage.SendData(21, -1, -1, "", number6, 1f, 0f, 0f, 0);
									}
									number6 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1748, 1, false, 0, false);
									if (Main.netMode == 1)
									{
										NetMessage.SendData(21, -1, -1, "", number6, 1f, 0f, 0f, 0);
										return;
									}
								}
								else
								{
									if (num == 2)
									{
										int number7 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1752, 1, false, 0, false);
										if (Main.netMode == 1)
										{
											NetMessage.SendData(21, -1, -1, "", number7, 1f, 0f, 0f, 0);
										}
										number7 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1753, 1, false, 0, false);
										if (Main.netMode == 1)
										{
											NetMessage.SendData(21, -1, -1, "", number7, 1f, 0f, 0f, 0);
											return;
										}
									}
									else
									{
										if (num == 3)
										{
											int number8 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1767, 1, false, 0, false);
											if (Main.netMode == 1)
											{
												NetMessage.SendData(21, -1, -1, "", number8, 1f, 0f, 0f, 0);
											}
											number8 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1768, 1, false, 0, false);
											if (Main.netMode == 1)
											{
												NetMessage.SendData(21, -1, -1, "", number8, 1f, 0f, 0f, 0);
											}
											number8 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1769, 1, false, 0, false);
											if (Main.netMode == 1)
											{
												NetMessage.SendData(21, -1, -1, "", number8, 1f, 0f, 0f, 0);
												return;
											}
										}
										else
										{
											if (num == 4)
											{
												int number9 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1770, 1, false, 0, false);
												if (Main.netMode == 1)
												{
													NetMessage.SendData(21, -1, -1, "", number9, 1f, 0f, 0f, 0);
												}
												number9 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1771, 1, false, 0, false);
												if (Main.netMode == 1)
												{
													NetMessage.SendData(21, -1, -1, "", number9, 1f, 0f, 0f, 0);
													return;
												}
											}
											else
											{
												if (num == 5)
												{
													int number10 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1772, 1, false, 0, false);
													if (Main.netMode == 1)
													{
														NetMessage.SendData(21, -1, -1, "", number10, 1f, 0f, 0f, 0);
													}
													number10 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1773, 1, false, 0, false);
													if (Main.netMode == 1)
													{
														NetMessage.SendData(21, -1, -1, "", number10, 1f, 0f, 0f, 0);
														return;
													}
												}
												else
												{
													if (num == 6)
													{
														int number11 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1754, 1, false, 0, false);
														if (Main.netMode == 1)
														{
															NetMessage.SendData(21, -1, -1, "", number11, 1f, 0f, 0f, 0);
														}
														number11 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1755, 1, false, 0, false);
														if (Main.netMode == 1)
														{
															NetMessage.SendData(21, -1, -1, "", number11, 1f, 0f, 0f, 0);
														}
														number11 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1756, 1, false, 0, false);
														if (Main.netMode == 1)
														{
															NetMessage.SendData(21, -1, -1, "", number11, 1f, 0f, 0f, 0);
															return;
														}
													}
													else
													{
														if (num == 7)
														{
															int number12 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1757, 1, false, 0, false);
															if (Main.netMode == 1)
															{
																NetMessage.SendData(21, -1, -1, "", number12, 1f, 0f, 0f, 0);
															}
															number12 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1758, 1, false, 0, false);
															if (Main.netMode == 1)
															{
																NetMessage.SendData(21, -1, -1, "", number12, 1f, 0f, 0f, 0);
															}
															number12 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1759, 1, false, 0, false);
															if (Main.netMode == 1)
															{
																NetMessage.SendData(21, -1, -1, "", number12, 1f, 0f, 0f, 0);
																return;
															}
														}
														else
														{
															if (num == 8)
															{
																int number13 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1760, 1, false, 0, false);
																if (Main.netMode == 1)
																{
																	NetMessage.SendData(21, -1, -1, "", number13, 1f, 0f, 0f, 0);
																}
																number13 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1761, 1, false, 0, false);
																if (Main.netMode == 1)
																{
																	NetMessage.SendData(21, -1, -1, "", number13, 1f, 0f, 0f, 0);
																}
																number13 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1762, 1, false, 0, false);
																if (Main.netMode == 1)
																{
																	NetMessage.SendData(21, -1, -1, "", number13, 1f, 0f, 0f, 0);
																	return;
																}
															}
															else
															{
																if (num == 9)
																{
																	int number14 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1763, 1, false, 0, false);
																	if (Main.netMode == 1)
																	{
																		NetMessage.SendData(21, -1, -1, "", number14, 1f, 0f, 0f, 0);
																	}
																	number14 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1764, 1, false, 0, false);
																	if (Main.netMode == 1)
																	{
																		NetMessage.SendData(21, -1, -1, "", number14, 1f, 0f, 0f, 0);
																	}
																	number14 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1765, 1, false, 0, false);
																	if (Main.netMode == 1)
																	{
																		NetMessage.SendData(21, -1, -1, "", number14, 1f, 0f, 0f, 0);
																		return;
																	}
																}
																else
																{
																	if (num == 10)
																	{
																		int number15 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1766, 1, false, 0, false);
																		if (Main.netMode == 1)
																		{
																			NetMessage.SendData(21, -1, -1, "", number15, 1f, 0f, 0f, 0);
																		}
																		number15 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1775, 1, false, 0, false);
																		if (Main.netMode == 1)
																		{
																			NetMessage.SendData(21, -1, -1, "", number15, 1f, 0f, 0f, 0);
																		}
																		number15 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1776, 1, false, 0, false);
																		if (Main.netMode == 1)
																		{
																			NetMessage.SendData(21, -1, -1, "", number15, 1f, 0f, 0f, 0);
																			return;
																		}
																	}
																	else
																	{
																		if (num == 11)
																		{
																			int number16 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1777, 1, false, 0, false);
																			if (Main.netMode == 1)
																			{
																				NetMessage.SendData(21, -1, -1, "", number16, 1f, 0f, 0f, 0);
																			}
																			number16 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1778, 1, false, 0, false);
																			if (Main.netMode == 1)
																			{
																				NetMessage.SendData(21, -1, -1, "", number16, 1f, 0f, 0f, 0);
																				return;
																			}
																		}
																		else
																		{
																			if (num == 12)
																			{
																				int number17 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1779, 1, false, 0, false);
																				if (Main.netMode == 1)
																				{
																					NetMessage.SendData(21, -1, -1, "", number17, 1f, 0f, 0f, 0);
																				}
																				number17 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1780, 1, false, 0, false);
																				if (Main.netMode == 1)
																				{
																					NetMessage.SendData(21, -1, -1, "", number17, 1f, 0f, 0f, 0);
																				}
																				number17 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1781, 1, false, 0, false);
																				if (Main.netMode == 1)
																				{
																					NetMessage.SendData(21, -1, -1, "", number17, 1f, 0f, 0f, 0);
																					return;
																				}
																			}
																			else
																			{
																				if (num == 13)
																				{
																					int number18 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1819, 1, false, 0, false);
																					if (Main.netMode == 1)
																					{
																						NetMessage.SendData(21, -1, -1, "", number18, 1f, 0f, 0f, 0);
																					}
																					number18 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1820, 1, false, 0, false);
																					if (Main.netMode == 1)
																					{
																						NetMessage.SendData(21, -1, -1, "", number18, 1f, 0f, 0f, 0);
																						return;
																					}
																				}
																				else
																				{
																					if (num == 14)
																					{
																						int number19 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1821, 1, false, 0, false);
																						if (Main.netMode == 1)
																						{
																							NetMessage.SendData(21, -1, -1, "", number19, 1f, 0f, 0f, 0);
																						}
																						number19 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1822, 1, false, 0, false);
																						if (Main.netMode == 1)
																						{
																							NetMessage.SendData(21, -1, -1, "", number19, 1f, 0f, 0f, 0);
																						}
																						number19 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1823, 1, false, 0, false);
																						if (Main.netMode == 1)
																						{
																							NetMessage.SendData(21, -1, -1, "", number19, 1f, 0f, 0f, 0);
																							return;
																						}
																					}
																					else
																					{
																						if (num == 15)
																						{
																							int number20 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1824, 1, false, 0, false);
																							if (Main.netMode == 1)
																							{
																								NetMessage.SendData(21, -1, -1, "", number20, 1f, 0f, 0f, 0);
																								return;
																							}
																						}
																						else
																						{
																							if (num == 16)
																							{
																								int number21 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1838, 1, false, 0, false);
																								if (Main.netMode == 1)
																								{
																									NetMessage.SendData(21, -1, -1, "", number21, 1f, 0f, 0f, 0);
																								}
																								number21 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1839, 1, false, 0, false);
																								if (Main.netMode == 1)
																								{
																									NetMessage.SendData(21, -1, -1, "", number21, 1f, 0f, 0f, 0);
																								}
																								number21 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1840, 1, false, 0, false);
																								if (Main.netMode == 1)
																								{
																									NetMessage.SendData(21, -1, -1, "", number21, 1f, 0f, 0f, 0);
																									return;
																								}
																							}
																							else
																							{
																								if (num == 17)
																								{
																									int number22 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1841, 1, false, 0, false);
																									if (Main.netMode == 1)
																									{
																										NetMessage.SendData(21, -1, -1, "", number22, 1f, 0f, 0f, 0);
																									}
																									number22 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1842, 1, false, 0, false);
																									if (Main.netMode == 1)
																									{
																										NetMessage.SendData(21, -1, -1, "", number22, 1f, 0f, 0f, 0);
																									}
																									number22 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1843, 1, false, 0, false);
																									if (Main.netMode == 1)
																									{
																										NetMessage.SendData(21, -1, -1, "", number22, 1f, 0f, 0f, 0);
																										return;
																									}
																								}
																								else
																								{
																									if (num == 18)
																									{
																										int number23 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1851, 1, false, 0, false);
																										if (Main.netMode == 1)
																										{
																											NetMessage.SendData(21, -1, -1, "", number23, 1f, 0f, 0f, 0);
																										}
																										number23 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1852, 1, false, 0, false);
																										if (Main.netMode == 1)
																										{
																											NetMessage.SendData(21, -1, -1, "", number23, 1f, 0f, 0f, 0);
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
		public void UpdatePlayerBuffs(int i)
		{
			for (int j = 0; j < 22; j++)
			{
				if (this.buffType[j] > 0 && this.buffTime[j] > 0)
				{
					if (this.whoAmi == Main.myPlayer && this.buffType[j] != 28)
					{
						this.buffTime[j]--;
					}
					if (this.buffType[j] == 1)
					{
						this.lavaImmune = true;
						this.fireWalk = true;
					}
					else
					{
						if (this.buffType[j] == 2)
						{
							this.lifeRegen += 2;
						}
						else
						{
							if (this.buffType[j] == 3)
							{
								this.moveSpeed += 0.25f;
							}
							else
							{
								if (this.buffType[j] == 4)
								{
									this.gills = true;
								}
								else
								{
									if (this.buffType[j] == 5)
									{
										this.statDefense += 8;
									}
									else
									{
										if (this.buffType[j] == 6)
										{
											this.manaRegenBuff = true;
										}
										else
										{
											if (this.buffType[j] == 7)
											{
												this.magicDamage += 0.2f;
											}
											else
											{
												if (this.buffType[j] == 8)
												{
													this.slowFall = true;
												}
												else
												{
													if (this.buffType[j] == 9)
													{
														this.findTreasure = true;
													}
													else
													{
														if (this.buffType[j] == 10)
														{
															this.invis = true;
														}
														else
														{
															if (this.buffType[j] == 11)
															{
																Lighting.addLight((int)(this.position.X + (float)(this.width / 2)) / 16, (int)(this.position.Y + (float)(this.height / 2)) / 16, 0.8f, 0.95f, 1f);
															}
															else
															{
																if (this.buffType[j] == 12)
																{
																	this.nightVision = true;
																}
																else
																{
																	if (this.buffType[j] == 13)
																	{
																		this.enemySpawns = true;
																	}
																	else
																	{
																		if (this.buffType[j] == 14)
																		{
																			this.thorns = true;
																		}
																		else
																		{
																			if (this.buffType[j] == 15)
																			{
																				this.waterWalk = true;
																			}
																			else
																			{
																				if (this.buffType[j] == 16)
																				{
																					this.archery = true;
																				}
																				else
																				{
																					if (this.buffType[j] == 17)
																					{
																						this.detectCreature = true;
																					}
																					else
																					{
																						if (this.buffType[j] == 18)
																						{
																							this.gravControl = true;
																						}
																						else
																						{
																							if (this.buffType[j] == 30)
																							{
																								this.bleed = true;
																							}
																							else
																							{
																								if (this.buffType[j] == 31)
																								{
																									this.confused = true;
																								}
																								else
																								{
																									if (this.buffType[j] == 32)
																									{
																										this.slow = true;
																									}
																									else
																									{
																										if (this.buffType[j] == 35)
																										{
																											this.silence = true;
																										}
																										else
																										{
																											if (this.buffType[j] == 46)
																											{
																												this.chilled = true;
																											}
																											else
																											{
																												if (this.buffType[j] == 47)
																												{
																													this.frozen = true;
																												}
																												else
																												{
																													if (this.buffType[j] == 69)
																													{
																														this.ichor = true;
																														this.statDefense -= 20;
																													}
																													else
																													{
																														if (this.buffType[j] == 36)
																														{
																															this.brokenArmor = true;
																														}
																														else
																														{
																															if (this.buffType[j] == 48)
																															{
																																this.honey = true;
																															}
																															else
																															{
																																if (this.buffType[j] == 59)
																																{
																																	this.shadowDodge = true;
																																}
																																else
																																{
																																	if (this.buffType[j] == 93)
																																	{
																																		this.ammoBox = true;
																																	}
																																	else
																																	{
																																		if (this.buffType[j] == 58)
																																		{
																																			this.palladiumRegen = true;
																																		}
																																		else
																																		{
																																			if (this.buffType[j] == 88)
																																			{
																																				this.chaosState = true;
																																			}
																																			else
																																			{
																																				if (this.buffType[j] == 63)
																																				{
																																					this.moveSpeed += 1f;
																																				}
																																				else
																																				{
																																					if (this.buffType[j] == 94)
																																					{
																																						this.manaSick = true;
																																						this.manaSickReduction = Player.manaSickLessDmg * ((float)this.buffTime[j] / (float)Player.manaSickTime);
																																					}
																																					else
																																					{
																																						if (this.buffType[j] >= 95 && this.buffType[j] <= 97)
																																						{
																																							this.buffTime[j] = 5;
																																							int num = (int)((byte)(1 + this.buffType[j] - 95));
																																							if (this.beetleOrbs > 0 && this.beetleOrbs != num)
																																							{
																																								if (this.beetleOrbs > num)
																																								{
																																									this.DelBuff(j);
																																								}
																																								else
																																								{
																																									for (int k = 0; k < 22; k++)
																																									{
																																										if (this.buffType[k] >= 95 && this.buffType[k] <= 95 + num - 1)
																																										{
																																											this.DelBuff(k);
																																										}
																																									}
																																								}
																																							}
																																							this.beetleOrbs = num;
																																							if (!this.beetleDefense)
																																							{
																																								this.beetleOrbs = 0;
																																								this.DelBuff(j);
																																							}
																																							else
																																							{
																																								this.beetleBuff = true;
																																							}
																																						}
																																						else
																																						{
																																							if (this.buffType[j] >= 98 && this.buffType[j] <= 100)
																																							{
																																								int num2 = (int)((byte)(1 + this.buffType[j] - 98));
																																								if (this.beetleOrbs > 0 && this.beetleOrbs != num2)
																																								{
																																									if (this.beetleOrbs > num2)
																																									{
																																										this.DelBuff(j);
																																									}
																																									else
																																									{
																																										for (int l = 0; l < 22; l++)
																																										{
																																											if (this.buffType[l] >= 98 && this.buffType[l] <= 98 + num2 - 1)
																																											{
																																												this.DelBuff(l);
																																											}
																																										}
																																									}
																																								}
																																								this.beetleOrbs = num2;
																																								this.meleeDamage += 0.1f * (float)this.beetleOrbs;
																																								this.meleeSpeed += 0.1f * (float)this.beetleOrbs;
																																								if (!this.beetleOffense)
																																								{
																																									this.beetleOrbs = 0;
																																									this.DelBuff(j);
																																								}
																																								else
																																								{
																																									this.beetleBuff = true;
																																								}
																																							}
																																							else
																																							{
																																								if (this.buffType[j] == 62)
																																								{
																																									if ((double)this.statLife <= (double)this.statLifeMax * 0.25)
																																									{
																																										Lighting.addLight((int)(this.Center().X / 16f), (int)(this.Center().Y / 16f), 0.1f, 0.2f, 0.45f);
																																										this.iceBarrier = true;
																																										this.statDefense += 30;
																																										this.iceBarrierFrameCounter += 1;
																																										if (this.iceBarrierFrameCounter > 2)
																																										{
																																											this.iceBarrierFrameCounter = 0;
																																											this.iceBarrierFrame += 1;
																																											if (this.iceBarrierFrame >= 12)
																																											{
																																												this.iceBarrierFrame = 0;
																																											}
																																										}
																																									}
																																									else
																																									{
																																										this.DelBuff(j);
																																									}
																																								}
																																								else
																																								{
																																									if (this.buffType[j] == 49)
																																									{
																																										if (Main.myPlayer == i)
																																										{
																																											for (int m = 0; m < 1000; m++)
																																											{
																																												if (Main.projectile[m].active && Main.projectile[m].owner == i && Main.projectile[m].type >= 191 && Main.projectile[m].type <= 194)
																																												{
																																													this.pygmy = true;
																																													break;
																																												}
																																											}
																																											if (!this.pygmy)
																																											{
																																												this.DelBuff(j);
																																											}
																																											else
																																											{
																																												this.buffTime[j] = 18000;
																																											}
																																										}
																																									}
																																									else
																																									{
																																										if (this.buffType[j] == 83)
																																										{
																																											if (Main.myPlayer == i)
																																											{
																																												for (int n = 0; n < 1000; n++)
																																												{
																																													if (Main.projectile[n].active && Main.projectile[n].owner == i && Main.projectile[n].type == 317)
																																													{
																																														this.raven = true;
																																														break;
																																													}
																																												}
																																												if (!this.raven)
																																												{
																																													this.DelBuff(j);
																																												}
																																												else
																																												{
																																													this.buffTime[j] = 18000;
																																												}
																																											}
																																										}
																																										else
																																										{
																																											if (this.buffType[j] == 64)
																																											{
																																												if (Main.myPlayer == i)
																																												{
																																													for (int num3 = 0; num3 < 1000; num3++)
																																													{
																																														if (Main.projectile[num3].active && Main.projectile[num3].owner == i && Main.projectile[num3].type == 266)
																																														{
																																															this.slime = true;
																																															break;
																																														}
																																													}
																																													if (!this.slime)
																																													{
																																														this.DelBuff(j);
																																													}
																																													else
																																													{
																																														this.buffTime[j] = 18000;
																																													}
																																												}
																																											}
																																											else
																																											{
																																												if (this.buffType[j] == 90)
																																												{
																																													this.mount = 1;
																																													this.buffTime[j] = 10;
																																												}
																																												else
																																												{
																																													if (this.buffType[j] == 37)
																																													{
																																														if (Main.wof >= 0 && Main.npc[Main.wof].type == 113)
																																														{
																																															this.gross = true;
																																															this.buffTime[j] = 10;
																																														}
																																														else
																																														{
																																															this.DelBuff(j);
																																														}
																																													}
																																													else
																																													{
																																														if (this.buffType[j] == 38)
																																														{
																																															this.buffTime[j] = 10;
																																															this.tongued = true;
																																														}
																																														else
																																														{
																																															if (this.buffType[j] == 19)
																																															{
																																																this.buffTime[j] = 18000;
																																																this.lightOrb = true;
																																																bool flag = true;
																																																for (int num4 = 0; num4 < 1000; num4++)
																																																{
																																																	if (Main.projectile[num4].active && Main.projectile[num4].owner == this.whoAmi && Main.projectile[num4].type == 18)
																																																	{
																																																		flag = false;
																																																	}
																																																}
																																																if (flag)
																																																{
																																																	Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 18, 0, 0f, this.whoAmi, 0f, 0f);
																																																}
																																															}
																																															else
																																															{
																																																if (this.buffType[j] == 27 || this.buffType[j] == 101 || this.buffType[j] == 102)
																																																{
																																																	this.buffTime[j] = 18000;
																																																	bool flag2 = true;
																																																	int num5 = 72;
																																																	if (this.buffType[j] == 27)
																																																	{
																																																		this.blueFairy = true;
																																																	}
																																																	if (this.buffType[j] == 101)
																																																	{
																																																		num5 = 86;
																																																		this.redFairy = true;
																																																	}
																																																	if (this.buffType[j] == 102)
																																																	{
																																																		num5 = 87;
																																																		this.greenFairy = true;
																																																	}
																																																	if (this.head == 45 && this.body == 26 && this.legs == 25)
																																																	{
																																																		num5 = 72;
																																																	}
																																																	for (int num6 = 0; num6 < 1000; num6++)
																																																	{
																																																		if (Main.projectile[num6].active && Main.projectile[num6].owner == this.whoAmi && Main.projectile[num6].type == num5)
																																																		{
																																																			flag2 = false;
																																																			break;
																																																		}
																																																	}
																																																	if (flag2)
																																																	{
																																																		Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, num5, 0, 0f, this.whoAmi, 0f, 0f);
																																																	}
																																																}
																																																else
																																																{
																																																	if (this.buffType[j] == 40)
																																																	{
																																																		this.buffTime[j] = 18000;
																																																		this.bunny = true;
																																																		bool flag3 = true;
																																																		for (int num7 = 0; num7 < 1000; num7++)
																																																		{
																																																			if (Main.projectile[num7].active && Main.projectile[num7].owner == this.whoAmi && Main.projectile[num7].type == 111)
																																																			{
																																																				flag3 = false;
																																																				break;
																																																			}
																																																		}
																																																		if (flag3)
																																																		{
																																																			Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 111, 0, 0f, this.whoAmi, 0f, 0f);
																																																		}
																																																	}
																																																	else
																																																	{
																																																		if (this.buffType[j] == 41)
																																																		{
																																																			this.buffTime[j] = 18000;
																																																			this.penguin = true;
																																																			bool flag4 = true;
																																																			for (int num8 = 0; num8 < 1000; num8++)
																																																			{
																																																				if (Main.projectile[num8].active && Main.projectile[num8].owner == this.whoAmi && Main.projectile[num8].type == 112)
																																																				{
																																																					flag4 = false;
																																																					break;
																																																				}
																																																			}
																																																			if (flag4)
																																																			{
																																																				Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 112, 0, 0f, this.whoAmi, 0f, 0f);
																																																			}
																																																		}
																																																		else
																																																		{
																																																			if (this.buffType[j] == 91)
																																																			{
																																																				this.buffTime[j] = 18000;
																																																				this.puppy = true;
																																																				bool flag5 = true;
																																																				for (int num9 = 0; num9 < 1000; num9++)
																																																				{
																																																					if (Main.projectile[num9].active && Main.projectile[num9].owner == this.whoAmi && Main.projectile[num9].type == 334)
																																																					{
																																																						flag5 = false;
																																																						break;
																																																					}
																																																				}
																																																				if (flag5)
																																																				{
																																																					Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 334, 0, 0f, this.whoAmi, 0f, 0f);
																																																				}
																																																			}
																																																			else
																																																			{
																																																				if (this.buffType[j] == 92)
																																																				{
																																																					this.buffTime[j] = 18000;
																																																					this.grinch = true;
																																																					bool flag6 = true;
																																																					for (int num10 = 0; num10 < 1000; num10++)
																																																					{
																																																						if (Main.projectile[num10].active && Main.projectile[num10].owner == this.whoAmi && Main.projectile[num10].type == 353)
																																																						{
																																																							flag6 = false;
																																																							break;
																																																						}
																																																					}
																																																					if (flag6)
																																																					{
																																																						Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 353, 0, 0f, this.whoAmi, 0f, 0f);
																																																					}
																																																				}
																																																				else
																																																				{
																																																					if (this.buffType[j] == 84)
																																																					{
																																																						this.buffTime[j] = 18000;
																																																						this.blackCat = true;
																																																						bool flag7 = true;
																																																						for (int num11 = 0; num11 < 1000; num11++)
																																																						{
																																																							if (Main.projectile[num11].active && Main.projectile[num11].owner == this.whoAmi && Main.projectile[num11].type == 319)
																																																							{
																																																								flag7 = false;
																																																								break;
																																																							}
																																																						}
																																																						if (flag7)
																																																						{
																																																							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 319, 0, 0f, this.whoAmi, 0f, 0f);
																																																						}
																																																					}
																																																					else
																																																					{
																																																						if (this.buffType[j] == 61)
																																																						{
																																																							this.buffTime[j] = 18000;
																																																							this.dino = true;
																																																							bool flag8 = true;
																																																							for (int num12 = 0; num12 < 1000; num12++)
																																																							{
																																																								if (Main.projectile[num12].active && Main.projectile[num12].owner == this.whoAmi && Main.projectile[num12].type == 236)
																																																								{
																																																									flag8 = false;
																																																									break;
																																																								}
																																																							}
																																																							if (flag8)
																																																							{
																																																								Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 236, 0, 0f, this.whoAmi, 0f, 0f);
																																																							}
																																																						}
																																																						else
																																																						{
																																																							if (this.buffType[j] == 65)
																																																							{
																																																								this.buffTime[j] = 18000;
																																																								this.eyeSpring = true;
																																																								bool flag9 = true;
																																																								for (int num13 = 0; num13 < 1000; num13++)
																																																								{
																																																									if (Main.projectile[num13].active && Main.projectile[num13].owner == this.whoAmi && Main.projectile[num13].type == 268)
																																																									{
																																																										flag9 = false;
																																																										break;
																																																									}
																																																								}
																																																								if (flag9)
																																																								{
																																																									Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 268, 0, 0f, this.whoAmi, 0f, 0f);
																																																								}
																																																							}
																																																							else
																																																							{
																																																								if (this.buffType[j] == 66)
																																																								{
																																																									this.buffTime[j] = 18000;
																																																									this.snowman = true;
																																																									bool flag10 = true;
																																																									for (int num14 = 0; num14 < 1000; num14++)
																																																									{
																																																										if (Main.projectile[num14].active && Main.projectile[num14].owner == this.whoAmi && Main.projectile[num14].type == 269)
																																																										{
																																																											flag10 = false;
																																																											break;
																																																										}
																																																									}
																																																									if (flag10)
																																																									{
																																																										Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 269, 0, 0f, this.whoAmi, 0f, 0f);
																																																									}
																																																								}
																																																								else
																																																								{
																																																									if (this.buffType[j] == 42)
																																																									{
																																																										this.buffTime[j] = 18000;
																																																										this.turtle = true;
																																																										bool flag11 = true;
																																																										for (int num15 = 0; num15 < 1000; num15++)
																																																										{
																																																											if (Main.projectile[num15].active && Main.projectile[num15].owner == this.whoAmi && Main.projectile[num15].type == 127)
																																																											{
																																																												flag11 = false;
																																																												break;
																																																											}
																																																										}
																																																										if (flag11)
																																																										{
																																																											Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 127, 0, 0f, this.whoAmi, 0f, 0f);
																																																										}
																																																									}
																																																									else
																																																									{
																																																										if (this.buffType[j] == 45)
																																																										{
																																																											this.buffTime[j] = 18000;
																																																											this.eater = true;
																																																											bool flag12 = true;
																																																											for (int num16 = 0; num16 < 1000; num16++)
																																																											{
																																																												if (Main.projectile[num16].active && Main.projectile[num16].owner == this.whoAmi && Main.projectile[num16].type == 175)
																																																												{
																																																													flag12 = false;
																																																													break;
																																																												}
																																																											}
																																																											if (flag12)
																																																											{
																																																												Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 175, 0, 0f, this.whoAmi, 0f, 0f);
																																																											}
																																																										}
																																																										else
																																																										{
																																																											if (this.buffType[j] == 50)
																																																											{
																																																												this.buffTime[j] = 18000;
																																																												this.skeletron = true;
																																																												bool flag13 = true;
																																																												for (int num17 = 0; num17 < 1000; num17++)
																																																												{
																																																													if (Main.projectile[num17].active && Main.projectile[num17].owner == this.whoAmi && Main.projectile[num17].type == 197)
																																																													{
																																																														flag13 = false;
																																																														break;
																																																													}
																																																												}
																																																												if (flag13)
																																																												{
																																																													Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 197, 0, 0f, this.whoAmi, 0f, 0f);
																																																												}
																																																											}
																																																											else
																																																											{
																																																												if (this.buffType[j] == 51)
																																																												{
																																																													this.buffTime[j] = 18000;
																																																													this.hornet = true;
																																																													bool flag14 = true;
																																																													for (int num18 = 0; num18 < 1000; num18++)
																																																													{
																																																														if (Main.projectile[num18].active && Main.projectile[num18].owner == this.whoAmi && Main.projectile[num18].type == 198)
																																																														{
																																																															flag14 = false;
																																																															break;
																																																														}
																																																													}
																																																													if (flag14)
																																																													{
																																																														Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 198, 0, 0f, this.whoAmi, 0f, 0f);
																																																													}
																																																												}
																																																												else
																																																												{
																																																													if (this.buffType[j] == 52)
																																																													{
																																																														this.buffTime[j] = 18000;
																																																														this.tiki = true;
																																																														bool flag15 = true;
																																																														for (int num19 = 0; num19 < 1000; num19++)
																																																														{
																																																															if (Main.projectile[num19].active && Main.projectile[num19].owner == this.whoAmi && Main.projectile[num19].type == 199)
																																																															{
																																																																flag15 = false;
																																																																break;
																																																															}
																																																														}
																																																														if (flag15)
																																																														{
																																																															Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 199, 0, 0f, this.whoAmi, 0f, 0f);
																																																														}
																																																													}
																																																													else
																																																													{
																																																														if (this.buffType[j] == 53)
																																																														{
																																																															this.buffTime[j] = 18000;
																																																															this.lizard = true;
																																																															bool flag16 = true;
																																																															for (int num20 = 0; num20 < 1000; num20++)
																																																															{
																																																																if (Main.projectile[num20].active && Main.projectile[num20].owner == this.whoAmi && Main.projectile[num20].type == 200)
																																																																{
																																																																	flag16 = false;
																																																																	break;
																																																																}
																																																															}
																																																															if (flag16)
																																																															{
																																																																Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 200, 0, 0f, this.whoAmi, 0f, 0f);
																																																															}
																																																														}
																																																														else
																																																														{
																																																															if (this.buffType[j] == 54)
																																																															{
																																																																this.buffTime[j] = 18000;
																																																																this.parrot = true;
																																																																bool flag17 = true;
																																																																for (int num21 = 0; num21 < 1000; num21++)
																																																																{
																																																																	if (Main.projectile[num21].active && Main.projectile[num21].owner == this.whoAmi && Main.projectile[num21].type == 208)
																																																																	{
																																																																		flag17 = false;
																																																																		break;
																																																																	}
																																																																}
																																																																if (flag17)
																																																																{
																																																																	Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 208, 0, 0f, this.whoAmi, 0f, 0f);
																																																																}
																																																															}
																																																															else
																																																															{
																																																																if (this.buffType[j] == 55)
																																																																{
																																																																	this.buffTime[j] = 18000;
																																																																	this.truffle = true;
																																																																	bool flag18 = true;
																																																																	for (int num22 = 0; num22 < 1000; num22++)
																																																																	{
																																																																		if (Main.projectile[num22].active && Main.projectile[num22].owner == this.whoAmi && Main.projectile[num22].type == 209)
																																																																		{
																																																																			flag18 = false;
																																																																			break;
																																																																		}
																																																																	}
																																																																	if (flag18)
																																																																	{
																																																																		Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 209, 0, 0f, this.whoAmi, 0f, 0f);
																																																																	}
																																																																}
																																																																else
																																																																{
																																																																	if (this.buffType[j] == 56)
																																																																	{
																																																																		this.buffTime[j] = 18000;
																																																																		this.sapling = true;
																																																																		bool flag19 = true;
																																																																		for (int num23 = 0; num23 < 1000; num23++)
																																																																		{
																																																																			if (Main.projectile[num23].active && Main.projectile[num23].owner == this.whoAmi && Main.projectile[num23].type == 210)
																																																																			{
																																																																				flag19 = false;
																																																																				break;
																																																																			}
																																																																		}
																																																																		if (flag19)
																																																																		{
																																																																			Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 210, 0, 0f, this.whoAmi, 0f, 0f);
																																																																		}
																																																																	}
																																																																	else
																																																																	{
																																																																		if (this.buffType[j] == 85)
																																																																		{
																																																																			this.buffTime[j] = 18000;
																																																																			this.cSapling = true;
																																																																			bool flag20 = true;
																																																																			for (int num24 = 0; num24 < 1000; num24++)
																																																																			{
																																																																				if (Main.projectile[num24].active && Main.projectile[num24].owner == this.whoAmi && Main.projectile[num24].type == 324)
																																																																				{
																																																																					flag20 = false;
																																																																					break;
																																																																				}
																																																																			}
																																																																			if (flag20)
																																																																			{
																																																																				Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 324, 0, 0f, this.whoAmi, 0f, 0f);
																																																																			}
																																																																		}
																																																																		else
																																																																		{
																																																																			if (this.buffType[j] == 81)
																																																																			{
																																																																				this.buffTime[j] = 18000;
																																																																				this.spider = true;
																																																																				bool flag21 = true;
																																																																				for (int num25 = 0; num25 < 1000; num25++)
																																																																				{
																																																																					if (Main.projectile[num25].active && Main.projectile[num25].owner == this.whoAmi && Main.projectile[num25].type == 313)
																																																																					{
																																																																						flag21 = false;
																																																																						break;
																																																																					}
																																																																				}
																																																																				if (flag21)
																																																																				{
																																																																					Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 313, 0, 0f, this.whoAmi, 0f, 0f);
																																																																				}
																																																																			}
																																																																			else
																																																																			{
																																																																				if (this.buffType[j] == 82)
																																																																				{
																																																																					this.buffTime[j] = 18000;
																																																																					this.squashling = true;
																																																																					bool flag22 = true;
																																																																					for (int num26 = 0; num26 < 1000; num26++)
																																																																					{
																																																																						if (Main.projectile[num26].active && Main.projectile[num26].owner == this.whoAmi && Main.projectile[num26].type == 314)
																																																																						{
																																																																							flag22 = false;
																																																																							break;
																																																																						}
																																																																					}
																																																																					if (flag22)
																																																																					{
																																																																						Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 314, 0, 0f, this.whoAmi, 0f, 0f);
																																																																					}
																																																																				}
																																																																				else
																																																																				{
																																																																					if (this.buffType[j] == 57)
																																																																					{
																																																																						this.buffTime[j] = 18000;
																																																																						this.wisp = true;
																																																																						bool flag23 = true;
																																																																						for (int num27 = 0; num27 < 1000; num27++)
																																																																						{
																																																																							if (Main.projectile[num27].active && Main.projectile[num27].owner == this.whoAmi && Main.projectile[num27].type == 211)
																																																																							{
																																																																								flag23 = false;
																																																																								break;
																																																																							}
																																																																						}
																																																																						if (flag23)
																																																																						{
																																																																							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 211, 0, 0f, this.whoAmi, 0f, 0f);
																																																																						}
																																																																					}
																																																																					else
																																																																					{
																																																																						if (this.buffType[j] == 60)
																																																																						{
																																																																							this.buffTime[j] = 18000;
																																																																							this.crystalLeaf = true;
																																																																							bool flag24 = true;
																																																																							for (int num28 = 0; num28 < 1000; num28++)
																																																																							{
																																																																								if (Main.projectile[num28].active && Main.projectile[num28].owner == this.whoAmi && Main.projectile[num28].type == 226)
																																																																								{
																																																																									if (!flag24)
																																																																									{
																																																																										Main.projectile[num28].Kill();
																																																																									}
																																																																									flag24 = false;
																																																																								}
																																																																							}
																																																																							if (flag24)
																																																																							{
																																																																								Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 226, 0, 0f, this.whoAmi, 0f, 0f);
																																																																							}
																																																																						}
																																																																						else
																																																																						{
																																																																							if (this.buffType[j] == 70)
																																																																							{
																																																																								this.venom = true;
																																																																							}
																																																																							else
																																																																							{
																																																																								if (this.buffType[j] == 20)
																																																																								{
																																																																									this.poisoned = true;
																																																																								}
																																																																								else
																																																																								{
																																																																									if (this.buffType[j] == 21)
																																																																									{
																																																																										this.potionDelay = this.buffTime[j];
																																																																									}
																																																																									else
																																																																									{
																																																																										if (this.buffType[j] == 22)
																																																																										{
																																																																											this.blind = true;
																																																																										}
																																																																										else
																																																																										{
																																																																											if (this.buffType[j] == 80)
																																																																											{
																																																																												this.blackout = true;
																																																																											}
																																																																											else
																																																																											{
																																																																												if (this.buffType[j] == 23)
																																																																												{
																																																																													this.noItems = true;
																																																																												}
																																																																												else
																																																																												{
																																																																													if (this.buffType[j] == 24)
																																																																													{
																																																																														this.onFire = true;
																																																																													}
																																																																													else
																																																																													{
																																																																														if (this.buffType[j] == 103)
																																																																														{
																																																																															this.dripping = true;
																																																																														}
																																																																														else
																																																																														{
																																																																															if (this.buffType[j] == 67)
																																																																															{
																																																																																this.burned = true;
																																																																															}
																																																																															else
																																																																															{
																																																																																if (this.buffType[j] == 68)
																																																																																{
																																																																																	this.suffocating = true;
																																																																																}
																																																																																else
																																																																																{
																																																																																	if (this.buffType[j] == 39)
																																																																																	{
																																																																																		this.onFire2 = true;
																																																																																	}
																																																																																	else
																																																																																	{
																																																																																		if (this.buffType[j] == 44)
																																																																																		{
																																																																																			this.onFrostBurn = true;
																																																																																		}
																																																																																		else
																																																																																		{
																																																																																			if (this.buffType[j] == 43)
																																																																																			{
																																																																																				this.paladinBuff = true;
																																																																																			}
																																																																																			else
																																																																																			{
																																																																																				if (this.buffType[j] == 29)
																																																																																				{
																																																																																					this.magicCrit += 2;
																																																																																					this.magicDamage += 0.05f;
																																																																																					this.statManaMax2 += 20;
																																																																																					this.manaCost -= 0.02f;
																																																																																				}
																																																																																				else
																																																																																				{
																																																																																					if (this.buffType[j] == 28)
																																																																																					{
																																																																																						if (!Main.dayTime && this.wolfAcc && !this.merman)
																																																																																						{
																																																																																							this.lifeRegen++;
																																																																																							this.wereWolf = true;
																																																																																							this.meleeCrit += 2;
																																																																																							this.meleeDamage += 0.051f;
																																																																																							this.meleeSpeed += 0.051f;
																																																																																							this.statDefense += 3;
																																																																																							this.moveSpeed += 0.05f;
																																																																																						}
																																																																																						else
																																																																																						{
																																																																																							this.DelBuff(j);
																																																																																						}
																																																																																					}
																																																																																					else
																																																																																					{
																																																																																						if (this.buffType[j] == 33)
																																																																																						{
																																																																																							this.meleeDamage -= 0.051f;
																																																																																							this.meleeSpeed -= 0.051f;
																																																																																							this.statDefense -= 4;
																																																																																							this.moveSpeed -= 0.1f;
																																																																																						}
																																																																																						else
																																																																																						{
																																																																																							if (this.buffType[j] == 25)
																																																																																							{
																																																																																								this.statDefense -= 4;
																																																																																								this.meleeCrit += 2;
																																																																																								this.meleeDamage += 0.1f;
																																																																																								this.meleeSpeed += 0.1f;
																																																																																							}
																																																																																							else
																																																																																							{
																																																																																								if (this.buffType[j] == 26)
																																																																																								{
																																																																																									this.statDefense += 2;
																																																																																									this.meleeCrit += 2;
																																																																																									this.meleeDamage += 0.05f;
																																																																																									this.meleeSpeed += 0.05f;
																																																																																									this.magicCrit += 2;
																																																																																									this.magicDamage += 0.05f;
																																																																																									this.rangedCrit += 2;
																																																																																									this.magicDamage += 0.05f;
																																																																																									this.minionDamage += 0.05f;
																																																																																									this.minionKB += 0.5f;
																																																																																									this.moveSpeed += 0.2f;
																																																																																								}
																																																																																								else
																																																																																								{
																																																																																									if (this.buffType[j] == 71)
																																																																																									{
																																																																																										this.meleeEnchant = 1;
																																																																																									}
																																																																																									else
																																																																																									{
																																																																																										if (this.buffType[j] == 73)
																																																																																										{
																																																																																											this.meleeEnchant = 2;
																																																																																										}
																																																																																										else
																																																																																										{
																																																																																											if (this.buffType[j] == 74)
																																																																																											{
																																																																																												this.meleeEnchant = 3;
																																																																																											}
																																																																																											else
																																																																																											{
																																																																																												if (this.buffType[j] == 75)
																																																																																												{
																																																																																													this.meleeEnchant = 4;
																																																																																												}
																																																																																												else
																																																																																												{
																																																																																													if (this.buffType[j] == 76)
																																																																																													{
																																																																																														this.meleeEnchant = 5;
																																																																																													}
																																																																																													else
																																																																																													{
																																																																																														if (this.buffType[j] == 77)
																																																																																														{
																																																																																															this.meleeEnchant = 6;
																																																																																														}
																																																																																														else
																																																																																														{
																																																																																															if (this.buffType[j] == 78)
																																																																																															{
																																																																																																this.meleeEnchant = 7;
																																																																																															}
																																																																																															else
																																																																																															{
																																																																																																if (this.buffType[j] == 79)
																																																																																																{
																																																																																																	this.meleeEnchant = 8;
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
		public void UpdatePlayerEquips(int i)
		{
			for (int j = 0; j < 8; j++)
			{
				this.statDefense += this.armor[j].defense;
				this.lifeRegen += this.armor[j].lifeRegen;
				if (this.armor[j].type == 268)
				{
					this.accDivingHelm = true;
				}
				if (this.armor[j].type == 238)
				{
					this.magicDamage += 0.15f;
				}
				if (this.armor[j].type == 2277)
				{
					this.magicDamage += 0.05f;
					this.meleeDamage += 0.05f;
					this.rangedDamage += 0.05f;
					this.magicCrit += 5;
					this.rangedCrit += 5;
					this.meleeCrit += 5;
					this.meleeSpeed += 0.1f;
					this.moveSpeed += 0.1f;
				}
				if (this.armor[j].type == 2279)
				{
					this.magicDamage += 0.06f;
					this.magicCrit += 6;
					this.manaCost -= 0.1f;
				}
				if (this.armor[j].type == 2275)
				{
					this.magicDamage += 0.07f;
					this.magicCrit += 7;
				}
				if (this.armor[j].type == 123 || this.armor[j].type == 124 || this.armor[j].type == 125)
				{
					this.magicDamage += 0.07f;
				}
				if (this.armor[j].type == 151 || this.armor[j].type == 152 || this.armor[j].type == 153 || this.armor[j].type == 959)
				{
					this.rangedDamage += 0.05f;
				}
				if (this.armor[j].type == 111 || this.armor[j].type == 228 || this.armor[j].type == 229 || this.armor[j].type == 230 || this.armor[j].type == 960 || this.armor[j].type == 961 || this.armor[j].type == 962)
				{
					this.statManaMax2 += 20;
				}
				if (this.armor[j].type == 228 || this.armor[j].type == 229 || this.armor[j].type == 230 || this.armor[j].type == 960 || this.armor[j].type == 961 || this.armor[j].type == 962)
				{
					this.magicCrit += 3;
				}
				if (this.armor[j].type == 100 || this.armor[j].type == 101 || this.armor[j].type == 102)
				{
					this.meleeSpeed += 0.07f;
				}
				if (this.armor[j].type == 956 || this.armor[j].type == 957 || this.armor[j].type == 958)
				{
					this.meleeSpeed += 0.07f;
				}
				if (this.armor[j].type == 791 || this.armor[j].type == 792 || this.armor[j].type == 793)
				{
					this.meleeDamage += 0.02f;
					this.rangedDamage += 0.02f;
					this.magicDamage += 0.02f;
				}
				if (this.armor[j].type == 371)
				{
					this.magicCrit += 9;
					this.statManaMax2 += 40;
				}
				if (this.armor[j].type == 372)
				{
					this.moveSpeed += 0.07f;
					this.meleeSpeed += 0.12f;
				}
				if (this.armor[j].type == 373)
				{
					this.rangedDamage += 0.1f;
					this.rangedCrit += 6;
				}
				if (this.armor[j].type == 374)
				{
					this.magicCrit += 3;
					this.meleeCrit += 3;
					this.rangedCrit += 3;
				}
				if (this.armor[j].type == 375)
				{
					this.moveSpeed += 0.1f;
				}
				if (this.armor[j].type == 376)
				{
					this.magicDamage += 0.15f;
					this.statManaMax2 += 60;
				}
				if (this.armor[j].type == 377)
				{
					this.meleeCrit += 5;
					this.meleeDamage += 0.1f;
				}
				if (this.armor[j].type == 378)
				{
					this.rangedDamage += 0.12f;
					this.rangedCrit += 7;
				}
				if (this.armor[j].type == 379)
				{
					this.rangedDamage += 0.05f;
					this.meleeDamage += 0.05f;
					this.magicDamage += 0.05f;
				}
				if (this.armor[j].type == 380)
				{
					this.magicCrit += 3;
					this.meleeCrit += 3;
					this.rangedCrit += 3;
				}
				if (this.armor[j].type == 400)
				{
					this.magicDamage += 0.11f;
					this.magicCrit += 11;
					this.statManaMax2 += 80;
				}
				if (this.armor[j].type == 401)
				{
					this.meleeCrit += 7;
					this.meleeDamage += 0.14f;
				}
				if (this.armor[j].type == 402)
				{
					this.rangedDamage += 0.14f;
					this.rangedCrit += 8;
				}
				if (this.armor[j].type == 403)
				{
					this.rangedDamage += 0.06f;
					this.meleeDamage += 0.06f;
					this.magicDamage += 0.06f;
				}
				if (this.armor[j].type == 404)
				{
					this.magicCrit += 4;
					this.meleeCrit += 4;
					this.rangedCrit += 4;
					this.moveSpeed += 0.05f;
				}
				if (this.armor[j].type == 1205)
				{
					this.meleeDamage += 0.08f;
					this.meleeSpeed += 0.12f;
				}
				if (this.armor[j].type == 1206)
				{
					this.rangedDamage += 0.09f;
					this.rangedCrit += 9;
				}
				if (this.armor[j].type == 1207)
				{
					this.magicDamage += 0.07f;
					this.magicCrit += 7;
					this.statManaMax2 += 60;
				}
				if (this.armor[j].type == 1208)
				{
					this.meleeDamage += 0.03f;
					this.rangedDamage += 0.03f;
					this.magicDamage += 0.03f;
					this.magicCrit += 2;
					this.meleeCrit += 2;
					this.rangedCrit += 2;
				}
				if (this.armor[j].type == 1209)
				{
					this.meleeDamage += 0.02f;
					this.rangedDamage += 0.02f;
					this.magicDamage += 0.02f;
					this.magicCrit++;
					this.meleeCrit++;
					this.rangedCrit++;
				}
				if (this.armor[j].type == 1210)
				{
					this.meleeDamage += 0.07f;
					this.meleeSpeed += 0.07f;
					this.moveSpeed += 0.07f;
				}
				if (this.armor[j].type == 1211)
				{
					this.rangedCrit += 15;
					this.moveSpeed += 0.08f;
				}
				if (this.armor[j].type == 1212)
				{
					this.magicCrit += 18;
					this.statManaMax2 += 80;
				}
				if (this.armor[j].type == 1213)
				{
					this.magicCrit += 6;
					this.meleeCrit += 6;
					this.rangedCrit += 6;
				}
				if (this.armor[j].type == 1214)
				{
					this.moveSpeed += 0.11f;
				}
				if (this.armor[j].type == 1215)
				{
					this.meleeDamage += 0.08f;
					this.meleeCrit += 8;
					this.meleeSpeed += 0.08f;
				}
				if (this.armor[j].type == 1216)
				{
					this.rangedDamage += 0.16f;
					this.rangedCrit += 7;
				}
				if (this.armor[j].type == 1217)
				{
					this.magicDamage += 0.16f;
					this.magicCrit += 7;
					this.statManaMax2 += 100;
				}
				if (this.armor[j].type == 1218)
				{
					this.meleeDamage += 0.04f;
					this.rangedDamage += 0.04f;
					this.magicDamage += 0.04f;
					this.magicCrit += 3;
					this.meleeCrit += 3;
					this.rangedCrit += 3;
				}
				if (this.armor[j].type == 1219)
				{
					this.meleeDamage += 0.03f;
					this.rangedDamage += 0.03f;
					this.magicDamage += 0.03f;
					this.magicCrit += 3;
					this.meleeCrit += 3;
					this.rangedCrit += 3;
					this.moveSpeed += 0.06f;
				}
				if (this.armor[j].type == 558)
				{
					this.magicDamage += 0.12f;
					this.magicCrit += 12;
					this.statManaMax2 += 100;
				}
				if (this.armor[j].type == 559)
				{
					this.meleeCrit += 10;
					this.meleeDamage += 0.1f;
					this.meleeSpeed += 0.1f;
				}
				if (this.armor[j].type == 553)
				{
					this.rangedDamage += 0.15f;
					this.rangedCrit += 8;
				}
				if (this.armor[j].type == 551)
				{
					this.magicCrit += 7;
					this.meleeCrit += 7;
					this.rangedCrit += 7;
				}
				if (this.armor[j].type == 552)
				{
					this.rangedDamage += 0.07f;
					this.meleeDamage += 0.07f;
					this.magicDamage += 0.07f;
					this.moveSpeed += 0.08f;
				}
				if (this.armor[j].type == 1001)
				{
					this.meleeDamage += 0.16f;
					this.meleeCrit += 6;
				}
				if (this.armor[j].type == 1002)
				{
					this.rangedDamage += 0.16f;
					this.ammoCost80 = true;
				}
				if (this.armor[j].type == 1003)
				{
					this.statManaMax2 += 80;
					this.manaCost -= 0.17f;
					this.magicDamage += 0.16f;
				}
				if (this.armor[j].type == 1004)
				{
					this.meleeDamage += 0.05f;
					this.magicDamage += 0.05f;
					this.rangedDamage += 0.05f;
					this.magicCrit += 7;
					this.meleeCrit += 7;
					this.rangedCrit += 7;
				}
				if (this.armor[j].type == 1005)
				{
					this.magicCrit += 8;
					this.meleeCrit += 8;
					this.rangedCrit += 8;
					this.moveSpeed += 0.05f;
				}
				if (this.armor[j].type == 2189)
				{
					this.statManaMax2 += 60;
					this.manaCost -= 0.13f;
					this.magicDamage += 0.05f;
					this.magicCrit += 5;
				}
				if (this.armor[j].type == 1503)
				{
					this.magicDamage -= 0.4f;
				}
				if (this.armor[j].type == 1504)
				{
					this.magicDamage += 0.07f;
					this.magicCrit += 7;
				}
				if (this.armor[j].type == 1505)
				{
					this.magicDamage += 0.08f;
					this.moveSpeed += 0.08f;
				}
				if (this.armor[j].type == 1546)
				{
					this.rangedCrit += 5;
					this.arrowDamage += 0.15f;
				}
				if (this.armor[j].type == 1547)
				{
					this.rangedCrit += 5;
					this.bulletDamage += 0.15f;
				}
				if (this.armor[j].type == 1548)
				{
					this.rangedCrit += 5;
					this.rocketDamage += 0.15f;
				}
				if (this.armor[j].type == 1549)
				{
					this.rangedCrit += 13;
					this.rangedDamage += 0.13f;
					this.ammoCost80 = true;
				}
				if (this.armor[j].type == 1550)
				{
					this.rangedCrit += 7;
					this.moveSpeed += 0.12f;
				}
				if (this.armor[j].type == 1282)
				{
					this.statManaMax2 += 20;
					this.manaCost -= 0.05f;
				}
				if (this.armor[j].type == 1283)
				{
					this.statManaMax2 += 40;
					this.manaCost -= 0.07f;
				}
				if (this.armor[j].type == 1284)
				{
					this.statManaMax2 += 40;
					this.manaCost -= 0.09f;
				}
				if (this.armor[j].type == 1285)
				{
					this.statManaMax2 += 60;
					this.manaCost -= 0.11f;
				}
				if (this.armor[j].type == 1286)
				{
					this.statManaMax2 += 60;
					this.manaCost -= 0.13f;
				}
				if (this.armor[j].type == 1287)
				{
					this.statManaMax2 += 80;
					this.manaCost -= 0.15f;
				}
				if (this.armor[j].type == 1316 || this.armor[j].type == 1317 || this.armor[j].type == 1318)
				{
					this.aggro += 250;
				}
				if (this.armor[j].type == 1316)
				{
					this.meleeDamage += 0.06f;
				}
				if (this.armor[j].type == 1317)
				{
					this.meleeDamage += 0.08f;
					this.meleeCrit += 8;
				}
				if (this.armor[j].type == 1318)
				{
					this.meleeCrit += 4;
				}
				if (this.armor[j].type == 2199 || this.armor[j].type == 2202)
				{
					this.aggro += 250;
				}
				if (this.armor[j].type == 2201)
				{
					this.aggro += 400;
				}
				if (this.armor[j].type == 2199)
				{
					this.meleeDamage += 0.06f;
				}
				if (this.armor[j].type == 2200)
				{
					this.meleeDamage += 0.08f;
					this.meleeCrit += 8;
					this.meleeSpeed += 0.06f;
					this.moveSpeed += 0.06f;
				}
				if (this.armor[j].type == 2201)
				{
					this.meleeDamage += 0.05f;
					this.meleeCrit += 5;
				}
				if (this.armor[j].type == 2202)
				{
					this.meleeSpeed += 0.06f;
					this.moveSpeed += 0.06f;
				}
				if (this.armor[j].type == 684)
				{
					this.rangedDamage += 0.16f;
					this.meleeDamage += 0.16f;
				}
				if (this.armor[j].type == 685)
				{
					this.meleeCrit += 11;
					this.rangedCrit += 11;
				}
				if (this.armor[j].type == 686)
				{
					this.moveSpeed += 0.08f;
					this.meleeSpeed += 0.07f;
				}
				if (this.armor[j].type >= 1158 && this.armor[j].type <= 1161)
				{
					this.maxMinions++;
				}
				if (this.armor[j].type >= 1159 && this.armor[j].type <= 1161)
				{
					this.minionDamage += 0.1f;
				}
				if (this.armor[j].type >= 1832 && this.armor[j].type <= 1834)
				{
					this.maxMinions++;
				}
				if (this.armor[j].type >= 1832 && this.armor[j].type <= 1834)
				{
					this.minionDamage += 0.11f;
				}
				if (this.armor[j].prefix == 62)
				{
					this.statDefense++;
				}
				if (this.armor[j].prefix == 63)
				{
					this.statDefense += 2;
				}
				if (this.armor[j].prefix == 64)
				{
					this.statDefense += 3;
				}
				if (this.armor[j].prefix == 65)
				{
					this.statDefense += 4;
				}
				if (this.armor[j].prefix == 66)
				{
					this.statManaMax2 += 20;
				}
				if (this.armor[j].prefix == 67)
				{
					this.meleeCrit += 2;
					this.rangedCrit += 2;
					this.magicCrit += 2;
				}
				if (this.armor[j].prefix == 68)
				{
					this.meleeCrit += 4;
					this.rangedCrit += 4;
					this.magicCrit += 4;
				}
				if (this.armor[j].prefix == 69)
				{
					this.meleeDamage += 0.01f;
					this.rangedDamage += 0.01f;
					this.magicDamage += 0.01f;
					this.minionDamage += 0.01f;
				}
				if (this.armor[j].prefix == 70)
				{
					this.meleeDamage += 0.02f;
					this.rangedDamage += 0.02f;
					this.magicDamage += 0.02f;
					this.minionDamage += 0.02f;
				}
				if (this.armor[j].prefix == 71)
				{
					this.meleeDamage += 0.03f;
					this.rangedDamage += 0.03f;
					this.magicDamage += 0.03f;
					this.minionDamage += 0.03f;
				}
				if (this.armor[j].prefix == 72)
				{
					this.meleeDamage += 0.04f;
					this.rangedDamage += 0.04f;
					this.magicDamage += 0.04f;
					this.minionDamage += 0.04f;
				}
				if (this.armor[j].prefix == 73)
				{
					this.moveSpeed += 0.01f;
				}
				if (this.armor[j].prefix == 74)
				{
					this.moveSpeed += 0.02f;
				}
				if (this.armor[j].prefix == 75)
				{
					this.moveSpeed += 0.03f;
				}
				if (this.armor[j].prefix == 76)
				{
					this.moveSpeed += 0.04f;
				}
				if (this.armor[j].prefix == 77)
				{
					this.meleeSpeed += 0.01f;
				}
				if (this.armor[j].prefix == 78)
				{
					this.meleeSpeed += 0.02f;
				}
				if (this.armor[j].prefix == 79)
				{
					this.meleeSpeed += 0.03f;
				}
				if (this.armor[j].prefix == 80)
				{
					this.meleeSpeed += 0.04f;
				}
			}
			for (int k = 3; k < 8; k++)
			{
				if (this.armor[k].type == 15 && this.accWatch < 1)
				{
					this.accWatch = 1;
				}
				if (this.armor[k].type == 16 && this.accWatch < 2)
				{
					this.accWatch = 2;
				}
				if (this.armor[k].type == 17 && this.accWatch < 3)
				{
					this.accWatch = 3;
				}
				if (this.armor[k].type == 707 && this.accWatch < 1)
				{
					this.accWatch = 1;
				}
				if (this.armor[k].type == 708 && this.accWatch < 2)
				{
					this.accWatch = 2;
				}
				if (this.armor[k].type == 709 && this.accWatch < 3)
				{
					this.accWatch = 3;
				}
				if (this.armor[k].type == 18 && this.accDepthMeter < 1)
				{
					this.accDepthMeter = 1;
				}
				if (this.armor[k].type == 857)
				{
					this.doubleJump2 = true;
				}
				if (this.armor[k].type == 983)
				{
					this.doubleJump2 = true;
					this.jumpBoost = true;
				}
				if (this.armor[k].type == 987)
				{
					this.doubleJump3 = true;
				}
				if (this.armor[k].type == 1163)
				{
					this.doubleJump3 = true;
					this.jumpBoost = true;
				}
				if (this.armor[k].type == 1724)
				{
					this.doubleJump4 = true;
				}
				if (this.armor[k].type == 1863)
				{
					this.doubleJump4 = true;
					this.jumpBoost = true;
				}
				if (this.armor[k].type == 1164)
				{
					this.doubleJump = true;
					this.doubleJump2 = true;
					this.doubleJump3 = true;
					this.jumpBoost = true;
				}
				if (this.armor[k].type == 1250)
				{
					this.jumpBoost = true;
					this.doubleJump = true;
					this.noFallDmg = true;
				}
				if (this.armor[k].type == 1252)
				{
					this.doubleJump2 = true;
					this.jumpBoost = true;
					this.noFallDmg = true;
				}
				if (this.armor[k].type == 1251)
				{
					this.doubleJump3 = true;
					this.jumpBoost = true;
					this.noFallDmg = true;
				}
				if (this.armor[k].type == 1249)
				{
					this.jumpBoost = true;
					this.bee = true;
				}
				if (this.armor[k].type == 1253 && (double)this.statLife <= (double)this.statLifeMax * 0.25)
				{
					this.AddBuff(62, 5, true);
				}
				if (this.armor[k].type == 1290)
				{
					this.panic = true;
				}
				if ((this.armor[k].type == 1300 || this.armor[k].type == 1858) && (this.inventory[this.selectedItem].useAmmo == 14 || this.inventory[this.selectedItem].useAmmo == 311 || this.inventory[this.selectedItem].useAmmo == 323))
				{
					this.scope = true;
				}
				if (this.armor[k].type == 1858)
				{
					this.rangedCrit += 10;
					this.rangedDamage += 0.1f;
				}
				if (this.armor[k].type == 1303 && this.wet)
				{
					Lighting.addLight((int)this.center().X / 16, (int)this.center().Y / 16, 0.9f, 0.2f, 0.6f);
				}
				if (this.armor[k].type == 1301)
				{
					this.meleeCrit += 8;
					this.rangedCrit += 8;
					this.magicCrit += 8;
					this.meleeDamage += 0.1f;
					this.rangedDamage += 0.1f;
					this.magicDamage += 0.1f;
					this.minionDamage += 0.1f;
				}
				if (this.armor[k].type == 982)
				{
					this.statManaMax2 += 20;
					this.manaRegenDelayBonus++;
					this.manaRegenBonus += 25;
				}
				if (this.armor[k].type == 1595)
				{
					this.statManaMax2 += 20;
					this.magicCuffs = true;
				}
				if (this.armor[k].type == 2219)
				{
					this.manaMagnet = true;
				}
				if (this.armor[k].type == 2220)
				{
					this.manaMagnet = true;
					this.magicDamage += 0.15f;
				}
				if (this.armor[k].type == 2221)
				{
					this.manaMagnet = true;
					this.magicCuffs = true;
				}
				if (this.armor[k].type == 1923)
				{
					Player.tileRangeX++;
					Player.tileRangeY++;
				}
				if (this.armor[k].type == 1247)
				{
					this.starCloak = true;
					this.bee = true;
				}
				if (this.armor[k].type == 1248)
				{
					this.meleeCrit += 10;
					this.rangedCrit += 10;
					this.magicCrit += 10;
				}
				if (this.armor[k].type == 854)
				{
					this.discount = true;
				}
				if (this.armor[k].type == 855)
				{
					this.coins = true;
				}
				if (this.armor[k].type == 53)
				{
					this.doubleJump = true;
				}
				if (this.armor[k].type == 54)
				{
					this.accRunSpeed = 6f;
				}
				if (this.armor[k].type == 1579)
				{
					this.accRunSpeed = 6f;
					this.coldDash = true;
				}
				if (this.armor[k].type == 128)
				{
					this.rocketBoots = 1;
				}
				if (this.armor[k].type == 156)
				{
					this.noKnockback = true;
				}
				if (this.armor[k].type == 158)
				{
					this.noFallDmg = true;
				}
				if (this.armor[k].type == 934)
				{
					this.carpet = true;
				}
				if (this.armor[k].type == 953)
				{
					this.spikedBoots++;
				}
				if (this.armor[k].type == 975)
				{
					this.spikedBoots++;
				}
				if (this.armor[k].type == 976)
				{
					this.spikedBoots += 2;
				}
				if (this.armor[k].type == 977)
				{
					this.dash = 1;
				}
				if (this.armor[k].type == 963)
				{
					this.blackBelt = true;
				}
				if (this.armor[k].type == 984)
				{
					this.blackBelt = true;
					this.dash = 1;
					this.spikedBoots = 2;
				}
				if (this.armor[k].type == 1131)
				{
					this.gravControl2 = true;
				}
				if (this.armor[k].type == 1132)
				{
					this.bee = true;
				}
				if (this.armor[k].type == 1578)
				{
					this.bee = true;
					this.panic = true;
				}
				if (this.armor[k].type == 950)
				{
					this.iceSkate = true;
				}
				if (this.armor[k].type == 159)
				{
					this.jumpBoost = true;
				}
				if (this.armor[k].type == 187)
				{
					this.accFlipper = true;
				}
				if (this.armor[k].type == 211)
				{
					this.meleeSpeed += 0.12f;
				}
				if (this.armor[k].type == 223)
				{
					this.manaCost -= 0.06f;
				}
				if (this.armor[k].type == 285)
				{
					this.moveSpeed += 0.05f;
				}
				if (this.armor[k].type == 212)
				{
					this.moveSpeed += 0.1f;
				}
				if (this.armor[k].type == 267)
				{
					this.killGuide = true;
				}
				if (this.armor[k].type == 1307)
				{
					this.killClothier = true;
				}
				if (this.armor[k].type == 193)
				{
					this.fireWalk = true;
				}
				if (this.armor[k].type == 861)
				{
					this.accMerman = true;
					this.wolfAcc = true;
				}
				if (this.armor[k].type == 862)
				{
					this.starCloak = true;
					this.longInvince = true;
				}
				if (this.armor[k].type == 860)
				{
					this.pStone = true;
				}
				if (this.armor[k].type == 863)
				{
					this.waterWalk2 = true;
				}
				if (this.armor[k].type == 907)
				{
					this.waterWalk2 = true;
					this.fireWalk = true;
				}
				if (this.armor[k].type == 908)
				{
					this.waterWalk = true;
					this.fireWalk = true;
					this.lavaMax += 420;
				}
				if (this.armor[k].type == 906)
				{
					this.lavaMax += 420;
				}
				if (this.armor[k].type == 485)
				{
					this.wolfAcc = true;
				}
				if (this.armor[k].type == 486)
				{
					this.rulerAcc = true;
				}
				if (this.armor[k].type == 393)
				{
					this.accCompass = 1;
				}
				if (this.armor[k].type == 394)
				{
					this.accFlipper = true;
					this.accDivingHelm = true;
				}
				if (this.armor[k].type == 395)
				{
					this.accWatch = 3;
					this.accDepthMeter = 1;
					this.accCompass = 1;
				}
				if (this.armor[k].type == 396)
				{
					this.noFallDmg = true;
					this.fireWalk = true;
				}
				if (this.armor[k].type == 397)
				{
					this.noKnockback = true;
					this.fireWalk = true;
				}
				if (this.armor[k].type == 399)
				{
					this.jumpBoost = true;
					this.doubleJump = true;
				}
				if (this.armor[k].type == 405)
				{
					this.accRunSpeed = 6f;
					this.rocketBoots = 2;
				}
				if (this.armor[k].type == 1860)
				{
					this.accFlipper = true;
					this.accDivingHelm = true;
					if (this.wet)
					{
						Lighting.addLight((int)this.center().X / 16, (int)this.center().Y / 16, 0.9f, 0.2f, 0.6f);
					}
				}
				if (this.armor[k].type == 1861)
				{
					this.accFlipper = true;
					this.accDivingHelm = true;
					this.iceSkate = true;
					if (this.wet)
					{
						Lighting.addLight((int)this.center().X / 16, (int)this.center().Y / 16, 0.2f, 0.8f, 0.9f);
					}
				}
				if (this.armor[k].type == 2214)
				{
					this.tileSpeed += 0.5f;
				}
				if (this.armor[k].type == 2215)
				{
					Player.tileRangeX += 3;
					Player.tileRangeY += 2;
				}
				if (this.armor[k].type == 2216)
				{
					this.autoPaint = true;
				}
				if (this.armor[k].type == 2217)
				{
					this.wallSpeed += 0.5f;
				}
				if (this.armor[k].type == 897)
				{
					this.kbGlove = true;
					this.meleeSpeed += 0.12f;
				}
				if (this.armor[k].type == 1343)
				{
					this.kbGlove = true;
					this.meleeSpeed += 0.09f;
					this.meleeDamage += 0.09f;
					this.magmaStone = true;
				}
				if (this.armor[k].type == 1167)
				{
					this.minionKB += 2f;
					this.minionDamage += 0.15f;
				}
				if (this.armor[k].type == 1864)
				{
					this.minionKB += 2f;
					this.minionDamage += 0.15f;
					this.maxMinions++;
				}
				if (this.armor[k].type == 1845)
				{
					this.minionDamage += 0.1f;
					this.maxMinions++;
				}
				if (this.armor[k].type == 1321)
				{
					this.magicQuiver = true;
					this.arrowDamage += 0.1f;
				}
				if (this.armor[k].type == 1322)
				{
					this.magmaStone = true;
				}
				if (this.armor[k].type == 1323)
				{
					this.lavaRose = true;
				}
				if (this.armor[k].type == 938)
				{
					this.noKnockback = true;
					if ((double)this.statLife > (double)this.statLifeMax * 0.25)
					{
						if (i == Main.myPlayer)
						{
							this.paladinGive = true;
						}
						else
						{
							if (this.miscCounter % 5 == 0)
							{
								int myPlayer = Main.myPlayer;
								if (Main.player[myPlayer].team == this.team && this.team != 0)
								{
									float num = this.position.X - Main.player[myPlayer].position.X;
									float num2 = this.position.Y - Main.player[myPlayer].position.Y;
									float num3 = (float)Math.Sqrt((double)(num * num + num2 * num2));
									if (num3 < 800f)
									{
										Main.player[myPlayer].AddBuff(43, 10, true);
									}
								}
							}
						}
					}
				}
				if (this.armor[k].type == 936)
				{
					this.kbGlove = true;
					this.meleeSpeed += 0.12f;
					this.meleeDamage += 0.12f;
				}
				if (this.armor[k].type == 898)
				{
					this.accRunSpeed = 6.75f;
					this.rocketBoots = 2;
					this.moveSpeed += 0.08f;
				}
				if (this.armor[k].type == 1862)
				{
					this.accRunSpeed = 6.75f;
					this.rocketBoots = 3;
					this.moveSpeed += 0.08f;
					this.iceSkate = true;
				}
				if (this.armor[k].type == 1865)
				{
					this.lifeRegen += 2;
					this.statDefense += 4;
					this.meleeSpeed += 0.1f;
					this.meleeDamage += 0.1f;
					this.meleeCrit += 2;
					this.rangedDamage += 0.1f;
					this.rangedCrit += 2;
					this.magicDamage += 0.1f;
					this.magicCrit += 2;
					this.pickSpeed -= 0.15f;
					this.minionDamage += 0.1f;
					this.minionKB += 0.5f;
				}
				if (this.armor[k].type == 899 && Main.dayTime)
				{
					this.lifeRegen += 2;
					this.statDefense += 4;
					this.meleeSpeed += 0.1f;
					this.meleeDamage += 0.1f;
					this.meleeCrit += 2;
					this.rangedDamage += 0.1f;
					this.rangedCrit += 2;
					this.magicDamage += 0.1f;
					this.magicCrit += 2;
					this.pickSpeed -= 0.15f;
					this.minionDamage += 0.1f;
					this.minionKB += 0.5f;
				}
				if (this.armor[k].type == 900 && !Main.dayTime)
				{
					this.lifeRegen += 2;
					this.statDefense += 4;
					this.meleeSpeed += 0.1f;
					this.meleeDamage += 0.1f;
					this.meleeCrit += 2;
					this.rangedDamage += 0.1f;
					this.rangedCrit += 2;
					this.magicDamage += 0.1f;
					this.magicCrit += 2;
					this.pickSpeed -= 0.15f;
					this.minionDamage += 0.1f;
					this.minionKB += 0.5f;
				}
				if (this.armor[k].type == 407)
				{
					this.blockRange = 1;
				}
				if (this.armor[k].type == 489)
				{
					this.magicDamage += 0.15f;
				}
				if (this.armor[k].type == 490)
				{
					this.meleeDamage += 0.15f;
				}
				if (this.armor[k].type == 491)
				{
					this.rangedDamage += 0.15f;
				}
				if (this.armor[k].type == 935)
				{
					this.magicDamage += 0.12f;
					this.meleeDamage += 0.12f;
					this.rangedDamage += 0.12f;
					this.minionDamage += 0.12f;
				}
				if (this.armor[k].type == 492)
				{
					this.wingTimeMax = 100;
				}
				if (this.armor[k].type == 493)
				{
					this.wingTimeMax = 100;
				}
				if (this.armor[k].type == 665)
				{
					this.wingTimeMax = 220;
				}
				if (this.armor[k].type == 748)
				{
					this.wingTimeMax = 115;
				}
				if (this.armor[k].type == 749)
				{
					this.wingTimeMax = 130;
				}
				if (this.armor[k].type == 761)
				{
					this.wingTimeMax = 130;
				}
				if (this.armor[k].type == 785)
				{
					this.wingTimeMax = 140;
				}
				if (this.armor[k].type == 786)
				{
					this.wingTimeMax = 140;
				}
				if (this.armor[k].type == 821)
				{
					this.wingTimeMax = 160;
				}
				if (this.armor[k].type == 822)
				{
					this.wingTimeMax = 160;
				}
				if (this.armor[k].type == 823)
				{
					this.wingTimeMax = 160;
				}
				if (this.armor[k].type == 2280)
				{
					this.wingTimeMax = 160;
				}
				if (this.armor[k].type == 948)
				{
					this.wingTimeMax = 180;
				}
				if (this.armor[k].type == 1162)
				{
					this.wingTimeMax = 160;
				}
				if (this.armor[k].type == 1165)
				{
					this.wingTimeMax = 140;
				}
				if (this.armor[k].type == 1515)
				{
					this.wingTimeMax = 130;
				}
				if (this.armor[k].type == 1583)
				{
					this.wingTimeMax = 190;
				}
				if (this.armor[k].type == 1584)
				{
					this.wingTimeMax = 190;
				}
				if (this.armor[k].type == 1585)
				{
					this.wingTimeMax = 190;
				}
				if (this.armor[k].type == 1586)
				{
					this.wingTimeMax = 190;
				}
				if (this.armor[k].type == 1797)
				{
					this.wingTimeMax = 180;
				}
				if (this.armor[k].type == 1830)
				{
					this.wingTimeMax = 180;
				}
				if (this.armor[k].type == 1866)
				{
					this.wingTimeMax = 170;
				}
				if (this.armor[k].type == 1871)
				{
					this.wingTimeMax = 170;
				}
				if (this.armor[k].type == 885)
				{
					this.buffImmune[30] = true;
				}
				if (this.armor[k].type == 886)
				{
					this.buffImmune[36] = true;
				}
				if (this.armor[k].type == 887)
				{
					this.buffImmune[20] = true;
				}
				if (this.armor[k].type == 888)
				{
					this.buffImmune[22] = true;
				}
				if (this.armor[k].type == 889)
				{
					this.buffImmune[32] = true;
				}
				if (this.armor[k].type == 890)
				{
					this.buffImmune[35] = true;
				}
				if (this.armor[k].type == 891)
				{
					this.buffImmune[23] = true;
				}
				if (this.armor[k].type == 892)
				{
					this.buffImmune[33] = true;
				}
				if (this.armor[k].type == 893)
				{
					this.buffImmune[31] = true;
				}
				if (this.armor[k].type == 901)
				{
					this.buffImmune[33] = true;
					this.buffImmune[36] = true;
				}
				if (this.armor[k].type == 902)
				{
					this.buffImmune[30] = true;
					this.buffImmune[20] = true;
				}
				if (this.armor[k].type == 903)
				{
					this.buffImmune[32] = true;
					this.buffImmune[31] = true;
				}
				if (this.armor[k].type == 904)
				{
					this.buffImmune[35] = true;
					this.buffImmune[23] = true;
				}
				if (this.armor[k].type == 1921)
				{
					this.buffImmune[46] = true;
					this.buffImmune[47] = true;
				}
				if (this.armor[k].type == 1612)
				{
					this.buffImmune[33] = true;
					this.buffImmune[36] = true;
					this.buffImmune[30] = true;
					this.buffImmune[20] = true;
					this.buffImmune[32] = true;
					this.buffImmune[31] = true;
					this.buffImmune[35] = true;
					this.buffImmune[23] = true;
					this.buffImmune[22] = true;
				}
				if (this.armor[k].type == 1613)
				{
					this.noKnockback = true;
					this.fireWalk = true;
					this.buffImmune[33] = true;
					this.buffImmune[36] = true;
					this.buffImmune[30] = true;
					this.buffImmune[20] = true;
					this.buffImmune[32] = true;
					this.buffImmune[31] = true;
					this.buffImmune[35] = true;
					this.buffImmune[23] = true;
					this.buffImmune[22] = true;
				}
				if (this.armor[k].type == 497)
				{
					this.accMerman = true;
				}
				if (this.armor[k].type == 535)
				{
					this.pStone = true;
				}
				if (this.armor[k].type == 536)
				{
					this.kbGlove = true;
				}
				if (this.armor[k].type == 532)
				{
					this.starCloak = true;
				}
				if (this.armor[k].type == 554)
				{
					this.longInvince = true;
				}
				if (this.armor[k].type == 555)
				{
					this.manaFlower = true;
					this.manaCost -= 0.08f;
				}
				if (Main.myPlayer == this.whoAmi)
				{
					if (this.armor[k].type == 576 && Main.rand.Next(18000) == 0 && Main.curMusic > 0 && Main.curMusic <= 32)
					{
						int num4 = 0;
						if (Main.curMusic == 1)
						{
							num4 = 0;
						}
						if (Main.curMusic == 2)
						{
							num4 = 1;
						}
						if (Main.curMusic == 3)
						{
							num4 = 2;
						}
						if (Main.curMusic == 4)
						{
							num4 = 4;
						}
						if (Main.curMusic == 5)
						{
							num4 = 5;
						}
						if (Main.curMusic == 6)
						{
							num4 = 3;
						}
						if (Main.curMusic == 7)
						{
							num4 = 6;
						}
						if (Main.curMusic == 8)
						{
							num4 = 7;
						}
						if (Main.curMusic == 9)
						{
							num4 = 9;
						}
						if (Main.curMusic == 10)
						{
							num4 = 8;
						}
						if (Main.curMusic == 11)
						{
							num4 = 11;
						}
						if (Main.curMusic == 12)
						{
							num4 = 10;
						}
						if (Main.curMusic == 13)
						{
							num4 = 12;
						}
						if (Main.curMusic == 29)
						{
							this.armor[k].SetDefaults(1610, false);
						}
						else
						{
							if (Main.curMusic == 30)
							{
								this.armor[k].SetDefaults(1963, false);
							}
							else
							{
								if (Main.curMusic == 31)
								{
									this.armor[k].SetDefaults(1964, false);
								}
								else
								{
									if (Main.curMusic == 32)
									{
										this.armor[k].SetDefaults(1965, false);
									}
									else
									{
										if (Main.curMusic > 13)
										{
											this.armor[k].SetDefaults(1596 + Main.curMusic - 14, false);
										}
										else
										{
											this.armor[k].SetDefaults(num4 + 562, false);
										}
									}
								}
							}
						}
					}
					if (this.armor[k].type >= 562 && this.armor[k].type <= 574)
					{
						Main.musicBox2 = this.armor[k].type - 562;
					}
					if (this.armor[k].type >= 1596 && this.armor[k].type <= 1609)
					{
						Main.musicBox2 = this.armor[k].type - 1596 + 13;
					}
					if (this.armor[k].type == 1610)
					{
						Main.musicBox2 = 27;
					}
					if (this.armor[k].type == 1963)
					{
						Main.musicBox2 = 28;
					}
					if (this.armor[k].type == 1964)
					{
						Main.musicBox2 = 29;
					}
					if (this.armor[k].type == 1965)
					{
						Main.musicBox2 = 30;
					}
				}
			}
			for (int l = 3; l < 8; l++)
			{
				if (this.armor[l].wingSlot > 0)
				{
					if (!this.hideVisual[l] || this.velocity.Y != 0f)
					{
						this.wings = (int)this.armor[l].wingSlot;
					}
					this.wingsLogic = (int)this.armor[l].wingSlot;
				}
			}
			for (int m = 11; m < 16; m++)
			{
				if (this.armor[m].wingSlot > 0)
				{
					this.wings = (int)this.armor[m].wingSlot;
				}
			}
		}
		public void UpdatePlayerArmorSets(int i)
		{
			this.setBonus = "";
			if (this.body == 67 && this.legs == 56 && this.head >= 103 && this.head <= 105)
			{
				this.setBonus = Lang.setBonus(31, false);
				this.armorSteath = true;
			}
			if ((this.head == 52 && this.body == 32 && this.legs == 31) || (this.head == 53 && this.body == 33 && this.legs == 32) || (this.head == 54 && this.body == 34 && this.legs == 33) || (this.head == 55 && this.body == 35 && this.legs == 34) || (this.head == 70 && this.body == 46 && this.legs == 42) || (this.head == 71 && this.body == 47 && this.legs == 43))
			{
				this.setBonus = Lang.setBonus(20, false);
				this.statDefense++;
			}
			if ((this.head == 1 && this.body == 1 && this.legs == 1) || ((this.head == 72 || this.head == 2) && this.body == 2 && this.legs == 2) || (this.head == 47 && this.body == 28 && this.legs == 27))
			{
				this.setBonus = Lang.setBonus(0, false);
				this.statDefense += 2;
			}
			if ((this.head == 3 && this.body == 3 && this.legs == 3) || ((this.head == 73 || this.head == 4) && this.body == 4 && this.legs == 4) || (this.head == 48 && this.body == 29 && this.legs == 28) || (this.head == 49 && this.body == 30 && this.legs == 29))
			{
				this.setBonus = Lang.setBonus(1, false);
				this.statDefense += 3;
			}
			if (this.head == 50 && this.body == 31 && this.legs == 30)
			{
				this.setBonus = Lang.setBonus(32, false);
				this.statDefense += 4;
			}
			if (this.head == 112 && this.body == 75 && this.legs == 64)
			{
				this.setBonus = Lang.setBonus(33, false);
				this.meleeDamage += 0.1f;
				this.magicDamage += 0.1f;
				this.rangedDamage += 0.1f;
			}
			if (this.head == 157 && this.body == 105 && this.legs == 98)
			{
				int num = 0;
				this.setBonus = Lang.setBonus(38, false);
				this.beetleOffense = true;
				this.beetleCounter -= 3f;
				this.beetleCounter -= (float)(this.beetleCountdown / 10);
				this.beetleCountdown++;
				if (this.beetleCounter < 0f)
				{
					this.beetleCounter = 0f;
				}
				int num2 = 400;
				int num3 = 1200;
				int num4 = 4600;
				if (this.beetleCounter > (float)(num2 + num3 + num4 + num3))
				{
					this.beetleCounter = (float)(num2 + num3 + num4 + num3);
				}
				if (this.beetleCounter > (float)(num2 + num3 + num4))
				{
					this.AddBuff(100, 5, false);
					num = 3;
				}
				else
				{
					if (this.beetleCounter > (float)(num2 + num3))
					{
						this.AddBuff(99, 5, false);
						num = 2;
					}
					else
					{
						if (this.beetleCounter > (float)num2)
						{
							this.AddBuff(98, 5, false);
							num = 1;
						}
					}
				}
				if (num < this.beetleOrbs)
				{
					this.beetleCountdown = 0;
				}
				else
				{
					if (num > this.beetleOrbs)
					{
						this.beetleCounter += 200f;
					}
				}
				if (num != this.beetleOrbs && this.beetleOrbs > 0)
				{
					for (int j = 0; j < 22; j++)
					{
						if (this.buffType[j] >= 98 && this.buffType[j] <= 100 && this.buffType[j] != 97 + num)
						{
							this.DelBuff(j);
						}
					}
				}
			}
			else
			{
				if (this.head == 157 && this.body == 106 && this.legs == 98)
				{
					this.setBonus = Lang.setBonus(37, false);
					this.beetleDefense = true;
					this.beetleCounter += 1f;
					int num5 = 180;
					if (this.beetleCounter >= (float)num5)
					{
						if (this.beetleOrbs > 0 && this.beetleOrbs < 3)
						{
							for (int k = 0; k < 22; k++)
							{
								if (this.buffType[k] >= 95 && this.buffType[k] <= 96)
								{
									this.DelBuff(k);
								}
							}
						}
						if (this.beetleOrbs < 3)
						{
							this.AddBuff(95 + this.beetleOrbs, 5, false);
							this.beetleCounter = 0f;
						}
						else
						{
							this.beetleCounter = (float)num5;
						}
					}
				}
			}
			if (!this.beetleDefense && !this.beetleOffense)
			{
				this.beetleCounter = 0f;
			}
			else
			{
				this.beetleFrameCounter++;
				if (this.beetleFrameCounter >= 1)
				{
					this.beetleFrameCounter = 0;
					this.beetleFrame++;
					if (this.beetleFrame > 2)
					{
						this.beetleFrame = 0;
					}
				}
				for (int l = this.beetleOrbs; l < 3; l++)
				{
					this.beetlePos[l].X = 0f;
					this.beetlePos[l].Y = 0f;
				}
				for (int m = 0; m < this.beetleOrbs; m++)
				{
					this.beetlePos[m] += this.beetleVel[m];
					Vector2[] expr_61A_cp_0 = this.beetleVel;
					int expr_61A_cp_1 = m;
					expr_61A_cp_0[expr_61A_cp_1].X = expr_61A_cp_0[expr_61A_cp_1].X + (float)Main.rand.Next(-100, 101) * 0.005f;
					Vector2[] expr_648_cp_0 = this.beetleVel;
					int expr_648_cp_1 = m;
					expr_648_cp_0[expr_648_cp_1].Y = expr_648_cp_0[expr_648_cp_1].Y + (float)Main.rand.Next(-100, 101) * 0.005f;
					float num6 = this.beetlePos[m].X;
					float num7 = this.beetlePos[m].Y;
					float num8 = (float)Math.Sqrt((double)(num6 * num6 + num7 * num7));
					if (num8 > 100f)
					{
						num8 = 20f / num8;
						num6 *= -num8;
						num7 *= -num8;
						int num9 = 10;
						this.beetleVel[m].X = (this.beetleVel[m].X * (float)(num9 - 1) + num6) / (float)num9;
						this.beetleVel[m].Y = (this.beetleVel[m].Y * (float)(num9 - 1) + num7) / (float)num9;
					}
					else
					{
						if (num8 > 30f)
						{
							num8 = 10f / num8;
							num6 *= -num8;
							num7 *= -num8;
							int num10 = 20;
							this.beetleVel[m].X = (this.beetleVel[m].X * (float)(num10 - 1) + num6) / (float)num10;
							this.beetleVel[m].Y = (this.beetleVel[m].Y * (float)(num10 - 1) + num7) / (float)num10;
						}
					}
					num6 = this.beetleVel[m].X;
					num7 = this.beetleVel[m].Y;
					num8 = (float)Math.Sqrt((double)(num6 * num6 + num7 * num7));
					if (num8 > 2f)
					{
						this.beetleVel[m] *= 0.9f;
					}
					this.beetlePos[m] -= this.velocity * 0.25f;
				}
			}
			if (this.head == 14 && ((this.body >= 58 && this.body <= 63) || this.body == 167))
			{
				this.setBonus = Lang.setBonus(28, false);
				this.magicCrit += 10;
			}
			if (this.head == 159 && ((this.body >= 58 && this.body <= 63) || this.body == 167))
			{
				this.setBonus = Lang.setBonus(36, false);
				this.statManaMax2 += 60;
			}
			if ((this.head == 5 || this.head == 74) && (this.body == 5 || this.body == 48) && (this.legs == 5 || this.legs == 44))
			{
				this.setBonus = Lang.setBonus(2, false);
				this.moveSpeed += 0.15f;
			}
			if (this.head == 57 && this.body == 37 && this.legs == 35)
			{
				this.setBonus = Lang.setBonus(21, false);
				this.crimsonRegen = true;
			}
			if (this.head == 101 && this.body == 66 && this.legs == 55)
			{
				this.setBonus = Lang.setBonus(30, false);
				this.ghostHeal = true;
			}
			if (this.head == 156 && this.body == 66 && this.legs == 55)
			{
				this.setBonus = Lang.setBonus(35, false);
				this.ghostHurt = true;
			}
			if (this.head == 6 && this.body == 6 && this.legs == 6)
			{
				this.setBonus = Lang.setBonus(3, false);
				this.spaceGun = true;
			}
			if (this.head == 46 && this.body == 27 && this.legs == 26)
			{
				this.setBonus = Lang.setBonus(22, false);
				this.frostBurn = true;
			}
			if ((this.head == 75 || this.head == 7) && this.body == 7 && this.legs == 7)
			{
				this.boneArmor = true;
				this.setBonus = Lang.setBonus(4, false);
				this.ammoCost80 = true;
			}
			if ((this.head == 76 || this.head == 8) && (this.body == 49 || this.body == 8) && (this.legs == 45 || this.legs == 8))
			{
				this.setBonus = Lang.setBonus(5, false);
				this.manaCost -= 0.16f;
			}
			if (this.head == 9 && this.body == 9 && this.legs == 9)
			{
				this.setBonus = Lang.setBonus(6, false);
				this.meleeDamage += 0.17f;
			}
			if (this.head == 11 && this.body == 20 && this.legs == 19)
			{
				this.setBonus = Lang.setBonus(7, false);
				this.pickSpeed -= 0.3f;
			}
			if ((this.head == 78 || this.head == 79 || this.head == 80) && this.body == 51 && this.legs == 47)
			{
				this.setBonus = Lang.setBonus(27, false);
				this.AddBuff(60, 18000, true);
			}
			else
			{
				if (this.crystalLeaf)
				{
					for (int n = 0; n < 22; n++)
					{
						if (this.buffType[n] == 60)
						{
							this.DelBuff(n);
						}
					}
				}
			}
			if (this.head == 99 && this.body == 65 && this.legs == 54)
			{
				this.setBonus = Lang.setBonus(29, false);
				this.thorns = true;
				this.turtleThorns = true;
			}
			if (this.body == 17 && this.legs == 16)
			{
				if (this.head == 29)
				{
					this.setBonus = Lang.setBonus(8, false);
					this.manaCost -= 0.14f;
				}
				else
				{
					if (this.head == 30)
					{
						this.setBonus = Lang.setBonus(9, false);
						this.meleeSpeed += 0.15f;
					}
					else
					{
						if (this.head == 31)
						{
							this.setBonus = Lang.setBonus(10, false);
							this.ammoCost80 = true;
						}
					}
				}
			}
			if (this.body == 18 && this.legs == 17)
			{
				if (this.head == 32)
				{
					this.setBonus = Lang.setBonus(11, false);
					this.manaCost -= 0.17f;
				}
				else
				{
					if (this.head == 33)
					{
						this.setBonus = Lang.setBonus(12, false);
						this.meleeCrit += 5;
					}
					else
					{
						if (this.head == 34)
						{
							this.setBonus = Lang.setBonus(13, false);
							this.ammoCost80 = true;
						}
					}
				}
			}
			if (this.body == 19 && this.legs == 18)
			{
				if (this.head == 35)
				{
					this.setBonus = Lang.setBonus(14, false);
					this.manaCost -= 0.19f;
				}
				else
				{
					if (this.head == 36)
					{
						this.setBonus = Lang.setBonus(15, false);
						this.meleeSpeed += 0.18f;
						this.moveSpeed += 0.18f;
					}
					else
					{
						if (this.head == 37)
						{
							this.setBonus = Lang.setBonus(16, false);
							this.ammoCost75 = true;
						}
					}
				}
			}
			if (this.body == 54 && this.legs == 49 && (this.head == 83 || this.head == 84 || this.head == 85))
			{
				this.setBonus = Lang.setBonus(24, false);
				this.onHitRegen = true;
			}
			if (this.body == 55 && this.legs == 50 && (this.head == 86 || this.head == 87 || this.head == 88))
			{
				this.setBonus = Lang.setBonus(25, false);
				this.onHitPetal = true;
			}
			if (this.body == 56 && this.legs == 51 && (this.head == 89 || this.head == 90 || this.head == 91))
			{
				this.setBonus = Lang.setBonus(26, false);
				this.onHitDodge = true;
			}
			if (this.body == 24 && this.legs == 23)
			{
				if (this.head == 42)
				{
					this.setBonus = Lang.setBonus(17, false);
					this.manaCost -= 0.2f;
				}
				else
				{
					if (this.head == 43)
					{
						this.setBonus = Lang.setBonus(18, false);
						this.meleeSpeed += 0.19f;
						this.moveSpeed += 0.19f;
					}
					else
					{
						if (this.head == 41)
						{
							this.setBonus = Lang.setBonus(19, false);
							this.ammoCost75 = true;
						}
					}
				}
			}
			if (this.head == 82 && this.body == 53 && this.legs == 48)
			{
				this.setBonus = Lang.setBonus(23, false);
				this.maxMinions++;
			}
			if (this.head == 134 && this.body == 95 && this.legs == 79)
			{
				this.setBonus = Lang.setBonus(34, false);
				this.minionDamage += 0.25f;
			}
		}
		public void UpdatePlayer(int i)
		{
			if (this.launcherWait > 0)
			{
				this.launcherWait--;
			}
			float num = 10f;
			float num2 = 0.4f;
			Player.jumpHeight = 15;
			Player.jumpSpeed = 5.01f;
			if (this.wet)
			{
				if (this.honeyWet)
				{
					num2 = 0.1f;
					num = 3f;
				}
				else
				{
					if (this.merman)
					{
						num2 = 0.3f;
						num = 7f;
					}
					else
					{
						num2 = 0.2f;
						num = 5f;
						Player.jumpHeight = 30;
						Player.jumpSpeed = 6.01f;
					}
				}
			}
			float num3 = 3f;
			float num4 = 0.08f;
			float num5 = 0.2f;
			this.accRunSpeed = num3;
			this.heldProj = -1;
			bool flag = false;
			if (this.active)
			{
				if (this.ghostDmg > 0f)
				{
					this.ghostDmg -= 2.5f;
				}
				if (this.ghostDmg < 0f)
				{
					this.ghostDmg = 0f;
				}
				if (this.lifeSteal < 80f)
				{
					this.lifeSteal += 0.6f;
				}
				if (this.lifeSteal > 80f)
				{
					this.lifeSteal = 80f;
				}
				if (this.mount == 1)
				{
					this.position.Y = this.position.Y + (float)this.height;
					this.height = 62;
					this.position.Y = this.position.Y - (float)this.height;
					int num6 = (int)(this.position.X + (float)(this.width / 2)) / 16;
					int j = (int)(this.position.Y + (float)(this.height / 2) - 14f) / 16;
					Lighting.addLight(num6, j, 0.5f, 0.2f, 0.05f);
					Lighting.addLight(num6 + this.direction, j, 0.5f, 0.2f, 0.05f);
					Lighting.addLight(num6 + this.direction * 2, j, 0.5f, 0.2f, 0.05f);
				}
				else
				{
					this.position.Y = this.position.Y + (float)this.height;
					this.height = 42;
					this.position.Y = this.position.Y - (float)this.height;
				}
				Main.numPlayers++;
				this.outOfRange = false;
				if (this.whoAmi != Main.myPlayer)
				{
					int num7 = (int)(this.position.X + (float)(this.width / 2)) / 16;
					int num8 = (int)(this.position.Y + (float)(this.height / 2)) / 16;
					if (Main.tile[num7, num8] == null)
					{
						flag = true;
					}
					else
					{
						if (Main.tile[num7 - 3, num8] == null)
						{
							flag = true;
						}
						else
						{
							if (Main.tile[num7 + 3, num8] == null)
							{
								flag = true;
							}
							else
							{
								if (Main.tile[num7, num8 - 3] == null)
								{
									flag = true;
								}
								else
								{
									if (Main.tile[num7, num8 + 3] == null)
									{
										flag = true;
									}
								}
							}
						}
					}
					if (flag)
					{
						this.outOfRange = true;
						this.numMinions = 0;
						this.itemAnimation = 0;
						this.PlayerFrame();
					}
				}
			}
			if (this.active && !flag)
			{
				this.miscCounter++;
				if (this.miscCounter >= 300)
				{
					this.miscCounter = 0;
				}
				float num9 = (float)(Main.maxTilesX / 4200);
				num9 *= num9;
				float num10 = (float)((double)(this.position.Y / 16f - (60f + 10f * num9)) / (Main.worldSurface / 6.0));
				if ((double)num10 < 0.25)
				{
					num10 = 0.25f;
				}
				if (num10 > 1f)
				{
					num10 = 1f;
				}
				num2 *= num10;
				this.maxRegenDelay = (1f - (float)this.statMana / (float)this.statManaMax2) * 60f * 4f + 45f;
				this.maxRegenDelay *= 0.7f;
				this.shadowCount++;
				if (this.shadowCount == 1)
				{
					this.shadowPos[2] = this.shadowPos[1];
				}
				else
				{
					if (this.shadowCount == 2)
					{
						this.shadowPos[1] = this.shadowPos[0];
					}
					else
					{
						if (this.shadowCount >= 3)
						{
							this.shadowCount = 0;
							this.shadowPos[0] = this.position;
							Vector2[] expr_4A0_cp_0 = this.shadowPos;
							int expr_4A0_cp_1 = 0;
							expr_4A0_cp_0[expr_4A0_cp_1].Y = expr_4A0_cp_0[expr_4A0_cp_1].Y + this.gfxOffY;
						}
					}
				}
				if (this.teleportTime > 0f)
				{
					if (this.teleportStyle == 1)
					{
						if ((float)Main.rand.Next(100) <= 100f * this.teleportTime)
						{
							int num11 = Dust.NewDust(new Vector2((float)this.getRect().X, (float)this.getRect().Y), this.getRect().Width, this.getRect().Height, 164, 0f, 0f, 0, default(Color), 1f);
							Main.dust[num11].scale = this.teleportTime * 1.5f;
							Main.dust[num11].noGravity = true;
							Main.dust[num11].velocity *= 1.1f;
						}
					}
					else
					{
						if ((float)Main.rand.Next(100) <= 100f * this.teleportTime * 2f)
						{
							int num12 = Dust.NewDust(new Vector2((float)this.getRect().X, (float)this.getRect().Y), this.getRect().Width, this.getRect().Height, 159, 0f, 0f, 0, default(Color), 1f);
							Main.dust[num12].scale = this.teleportTime * 1.5f;
							Main.dust[num12].noGravity = true;
							Main.dust[num12].velocity *= 1.1f;
						}
					}
					this.teleportTime -= 0.005f;
				}
				this.whoAmi = i;
				if (this.runSoundDelay > 0)
				{
					this.runSoundDelay--;
				}
				if (this.attackCD > 0)
				{
					this.attackCD--;
				}
				if (this.itemAnimation == 0)
				{
					this.attackCD = 0;
				}
				if (this.chatShowTime > 0)
				{
					this.chatShowTime--;
				}
				if (this.potionDelay > 0)
				{
					this.potionDelay--;
				}
				if (i == Main.myPlayer)
				{
					if (Main.trashItem.type >= 1522 && Main.trashItem.type <= 1527)
					{
						Main.trashItem.SetDefaults(0, false);
					}
					this.zoneEvil = false;
					if (Main.evilTiles >= 200)
					{
						this.zoneEvil = true;
					}
					this.zoneHoly = false;
					if (Main.holyTiles >= 100)
					{
						this.zoneHoly = true;
					}
					this.zoneMeteor = false;
					if (Main.meteorTiles >= 50)
					{
						this.zoneMeteor = true;
					}
					this.zoneDungeon = false;
					if (Main.dungeonTiles >= 250 && (double)this.position.Y > Main.worldSurface * 16.0)
					{
						int num13 = (int)this.position.X / 16;
						int num14 = (int)this.position.Y / 16;
						if (Main.wallDungeon[(int)Main.tile[num13, num14].wall])
						{
							this.zoneDungeon = true;
						}
					}
					this.zoneJungle = false;
					if (Main.jungleTiles >= 80)
					{
						this.zoneJungle = true;
					}
					this.zoneSnow = false;
					if (Main.snowTiles >= 300)
					{
						this.zoneSnow = true;
					}
					this.zoneBlood = false;
					if (Main.bloodTiles >= 200)
					{
						this.zoneBlood = true;
					}
					if (Main.waterCandles > 0)
					{
						this.zoneCandle = true;
					}
					else
					{
						this.zoneCandle = false;
					}
				}
				if (this.ghost)
				{
					this.Ghost();
					return;
				}
				if (this.dead)
				{
					this.gem = -1;
					this.slippy = false;
					this.slippy2 = false;
					this.powerrun = false;
					this.wings = 0;
					this.wingsLogic = 0;
					this.face = (this.neck = (this.back = (this.front = (this.handoff = (this.handon = (this.shoe = (this.waist = (this.balloon = (this.shield = 0)))))))));
					this.poisoned = false;
					this.venom = false;
					this.onFire = false;
					this.dripping = false;
					this.burned = false;
					this.suffocating = false;
					this.onFire2 = false;
					this.onFrostBurn = false;
					this.blind = false;
					this.blackout = false;
					this.gravDir = 1f;
					for (int k = 0; k < 22; k++)
					{
						this.buffTime[k] = 0;
						this.buffType[k] = 0;
					}
					if (i == Main.myPlayer)
					{
						Main.npcChatText = "";
						Main.editSign = false;
					}
					this.grappling[0] = -1;
					this.grappling[1] = -1;
					this.grappling[2] = -1;
					this.sign = -1;
					this.talkNPC = -1;
					this.statLife = 0;
					this.channel = false;
					this.potionDelay = 0;
					this.chest = -1;
					this.changeItem = -1;
					this.itemAnimation = 0;
					this.immuneAlpha += 2;
					if (this.immuneAlpha > 255)
					{
						this.immuneAlpha = 255;
					}
					this.headPosition += this.headVelocity;
					this.bodyPosition += this.bodyVelocity;
					this.legPosition += this.legVelocity;
					this.headRotation += this.headVelocity.X * 0.1f;
					this.bodyRotation += this.bodyVelocity.X * 0.1f;
					this.legRotation += this.legVelocity.X * 0.1f;
					this.headVelocity.Y = this.headVelocity.Y + 0.1f;
					this.bodyVelocity.Y = this.bodyVelocity.Y + 0.1f;
					this.legVelocity.Y = this.legVelocity.Y + 0.1f;
					this.headVelocity.X = this.headVelocity.X * 0.99f;
					this.bodyVelocity.X = this.bodyVelocity.X * 0.99f;
					this.legVelocity.X = this.legVelocity.X * 0.99f;
					if (this.difficulty == 2)
					{
						if (this.respawnTimer > 0)
						{
							this.respawnTimer--;
							return;
						}
						if (this.whoAmi == Main.myPlayer || Main.netMode == 2)
						{
							this.ghost = true;
							return;
						}
					}
					else
					{
						this.respawnTimer--;
						if (this.respawnTimer <= 0 && Main.myPlayer == this.whoAmi)
						{
							if (Main.mouseItem.type > 0)
							{
								Main.playerInventory = true;
							}
							this.Spawn();
							return;
						}
					}
				}
				else
				{
					if (i == Main.myPlayer)
					{
						this.controlUp = false;
						this.controlLeft = false;
						this.controlDown = false;
						this.controlRight = false;
						this.controlJump = false;
						this.controlUseItem = false;
						this.controlUseTile = false;
						this.controlThrow = false;
						this.controlInv = false;
						this.controlHook = false;
						this.controlTorch = false;
						this.mapStyle = false;
						this.mapAlphaDown = false;
						this.mapAlphaUp = false;
						this.mapFullScreen = false;
						this.mapZoomIn = false;
						this.mapZoomOut = false;
						if (Main.hasFocus)
						{
							if (!Main.chatMode && !Main.editSign && !Main.editChest && !Main.blockInput)
							{
								Keys[] pressedKeys = Main.keyState.GetPressedKeys();
								if (Main.blockKey != Keys.None)
								{
									bool flag2 = false;
									for (int l = 0; l < pressedKeys.Length; l++)
									{
										if (pressedKeys[l] == Main.blockKey)
										{
											pressedKeys[l] = Keys.None;
											flag2 = true;
										}
									}
									if (!flag2)
									{
										Main.blockKey = Keys.None;
									}
								}
								bool flag3 = false;
								bool flag4 = false;
								for (int m = 0; m < pressedKeys.Length; m++)
								{
									string a = string.Concat(pressedKeys[m]);
									if (a == Main.cUp)
									{
										this.controlUp = true;
									}
									if (a == Main.cLeft)
									{
										this.controlLeft = true;
									}
									if (a == Main.cDown)
									{
										this.controlDown = true;
									}
									if (a == Main.cRight)
									{
										this.controlRight = true;
									}
									if (a == Main.cJump)
									{
										this.controlJump = true;
									}
									if (a == Main.cThrowItem)
									{
										this.controlThrow = true;
									}
									if (a == Main.cInv)
									{
										this.controlInv = true;
									}
									if (a == Main.cBuff)
									{
										this.QuickBuff();
									}
									if (a == Main.cHeal)
									{
										flag4 = true;
									}
									if (a == Main.cMana)
									{
										flag3 = true;
									}
									if (a == Main.cHook)
									{
										this.controlHook = true;
									}
									if (a == Main.cTorch)
									{
										this.controlTorch = true;
									}
									if (Main.mapEnabled)
									{
										if (a == Main.cMapZoomIn)
										{
											this.mapZoomIn = true;
										}
										if (a == Main.cMapZoomOut)
										{
											this.mapZoomOut = true;
										}
										if (a == Main.cMapAlphaUp)
										{
											this.mapAlphaUp = true;
										}
										if (a == Main.cMapAlphaDown)
										{
											this.mapAlphaDown = true;
										}
										if (a == Main.cMapFull)
										{
											this.mapFullScreen = true;
										}
										if (a == Main.cMapStyle)
										{
											this.mapStyle = true;
										}
									}
								}
								if (Main.gamePad)
								{
									GamePadState state = GamePad.GetState(PlayerIndex.One);
									if (state.DPad.Up == ButtonState.Pressed)
									{
										this.controlUp = true;
									}
									if (state.DPad.Down == ButtonState.Pressed)
									{
										this.controlDown = true;
									}
									if (state.DPad.Left == ButtonState.Pressed)
									{
										this.controlLeft = true;
									}
									if (state.DPad.Right == ButtonState.Pressed)
									{
										this.controlRight = true;
									}
									if (state.Triggers.Left > 0f)
									{
										this.controlJump = true;
									}
									if (state.Triggers.Right > 0f)
									{
										this.controlUseItem = true;
									}
									Main.mouseX = (int)((float)(Main.screenWidth / 2) + state.ThumbSticks.Right.X * (float)Player.tileRangeX * 16f);
									Main.mouseY = (int)((float)(Main.screenHeight / 2) - state.ThumbSticks.Right.Y * (float)Player.tileRangeX * 16f);
									if (state.ThumbSticks.Right.X == 0f)
									{
										Main.mouseX = Main.screenWidth / 2 + this.direction * 2;
									}
								}
								if (Main.mapFullscreen)
								{
									if (this.controlUp)
									{
										Main.mapFullscreenPos.Y = Main.mapFullscreenPos.Y - 1f * (16f / Main.mapFullscreenScale);
									}
									if (this.controlDown)
									{
										Main.mapFullscreenPos.Y = Main.mapFullscreenPos.Y + 1f * (16f / Main.mapFullscreenScale);
									}
									if (this.controlLeft)
									{
										Main.mapFullscreenPos.X = Main.mapFullscreenPos.X - 1f * (16f / Main.mapFullscreenScale);
									}
									if (this.controlRight)
									{
										Main.mapFullscreenPos.X = Main.mapFullscreenPos.X + 1f * (16f / Main.mapFullscreenScale);
									}
									this.controlUp = false;
									this.controlLeft = false;
									this.controlDown = false;
									this.controlRight = false;
									this.controlJump = false;
									this.controlUseItem = false;
									this.controlUseTile = false;
									this.controlThrow = false;
									this.controlHook = false;
									this.controlTorch = false;
								}
								if (flag4)
								{
									if (this.releaseQuickHeal)
									{
										this.QuickHeal();
									}
									this.releaseQuickHeal = false;
								}
								else
								{
									this.releaseQuickHeal = true;
								}
								if (flag3)
								{
									if (this.releaseQuickMana)
									{
										this.QuickMana();
									}
									this.releaseQuickMana = false;
								}
								else
								{
									this.releaseQuickMana = true;
								}
								if (this.controlLeft && this.controlRight)
								{
									this.controlLeft = false;
									this.controlRight = false;
								}
								if (Main.mapFullscreen)
								{
									if (this.mapZoomIn)
									{
										Main.mapFullscreenScale *= 1.05f;
									}
									if (this.mapZoomOut)
									{
										Main.mapFullscreenScale *= 0.95f;
									}
								}
								else
								{
									if (Main.mapStyle == 1)
									{
										if (this.mapZoomIn)
										{
											Main.mapMinimapScale *= 1.025f;
										}
										if (this.mapZoomOut)
										{
											Main.mapMinimapScale *= 0.975f;
										}
										if (this.mapAlphaUp)
										{
											Main.mapMinimapAlpha += 0.015f;
										}
										if (this.mapAlphaDown)
										{
											Main.mapMinimapAlpha -= 0.015f;
										}
									}
									else
									{
										if (Main.mapStyle == 2)
										{
											if (this.mapZoomIn)
											{
												Main.mapOverlayScale *= 1.05f;
											}
											if (this.mapZoomOut)
											{
												Main.mapOverlayScale *= 0.95f;
											}
											if (this.mapAlphaUp)
											{
												Main.mapOverlayAlpha += 0.015f;
											}
											if (this.mapAlphaDown)
											{
												Main.mapOverlayAlpha -= 0.015f;
											}
										}
									}
									if (this.mapStyle)
									{
										if (this.releaseMapStyle)
										{
											Main.PlaySound(12, -1, -1, 1);
											Main.mapStyle++;
											if (Main.mapStyle > 2)
											{
												Main.mapStyle = 0;
											}
										}
										this.releaseMapStyle = false;
									}
									else
									{
										this.releaseMapStyle = true;
									}
								}
								if (this.mapFullScreen)
								{
									if (this.releaseMapFullscreen)
									{
										if (Main.mapFullscreen)
										{
											Main.PlaySound(11, -1, -1, 1);
											Main.mapFullscreen = false;
										}
										else
										{
											Main.playerInventory = false;
											this.talkNPC = -1;
											Main.PlaySound(10, -1, -1, 1);
											float mapFullscreenScale = 2.5f;
											Main.mapFullscreenScale = mapFullscreenScale;
											Main.mapFullscreen = true;
											Main.resetMapFull = true;
										}
									}
									this.releaseMapFullscreen = false;
								}
								else
								{
									this.releaseMapFullscreen = true;
								}
							}
							if (this.confused)
							{
								bool flag5 = this.controlLeft;
								bool flag6 = this.controlUp;
								this.controlLeft = this.controlRight;
								this.controlRight = flag5;
								this.controlUp = this.controlRight;
								this.controlDown = flag6;
							}
							if (Main.mouseLeft)
							{
								if (!Main.blockMouse && !this.mouseInterface)
								{
									this.controlUseItem = true;
								}
							}
							else
							{
								Main.blockMouse = false;
							}
							if (Main.mouseRight && !this.mouseInterface && !Main.blockMouse)
							{
								this.controlUseTile = true;
							}
							if (this.controlInv)
							{
								if (this.releaseInventory)
								{
									if (Main.mapFullscreen)
									{
										Main.mapFullscreen = false;
										this.releaseInventory = false;
										Main.PlaySound(11, -1, -1, 1);
									}
									else
									{
										this.toggleInv();
									}
								}
								this.releaseInventory = false;
							}
							else
							{
								this.releaseInventory = true;
							}
							if (this.delayUseItem)
							{
								if (!this.controlUseItem)
								{
									this.delayUseItem = false;
								}
								this.controlUseItem = false;
							}
							if (this.itemAnimation == 0 && this.itemTime == 0)
							{
								this.dropItemCheck();
								int num15 = this.selectedItem;
								if (!Main.chatMode && this.selectedItem != 58 && !Main.editSign && !Main.editChest)
								{
									if (Main.keyState.IsKeyDown(Keys.D1))
									{
										this.selectedItem = 0;
									}
									if (Main.keyState.IsKeyDown(Keys.D2))
									{
										this.selectedItem = 1;
									}
									if (Main.keyState.IsKeyDown(Keys.D3))
									{
										this.selectedItem = 2;
									}
									if (Main.keyState.IsKeyDown(Keys.D4))
									{
										this.selectedItem = 3;
									}
									if (Main.keyState.IsKeyDown(Keys.D5))
									{
										this.selectedItem = 4;
									}
									if (Main.keyState.IsKeyDown(Keys.D6))
									{
										this.selectedItem = 5;
									}
									if (Main.keyState.IsKeyDown(Keys.D7))
									{
										this.selectedItem = 6;
									}
									if (Main.keyState.IsKeyDown(Keys.D8))
									{
										this.selectedItem = 7;
									}
									if (Main.keyState.IsKeyDown(Keys.D9))
									{
										this.selectedItem = 8;
									}
									if (Main.keyState.IsKeyDown(Keys.D0))
									{
										this.selectedItem = 9;
									}
								}
								if (num15 != this.selectedItem)
								{
									Main.PlaySound(12, -1, -1, 1);
								}
								if (Main.mapFullscreen)
								{
									int num16 = (Main.mouseState.ScrollWheelValue - Main.oldMouseState.ScrollWheelValue) / 120;
									Main.mapFullscreenScale *= 1f + (float)num16 * 0.3f;
								}
								else
								{
									if (!Main.playerInventory)
									{
										int n;
										for (n = (Main.mouseState.ScrollWheelValue - Main.oldMouseState.ScrollWheelValue) / 120; n > 9; n -= 10)
										{
										}
										while (n < 0)
										{
											n += 10;
										}
										this.selectedItem -= n;
										if (n != 0)
										{
											Main.PlaySound(12, -1, -1, 1);
										}
										if (this.changeItem >= 0)
										{
											if (this.selectedItem != this.changeItem)
											{
												Main.PlaySound(12, -1, -1, 1);
											}
											this.selectedItem = this.changeItem;
											this.changeItem = -1;
										}
										if (this.itemAnimation == 0)
										{
											while (this.selectedItem > 9)
											{
												this.selectedItem -= 10;
											}
											while (this.selectedItem < 0)
											{
												this.selectedItem += 10;
											}
										}
									}
									else
									{
										int num17 = (Main.mouseState.ScrollWheelValue - Main.oldMouseState.ScrollWheelValue) / 120;
										Main.focusRecipe += num17;
										if (Main.focusRecipe > Main.numAvailableRecipes - 1)
										{
											Main.focusRecipe = Main.numAvailableRecipes - 1;
										}
										if (Main.focusRecipe < 0)
										{
											Main.focusRecipe = 0;
										}
									}
								}
							}
						}
						if (this.selectedItem == 58)
						{
							this.nonTorch = -1;
						}
						else
						{
							if (this.controlTorch && this.itemAnimation == 0)
							{
								int num18 = 0;
								int num19 = (int)(((float)Main.mouseX + Main.screenPosition.X) / 16f);
								int num20 = (int)(((float)Main.mouseY + Main.screenPosition.Y) / 16f);
								if (this.gravDir == -1f)
								{
									num20 = (int)((Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY) / 16f);
								}
								if (this.position.X / 16f - (float)Player.tileRangeX <= (float)num19 && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX - 1f >= (float)num19 && this.position.Y / 16f - (float)Player.tileRangeY <= (float)num20 && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY - 2f >= (float)num20)
								{
									try
									{
										if (Main.tile[num19, num20].active())
										{
											int type = (int)Main.tile[num19, num20].type;
											if (type == 209)
											{
												num18 = 6;
											}
											else
											{
												if (Main.tileHammer[type])
												{
													num18 = 1;
												}
												else
												{
													if (Main.tileAxe[type])
													{
														num18 = 2;
													}
													else
													{
														num18 = 3;
													}
												}
											}
										}
										else
										{
											if (Main.tile[num19, num20].liquid > 0 && this.wet)
											{
												num18 = 4;
											}
										}
										goto IL_181C;
									}
									catch
									{
										goto IL_181C;
									}
								}
								if (this.wet)
								{
									num18 = 4;
								}
								IL_181C:
								if (num18 == 0 || num18 == 4)
								{
									float num21 = Math.Abs((float)Main.mouseX + Main.screenPosition.X - (this.position.X + (float)(this.width / 2)));
									float num22 = Math.Abs((float)Main.mouseY + Main.screenPosition.Y - (this.position.Y + (float)(this.height / 2))) * 1.3f;
									float num23 = (float)Math.Sqrt((double)(num21 * num21 + num22 * num22));
									if (num23 > 200f)
									{
										num18 = 5;
									}
								}
								for (int num24 = 0; num24 < 50; num24++)
								{
									int type2 = this.inventory[num24].type;
									if (num18 == 0)
									{
										if (type2 == 8 || type2 == 427 || type2 == 428 || type2 == 429 || type2 == 430 || type2 == 431 || type2 == 432 || type2 == 433 || type2 == 523 || type2 == 974 || type2 == 1245 || type2 == 1333 || type2 == 2274)
										{
											if (this.nonTorch == -1)
											{
												this.nonTorch = this.selectedItem;
											}
											this.selectedItem = num24;
											break;
										}
										if (type2 == 282 || type2 == 286)
										{
											if (this.nonTorch == -1)
											{
												this.nonTorch = this.selectedItem;
											}
											this.selectedItem = num24;
										}
									}
									else
									{
										if (num18 == 1)
										{
											if (this.inventory[num24].hammer > 0)
											{
												if (this.nonTorch == -1)
												{
													this.nonTorch = this.selectedItem;
												}
												this.selectedItem = num24;
												break;
											}
										}
										else
										{
											if (num18 == 2)
											{
												if (this.inventory[num24].axe > 0)
												{
													if (this.nonTorch == -1)
													{
														this.nonTorch = this.selectedItem;
													}
													this.selectedItem = num24;
													break;
												}
											}
											else
											{
												if (num18 == 3)
												{
													if (this.inventory[num24].pick > 0)
													{
														if (this.nonTorch == -1)
														{
															this.nonTorch = this.selectedItem;
														}
														this.selectedItem = num24;
														break;
													}
												}
												else
												{
													if (num18 == 4)
													{
														if (this.inventory[this.selectedItem].type != 282 && this.inventory[this.selectedItem].type != 286 && (type2 == 8 || type2 == 427 || type2 == 428 || type2 == 429 || type2 == 430 || type2 == 431 || type2 == 432 || type2 == 433 || type2 == 974 || type2 == 1245 || type2 == 2274))
														{
															if (this.nonTorch == -1)
															{
																this.nonTorch = this.selectedItem;
															}
															if (this.inventory[this.selectedItem].createTile != 4)
															{
																this.selectedItem = num24;
															}
														}
														else
														{
															if (type2 == 282 || type2 == 286)
															{
																if (this.nonTorch == -1)
																{
																	this.nonTorch = this.selectedItem;
																}
																this.selectedItem = num24;
															}
															else
															{
																if (type2 == 930)
																{
																	bool flag7 = false;
																	for (int num25 = 57; num25 >= 0; num25--)
																	{
																		if (this.inventory[num25].ammo == this.inventory[num24].useAmmo)
																		{
																			flag7 = true;
																			break;
																		}
																	}
																	if (flag7)
																	{
																		if (this.nonTorch == -1)
																		{
																			this.nonTorch = this.selectedItem;
																		}
																		this.selectedItem = num24;
																		break;
																	}
																}
																else
																{
																	if (type2 == 1333 || type2 == 523)
																	{
																		if (this.nonTorch == -1)
																		{
																			this.nonTorch = this.selectedItem;
																		}
																		this.selectedItem = num24;
																		break;
																	}
																}
															}
														}
													}
													else
													{
														if (num18 == 5)
														{
															if (type2 == 8 || type2 == 427 || type2 == 428 || type2 == 429 || type2 == 430 || type2 == 431 || type2 == 432 || type2 == 433 || type2 == 523 || type2 == 974 || type2 == 1245 || type2 == 1333 || type2 == 2274)
															{
																if (this.nonTorch == -1)
																{
																	this.nonTorch = this.selectedItem;
																}
																if (this.inventory[this.selectedItem].createTile != 4)
																{
																	this.selectedItem = num24;
																}
															}
															else
															{
																if (type2 == 930)
																{
																	bool flag8 = false;
																	for (int num26 = 57; num26 >= 0; num26--)
																	{
																		if (this.inventory[num26].ammo == this.inventory[num24].useAmmo)
																		{
																			flag8 = true;
																			break;
																		}
																	}
																	if (flag8)
																	{
																		if (this.nonTorch == -1)
																		{
																			this.nonTorch = this.selectedItem;
																		}
																		this.selectedItem = num24;
																		break;
																	}
																}
																else
																{
																	if (type2 == 282 || type2 == 286)
																	{
																		if (this.nonTorch == -1)
																		{
																			this.nonTorch = this.selectedItem;
																		}
																		this.selectedItem = num24;
																		break;
																	}
																}
															}
														}
														else
														{
															if (num18 == 6)
															{
																int num27 = 929;
																if (Main.tile[num19, num20].frameX >= 72)
																{
																	num27 = 1338;
																}
																if (type2 == num27)
																{
																	if (this.nonTorch == -1)
																	{
																		this.nonTorch = this.selectedItem;
																	}
																	this.selectedItem = num24;
																	break;
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
							else
							{
								if (this.nonTorch > -1 && this.itemAnimation == 0)
								{
									this.selectedItem = this.nonTorch;
									this.nonTorch = -1;
								}
							}
						}
						if (this.frozen)
						{
							this.controlJump = false;
							this.controlDown = false;
							this.controlLeft = false;
							this.controlRight = false;
							this.controlUp = false;
							this.controlUseItem = false;
							this.controlUseTile = false;
							this.controlThrow = false;
						}
						if (!this.controlThrow)
						{
							this.releaseThrow = true;
						}
						else
						{
							this.releaseThrow = false;
						}
						if (Main.netMode == 1)
						{
							bool flag9 = false;
							if (this.controlUp != Main.clientPlayer.controlUp)
							{
								flag9 = true;
							}
							if (this.controlDown != Main.clientPlayer.controlDown)
							{
								flag9 = true;
							}
							if (this.controlLeft != Main.clientPlayer.controlLeft)
							{
								flag9 = true;
							}
							if (this.controlRight != Main.clientPlayer.controlRight)
							{
								flag9 = true;
							}
							if (this.controlJump != Main.clientPlayer.controlJump)
							{
								flag9 = true;
							}
							if (this.controlUseItem != Main.clientPlayer.controlUseItem)
							{
								flag9 = true;
							}
							if (this.selectedItem != Main.clientPlayer.selectedItem)
							{
								flag9 = true;
							}
							if (flag9)
							{
								NetMessage.SendData(13, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
							}
						}
						if (Main.playerInventory)
						{
							this.AdjTiles();
						}
						if (this.chest != -1)
						{
							int num28 = (int)(((double)this.position.X + (double)this.width * 0.5) / 16.0);
							int num29 = (int)(((double)this.position.Y + (double)this.height * 0.5) / 16.0);
							if (num28 < this.chestX - Player.tileRangeX || num28 > this.chestX + Player.tileRangeX + 1 || num29 < this.chestY - Player.tileRangeY || num29 > this.chestY + Player.tileRangeY + 1)
							{
								if (this.chest != -1)
								{
									Main.PlaySound(11, -1, -1, 1);
								}
								this.chest = -1;
							}
							if (!Main.tile[this.chestX, this.chestY].active())
							{
								Main.PlaySound(11, -1, -1, 1);
								this.chest = -1;
							}
						}
						if (this.velocity.Y == 0f)
						{
							int num30 = 25;
							if (this.mount == 1)
							{
								num30 = 32;
							}
							int num31 = (int)(this.position.Y / 16f) - this.fallStart;
							if (this.mount == 1)
							{
								num31 = 0;
							}
							if (((this.gravDir == 1f && num31 > num30) || (this.gravDir == -1f && num31 < -num30)) && !this.noFallDmg && this.wingsLogic == 0)
							{
								int num32 = (int)((float)num31 * this.gravDir - (float)num30) * 10;
								if (this.mount == 1)
								{
									num32 = (int)((double)num32 * 0.8);
								}
								this.immune = false;
								this.Hurt(num32, 0, false, false, Lang.deathMsg(-1, -1, -1, 0), false);
							}
							this.fallStart = (int)(this.position.Y / 16f);
						}
						if (this.jump > 0 || this.rocketDelay > 0 || this.wet || this.slowFall || (double)num10 < 0.8 || this.tongued)
						{
							this.fallStart = (int)(this.position.Y / 16f);
						}
					}
					if (this.mouseInterface)
					{
						this.delayUseItem = true;
					}
					Player.tileTargetX = (int)(((float)Main.mouseX + Main.screenPosition.X) / 16f);
					Player.tileTargetY = (int)(((float)Main.mouseY + Main.screenPosition.Y) / 16f);
					if (Player.tileTargetX >= Main.maxTilesX)
					{
						Player.tileTargetX = Main.maxTilesX - 5;
					}
					if (Player.tileTargetY >= Main.maxTilesY)
					{
						Player.tileTargetY = Main.maxTilesY - 5;
					}
					if (this.gravDir == -1f)
					{
						Player.tileTargetY = (int)((Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY) / 16f);
					}
					if (this.immune)
					{
						this.immuneTime--;
						if (this.immuneTime <= 0)
						{
							this.immune = false;
						}
						this.immuneAlpha += this.immuneAlphaDirection * 50;
						if (this.immuneAlpha <= 50)
						{
							this.immuneAlphaDirection = 1;
						}
						else
						{
							if (this.immuneAlpha >= 205)
							{
								this.immuneAlphaDirection = -1;
							}
						}
					}
					else
					{
						this.immuneAlpha = 0;
					}
					if (this.petalTimer > 0)
					{
						this.petalTimer--;
					}
					if (this.shadowDodgeTimer > 0)
					{
						this.shadowDodgeTimer--;
					}
					if (this.jump > 0 || this.velocity.Y != 0f)
					{
						this.slippy = false;
						this.slippy2 = false;
						this.powerrun = false;
						this.sticky = false;
					}
					this.potionDelayTime = Item.potionDelay;
					if (this.pStone)
					{
						this.potionDelayTime -= 900;
					}
					this.armorSteath = false;
					this.statDefense = 0;
					this.accWatch = 0;
					this.accCompass = 0;
					this.accDepthMeter = 0;
					this.accDivingHelm = false;
					this.lifeRegen = 0;
					this.manaCost = 1f;
					this.meleeSpeed = 1f;
					this.meleeDamage = 1f;
					this.rangedDamage = 1f;
					this.magicDamage = 1f;
					this.minionDamage = 1f;
					this.minionKB = 0f;
					this.moveSpeed = 1f;
					this.boneArmor = false;
					this.honey = false;
					this.frostArmor = false;
					this.rocketBoots = 0;
					this.fireWalk = false;
					this.noKnockback = false;
					this.jumpBoost = false;
					this.noFallDmg = false;
					this.accFlipper = false;
					this.spawnMax = false;
					this.spaceGun = false;
					this.killGuide = false;
					this.killClothier = false;
					this.lavaImmune = false;
					this.gills = false;
					this.slowFall = false;
					this.findTreasure = false;
					this.invis = false;
					this.nightVision = false;
					this.enemySpawns = false;
					this.thorns = false;
					this.aggro = 0;
					this.waterWalk = false;
					this.waterWalk2 = false;
					this.detectCreature = false;
					this.gravControl = false;
					this.bee = false;
					this.gravControl2 = false;
					this.statManaMax2 = this.statManaMax;
					this.ammoCost80 = false;
					this.ammoCost75 = false;
					this.manaRegenBuff = false;
					this.meleeCrit = 4;
					this.rangedCrit = 4;
					this.magicCrit = 4;
					this.arrowDamage = 1f;
					this.bulletDamage = 1f;
					this.rocketDamage = 1f;
					this.lightOrb = false;
					this.blueFairy = false;
					this.redFairy = false;
					this.greenFairy = false;
					this.wisp = false;
					this.bunny = false;
					this.turtle = false;
					this.eater = false;
					this.skeletron = false;
					this.hornet = false;
					this.tiki = false;
					this.lizard = false;
					this.parrot = false;
					this.sapling = false;
					this.cSapling = false;
					this.truffle = false;
					this.shadowDodge = false;
					this.palladiumRegen = false;
					this.chaosState = false;
					this.onHitDodge = false;
					this.onHitRegen = false;
					this.onHitPetal = false;
					this.iceBarrier = false;
					this.maxMinions = 1;
					this.ammoBox = false;
					this.penguin = false;
					this.manaMagnet = false;
					this.beetleOrbs = 0;
					this.beetleBuff = false;
					this.wallSpeed = 1f;
					this.tileSpeed = 1f;
					this.autoPaint = false;
					this.manaSick = false;
					this.puppy = false;
					this.grinch = false;
					this.blackCat = false;
					this.spider = false;
					this.squashling = false;
					this.magicCuffs = false;
					this.coldDash = false;
					this.magicQuiver = false;
					this.magmaStone = false;
					this.lavaRose = false;
					this.eyeSpring = false;
					this.snowman = false;
					this.scope = false;
					this.panic = false;
					this.dino = false;
					this.crystalLeaf = false;
					this.pygmy = false;
					this.raven = false;
					this.slime = false;
					this.chilled = false;
					this.frozen = false;
					this.ichor = false;
					this.manaRegenBonus = 0;
					this.manaRegenDelayBonus = 0;
					this.carpet = false;
					this.iceSkate = false;
					this.dash = 0;
					this.spikedBoots = 0;
					this.blackBelt = false;
					this.lavaMax = 0;
					this.archery = false;
					this.poisoned = false;
					this.venom = false;
					this.blind = false;
					this.blackout = false;
					this.onFire = false;
					this.dripping = false;
					this.burned = false;
					this.suffocating = false;
					this.onFire2 = false;
					this.onFrostBurn = false;
					this.frostBurn = false;
					this.noItems = false;
					this.blockRange = 0;
					this.pickSpeed = 1f;
					this.wereWolf = false;
					this.rulerAcc = false;
					this.bleed = false;
					this.confused = false;
					this.wings = 0;
					this.wingsLogic = 0;
					this.wingTimeMax = 0;
					this.brokenArmor = false;
					this.silence = false;
					this.slow = false;
					this.gross = false;
					this.tongued = false;
					this.kbGlove = false;
					this.starCloak = false;
					this.longInvince = false;
					this.pStone = false;
					this.manaFlower = false;
					this.crimsonRegen = false;
					this.ghostHeal = false;
					this.ghostHurt = false;
					this.turtleArmor = false;
					this.turtleThorns = false;
					this.meleeEnchant = 0;
					this.discount = false;
					this.coins = false;
					this.doubleJump2 = false;
					this.doubleJump3 = false;
					this.doubleJump4 = false;
					this.paladinBuff = false;
					this.paladinGive = false;
					this.meleeCrit += this.inventory[this.selectedItem].crit;
					this.magicCrit += this.inventory[this.selectedItem].crit;
					this.rangedCrit += this.inventory[this.selectedItem].crit;
					Player.tileRangeX = 5;
					Player.tileRangeY = 4;
					this.mount = 0;
					if (this.whoAmi == Main.myPlayer)
					{
						Main.musicBox2 = -1;
						if (Main.waterCandles > 0)
						{
							this.AddBuff(86, 2, false);
						}
						if (Main.campfire)
						{
							this.AddBuff(87, 2, false);
						}
						if (Main.heartLantern)
						{
							this.AddBuff(89, 2, false);
						}
					}
					for (int num33 = 0; num33 < 104; num33++)
					{
						this.buffImmune[num33] = false;
					}
					this.UpdatePlayerBuffs(i);
					if (this.accMerman && this.wet && !this.lavaWet)
					{
						this.releaseJump = true;
						this.wings = 0;
						this.wingsLogic = 0;
						this.merman = true;
						this.accFlipper = true;
						this.AddBuff(34, 2, true);
					}
					else
					{
						this.merman = false;
					}
					this.accMerman = false;
					if (this.wolfAcc && !this.merman && !Main.dayTime && !this.wereWolf)
					{
						this.AddBuff(28, 60, true);
					}
					this.wolfAcc = false;
					if (this.whoAmi == Main.myPlayer)
					{
						for (int num34 = 0; num34 < 22; num34++)
						{
							if (this.buffType[num34] > 0 && this.buffTime[num34] <= 0)
							{
								this.DelBuff(num34);
							}
						}
					}
					this.beetleDefense = false;
					this.beetleOffense = false;
					this.doubleJump = false;
					this.head = this.armor[0].headSlot;
					this.body = this.armor[1].bodySlot;
					this.legs = this.armor[2].legSlot;
					this.handon = -1;
					this.handoff = -1;
					this.back = -1;
					this.front = -1;
					this.shoe = -1;
					this.waist = -1;
					this.shield = -1;
					this.neck = -1;
					this.face = -1;
					this.balloon = -1;
					this.UpdatePlayerEquips(i);
					this.gemCount++;
					if (this.gemCount >= 10)
					{
						this.gem = -1;
						this.gemCount = 0;
						for (int num35 = 0; num35 <= 58; num35++)
						{
							if (this.inventory[num35].type == 0 || this.inventory[num35].stack == 0)
							{
								this.inventory[num35].type = 0;
								this.inventory[num35].stack = 0;
								this.inventory[num35].name = "";
								this.inventory[num35].netID = 0;
							}
							if (this.inventory[num35].type >= 1522 && this.inventory[num35].type <= 1527)
							{
								this.gem = this.inventory[num35].type - 1522;
							}
						}
					}
					if (this.head == 11)
					{
						int i2 = (int)(this.position.X + (float)(this.width / 2) + (float)(8 * this.direction)) / 16;
						int j2 = (int)(this.position.Y + 2f) / 16;
						Lighting.addLight(i2, j2, 0.92f, 0.8f, 0.65f);
					}
					this.UpdatePlayerArmorSets(i);
					if (this.merman)
					{
						this.wings = 0;
						this.wingsLogic = 0;
					}
					if (this.armorSteath)
					{
						if (this.itemAnimation > 0)
						{
							this.stealthTimer = 5;
						}
						if ((double)this.velocity.X > -0.1 && (double)this.velocity.X < 0.1 && (double)this.velocity.Y > -0.1 && (double)this.velocity.Y < 0.1)
						{
							if (this.stealthTimer == 0)
							{
								this.stealth -= 0.015f;
								if ((double)this.stealth < 0.0)
								{
									this.stealth = 0f;
								}
							}
						}
						else
						{
							float num36 = Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y);
							this.stealth += num36 * 0.0075f;
							if (this.stealth > 1f)
							{
								this.stealth = 1f;
							}
						}
						this.rangedDamage += (1f - this.stealth) * 0.6f;
						this.rangedCrit += (int)((1f - this.stealth) * 10f);
						this.aggro -= (int)((1f - this.stealth) * 750f);
						if (this.stealthTimer > 0)
						{
							this.stealthTimer--;
						}
					}
					else
					{
						this.stealth = 1f;
					}
					if (this.manaSick)
					{
						this.magicDamage *= 1f - this.manaSickReduction;
					}
					if (this.inventory[this.selectedItem].type == 1947)
					{
						this.meleeSpeed = (1f + this.meleeSpeed) / 2f;
					}
					if ((double)this.pickSpeed < 0.3)
					{
						this.pickSpeed = 0.3f;
					}
					if (this.meleeSpeed > 3f)
					{
						this.meleeSpeed = 3f;
					}
					if ((double)this.moveSpeed > 1.6)
					{
						this.moveSpeed = 1.6f;
					}
					if (this.tileSpeed > 3f)
					{
						this.tileSpeed = 3f;
					}
					this.tileSpeed = 1f / this.tileSpeed;
					if (this.wallSpeed > 3f)
					{
						this.wallSpeed = 3f;
					}
					this.wallSpeed = 1f / this.wallSpeed;
					if (this.slow)
					{
						this.moveSpeed *= 0.5f;
					}
					if (this.chilled)
					{
						this.moveSpeed *= 0.75f;
					}
					if (this.statManaMax2 > 400)
					{
						this.statManaMax2 = 400;
					}
					if (this.statDefense < 0)
					{
						this.statDefense = 0;
					}
					this.meleeSpeed = 1f / this.meleeSpeed;
					if (this.poisoned)
					{
						if (this.lifeRegen > 0)
						{
							this.lifeRegen = 0;
						}
						this.lifeRegenTime = 0;
						this.lifeRegen -= 4;
					}
					else
					{
						if (this.venom)
						{
							if (this.lifeRegen > 0)
							{
								this.lifeRegen = 0;
							}
							this.lifeRegenTime = 0;
							this.lifeRegen -= 12;
						}
					}
					if (this.onFire)
					{
						if (this.lifeRegen > 0)
						{
							this.lifeRegen = 0;
						}
						this.lifeRegenTime = 0;
						this.lifeRegen -= 8;
					}
					if (this.onFrostBurn)
					{
						if (this.lifeRegen > 0)
						{
							this.lifeRegen = 0;
						}
						this.lifeRegenTime = 0;
						this.lifeRegen -= 12;
					}
					if (this.onFire2)
					{
						if (this.lifeRegen > 0)
						{
							this.lifeRegen = 0;
						}
						this.lifeRegenTime = 0;
						this.lifeRegen -= 12;
					}
					if (this.burned)
					{
						if (this.lifeRegen > 0)
						{
							this.lifeRegen = 0;
						}
						this.lifeRegenTime = 0;
						this.lifeRegen -= 60;
						this.moveSpeed *= 0.5f;
					}
					if (this.suffocating)
					{
						if (this.lifeRegen > 0)
						{
							this.lifeRegen = 0;
						}
						this.lifeRegenTime = 0;
						this.lifeRegen -= 40;
					}
					this.lifeRegenTime++;
					if (this.crimsonRegen)
					{
						this.lifeRegenTime++;
					}
					if (this.honey)
					{
						this.lifeRegenTime += 2;
						this.lifeRegen += 2;
					}
					if (this.whoAmi == Main.myPlayer && Main.campfire)
					{
						this.lifeRegen++;
					}
					if (this.whoAmi == Main.myPlayer && Main.heartLantern)
					{
						this.lifeRegen += 2;
					}
					if (this.bleed)
					{
						this.lifeRegenTime = 0;
					}
					float num37 = 0f;
					if (this.lifeRegenTime >= 300)
					{
						num37 += 1f;
					}
					if (this.lifeRegenTime >= 600)
					{
						num37 += 1f;
					}
					if (this.lifeRegenTime >= 900)
					{
						num37 += 1f;
					}
					if (this.lifeRegenTime >= 1200)
					{
						num37 += 1f;
					}
					if (this.lifeRegenTime >= 1500)
					{
						num37 += 1f;
					}
					if (this.lifeRegenTime >= 1800)
					{
						num37 += 1f;
					}
					if (this.lifeRegenTime >= 2400)
					{
						num37 += 1f;
					}
					if (this.lifeRegenTime >= 3000)
					{
						num37 += 1f;
					}
					if (this.lifeRegenTime >= 3600)
					{
						num37 += 1f;
						this.lifeRegenTime = 3600;
					}
					if (this.velocity.X == 0f || this.grappling[0] > 0)
					{
						num37 *= 1.25f;
					}
					else
					{
						num37 *= 0.5f;
					}
					if (this.crimsonRegen)
					{
						num37 *= 1.5f;
					}
					if (this.whoAmi == Main.myPlayer && Main.campfire)
					{
						num37 *= 1.1f;
					}
					float num38 = (float)this.statLifeMax / 400f * 0.85f + 0.15f;
					num37 *= num38;
					this.lifeRegen += (int)Math.Round((double)num37);
					this.lifeRegenCount += this.lifeRegen;
					if (this.palladiumRegen)
					{
						this.lifeRegenCount += 6;
					}
					while (this.lifeRegenCount >= 120)
					{
						this.lifeRegenCount -= 120;
						if (this.statLife < this.statLifeMax)
						{
							this.statLife++;
							if (this.crimsonRegen)
							{
								for (int num39 = 0; num39 < 10; num39++)
								{
									int num40 = Dust.NewDust(this.position, this.width, this.height, 5, 0f, 0f, 175, default(Color), 1.75f);
									Main.dust[num40].noGravity = true;
									Main.dust[num40].velocity *= 0.75f;
									int num41 = Main.rand.Next(-40, 41);
									int num42 = Main.rand.Next(-40, 41);
									Dust expr_3251_cp_0 = Main.dust[num40];
									expr_3251_cp_0.position.X = expr_3251_cp_0.position.X + (float)num41;
									Dust expr_326D_cp_0 = Main.dust[num40];
									expr_326D_cp_0.position.Y = expr_326D_cp_0.position.Y + (float)num42;
									Main.dust[num40].velocity.X = (float)(-(float)num41) * 0.075f;
									Main.dust[num40].velocity.Y = (float)(-(float)num42) * 0.075f;
								}
							}
						}
						if (this.statLife > this.statLifeMax)
						{
							this.statLife = this.statLifeMax;
						}
					}
					if (!this.burned)
					{
						if (!this.suffocating)
						{
							while (this.lifeRegenCount <= -120)
							{
								if (this.lifeRegenCount <= -480)
								{
									this.lifeRegenCount += 480;
									this.statLife -= 4;
									CombatText.NewText(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height), new Color(255, 60, 70, 255), string.Concat(4), false, true);
								}
								else
								{
									if (this.lifeRegenCount <= -360)
									{
										this.lifeRegenCount += 360;
										this.statLife -= 3;
										CombatText.NewText(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height), new Color(255, 60, 70, 255), string.Concat(3), false, true);
									}
									else
									{
										if (this.lifeRegenCount <= -240)
										{
											this.lifeRegenCount += 240;
											this.statLife -= 2;
											CombatText.NewText(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height), new Color(255, 60, 70, 255), string.Concat(2), false, true);
										}
										else
										{
											this.lifeRegenCount += 120;
											this.statLife--;
											CombatText.NewText(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height), new Color(255, 60, 70, 255), string.Concat(1), false, true);
										}
									}
								}
								if (this.statLife <= 0 && this.whoAmi == Main.myPlayer)
								{
									if (this.poisoned || this.venom)
									{
										this.KillMe(10.0, 0, false, " " + Lang.dt[0]);
									}
									else
									{
										this.KillMe(10.0, 0, false, " " + Lang.dt[1]);
									}
								}
							}
							goto IL_364D;
						}
					}
					while (this.lifeRegenCount <= -600)
					{
						this.lifeRegenCount += 600;
						this.statLife -= 5;
						CombatText.NewText(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height), new Color(255, 60, 70, 255), string.Concat(5), false, true);
						if (this.statLife <= 0 && this.whoAmi == Main.myPlayer)
						{
							if (this.suffocating)
							{
								this.KillMe(10.0, 0, false, " " + Lang.dt[2]);
							}
							else
							{
								this.KillMe(10.0, 0, false, " " + Lang.dt[1]);
							}
						}
					}
					IL_364D:
					if (this.manaRegenDelay > 0)
					{
						this.manaRegenDelay--;
						this.manaRegenDelay -= this.manaRegenDelayBonus;
						if ((this.velocity.X == 0f && this.velocity.Y == 0f) || this.grappling[0] >= 0 || this.manaRegenBuff)
						{
							this.manaRegenDelay--;
						}
					}
					if (this.manaRegenBuff && this.manaRegenDelay > 20)
					{
						this.manaRegenDelay = 20;
					}
					if (this.manaRegenDelay <= 0)
					{
						this.manaRegenDelay = 0;
						this.manaRegen = this.statManaMax2 / 7 + 1 + this.manaRegenBonus;
						if ((this.velocity.X == 0f && this.velocity.Y == 0f) || this.grappling[0] >= 0 || this.manaRegenBuff)
						{
							this.manaRegen += this.statManaMax2 / 2;
						}
						float num43 = (float)this.statMana / (float)this.statManaMax2 * 0.8f + 0.2f;
						if (this.manaRegenBuff)
						{
							num43 = 1f;
						}
						this.manaRegen = (int)((double)((float)this.manaRegen * num43) * 1.15);
					}
					else
					{
						this.manaRegen = 0;
					}
					this.manaRegenCount += this.manaRegen;
					while (this.manaRegenCount >= 120)
					{
						bool flag10 = false;
						this.manaRegenCount -= 120;
						if (this.statMana < this.statManaMax2)
						{
							this.statMana++;
							flag10 = true;
						}
						if (this.statMana >= this.statManaMax2)
						{
							if (this.whoAmi == Main.myPlayer && flag10)
							{
								Main.PlaySound(25, -1, -1, 1);
								for (int num44 = 0; num44 < 5; num44++)
								{
									int num45 = Dust.NewDust(this.position, this.width, this.height, 45, 0f, 0f, 255, default(Color), (float)Main.rand.Next(20, 26) * 0.1f);
									Main.dust[num45].noLight = true;
									Main.dust[num45].noGravity = true;
									Main.dust[num45].velocity *= 0.5f;
								}
							}
							this.statMana = this.statManaMax2;
						}
					}
					if (this.manaRegenCount < 0)
					{
						this.manaRegenCount = 0;
					}
					if (this.statMana > this.statManaMax2)
					{
						this.statMana = this.statManaMax2;
					}
					num4 *= this.moveSpeed;
					num3 *= this.moveSpeed;
					if (this.mount == 1)
					{
						Player.jumpHeight = 17 + (int)(Math.Abs(this.velocity.X) / 4f);
						Player.jumpSpeed = 5.31f + Math.Abs(this.velocity.X) / 3f;
					}
					else
					{
						if (this.jumpBoost)
						{
							Player.jumpHeight = 20;
							Player.jumpSpeed = 6.51f;
						}
						if (this.wereWolf)
						{
							Player.jumpHeight += 2;
							Player.jumpSpeed += 0.2f;
						}
					}
					if (this.sticky)
					{
						Player.jumpHeight /= 10;
						Player.jumpSpeed /= 5f;
					}
					for (int num46 = 0; num46 < 22; num46++)
					{
						if (this.buffType[num46] > 0 && this.buffTime[num46] > 0 && this.buffImmune[this.buffType[num46]])
						{
							this.DelBuff(num46);
						}
					}
					if (this.brokenArmor)
					{
						this.statDefense /= 2;
					}
					if (!this.doubleJump)
					{
						this.jumpAgain = false;
					}
					else
					{
						if (this.velocity.Y == 0f || this.sliding)
						{
							this.jumpAgain = true;
						}
					}
					if (!this.doubleJump2)
					{
						this.jumpAgain2 = false;
					}
					else
					{
						if (this.velocity.Y == 0f || this.sliding)
						{
							this.jumpAgain2 = true;
						}
					}
					if (!this.doubleJump3)
					{
						this.jumpAgain3 = false;
					}
					else
					{
						if (this.velocity.Y == 0f || this.sliding)
						{
							this.jumpAgain3 = true;
						}
					}
					if (!this.doubleJump4)
					{
						this.jumpAgain4 = false;
					}
					else
					{
						if (this.velocity.Y == 0f || this.sliding)
						{
							this.jumpAgain4 = true;
						}
					}
					if (!this.carpet)
					{
						this.canCarpet = false;
						this.carpetFrame = -1;
					}
					else
					{
						if (this.velocity.Y == 0f || this.sliding)
						{
							this.canCarpet = true;
							this.carpetTime = 0;
							this.carpetFrame = -1;
							this.carpetFrameCounter = 0f;
						}
					}
					if (this.gravDir == -1f)
					{
						this.canCarpet = false;
					}
					if (this.ropeCount > 0)
					{
						this.ropeCount--;
					}
					if (!this.pulley && !this.frozen && !this.controlJump && this.gravDir == 1f && this.ropeCount == 0 && this.grappling[0] == -1 && !this.tongued && this.mount == 0 && (this.controlUp || this.controlDown))
					{
						int num47 = (int)(this.position.X + (float)(this.width / 2)) / 16;
						int num48 = (int)(this.position.Y - 8f) / 16;
						if (Main.tile[num47, num48].active() && Main.tileRope[(int)Main.tile[num47, num48].type])
						{
							float num49 = this.position.Y;
							if (Main.tile[num47, num48 - 1] == null)
							{
								Main.tile[num47, num48 - 1] = new Tile();
							}
							if (Main.tile[num47, num48 + 1] == null)
							{
								Main.tile[num47, num48 + 1] = new Tile();
							}
							if ((!Main.tile[num47, num48 - 1].active() || !Main.tileRope[(int)Main.tile[num47, num48 - 1].type]) && (!Main.tile[num47, num48 + 1].active() || !Main.tileRope[(int)Main.tile[num47, num48 + 1].type]))
							{
								num49 = (float)(num48 * 16 + 22);
							}
							float num50 = (float)(num47 * 16 + 8 - this.width / 2 + 6 * this.direction);
							int num51 = num47 * 16 + 8 - this.width / 2 + 6;
							int num52 = num47 * 16 + 8 - this.width / 2;
							int num53 = num47 * 16 + 8 - this.width / 2 + -6;
							int num54 = 1;
							float num55 = Math.Abs(this.position.X - (float)num51);
							if (Math.Abs(this.position.X - (float)num52) < num55)
							{
								num54 = 2;
								num55 = Math.Abs(this.position.X - (float)num52);
							}
							if (Math.Abs(this.position.X - (float)num53) < num55)
							{
								num54 = 3;
								num55 = Math.Abs(this.position.X - (float)num53);
							}
							if (num54 == 1)
							{
								num50 = (float)num51;
								this.pulleyDir = 2;
								this.direction = 1;
							}
							if (num54 == 2)
							{
								num50 = (float)num52;
								this.pulleyDir = 1;
							}
							if (num54 == 3)
							{
								num50 = (float)num53;
								this.pulleyDir = 2;
								this.direction = -1;
							}
							if (!Collision.SolidCollision(new Vector2(num50, this.position.Y), this.width, this.height))
							{
								if (i == Main.myPlayer)
								{
									Main.cameraX = Main.cameraX + this.position.X - num50;
								}
								this.pulley = true;
								this.position.X = num50;
								this.gfxOffY = this.position.Y - num49;
								this.stepSpeed = 2.5f;
								this.position.Y = num49;
								this.velocity.X = 0f;
							}
							else
							{
								num50 = (float)num51;
								this.pulleyDir = 2;
								this.direction = 1;
								if (!Collision.SolidCollision(new Vector2(num50, this.position.Y), this.width, this.height))
								{
									if (i == Main.myPlayer)
									{
										Main.cameraX = Main.cameraX + this.position.X - num50;
									}
									this.pulley = true;
									this.position.X = num50;
									this.gfxOffY = this.position.Y - num49;
									this.stepSpeed = 2.5f;
									this.position.Y = num49;
									this.velocity.X = 0f;
								}
								else
								{
									num50 = (float)num53;
									this.pulleyDir = 2;
									this.direction = -1;
									if (!Collision.SolidCollision(new Vector2(num50, this.position.Y), this.width, this.height))
									{
										if (i == Main.myPlayer)
										{
											Main.cameraX = Main.cameraX + this.position.X - num50;
										}
										this.pulley = true;
										this.position.X = num50;
										this.gfxOffY = this.position.Y - num49;
										this.stepSpeed = 2.5f;
										this.position.Y = num49;
										this.velocity.X = 0f;
									}
								}
							}
						}
					}
					if (this.pulley)
					{
						this.sandStorm = false;
						this.dJumpEffect = false;
						this.dJumpEffect2 = false;
						this.dJumpEffect3 = false;
						this.dJumpEffect4 = false;
						int num56 = (int)(this.position.X + (float)(this.width / 2)) / 16;
						int num57 = (int)(this.position.Y - 8f) / 16;
						bool flag11 = false;
						if (this.pulleyDir == 0)
						{
							this.pulleyDir = 1;
						}
						if (this.pulleyDir == 1)
						{
							if (this.direction == -1 && this.controlLeft && (this.releaseLeft || this.leftTimer == 0))
							{
								this.pulleyDir = 2;
								flag11 = true;
							}
							else
							{
								if ((this.direction == 1 && this.controlRight && this.releaseRight) || this.rightTimer == 0)
								{
									this.pulleyDir = 2;
									flag11 = true;
								}
								else
								{
									if (this.direction == 1 && this.controlLeft)
									{
										this.direction = -1;
										flag11 = true;
									}
									if (this.direction == -1 && this.controlRight)
									{
										this.direction = 1;
										flag11 = true;
									}
								}
							}
						}
						else
						{
							if (this.pulleyDir == 2)
							{
								if (this.direction == 1 && this.controlLeft)
								{
									flag11 = true;
									int num58 = num56 * 16 + 8 - this.width / 2;
									if (!Collision.SolidCollision(new Vector2((float)num58, this.position.Y), this.width, this.height))
									{
										this.pulleyDir = 1;
										this.direction = -1;
										flag11 = true;
									}
								}
								if (this.direction == -1 && this.controlRight)
								{
									flag11 = true;
									int num59 = num56 * 16 + 8 - this.width / 2;
									if (!Collision.SolidCollision(new Vector2((float)num59, this.position.Y), this.width, this.height))
									{
										this.pulleyDir = 1;
										this.direction = 1;
										flag11 = true;
									}
								}
							}
						}
						bool flag12 = false;
						if (!flag11 && ((this.controlLeft && (this.releaseLeft || this.leftTimer == 0)) || (this.controlRight && (this.releaseRight || this.rightTimer == 0))))
						{
							int num60 = 1;
							if (this.controlLeft)
							{
								num60 = -1;
							}
							int num61 = num56 + num60;
							if (Main.tile[num61, num57].active() && Main.tileRope[(int)Main.tile[num61, num57].type])
							{
								this.pulleyDir = 1;
								this.direction = num60;
								int num62 = num61 * 16 + 8 - this.width / 2;
								float num63 = this.position.Y;
								num63 = (float)(num57 * 16 + 22);
								if ((!Main.tile[num61, num57 - 1].active() || !Main.tileRope[(int)Main.tile[num61, num57 - 1].type]) && (!Main.tile[num61, num57 + 1].active() || !Main.tileRope[(int)Main.tile[num61, num57 + 1].type]))
								{
									num63 = (float)(num57 * 16 + 22);
								}
								if (Collision.SolidCollision(new Vector2((float)num62, num63), this.width, this.height))
								{
									this.pulleyDir = 2;
									this.direction = -num60;
									if (this.direction == 1)
									{
										num62 = num61 * 16 + 8 - this.width / 2 + 6;
									}
									else
									{
										num62 = num61 * 16 + 8 - this.width / 2 + -6;
									}
								}
								if (i == Main.myPlayer)
								{
									Main.cameraX = Main.cameraX + this.position.X - (float)num62;
								}
								this.position.X = (float)num62;
								this.gfxOffY = this.position.Y - num63;
								this.position.Y = num63;
								flag12 = true;
							}
						}
						if (!flag12 && !flag11 && !this.controlUp && ((this.controlLeft && this.releaseLeft) || (this.controlRight && this.releaseRight)))
						{
							this.pulley = false;
							if (this.controlLeft && this.velocity.X == 0f)
							{
								this.velocity.X = -1f;
							}
							if (this.controlRight && this.velocity.X == 0f)
							{
								this.velocity.X = 1f;
							}
						}
						if (this.velocity.X != 0f)
						{
							this.pulley = false;
						}
						if (Main.tile[num56, num57] == null)
						{
							Main.tile[num56, num57] = new Tile();
						}
						if (!Main.tile[num56, num57].active() || !Main.tileRope[(int)Main.tile[num56, num57].type])
						{
							this.pulley = false;
						}
						if (this.gravDir != 1f)
						{
							this.pulley = false;
						}
						if (this.frozen)
						{
							this.pulley = false;
						}
						if (!this.pulley)
						{
							this.velocity.Y = this.velocity.Y - num2;
						}
						if (this.controlJump)
						{
							this.pulley = false;
							this.jump = Player.jumpHeight;
							this.velocity.Y = -Player.jumpSpeed;
						}
					}
					if (this.pulley)
					{
						this.fallStart = (int)this.position.Y / 16;
						this.wingFrame = 0;
						if (this.wings == 4)
						{
							this.wingFrame = 3;
						}
						int num64 = (int)(this.position.X + (float)(this.width / 2)) / 16;
						int num65 = (int)(this.position.Y - 16f) / 16;
						int num66 = (int)(this.position.Y - 8f) / 16;
						bool flag13 = true;
						bool flag14 = false;
						if ((Main.tile[num64, num66 - 1].active() && Main.tileRope[(int)Main.tile[num64, num66 - 1].type]) || (Main.tile[num64, num66 + 1].active() && Main.tileRope[(int)Main.tile[num64, num66 + 1].type]))
						{
							flag14 = true;
						}
						if (Main.tile[num64, num65] == null)
						{
							Main.tile[num64, num65] = new Tile();
						}
						if (!Main.tile[num64, num65].active() || !Main.tileRope[(int)Main.tile[num64, num65].type])
						{
							flag13 = false;
							if (this.velocity.Y < 0f)
							{
								this.velocity.Y = 0f;
							}
						}
						if (flag14)
						{
							if (this.controlUp && flag13)
							{
								float num67 = this.position.X;
								float y = this.position.Y - Math.Abs(this.velocity.Y) - 2f;
								if (Collision.SolidCollision(new Vector2(num67, y), this.width, this.height))
								{
									num67 = (float)(num64 * 16 + 8 - this.width / 2 + 6);
									if (!Collision.SolidCollision(new Vector2(num67, y), this.width, (int)((float)this.height + Math.Abs(this.velocity.Y) + 2f)))
									{
										if (i == Main.myPlayer)
										{
											Main.cameraX = Main.cameraX + this.position.X - num67;
										}
										this.pulleyDir = 2;
										this.direction = 1;
										this.position.X = num67;
										this.velocity.X = 0f;
									}
									else
									{
										num67 = (float)(num64 * 16 + 8 - this.width / 2 + -6);
										if (!Collision.SolidCollision(new Vector2(num67, y), this.width, (int)((float)this.height + Math.Abs(this.velocity.Y) + 2f)))
										{
											if (i == Main.myPlayer)
											{
												Main.cameraX = Main.cameraX + this.position.X - num67;
											}
											this.pulleyDir = 2;
											this.direction = -1;
											this.position.X = num67;
											this.velocity.X = 0f;
										}
									}
								}
								if (this.velocity.Y > 0f)
								{
									this.velocity.Y = this.velocity.Y * 0.7f;
								}
								if (this.velocity.Y > -3f)
								{
									this.velocity.Y = this.velocity.Y - 0.2f;
								}
								else
								{
									this.velocity.Y = this.velocity.Y - 0.02f;
								}
								if (this.velocity.Y < -8f)
								{
									this.velocity.Y = -8f;
								}
							}
							else
							{
								if (this.controlDown)
								{
									float num68 = this.position.X;
									float y2 = this.position.Y;
									if (Collision.SolidCollision(new Vector2(num68, y2), this.width, (int)((float)this.height + Math.Abs(this.velocity.Y) + 2f)))
									{
										num68 = (float)(num64 * 16 + 8 - this.width / 2 + 6);
										if (!Collision.SolidCollision(new Vector2(num68, y2), this.width, (int)((float)this.height + Math.Abs(this.velocity.Y) + 2f)))
										{
											if (i == Main.myPlayer)
											{
												Main.cameraX = Main.cameraX + this.position.X - num68;
											}
											this.pulleyDir = 2;
											this.direction = 1;
											this.position.X = num68;
											this.velocity.X = 0f;
										}
										else
										{
											num68 = (float)(num64 * 16 + 8 - this.width / 2 + -6);
											if (!Collision.SolidCollision(new Vector2(num68, y2), this.width, (int)((float)this.height + Math.Abs(this.velocity.Y) + 2f)))
											{
												if (i == Main.myPlayer)
												{
													Main.cameraX = Main.cameraX + this.position.X - num68;
												}
												this.pulleyDir = 2;
												this.direction = -1;
												this.position.X = num68;
												this.velocity.X = 0f;
											}
										}
									}
									if (this.velocity.Y < 0f)
									{
										this.velocity.Y = this.velocity.Y * 0.7f;
									}
									if (this.velocity.Y < 3f)
									{
										this.velocity.Y = this.velocity.Y + 0.2f;
									}
									else
									{
										this.velocity.Y = this.velocity.Y + 0.1f;
									}
									if (this.velocity.Y > num)
									{
										this.velocity.Y = num;
									}
								}
								else
								{
									this.velocity.Y = this.velocity.Y * 0.7f;
									if ((double)this.velocity.Y > -0.1 && (double)this.velocity.Y < 0.1)
									{
										this.velocity.Y = 0f;
									}
								}
							}
						}
						else
						{
							if (this.controlDown)
							{
								this.ropeCount = 10;
								this.pulley = false;
								this.velocity.Y = 1f;
							}
							else
							{
								this.velocity.Y = 0f;
								this.position.Y = (float)(num65 * 16 + 22);
							}
						}
						float num69 = (float)(num64 * 16 + 8 - this.width / 2);
						if (this.pulleyDir == 1)
						{
							num69 = (float)(num64 * 16 + 8 - this.width / 2);
						}
						if (this.pulleyDir == 2)
						{
							num69 = (float)(num64 * 16 + 8 - this.width / 2 + 6 * this.direction);
						}
						if (i == Main.myPlayer)
						{
							Main.cameraX = Main.cameraX + this.position.X - num69;
						}
						this.position.X = num69;
						this.pulleyFrameCounter += Math.Abs(this.velocity.Y * 0.75f);
						if (this.velocity.Y != 0f)
						{
							this.pulleyFrameCounter += 0.75f;
						}
						if (this.pulleyFrameCounter > 10f)
						{
							this.pulleyFrame++;
							this.pulleyFrameCounter = 0f;
						}
						if (this.pulleyFrame > 1)
						{
							this.pulleyFrame = 0;
						}
						this.canCarpet = true;
						this.carpetFrame = -1;
						this.wingTime = (float)this.wingTimeMax;
						this.rocketTime = this.rocketTimeMax;
						this.rocketDelay = 0;
						this.rocketFrame = false;
						this.canRocket = false;
						this.rocketRelease = false;
					}
					else
					{
						if (this.grappling[0] == -1 && !this.tongued)
						{
							if (this.wingsLogic == 3 && this.velocity.Y == 0f)
							{
								this.accRunSpeed = 8.5f;
							}
							if (this.wingsLogic == 3 && Main.myPlayer == this.whoAmi)
							{
								this.accRunSpeed = 0f;
							}
							if (this.wingsLogic > 0 && this.velocity.Y != 0f)
							{
								if (this.wingsLogic == 1 || this.wingsLogic == 2)
								{
									this.accRunSpeed = 6.25f;
								}
								if (this.wingsLogic == 4)
								{
									this.accRunSpeed = 6.5f;
								}
								if (this.wingsLogic == 5 || this.wingsLogic == 6 || this.wingsLogic == 13 || this.wingsLogic == 15)
								{
									this.accRunSpeed = 6.75f;
								}
								if (this.wingsLogic == 7 || this.wingsLogic == 8)
								{
									this.accRunSpeed = 7f;
								}
								if (this.wingsLogic == 9 || this.wingsLogic == 10 || this.wingsLogic == 11 || this.wingsLogic == 20 || this.wingsLogic == 21 || this.wingsLogic == 23 || this.wingsLogic == 24)
								{
									this.accRunSpeed = 7.5f;
								}
								if (this.wingsLogic == 22)
								{
									if (this.controlDown && this.controlJump && this.wingTime > 0f)
									{
										this.accRunSpeed = 10f;
										num4 *= 10f;
									}
									else
									{
										this.accRunSpeed = 6.25f;
									}
								}
								if (this.wingsLogic == 12)
								{
									this.accRunSpeed = 7.75f;
								}
								if (this.wingsLogic == 16 || this.wingsLogic == 17 || this.wingsLogic == 18 || this.wingsLogic == 19)
								{
									this.accRunSpeed = 7.9f;
								}
								if (this.wingsLogic == 3)
								{
									this.accRunSpeed = 11f;
									num4 *= 3f;
								}
							}
							if (Main.myPlayer == this.whoAmi && (this.wings == 3 || this.wings == 16 || this.wings == 17 || this.wings == 18 || this.wings == 19))
							{
								this.accRunSpeed = 0f;
								num3 *= 0.2f;
								num4 *= 0.2f;
							}
							if (this.sticky)
							{
								num3 *= 0.25f;
								num4 *= 0.25f;
								num5 *= 2f;
								if (this.velocity.X > num3)
								{
									this.velocity.X = num3;
								}
								if (this.velocity.X < -num3)
								{
									this.velocity.X = -num3;
								}
							}
							else
							{
								if (this.powerrun)
								{
									num3 *= 3.5f;
									num4 *= 1f;
									num5 *= 2f;
								}
								else
								{
									if (this.slippy2)
									{
										num4 *= 0.6f;
										num5 = 0f;
										if (this.iceSkate)
										{
											num4 *= 3.5f;
											num3 *= 1.25f;
										}
									}
									else
									{
										if (this.slippy)
										{
											num4 *= 0.7f;
											if (this.iceSkate)
											{
												num4 *= 3.5f;
												num3 *= 1.25f;
											}
											else
											{
												num5 *= 0.1f;
											}
										}
									}
								}
							}
							if (this.sandStorm)
							{
								num4 *= 1.5f;
								num3 *= 2f;
							}
							if (this.dJumpEffect3 && this.doubleJump3)
							{
								num4 *= 3f;
								num3 *= 1.5f;
							}
							if (this.dJumpEffect4 && this.doubleJump4)
							{
								num4 *= 3f;
								num3 *= 1.75f;
							}
							if (this.carpetFrame != -1)
							{
								num4 *= 1.25f;
								num3 *= 1.5f;
							}
							if (this.mount > 0)
							{
								this.rocketBoots = 0;
								this.wings = 0;
								this.wingsLogic = 0;
								this.accRunSpeed = num3;
								if (this.mount == 1)
								{
									num3 = 5.5f;
									this.accRunSpeed = 12f;
									num4 = 0.09f;
								}
							}
							if (this.controlLeft && this.velocity.X > -num3)
							{
								if (this.velocity.X > num5)
								{
									this.velocity.X = this.velocity.X - num5;
								}
								this.velocity.X = this.velocity.X - num4;
								if (!this.sandStorm && (this.itemAnimation == 0 || this.inventory[this.selectedItem].useTurn))
								{
									this.direction = -1;
								}
							}
							else
							{
								if (this.controlRight && this.velocity.X < num3)
								{
									if (this.velocity.X < -num5)
									{
										this.velocity.X = this.velocity.X + num5;
									}
									this.velocity.X = this.velocity.X + num4;
									if (!this.sandStorm && (this.itemAnimation == 0 || this.inventory[this.selectedItem].useTurn))
									{
										this.direction = 1;
									}
								}
								else
								{
									if (this.controlLeft && this.velocity.X > -this.accRunSpeed && this.dashDelay >= 0)
									{
										if (this.itemAnimation == 0 || this.inventory[this.selectedItem].useTurn)
										{
											this.direction = -1;
										}
										if (this.velocity.Y == 0f || this.wingsLogic > 0 || this.mount == 1)
										{
											if (this.velocity.X > num5)
											{
												this.velocity.X = this.velocity.X - num5;
											}
											this.velocity.X = this.velocity.X - num4 * 0.2f;
											if (this.wingsLogic > 0)
											{
												this.velocity.X = this.velocity.X - num4 * 0.2f;
											}
										}
										if (this.velocity.X < -(this.accRunSpeed + num3) / 2f && this.velocity.Y == 0f && this.mount == 0)
										{
											int num70 = 0;
											if (this.gravDir == -1f)
											{
												num70 -= this.height;
											}
											if (this.runSoundDelay == 0 && this.velocity.Y == 0f)
											{
												Main.PlaySound(17, (int)this.position.X, (int)this.position.Y, 1);
												this.runSoundDelay = 9;
											}
											if (this.wings == 3)
											{
												int num71 = Dust.NewDust(new Vector2(this.position.X - 4f, this.position.Y + (float)this.height + (float)num70), this.width + 8, 4, 186, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 50, default(Color), 1.5f);
												Main.dust[num71].velocity *= 0.025f;
												num71 = Dust.NewDust(new Vector2(this.position.X - 4f, this.position.Y + (float)this.height + (float)num70), this.width + 8, 4, 186, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 50, default(Color), 1.5f);
												Main.dust[num71].velocity *= 0.2f;
											}
											else
											{
												if (this.coldDash)
												{
													for (int num72 = 0; num72 < 2; num72++)
													{
														int num73;
														if (num72 == 0)
														{
															num73 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)this.height + this.gfxOffY), this.width / 2, 6, 76, 0f, 0f, 0, default(Color), 1.35f);
														}
														else
														{
															num73 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2), this.position.Y + (float)this.height + this.gfxOffY), this.width / 2, 6, 76, 0f, 0f, 0, default(Color), 1.35f);
														}
														Main.dust[num73].scale *= 1f + (float)Main.rand.Next(20, 40) * 0.01f;
														Main.dust[num73].noGravity = true;
														Main.dust[num73].noLight = true;
														Main.dust[num73].velocity *= 0.001f;
														Dust expr_55D4_cp_0 = Main.dust[num73];
														expr_55D4_cp_0.velocity.Y = expr_55D4_cp_0.velocity.Y - 0.003f;
													}
												}
												else
												{
													int num74 = Dust.NewDust(new Vector2(this.position.X - 4f, this.position.Y + (float)this.height + (float)num70), this.width + 8, 4, 16, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 50, default(Color), 1.5f);
													Main.dust[num74].velocity.X = Main.dust[num74].velocity.X * 0.2f;
													Main.dust[num74].velocity.Y = Main.dust[num74].velocity.Y * 0.2f;
												}
											}
										}
									}
									else
									{
										if (this.controlRight && this.velocity.X < this.accRunSpeed)
										{
											if (this.itemAnimation == 0 || this.inventory[this.selectedItem].useTurn)
											{
												this.direction = 1;
											}
											if (this.velocity.Y == 0f || this.wingsLogic > 0 || this.mount == 1)
											{
												if (this.velocity.X < -num5)
												{
													this.velocity.X = this.velocity.X + num5;
												}
												this.velocity.X = this.velocity.X + num4 * 0.2f;
												if (this.wingsLogic > 0)
												{
													this.velocity.X = this.velocity.X + num4 * 0.2f;
												}
											}
											if (this.velocity.X > (this.accRunSpeed + num3) / 2f && this.velocity.Y == 0f && this.mount == 0)
											{
												int num75 = 0;
												if (this.gravDir == -1f)
												{
													num75 -= this.height;
												}
												if (this.runSoundDelay == 0 && this.velocity.Y == 0f)
												{
													Main.PlaySound(17, (int)this.position.X, (int)this.position.Y, 1);
													this.runSoundDelay = 9;
												}
												if (this.wings == 3)
												{
													int num76 = Dust.NewDust(new Vector2(this.position.X - 4f, this.position.Y + (float)this.height + (float)num75), this.width + 8, 4, 186, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 50, default(Color), 1.5f);
													Main.dust[num76].velocity *= 0.025f;
													num76 = Dust.NewDust(new Vector2(this.position.X - 4f, this.position.Y + (float)this.height + (float)num75), this.width + 8, 4, 186, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 50, default(Color), 1.5f);
													Main.dust[num76].velocity *= 0.2f;
												}
												else
												{
													if (this.coldDash)
													{
														for (int num77 = 0; num77 < 2; num77++)
														{
															int num78;
															if (num77 == 0)
															{
																num78 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)this.height + this.gfxOffY), this.width / 2, 6, 76, 0f, 0f, 0, default(Color), 1.35f);
															}
															else
															{
																num78 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2), this.position.Y + (float)this.height + this.gfxOffY), this.width / 2, 6, 76, 0f, 0f, 0, default(Color), 1.35f);
															}
															Main.dust[num78].scale *= 1f + (float)Main.rand.Next(20, 40) * 0.01f;
															Main.dust[num78].noGravity = true;
															Main.dust[num78].noLight = true;
															Main.dust[num78].velocity *= 0.001f;
															Dust expr_5AB5_cp_0 = Main.dust[num78];
															expr_5AB5_cp_0.velocity.Y = expr_5AB5_cp_0.velocity.Y - 0.003f;
														}
													}
													else
													{
														int num79 = Dust.NewDust(new Vector2(this.position.X - 4f, this.position.Y + (float)this.height + (float)num75), this.width + 8, 4, 16, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 50, default(Color), 1.5f);
														Main.dust[num79].velocity.X = Main.dust[num79].velocity.X * 0.2f;
														Main.dust[num79].velocity.Y = Main.dust[num79].velocity.Y * 0.2f;
													}
												}
											}
										}
										else
										{
											if (this.velocity.Y == 0f)
											{
												if (this.velocity.X > num5)
												{
													this.velocity.X = this.velocity.X - num5;
												}
												else
												{
													if (this.velocity.X < -num5)
													{
														this.velocity.X = this.velocity.X + num5;
													}
													else
													{
														this.velocity.X = 0f;
													}
												}
											}
											else
											{
												if ((double)this.velocity.X > (double)num5 * 0.5)
												{
													this.velocity.X = this.velocity.X - num5 * 0.5f;
												}
												else
												{
													if ((double)this.velocity.X < (double)(-(double)num5) * 0.5)
													{
														this.velocity.X = this.velocity.X + num5 * 0.5f;
													}
													else
													{
														this.velocity.X = 0f;
													}
												}
											}
										}
									}
								}
							}
							if (this.gravControl)
							{
								if (this.controlUp && this.releaseUp)
								{
									if (this.gravDir == 1f)
									{
										this.gravDir = -1f;
										this.fallStart = (int)(this.position.Y / 16f);
										this.jump = 0;
										Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 8);
									}
									else
									{
										this.gravDir = 1f;
										this.fallStart = (int)(this.position.Y / 16f);
										this.jump = 0;
										Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 8);
									}
								}
							}
							else
							{
								if (this.gravControl2)
								{
									if (this.controlUp && this.releaseUp && this.velocity.Y == 0f)
									{
										if (this.gravDir == 1f)
										{
											this.gravDir = -1f;
											this.fallStart = (int)(this.position.Y / 16f);
											this.jump = 0;
											Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 8);
										}
										else
										{
											this.gravDir = 1f;
											this.fallStart = (int)(this.position.Y / 16f);
											this.jump = 0;
											Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 8);
										}
									}
								}
								else
								{
									this.gravDir = 1f;
								}
							}
							if (this.controlUp)
							{
								this.releaseUp = false;
							}
							else
							{
								this.releaseUp = true;
							}
							this.sandStorm = false;
							if (this.controlJump)
							{
								if (this.jump > 0)
								{
									if (this.velocity.Y == 0f)
									{
										if (this.merman)
										{
											this.jump = 10;
										}
										this.jump = 0;
									}
									else
									{
										this.velocity.Y = -Player.jumpSpeed * this.gravDir;
										if (this.merman)
										{
											if (this.swimTime <= 10)
											{
												this.swimTime = 30;
											}
										}
										else
										{
											this.jump--;
										}
									}
								}
								else
								{
									if ((this.sliding || this.velocity.Y == 0f || this.jumpAgain || this.jumpAgain2 || this.jumpAgain3 || this.jumpAgain4 || (this.wet && this.accFlipper)) && this.releaseJump)
									{
										bool flag15 = false;
										if (this.wet && this.accFlipper)
										{
											if (this.swimTime == 0)
											{
												this.swimTime = 30;
											}
											flag15 = true;
										}
										bool flag16 = false;
										bool flag17 = false;
										bool flag18 = false;
										if (this.jumpAgain2)
										{
											flag16 = true;
											this.jumpAgain2 = false;
										}
										else
										{
											if (this.jumpAgain3)
											{
												flag17 = true;
												this.jumpAgain3 = false;
											}
											else
											{
												if (this.jumpAgain4)
												{
													this.jumpAgain4 = false;
													flag18 = true;
												}
												else
												{
													this.jumpAgain = false;
												}
											}
										}
										this.canRocket = false;
										this.rocketRelease = false;
										if ((this.velocity.Y == 0f || this.sliding) && this.doubleJump)
										{
											this.jumpAgain = true;
										}
										if ((this.velocity.Y == 0f || this.sliding) && this.doubleJump2)
										{
											this.jumpAgain2 = true;
										}
										if ((this.velocity.Y == 0f || this.sliding) && this.doubleJump3)
										{
											this.jumpAgain3 = true;
										}
										if ((this.velocity.Y == 0f || this.sliding) && this.doubleJump4)
										{
											this.jumpAgain4 = true;
										}
										if (this.velocity.Y == 0f || flag15 || this.sliding)
										{
											this.velocity.Y = -Player.jumpSpeed * this.gravDir;
											this.jump = Player.jumpHeight;
											if (this.sliding)
											{
												this.velocity.X = (float)(3 * -(float)this.slideDir);
											}
										}
										else
										{
											if (flag16)
											{
												this.dJumpEffect2 = true;
												float arg_60F5_0 = this.gravDir;
												Main.PlaySound(16, (int)this.position.X, (int)this.position.Y, 1);
												this.velocity.Y = -Player.jumpSpeed * this.gravDir;
												this.jump = Player.jumpHeight * 3;
											}
											else
											{
												if (flag17)
												{
													this.dJumpEffect3 = true;
													float arg_6157_0 = this.gravDir;
													Main.PlaySound(16, (int)this.position.X, (int)this.position.Y, 1);
													this.velocity.Y = -Player.jumpSpeed * this.gravDir;
													this.jump = (int)((double)Player.jumpHeight * 1.5);
												}
												else
												{
													if (flag18)
													{
														this.dJumpEffect4 = true;
														int num80 = this.height;
														if (this.gravDir == -1f)
														{
															num80 = 0;
														}
														Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 16);
														this.velocity.Y = -Player.jumpSpeed * this.gravDir;
														this.jump = Player.jumpHeight * 2;
														for (int num81 = 0; num81 < 10; num81++)
														{
															int num82 = Dust.NewDust(new Vector2(this.position.X - 34f, this.position.Y + (float)num80 - 16f), 102, 32, 188, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 100, default(Color), 1.5f);
															Main.dust[num82].velocity.X = Main.dust[num82].velocity.X * 0.5f - this.velocity.X * 0.1f;
															Main.dust[num82].velocity.Y = Main.dust[num82].velocity.Y * 0.5f - this.velocity.Y * 0.3f;
														}
														int num83 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 16f, this.position.Y + (float)num80 - 16f), new Vector2(-this.velocity.X, -this.velocity.Y), Main.rand.Next(435, 438), 1f);
														Main.gore[num83].velocity.X = Main.gore[num83].velocity.X * 0.1f - this.velocity.X * 0.1f;
														Main.gore[num83].velocity.Y = Main.gore[num83].velocity.Y * 0.1f - this.velocity.Y * 0.05f;
														num83 = Gore.NewGore(new Vector2(this.position.X - 36f, this.position.Y + (float)num80 - 16f), new Vector2(-this.velocity.X, -this.velocity.Y), Main.rand.Next(435, 438), 1f);
														Main.gore[num83].velocity.X = Main.gore[num83].velocity.X * 0.1f - this.velocity.X * 0.1f;
														Main.gore[num83].velocity.Y = Main.gore[num83].velocity.Y * 0.1f - this.velocity.Y * 0.05f;
														num83 = Gore.NewGore(new Vector2(this.position.X + (float)this.width + 4f, this.position.Y + (float)num80 - 16f), new Vector2(-this.velocity.X, -this.velocity.Y), Main.rand.Next(435, 438), 1f);
														Main.gore[num83].velocity.X = Main.gore[num83].velocity.X * 0.1f - this.velocity.X * 0.1f;
														Main.gore[num83].velocity.Y = Main.gore[num83].velocity.Y * 0.1f - this.velocity.Y * 0.05f;
													}
													else
													{
														this.dJumpEffect = true;
														int num84 = this.height;
														if (this.gravDir == -1f)
														{
															num84 = 0;
														}
														Main.PlaySound(16, (int)this.position.X, (int)this.position.Y, 1);
														this.velocity.Y = -Player.jumpSpeed * this.gravDir;
														this.jump = (int)((double)Player.jumpHeight * 0.75);
														for (int num85 = 0; num85 < 10; num85++)
														{
															int num86 = Dust.NewDust(new Vector2(this.position.X - 34f, this.position.Y + (float)num84 - 16f), 102, 32, 16, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 100, default(Color), 1.5f);
															Main.dust[num86].velocity.X = Main.dust[num86].velocity.X * 0.5f - this.velocity.X * 0.1f;
															Main.dust[num86].velocity.Y = Main.dust[num86].velocity.Y * 0.5f - this.velocity.Y * 0.3f;
														}
														int num87 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 16f, this.position.Y + (float)num84 - 16f), new Vector2(-this.velocity.X, -this.velocity.Y), Main.rand.Next(11, 14), 1f);
														Main.gore[num87].velocity.X = Main.gore[num87].velocity.X * 0.1f - this.velocity.X * 0.1f;
														Main.gore[num87].velocity.Y = Main.gore[num87].velocity.Y * 0.1f - this.velocity.Y * 0.05f;
														num87 = Gore.NewGore(new Vector2(this.position.X - 36f, this.position.Y + (float)num84 - 16f), new Vector2(-this.velocity.X, -this.velocity.Y), Main.rand.Next(11, 14), 1f);
														Main.gore[num87].velocity.X = Main.gore[num87].velocity.X * 0.1f - this.velocity.X * 0.1f;
														Main.gore[num87].velocity.Y = Main.gore[num87].velocity.Y * 0.1f - this.velocity.Y * 0.05f;
														num87 = Gore.NewGore(new Vector2(this.position.X + (float)this.width + 4f, this.position.Y + (float)num84 - 16f), new Vector2(-this.velocity.X, -this.velocity.Y), Main.rand.Next(11, 14), 1f);
														Main.gore[num87].velocity.X = Main.gore[num87].velocity.X * 0.1f - this.velocity.X * 0.1f;
														Main.gore[num87].velocity.Y = Main.gore[num87].velocity.Y * 0.1f - this.velocity.Y * 0.05f;
													}
												}
											}
										}
									}
								}
								this.releaseJump = false;
							}
							else
							{
								this.jump = 0;
								this.releaseJump = true;
								this.rocketRelease = true;
							}
							if (this.wingsLogic == 0)
							{
								this.wingTime = 0f;
							}
							if (this.wingsLogic == 3)
							{
								this.wingTime = 1000f;
							}
							if (Main.myPlayer == this.whoAmi && (this.wings == 3 || this.wings == 16 || this.wings == 17 || this.wings == 18 || this.wings == 19))
							{
								this.wingTime = 0f;
								this.jump = 0;
							}
							if (this.rocketBoots == 0)
							{
								this.rocketTime = 0;
							}
							if (this.jump == 0)
							{
								this.dJumpEffect = false;
								this.dJumpEffect2 = false;
								this.dJumpEffect3 = false;
								this.dJumpEffect4 = false;
							}
							if (this.dashDelay > 0)
							{
								this.dashDelay--;
							}
							else
							{
								if (this.dashDelay < 0)
								{
									for (int num88 = 0; num88 < 2; num88++)
									{
										int num89;
										if (this.velocity.Y == 0f)
										{
											num89 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)this.height - 4f), this.width, 8, 31, 0f, 0f, 100, default(Color), 1.4f);
										}
										else
										{
											num89 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)(this.height / 2) - 8f), this.width, 16, 31, 0f, 0f, 100, default(Color), 1.4f);
										}
										Main.dust[num89].velocity *= 0.1f;
										Main.dust[num89].scale *= 1f + (float)Main.rand.Next(20) * 0.01f;
									}
									if (this.velocity.X > 13f || this.velocity.X < -13f)
									{
										this.velocity.X = this.velocity.X * 0.99f;
									}
									else
									{
										if (this.velocity.X > this.accRunSpeed || this.velocity.X < -this.accRunSpeed)
										{
											this.velocity.X = this.velocity.X * 0.9f;
										}
										else
										{
											this.dashDelay = 20;
											if (this.velocity.X < 0f)
											{
												this.velocity.X = -this.accRunSpeed;
											}
											else
											{
												if (this.velocity.X > 0f)
												{
													this.velocity.X = this.accRunSpeed;
												}
											}
										}
									}
								}
								else
								{
									if (this.dash > 0 && this.mount == 0)
									{
										int num90 = 0;
										bool flag19 = false;
										if (this.dashTime > 0)
										{
											this.dashTime--;
										}
										if (this.dashTime < 0)
										{
											this.dashTime++;
										}
										if (this.controlRight && this.releaseRight)
										{
											if (this.dashTime > 0)
											{
												num90 = 1;
												flag19 = true;
												this.dashTime = 0;
											}
											else
											{
												this.dashTime = 15;
											}
										}
										else
										{
											if (this.controlLeft && this.releaseLeft)
											{
												if (this.dashTime < 0)
												{
													num90 = -1;
													flag19 = true;
													this.dashTime = 0;
												}
												else
												{
													this.dashTime = -15;
												}
											}
										}
										if (flag19)
										{
											this.velocity.X = 15.9f * (float)num90;
											this.dashDelay = -1;
											for (int num91 = 0; num91 < 20; num91++)
											{
												int num92 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 2f);
												Dust expr_6E06_cp_0 = Main.dust[num92];
												expr_6E06_cp_0.position.X = expr_6E06_cp_0.position.X + (float)Main.rand.Next(-5, 6);
												Dust expr_6E2D_cp_0 = Main.dust[num92];
												expr_6E2D_cp_0.position.Y = expr_6E2D_cp_0.position.Y + (float)Main.rand.Next(-5, 6);
												Main.dust[num92].velocity *= 0.2f;
												Main.dust[num92].scale *= 1f + (float)Main.rand.Next(20) * 0.01f;
											}
											int num93 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 34f), default(Vector2), Main.rand.Next(61, 64), 1f);
											Main.gore[num93].velocity.X = (float)Main.rand.Next(-50, 51) * 0.01f;
											Main.gore[num93].velocity.Y = (float)Main.rand.Next(-50, 51) * 0.01f;
											Main.gore[num93].velocity *= 0.4f;
											num93 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 14f), default(Vector2), Main.rand.Next(61, 64), 1f);
											Main.gore[num93].velocity.X = (float)Main.rand.Next(-50, 51) * 0.01f;
											Main.gore[num93].velocity.Y = (float)Main.rand.Next(-50, 51) * 0.01f;
											Main.gore[num93].velocity *= 0.4f;
										}
									}
								}
							}
							this.sliding = false;
							if (this.slideDir != 0 && this.spikedBoots > 0 && this.mount == 0 && ((this.controlLeft && this.slideDir == -1) || (this.controlRight && this.slideDir == 1)))
							{
								bool flag20 = false;
								float num94 = this.position.X;
								if (this.slideDir == 1)
								{
									num94 += (float)this.width;
								}
								num94 += (float)this.slideDir;
								float num95 = this.position.Y + (float)this.height + 1f;
								if (this.gravDir < 0f)
								{
									num95 = this.position.Y - 1f;
								}
								num94 /= 16f;
								num95 /= 16f;
								if (WorldGen.SolidTile((int)num94, (int)num95) && WorldGen.SolidTile((int)num94, (int)num95 - 1))
								{
									flag20 = true;
								}
								if (this.spikedBoots >= 2)
								{
									if (flag20 && ((this.velocity.Y > 0f && this.gravDir == 1f) || (this.velocity.Y < num2 && this.gravDir == -1f)))
									{
										float num96 = num2;
										if (this.slowFall)
										{
											if (this.controlUp)
											{
												num96 = num2 / 10f * this.gravDir;
											}
											else
											{
												num96 = num2 / 3f * this.gravDir;
											}
										}
										this.fallStart = (int)(this.position.Y / 16f);
										if ((this.controlDown && this.gravDir == 1f) || (this.controlUp && this.gravDir == -1f))
										{
											this.velocity.Y = 4f * this.gravDir;
											int num97 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) + (float)((this.width / 2 - 4) * this.slideDir), this.position.Y + (float)(this.height / 2) + (float)(this.height / 2 - 4) * this.gravDir), 8, 8, 31, 0f, 0f, 0, default(Color), 1f);
											if (this.slideDir < 0)
											{
												Dust expr_72A7_cp_0 = Main.dust[num97];
												expr_72A7_cp_0.position.X = expr_72A7_cp_0.position.X - 10f;
											}
											if (this.gravDir < 0f)
											{
												Dust expr_72D2_cp_0 = Main.dust[num97];
												expr_72D2_cp_0.position.Y = expr_72D2_cp_0.position.Y - 12f;
											}
											Main.dust[num97].velocity *= 0.1f;
											Main.dust[num97].scale *= 1.2f;
											Main.dust[num97].noGravity = true;
										}
										else
										{
											if (this.gravDir == -1f)
											{
												this.velocity.Y = (-num96 + 1E-05f) * this.gravDir;
											}
											else
											{
												this.velocity.Y = (-num96 + 1E-05f) * this.gravDir;
											}
										}
										this.sliding = true;
									}
								}
								else
								{
									if ((flag20 && (double)this.velocity.Y > 0.5 && this.gravDir == 1f) || ((double)this.velocity.Y < -0.5 && this.gravDir == -1f))
									{
										this.fallStart = (int)(this.position.Y / 16f);
										if (this.controlDown)
										{
											this.velocity.Y = 4f * this.gravDir;
										}
										else
										{
											this.velocity.Y = 0.5f * this.gravDir;
										}
										this.sliding = true;
										int num98 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) + (float)((this.width / 2 - 4) * this.slideDir), this.position.Y + (float)(this.height / 2) + (float)(this.height / 2 - 4) * this.gravDir), 8, 8, 31, 0f, 0f, 0, default(Color), 1f);
										if (this.slideDir < 0)
										{
											Dust expr_74B7_cp_0 = Main.dust[num98];
											expr_74B7_cp_0.position.X = expr_74B7_cp_0.position.X - 10f;
										}
										if (this.gravDir < 0f)
										{
											Dust expr_74E2_cp_0 = Main.dust[num98];
											expr_74E2_cp_0.position.Y = expr_74E2_cp_0.position.Y - 12f;
										}
										Main.dust[num98].velocity *= 0.1f;
										Main.dust[num98].scale *= 1.2f;
										Main.dust[num98].noGravity = true;
									}
								}
							}
							bool flag21 = false;
							if (this.grappling[0] == -1 && this.carpet && !this.jumpAgain && !this.jumpAgain2 && !this.jumpAgain3 && !this.jumpAgain4 && this.jump == 0 && this.velocity.Y != 0f && this.rocketTime == 0 && this.wingTime == 0f && this.mount == 0)
							{
								if (this.controlJump && this.canCarpet)
								{
									this.canCarpet = false;
									this.carpetTime = 300;
								}
								if (this.carpetTime > 0 && this.controlJump)
								{
									this.fallStart = (int)(this.position.Y / 16f);
									flag21 = true;
									this.carpetTime--;
									if (this.gravDir == 1f && this.velocity.Y > -num2)
									{
										this.velocity.Y = -(num2 + 1E-06f);
									}
									else
									{
										if (this.gravDir == -1f && this.velocity.Y < num2)
										{
											this.velocity.Y = num2 + 1E-06f;
										}
									}
									this.carpetFrameCounter += 1f + Math.Abs(this.velocity.X * 0.5f);
									if (this.carpetFrameCounter > 8f)
									{
										this.carpetFrameCounter = 0f;
										this.carpetFrame++;
									}
									if (this.carpetFrame < 0)
									{
										this.carpetFrame = 0;
									}
									if (this.carpetFrame > 5)
									{
										this.carpetFrame = 0;
									}
								}
							}
							if (!flag21)
							{
								this.carpetFrame = -1;
							}
							if (this.dJumpEffect && this.doubleJump && !this.jumpAgain && (this.jumpAgain2 || !this.doubleJump2) && ((this.gravDir == 1f && this.velocity.Y < 0f) || (this.gravDir == -1f && this.velocity.Y > 0f)))
							{
								int num99 = this.height;
								if (this.gravDir == -1f)
								{
									num99 = -6;
								}
								int num100 = Dust.NewDust(new Vector2(this.position.X - 4f, this.position.Y + (float)num99), this.width + 8, 4, 16, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 100, default(Color), 1.5f);
								Main.dust[num100].velocity.X = Main.dust[num100].velocity.X * 0.5f - this.velocity.X * 0.1f;
								Main.dust[num100].velocity.Y = Main.dust[num100].velocity.Y * 0.5f - this.velocity.Y * 0.3f;
							}
							if (this.dJumpEffect2 && this.doubleJump2 && !this.jumpAgain2 && ((this.gravDir == 1f && this.velocity.Y < 0f) || (this.gravDir == -1f && this.velocity.Y > 0f)))
							{
								int num101 = this.height;
								if (this.gravDir == -1f)
								{
									num101 = -6;
								}
								float num102 = ((float)this.jump / 75f + 1f) / 2f;
								for (int num103 = 0; num103 < 3; num103++)
								{
									int num104 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)(num101 / 2)), this.width, 32, 124, this.velocity.X * 0.3f, this.velocity.Y * 0.3f, 150, default(Color), 1f * num102);
									Main.dust[num104].velocity *= 0.5f * num102;
									Main.dust[num104].fadeIn = 1.5f * num102;
								}
								this.sandStorm = true;
								if (this.miscCounter % 3 == 0)
								{
									int num105 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 18f, this.position.Y + (float)(num101 / 2)), new Vector2(-this.velocity.X, -this.velocity.Y), Main.rand.Next(220, 223), num102);
									Main.gore[num105].velocity = this.velocity * 0.3f * num102;
									Main.gore[num105].alpha = 100;
								}
							}
							if (this.dJumpEffect4 && this.doubleJump4 && !this.jumpAgain4 && ((this.gravDir == 1f && this.velocity.Y < 0f) || (this.gravDir == -1f && this.velocity.Y > 0f)))
							{
								int num106 = this.height;
								if (this.gravDir == -1f)
								{
									num106 = -6;
								}
								int num107 = Dust.NewDust(new Vector2(this.position.X - 4f, this.position.Y + (float)num106), this.width + 8, 4, 188, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 100, default(Color), 1.5f);
								Main.dust[num107].velocity.X = Main.dust[num107].velocity.X * 0.5f - this.velocity.X * 0.1f;
								Main.dust[num107].velocity.Y = Main.dust[num107].velocity.Y * 0.5f - this.velocity.Y * 0.3f;
								Main.dust[num107].velocity *= 0.5f;
							}
							if (this.dJumpEffect3 && this.doubleJump3 && !this.jumpAgain3 && ((this.gravDir == 1f && this.velocity.Y < 0f) || (this.gravDir == -1f && this.velocity.Y > 0f)))
							{
								int num108 = this.height - 6;
								if (this.gravDir == -1f)
								{
									num108 = 6;
								}
								for (int num109 = 0; num109 < 2; num109++)
								{
									int num110 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)num108), this.width, 12, 76, this.velocity.X * 0.3f, this.velocity.Y * 0.3f, 0, default(Color), 1f);
									Main.dust[num110].velocity *= 0.1f;
									if (num109 == 0)
									{
										Main.dust[num110].velocity += this.velocity * 0.03f;
									}
									else
									{
										Main.dust[num110].velocity -= this.velocity * 0.03f;
									}
									Main.dust[num110].noLight = true;
								}
								for (int num111 = 0; num111 < 3; num111++)
								{
									int num112 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)num108), this.width, 12, 76, this.velocity.X * 0.3f, this.velocity.Y * 0.3f, 0, default(Color), 1f);
									Main.dust[num112].fadeIn = 1.5f;
									Main.dust[num112].velocity *= 0.6f;
									Main.dust[num112].velocity += this.velocity * 0.8f;
									Main.dust[num112].noGravity = true;
									Main.dust[num112].noLight = true;
								}
								for (int num113 = 0; num113 < 3; num113++)
								{
									int num114 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)num108), this.width, 12, 76, this.velocity.X * 0.3f, this.velocity.Y * 0.3f, 0, default(Color), 1f);
									Main.dust[num114].fadeIn = 1.5f;
									Main.dust[num114].velocity *= 0.6f;
									Main.dust[num114].velocity -= this.velocity * 0.8f;
									Main.dust[num114].noGravity = true;
									Main.dust[num114].noLight = true;
								}
							}
							if (this.wings > 0)
							{
								this.sandStorm = false;
							}
							if (((this.gravDir == 1f && this.velocity.Y > -Player.jumpSpeed) || (this.gravDir == -1f && this.velocity.Y < Player.jumpSpeed)) && this.velocity.Y != 0f)
							{
								this.canRocket = true;
							}
							bool flag22 = false;
							if (this.velocity.Y == 0f || this.sliding)
							{
								if (this.mount == 1)
								{
									this.mountFlyTime = 160;
									this.mountFlyTime += (int)(Math.Abs(this.velocity.X) * 20f);
								}
								else
								{
									this.mountFlyTime = 0;
								}
								this.wingTime = (float)this.wingTimeMax;
							}
							if (this.wingsLogic > 0 && this.controlJump && this.wingTime > 0f && !this.jumpAgain && this.jump == 0 && this.velocity.Y != 0f)
							{
								flag22 = true;
							}
							if (this.frozen)
							{
								this.Dismount();
								this.velocity.Y = this.velocity.Y + num2;
								if (this.velocity.Y > num)
								{
									this.velocity.Y = num;
								}
								this.sandStorm = false;
								this.dJumpEffect = false;
								this.dJumpEffect2 = false;
								this.dJumpEffect3 = false;
							}
							else
							{
								if (flag22)
								{
									if (this.wings == 10 && Main.rand.Next(2) == 0)
									{
										int num115 = 4;
										if (this.direction == 1)
										{
											num115 = -40;
										}
										int num116 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) + (float)num115, this.position.Y + (float)(this.height / 2) - 15f), 30, 30, 76, 0f, 0f, 50, default(Color), 0.6f);
										Main.dust[num116].fadeIn = 1.1f;
										Main.dust[num116].noGravity = true;
										Main.dust[num116].noLight = true;
										Main.dust[num116].velocity *= 0.3f;
									}
									if (this.wings == 9 && Main.rand.Next(2) == 0)
									{
										int num117 = 4;
										if (this.direction == 1)
										{
											num117 = -40;
										}
										int num118 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) + (float)num117, this.position.Y + (float)(this.height / 2) - 15f), 30, 30, 6, 0f, 0f, 200, default(Color), 2f);
										Main.dust[num118].noGravity = true;
										Main.dust[num118].velocity *= 0.3f;
									}
									if (this.wings == 6 && Main.rand.Next(4) == 0)
									{
										int num119 = 4;
										if (this.direction == 1)
										{
											num119 = -40;
										}
										int num120 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) + (float)num119, this.position.Y + (float)(this.height / 2) - 15f), 30, 30, 55, 0f, 0f, 200, default(Color), 1f);
										Main.dust[num120].velocity *= 0.3f;
									}
									if (this.wings == 5 && Main.rand.Next(3) == 0)
									{
										int num121 = 6;
										if (this.direction == 1)
										{
											num121 = -30;
										}
										int num122 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) + (float)num121, this.position.Y), 18, this.height, 58, 0f, 0f, 255, default(Color), 1.2f);
										Main.dust[num122].velocity *= 0.3f;
									}
									if (this.wingsLogic == 4 && this.controlUp)
									{
										this.velocity.Y = this.velocity.Y - 0.2f * this.gravDir;
										if (this.gravDir == 1f)
										{
											if (this.velocity.Y > 0f)
											{
												this.velocity.Y = this.velocity.Y - 1f;
											}
											else
											{
												if (this.velocity.Y > -Player.jumpSpeed)
												{
													this.velocity.Y = this.velocity.Y - 0.2f;
												}
											}
											if (this.velocity.Y < -Player.jumpSpeed * 3f)
											{
												this.velocity.Y = -Player.jumpSpeed * 3f;
											}
										}
										else
										{
											if (this.velocity.Y < 0f)
											{
												this.velocity.Y = this.velocity.Y + 1f;
											}
											else
											{
												if (this.velocity.Y < Player.jumpSpeed)
												{
													this.velocity.Y = this.velocity.Y + 0.2f;
												}
											}
											if (this.velocity.Y > Player.jumpSpeed * 3f)
											{
												this.velocity.Y = Player.jumpSpeed * 3f;
											}
										}
										this.wingTime -= 2f;
									}
									else
									{
										if (this.wingsLogic == 3 && this.controlUp)
										{
											this.velocity.Y = this.velocity.Y - 0.3f * this.gravDir;
											if (this.gravDir == 1f)
											{
												if (this.velocity.Y > 0f)
												{
													this.velocity.Y = this.velocity.Y - 1f;
												}
												else
												{
													if (this.velocity.Y > -Player.jumpSpeed)
													{
														this.velocity.Y = this.velocity.Y - 0.2f;
													}
												}
												if (this.velocity.Y < -Player.jumpSpeed * 3f)
												{
													this.velocity.Y = -Player.jumpSpeed * 3f;
												}
											}
											else
											{
												if (this.velocity.Y < 0f)
												{
													this.velocity.Y = this.velocity.Y + 1f;
												}
												else
												{
													if (this.velocity.Y < Player.jumpSpeed)
													{
														this.velocity.Y = this.velocity.Y + 0.2f;
													}
												}
												if (this.velocity.Y > Player.jumpSpeed * 3f)
												{
													this.velocity.Y = Player.jumpSpeed * 3f;
												}
											}
											this.wingTime -= 2f;
										}
										else
										{
											this.velocity.Y = this.velocity.Y - 0.1f * this.gravDir;
											if (this.gravDir == 1f)
											{
												if (this.velocity.Y > 0f)
												{
													this.velocity.Y = this.velocity.Y - 0.5f;
												}
												else
												{
													if ((double)this.velocity.Y > (double)(-(double)Player.jumpSpeed) * 0.5)
													{
														this.velocity.Y = this.velocity.Y - 0.1f;
													}
												}
												if (this.velocity.Y < -Player.jumpSpeed * 1.5f)
												{
													this.velocity.Y = -Player.jumpSpeed * 1.5f;
												}
											}
											else
											{
												if (this.velocity.Y < 0f)
												{
													this.velocity.Y = this.velocity.Y + 0.5f;
												}
												else
												{
													if ((double)this.velocity.Y < (double)Player.jumpSpeed * 0.5)
													{
														this.velocity.Y = this.velocity.Y + 0.1f;
													}
												}
												if (this.velocity.Y > Player.jumpSpeed * 1.5f)
												{
													this.velocity.Y = Player.jumpSpeed * 1.5f;
												}
											}
											if (this.wingsLogic == 22 && this.controlDown && !this.controlLeft && !this.controlRight)
											{
												this.wingTime -= 0.5f;
											}
											else
											{
												this.wingTime -= 1f;
											}
										}
									}
								}
								if (this.wings == 4)
								{
									if (flag22 || this.jump > 0)
									{
										this.rocketDelay2--;
										if (this.rocketDelay2 <= 0)
										{
											Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 13);
											this.rocketDelay2 = 60;
										}
										int num123 = 2;
										if (this.controlUp)
										{
											num123 = 4;
										}
										for (int num124 = 0; num124 < num123; num124++)
										{
											int type3 = 6;
											if (this.head == 41)
											{
												int arg_88C0_0 = this.body;
											}
											float scale = 1.75f;
											int alpha = 100;
											float x = this.position.X + (float)(this.width / 2) + 16f;
											if (this.direction > 0)
											{
												x = this.position.X + (float)(this.width / 2) - 26f;
											}
											float num125 = this.position.Y + (float)this.height - 18f;
											if (num124 == 1 || num124 == 3)
											{
												x = this.position.X + (float)(this.width / 2) + 8f;
												if (this.direction > 0)
												{
													x = this.position.X + (float)(this.width / 2) - 20f;
												}
												num125 += 6f;
											}
											if (num124 > 1)
											{
												num125 += this.velocity.Y;
											}
											int num126 = Dust.NewDust(new Vector2(x, num125), 8, 8, type3, 0f, 0f, alpha, default(Color), scale);
											Dust expr_89D3_cp_0 = Main.dust[num126];
											expr_89D3_cp_0.velocity.X = expr_89D3_cp_0.velocity.X * 0.1f;
											Main.dust[num126].velocity.Y = Main.dust[num126].velocity.Y * 1f + 2f * this.gravDir - this.velocity.Y * 0.3f;
											Main.dust[num126].noGravity = true;
											if (num123 == 4)
											{
												Dust expr_8A4D_cp_0 = Main.dust[num126];
												expr_8A4D_cp_0.velocity.Y = expr_8A4D_cp_0.velocity.Y + 6f;
											}
										}
										this.wingFrameCounter++;
										if (this.wingFrameCounter > 4)
										{
											this.wingFrame++;
											this.wingFrameCounter = 0;
											if (this.wingFrame >= 3)
											{
												this.wingFrame = 0;
											}
										}
									}
									else
									{
										if (!this.controlJump || this.velocity.Y == 0f)
										{
											this.wingFrame = 3;
										}
									}
								}
								else
								{
									if (this.wings == 22)
									{
										if (!this.controlJump)
										{
											this.wingFrame = 0;
											this.wingFrameCounter = 0;
										}
										else
										{
											if (this.wingTime > 0f)
											{
												if (this.controlDown)
												{
													if (this.velocity.X != 0f)
													{
														this.wingFrameCounter++;
														int num127 = 2;
														if (this.wingFrameCounter < num127)
														{
															this.wingFrame = 1;
														}
														else
														{
															if (this.wingFrameCounter < num127 * 2)
															{
																this.wingFrame = 2;
															}
															else
															{
																if (this.wingFrameCounter < num127 * 3)
																{
																	this.wingFrame = 3;
																}
																else
																{
																	if (this.wingFrameCounter < num127 * 4 - 1)
																	{
																		this.wingFrame = 2;
																	}
																	else
																	{
																		this.wingFrame = 2;
																		this.wingFrameCounter = 0;
																	}
																}
															}
														}
													}
													else
													{
														this.wingFrameCounter++;
														int num128 = 6;
														if (this.wingFrameCounter < num128)
														{
															this.wingFrame = 4;
														}
														else
														{
															if (this.wingFrameCounter < num128 * 2)
															{
																this.wingFrame = 5;
															}
															else
															{
																if (this.wingFrameCounter < num128 * 3 - 1)
																{
																	this.wingFrame = 4;
																}
																else
																{
																	this.wingFrame = 4;
																	this.wingFrameCounter = 0;
																}
															}
														}
													}
												}
												else
												{
													this.wingFrameCounter++;
													int num129 = 2;
													if (this.wingFrameCounter < num129)
													{
														this.wingFrame = 4;
													}
													else
													{
														if (this.wingFrameCounter < num129 * 2)
														{
															this.wingFrame = 5;
														}
														else
														{
															if (this.wingFrameCounter < num129 * 3)
															{
																this.wingFrame = 6;
															}
															else
															{
																if (this.wingFrameCounter < num129 * 4 - 1)
																{
																	this.wingFrame = 5;
																}
																else
																{
																	this.wingFrame = 5;
																	this.wingFrameCounter = 0;
																}
															}
														}
													}
												}
											}
											else
											{
												this.wingFrameCounter++;
												int num130 = 6;
												if (this.wingFrameCounter < num130)
												{
													this.wingFrame = 4;
												}
												else
												{
													if (this.wingFrameCounter < num130 * 2)
													{
														this.wingFrame = 5;
													}
													else
													{
														if (this.wingFrameCounter < num130 * 3 - 1)
														{
															this.wingFrame = 4;
														}
														else
														{
															this.wingFrame = 4;
															this.wingFrameCounter = 0;
														}
													}
												}
											}
										}
									}
									else
									{
										if (this.wings == 12)
										{
											if (flag22 || this.jump > 0)
											{
												this.wingFrameCounter++;
												int num131 = 5;
												if (this.wingFrameCounter < num131)
												{
													this.wingFrame = 1;
												}
												else
												{
													if (this.wingFrameCounter < num131 * 2)
													{
														this.wingFrame = 2;
													}
													else
													{
														if (this.wingFrameCounter < num131 * 3)
														{
															this.wingFrame = 3;
														}
														else
														{
															if (this.wingFrameCounter < num131 * 4 - 1)
															{
																this.wingFrame = 2;
															}
															else
															{
																this.wingFrame = 2;
																this.wingFrameCounter = 0;
															}
														}
													}
												}
											}
											else
											{
												if (this.velocity.Y != 0f)
												{
													this.wingFrame = 2;
												}
												else
												{
													this.wingFrame = 0;
												}
											}
										}
										else
										{
											if (this.wings == 24)
											{
												if (flag22 || this.jump > 0)
												{
													this.wingFrameCounter++;
													int num132 = 1;
													if (this.wingFrameCounter < num132)
													{
														this.wingFrame = 1;
													}
													else
													{
														if (this.wingFrameCounter < num132 * 2)
														{
															this.wingFrame = 2;
														}
														else
														{
															if (this.wingFrameCounter < num132 * 3)
															{
																this.wingFrame = 3;
															}
															else
															{
																this.wingFrame = 2;
																if (this.wingFrameCounter >= num132 * 4 - 1)
																{
																	this.wingFrameCounter = 0;
																}
															}
														}
													}
												}
												else
												{
													if (this.velocity.Y != 0f)
													{
														if (this.controlJump)
														{
															this.wingFrameCounter++;
															int num133 = 3;
															if (this.wingFrameCounter < num133)
															{
																this.wingFrame = 1;
															}
															else
															{
																if (this.wingFrameCounter < num133 * 2)
																{
																	this.wingFrame = 2;
																}
																else
																{
																	if (this.wingFrameCounter < num133 * 3)
																	{
																		this.wingFrame = 3;
																	}
																	else
																	{
																		this.wingFrame = 2;
																		if (this.wingFrameCounter >= num133 * 4 - 1)
																		{
																			this.wingFrameCounter = 0;
																		}
																	}
																}
															}
														}
														else
														{
															if (this.wingTime == 0f)
															{
																this.wingFrame = 0;
															}
															else
															{
																this.wingFrame = 1;
															}
														}
													}
													else
													{
														this.wingFrame = 0;
													}
												}
											}
											else
											{
												if (flag22 || this.jump > 0)
												{
													this.wingFrameCounter++;
													if (this.wingFrameCounter > 4)
													{
														this.wingFrame++;
														this.wingFrameCounter = 0;
														if (this.wingFrame >= 4)
														{
															this.wingFrame = 0;
														}
													}
												}
												else
												{
													if (this.velocity.Y != 0f)
													{
														this.wingFrame = 1;
													}
													else
													{
														this.wingFrame = 0;
													}
												}
											}
										}
									}
								}
								if (this.wingsLogic > 0 && this.rocketBoots > 0)
								{
									this.wingTime += (float)(this.rocketTime * 3);
									this.rocketTime = 0;
								}
								if (flag22 && this.wings != 4 && this.wings != 22 && this.wings != 0 && this.wings != 24)
								{
									if (this.wingFrame == 3)
									{
										if (!this.flapSound)
										{
											Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 32);
										}
										this.flapSound = true;
									}
									else
									{
										this.flapSound = false;
									}
								}
								if (this.velocity.Y == 0f || this.sliding)
								{
									this.rocketTime = this.rocketTimeMax;
								}
								if ((this.wingTime == 0f || this.wingsLogic == 0) && this.rocketBoots > 0 && this.controlJump && this.rocketDelay == 0 && this.canRocket && this.rocketRelease && !this.jumpAgain)
								{
									if (this.rocketTime > 0)
									{
										this.rocketTime--;
										this.rocketDelay = 10;
										if (this.rocketDelay2 <= 0)
										{
											if (this.rocketBoots == 1)
											{
												Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 13);
												this.rocketDelay2 = 30;
											}
											else
											{
												if (this.rocketBoots == 2 || this.rocketBoots == 3)
												{
													Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 24);
													this.rocketDelay2 = 15;
												}
											}
										}
									}
									else
									{
										this.canRocket = false;
									}
								}
								if (this.rocketDelay2 > 0)
								{
									this.rocketDelay2--;
								}
								if (this.rocketDelay == 0)
								{
									this.rocketFrame = false;
								}
								if (this.rocketDelay > 0)
								{
									int num134 = this.height;
									if (this.gravDir == -1f)
									{
										num134 = 4;
									}
									this.rocketFrame = true;
									for (int num135 = 0; num135 < 2; num135++)
									{
										int type4 = 6;
										float scale2 = 2.5f;
										int alpha2 = 100;
										if (this.rocketBoots == 2)
										{
											type4 = 16;
											scale2 = 1.5f;
											alpha2 = 20;
										}
										else
										{
											if (this.rocketBoots == 3)
											{
												type4 = 76;
												scale2 = 1f;
												alpha2 = 20;
											}
											else
											{
												if (this.socialShadow)
												{
													type4 = 27;
													scale2 = 1.5f;
												}
											}
										}
										if (num135 == 0)
										{
											int num136 = Dust.NewDust(new Vector2(this.position.X - 4f, this.position.Y + (float)num134 - 10f), 8, 8, type4, 0f, 0f, alpha2, default(Color), scale2);
											if (this.rocketBoots == 1)
											{
												Main.dust[num136].noGravity = true;
											}
											Main.dust[num136].velocity.X = Main.dust[num136].velocity.X * 1f - 2f - this.velocity.X * 0.3f;
											Main.dust[num136].velocity.Y = Main.dust[num136].velocity.Y * 1f + 2f * this.gravDir - this.velocity.Y * 0.3f;
											if (this.rocketBoots == 2)
											{
												Main.dust[num136].velocity *= 0.1f;
											}
											if (this.rocketBoots == 3)
											{
												Main.dust[num136].velocity *= 0.05f;
												Dust expr_9362_cp_0 = Main.dust[num136];
												expr_9362_cp_0.velocity.Y = expr_9362_cp_0.velocity.Y + 0.15f;
												Main.dust[num136].noLight = true;
												if (Main.rand.Next(2) == 0)
												{
													Main.dust[num136].noGravity = true;
													Main.dust[num136].scale = 1.75f;
												}
											}
										}
										else
										{
											int num137 = Dust.NewDust(new Vector2(this.position.X + (float)this.width - 4f, this.position.Y + (float)num134 - 10f), 8, 8, type4, 0f, 0f, alpha2, default(Color), scale2);
											if (this.rocketBoots == 1)
											{
												Main.dust[num137].noGravity = true;
											}
											Main.dust[num137].velocity.X = Main.dust[num137].velocity.X * 1f + 2f - this.velocity.X * 0.3f;
											Main.dust[num137].velocity.Y = Main.dust[num137].velocity.Y * 1f + 2f * this.gravDir - this.velocity.Y * 0.3f;
											if (this.rocketBoots == 2)
											{
												Main.dust[num137].velocity *= 0.1f;
											}
											if (this.rocketBoots == 3)
											{
												Main.dust[num137].velocity *= 0.05f;
												Dust expr_950B_cp_0 = Main.dust[num137];
												expr_950B_cp_0.velocity.Y = expr_950B_cp_0.velocity.Y + 0.15f;
												Main.dust[num137].noLight = true;
												if (Main.rand.Next(2) == 0)
												{
													Main.dust[num137].noGravity = true;
													Main.dust[num137].scale = 1.75f;
												}
											}
										}
									}
									if (this.rocketDelay == 0)
									{
										this.releaseJump = true;
									}
									this.rocketDelay--;
									this.velocity.Y = this.velocity.Y - 0.1f * this.gravDir;
									if (this.gravDir == 1f)
									{
										if (this.velocity.Y > 0f)
										{
											this.velocity.Y = this.velocity.Y - 0.5f;
										}
										else
										{
											if ((double)this.velocity.Y > (double)(-(double)Player.jumpSpeed) * 0.5)
											{
												this.velocity.Y = this.velocity.Y - 0.1f;
											}
										}
										if (this.velocity.Y < -Player.jumpSpeed * 1.5f)
										{
											this.velocity.Y = -Player.jumpSpeed * 1.5f;
										}
									}
									else
									{
										if (this.velocity.Y < 0f)
										{
											this.velocity.Y = this.velocity.Y + 0.5f;
										}
										else
										{
											if ((double)this.velocity.Y < (double)Player.jumpSpeed * 0.5)
											{
												this.velocity.Y = this.velocity.Y + 0.1f;
											}
										}
										if (this.velocity.Y > Player.jumpSpeed * 1.5f)
										{
											this.velocity.Y = Player.jumpSpeed * 1.5f;
										}
									}
								}
								else
								{
									if (!flag22)
									{
										if (this.mount == 1 && this.controlJump && this.jump == 0)
										{
											if (this.mountFlyTime > 0)
											{
												this.mountFlyTime--;
												if (this.controlDown)
												{
													this.velocity.Y = this.velocity.Y * 0.9f;
													if (this.velocity.Y > -1f && (double)this.velocity.Y < 0.5)
													{
														this.velocity.Y = 1E-05f;
													}
												}
												else
												{
													if (this.velocity.Y > 0f)
													{
														this.velocity.Y = this.velocity.Y - 0.5f;
													}
													else
													{
														if ((double)this.velocity.Y > (double)(-(double)Player.jumpSpeed) * 1.5)
														{
															this.velocity.Y = this.velocity.Y - 0.1f;
														}
													}
													if (this.velocity.Y < -Player.jumpSpeed * 1.5f)
													{
														this.velocity.Y = -Player.jumpSpeed * 1.5f;
													}
												}
											}
											else
											{
												this.velocity.Y = this.velocity.Y + num2 / 3f * this.gravDir;
												if (this.gravDir == 1f)
												{
													if (this.velocity.Y > num / 3f && !this.controlDown)
													{
														this.velocity.Y = num / 3f;
													}
												}
												else
												{
													if (this.velocity.Y < -num / 3f && !this.controlUp)
													{
														this.velocity.Y = -num / 3f;
													}
												}
											}
										}
										else
										{
											if (this.slowFall && ((!this.controlDown && this.gravDir == 1f) || (!this.controlDown && this.gravDir == -1f)))
											{
												if ((this.controlUp && this.gravDir == 1f) || (this.controlUp && this.gravDir == -1f))
												{
													num2 = num2 / 10f * this.gravDir;
												}
												else
												{
													num2 = num2 / 3f * this.gravDir;
												}
												this.velocity.Y = this.velocity.Y + num2;
											}
											else
											{
												if (this.wingsLogic > 0 && this.controlJump && this.velocity.Y > 0f)
												{
													this.fallStart = (int)(this.position.Y / 16f);
													if (this.velocity.Y > 0f)
													{
														if (this.wings == 10 && Main.rand.Next(3) == 0)
														{
															int num138 = 4;
															if (this.direction == 1)
															{
																num138 = -40;
															}
															int num139 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) + (float)num138, this.position.Y + (float)(this.height / 2) - 15f), 30, 30, 76, 0f, 0f, 50, default(Color), 0.6f);
															Main.dust[num139].fadeIn = 1.1f;
															Main.dust[num139].noGravity = true;
															Main.dust[num139].noLight = true;
															Main.dust[num139].velocity *= 0.3f;
														}
														if (this.wings == 9 && Main.rand.Next(3) == 0)
														{
															int num140 = 8;
															if (this.direction == 1)
															{
																num140 = -40;
															}
															int num141 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) + (float)num140, this.position.Y + (float)(this.height / 2) - 15f), 30, 30, 6, 0f, 0f, 200, default(Color), 2f);
															Main.dust[num141].noGravity = true;
															Main.dust[num141].velocity *= 0.3f;
														}
														if (this.wings == 6)
														{
															if (Main.rand.Next(10) == 0)
															{
																int num142 = 4;
																if (this.direction == 1)
																{
																	num142 = -40;
																}
																int num143 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) + (float)num142, this.position.Y + (float)(this.height / 2) - 12f), 30, 20, 55, 0f, 0f, 200, default(Color), 1f);
																Main.dust[num143].velocity *= 0.3f;
															}
														}
														else
														{
															if (this.wings == 5 && Main.rand.Next(6) == 0)
															{
																int num144 = 6;
																if (this.direction == 1)
																{
																	num144 = -30;
																}
																int num145 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) + (float)num144, this.position.Y), 18, this.height, 58, 0f, 0f, 255, default(Color), 1.2f);
																Main.dust[num145].velocity *= 0.3f;
															}
														}
														if (this.wings == 4)
														{
															this.rocketDelay2--;
															if (this.rocketDelay2 <= 0)
															{
																Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 13);
																this.rocketDelay2 = 60;
															}
															int type5 = 6;
															float scale3 = 1.5f;
															int alpha3 = 100;
															float x2 = this.position.X + (float)(this.width / 2) + 16f;
															if (this.direction > 0)
															{
																x2 = this.position.X + (float)(this.width / 2) - 26f;
															}
															float num146 = this.position.Y + (float)this.height - 18f;
															if (Main.rand.Next(2) == 1)
															{
																x2 = this.position.X + (float)(this.width / 2) + 8f;
																if (this.direction > 0)
																{
																	x2 = this.position.X + (float)(this.width / 2) - 20f;
																}
																num146 += 6f;
															}
															int num147 = Dust.NewDust(new Vector2(x2, num146), 8, 8, type5, 0f, 0f, alpha3, default(Color), scale3);
															Dust expr_9DF6_cp_0 = Main.dust[num147];
															expr_9DF6_cp_0.velocity.X = expr_9DF6_cp_0.velocity.X * 0.3f;
															Dust expr_9E14_cp_0 = Main.dust[num147];
															expr_9E14_cp_0.velocity.Y = expr_9E14_cp_0.velocity.Y + 10f;
															Main.dust[num147].noGravity = true;
															this.wingFrameCounter++;
															if (this.wingFrameCounter > 4)
															{
																this.wingFrame++;
																this.wingFrameCounter = 0;
																if (this.wingFrame >= 3)
																{
																	this.wingFrame = 0;
																}
															}
														}
														else
														{
															if (this.wings != 22 && this.wings != 24)
															{
																if (this.wings == 12)
																{
																	this.wingFrame = 3;
																}
																else
																{
																	this.wingFrame = 2;
																}
															}
														}
													}
													this.velocity.Y = this.velocity.Y + num2 / 3f * this.gravDir;
													if (this.gravDir == 1f)
													{
														if (this.velocity.Y > num / 3f && !this.controlDown)
														{
															this.velocity.Y = num / 3f;
														}
													}
													else
													{
														if (this.velocity.Y < -num / 3f && !this.controlUp)
														{
															this.velocity.Y = -num / 3f;
														}
													}
												}
												else
												{
													this.velocity.Y = this.velocity.Y + num2 * this.gravDir;
												}
											}
										}
									}
								}
								if (this.gravDir == 1f)
								{
									if (this.velocity.Y > num)
									{
										this.velocity.Y = num;
									}
									if (this.slowFall && this.velocity.Y > num / 3f && !this.controlDown)
									{
										this.velocity.Y = num / 3f;
									}
									if (this.slowFall && this.velocity.Y > num / 5f && this.controlUp)
									{
										this.velocity.Y = num / 10f;
									}
								}
								else
								{
									if (this.velocity.Y < -num)
									{
										this.velocity.Y = -num;
									}
									if (this.slowFall && this.velocity.Y < -num / 3f && !this.controlDown)
									{
										this.velocity.Y = -num / 3f;
									}
									if (this.slowFall && this.velocity.Y < -num / 5f && this.controlUp)
									{
										this.velocity.Y = -num / 10f;
									}
								}
							}
						}
					}
					if (this.wingsLogic == 3)
					{
						if (this.controlUp && this.controlDown)
						{
							this.velocity.Y = 0f;
						}
						else
						{
							if (this.controlDown && this.controlJump)
							{
								this.velocity.Y = this.velocity.Y * 0.9f;
								if (this.velocity.Y > -2f && this.velocity.Y < 1f)
								{
									this.velocity.Y = 1E-05f;
								}
							}
							else
							{
								if (this.controlDown && this.velocity.Y != 0f)
								{
									this.velocity.Y = this.velocity.Y + 0.2f;
								}
							}
						}
					}
					if (this.wingsLogic == 22 && this.controlDown && this.controlJump && this.wingTime > 0f)
					{
						this.velocity.Y = this.velocity.Y * 0.9f;
						if (this.velocity.Y > -2f && this.velocity.Y < 1f)
						{
							this.velocity.Y = 1E-05f;
						}
					}
					for (int num148 = 0; num148 < 400; num148++)
					{
						if (Main.item[num148].active && Main.item[num148].noGrabDelay == 0 && Main.item[num148].owner == i)
						{
							int num149 = Player.defaultItemGrabRange;
							if (this.manaMagnet && (Main.item[num148].type == 184 || Main.item[num148].type == 1735 || Main.item[num148].type == 1868))
							{
								num149 += Item.manaGrabRange;
							}
							if (new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height).Intersects(new Rectangle((int)Main.item[num148].position.X, (int)Main.item[num148].position.Y, Main.item[num148].width, Main.item[num148].height)))
							{
								if (i == Main.myPlayer && (this.inventory[this.selectedItem].type != 0 || this.itemAnimation <= 0))
								{
									if (Main.item[num148].type == 58 || Main.item[num148].type == 1734 || Main.item[num148].type == 1867)
									{
										Main.PlaySound(7, (int)this.position.X, (int)this.position.Y, 1);
										this.statLife += 20;
										if (Main.myPlayer == this.whoAmi)
										{
											this.HealEffect(20, true);
										}
										if (this.statLife > this.statLifeMax)
										{
											this.statLife = this.statLifeMax;
										}
										Main.item[num148] = new Item();
										if (Main.netMode == 1)
										{
											NetMessage.SendData(21, -1, -1, "", num148, 0f, 0f, 0f, 0);
										}
									}
									else
									{
										if (Main.item[num148].type == 184 || Main.item[num148].type == 1735 || Main.item[num148].type == 1868)
										{
											Main.PlaySound(7, (int)this.position.X, (int)this.position.Y, 1);
											this.statMana += 100;
											if (Main.myPlayer == this.whoAmi)
											{
												this.ManaEffect(100);
											}
											if (this.statMana > this.statManaMax2)
											{
												this.statMana = this.statManaMax2;
											}
											Main.item[num148] = new Item();
											if (Main.netMode == 1)
											{
												NetMessage.SendData(21, -1, -1, "", num148, 0f, 0f, 0f, 0);
											}
										}
										else
										{
											Main.item[num148] = this.GetItem(i, Main.item[num148]);
											if (Main.netMode == 1)
											{
												NetMessage.SendData(21, -1, -1, "", num148, 0f, 0f, 0f, 0);
											}
										}
									}
								}
							}
							else
							{
								if (new Rectangle((int)this.position.X - num149, (int)this.position.Y - num149, this.width + num149 * 2, this.height + num149 * 2).Intersects(new Rectangle((int)Main.item[num148].position.X, (int)Main.item[num148].position.Y, Main.item[num148].width, Main.item[num148].height)) && this.ItemSpace(Main.item[num148]))
								{
									Main.item[num148].beingGrabbed = true;
									if (this.manaMagnet && (Main.item[num148].type == 184 || Main.item[num148].type == 1735 || Main.item[num148].type == 1868))
									{
										float num150 = 12f;
										Vector2 vector = new Vector2(Main.item[num148].position.X + (float)(Main.item[num148].width / 2), Main.item[num148].position.Y + (float)(Main.item[num148].height / 2));
										float num151 = this.center().X - vector.X;
										float num152 = this.center().Y - vector.Y;
										float num153 = (float)Math.Sqrt((double)(num151 * num151 + num152 * num152));
										num153 = num150 / num153;
										num151 *= num153;
										num152 *= num153;
										int num154 = 5;
										Main.item[num148].velocity.X = (Main.item[num148].velocity.X * (float)(num154 - 1) + num151) / (float)num154;
										Main.item[num148].velocity.Y = (Main.item[num148].velocity.Y * (float)(num154 - 1) + num152) / (float)num154;
									}
									else
									{
										if ((double)this.position.X + (double)this.width * 0.5 > (double)Main.item[num148].position.X + (double)Main.item[num148].width * 0.5)
										{
											if (Main.item[num148].velocity.X < Player.itemGrabSpeedMax + this.velocity.X)
											{
												Item expr_A76C_cp_0 = Main.item[num148];
												expr_A76C_cp_0.velocity.X = expr_A76C_cp_0.velocity.X + Player.itemGrabSpeed;
											}
											if (Main.item[num148].velocity.X < 0f)
											{
												Item expr_A7A6_cp_0 = Main.item[num148];
												expr_A7A6_cp_0.velocity.X = expr_A7A6_cp_0.velocity.X + Player.itemGrabSpeed * 0.75f;
											}
										}
										else
										{
											if (Main.item[num148].velocity.X > -Player.itemGrabSpeedMax + this.velocity.X)
											{
												Item expr_A7F5_cp_0 = Main.item[num148];
												expr_A7F5_cp_0.velocity.X = expr_A7F5_cp_0.velocity.X - Player.itemGrabSpeed;
											}
											if (Main.item[num148].velocity.X > 0f)
											{
												Item expr_A82C_cp_0 = Main.item[num148];
												expr_A82C_cp_0.velocity.X = expr_A82C_cp_0.velocity.X - Player.itemGrabSpeed * 0.75f;
											}
										}
										if ((double)this.position.Y + (double)this.height * 0.5 > (double)Main.item[num148].position.Y + (double)Main.item[num148].height * 0.5)
										{
											if (Main.item[num148].velocity.Y < Player.itemGrabSpeedMax)
											{
												Item expr_A8B5_cp_0 = Main.item[num148];
												expr_A8B5_cp_0.velocity.Y = expr_A8B5_cp_0.velocity.Y + Player.itemGrabSpeed;
											}
											if (Main.item[num148].velocity.Y < 0f)
											{
												Item expr_A8EF_cp_0 = Main.item[num148];
												expr_A8EF_cp_0.velocity.Y = expr_A8EF_cp_0.velocity.Y + Player.itemGrabSpeed * 0.75f;
											}
										}
										else
										{
											if (Main.item[num148].velocity.Y > -Player.itemGrabSpeedMax)
											{
												Item expr_A92F_cp_0 = Main.item[num148];
												expr_A92F_cp_0.velocity.Y = expr_A92F_cp_0.velocity.Y - Player.itemGrabSpeed;
											}
											if (Main.item[num148].velocity.Y > 0f)
											{
												Item expr_A966_cp_0 = Main.item[num148];
												expr_A966_cp_0.velocity.Y = expr_A966_cp_0.velocity.Y - Player.itemGrabSpeed * 0.75f;
											}
										}
									}
								}
							}
						}
					}
					if (!Main.mapFullscreen)
					{
						if (this.position.X / 16f - (float)Player.tileRangeX <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX - 1f >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY - 2f >= (float)Player.tileTargetY)
						{
							if (Main.tile[Player.tileTargetX, Player.tileTargetY] == null)
							{
								Main.tile[Player.tileTargetX, Player.tileTargetY] = new Tile();
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].active())
							{
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 104)
								{
									this.noThrow = 2;
									this.showItemIcon = true;
									int num155 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 36);
									this.showItemIcon2 = 359;
									if (num155 == 1)
									{
										this.showItemIcon2 = 2237;
									}
									if (num155 == 2)
									{
										this.showItemIcon2 = 2238;
									}
									if (num155 == 3)
									{
										this.showItemIcon2 = 2239;
									}
									if (num155 == 4)
									{
										this.showItemIcon2 = 2240;
									}
									if (num155 == 5)
									{
										this.showItemIcon2 = 2241;
									}
								}
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 79)
								{
									this.noThrow = 2;
									this.showItemIcon = true;
									int num156 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameY / 36);
									if (num156 == 0)
									{
										this.showItemIcon2 = 224;
									}
									else
									{
										if (num156 == 1)
										{
											this.showItemIcon2 = 644;
										}
										else
										{
											if (num156 == 2)
											{
												this.showItemIcon2 = 645;
											}
											else
											{
												if (num156 == 3)
												{
													this.showItemIcon2 = 646;
												}
												else
												{
													if (num156 == 4)
													{
														this.showItemIcon2 = 920;
													}
													else
													{
														if (num156 == 5)
														{
															this.showItemIcon2 = 1470;
														}
														else
														{
															if (num156 == 6)
															{
																this.showItemIcon2 = 1471;
															}
															else
															{
																if (num156 == 7)
																{
																	this.showItemIcon2 = 1472;
																}
																else
																{
																	if (num156 == 8)
																	{
																		this.showItemIcon2 = 1473;
																	}
																	else
																	{
																		if (num156 == 9)
																		{
																			this.showItemIcon2 = 1719;
																		}
																		else
																		{
																			if (num156 == 10)
																			{
																				this.showItemIcon2 = 1720;
																			}
																			else
																			{
																				if (num156 == 11)
																				{
																					this.showItemIcon2 = 1721;
																				}
																				else
																				{
																					if (num156 == 12)
																					{
																						this.showItemIcon2 = 1722;
																					}
																					else
																					{
																						if (num156 >= 13 && num156 <= 18)
																						{
																							this.showItemIcon2 = 2066 + num156 - 13;
																						}
																						else
																						{
																							if (num156 >= 19 && num156 <= 20)
																							{
																								this.showItemIcon2 = 2139 + num156 - 19;
																							}
																							else
																							{
																								if (num156 == 21)
																								{
																									this.showItemIcon2 = 2231;
																								}
																								else
																								{
																									this.showItemIcon2 = 646;
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
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 209)
								{
									this.noThrow = 2;
									this.showItemIcon = true;
									if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX < 72)
									{
										this.showItemIcon2 = 928;
									}
									else
									{
										if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX < 144)
										{
											this.showItemIcon2 = 1337;
										}
									}
									int num157;
									for (num157 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 18); num157 >= 4; num157 -= 4)
									{
									}
									if (num157 < 2)
									{
										this.showItemIconR = true;
									}
									else
									{
										this.showItemIconR = false;
									}
								}
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 216)
								{
									this.noThrow = 2;
									this.showItemIcon = true;
									int num158 = (int)Main.tile[Player.tileTargetX, Player.tileTargetY].frameY;
									int num159 = 0;
									while (num158 >= 40)
									{
										num158 -= 40;
										num159++;
									}
									this.showItemIcon2 = 970 + num159;
								}
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 212)
								{
									this.noThrow = 2;
									this.showItemIcon = true;
									this.showItemIcon2 = 949;
								}
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 21)
								{
									Tile tile = Main.tile[Player.tileTargetX, Player.tileTargetY];
									int num160 = Player.tileTargetX;
									int num161 = Player.tileTargetY;
									if (tile.frameX % 36 != 0)
									{
										num160--;
									}
									if (tile.frameY % 36 != 0)
									{
										num161--;
									}
									int num162 = Chest.FindChest(num160, num161);
									this.showItemIcon2 = -1;
									if (num162 < 0)
									{
										this.showItemIconText = Lang.chestType[0];
									}
									else
									{
										if (Main.chest[num162].name != "")
										{
											this.showItemIconText = Main.chest[num162].name;
										}
										else
										{
											this.showItemIconText = Lang.chestType[(int)(tile.frameX / 36)];
										}
										if (this.showItemIconText == Lang.chestType[(int)(tile.frameX / 36)])
										{
											this.showItemIcon2 = Chest.typeToIcon[(int)(tile.frameX / 36)];
											this.showItemIconText = "";
										}
									}
									this.noThrow = 2;
									this.showItemIcon = true;
								}
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 4)
								{
									this.noThrow = 2;
									this.showItemIcon = true;
									int num163 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameY / 22);
									if (num163 == 0)
									{
										this.showItemIcon2 = 8;
									}
									else
									{
										if (num163 == 8)
										{
											this.showItemIcon2 = 523;
										}
										else
										{
											if (num163 == 9)
											{
												this.showItemIcon2 = 974;
											}
											else
											{
												if (num163 == 10)
												{
													this.showItemIcon2 = 1245;
												}
												else
												{
													if (num163 == 11)
													{
														this.showItemIcon2 = 1333;
													}
													else
													{
														if (num163 == 12)
														{
															this.showItemIcon2 = 2274;
														}
														else
														{
															this.showItemIcon2 = 426 + num163;
														}
													}
												}
											}
										}
									}
								}
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 13)
								{
									this.noThrow = 2;
									this.showItemIcon = true;
									int num164 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 18);
									if (num164 == 1)
									{
										this.showItemIcon2 = 28;
									}
									else
									{
										if (num164 == 2)
										{
											this.showItemIcon2 = 110;
										}
										else
										{
											if (num164 == 3)
											{
												this.showItemIcon2 = 350;
											}
											else
											{
												if (num164 == 4)
												{
													this.showItemIcon2 = 351;
												}
												else
												{
													if (num164 == 5)
													{
														this.showItemIcon2 = 2234;
													}
													else
													{
														if (num164 == 6)
														{
															this.showItemIcon2 = 2244;
														}
														else
														{
															if (num164 == 7)
															{
																this.showItemIcon2 = 2257;
															}
															else
															{
																if (num164 == 8)
																{
																	this.showItemIcon2 = 2258;
																}
																else
																{
																	this.showItemIcon2 = 31;
																}
															}
														}
													}
												}
											}
										}
									}
								}
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 29)
								{
									this.noThrow = 2;
									this.showItemIcon = true;
									this.showItemIcon2 = 87;
								}
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 97)
								{
									this.noThrow = 2;
									this.showItemIcon = true;
									this.showItemIcon2 = 346;
								}
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 33)
								{
									this.noThrow = 2;
									this.showItemIcon = true;
									this.showItemIcon2 = 105;
									int num165 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameY / 22);
									if (num165 == 1)
									{
										this.showItemIcon2 = 1405;
									}
									if (num165 == 2)
									{
										this.showItemIcon2 = 1406;
									}
									if (num165 == 3)
									{
										this.showItemIcon2 = 1407;
									}
									if (num165 >= 4 && num165 <= 13)
									{
										this.showItemIcon2 = 2045 + num165 - 4;
									}
									if (num165 >= 14 && num165 <= 16)
									{
										this.showItemIcon2 = 2153 + num165 - 14;
									}
									if (num165 == 17)
									{
										this.showItemIcon2 = 2236;
									}
								}
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 49)
								{
									this.noThrow = 2;
									this.showItemIcon = true;
									this.showItemIcon2 = 148;
								}
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 174)
								{
									this.noThrow = 2;
									this.showItemIcon = true;
									this.showItemIcon2 = 713;
								}
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 50)
								{
									this.noThrow = 2;
									if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX == 90)
									{
										this.showItemIcon = true;
										this.showItemIcon2 = 165;
									}
								}
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 139)
								{
									this.noThrow = 2;
									int num166 = Player.tileTargetX;
									int num167 = Player.tileTargetY;
									int num168 = 0;
									for (int num169 = (int)(Main.tile[num166, num167].frameY / 18); num169 >= 2; num169 -= 2)
									{
										num168++;
									}
									this.showItemIcon = true;
									if (num168 == 28)
									{
										this.showItemIcon2 = 1963;
									}
									else
									{
										if (num168 == 29)
										{
											this.showItemIcon2 = 1964;
										}
										else
										{
											if (num168 == 30)
											{
												this.showItemIcon2 = 1965;
											}
											else
											{
												if (num168 >= 13)
												{
													this.showItemIcon2 = 1596 + num168 - 13;
												}
												else
												{
													this.showItemIcon2 = 562 + num168;
												}
											}
										}
									}
								}
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 207)
								{
									this.noThrow = 2;
									int num170 = Player.tileTargetX;
									int num171 = Player.tileTargetY;
									int num172 = 0;
									for (int num173 = (int)(Main.tile[num170, num171].frameX / 18); num173 >= 2; num173 -= 2)
									{
										num172++;
									}
									this.showItemIcon = true;
									if (num172 == 0)
									{
										this.showItemIcon2 = 909;
									}
									else
									{
										if (num172 == 1)
										{
											this.showItemIcon2 = 910;
										}
										else
										{
											if (num172 == 2)
											{
												this.showItemIcon2 = 940;
											}
											else
											{
												if (num172 == 3)
												{
													this.showItemIcon2 = 941;
												}
												else
												{
													if (num172 == 4)
													{
														this.showItemIcon2 = 942;
													}
													else
													{
														if (num172 == 5)
														{
															this.showItemIcon2 = 943;
														}
														else
														{
															if (num172 == 6)
															{
																this.showItemIcon2 = 944;
															}
															else
															{
																if (num172 == 7)
																{
																	this.showItemIcon2 = 945;
																}
															}
														}
													}
												}
											}
										}
									}
								}
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 55 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 85)
								{
									this.noThrow = 2;
									int num174 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 18);
									int num175 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameY / 18);
									while (num174 > 1)
									{
										num174 -= 2;
									}
									int num176 = Player.tileTargetX - num174;
									int num177 = Player.tileTargetY - num175;
									Main.signBubble = true;
									Main.signX = num176 * 16 + 16;
									Main.signY = num177 * 16;
								}
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 237)
								{
									this.noThrow = 2;
									this.showItemIcon = true;
									this.showItemIcon2 = 1293;
								}
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 88)
								{
									this.noThrow = 2;
									this.showItemIcon = true;
									int num178 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 54);
									if (num178 == 0)
									{
										this.showItemIcon2 = 334;
									}
									else
									{
										if (num178 == 1)
										{
											this.showItemIcon2 = 647;
										}
										else
										{
											if (num178 == 2)
											{
												this.showItemIcon2 = 648;
											}
											else
											{
												if (num178 == 3)
												{
													this.showItemIcon2 = 649;
												}
											}
										}
									}
								}
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 10 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 11)
								{
									this.noThrow = 2;
									this.showItemIcon = true;
									int num179 = (int)Main.tile[Player.tileTargetX, Player.tileTargetY].frameY;
									int num180 = 0;
									while (num179 >= 54)
									{
										num179 -= 54;
										num180++;
									}
									if (num180 == 0)
									{
										this.showItemIcon2 = 25;
									}
									else
									{
										if (num180 == 9)
										{
											this.showItemIcon2 = 837;
										}
										else
										{
											if (num180 == 10)
											{
												this.showItemIcon2 = 912;
											}
											else
											{
												if (num180 == 11)
												{
													this.showItemIcon2 = 1141;
												}
												else
												{
													if (num180 == 12)
													{
														this.showItemIcon2 = 1137;
													}
													else
													{
														if (num180 == 13)
														{
															this.showItemIcon2 = 1138;
														}
														else
														{
															if (num180 == 14)
															{
																this.showItemIcon2 = 1139;
															}
															else
															{
																if (num180 == 15)
																{
																	this.showItemIcon2 = 1140;
																}
																else
																{
																	if (num180 == 16)
																	{
																		this.showItemIcon2 = 1411;
																	}
																	else
																	{
																		if (num180 == 17)
																		{
																			this.showItemIcon2 = 1412;
																		}
																		else
																		{
																			if (num180 == 18)
																			{
																				this.showItemIcon2 = 1413;
																			}
																			else
																			{
																				if (num180 == 19)
																				{
																					this.showItemIcon2 = 1458;
																				}
																				else
																				{
																					if (num180 >= 20 && num180 <= 23)
																					{
																						this.showItemIcon2 = 1709 + num180 - 20;
																					}
																					else
																					{
																						if (num180 == 24)
																						{
																							this.showItemIcon2 = 1793;
																						}
																						else
																						{
																							if (num180 == 25)
																							{
																								this.showItemIcon2 = 1815;
																							}
																							else
																							{
																								if (num180 == 26)
																								{
																									this.showItemIcon2 = 1924;
																								}
																								else
																								{
																									if (num180 == 27)
																									{
																										this.showItemIcon2 = 2044;
																									}
																									else
																									{
																										if (num180 == 28)
																										{
																											this.showItemIcon2 = 2265;
																										}
																										else
																										{
																											if (num180 >= 4 && num180 <= 8)
																											{
																												this.showItemIcon2 = 812 + num180;
																											}
																											else
																											{
																												this.showItemIcon2 = 649 + num180;
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
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 125)
								{
									this.noThrow = 2;
									this.showItemIcon = true;
									this.showItemIcon2 = 487;
								}
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 287)
								{
									this.noThrow = 2;
									this.showItemIcon = true;
									this.showItemIcon2 = 2177;
								}
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 132)
								{
									this.noThrow = 2;
									this.showItemIcon = true;
									this.showItemIcon2 = 513;
								}
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 136)
								{
									this.noThrow = 2;
									this.showItemIcon = true;
									this.showItemIcon2 = 538;
								}
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 144)
								{
									this.noThrow = 2;
									this.showItemIcon = true;
									this.showItemIcon2 = (int)(583 + Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 18);
								}
								if (this.controlUseTile)
								{
									if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 212 && this.launcherWait <= 0)
									{
										int num181 = Player.tileTargetX;
										int num182 = Player.tileTargetY;
										bool flag23 = false;
										for (int num183 = 0; num183 < 58; num183++)
										{
											if (this.inventory[num183].type == 949 && this.inventory[num183].stack > 0)
											{
												this.inventory[num183].stack--;
												if (this.inventory[num183].stack <= 0)
												{
													this.inventory[num183].SetDefaults(0, false);
												}
												flag23 = true;
												break;
											}
										}
										if (flag23)
										{
											this.launcherWait = 10;
											Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 11);
											int num184 = (int)(Main.tile[num181, num182].frameX / 18);
											int num185 = 0;
											while (num184 >= 3)
											{
												num185++;
												num184 -= 3;
											}
											num184 = num181 - num184;
											int num186;
											for (num186 = (int)(Main.tile[num181, num182].frameY / 18); num186 >= 3; num186 -= 3)
											{
											}
											num186 = num182 - num186;
											float num187 = 12f + (float)Main.rand.Next(450) * 0.01f;
											float num188 = (float)Main.rand.Next(85, 105);
											float num189 = (float)Main.rand.Next(-35, 11);
											int type6 = 166;
											int damage = 17;
											float knockBack = 3.5f;
											Vector2 vector2 = new Vector2((float)((num184 + 2) * 16 - 8), (float)((num186 + 2) * 16 - 8));
											if (num185 == 0)
											{
												num188 *= -1f;
												vector2.X -= 12f;
											}
											else
											{
												vector2.X += 12f;
											}
											float num190 = num188;
											float num191 = num189;
											float num192 = (float)Math.Sqrt((double)(num190 * num190 + num191 * num191));
											num192 = num187 / num192;
											num190 *= num192;
											num191 *= num192;
											Projectile.NewProjectile(vector2.X, vector2.Y, num190, num191, type6, damage, knockBack, Main.myPlayer, 0f, 0f);
										}
									}
									if (this.releaseUseTile)
									{
										if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 132 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 136 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 144)
										{
											WorldGen.hitSwitch(Player.tileTargetX, Player.tileTargetY);
											NetMessage.SendData(59, -1, -1, "", Player.tileTargetX, (float)Player.tileTargetY, 0f, 0f, 0);
										}
										else
										{
											if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 139)
											{
												Main.PlaySound(28, Player.tileTargetX * 16, Player.tileTargetY * 16, 0);
												WorldGen.SwitchMB(Player.tileTargetX, Player.tileTargetY);
											}
											else
											{
												if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 207)
												{
													Main.PlaySound(28, Player.tileTargetX * 16, Player.tileTargetY * 16, 0);
													WorldGen.SwitchFountain(Player.tileTargetX, Player.tileTargetY);
												}
												else
												{
													if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 216)
													{
														WorldGen.LaunchRocket(Player.tileTargetX, Player.tileTargetY);
													}
													else
													{
														if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 4 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 13 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 33 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 49 || (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 50 && Main.tile[Player.tileTargetX, Player.tileTargetY].frameX == 90) || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 174)
														{
															WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, false, false, false);
															if (Main.netMode == 1)
															{
																NetMessage.SendData(17, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
															}
														}
														else
														{
															if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 125)
															{
																this.AddBuff(29, 36000, true);
																Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 4);
															}
															else
															{
																if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 287)
																{
																	this.AddBuff(93, 36000, true);
																	Main.PlaySound(7, (int)this.position.X, (int)this.position.Y, 1);
																}
																else
																{
																	if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 79)
																	{
																		int num193 = Player.tileTargetX;
																		int num194 = Player.tileTargetY;
																		num193 += (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 18 * -1);
																		if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 72)
																		{
																			num193 += 4;
																			num193++;
																		}
																		else
																		{
																			num193 += 2;
																		}
																		int num195 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameY / 18);
																		int num196 = 0;
																		while (num195 > 1)
																		{
																			num195 -= 2;
																			num196++;
																		}
																		num194 -= num195;
																		num194 += 2;
																		if (Player.CheckSpawn(num193, num194))
																		{
																			this.ChangeSpawn(num193, num194);
																			Main.NewText("Spawn point set!", 255, 240, 20, false);
																		}
																	}
																	else
																	{
																		if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 55 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 85)
																		{
																			bool flag24 = true;
																			if (this.sign >= 0)
																			{
																				int num197 = Sign.ReadSign(Player.tileTargetX, Player.tileTargetY);
																				if (num197 == this.sign)
																				{
																					this.sign = -1;
																					Main.npcChatText = "";
																					Main.editSign = false;
																					Main.PlaySound(11, -1, -1, 1);
																					flag24 = false;
																				}
																			}
																			if (flag24)
																			{
																				if (Main.netMode == 0)
																				{
																					this.talkNPC = -1;
																					Main.playerInventory = false;
																					Main.editSign = false;
																					Main.PlaySound(10, -1, -1, 1);
																					int num198 = Sign.ReadSign(Player.tileTargetX, Player.tileTargetY);
																					this.sign = num198;
																					Main.npcChatText = Main.sign[num198].text;
																				}
																				else
																				{
																					int num199 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 18);
																					int num200 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameY / 18);
																					while (num199 > 1)
																					{
																						num199 -= 2;
																					}
																					int num201 = Player.tileTargetX - num199;
																					int num202 = Player.tileTargetY - num200;
																					if (Main.tile[num201, num202].type == 55 || Main.tile[num201, num202].type == 85)
																					{
																						NetMessage.SendData(46, -1, -1, "", num201, (float)num202, 0f, 0f, 0);
																					}
																				}
																			}
																		}
																		else
																		{
																			if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 104)
																			{
																				string text = "AM";
																				double num203 = Main.time;
																				if (!Main.dayTime)
																				{
																					num203 += 54000.0;
																				}
																				num203 = num203 / 86400.0 * 24.0;
																				double num204 = 7.5;
																				num203 = num203 - num204 - 12.0;
																				if (num203 < 0.0)
																				{
																					num203 += 24.0;
																				}
																				if (num203 >= 12.0)
																				{
																					text = "PM";
																				}
																				int num205 = (int)num203;
																				double num206 = num203 - (double)num205;
																				num206 = (double)((int)(num206 * 60.0));
																				string text2 = string.Concat(num206);
																				if (num206 < 10.0)
																				{
																					text2 = "0" + text2;
																				}
																				if (num205 > 12)
																				{
																					num205 -= 12;
																				}
																				if (num205 == 0)
																				{
																					num205 = 12;
																				}
																				string newText = string.Concat(new object[]
																				{
																					"Time: ",
																					num205,
																					":",
																					text2,
																					" ",
																					text
																				});
																				Main.NewText(newText, 255, 240, 20, false);
																			}
																			else
																			{
																				if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 237)
																				{
																					bool flag25 = false;
																					if (!NPC.AnyNPCs(245) && Main.hardMode && NPC.downedPlantBoss)
																					{
																						for (int num207 = 0; num207 < 58; num207++)
																						{
																							if (this.inventory[num207].type == 1293)
																							{
																								this.inventory[num207].stack--;
																								if (this.inventory[num207].stack <= 0)
																								{
																									this.inventory[num207].SetDefaults(0, false);
																								}
																								flag25 = true;
																								break;
																							}
																						}
																					}
																					if (flag25)
																					{
																						Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
																						if (Main.netMode != 1)
																						{
																							NPC.SpawnOnPlayer(i, 245);
																						}
																						else
																						{
																							NetMessage.SendData(61, -1, -1, "", this.whoAmi, 245f, 0f, 0f, 0);
																						}
																					}
																				}
																				else
																				{
																					if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 10)
																					{
																						int num208 = Player.tileTargetX;
																						int num209 = Player.tileTargetY;
																						if (Main.tile[num208, num209].frameY >= 594 && Main.tile[num208, num209].frameY <= 646)
																						{
																							int num210 = 1141;
																							for (int num211 = 0; num211 < 58; num211++)
																							{
																								if (this.inventory[num211].type == num210 && this.inventory[num211].stack > 0)
																								{
																									this.inventory[num211].stack--;
																									if (this.inventory[num211].stack <= 0)
																									{
																										this.inventory[num211] = new Item();
																									}
																									WorldGen.UnlockDoor(num208, num209);
																									if (Main.netMode == 1)
																									{
																										NetMessage.SendData(52, -1, -1, "", this.whoAmi, 2f, (float)num208, (float)num209, 0);
																									}
																								}
																							}
																						}
																						else
																						{
																							WorldGen.OpenDoor(Player.tileTargetX, Player.tileTargetY, this.direction);
																							NetMessage.SendData(19, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, (float)this.direction, 0);
																						}
																					}
																					else
																					{
																						if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 11 && WorldGen.CloseDoor(Player.tileTargetX, Player.tileTargetY, false))
																						{
																							NetMessage.SendData(19, -1, -1, "", 1, (float)Player.tileTargetX, (float)Player.tileTargetY, (float)this.direction, 0);
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
										if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 88)
										{
											Main.dresserX = Player.tileTargetX;
											Main.dresserY = Player.tileTargetY;
											Main.OpenClothesWindow();
										}
										if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 209)
										{
											WorldGen.SwitchCannon(Player.tileTargetX, Player.tileTargetY);
										}
										else
										{
											if ((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 21 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 29 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 97) && this.talkNPC == -1)
											{
												Main.mouseRightRelease = false;
												int num212 = 0;
												int num213;
												for (num213 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 18); num213 > 1; num213 -= 2)
												{
												}
												num213 = Player.tileTargetX - num213;
												int num214 = Player.tileTargetY - (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameY / 18);
												if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 29)
												{
													num212 = 1;
												}
												else
												{
													if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 97)
													{
														num212 = 2;
													}
												}
												if (this.sign > -1)
												{
													Main.PlaySound(11, -1, -1, 1);
													this.sign = -1;
													Main.editSign = false;
													Main.npcChatText = string.Empty;
												}
												if (Main.editChest)
												{
													Main.PlaySound(12, -1, -1, 1);
													Main.editChest = false;
													Main.npcChatText = string.Empty;
												}
												if (this.editedChestName)
												{
													NetMessage.SendData(33, -1, -1, Main.chest[this.chest].name, this.chest, 1f, 0f, 0f, 0);
													this.editedChestName = false;
												}
												if (Main.netMode == 1 && num212 == 0 && (Main.tile[num213, num214].frameX < 72 || Main.tile[num213, num214].frameX > 106) && (Main.tile[num213, num214].frameX < 144 || Main.tile[num213, num214].frameX > 178) && (Main.tile[num213, num214].frameX < 828 || Main.tile[num213, num214].frameX > 1006))
												{
													if (num213 == this.chestX && num214 == this.chestY && this.chest != -1)
													{
														this.chest = -1;
														Main.PlaySound(11, -1, -1, 1);
													}
													else
													{
														NetMessage.SendData(31, -1, -1, "", num213, (float)num214, 0f, 0f, 0);
													}
												}
												else
												{
													int num215 = -1;
													if (num212 == 1)
													{
														num215 = -2;
													}
													else
													{
														if (num212 == 2)
														{
															num215 = -3;
														}
														else
														{
															bool flag26 = false;
															if ((Main.tile[num213, num214].frameX >= 72 && Main.tile[num213, num214].frameX <= 106) || (Main.tile[num213, num214].frameX >= 144 && Main.tile[num213, num214].frameX <= 178) || (Main.tile[num213, num214].frameX >= 828 && Main.tile[num213, num214].frameX <= 1006))
															{
																int num216 = 327;
																if (Main.tile[num213, num214].frameX >= 144 && Main.tile[num213, num214].frameX <= 178)
																{
																	num216 = 329;
																}
																if (Main.tile[num213, num214].frameX >= 828 && Main.tile[num213, num214].frameX <= 1006)
																{
																	int num217 = (int)(Main.tile[num213, num214].frameX / 18);
																	int num218 = 0;
																	while (num217 >= 2)
																	{
																		num217 -= 2;
																		num218++;
																	}
																	num218 -= 23;
																	num216 = 1533 + num218;
																}
																flag26 = true;
																for (int num219 = 0; num219 < 58; num219++)
																{
																	if (this.inventory[num219].type == num216 && this.inventory[num219].stack > 0)
																	{
																		if (num216 != 329)
																		{
																			this.inventory[num219].stack--;
																			if (this.inventory[num219].stack <= 0)
																			{
																				this.inventory[num219] = new Item();
																			}
																		}
																		Chest.Unlock(num213, num214);
																		if (Main.netMode == 1)
																		{
																			NetMessage.SendData(52, -1, -1, "", this.whoAmi, 1f, (float)num213, (float)num214, 0);
																		}
																	}
																}
															}
															if (!flag26)
															{
																num215 = Chest.FindChest(num213, num214);
																Main.stackSplit = 600;
															}
														}
													}
													if (num215 != -1)
													{
														if (num215 == this.chest)
														{
															this.chest = -1;
															Main.PlaySound(11, -1, -1, 1);
														}
														else
														{
															if (num215 != this.chest && this.chest == -1)
															{
																this.chest = num215;
																Main.playerInventory = true;
																Main.PlaySound(10, -1, -1, 1);
																this.chestX = num213;
																this.chestY = num214;
															}
															else
															{
																this.chest = num215;
																Main.playerInventory = true;
																Main.PlaySound(12, -1, -1, 1);
																this.chestX = num213;
																this.chestY = num214;
															}
														}
													}
												}
											}
										}
									}
									this.releaseUseTile = false;
								}
								else
								{
									this.releaseUseTile = true;
								}
							}
						}
						else
						{
							if (Main.tile[Player.tileTargetX, Player.tileTargetY] == null)
							{
								Main.tile[Player.tileTargetX, Player.tileTargetY] = new Tile();
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 21)
							{
								Tile tile2 = Main.tile[Player.tileTargetX, Player.tileTargetY];
								int num220 = Player.tileTargetX;
								int num221 = Player.tileTargetY;
								if (tile2.frameX % 36 != 0)
								{
									num220--;
								}
								if (tile2.frameY % 36 != 0)
								{
									num221--;
								}
								int num222 = Chest.FindChest(num220, num221);
								this.showItemIcon2 = -1;
								if (num222 < 0)
								{
									this.showItemIconText = Lang.chestType[0];
								}
								else
								{
									if (Main.chest[num222].name != "")
									{
										this.showItemIconText = Main.chest[num222].name;
									}
									else
									{
										this.showItemIconText = Lang.chestType[(int)(tile2.frameX / 36)];
									}
									if (this.showItemIconText == Lang.chestType[(int)(tile2.frameX / 36)])
									{
										this.showItemIcon2 = Chest.typeToIcon[(int)(tile2.frameX / 36)];
										this.showItemIconText = "";
									}
								}
								this.noThrow = 2;
								this.showItemIcon = true;
								if (this.showItemIconText == "")
								{
									this.showItemIcon = false;
									this.showItemIcon2 = 0;
								}
							}
						}
					}
					if (this.tongued)
					{
						bool flag27 = false;
						if (Main.wof >= 0)
						{
							float num223 = Main.npc[Main.wof].position.X + (float)(Main.npc[Main.wof].width / 2);
							num223 += (float)(Main.npc[Main.wof].direction * 200);
							float num224 = Main.npc[Main.wof].position.Y + (float)(Main.npc[Main.wof].height / 2);
							Vector2 vector3 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
							float num225 = num223 - vector3.X;
							float num226 = num224 - vector3.Y;
							float num227 = (float)Math.Sqrt((double)(num225 * num225 + num226 * num226));
							float num228 = 11f;
							float num229;
							if (num227 > num228)
							{
								num229 = num228 / num227;
							}
							else
							{
								num229 = 1f;
								flag27 = true;
							}
							num225 *= num229;
							num226 *= num229;
							this.velocity.X = num225;
							this.velocity.Y = num226;
						}
						else
						{
							flag27 = true;
						}
						if (flag27 && Main.myPlayer == this.whoAmi)
						{
							for (int num230 = 0; num230 < 22; num230++)
							{
								if (this.buffType[num230] == 38)
								{
									this.DelBuff(num230);
								}
							}
						}
					}
					if (Main.myPlayer == this.whoAmi)
					{
						if (Main.wof >= 0 && Main.npc[Main.wof].active)
						{
							float num231 = Main.npc[Main.wof].position.X + 40f;
							if (Main.npc[Main.wof].direction > 0)
							{
								num231 -= 96f;
							}
							if (this.position.X + (float)this.width > num231 && this.position.X < num231 + 140f && this.gross)
							{
								this.noKnockback = false;
								this.Hurt(50, Main.npc[Main.wof].direction, false, false, " was slain...", false);
							}
							if (!this.gross && this.position.Y > (float)((Main.maxTilesY - 250) * 16) && this.position.X > num231 - 1920f && this.position.X < num231 + 1920f)
							{
								this.AddBuff(37, 10, true);
								Main.PlaySound(4, (int)Main.npc[Main.wof].position.X, (int)Main.npc[Main.wof].position.Y, 10);
							}
							if (this.gross)
							{
								if (this.position.Y < (float)((Main.maxTilesY - 200) * 16))
								{
									this.AddBuff(38, 10, true);
								}
								if (Main.npc[Main.wof].direction < 0)
								{
									if (this.position.X + (float)(this.width / 2) > Main.npc[Main.wof].position.X + (float)(Main.npc[Main.wof].width / 2) + 40f)
									{
										this.AddBuff(38, 10, true);
									}
								}
								else
								{
									if (this.position.X + (float)(this.width / 2) < Main.npc[Main.wof].position.X + (float)(Main.npc[Main.wof].width / 2) - 40f)
									{
										this.AddBuff(38, 10, true);
									}
								}
							}
							if (this.tongued)
							{
								this.controlHook = false;
								this.controlUseItem = false;
								for (int num232 = 0; num232 < 1000; num232++)
								{
									if (Main.projectile[num232].active && Main.projectile[num232].owner == Main.myPlayer && Main.projectile[num232].aiStyle == 7)
									{
										Main.projectile[num232].Kill();
									}
								}
								Vector2 vector4 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
								float num233 = Main.npc[Main.wof].position.X + (float)(Main.npc[Main.wof].width / 2) - vector4.X;
								float num234 = Main.npc[Main.wof].position.Y + (float)(Main.npc[Main.wof].height / 2) - vector4.Y;
								float num235 = (float)Math.Sqrt((double)(num233 * num233 + num234 * num234));
								if (num235 > 3000f)
								{
									this.KillMe(1000.0, 0, false, " tried to escape.");
								}
								else
								{
									if (Main.npc[Main.wof].position.X < 608f || Main.npc[Main.wof].position.X > (float)((Main.maxTilesX - 38) * 16))
									{
										this.KillMe(1000.0, 0, false, " was licked.");
									}
								}
							}
						}
						if (this.controlHook)
						{
							if (this.releaseHook)
							{
								this.QuickGrapple();
							}
							this.releaseHook = false;
						}
						else
						{
							this.releaseHook = true;
						}
						if (this.talkNPC >= 0)
						{
							Rectangle rectangle = new Rectangle((int)(this.position.X + (float)(this.width / 2) - (float)(Player.tileRangeX * 16)), (int)(this.position.Y + (float)(this.height / 2) - (float)(Player.tileRangeY * 16)), Player.tileRangeX * 16 * 2, Player.tileRangeY * 16 * 2);
							Rectangle value = new Rectangle((int)Main.npc[this.talkNPC].position.X, (int)Main.npc[this.talkNPC].position.Y, Main.npc[this.talkNPC].width, Main.npc[this.talkNPC].height);
							if (!rectangle.Intersects(value) || this.chest != -1 || !Main.npc[this.talkNPC].active)
							{
								if (this.chest == -1)
								{
									Main.PlaySound(11, -1, -1, 1);
								}
								this.talkNPC = -1;
								Main.npcChatText = "";
							}
						}
						if (this.sign >= 0)
						{
							Rectangle rectangle2 = new Rectangle((int)(this.position.X + (float)(this.width / 2) - (float)(Player.tileRangeX * 16)), (int)(this.position.Y + (float)(this.height / 2) - (float)(Player.tileRangeY * 16)), Player.tileRangeX * 16 * 2, Player.tileRangeY * 16 * 2);
							try
							{
								Rectangle value2 = new Rectangle(Main.sign[this.sign].x * 16, Main.sign[this.sign].y * 16, 32, 32);
								if (!rectangle2.Intersects(value2))
								{
									Main.PlaySound(11, -1, -1, 1);
									this.sign = -1;
									Main.editSign = false;
									Main.npcChatText = "";
								}
							}
							catch
							{
								Main.PlaySound(11, -1, -1, 1);
								this.sign = -1;
								Main.editSign = false;
								Main.npcChatText = "";
							}
						}
						if (Main.editSign)
						{
							if (this.sign == -1)
							{
								Main.editSign = false;
							}
							else
							{
								Main.npcChatText = Main.GetInputText(Main.npcChatText);
								if (Main.inputTextEnter)
								{
									byte[] bytes = new byte[]
									{
										10
									};
									Main.npcChatText += Encoding.ASCII.GetString(bytes);
								}
								else
								{
									if (Main.inputTextEscape)
									{
										Main.PlaySound(12, -1, -1, 1);
										Main.editSign = false;
										Main.blockKey = Keys.Escape;
										Main.npcChatText = Main.sign[this.sign].text;
									}
								}
							}
						}
						else
						{
							if (Main.editChest)
							{
								string inputText = Main.GetInputText(Main.npcChatText);
								if (Main.inputTextEnter)
								{
									Main.PlaySound(12, -1, -1, 1);
									Main.editChest = false;
									int num236 = Main.player[Main.myPlayer].chest;
									if (Main.npcChatText == Main.defaultChestName)
									{
										Main.npcChatText = "";
									}
									if (Main.chest[num236].name != Main.npcChatText)
									{
										Main.chest[num236].name = Main.npcChatText;
										if (Main.netMode == 1)
										{
											this.editedChestName = true;
										}
									}
								}
								else
								{
									if (Main.inputTextEscape)
									{
										Main.PlaySound(12, -1, -1, 1);
										Main.editChest = false;
										Main.npcChatText = string.Empty;
										Main.blockKey = Keys.Escape;
									}
									else
									{
										if (inputText.Length <= 20)
										{
											Main.npcChatText = inputText;
										}
									}
								}
							}
						}
						if (!this.immune)
						{
							Rectangle rectangle3 = new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height);
							for (int num237 = 0; num237 < 200; num237++)
							{
								if (Main.npc[num237].active && !Main.npc[num237].friendly && Main.npc[num237].damage > 0 && rectangle3.Intersects(new Rectangle((int)Main.npc[num237].position.X, (int)Main.npc[num237].position.Y, Main.npc[num237].width, Main.npc[num237].height)))
								{
									int num238 = -1;
									if (Main.npc[num237].position.X + (float)(Main.npc[num237].width / 2) < this.position.X + (float)(this.width / 2))
									{
										num238 = 1;
									}
									int num239 = Main.DamageVar((float)Main.npc[num237].damage);
									if (this.whoAmi == Main.myPlayer && this.thorns && !this.immune && !Main.npc[num237].dontTakeDamage)
									{
										int num240 = num239 / 3;
										int num241 = 10;
										if (this.turtleThorns)
										{
											num240 = num239;
										}
										Main.npc[num237].StrikeNPC(num240, (float)num241, -num238, false, false);
										if (Main.netMode != 0)
										{
											NetMessage.SendData(28, -1, -1, "", num237, (float)num240, (float)num241, (float)(-(float)num238), 0);
										}
									}
									if (!this.immune)
									{
										if (Main.npc[num237].type >= 269 && Main.npc[num237].type <= 272)
										{
											if (Main.rand.Next(3) == 0)
											{
												this.AddBuff(30, 600, true);
											}
											else
											{
												if (Main.rand.Next(3) == 0)
												{
													this.AddBuff(32, 300, true);
												}
											}
										}
										if (Main.npc[num237].type >= 273 && Main.npc[num237].type <= 276 && Main.rand.Next(2) == 0)
										{
											this.AddBuff(36, 600, true);
										}
										if (Main.npc[num237].type >= 277 && Main.npc[num237].type <= 280)
										{
											this.AddBuff(24, 600, true);
										}
										if (((Main.npc[num237].type == 1 && Main.npc[num237].name == "Black Slime") || Main.npc[num237].type == 81 || Main.npc[num237].type == 79) && Main.rand.Next(4) == 0)
										{
											this.AddBuff(22, 900, true);
										}
										if ((Main.npc[num237].type == 23 || Main.npc[num237].type == 25) && Main.rand.Next(3) == 0)
										{
											this.AddBuff(24, 420, true);
										}
										if ((Main.npc[num237].type == 34 || Main.npc[num237].type == 83 || Main.npc[num237].type == 84) && Main.rand.Next(3) == 0)
										{
											this.AddBuff(23, 240, true);
										}
										if ((Main.npc[num237].type == 104 || Main.npc[num237].type == 102) && Main.rand.Next(8) == 0)
										{
											this.AddBuff(30, 2700, true);
										}
										if (Main.npc[num237].type == 75 && Main.rand.Next(10) == 0)
										{
											this.AddBuff(35, 420, true);
										}
										if ((Main.npc[num237].type == 163 || Main.npc[num237].type == 238) && Main.rand.Next(10) == 0)
										{
											this.AddBuff(70, 480, true);
										}
										if ((Main.npc[num237].type == 79 || Main.npc[num237].type == 103) && Main.rand.Next(5) == 0)
										{
											this.AddBuff(35, 420, true);
										}
										if ((Main.npc[num237].type == 75 || Main.npc[num237].type == 78 || Main.npc[num237].type == 82) && Main.rand.Next(8) == 0)
										{
											this.AddBuff(32, 900, true);
										}
										if ((Main.npc[num237].type == 93 || Main.npc[num237].type == 109 || Main.npc[num237].type == 80) && Main.rand.Next(14) == 0)
										{
											this.AddBuff(31, 300, true);
										}
										if (Main.npc[num237].type >= 305 && Main.npc[num237].type <= 314 && Main.rand.Next(10) == 0)
										{
											this.AddBuff(33, 3600, true);
										}
										if (Main.npc[num237].type == 77 && Main.rand.Next(6) == 0)
										{
											this.AddBuff(36, 18000, true);
										}
										if (Main.npc[num237].type == 112 && Main.rand.Next(20) == 0)
										{
											this.AddBuff(33, 18000, true);
										}
										if (Main.npc[num237].type == 182 && Main.rand.Next(25) == 0)
										{
											this.AddBuff(33, 7200, true);
										}
										if (Main.npc[num237].type == 141 && Main.rand.Next(2) == 0)
										{
											this.AddBuff(20, 600, true);
										}
										if (Main.npc[num237].type == 147 && !Main.player[i].frozen && Main.rand.Next(12) == 0)
										{
											Main.player[i].AddBuff(46, 600, true);
										}
										if (Main.npc[num237].type == 150)
										{
											if (Main.rand.Next(2) == 0)
											{
												Main.player[i].AddBuff(46, 900, true);
											}
											if (!Main.player[i].frozen && Main.rand.Next(35) == 0)
											{
												Main.player[i].AddBuff(47, 60, true);
											}
										}
										if (Main.npc[num237].type == 184)
										{
											Main.player[i].AddBuff(46, 1200, true);
											if (!Main.player[i].frozen && Main.rand.Next(15) == 0)
											{
												Main.player[i].AddBuff(47, 60, true);
											}
										}
									}
									this.Hurt(num239, num238, false, false, Lang.deathMsg(-1, num237, -1, -1), false);
								}
							}
						}
						Vector2 vector5 = Collision.HurtTiles(this.position, this.velocity, this.width, this.height, this.fireWalk);
						if (vector5.Y == 20f)
						{
							this.AddBuff(67, 20, true);
						}
						else
						{
							if (vector5.Y == 15f)
							{
								if (this.suffocateDelay < 5)
								{
									this.suffocateDelay += 1;
								}
								else
								{
									this.AddBuff(68, 1, true);
								}
							}
							else
							{
								if (vector5.Y != 0f)
								{
									int damage2 = Main.DamageVar(vector5.Y);
									this.Hurt(damage2, 0, false, false, Lang.deathMsg(-1, -1, -1, 3), false);
								}
								else
								{
									this.suffocateDelay = 0;
								}
							}
						}
					}
					if (this.controlRight)
					{
						this.releaseRight = false;
					}
					else
					{
						this.releaseRight = true;
						this.rightTimer = 7;
					}
					if (this.controlLeft)
					{
						this.releaseLeft = false;
					}
					else
					{
						this.releaseLeft = true;
						this.leftTimer = 7;
					}
					if (this.rightTimer > 0)
					{
						this.rightTimer--;
					}
					else
					{
						if (this.controlRight)
						{
							this.rightTimer = 7;
						}
					}
					if (this.leftTimer > 0)
					{
						this.leftTimer--;
					}
					else
					{
						if (this.controlLeft)
						{
							this.leftTimer = 7;
						}
					}
					if (this.grappling[0] >= 0)
					{
						if (Main.myPlayer == this.whoAmi && this.mount > 0)
						{
							this.Dismount();
						}
						this.canCarpet = true;
						this.carpetFrame = -1;
						this.wingFrame = 1;
						if (this.velocity.Y == 0f || (this.wet && (double)this.velocity.Y > -0.02 && (double)this.velocity.Y < 0.02))
						{
							this.wingFrame = 0;
						}
						if (this.wings == 4)
						{
							this.wingFrame = 3;
						}
						this.wingTime = (float)this.wingTimeMax;
						this.rocketTime = this.rocketTimeMax;
						this.rocketDelay = 0;
						this.rocketFrame = false;
						this.canRocket = false;
						this.rocketRelease = false;
						this.fallStart = (int)(this.position.Y / 16f);
						float num242 = 0f;
						float num243 = 0f;
						for (int num244 = 0; num244 < this.grapCount; num244++)
						{
							num242 += Main.projectile[this.grappling[num244]].position.X + (float)(Main.projectile[this.grappling[num244]].width / 2);
							num243 += Main.projectile[this.grappling[num244]].position.Y + (float)(Main.projectile[this.grappling[num244]].height / 2);
						}
						num242 /= (float)this.grapCount;
						num243 /= (float)this.grapCount;
						Vector2 vector6 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num245 = num242 - vector6.X;
						float num246 = num243 - vector6.Y;
						float num247 = (float)Math.Sqrt((double)(num245 * num245 + num246 * num246));
						float num248 = 11f;
						if (Main.projectile[this.grappling[0]].type == 315)
						{
							num248 = 16f;
						}
						float num249;
						if (num247 > num248)
						{
							num249 = num248 / num247;
						}
						else
						{
							num249 = 1f;
						}
						num245 *= num249;
						num246 *= num249;
						this.velocity.X = num245;
						this.velocity.Y = num246;
						if (this.itemAnimation == 0)
						{
							if (this.velocity.X > 0f)
							{
								this.ChangeDir(1);
							}
							if (this.velocity.X < 0f)
							{
								this.ChangeDir(-1);
							}
						}
						if (this.controlJump)
						{
							if (this.releaseJump)
							{
								if ((this.velocity.Y == 0f || (this.wet && (double)this.velocity.Y > -0.02 && (double)this.velocity.Y < 0.02)) && !this.controlDown)
								{
									this.velocity.Y = -Player.jumpSpeed;
									this.jump = Player.jumpHeight / 2;
									this.releaseJump = false;
								}
								else
								{
									this.velocity.Y = this.velocity.Y + 0.01f;
									this.releaseJump = false;
								}
								if (this.doubleJump)
								{
									this.jumpAgain = true;
								}
								if (this.doubleJump2)
								{
									this.jumpAgain2 = true;
								}
								if (this.doubleJump3)
								{
									this.jumpAgain3 = true;
								}
								if (this.doubleJump4)
								{
									this.jumpAgain4 = true;
								}
								this.grappling[0] = 0;
								this.grapCount = 0;
								for (int num250 = 0; num250 < 1000; num250++)
								{
									if (Main.projectile[num250].active && Main.projectile[num250].owner == i && Main.projectile[num250].aiStyle == 7)
									{
										Main.projectile[num250].Kill();
									}
								}
							}
						}
						else
						{
							this.releaseJump = true;
						}
					}
					int num251 = this.width / 2;
					int num252 = this.height / 2;
					new Vector2(this.position.X + (float)(this.width / 2) - (float)(num251 / 2), this.position.Y + (float)(this.height / 2) - (float)(num252 / 2));
					Vector2 vector7 = Collision.StickyTiles(this.position, this.velocity, this.width, this.height);
					if (vector7.Y != -1f && vector7.X != -1f)
					{
						int num253 = (int)vector7.X;
						int num254 = (int)vector7.Y;
						int type7 = (int)Main.tile[num253, num254].type;
						if (this.whoAmi == Main.myPlayer && type7 == 51 && (this.velocity.X != 0f || this.velocity.Y != 0f))
						{
							this.stickyBreak++;
							if (this.stickyBreak > Main.rand.Next(20, 100))
							{
								this.stickyBreak = 0;
								WorldGen.KillTile(num253, num254, false, false, false);
								if (Main.netMode == 1 && !Main.tile[num253, num254].active() && Main.netMode == 1)
								{
									NetMessage.SendData(17, -1, -1, "", 0, (float)num253, (float)num254, 0f, 0);
								}
							}
						}
						this.fallStart = (int)(this.position.Y / 16f);
						if (type7 != 229)
						{
							this.jump = 0;
						}
						if (this.velocity.X > 1f)
						{
							this.velocity.X = 1f;
						}
						if (this.velocity.X < -1f)
						{
							this.velocity.X = -1f;
						}
						if (this.velocity.Y > 1f)
						{
							this.velocity.Y = 1f;
						}
						if (this.velocity.Y < -5f)
						{
							this.velocity.Y = -5f;
						}
						if ((double)this.velocity.X > 0.75 || (double)this.velocity.X < -0.75)
						{
							this.velocity.X = this.velocity.X * 0.85f;
						}
						else
						{
							this.velocity.X = this.velocity.X * 0.6f;
						}
						if (this.velocity.Y < 0f)
						{
							this.velocity.Y = this.velocity.Y * 0.96f;
						}
						else
						{
							this.velocity.Y = this.velocity.Y * 0.3f;
						}
						if (type7 == 229 && Main.rand.Next(5) == 0 && ((double)this.velocity.Y > 0.15 || this.velocity.Y < 0f))
						{
							if ((float)(num253 * 16) < this.position.X + (float)(this.width / 2))
							{
								int num255 = Dust.NewDust(new Vector2(this.position.X - 4f, (float)(num254 * 16)), 4, 16, 153, 0f, 0f, 50, default(Color), 1f);
								Main.dust[num255].scale += (float)Main.rand.Next(0, 6) * 0.1f;
								Main.dust[num255].velocity *= 0.1f;
								Main.dust[num255].noGravity = true;
							}
							else
							{
								int num256 = Dust.NewDust(new Vector2(this.position.X + (float)this.width - 2f, (float)(num254 * 16)), 4, 16, 153, 0f, 0f, 50, default(Color), 1f);
								Main.dust[num256].scale += (float)Main.rand.Next(0, 6) * 0.1f;
								Main.dust[num256].velocity *= 0.1f;
								Main.dust[num256].noGravity = true;
							}
							if (Main.tile[num253, num254 + 1] != null && Main.tile[num253, num254 + 1].type == 229 && this.position.Y + (float)this.height > (float)((num254 + 1) * 16))
							{
								if ((float)(num253 * 16) < this.position.X + (float)(this.width / 2))
								{
									int num257 = Dust.NewDust(new Vector2(this.position.X - 4f, (float)(num254 * 16 + 16)), 4, 16, 153, 0f, 0f, 50, default(Color), 1f);
									Main.dust[num257].scale += (float)Main.rand.Next(0, 6) * 0.1f;
									Main.dust[num257].velocity *= 0.1f;
									Main.dust[num257].noGravity = true;
								}
								else
								{
									int num258 = Dust.NewDust(new Vector2(this.position.X + (float)this.width - 2f, (float)(num254 * 16 + 16)), 4, 16, 153, 0f, 0f, 50, default(Color), 1f);
									Main.dust[num258].scale += (float)Main.rand.Next(0, 6) * 0.1f;
									Main.dust[num258].velocity *= 0.1f;
									Main.dust[num258].noGravity = true;
								}
							}
							if (Main.tile[num253, num254 + 2] != null && Main.tile[num253, num254 + 2].type == 229 && this.position.Y + (float)this.height > (float)((num254 + 2) * 16))
							{
								if ((float)(num253 * 16) < this.position.X + (float)(this.width / 2))
								{
									int num259 = Dust.NewDust(new Vector2(this.position.X - 4f, (float)(num254 * 16 + 32)), 4, 16, 153, 0f, 0f, 50, default(Color), 1f);
									Main.dust[num259].scale += (float)Main.rand.Next(0, 6) * 0.1f;
									Main.dust[num259].velocity *= 0.1f;
									Main.dust[num259].noGravity = true;
								}
								else
								{
									int num260 = Dust.NewDust(new Vector2(this.position.X + (float)this.width - 2f, (float)(num254 * 16 + 32)), 4, 16, 153, 0f, 0f, 50, default(Color), 1f);
									Main.dust[num260].scale += (float)Main.rand.Next(0, 6) * 0.1f;
									Main.dust[num260].velocity *= 0.1f;
									Main.dust[num260].noGravity = true;
								}
							}
						}
					}
					else
					{
						this.stickyBreak = 0;
					}
					bool flag28 = Collision.DrownCollision(this.position, this.width, this.height, this.gravDir);
					if (this.armor[0].type == 250)
					{
						flag28 = true;
					}
					if (this.inventory[this.selectedItem].type == 186)
					{
						try
						{
							int num261 = (int)((this.position.X + (float)(this.width / 2) + (float)(6 * this.direction)) / 16f);
							int num262 = 0;
							if (this.gravDir == -1f)
							{
								num262 = this.height;
							}
							int num263 = (int)((this.position.Y + (float)num262 - 44f * this.gravDir) / 16f);
							if (Main.tile[num261, num263].liquid < 128)
							{
								if (Main.tile[num261, num263] == null)
								{
									Main.tile[num261, num263] = new Tile();
								}
								if (!Main.tile[num261, num263].active() || !Main.tileSolid[(int)Main.tile[num261, num263].type] || Main.tileSolidTop[(int)Main.tile[num261, num263].type])
								{
									flag28 = false;
								}
							}
						}
						catch
						{
						}
					}
					if (this.gills)
					{
						flag28 = false;
					}
					if (Main.myPlayer == i)
					{
						if (this.merman)
						{
							flag28 = false;
						}
						if (flag28)
						{
							this.breathCD++;
							int num264 = 7;
							if (this.inventory[this.selectedItem].type == 186)
							{
								num264 *= 2;
							}
							if (this.accDivingHelm)
							{
								num264 *= 4;
							}
							if (this.breathCD >= num264)
							{
								this.breathCD = 0;
								this.breath--;
								if (this.breath == 0)
								{
									Main.PlaySound(23, -1, -1, 1);
								}
								if (this.breath <= 0)
								{
									this.lifeRegenTime = 0;
									this.breath = 0;
									this.statLife -= 2;
									if (this.statLife <= 0)
									{
										this.statLife = 0;
										this.KillMe(10.0, 0, false, Lang.deathMsg(-1, -1, -1, 1));
									}
								}
							}
						}
						else
						{
							this.breath += 3;
							if (this.breath > this.breathMax)
							{
								this.breath = this.breathMax;
							}
							this.breathCD = 0;
						}
					}
					if (flag28 && Main.rand.Next(20) == 0 && !this.lavaWet && !this.honeyWet)
					{
						int num265 = 0;
						if (this.gravDir == -1f)
						{
							num265 += this.height - 12;
						}
						if (this.inventory[this.selectedItem].type == 186)
						{
							Dust.NewDust(new Vector2(this.position.X + (float)(10 * this.direction) + 4f, this.position.Y + (float)num265 - 54f * this.gravDir), this.width - 8, 8, 34, 0f, 0f, 0, default(Color), 1.2f);
						}
						else
						{
							Dust.NewDust(new Vector2(this.position.X + (float)(12 * this.direction), this.position.Y + (float)num265 + 4f * this.gravDir), this.width - 8, 8, 34, 0f, 0f, 0, default(Color), 1.2f);
						}
					}
					if (this.gravDir == -1f)
					{
						this.waterWalk = false;
						this.waterWalk2 = false;
					}
					int num266 = this.height;
					if (this.waterWalk)
					{
						num266 -= 6;
					}
					bool flag29 = Collision.LavaCollision(this.position, this.width, num266);
					if (flag29)
					{
						if (!this.lavaImmune && Main.myPlayer == i && !this.immune)
						{
							if (this.lavaTime > 0)
							{
								this.lavaTime--;
							}
							else
							{
								if (this.lavaRose)
								{
									this.Hurt(50, 0, false, false, Lang.deathMsg(-1, -1, -1, 2), false);
									this.AddBuff(24, 210, true);
								}
								else
								{
									this.Hurt(80, 0, false, false, Lang.deathMsg(-1, -1, -1, 2), false);
									this.AddBuff(24, 420, true);
								}
							}
						}
						this.lavaWet = true;
					}
					else
					{
						this.lavaWet = false;
						if (this.lavaTime < this.lavaMax)
						{
							this.lavaTime++;
						}
					}
					if (this.lavaTime > this.lavaMax)
					{
						this.lavaTime = this.lavaMax;
					}
					if (this.waterWalk2 && !this.waterWalk)
					{
						num266 -= 6;
					}
					bool flag30 = Collision.WetCollision(this.position, this.width, this.height);
					bool flag31 = Collision.honey;
					if (flag31)
					{
						this.AddBuff(48, 1800, true);
						this.honeyWet = true;
					}
					if (flag30)
					{
						if (this.onFire && !this.lavaWet)
						{
							for (int num267 = 0; num267 < 22; num267++)
							{
								if (this.buffType[num267] == 24)
								{
									this.DelBuff(num267);
								}
							}
						}
						if (!this.wet)
						{
							if (this.wetCount == 0)
							{
								this.wetCount = 10;
								if (!flag29)
								{
									if (this.honeyWet)
									{
										for (int num268 = 0; num268 < 20; num268++)
										{
											int num269 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f), this.width + 12, 24, 152, 0f, 0f, 0, default(Color), 1f);
											Dust expr_F46B_cp_0 = Main.dust[num269];
											expr_F46B_cp_0.velocity.Y = expr_F46B_cp_0.velocity.Y - 1f;
											Dust expr_F48B_cp_0 = Main.dust[num269];
											expr_F48B_cp_0.velocity.X = expr_F48B_cp_0.velocity.X * 2.5f;
											Main.dust[num269].scale = 1.3f;
											Main.dust[num269].alpha = 100;
											Main.dust[num269].noGravity = true;
										}
										Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
									}
									else
									{
										for (int num270 = 0; num270 < 50; num270++)
										{
											int num271 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f), this.width + 12, 24, Dust.dustWater(), 0f, 0f, 0, default(Color), 1f);
											Dust expr_F58C_cp_0 = Main.dust[num271];
											expr_F58C_cp_0.velocity.Y = expr_F58C_cp_0.velocity.Y - 3f;
											Dust expr_F5AC_cp_0 = Main.dust[num271];
											expr_F5AC_cp_0.velocity.X = expr_F5AC_cp_0.velocity.X * 2.5f;
											Main.dust[num271].scale = 0.8f;
											Main.dust[num271].alpha = 100;
											Main.dust[num271].noGravity = true;
										}
										Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 0);
									}
								}
								else
								{
									for (int num272 = 0; num272 < 20; num272++)
									{
										int num273 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f), this.width + 12, 24, 35, 0f, 0f, 0, default(Color), 1f);
										Dust expr_F6AA_cp_0 = Main.dust[num273];
										expr_F6AA_cp_0.velocity.Y = expr_F6AA_cp_0.velocity.Y - 1.5f;
										Dust expr_F6CA_cp_0 = Main.dust[num273];
										expr_F6CA_cp_0.velocity.X = expr_F6CA_cp_0.velocity.X * 2.5f;
										Main.dust[num273].scale = 1.3f;
										Main.dust[num273].alpha = 100;
										Main.dust[num273].noGravity = true;
									}
									Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
								}
							}
							this.wet = true;
						}
					}
					else
					{
						if (this.wet)
						{
							this.wet = false;
							if (this.jump > Player.jumpHeight / 5)
							{
								this.jump = Player.jumpHeight / 5;
							}
							if (this.wetCount == 0)
							{
								this.wetCount = 10;
								if (!this.lavaWet)
								{
									if (this.honeyWet)
									{
										for (int num274 = 0; num274 < 20; num274++)
										{
											int num275 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f), this.width + 12, 24, 152, 0f, 0f, 0, default(Color), 1f);
											Dust expr_F829_cp_0 = Main.dust[num275];
											expr_F829_cp_0.velocity.Y = expr_F829_cp_0.velocity.Y - 1f;
											Dust expr_F849_cp_0 = Main.dust[num275];
											expr_F849_cp_0.velocity.X = expr_F849_cp_0.velocity.X * 2.5f;
											Main.dust[num275].scale = 1.3f;
											Main.dust[num275].alpha = 100;
											Main.dust[num275].noGravity = true;
										}
										Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
									}
									else
									{
										for (int num276 = 0; num276 < 50; num276++)
										{
											int num277 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2)), this.width + 12, 24, Dust.dustWater(), 0f, 0f, 0, default(Color), 1f);
											Dust expr_F944_cp_0 = Main.dust[num277];
											expr_F944_cp_0.velocity.Y = expr_F944_cp_0.velocity.Y - 4f;
											Dust expr_F964_cp_0 = Main.dust[num277];
											expr_F964_cp_0.velocity.X = expr_F964_cp_0.velocity.X * 2.5f;
											Main.dust[num277].scale = 0.8f;
											Main.dust[num277].alpha = 100;
											Main.dust[num277].noGravity = true;
										}
										Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 0);
									}
								}
								else
								{
									for (int num278 = 0; num278 < 20; num278++)
									{
										int num279 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f), this.width + 12, 24, 35, 0f, 0f, 0, default(Color), 1f);
										Dust expr_FA62_cp_0 = Main.dust[num279];
										expr_FA62_cp_0.velocity.Y = expr_FA62_cp_0.velocity.Y - 1.5f;
										Dust expr_FA82_cp_0 = Main.dust[num279];
										expr_FA82_cp_0.velocity.X = expr_FA82_cp_0.velocity.X * 2.5f;
										Main.dust[num279].scale = 1.3f;
										Main.dust[num279].alpha = 100;
										Main.dust[num279].noGravity = true;
									}
									Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
								}
							}
						}
					}
					if (!flag31)
					{
						this.honeyWet = false;
					}
					if (!this.wet)
					{
						this.lavaWet = false;
						this.honeyWet = false;
					}
					if (this.wetCount > 0)
					{
						this.wetCount -= 1;
					}
					float num280 = 1f + Math.Abs(this.velocity.X) / 3f;
					if (this.gfxOffY > 0f)
					{
						this.gfxOffY -= num280 * this.stepSpeed;
						if (this.gfxOffY < 0f)
						{
							this.gfxOffY = 0f;
						}
					}
					else
					{
						if (this.gfxOffY < 0f)
						{
							this.gfxOffY += num280 * this.stepSpeed;
							if (this.gfxOffY > 0f)
							{
								this.gfxOffY = 0f;
							}
						}
					}
					if (this.gfxOffY > 32f)
					{
						this.gfxOffY = 32f;
					}
					if (this.gfxOffY < -32f)
					{
						this.gfxOffY = -32f;
					}
					if (Main.myPlayer == i && !this.iceSkate && this.velocity.Y > 7f)
					{
						Vector2 vector8 = this.position + this.velocity;
						int num281 = (int)(vector8.X / 16f);
						int num282 = (int)((vector8.X + (float)this.width) / 16f);
						int num283 = (int)((this.position.Y + (float)this.height + 1f) / 16f);
						for (int num284 = num281; num284 <= num282; num284++)
						{
							for (int num285 = num283; num285 <= num283 + 1; num285++)
							{
								if (Main.tile[num284, num285].nactive() && Main.tile[num284, num285].type == 162)
								{
									WorldGen.KillTile(num284, num285, false, false, false);
									if (Main.netMode == 1)
									{
										NetMessage.SendData(17, -1, -1, "", 0, (float)num284, (float)num285, 0f, 0);
									}
								}
							}
						}
					}
					this.sloping = false;
					float y3 = this.velocity.Y;
					Vector4 vector9 = Collision.WalkDownSlope(this.position, this.velocity, this.width, this.height, num2 * this.gravDir);
					this.position.X = vector9.X;
					this.position.Y = vector9.Y;
					this.velocity.X = vector9.Z;
					this.velocity.Y = vector9.W;
					if (this.velocity.Y != y3)
					{
						this.sloping = true;
					}
					if (this.velocity.Y == num2)
					{
						Vector2 vector10 = this.position;
						vector10.X += this.velocity.X;
						bool flag32 = false;
						int num286 = (int)(vector10.X / 16f);
						int num287 = (int)((vector10.X + (float)this.width) / 16f);
						int num288 = (int)((this.position.Y + (float)this.height + 4f) / 16f);
						int num289 = this.height / 16 + ((this.height % 16 == 0) ? 0 : 1);
						float num290 = (float)((num288 + num289) * 16);
						float num291 = Main.bottomWorld / 16f - 42f;
						for (int num292 = num286; num292 <= num287; num292++)
						{
							for (int num293 = num288; num293 <= num288 + 1; num293++)
							{
								if (Main.tile[num292, num293] == null)
								{
									Main.tile[num292, num293] = new Tile();
								}
								if (Main.tile[num292, num293 - 1] == null)
								{
									Main.tile[num292, num293 - 1] = new Tile();
								}
								if (Main.tile[num292, num293].topSlope())
								{
									flag32 = true;
								}
								if ((this.waterWalk2 || this.waterWalk) && Main.tile[num292, num293].liquid > 0 && Main.tile[num292, num293 - 1].liquid == 0)
								{
									int num294 = (int)(Main.tile[num292, num293].liquid / 32 * 2 + 2);
									int num295 = num293 * 16 + 16 - num294;
									Rectangle rectangle4 = new Rectangle(num292 * 16, num293 * 16 - 17, 16, 16);
									if (rectangle4.Intersects(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height)) && (float)num295 < num290)
									{
										num290 = (float)num295;
									}
								}
								if ((float)num293 >= num291 || (Main.tile[num292, num293].nactive() && (Main.tileSolid[(int)Main.tile[num292, num293].type] || Main.tileSolidTop[(int)Main.tile[num292, num293].type])))
								{
									int num296 = num293 * 16;
									if (Main.tile[num292, num293].halfBrick())
									{
										num296 += 8;
									}
									if (Utils.FloatIntersect((float)(num292 * 16), (float)(num293 * 16 - 17), 16f, 16f, this.position.X, this.position.Y, (float)this.width, (float)this.height) && (float)num296 < num290)
									{
										num290 = (float)num296;
									}
								}
							}
						}
						float num297 = num290 - (this.position.Y + (float)this.height);
						if (num297 > 7f && num297 < 17f && !flag32)
						{
							this.stepSpeed = 1.5f;
							if (num297 > 9f)
							{
								this.stepSpeed = 2.5f;
							}
							this.gfxOffY += this.position.Y + (float)this.height - num290;
							this.position.Y = num290 - (float)this.height;
						}
					}
					if (this.gravDir == -1f)
					{
						if ((this.carpetFrame != -1 || this.velocity.Y <= num2) && !this.controlUp)
						{
							Collision.StepUp(ref this.position, ref this.velocity, this.width, this.height, ref this.stepSpeed, ref this.gfxOffY, (int)this.gravDir, this.controlUp);
						}
					}
					else
					{
						if ((this.carpetFrame != -1 || this.velocity.Y >= num2) && !this.controlDown)
						{
							Collision.StepUp(ref this.position, ref this.velocity, this.width, this.height, ref this.stepSpeed, ref this.gfxOffY, (int)this.gravDir, this.controlUp);
						}
					}
					this.oldPosition = this.position;
					bool flag33 = false;
					if (this.velocity.Y > num2)
					{
						flag33 = true;
					}
					Vector2 vector11 = this.velocity;
					this.slideDir = 0;
					bool fall = false;
					bool fallThrough = this.controlDown;
					if (this.gravDir == -1f)
					{
						fall = true;
						fallThrough = true;
					}
					if (this.wingsLogic == 3 && this.controlUp && this.controlDown)
					{
						this.position += this.velocity;
					}
					else
					{
						if (this.tongued)
						{
							this.position += this.velocity;
						}
						else
						{
							if (this.honeyWet)
							{
								Vector2 vector12 = this.velocity;
								this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, fallThrough, fall, (int)this.gravDir);
								Vector2 value3 = this.velocity * 0.25f;
								if (this.velocity.X != vector12.X)
								{
									value3.X = this.velocity.X;
								}
								if (this.velocity.Y != vector12.Y)
								{
									value3.Y = this.velocity.Y;
								}
								this.position += value3;
							}
							else
							{
								if (this.wet && !this.merman)
								{
									Vector2 vector13 = this.velocity;
									this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, fallThrough, fall, (int)this.gravDir);
									Vector2 value4 = this.velocity * 0.5f;
									if (this.velocity.X != vector13.X)
									{
										value4.X = this.velocity.X;
									}
									if (this.velocity.Y != vector13.Y)
									{
										value4.Y = this.velocity.Y;
									}
									this.position += value4;
								}
								else
								{
									this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, fallThrough, fall, (int)this.gravDir);
									if (Collision.up && this.gravDir == 1f)
									{
										this.jump = 0;
									}
									if (this.waterWalk || this.waterWalk2)
									{
										Vector2 value5 = this.velocity;
										this.velocity = Collision.WaterCollision(this.position, this.velocity, this.width, this.height, this.controlDown, false, this.waterWalk);
										if (value5 != this.velocity)
										{
											this.fallStart = (int)(this.position.Y / 16f);
										}
									}
									this.position += this.velocity;
								}
							}
						}
					}
					if (this.wingsLogic != 3 || !this.controlUp || !this.controlDown)
					{
						if (this.controlDown || this.grappling[0] >= 0 || this.gravDir == -1f)
						{
							this.stairFall = true;
						}
						Vector4 vector14 = Collision.SlopeCollision(this.position, this.velocity, this.width, this.height, num2, this.stairFall);
						if (Collision.stairFall)
						{
							this.stairFall = true;
						}
						else
						{
							if (!this.controlDown)
							{
								this.stairFall = false;
							}
						}
						if (Collision.stair && Math.Abs(vector14.Y - this.position.Y) > 8f + Math.Abs(this.velocity.X))
						{
							this.gfxOffY -= vector14.Y - this.position.Y;
							this.stepSpeed = 4f;
						}
						this.position.X = vector14.X;
						this.position.Y = vector14.Y;
						this.velocity.X = vector14.Z;
						this.velocity.Y = vector14.W;
						if (this.gravDir == -1f && this.velocity.Y == 0.0101f)
						{
							this.velocity.Y = 0f;
						}
					}
					if (vector11.X != this.velocity.X)
					{
						if (vector11.X < 0f)
						{
							this.slideDir = -1;
						}
						else
						{
							if (vector11.X > 0f)
							{
								this.slideDir = 1;
							}
						}
					}
					if (this.gravDir == 1f && Collision.up)
					{
						this.velocity.Y = 0.01f;
						if (!this.merman)
						{
							this.jump = 0;
						}
					}
					else
					{
						if (this.gravDir == -1f && Collision.down)
						{
							this.velocity.Y = -0.01f;
							if (!this.merman)
							{
								this.jump = 0;
							}
						}
					}
					if (this.velocity.Y == 0f && this.grappling[0] == -1)
					{
						int num298 = (int)((this.position.X + (float)(this.width / 2)) / 16f);
						int num299 = (int)((this.position.Y + (float)this.height) / 16f);
						int num300 = -1;
						if (Main.tile[num298 - 1, num299] == null)
						{
							Main.tile[num298 - 1, num299] = new Tile();
						}
						if (Main.tile[num298 + 1, num299] == null)
						{
							Main.tile[num298 + 1, num299] = new Tile();
						}
						if (Main.tile[num298, num299] == null)
						{
							Main.tile[num298, num299] = new Tile();
						}
						if (Main.tile[num298, num299].nactive() && Main.tileSolid[(int)Main.tile[num298, num299].type])
						{
							num300 = (int)Main.tile[num298, num299].type;
						}
						else
						{
							if (Main.tile[num298 - 1, num299].nactive() && Main.tileSolid[(int)Main.tile[num298 - 1, num299].type])
							{
								num300 = (int)Main.tile[num298 - 1, num299].type;
							}
							else
							{
								if (Main.tile[num298 + 1, num299].nactive() && Main.tileSolid[(int)Main.tile[num298 + 1, num299].type])
								{
									num300 = (int)Main.tile[num298 + 1, num299].type;
								}
							}
						}
						if (num300 > -1)
						{
							if (num300 == 229)
							{
								this.sticky = true;
							}
							else
							{
								this.sticky = false;
							}
							if (num300 == 161 || num300 == 162 || num300 == 163 || num300 == 164 || num300 == 200)
							{
								this.slippy = true;
							}
							else
							{
								this.slippy = false;
							}
							if (num300 == 197)
							{
								this.slippy2 = true;
							}
							else
							{
								this.slippy2 = false;
							}
							if (num300 == 198)
							{
								this.powerrun = true;
							}
							else
							{
								this.powerrun = false;
							}
							if (Main.tile[num298 - 1, num299].slope() != 0 || Main.tile[num298, num299].slope() != 0 || Main.tile[num298 + 1, num299].slope() != 0)
							{
								num300 = -1;
							}
							if (!this.wet && (num300 == 147 || num300 == 25 || num300 == 53 || num300 == 189 || num300 == 0 || num300 == 123 || num300 == 57 || num300 == 112 || num300 == 116 || num300 == 196 || num300 == 193 || num300 == 195 || num300 == 197 || num300 == 199 || num300 == 229))
							{
								int num301 = 1;
								if (flag33)
								{
									num301 = 20;
								}
								for (int num302 = 0; num302 < num301; num302++)
								{
									bool flag34 = true;
									int num303 = 76;
									if (num300 == 53)
									{
										num303 = 32;
									}
									if (num300 == 189)
									{
										num303 = 16;
									}
									if (num300 == 0)
									{
										num303 = 0;
									}
									if (num300 == 123)
									{
										num303 = 53;
									}
									if (num300 == 57)
									{
										num303 = 36;
									}
									if (num300 == 112)
									{
										num303 = 14;
									}
									if (num300 == 116)
									{
										num303 = 51;
									}
									if (num300 == 196)
									{
										num303 = 108;
									}
									if (num300 == 193)
									{
										num303 = 4;
									}
									if (num300 == 195 || num300 == 199)
									{
										num303 = 5;
									}
									if (num300 == 197)
									{
										num303 = 4;
									}
									if (num300 == 229)
									{
										num303 = 153;
									}
									if (num300 == 25)
									{
										num303 = 37;
									}
									if (num303 == 32 && Main.rand.Next(2) == 0)
									{
										flag34 = false;
									}
									if (num303 == 14 && Main.rand.Next(2) == 0)
									{
										flag34 = false;
									}
									if (num303 == 51 && Main.rand.Next(2) == 0)
									{
										flag34 = false;
									}
									if (num303 == 36 && Main.rand.Next(2) == 0)
									{
										flag34 = false;
									}
									if (num303 == 0 && Main.rand.Next(3) != 0)
									{
										flag34 = false;
									}
									if (num303 == 53 && Main.rand.Next(3) != 0)
									{
										flag34 = false;
									}
									Color newColor = default(Color);
									if (num300 == 193)
									{
										newColor = new Color(30, 100, 255, 100);
									}
									if (num300 == 197)
									{
										newColor = new Color(97, 200, 255, 100);
									}
									if (!flag33)
									{
										float num304 = Math.Abs(this.velocity.X) / 3f;
										if ((float)Main.rand.Next(100) > num304 * 100f)
										{
											flag34 = false;
										}
									}
									if (flag34)
									{
										float num305 = this.velocity.X;
										if (num305 > 6f)
										{
											num305 = 6f;
										}
										if (num305 < -6f)
										{
											num305 = -6f;
										}
										if (this.velocity.X != 0f || flag33)
										{
											int num306 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)this.height - 2f), this.width, 6, num303, 0f, 0f, 50, newColor, 1f);
											if (num303 == 76)
											{
												Main.dust[num306].scale += (float)Main.rand.Next(3) * 0.1f;
												Main.dust[num306].noLight = true;
											}
											if (num303 == 16 || num303 == 108 || num303 == 153)
											{
												Main.dust[num306].scale += (float)Main.rand.Next(6) * 0.1f;
											}
											if (num303 == 37)
											{
												Main.dust[num306].scale += 0.25f;
												Main.dust[num306].alpha = 50;
											}
											if (num303 == 5)
											{
												Main.dust[num306].scale += (float)Main.rand.Next(2, 8) * 0.1f;
											}
											Main.dust[num306].noGravity = true;
											if (num301 > 1)
											{
												Dust expr_10F62_cp_0 = Main.dust[num306];
												expr_10F62_cp_0.velocity.X = expr_10F62_cp_0.velocity.X * 1.2f;
												Dust expr_10F82_cp_0 = Main.dust[num306];
												expr_10F82_cp_0.velocity.Y = expr_10F82_cp_0.velocity.Y * 0.8f;
												Dust expr_10FA2_cp_0 = Main.dust[num306];
												expr_10FA2_cp_0.velocity.Y = expr_10FA2_cp_0.velocity.Y - 1f;
												Main.dust[num306].velocity *= 0.8f;
												Main.dust[num306].scale += (float)Main.rand.Next(3) * 0.1f;
												Main.dust[num306].velocity.X = (Main.dust[num306].position.X - (this.position.X + (float)(this.width / 2))) * 0.2f;
												if (Main.dust[num306].velocity.Y > 0f)
												{
													Dust expr_11068_cp_0 = Main.dust[num306];
													expr_11068_cp_0.velocity.Y = expr_11068_cp_0.velocity.Y * -1f;
												}
												Dust expr_11088_cp_0 = Main.dust[num306];
												expr_11088_cp_0.velocity.X = expr_11088_cp_0.velocity.X + num305 * 0.3f;
											}
											else
											{
												Main.dust[num306].velocity *= 0.2f;
											}
											Dust expr_110CE_cp_0 = Main.dust[num306];
											expr_110CE_cp_0.position.X = expr_110CE_cp_0.position.X - num305 * 1f;
										}
									}
								}
							}
						}
					}
					if (this.whoAmi == Main.myPlayer)
					{
						Collision.SwitchTiles(this.position, this.width, this.height, this.oldPosition, 1);
					}
					if (this.position.X < Main.leftWorld + 640f + 16f)
					{
						this.position.X = Main.leftWorld + 640f + 16f;
						this.velocity.X = 0f;
					}
					if (this.position.X + (float)this.width > Main.rightWorld - 640f - 32f)
					{
						this.position.X = Main.rightWorld - 640f - 32f - (float)this.width;
						this.velocity.X = 0f;
					}
					if (this.position.Y < Main.topWorld + 640f + 16f)
					{
						this.position.Y = Main.topWorld + 640f + 16f;
						if ((double)this.velocity.Y < 0.11)
						{
							this.velocity.Y = 0.11f;
						}
						this.gravDir = 1f;
					}
					if (this.position.Y > Main.bottomWorld - 640f - 32f - (float)this.height)
					{
						this.position.Y = Main.bottomWorld - 640f - 32f - (float)this.height;
						this.velocity.Y = 0f;
					}
					this.numMinions = 0;
					if (Main.ignoreErrors)
					{
						try
						{
							this.ItemCheck(i);
							goto IL_112B2;
						}
						catch
						{
							goto IL_112B2;
						}
					}
					this.ItemCheck(i);
					IL_112B2:
					this.PlayerFrame();
					if (this.statLife > this.statLifeMax)
					{
						this.statLife = this.statLifeMax;
					}
					this.grappling[0] = -1;
					this.grapCount = 0;
				}
			}
		}
		public bool SellItem(int price, int stack)
		{
			if (price <= 0)
			{
				return false;
			}
			Item[] array = new Item[58];
			for (int i = 0; i < 58; i++)
			{
				array[i] = new Item();
				array[i] = this.inventory[i].Clone();
			}
			int j = price / 5;
			j *= stack;
			if (j < 1)
			{
				j = 1;
			}
			bool flag = false;
			while (j >= 1000000)
			{
				if (flag)
				{
					break;
				}
				int num = -1;
				for (int k = 53; k >= 0; k--)
				{
					if (num == -1 && (this.inventory[k].type == 0 || this.inventory[k].stack == 0))
					{
						num = k;
					}
					while (this.inventory[k].type == 74 && this.inventory[k].stack < this.inventory[k].maxStack && j >= 1000000)
					{
						this.inventory[k].stack++;
						j -= 1000000;
						this.DoCoins(k);
						if (this.inventory[k].stack == 0 && num == -1)
						{
							num = k;
						}
					}
				}
				if (j >= 1000000)
				{
					if (num == -1)
					{
						flag = true;
					}
					else
					{
						this.inventory[num].SetDefaults(74, false);
						j -= 1000000;
					}
				}
			}
			while (j >= 10000)
			{
				if (flag)
				{
					break;
				}
				int num2 = -1;
				for (int l = 53; l >= 0; l--)
				{
					if (num2 == -1 && (this.inventory[l].type == 0 || this.inventory[l].stack == 0))
					{
						num2 = l;
					}
					while (this.inventory[l].type == 73 && this.inventory[l].stack < this.inventory[l].maxStack && j >= 10000)
					{
						this.inventory[l].stack++;
						j -= 10000;
						this.DoCoins(l);
						if (this.inventory[l].stack == 0 && num2 == -1)
						{
							num2 = l;
						}
					}
				}
				if (j >= 10000)
				{
					if (num2 == -1)
					{
						flag = true;
					}
					else
					{
						this.inventory[num2].SetDefaults(73, false);
						j -= 10000;
					}
				}
			}
			while (j >= 100)
			{
				if (flag)
				{
					break;
				}
				int num3 = -1;
				for (int m = 53; m >= 0; m--)
				{
					if (num3 == -1 && (this.inventory[m].type == 0 || this.inventory[m].stack == 0))
					{
						num3 = m;
					}
					while (this.inventory[m].type == 72 && this.inventory[m].stack < this.inventory[m].maxStack && j >= 100)
					{
						this.inventory[m].stack++;
						j -= 100;
						this.DoCoins(m);
						if (this.inventory[m].stack == 0 && num3 == -1)
						{
							num3 = m;
						}
					}
				}
				if (j >= 100)
				{
					if (num3 == -1)
					{
						flag = true;
					}
					else
					{
						this.inventory[num3].SetDefaults(72, false);
						j -= 100;
					}
				}
			}
			while (j >= 1 && !flag)
			{
				int num4 = -1;
				for (int n = 53; n >= 0; n--)
				{
					if (num4 == -1 && (this.inventory[n].type == 0 || this.inventory[n].stack == 0))
					{
						num4 = n;
					}
					while (this.inventory[n].type == 71 && this.inventory[n].stack < this.inventory[n].maxStack && j >= 1)
					{
						this.inventory[n].stack++;
						j--;
						this.DoCoins(n);
						if (this.inventory[n].stack == 0 && num4 == -1)
						{
							num4 = n;
						}
					}
				}
				if (j >= 1)
				{
					if (num4 == -1)
					{
						flag = true;
					}
					else
					{
						this.inventory[num4].SetDefaults(71, false);
						j--;
					}
				}
			}
			if (flag)
			{
				for (int num5 = 0; num5 < 58; num5++)
				{
					this.inventory[num5] = array[num5].Clone();
				}
				return false;
			}
			return true;
		}
		public bool BuyItem(int price)
		{
			if (price == 0)
			{
				return true;
			}
			long num = 0L;
			Item[] array = new Item[54];
			for (int i = 0; i < 54; i++)
			{
				array[i] = new Item();
				array[i] = this.inventory[i].Clone();
				if (this.inventory[i].type == 71)
				{
					num += (long)this.inventory[i].stack;
				}
				if (this.inventory[i].type == 72)
				{
					num += (long)(this.inventory[i].stack * 100);
				}
				if (this.inventory[i].type == 73)
				{
					num += (long)(this.inventory[i].stack * 10000);
				}
				if (this.inventory[i].type == 74)
				{
					num += (long)(this.inventory[i].stack * 1000000);
				}
			}
			if (num >= (long)price)
			{
				int j = price;
				while (j > 0)
				{
					if (j >= 1000000)
					{
						for (int k = 0; k < 54; k++)
						{
							if (this.inventory[k].type == 74)
							{
								while (this.inventory[k].stack > 0 && j >= 1000000)
								{
									j -= 1000000;
									this.inventory[k].stack--;
									if (this.inventory[k].stack == 0)
									{
										this.inventory[k].type = 0;
									}
								}
							}
						}
					}
					if (j >= 10000)
					{
						for (int l = 0; l < 54; l++)
						{
							if (this.inventory[l].type == 73)
							{
								while (this.inventory[l].stack > 0 && j >= 10000)
								{
									j -= 10000;
									this.inventory[l].stack--;
									if (this.inventory[l].stack == 0)
									{
										this.inventory[l].type = 0;
									}
								}
							}
						}
					}
					if (j >= 100)
					{
						for (int m = 0; m < 54; m++)
						{
							if (this.inventory[m].type == 72)
							{
								while (this.inventory[m].stack > 0 && j >= 100)
								{
									j -= 100;
									this.inventory[m].stack--;
									if (this.inventory[m].stack == 0)
									{
										this.inventory[m].type = 0;
									}
								}
							}
						}
					}
					if (j >= 1)
					{
						for (int n = 0; n < 54; n++)
						{
							if (this.inventory[n].type == 71)
							{
								while (this.inventory[n].stack > 0 && j >= 1)
								{
									j--;
									this.inventory[n].stack--;
									if (this.inventory[n].stack == 0)
									{
										this.inventory[n].type = 0;
									}
								}
							}
						}
					}
					if (j > 0)
					{
						int num2 = -1;
						for (int num3 = 53; num3 >= 0; num3--)
						{
							if (this.inventory[num3].type == 0 || this.inventory[num3].stack == 0)
							{
								num2 = num3;
								break;
							}
						}
						if (num2 < 0)
						{
							for (int num4 = 0; num4 < 54; num4++)
							{
								this.inventory[num4] = array[num4].Clone();
							}
							return false;
						}
						bool flag = true;
						if (j >= 10000)
						{
							for (int num5 = 0; num5 < 58; num5++)
							{
								if (this.inventory[num5].type == 74 && this.inventory[num5].stack >= 1)
								{
									this.inventory[num5].stack--;
									if (this.inventory[num5].stack == 0)
									{
										this.inventory[num5].type = 0;
									}
									this.inventory[num2].SetDefaults(73, false);
									this.inventory[num2].stack = 100;
									flag = false;
									break;
								}
							}
						}
						else
						{
							if (j >= 100)
							{
								for (int num6 = 0; num6 < 54; num6++)
								{
									if (this.inventory[num6].type == 73 && this.inventory[num6].stack >= 1)
									{
										this.inventory[num6].stack--;
										if (this.inventory[num6].stack == 0)
										{
											this.inventory[num6].type = 0;
										}
										this.inventory[num2].SetDefaults(72, false);
										this.inventory[num2].stack = 100;
										flag = false;
										break;
									}
								}
							}
							else
							{
								if (j >= 1)
								{
									for (int num7 = 0; num7 < 54; num7++)
									{
										if (this.inventory[num7].type == 72 && this.inventory[num7].stack >= 1)
										{
											this.inventory[num7].stack--;
											if (this.inventory[num7].stack == 0)
											{
												this.inventory[num7].type = 0;
											}
											this.inventory[num2].SetDefaults(71, false);
											this.inventory[num2].stack = 100;
											flag = false;
											break;
										}
									}
								}
							}
						}
						if (flag)
						{
							if (j < 10000)
							{
								for (int num8 = 0; num8 < 54; num8++)
								{
									if (this.inventory[num8].type == 73 && this.inventory[num8].stack >= 1)
									{
										this.inventory[num8].stack--;
										if (this.inventory[num8].stack == 0)
										{
											this.inventory[num8].type = 0;
										}
										this.inventory[num2].SetDefaults(72, false);
										this.inventory[num2].stack = 100;
										flag = false;
										break;
									}
								}
							}
							if (flag && j < 1000000)
							{
								for (int num9 = 0; num9 < 54; num9++)
								{
									if (this.inventory[num9].type == 74 && this.inventory[num9].stack >= 1)
									{
										this.inventory[num9].stack--;
										if (this.inventory[num9].stack == 0)
										{
											this.inventory[num9].type = 0;
										}
										this.inventory[num2].SetDefaults(73, false);
										this.inventory[num2].stack = 100;
										break;
									}
								}
							}
						}
					}
				}
				return true;
			}
			return false;
		}
		public void AdjTiles()
		{
			int num = 4;
			int num2 = 3;
			for (int i = 0; i < 314; i++)
			{
				this.oldAdjTile[i] = this.adjTile[i];
				this.adjTile[i] = false;
			}
			this.oldAdjWater = this.adjWater;
			this.adjWater = false;
			this.oldAdjHoney = this.adjHoney;
			this.adjHoney = false;
			this.oldAdjLava = this.adjLava;
			this.adjLava = false;
			int num3 = (int)((this.position.X + (float)(this.width / 2)) / 16f);
			int num4 = (int)((this.position.Y + (float)this.height) / 16f);
			for (int j = num3 - num; j <= num3 + num; j++)
			{
				for (int k = num4 - num2; k < num4 + num2; k++)
				{
					if (Main.tile[j, k].active())
					{
						this.adjTile[(int)Main.tile[j, k].type] = true;
						if (Main.tile[j, k].type == 302)
						{
							this.adjTile[17] = true;
						}
						if (Main.tile[j, k].type == 77)
						{
							this.adjTile[17] = true;
						}
						if (Main.tile[j, k].type == 133)
						{
							this.adjTile[17] = true;
							this.adjTile[77] = true;
						}
						if (Main.tile[j, k].type == 134)
						{
							this.adjTile[16] = true;
						}
					}
					if (Main.tile[j, k].liquid > 200 && Main.tile[j, k].liquidType() == 0)
					{
						this.adjWater = true;
					}
					if (Main.tile[j, k].liquid > 200 && Main.tile[j, k].liquidType() == 2)
					{
						this.adjHoney = true;
					}
					if (Main.tile[j, k].liquid > 200 && Main.tile[j, k].liquidType() == 1)
					{
						this.adjLava = true;
					}
				}
			}
			if (Main.playerInventory)
			{
				bool flag = false;
				for (int l = 0; l < 314; l++)
				{
					if (this.oldAdjTile[l] != this.adjTile[l])
					{
						flag = true;
						break;
					}
				}
				if (this.adjWater != this.oldAdjWater)
				{
					flag = true;
				}
				if (this.adjHoney != this.oldAdjHoney)
				{
					flag = true;
				}
				if (this.adjLava != this.oldAdjLava)
				{
					flag = true;
				}
				if (flag)
				{
					Recipe.FindRecipes();
				}
			}
		}
		public void PlayerFrame()
		{
			if (this.swimTime > 0)
			{
				this.swimTime--;
				if (!this.wet)
				{
					this.swimTime = 0;
				}
			}
			this.head = this.armor[0].headSlot;
			this.body = this.armor[1].bodySlot;
			this.legs = this.armor[2].legSlot;
			for (int i = 3; i < 8; i++)
			{
				if ((this.shield <= 0 || this.armor[i].frontSlot < 1 || this.armor[i].frontSlot > 4) && (this.front < 1 || this.front > 4 || this.armor[i].shieldSlot <= 0))
				{
					if (this.armor[i].wingSlot > 0)
					{
						if (this.hideVisual[i] && this.velocity.Y == 0f)
						{
							goto IL_273;
						}
						this.wings = (int)this.armor[i].wingSlot;
					}
					if (!this.hideVisual[i])
					{
						if (this.armor[i].handOnSlot > 0)
						{
							this.handon = this.armor[i].handOnSlot;
						}
						if (this.armor[i].handOffSlot > 0)
						{
							this.handoff = this.armor[i].handOffSlot;
						}
						if (this.armor[i].backSlot > 0)
						{
							this.back = this.armor[i].backSlot;
							this.front = -1;
						}
						if (this.armor[i].frontSlot > 0)
						{
							this.front = this.armor[i].frontSlot;
						}
						if (this.armor[i].shoeSlot > 0)
						{
							this.shoe = this.armor[i].shoeSlot;
						}
						if (this.armor[i].waistSlot > 0)
						{
							this.waist = this.armor[i].waistSlot;
						}
						if (this.armor[i].shieldSlot > 0)
						{
							this.shield = this.armor[i].shieldSlot;
						}
						if (this.armor[i].neckSlot > 0)
						{
							this.neck = this.armor[i].neckSlot;
						}
						if (this.armor[i].faceSlot > 0)
						{
							this.face = this.armor[i].faceSlot;
						}
						if (this.armor[i].balloonSlot > 0)
						{
							this.balloon = this.armor[i].balloonSlot;
						}
					}
				}
				IL_273:;
			}
			for (int j = 11; j < 16; j++)
			{
				if (this.armor[j].handOnSlot > 0)
				{
					this.handon = this.armor[j].handOnSlot;
				}
				if (this.armor[j].handOffSlot > 0)
				{
					this.handoff = this.armor[j].handOffSlot;
				}
				if (this.armor[j].backSlot > 0)
				{
					this.back = this.armor[j].backSlot;
					this.front = -1;
				}
				if (this.armor[j].frontSlot > 0)
				{
					this.front = this.armor[j].frontSlot;
				}
				if (this.armor[j].shoeSlot > 0)
				{
					this.shoe = this.armor[j].shoeSlot;
				}
				if (this.armor[j].waistSlot > 0)
				{
					this.waist = this.armor[j].waistSlot;
				}
				if (this.armor[j].shieldSlot > 0)
				{
					this.shield = this.armor[j].shieldSlot;
				}
				if (this.armor[j].neckSlot > 0)
				{
					this.neck = this.armor[j].neckSlot;
				}
				if (this.armor[j].faceSlot > 0)
				{
					this.face = this.armor[j].faceSlot;
				}
				if (this.armor[j].balloonSlot > 0)
				{
					this.balloon = this.armor[j].balloonSlot;
				}
				if (this.armor[j].wingSlot > 0)
				{
					this.wings = (int)this.armor[j].wingSlot;
				}
			}
			if (this.armor[8].headSlot >= 0)
			{
				this.head = this.armor[8].headSlot;
			}
			if (this.armor[9].bodySlot >= 0)
			{
				this.body = this.armor[9].bodySlot;
			}
			if (this.armor[10].legSlot >= 0)
			{
				this.legs = this.armor[10].legSlot;
			}
			this.wearsRobe = false;
			int num = this.body;
			if (num <= 36)
			{
				if (num != 15)
				{
					if (num == 36)
					{
						this.legs = 89;
						this.wearsRobe = true;
					}
				}
				else
				{
					this.legs = 88;
					this.wearsRobe = true;
				}
			}
			else
			{
				switch (num)
				{
				case 41:
					this.legs = 97;
					this.wearsRobe = true;
					break;
				case 42:
					this.legs = 90;
					this.wearsRobe = true;
					break;
				default:
					switch (num)
					{
					case 58:
						this.legs = 91;
						this.wearsRobe = true;
						break;
					case 59:
						this.legs = 92;
						this.wearsRobe = true;
						break;
					case 60:
						this.legs = 93;
						this.wearsRobe = true;
						break;
					case 61:
						this.legs = 94;
						this.wearsRobe = true;
						break;
					case 62:
						this.legs = 95;
						this.wearsRobe = true;
						break;
					case 63:
						this.legs = 96;
						this.wearsRobe = true;
						break;
					default:
						switch (num)
						{
						case 165:
							this.legs = 99;
							this.wearsRobe = true;
							break;
						case 166:
							this.legs = 100;
							this.wearsRobe = true;
							break;
						case 167:
							if (this.male)
							{
								this.legs = 101;
							}
							else
							{
								this.legs = 102;
							}
							this.wearsRobe = true;
							break;
						}
						break;
					}
					break;
				}
			}
			if (Main.myPlayer == this.whoAmi)
			{
				bool flag = false;
				if (this.wings == 3 || (this.wings >= 16 && this.wings <= 19))
				{
					flag = true;
				}
				if (this.wingsLogic == 3 || (this.wingsLogic >= 16 && this.wingsLogic <= 19))
				{
					flag = true;
				}
				else
				{
					if (this.head == 45 || (this.head >= 106 && this.head <= 111))
					{
						flag = true;
					}
					else
					{
						if (this.body == 26 || (this.body >= 68 && this.body <= 74))
						{
							flag = true;
						}
						else
						{
							if (this.legs == 25 || (this.legs >= 57 && this.legs <= 63))
							{
								flag = true;
							}
						}
					}
				}
				if (flag)
				{
					this.velocity.X = this.velocity.X * 0.9f;
					if (this.velocity.Y < 0f)
					{
						this.velocity.Y = this.velocity.Y + 0.2f;
					}
					this.jump = 0;
					this.statDefense = -1000;
					this.AddBuff(23, 2, false);
					this.AddBuff(80, 2, false);
					this.AddBuff(67, 2, false);
					this.AddBuff(32, 2, false);
					this.AddBuff(31, 2, false);
					this.AddBuff(33, 2, false);
				}
			}
			if (this.body == 93)
			{
				this.shield = 0;
				this.handoff = 0;
			}
			if (this.legs == 67)
			{
				this.shoe = 0;
			}
			if (this.wereWolf)
			{
				this.legs = 20;
				this.body = 21;
				this.head = 38;
			}
			if (this.merman)
			{
				this.head = 39;
				this.legs = 21;
				this.body = 22;
				this.wings = 0;
			}
			this.socialShadow = false;
			this.socialGhost = false;
			if (this.head == 101 && this.body == 66 && this.legs == 55)
			{
				this.socialGhost = true;
			}
			if (this.head == 156 && this.body == 66 && this.legs == 55)
			{
				this.socialGhost = true;
			}
			if (this.head == 99 && this.body == 65 && this.legs == 54)
			{
				this.turtleArmor = true;
			}
			if ((this.head == 75 || this.head == 7) && this.body == 7 && this.legs == 7)
			{
				this.boneArmor = true;
			}
			if (this.wings > 0)
			{
				this.back = -1;
				this.front = -1;
			}
			if (this.head > 0 && this.face != 7)
			{
				this.face = -1;
			}
			if (this.frozen)
			{
				return;
			}
			if (Main.gamePaused && !Main.gameMenu)
			{
				return;
			}
			if (((this.body == 68 && this.legs == 57 && this.head == 106) || (this.body == 74 && this.legs == 63 && this.head == 106)) && Main.rand.Next(10) == 0)
			{
				int num2 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 2f, this.position.Y - 2f - this.velocity.Y * 2f), this.width, this.height, 43, 0f, 0f, 100, new Color(255, 0, 255), 0.3f);
				Main.dust[num2].fadeIn = 0.8f;
				Main.dust[num2].noGravity = true;
				Main.dust[num2].velocity *= 2f;
			}
			if (this.head == 5 && this.body == 5 && this.legs == 5)
			{
				this.socialShadow = true;
			}
			if (this.head == 5 && this.body == 5 && this.legs == 5 && Main.rand.Next(10) == 0)
			{
				Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 14, 0f, 0f, 200, default(Color), 1.2f);
			}
			if (this.head == 45 && this.body == 26 && this.legs == 25 && Main.rand.Next(12) == 0)
			{
				Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 186, 0f, 0f, 160, default(Color), 1.4f);
			}
			if (this.head == 76 && this.body == 49 && this.legs == 45)
			{
				this.socialShadow = true;
			}
			if (this.head == 74 && this.body == 48 && this.legs == 44)
			{
				this.socialShadow = true;
			}
			if (this.head == 74 && this.body == 48 && this.legs == 44 && Main.rand.Next(10) == 0)
			{
				Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 14, 0f, 0f, 200, default(Color), 1.2f);
			}
			if (this.head == 57 && this.body == 37 && this.legs == 35)
			{
				int maxValue = 10;
				if (Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) > 1f)
				{
					maxValue = 2;
				}
				if (Main.rand.Next(maxValue) == 0)
				{
					int num3 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 115, 0f, 0f, 140, default(Color), 0.75f);
					Main.dust[num3].noGravity = true;
					Main.dust[num3].fadeIn = 1.5f;
					Main.dust[num3].velocity *= 0.3f;
					Main.dust[num3].velocity += this.velocity * 0.2f;
				}
			}
			if (this.head == 6 && this.body == 6 && this.legs == 6 && Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) > 1f && !this.rocketFrame)
			{
				for (int k = 0; k < 2; k++)
				{
					int num4 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 2f, this.position.Y - 2f - this.velocity.Y * 2f), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2f);
					Main.dust[num4].noGravity = true;
					Main.dust[num4].noLight = true;
					Dust expr_DA6_cp_0 = Main.dust[num4];
					expr_DA6_cp_0.velocity.X = expr_DA6_cp_0.velocity.X - this.velocity.X * 0.5f;
					Dust expr_DD0_cp_0 = Main.dust[num4];
					expr_DD0_cp_0.velocity.Y = expr_DD0_cp_0.velocity.Y - this.velocity.Y * 0.5f;
				}
			}
			if (this.head == 8 && this.body == 8 && this.legs == 8 && Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) > 1f)
			{
				int num5 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 2f, this.position.Y - 2f - this.velocity.Y * 2f), this.width, this.height, 40, 0f, 0f, 50, default(Color), 1.4f);
				Main.dust[num5].noGravity = true;
				Main.dust[num5].velocity.X = this.velocity.X * 0.25f;
				Main.dust[num5].velocity.Y = this.velocity.Y * 0.25f;
			}
			if (this.head == 9 && this.body == 9 && this.legs == 9 && Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) > 1f && !this.rocketFrame)
			{
				for (int l = 0; l < 2; l++)
				{
					int num6 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 2f, this.position.Y - 2f - this.velocity.Y * 2f), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2f);
					Main.dust[num6].noGravity = true;
					Main.dust[num6].noLight = true;
					Dust expr_1015_cp_0 = Main.dust[num6];
					expr_1015_cp_0.velocity.X = expr_1015_cp_0.velocity.X - this.velocity.X * 0.5f;
					Dust expr_103F_cp_0 = Main.dust[num6];
					expr_103F_cp_0.velocity.Y = expr_103F_cp_0.velocity.Y - this.velocity.Y * 0.5f;
				}
			}
			if (this.body == 18 && this.legs == 17 && (this.head == 32 || this.head == 33 || this.head == 34) && Main.rand.Next(10) == 0)
			{
				int num7 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 2f, this.position.Y - 2f - this.velocity.Y * 2f), this.width, this.height, 43, 0f, 0f, 100, default(Color), 0.3f);
				Main.dust[num7].fadeIn = 0.8f;
				Main.dust[num7].velocity *= 0f;
			}
			if (this.body == 24 && this.legs == 23 && (this.head == 42 || this.head == 43 || this.head == 41) && this.velocity.X != 0f && this.velocity.Y != 0f && Main.rand.Next(10) == 0)
			{
				int num8 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 2f, this.position.Y - 2f - this.velocity.Y * 2f), this.width, this.height, 43, 0f, 0f, 100, default(Color), 0.3f);
				Main.dust[num8].fadeIn = 0.8f;
				Main.dust[num8].velocity *= 0f;
			}
			if (this.body == 36 && this.head == 56 && this.velocity.X != 0f && this.velocity.Y == 0f)
			{
				for (int m = 0; m < 2; m++)
				{
					int num9 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)((this.gravDir == 1f) ? (this.height - 2) : -4)), this.width, 6, 106, 0f, 0f, 100, default(Color), 0.1f);
					Main.dust[num9].fadeIn = 1f;
					Main.dust[num9].noGravity = true;
					Main.dust[num9].velocity *= 0.2f;
				}
			}
			if (this.body == 27 && this.head == 46 && this.legs == 26)
			{
				this.frostArmor = true;
				if (this.velocity.X != 0f && this.velocity.Y == 0f && this.miscCounter % 2 == 0)
				{
					for (int n = 0; n < 2; n++)
					{
						int num10;
						if (n == 0)
						{
							num10 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)this.height + this.gfxOffY), this.width / 2, 6, 76, 0f, 0f, 0, default(Color), 1.35f);
						}
						else
						{
							num10 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2), this.position.Y + (float)this.height + this.gfxOffY), this.width / 2, 6, 76, 0f, 0f, 0, default(Color), 1.35f);
						}
						Main.dust[num10].scale *= 1f + (float)Main.rand.Next(20, 40) * 0.01f;
						Main.dust[num10].noGravity = true;
						Main.dust[num10].noLight = true;
						Main.dust[num10].velocity *= 0.001f;
						Dust expr_150A_cp_0 = Main.dust[num10];
						expr_150A_cp_0.velocity.Y = expr_150A_cp_0.velocity.Y - 0.003f;
					}
				}
			}
			this.bodyFrame.Width = 40;
			this.bodyFrame.Height = 56;
			this.legFrame.Width = 40;
			this.legFrame.Height = 56;
			this.bodyFrame.X = 0;
			this.legFrame.X = 0;
			if (this.itemAnimation > 0 && this.inventory[this.selectedItem].useStyle != 10)
			{
				if (this.inventory[this.selectedItem].useStyle == 1 || this.inventory[this.selectedItem].type == 0)
				{
					if ((double)this.itemAnimation < (double)this.itemAnimationMax * 0.333)
					{
						this.bodyFrame.Y = this.bodyFrame.Height * 3;
					}
					else
					{
						if ((double)this.itemAnimation < (double)this.itemAnimationMax * 0.666)
						{
							this.bodyFrame.Y = this.bodyFrame.Height * 2;
						}
						else
						{
							this.bodyFrame.Y = this.bodyFrame.Height;
						}
					}
				}
				else
				{
					if (this.inventory[this.selectedItem].useStyle == 2)
					{
						if ((double)this.itemAnimation > (double)this.itemAnimationMax * 0.5)
						{
							this.bodyFrame.Y = this.bodyFrame.Height * 3;
						}
						else
						{
							this.bodyFrame.Y = this.bodyFrame.Height * 2;
						}
					}
					else
					{
						if (this.inventory[this.selectedItem].useStyle == 3)
						{
							if ((double)this.itemAnimation > (double)this.itemAnimationMax * 0.666)
							{
								this.bodyFrame.Y = this.bodyFrame.Height * 3;
							}
							else
							{
								this.bodyFrame.Y = this.bodyFrame.Height * 3;
							}
						}
						else
						{
							if (this.inventory[this.selectedItem].useStyle == 4)
							{
								this.bodyFrame.Y = this.bodyFrame.Height * 2;
							}
							else
							{
								if (this.inventory[this.selectedItem].useStyle == 5)
								{
									if (this.inventory[this.selectedItem].type == 281 || this.inventory[this.selectedItem].type == 986)
									{
										this.bodyFrame.Y = this.bodyFrame.Height * 2;
									}
									else
									{
										float num11 = this.itemRotation * (float)this.direction;
										this.bodyFrame.Y = this.bodyFrame.Height * 3;
										if ((double)num11 < -0.75)
										{
											this.bodyFrame.Y = this.bodyFrame.Height * 2;
											if (this.gravDir == -1f)
											{
												this.bodyFrame.Y = this.bodyFrame.Height * 4;
											}
										}
										if ((double)num11 > 0.6)
										{
											this.bodyFrame.Y = this.bodyFrame.Height * 4;
											if (this.gravDir == -1f)
											{
												this.bodyFrame.Y = this.bodyFrame.Height * 2;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			else
			{
				if (this.mount == 1)
				{
					this.bodyFrameCounter = 0.0;
					this.bodyFrame.Y = this.bodyFrame.Height * 3;
				}
				else
				{
					if (this.pulley)
					{
						if (this.pulleyDir == 2)
						{
							this.bodyFrame.Y = this.bodyFrame.Height;
						}
						else
						{
							this.bodyFrame.Y = this.bodyFrame.Height * 2;
						}
					}
					else
					{
						if (this.inventory[this.selectedItem].holdStyle == 1 && (!this.wet || !this.inventory[this.selectedItem].noWet))
						{
							this.bodyFrame.Y = this.bodyFrame.Height * 3;
						}
						else
						{
							if (this.inventory[this.selectedItem].holdStyle == 2 && (!this.wet || !this.inventory[this.selectedItem].noWet))
							{
								this.bodyFrame.Y = this.bodyFrame.Height * 2;
							}
							else
							{
								if (this.inventory[this.selectedItem].holdStyle == 3)
								{
									this.bodyFrame.Y = this.bodyFrame.Height * 3;
								}
								else
								{
									if (this.grappling[0] >= 0)
									{
										this.sandStorm = false;
										this.dJumpEffect = false;
										this.dJumpEffect2 = false;
										this.dJumpEffect3 = false;
										Vector2 vector = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
										float num12 = 0f;
										float num13 = 0f;
										for (int num14 = 0; num14 < this.grapCount; num14++)
										{
											num12 += Main.projectile[this.grappling[num14]].position.X + (float)(Main.projectile[this.grappling[num14]].width / 2);
											num13 += Main.projectile[this.grappling[num14]].position.Y + (float)(Main.projectile[this.grappling[num14]].height / 2);
										}
										num12 /= (float)this.grapCount;
										num13 /= (float)this.grapCount;
										num12 -= vector.X;
										num13 -= vector.Y;
										if (num13 < 0f && Math.Abs(num13) > Math.Abs(num12))
										{
											this.bodyFrame.Y = this.bodyFrame.Height * 2;
											if (this.gravDir == -1f)
											{
												this.bodyFrame.Y = this.bodyFrame.Height * 4;
											}
										}
										else
										{
											if (num13 > 0f && Math.Abs(num13) > Math.Abs(num12))
											{
												this.bodyFrame.Y = this.bodyFrame.Height * 4;
												if (this.gravDir == -1f)
												{
													this.bodyFrame.Y = this.bodyFrame.Height * 2;
												}
											}
											else
											{
												this.bodyFrame.Y = this.bodyFrame.Height * 3;
											}
										}
									}
									else
									{
										if (this.swimTime > 0)
										{
											if (this.swimTime > 20)
											{
												this.bodyFrame.Y = 0;
											}
											else
											{
												if (this.swimTime > 10)
												{
													this.bodyFrame.Y = this.bodyFrame.Height * 5;
												}
												else
												{
													this.bodyFrame.Y = 0;
												}
											}
										}
										else
										{
											if (this.velocity.Y != 0f)
											{
												if (this.sliding)
												{
													this.bodyFrame.Y = this.bodyFrame.Height * 3;
												}
												else
												{
													if (this.sandStorm || this.carpetFrame >= 0)
													{
														this.bodyFrame.Y = this.bodyFrame.Height * 6;
													}
													else
													{
														if (this.wings > 0)
														{
															if (this.wings == 22)
															{
																this.bodyFrame.Y = 0;
															}
															else
															{
																if (this.velocity.Y > 0f)
																{
																	if (this.controlJump)
																	{
																		this.bodyFrame.Y = this.bodyFrame.Height * 6;
																	}
																	else
																	{
																		this.bodyFrame.Y = this.bodyFrame.Height * 5;
																	}
																}
																else
																{
																	this.bodyFrame.Y = this.bodyFrame.Height * 6;
																}
															}
														}
														else
														{
															this.bodyFrame.Y = this.bodyFrame.Height * 5;
														}
													}
												}
												this.bodyFrameCounter = 0.0;
											}
											else
											{
												if (this.velocity.X != 0f)
												{
													this.bodyFrameCounter += (double)Math.Abs(this.velocity.X) * 1.5;
													this.bodyFrame.Y = this.legFrame.Y;
												}
												else
												{
													this.bodyFrameCounter = 0.0;
													this.bodyFrame.Y = 0;
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
			if (this.mount == 1)
			{
				this.legFrameCounter = 0.0;
				this.legFrame.Y = this.legFrame.Height * 6;
				if (this.velocity.Y != 0f)
				{
					if (this.mountFlyTime > 0 && this.jump == 0 && this.controlJump)
					{
						if (this.direction > 0)
						{
							if (Main.rand.Next(4) == 0)
							{
								int num15 = Dust.NewDust(new Vector2(this.Center().X - 22f, this.position.Y + (float)this.height - 6f), 20, 10, 64, this.velocity.X * 0.25f, this.velocity.Y * 0.25f, 255, default(Color), 1f);
								Main.dust[num15].velocity *= 0.1f;
								Main.dust[num15].noLight = true;
							}
							if (Main.rand.Next(4) == 0)
							{
								int num16 = Dust.NewDust(new Vector2(this.Center().X + 12f, this.position.Y + (float)this.height - 6f), 20, 10, 64, this.velocity.X * 0.25f, this.velocity.Y * 0.25f, 255, default(Color), 1f);
								Main.dust[num16].velocity *= 0.1f;
								Main.dust[num16].noLight = true;
							}
						}
						else
						{
							if (Main.rand.Next(4) == 0)
							{
								int num17 = Dust.NewDust(new Vector2(this.Center().X - 32f, this.position.Y + (float)this.height - 6f), 20, 10, 64, this.velocity.X * 0.25f, this.velocity.Y * 0.25f, 255, default(Color), 1f);
								Main.dust[num17].velocity *= 0.1f;
								Main.dust[num17].noLight = true;
							}
							if (Main.rand.Next(4) == 0)
							{
								int num18 = Dust.NewDust(new Vector2(this.Center().X + 2f, this.position.Y + (float)this.height - 6f), 20, 10, 64, this.velocity.X * 0.25f, this.velocity.Y * 0.25f, 255, default(Color), 1f);
								Main.dust[num18].velocity *= 0.1f;
								Main.dust[num18].noLight = true;
							}
						}
						this.mountFrameCounter += 1f;
						if (this.mountFrameCounter > 6f)
						{
							this.mountFrameCounter = 0f;
							this.mountFrame++;
						}
						if (this.mountFrame < 6)
						{
							this.mountFrame = 6;
						}
						if (this.mountFrame > 11)
						{
							this.mountFrame = 6;
						}
					}
					else
					{
						this.mountFrameCounter = 0f;
						this.mountFrame = 1;
					}
				}
				else
				{
					if (this.velocity.X == 0f)
					{
						this.mountFrameCounter = 0f;
						this.mountFrame = 0;
					}
					else
					{
						this.mountFrameCounter += Math.Abs(this.velocity.X);
						if (this.mountFrameCounter > 12f)
						{
							this.mountFrameCounter = 0f;
							this.mountFrame++;
						}
						if (this.mountFrame < 6)
						{
							this.mountFrame = 6;
						}
						if (this.mountFrame > 11)
						{
							this.mountFrame = 6;
						}
					}
				}
			}
			else
			{
				if (this.swimTime > 0)
				{
					this.legFrameCounter += 2.0;
					while (this.legFrameCounter > 8.0)
					{
						this.legFrameCounter -= 8.0;
						this.legFrame.Y = this.legFrame.Y + this.legFrame.Height;
					}
					if (this.legFrame.Y < this.legFrame.Height * 7)
					{
						this.legFrame.Y = this.legFrame.Height * 19;
					}
					else
					{
						if (this.legFrame.Y > this.legFrame.Height * 19)
						{
							this.legFrame.Y = this.legFrame.Height * 7;
						}
					}
				}
				else
				{
					if (this.velocity.Y != 0f || this.grappling[0] > -1)
					{
						this.legFrameCounter = 0.0;
						this.legFrame.Y = this.legFrame.Height * 5;
						if (this.wings == 22)
						{
							this.legFrame.Y = 0;
						}
					}
					else
					{
						if (this.velocity.X != 0f)
						{
							if ((this.slippy || this.slippy2) && !this.controlLeft && !this.controlRight)
							{
								this.legFrameCounter = 0.0;
								this.legFrame.Y = 0;
							}
							else
							{
								this.legFrameCounter += (double)Math.Abs(this.velocity.X) * 1.3;
								while (this.legFrameCounter > 8.0)
								{
									this.legFrameCounter -= 8.0;
									this.legFrame.Y = this.legFrame.Y + this.legFrame.Height;
								}
								if (this.legFrame.Y < this.legFrame.Height * 7)
								{
									this.legFrame.Y = this.legFrame.Height * 19;
								}
								else
								{
									if (this.legFrame.Y > this.legFrame.Height * 19)
									{
										this.legFrame.Y = this.legFrame.Height * 7;
									}
								}
							}
						}
						else
						{
							this.legFrameCounter = 0.0;
							this.legFrame.Y = 0;
						}
					}
				}
			}
			if (this.carpetFrame >= 0)
			{
				this.legFrameCounter = 0.0;
				this.legFrame.Y = 0;
			}
			if (this.sandStorm)
			{
				if (this.miscCounter % 4 == 0 && this.itemAnimation == 0)
				{
					this.ChangeDir(this.direction * -1);
					if (this.inventory[this.selectedItem].holdStyle == 2)
					{
						if (this.inventory[this.selectedItem].type == 946)
						{
							this.itemLocation.X = this.position.X + (float)this.width * 0.5f - (float)(16 * this.direction);
						}
						if (this.inventory[this.selectedItem].type == 186)
						{
							this.itemLocation.X = this.position.X + (float)this.width * 0.5f + (float)(6 * this.direction);
							this.itemRotation = 0.79f * (float)(-(float)this.direction);
						}
					}
				}
				this.legFrameCounter = 0.0;
				this.legFrame.Y = 0;
			}
		}
		public void Teleport(Vector2 newPos, int Style = 0)
		{
			try
			{
				this.grappling[0] = -1;
				this.grapCount = 0;
				for (int i = 0; i < 1000; i++)
				{
					if (Main.projectile[i].active && Main.projectile[i].owner == this.whoAmi && Main.projectile[i].aiStyle == 7)
					{
						Main.projectile[i].Kill();
					}
				}
				Main.TeleportEffect(this.getRect(), Style);
				this.position = newPos;
				this.fallStart = (int)(this.position.Y / 16f);
				if (this.whoAmi == Main.myPlayer)
				{
					Main.BlackFadeIn = 255;
					Lighting.BlackOut();
					Main.screenLastPosition = Main.screenPosition;
					Main.screenPosition.X = this.position.X + (float)(this.width / 2) - (float)(Main.screenWidth / 2);
					Main.screenPosition.Y = this.position.Y + (float)(this.height / 2) - (float)(Main.screenHeight / 2);
					if (Main.mapTime < 5)
					{
						Main.mapTime = 5;
					}
					Main.quickBG = 10;
					Main.maxQ = true;
					Main.renderNow = true;
				}
				Main.TeleportEffect(this.getRect(), Style);
				this.teleportTime = 1f;
				this.teleportStyle = Style;
			}
			catch
			{
			}
		}
		public void Spawn()
		{
			if (this.whoAmi == Main.myPlayer)
			{
				if (Main.mapTime < 5)
				{
					Main.mapTime = 5;
				}
				Main.quickBG = 10;
				this.FindSpawn();
				if (!Player.CheckSpawn(this.SpawnX, this.SpawnY))
				{
					this.SpawnX = -1;
					this.SpawnY = -1;
				}
				Main.maxQ = true;
			}
			if (Main.netMode == 1 && this.whoAmi == Main.myPlayer)
			{
				NetMessage.SendData(12, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
				Main.gameMenu = false;
			}
			this.headPosition = default(Vector2);
			this.bodyPosition = default(Vector2);
			this.legPosition = default(Vector2);
			this.headRotation = 0f;
			this.bodyRotation = 0f;
			this.legRotation = 0f;
			this.lavaTime = this.lavaMax;
			if (this.statLife <= 0)
			{
				this.statLife = 100;
				this.breath = this.breathMax;
				if (this.spawnMax)
				{
					this.statLife = this.statLifeMax;
					this.statMana = this.statManaMax2;
				}
			}
			this.immune = true;
			this.dead = false;
			this.immuneTime = 0;
			this.active = true;
			if (this.SpawnX >= 0 && this.SpawnY >= 0)
			{
				this.position.X = (float)(this.SpawnX * 16 + 8 - this.width / 2);
				this.position.Y = (float)(this.SpawnY * 16 - this.height);
			}
			else
			{
				this.position.X = (float)(Main.spawnTileX * 16 + 8 - this.width / 2);
				this.position.Y = (float)(Main.spawnTileY * 16 - this.height);
				for (int i = Main.spawnTileX - 1; i < Main.spawnTileX + 2; i++)
				{
					for (int j = Main.spawnTileY - 3; j < Main.spawnTileY; j++)
					{
						if (Main.tileSolid[(int)Main.tile[i, j].type] && !Main.tileSolidTop[(int)Main.tile[i, j].type])
						{
							WorldGen.KillTile(i, j, false, false, false);
						}
						if (Main.tile[i, j].liquid > 0)
						{
							Main.tile[i, j].lava(false);
							Main.tile[i, j].liquid = 0;
							WorldGen.SquareTileFrame(i, j, true);
						}
					}
				}
			}
			this.wet = false;
			this.wetCount = 0;
			this.lavaWet = false;
			this.fallStart = (int)(this.position.Y / 16f);
			this.velocity.X = 0f;
			this.velocity.Y = 0f;
			this.talkNPC = -1;
			if (this.pvpDeath)
			{
				this.pvpDeath = false;
				this.immuneTime = 300;
				this.statLife = this.statLifeMax;
			}
			else
			{
				this.immuneTime = 60;
			}
			if (this.whoAmi == Main.myPlayer)
			{
				Main.BlackFadeIn = 255;
				Main.renderNow = true;
				if (Main.netMode == 1)
				{
					Netplay.newRecent();
				}
				Main.screenPosition.X = this.position.X + (float)(this.width / 2) - (float)(Main.screenWidth / 2);
				Main.screenPosition.Y = this.position.Y + (float)(this.height / 2) - (float)(Main.screenHeight / 2);
			}
		}
		public void ShadowDodge()
		{
			this.immune = true;
			this.immuneTime = 80;
			if (this.longInvince)
			{
				this.immuneTime += 40;
			}
			if (this.whoAmi == Main.myPlayer)
			{
				for (int i = 0; i < 22; i++)
				{
					if (this.buffTime[i] > 0 && this.buffType[i] == 59)
					{
						this.DelBuff(i);
					}
				}
				NetMessage.SendData(62, -1, -1, "", this.whoAmi, 2f, 0f, 0f, 0);
			}
		}
		public void NinjaDodge()
		{
			this.immune = true;
			this.immuneTime = 80;
			if (this.longInvince)
			{
				this.immuneTime += 40;
			}
			for (int i = 0; i < 100; i++)
			{
				int num = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 2f);
				Dust expr_82_cp_0 = Main.dust[num];
				expr_82_cp_0.position.X = expr_82_cp_0.position.X + (float)Main.rand.Next(-20, 21);
				Dust expr_A9_cp_0 = Main.dust[num];
				expr_A9_cp_0.position.Y = expr_A9_cp_0.position.Y + (float)Main.rand.Next(-20, 21);
				Main.dust[num].velocity *= 0.4f;
				Main.dust[num].scale *= 1f + (float)Main.rand.Next(40) * 0.01f;
				if (Main.rand.Next(2) == 0)
				{
					Main.dust[num].scale *= 1f + (float)Main.rand.Next(40) * 0.01f;
					Main.dust[num].noGravity = true;
				}
			}
			int num2 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
			Main.gore[num2].scale = 1.5f;
			Main.gore[num2].velocity.X = (float)Main.rand.Next(-50, 51) * 0.01f;
			Main.gore[num2].velocity.Y = (float)Main.rand.Next(-50, 51) * 0.01f;
			Main.gore[num2].velocity *= 0.4f;
			num2 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
			Main.gore[num2].scale = 1.5f;
			Main.gore[num2].velocity.X = 1.5f + (float)Main.rand.Next(-50, 51) * 0.01f;
			Main.gore[num2].velocity.Y = 1.5f + (float)Main.rand.Next(-50, 51) * 0.01f;
			Main.gore[num2].velocity *= 0.4f;
			num2 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
			Main.gore[num2].scale = 1.5f;
			Main.gore[num2].velocity.X = -1.5f - (float)Main.rand.Next(-50, 51) * 0.01f;
			Main.gore[num2].velocity.Y = 1.5f + (float)Main.rand.Next(-50, 51) * 0.01f;
			Main.gore[num2].velocity *= 0.4f;
			num2 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
			Main.gore[num2].scale = 1.5f;
			Main.gore[num2].velocity.X = 1.5f + (float)Main.rand.Next(-50, 51) * 0.01f;
			Main.gore[num2].velocity.Y = -1.5f - (float)Main.rand.Next(-50, 51) * 0.01f;
			Main.gore[num2].velocity *= 0.4f;
			num2 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
			Main.gore[num2].scale = 1.5f;
			Main.gore[num2].velocity.X = -1.5f - (float)Main.rand.Next(-50, 51) * 0.01f;
			Main.gore[num2].velocity.Y = -1.5f - (float)Main.rand.Next(-50, 51) * 0.01f;
			Main.gore[num2].velocity *= 0.4f;
			if (this.whoAmi == Main.myPlayer)
			{
				NetMessage.SendData(62, -1, -1, "", this.whoAmi, 1f, 0f, 0f, 0);
			}
		}
		public double Hurt(int Damage, int hitDirection, bool pvp = false, bool quiet = false, string deathText = " was slain...", bool Crit = false)
		{
			if (this.immune)
			{
				return 0.0;
			}
			if (this.whoAmi == Main.myPlayer && this.blackBelt && Main.rand.Next(10) == 0)
			{
				this.NinjaDodge();
				return 0.0;
			}
			if (this.whoAmi == Main.myPlayer && this.shadowDodge)
			{
				this.ShadowDodge();
				return 0.0;
			}
			if (this.whoAmi == Main.myPlayer && this.panic)
			{
				this.AddBuff(63, 300, true);
			}
			int num = Damage;
			double num2 = Main.CalculateDamage(num, this.statDefense);
			if (Crit)
			{
				num *= 2;
			}
			if (num2 >= 1.0)
			{
				if (this.beetleDefense && this.beetleOrbs > 0)
				{
					float num3 = 0.15f * (float)this.beetleOrbs;
					num2 = (double)((int)((double)(1f - num3) * num2));
					this.beetleOrbs--;
					for (int i = 0; i < 22; i++)
					{
						if (this.buffType[i] >= 95 && this.buffType[i] <= 97)
						{
							this.DelBuff(i);
						}
					}
					if (this.beetleOrbs > 0)
					{
						this.AddBuff(95 + this.beetleOrbs - 1, 5, false);
					}
					this.beetleCounter = 0f;
					if (num2 < 1.0)
					{
						num2 = 1.0;
					}
				}
				if (this.magicCuffs)
				{
					int num4 = num;
					this.statMana += num4;
					if (this.statMana > this.statManaMax2)
					{
						this.statMana = this.statManaMax2;
					}
					this.ManaEffect(num4);
				}
				if (this.paladinBuff)
				{
					int damage = (int)(num2 * 0.25);
					num2 = (double)((int)(num2 * 0.75));
					if (this.whoAmi != Main.myPlayer && Main.player[Main.myPlayer].paladinGive)
					{
						int myPlayer = Main.myPlayer;
						if (Main.player[myPlayer].team == this.team && this.team != 0)
						{
							float num5 = this.position.X - Main.player[myPlayer].position.X;
							float num6 = this.position.Y - Main.player[myPlayer].position.Y;
							float num7 = (float)Math.Sqrt((double)(num5 * num5 + num6 * num6));
							if (num7 < 800f)
							{
								Main.player[myPlayer].Hurt(damage, 0, false, false, "", false);
							}
						}
					}
				}
				if (Main.netMode == 1 && this.whoAmi == Main.myPlayer && !quiet)
				{
					int number = 0;
					if (Crit)
					{
						number = 1;
					}
					int num8 = 0;
					if (pvp)
					{
						num8 = 1;
					}
					NetMessage.SendData(13, -1, -1, "", this.whoAmi, 0f, 0f, 0f, 0);
					NetMessage.SendData(16, -1, -1, "", this.whoAmi, 0f, 0f, 0f, 0);
					NetMessage.SendData(26, -1, -1, "", this.whoAmi, (float)hitDirection, (float)Damage, (float)num8, number);
				}
				CombatText.NewText(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height), new Color(255, 80, 90, 255), string.Concat((int)num2), Crit, false);
				this.statLife -= (int)num2;
				this.immune = true;
				if (num2 == 1.0)
				{
					this.immuneTime = 20;
					if (this.longInvince)
					{
						this.immuneTime += 20;
					}
				}
				else
				{
					this.immuneTime = 40;
					if (this.longInvince)
					{
						this.immuneTime += 40;
					}
				}
				this.lifeRegenTime = 0;
				if (pvp)
				{
					this.immuneTime = 8;
				}
				if (this.whoAmi == Main.myPlayer)
				{
					if (this.starCloak)
					{
						for (int j = 0; j < 3; j++)
						{
							float x = this.position.X + (float)Main.rand.Next(-400, 400);
							float y = this.position.Y - (float)Main.rand.Next(500, 800);
							Vector2 vector = new Vector2(x, y);
							float num9 = this.position.X + (float)(this.width / 2) - vector.X;
							float num10 = this.position.Y + (float)(this.height / 2) - vector.Y;
							num9 += (float)Main.rand.Next(-100, 101);
							int num11 = 23;
							float num12 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
							num12 = (float)num11 / num12;
							num9 *= num12;
							num10 *= num12;
							int num13 = Projectile.NewProjectile(x, y, num9, num10, 92, 30, 5f, this.whoAmi, 0f, 0f);
							Main.projectile[num13].ai[1] = this.position.Y;
						}
					}
					if (this.bee)
					{
						int num14 = 1;
						if (Main.rand.Next(3) == 0)
						{
							num14++;
						}
						if (Main.rand.Next(3) == 0)
						{
							num14++;
						}
						for (int k = 0; k < num14; k++)
						{
							float speedX = (float)Main.rand.Next(-35, 36) * 0.02f;
							float speedY = (float)Main.rand.Next(-35, 36) * 0.02f;
							Projectile.NewProjectile(this.position.X, this.position.Y, speedX, speedY, 181, 7, 0f, Main.myPlayer, 0f, 0f);
						}
					}
				}
				if (!this.noKnockback && hitDirection != 0)
				{
					this.velocity.X = 4.5f * (float)hitDirection;
					this.velocity.Y = -3.5f;
				}
				if (this.frostArmor)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 27);
				}
				else
				{
					if (this.wereWolf)
					{
						Main.PlaySound(3, (int)this.position.X, (int)this.position.Y, 6);
					}
					else
					{
						if (this.boneArmor)
						{
							Main.PlaySound(3, (int)this.position.X, (int)this.position.Y, 2);
						}
						else
						{
							if (!this.male)
							{
								Main.PlaySound(20, (int)this.position.X, (int)this.position.Y, 1);
							}
							else
							{
								Main.PlaySound(1, (int)this.position.X, (int)this.position.Y, 1);
							}
						}
					}
				}
				if (this.statLife > 0)
				{
					int num15 = 0;
					while ((double)num15 < num2 / (double)this.statLifeMax * 100.0)
					{
						if (this.body == 27 && this.head == 46 && this.legs == 26)
						{
							Dust.NewDust(this.position, this.width, this.height, 135, (float)(2 * hitDirection), -2f, 0, default(Color), 1f);
						}
						else
						{
							if (this.boneArmor)
							{
								Dust.NewDust(this.position, this.width, this.height, 26, (float)(2 * hitDirection), -2f, 0, default(Color), 1f);
							}
							else
							{
								Dust.NewDust(this.position, this.width, this.height, 5, (float)(2 * hitDirection), -2f, 0, default(Color), 1f);
							}
						}
						num15++;
					}
				}
				else
				{
					this.statLife = 0;
					if (this.whoAmi == Main.myPlayer)
					{
						this.KillMe(num2, hitDirection, pvp, deathText);
					}
				}
			}
			if (pvp)
			{
				num2 = Main.CalculateDamage(num, this.statDefense);
			}
			return num2;
		}
		public void KillMeForGood()
		{
			if (File.Exists(Main.playerPathName))
			{
				File.Delete(Main.playerPathName);
			}
			if (File.Exists(Main.playerPathName + ".bak"))
			{
				File.Delete(Main.playerPathName + ".bak");
			}
			if (File.Exists(Main.playerPathName + ".dat"))
			{
				File.Delete(Main.playerPathName + ".dat");
			}
			Main.playerPathName = "";
		}
		public void KillMe(double dmg, int hitDirection, bool pvp = false, string deathText = " was slain...")
		{
			if (this.dead)
			{
				return;
			}
			if (pvp)
			{
				this.pvpDeath = true;
			}
			if (this.difficulty == 0)
			{
				if (Main.netMode != 1)
				{
					float num = (float)Main.rand.Next(-35, 36) * 0.1f;
					while (num < 2f && num > -2f)
					{
						num += (float)Main.rand.Next(-30, 31) * 0.1f;
					}
					int num2 = Main.rand.Next(6);
					if (num2 == 0)
					{
						num2 = 43;
					}
					else
					{
						num2 = 200 + num2;
					}
					int num3 = Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.head / 2), (float)Main.rand.Next(10, 30) * 0.1f * (float)hitDirection + num, (float)Main.rand.Next(-40, -20) * 0.1f, num2, 0, 0f, Main.myPlayer, 0f, 0f);
					Main.projectile[num3].miscText = this.name + deathText;
				}
				if (Main.myPlayer == this.whoAmi)
				{
					for (int i = 0; i < 59; i++)
					{
						if (this.inventory[i].stack > 0 && this.inventory[i].type >= 1522 && this.inventory[i].type <= 1527)
						{
							int num4 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, this.inventory[i].type, 1, false, 0, false);
							Main.item[num4].SetDefaults(this.inventory[i].name);
							Main.item[num4].Prefix((int)this.inventory[i].prefix);
							Main.item[num4].stack = this.inventory[i].stack;
							Main.item[num4].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
							Main.item[num4].velocity.X = (float)Main.rand.Next(-20, 21) * 0.2f;
							Main.item[num4].noGrabDelay = 100;
							if (Main.netMode == 1)
							{
								NetMessage.SendData(21, -1, -1, "", num4, 0f, 0f, 0f, 0);
							}
							this.inventory[i].SetDefaults(0, false);
						}
					}
					Main.mapFullscreen = false;
				}
			}
			else
			{
				if (Main.netMode != 1)
				{
					float num5 = (float)Main.rand.Next(-35, 36) * 0.1f;
					while (num5 < 2f && num5 > -2f)
					{
						num5 += (float)Main.rand.Next(-30, 31) * 0.1f;
					}
					int num6 = Main.rand.Next(6);
					if (num6 == 0)
					{
						num6 = 43;
					}
					else
					{
						num6 = 200 + num6;
					}
					int num7 = Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.head / 2), (float)Main.rand.Next(10, 30) * 0.1f * (float)hitDirection + num5, (float)Main.rand.Next(-40, -20) * 0.1f, num6, 0, 0f, Main.myPlayer, 0f, 0f);
					Main.projectile[num7].miscText = this.name + deathText;
				}
				if (Main.myPlayer == this.whoAmi)
				{
					if (Main.myPlayer == this.whoAmi)
					{
						Main.mapFullscreen = false;
					}
					Main.trashItem.SetDefaults(0, false);
					if (this.difficulty == 1)
					{
						this.DropItems();
					}
					else
					{
						if (this.difficulty == 2)
						{
							this.DropItems();
							this.KillMeForGood();
						}
					}
				}
			}
			Main.PlaySound(5, (int)this.position.X, (int)this.position.Y, 1);
			this.headVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
			this.bodyVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
			this.legVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
			this.headVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + (float)(2 * hitDirection);
			this.bodyVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + (float)(2 * hitDirection);
			this.legVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + (float)(2 * hitDirection);
			for (int j = 0; j < 100; j++)
			{
				if (this.boneArmor)
				{
					Dust.NewDust(this.position, this.width, this.height, 26, (float)(2 * hitDirection), -2f, 0, default(Color), 1f);
				}
				else
				{
					Dust.NewDust(this.position, this.width, this.height, 5, (float)(2 * hitDirection), -2f, 0, default(Color), 1f);
				}
			}
			this.mount = 0;
			this.dead = true;
			this.respawnTimer = 600;
			bool flag = false;
			if (Main.netMode != 0 && !pvp)
			{
				for (int k = 0; k < 200; k++)
				{
					if (Main.npc[k].active && (Main.npc[k].boss || Main.npc[k].type == 13 || Main.npc[k].type == 14 || Main.npc[k].type == 15) && Math.Abs(this.center().X - Main.npc[k].center().X) + Math.Abs(this.center().Y - Main.npc[k].center().Y) < 4000f)
					{
						flag = true;
						break;
					}
				}
			}
			if (flag)
			{
				this.respawnTimer += 600;
			}
			this.immuneAlpha = 0;
			this.palladiumRegen = false;
			this.iceBarrier = false;
			this.crystalLeaf = false;
			if (Main.netMode == 2)
			{
				NetMessage.SendData(25, -1, -1, this.name + deathText, 255, 225f, 25f, 25f, 0);
			}
			else
			{
				if (Main.netMode == 0)
				{
					Main.NewText(this.name + deathText, 225, 25, 25, false);
				}
			}
			if (Main.netMode == 1 && this.whoAmi == Main.myPlayer)
			{
				int num8 = 0;
				if (pvp)
				{
					num8 = 1;
				}
				NetMessage.SendData(44, -1, -1, deathText, this.whoAmi, (float)hitDirection, (float)((int)dmg), (float)num8, 0);
			}
			if (!pvp && this.whoAmi == Main.myPlayer && this.difficulty == 0)
			{
				this.DropCoins();
			}
			if (this.whoAmi == Main.myPlayer)
			{
				try
				{
					WorldGen.saveToonWhilePlaying();
				}
				catch
				{
				}
			}
		}
		public bool ItemSpace(Item newItem)
		{
			if (newItem.type == 58 || newItem.type == 184 || newItem.type == 1734 || newItem.type == 1735 || newItem.type == 1867 || newItem.type == 1868)
			{
				return true;
			}
			int num = 50;
			if (newItem.type == 71 || newItem.type == 72 || newItem.type == 73 || newItem.type == 74)
			{
				num = 54;
			}
			for (int i = 0; i < num; i++)
			{
				if (this.inventory[i].type == 0)
				{
					return true;
				}
			}
			for (int j = 0; j < num; j++)
			{
				if (this.inventory[j].type > 0 && this.inventory[j].stack < this.inventory[j].maxStack && newItem.IsTheSameAs(this.inventory[j]))
				{
					return true;
				}
			}
			if (newItem.ammo > 0 && !newItem.notAmmo)
			{
				if (newItem.type != 75 && newItem.type != 169 && newItem.type != 23 && newItem.type != 408 && newItem.type != 370)
				{
					for (int k = 54; k < 58; k++)
					{
						if (this.inventory[k].type == 0)
						{
							return true;
						}
					}
				}
				for (int l = 54; l < 58; l++)
				{
					if (this.inventory[l].type > 0 && this.inventory[l].stack < this.inventory[l].maxStack && newItem.IsTheSameAs(this.inventory[l]))
					{
						return true;
					}
				}
			}
			return false;
		}
		public void DoCoins(int i)
		{
			if (this.inventory[i].stack == 100 && (this.inventory[i].type == 71 || this.inventory[i].type == 72 || this.inventory[i].type == 73))
			{
				this.inventory[i].SetDefaults(this.inventory[i].type + 1, false);
				for (int j = 0; j < 54; j++)
				{
					if (this.inventory[j].IsTheSameAs(this.inventory[i]) && j != i && this.inventory[j].type == this.inventory[i].type && this.inventory[j].stack < this.inventory[j].maxStack)
					{
						this.inventory[j].stack++;
						this.inventory[i].SetDefaults(0, false);
						this.inventory[i].active = false;
						this.inventory[i].name = "";
						this.inventory[i].type = 0;
						this.inventory[i].stack = 0;
						this.DoCoins(j);
					}
				}
			}
		}
		public Item FillAmmo(int plr, Item newItem)
		{
			for (int i = 54; i < 58; i++)
			{
				if (this.inventory[i].type > 0 && this.inventory[i].stack < this.inventory[i].maxStack && newItem.IsTheSameAs(this.inventory[i]))
				{
					Main.PlaySound(7, (int)this.position.X, (int)this.position.Y, 1);
					if (newItem.stack + this.inventory[i].stack <= this.inventory[i].maxStack)
					{
						this.inventory[i].stack += newItem.stack;
						ItemText.NewText(newItem, newItem.stack);
						this.DoCoins(i);
						if (plr == Main.myPlayer)
						{
							Recipe.FindRecipes();
						}
						return new Item();
					}
					newItem.stack -= this.inventory[i].maxStack - this.inventory[i].stack;
					ItemText.NewText(newItem, this.inventory[i].maxStack - this.inventory[i].stack);
					this.inventory[i].stack = this.inventory[i].maxStack;
					this.DoCoins(i);
					if (plr == Main.myPlayer)
					{
						Recipe.FindRecipes();
					}
				}
			}
			if (newItem.type != 169 && newItem.type != 75 && newItem.type != 23 && newItem.type != 408 && newItem.type != 370 && !newItem.notAmmo)
			{
				for (int j = 54; j < 58; j++)
				{
					if (this.inventory[j].type == 0)
					{
						this.inventory[j] = newItem;
						ItemText.NewText(newItem, newItem.stack);
						this.DoCoins(j);
						Main.PlaySound(7, (int)this.position.X, (int)this.position.Y, 1);
						if (plr == Main.myPlayer)
						{
							Recipe.FindRecipes();
						}
						return new Item();
					}
				}
			}
			return newItem;
		}
		public Item GetItem(int plr, Item newItem)
		{
			Item item = newItem;
			int num = 50;
			if (newItem.noGrabDelay > 0)
			{
				return item;
			}
			int num2 = 0;
			if (newItem.type == 71 || newItem.type == 72 || newItem.type == 73 || newItem.type == 74)
			{
				num2 = -4;
				num = 54;
			}
			if (item.ammo > 0 && !item.notAmmo)
			{
				item = this.FillAmmo(plr, item);
				if (item.type == 0 || item.stack == 0)
				{
					return new Item();
				}
			}
			for (int i = num2; i < 50; i++)
			{
				int num3 = i;
				if (num3 < 0)
				{
					num3 = 54 + i;
				}
				if (this.inventory[num3].type > 0 && this.inventory[num3].stack < this.inventory[num3].maxStack && item.IsTheSameAs(this.inventory[num3]))
				{
					Main.PlaySound(7, (int)this.position.X, (int)this.position.Y, 1);
					if (item.stack + this.inventory[num3].stack <= this.inventory[num3].maxStack)
					{
						this.inventory[num3].stack += item.stack;
						ItemText.NewText(newItem, item.stack);
						this.DoCoins(num3);
						if (plr == Main.myPlayer)
						{
							Recipe.FindRecipes();
						}
						return new Item();
					}
					item.stack -= this.inventory[num3].maxStack - this.inventory[num3].stack;
					ItemText.NewText(newItem, this.inventory[num3].maxStack - this.inventory[num3].stack);
					this.inventory[num3].stack = this.inventory[num3].maxStack;
					this.DoCoins(num3);
					if (plr == Main.myPlayer)
					{
						Recipe.FindRecipes();
					}
				}
			}
			if (newItem.type != 71 && newItem.type != 72 && newItem.type != 73 && newItem.type != 74 && newItem.useStyle > 0)
			{
				for (int j = 0; j < 10; j++)
				{
					if (this.inventory[j].type == 0)
					{
						this.inventory[j] = item;
						ItemText.NewText(newItem, newItem.stack);
						this.DoCoins(j);
						Main.PlaySound(7, (int)this.position.X, (int)this.position.Y, 1);
						if (plr == Main.myPlayer)
						{
							Recipe.FindRecipes();
						}
						return new Item();
					}
				}
			}
			for (int k = num - 1; k >= 0; k--)
			{
				if (this.inventory[k].type == 0)
				{
					this.inventory[k] = item;
					ItemText.NewText(newItem, newItem.stack);
					this.DoCoins(k);
					Main.PlaySound(7, (int)this.position.X, (int)this.position.Y, 1);
					if (plr == Main.myPlayer)
					{
						Recipe.FindRecipes();
					}
					return new Item();
				}
			}
			return item;
		}
		public void PlaceThing()
		{
			if ((this.inventory[this.selectedItem].type == 1071 || this.inventory[this.selectedItem].type == 1543) && this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f + (float)this.blockRange >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f + (float)this.blockRange >= (float)Player.tileTargetY)
			{
				int num = Player.tileTargetX;
				int num2 = Player.tileTargetY;
				if (Main.tile[num, num2] != null && Main.tile[num, num2].active())
				{
					this.showItemIcon = true;
					if (this.itemTime == 0 && this.itemAnimation > 0 && this.controlUseItem)
					{
						int num3 = -1;
						int num4 = -1;
						for (int i = 0; i < 58; i++)
						{
							if (this.inventory[i].stack > 0 && this.inventory[i].paint > 0)
							{
								num3 = (int)this.inventory[i].paint;
								num4 = i;
								break;
							}
						}
						if (num3 > 0 && (int)Main.tile[num, num2].color() != num3 && WorldGen.paintTile(num, num2, (byte)num3, true))
						{
							int num5 = num4;
							this.inventory[num5].stack--;
							if (this.inventory[num5].stack <= 0)
							{
								this.inventory[num5].SetDefaults(0, false);
							}
							this.itemTime = this.inventory[this.selectedItem].useTime;
						}
					}
				}
			}
			if ((this.inventory[this.selectedItem].type == 1072 || this.inventory[this.selectedItem].type == 1544) && this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f + (float)this.blockRange >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f + (float)this.blockRange >= (float)Player.tileTargetY)
			{
				int num6 = Player.tileTargetX;
				int num7 = Player.tileTargetY;
				if (Main.tile[num6, num7] != null && Main.tile[num6, num7].wall > 0)
				{
					this.showItemIcon = true;
					if (this.itemTime == 0 && this.itemAnimation > 0 && this.controlUseItem)
					{
						int num8 = -1;
						int num9 = -1;
						for (int j = 0; j < 58; j++)
						{
							if (this.inventory[j].stack > 0 && this.inventory[j].paint > 0)
							{
								num8 = (int)this.inventory[j].paint;
								num9 = j;
								break;
							}
						}
						if (num8 > 0 && (int)Main.tile[num6, num7].wallColor() != num8 && WorldGen.paintWall(num6, num7, (byte)num8, true))
						{
							int num10 = num9;
							this.inventory[num10].stack--;
							if (this.inventory[num10].stack <= 0)
							{
								this.inventory[num10].SetDefaults(0, false);
							}
							this.itemTime = this.inventory[this.selectedItem].useTime;
						}
					}
				}
			}
			if ((this.inventory[this.selectedItem].type == 1100 || this.inventory[this.selectedItem].type == 1545) && this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f + (float)this.blockRange >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f + (float)this.blockRange >= (float)Player.tileTargetY)
			{
				int num11 = Player.tileTargetX;
				int num12 = Player.tileTargetY;
				if (Main.tile[num11, num12] != null && ((Main.tile[num11, num12].wallColor() > 0 && Main.tile[num11, num12].wall > 0) || (Main.tile[num11, num12].color() > 0 && Main.tile[num11, num12].active())))
				{
					this.showItemIcon = true;
					if (this.itemTime == 0 && this.itemAnimation > 0 && this.controlUseItem)
					{
						if (Main.tile[num11, num12].color() > 0 && Main.tile[num11, num12].active() && WorldGen.paintTile(num11, num12, 0, true))
						{
							this.itemTime = this.inventory[this.selectedItem].useTime;
						}
						else
						{
							if (Main.tile[num11, num12].wallColor() > 0 && Main.tile[num11, num12].wall > 0 && WorldGen.paintWall(num11, num12, 0, true))
							{
								this.itemTime = this.inventory[this.selectedItem].useTime;
							}
						}
					}
				}
			}
			if ((this.inventory[this.selectedItem].type == 929 || this.inventory[this.selectedItem].type == 1338) && this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f + (float)this.blockRange >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f + (float)this.blockRange >= (float)Player.tileTargetY)
			{
				int num13 = Player.tileTargetX;
				int num14 = Player.tileTargetY;
				if (Main.tile[num13, num14].active() && Main.tile[num13, num14].type == 209)
				{
					int num15 = 0;
					if (Main.tile[num13, num14].frameX < 72)
					{
						if (this.inventory[this.selectedItem].type == 929)
						{
							num15 = 1;
						}
					}
					else
					{
						if (Main.tile[num13, num14].frameX < 144 && this.inventory[this.selectedItem].type == 1338)
						{
							num15 = 2;
						}
					}
					if (num15 > 0)
					{
						this.showItemIcon = true;
						if (this.itemTime == 0 && this.itemAnimation > 0 && this.controlUseItem)
						{
							int k = (int)(Main.tile[num13, num14].frameX / 18);
							int num16 = 0;
							int num17 = 0;
							while (k >= 4)
							{
								num16++;
								k -= 4;
							}
							k = num13 - k;
							int l;
							for (l = (int)(Main.tile[num13, num14].frameY / 18); l >= 3; l -= 3)
							{
								num17++;
							}
							l = num14 - l;
							this.itemTime = this.inventory[this.selectedItem].useTime;
							float num18 = 14f;
							float num19 = 0f;
							float num20 = 0f;
							int type = 162;
							if (num15 == 2)
							{
								type = 281;
							}
							int damage = this.inventory[this.selectedItem].damage;
							int num21 = 8;
							if (num17 == 0)
							{
								num19 = 10f;
								num20 = 0f;
							}
							if (num17 == 1)
							{
								num19 = 7.5f;
								num20 = -2.5f;
							}
							if (num17 == 2)
							{
								num19 = 5f;
								num20 = -5f;
							}
							if (num17 == 3)
							{
								num19 = 2.75f;
								num20 = -6f;
							}
							if (num17 == 4)
							{
								num19 = 0f;
								num20 = -10f;
							}
							if (num17 == 5)
							{
								num19 = -2.75f;
								num20 = -6f;
							}
							if (num17 == 6)
							{
								num19 = -5f;
								num20 = -5f;
							}
							if (num17 == 7)
							{
								num19 = -7.5f;
								num20 = -2.5f;
							}
							if (num17 == 8)
							{
								num19 = -10f;
								num20 = 0f;
							}
							Vector2 vector = new Vector2((float)((k + 2) * 16), (float)((l + 2) * 16));
							float num22 = num19;
							float num23 = num20;
							float num24 = (float)Math.Sqrt((double)(num22 * num22 + num23 * num23));
							num24 = num18 / num24;
							num22 *= num24;
							num23 *= num24;
							Projectile.NewProjectile(vector.X, vector.Y, num22, num23, type, damage, (float)num21, Main.myPlayer, 0f, 0f);
						}
					}
				}
			}
			if (this.inventory[this.selectedItem].type >= 1874 && this.inventory[this.selectedItem].type <= 1905 && Main.tile[Player.tileTargetX, Player.tileTargetY].active() && Main.tile[Player.tileTargetX, Player.tileTargetY].type == 171 && this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f + (float)this.blockRange >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f + (float)this.blockRange >= (float)Player.tileTargetY && this.itemTime == 0 && this.itemAnimation > 0 && this.controlUseItem)
			{
				int num25 = this.inventory[this.selectedItem].type;
				if (num25 >= 1874 && num25 <= 1877)
				{
					num25 -= 1873;
					if (WorldGen.checkXmasTreeDrop(Player.tileTargetX, Player.tileTargetY, 0) != num25)
					{
						this.itemTime = this.inventory[this.selectedItem].useTime;
						WorldGen.dropXmasTree(Player.tileTargetX, Player.tileTargetY, 0);
						WorldGen.setXmasTree(Player.tileTargetX, Player.tileTargetY, 0, num25);
						int num26 = Player.tileTargetX;
						int num27 = Player.tileTargetY;
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX < 10)
						{
							num26 -= (int)Main.tile[Player.tileTargetX, Player.tileTargetY].frameX;
							num27 -= (int)Main.tile[Player.tileTargetX, Player.tileTargetY].frameY;
						}
						NetMessage.SendTileSquare(-1, num26, num27, 1);
					}
				}
				else
				{
					if (num25 >= 1878 && num25 <= 1883)
					{
						num25 -= 1877;
						if (WorldGen.checkXmasTreeDrop(Player.tileTargetX, Player.tileTargetY, 1) != num25)
						{
							this.itemTime = this.inventory[this.selectedItem].useTime;
							WorldGen.dropXmasTree(Player.tileTargetX, Player.tileTargetY, 1);
							WorldGen.setXmasTree(Player.tileTargetX, Player.tileTargetY, 1, num25);
							int num28 = Player.tileTargetX;
							int num29 = Player.tileTargetY;
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX < 10)
							{
								num28 -= (int)Main.tile[Player.tileTargetX, Player.tileTargetY].frameX;
								num29 -= (int)Main.tile[Player.tileTargetX, Player.tileTargetY].frameY;
							}
							NetMessage.SendTileSquare(-1, num28, num29, 1);
						}
					}
					else
					{
						if (num25 >= 1884 && num25 <= 1894)
						{
							num25 -= 1883;
							if (WorldGen.checkXmasTreeDrop(Player.tileTargetX, Player.tileTargetY, 2) != num25)
							{
								this.itemTime = this.inventory[this.selectedItem].useTime;
								WorldGen.dropXmasTree(Player.tileTargetX, Player.tileTargetY, 2);
								WorldGen.setXmasTree(Player.tileTargetX, Player.tileTargetY, 2, num25);
								int num30 = Player.tileTargetX;
								int num31 = Player.tileTargetY;
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX < 10)
								{
									num30 -= (int)Main.tile[Player.tileTargetX, Player.tileTargetY].frameX;
									num31 -= (int)Main.tile[Player.tileTargetX, Player.tileTargetY].frameY;
								}
								NetMessage.SendTileSquare(-1, num30, num31, 1);
							}
						}
						else
						{
							if (num25 >= 1895 && num25 <= 1905)
							{
								num25 -= 1894;
								if (WorldGen.checkXmasTreeDrop(Player.tileTargetX, Player.tileTargetY, 3) != num25)
								{
									this.itemTime = this.inventory[this.selectedItem].useTime;
									WorldGen.dropXmasTree(Player.tileTargetX, Player.tileTargetY, 3);
									WorldGen.setXmasTree(Player.tileTargetX, Player.tileTargetY, 3, num25);
									int num32 = Player.tileTargetX;
									int num33 = Player.tileTargetY;
									if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX < 10)
									{
										num32 -= (int)Main.tile[Player.tileTargetX, Player.tileTargetY].frameX;
										num33 -= (int)Main.tile[Player.tileTargetX, Player.tileTargetY].frameY;
									}
									NetMessage.SendTileSquare(-1, num32, num33, 1);
								}
							}
						}
					}
				}
			}
			if ((this.inventory[this.selectedItem].type == 424 || this.inventory[this.selectedItem].type == 1103) && Main.tile[Player.tileTargetX, Player.tileTargetY].active() && Main.tile[Player.tileTargetX, Player.tileTargetY].type == 219)
			{
				if (this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f + (float)this.blockRange >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f + (float)this.blockRange >= (float)Player.tileTargetY && this.itemTime == 0 && this.itemAnimation > 0 && this.controlUseItem)
				{
					this.itemTime = this.inventory[this.selectedItem].useTime;
					if (this.inventory[this.selectedItem].stack <= 0)
					{
						this.inventory[this.selectedItem].SetDefaults(0, false);
					}
					if (this.selectedItem == 48)
					{
						Main.mouseItem = this.inventory[this.selectedItem];
					}
					Main.PlaySound(7, -1, -1, 1);
					int num34 = 1;
					int num35;
					if (Main.rand.Next(2) == 0)
					{
						if (Main.rand.Next(10000) == 0)
						{
							num35 = 74;
							if (Main.rand.Next(12) == 0)
							{
								num34 += Main.rand.Next(0, 3);
							}
							if (Main.rand.Next(12) == 0)
							{
								num34 += Main.rand.Next(0, 3);
							}
							if (Main.rand.Next(12) == 0)
							{
								num34 += Main.rand.Next(0, 3);
							}
							if (Main.rand.Next(12) == 0)
							{
								num34 += Main.rand.Next(0, 3);
							}
							if (Main.rand.Next(12) == 0)
							{
								num34 += Main.rand.Next(0, 3);
							}
						}
						else
						{
							if (Main.rand.Next(800) == 0)
							{
								num35 = 73;
								if (Main.rand.Next(6) == 0)
								{
									num34 += Main.rand.Next(1, 21);
								}
								if (Main.rand.Next(6) == 0)
								{
									num34 += Main.rand.Next(1, 21);
								}
								if (Main.rand.Next(6) == 0)
								{
									num34 += Main.rand.Next(1, 21);
								}
								if (Main.rand.Next(6) == 0)
								{
									num34 += Main.rand.Next(1, 21);
								}
								if (Main.rand.Next(6) == 0)
								{
									num34 += Main.rand.Next(1, 20);
								}
							}
							else
							{
								if (Main.rand.Next(60) == 0)
								{
									num35 = 72;
									if (Main.rand.Next(4) == 0)
									{
										num34 += Main.rand.Next(5, 26);
									}
									if (Main.rand.Next(4) == 0)
									{
										num34 += Main.rand.Next(5, 26);
									}
									if (Main.rand.Next(4) == 0)
									{
										num34 += Main.rand.Next(5, 26);
									}
									if (Main.rand.Next(4) == 0)
									{
										num34 += Main.rand.Next(5, 25);
									}
								}
								else
								{
									num35 = 71;
									if (Main.rand.Next(3) == 0)
									{
										num34 += Main.rand.Next(10, 26);
									}
									if (Main.rand.Next(3) == 0)
									{
										num34 += Main.rand.Next(10, 26);
									}
									if (Main.rand.Next(3) == 0)
									{
										num34 += Main.rand.Next(10, 26);
									}
									if (Main.rand.Next(3) == 0)
									{
										num34 += Main.rand.Next(10, 25);
									}
								}
							}
						}
					}
					else
					{
						if (Main.rand.Next(5000) == 0)
						{
							num35 = 1242;
						}
						else
						{
							if (Main.rand.Next(25) == 0)
							{
								num35 = Main.rand.Next(6);
								if (num35 == 0)
								{
									num35 = 181;
								}
								else
								{
									if (num35 == 1)
									{
										num35 = 180;
									}
									else
									{
										if (num35 == 2)
										{
											num35 = 177;
										}
										else
										{
											if (num35 == 3)
											{
												num35 = 179;
											}
											else
											{
												if (num35 == 4)
												{
													num35 = 178;
												}
												else
												{
													num35 = 182;
												}
											}
										}
									}
								}
								if (Main.rand.Next(20) == 0)
								{
									num34 += Main.rand.Next(0, 2);
								}
								if (Main.rand.Next(30) == 0)
								{
									num34 += Main.rand.Next(0, 3);
								}
								if (Main.rand.Next(40) == 0)
								{
									num34 += Main.rand.Next(0, 4);
								}
								if (Main.rand.Next(50) == 0)
								{
									num34 += Main.rand.Next(0, 5);
								}
								if (Main.rand.Next(60) == 0)
								{
									num34 += Main.rand.Next(0, 6);
								}
							}
							else
							{
								if (Main.rand.Next(50) == 0)
								{
									num35 = 999;
									if (Main.rand.Next(20) == 0)
									{
										num34 += Main.rand.Next(0, 2);
									}
									if (Main.rand.Next(30) == 0)
									{
										num34 += Main.rand.Next(0, 3);
									}
									if (Main.rand.Next(40) == 0)
									{
										num34 += Main.rand.Next(0, 4);
									}
									if (Main.rand.Next(50) == 0)
									{
										num34 += Main.rand.Next(0, 5);
									}
									if (Main.rand.Next(60) == 0)
									{
										num34 += Main.rand.Next(0, 6);
									}
								}
								else
								{
									if (Main.rand.Next(3) == 0)
									{
										if (Main.rand.Next(5000) == 0)
										{
											num35 = 74;
											if (Main.rand.Next(10) == 0)
											{
												num34 += Main.rand.Next(0, 3);
											}
											if (Main.rand.Next(10) == 0)
											{
												num34 += Main.rand.Next(0, 3);
											}
											if (Main.rand.Next(10) == 0)
											{
												num34 += Main.rand.Next(0, 3);
											}
											if (Main.rand.Next(10) == 0)
											{
												num34 += Main.rand.Next(0, 3);
											}
											if (Main.rand.Next(10) == 0)
											{
												num34 += Main.rand.Next(0, 3);
											}
										}
										else
										{
											if (Main.rand.Next(400) == 0)
											{
												num35 = 73;
												if (Main.rand.Next(5) == 0)
												{
													num34 += Main.rand.Next(1, 21);
												}
												if (Main.rand.Next(5) == 0)
												{
													num34 += Main.rand.Next(1, 21);
												}
												if (Main.rand.Next(5) == 0)
												{
													num34 += Main.rand.Next(1, 21);
												}
												if (Main.rand.Next(5) == 0)
												{
													num34 += Main.rand.Next(1, 21);
												}
												if (Main.rand.Next(5) == 0)
												{
													num34 += Main.rand.Next(1, 20);
												}
											}
											else
											{
												if (Main.rand.Next(30) == 0)
												{
													num35 = 72;
													if (Main.rand.Next(3) == 0)
													{
														num34 += Main.rand.Next(5, 26);
													}
													if (Main.rand.Next(3) == 0)
													{
														num34 += Main.rand.Next(5, 26);
													}
													if (Main.rand.Next(3) == 0)
													{
														num34 += Main.rand.Next(5, 26);
													}
													if (Main.rand.Next(3) == 0)
													{
														num34 += Main.rand.Next(5, 25);
													}
												}
												else
												{
													num35 = 71;
													if (Main.rand.Next(2) == 0)
													{
														num34 += Main.rand.Next(10, 26);
													}
													if (Main.rand.Next(2) == 0)
													{
														num34 += Main.rand.Next(10, 26);
													}
													if (Main.rand.Next(2) == 0)
													{
														num34 += Main.rand.Next(10, 26);
													}
													if (Main.rand.Next(2) == 0)
													{
														num34 += Main.rand.Next(10, 25);
													}
												}
											}
										}
									}
									else
									{
										num35 = Main.rand.Next(8);
										if (num35 == 0)
										{
											num35 = 12;
										}
										else
										{
											if (num35 == 1)
											{
												num35 = 11;
											}
											else
											{
												if (num35 == 2)
												{
													num35 = 14;
												}
												else
												{
													if (num35 == 3)
													{
														num35 = 13;
													}
													else
													{
														if (num35 == 4)
														{
															num35 = 699;
														}
														else
														{
															if (num35 == 5)
															{
																num35 = 700;
															}
															else
															{
																if (num35 == 6)
																{
																	num35 = 701;
																}
																else
																{
																	num35 = 702;
																}
															}
														}
													}
												}
											}
										}
										if (Main.rand.Next(20) == 0)
										{
											num34 += Main.rand.Next(0, 2);
										}
										if (Main.rand.Next(30) == 0)
										{
											num34 += Main.rand.Next(0, 3);
										}
										if (Main.rand.Next(40) == 0)
										{
											num34 += Main.rand.Next(0, 4);
										}
										if (Main.rand.Next(50) == 0)
										{
											num34 += Main.rand.Next(0, 5);
										}
										if (Main.rand.Next(60) == 0)
										{
											num34 += Main.rand.Next(0, 6);
										}
									}
								}
							}
						}
					}
					if (num35 > 0)
					{
						int number = Item.NewItem((int)Main.screenPosition.X + Main.mouseX, (int)Main.screenPosition.Y + Main.mouseY, 1, 1, num35, num34, false, -1, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number, 1f, 0f, 0f, 0);
						}
					}
				}
			}
			else
			{
				if (this.inventory[this.selectedItem].createTile >= 0 && this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f + (float)this.blockRange >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f + (float)this.blockRange >= (float)Player.tileTargetY)
				{
					this.showItemIcon = true;
					bool flag = false;
					if (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid > 0 && Main.tile[Player.tileTargetX, Player.tileTargetY].lava())
					{
						if (Main.tileSolid[this.inventory[this.selectedItem].createTile])
						{
							flag = true;
						}
						else
						{
							if (Main.tileLavaDeath[this.inventory[this.selectedItem].createTile])
							{
								flag = true;
							}
						}
					}
					bool flag2 = true;
					if (this.inventory[this.selectedItem].tileWand > 0)
					{
						int tileWand = this.inventory[this.selectedItem].tileWand;
						flag2 = false;
						for (int m = 0; m < 58; m++)
						{
							if (tileWand == this.inventory[m].type && this.inventory[m].stack > 0)
							{
								flag2 = true;
								break;
							}
						}
					}
					if (Main.tileRope[this.inventory[this.selectedItem].createTile] && flag2 && Main.tile[Player.tileTargetX, Player.tileTargetY].active() && Main.tileRope[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type])
					{
						int num36 = Player.tileTargetY;
						int num37 = Player.tileTargetX;
						int createTile = this.inventory[this.selectedItem].createTile;
						while (Main.tile[num37, num36].active() && (int)Main.tile[num37, num36].type == createTile && num36 < Main.maxTilesX - 5)
						{
							num36++;
							if (Main.tile[num37, num36] == null)
							{
								flag2 = false;
								num36 = Player.tileTargetY;
							}
						}
						if (!Main.tile[num37, num36].active())
						{
							Player.tileTargetY = num36;
						}
					}
					if (flag2 && ((!Main.tile[Player.tileTargetX, Player.tileTargetY].active() && !flag) || Main.tileCut[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type] || this.inventory[this.selectedItem].createTile == 199 || this.inventory[this.selectedItem].createTile == 23 || this.inventory[this.selectedItem].createTile == 2 || this.inventory[this.selectedItem].createTile == 109 || this.inventory[this.selectedItem].createTile == 60 || this.inventory[this.selectedItem].createTile == 70) && this.itemTime == 0 && this.itemAnimation > 0 && this.controlUseItem)
					{
						bool flag3 = false;
						if (this.inventory[this.selectedItem].createTile == 23 || this.inventory[this.selectedItem].createTile == 2 || this.inventory[this.selectedItem].createTile == 109 || this.inventory[this.selectedItem].createTile == 199)
						{
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].nactive() && Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0)
							{
								flag3 = true;
							}
						}
						else
						{
							if (this.inventory[this.selectedItem].createTile == 227)
							{
								flag3 = true;
							}
							else
							{
								if (this.inventory[this.selectedItem].createTile == 60 || this.inventory[this.selectedItem].createTile == 70)
								{
									if (Main.tile[Player.tileTargetX, Player.tileTargetY].nactive() && Main.tile[Player.tileTargetX, Player.tileTargetY].type == 59)
									{
										flag3 = true;
									}
								}
								else
								{
									if (this.inventory[this.selectedItem].createTile == 4 || this.inventory[this.selectedItem].createTile == 136)
									{
										if (Main.tile[Player.tileTargetX, Player.tileTargetY].wall > 0)
										{
											flag3 = true;
										}
										else
										{
											if (!WorldGen.SolidTileNoAttach(Player.tileTargetX, Player.tileTargetY + 1) && !WorldGen.SolidTileNoAttach(Player.tileTargetX - 1, Player.tileTargetY) && !WorldGen.SolidTileNoAttach(Player.tileTargetX + 1, Player.tileTargetY))
											{
												if (!WorldGen.SolidTileNoAttach(Player.tileTargetX, Player.tileTargetY + 1) && (Main.tile[Player.tileTargetX, Player.tileTargetY + 1].halfBrick() || Main.tile[Player.tileTargetX, Player.tileTargetY + 1].slope() != 0))
												{
													if (Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type != 19)
													{
														WorldGen.SlopeTile(Player.tileTargetX, Player.tileTargetY + 1, 0);
														if (Main.netMode == 1)
														{
															NetMessage.SendData(17, -1, -1, "", 14, (float)Player.tileTargetX, (float)(Player.tileTargetY + 1), 0f, 0);
														}
													}
												}
												else
												{
													if (!WorldGen.SolidTileNoAttach(Player.tileTargetX, Player.tileTargetY + 1) && !WorldGen.SolidTileNoAttach(Player.tileTargetX - 1, Player.tileTargetY) && (Main.tile[Player.tileTargetX - 1, Player.tileTargetY].halfBrick() || Main.tile[Player.tileTargetX - 1, Player.tileTargetY].slope() != 0))
													{
														if (Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type != 19)
														{
															WorldGen.SlopeTile(Player.tileTargetX - 1, Player.tileTargetY, 0);
															if (Main.netMode == 1)
															{
																NetMessage.SendData(17, -1, -1, "", 14, (float)(Player.tileTargetX - 1), (float)Player.tileTargetY, 0f, 0);
															}
														}
													}
													else
													{
														if (!WorldGen.SolidTileNoAttach(Player.tileTargetX, Player.tileTargetY + 1) && !WorldGen.SolidTileNoAttach(Player.tileTargetX - 1, Player.tileTargetY) && !WorldGen.SolidTileNoAttach(Player.tileTargetX + 1, Player.tileTargetY) && (Main.tile[Player.tileTargetX + 1, Player.tileTargetY].halfBrick() || Main.tile[Player.tileTargetX + 1, Player.tileTargetY].slope() != 0) && Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type != 19)
														{
															WorldGen.SlopeTile(Player.tileTargetX + 1, Player.tileTargetY, 0);
															if (Main.netMode == 1)
															{
																NetMessage.SendData(17, -1, -1, "", 14, (float)(Player.tileTargetX + 1), (float)Player.tileTargetY, 0f, 0);
															}
														}
													}
												}
											}
											int num38 = (int)Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type;
											if (Main.tile[Player.tileTargetX, Player.tileTargetY].halfBrick())
											{
												num38 = -1;
											}
											int num39 = (int)Main.tile[Player.tileTargetX - 1, Player.tileTargetY].type;
											int num40 = (int)Main.tile[Player.tileTargetX + 1, Player.tileTargetY].type;
											int num41 = (int)Main.tile[Player.tileTargetX - 1, Player.tileTargetY - 1].type;
											int num42 = (int)Main.tile[Player.tileTargetX + 1, Player.tileTargetY - 1].type;
											int num43 = (int)Main.tile[Player.tileTargetX - 1, Player.tileTargetY - 1].type;
											int num44 = (int)Main.tile[Player.tileTargetX + 1, Player.tileTargetY + 1].type;
											if (!Main.tile[Player.tileTargetX, Player.tileTargetY + 1].nactive())
											{
												num38 = -1;
											}
											if (!Main.tile[Player.tileTargetX - 1, Player.tileTargetY].nactive())
											{
												num39 = -1;
											}
											if (!Main.tile[Player.tileTargetX + 1, Player.tileTargetY].nactive())
											{
												num40 = -1;
											}
											if (!Main.tile[Player.tileTargetX - 1, Player.tileTargetY - 1].nactive())
											{
												num41 = -1;
											}
											if (!Main.tile[Player.tileTargetX + 1, Player.tileTargetY - 1].nactive())
											{
												num42 = -1;
											}
											if (!Main.tile[Player.tileTargetX - 1, Player.tileTargetY + 1].nactive())
											{
												num43 = -1;
											}
											if (!Main.tile[Player.tileTargetX + 1, Player.tileTargetY + 1].nactive())
											{
												num44 = -1;
											}
											if (num38 >= 0 && Main.tileSolid[num38] && !Main.tileNoAttach[num38])
											{
												flag3 = true;
											}
											else
											{
												if ((num39 >= 0 && Main.tileSolid[num39] && !Main.tileNoAttach[num39]) || (num39 == 5 && num41 == 5 && num43 == 5) || num39 == 124)
												{
													flag3 = true;
												}
												else
												{
													if ((num40 >= 0 && Main.tileSolid[num40] && !Main.tileNoAttach[num40]) || (num40 == 5 && num42 == 5 && num44 == 5) || num40 == 124)
													{
														flag3 = true;
													}
												}
											}
										}
									}
									else
									{
										if (this.inventory[this.selectedItem].createTile == 78 || this.inventory[this.selectedItem].createTile == 98 || this.inventory[this.selectedItem].createTile == 100 || this.inventory[this.selectedItem].createTile == 173 || this.inventory[this.selectedItem].createTile == 174)
										{
											if (Main.tile[Player.tileTargetX, Player.tileTargetY + 1].nactive() && (Main.tileSolid[(int)Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type] || Main.tileTable[(int)Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type]))
											{
												flag3 = true;
											}
										}
										else
										{
											if (this.inventory[this.selectedItem].createTile == 13 || this.inventory[this.selectedItem].createTile == 29 || this.inventory[this.selectedItem].createTile == 33 || this.inventory[this.selectedItem].createTile == 49 || this.inventory[this.selectedItem].createTile == 50 || this.inventory[this.selectedItem].createTile == 103)
											{
												if (Main.tile[Player.tileTargetX, Player.tileTargetY + 1].nactive() && Main.tileTable[(int)Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type])
												{
													flag3 = true;
												}
											}
											else
											{
												if (this.inventory[this.selectedItem].createTile == 275 || this.inventory[this.selectedItem].createTile == 276 || this.inventory[this.selectedItem].createTile == 277)
												{
													flag3 = true;
												}
												else
												{
													if (this.inventory[this.selectedItem].createTile == 51)
													{
														if (Main.tile[Player.tileTargetX + 1, Player.tileTargetY].active() || Main.tile[Player.tileTargetX + 1, Player.tileTargetY].wall > 0 || Main.tile[Player.tileTargetX - 1, Player.tileTargetY].active() || Main.tile[Player.tileTargetX - 1, Player.tileTargetY].wall > 0 || Main.tile[Player.tileTargetX, Player.tileTargetY + 1].active() || Main.tile[Player.tileTargetX, Player.tileTargetY + 1].wall > 0 || Main.tile[Player.tileTargetX, Player.tileTargetY - 1].active() || Main.tile[Player.tileTargetX, Player.tileTargetY - 1].wall > 0)
														{
															flag3 = true;
														}
													}
													else
													{
														if ((Main.tile[Player.tileTargetX + 1, Player.tileTargetY].active() && (Main.tileSolid[(int)Main.tile[Player.tileTargetX + 1, Player.tileTargetY].type] || Main.tileRope[(int)Main.tile[Player.tileTargetX + 1, Player.tileTargetY].type])) || (Main.tile[Player.tileTargetX + 1, Player.tileTargetY].wall > 0 || (Main.tile[Player.tileTargetX - 1, Player.tileTargetY].active() && (Main.tileSolid[(int)Main.tile[Player.tileTargetX - 1, Player.tileTargetY].type] || Main.tileRope[(int)Main.tile[Player.tileTargetX - 1, Player.tileTargetY].type]))) || (Main.tile[Player.tileTargetX - 1, Player.tileTargetY].wall > 0 || (Main.tile[Player.tileTargetX, Player.tileTargetY + 1].active() && (Main.tileSolid[(int)Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type] || Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type == 124 || Main.tileRope[(int)Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type]))) || (Main.tile[Player.tileTargetX, Player.tileTargetY + 1].wall > 0 || (Main.tile[Player.tileTargetX, Player.tileTargetY - 1].active() && (Main.tileSolid[(int)Main.tile[Player.tileTargetX, Player.tileTargetY - 1].type] || Main.tile[Player.tileTargetX, Player.tileTargetY - 1].type == 124 || Main.tileRope[(int)Main.tile[Player.tileTargetX, Player.tileTargetY - 1].type]))) || Main.tile[Player.tileTargetX, Player.tileTargetY - 1].wall > 0)
														{
															flag3 = true;
														}
													}
												}
											}
										}
									}
								}
							}
						}
						if (Main.tileAlch[this.inventory[this.selectedItem].createTile])
						{
							flag3 = true;
						}
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].active() && Main.tileCut[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type])
						{
							if ((int)Main.tile[Player.tileTargetX, Player.tileTargetY].type != this.inventory[this.selectedItem].createTile)
							{
								if (Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type != 78)
								{
									WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, false, false, false);
									if (!Main.tile[Player.tileTargetX, Player.tileTargetY].active() && Main.netMode == 1)
									{
										NetMessage.SendData(17, -1, -1, "", 4, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
									}
								}
								else
								{
									flag3 = false;
								}
							}
							else
							{
								flag3 = false;
							}
						}
						if (!flag3 && this.inventory[this.selectedItem].createTile == 19)
						{
							for (int n = Player.tileTargetX - 1; n <= Player.tileTargetX + 1; n++)
							{
								for (int num45 = Player.tileTargetY - 1; num45 <= Player.tileTargetY + 1; num45++)
								{
									if (Main.tile[n, num45].active())
									{
										flag3 = true;
										break;
									}
								}
							}
						}
						if (flag3)
						{
							int num46 = this.inventory[this.selectedItem].placeStyle;
							if (this.inventory[this.selectedItem].createTile == 36)
							{
								num46 = Main.rand.Next(7);
							}
							if (this.inventory[this.selectedItem].createTile == 212 && this.direction > 0)
							{
								num46 = 1;
							}
							if (this.inventory[this.selectedItem].createTile == 141)
							{
								num46 = Main.rand.Next(2);
							}
							if (this.inventory[this.selectedItem].createTile == 128 || this.inventory[this.selectedItem].createTile == 269)
							{
								if (this.direction < 0)
								{
									num46 = -1;
								}
								else
								{
									num46 = 1;
								}
							}
							if (this.inventory[this.selectedItem].createTile == 241 && this.inventory[this.selectedItem].placeStyle == 0)
							{
								num46 = Main.rand.Next(0, 9);
							}
							if (this.inventory[this.selectedItem].createTile == 35 && this.inventory[this.selectedItem].placeStyle == 0)
							{
								num46 = Main.rand.Next(9);
							}
							int[,] array = new int[11, 11];
							if (this.autoPaint)
							{
								for (int num47 = 0; num47 < 11; num47++)
								{
									for (int num48 = 0; num48 < 11; num48++)
									{
										int num49 = Player.tileTargetX - 5 + num47;
										int num50 = Player.tileTargetY - 5 + num48;
										if (Main.tile[num49, num50].active())
										{
											array[num47, num48] = (int)Main.tile[num49, num50].type;
										}
										else
										{
											array[num47, num48] = -1;
										}
									}
								}
							}
							if (WorldGen.PlaceTile(Player.tileTargetX, Player.tileTargetY, this.inventory[this.selectedItem].createTile, false, false, this.whoAmi, num46))
							{
								this.itemTime = (int)((float)this.inventory[this.selectedItem].useTime * this.tileSpeed);
								if (Main.netMode == 1 && this.inventory[this.selectedItem].createTile != 21)
								{
									NetMessage.SendData(17, -1, -1, "", 1, (float)Player.tileTargetX, (float)Player.tileTargetY, (float)this.inventory[this.selectedItem].createTile, num46);
								}
								if (this.inventory[this.selectedItem].createTile == 15)
								{
									if (this.direction == 1)
									{
										Tile expr_2FFA = Main.tile[Player.tileTargetX, Player.tileTargetY];
										expr_2FFA.frameX += 18;
										Tile expr_301F = Main.tile[Player.tileTargetX, Player.tileTargetY - 1];
										expr_301F.frameX += 18;
									}
									if (Main.netMode == 1)
									{
										NetMessage.SendTileSquare(-1, Player.tileTargetX - 1, Player.tileTargetY - 1, 3);
									}
								}
								else
								{
									if (this.inventory[this.selectedItem].createTile == 137)
									{
										if (this.direction == 1)
										{
											Tile expr_3089 = Main.tile[Player.tileTargetX, Player.tileTargetY];
											expr_3089.frameX += 18;
										}
										if (Main.netMode == 1)
										{
											NetMessage.SendTileSquare(-1, Player.tileTargetX, Player.tileTargetY, 1);
										}
									}
									else
									{
										if ((this.inventory[this.selectedItem].createTile == 79 || this.inventory[this.selectedItem].createTile == 90) && Main.netMode == 1)
										{
											NetMessage.SendTileSquare(-1, Player.tileTargetX, Player.tileTargetY, 5);
										}
									}
								}
								if (Main.tileSolid[this.inventory[this.selectedItem].createTile] && this.inventory[this.selectedItem].createTile != 19)
								{
									int num51 = Player.tileTargetX;
									int num52 = Player.tileTargetY + 1;
									if (Main.tile[num51, num52] != null && Main.tile[num51, num52].type != 19 && (Main.tile[num51, num52].topSlope() || Main.tile[num51, num52].halfBrick()))
									{
										WorldGen.SlopeTile(num51, num52, 0);
										if (Main.netMode == 1)
										{
											NetMessage.SendData(17, -1, -1, "", 14, (float)num51, (float)num52, 0f, 0);
										}
									}
									num51 = Player.tileTargetX;
									num52 = Player.tileTargetY - 1;
									if (Main.tile[num51, num52] != null && Main.tile[num51, num52].type != 19 && Main.tile[num51, num52].bottomSlope())
									{
										WorldGen.SlopeTile(num51, num52, 0);
										if (Main.netMode == 1)
										{
											NetMessage.SendData(17, -1, -1, "", 14, (float)num51, (float)num52, 0f, 0);
										}
									}
								}
								if (this.autoPaint)
								{
									for (int num53 = 0; num53 < 11; num53++)
									{
										for (int num54 = 0; num54 < 11; num54++)
										{
											int num55 = Player.tileTargetX - 5 + num53;
											int num56 = Player.tileTargetY - 5 + num54;
											if ((Main.tile[num55, num56].active() || array[num53, num54] != -1) && (!Main.tile[num55, num56].active() || array[num53, num54] != (int)Main.tile[num55, num56].type))
											{
												int num57 = -1;
												int num58 = -1;
												for (int num59 = 0; num59 < 58; num59++)
												{
													if (this.inventory[num59].stack > 0 && this.inventory[num59].paint > 0)
													{
														num57 = (int)this.inventory[num59].paint;
														num58 = num59;
														break;
													}
												}
												if (num57 > 0 && (int)Main.tile[num55, num56].color() != num57 && WorldGen.paintTile(num55, num56, (byte)num57, true))
												{
													int num60 = num58;
													this.inventory[num60].stack--;
													if (this.inventory[num60].stack <= 0)
													{
														this.inventory[num60].SetDefaults(0, false);
													}
													this.itemTime = this.inventory[this.selectedItem].useTime;
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
			if (this.inventory[this.selectedItem].createWall >= 0 && this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f >= (float)Player.tileTargetY)
			{
				this.showItemIcon = true;
				if (this.itemTime == 0 && this.itemAnimation > 0 && this.controlUseItem && (Main.tile[Player.tileTargetX + 1, Player.tileTargetY].active() || Main.tile[Player.tileTargetX + 1, Player.tileTargetY].wall > 0 || Main.tile[Player.tileTargetX - 1, Player.tileTargetY].active() || Main.tile[Player.tileTargetX - 1, Player.tileTargetY].wall > 0 || Main.tile[Player.tileTargetX, Player.tileTargetY + 1].active() || Main.tile[Player.tileTargetX, Player.tileTargetY + 1].wall > 0 || Main.tile[Player.tileTargetX, Player.tileTargetY - 1].active() || Main.tile[Player.tileTargetX, Player.tileTargetY - 1].wall > 0) && (int)Main.tile[Player.tileTargetX, Player.tileTargetY].wall != this.inventory[this.selectedItem].createWall)
				{
					WorldGen.PlaceWall(Player.tileTargetX, Player.tileTargetY, this.inventory[this.selectedItem].createWall, false);
					if ((int)Main.tile[Player.tileTargetX, Player.tileTargetY].wall == this.inventory[this.selectedItem].createWall)
					{
						this.itemTime = (int)((float)this.inventory[this.selectedItem].useTime * this.wallSpeed);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(17, -1, -1, "", 3, (float)Player.tileTargetX, (float)Player.tileTargetY, (float)this.inventory[this.selectedItem].createWall, 0);
						}
						if (this.inventory[this.selectedItem].stack > 1)
						{
							int createWall = this.inventory[this.selectedItem].createWall;
							for (int num61 = 0; num61 < 4; num61++)
							{
								int num62 = Player.tileTargetX;
								int num63 = Player.tileTargetY;
								if (num61 == 0)
								{
									num62--;
								}
								if (num61 == 1)
								{
									num62++;
								}
								if (num61 == 2)
								{
									num63--;
								}
								if (num61 == 3)
								{
									num63++;
								}
								if (Main.tile[num62, num63].wall == 0)
								{
									int num64 = 0;
									for (int num65 = 0; num65 < 4; num65++)
									{
										int num66 = num62;
										int num67 = num63;
										if (num65 == 0)
										{
											num66--;
										}
										if (num65 == 1)
										{
											num66++;
										}
										if (num65 == 2)
										{
											num67--;
										}
										if (num65 == 3)
										{
											num67++;
										}
										if ((int)Main.tile[num66, num67].wall == createWall)
										{
											num64++;
										}
									}
									if (num64 == 4)
									{
										WorldGen.PlaceWall(num62, num63, createWall, false);
										if ((int)Main.tile[num62, num63].wall == createWall)
										{
											this.inventory[this.selectedItem].stack--;
											if (this.inventory[this.selectedItem].stack == 0)
											{
												this.inventory[this.selectedItem].SetDefaults(0, false);
											}
											if (Main.netMode == 1)
											{
												NetMessage.SendData(17, -1, -1, "", 3, (float)num62, (float)num63, (float)createWall, 0);
											}
											if (this.autoPaint)
											{
												int num68 = num62;
												int num69 = num63;
												int num70 = -1;
												int num71 = -1;
												for (int num72 = 0; num72 < 58; num72++)
												{
													if (this.inventory[num72].stack > 0 && this.inventory[num72].paint > 0)
													{
														num70 = (int)this.inventory[num72].paint;
														num71 = num72;
														break;
													}
												}
												if (num70 > 0 && (int)Main.tile[num68, num69].wallColor() != num70 && WorldGen.paintWall(num68, num69, (byte)num70, true))
												{
													int num73 = num71;
													this.inventory[num73].stack--;
													if (this.inventory[num73].stack <= 0)
													{
														this.inventory[num73].SetDefaults(0, false);
													}
													this.itemTime = this.inventory[this.selectedItem].useTime;
												}
											}
										}
									}
								}
							}
						}
						if (this.autoPaint)
						{
							int num74 = Player.tileTargetX;
							int num75 = Player.tileTargetY;
							int num76 = -1;
							int num77 = -1;
							for (int num78 = 0; num78 < 58; num78++)
							{
								if (this.inventory[num78].stack > 0 && this.inventory[num78].paint > 0)
								{
									num76 = (int)this.inventory[num78].paint;
									num77 = num78;
									break;
								}
							}
							if (num76 > 0 && (int)Main.tile[num74, num75].wallColor() != num76 && WorldGen.paintWall(num74, num75, (byte)num76, true))
							{
								int num79 = num77;
								this.inventory[num79].stack--;
								if (this.inventory[num79].stack <= 0)
								{
									this.inventory[num79].SetDefaults(0, false);
								}
								this.itemTime = this.inventory[this.selectedItem].useTime;
							}
						}
					}
				}
			}
		}
		public void ChangeDir(int dir)
		{
			if (!this.pulley || this.pulleyDir != 2)
			{
				this.direction = dir;
				return;
			}
			if (this.pulleyDir == 2 && dir == this.direction)
			{
				return;
			}
			int num = (int)(this.position.X + (float)(this.width / 2)) / 16;
			int num2 = num * 16 + 8 - this.width / 2;
			if (!Collision.SolidCollision(new Vector2((float)num2, this.position.Y), this.width, this.height))
			{
				if (this.whoAmi == Main.myPlayer)
				{
					Main.cameraX = Main.cameraX + this.position.X - (float)num2;
				}
				this.pulleyDir = 1;
				this.position.X = (float)num2;
				this.direction = dir;
			}
		}
		public Vector2 center()
		{
			return new Vector2(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2));
		}
		public Rectangle getRect()
		{
			return new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height);
		}
		private void pumpkinSword(int i, int dmg, float kb)
		{
			int num = Main.rand.Next(100, 300);
			int num2 = Main.rand.Next(100, 300);
			if (Main.rand.Next(2) == 0)
			{
				num -= Main.maxScreenW / 2 + num;
			}
			else
			{
				num += Main.maxScreenW / 2 - num;
			}
			if (Main.rand.Next(2) == 0)
			{
				num2 -= Main.maxScreenH / 2 + num2;
			}
			else
			{
				num2 += Main.maxScreenH / 2 - num2;
			}
			num += (int)this.position.X;
			num2 += (int)this.position.Y;
			float num3 = 8f;
			Vector2 vector = new Vector2((float)num, (float)num2);
			float num4 = Main.npc[i].position.X - vector.X;
			float num5 = Main.npc[i].position.Y - vector.Y;
			float num6 = (float)Math.Sqrt((double)(num4 * num4 + num5 * num5));
			num6 = num3 / num6;
			num4 *= num6;
			num5 *= num6;
			Projectile.NewProjectile((float)num, (float)num2, num4, num5, 321, dmg, kb, this.whoAmi, (float)i, 0f);
		}
		public void Dismount()
		{
			if (this.mount > 0)
			{
				for (int i = 0; i < 22; i++)
				{
					if (this.buffType[i] == 90)
					{
						this.DelBuff(i);
					}
				}
				if (this.mount == 1)
				{
					for (int j = 0; j < 100; j++)
					{
						int num = Dust.NewDust(new Vector2(this.position.X - 20f, this.position.Y), this.width + 40, this.height, 57, 0f, 0f, 255, default(Color), 1f);
						Main.dust[num].scale += (float)Main.rand.Next(-10, 21) * 0.01f;
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[num].scale *= 1.3f;
							Main.dust[num].noGravity = true;
						}
						else
						{
							Main.dust[num].velocity *= 0.5f;
						}
						Main.dust[num].velocity += this.velocity * 0.8f;
					}
				}
				this.mount = 0;
				this.position.Y = this.position.Y + (float)this.height;
				this.height = 42;
				this.position.Y = this.position.Y - (float)this.height;
				if (this.whoAmi == Main.myPlayer)
				{
					NetMessage.SendData(13, -1, -1, "", this.whoAmi, 0f, 0f, 0f, 0);
				}
			}
		}
		public void Mount(int m)
		{
			this.mountFlyTime = 0;
			if (this.mount == m)
			{
				return;
			}
			this.mount = m;
			if (this.mount == 1)
			{
				this.position.Y = this.position.Y + (float)this.height;
				this.height = 62;
				this.position.Y = this.position.Y - (float)this.height;
				for (int i = 0; i < 100; i++)
				{
					int num = Dust.NewDust(new Vector2(this.position.X - 20f, this.position.Y), this.width + 40, this.height, 57, 0f, 0f, 255, default(Color), 1f);
					Main.dust[num].scale += (float)Main.rand.Next(-10, 21) * 0.01f;
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num].scale *= 1.3f;
						Main.dust[num].noGravity = true;
					}
					else
					{
						Main.dust[num].velocity *= 0.5f;
					}
					Main.dust[num].velocity += this.velocity * 0.8f;
				}
				if (this.whoAmi == Main.myPlayer)
				{
					NetMessage.SendData(13, -1, -1, "", this.whoAmi, 0f, 0f, 0f, 0);
				}
			}
		}
		public void PutItemInInventory(int type, int selItem = -1)
		{
			if (selItem >= 0 && (this.inventory[selItem].type == 0 || this.inventory[selItem].stack <= 0))
			{
				this.inventory[selItem].SetDefaults(type, false);
				return;
			}
			Item item = new Item();
			item.SetDefaults(type, false);
			Item item2 = this.GetItem(this.whoAmi, item);
			if (item2.stack > 0)
			{
				int number = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, type, 1, false, 0, true);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number, 1f, 0f, 0f, 0);
					return;
				}
			}
			else
			{
				item.position.X = this.center().X - (float)(item.width / 2);
				item.position.Y = this.center().Y - (float)(item.height / 2);
				item.active = true;
				ItemText.NewText(item, 0);
			}
		}
		public bool SummonItemCheck()
		{
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].active && ((this.inventory[this.selectedItem].type == 43 && Main.npc[i].type == 4) || (this.inventory[this.selectedItem].type == 70 && Main.npc[i].type == 13) || ((this.inventory[this.selectedItem].type == 560 & Main.npc[i].type == 50) || (this.inventory[this.selectedItem].type == 544 && Main.npc[i].type == 125)) || (this.inventory[this.selectedItem].type == 544 && Main.npc[i].type == 126) || (this.inventory[this.selectedItem].type == 556 && Main.npc[i].type == 134) || (this.inventory[this.selectedItem].type == 557 && Main.npc[i].type == 127) || (this.inventory[this.selectedItem].type == 1133 && Main.npc[i].type == 222) || (this.inventory[this.selectedItem].type == 1331 && Main.npc[i].type == 266)))
				{
					return false;
				}
			}
			return true;
		}
		public void ItemCheck(int i)
		{
			if (this.frozen)
			{
				return;
			}
			bool flag = false;
			float num = 5E-06f;
			int num2 = this.inventory[this.selectedItem].damage;
			if (num2 > 0)
			{
				if (this.inventory[this.selectedItem].melee)
				{
					num2 = (int)((float)num2 * this.meleeDamage + num);
				}
				else
				{
					if (this.inventory[this.selectedItem].ranged)
					{
						num2 = (int)((float)num2 * this.rangedDamage + num);
						if (this.inventory[this.selectedItem].useAmmo == 1 || this.inventory[this.selectedItem].useAmmo == 323)
						{
							num2 = (int)((float)num2 * this.arrowDamage + num);
						}
						if (this.inventory[this.selectedItem].useAmmo == 14 || this.inventory[this.selectedItem].useAmmo == 311)
						{
							num2 = (int)((float)num2 * this.bulletDamage + num);
						}
						if (this.inventory[this.selectedItem].useAmmo == 771 || this.inventory[this.selectedItem].useAmmo == 246 || this.inventory[this.selectedItem].useAmmo == 312)
						{
							num2 = (int)((float)num2 * this.rocketDamage + num);
						}
					}
					else
					{
						if (this.inventory[this.selectedItem].magic)
						{
							num2 = (int)((float)num2 * this.magicDamage + num);
						}
					}
				}
			}
			if (this.inventory[this.selectedItem].autoReuse && !this.noItems)
			{
				this.releaseUseItem = true;
				if (this.itemAnimation == 1 && this.inventory[this.selectedItem].stack > 0)
				{
					if (this.inventory[this.selectedItem].shoot > 0 && this.whoAmi != Main.myPlayer && this.controlUseItem)
					{
						this.itemAnimation = 2;
					}
					else
					{
						this.itemAnimation = 0;
					}
				}
			}
			if (this.whoAmi == Main.myPlayer && this.mount > 0)
			{
				if (this.inventory[this.selectedItem].buffType != 90 && this.itemAnimation > 0)
				{
					this.Dismount();
				}
				if (this.gravDir == -1f)
				{
					this.Dismount();
				}
			}
			if (this.itemAnimation == 0 && this.reuseDelay > 0)
			{
				this.itemAnimation = this.reuseDelay;
				this.itemTime = this.reuseDelay;
				this.reuseDelay = 0;
			}
			if (this.controlUseItem && this.releaseUseItem && (this.inventory[this.selectedItem].headSlot > 0 || this.inventory[this.selectedItem].bodySlot > 0 || this.inventory[this.selectedItem].legSlot > 0))
			{
				if (this.inventory[this.selectedItem].useStyle == 0)
				{
					this.releaseUseItem = false;
				}
				if (this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f >= (float)Player.tileTargetY)
				{
					int num3 = Player.tileTargetX;
					int num4 = Player.tileTargetY;
					if (Main.tile[num3, num4].active() && (Main.tile[num3, num4].type == 128 || Main.tile[num3, num4].type == 269))
					{
						int num5 = (int)Main.tile[num3, num4].frameY;
						int j = 0;
						if (this.inventory[this.selectedItem].bodySlot >= 0)
						{
							j = 1;
						}
						if (this.inventory[this.selectedItem].legSlot >= 0)
						{
							j = 2;
						}
						num5 /= 18;
						while (j > num5)
						{
							num4++;
							num5 = (int)Main.tile[num3, num4].frameY;
							num5 /= 18;
						}
						while (j < num5)
						{
							num4--;
							num5 = (int)Main.tile[num3, num4].frameY;
							num5 /= 18;
						}
						int k;
						for (k = (int)Main.tile[num3, num4].frameX; k >= 100; k -= 100)
						{
						}
						if (k >= 36)
						{
							k -= 36;
						}
						num3 -= k / 18;
						int l = (int)Main.tile[num3, num4].frameX;
						WorldGen.KillTile(num3, num4, true, false, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(17, -1, -1, "", 0, (float)num3, (float)num4, 1f, 0);
						}
						while (l >= 100)
						{
							l -= 100;
						}
						if (num5 == 0 && this.inventory[this.selectedItem].headSlot >= 0)
						{
							Main.blockMouse = true;
							Main.tile[num3, num4].frameX = (short)(l + this.inventory[this.selectedItem].headSlot * 100);
							if (Main.netMode == 1)
							{
								NetMessage.SendTileSquare(-1, num3, num4, 1);
							}
							this.inventory[this.selectedItem].stack--;
							if (this.inventory[this.selectedItem].stack <= 0)
							{
								this.inventory[this.selectedItem].SetDefaults(0, false);
								Main.mouseItem.SetDefaults(0, false);
							}
							this.releaseUseItem = false;
							this.mouseInterface = true;
						}
						else
						{
							if (num5 == 1 && this.inventory[this.selectedItem].bodySlot >= 0)
							{
								Main.blockMouse = true;
								Main.tile[num3, num4].frameX = (short)(l + this.inventory[this.selectedItem].bodySlot * 100);
								if (Main.netMode == 1)
								{
									NetMessage.SendTileSquare(-1, num3, num4, 1);
								}
								this.inventory[this.selectedItem].stack--;
								if (this.inventory[this.selectedItem].stack <= 0)
								{
									this.inventory[this.selectedItem].SetDefaults(0, false);
									Main.mouseItem.SetDefaults(0, false);
								}
								this.releaseUseItem = false;
								this.mouseInterface = true;
							}
							else
							{
								if (num5 == 2 && this.inventory[this.selectedItem].legSlot >= 0)
								{
									Main.blockMouse = true;
									Main.tile[num3, num4].frameX = (short)(l + this.inventory[this.selectedItem].legSlot * 100);
									if (Main.netMode == 1)
									{
										NetMessage.SendTileSquare(-1, num3, num4, 1);
									}
									this.inventory[this.selectedItem].stack--;
									if (this.inventory[this.selectedItem].stack <= 0)
									{
										this.inventory[this.selectedItem].SetDefaults(0, false);
										Main.mouseItem.SetDefaults(0, false);
									}
									this.releaseUseItem = false;
									this.mouseInterface = true;
								}
							}
						}
					}
				}
			}
			if (this.controlUseItem && this.itemAnimation == 0 && this.releaseUseItem && this.inventory[this.selectedItem].useStyle > 0)
			{
				bool flag2 = true;
				if (this.inventory[this.selectedItem].shoot == 0)
				{
					this.itemRotation = 0f;
				}
				if (this.wet && (this.inventory[this.selectedItem].shoot == 85 || this.inventory[this.selectedItem].shoot == 15 || this.inventory[this.selectedItem].shoot == 34))
				{
					flag2 = false;
				}
				if (this.inventory[this.selectedItem].makeNPC > 0 && !NPC.CanReleaseNPCs(this.whoAmi))
				{
					flag2 = false;
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 603 && !Main.cEd)
				{
					flag2 = false;
				}
				if (this.inventory[this.selectedItem].type == 1071 || this.inventory[this.selectedItem].type == 1072)
				{
					bool flag3 = false;
					for (int m = 0; m < 58; m++)
					{
						if (this.inventory[m].paint > 0)
						{
							flag3 = true;
							break;
						}
					}
					if (!flag3)
					{
						flag2 = false;
					}
				}
				if (this.noItems)
				{
					flag2 = false;
				}
				if (this.inventory[this.selectedItem].tileWand > 0)
				{
					int tileWand = this.inventory[this.selectedItem].tileWand;
					flag2 = false;
					for (int n = 0; n < 58; n++)
					{
						if (tileWand == this.inventory[n].type && this.inventory[n].stack > 0)
						{
							flag2 = true;
							break;
						}
					}
				}
				if (this.inventory[this.selectedItem].shoot == 6 || this.inventory[this.selectedItem].shoot == 19 || this.inventory[this.selectedItem].shoot == 33 || this.inventory[this.selectedItem].shoot == 52 || this.inventory[this.selectedItem].shoot == 113 || this.inventory[this.selectedItem].shoot == 182 || this.inventory[this.selectedItem].shoot == 320 || this.inventory[this.selectedItem].shoot == 333)
				{
					for (int num6 = 0; num6 < 1000; num6++)
					{
						if (Main.projectile[num6].active && Main.projectile[num6].owner == Main.myPlayer && Main.projectile[num6].type == this.inventory[this.selectedItem].shoot)
						{
							flag2 = false;
						}
					}
				}
				if (this.inventory[this.selectedItem].shoot == 106)
				{
					int num7 = 0;
					for (int num8 = 0; num8 < 1000; num8++)
					{
						if (Main.projectile[num8].active && Main.projectile[num8].owner == Main.myPlayer && Main.projectile[num8].type == this.inventory[this.selectedItem].shoot)
						{
							num7++;
						}
					}
					if (num7 >= this.inventory[this.selectedItem].stack)
					{
						flag2 = false;
					}
				}
				if (this.inventory[this.selectedItem].shoot == 272)
				{
					int num9 = 0;
					for (int num10 = 0; num10 < 1000; num10++)
					{
						if (Main.projectile[num10].active && Main.projectile[num10].owner == Main.myPlayer && Main.projectile[num10].type == this.inventory[this.selectedItem].shoot)
						{
							num9++;
						}
					}
					if (num9 >= this.inventory[this.selectedItem].stack)
					{
						flag2 = false;
					}
				}
				if (this.inventory[this.selectedItem].shoot == 13 || this.inventory[this.selectedItem].shoot == 32 || (this.inventory[this.selectedItem].shoot >= 230 && this.inventory[this.selectedItem].shoot <= 235) || this.inventory[this.selectedItem].shoot == 315 || this.inventory[this.selectedItem].shoot == 331)
				{
					for (int num11 = 0; num11 < 1000; num11++)
					{
						if (Main.projectile[num11].active && Main.projectile[num11].owner == Main.myPlayer && Main.projectile[num11].type == this.inventory[this.selectedItem].shoot && Main.projectile[num11].ai[0] != 2f)
						{
							flag2 = false;
						}
					}
				}
				if (this.inventory[this.selectedItem].shoot == 332)
				{
					int num12 = 0;
					for (int num13 = 0; num13 < 1000; num13++)
					{
						if (Main.projectile[num13].active && Main.projectile[num13].owner == Main.myPlayer && Main.projectile[num13].type == this.inventory[this.selectedItem].shoot && Main.projectile[num13].ai[0] != 2f)
						{
							num12++;
						}
					}
					if (num12 >= 3)
					{
						flag2 = false;
					}
				}
				if (this.inventory[this.selectedItem].potion && flag2)
				{
					if (this.potionDelay <= 0)
					{
						this.potionDelay = this.potionDelayTime;
						this.AddBuff(21, this.potionDelay, true);
					}
					else
					{
						flag2 = false;
					}
				}
				if (this.inventory[this.selectedItem].mana > 0 && this.silence)
				{
					flag2 = false;
				}
				if (this.inventory[this.selectedItem].mana > 0 && flag2)
				{
					if (this.inventory[this.selectedItem].type != 127 || !this.spaceGun)
					{
						if (this.statMana >= (int)((float)this.inventory[this.selectedItem].mana * this.manaCost))
						{
							this.statMana -= (int)((float)this.inventory[this.selectedItem].mana * this.manaCost);
						}
						else
						{
							if (this.manaFlower)
							{
								this.QuickMana();
								if (this.statMana >= (int)((float)this.inventory[this.selectedItem].mana * this.manaCost))
								{
									this.statMana -= (int)((float)this.inventory[this.selectedItem].mana * this.manaCost);
								}
								else
								{
									flag2 = false;
								}
							}
							else
							{
								flag2 = false;
							}
						}
					}
					if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].buffType != 0 && flag2)
					{
						this.AddBuff(this.inventory[this.selectedItem].buffType, this.inventory[this.selectedItem].buffTime, true);
					}
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 603 && Main.cEd)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 669)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 115)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 425)
				{
					int num14 = Main.rand.Next(3);
					if (num14 == 0)
					{
						num14 = 27;
					}
					if (num14 == 1)
					{
						num14 = 101;
					}
					if (num14 == 2)
					{
						num14 = 102;
					}
					for (int num15 = 0; num15 < 22; num15++)
					{
						if (this.buffType[num15] == 27 || this.buffType[num15] == 101 || this.buffType[num15] == 102)
						{
							this.DelBuff(num15);
							num15--;
						}
					}
					this.AddBuff(num14, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 753)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 994)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 1169)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 1170)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 1171)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 1172)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 1180)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 1181)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 1182)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 1183)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 1242)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 1157)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 1309)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 1311)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 1837)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 1312)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 1798)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 1799)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 1802)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 1810)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 1927)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 1959)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.gravDir == 1f && this.inventory[this.selectedItem].type == 1914)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
					this.Mount(1);
				}
				if (this.inventory[this.selectedItem].type == 43 && Main.dayTime)
				{
					flag2 = false;
				}
				if (this.inventory[this.selectedItem].type == 544 && Main.dayTime)
				{
					flag2 = false;
				}
				if (this.inventory[this.selectedItem].type == 556 && Main.dayTime)
				{
					flag2 = false;
				}
				if (this.inventory[this.selectedItem].type == 557 && Main.dayTime)
				{
					flag2 = false;
				}
				if (this.inventory[this.selectedItem].type == 70 && !this.zoneEvil)
				{
					flag2 = false;
				}
				if (this.inventory[this.selectedItem].type == 1133 && !this.zoneJungle)
				{
					flag2 = false;
				}
				if (this.inventory[this.selectedItem].type == 1844 && (Main.dayTime || Main.pumpkinMoon || Main.snowMoon))
				{
					flag2 = false;
				}
				if (this.inventory[this.selectedItem].type == 1958 && (Main.dayTime || Main.pumpkinMoon || Main.snowMoon))
				{
					flag2 = false;
				}
				if (!this.SummonItemCheck())
				{
					flag2 = false;
				}
				if (this.inventory[this.selectedItem].shoot == 17 && flag2 && i == Main.myPlayer)
				{
					int num16 = (int)((float)Main.mouseX + Main.screenPosition.X) / 16;
					int num17 = (int)((float)Main.mouseY + Main.screenPosition.Y) / 16;
					Tile tile = Main.tile[num16, num17];
					if (tile.active() && (tile.type == 0 || tile.type == 2 || tile.type == 23 || tile.type == 109 || tile.type == 199))
					{
						WorldGen.KillTile(num16, num17, false, false, true);
						if (!Main.tile[num16, num17].active())
						{
							if (Main.netMode == 1)
							{
								NetMessage.SendData(17, -1, -1, "", 4, (float)num16, (float)num17, 0f, 0);
							}
						}
						else
						{
							flag2 = false;
						}
					}
					else
					{
						flag2 = false;
					}
				}
				if (flag2 && this.inventory[this.selectedItem].useAmmo > 0)
				{
					flag2 = false;
					for (int num18 = 0; num18 < 58; num18++)
					{
						if (this.inventory[num18].ammo == this.inventory[this.selectedItem].useAmmo && this.inventory[num18].stack > 0)
						{
							flag2 = true;
							break;
						}
					}
				}
				if (flag2)
				{
					if (this.inventory[this.selectedItem].pick > 0 || this.inventory[this.selectedItem].axe > 0 || this.inventory[this.selectedItem].hammer > 0)
					{
						this.toolTime = 1;
					}
					if (this.grappling[0] > -1)
					{
						this.pulley = false;
						this.pulleyDir = 1;
						if (this.controlRight)
						{
							this.direction = 1;
						}
						else
						{
							if (this.controlLeft)
							{
								this.direction = -1;
							}
						}
					}
					this.channel = this.inventory[this.selectedItem].channel;
					this.attackCD = 0;
					if (this.inventory[this.selectedItem].melee)
					{
						this.itemAnimation = (int)((float)this.inventory[this.selectedItem].useAnimation * this.meleeSpeed);
						this.itemAnimationMax = (int)((float)this.inventory[this.selectedItem].useAnimation * this.meleeSpeed);
					}
					else
					{
						if (this.inventory[this.selectedItem].createTile >= 0)
						{
							this.itemAnimation = (int)((float)this.inventory[this.selectedItem].useAnimation * this.tileSpeed);
							this.itemAnimationMax = (int)((float)this.inventory[this.selectedItem].useAnimation * this.tileSpeed);
						}
						else
						{
							if (this.inventory[this.selectedItem].createWall >= 0)
							{
								this.itemAnimation = (int)((float)this.inventory[this.selectedItem].useAnimation * this.wallSpeed);
								this.itemAnimationMax = (int)((float)this.inventory[this.selectedItem].useAnimation * this.wallSpeed);
							}
							else
							{
								this.itemAnimation = this.inventory[this.selectedItem].useAnimation;
								this.itemAnimationMax = this.inventory[this.selectedItem].useAnimation;
								this.reuseDelay = this.inventory[this.selectedItem].reuseDelay;
							}
						}
					}
					if (this.inventory[this.selectedItem].useSound > 0)
					{
						Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, this.inventory[this.selectedItem].useSound);
					}
				}
				if (flag2 && (this.inventory[this.selectedItem].shoot == 18 || this.inventory[this.selectedItem].shoot == 72 || this.inventory[this.selectedItem].shoot == 86 || this.inventory[this.selectedItem].shoot == 86 || Main.projPet[this.inventory[this.selectedItem].shoot]))
				{
					if ((this.inventory[this.selectedItem].shoot >= 191 && this.inventory[this.selectedItem].shoot <= 194) || this.inventory[this.selectedItem].shoot == 266 || this.inventory[this.selectedItem].shoot == 317)
					{
						int num19 = 0;
						int num20 = -1;
						int num21 = -1;
						for (int num22 = 0; num22 < 1000; num22++)
						{
							if (Main.projectile[num22].active && Main.projectile[num22].owner == i && Main.projectile[num22].minion)
							{
								num19++;
								if (num20 == -1 || Main.projectile[num22].timeLeft < num20)
								{
									num21 = num22;
									num20 = Main.projectile[num22].timeLeft;
								}
							}
						}
						if (num19 >= this.maxMinions)
						{
							Main.projectile[num21].Kill();
						}
					}
					else
					{
						for (int num23 = 0; num23 < 1000; num23++)
						{
							if (Main.projectile[num23].active && Main.projectile[num23].owner == i && Main.projectile[num23].type == this.inventory[this.selectedItem].shoot)
							{
								Main.projectile[num23].Kill();
							}
							if (this.inventory[this.selectedItem].shoot == 72)
							{
								if (Main.projectile[num23].active && Main.projectile[num23].owner == i && Main.projectile[num23].type == 86)
								{
									Main.projectile[num23].Kill();
								}
								if (Main.projectile[num23].active && Main.projectile[num23].owner == i && Main.projectile[num23].type == 87)
								{
									Main.projectile[num23].Kill();
								}
							}
						}
					}
				}
			}
			if (!this.controlUseItem)
			{
				bool arg_1DDC_0 = this.channel;
				this.channel = false;
			}
			if (this.itemAnimation > 0)
			{
				if (this.inventory[this.selectedItem].melee)
				{
					this.itemAnimationMax = (int)((float)this.inventory[this.selectedItem].useAnimation * this.meleeSpeed);
				}
				else
				{
					this.itemAnimationMax = this.inventory[this.selectedItem].useAnimation;
				}
				if (this.inventory[this.selectedItem].mana > 0 && !flag && (this.inventory[this.selectedItem].type != 127 || !this.spaceGun))
				{
					this.manaRegenDelay = (int)this.maxRegenDelay;
				}
				if (Main.dedServ)
				{
					this.itemHeight = this.inventory[this.selectedItem].height;
					this.itemWidth = this.inventory[this.selectedItem].width;
				}
				else
				{
					this.itemHeight = Main.itemTexture[this.inventory[this.selectedItem].type].Height;
					this.itemWidth = Main.itemTexture[this.inventory[this.selectedItem].type].Width;
				}
				this.itemAnimation--;
				if (!Main.dedServ)
				{
					if (this.inventory[this.selectedItem].useStyle == 1)
					{
						if (this.inventory[this.selectedItem].type == 1827)
						{
							if ((double)this.itemAnimation < (double)this.itemAnimationMax * 0.333)
							{
								float num24 = 10f;
								this.itemLocation.X = this.position.X + (float)this.width * 0.5f + ((float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f - num24) * (float)this.direction;
								this.itemLocation.Y = this.position.Y + 26f;
							}
							else
							{
								if ((double)this.itemAnimation < (double)this.itemAnimationMax * 0.666)
								{
									float num25 = 8f;
									this.itemLocation.X = this.position.X + (float)this.width * 0.5f + ((float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f - num25) * (float)this.direction;
									num25 = 24f;
									this.itemLocation.Y = this.position.Y + num25;
								}
								else
								{
									float num26 = 6f;
									this.itemLocation.X = this.position.X + (float)this.width * 0.5f - ((float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f - num26) * (float)this.direction;
									num26 = 20f;
									this.itemLocation.Y = this.position.Y + num26;
								}
							}
							this.itemRotation = ((float)this.itemAnimation / (float)this.itemAnimationMax - 0.5f) * (float)(-(float)this.direction) * 3.5f - (float)this.direction * 0.3f;
						}
						else
						{
							if ((double)this.itemAnimation < (double)this.itemAnimationMax * 0.333)
							{
								float num27 = 10f;
								if (Main.itemTexture[this.inventory[this.selectedItem].type].Width > 32)
								{
									num27 = 14f;
								}
								if (Main.itemTexture[this.inventory[this.selectedItem].type].Width >= 52)
								{
									num27 = 24f;
								}
								if (Main.itemTexture[this.inventory[this.selectedItem].type].Width >= 64)
								{
									num27 = 28f;
								}
								if (Main.itemTexture[this.inventory[this.selectedItem].type].Width >= 92)
								{
									num27 = 38f;
								}
								this.itemLocation.X = this.position.X + (float)this.width * 0.5f + ((float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f - num27) * (float)this.direction;
								this.itemLocation.Y = this.position.Y + 24f;
							}
							else
							{
								if ((double)this.itemAnimation < (double)this.itemAnimationMax * 0.666)
								{
									float num28 = 10f;
									if (Main.itemTexture[this.inventory[this.selectedItem].type].Width > 32)
									{
										num28 = 18f;
									}
									if (Main.itemTexture[this.inventory[this.selectedItem].type].Width >= 52)
									{
										num28 = 24f;
									}
									if (Main.itemTexture[this.inventory[this.selectedItem].type].Width >= 64)
									{
										num28 = 28f;
									}
									if (Main.itemTexture[this.inventory[this.selectedItem].type].Width >= 92)
									{
										num28 = 38f;
									}
									this.itemLocation.X = this.position.X + (float)this.width * 0.5f + ((float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f - num28) * (float)this.direction;
									num28 = 10f;
									if (Main.itemTexture[this.inventory[this.selectedItem].type].Height > 32)
									{
										num28 = 8f;
									}
									if (Main.itemTexture[this.inventory[this.selectedItem].type].Height >= 32)
									{
										num28 = 12f;
									}
									if (Main.itemTexture[this.inventory[this.selectedItem].type].Height > 64)
									{
										num28 = 14f;
									}
									this.itemLocation.Y = this.position.Y + num28;
								}
								else
								{
									float num29 = 6f;
									if (Main.itemTexture[this.inventory[this.selectedItem].type].Width > 32)
									{
										num29 = 14f;
									}
									if (Main.itemTexture[this.inventory[this.selectedItem].type].Width >= 52)
									{
										num29 = 24f;
									}
									if (Main.itemTexture[this.inventory[this.selectedItem].type].Width >= 64)
									{
										num29 = 28f;
									}
									if (Main.itemTexture[this.inventory[this.selectedItem].type].Width >= 92)
									{
										num29 = 38f;
									}
									this.itemLocation.X = this.position.X + (float)this.width * 0.5f - ((float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f - num29) * (float)this.direction;
									num29 = 10f;
									if (Main.itemTexture[this.inventory[this.selectedItem].type].Height > 32)
									{
										num29 = 10f;
									}
									if (Main.itemTexture[this.inventory[this.selectedItem].type].Height > 52)
									{
										num29 = 12f;
									}
									if (Main.itemTexture[this.inventory[this.selectedItem].type].Height > 64)
									{
										num29 = 14f;
									}
									this.itemLocation.Y = this.position.Y + num29;
								}
							}
							this.itemRotation = ((float)this.itemAnimation / (float)this.itemAnimationMax - 0.5f) * (float)(-(float)this.direction) * 3.5f - (float)this.direction * 0.3f;
						}
						if (this.gravDir == -1f)
						{
							this.itemRotation = -this.itemRotation;
							this.itemLocation.Y = this.position.Y + (float)this.height + (this.position.Y - this.itemLocation.Y);
						}
					}
					else
					{
						if (this.inventory[this.selectedItem].useStyle == 2)
						{
							this.itemRotation = (float)this.itemAnimation / (float)this.itemAnimationMax * (float)this.direction * 2f + -1.4f * (float)this.direction;
							if ((double)this.itemAnimation < (double)this.itemAnimationMax * 0.5)
							{
								this.itemLocation.X = this.position.X + (float)this.width * 0.5f + ((float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f - 9f - this.itemRotation * 12f * (float)this.direction) * (float)this.direction;
								this.itemLocation.Y = this.position.Y + 38f + this.itemRotation * (float)this.direction * 4f;
							}
							else
							{
								this.itemLocation.X = this.position.X + (float)this.width * 0.5f + ((float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f - 9f - this.itemRotation * 16f * (float)this.direction) * (float)this.direction;
								this.itemLocation.Y = this.position.Y + 38f + this.itemRotation * (float)this.direction;
							}
							if (this.gravDir == -1f)
							{
								this.itemRotation = -this.itemRotation;
								this.itemLocation.Y = this.position.Y + (float)this.height + (this.position.Y - this.itemLocation.Y);
							}
						}
						else
						{
							if (this.inventory[this.selectedItem].useStyle == 3)
							{
								if ((double)this.itemAnimation > (double)this.itemAnimationMax * 0.666)
								{
									this.itemLocation.X = -1000f;
									this.itemLocation.Y = -1000f;
									this.itemRotation = -1.3f * (float)this.direction;
								}
								else
								{
									this.itemLocation.X = this.position.X + (float)this.width * 0.5f + ((float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f - 4f) * (float)this.direction;
									this.itemLocation.Y = this.position.Y + 24f;
									float num30 = (float)this.itemAnimation / (float)this.itemAnimationMax * (float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * (float)this.direction * this.inventory[this.selectedItem].scale * 1.2f - (float)(10 * this.direction);
									if (num30 > -4f && this.direction == -1)
									{
										num30 = -8f;
									}
									if (num30 < 4f && this.direction == 1)
									{
										num30 = 8f;
									}
									this.itemLocation.X = this.itemLocation.X - num30;
									this.itemRotation = 0.8f * (float)this.direction;
								}
								if (this.gravDir == -1f)
								{
									this.itemRotation = -this.itemRotation;
									this.itemLocation.Y = this.position.Y + (float)this.height + (this.position.Y - this.itemLocation.Y);
								}
							}
							else
							{
								if (this.inventory[this.selectedItem].useStyle == 4)
								{
									this.itemRotation = 0f;
									this.itemLocation.X = this.position.X + (float)this.width * 0.5f + ((float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f - 9f - this.itemRotation * 14f * (float)this.direction - 4f) * (float)this.direction;
									this.itemLocation.Y = this.position.Y + (float)Main.itemTexture[this.inventory[this.selectedItem].type].Height * 0.5f + 4f;
									if (this.gravDir == -1f)
									{
										this.itemRotation = -this.itemRotation;
										this.itemLocation.Y = this.position.Y + (float)this.height + (this.position.Y - this.itemLocation.Y);
									}
								}
								else
								{
									if (this.inventory[this.selectedItem].useStyle == 5)
									{
										this.itemLocation.X = this.position.X + (float)this.width * 0.5f - (float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f - (float)(this.direction * 2);
										this.itemLocation.Y = this.position.Y + (float)this.height * 0.5f - (float)Main.itemTexture[this.inventory[this.selectedItem].type].Height * 0.5f;
									}
								}
							}
						}
					}
				}
			}
			else
			{
				if (this.inventory[this.selectedItem].holdStyle == 1 && !this.pulley && this.mount == 0)
				{
					if (Main.dedServ)
					{
						this.itemLocation.X = this.position.X + (float)this.width * 0.5f + 20f * (float)this.direction;
					}
					else
					{
						if (this.inventory[this.selectedItem].type == 930)
						{
							this.itemLocation.X = this.position.X + (float)(this.width / 2) * 0.5f - 12f - (float)(2 * this.direction);
							float num31 = this.position.X + (float)(this.width / 2) + (float)(38 * this.direction);
							if (this.direction == 1)
							{
								num31 -= 10f;
							}
							float num32 = this.position.Y + (float)(this.height / 2) - 4f * this.gravDir;
							if (this.gravDir == -1f)
							{
								num32 -= 8f;
							}
							int num33 = 0;
							for (int num34 = 54; num34 < 58; num34++)
							{
								if (this.inventory[num34].stack > 0 && this.inventory[num34].ammo == 931)
								{
									num33 = this.inventory[num34].type;
									break;
								}
							}
							if (num33 == 0)
							{
								for (int num35 = 0; num35 < 54; num35++)
								{
									if (this.inventory[num35].stack > 0 && this.inventory[num35].ammo == 931)
									{
										num33 = this.inventory[num35].type;
										break;
									}
								}
							}
							if (num33 == 931)
							{
								num33 = 127;
							}
							else
							{
								if (num33 == 1614)
								{
									num33 = 187;
								}
							}
							if (num33 > 0)
							{
								int num36 = Dust.NewDust(new Vector2(num31, num32 + this.gfxOffY), 6, 6, num33, 0f, 0f, 100, default(Color), 1.6f);
								Main.dust[num36].noGravity = true;
								Dust expr_2E4F_cp_0 = Main.dust[num36];
								expr_2E4F_cp_0.velocity.Y = expr_2E4F_cp_0.velocity.Y - 4f * this.gravDir;
							}
						}
						else
						{
							if (this.inventory[this.selectedItem].type == 968)
							{
								this.itemLocation.X = this.position.X + (float)this.width * 0.5f + (float)(8 * this.direction);
								if (this.whoAmi == Main.myPlayer)
								{
									int num37 = (int)(this.itemLocation.X + (float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.8f * (float)this.direction) / 16;
									int num38 = (int)(this.itemLocation.Y + (float)(Main.itemTexture[this.inventory[this.selectedItem].type].Height / 2)) / 16;
									if (Main.tile[num37, num38] == null)
									{
										Main.tile[num37, num38] = new Tile();
									}
									if (Main.tile[num37, num38].active() && Main.tile[num37, num38].type == 215)
									{
										this.miscTimer++;
										if (Main.rand.Next(5) == 0)
										{
											this.miscTimer++;
										}
										if (this.miscTimer > 900)
										{
											this.miscTimer = 0;
											this.inventory[this.selectedItem].SetDefaults(969, false);
											if (this.selectedItem == 58)
											{
												Main.mouseItem.SetDefaults(969, false);
											}
											for (int num39 = 0; num39 < 58; num39++)
											{
												if (this.inventory[num39].type == this.inventory[this.selectedItem].type && num39 != this.selectedItem && this.inventory[num39].stack < this.inventory[num39].maxStack)
												{
													Main.PlaySound(7, -1, -1, 1);
													this.inventory[num39].stack++;
													this.inventory[this.selectedItem].SetDefaults(0, false);
													if (this.selectedItem == 58)
													{
														Main.mouseItem.SetDefaults(0, false);
													}
												}
											}
										}
									}
									else
									{
										this.miscTimer = 0;
									}
								}
							}
							else
							{
								if (this.inventory[this.selectedItem].type == 856)
								{
									this.itemLocation.X = this.position.X + (float)this.width * 0.5f + (float)(4 * this.direction);
								}
								else
								{
									this.itemLocation.X = this.position.X + (float)this.width * 0.5f + ((float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f + 2f) * (float)this.direction;
									if (this.inventory[this.selectedItem].type == 282 || this.inventory[this.selectedItem].type == 286)
									{
										this.itemLocation.X = this.itemLocation.X - (float)(this.direction * 2);
										this.itemLocation.Y = this.itemLocation.Y + 4f;
									}
								}
							}
						}
					}
					this.itemLocation.Y = this.position.Y + 24f;
					if (this.inventory[this.selectedItem].type == 856)
					{
						this.itemLocation.Y = this.position.Y + 34f;
					}
					if (this.inventory[this.selectedItem].type == 930)
					{
						this.itemLocation.Y = this.position.Y + 9f;
					}
					this.itemRotation = 0f;
					if (this.gravDir == -1f)
					{
						this.itemRotation = -this.itemRotation;
						this.itemLocation.Y = this.position.Y + (float)this.height + (this.position.Y - this.itemLocation.Y);
						if (this.inventory[this.selectedItem].type == 930)
						{
							this.itemLocation.Y = this.itemLocation.Y - 24f;
						}
					}
				}
				else
				{
					if (this.inventory[this.selectedItem].holdStyle == 2 && !this.pulley && this.mount == 0)
					{
						if (this.inventory[this.selectedItem].type == 946)
						{
							this.itemRotation = 0f;
							this.itemLocation.X = this.position.X + (float)this.width * 0.5f - (float)(16 * this.direction);
							this.itemLocation.Y = this.position.Y + 22f;
							this.fallStart = (int)(this.position.Y / 16f);
							if (this.gravDir == -1f)
							{
								this.itemRotation = -this.itemRotation;
								this.itemLocation.Y = this.position.Y + (float)this.height + (this.position.Y - this.itemLocation.Y);
								if (this.velocity.Y < -2f)
								{
									this.velocity.Y = -2f;
								}
							}
							else
							{
								if (this.velocity.Y > 2f)
								{
									this.velocity.Y = 2f;
								}
							}
						}
						else
						{
							this.itemLocation.X = this.position.X + (float)this.width * 0.5f + (float)(6 * this.direction);
							this.itemLocation.Y = this.position.Y + 16f;
							this.itemRotation = 0.79f * (float)(-(float)this.direction);
							if (this.gravDir == -1f)
							{
								this.itemRotation = -this.itemRotation;
								this.itemLocation.Y = this.position.Y + (float)this.height + (this.position.Y - this.itemLocation.Y);
							}
						}
					}
					else
					{
						if (this.inventory[this.selectedItem].holdStyle == 3 && !this.pulley && this.mount == 0 && !Main.dedServ)
						{
							this.itemLocation.X = this.position.X + (float)this.width * 0.5f - (float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f - (float)(this.direction * 2);
							this.itemLocation.Y = this.position.Y + (float)this.height * 0.5f - (float)Main.itemTexture[this.inventory[this.selectedItem].type].Height * 0.5f;
							this.itemRotation = 0f;
						}
					}
				}
			}
			if ((((this.inventory[this.selectedItem].type == 974 || this.inventory[this.selectedItem].type == 8 || this.inventory[this.selectedItem].type == 1245 || this.inventory[this.selectedItem].type == 2274 || (this.inventory[this.selectedItem].type >= 427 && this.inventory[this.selectedItem].type <= 433)) && !this.wet) || this.inventory[this.selectedItem].type == 523 || this.inventory[this.selectedItem].type == 1333) && !this.pulley && this.mount == 0)
			{
				float num40 = 1f;
				float num41 = 0.95f;
				float num42 = 0.8f;
				int num43 = 0;
				if (this.inventory[this.selectedItem].type == 523)
				{
					num43 = 8;
				}
				else
				{
					if (this.inventory[this.selectedItem].type == 974)
					{
						num43 = 9;
					}
					else
					{
						if (this.inventory[this.selectedItem].type == 1245)
						{
							num43 = 10;
						}
						else
						{
							if (this.inventory[this.selectedItem].type == 1333)
							{
								num43 = 11;
							}
							else
							{
								if (this.inventory[this.selectedItem].type == 2274)
								{
									num43 = 12;
								}
								else
								{
									if (this.inventory[this.selectedItem].type >= 427)
									{
										num43 = this.inventory[this.selectedItem].type - 426;
									}
								}
							}
						}
					}
				}
				if (num43 == 1)
				{
					num40 = 0f;
					num41 = 0.1f;
					num42 = 1.3f;
				}
				else
				{
					if (num43 == 2)
					{
						num40 = 1f;
						num41 = 0.1f;
						num42 = 0.1f;
					}
					else
					{
						if (num43 == 3)
						{
							num40 = 0f;
							num41 = 1f;
							num42 = 0.1f;
						}
						else
						{
							if (num43 == 4)
							{
								num40 = 0.9f;
								num41 = 0f;
								num42 = 0.9f;
							}
							else
							{
								if (num43 == 5)
								{
									num40 = 1.3f;
									num41 = 1.3f;
									num42 = 1.3f;
								}
								else
								{
									if (num43 == 6)
									{
										num40 = 0.9f;
										num41 = 0.9f;
										num42 = 0f;
									}
									else
									{
										if (num43 == 7)
										{
											num40 = 0.5f * Main.demonTorch + 1f * (1f - Main.demonTorch);
											num41 = 0.3f;
											num42 = 1f * Main.demonTorch + 0.5f * (1f - Main.demonTorch);
										}
										else
										{
											if (num43 == 8)
											{
												num42 = 0.7f;
												num40 = 0.85f;
												num41 = 1f;
											}
											else
											{
												if (num43 == 9)
												{
													num42 = 1f;
													num40 = 0.7f;
													num41 = 0.85f;
												}
												else
												{
													if (num43 == 10)
													{
														num42 = 0f;
														num40 = 1f;
														num41 = 0.5f;
													}
													else
													{
														if (num43 == 11)
														{
															num42 = 0.8f;
															num40 = 1.25f;
															num41 = 1.25f;
														}
														else
														{
															if (num43 == 12)
															{
																num40 *= 0.75f;
																num41 *= 1.3499999f;
																num42 *= 1.5f;
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
				int num44 = num43;
				if (num44 == 0)
				{
					num44 = 6;
				}
				else
				{
					if (num44 == 8)
					{
						num44 = 75;
					}
					else
					{
						if (num44 == 9)
						{
							num44 = 135;
						}
						else
						{
							if (num44 == 10)
							{
								num44 = 158;
							}
							else
							{
								if (num44 == 11)
								{
									num44 = 169;
								}
								else
								{
									if (num44 == 12)
									{
										num44 = 156;
									}
									else
									{
										num44 = 58 + num44;
									}
								}
							}
						}
					}
				}
				int maxValue = 30;
				if (this.itemAnimation > 0)
				{
					maxValue = 7;
				}
				if (this.direction == -1)
				{
					if (Main.rand.Next(maxValue) == 0)
					{
						int num45 = Dust.NewDust(new Vector2(this.itemLocation.X - 16f, this.itemLocation.Y - 14f * this.gravDir), 4, 4, num44, 0f, 0f, 100, default(Color), 1f);
						if (Main.rand.Next(3) != 0)
						{
							Main.dust[num45].noGravity = true;
						}
						Main.dust[num45].velocity *= 0.3f;
						Dust expr_3A64_cp_0 = Main.dust[num45];
						expr_3A64_cp_0.velocity.Y = expr_3A64_cp_0.velocity.Y - 1.5f;
					}
					Lighting.addLight((int)((this.itemLocation.X - 12f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f + this.velocity.Y) / 16f), num40, num41, num42);
				}
				else
				{
					if (Main.rand.Next(maxValue) == 0)
					{
						int num46 = Dust.NewDust(new Vector2(this.itemLocation.X + 6f, this.itemLocation.Y - 14f * this.gravDir), 4, 4, num44, 0f, 0f, 100, default(Color), 1f);
						if (Main.rand.Next(3) != 0)
						{
							Main.dust[num46].noGravity = true;
						}
						Main.dust[num46].velocity *= 0.3f;
						Dust expr_3B7B_cp_0 = Main.dust[num46];
						expr_3B7B_cp_0.velocity.Y = expr_3B7B_cp_0.velocity.Y - 1.5f;
					}
					Lighting.addLight((int)((this.itemLocation.X + 12f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f + this.velocity.Y) / 16f), num40, num41, num42);
				}
			}
			if ((this.inventory[this.selectedItem].type == 105 || this.inventory[this.selectedItem].type == 713) && !this.wet && !this.pulley)
			{
				int maxValue2 = 20;
				if (this.itemAnimation > 0)
				{
					maxValue2 = 7;
				}
				if (this.direction == -1)
				{
					if (Main.rand.Next(maxValue2) == 0)
					{
						int num47 = Dust.NewDust(new Vector2(this.itemLocation.X - 12f, this.itemLocation.Y - 20f * this.gravDir), 4, 4, 6, 0f, 0f, 100, default(Color), 1f);
						if (Main.rand.Next(3) != 0)
						{
							Main.dust[num47].noGravity = true;
						}
						Main.dust[num47].velocity *= 0.3f;
						Dust expr_3CF0_cp_0 = Main.dust[num47];
						expr_3CF0_cp_0.velocity.Y = expr_3CF0_cp_0.velocity.Y - 1.5f;
					}
					Lighting.addLight((int)((this.itemLocation.X - 16f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f) / 16f), 1f, 0.95f, 0.8f);
				}
				else
				{
					if (Main.rand.Next(maxValue2) == 0)
					{
						int num48 = Dust.NewDust(new Vector2(this.itemLocation.X + 4f, this.itemLocation.Y - 20f * this.gravDir), 4, 4, 6, 0f, 0f, 100, default(Color), 1f);
						if (Main.rand.Next(3) != 0)
						{
							Main.dust[num48].noGravity = true;
						}
						Main.dust[num48].velocity *= 0.3f;
						Dust expr_3E03_cp_0 = Main.dust[num48];
						expr_3E03_cp_0.velocity.Y = expr_3E03_cp_0.velocity.Y - 1.5f;
					}
					Lighting.addLight((int)((this.itemLocation.X + 6f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f) / 16f), 1f, 0.95f, 0.8f);
				}
			}
			else
			{
				if (this.inventory[this.selectedItem].type == 148 && !this.wet)
				{
					int maxValue3 = 10;
					if (this.itemAnimation > 0)
					{
						maxValue3 = 7;
					}
					if (this.direction == -1)
					{
						if (Main.rand.Next(maxValue3) == 0)
						{
							int num49 = Dust.NewDust(new Vector2(this.itemLocation.X - 12f, this.itemLocation.Y - 20f * this.gravDir), 4, 4, 172, 0f, 0f, 100, default(Color), 1f);
							if (Main.rand.Next(3) != 0)
							{
								Main.dust[num49].noGravity = true;
							}
							Main.dust[num49].velocity *= 0.3f;
							Dust expr_3F5D_cp_0 = Main.dust[num49];
							expr_3F5D_cp_0.velocity.Y = expr_3F5D_cp_0.velocity.Y - 1.5f;
						}
						Lighting.addLight((int)((this.itemLocation.X - 16f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f) / 16f), 0f, 0.5f, 1f);
					}
					else
					{
						if (Main.rand.Next(maxValue3) == 0)
						{
							int num50 = Dust.NewDust(new Vector2(this.itemLocation.X + 4f, this.itemLocation.Y - 20f * this.gravDir), 4, 4, 172, 0f, 0f, 100, default(Color), 1f);
							if (Main.rand.Next(3) != 0)
							{
								Main.dust[num50].noGravity = true;
							}
							Main.dust[num50].velocity *= 0.3f;
							Dust expr_4074_cp_0 = Main.dust[num50];
							expr_4074_cp_0.velocity.Y = expr_4074_cp_0.velocity.Y - 1.5f;
						}
						Lighting.addLight((int)((this.itemLocation.X + 6f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f) / 16f), 0f, 0.5f, 1f);
					}
				}
			}
			if (this.inventory[this.selectedItem].type == 282 && !this.pulley)
			{
				if (this.direction == -1)
				{
					Lighting.addLight((int)((this.itemLocation.X - 16f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f) / 16f), 0.7f, 1f, 0.8f);
				}
				else
				{
					Lighting.addLight((int)((this.itemLocation.X + 6f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f) / 16f), 0.7f, 1f, 0.8f);
				}
			}
			if (this.inventory[this.selectedItem].type == 286 && !this.pulley)
			{
				if (this.direction == -1)
				{
					Lighting.addLight((int)((this.itemLocation.X - 16f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f) / 16f), 0.7f, 0.8f, 1f);
				}
				else
				{
					Lighting.addLight((int)((this.itemLocation.X + 6f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f) / 16f), 0.7f, 0.8f, 1f);
				}
			}
			if (this.controlUseItem)
			{
				this.releaseUseItem = false;
			}
			else
			{
				this.releaseUseItem = true;
			}
			if (this.itemTime > 0)
			{
				this.itemTime--;
				if (this.itemTime == 0 && this.whoAmi == Main.myPlayer)
				{
					int type = this.inventory[this.selectedItem].type;
					if (type == 65 || type == 676 || type == 723 || type == 724 || type == 989 || type == 1226 || type == 1227)
					{
						Main.PlaySound(25, -1, -1, 1);
						for (int num51 = 0; num51 < 5; num51++)
						{
							int num52 = Dust.NewDust(this.position, this.width, this.height, 45, 0f, 0f, 255, default(Color), (float)Main.rand.Next(20, 26) * 0.1f);
							Main.dust[num52].noLight = true;
							Main.dust[num52].noGravity = true;
							Main.dust[num52].velocity *= 0.5f;
						}
					}
				}
			}
			if (i == Main.myPlayer)
			{
				bool flag4 = true;
				int type2 = this.inventory[this.selectedItem].type;
				if ((type2 == 65 || type2 == 676 || type2 == 723 || type2 == 724 || type2 == 757 || type2 == 674 || type2 == 675 || type2 == 989 || type2 == 1226 || type2 == 1227) && this.itemAnimation != this.itemAnimationMax - 1)
				{
					flag4 = false;
				}
				if (this.inventory[this.selectedItem].shoot > 0 && this.itemAnimation > 0 && this.itemTime == 0 && flag4)
				{
					int num53 = this.inventory[this.selectedItem].shoot;
					float num54 = this.inventory[this.selectedItem].shootSpeed;
					if (this.inventory[this.selectedItem].melee && num53 != 25 && num53 != 26 && num53 != 35)
					{
						num54 /= this.meleeSpeed;
					}
					bool flag5 = false;
					int num55 = num2;
					float num56 = this.inventory[this.selectedItem].knockBack;
					if (num53 == 13 || num53 == 32 || num53 == 315 || (num53 >= 230 && num53 <= 235) || num53 == 331)
					{
						this.grappling[0] = -1;
						this.grapCount = 0;
						for (int num57 = 0; num57 < 1000; num57++)
						{
							if (Main.projectile[num57].active && Main.projectile[num57].owner == i)
							{
								if (Main.projectile[num57].type == 13)
								{
									Main.projectile[num57].Kill();
								}
								if (Main.projectile[num57].type == 331)
								{
									Main.projectile[num57].Kill();
								}
								if (Main.projectile[num57].type == 315)
								{
									Main.projectile[num57].Kill();
								}
								if (Main.projectile[num57].type >= 230 && Main.projectile[num57].type <= 235)
								{
									Main.projectile[num57].Kill();
								}
							}
						}
					}
					if (this.inventory[this.selectedItem].useAmmo > 0)
					{
						Item item = new Item();
						bool flag6 = false;
						for (int num58 = 54; num58 < 58; num58++)
						{
							if (this.inventory[num58].ammo == this.inventory[this.selectedItem].useAmmo && this.inventory[num58].stack > 0)
							{
								item = this.inventory[num58];
								flag5 = true;
								flag6 = true;
								break;
							}
						}
						if (!flag6)
						{
							for (int num59 = 0; num59 < 54; num59++)
							{
								if (this.inventory[num59].ammo == this.inventory[this.selectedItem].useAmmo && this.inventory[num59].stack > 0)
								{
									item = this.inventory[num59];
									flag5 = true;
									break;
								}
							}
						}
						if (flag5)
						{
							if (this.inventory[this.selectedItem].type == 1946)
							{
								num53 = 338 + item.type - 771;
							}
							else
							{
								if (this.inventory[this.selectedItem].useAmmo == 771)
								{
									num53 += item.shoot;
								}
								else
								{
									if (this.inventory[this.selectedItem].useAmmo == 780)
									{
										num53 += item.shoot;
									}
									else
									{
										if (item.shoot > 0)
										{
											num53 = item.shoot;
										}
									}
								}
							}
							if (num53 == 42)
							{
								if (item.type == 370)
								{
									num53 = 65;
									num55 += 5;
								}
								else
								{
									if (item.type == 408)
									{
										num53 = 68;
										num55 += 5;
									}
									else
									{
										if (item.type == 1246)
										{
											num53 = 354;
											num55 += 5;
										}
									}
								}
							}
							if (this.magicQuiver && (this.inventory[this.selectedItem].useAmmo == 1 || this.inventory[this.selectedItem].useAmmo == 323))
							{
								num56 = (float)((int)((double)num56 * 1.1));
								num54 *= 1.1f;
							}
							num54 += item.shootSpeed;
							if (item.ranged)
							{
								if (item.damage > 0)
								{
									num55 += (int)((float)item.damage * this.rangedDamage);
								}
							}
							else
							{
								num55 += item.damage;
							}
							if (this.inventory[this.selectedItem].useAmmo == 1 && this.archery)
							{
								if (num54 < 20f)
								{
									num54 *= 1.2f;
									if (num54 > 20f)
									{
										num54 = 20f;
									}
								}
								num55 = (int)((double)((float)num55) * 1.2);
							}
							num56 += item.knockBack;
							bool flag7 = false;
							if (this.magicQuiver && this.inventory[this.selectedItem].useAmmo == 1 && Main.rand.Next(5) == 0)
							{
								flag7 = true;
							}
							if (this.ammoBox && Main.rand.Next(5) == 0)
							{
								flag7 = true;
							}
							if (this.inventory[this.selectedItem].type == 1782 && Main.rand.Next(3) == 0)
							{
								flag7 = true;
							}
							if (this.inventory[this.selectedItem].type == 98 && Main.rand.Next(3) == 0)
							{
								flag7 = true;
							}
							if (this.inventory[this.selectedItem].type == 2270 && Main.rand.Next(2) == 0)
							{
								flag7 = true;
							}
							if (this.inventory[this.selectedItem].type == 533 && Main.rand.Next(2) == 0)
							{
								flag7 = true;
							}
							if (this.inventory[this.selectedItem].type == 1929 && Main.rand.Next(2) == 0)
							{
								flag7 = true;
							}
							if (this.inventory[this.selectedItem].type == 1553 && Main.rand.Next(2) == 0)
							{
								flag7 = true;
							}
							if (this.inventory[this.selectedItem].type == 434 && this.itemAnimation < this.inventory[this.selectedItem].useAnimation - 2)
							{
								flag7 = true;
							}
							if (this.ammoCost80 && Main.rand.Next(5) == 0)
							{
								flag7 = true;
							}
							if (this.ammoCost75 && Main.rand.Next(4) == 0)
							{
								flag7 = true;
							}
							if (num53 == 85 && this.itemAnimation < this.itemAnimationMax - 6)
							{
								flag7 = true;
							}
							if ((num53 == 145 || num53 == 146 || num53 == 147 || num53 == 148 || num53 == 149) && this.itemAnimation < this.itemAnimationMax - 5)
							{
								flag7 = true;
							}
							if (!flag7)
							{
								item.stack--;
								if (item.stack <= 0)
								{
									item.active = false;
									item.name = "";
									item.type = 0;
								}
							}
						}
					}
					else
					{
						flag5 = true;
					}
					if (this.inventory[this.selectedItem].type == 1254 && num53 == 14)
					{
						num53 = 242;
					}
					if (this.inventory[this.selectedItem].type == 1255 && num53 == 14)
					{
						num53 = 242;
					}
					if (this.inventory[this.selectedItem].type == 1265 && num53 == 14)
					{
						num53 = 242;
					}
					if (num53 == 73)
					{
						for (int num60 = 0; num60 < 1000; num60++)
						{
							if (Main.projectile[num60].active && Main.projectile[num60].owner == i)
							{
								if (Main.projectile[num60].type == 73)
								{
									num53 = 74;
								}
								if (num53 == 74 && Main.projectile[num60].type == 74)
								{
									flag5 = false;
								}
							}
						}
					}
					if (flag5)
					{
						if (this.inventory[this.selectedItem].summon)
						{
							num56 += this.minionKB;
							num55 = (int)((float)num55 * this.minionDamage);
						}
						if (num53 == 228)
						{
							num56 = 0f;
						}
						if (this.inventory[this.selectedItem].mech && this.kbGlove)
						{
							num56 *= 1.7f;
						}
						if (this.inventory[this.selectedItem].ranged && this.armorSteath)
						{
							num56 *= 1f + (1f - this.stealth) * 0.5f;
						}
						if (num53 == 1 && this.inventory[this.selectedItem].type == 120)
						{
							num53 = 2;
						}
						if (this.inventory[this.selectedItem].type == 682)
						{
							num53 = 117;
						}
						if (this.inventory[this.selectedItem].type == 725)
						{
							num53 = 120;
						}
						if (this.inventory[this.selectedItem].type == 2223)
						{
							num53 = 357;
						}
						this.itemTime = this.inventory[this.selectedItem].useTime;
						if ((float)Main.mouseX + Main.screenPosition.X > this.position.X + (float)this.width * 0.5f)
						{
							this.ChangeDir(1);
						}
						else
						{
							this.ChangeDir(-1);
						}
						Vector2 vector = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						if (num53 == 9)
						{
							vector = new Vector2(this.position.X + (float)this.width * 0.5f + (float)(Main.rand.Next(201) * -(float)this.direction) + ((float)Main.mouseX + Main.screenPosition.X - this.position.X), this.position.Y + (float)this.height * 0.5f - 600f);
							num56 = 0f;
							num55 *= 2;
						}
						else
						{
							if (num53 == 51)
							{
								vector.Y -= 6f * this.gravDir;
							}
						}
						float num61 = (float)Main.mouseX + Main.screenPosition.X - vector.X;
						float num62 = (float)Main.mouseY + Main.screenPosition.Y - vector.Y;
						if (this.gravDir == -1f)
						{
							num62 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector.Y;
						}
						float num63 = (float)Math.Sqrt((double)(num61 * num61 + num62 * num62));
						float num64 = num63;
						num63 = num54 / num63;
						if (this.inventory[this.selectedItem].type == 1929 || this.inventory[this.selectedItem].type == 2270)
						{
							num61 += (float)Main.rand.Next(-50, 51) * 0.03f / num63;
							num62 += (float)Main.rand.Next(-50, 51) * 0.03f / num63;
						}
						num61 *= num63;
						num62 *= num63;
						if (this.inventory[this.selectedItem].type == 757)
						{
							num55 = (int)((float)num55 * 1.25f);
						}
						if (num53 == 250)
						{
							for (int num65 = 0; num65 < 1000; num65++)
							{
								if (Main.projectile[num65].active && Main.projectile[num65].owner == this.whoAmi && (Main.projectile[num65].type == 250 || Main.projectile[num65].type == 251))
								{
									Main.projectile[num65].Kill();
								}
							}
						}
						if (num53 == 12)
						{
							vector.X += num61 * 3f;
							vector.Y += num62 * 3f;
						}
						if (this.inventory[this.selectedItem].useStyle == 5)
						{
							this.itemRotation = (float)Math.Atan2((double)(num62 * (float)this.direction), (double)(num61 * (float)this.direction));
							NetMessage.SendData(13, -1, -1, "", this.whoAmi, 0f, 0f, 0f, 0);
							NetMessage.SendData(41, -1, -1, "", this.whoAmi, 0f, 0f, 0f, 0);
						}
						if (num53 == 17)
						{
							vector.X = (float)Main.mouseX + Main.screenPosition.X;
							vector.Y = (float)Main.mouseY + Main.screenPosition.Y;
						}
						if (num53 == 76)
						{
							num53 += Main.rand.Next(3);
							num64 /= (float)(Main.screenHeight / 2);
							if (num64 > 1f)
							{
								num64 = 1f;
							}
							float num66 = num61 + (float)Main.rand.Next(-40, 41) * 0.01f;
							float num67 = num62 + (float)Main.rand.Next(-40, 41) * 0.01f;
							num66 *= num64 + 0.25f;
							num67 *= num64 + 0.25f;
							int num68 = Projectile.NewProjectile(vector.X, vector.Y, num66, num67, num53, num55, num56, i, 0f, 0f);
							Main.projectile[num68].ai[1] = 1f;
							num64 = num64 * 2f - 1f;
							if (num64 < -1f)
							{
								num64 = -1f;
							}
							if (num64 > 1f)
							{
								num64 = 1f;
							}
							Main.projectile[num68].ai[0] = num64;
							NetMessage.SendData(27, -1, -1, "", num68, 0f, 0f, 0f, 0);
						}
						else
						{
							if (this.inventory[this.selectedItem].type == 98 || this.inventory[this.selectedItem].type == 533)
							{
								float speedX = num61 + (float)Main.rand.Next(-40, 41) * 0.01f;
								float speedY = num62 + (float)Main.rand.Next(-40, 41) * 0.01f;
								Projectile.NewProjectile(vector.X, vector.Y, speedX, speedY, num53, num55, num56, i, 0f, 0f);
							}
							else
							{
								if (this.inventory[this.selectedItem].type == 2270)
								{
									float num69 = num61 + (float)Main.rand.Next(-40, 41) * 0.05f;
									float num70 = num62 + (float)Main.rand.Next(-40, 41) * 0.05f;
									if (Main.rand.Next(3) == 0)
									{
										num69 *= 1f + (float)Main.rand.Next(-30, 31) * 0.02f;
										num70 *= 1f + (float)Main.rand.Next(-30, 31) * 0.02f;
									}
									Projectile.NewProjectile(vector.X, vector.Y, num69, num70, num53, num55, num56, i, 0f, 0f);
								}
								else
								{
									if (this.inventory[this.selectedItem].type == 1930)
									{
										int num71 = 2 + Main.rand.Next(3);
										for (int num72 = 0; num72 < num71; num72++)
										{
											float num73 = num61;
											float num74 = num62;
											float num75 = 0.025f * (float)num72;
											num73 += (float)Main.rand.Next(-35, 36) * num75;
											num74 += (float)Main.rand.Next(-35, 36) * num75;
											num63 = (float)Math.Sqrt((double)(num73 * num73 + num74 * num74));
											num63 = num54 / num63;
											num73 *= num63;
											num74 *= num63;
											float x = vector.X + num61 * (float)(num71 - num72) * 1.75f;
											float y = vector.Y + num62 * (float)(num71 - num72) * 1.75f;
											Projectile.NewProjectile(x, y, num73, num74, num53, num55, num56, i, (float)Main.rand.Next(0, 10 * (num72 + 1)), 0f);
										}
									}
									else
									{
										if (this.inventory[this.selectedItem].type == 1931)
										{
											int num76 = 2;
											for (int num77 = 0; num77 < num76; num77++)
											{
												vector = new Vector2(this.position.X + (float)this.width * 0.5f + (float)(Main.rand.Next(201) * -(float)this.direction) + ((float)Main.mouseX + Main.screenPosition.X - this.position.X), this.position.Y + (float)this.height * 0.5f - 600f);
												vector.X = (vector.X + this.center().X) / 2f + (float)Main.rand.Next(-200, 201);
												vector.Y -= (float)(100 * num77);
												num61 = (float)Main.mouseX + Main.screenPosition.X - vector.X;
												num62 = (float)Main.mouseY + Main.screenPosition.Y - vector.Y;
												if (num62 < 0f)
												{
													num62 *= -1f;
												}
												if (num62 < 20f)
												{
													num62 = 20f;
												}
												num63 = (float)Math.Sqrt((double)(num61 * num61 + num62 * num62));
												num63 = num54 / num63;
												num61 *= num63;
												num62 *= num63;
												float speedX2 = num61 + (float)Main.rand.Next(-40, 41) * 0.02f;
												float speedY2 = num62 + (float)Main.rand.Next(-40, 41) * 0.02f;
												Projectile.NewProjectile(vector.X, vector.Y, speedX2, speedY2, num53, num55, num56, i, 0f, (float)Main.rand.Next(5));
											}
										}
										else
										{
											if (this.inventory[this.selectedItem].type == 1929)
											{
												float speedX3 = num61 + (float)Main.rand.Next(-40, 41) * 0.03f;
												float speedY3 = num62 + (float)Main.rand.Next(-40, 41) * 0.03f;
												Projectile.NewProjectile(vector.X, vector.Y, speedX3, speedY3, num53, num55, num56, i, 0f, 0f);
											}
											else
											{
												if (this.inventory[this.selectedItem].type == 1553)
												{
													float speedX4 = num61 + (float)Main.rand.Next(-40, 41) * 0.005f;
													float speedY4 = num62 + (float)Main.rand.Next(-40, 41) * 0.005f;
													Projectile.NewProjectile(vector.X, vector.Y, speedX4, speedY4, num53, num55, num56, i, 0f, 0f);
												}
												else
												{
													if (this.inventory[this.selectedItem].type == 518)
													{
														float num78 = num61;
														float num79 = num62;
														num78 += (float)Main.rand.Next(-40, 41) * 0.04f;
														num79 += (float)Main.rand.Next(-40, 41) * 0.04f;
														Projectile.NewProjectile(vector.X, vector.Y, num78, num79, num53, num55, num56, i, 0f, 0f);
													}
													else
													{
														if (this.inventory[this.selectedItem].type == 1265)
														{
															float num80 = num61;
															float num81 = num62;
															num80 += (float)Main.rand.Next(-30, 31) * 0.03f;
															num81 += (float)Main.rand.Next(-30, 31) * 0.03f;
															Projectile.NewProjectile(vector.X, vector.Y, num80, num81, num53, num55, num56, i, 0f, 0f);
														}
														else
														{
															if (this.inventory[this.selectedItem].type == 534)
															{
																for (int num82 = 0; num82 < 4; num82++)
																{
																	float num83 = num61;
																	float num84 = num62;
																	num83 += (float)Main.rand.Next(-40, 41) * 0.05f;
																	num84 += (float)Main.rand.Next(-40, 41) * 0.05f;
																	Projectile.NewProjectile(vector.X, vector.Y, num83, num84, num53, num55, num56, i, 0f, 0f);
																}
															}
															else
															{
																if (this.inventory[this.selectedItem].type == 2188)
																{
																	int num85 = 4;
																	if (Main.rand.Next(3) == 0)
																	{
																		num85++;
																	}
																	if (Main.rand.Next(4) == 0)
																	{
																		num85++;
																	}
																	if (Main.rand.Next(5) == 0)
																	{
																		num85++;
																	}
																	for (int num86 = 0; num86 < num85; num86++)
																	{
																		float num87 = num61;
																		float num88 = num62;
																		float num89 = 0.05f * (float)num86;
																		num87 += (float)Main.rand.Next(-35, 36) * num89;
																		num88 += (float)Main.rand.Next(-35, 36) * num89;
																		num63 = (float)Math.Sqrt((double)(num87 * num87 + num88 * num88));
																		num63 = num54 / num63;
																		num87 *= num63;
																		num88 *= num63;
																		float x2 = vector.X;
																		float y2 = vector.Y;
																		Projectile.NewProjectile(x2, y2, num87, num88, num53, num55, num56, i, 0f, 0f);
																	}
																}
																else
																{
																	if (this.inventory[this.selectedItem].type == 1308)
																	{
																		int num90 = 3;
																		if (Main.rand.Next(3) == 0)
																		{
																			num90++;
																		}
																		for (int num91 = 0; num91 < num90; num91++)
																		{
																			float num92 = num61;
																			float num93 = num62;
																			float num94 = 0.05f * (float)num91;
																			num92 += (float)Main.rand.Next(-35, 36) * num94;
																			num93 += (float)Main.rand.Next(-35, 36) * num94;
																			num63 = (float)Math.Sqrt((double)(num92 * num92 + num93 * num93));
																			num63 = num54 / num63;
																			num92 *= num63;
																			num93 *= num63;
																			float x3 = vector.X;
																			float y3 = vector.Y;
																			Projectile.NewProjectile(x3, y3, num92, num93, num53, num55, num56, i, 0f, 0f);
																		}
																	}
																	else
																	{
																		if (this.inventory[this.selectedItem].type == 1258)
																		{
																			float num95 = num61;
																			float num96 = num62;
																			num95 += (float)Main.rand.Next(-40, 41) * 0.01f;
																			num96 += (float)Main.rand.Next(-40, 41) * 0.01f;
																			vector.X += (float)Main.rand.Next(-40, 41) * 0.05f;
																			vector.Y += (float)Main.rand.Next(-45, 36) * 0.05f;
																			Projectile.NewProjectile(vector.X, vector.Y, num95, num96, num53, num55, num56, i, 0f, 0f);
																		}
																		else
																		{
																			if (this.inventory[this.selectedItem].type == 964)
																			{
																				for (int num97 = 0; num97 < 3; num97++)
																				{
																					float num98 = num61;
																					float num99 = num62;
																					num98 += (float)Main.rand.Next(-35, 36) * 0.04f;
																					num99 += (float)Main.rand.Next(-35, 36) * 0.04f;
																					Projectile.NewProjectile(vector.X, vector.Y, num98, num99, num53, num55, num56, i, 0f, 0f);
																				}
																			}
																			else
																			{
																				if (this.inventory[this.selectedItem].type == 1569)
																				{
																					int num100 = 4;
																					if (Main.rand.Next(2) == 0)
																					{
																						num100++;
																					}
																					if (Main.rand.Next(4) == 0)
																					{
																						num100++;
																					}
																					if (Main.rand.Next(8) == 0)
																					{
																						num100++;
																					}
																					if (Main.rand.Next(16) == 0)
																					{
																						num100++;
																					}
																					for (int num101 = 0; num101 < num100; num101++)
																					{
																						float num102 = num61;
																						float num103 = num62;
																						float num104 = 0.05f * (float)num101;
																						num102 += (float)Main.rand.Next(-35, 36) * num104;
																						num103 += (float)Main.rand.Next(-35, 36) * num104;
																						num63 = (float)Math.Sqrt((double)(num102 * num102 + num103 * num103));
																						num63 = num54 / num63;
																						num102 *= num63;
																						num103 *= num63;
																						float x4 = vector.X;
																						float y4 = vector.Y;
																						Projectile.NewProjectile(x4, y4, num102, num103, num53, num55, num56, i, 0f, 0f);
																					}
																				}
																				else
																				{
																					if (this.inventory[this.selectedItem].type == 1572)
																					{
																						for (int num105 = 0; num105 < 1000; num105++)
																						{
																							if (Main.projectile[num105].owner == this.whoAmi && Main.projectile[num105].type == 308)
																							{
																								Main.projectile[num105].Kill();
																							}
																						}
																						int num106 = (int)((float)Main.mouseX + Main.screenPosition.X) / 16;
																						int num107 = (int)((float)Main.mouseY + Main.screenPosition.Y) / 16;
																						if (this.gravDir == -1f)
																						{
																							num107 = (int)(Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY) / 16;
																						}
																						while (num107 < Main.maxTilesY - 10 && Main.tile[num106, num107] != null && !WorldGen.SolidTile(num106, num107) && Main.tile[num106 - 1, num107] != null && !WorldGen.SolidTile(num106 - 1, num107) && Main.tile[num106 + 1, num107] != null && !WorldGen.SolidTile(num106 + 1, num107))
																						{
																							num107++;
																						}
																						num107--;
																						Projectile.NewProjectile((float)Main.mouseX + Main.screenPosition.X, (float)(num107 * 16 - 24), 0f, 15f, num53, num55, num56, i, 0f, 0f);
																					}
																					else
																					{
																						if (this.inventory[this.selectedItem].type == 1244 || this.inventory[this.selectedItem].type == 1256)
																						{
																							int num108 = Projectile.NewProjectile(vector.X, vector.Y, num61, num62, num53, num55, num56, i, 0f, 0f);
																							Main.projectile[num108].ai[0] = (float)Main.mouseX + Main.screenPosition.X;
																							Main.projectile[num108].ai[1] = (float)Main.mouseY + Main.screenPosition.Y;
																						}
																						else
																						{
																							if (this.inventory[this.selectedItem].type == 1229)
																							{
																								int num109 = Main.rand.Next(2, 4);
																								if (Main.rand.Next(5) == 0)
																								{
																									num109++;
																								}
																								for (int num110 = 0; num110 < num109; num110++)
																								{
																									float num111 = num61;
																									float num112 = num62;
																									if (num110 > 0)
																									{
																										num111 += (float)Main.rand.Next(-35, 36) * 0.04f;
																										num112 += (float)Main.rand.Next(-35, 36) * 0.04f;
																									}
																									if (num110 > 1)
																									{
																										num111 += (float)Main.rand.Next(-35, 36) * 0.04f;
																										num112 += (float)Main.rand.Next(-35, 36) * 0.04f;
																									}
																									if (num110 > 2)
																									{
																										num111 += (float)Main.rand.Next(-35, 36) * 0.04f;
																										num112 += (float)Main.rand.Next(-35, 36) * 0.04f;
																									}
																									int num113 = Projectile.NewProjectile(vector.X, vector.Y, num111, num112, num53, num55, num56, i, 0f, 0f);
																									Main.projectile[num113].noDropItem = true;
																								}
																							}
																							else
																							{
																								if (this.inventory[this.selectedItem].type == 1121 || this.inventory[this.selectedItem].type == 1155)
																								{
																									int num114;
																									if (this.inventory[this.selectedItem].type == 1121)
																									{
																										num114 = Main.rand.Next(1, 4);
																										if (Main.rand.Next(6) == 0)
																										{
																											num114++;
																										}
																										if (Main.rand.Next(6) == 0)
																										{
																											num114++;
																										}
																									}
																									else
																									{
																										num114 = Main.rand.Next(2, 5);
																										if (Main.rand.Next(5) == 0)
																										{
																											num114++;
																										}
																										if (Main.rand.Next(5) == 0)
																										{
																											num114++;
																										}
																									}
																									for (int num115 = 0; num115 < num114; num115++)
																									{
																										float num116 = num61;
																										float num117 = num62;
																										num116 += (float)Main.rand.Next(-35, 36) * 0.02f;
																										num117 += (float)Main.rand.Next(-35, 36) * 0.02f;
																										Projectile.NewProjectile(vector.X, vector.Y, num116, num117, num53, num55, num56, i, 0f, 0f);
																									}
																								}
																								else
																								{
																									if (this.inventory[this.selectedItem].type == 1801)
																									{
																										int num118 = Main.rand.Next(1, 4);
																										for (int num119 = 0; num119 < num118; num119++)
																										{
																											float num120 = num61;
																											float num121 = num62;
																											num120 += (float)Main.rand.Next(-35, 36) * 0.05f;
																											num121 += (float)Main.rand.Next(-35, 36) * 0.05f;
																											Projectile.NewProjectile(vector.X, vector.Y, num120, num121, num53, num55, num56, i, 0f, 0f);
																										}
																									}
																									else
																									{
																										if (this.inventory[this.selectedItem].type == 679)
																										{
																											for (int num122 = 0; num122 < 6; num122++)
																											{
																												float num123 = num61;
																												float num124 = num62;
																												num123 += (float)Main.rand.Next(-40, 41) * 0.05f;
																												num124 += (float)Main.rand.Next(-40, 41) * 0.05f;
																												Projectile.NewProjectile(vector.X, vector.Y, num123, num124, num53, num55, num56, i, 0f, 0f);
																											}
																										}
																										else
																										{
																											if (this.inventory[this.selectedItem].type == 434)
																											{
																												float num125 = num61;
																												float num126 = num62;
																												if (this.itemAnimation < 5)
																												{
																													num125 += (float)Main.rand.Next(-40, 41) * 0.01f;
																													num126 += (float)Main.rand.Next(-40, 41) * 0.01f;
																													num125 *= 1.1f;
																													num126 *= 1.1f;
																												}
																												else
																												{
																													if (this.itemAnimation < 10)
																													{
																														num125 += (float)Main.rand.Next(-20, 21) * 0.01f;
																														num126 += (float)Main.rand.Next(-20, 21) * 0.01f;
																														num125 *= 1.05f;
																														num126 *= 1.05f;
																													}
																												}
																												Projectile.NewProjectile(vector.X, vector.Y, num125, num126, num53, num55, num56, i, 0f, 0f);
																											}
																											else
																											{
																												if (this.inventory[this.selectedItem].type == 1157)
																												{
																													num53 = Main.rand.Next(191, 195);
																													num61 = 0f;
																													num62 = 0f;
																													vector.X = (float)Main.mouseX + Main.screenPosition.X;
																													vector.Y = (float)Main.mouseY + Main.screenPosition.Y;
																													int num127 = Projectile.NewProjectile(vector.X, vector.Y, num61, num62, num53, num55, num56, i, 0f, 0f);
																													Main.projectile[num127].localAI[0] = 30f;
																												}
																												else
																												{
																													if (this.inventory[this.selectedItem].type == 1802)
																													{
																														num61 = 0f;
																														num62 = 0f;
																														vector.X = (float)Main.mouseX + Main.screenPosition.X;
																														vector.Y = (float)Main.mouseY + Main.screenPosition.Y;
																														Projectile.NewProjectile(vector.X, vector.Y, num61, num62, num53, num55, num56, i, 0f, 0f);
																													}
																													else
																													{
																														if (this.inventory[this.selectedItem].type == 1309)
																														{
																															num61 = 0f;
																															num62 = 0f;
																															vector.X = (float)Main.mouseX + Main.screenPosition.X;
																															vector.Y = (float)Main.mouseY + Main.screenPosition.Y;
																															Projectile.NewProjectile(vector.X, vector.Y, num61, num62, num53, num55, num56, i, 0f, 0f);
																														}
																														else
																														{
																															if (this.inventory[this.selectedItem].shoot > 0 && (Main.projPet[this.inventory[this.selectedItem].shoot] || this.inventory[this.selectedItem].shoot == 72 || this.inventory[this.selectedItem].shoot == 18) && !this.inventory[this.selectedItem].summon)
																															{
																																for (int num128 = 0; num128 < 1000; num128++)
																																{
																																	if (Main.projectile[num128].active && Main.projectile[num128].owner == this.whoAmi)
																																	{
																																		if (this.inventory[this.selectedItem].shoot == 72)
																																		{
																																			if (Main.projectile[num128].type == 72 || Main.projectile[num128].type == 86 || Main.projectile[num128].type == 87)
																																			{
																																				Main.projectile[num128].Kill();
																																			}
																																		}
																																		else
																																		{
																																			if (this.inventory[this.selectedItem].shoot == Main.projectile[num128].type)
																																			{
																																				Main.projectile[num128].Kill();
																																			}
																																		}
																																	}
																																}
																																Projectile.NewProjectile(vector.X, vector.Y, num61, num62, num53, num55, num56, i, 0f, 0f);
																															}
																															else
																															{
																																int num129 = Projectile.NewProjectile(vector.X, vector.Y, num61, num62, num53, num55, num56, i, 0f, 0f);
																																if (this.inventory[this.selectedItem].type == 726)
																																{
																																	Main.projectile[num129].magic = true;
																																}
																																if (this.inventory[this.selectedItem].type == 724 || this.inventory[this.selectedItem].type == 676)
																																{
																																	Main.projectile[num129].melee = true;
																																}
																																if (num53 == 80)
																																{
																																	Main.projectile[num129].ai[0] = (float)Player.tileTargetX;
																																	Main.projectile[num129].ai[1] = (float)Player.tileTargetY;
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
					else
					{
						if (this.inventory[this.selectedItem].useStyle == 5)
						{
							this.itemRotation = 0f;
							NetMessage.SendData(41, -1, -1, "", this.whoAmi, 0f, 0f, 0f, 0);
						}
					}
				}
				if (this.whoAmi == Main.myPlayer && (this.inventory[this.selectedItem].type == 509 || this.inventory[this.selectedItem].type == 510 || this.inventory[this.selectedItem].type == 849 || this.inventory[this.selectedItem].type == 850 || this.inventory[this.selectedItem].type == 851) && this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f + (float)this.blockRange >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f + (float)this.blockRange >= (float)Player.tileTargetY)
				{
					this.showItemIcon = true;
					if (this.itemAnimation > 0 && this.itemTime == 0 && this.controlUseItem)
					{
						int i2 = Player.tileTargetX;
						int j2 = Player.tileTargetY;
						if (this.inventory[this.selectedItem].type == 509)
						{
							int num130 = -1;
							for (int num131 = 0; num131 < 58; num131++)
							{
								if (this.inventory[num131].stack > 0 && this.inventory[num131].type == 530)
								{
									num130 = num131;
									break;
								}
							}
							if (num130 >= 0 && WorldGen.PlaceWire(i2, j2))
							{
								this.inventory[num130].stack--;
								if (this.inventory[num130].stack <= 0)
								{
									this.inventory[num130].SetDefaults(0, false);
								}
								this.itemTime = this.inventory[this.selectedItem].useTime;
								NetMessage.SendData(17, -1, -1, "", 5, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
							}
						}
						else
						{
							if (this.inventory[this.selectedItem].type == 850)
							{
								int num132 = -1;
								for (int num133 = 0; num133 < 58; num133++)
								{
									if (this.inventory[num133].stack > 0 && this.inventory[num133].type == 530)
									{
										num132 = num133;
										break;
									}
								}
								if (num132 >= 0 && WorldGen.PlaceWire2(i2, j2))
								{
									this.inventory[num132].stack--;
									if (this.inventory[num132].stack <= 0)
									{
										this.inventory[num132].SetDefaults(0, false);
									}
									this.itemTime = this.inventory[this.selectedItem].useTime;
									NetMessage.SendData(17, -1, -1, "", 10, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
								}
							}
						}
						if (this.inventory[this.selectedItem].type == 851)
						{
							int num134 = -1;
							for (int num135 = 0; num135 < 58; num135++)
							{
								if (this.inventory[num135].stack > 0 && this.inventory[num135].type == 530)
								{
									num134 = num135;
									break;
								}
							}
							if (num134 >= 0 && WorldGen.PlaceWire3(i2, j2))
							{
								this.inventory[num134].stack--;
								if (this.inventory[num134].stack <= 0)
								{
									this.inventory[num134].SetDefaults(0, false);
								}
								this.itemTime = this.inventory[this.selectedItem].useTime;
								NetMessage.SendData(17, -1, -1, "", 12, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
							}
						}
						else
						{
							if (this.inventory[this.selectedItem].type == 510)
							{
								if (WorldGen.KillActuator(i2, j2))
								{
									this.itemTime = this.inventory[this.selectedItem].useTime;
									NetMessage.SendData(17, -1, -1, "", 9, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
								}
								else
								{
									if (WorldGen.KillWire3(i2, j2))
									{
										this.itemTime = this.inventory[this.selectedItem].useTime;
										NetMessage.SendData(17, -1, -1, "", 13, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
									}
									else
									{
										if (WorldGen.KillWire2(i2, j2))
										{
											this.itemTime = this.inventory[this.selectedItem].useTime;
											NetMessage.SendData(17, -1, -1, "", 11, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
										}
										else
										{
											if (WorldGen.KillWire(i2, j2))
											{
												this.itemTime = this.inventory[this.selectedItem].useTime;
												NetMessage.SendData(17, -1, -1, "", 6, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
											}
										}
									}
								}
							}
							else
							{
								if (this.inventory[this.selectedItem].type == 849 && this.inventory[this.selectedItem].stack > 0 && WorldGen.PlaceActuator(i2, j2))
								{
									this.itemTime = this.inventory[this.selectedItem].useTime;
									NetMessage.SendData(17, -1, -1, "", 8, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
									this.inventory[this.selectedItem].stack--;
									if (this.inventory[this.selectedItem].stack <= 0)
									{
										this.inventory[this.selectedItem].SetDefaults(0, false);
									}
								}
							}
						}
					}
				}
				if (this.itemAnimation > 0 && this.itemTime == 0 && (this.inventory[this.selectedItem].type == 507 || this.inventory[this.selectedItem].type == 508))
				{
					this.itemTime = this.inventory[this.selectedItem].useTime;
					Vector2 vector2 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
					float num136 = (float)Main.mouseX + Main.screenPosition.X - vector2.X;
					float num137 = (float)Main.mouseY + Main.screenPosition.Y - vector2.Y;
					float num138 = (float)Math.Sqrt((double)(num136 * num136 + num137 * num137));
					num138 /= (float)(Main.screenHeight / 2);
					if (num138 > 1f)
					{
						num138 = 1f;
					}
					num138 = num138 * 2f - 1f;
					if (num138 < -1f)
					{
						num138 = -1f;
					}
					if (num138 > 1f)
					{
						num138 = 1f;
					}
					Main.harpNote = num138;
					int style = 26;
					if (this.inventory[this.selectedItem].type == 507)
					{
						style = 35;
					}
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, style);
					NetMessage.SendData(58, -1, -1, "", this.whoAmi, num138, 0f, 0f, 0);
				}
				if (((this.inventory[this.selectedItem].type >= 205 && this.inventory[this.selectedItem].type <= 207) || this.inventory[this.selectedItem].type == 1128) && this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f >= (float)Player.tileTargetY)
				{
					this.showItemIcon = true;
					if (this.itemTime == 0 && this.itemAnimation > 0 && this.controlUseItem)
					{
						if (this.inventory[this.selectedItem].type == 205)
						{
							int num139 = (int)Main.tile[Player.tileTargetX, Player.tileTargetY].liquidType();
							int num140 = 0;
							for (int num141 = Player.tileTargetX - 1; num141 <= Player.tileTargetX + 1; num141++)
							{
								for (int num142 = Player.tileTargetY - 1; num142 <= Player.tileTargetY + 1; num142++)
								{
									if ((int)Main.tile[num141, num142].liquidType() == num139)
									{
										num140 += (int)Main.tile[num141, num142].liquid;
									}
								}
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid > 0 && num140 > 100)
							{
								int liquidType = (int)Main.tile[Player.tileTargetX, Player.tileTargetY].liquidType();
								if (!Main.tile[Player.tileTargetX, Player.tileTargetY].lava())
								{
									if (Main.tile[Player.tileTargetX, Player.tileTargetY].honey())
									{
										this.inventory[this.selectedItem].stack--;
										this.PutItemInInventory(1128, this.selectedItem);
									}
									else
									{
										this.inventory[this.selectedItem].stack--;
										this.PutItemInInventory(206, this.selectedItem);
									}
								}
								else
								{
									this.inventory[this.selectedItem].stack--;
									this.PutItemInInventory(207, this.selectedItem);
								}
								Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
								this.itemTime = this.inventory[this.selectedItem].useTime;
								int num143 = (int)Main.tile[Player.tileTargetX, Player.tileTargetY].liquid;
								Main.tile[Player.tileTargetX, Player.tileTargetY].liquid = 0;
								Main.tile[Player.tileTargetX, Player.tileTargetY].lava(false);
								Main.tile[Player.tileTargetX, Player.tileTargetY].honey(false);
								WorldGen.SquareTileFrame(Player.tileTargetX, Player.tileTargetY, false);
								if (Main.netMode == 1)
								{
									NetMessage.sendWater(Player.tileTargetX, Player.tileTargetY);
								}
								else
								{
									Liquid.AddWater(Player.tileTargetX, Player.tileTargetY);
								}
								for (int num144 = Player.tileTargetX - 1; num144 <= Player.tileTargetX + 1; num144++)
								{
									for (int num145 = Player.tileTargetY - 1; num145 <= Player.tileTargetY + 1; num145++)
									{
										if (num143 < 256 && (int)Main.tile[num144, num145].liquidType() == num139)
										{
											int num146 = (int)Main.tile[num144, num145].liquid;
											if (num146 + num143 > 255)
											{
												num146 = 255 - num143;
											}
											num143 += num146;
											Tile expr_74A3 = Main.tile[num144, num145];
											expr_74A3.liquid -= (byte)num146;
											Main.tile[num144, num145].liquidType(liquidType);
											if (Main.tile[num144, num145].liquid == 0)
											{
												Main.tile[num144, num145].lava(false);
												Main.tile[num144, num145].honey(false);
											}
											WorldGen.SquareTileFrame(num144, num145, false);
											if (Main.netMode == 1)
											{
												NetMessage.sendWater(num144, num145);
											}
											else
											{
												Liquid.AddWater(num144, num145);
											}
										}
									}
								}
							}
						}
						else
						{
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid < 200 && (!Main.tile[Player.tileTargetX, Player.tileTargetY].nactive() || !Main.tileSolid[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type] || Main.tileSolidTop[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type]))
							{
								if (this.inventory[this.selectedItem].type == 207)
								{
									if (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid == 0 || Main.tile[Player.tileTargetX, Player.tileTargetY].liquidType() == 1)
									{
										Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
										Main.tile[Player.tileTargetX, Player.tileTargetY].liquidType(1);
										Main.tile[Player.tileTargetX, Player.tileTargetY].liquid = 255;
										WorldGen.SquareTileFrame(Player.tileTargetX, Player.tileTargetY, true);
										this.inventory[this.selectedItem].stack--;
										this.PutItemInInventory(205, this.selectedItem);
										this.itemTime = this.inventory[this.selectedItem].useTime;
										if (Main.netMode == 1)
										{
											NetMessage.sendWater(Player.tileTargetX, Player.tileTargetY);
										}
									}
								}
								else
								{
									if (this.inventory[this.selectedItem].type == 206)
									{
										if (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid == 0 || Main.tile[Player.tileTargetX, Player.tileTargetY].liquidType() == 0)
										{
											Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
											Main.tile[Player.tileTargetX, Player.tileTargetY].liquidType(0);
											Main.tile[Player.tileTargetX, Player.tileTargetY].liquid = 255;
											WorldGen.SquareTileFrame(Player.tileTargetX, Player.tileTargetY, true);
											this.inventory[this.selectedItem].stack--;
											this.PutItemInInventory(205, this.selectedItem);
											this.itemTime = this.inventory[this.selectedItem].useTime;
											if (Main.netMode == 1)
											{
												NetMessage.sendWater(Player.tileTargetX, Player.tileTargetY);
											}
										}
									}
									else
									{
										if (this.inventory[this.selectedItem].type == 1128 && (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid == 0 || Main.tile[Player.tileTargetX, Player.tileTargetY].liquidType() == 2))
										{
											Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
											Main.tile[Player.tileTargetX, Player.tileTargetY].liquidType(2);
											Main.tile[Player.tileTargetX, Player.tileTargetY].liquid = 255;
											WorldGen.SquareTileFrame(Player.tileTargetX, Player.tileTargetY, true);
											this.inventory[this.selectedItem].stack--;
											this.PutItemInInventory(205, this.selectedItem);
											this.itemTime = this.inventory[this.selectedItem].useTime;
											if (Main.netMode == 1)
											{
												NetMessage.sendWater(Player.tileTargetX, Player.tileTargetY);
											}
										}
									}
								}
							}
						}
					}
				}
				if (!this.channel)
				{
					this.toolTime = this.itemTime;
				}
				else
				{
					this.toolTime--;
					if (this.toolTime < 0)
					{
						if (this.inventory[this.selectedItem].pick > 0)
						{
							this.toolTime = this.inventory[this.selectedItem].useTime;
						}
						else
						{
							this.toolTime = (int)((float)this.inventory[this.selectedItem].useTime * this.pickSpeed);
						}
					}
				}
				if ((this.inventory[this.selectedItem].pick > 0 || this.inventory[this.selectedItem].axe > 0 || this.inventory[this.selectedItem].hammer > 0) && this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f >= (float)Player.tileTargetY)
				{
					int num147 = 0;
					bool flag8 = true;
					this.showItemIcon = true;
					if (this.toolTime == 0 && this.itemAnimation > 0 && this.controlUseItem && (!Main.tile[Player.tileTargetX, Player.tileTargetY].active() || (!Main.tileHammer[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type] && !Main.tileSolid[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type])))
					{
						this.poundRelease = false;
					}
					if (Main.tile[Player.tileTargetX, Player.tileTargetY].active())
					{
						if ((this.inventory[this.selectedItem].pick > 0 && !Main.tileAxe[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type] && !Main.tileHammer[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type]) || (this.inventory[this.selectedItem].axe > 0 && Main.tileAxe[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type]) || (this.inventory[this.selectedItem].hammer > 0 && Main.tileHammer[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type]))
						{
							flag8 = false;
						}
						if (this.toolTime == 0 && this.itemAnimation > 0 && this.controlUseItem)
						{
							int tileId = this.hitTile.HitObject(Player.tileTargetX, Player.tileTargetY, 1);
							if (Main.tileNoFail[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type])
							{
								num147 = 100;
							}
							if (Main.tileHammer[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type])
							{
								flag8 = false;
								if (this.inventory[this.selectedItem].hammer > 0)
								{
									num147 += this.inventory[this.selectedItem].hammer;
									if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 26 && (this.inventory[this.selectedItem].hammer < 80 || !Main.hardMode))
									{
										num147 = 0;
										this.Hurt(this.statLife / 2, -this.direction, false, false, Lang.deathMsg(-1, -1, -1, 4), false);
									}
									if (this.hitTile.AddDamage(tileId, num147, true) >= 100)
									{
										this.hitTile.Clear(tileId);
										WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, false, false, false);
										if (Main.netMode == 1)
										{
											NetMessage.SendData(17, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
										}
									}
									else
									{
										WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, true, false, false);
										if (Main.netMode == 1)
										{
											NetMessage.SendData(17, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, 1f, 0);
										}
									}
									if (num147 != 0)
									{
										this.hitTile.Prune();
									}
									this.itemTime = this.inventory[this.selectedItem].useTime;
								}
							}
							else
							{
								if (Main.tileAxe[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type])
								{
									if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 80)
									{
										num147 += this.inventory[this.selectedItem].axe * 3;
									}
									else
									{
										num147 += this.inventory[this.selectedItem].axe;
									}
									if (this.inventory[this.selectedItem].axe > 0)
									{
										if (this.hitTile.AddDamage(tileId, num147, true) >= 100)
										{
											this.hitTile.Clear(tileId);
											WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, false, false, false);
											if (Main.netMode == 1)
											{
												NetMessage.SendData(17, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
											}
										}
										else
										{
											WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, true, false, false);
											if (Main.netMode == 1)
											{
												NetMessage.SendData(17, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, 1f, 0);
											}
										}
										if (num147 != 0)
										{
											this.hitTile.Prune();
										}
										this.itemTime = this.inventory[this.selectedItem].useTime;
									}
								}
								else
								{
									if (this.inventory[this.selectedItem].pick > 0)
									{
										if (Main.tileDungeon[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type] || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 25 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 58 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 117 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 203)
										{
											num147 += this.inventory[this.selectedItem].pick / 2;
										}
										else
										{
											if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 48 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 232)
											{
												num147 += this.inventory[this.selectedItem].pick / 4;
											}
											else
											{
												if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 226)
												{
													num147 += this.inventory[this.selectedItem].pick / 4;
												}
												else
												{
													if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 107 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 221)
													{
														num147 += this.inventory[this.selectedItem].pick / 2;
													}
													else
													{
														if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 108 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 222)
														{
															num147 += this.inventory[this.selectedItem].pick / 3;
														}
														else
														{
															if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 111 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 223)
															{
																num147 += this.inventory[this.selectedItem].pick / 4;
															}
															else
															{
																if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 211)
																{
																	num147 += this.inventory[this.selectedItem].pick / 5;
																}
																else
																{
																	num147 += this.inventory[this.selectedItem].pick;
																}
															}
														}
													}
												}
											}
										}
										if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 211 && this.inventory[this.selectedItem].pick < 200)
										{
											num147 = 0;
										}
										if ((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 25 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 203) && this.inventory[this.selectedItem].pick < 65)
										{
											num147 = 0;
										}
										else
										{
											if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 117 && this.inventory[this.selectedItem].pick < 65)
											{
												num147 = 0;
											}
											else
											{
												if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 37 && this.inventory[this.selectedItem].pick < 50)
												{
													num147 = 0;
												}
												else
												{
													if ((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 22 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 204) && (double)Player.tileTargetY > Main.worldSurface && this.inventory[this.selectedItem].pick < 55)
													{
														num147 = 0;
													}
													else
													{
														if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 56 && this.inventory[this.selectedItem].pick < 65)
														{
															num147 = 0;
														}
														else
														{
															if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 58 && this.inventory[this.selectedItem].pick < 65)
															{
																num147 = 0;
															}
															else
															{
																if ((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 226 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 237) && this.inventory[this.selectedItem].pick < 210)
																{
																	num147 = 0;
																}
																else
																{
																	if (Main.tileDungeon[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type] && this.inventory[this.selectedItem].pick < 65)
																	{
																		if ((double)Player.tileTargetX < (double)Main.maxTilesX * 0.35 || (double)Player.tileTargetX > (double)Main.maxTilesX * 0.65)
																		{
																			num147 = 0;
																		}
																	}
																	else
																	{
																		if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 107 && this.inventory[this.selectedItem].pick < 100)
																		{
																			num147 = 0;
																		}
																		else
																		{
																			if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 108 && this.inventory[this.selectedItem].pick < 110)
																			{
																				num147 = 0;
																			}
																			else
																			{
																				if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 111 && this.inventory[this.selectedItem].pick < 150)
																				{
																					num147 = 0;
																				}
																				else
																				{
																					if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 221 && this.inventory[this.selectedItem].pick < 100)
																					{
																						num147 = 0;
																					}
																					else
																					{
																						if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 222 && this.inventory[this.selectedItem].pick < 110)
																						{
																							num147 = 0;
																						}
																						else
																						{
																							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 223 && this.inventory[this.selectedItem].pick < 150)
																							{
																								num147 = 0;
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
										if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 147 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 40 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 53 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 57 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 59 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 123 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 224)
										{
											num147 += this.inventory[this.selectedItem].pick;
										}
										if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 165 || Main.tileRope[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type] || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 199 || Main.tileMoss[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type])
										{
											num147 = 100;
										}
										if (this.hitTile.AddDamage(tileId, num147, false) >= 100 && (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 2 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 23 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 60 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 70 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 109 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 71 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 199 || Main.tileMoss[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type]))
										{
											num147 = 0;
										}
										if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 128 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 269)
										{
											if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX == 18 || Main.tile[Player.tileTargetX, Player.tileTargetY].frameX == 54)
											{
												Player.tileTargetX--;
												this.hitTile.UpdatePosition(tileId, Player.tileTargetX, Player.tileTargetY);
											}
											if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 100)
											{
												num147 = 0;
											}
										}
										if (this.hitTile.AddDamage(tileId, num147, true) >= 100)
										{
											this.hitTile.Clear(tileId);
											if (Main.netMode == 1 && Main.tile[Player.tileTargetX, Player.tileTargetY].type == 21)
											{
												WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, true, false, false);
												NetMessage.SendData(17, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, 1f, 0);
												NetMessage.SendData(34, -1, -1, "", 1, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
											}
											else
											{
												int num148 = Player.tileTargetY;
												WorldGen.KillTile(Player.tileTargetX, num148, false, false, false);
												if (Main.netMode == 1)
												{
													NetMessage.SendData(17, -1, -1, "", 0, (float)Player.tileTargetX, (float)num148, 0f, 0);
												}
											}
										}
										else
										{
											WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, true, false, false);
											if (Main.netMode == 1)
											{
												NetMessage.SendData(17, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, 1f, 0);
											}
										}
										if (num147 != 0)
										{
											this.hitTile.Prune();
										}
										this.itemTime = (int)((float)this.inventory[this.selectedItem].useTime * this.pickSpeed);
									}
								}
							}
							if (this.inventory[this.selectedItem].hammer > 0 && Main.tile[Player.tileTargetX, Player.tileTargetY].active() && Main.tileSolid[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type] && Main.tile[Player.tileTargetX, Player.tileTargetY].type != 10 && this.poundRelease)
							{
								flag8 = false;
								this.itemTime = this.inventory[this.selectedItem].useTime;
								num147 += (int)((double)this.inventory[this.selectedItem].hammer * 1.25);
								num147 = 100;
								if (Main.tile[Player.tileTargetX, Player.tileTargetY - 1].active() && Main.tile[Player.tileTargetX, Player.tileTargetY - 1].type == 10)
								{
									num147 = 0;
								}
								if (Main.tile[Player.tileTargetX, Player.tileTargetY + 1].active() && Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type == 10)
								{
									num147 = 0;
								}
								if (this.hitTile.AddDamage(tileId, num147, true) >= 100)
								{
									this.hitTile.Clear(tileId);
									if (this.poundRelease)
									{
										int num149 = Player.tileTargetX;
										int num150 = Player.tileTargetY;
										if (Main.tile[num149, num150].type == 19)
										{
											if (Main.tile[num149, num150].halfBrick())
											{
												WorldGen.PoundTile(num149, num150);
												if (Main.netMode == 1)
												{
													NetMessage.SendData(17, -1, -1, "", 7, (float)Player.tileTargetX, (float)Player.tileTargetY, 1f, 0);
												}
											}
											else
											{
												int num151 = 1;
												int slope = 2;
												if (Main.tile[num149 + 1, num150 - 1].type == 19 || Main.tile[num149 - 1, num150 + 1].type == 19 || (WorldGen.SolidTile(num149 + 1, num150) && !WorldGen.SolidTile(num149 - 1, num150)))
												{
													num151 = 2;
													slope = 1;
												}
												if (Main.tile[num149, num150].slope() == 0)
												{
													WorldGen.SlopeTile(num149, num150, num151);
													int num152 = (int)Main.tile[num149, num150].slope();
													if (Main.netMode == 1)
													{
														NetMessage.SendData(17, -1, -1, "", 14, (float)Player.tileTargetX, (float)Player.tileTargetY, (float)num152, 0);
													}
												}
												else
												{
													if ((int)Main.tile[num149, num150].slope() == num151)
													{
														WorldGen.SlopeTile(num149, num150, slope);
														int num153 = (int)Main.tile[num149, num150].slope();
														if (Main.netMode == 1)
														{
															NetMessage.SendData(17, -1, -1, "", 14, (float)Player.tileTargetX, (float)Player.tileTargetY, (float)num153, 0);
														}
													}
													else
													{
														WorldGen.SlopeTile(num149, num150, 0);
														int num154 = (int)Main.tile[num149, num150].slope();
														if (Main.netMode == 1)
														{
															NetMessage.SendData(17, -1, -1, "", 14, (float)Player.tileTargetX, (float)Player.tileTargetY, (float)num154, 0);
														}
														WorldGen.PoundTile(num149, num150);
														if (Main.netMode == 1)
														{
															NetMessage.SendData(17, -1, -1, "", 7, (float)Player.tileTargetX, (float)Player.tileTargetY, 1f, 0);
														}
													}
												}
											}
										}
										else
										{
											if ((Main.tile[num149, num150].halfBrick() || Main.tile[num149, num150].slope() != 0) && !Main.tileSolidTop[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type])
											{
												int num155 = 1;
												int num156 = 1;
												int num157 = 2;
												if ((WorldGen.SolidTile(num149 + 1, num150) || Main.tile[num149 + 1, num150].slope() == 1 || Main.tile[num149 + 1, num150].slope() == 3) && !WorldGen.SolidTile(num149 - 1, num150))
												{
													num156 = 2;
													num157 = 1;
												}
												if (WorldGen.SolidTile(num149, num150 - 1) && !WorldGen.SolidTile(num149, num150 + 1))
												{
													num155 = -1;
												}
												if (num155 == 1)
												{
													if (Main.tile[num149, num150].slope() == 0)
													{
														WorldGen.SlopeTile(num149, num150, num156);
													}
													else
													{
														if ((int)Main.tile[num149, num150].slope() == num156)
														{
															WorldGen.SlopeTile(num149, num150, num157);
														}
														else
														{
															if ((int)Main.tile[num149, num150].slope() == num157)
															{
																WorldGen.SlopeTile(num149, num150, num156 + 2);
															}
															else
															{
																if ((int)Main.tile[num149, num150].slope() == num156 + 2)
																{
																	WorldGen.SlopeTile(num149, num150, num157 + 2);
																}
																else
																{
																	WorldGen.SlopeTile(num149, num150, 0);
																}
															}
														}
													}
												}
												else
												{
													if (Main.tile[num149, num150].slope() == 0)
													{
														WorldGen.SlopeTile(num149, num150, num156 + 2);
													}
													else
													{
														if ((int)Main.tile[num149, num150].slope() == num156 + 2)
														{
															WorldGen.SlopeTile(num149, num150, num157 + 2);
														}
														else
														{
															if ((int)Main.tile[num149, num150].slope() == num157 + 2)
															{
																WorldGen.SlopeTile(num149, num150, num156);
															}
															else
															{
																if ((int)Main.tile[num149, num150].slope() == num156)
																{
																	WorldGen.SlopeTile(num149, num150, num157);
																}
																else
																{
																	WorldGen.SlopeTile(num149, num150, 0);
																}
															}
														}
													}
												}
												int num158 = (int)Main.tile[num149, num150].slope();
												if (Main.netMode == 1)
												{
													NetMessage.SendData(17, -1, -1, "", 14, (float)Player.tileTargetX, (float)Player.tileTargetY, (float)num158, 0);
												}
											}
											else
											{
												WorldGen.PoundTile(num149, num150);
												if (Main.netMode == 1)
												{
													NetMessage.SendData(17, -1, -1, "", 7, (float)Player.tileTargetX, (float)Player.tileTargetY, 1f, 0);
												}
											}
										}
										this.poundRelease = false;
									}
								}
								else
								{
									WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, true, true, false);
									Main.PlaySound(0, Player.tileTargetX * 16, Player.tileTargetY * 16, 1);
								}
							}
							else
							{
								this.poundRelease = false;
							}
						}
					}
					if (this.releaseUseItem)
					{
						this.poundRelease = true;
					}
					int num159 = Player.tileTargetX;
					int num160 = Player.tileTargetY;
					bool flag9 = true;
					if (Main.tile[num159, num160].wall > 0)
					{
						if (!Main.wallHouse[(int)Main.tile[num159, num160].wall])
						{
							for (int num161 = num159 - 1; num161 < num159 + 2; num161++)
							{
								for (int num162 = num160 - 1; num162 < num160 + 2; num162++)
								{
									if (Main.tile[num161, num162].wall != Main.tile[num159, num160].wall)
									{
										flag9 = false;
										break;
									}
								}
							}
						}
						else
						{
							flag9 = false;
						}
					}
					if (flag9 && !Main.tile[num159, num160].active())
					{
						int num163 = -1;
						if ((double)(((float)Main.mouseX + Main.screenPosition.X) / 16f) < Math.Round((double)(((float)Main.mouseX + Main.screenPosition.X) / 16f)))
						{
							num163 = 0;
						}
						int num164 = -1;
						if ((double)(((float)Main.mouseY + Main.screenPosition.Y) / 16f) < Math.Round((double)(((float)Main.mouseY + Main.screenPosition.Y) / 16f)))
						{
							num164 = 0;
						}
						for (int num165 = Player.tileTargetX + num163; num165 <= Player.tileTargetX + num163 + 1; num165++)
						{
							for (int num166 = Player.tileTargetY + num164; num166 <= Player.tileTargetY + num164 + 1; num166++)
							{
								if (flag9)
								{
									num159 = num165;
									num160 = num166;
									if (Main.tile[num159, num160].wall > 0)
									{
										if (!Main.wallHouse[(int)Main.tile[num159, num160].wall])
										{
											for (int num167 = num159 - 1; num167 < num159 + 2; num167++)
											{
												for (int num168 = num160 - 1; num168 < num160 + 2; num168++)
												{
													if (Main.tile[num167, num168].wall != Main.tile[num159, num160].wall)
													{
														flag9 = false;
														break;
													}
												}
											}
										}
										else
										{
											flag9 = false;
										}
									}
								}
							}
						}
					}
					if (flag8 && Main.tile[num159, num160].wall > 0 && (!Main.tile[num159, num160].active() || num159 != Player.tileTargetX || num160 != Player.tileTargetY || (!Main.tileHammer[(int)Main.tile[num159, num160].type] && !this.poundRelease)) && this.toolTime == 0 && this.itemAnimation > 0 && this.controlUseItem && this.inventory[this.selectedItem].hammer > 0)
					{
						bool flag10 = true;
						if (!Main.wallHouse[(int)Main.tile[num159, num160].wall])
						{
							flag10 = false;
							for (int num169 = num159 - 1; num169 < num159 + 2; num169++)
							{
								for (int num170 = num160 - 1; num170 < num160 + 2; num170++)
								{
									if (Main.tile[num169, num170].wall == 0 || Main.wallHouse[(int)Main.tile[num169, num170].wall])
									{
										flag10 = true;
										break;
									}
								}
							}
						}
						if (flag10)
						{
							int tileId = this.hitTile.HitObject(num159, num160, 2);
							num147 += (int)((float)this.inventory[this.selectedItem].hammer * 1.5f);
							if (this.hitTile.AddDamage(tileId, num147, true) >= 100)
							{
								this.hitTile.Clear(tileId);
								WorldGen.KillWall(num159, num160, false);
								if (Main.netMode == 1)
								{
									NetMessage.SendData(17, -1, -1, "", 2, (float)num159, (float)num160, 0f, 0);
								}
							}
							else
							{
								WorldGen.KillWall(num159, num160, true);
								if (Main.netMode == 1)
								{
									NetMessage.SendData(17, -1, -1, "", 2, (float)num159, (float)num160, 1f, 0);
								}
							}
							if (num147 != 0)
							{
								this.hitTile.Prune();
							}
							this.itemTime = this.inventory[this.selectedItem].useTime / 2;
						}
					}
				}
				if (Main.myPlayer == this.whoAmi && this.inventory[this.selectedItem].type == 1326 && this.itemAnimation > 0 && this.itemTime == 0)
				{
					this.itemTime = this.inventory[this.selectedItem].useTime;
					Vector2 newPos;
					newPos.X = (float)Main.mouseX + Main.screenPosition.X;
					if (this.gravDir == 1f)
					{
						newPos.Y = (float)Main.mouseY + Main.screenPosition.Y - (float)this.height;
					}
					else
					{
						newPos.Y = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY;
					}
					newPos.X -= (float)(this.width / 2);
					if (newPos.X > 50f && newPos.X < (float)(Main.maxTilesX * 16 - 50) && newPos.Y > 50f && newPos.Y < (float)(Main.maxTilesY * 16 - 50))
					{
						int num171 = (int)(newPos.X / 16f);
						int num172 = (int)(newPos.Y / 16f);
						if ((Main.tile[num171, num172].wall != 87 || (double)num172 <= Main.worldSurface || NPC.downedPlantBoss) && !Collision.SolidCollision(newPos, this.width, this.height))
						{
							this.Teleport(newPos, 1);
							NetMessage.SendData(65, -1, -1, "", 0, (float)this.whoAmi, newPos.X, newPos.Y, 1);
							if (this.chaosState)
							{
								this.statLife -= this.statLifeMax / 6;
								if (Lang.lang <= 1)
								{
									string deathText = " didn't materialize";
									if (Main.rand.Next(2) == 0)
									{
										if (this.male)
										{
											deathText = "'s legs appeared where his head should be";
										}
										else
										{
											deathText = "'s legs appeared where her head should be";
										}
									}
									if (this.statLife <= 0)
									{
										this.KillMe(1.0, 0, false, deathText);
									}
								}
								else
								{
									if (this.statLife <= 0)
									{
										this.KillMe(1.0, 0, false, "");
									}
								}
								this.lifeRegenCount = 0;
								this.lifeRegenTime = 0;
							}
							this.AddBuff(88, 480, true);
						}
					}
				}
				if (this.inventory[this.selectedItem].type == 29 && this.itemAnimation > 0 && this.statLifeMax < 400 && this.itemTime == 0)
				{
					this.itemTime = this.inventory[this.selectedItem].useTime;
					this.statLifeMax += 20;
					this.statLife += 20;
					if (Main.myPlayer == this.whoAmi)
					{
						this.HealEffect(20, true);
					}
				}
				if (this.inventory[this.selectedItem].type == 1291 && this.itemAnimation > 0 && this.statLifeMax >= 400 && this.statLifeMax < 500 && this.itemTime == 0)
				{
					this.itemTime = this.inventory[this.selectedItem].useTime;
					this.statLifeMax += 5;
					this.statLife += 5;
					if (Main.myPlayer == this.whoAmi)
					{
						this.HealEffect(5, true);
					}
				}
				if (this.inventory[this.selectedItem].type == 109 && this.itemAnimation > 0 && this.statManaMax < 200 && this.itemTime == 0)
				{
					this.itemTime = this.inventory[this.selectedItem].useTime;
					this.statManaMax += 20;
					this.statMana += 20;
					if (Main.myPlayer == this.whoAmi)
					{
						this.ManaEffect(20);
					}
				}
				this.PlaceThing();
			}
			if (((this.inventory[this.selectedItem].damage >= 0 && this.inventory[this.selectedItem].type > 0 && !this.inventory[this.selectedItem].noMelee) || this.inventory[this.selectedItem].type == 1450 || this.inventory[this.selectedItem].type == 1991) && this.itemAnimation > 0)
			{
				bool flag11 = false;
				Rectangle rectangle = new Rectangle((int)this.itemLocation.X, (int)this.itemLocation.Y, 32, 32);
				if (!Main.dedServ)
				{
					rectangle = new Rectangle((int)this.itemLocation.X, (int)this.itemLocation.Y, Main.itemTexture[this.inventory[this.selectedItem].type].Width, Main.itemTexture[this.inventory[this.selectedItem].type].Height);
				}
				rectangle.Width = (int)((float)rectangle.Width * this.inventory[this.selectedItem].scale);
				rectangle.Height = (int)((float)rectangle.Height * this.inventory[this.selectedItem].scale);
				if (this.direction == -1)
				{
					rectangle.X -= rectangle.Width;
				}
				if (this.gravDir == 1f)
				{
					rectangle.Y -= rectangle.Height;
				}
				if (this.inventory[this.selectedItem].useStyle == 1)
				{
					if ((double)this.itemAnimation < (double)this.itemAnimationMax * 0.333)
					{
						if (this.direction == -1)
						{
							rectangle.X -= (int)((double)rectangle.Width * 1.4 - (double)rectangle.Width);
						}
						rectangle.Width = (int)((double)rectangle.Width * 1.4);
						rectangle.Y += (int)((double)rectangle.Height * 0.5 * (double)this.gravDir);
						rectangle.Height = (int)((double)rectangle.Height * 1.1);
					}
					else
					{
						if ((double)this.itemAnimation >= (double)this.itemAnimationMax * 0.666)
						{
							if (this.direction == 1)
							{
								rectangle.X -= (int)((double)rectangle.Width * 1.2);
							}
							rectangle.Width *= 2;
							rectangle.Y -= (int)(((double)rectangle.Height * 1.4 - (double)rectangle.Height) * (double)this.gravDir);
							rectangle.Height = (int)((double)rectangle.Height * 1.4);
						}
					}
				}
				else
				{
					if (this.inventory[this.selectedItem].useStyle == 3)
					{
						if ((double)this.itemAnimation > (double)this.itemAnimationMax * 0.666)
						{
							flag11 = true;
						}
						else
						{
							if (this.direction == -1)
							{
								rectangle.X -= (int)((double)rectangle.Width * 1.4 - (double)rectangle.Width);
							}
							rectangle.Width = (int)((double)rectangle.Width * 1.4);
							rectangle.Y += (int)((double)rectangle.Height * 0.6);
							rectangle.Height = (int)((double)rectangle.Height * 0.6);
						}
					}
				}
				float arg_9D88_0 = this.gravDir;
				if (this.inventory[this.selectedItem].type == 1450 && Main.rand.Next(3) == 0)
				{
					int num173 = -1;
					float x5 = (float)(rectangle.X + Main.rand.Next(rectangle.Width));
					float y5 = (float)(rectangle.Y + Main.rand.Next(rectangle.Height));
					if (Main.rand.Next(500) == 0)
					{
						num173 = Gore.NewGore(new Vector2(x5, y5), default(Vector2), 415, (float)Main.rand.Next(51, 101) * 0.01f);
					}
					else
					{
						if (Main.rand.Next(250) == 0)
						{
							num173 = Gore.NewGore(new Vector2(x5, y5), default(Vector2), 414, (float)Main.rand.Next(51, 101) * 0.01f);
						}
						else
						{
							if (Main.rand.Next(80) == 0)
							{
								num173 = Gore.NewGore(new Vector2(x5, y5), default(Vector2), 413, (float)Main.rand.Next(51, 101) * 0.01f);
							}
							else
							{
								if (Main.rand.Next(10) == 0)
								{
									num173 = Gore.NewGore(new Vector2(x5, y5), default(Vector2), 412, (float)Main.rand.Next(51, 101) * 0.01f);
								}
								else
								{
									if (Main.rand.Next(3) == 0)
									{
										num173 = Gore.NewGore(new Vector2(x5, y5), default(Vector2), 411, (float)Main.rand.Next(51, 101) * 0.01f);
									}
								}
							}
						}
					}
					if (num173 >= 0)
					{
						Gore expr_9F76_cp_0 = Main.gore[num173];
						expr_9F76_cp_0.velocity.X = expr_9F76_cp_0.velocity.X + (float)(this.direction * 2);
						Gore expr_9F98_cp_0 = Main.gore[num173];
						expr_9F98_cp_0.velocity.Y = expr_9F98_cp_0.velocity.Y * 0.3f;
					}
				}
				if (!flag11)
				{
					if (this.inventory[this.selectedItem].type == 989 && Main.rand.Next(5) == 0)
					{
						int num174 = Main.rand.Next(3);
						if (num174 == 0)
						{
							num174 = 15;
						}
						else
						{
							if (num174 == 1)
							{
								num174 = 57;
							}
							else
							{
								num174 = 58;
							}
						}
						int num175 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, num174, (float)(this.direction * 2), 0f, 150, default(Color), 1.3f);
						Main.dust[num175].velocity *= 0.2f;
					}
					if ((this.inventory[this.selectedItem].type == 44 || this.inventory[this.selectedItem].type == 45 || this.inventory[this.selectedItem].type == 46 || this.inventory[this.selectedItem].type == 103 || this.inventory[this.selectedItem].type == 104) && Main.rand.Next(15) == 0)
					{
						Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 14, (float)(this.direction * 2), 0f, 150, default(Color), 1.3f);
					}
					if (this.inventory[this.selectedItem].type == 273 || this.inventory[this.selectedItem].type == 675)
					{
						if (Main.rand.Next(5) == 0)
						{
							Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 14, (float)(this.direction * 2), 0f, 150, default(Color), 1.4f);
						}
						int num176 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 27, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 1.2f);
						Main.dust[num176].noGravity = true;
						Dust expr_A259_cp_0 = Main.dust[num176];
						expr_A259_cp_0.velocity.X = expr_A259_cp_0.velocity.X / 2f;
						Dust expr_A277_cp_0 = Main.dust[num176];
						expr_A277_cp_0.velocity.Y = expr_A277_cp_0.velocity.Y / 2f;
					}
					if (this.inventory[this.selectedItem].type == 723 && Main.rand.Next(2) == 0)
					{
						int num177 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 64, 0f, 0f, 150, default(Color), 1.2f);
						Main.dust[num177].noGravity = true;
					}
					if (this.inventory[this.selectedItem].type == 65)
					{
						if (Main.rand.Next(5) == 0)
						{
							Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 58, 0f, 0f, 150, default(Color), 1.2f);
						}
						if (Main.rand.Next(10) == 0)
						{
							Gore.NewGore(new Vector2((float)rectangle.X, (float)rectangle.Y), default(Vector2), Main.rand.Next(16, 18), 1f);
						}
					}
					if (this.inventory[this.selectedItem].type == 190 || this.inventory[this.selectedItem].type == 213)
					{
						int num178 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 40, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 0, default(Color), 1.2f);
						Main.dust[num178].noGravity = true;
					}
					if (this.inventory[this.selectedItem].type == 121)
					{
						for (int num179 = 0; num179 < 2; num179++)
						{
							int num180 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 6, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 2.5f);
							Main.dust[num180].noGravity = true;
							Dust expr_A51B_cp_0 = Main.dust[num180];
							expr_A51B_cp_0.velocity.X = expr_A51B_cp_0.velocity.X * 2f;
							Dust expr_A539_cp_0 = Main.dust[num180];
							expr_A539_cp_0.velocity.Y = expr_A539_cp_0.velocity.Y * 2f;
						}
					}
					if (this.inventory[this.selectedItem].type == 122 || this.inventory[this.selectedItem].type == 217)
					{
						int num181 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 6, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 1.9f);
						Main.dust[num181].noGravity = true;
					}
					if (this.inventory[this.selectedItem].type == 155)
					{
						int num182 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 172, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 0.9f);
						Main.dust[num182].noGravity = true;
						Main.dust[num182].velocity *= 0.1f;
					}
					if ((this.inventory[this.selectedItem].type == 676 || this.inventory[this.selectedItem].type == 673) && Main.rand.Next(3) == 0)
					{
						int num183 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 67, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 90, default(Color), 1.5f);
						Main.dust[num183].noGravity = true;
						Main.dust[num183].velocity *= 0.2f;
					}
					if (this.inventory[this.selectedItem].type == 724 && Main.rand.Next(5) == 0)
					{
						int num184 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 67, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 90, default(Color), 1.5f);
						Main.dust[num184].noGravity = true;
						Main.dust[num184].velocity *= 0.2f;
					}
					if (this.inventory[this.selectedItem].type >= 795 && this.inventory[this.selectedItem].type <= 802 && Main.rand.Next(3) == 0)
					{
						int num185 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 115, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 140, default(Color), 1.5f);
						Main.dust[num185].noGravity = true;
						Main.dust[num185].velocity *= 0.25f;
					}
					if (this.inventory[this.selectedItem].type == 367 || this.inventory[this.selectedItem].type == 368 || this.inventory[this.selectedItem].type == 674)
					{
						if (Main.rand.Next(3) == 0)
						{
							int num186 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 57, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 1.1f);
							Main.dust[num186].noGravity = true;
							Dust expr_AA25_cp_0 = Main.dust[num186];
							expr_AA25_cp_0.velocity.X = expr_AA25_cp_0.velocity.X / 2f;
							Dust expr_AA43_cp_0 = Main.dust[num186];
							expr_AA43_cp_0.velocity.Y = expr_AA43_cp_0.velocity.Y / 2f;
							Dust expr_AA61_cp_0 = Main.dust[num186];
							expr_AA61_cp_0.velocity.X = expr_AA61_cp_0.velocity.X + (float)(this.direction * 2);
						}
						if (Main.rand.Next(4) == 0)
						{
							int num186 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 43, 0f, 0f, 254, default(Color), 0.3f);
							Main.dust[num186].velocity *= 0f;
						}
					}
					if (this.inventory[this.selectedItem].type >= 198 && this.inventory[this.selectedItem].type <= 203)
					{
						float num187 = 0.5f;
						float num188 = 0.5f;
						float num189 = 0.5f;
						if (this.inventory[this.selectedItem].type == 198)
						{
							num187 *= 0.1f;
							num188 *= 0.5f;
							num189 *= 1.2f;
						}
						else
						{
							if (this.inventory[this.selectedItem].type == 199)
							{
								num187 *= 1f;
								num188 *= 0.2f;
								num189 *= 0.1f;
							}
							else
							{
								if (this.inventory[this.selectedItem].type == 200)
								{
									num187 *= 0.1f;
									num188 *= 1f;
									num189 *= 0.2f;
								}
								else
								{
									if (this.inventory[this.selectedItem].type == 201)
									{
										num187 *= 0.8f;
										num188 *= 0.1f;
										num189 *= 1f;
									}
									else
									{
										if (this.inventory[this.selectedItem].type == 202)
										{
											num187 *= 0.8f;
											num188 *= 0.9f;
											num189 *= 1f;
										}
										else
										{
											if (this.inventory[this.selectedItem].type == 203)
											{
												num187 *= 0.9f;
												num188 *= 0.9f;
												num189 *= 0.1f;
											}
										}
									}
								}
							}
						}
						Lighting.addLight((int)((this.itemLocation.X + 6f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f) / 16f), num187, num188, num189);
					}
					if (this.frostBurn && this.inventory[this.selectedItem].melee && !this.inventory[this.selectedItem].noMelee && !this.inventory[this.selectedItem].noUseGraphic && Main.rand.Next(2) == 0)
					{
						int num190 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 135, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 2.5f);
						Main.dust[num190].noGravity = true;
						Main.dust[num190].velocity *= 0.7f;
						Dust expr_ADE7_cp_0 = Main.dust[num190];
						expr_ADE7_cp_0.velocity.Y = expr_ADE7_cp_0.velocity.Y - 0.5f;
					}
					if (this.inventory[this.selectedItem].melee && !this.inventory[this.selectedItem].noMelee && !this.inventory[this.selectedItem].noUseGraphic && this.meleeEnchant > 0)
					{
						if (this.meleeEnchant == 1)
						{
							if (Main.rand.Next(3) == 0)
							{
								int num191 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 171, 0f, 0f, 100, default(Color), 1f);
								Main.dust[num191].noGravity = true;
								Main.dust[num191].fadeIn = 1.5f;
								Main.dust[num191].velocity *= 0.25f;
							}
						}
						else
						{
							if (this.meleeEnchant == 2)
							{
								if (Main.rand.Next(2) == 0)
								{
									int num192 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 75, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 2.5f);
									Main.dust[num192].noGravity = true;
									Main.dust[num192].velocity *= 0.7f;
									Dust expr_AFB6_cp_0 = Main.dust[num192];
									expr_AFB6_cp_0.velocity.Y = expr_AFB6_cp_0.velocity.Y - 0.5f;
								}
							}
							else
							{
								if (this.meleeEnchant == 3)
								{
									if (Main.rand.Next(2) == 0)
									{
										int num193 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 6, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 2.5f);
										Main.dust[num193].noGravity = true;
										Main.dust[num193].velocity *= 0.7f;
										Dust expr_B08C_cp_0 = Main.dust[num193];
										expr_B08C_cp_0.velocity.Y = expr_B08C_cp_0.velocity.Y - 0.5f;
									}
								}
								else
								{
									if (this.meleeEnchant == 4)
									{
										if (Main.rand.Next(2) == 0)
										{
											int num194 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 57, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 1.1f);
											Main.dust[num194].noGravity = true;
											Dust expr_B149_cp_0 = Main.dust[num194];
											expr_B149_cp_0.velocity.X = expr_B149_cp_0.velocity.X / 2f;
											Dust expr_B167_cp_0 = Main.dust[num194];
											expr_B167_cp_0.velocity.Y = expr_B167_cp_0.velocity.Y / 2f;
										}
									}
									else
									{
										if (this.meleeEnchant == 5)
										{
											if (Main.rand.Next(2) == 0)
											{
												int num195 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 169, 0f, 0f, 100, default(Color), 1f);
												Dust expr_B1F4_cp_0 = Main.dust[num195];
												expr_B1F4_cp_0.velocity.X = expr_B1F4_cp_0.velocity.X + (float)this.direction;
												Dust expr_B214_cp_0 = Main.dust[num195];
												expr_B214_cp_0.velocity.Y = expr_B214_cp_0.velocity.Y + 0.2f;
												Main.dust[num195].noGravity = true;
											}
										}
										else
										{
											if (this.meleeEnchant == 6)
											{
												if (Main.rand.Next(2) == 0)
												{
													int num196 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 135, 0f, 0f, 100, default(Color), 1f);
													Dust expr_B2AF_cp_0 = Main.dust[num196];
													expr_B2AF_cp_0.velocity.X = expr_B2AF_cp_0.velocity.X + (float)this.direction;
													Dust expr_B2CF_cp_0 = Main.dust[num196];
													expr_B2CF_cp_0.velocity.Y = expr_B2CF_cp_0.velocity.Y + 0.2f;
													Main.dust[num196].noGravity = true;
												}
											}
											else
											{
												if (this.meleeEnchant == 7)
												{
													if (Main.rand.Next(20) == 0)
													{
														int type3 = Main.rand.Next(139, 143);
														int num197 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, type3, this.velocity.X, this.velocity.Y, 0, default(Color), 1.2f);
														Dust expr_B389_cp_0 = Main.dust[num197];
														expr_B389_cp_0.velocity.X = expr_B389_cp_0.velocity.X * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
														Dust expr_B3BD_cp_0 = Main.dust[num197];
														expr_B3BD_cp_0.velocity.Y = expr_B3BD_cp_0.velocity.Y * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
														Dust expr_B3F1_cp_0 = Main.dust[num197];
														expr_B3F1_cp_0.velocity.X = expr_B3F1_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.05f;
														Dust expr_B41F_cp_0 = Main.dust[num197];
														expr_B41F_cp_0.velocity.Y = expr_B41F_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.05f;
														Main.dust[num197].scale *= 1f + (float)Main.rand.Next(-30, 31) * 0.01f;
													}
													if (Main.rand.Next(40) == 0)
													{
														int type4 = Main.rand.Next(276, 283);
														int num198 = Gore.NewGore(new Vector2((float)rectangle.X, (float)rectangle.Y), this.velocity, type4, 1f);
														Gore expr_B4CC_cp_0 = Main.gore[num198];
														expr_B4CC_cp_0.velocity.X = expr_B4CC_cp_0.velocity.X * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
														Gore expr_B500_cp_0 = Main.gore[num198];
														expr_B500_cp_0.velocity.Y = expr_B500_cp_0.velocity.Y * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
														Main.gore[num198].scale *= 1f + (float)Main.rand.Next(-20, 21) * 0.01f;
														Gore expr_B563_cp_0 = Main.gore[num198];
														expr_B563_cp_0.velocity.X = expr_B563_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.05f;
														Gore expr_B591_cp_0 = Main.gore[num198];
														expr_B591_cp_0.velocity.Y = expr_B591_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.05f;
													}
												}
												else
												{
													if (this.meleeEnchant == 8 && Main.rand.Next(4) == 0)
													{
														int num199 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 46, 0f, 0f, 100, default(Color), 1f);
														Main.dust[num199].noGravity = true;
														Main.dust[num199].fadeIn = 1.5f;
														Main.dust[num199].velocity *= 0.25f;
													}
												}
											}
										}
									}
								}
							}
						}
					}
					if (this.magmaStone && this.inventory[this.selectedItem].melee && !this.inventory[this.selectedItem].noMelee && !this.inventory[this.selectedItem].noUseGraphic && Main.rand.Next(3) != 0)
					{
						int num200 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 6, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 2.5f);
						Main.dust[num200].noGravity = true;
						Dust expr_B742_cp_0 = Main.dust[num200];
						expr_B742_cp_0.velocity.X = expr_B742_cp_0.velocity.X * 2f;
						Dust expr_B760_cp_0 = Main.dust[num200];
						expr_B760_cp_0.velocity.Y = expr_B760_cp_0.velocity.Y * 2f;
					}
					if (Main.myPlayer == i && this.inventory[this.selectedItem].type == 1991)
					{
						for (int num201 = 0; num201 < 200; num201++)
						{
							if (Main.npc[num201].active && Main.npc[num201].catchItem > 0)
							{
								Rectangle value = new Rectangle((int)Main.npc[num201].position.X, (int)Main.npc[num201].position.Y, Main.npc[num201].width, Main.npc[num201].height);
								if (rectangle.Intersects(value) && (Main.npc[num201].noTileCollide || Collision.CanHit(this.position, this.width, this.height, Main.npc[num201].position, Main.npc[num201].width, Main.npc[num201].height)))
								{
									int arg_B87D_0 = Main.npc[num201].type;
									Item item2 = new Item();
									item2.SetDefaults((int)Main.npc[num201].catchItem, false);
									Item item3 = this.GetItem(this.whoAmi, item2);
									if (item3.stack > 0)
									{
										int number = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, (int)Main.npc[num201].catchItem, 1, false, 0, true);
										if (Main.netMode == 1)
										{
											NetMessage.SendData(21, -1, -1, "", number, 1f, 0f, 0f, 0);
										}
									}
									else
									{
										item2.position.X = this.center().X - (float)(item2.width / 2);
										item2.position.Y = this.center().Y - (float)(item2.height / 2);
										item2.active = true;
										ItemText.NewText(item2, 0);
									}
									NPC.CatchNPC(num201, -1);
								}
							}
						}
					}
					else
					{
						if (Main.myPlayer == i && this.inventory[this.selectedItem].damage > 0)
						{
							int num202 = (int)((float)this.inventory[this.selectedItem].damage * this.meleeDamage);
							float num203 = this.inventory[this.selectedItem].knockBack;
							if (this.kbGlove)
							{
								num203 *= 2f;
							}
							int num204 = rectangle.X / 16;
							int num205 = (rectangle.X + rectangle.Width) / 16 + 1;
							int num206 = rectangle.Y / 16;
							int num207 = (rectangle.Y + rectangle.Height) / 16 + 1;
							for (int num208 = num204; num208 < num205; num208++)
							{
								for (int num209 = num206; num209 < num207; num209++)
								{
									if (Main.tile[num208, num209] != null && Main.tileCut[(int)Main.tile[num208, num209].type] && Main.tile[num208, num209 + 1] != null && Main.tile[num208, num209 + 1].type != 78)
									{
										if (this.inventory[this.selectedItem].type == 1786)
										{
											int type5 = (int)Main.tile[num208, num209].type;
											WorldGen.KillTile(num208, num209, false, false, false);
											if (!Main.tile[num208, num209].active())
											{
												int num210 = 0;
												if (type5 == 3 || type5 == 24 || type5 == 61 || type5 == 110 || type5 == 201)
												{
													num210 = Main.rand.Next(1, 3);
												}
												if (type5 == 73 || type5 == 74 || type5 == 113)
												{
													num210 = Main.rand.Next(2, 5);
												}
												if (num210 > 0)
												{
													int number2 = Item.NewItem(num208 * 16, num209 * 16, 16, 16, 1727, num210, false, 0, false);
													if (Main.netMode == 1)
													{
														NetMessage.SendData(21, -1, -1, "", number2, 1f, 0f, 0f, 0);
													}
												}
											}
											if (Main.netMode == 1)
											{
												NetMessage.SendData(17, -1, -1, "", 0, (float)num208, (float)num209, 0f, 0);
											}
										}
										else
										{
											WorldGen.KillTile(num208, num209, false, false, false);
											if (Main.netMode == 1)
											{
												NetMessage.SendData(17, -1, -1, "", 0, (float)num208, (float)num209, 0f, 0);
											}
										}
									}
								}
							}
							for (int num211 = 0; num211 < 200; num211++)
							{
								if (Main.npc[num211].active && Main.npc[num211].immune[i] == 0 && this.attackCD == 0 && !Main.npc[num211].dontTakeDamage && (!Main.npc[num211].friendly || (Main.npc[num211].type == 22 && this.killGuide) || (Main.npc[num211].type == 54 && this.killClothier)))
								{
									Rectangle value2 = new Rectangle((int)Main.npc[num211].position.X, (int)Main.npc[num211].position.Y, Main.npc[num211].width, Main.npc[num211].height);
									if (rectangle.Intersects(value2) && (Main.npc[num211].noTileCollide || Collision.CanHit(this.position, this.width, this.height, Main.npc[num211].position, Main.npc[num211].width, Main.npc[num211].height)))
									{
										bool flag12 = false;
										if (Main.rand.Next(1, 101) <= this.meleeCrit)
										{
											flag12 = true;
										}
										int num212 = Main.DamageVar((float)num202);
										this.StatusNPC(this.inventory[this.selectedItem].type, num211);
										this.onHit(Main.npc[num211].center().X, Main.npc[num211].center().Y);
										int num213 = (int)Main.npc[num211].StrikeNPC(num212, num203, this.direction, flag12, false);
										if (this.beetleOffense)
										{
											this.beetleCounter += (float)num213;
											this.beetleCountdown = 0;
										}
										if (this.inventory[this.selectedItem].type == 1826)
										{
											this.pumpkinSword(num211, (int)((double)num202 * 1.5), num203);
										}
										if (this.meleeEnchant == 7)
										{
											Projectile.NewProjectile(Main.npc[num211].center().X, Main.npc[num211].center().Y, Main.npc[num211].velocity.X, Main.npc[num211].velocity.Y, 289, 0, 0f, this.whoAmi, 0f, 0f);
										}
										if (this.inventory[this.selectedItem].type == 1123)
										{
											int num214 = Main.rand.Next(1, 4);
											for (int num215 = 0; num215 < num214; num215++)
											{
												float num216 = (float)(this.direction * 2) + (float)Main.rand.Next(-35, 36) * 0.02f;
												float num217 = (float)Main.rand.Next(-35, 36) * 0.02f;
												num216 *= 0.2f;
												num217 *= 0.2f;
												Projectile.NewProjectile((float)(rectangle.X + rectangle.Width / 2), (float)(rectangle.Y + rectangle.Height / 2), num216, num217, 181, num212 / 3, 0f, i, 0f, 0f);
											}
										}
										if (Main.npc[num211].value > 0f && this.coins && Main.rand.Next(5) == 0)
										{
											int type6 = 71;
											if (Main.rand.Next(10) == 0)
											{
												type6 = 72;
											}
											if (Main.rand.Next(100) == 0)
											{
												type6 = 73;
											}
											int num218 = Item.NewItem((int)Main.npc[num211].position.X, (int)Main.npc[num211].position.Y, Main.npc[num211].width, Main.npc[num211].height, type6, 1, false, 0, false);
											Main.item[num218].stack = Main.rand.Next(1, 11);
											Main.item[num218].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
											Main.item[num218].velocity.X = (float)Main.rand.Next(10, 31) * 0.2f * (float)this.direction;
											if (Main.netMode == 1)
											{
												NetMessage.SendData(21, -1, -1, "", num218, 0f, 0f, 0f, 0);
											}
										}
										if (Main.netMode != 0)
										{
											if (flag12)
											{
												NetMessage.SendData(28, -1, -1, "", num211, (float)num212, num203, (float)this.direction, 1);
											}
											else
											{
												NetMessage.SendData(28, -1, -1, "", num211, (float)num212, num203, (float)this.direction, 0);
											}
										}
										Main.npc[num211].immune[i] = this.itemAnimation;
										this.attackCD = (int)((double)this.itemAnimationMax * 0.33);
									}
								}
							}
							if (this.hostile)
							{
								for (int num219 = 0; num219 < 255; num219++)
								{
									if (num219 != i && Main.player[num219].active && Main.player[num219].hostile && !Main.player[num219].immune && !Main.player[num219].dead && (Main.player[i].team == 0 || Main.player[i].team != Main.player[num219].team))
									{
										Rectangle value3 = new Rectangle((int)Main.player[num219].position.X, (int)Main.player[num219].position.Y, Main.player[num219].width, Main.player[num219].height);
										if (rectangle.Intersects(value3) && Collision.CanHit(this.position, this.width, this.height, Main.player[num219].position, Main.player[num219].width, Main.player[num219].height))
										{
											bool flag13 = false;
											if (Main.rand.Next(1, 101) <= 10)
											{
												flag13 = true;
											}
											int num220 = Main.DamageVar((float)num202);
											this.StatusPvP(this.inventory[this.selectedItem].type, num219);
											this.onHit(Main.player[num219].center().X, Main.player[num219].center().Y);
											Main.player[num219].Hurt(num220, this.direction, true, false, "", flag13);
											if (this.meleeEnchant == 7)
											{
												Projectile.NewProjectile(Main.player[num219].center().X, Main.player[num219].center().Y, Main.player[num219].velocity.X, Main.player[num219].velocity.Y, 289, 0, 0f, this.whoAmi, 0f, 0f);
											}
											if (this.inventory[this.selectedItem].type == 1123)
											{
												int num221 = Main.rand.Next(1, 4);
												for (int num222 = 0; num222 < num221; num222++)
												{
													float num223 = (float)(this.direction * 2) + (float)Main.rand.Next(-35, 36) * 0.02f;
													float num224 = (float)Main.rand.Next(-35, 36) * 0.02f;
													num223 *= 0.2f;
													num224 *= 0.2f;
													Projectile.NewProjectile((float)(rectangle.X + rectangle.Width / 2), (float)(rectangle.Y + rectangle.Height / 2), num223, num224, 181, num220 / 3, 0f, i, 0f, 0f);
												}
											}
											if (Main.netMode != 0)
											{
												if (flag13)
												{
													NetMessage.SendData(26, -1, -1, Lang.deathMsg(this.whoAmi, -1, -1, -1), num219, (float)this.direction, (float)num220, 1f, 1);
												}
												else
												{
													NetMessage.SendData(26, -1, -1, Lang.deathMsg(this.whoAmi, -1, -1, -1), num219, (float)this.direction, (float)num220, 1f, 0);
												}
											}
											this.attackCD = (int)((double)this.itemAnimationMax * 0.33);
										}
									}
								}
							}
							if (this.inventory[this.selectedItem].type == 787 && (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.1) || this.itemAnimation == (int)((double)this.itemAnimationMax * 0.3) || this.itemAnimation == (int)((double)this.itemAnimationMax * 0.5) || this.itemAnimation == (int)((double)this.itemAnimationMax * 0.7) || this.itemAnimation == (int)((double)this.itemAnimationMax * 0.9)))
							{
								float num225 = 0f;
								float num226 = 0f;
								float num227 = 0f;
								float num228 = 0f;
								if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.9))
								{
									num225 = -7f;
								}
								if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.7))
								{
									num225 = -6f;
									num226 = 2f;
								}
								if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.5))
								{
									num225 = -4f;
									num226 = 4f;
								}
								if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.3))
								{
									num225 = -2f;
									num226 = 6f;
								}
								if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.1))
								{
									num226 = 7f;
								}
								if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.7))
								{
									num228 = 26f;
								}
								if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.3))
								{
									num228 -= 4f;
									num227 -= 20f;
								}
								if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.1))
								{
									num227 += 6f;
								}
								if (this.direction == -1)
								{
									if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.9))
									{
										num228 -= 8f;
									}
									if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.7))
									{
										num228 -= 6f;
									}
								}
								num225 *= 1.5f;
								num226 *= 1.5f;
								num228 *= (float)this.direction;
								num227 *= this.gravDir;
								Projectile.NewProjectile((float)(rectangle.X + rectangle.Width / 2) + num228, (float)(rectangle.Y + rectangle.Height / 2) + num227, (float)this.direction * num226, num225 * this.gravDir, 131, num202 / 2, 0f, i, 0f, 0f);
							}
						}
					}
				}
			}
			if (this.itemTime == 0 && this.itemAnimation > 0)
			{
				if (this.inventory[this.selectedItem].hairDye >= 0)
				{
					this.itemTime = this.inventory[this.selectedItem].useTime;
					if (this.whoAmi == Main.myPlayer)
					{
						this.hairDye = (byte)this.inventory[this.selectedItem].hairDye;
						NetMessage.SendData(4, -1, -1, Main.player[this.whoAmi].name, this.whoAmi, 0f, 0f, 0f, 0);
					}
				}
				if (this.inventory[this.selectedItem].healLife > 0)
				{
					this.statLife += this.inventory[this.selectedItem].healLife;
					this.itemTime = this.inventory[this.selectedItem].useTime;
					if (Main.myPlayer == this.whoAmi)
					{
						this.HealEffect(this.inventory[this.selectedItem].healLife, true);
					}
				}
				if (this.inventory[this.selectedItem].healMana > 0)
				{
					this.statMana += this.inventory[this.selectedItem].healMana;
					this.itemTime = this.inventory[this.selectedItem].useTime;
					if (Main.myPlayer == this.whoAmi)
					{
						this.AddBuff(94, Player.manaSickTime, true);
						this.ManaEffect(this.inventory[this.selectedItem].healMana);
					}
				}
				if (this.inventory[this.selectedItem].buffType > 0)
				{
					if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].buffType != 90)
					{
						this.AddBuff(this.inventory[this.selectedItem].buffType, this.inventory[this.selectedItem].buffTime, true);
					}
					this.itemTime = this.inventory[this.selectedItem].useTime;
				}
				if (this.inventory[this.selectedItem].type == 678)
				{
					this.itemTime = this.inventory[this.selectedItem].useTime;
					if (this.whoAmi == Main.myPlayer)
					{
						this.AddBuff(20, 216000, true);
						this.AddBuff(22, 216000, true);
						this.AddBuff(23, 216000, true);
						this.AddBuff(24, 216000, true);
						this.AddBuff(30, 216000, true);
						this.AddBuff(31, 216000, true);
						this.AddBuff(32, 216000, true);
						this.AddBuff(33, 216000, true);
						this.AddBuff(35, 216000, true);
						this.AddBuff(36, 216000, true);
						this.AddBuff(68, 216000, true);
					}
				}
			}
			if (this.whoAmi == Main.myPlayer)
			{
				if (this.itemTime == 0 && this.itemAnimation > 0 && this.inventory[this.selectedItem].type == 361)
				{
					this.itemTime = this.inventory[this.selectedItem].useTime;
					Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
					if (Main.netMode != 1)
					{
						if (Main.invasionType == 0)
						{
							Main.invasionDelay = 0;
							Main.StartInvasion(1);
						}
					}
					else
					{
						NetMessage.SendData(61, -1, -1, "", this.whoAmi, -1f, 0f, 0f, 0);
					}
				}
				if (this.itemTime == 0 && this.itemAnimation > 0 && this.inventory[this.selectedItem].type == 602)
				{
					this.itemTime = this.inventory[this.selectedItem].useTime;
					Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
					if (Main.netMode != 1)
					{
						if (Main.invasionType == 0)
						{
							Main.invasionDelay = 0;
							Main.StartInvasion(2);
						}
					}
					else
					{
						NetMessage.SendData(61, -1, -1, "", this.whoAmi, -2f, 0f, 0f, 0);
					}
				}
				if (this.itemTime == 0 && this.itemAnimation > 0 && this.inventory[this.selectedItem].type == 1315)
				{
					this.itemTime = this.inventory[this.selectedItem].useTime;
					Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
					if (Main.netMode != 1)
					{
						if (Main.invasionType == 0)
						{
							Main.invasionDelay = 0;
							Main.StartInvasion(3);
						}
					}
					else
					{
						NetMessage.SendData(61, -1, -1, "", this.whoAmi, -3f, 0f, 0f, 0);
					}
				}
				if (this.itemTime == 0 && this.itemAnimation > 0 && this.inventory[this.selectedItem].type == 1844 && !Main.dayTime && !Main.pumpkinMoon && !Main.snowMoon)
				{
					this.itemTime = this.inventory[this.selectedItem].useTime;
					Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
					if (Main.netMode != 1)
					{
						Main.NewText(Lang.misc[31], 50, 255, 130, false);
						Main.startPumpkinMoon();
					}
					else
					{
						NetMessage.SendData(61, -1, -1, "", this.whoAmi, -4f, 0f, 0f, 0);
					}
				}
				if (this.itemTime == 0 && this.itemAnimation > 0 && this.inventory[this.selectedItem].type == 1958 && !Main.dayTime && !Main.pumpkinMoon && !Main.snowMoon)
				{
					this.itemTime = this.inventory[this.selectedItem].useTime;
					Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
					if (Main.netMode != 1)
					{
						Main.NewText(Lang.misc[34], 50, 255, 130, false);
						Main.startSnowMoon();
					}
					else
					{
						NetMessage.SendData(61, -1, -1, "", this.whoAmi, -5f, 0f, 0f, 0);
					}
				}
				if (this.itemTime == 0 && this.itemAnimation > 0 && this.inventory[this.selectedItem].makeNPC > 0 && this.controlUseItem && this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f >= (float)Player.tileTargetY)
				{
					this.itemTime = this.inventory[this.selectedItem].useTime;
					int x6 = Main.mouseX + (int)Main.screenPosition.X;
					int y6 = Main.mouseY + (int)Main.screenPosition.Y;
					NPC.ReleaseNPC(x6, y6, (int)this.inventory[this.selectedItem].makeNPC, this.inventory[this.selectedItem].placeStyle, this.whoAmi);
				}
				if (this.itemTime == 0 && this.itemAnimation > 0 && (this.inventory[this.selectedItem].type == 43 || this.inventory[this.selectedItem].type == 70 || this.inventory[this.selectedItem].type == 544 || this.inventory[this.selectedItem].type == 556 || this.inventory[this.selectedItem].type == 557 || this.inventory[this.selectedItem].type == 560 || this.inventory[this.selectedItem].type == 1133 || this.inventory[this.selectedItem].type == 1331) && this.SummonItemCheck())
				{
					if (this.inventory[this.selectedItem].type == 560)
					{
						this.itemTime = this.inventory[this.selectedItem].useTime;
						Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
						if (Main.netMode != 1)
						{
							NPC.SpawnOnPlayer(i, 50);
						}
						else
						{
							NetMessage.SendData(61, -1, -1, "", this.whoAmi, 50f, 0f, 0f, 0);
						}
					}
					else
					{
						if (this.inventory[this.selectedItem].type == 43)
						{
							if (!Main.dayTime)
							{
								this.itemTime = this.inventory[this.selectedItem].useTime;
								Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
								if (Main.netMode != 1)
								{
									NPC.SpawnOnPlayer(i, 4);
								}
								else
								{
									NetMessage.SendData(61, -1, -1, "", this.whoAmi, 4f, 0f, 0f, 0);
								}
							}
						}
						else
						{
							if (this.inventory[this.selectedItem].type == 70)
							{
								if (this.zoneEvil)
								{
									this.itemTime = this.inventory[this.selectedItem].useTime;
									Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
									if (Main.netMode != 1)
									{
										NPC.SpawnOnPlayer(i, 13);
									}
									else
									{
										NetMessage.SendData(61, -1, -1, "", this.whoAmi, 13f, 0f, 0f, 0);
									}
								}
							}
							else
							{
								if (this.inventory[this.selectedItem].type == 544)
								{
									if (!Main.dayTime)
									{
										this.itemTime = this.inventory[this.selectedItem].useTime;
										Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
										if (Main.netMode != 1)
										{
											NPC.SpawnOnPlayer(i, 125);
											NPC.SpawnOnPlayer(i, 126);
										}
										else
										{
											NetMessage.SendData(61, -1, -1, "", this.whoAmi, 125f, 0f, 0f, 0);
											NetMessage.SendData(61, -1, -1, "", this.whoAmi, 126f, 0f, 0f, 0);
										}
									}
								}
								else
								{
									if (this.inventory[this.selectedItem].type == 556)
									{
										if (!Main.dayTime)
										{
											this.itemTime = this.inventory[this.selectedItem].useTime;
											Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
											if (Main.netMode != 1)
											{
												NPC.SpawnOnPlayer(i, 134);
											}
											else
											{
												NetMessage.SendData(61, -1, -1, "", this.whoAmi, 134f, 0f, 0f, 0);
											}
										}
									}
									else
									{
										if (this.inventory[this.selectedItem].type == 557)
										{
											if (!Main.dayTime)
											{
												this.itemTime = this.inventory[this.selectedItem].useTime;
												Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
												if (Main.netMode != 1)
												{
													NPC.SpawnOnPlayer(i, 127);
												}
												else
												{
													NetMessage.SendData(61, -1, -1, "", this.whoAmi, 127f, 0f, 0f, 0);
												}
											}
										}
										else
										{
											if (this.inventory[this.selectedItem].type == 1133)
											{
												this.itemTime = this.inventory[this.selectedItem].useTime;
												Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
												if (Main.netMode != 1)
												{
													NPC.SpawnOnPlayer(i, 222);
												}
												else
												{
													NetMessage.SendData(61, -1, -1, "", this.whoAmi, 222f, 0f, 0f, 0);
												}
											}
											else
											{
												if (this.inventory[this.selectedItem].type == 1331 && this.zoneBlood)
												{
													this.itemTime = this.inventory[this.selectedItem].useTime;
													Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
													if (Main.netMode != 1)
													{
														NPC.SpawnOnPlayer(i, 266);
													}
													else
													{
														NetMessage.SendData(61, -1, -1, "", this.whoAmi, 266f, 0f, 0f, 0);
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
			if (this.inventory[this.selectedItem].type == 50 && this.itemAnimation > 0)
			{
				if (Main.rand.Next(2) == 0)
				{
					Dust.NewDust(this.position, this.width, this.height, 15, 0f, 0f, 150, default(Color), 1.1f);
				}
				if (this.itemTime == 0)
				{
					this.itemTime = this.inventory[this.selectedItem].useTime;
				}
				else
				{
					if (this.itemTime == this.inventory[this.selectedItem].useTime / 2)
					{
						for (int num229 = 0; num229 < 70; num229++)
						{
							Dust.NewDust(this.position, this.width, this.height, 15, this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 150, default(Color), 1.5f);
						}
						this.grappling[0] = -1;
						this.grapCount = 0;
						for (int num230 = 0; num230 < 1000; num230++)
						{
							if (Main.projectile[num230].active && Main.projectile[num230].owner == i && Main.projectile[num230].aiStyle == 7)
							{
								Main.projectile[num230].Kill();
							}
						}
						this.Spawn();
						for (int num231 = 0; num231 < 70; num231++)
						{
							Dust.NewDust(this.position, this.width, this.height, 15, 0f, 0f, 150, default(Color), 1.5f);
						}
					}
				}
			}
			if (i == Main.myPlayer)
			{
				if (this.itemTime == this.inventory[this.selectedItem].useTime && this.inventory[this.selectedItem].tileWand > 0)
				{
					int tileWand2 = this.inventory[this.selectedItem].tileWand;
					int num232 = 0;
					while (num232 < 58)
					{
						if (tileWand2 == this.inventory[num232].type && this.inventory[num232].stack > 0)
						{
							this.inventory[num232].stack--;
							if (this.inventory[num232].stack <= 0)
							{
								this.inventory[num232] = new Item();
								break;
							}
							break;
						}
						else
						{
							num232++;
						}
					}
				}
				int num233;
				if (this.inventory[this.selectedItem].createTile >= 0)
				{
					num233 = (int)((float)this.inventory[this.selectedItem].useTime * this.tileSpeed);
				}
				else
				{
					if (this.inventory[this.selectedItem].createWall > 0)
					{
						num233 = (int)((float)this.inventory[this.selectedItem].useTime * this.wallSpeed);
					}
					else
					{
						num233 = this.inventory[this.selectedItem].useTime;
					}
				}
				if (this.itemTime == num233 && this.inventory[this.selectedItem].consumable)
				{
					bool flag14 = true;
					if (this.inventory[this.selectedItem].ranged)
					{
						if (this.ammoCost80 && Main.rand.Next(5) == 0)
						{
							flag14 = false;
						}
						if (this.ammoCost75 && Main.rand.Next(4) == 0)
						{
							flag14 = false;
						}
					}
					if (flag14)
					{
						if (this.inventory[this.selectedItem].stack > 0)
						{
							this.inventory[this.selectedItem].stack--;
						}
						if (this.inventory[this.selectedItem].stack <= 0)
						{
							this.itemTime = this.itemAnimation;
						}
					}
				}
				if (this.inventory[this.selectedItem].stack <= 0 && this.itemAnimation == 0)
				{
					this.inventory[this.selectedItem] = new Item();
				}
				if (this.selectedItem == 58)
				{
					if (this.itemAnimation == 0)
					{
						return;
					}
					Main.mouseItem = this.inventory[this.selectedItem].Clone();
				}
			}
		}
		public Color GetImmuneAlpha(Color newColor)
		{
			float num = (float)(255 - this.immuneAlpha) / 255f;
			if (this.shadow > 0f)
			{
				num *= 1f - this.shadow;
			}
			if (this.immuneAlpha > 125)
			{
				return new Color(0, 0, 0, 0);
			}
			int r = (int)((float)newColor.R * num);
			int g = (int)((float)newColor.G * num);
			int b = (int)((float)newColor.B * num);
			int num2 = (int)((float)newColor.A * num);
			if (num2 < 0)
			{
				num2 = 0;
			}
			if (num2 > 255)
			{
				num2 = 255;
			}
			return new Color(r, g, b, num2);
		}
		public Color GetImmuneAlpha2(Color newColor)
		{
			float num = (float)(255 - this.immuneAlpha) / 255f;
			if (this.shadow > 0f)
			{
				num *= 1f - this.shadow;
			}
			int r = (int)((float)newColor.R * num);
			int g = (int)((float)newColor.G * num);
			int b = (int)((float)newColor.B * num);
			int num2 = (int)((float)newColor.A * num);
			if (num2 < 0)
			{
				num2 = 0;
			}
			if (num2 > 255)
			{
				num2 = 255;
			}
			return new Color(r, g, b, num2);
		}
		public Color GetDeathAlpha(Color newColor)
		{
			int r = (int)newColor.R + (int)((double)this.immuneAlpha * 0.9);
			int g = (int)newColor.G + (int)((double)this.immuneAlpha * 0.5);
			int b = (int)newColor.B + (int)((double)this.immuneAlpha * 0.5);
			int num = (int)newColor.A + (int)((double)this.immuneAlpha * 0.4);
			if (num < 0)
			{
				num = 0;
			}
			if (num > 255)
			{
				num = 255;
			}
			return new Color(r, g, b, num);
		}
		public void DropCoins()
		{
			for (int i = 0; i < 59; i++)
			{
				if (this.inventory[i].type >= 71 && this.inventory[i].type <= 74)
				{
					int num = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, this.inventory[i].type, 1, false, 0, false);
					int num2 = this.inventory[i].stack / 2;
					num2 = this.inventory[i].stack - num2;
					this.inventory[i].stack -= num2;
					if (this.inventory[i].stack <= 0)
					{
						this.inventory[i] = new Item();
					}
					Main.item[num].stack = num2;
					Main.item[num].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
					Main.item[num].velocity.X = (float)Main.rand.Next(-20, 21) * 0.2f;
					Main.item[num].noGrabDelay = 100;
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", num, 0f, 0f, 0f, 0);
					}
					if (i == 58)
					{
						Main.mouseItem = this.inventory[i].Clone();
					}
				}
			}
		}
		public void DropItems()
		{
			for (int i = 0; i < 59; i++)
			{
				if (this.inventory[i].stack > 0 && this.inventory[i].name != "Copper Pickaxe" && this.inventory[i].name != "Copper Axe" && this.inventory[i].name != "Copper Shortsword")
				{
					int num = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, this.inventory[i].type, 1, false, 0, false);
					Main.item[num].SetDefaults(this.inventory[i].name);
					Main.item[num].Prefix((int)this.inventory[i].prefix);
					Main.item[num].stack = this.inventory[i].stack;
					Main.item[num].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
					Main.item[num].velocity.X = (float)Main.rand.Next(-20, 21) * 0.2f;
					Main.item[num].noGrabDelay = 100;
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", num, 0f, 0f, 0f, 0);
					}
				}
				this.inventory[i] = new Item();
				if (i < 16)
				{
					if (this.armor[i].stack > 0)
					{
						int num2 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, this.armor[i].type, 1, false, 0, false);
						Main.item[num2].SetDefaults(this.armor[i].name);
						Main.item[num2].Prefix((int)this.armor[i].prefix);
						Main.item[num2].stack = this.armor[i].stack;
						Main.item[num2].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
						Main.item[num2].velocity.X = (float)Main.rand.Next(-20, 21) * 0.2f;
						Main.item[num2].noGrabDelay = 100;
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", num2, 0f, 0f, 0f, 0);
						}
					}
					this.armor[i] = new Item();
				}
				if (i < 8)
				{
					if (this.dye[i].stack > 0)
					{
						int num3 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, this.dye[i].type, 1, false, 0, false);
						Main.item[num3].SetDefaults(this.dye[i].name);
						Main.item[num3].Prefix((int)this.dye[i].prefix);
						Main.item[num3].stack = this.dye[i].stack;
						Main.item[num3].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
						Main.item[num3].velocity.X = (float)Main.rand.Next(-20, 21) * 0.2f;
						Main.item[num3].noGrabDelay = 100;
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", num3, 0f, 0f, 0f, 0);
						}
					}
					this.dye[i] = new Item();
				}
			}
			this.inventory[0].SetDefaults("Copper Shortsword");
			this.inventory[0].Prefix(-1);
			this.inventory[1].SetDefaults("Copper Pickaxe");
			this.inventory[1].Prefix(-1);
			this.inventory[2].SetDefaults("Copper Axe");
			this.inventory[2].Prefix(-1);
			Main.mouseItem = new Item();
		}
		public object Clone()
		{
			return base.MemberwiseClone();
		}
		public object clientClone()
		{
			Player player = new Player();
			player.zoneEvil = this.zoneEvil;
			player.zoneMeteor = this.zoneMeteor;
			player.zoneDungeon = this.zoneDungeon;
			player.zoneJungle = this.zoneJungle;
			player.zoneHoly = this.zoneHoly;
			player.zoneSnow = this.zoneSnow;
			player.zoneBlood = this.zoneBlood;
			player.zoneCandle = this.zoneCandle;
			player.direction = this.direction;
			player.selectedItem = this.selectedItem;
			player.controlUp = this.controlUp;
			player.controlDown = this.controlDown;
			player.controlLeft = this.controlLeft;
			player.controlRight = this.controlRight;
			player.controlJump = this.controlJump;
			player.controlUseItem = this.controlUseItem;
			player.statLife = this.statLife;
			player.statLifeMax = this.statLifeMax;
			player.statMana = this.statMana;
			player.statManaMax = this.statManaMax;
			player.position.X = this.position.X;
			player.chest = this.chest;
			player.talkNPC = this.talkNPC;
			player.hideVisual = this.hideVisual;
			for (int i = 0; i < 59; i++)
			{
				player.inventory[i] = this.inventory[i].Clone();
				if (i < 16)
				{
					player.armor[i] = this.armor[i].Clone();
				}
				if (i < 8)
				{
					player.dye[i] = this.dye[i].Clone();
				}
			}
			for (int j = 0; j < 22; j++)
			{
				player.buffType[j] = this.buffType[j];
				player.buffTime[j] = this.buffTime[j];
			}
			return player;
		}
		private static void EncryptFile(string inputFile, string outputFile)
		{
			string s = "h3y_gUyZ";
			UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
			byte[] bytes = unicodeEncoding.GetBytes(s);
			FileStream fileStream = new FileStream(outputFile, FileMode.Create);
			RijndaelManaged rijndaelManaged = new RijndaelManaged();
			CryptoStream cryptoStream = new CryptoStream(fileStream, rijndaelManaged.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);
			FileStream fileStream2 = new FileStream(inputFile, FileMode.Open);
			int num;
			while ((num = fileStream2.ReadByte()) != -1)
			{
				cryptoStream.WriteByte((byte)num);
			}
			fileStream2.Close();
			cryptoStream.Close();
			fileStream.Close();
		}
		private static bool DecryptFile(string inputFile, string outputFile)
		{
			string s = "h3y_gUyZ";
			UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
			byte[] bytes = unicodeEncoding.GetBytes(s);
			FileStream fileStream = new FileStream(inputFile, FileMode.Open);
			RijndaelManaged rijndaelManaged = new RijndaelManaged();
			CryptoStream cryptoStream = new CryptoStream(fileStream, rijndaelManaged.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
			FileStream fileStream2 = new FileStream(outputFile, FileMode.Create);
			try
			{
				int num;
				while ((num = cryptoStream.ReadByte()) != -1)
				{
					fileStream2.WriteByte((byte)num);
				}
				fileStream2.Close();
				cryptoStream.Close();
				fileStream.Close();
			}
			catch
			{
				fileStream2.Close();
				fileStream.Close();
				File.Delete(outputFile);
				return true;
			}
			return false;
		}
		public static bool CheckSpawn(int x, int y)
		{
			if (x < 10 || x > Main.maxTilesX - 10 || y < 10 || y > Main.maxTilesX - 10)
			{
				return false;
			}
			if (Main.tile[x, y - 1] == null)
			{
				return false;
			}
			if (!Main.tile[x, y - 1].active() || Main.tile[x, y - 1].type != 79)
			{
				return false;
			}
			for (int i = x - 1; i <= x + 1; i++)
			{
				for (int j = y - 3; j < y; j++)
				{
					if (Main.tile[i, j] == null)
					{
						return false;
					}
					if (Main.tile[i, j].nactive() && Main.tileSolid[(int)Main.tile[i, j].type] && !Main.tileSolidTop[(int)Main.tile[i, j].type])
					{
						Main.NewText("There is not enough space", 255, 240, 20, false);
						return false;
					}
				}
			}
			return WorldGen.StartRoomCheck(x, y - 1);
		}
		public void FindSpawn()
		{
			for (int i = 0; i < 200; i++)
			{
				if (this.spN[i] == null)
				{
					this.SpawnX = -1;
					this.SpawnY = -1;
					return;
				}
				if (this.spN[i] == Main.worldName && this.spI[i] == Main.worldID)
				{
					this.SpawnX = this.spX[i];
					this.SpawnY = this.spY[i];
					return;
				}
			}
		}
		public void ChangeSpawn(int x, int y)
		{
			int num = 0;
			while (num < 200 && this.spN[num] != null)
			{
				if (this.spN[num] == Main.worldName && this.spI[num] == Main.worldID)
				{
					for (int i = num; i > 0; i--)
					{
						this.spN[i] = this.spN[i - 1];
						this.spI[i] = this.spI[i - 1];
						this.spX[i] = this.spX[i - 1];
						this.spY[i] = this.spY[i - 1];
					}
					this.spN[0] = Main.worldName;
					this.spI[0] = Main.worldID;
					this.spX[0] = x;
					this.spY[0] = y;
					return;
				}
				num++;
			}
			for (int j = 199; j > 0; j--)
			{
				if (this.spN[j - 1] != null)
				{
					this.spN[j] = this.spN[j - 1];
					this.spI[j] = this.spI[j - 1];
					this.spX[j] = this.spX[j - 1];
					this.spY[j] = this.spY[j - 1];
				}
			}
			this.spN[0] = Main.worldName;
			this.spI[0] = Main.worldID;
			this.spX[0] = x;
			this.spY[0] = y;
		}
		public static void SavePlayer(Player newPlayer, string playerPath, bool skipMapSave = false, bool fileAlreadyDecrypted = false)
		{
			if (!skipMapSave)
			{
				try
				{
					if (Main.mapEnabled)
					{
						Map.saveMap();
					}
				}
				catch
				{
				}
				try
				{
					Directory.CreateDirectory(Main.PlayerPath);
				}
				catch
				{
				}
			}
			if (Main.ServerSideCharacter)
			{
				return;
			}
			if (playerPath == null || playerPath == "")
			{
				return;
			}
			string destFileName = playerPath + ".bak";
			if (File.Exists(playerPath))
			{
				File.Copy(playerPath, destFileName, true);
			}
			string text = playerPath + ".dat";
			using (FileStream fileStream = new FileStream(text, FileMode.Create))
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
				{
					binaryWriter.Write(Main.curRelease);
					binaryWriter.Write(newPlayer.name);
					binaryWriter.Write(newPlayer.difficulty);
					binaryWriter.Write(newPlayer.hair);
					binaryWriter.Write(newPlayer.hairDye);
					binaryWriter.Write(newPlayer.hideVisual);
					binaryWriter.Write(newPlayer.male);
					binaryWriter.Write(newPlayer.statLife);
					binaryWriter.Write(newPlayer.statLifeMax);
					binaryWriter.Write(newPlayer.statMana);
					binaryWriter.Write(newPlayer.statManaMax);
					binaryWriter.Write(newPlayer.hairColor.R);
					binaryWriter.Write(newPlayer.hairColor.G);
					binaryWriter.Write(newPlayer.hairColor.B);
					binaryWriter.Write(newPlayer.skinColor.R);
					binaryWriter.Write(newPlayer.skinColor.G);
					binaryWriter.Write(newPlayer.skinColor.B);
					binaryWriter.Write(newPlayer.eyeColor.R);
					binaryWriter.Write(newPlayer.eyeColor.G);
					binaryWriter.Write(newPlayer.eyeColor.B);
					binaryWriter.Write(newPlayer.shirtColor.R);
					binaryWriter.Write(newPlayer.shirtColor.G);
					binaryWriter.Write(newPlayer.shirtColor.B);
					binaryWriter.Write(newPlayer.underShirtColor.R);
					binaryWriter.Write(newPlayer.underShirtColor.G);
					binaryWriter.Write(newPlayer.underShirtColor.B);
					binaryWriter.Write(newPlayer.pantsColor.R);
					binaryWriter.Write(newPlayer.pantsColor.G);
					binaryWriter.Write(newPlayer.pantsColor.B);
					binaryWriter.Write(newPlayer.shoeColor.R);
					binaryWriter.Write(newPlayer.shoeColor.G);
					binaryWriter.Write(newPlayer.shoeColor.B);
					for (int i = 0; i < 16; i++)
					{
						if (newPlayer.armor[i].name == null)
						{
							newPlayer.armor[i].name = "";
						}
						binaryWriter.Write(newPlayer.armor[i].netID);
						binaryWriter.Write(newPlayer.armor[i].prefix);
					}
					for (int j = 0; j < 8; j++)
					{
						binaryWriter.Write(newPlayer.dye[j].netID);
						binaryWriter.Write(newPlayer.dye[j].prefix);
					}
					for (int k = 0; k < 58; k++)
					{
						if (newPlayer.inventory[k].name == null)
						{
							newPlayer.inventory[k].name = "";
						}
						binaryWriter.Write(newPlayer.inventory[k].netID);
						binaryWriter.Write(newPlayer.inventory[k].stack);
						binaryWriter.Write(newPlayer.inventory[k].prefix);
					}
					for (int l = 0; l < Chest.maxItems; l++)
					{
						if (newPlayer.bank.item[l].name == null)
						{
							newPlayer.bank.item[l].name = "";
						}
						binaryWriter.Write(newPlayer.bank.item[l].netID);
						binaryWriter.Write(newPlayer.bank.item[l].stack);
						binaryWriter.Write(newPlayer.bank.item[l].prefix);
					}
					for (int m = 0; m < Chest.maxItems; m++)
					{
						if (newPlayer.bank2.item[m].name == null)
						{
							newPlayer.bank2.item[m].name = "";
						}
						binaryWriter.Write(newPlayer.bank2.item[m].netID);
						binaryWriter.Write(newPlayer.bank2.item[m].stack);
						binaryWriter.Write(newPlayer.bank2.item[m].prefix);
					}
					for (int n = 0; n < 22; n++)
					{
						binaryWriter.Write(newPlayer.buffType[n]);
						binaryWriter.Write(newPlayer.buffTime[n]);
					}
					for (int num = 0; num < 200; num++)
					{
						if (newPlayer.spN[num] == null)
						{
							binaryWriter.Write(-1);
							break;
						}
						binaryWriter.Write(newPlayer.spX[num]);
						binaryWriter.Write(newPlayer.spY[num]);
						binaryWriter.Write(newPlayer.spI[num]);
						binaryWriter.Write(newPlayer.spN[num]);
					}
					binaryWriter.Write(newPlayer.hbLocked);
					binaryWriter.Close();
				}
			}
			Player.EncryptFile(text, playerPath);
			File.Delete(text);
		}
		public static Player LoadPlayer(string playerPath, bool decryptedCopy = false)
		{
			if (Main.rand == null)
			{
				Main.rand = new Random((int)DateTime.Now.Ticks);
			}
			Player player = new Player();
			try
			{
				string text = playerPath + ".dat";
				Player result;
				if (!decryptedCopy)
				{
					bool flag = Player.DecryptFile(playerPath, text);
					if (flag)
					{
						using (FileStream fileStream = new FileStream(playerPath, FileMode.Open))
						{
							while (fileStream.Position < fileStream.Length && fileStream.ReadByte() == 0)
							{
							}
							if (fileStream.Position == fileStream.Length)
							{
								player.loadStatus = 3;
							}
							else
							{
								player.loadStatus = 4;
							}
							string[] array = playerPath.Split(new char[]
							{
								Path.DirectorySeparatorChar
							});
							player.name = array[array.Length - 1].Split(new char[]
							{
								'.'
							})[0];
							result = player;
							return result;
						}
					}
				}
				using (FileStream fileStream2 = new FileStream(text, FileMode.Open))
				{
					using (BinaryReader binaryReader = new BinaryReader(fileStream2))
					{
						int num = binaryReader.ReadInt32();
						if (num > Main.curRelease)
						{
							player.loadStatus = 1;
							player.name = binaryReader.ReadString();
							result = player;
							return result;
						}
						player.name = binaryReader.ReadString();
						if (num >= 10)
						{
							if (num >= 17)
							{
								player.difficulty = binaryReader.ReadByte();
							}
							else
							{
								bool flag2 = binaryReader.ReadBoolean();
								if (flag2)
								{
									player.difficulty = 2;
								}
							}
						}
						player.hair = binaryReader.ReadInt32();
						if (num >= 82)
						{
							player.hairDye = binaryReader.ReadByte();
						}
						if (num >= 83)
						{
							player.hideVisual = binaryReader.ReadByte();
						}
						if (num <= 17)
						{
							if (player.hair == 5 || player.hair == 6 || player.hair == 9 || player.hair == 11)
							{
								player.male = false;
							}
							else
							{
								player.male = true;
							}
						}
						else
						{
							player.male = binaryReader.ReadBoolean();
						}
						player.statLife = binaryReader.ReadInt32();
						player.statLifeMax = binaryReader.ReadInt32();
						if (player.statLifeMax > 500)
						{
							player.statLifeMax = 500;
						}
						if (player.statLife > player.statLifeMax)
						{
							player.statLife = player.statLifeMax;
						}
						player.statMana = binaryReader.ReadInt32();
						player.statManaMax = binaryReader.ReadInt32();
						if (player.statManaMax > 200)
						{
							player.statManaMax = 200;
						}
						if (player.statMana > 400)
						{
							player.statMana = 400;
						}
						player.hairColor.R = binaryReader.ReadByte();
						player.hairColor.G = binaryReader.ReadByte();
						player.hairColor.B = binaryReader.ReadByte();
						player.skinColor.R = binaryReader.ReadByte();
						player.skinColor.G = binaryReader.ReadByte();
						player.skinColor.B = binaryReader.ReadByte();
						player.eyeColor.R = binaryReader.ReadByte();
						player.eyeColor.G = binaryReader.ReadByte();
						player.eyeColor.B = binaryReader.ReadByte();
						player.shirtColor.R = binaryReader.ReadByte();
						player.shirtColor.G = binaryReader.ReadByte();
						player.shirtColor.B = binaryReader.ReadByte();
						player.underShirtColor.R = binaryReader.ReadByte();
						player.underShirtColor.G = binaryReader.ReadByte();
						player.underShirtColor.B = binaryReader.ReadByte();
						player.pantsColor.R = binaryReader.ReadByte();
						player.pantsColor.G = binaryReader.ReadByte();
						player.pantsColor.B = binaryReader.ReadByte();
						player.shoeColor.R = binaryReader.ReadByte();
						player.shoeColor.G = binaryReader.ReadByte();
						player.shoeColor.B = binaryReader.ReadByte();
						Main.player[Main.myPlayer].shirtColor = player.shirtColor;
						Main.player[Main.myPlayer].pantsColor = player.pantsColor;
						Main.player[Main.myPlayer].hairColor = player.hairColor;
						if (num >= 38)
						{
							int num2 = 11;
							if (num >= 81)
							{
								num2 = 16;
							}
							for (int i = 0; i < num2; i++)
							{
								player.armor[i].netDefaults(binaryReader.ReadInt32());
								player.armor[i].Prefix((int)binaryReader.ReadByte());
							}
							if (num >= 47)
							{
								int num3 = 3;
								if (num >= 81)
								{
									num3 = 8;
								}
								for (int j = 0; j < num3; j++)
								{
									player.dye[j].netDefaults(binaryReader.ReadInt32());
									player.dye[j].Prefix((int)binaryReader.ReadByte());
								}
							}
							if (num >= 58)
							{
								for (int k = 0; k < 58; k++)
								{
									int num4 = binaryReader.ReadInt32();
									if (num4 >= 2289)
									{
										player.inventory[k].netDefaults(0);
									}
									else
									{
										player.inventory[k].netDefaults(num4);
										player.inventory[k].stack = binaryReader.ReadInt32();
										player.inventory[k].Prefix((int)binaryReader.ReadByte());
									}
								}
							}
							else
							{
								for (int l = 0; l < 48; l++)
								{
									int num5 = binaryReader.ReadInt32();
									if (num5 >= 2289)
									{
										player.inventory[l].netDefaults(0);
									}
									else
									{
										player.inventory[l].netDefaults(num5);
										player.inventory[l].stack = binaryReader.ReadInt32();
										player.inventory[l].Prefix((int)binaryReader.ReadByte());
									}
								}
							}
							if (num >= 58)
							{
								for (int m = 0; m < 40; m++)
								{
									player.bank.item[m].netDefaults(binaryReader.ReadInt32());
									player.bank.item[m].stack = binaryReader.ReadInt32();
									player.bank.item[m].Prefix((int)binaryReader.ReadByte());
								}
								for (int n = 0; n < 40; n++)
								{
									player.bank2.item[n].netDefaults(binaryReader.ReadInt32());
									player.bank2.item[n].stack = binaryReader.ReadInt32();
									player.bank2.item[n].Prefix((int)binaryReader.ReadByte());
								}
							}
							else
							{
								for (int num6 = 0; num6 < 20; num6++)
								{
									player.bank.item[num6].netDefaults(binaryReader.ReadInt32());
									player.bank.item[num6].stack = binaryReader.ReadInt32();
									player.bank.item[num6].Prefix((int)binaryReader.ReadByte());
								}
								for (int num7 = 0; num7 < 20; num7++)
								{
									player.bank2.item[num7].netDefaults(binaryReader.ReadInt32());
									player.bank2.item[num7].stack = binaryReader.ReadInt32();
									player.bank2.item[num7].Prefix((int)binaryReader.ReadByte());
								}
							}
						}
						else
						{
							for (int num8 = 0; num8 < 8; num8++)
							{
								player.armor[num8].SetDefaults(Item.VersionName(binaryReader.ReadString(), num));
								if (num >= 36)
								{
									player.armor[num8].Prefix((int)binaryReader.ReadByte());
								}
							}
							if (num >= 6)
							{
								for (int num9 = 8; num9 < 11; num9++)
								{
									player.armor[num9].SetDefaults(Item.VersionName(binaryReader.ReadString(), num));
									if (num >= 36)
									{
										player.armor[num9].Prefix((int)binaryReader.ReadByte());
									}
								}
							}
							for (int num10 = 0; num10 < 44; num10++)
							{
								player.inventory[num10].SetDefaults(Item.VersionName(binaryReader.ReadString(), num));
								player.inventory[num10].stack = binaryReader.ReadInt32();
								if (num >= 36)
								{
									player.inventory[num10].Prefix((int)binaryReader.ReadByte());
								}
							}
							if (num >= 15)
							{
								for (int num11 = 44; num11 < 48; num11++)
								{
									player.inventory[num11].SetDefaults(Item.VersionName(binaryReader.ReadString(), num));
									player.inventory[num11].stack = binaryReader.ReadInt32();
									if (num >= 36)
									{
										player.inventory[num11].Prefix((int)binaryReader.ReadByte());
									}
								}
							}
							for (int num12 = 0; num12 < 20; num12++)
							{
								player.bank.item[num12].SetDefaults(Item.VersionName(binaryReader.ReadString(), num));
								player.bank.item[num12].stack = binaryReader.ReadInt32();
								if (num >= 36)
								{
									player.bank.item[num12].Prefix((int)binaryReader.ReadByte());
								}
							}
							if (num >= 20)
							{
								for (int num13 = 0; num13 < 20; num13++)
								{
									player.bank2.item[num13].SetDefaults(Item.VersionName(binaryReader.ReadString(), num));
									player.bank2.item[num13].stack = binaryReader.ReadInt32();
									if (num >= 36)
									{
										player.bank2.item[num13].Prefix((int)binaryReader.ReadByte());
									}
								}
							}
						}
						if (num < 58)
						{
							for (int num14 = 40; num14 < 48; num14++)
							{
								player.inventory[num14 + 10] = player.inventory[num14].Clone();
								player.inventory[num14].SetDefaults(0, false);
							}
						}
						if (num >= 11)
						{
							int num15 = 22;
							if (num < 74)
							{
								num15 = 10;
							}
							for (int num16 = 0; num16 < num15; num16++)
							{
								player.buffType[num16] = binaryReader.ReadInt32();
								player.buffTime[num16] = binaryReader.ReadInt32();
							}
						}
						for (int num17 = 0; num17 < 200; num17++)
						{
							int num18 = binaryReader.ReadInt32();
							if (num18 == -1)
							{
								break;
							}
							player.spX[num17] = num18;
							player.spY[num17] = binaryReader.ReadInt32();
							player.spI[num17] = binaryReader.ReadInt32();
							player.spN[num17] = binaryReader.ReadString();
						}
						if (num >= 16)
						{
							player.hbLocked = binaryReader.ReadBoolean();
						}
						binaryReader.Close();
					}
				}
				player.PlayerFrame();
				if (decryptedCopy)
				{
					Player.EncryptFile(text, playerPath);
					File.Delete(text);
				}
				else
				{
					File.Delete(text);
				}
				player.loadStatus = 0;
				result = player;
				return result;
			}
			catch
			{
			}
			Player player2 = new Player();
			player2.loadStatus = 2;
			if (player.name != "")
			{
				player2.name = player.name;
			}
			else
			{
				string[] array2 = playerPath.Split(new char[]
				{
					Path.DirectorySeparatorChar
				});
				player.name = array2[array2.Length - 1].Split(new char[]
				{
					'.'
				})[0];
			}
			return player2;
		}
		public Color GetHairColor(bool lighting = true)
		{
			Color color = this.hairColor;
			if (this.hairDye == 1)
			{
				color.R = (byte)((float)this.statLife / (float)this.statLifeMax * 235f + 20f);
				color.B = 20;
				color.G = 20;
			}
			else
			{
				if (this.hairDye == 2)
				{
					color.R = (byte)((1f - (float)this.statMana / (float)this.statManaMax2) * 200f + 50f);
					color.B = 255;
					color.G = (byte)((1f - (float)this.statMana / (float)this.statManaMax2) * 180f + 75f);
				}
				else
				{
					if (this.hairDye == 3)
					{
						float num = (float)(Main.worldSurface * 0.45) * 16f;
						float num2 = (float)(Main.worldSurface + Main.rockLayer) * 8f;
						float num3 = (float)(Main.rockLayer + (double)Main.maxTilesY) * 8f;
						float num4 = (float)(Main.maxTilesY - 150) * 16f;
						if (this.center().Y < num)
						{
							float num5 = this.center().Y / num;
							float num6 = 1f - num5;
							color.R = (byte)(116f * num6 + 28f * num5);
							color.G = (byte)(160f * num6 + 216f * num5);
							color.B = (byte)(249f * num6 + 94f * num5);
						}
						else
						{
							if (this.center().Y < num2)
							{
								float num7 = num;
								float num8 = (this.center().Y - num7) / (num2 - num7);
								float num9 = 1f - num8;
								color.R = (byte)(28f * num9 + 151f * num8);
								color.G = (byte)(216f * num9 + 107f * num8);
								color.B = (byte)(94f * num9 + 75f * num8);
							}
							else
							{
								if (this.center().Y < num3)
								{
									float num10 = num2;
									float num11 = (this.center().Y - num10) / (num3 - num10);
									float num12 = 1f - num11;
									color.R = (byte)(151f * num12 + 128f * num11);
									color.G = (byte)(107f * num12 + 128f * num11);
									color.B = (byte)(75f * num12 + 128f * num11);
								}
								else
								{
									if (this.center().Y < num4)
									{
										float num13 = num3;
										float num14 = (this.center().Y - num13) / (num4 - num13);
										float num15 = 1f - num14;
										color.R = (byte)(128f * num15 + 255f * num14);
										color.G = (byte)(128f * num15 + 50f * num14);
										color.B = (byte)(128f * num15 + 15f * num14);
									}
									else
									{
										color.R = 255;
										color.G = 50;
										color.B = 10;
									}
								}
							}
						}
					}
					else
					{
						if (this.hairDye == 4)
						{
							int num16 = 0;
							for (int i = 0; i < 54; i++)
							{
								if (this.inventory[i].type == 71)
								{
									num16 += this.inventory[i].stack;
								}
								if (this.inventory[i].type == 72)
								{
									num16 += this.inventory[i].stack * 100;
								}
								if (this.inventory[i].type == 73)
								{
									num16 += this.inventory[i].stack * 10000;
								}
								if (this.inventory[i].type == 74)
								{
									num16 += this.inventory[i].stack * 1000000;
								}
							}
							float num17 = (float)Item.buyPrice(0, 5, 0, 0);
							float num18 = (float)Item.buyPrice(0, 50, 0, 0);
							float num19 = (float)Item.buyPrice(2, 0, 0, 0);
							Color color2 = new Color(226, 118, 76);
							Color color3 = new Color(174, 194, 196);
							Color color4 = new Color(204, 181, 72);
							Color color5 = new Color(161, 172, 173);
							if ((float)num16 < num17)
							{
								float num20 = (float)num16 / num17;
								float num21 = 1f - num20;
								color.R = (byte)((float)color2.R * num21 + (float)color3.R * num20);
								color.G = (byte)((float)color2.G * num21 + (float)color3.G * num20);
								color.B = (byte)((float)color2.B * num21 + (float)color3.B * num20);
							}
							else
							{
								if ((float)num16 < num18)
								{
									float num22 = num17;
									float num23 = ((float)num16 - num22) / (num18 - num22);
									float num24 = 1f - num23;
									color.R = (byte)((float)color3.R * num24 + (float)color4.R * num23);
									color.G = (byte)((float)color3.G * num24 + (float)color4.G * num23);
									color.B = (byte)((float)color3.B * num24 + (float)color4.B * num23);
								}
								else
								{
									if ((float)num16 < num19)
									{
										float num25 = num18;
										float num26 = ((float)num16 - num25) / (num19 - num25);
										float num27 = 1f - num26;
										color.R = (byte)((float)color4.R * num27 + (float)color5.R * num26);
										color.G = (byte)((float)color4.G * num27 + (float)color5.G * num26);
										color.B = (byte)((float)color4.B * num27 + (float)color5.B * num26);
									}
									else
									{
										color = color5;
									}
								}
							}
						}
						else
						{
							if (this.hairDye == 5)
							{
								Color color6 = new Color(1, 142, 255);
								Color color7 = new Color(255, 255, 0);
								Color color8 = new Color(211, 45, 127);
								Color color9 = new Color(67, 44, 118);
								if (Main.dayTime)
								{
									if (Main.time < 27000.0)
									{
										float num28 = (float)(Main.time / 27000.0);
										float num29 = 1f - num28;
										color.R = (byte)((float)color6.R * num29 + (float)color7.R * num28);
										color.G = (byte)((float)color6.G * num29 + (float)color7.G * num28);
										color.B = (byte)((float)color6.B * num29 + (float)color7.B * num28);
									}
									else
									{
										float num30 = 27000f;
										float num31 = (float)((Main.time - (double)num30) / (54000.0 - (double)num30));
										float num32 = 1f - num31;
										color.R = (byte)((float)color7.R * num32 + (float)color8.R * num31);
										color.G = (byte)((float)color7.G * num32 + (float)color8.G * num31);
										color.B = (byte)((float)color7.B * num32 + (float)color8.B * num31);
									}
								}
								else
								{
									if (Main.time < 16200.0)
									{
										float num33 = (float)(Main.time / 16200.0);
										float num34 = 1f - num33;
										color.R = (byte)((float)color8.R * num34 + (float)color9.R * num33);
										color.G = (byte)((float)color8.G * num34 + (float)color9.G * num33);
										color.B = (byte)((float)color8.B * num34 + (float)color9.B * num33);
									}
									else
									{
										float num35 = 16200f;
										float num36 = (float)((Main.time - (double)num35) / (32400.0 - (double)num35));
										float num37 = 1f - num36;
										color.R = (byte)((float)color9.R * num37 + (float)color6.R * num36);
										color.G = (byte)((float)color9.G * num37 + (float)color6.G * num36);
										color.B = (byte)((float)color9.B * num37 + (float)color6.B * num36);
									}
								}
							}
							else
							{
								if (this.hairDye == 6)
								{
									if (this.team == 1)
									{
										color = new Color(255, 0, 0);
									}
									else
									{
										if (this.team == 2)
										{
											color = new Color(0, 255, 0);
										}
										else
										{
											if (this.team == 3)
											{
												color = new Color(0, 0, 255);
											}
											else
											{
												if (this.team == 4)
												{
													color = new Color(255, 255, 0);
												}
											}
										}
									}
								}
								else
								{
									if (this.hairDye == 7)
									{
										Color color10 = default(Color);
										if (Main.waterStyle == 2)
										{
											color10 = new Color(124, 118, 242);
										}
										else
										{
											if (Main.waterStyle == 3)
											{
												color10 = new Color(143, 215, 29);
											}
											else
											{
												if (Main.waterStyle == 4)
												{
													color10 = new Color(78, 193, 227);
												}
												else
												{
													if (Main.waterStyle == 5)
													{
														color10 = new Color(189, 231, 255);
													}
													else
													{
														if (Main.waterStyle == 6)
														{
															color10 = new Color(230, 219, 100);
														}
														else
														{
															if (Main.waterStyle == 7)
															{
																color10 = new Color(151, 107, 75);
															}
															else
															{
																if (Main.waterStyle == 8)
																{
																	color10 = new Color(128, 128, 128);
																}
																else
																{
																	if (Main.waterStyle == 9)
																	{
																		color10 = new Color(200, 0, 0);
																	}
																	else
																	{
																		if (Main.waterStyle == 10)
																		{
																			color10 = new Color(208, 80, 80);
																		}
																		else
																		{
																			color10 = new Color(28, 216, 94);
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
										if (this.hairDyeColor.A == 0)
										{
											this.hairDyeColor = color10;
										}
										if (this.hairDyeColor.R > color10.R)
										{
											this.hairDyeColor.R = (byte)(this.hairDyeColor.R - 1);
										}
										if (this.hairDyeColor.R < color10.R)
										{
											this.hairDyeColor.R = (byte)(this.hairDyeColor.R + 1);
										}
										if (this.hairDyeColor.G > color10.G)
										{
											this.hairDyeColor.G = (byte)(this.hairDyeColor.G - 1);
										}
										if (this.hairDyeColor.G < color10.G)
										{
											this.hairDyeColor.G = (byte)(this.hairDyeColor.G + 1);
										}
										if (this.hairDyeColor.B > color10.B)
										{
											this.hairDyeColor.B = (byte)(this.hairDyeColor.B - 1);
										}
										if (this.hairDyeColor.B < color10.B)
										{
											this.hairDyeColor.B = (byte)(this.hairDyeColor.B + 1);
										}
										color = this.hairDyeColor;
									}
									else
									{
										if (this.hairDye == 8)
										{
											color = new Color(244, 22, 175);
											if (!Main.gameMenu && !Main.gamePaused)
											{
												if (Main.rand.Next(45) == 0)
												{
													int type = Main.rand.Next(139, 143);
													int num38 = Dust.NewDust(this.position, this.width, 8, type, 0f, 0f, 0, default(Color), 1.2f);
													Dust expr_BE5_cp_0 = Main.dust[num38];
													expr_BE5_cp_0.velocity.X = expr_BE5_cp_0.velocity.X * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
													Dust expr_C19_cp_0 = Main.dust[num38];
													expr_C19_cp_0.velocity.Y = expr_C19_cp_0.velocity.Y * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
													Dust expr_C4D_cp_0 = Main.dust[num38];
													expr_C4D_cp_0.velocity.X = expr_C4D_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.01f;
													Dust expr_C7B_cp_0 = Main.dust[num38];
													expr_C7B_cp_0.velocity.Y = expr_C7B_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.01f;
													Dust expr_CA9_cp_0 = Main.dust[num38];
													expr_CA9_cp_0.velocity.Y = expr_CA9_cp_0.velocity.Y - 1f;
													Main.dust[num38].scale *= 0.7f + (float)Main.rand.Next(-30, 31) * 0.01f;
													Main.dust[num38].velocity += this.velocity * 0.2f;
												}
												if (Main.rand.Next(225) == 0)
												{
													int type2 = Main.rand.Next(276, 283);
													int num39 = Gore.NewGore(new Vector2(this.position.X + (float)Main.rand.Next(this.width), this.position.Y + (float)Main.rand.Next(8)), this.velocity, type2, 1f);
													Gore expr_D96_cp_0 = Main.gore[num39];
													expr_D96_cp_0.velocity.X = expr_D96_cp_0.velocity.X * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
													Gore expr_DCA_cp_0 = Main.gore[num39];
													expr_DCA_cp_0.velocity.Y = expr_DCA_cp_0.velocity.Y * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
													Main.gore[num39].scale *= 1f + (float)Main.rand.Next(-20, 21) * 0.01f;
													Gore expr_E2D_cp_0 = Main.gore[num39];
													expr_E2D_cp_0.velocity.X = expr_E2D_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.01f;
													Gore expr_E5B_cp_0 = Main.gore[num39];
													expr_E5B_cp_0.velocity.Y = expr_E5B_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.01f;
													Gore expr_E89_cp_0 = Main.gore[num39];
													expr_E89_cp_0.velocity.Y = expr_E89_cp_0.velocity.Y - 1f;
													Main.gore[num39].velocity += this.velocity * 0.2f;
												}
											}
										}
										else
										{
											if (this.hairDye == 9)
											{
												color = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB);
											}
											else
											{
												if (this.hairDye == 10)
												{
													float num40 = Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y);
													float num41 = 10f;
													if (num40 > num41)
													{
														num40 = num41;
													}
													float num42 = num40 / num41;
													float num43 = 1f - num42;
													color.R = (byte)(75f * num42 + (float)this.hairColor.R * num43);
													color.G = (byte)(255f * num42 + (float)this.hairColor.G * num43);
													color.B = (byte)(200f * num42 + (float)this.hairColor.B * num43);
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
			if (lighting)
			{
				color = Lighting.GetColor((int)((double)this.position.X + (double)this.width * 0.5) / 16, (int)(((double)this.position.Y + (double)this.height * 0.25) / 16.0), color);
			}
			return color;
		}
		public bool HasItem(int type)
		{
			for (int i = 0; i < 58; i++)
			{
				if (type == this.inventory[i].type && this.inventory[i].stack > 0)
				{
					return true;
				}
			}
			return false;
		}
		public void QuickGrapple()
		{
			this.Dismount();
			if (this.noItems)
			{
				return;
			}
			int num = -1;
			for (int i = 0; i < 58; i++)
			{
				if (this.inventory[i].shoot == 13 || this.inventory[i].shoot == 32 || this.inventory[i].shoot == 73 || this.inventory[i].shoot == 165 || (this.inventory[i].shoot >= 230 && this.inventory[i].shoot <= 235) || this.inventory[i].shoot == 256 || this.inventory[i].shoot == 315 || this.inventory[i].shoot == 322 || this.inventory[i].shoot == 331 || this.inventory[i].shoot == 332)
				{
					num = i;
					break;
				}
			}
			if (num < 0)
			{
				return;
			}
			if (this.inventory[num].shoot == 73)
			{
				int num2 = 0;
				if (num >= 0)
				{
					for (int j = 0; j < 1000; j++)
					{
						if (Main.projectile[j].active && Main.projectile[j].owner == Main.myPlayer && (Main.projectile[j].type == 73 || Main.projectile[j].type == 74))
						{
							num2++;
						}
					}
				}
				if (num2 > 1)
				{
					num = -1;
				}
			}
			else
			{
				if (this.inventory[num].shoot == 165)
				{
					int num3 = 0;
					if (num >= 0)
					{
						for (int k = 0; k < 1000; k++)
						{
							if (Main.projectile[k].active && Main.projectile[k].owner == Main.myPlayer && Main.projectile[k].type == 165)
							{
								num3++;
							}
						}
					}
					if (num3 > 8)
					{
						num = -1;
					}
				}
				else
				{
					if (num >= 0)
					{
						for (int l = 0; l < 1000; l++)
						{
							if (Main.projectile[l].active && Main.projectile[l].owner == Main.myPlayer && Main.projectile[l].type == this.inventory[num].shoot && Main.projectile[l].ai[0] != 2f)
							{
								num = -1;
								break;
							}
						}
					}
				}
			}
			if (num >= 0)
			{
				Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, this.inventory[num].useSound);
				if (Main.netMode == 1 && this.whoAmi == Main.myPlayer)
				{
					NetMessage.SendData(51, -1, -1, "", this.whoAmi, 2f, 0f, 0f, 0);
				}
				int num4 = this.inventory[num].shoot;
				float shootSpeed = this.inventory[num].shootSpeed;
				int damage = this.inventory[num].damage;
				float knockBack = this.inventory[num].knockBack;
				if (num4 == 13 || num4 == 32 || num4 == 315 || (num4 >= 230 && num4 <= 235) || num4 == 331)
				{
					this.grappling[0] = -1;
					this.grapCount = 0;
					for (int m = 0; m < 1000; m++)
					{
						if (Main.projectile[m].active && Main.projectile[m].owner == this.whoAmi)
						{
							if (Main.projectile[m].type == 13)
							{
								Main.projectile[m].Kill();
							}
							if (Main.projectile[m].type == 331)
							{
								Main.projectile[m].Kill();
							}
							if (Main.projectile[m].type == 315)
							{
								Main.projectile[m].Kill();
							}
							if (Main.projectile[m].type >= 230 && Main.projectile[m].type <= 235)
							{
								Main.projectile[m].Kill();
							}
						}
					}
				}
				if (num4 == 256)
				{
					int num5 = 0;
					int num6 = -1;
					int num7 = 100000;
					for (int n = 0; n < 1000; n++)
					{
						if (Main.projectile[n].active && Main.projectile[n].owner == this.whoAmi && Main.projectile[n].type == 256)
						{
							num5++;
							if (Main.projectile[n].timeLeft < num7)
							{
								num6 = n;
								num7 = Main.projectile[n].timeLeft;
							}
						}
					}
					if (num5 > 1)
					{
						Main.projectile[num6].Kill();
					}
				}
				if (num4 == 73)
				{
					for (int num8 = 0; num8 < 1000; num8++)
					{
						if (Main.projectile[num8].active && Main.projectile[num8].owner == this.whoAmi && Main.projectile[num8].type == 73)
						{
							num4 = 74;
						}
					}
				}
				Vector2 vector = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
				float num9 = (float)Main.mouseX + Main.screenPosition.X - vector.X;
				float num10 = (float)Main.mouseY + Main.screenPosition.Y - vector.Y;
				if (this.gravDir == -1f)
				{
					num10 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector.Y;
				}
				float num11 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
				num11 = shootSpeed / num11;
				num9 *= num11;
				num10 *= num11;
				Projectile.NewProjectile(vector.X, vector.Y, num9, num10, num4, damage, knockBack, this.whoAmi, 0f, 0f);
			}
		}
		public Player()
		{
			this.name = string.Empty;
			for (int i = 0; i < 59; i++)
			{
				if (i < 16)
				{
					this.armor[i] = new Item();
					this.armor[i].name = "";
				}
				this.inventory[i] = new Item();
				this.inventory[i].name = "";
			}
			for (int j = 0; j < Chest.maxItems; j++)
			{
				this.bank.item[j] = new Item();
				this.bank.item[j].name = "";
				this.bank2.item[j] = new Item();
				this.bank2.item[j].name = "";
			}
			for (int k = 0; k < 8; k++)
			{
				this.dye[k] = new Item();
			}
			this.grappling[0] = -1;
			this.inventory[0].SetDefaults("Copper Shortsword");
			this.inventory[1].SetDefaults("Copper Pickaxe");
			this.inventory[2].SetDefaults("Copper Axe");
			this.statManaMax = 20;
			if (Main.cEd)
			{
				this.inventory[3].SetDefaults(603, false);
			}
			for (int l = 0; l < 314; l++)
			{
				this.adjTile[l] = false;
				this.oldAdjTile[l] = false;
			}
			this.hitTile = new HitTile();
		}
	}
}
