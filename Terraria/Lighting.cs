using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;
using System.Threading;
namespace Terraria
{
	public class Lighting
	{
		private class LightingSwipeData
		{
			public int outerLoopStart;
			public int outerLoopEnd;
			public int innerLoop1Start;
			public int innerLoop1End;
			public int innerLoop2Start;
			public int innerLoop2End;
			public Random rand;
			public Action<Lighting.LightingSwipeData> function;
			public Lighting.LightingState[][] jaggedArray;
			public LightingSwipeData()
			{
				this.innerLoop1Start = 0;
				this.outerLoopStart = 0;
				this.innerLoop1End = 0;
				this.outerLoopEnd = 0;
				this.innerLoop2Start = 0;
				this.innerLoop2End = 0;
				this.function = null;
				this.rand = new Random();
			}
			public void CopyFrom(Lighting.LightingSwipeData from)
			{
				this.innerLoop1Start = from.innerLoop1Start;
				this.outerLoopStart = from.outerLoopStart;
				this.innerLoop1End = from.innerLoop1End;
				this.outerLoopEnd = from.outerLoopEnd;
				this.innerLoop2Start = from.innerLoop2Start;
				this.innerLoop2End = from.innerLoop2End;
				this.function = from.function;
				this.jaggedArray = from.jaggedArray;
			}
		}
		private class LightingState
		{
			public float r;
			public float r2;
			public float g;
			public float g2;
			public float b;
			public float b2;
			public bool stopLight;
			public bool wetLight;
			public bool honeyLight;
		}
		public static int maxRenderCount = 4;
		public static float brightness = 1f;
		public static float defBrightness = 1f;
		public static int lightMode = 0;
		public static bool RGB = true;
		public static float oldSkyColor = 0f;
		public static float skyColor = 0f;
		public static int lightCounter = 0;
		public static int offScreenTiles = 45;
		public static int offScreenTiles2 = 35;
		private static int firstTileX;
		private static int lastTileX;
		private static int firstTileY;
		private static int lastTileY;
		public static int LightingThreads = 0;
		private static Lighting.LightingState[][] states;
		private static Lighting.LightingState[][] axisFlipStates;
		private static Lighting.LightingSwipeData swipe;
		private static Lighting.LightingSwipeData[] threadSwipes;
		private static CountdownEvent countdown;
		public static int scrX;
		public static int scrY;
		public static int minX;
		public static int maxX;
		public static int minY;
		public static int maxY;
		private static int maxTempLights = 2000;
		private static int[] tempLightX;
		private static int[] tempLightY;
		private static float[] tempLight;
		private static float[] tempLightG;
		private static float[] tempLightB;
		public static int tempLightCount;
		private static int firstToLightX;
		private static int firstToLightY;
		private static int lastToLightX;
		private static int lastToLightY;
		public static bool resize = false;
		private static float negLight = 0.04f;
		private static float negLight2 = 0.16f;
		private static float wetLightR = 0.16f;
		private static float wetLightG = 0.16f;
		private static float wetLightB = 0.16f;
		private static float honeyLightR = 0.16f;
		private static float honeyLightG = 0.16f;
		private static float honeyLightB = 0.16f;
		private static float blueWave = 1f;
		private static int blueDir = 1;
		private static int minX7;
		private static int maxX7;
		private static int minY7;
		private static int maxY7;
		private static int firstTileX7;
		private static int lastTileX7;
		private static int lastTileY7;
		private static int firstTileY7;
		private static int firstToLightX7;
		private static int lastToLightX7;
		private static int firstToLightY7;
		private static int lastToLightY7;
		private static int firstToLightX27;
		private static int lastToLightX27;
		private static int firstToLightY27;
		private static int lastToLightY27;
		public static void Initialize()
		{
			Lighting.tempLightX = new int[Lighting.maxTempLights];
			Lighting.tempLightY = new int[Lighting.maxTempLights];
			Lighting.tempLight = new float[Lighting.maxTempLights];
			Lighting.tempLightG = new float[Lighting.maxTempLights];
			Lighting.tempLightB = new float[Lighting.maxTempLights];
			Lighting.swipe = new Lighting.LightingSwipeData();
			Lighting.countdown = new CountdownEvent(0);
			Lighting.threadSwipes = new Lighting.LightingSwipeData[Environment.ProcessorCount];
			for (int i = 0; i < Lighting.threadSwipes.Length; i++)
			{
				Lighting.threadSwipes[i] = new Lighting.LightingSwipeData();
			}
			int num = Main.screenWidth + Lighting.offScreenTiles * 2 + 10;
			int num2 = Main.screenHeight + Lighting.offScreenTiles * 2 + 10;
			Lighting.states = new Lighting.LightingState[num][];
			Lighting.axisFlipStates = new Lighting.LightingState[num2][];
			for (int j = 0; j < num2; j++)
			{
				Lighting.axisFlipStates[j] = new Lighting.LightingState[num];
			}
			for (int k = 0; k < num; k++)
			{
				Lighting.LightingState[] array = new Lighting.LightingState[num2];
				for (int l = 0; l < num2; l++)
				{
					Lighting.LightingState lightingState = new Lighting.LightingState();
					array[l] = lightingState;
					Lighting.axisFlipStates[l][k] = lightingState;
				}
				Lighting.states[k] = array;
			}
		}
		public static void LightTiles(int firstX, int lastX, int firstY, int lastY)
		{
			Main.render = true;
			Lighting.oldSkyColor = Lighting.skyColor;
			Lighting.skyColor = (float)((Main.tileColor.R + Main.tileColor.G + Main.tileColor.B) / 3) / 255f;
			if (Lighting.lightMode < 2)
			{
				Lighting.brightness = 1.2f;
				Lighting.offScreenTiles2 = 34;
				Lighting.offScreenTiles = 40;
			}
			else
			{
				Lighting.brightness = 1f;
				Lighting.offScreenTiles2 = 18;
				Lighting.offScreenTiles = 23;
			}
			if (Main.player[Main.myPlayer].blind)
			{
				Lighting.brightness = 1f;
			}
			Lighting.defBrightness = Lighting.brightness;
			Lighting.firstTileX = firstX;
			Lighting.lastTileX = lastX;
			Lighting.firstTileY = firstY;
			Lighting.lastTileY = lastY;
			Lighting.firstToLightX = Lighting.firstTileX - Lighting.offScreenTiles;
			Lighting.firstToLightY = Lighting.firstTileY - Lighting.offScreenTiles;
			Lighting.lastToLightX = Lighting.lastTileX + Lighting.offScreenTiles;
			Lighting.lastToLightY = Lighting.lastTileY + Lighting.offScreenTiles;
			if (Lighting.firstToLightX < 0)
			{
				Lighting.firstToLightX = 0;
			}
			if (Lighting.lastToLightX >= Main.maxTilesX)
			{
				Lighting.lastToLightX = Main.maxTilesX - 1;
			}
			if (Lighting.firstToLightY < 0)
			{
				Lighting.firstToLightY = 0;
			}
			if (Lighting.lastToLightY >= Main.maxTilesY)
			{
				Lighting.lastToLightY = Main.maxTilesY - 1;
			}
			int num = Lighting.firstTileX - Lighting.offScreenTiles2;
			int num2 = Lighting.firstTileY - Lighting.offScreenTiles2;
			int num3 = Lighting.lastTileX + Lighting.offScreenTiles2;
			int num4 = Lighting.lastTileY + Lighting.offScreenTiles2;
			if (num < 0)
			{
				num = 0;
			}
			if (num3 >= Main.maxTilesX)
			{
				num3 = Main.maxTilesX - 1;
			}
			if (num2 < 0)
			{
				num2 = 0;
			}
			if (num4 >= Main.maxTilesY)
			{
				num4 = Main.maxTilesY - 1;
			}
			Lighting.lightCounter++;
			Main.renderCount++;
			int num5 = Main.screenWidth / 16 + Lighting.offScreenTiles * 2;
			int num6 = Main.screenHeight / 16 + Lighting.offScreenTiles * 2;
			Vector2 vector = Main.screenLastPosition;
			Lighting.doColors();
			if (Main.renderCount == 2)
			{
				vector = Main.screenPosition;
				int num7 = (int)(Main.screenPosition.X / 16f) - Lighting.scrX;
				int num8 = (int)(Main.screenPosition.Y / 16f) - Lighting.scrY;
				if (num7 > 16)
				{
					num7 = 0;
				}
				if (num8 > 16)
				{
					num8 = 0;
				}
				if (Lighting.RGB)
				{
					for (int i = 0; i < num5; i++)
					{
						if (i + num7 >= 0)
						{
							Lighting.LightingState[] array = Lighting.states[i];
							Lighting.LightingState[] array2 = Lighting.states[i + num7];
							for (int j = 0; j < num6; j++)
							{
								if (j + num8 >= 0)
								{
									Lighting.LightingState lightingState = array[j];
									Lighting.LightingState lightingState2 = array2[j + num8];
									lightingState.r = lightingState2.r2;
									lightingState.g = lightingState2.g2;
									lightingState.b = lightingState2.b2;
								}
							}
						}
					}
				}
				else
				{
					for (int k = 0; k < num5; k++)
					{
						if (k + num7 >= 0)
						{
							Lighting.LightingState[] array3 = Lighting.states[k];
							Lighting.LightingState[] array4 = Lighting.states[k + num7];
							for (int l = 0; l < num6; l++)
							{
								if (l + num8 >= 0)
								{
									Lighting.LightingState lightingState3 = array3[l];
									Lighting.LightingState lightingState4 = array4[l + num8];
									lightingState3.r = lightingState4.r2;
									lightingState3.g = lightingState4.r2;
									lightingState3.b = lightingState4.r2;
								}
							}
						}
					}
				}
			}
			if (Main.renderCount != 2 && !Lighting.resize && !Main.renderNow)
			{
				if (Math.Abs(Main.screenPosition.X / 16f - vector.X / 16f) < 5f)
				{
					while ((int)(Main.screenPosition.X / 16f) < (int)(vector.X / 16f))
					{
						vector.X -= 16f;
						for (int m = num5 - 1; m > 1; m--)
						{
							Lighting.LightingState[] array5 = Lighting.states[m];
							Lighting.LightingState[] array6 = Lighting.states[m - 1];
							for (int n = 0; n < num6; n++)
							{
								Lighting.LightingState lightingState5 = array5[n];
								Lighting.LightingState lightingState6 = array6[n];
								lightingState5.r = lightingState6.r;
								lightingState5.g = lightingState6.g;
								lightingState5.b = lightingState6.b;
							}
						}
					}
					while ((int)(Main.screenPosition.X / 16f) > (int)(vector.X / 16f))
					{
						vector.X += 16f;
						for (int num9 = 0; num9 < num5 - 1; num9++)
						{
							Lighting.LightingState[] array7 = Lighting.states[num9];
							Lighting.LightingState[] array8 = Lighting.states[num9 + 1];
							for (int num10 = 0; num10 < num6; num10++)
							{
								Lighting.LightingState lightingState7 = array7[num10];
								Lighting.LightingState lightingState8 = array8[num10];
								lightingState7.r = lightingState8.r;
								lightingState7.g = lightingState8.g;
								lightingState7.b = lightingState8.b;
							}
						}
					}
				}
				if (Math.Abs(Main.screenPosition.Y / 16f - vector.Y / 16f) < 5f)
				{
					while ((int)(Main.screenPosition.Y / 16f) < (int)(vector.Y / 16f))
					{
						vector.Y -= 16f;
						for (int num11 = num6 - 1; num11 > 1; num11--)
						{
							for (int num12 = 0; num12 < num5; num12++)
							{
								Lighting.LightingState lightingState9 = Lighting.states[num12][num11];
								Lighting.LightingState lightingState10 = Lighting.states[num12][num11 - 1];
								lightingState9.r = lightingState10.r;
								lightingState9.g = lightingState10.g;
								lightingState9.b = lightingState10.b;
							}
						}
					}
					while ((int)(Main.screenPosition.Y / 16f) > (int)(vector.Y / 16f))
					{
						vector.Y += 16f;
						for (int num13 = 0; num13 < num6 - 1; num13++)
						{
							for (int num14 = 0; num14 < num5 - 1; num14++)
							{
								Lighting.LightingState lightingState11 = Lighting.states[num14][num13];
								Lighting.LightingState lightingState12 = Lighting.states[num14][num13 + 1];
								lightingState11.r = lightingState12.r;
								lightingState11.g = lightingState12.g;
								lightingState11.b = lightingState12.b;
							}
						}
					}
				}
				if (Netplay.clientSock.statusMax > 0)
				{
					Main.mapTime = 1;
				}
				if (Main.mapTime == 0 && Main.mapEnabled && Main.renderCount == 3)
				{
					try
					{
						Main.mapTime = Main.mapTimeMax;
						Main.updateMap = true;
						Main.mapMinX = Lighting.firstToLightX + Lighting.offScreenTiles;
						Main.mapMaxX = Lighting.lastToLightX - Lighting.offScreenTiles;
						Main.mapMinY = Lighting.firstToLightY + Lighting.offScreenTiles;
						Main.mapMaxY = Lighting.lastToLightY - Lighting.offScreenTiles;
						for (int num15 = Main.mapMinX; num15 < Main.mapMaxX; num15++)
						{
							Lighting.LightingState[] array9 = Lighting.states[num15 - Lighting.firstTileX + Lighting.offScreenTiles];
							for (int num16 = Main.mapMinY; num16 < Main.mapMaxY; num16++)
							{
								Lighting.LightingState lightingState13 = array9[num16 - Lighting.firstTileY + Lighting.offScreenTiles];
								Tile tile = Main.tile[num15, num16];
								Map map = Main.map[num15, num16];
								if (map == null)
								{
									map = new Map();
									Main.map[num15, num16] = map;
								}
								float num17 = 0f;
								int arg_77A_0 = Lighting.firstTileX;
								int arg_780_0 = Lighting.offScreenTiles;
								int arg_786_0 = Lighting.firstTileY;
								int arg_78C_0 = Lighting.offScreenTiles;
								if (lightingState13.r * 255f > num17)
								{
									num17 = lightingState13.r * 255f;
								}
								if (lightingState13.g * 255f > num17)
								{
									num17 = lightingState13.g * 255f;
								}
								if (lightingState13.b * 255f > num17)
								{
									num17 = lightingState13.b * 255f;
								}
								if (Lighting.lightMode < 2)
								{
									num17 *= 1.5f;
								}
								if (num17 > 255f)
								{
									num17 = 255f;
								}
								if ((double)num16 < Main.worldSurface && !tile.active() && tile.wall == 0 && tile.liquid == 0)
								{
									num17 = 22f;
								}
								if (num17 > 18f || map.light > 0)
								{
									if (num17 < 22f)
									{
										num17 = 22f;
									}
									map.setTile(num15, num16, (byte)num17);
								}
							}
						}
					}
					catch
					{
					}
				}
				if (Lighting.oldSkyColor != Lighting.skyColor)
				{
					for (int num18 = Lighting.firstToLightX; num18 < Lighting.lastToLightX; num18++)
					{
						Lighting.LightingState[] array10 = Lighting.states[num18 - Lighting.firstToLightX];
						for (int num19 = Lighting.firstToLightY; num19 < Lighting.lastToLightY; num19++)
						{
							Lighting.LightingState lightingState14 = array10[num19 - Lighting.firstToLightY];
							Tile tile2 = Main.tile[num18, num19];
							if (tile2 == null)
							{
								tile2 = new Tile();
								Main.tile[num18, num19] = tile2;
							}
							if ((!tile2.active() || !Main.tileNoSunLight[(int)tile2.type]) && lightingState14.r < Lighting.skyColor && (double)num19 < Main.worldSurface && tile2.liquid < 200 && (Main.wallLight[(int)tile2.wall] || tile2.wall == 73))
							{
								if (lightingState14.r < Lighting.skyColor)
								{
									lightingState14.r = (float)Main.tileColor.R / 255f;
								}
								if (lightingState14.g < Lighting.skyColor)
								{
									lightingState14.g = (float)Main.tileColor.G / 255f;
								}
								if (lightingState14.b < Lighting.skyColor)
								{
									lightingState14.b = (float)Main.tileColor.B / 255f;
								}
							}
						}
					}
				}
			}
			else
			{
				Lighting.lightCounter = 0;
			}
			if (Main.renderCount <= Lighting.maxRenderCount)
			{
				return;
			}
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			long arg_A28_0 = stopwatch.ElapsedMilliseconds;
			Lighting.resize = false;
			Main.drawScene = true;
			Lighting.ResetRange();
			if (Lighting.lightMode == 0 || Lighting.lightMode == 3)
			{
				Lighting.RGB = true;
			}
			else
			{
				Lighting.RGB = false;
			}
			int num20 = 0;
			int num21 = Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10;
			int num22 = 0;
			int num23 = Main.screenHeight / 16 + Lighting.offScreenTiles * 2 + 10;
			for (int num24 = num20; num24 < num21; num24++)
			{
				Lighting.LightingState[] array11 = Lighting.states[num24];
				for (int num25 = num22; num25 < num23; num25++)
				{
					Lighting.LightingState lightingState15 = array11[num25];
					lightingState15.r2 = 0f;
					lightingState15.g2 = 0f;
					lightingState15.b2 = 0f;
					lightingState15.stopLight = false;
					lightingState15.wetLight = false;
					lightingState15.honeyLight = false;
				}
			}
			for (int num26 = 0; num26 < Lighting.tempLightCount; num26++)
			{
				if (Lighting.tempLightX[num26] - Lighting.firstTileX + Lighting.offScreenTiles >= 0 && Lighting.tempLightX[num26] - Lighting.firstTileX + Lighting.offScreenTiles < Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10 && Lighting.tempLightY[num26] - Lighting.firstTileY + Lighting.offScreenTiles >= 0 && Lighting.tempLightY[num26] - Lighting.firstTileY + Lighting.offScreenTiles < Main.screenHeight / 16 + Lighting.offScreenTiles * 2 + 10)
				{
					Lighting.LightingState lightingState16 = Lighting.states[Lighting.tempLightX[num26] - Lighting.firstTileX + Lighting.offScreenTiles][Lighting.tempLightY[num26] - Lighting.firstTileY + Lighting.offScreenTiles];
					if (lightingState16.r2 < Lighting.tempLight[num26])
					{
						lightingState16.r2 = Lighting.tempLight[num26];
					}
					if (lightingState16.g2 < Lighting.tempLightG[num26])
					{
						lightingState16.g2 = Lighting.tempLightG[num26];
					}
					if (lightingState16.b2 < Lighting.tempLightB[num26])
					{
						lightingState16.b2 = Lighting.tempLightB[num26];
					}
				}
			}
			if (Main.wof >= 0 && Main.player[Main.myPlayer].gross)
			{
				try
				{
					int num27 = (int)Main.screenPosition.Y / 16 - 10;
					int num28 = (int)(Main.screenPosition.Y + (float)Main.screenHeight) / 16 + 10;
					int num29 = (int)Main.npc[Main.wof].position.X / 16;
					if (Main.npc[Main.wof].direction > 0)
					{
						num29 -= 3;
					}
					else
					{
						num29 += 2;
					}
					int num30 = num29 + 8;
					float num31 = 0.5f * Main.demonTorch + 1f * (1f - Main.demonTorch);
					float num32 = 0.3f;
					float num33 = 1f * Main.demonTorch + 0.5f * (1f - Main.demonTorch);
					num31 *= 0.2f;
					num32 *= 0.1f;
					num33 *= 0.3f;
					for (int num34 = num29; num34 <= num30; num34++)
					{
						Lighting.LightingState[] array12 = Lighting.states[num34 - Lighting.firstToLightX];
						for (int num35 = num27; num35 <= num28; num35++)
						{
							Lighting.LightingState lightingState17 = array12[num35 - Lighting.firstToLightY];
							if (lightingState17.r2 < num31)
							{
								lightingState17.r2 = num31;
							}
							if (lightingState17.g2 < num32)
							{
								lightingState17.g2 = num32;
							}
							if (lightingState17.b2 < num33)
							{
								lightingState17.b2 = num33;
							}
						}
					}
				}
				catch
				{
				}
			}
			if (!Main.renderNow)
			{
				Main.oldTempLightCount = Lighting.tempLightCount;
				Lighting.tempLightCount = 0;
			}
			if (Main.gamePaused)
			{
				Lighting.tempLightCount = Main.oldTempLightCount;
			}
			Main.sandTiles = 0;
			Main.evilTiles = 0;
			Main.bloodTiles = 0;
			Main.shroomTiles = 0;
			Main.snowTiles = 0;
			Main.holyTiles = 0;
			Main.meteorTiles = 0;
			Main.jungleTiles = 0;
			Main.dungeonTiles = 0;
			Main.campfire = false;
			Main.heartLantern = false;
			Main.musicBox = -1;
			Main.waterCandles = 0;
			num20 = Lighting.firstToLightX;
			num21 = Lighting.lastToLightX;
			num22 = Lighting.firstToLightY;
			num23 = Lighting.lastToLightY;
			for (int num36 = num20; num36 < num21; num36++)
			{
				Lighting.LightingState[] array13 = Lighting.states[num36 - Lighting.firstToLightX];
				for (int num37 = num22; num37 < num23; num37++)
				{
					Lighting.LightingState lightingState18 = array13[num37 - Lighting.firstToLightY];
					Tile tile3 = Main.tile[num36, num37];
					if (tile3 == null)
					{
						tile3 = new Tile();
						Main.tile[num36, num37] = tile3;
					}
					if ((!tile3.active() || !Main.tileNoSunLight[(int)tile3.type]) && lightingState18.r2 < Lighting.skyColor && (Main.wallLight[(int)tile3.wall] || tile3.wall == 73) && (double)num37 < Main.worldSurface)
					{
						if (tile3.halfBrick())
						{
							if (tile3.liquid < 200 && Main.tile[num36, num37 - 1].liquid < 200)
							{
								if (lightingState18.r2 < Lighting.skyColor)
								{
									lightingState18.r2 = (float)Main.tileColor.R / 255f;
								}
								if (lightingState18.g2 < Lighting.skyColor)
								{
									lightingState18.g2 = (float)Main.tileColor.G / 255f;
								}
								if (lightingState18.b2 < Lighting.skyColor)
								{
									lightingState18.b2 = (float)Main.tileColor.B / 255f;
								}
							}
						}
						else
						{
							if (tile3.liquid < 200)
							{
								if (lightingState18.r2 < Lighting.skyColor)
								{
									lightingState18.r2 = (float)Main.tileColor.R / 255f;
								}
								if (lightingState18.g2 < Lighting.skyColor)
								{
									lightingState18.g2 = (float)Main.tileColor.G / 255f;
								}
								if (lightingState18.b2 < Lighting.skyColor)
								{
									lightingState18.b2 = (float)Main.tileColor.B / 255f;
								}
							}
						}
					}
					if ((!tile3.active() || tile3.halfBrick() || !Main.tileNoSunLight[(int)tile3.type]) && tile3.wall >= 88 && tile3.wall <= 93 && (double)num37 < Main.worldSurface && tile3.liquid < 255)
					{
						float num38 = (float)Main.tileColor.R / 255f;
						float num39 = (float)Main.tileColor.G / 255f;
						float num40 = (float)Main.tileColor.B / 255f;
						int num41 = (int)(tile3.wall - 88);
						if (num41 == 0)
						{
							num38 *= 0.9f;
							num39 *= 0.15f;
							num40 *= 0.9f;
						}
						else
						{
							if (num41 == 1)
							{
								num38 *= 0.9f;
								num39 *= 0.9f;
								num40 *= 0.15f;
							}
							else
							{
								if (num41 == 2)
								{
									num38 *= 0.15f;
									num39 *= 0.15f;
									num40 *= 0.9f;
								}
								else
								{
									if (num41 == 3)
									{
										num38 *= 0.15f;
										num39 *= 0.9f;
										num40 *= 0.15f;
									}
									else
									{
										if (num41 == 4)
										{
											num38 *= 0.9f;
											num39 *= 0.15f;
											num40 *= 0.15f;
										}
										else
										{
											if (num41 == 5)
											{
												float num42 = 0.2f;
												float num43 = 0.7f - num42;
												num38 *= num43 + (float)Main.DiscoR / 255f * num42;
												num39 *= num43 + (float)Main.DiscoG / 255f * num42;
												num40 *= num43 + (float)Main.DiscoB / 255f * num42;
											}
										}
									}
								}
							}
						}
						if (lightingState18.r2 < num38)
						{
							lightingState18.r2 = num38;
						}
						if (lightingState18.g2 < num39)
						{
							lightingState18.g2 = num39;
						}
						if (lightingState18.b2 < num40)
						{
							lightingState18.b2 = num40;
						}
					}
				}
			}
			Main.fountainColor = -1;
			for (int num44 = num20; num44 < num21; num44++)
			{
				Lighting.LightingState[] array14 = Lighting.states[num44 - Lighting.firstToLightX];
				for (int num45 = num22; num45 < num23; num45++)
				{
					Lighting.LightingState lightingState19 = array14[num45 - Lighting.firstToLightY];
					Tile tile4 = Main.tile[num44, num45];
					if (tile4 == null)
					{
						tile4 = new Tile();
						Main.tile[num44, num45] = tile4;
					}
					int num46 = num44 - Lighting.firstToLightX;
					int num47 = num45 - Lighting.firstToLightY;
					int zoneX = Main.zoneX;
					int zoneY = Main.zoneY;
					int num48 = (num21 - num20 - zoneX) / 2;
					int num49 = (num23 - num22 - zoneY) / 2;
					byte wall = tile4.wall;
					if (wall != 33)
					{
						if (wall != 44)
						{
							if (wall == 137)
							{
								if (!tile4.active() || !Main.tileBlockLight[(int)tile4.type])
								{
									float num50 = 0.4f;
									num50 += (float)(270 - (int)Main.mouseTextColor) / 1500f;
									num50 += (float)Main.rand.Next(0, 50) * 0.0005f;
									float num51 = 1f * num50;
									float num52 = 0.5f * num50;
									float num53 = 0.1f * num50;
									if (lightingState19.r2 < num51)
									{
										lightingState19.r2 = num51;
									}
									if (lightingState19.g2 < num52)
									{
										lightingState19.g2 = num52;
									}
									if (lightingState19.b2 < num53)
									{
										lightingState19.b2 = num53;
									}
								}
							}
						}
						else
						{
							if (!tile4.active() || !Main.tileBlockLight[(int)tile4.type])
							{
								if (Lighting.RGB)
								{
									float num54 = (float)Main.DiscoR / 255f;
									float num55 = (float)Main.DiscoG / 255f;
									float num56 = (float)Main.DiscoB / 255f;
									num54 *= 0.15f;
									num55 *= 0.15f;
									num56 *= 0.15f;
									if (lightingState19.r2 < num54)
									{
										lightingState19.r2 = num54;
									}
									if (lightingState19.g2 < num55)
									{
										lightingState19.g2 = num55;
									}
									if (lightingState19.b2 < num56)
									{
										lightingState19.b2 = num56;
									}
								}
								else
								{
									if (lightingState19.r2 < 0.15f)
									{
										lightingState19.r2 = 0.15f;
									}
								}
							}
						}
					}
					else
					{
						if (!tile4.active() || !Main.tileBlockLight[(int)tile4.type])
						{
							if ((double)lightingState19.r2 < 0.09)
							{
								lightingState19.r2 = 0.0899999961f;
							}
							if ((double)lightingState19.g2 < 0.052500000000000005)
							{
								lightingState19.g2 = 0.0525000021f;
							}
							if ((double)lightingState19.b2 < 0.24)
							{
								lightingState19.b2 = 0.24f;
							}
						}
					}
					if (tile4.active())
					{
						ushort type;
						if (num44 > num20 + num48 && num44 < num21 - num48 && num45 > num22 + num49 && num45 < num23 - num49)
						{
							type = tile4.type;
							if (type <= 74)
							{
								if (type <= 44)
								{
									switch (type)
									{
									case 23:
									case 24:
									case 25:
										break;
									case 26:
										goto IL_184F;
									case 27:
										Main.evilTiles -= 5;
										Main.bloodTiles -= 5;
										goto IL_184F;
									default:
										if (type != 32)
										{
											switch (type)
											{
											case 37:
												Main.meteorTiles++;
												goto IL_184F;
											case 38:
											case 39:
											case 40:
												goto IL_184F;
											case 41:
											case 43:
											case 44:
												Main.dungeonTiles++;
												goto IL_184F;
											case 42:
												if (tile4.frameY >= 324 && tile4.frameY <= 358)
												{
													Main.heartLantern = true;
													goto IL_184F;
												}
												goto IL_184F;
											default:
												goto IL_184F;
											}
										}
										break;
									}
									Main.evilTiles++;
									goto IL_184F;
								}
								if (type <= 53)
								{
									if (type == 49)
									{
										Main.waterCandles++;
										goto IL_184F;
									}
									if (type != 53)
									{
										goto IL_184F;
									}
									Main.sandTiles++;
									goto IL_184F;
								}
								else
								{
									switch (type)
									{
									case 60:
									case 61:
									case 62:
										break;
									default:
										switch (type)
										{
										case 70:
										case 71:
										case 72:
											Main.shroomTiles++;
											goto IL_184F;
										case 73:
											goto IL_184F;
										case 74:
											break;
										default:
											goto IL_184F;
										}
										break;
									}
								}
							}
							else
							{
								if (type <= 164)
								{
									switch (type)
									{
									case 109:
									case 110:
									case 113:
									case 117:
										Main.holyTiles++;
										goto IL_184F;
									case 111:
									case 114:
									case 115:
										goto IL_184F;
									case 112:
										Main.sandTiles++;
										Main.evilTiles++;
										goto IL_184F;
									case 116:
										Main.sandTiles++;
										Main.holyTiles++;
										goto IL_184F;
									default:
										switch (type)
										{
										case 147:
										case 148:
											break;
										default:
											switch (type)
											{
											case 161:
											case 162:
												break;
											case 163:
												Main.snowTiles++;
												Main.evilTiles++;
												goto IL_184F;
											case 164:
												Main.holyTiles++;
												Main.snowTiles++;
												goto IL_184F;
											default:
												goto IL_184F;
											}
											break;
										}
										Main.snowTiles++;
										goto IL_184F;
									}
								}
								else
								{
									if (type <= 215)
									{
										switch (type)
										{
										case 199:
										case 203:
											Main.bloodTiles++;
											goto IL_184F;
										case 200:
											Main.snowTiles++;
											Main.bloodTiles++;
											goto IL_184F;
										case 201:
										case 202:
											goto IL_184F;
										default:
											if (type != 215)
											{
												goto IL_184F;
											}
											Main.campfire = true;
											goto IL_184F;
										}
									}
									else
									{
										if (type != 226)
										{
											if (type != 234)
											{
												goto IL_184F;
											}
											Main.bloodTiles++;
											Main.sandTiles++;
											goto IL_184F;
										}
									}
								}
							}
							Main.jungleTiles++;
						}
						IL_184F:
						type = tile4.type;
						if (type != 139)
						{
							if (type == 207)
							{
								if (tile4.frameY >= 72)
								{
									switch (tile4.frameX / 36)
									{
									case 0:
										Main.fountainColor = 0;
										break;
									case 1:
										Main.fountainColor = 6;
										break;
									case 2:
										Main.fountainColor = 3;
										break;
									case 3:
										Main.fountainColor = 5;
										break;
									case 4:
										Main.fountainColor = 2;
										break;
									case 5:
										Main.fountainColor = 10;
										break;
									case 6:
										Main.fountainColor = 4;
										break;
									case 7:
										Main.fountainColor = 9;
										break;
									default:
										Main.fountainColor = -1;
										break;
									}
								}
							}
						}
						else
						{
							if (tile4.frameX >= 36)
							{
								int num57 = 0;
								for (int num58 = (int)(tile4.frameY / 18); num58 >= 2; num58 -= 2)
								{
									num57++;
								}
								Main.musicBox = num57;
							}
						}
						if (Main.tileBlockLight[(int)tile4.type] && (Lighting.lightMode >= 2 || (tile4.type != 131 && !tile4.inActive() && tile4.slope() == 0)))
						{
							lightingState19.stopLight = true;
						}
						if (Main.tileLighted[(int)tile4.type])
						{
							if (Lighting.RGB)
							{
								type = tile4.type;
								if (type <= 100)
								{
									if (type <= 42)
									{
										if (type <= 22)
										{
											if (type != 4)
											{
												if (type == 17)
												{
													goto IL_2F00;
												}
												if (type != 22)
												{
													goto IL_4430;
												}
												goto IL_3011;
											}
											else
											{
												float num59 = 1f;
												float num60 = 0.95f;
												float num61 = 0.8f;
												if (tile4.frameX >= 66)
												{
													goto IL_4430;
												}
												int num62 = (int)(tile4.frameY / 22);
												if (num62 == 1)
												{
													num59 = 0f;
													num60 = 0.1f;
													num61 = 1.3f;
												}
												else
												{
													if (num62 == 2)
													{
														num59 = 1f;
														num60 = 0.1f;
														num61 = 0.1f;
													}
													else
													{
														if (num62 == 3)
														{
															num59 = 0f;
															num60 = 1f;
															num61 = 0.1f;
														}
														else
														{
															if (num62 == 4)
															{
																num59 = 0.9f;
																num60 = 0f;
																num61 = 0.9f;
															}
															else
															{
																if (num62 == 5)
																{
																	num59 = 1.3f;
																	num60 = 1.3f;
																	num61 = 1.3f;
																}
																else
																{
																	if (num62 == 6)
																	{
																		num59 = 0.9f;
																		num60 = 0.9f;
																		num61 = 0f;
																	}
																	else
																	{
																		if (num62 == 7)
																		{
																			num59 = 0.5f * Main.demonTorch + 1f * (1f - Main.demonTorch);
																			num60 = 0.3f;
																			num61 = 1f * Main.demonTorch + 0.5f * (1f - Main.demonTorch);
																		}
																		else
																		{
																			if (num62 == 8)
																			{
																				num61 = 0.7f;
																				num59 = 0.85f;
																				num60 = 1f;
																			}
																			else
																			{
																				if (num62 == 9)
																				{
																					num61 = 1f;
																					num59 = 0.7f;
																					num60 = 0.85f;
																				}
																				else
																				{
																					if (num62 == 10)
																					{
																						num59 = 1f;
																						num60 = 0.5f;
																						num61 = 0f;
																					}
																					else
																					{
																						if (num62 == 11)
																						{
																							num59 = 1.25f;
																							num60 = 1.25f;
																							num61 = 0.8f;
																						}
																						else
																						{
																							if (num62 == 12)
																							{
																								num59 *= 0.75f;
																								num60 *= 1.3499999f;
																								num61 *= 1.5f;
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
												if (lightingState19.r2 < num59)
												{
													lightingState19.r2 = num59;
												}
												if (lightingState19.g2 < num60)
												{
													lightingState19.g2 = num60;
												}
												if (lightingState19.b2 < num61)
												{
													lightingState19.b2 = num61;
													goto IL_4430;
												}
												goto IL_4430;
											}
										}
										else
										{
											if (type != 26)
											{
												switch (type)
												{
												case 31:
													break;
												case 32:
												case 36:
													goto IL_4430;
												case 33:
													if (tile4.frameX != 0)
													{
														goto IL_4430;
													}
													if (tile4.frameY == 0)
													{
														if (lightingState19.r2 < 1f)
														{
															lightingState19.r2 = 1f;
														}
														if ((double)lightingState19.g2 < 0.95)
														{
															lightingState19.g2 = 0.95f;
														}
														if ((double)lightingState19.b2 < 0.65)
														{
															lightingState19.b2 = 0.65f;
															goto IL_4430;
														}
														goto IL_4430;
													}
													else
													{
														if (tile4.frameY == 22)
														{
															if (lightingState19.r2 < 0.55f)
															{
																lightingState19.r2 = 0.55f;
															}
															if ((double)lightingState19.g2 < 0.85)
															{
																lightingState19.g2 = 0.85f;
															}
															if ((double)lightingState19.b2 < 0.35)
															{
																lightingState19.b2 = 0.35f;
																goto IL_4430;
															}
															goto IL_4430;
														}
														else
														{
															if (tile4.frameY == 44)
															{
																if ((double)lightingState19.r2 < 0.65)
																{
																	lightingState19.r2 = 0.65f;
																}
																if ((double)lightingState19.g2 < 0.95)
																{
																	lightingState19.g2 = 0.95f;
																}
																if ((double)lightingState19.b2 < 0.5)
																{
																	lightingState19.b2 = 0.5f;
																	goto IL_4430;
																}
																goto IL_4430;
															}
															else
															{
																if (tile4.frameY == 66)
																{
																	if ((double)lightingState19.r2 < 0.2)
																	{
																		lightingState19.r2 = 0.2f;
																	}
																	if ((double)lightingState19.g2 < 0.75)
																	{
																		lightingState19.g2 = 0.75f;
																	}
																	if (lightingState19.b2 < 1f)
																	{
																		lightingState19.b2 = 1f;
																		goto IL_4430;
																	}
																	goto IL_4430;
																}
																else
																{
																	if (tile4.frameY == 308)
																	{
																		if (lightingState19.r2 < 1f)
																		{
																			lightingState19.r2 = 1f;
																		}
																		if (lightingState19.g2 < 1f)
																		{
																			lightingState19.g2 = 1f;
																		}
																		if ((double)lightingState19.b2 < 0.6)
																		{
																			lightingState19.b2 = 0.6f;
																			goto IL_4430;
																		}
																		goto IL_4430;
																	}
																	else
																	{
																		if (lightingState19.r2 < 1f)
																		{
																			lightingState19.r2 = 1f;
																		}
																		if ((double)lightingState19.g2 < 0.95)
																		{
																			lightingState19.g2 = 0.95f;
																		}
																		if ((double)lightingState19.b2 < 0.65)
																		{
																			lightingState19.b2 = 0.65f;
																			goto IL_4430;
																		}
																		goto IL_4430;
																	}
																}
															}
														}
													}
													break;
												case 34:
												{
													if (tile4.frameX >= 54)
													{
														goto IL_4430;
													}
													int num63 = (int)(tile4.frameY / 54);
													if (num63 == 7)
													{
														if ((double)lightingState19.r2 < 0.95)
														{
															lightingState19.r2 = 0.95f;
														}
														if ((double)lightingState19.g2 < 0.95)
														{
															lightingState19.g2 = 0.95f;
														}
														if ((double)lightingState19.b2 < 0.5)
														{
															lightingState19.b2 = 0.5f;
															goto IL_4430;
														}
														goto IL_4430;
													}
													else
													{
														if (num63 == 8)
														{
															if ((double)lightingState19.r2 < 0.85)
															{
																lightingState19.r2 = 0.85f;
															}
															if ((double)lightingState19.g2 < 0.6)
															{
																lightingState19.g2 = 0.6f;
															}
															if (lightingState19.b2 < 1f)
															{
																lightingState19.b2 = 1f;
																goto IL_4430;
															}
															goto IL_4430;
														}
														else
														{
															if (num63 == 9)
															{
																if (lightingState19.r2 < 1f)
																{
																	lightingState19.r2 = 1f;
																}
																if ((double)lightingState19.g2 < 0.6)
																{
																	lightingState19.g2 = 0.6f;
																}
																if ((double)lightingState19.b2 < 0.6)
																{
																	lightingState19.b2 = 0.6f;
																	goto IL_4430;
																}
																goto IL_4430;
															}
															else
															{
																if (num63 == 11 || num63 == 17)
																{
																	if ((double)lightingState19.r2 < 0.75)
																	{
																		lightingState19.r2 = 0.75f;
																	}
																	if ((double)lightingState19.g2 < 0.9)
																	{
																		lightingState19.g2 = 0.9f;
																	}
																	if (lightingState19.b2 < 1f)
																	{
																		lightingState19.b2 = 1f;
																		goto IL_4430;
																	}
																	goto IL_4430;
																}
																else
																{
																	if (num63 == 15)
																	{
																		if (lightingState19.r2 < 1f)
																		{
																			lightingState19.r2 = 1f;
																		}
																		if (lightingState19.g2 < 1f)
																		{
																			lightingState19.g2 = 1f;
																		}
																		if ((double)lightingState19.b2 < 0.7)
																		{
																			lightingState19.b2 = 0.7f;
																			goto IL_4430;
																		}
																		goto IL_4430;
																	}
																	else
																	{
																		if (num63 == 18)
																		{
																			if (lightingState19.r2 < 1f)
																			{
																				lightingState19.r2 = 1f;
																			}
																			if (lightingState19.g2 < 1f)
																			{
																				lightingState19.g2 = 1f;
																			}
																			if ((double)lightingState19.b2 < 0.6)
																			{
																				lightingState19.b2 = 0.6f;
																				goto IL_4430;
																			}
																			goto IL_4430;
																		}
																		else
																		{
																			if (lightingState19.r2 < 1f)
																			{
																				lightingState19.r2 = 1f;
																			}
																			if ((double)lightingState19.g2 < 0.95)
																			{
																				lightingState19.g2 = 0.95f;
																			}
																			if ((double)lightingState19.b2 < 0.8)
																			{
																				lightingState19.b2 = 0.8f;
																				goto IL_4430;
																			}
																			goto IL_4430;
																		}
																	}
																}
															}
														}
													}
													break;
												}
												case 35:
													if (tile4.frameX >= 36)
													{
														goto IL_4430;
													}
													if ((double)lightingState19.r2 < 0.75)
													{
														lightingState19.r2 = 0.75f;
													}
													if ((double)lightingState19.g2 < 0.6)
													{
														lightingState19.g2 = 0.6f;
													}
													if ((double)lightingState19.b2 < 0.3)
													{
														lightingState19.b2 = 0.3f;
														goto IL_4430;
													}
													goto IL_4430;
												case 37:
													if ((double)lightingState19.r2 < 0.56)
													{
														lightingState19.r2 = 0.56f;
													}
													if ((double)lightingState19.g2 < 0.43)
													{
														lightingState19.g2 = 0.43f;
													}
													if ((double)lightingState19.b2 < 0.15)
													{
														lightingState19.b2 = 0.15f;
														goto IL_4430;
													}
													goto IL_4430;
												default:
												{
													if (type != 42)
													{
														goto IL_4430;
													}
													if (tile4.frameX != 0)
													{
														goto IL_4430;
													}
													int num64 = (int)(tile4.frameY / 36);
													float num65 = 1f;
													float num66 = 1f;
													float num67 = 1f;
													if (num64 == 0)
													{
														num65 = 0.7f;
														num66 = 0.65f;
														num67 = 0.55f;
													}
													else
													{
														if (num64 == 1)
														{
															num65 = 0.9f;
															num66 = 0.75f;
															num67 = 0.6f;
														}
														else
														{
															if (num64 == 2)
															{
																num65 = 0.8f;
																num66 = 0.6f;
																num67 = 0.6f;
															}
															else
															{
																if (num64 == 3)
																{
																	num65 = 0.65f;
																	num66 = 0.5f;
																	num67 = 0.2f;
																}
																else
																{
																	if (num64 == 4)
																	{
																		num65 = 0.5f;
																		num66 = 0.7f;
																		num67 = 0.4f;
																	}
																	else
																	{
																		if (num64 == 5)
																		{
																			num65 = 0.9f;
																			num66 = 0.4f;
																			num67 = 0.2f;
																		}
																		else
																		{
																			if (num64 == 6)
																			{
																				num65 = 0.7f;
																				num66 = 0.75f;
																				num67 = 0.3f;
																			}
																			else
																			{
																				if (num64 == 7)
																				{
																					num65 = 0.9f;
																					num66 = 0.9f;
																					num67 = 0.7f;
																					num67 += Main.demonTorch * 0.2f;
																					num65 -= Main.demonTorch * 0.2f;
																					num66 -= Main.demonTorch * 0.2f;
																				}
																				else
																				{
																					if (num64 == 8)
																					{
																						num65 = 0.75f;
																						num66 = 0.6f;
																						num67 = 0.3f;
																					}
																					else
																					{
																						if (num64 == 9)
																						{
																							num65 = 1f;
																							num66 = 0.3f;
																							num67 = 0.5f;
																							num67 += Main.demonTorch * 0.2f;
																							num65 -= Main.demonTorch * 0.1f;
																							num66 -= Main.demonTorch * 0.2f;
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
													if (lightingState19.r2 < num65)
													{
														lightingState19.r2 = num65;
													}
													if (lightingState19.g2 < num66)
													{
														lightingState19.g2 = num66;
													}
													if (lightingState19.b2 < num67)
													{
														lightingState19.b2 = num67;
														goto IL_4430;
													}
													goto IL_4430;
												}
												}
											}
											if ((tile4.type == 31 && tile4.frameX >= 36) || (tile4.type == 26 && tile4.frameX >= 54))
											{
												float num68 = (float)Main.rand.Next(-5, 6) * 0.0025f;
												if (lightingState19.r2 < 0.5f + num68 * 2f)
												{
													lightingState19.r2 = 0.5f + num68 * 2f;
												}
												if (lightingState19.g2 < 0.2f + num68)
												{
													lightingState19.g2 = 0.2f + num68;
												}
												if (lightingState19.b2 < 0.1f)
												{
													lightingState19.b2 = 0.1f;
													goto IL_4430;
												}
												goto IL_4430;
											}
											else
											{
												float num69 = (float)Main.rand.Next(-5, 6) * 0.0025f;
												if (lightingState19.r2 < 0.31f + num69)
												{
													lightingState19.r2 = 0.31f + num69;
												}
												if (lightingState19.g2 < 0.1f + num69)
												{
													lightingState19.g2 = 0.1f;
												}
												if (lightingState19.b2 < 0.44f + num69 * 2f)
												{
													lightingState19.b2 = 0.44f + num69 * 2f;
													goto IL_4430;
												}
												goto IL_4430;
											}
										}
									}
									else
									{
										if (type <= 72)
										{
											if (type != 49)
											{
												if (type != 61)
												{
													switch (type)
													{
													case 70:
													case 71:
													case 72:
														goto IL_3524;
													default:
														goto IL_4430;
													}
												}
												else
												{
													if (tile4.frameX != 144)
													{
														goto IL_4430;
													}
													float num70 = 1f + (float)(270 - (int)Main.mouseTextColor) / 400f;
													float num71 = 0.8f - (float)(270 - (int)Main.mouseTextColor) / 400f;
													if (lightingState19.r2 < 0.42f * num70)
													{
														lightingState19.r2 = 0.42f * num71;
													}
													if (lightingState19.g2 < 0.81f * num70)
													{
														lightingState19.g2 = 0.81f * num70;
													}
													if (lightingState19.b2 < 0.52f * num70)
													{
														lightingState19.b2 = 0.52f * num71;
														goto IL_4430;
													}
													goto IL_4430;
												}
											}
											else
											{
												if (lightingState19.r2 < 0f)
												{
													lightingState19.r2 = 0f;
												}
												if (lightingState19.g2 < 0.35f)
												{
													lightingState19.g2 = 0.35f;
												}
												if (lightingState19.b2 < 0.8f)
												{
													lightingState19.b2 = 0.8f;
													goto IL_4430;
												}
												goto IL_4430;
											}
										}
										else
										{
											if (type != 77)
											{
												switch (type)
												{
												case 83:
													if (tile4.frameX != 18 || Main.dayTime)
													{
														goto IL_4430;
													}
													if ((double)lightingState19.r2 < 0.1)
													{
														lightingState19.r2 = 0.1f;
													}
													if ((double)lightingState19.g2 < 0.4)
													{
														lightingState19.g2 = 0.4f;
													}
													if ((double)lightingState19.b2 < 0.6)
													{
														lightingState19.b2 = 0.6f;
														goto IL_4430;
													}
													goto IL_4430;
												case 84:
												{
													int num72 = (int)(tile4.frameX / 18);
													if (num72 == 2)
													{
														float num73 = (float)(270 - (int)Main.mouseTextColor);
														num73 /= 800f;
														if (num73 > 1f)
														{
															num73 = 1f;
														}
														if (num73 < 0f)
														{
															num73 = 0f;
														}
														float num74 = num73;
														if (lightingState19.r2 < num74 * 0.7f)
														{
															lightingState19.r2 = num74 * 0.7f;
														}
														if (lightingState19.g2 < num74)
														{
															lightingState19.g2 = num74;
														}
														if (lightingState19.b2 < num74 * 0.1f)
														{
															lightingState19.b2 = num74 * 0.1f;
															goto IL_4430;
														}
														goto IL_4430;
													}
													else
													{
														if (num72 != 5)
														{
															goto IL_4430;
														}
														float num74 = 0.9f;
														if (lightingState19.r2 < num74)
														{
															lightingState19.r2 = num74;
														}
														if (lightingState19.g2 < num74 * 0.8f)
														{
															lightingState19.g2 = num74 * 0.8f;
														}
														if (lightingState19.b2 < num74 * 0.2f)
														{
															lightingState19.b2 = num74 * 0.2f;
															goto IL_4430;
														}
														goto IL_4430;
													}
													break;
												}
												default:
													switch (type)
													{
													case 92:
														if (tile4.frameY > 18 || tile4.frameX != 0)
														{
															goto IL_4430;
														}
														if (lightingState19.r2 < 1f)
														{
															lightingState19.r2 = 1f;
														}
														if (lightingState19.g2 < 1f)
														{
															lightingState19.g2 = 1f;
														}
														if (lightingState19.b2 < 1f)
														{
															lightingState19.b2 = 1f;
															goto IL_4430;
														}
														goto IL_4430;
													case 93:
													{
														if (tile4.frameX != 0)
														{
															goto IL_4430;
														}
														int num75 = (int)(tile4.frameY / 54);
														if (num75 == 1)
														{
															if ((double)lightingState19.r2 < 0.95)
															{
																lightingState19.r2 = 0.95f;
															}
															if ((double)lightingState19.g2 < 0.95)
															{
																lightingState19.g2 = 0.95f;
															}
															if ((double)lightingState19.b2 < 0.5)
															{
																lightingState19.b2 = 0.5f;
																goto IL_4430;
															}
															goto IL_4430;
														}
														else
														{
															if (num75 == 2)
															{
																if ((double)lightingState19.r2 < 0.85)
																{
																	lightingState19.r2 = 0.85f;
																}
																if ((double)lightingState19.g2 < 0.6)
																{
																	lightingState19.g2 = 0.6f;
																}
																if (lightingState19.b2 < 1f)
																{
																	lightingState19.b2 = 1f;
																	goto IL_4430;
																}
																goto IL_4430;
															}
															else
															{
																if (num75 == 3)
																{
																	if ((double)lightingState19.r2 < 0.75)
																	{
																		lightingState19.r2 = 0.75f;
																	}
																	if (lightingState19.g2 < 1f)
																	{
																		lightingState19.g2 = 1f;
																	}
																	if ((double)lightingState19.b2 < 0.6)
																	{
																		lightingState19.b2 = 0.6f;
																		goto IL_4430;
																	}
																	goto IL_4430;
																}
																else
																{
																	if (num75 == 4 || num75 == 5)
																	{
																		if ((double)lightingState19.r2 < 0.75)
																		{
																			lightingState19.r2 = 0.75f;
																		}
																		if ((double)lightingState19.g2 < 0.9)
																		{
																			lightingState19.g2 = 0.9f;
																		}
																		if (lightingState19.b2 < 1f)
																		{
																			lightingState19.b2 = 1f;
																			goto IL_4430;
																		}
																		goto IL_4430;
																	}
																	else
																	{
																		if (num75 == 9)
																		{
																			if (lightingState19.r2 < 1f)
																			{
																				lightingState19.r2 = 1f;
																			}
																			if (lightingState19.g2 < 1f)
																			{
																				lightingState19.g2 = 1f;
																			}
																			if ((double)lightingState19.b2 < 0.7)
																			{
																				lightingState19.b2 = 0.7f;
																				goto IL_4430;
																			}
																			goto IL_4430;
																		}
																		else
																		{
																			if (num75 == 13)
																			{
																				if (lightingState19.r2 < 1f)
																				{
																					lightingState19.r2 = 1f;
																				}
																				if (lightingState19.g2 < 1f)
																				{
																					lightingState19.g2 = 1f;
																				}
																				if ((double)lightingState19.b2 < 0.6)
																				{
																					lightingState19.b2 = 0.6f;
																					goto IL_4430;
																				}
																				goto IL_4430;
																			}
																			else
																			{
																				if (lightingState19.r2 < 1f)
																				{
																					lightingState19.r2 = 1f;
																				}
																				if ((double)lightingState19.g2 < 0.97)
																				{
																					lightingState19.g2 = 0.97f;
																				}
																				if ((double)lightingState19.b2 < 0.85)
																				{
																					lightingState19.b2 = 0.85f;
																					goto IL_4430;
																				}
																				goto IL_4430;
																			}
																		}
																	}
																}
															}
														}
														break;
													}
													case 94:
													case 97:
													case 99:
														goto IL_4430;
													case 95:
														if (tile4.frameX >= 36)
														{
															goto IL_4430;
														}
														if (lightingState19.r2 < 1f)
														{
															lightingState19.r2 = 1f;
														}
														if ((double)lightingState19.g2 < 0.95)
														{
															lightingState19.g2 = 0.95f;
														}
														if ((double)lightingState19.b2 < 0.8)
														{
															lightingState19.b2 = 0.8f;
															goto IL_4430;
														}
														goto IL_4430;
													case 96:
														if (tile4.frameX < 36)
														{
															goto IL_4430;
														}
														if ((double)lightingState19.r2 < 0.5)
														{
															lightingState19.r2 = 0.5f;
														}
														if ((double)lightingState19.g2 < 0.35)
														{
															lightingState19.g2 = 0.35f;
														}
														if ((double)lightingState19.b2 < 0.1)
														{
															lightingState19.b2 = 0.1f;
															goto IL_4430;
														}
														goto IL_4430;
													case 98:
														if (tile4.frameY != 0)
														{
															goto IL_4430;
														}
														if (lightingState19.r2 < 1f)
														{
															lightingState19.r2 = 1f;
														}
														if ((double)lightingState19.g2 < 0.97)
														{
															lightingState19.g2 = 0.97f;
														}
														if ((double)lightingState19.b2 < 0.85)
														{
															lightingState19.b2 = 0.85f;
															goto IL_4430;
														}
														goto IL_4430;
													case 100:
														break;
													default:
														goto IL_4430;
													}
													break;
												}
											}
											else
											{
												if (lightingState19.r2 < 0.75f)
												{
													lightingState19.r2 = 0.75f;
												}
												if (lightingState19.g2 < 0.45f)
												{
													lightingState19.g2 = 0.45f;
												}
												if (lightingState19.b2 < 0.25f)
												{
													lightingState19.b2 = 0.25f;
													goto IL_4430;
												}
												goto IL_4430;
											}
										}
									}
								}
								else
								{
									if (type <= 174)
									{
										if (type <= 140)
										{
											switch (type)
											{
											case 125:
											{
												float num76 = (float)Main.rand.Next(28, 42) * 0.01f;
												num76 += (float)(270 - (int)Main.mouseTextColor) / 800f;
												if ((double)lightingState19.g2 < 0.1 * (double)num76)
												{
													lightingState19.g2 = 0.3f * num76;
												}
												if ((double)lightingState19.b2 < 0.3 * (double)num76)
												{
													lightingState19.b2 = 0.6f * num76;
													goto IL_4430;
												}
												goto IL_4430;
											}
											case 126:
												if (tile4.frameX >= 36)
												{
													goto IL_4430;
												}
												if (lightingState19.r2 < (float)Main.DiscoR / 255f)
												{
													lightingState19.r2 = (float)Main.DiscoR / 255f;
												}
												if (lightingState19.g2 < (float)Main.DiscoG / 255f)
												{
													lightingState19.g2 = (float)Main.DiscoG / 255f;
												}
												if (lightingState19.b2 < (float)Main.DiscoB / 255f)
												{
													lightingState19.b2 = (float)Main.DiscoB / 255f;
													goto IL_4430;
												}
												goto IL_4430;
											case 127:
											case 128:
												goto IL_4430;
											case 129:
											{
												float num59;
												float num60;
												float num61;
												if (tile4.frameX == 0 || tile4.frameX == 54 || tile4.frameX == 108)
												{
													num60 = 0.05f;
													num61 = 0.25f;
													num59 = 0f;
												}
												else
												{
													if (tile4.frameX == 18 || tile4.frameX == 72 || tile4.frameX == 126)
													{
														num59 = 0.2f;
														num61 = 0.15f;
														num60 = 0f;
													}
													else
													{
														num61 = 0.2f;
														num59 = 0.1f;
														num60 = 0f;
													}
												}
												if (lightingState19.r2 < num59)
												{
													lightingState19.r2 = num59 * (float)Main.rand.Next(970, 1031) * 0.001f;
												}
												if (lightingState19.g2 < num60)
												{
													lightingState19.g2 = num60 * (float)Main.rand.Next(970, 1031) * 0.001f;
												}
												if (lightingState19.b2 < num61)
												{
													lightingState19.b2 = num61 * (float)Main.rand.Next(970, 1031) * 0.001f;
													goto IL_4430;
												}
												goto IL_4430;
											}
											default:
												if (type == 133)
												{
													goto IL_2F00;
												}
												if (type != 140)
												{
													goto IL_4430;
												}
												goto IL_3011;
											}
										}
										else
										{
											if (type != 149)
											{
												if (type != 160)
												{
													switch (type)
													{
													case 171:
													{
														int num77 = num44;
														int num78 = num45;
														if (tile4.frameX < 10)
														{
															num77 -= (int)tile4.frameX;
															num78 -= (int)tile4.frameY;
														}
														int num79 = 0;
														if ((Main.tile[num77, num78].frameY & 1024) == 1024)
														{
															num79++;
														}
														if ((Main.tile[num77, num78].frameY & 2048) == 2048)
														{
															num79 += 2;
														}
														if ((Main.tile[num77, num78].frameY & 4096) == 4096)
														{
															num79 += 4;
														}
														if ((Main.tile[num77, num78].frameY & 8192) == 8192)
														{
															num79 += 8;
														}
														if (num79 <= 0)
														{
															goto IL_4430;
														}
														float num80 = 0f;
														float num81 = 0f;
														float num82 = 0f;
														if (num79 == 1)
														{
															num80 = 0.1f;
															num81 = 0.1f;
															num82 = 0.1f;
														}
														else
														{
															if (num79 == 2)
															{
																num80 = 0.2f;
															}
															else
															{
																if (num79 == 3)
																{
																	num81 = 0.2f;
																}
																else
																{
																	if (num79 == 4)
																	{
																		num82 = 0.2f;
																	}
																	else
																	{
																		if (num79 == 5)
																		{
																			num80 = 0.125f;
																			num81 = 0.125f;
																		}
																		else
																		{
																			if (num79 == 6)
																			{
																				num80 = 0.2f;
																				num81 = 0.1f;
																			}
																			else
																			{
																				if (num79 == 7)
																				{
																					num80 = 0.125f;
																					num81 = 0.125f;
																				}
																				else
																				{
																					if (num79 == 8)
																					{
																						num80 = 0.08f;
																						num81 = 0.175f;
																					}
																					else
																					{
																						if (num79 == 9)
																						{
																							num81 = 0.125f;
																							num82 = 0.125f;
																						}
																						else
																						{
																							if (num79 == 10)
																							{
																								num80 = 0.125f;
																								num82 = 0.125f;
																							}
																							else
																							{
																								if (num79 == 11)
																								{
																									num80 = 0.1f;
																									num81 = 0.1f;
																									num82 = 0.2f;
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
														num80 *= 0.5f;
														num81 *= 0.5f;
														num82 *= 0.5f;
														if (lightingState19.r2 < num80)
														{
															lightingState19.r2 = num80;
														}
														if (lightingState19.g2 < num81)
														{
															lightingState19.g2 = num81;
														}
														if (lightingState19.b2 < num82)
														{
															lightingState19.b2 = num82;
															goto IL_4430;
														}
														goto IL_4430;
													}
													case 172:
														goto IL_4430;
													case 173:
														break;
													case 174:
														if (tile4.frameX != 0)
														{
															goto IL_4430;
														}
														if (lightingState19.r2 < 1f)
														{
															lightingState19.r2 = 1f;
														}
														if ((double)lightingState19.g2 < 0.95)
														{
															lightingState19.g2 = 0.95f;
														}
														if ((double)lightingState19.b2 < 0.65)
														{
															lightingState19.b2 = 0.65f;
															goto IL_4430;
														}
														goto IL_4430;
													default:
														goto IL_4430;
													}
												}
												else
												{
													float num83 = (float)Main.DiscoR / 255f;
													float num84 = (float)Main.DiscoG / 255f;
													float num85 = (float)Main.DiscoB / 255f;
													num83 *= 0.25f;
													num84 *= 0.25f;
													num85 *= 0.25f;
													if (lightingState19.r2 < num83)
													{
														lightingState19.r2 = num83;
													}
													if (lightingState19.g2 < num84)
													{
														lightingState19.g2 = num84;
													}
													if (lightingState19.b2 < num85)
													{
														lightingState19.b2 = num85;
														goto IL_4430;
													}
													goto IL_4430;
												}
											}
											else
											{
												float num59;
												float num60;
												float num61;
												if (tile4.frameX == 0)
												{
													num60 = 0.2f;
													num61 = 0.5f;
													num59 = 0.1f;
												}
												else
												{
													if (tile4.frameX == 18)
													{
														num59 = 0.5f;
														num61 = 0.1f;
														num60 = 0.1f;
													}
													else
													{
														num61 = 0.1f;
														num59 = 0.2f;
														num60 = 0.5f;
													}
												}
												if (tile4.frameX > 36)
												{
													goto IL_4430;
												}
												if (lightingState19.r2 < num59)
												{
													lightingState19.r2 = num59 * (float)Main.rand.Next(970, 1031) * 0.001f;
												}
												if (lightingState19.g2 < num60)
												{
													lightingState19.g2 = num60 * (float)Main.rand.Next(970, 1031) * 0.001f;
												}
												if (lightingState19.b2 < num61)
												{
													lightingState19.b2 = num61 * (float)Main.rand.Next(970, 1031) * 0.001f;
													goto IL_4430;
												}
												goto IL_4430;
											}
										}
									}
									else
									{
										if (type <= 215)
										{
											if (type == 190)
											{
												goto IL_3524;
											}
											if (type != 204)
											{
												if (type != 215)
												{
													goto IL_4430;
												}
												float num86 = (float)Main.rand.Next(28, 42) * 0.005f;
												num86 += (float)(270 - (int)Main.mouseTextColor) / 700f;
												if ((double)lightingState19.r2 < 0.9 + (double)num86)
												{
													lightingState19.r2 = 0.9f + num86;
												}
												if ((double)lightingState19.g2 < 0.3 + (double)num86)
												{
													lightingState19.g2 = 0.3f + num86;
												}
												if ((double)lightingState19.b2 < 0.1 + (double)num86)
												{
													lightingState19.b2 = 0.1f + num86;
													goto IL_4430;
												}
												goto IL_4430;
											}
											else
											{
												if ((double)lightingState19.r2 < 0.35)
												{
													lightingState19.r2 = 0.35f;
													goto IL_4430;
												}
												goto IL_4430;
											}
										}
										else
										{
											switch (type)
											{
											case 235:
												if ((double)lightingState19.r2 < 0.6)
												{
													lightingState19.r2 = 0.6f;
												}
												if ((double)lightingState19.g2 < 0.6)
												{
													lightingState19.g2 = 0.6f;
													goto IL_4430;
												}
												goto IL_4430;
											case 236:
												goto IL_4430;
											case 237:
												if ((double)lightingState19.r2 < 0.1)
												{
													lightingState19.r2 = 0.1f;
												}
												if ((double)lightingState19.g2 < 0.1)
												{
													lightingState19.g2 = 0.1f;
													goto IL_4430;
												}
												goto IL_4430;
											case 238:
												if ((double)lightingState19.r2 < 0.5)
												{
													lightingState19.r2 = 0.5f;
												}
												if ((double)lightingState19.b2 < 0.5)
												{
													lightingState19.b2 = 0.5f;
													goto IL_4430;
												}
												goto IL_4430;
											default:
												switch (type)
												{
												case 262:
													if (lightingState19.r2 < 0.75f)
													{
														lightingState19.r2 = 0.75f;
													}
													if (lightingState19.b2 < 0.75f)
													{
														lightingState19.b2 = 0.75f;
														goto IL_4430;
													}
													goto IL_4430;
												case 263:
													if (lightingState19.r2 < 0.75f)
													{
														lightingState19.r2 = 0.75f;
													}
													if (lightingState19.g2 < 0.75f)
													{
														lightingState19.g2 = 0.75f;
														goto IL_4430;
													}
													goto IL_4430;
												case 264:
													if (lightingState19.b2 < 0.75f)
													{
														lightingState19.b2 = 0.75f;
														goto IL_4430;
													}
													goto IL_4430;
												case 265:
													if (lightingState19.g2 < 0.75f)
													{
														lightingState19.g2 = 0.75f;
														goto IL_4430;
													}
													goto IL_4430;
												case 266:
													if (lightingState19.r2 < 0.75f)
													{
														lightingState19.r2 = 0.75f;
														goto IL_4430;
													}
													goto IL_4430;
												case 267:
													if (lightingState19.r2 < 0.75f)
													{
														lightingState19.r2 = 0.75f;
													}
													if (lightingState19.g2 < 0.75f)
													{
														lightingState19.g2 = 0.75f;
													}
													if (lightingState19.b2 < 0.75f)
													{
														lightingState19.b2 = 0.75f;
														goto IL_4430;
													}
													goto IL_4430;
												case 268:
													if (lightingState19.r2 < 0.75f)
													{
														lightingState19.r2 = 0.75f;
													}
													if (lightingState19.g2 < 0.375f)
													{
														lightingState19.g2 = 0.375f;
														goto IL_4430;
													}
													goto IL_4430;
												case 269:
													goto IL_4430;
												case 270:
													if (lightingState19.r2 < 0.73f)
													{
														lightingState19.r2 = 0.73f;
													}
													if (lightingState19.g2 < 1f)
													{
														lightingState19.g2 = 1f;
													}
													if (lightingState19.b2 < 0.41f)
													{
														lightingState19.b2 = 0.41f;
														goto IL_4430;
													}
													goto IL_4430;
												case 271:
													if (lightingState19.r2 < 0.45f)
													{
														lightingState19.r2 = 0.45f;
													}
													if (lightingState19.g2 < 0.95f)
													{
														lightingState19.g2 = 0.95f;
													}
													if (lightingState19.b2 < 1f)
													{
														lightingState19.b2 = 1f;
														goto IL_4430;
													}
													goto IL_4430;
												default:
													if (type != 286)
													{
														goto IL_4430;
													}
													if ((double)lightingState19.r2 < 0.1)
													{
														lightingState19.r2 = 0.1f;
													}
													if ((double)lightingState19.g2 < 0.2)
													{
														lightingState19.g2 = 0.2f;
													}
													if ((double)lightingState19.b2 < 0.7)
													{
														lightingState19.b2 = 0.7f;
														goto IL_4430;
													}
													goto IL_4430;
												}
												break;
											}
										}
									}
								}
								if (tile4.frameX >= 36)
								{
									goto IL_4430;
								}
								int num87 = (int)(tile4.frameY / 36);
								if (num87 == 1)
								{
									if ((double)lightingState19.r2 < 0.95)
									{
										lightingState19.r2 = 0.95f;
									}
									if ((double)lightingState19.g2 < 0.95)
									{
										lightingState19.g2 = 0.95f;
									}
									if ((double)lightingState19.b2 < 0.5)
									{
										lightingState19.b2 = 0.5f;
										goto IL_4430;
									}
									goto IL_4430;
								}
								else
								{
									if (num87 == 3)
									{
										if (lightingState19.r2 < 1f)
										{
											lightingState19.r2 = 1f;
										}
										if ((double)lightingState19.g2 < 0.6)
										{
											lightingState19.g2 = 0.6f;
										}
										if ((double)lightingState19.b2 < 0.6)
										{
											lightingState19.b2 = 0.6f;
											goto IL_4430;
										}
										goto IL_4430;
									}
									else
									{
										if (num87 == 6 || num87 == 9)
										{
											if ((double)lightingState19.r2 < 0.75)
											{
												lightingState19.r2 = 0.75f;
											}
											if ((double)lightingState19.g2 < 0.9)
											{
												lightingState19.g2 = 0.9f;
											}
											if (lightingState19.b2 < 1f)
											{
												lightingState19.b2 = 1f;
												goto IL_4430;
											}
											goto IL_4430;
										}
										else
										{
											if (num87 == 11)
											{
												if (lightingState19.r2 < 1f)
												{
													lightingState19.r2 = 1f;
												}
												if (lightingState19.g2 < 1f)
												{
													lightingState19.g2 = 1f;
												}
												if ((double)lightingState19.b2 < 0.7)
												{
													lightingState19.b2 = 0.7f;
													goto IL_4430;
												}
												goto IL_4430;
											}
											else
											{
												if (num87 == 13)
												{
													if (lightingState19.r2 < 1f)
													{
														lightingState19.r2 = 1f;
													}
													if (lightingState19.g2 < 1f)
													{
														lightingState19.g2 = 1f;
													}
													if ((double)lightingState19.b2 < 0.6)
													{
														lightingState19.b2 = 0.6f;
														goto IL_4430;
													}
													goto IL_4430;
												}
												else
												{
													if (lightingState19.r2 < 1f)
													{
														lightingState19.r2 = 1f;
													}
													if ((double)lightingState19.g2 < 0.95)
													{
														lightingState19.g2 = 0.95f;
													}
													if ((double)lightingState19.b2 < 0.65)
													{
														lightingState19.b2 = 0.65f;
														goto IL_4430;
													}
													goto IL_4430;
												}
											}
										}
									}
								}
								IL_2F00:
								if (lightingState19.r2 < 0.83f)
								{
									lightingState19.r2 = 0.83f;
								}
								if (lightingState19.g2 < 0.6f)
								{
									lightingState19.g2 = 0.6f;
								}
								if (lightingState19.b2 < 0.5f)
								{
									lightingState19.b2 = 0.5f;
									goto IL_4430;
								}
								goto IL_4430;
								IL_3011:
								if ((double)lightingState19.r2 < 0.12)
								{
									lightingState19.r2 = 0.12f;
								}
								if ((double)lightingState19.g2 < 0.07)
								{
									lightingState19.g2 = 0.07f;
								}
								if ((double)lightingState19.b2 < 0.32)
								{
									lightingState19.b2 = 0.32f;
									goto IL_4430;
								}
								goto IL_4430;
								IL_3524:
								float num88 = (float)Main.rand.Next(28, 42) * 0.005f;
								num88 += (float)(270 - (int)Main.mouseTextColor) / 1000f;
								if (lightingState19.r2 < 0.1f)
								{
									lightingState19.r2 = 0.1f;
								}
								if (lightingState19.g2 < 0.2f + num88 / 2f)
								{
									lightingState19.g2 = 0.2f + num88 / 2f;
								}
								if (lightingState19.b2 < 0.7f + num88)
								{
									lightingState19.b2 = 0.7f + num88;
								}
							}
							else
							{
								type = tile4.type;
								if (type <= 84)
								{
									if (type <= 37)
									{
										if (type <= 17)
										{
											if (type != 4)
											{
												if (type != 17)
												{
													goto IL_4430;
												}
												goto IL_40CA;
											}
											else
											{
												if (tile4.frameX < 66)
												{
													lightingState19.r2 = 1f;
													goto IL_4430;
												}
												goto IL_4430;
											}
										}
										else
										{
											if (type != 22)
											{
												if (type != 26)
												{
													switch (type)
													{
													case 31:
														break;
													case 32:
													case 36:
														goto IL_4430;
													case 33:
														goto IL_406F;
													case 34:
														if (tile4.frameX < 54)
														{
															lightingState19.r2 = 1f;
															goto IL_4430;
														}
														goto IL_4430;
													case 35:
														if (tile4.frameX < 36)
														{
															lightingState19.r2 = 0.6f;
															goto IL_4430;
														}
														goto IL_4430;
													case 37:
														if (lightingState19.r2 < 0.5f)
														{
															lightingState19.r2 = 0.5f;
															goto IL_4430;
														}
														goto IL_4430;
													default:
														goto IL_4430;
													}
												}
												float num89 = (float)Main.rand.Next(-5, 6) * 0.01f;
												if (lightingState19.r2 < 0.4f + num89)
												{
													lightingState19.r2 = 0.4f + num89;
													goto IL_4430;
												}
												goto IL_4430;
											}
											else
											{
												if (lightingState19.r2 < 0.2f)
												{
													lightingState19.r2 = 0.2f;
													goto IL_4430;
												}
												goto IL_4430;
											}
										}
									}
									else
									{
										if (type <= 61)
										{
											if (type != 42)
											{
												if (type != 49)
												{
													if (type != 61)
													{
														goto IL_4430;
													}
													if (tile4.frameX == 144 && lightingState19.r2 < 0.75f)
													{
														lightingState19.r2 = 0.75f;
														goto IL_4430;
													}
													goto IL_4430;
												}
												else
												{
													if (lightingState19.r2 < 0.1f)
													{
														lightingState19.r2 = 0.7f;
														goto IL_4430;
													}
													goto IL_4430;
												}
											}
											else
											{
												if (tile4.frameX == 0)
												{
													lightingState19.r2 = 0.75f;
													goto IL_4430;
												}
												goto IL_4430;
											}
										}
										else
										{
											switch (type)
											{
											case 70:
											case 71:
											case 72:
												goto IL_41E8;
											default:
												if (type != 77)
												{
													if (type != 84)
													{
														goto IL_4430;
													}
													int num90 = (int)(tile4.frameX / 18);
													float num91 = 0f;
													if (num90 == 2)
													{
														float num92 = (float)(270 - (int)Main.mouseTextColor);
														num92 /= 500f;
														if (num92 > 1f)
														{
															num92 = 1f;
														}
														if (num92 < 0f)
														{
															num92 = 0f;
														}
														num91 = num92;
													}
													else
													{
														if (num90 == 5)
														{
															num91 = 0.7f;
														}
													}
													if (lightingState19.r2 < num91)
													{
														lightingState19.r2 = num91;
														goto IL_4430;
													}
													goto IL_4430;
												}
												else
												{
													if (lightingState19.r2 < 0.6f)
													{
														lightingState19.r2 = 0.6f;
														goto IL_4430;
													}
													goto IL_4430;
												}
												break;
											}
										}
									}
								}
								else
								{
									if (type <= 160)
									{
										if (type <= 129)
										{
											switch (type)
											{
											case 92:
												if (tile4.frameY <= 18 && tile4.frameX == 0)
												{
													lightingState19.r2 = 1f;
													goto IL_4430;
												}
												goto IL_4430;
											case 93:
												if (tile4.frameX == 0)
												{
													lightingState19.r2 = 1f;
													goto IL_4430;
												}
												goto IL_4430;
											case 94:
											case 97:
											case 99:
												goto IL_4430;
											case 95:
												if (tile4.frameX < 36 && lightingState19.r2 < 0.85f)
												{
													lightingState19.r2 = 0.9f;
													goto IL_4430;
												}
												goto IL_4430;
											case 96:
												if (tile4.frameX >= 36 && (double)lightingState19.r2 < 0.4)
												{
													lightingState19.r2 = 0.4f;
													goto IL_4430;
												}
												goto IL_4430;
											case 98:
												if (tile4.frameY == 0)
												{
													lightingState19.r2 = 1f;
													goto IL_4430;
												}
												goto IL_4430;
											case 100:
												if (tile4.frameX < 36)
												{
													lightingState19.r2 = 1f;
													goto IL_4430;
												}
												goto IL_4430;
											default:
												switch (type)
												{
												case 125:
												{
													float num93 = (float)Main.rand.Next(28, 42) * 0.007f;
													num93 += (float)(270 - (int)Main.mouseTextColor) / 900f;
													if ((double)lightingState19.r2 < 0.5 * (double)num93)
													{
														lightingState19.r2 = 0.3f * num93;
														goto IL_4430;
													}
													goto IL_4430;
												}
												case 126:
													if (tile4.frameX < 36 && lightingState19.r2 < 0.3f)
													{
														lightingState19.r2 = 0.3f;
														goto IL_4430;
													}
													goto IL_4430;
												case 127:
												case 128:
													goto IL_4430;
												case 129:
												{
													float num94 = 0.08f;
													if (lightingState19.r2 < num94)
													{
														lightingState19.r2 = num94 * (float)Main.rand.Next(970, 1031) * 0.001f;
														goto IL_4430;
													}
													goto IL_4430;
												}
												default:
													goto IL_4430;
												}
												break;
											}
										}
										else
										{
											if (type == 133)
											{
												goto IL_40CA;
											}
											if (type != 149)
											{
												if (type != 160)
												{
													goto IL_4430;
												}
												if (lightingState19.r2 < 15f)
												{
													lightingState19.r2 = 0.1f;
													goto IL_4430;
												}
												goto IL_4430;
											}
											else
											{
												if (tile4.frameX > 36)
												{
													goto IL_4430;
												}
												float num94 = 0.4f;
												if (lightingState19.r2 < num94)
												{
													lightingState19.r2 = num94 * (float)Main.rand.Next(970, 1031) * 0.001f;
													goto IL_4430;
												}
												goto IL_4430;
											}
										}
									}
									else
									{
										if (type <= 204)
										{
											if (type != 174)
											{
												if (type == 190)
												{
													goto IL_41E8;
												}
												if (type != 204)
												{
													goto IL_4430;
												}
												if ((double)lightingState19.r2 < 0.2)
												{
													lightingState19.r2 = 0.2f;
													goto IL_4430;
												}
												goto IL_4430;
											}
										}
										else
										{
											if (type != 215)
											{
												if (type != 237)
												{
													switch (type)
													{
													case 262:
													case 263:
													case 264:
													case 265:
													case 266:
													case 267:
													case 268:
														if (lightingState19.r2 < 0.7f)
														{
															lightingState19.r2 = 0.7f;
															goto IL_4430;
														}
														goto IL_4430;
													case 269:
														goto IL_4430;
													case 270:
													case 271:
														if (lightingState19.r2 < 0.6f)
														{
															lightingState19.r2 = 0.6f;
															goto IL_4430;
														}
														goto IL_4430;
													default:
														goto IL_4430;
													}
												}
												else
												{
													if ((double)lightingState19.r2 < 0.1)
													{
														lightingState19.r2 = 0.1f;
														goto IL_4430;
													}
													goto IL_4430;
												}
											}
											else
											{
												float num95 = (float)Main.rand.Next(28, 42) * 0.005f;
												num95 += (float)(270 - (int)Main.mouseTextColor) / 700f;
												if ((double)lightingState19.r2 < 0.9 + (double)num95)
												{
													lightingState19.r2 = 0.9f + num95;
													goto IL_4430;
												}
												goto IL_4430;
											}
										}
									}
								}
								IL_406F:
								if (tile4.frameX == 0)
								{
									lightingState19.r2 = 1f;
									goto IL_4430;
								}
								goto IL_4430;
								IL_40CA:
								if (lightingState19.r2 < 0.75f)
								{
									lightingState19.r2 = 0.75f;
									goto IL_4430;
								}
								goto IL_4430;
								IL_41E8:
								float num96 = (float)Main.rand.Next(38, 43) * 0.01f;
								if (lightingState19.r2 < num96)
								{
									lightingState19.r2 = num96;
								}
							}
						}
					}
					IL_4430:
					if (tile4.lava() && tile4.liquid > 0)
					{
						if (Lighting.RGB)
						{
							float num97 = (float)(tile4.liquid / 255) * 0.41f + 0.14f;
							num97 = 0.55f;
							num97 += (float)(270 - (int)Main.mouseTextColor) / 900f;
							if (lightingState19.r2 < num97)
							{
								lightingState19.r2 = num97;
							}
							if (lightingState19.g2 < num97)
							{
								lightingState19.g2 = num97 * 0.6f;
							}
							if (lightingState19.b2 < num97)
							{
								lightingState19.b2 = num97 * 0.2f;
							}
						}
						else
						{
							float num98 = (float)(tile4.liquid / 255) * 0.38f + 0.08f;
							num98 += (float)(270 - (int)Main.mouseTextColor) / 2000f;
							if (lightingState19.r2 < num98)
							{
								lightingState19.r2 = num98;
							}
						}
					}
					else
					{
						if (tile4.liquid > 128)
						{
							lightingState19.wetLight = true;
							if (tile4.honey())
							{
								lightingState19.honeyLight = true;
							}
						}
					}
					if (Lighting.RGB)
					{
						if (lightingState19.r2 > 0f || lightingState19.g2 > 0f || lightingState19.b2 > 0f)
						{
							if (Lighting.minX > num46)
							{
								Lighting.minX = num46;
							}
							if (Lighting.maxX < num46 + 1)
							{
								Lighting.maxX = num46 + 1;
							}
							if (Lighting.minY > num47)
							{
								Lighting.minY = num47;
							}
							if (Lighting.maxY < num47 + 1)
							{
								Lighting.maxY = num47 + 1;
							}
						}
					}
					else
					{
						if (lightingState19.r2 > 0f)
						{
							if (Lighting.minX > num46)
							{
								Lighting.minX = num46;
							}
							if (Lighting.maxX < num46 + 1)
							{
								Lighting.maxX = num46 + 1;
							}
							if (Lighting.minY > num47)
							{
								Lighting.minY = num47;
							}
							if (Lighting.maxY < num47 + 1)
							{
								Lighting.maxY = num47 + 1;
							}
						}
					}
				}
			}
			if (Main.holyTiles < 0)
			{
				Main.holyTiles = 0;
			}
			if (Main.evilTiles < 0)
			{
				Main.evilTiles = 0;
			}
			if (Main.bloodTiles < 0)
			{
				Main.bloodTiles = 0;
			}
			int holyTiles = Main.holyTiles;
			Main.holyTiles -= Main.evilTiles;
			Main.holyTiles -= Main.bloodTiles;
			Main.evilTiles -= holyTiles;
			Main.bloodTiles -= holyTiles;
			if (Main.holyTiles < 0)
			{
				Main.holyTiles = 0;
			}
			if (Main.evilTiles < 0)
			{
				Main.evilTiles = 0;
			}
			if (Main.bloodTiles < 0)
			{
				Main.bloodTiles = 0;
			}
			Lighting.minX += Lighting.firstToLightX;
			Lighting.maxX += Lighting.firstToLightX;
			Lighting.minY += Lighting.firstToLightY;
			Lighting.maxY += Lighting.firstToLightY;
			Lighting.minX7 = Lighting.minX;
			Lighting.maxX7 = Lighting.maxX;
			Lighting.minY7 = Lighting.minY;
			Lighting.maxY7 = Lighting.maxY;
			Lighting.firstTileX7 = Lighting.firstTileX;
			Lighting.lastTileX7 = Lighting.lastTileX;
			Lighting.lastTileY7 = Lighting.lastTileY;
			Lighting.firstTileY7 = Lighting.firstTileY;
			Lighting.firstToLightX7 = Lighting.firstToLightX;
			Lighting.lastToLightX7 = Lighting.lastToLightX;
			Lighting.firstToLightY7 = Lighting.firstToLightY;
			Lighting.lastToLightY7 = Lighting.lastToLightY;
			Lighting.firstToLightX27 = num;
			Lighting.lastToLightX27 = num3;
			Lighting.firstToLightY27 = num2;
			Lighting.lastToLightY27 = num4;
			Lighting.scrX = (int)Main.screenPosition.X / 16;
			Lighting.scrY = (int)Main.screenPosition.Y / 16;
			Main.renderCount = 0;
			Main.lightTimer[0] = (float)stopwatch.Elapsed.TotalMilliseconds;
			Lighting.doColors();
		}
		public static void doColors()
		{
			if (Main.renderCount >= 3)
			{
				return;
			}
			Stopwatch stopwatch = new Stopwatch();
			if (Lighting.lightMode < 2)
			{
				Lighting.blueWave += (float)Lighting.blueDir * 0.0001f;
				if (Lighting.blueWave > 1f)
				{
					Lighting.blueWave = 1f;
					Lighting.blueDir = -1;
				}
				else
				{
					if (Lighting.blueWave < 0.97f)
					{
						Lighting.blueWave = 0.97f;
						Lighting.blueDir = 1;
					}
				}
				if (Lighting.RGB)
				{
					Lighting.negLight = 0.91f;
					Lighting.negLight2 = 0.56f;
					Lighting.honeyLightG = 0.7f * Lighting.negLight * Lighting.blueWave;
					Lighting.honeyLightR = 0.75f * Lighting.negLight * Lighting.blueWave;
					Lighting.honeyLightB = 0.6f * Lighting.negLight * Lighting.blueWave;
					switch (Main.waterStyle)
					{
					case 0:
					case 1:
					case 7:
					case 8:
						Lighting.wetLightG = 0.96f * Lighting.negLight * Lighting.blueWave;
						Lighting.wetLightR = 0.88f * Lighting.negLight * Lighting.blueWave;
						Lighting.wetLightB = 1.015f * Lighting.negLight * Lighting.blueWave;
						break;
					case 2:
						Lighting.wetLightG = 0.85f * Lighting.negLight * Lighting.blueWave;
						Lighting.wetLightR = 0.94f * Lighting.negLight * Lighting.blueWave;
						Lighting.wetLightB = 1.01f * Lighting.negLight * Lighting.blueWave;
						break;
					case 3:
						Lighting.wetLightG = 0.95f * Lighting.negLight * Lighting.blueWave;
						Lighting.wetLightR = 0.84f * Lighting.negLight * Lighting.blueWave;
						Lighting.wetLightB = 1.015f * Lighting.negLight * Lighting.blueWave;
						break;
					case 4:
						Lighting.wetLightG = 0.86f * Lighting.negLight * Lighting.blueWave;
						Lighting.wetLightR = 0.9f * Lighting.negLight * Lighting.blueWave;
						Lighting.wetLightB = 1.01f * Lighting.negLight * Lighting.blueWave;
						break;
					case 5:
						Lighting.wetLightG = 0.99f * Lighting.negLight * Lighting.blueWave;
						Lighting.wetLightR = 0.84f * Lighting.negLight * Lighting.blueWave;
						Lighting.wetLightB = 1.01f * Lighting.negLight * Lighting.blueWave;
						break;
					case 6:
						Lighting.wetLightG = 0.98f * Lighting.negLight * Lighting.blueWave;
						Lighting.wetLightR = 0.95f * Lighting.negLight * Lighting.blueWave;
						Lighting.wetLightB = 0.85f * Lighting.negLight * Lighting.blueWave;
						break;
					case 9:
						Lighting.wetLightG = 0.88f * Lighting.negLight * Lighting.blueWave;
						Lighting.wetLightR = 1f * Lighting.negLight * Lighting.blueWave;
						Lighting.wetLightB = 0.84f * Lighting.negLight * Lighting.blueWave;
						break;
					case 10:
						Lighting.wetLightG = 1f * Lighting.negLight * Lighting.blueWave;
						Lighting.wetLightR = 0.83f * Lighting.negLight * Lighting.blueWave;
						Lighting.wetLightB = 1f * Lighting.negLight * Lighting.blueWave;
						break;
					default:
						Lighting.wetLightG = 0f;
						Lighting.wetLightR = 0f;
						Lighting.wetLightB = 0f;
						break;
					}
				}
				else
				{
					Lighting.negLight = 0.9f;
					Lighting.negLight2 = 0.54f;
					Lighting.wetLightR = 0.95f * Lighting.negLight * Lighting.blueWave;
				}
				if (Main.player[Main.myPlayer].nightVision)
				{
					Lighting.negLight *= 1.03f;
					Lighting.negLight2 *= 1.03f;
				}
				if (Main.player[Main.myPlayer].blind)
				{
					Lighting.negLight *= 0.95f;
					Lighting.negLight2 *= 0.95f;
				}
				if (Main.player[Main.myPlayer].blackout)
				{
					Lighting.negLight *= 0.85f;
					Lighting.negLight2 *= 0.85f;
				}
			}
			else
			{
				Lighting.negLight = 0.04f;
				Lighting.negLight2 = 0.16f;
				if (Main.player[Main.myPlayer].nightVision)
				{
					Lighting.negLight -= 0.013f;
					Lighting.negLight2 -= 0.04f;
				}
				if (Main.player[Main.myPlayer].blind)
				{
					Lighting.negLight += 0.03f;
					Lighting.negLight2 += 0.06f;
				}
				if (Main.player[Main.myPlayer].blackout)
				{
					Lighting.negLight += 0.09f;
					Lighting.negLight2 += 0.18f;
				}
				Lighting.wetLightR = Lighting.negLight * 1.2f;
				Lighting.wetLightG = Lighting.negLight * 1.1f;
			}
			int num;
			int num2;
			switch (Main.renderCount)
			{
			case 0:
				num = 0;
				num2 = 1;
				break;
			case 1:
				num = 1;
				num2 = 3;
				break;
			case 2:
				num = 3;
				num2 = 4;
				break;
			default:
				num = 0;
				num2 = 0;
				break;
			}
			if (Lighting.LightingThreads < 0)
			{
				Lighting.LightingThreads = 0;
			}
			if (Lighting.LightingThreads >= Environment.ProcessorCount)
			{
				Lighting.LightingThreads = Environment.ProcessorCount - 1;
			}
			int num3 = Lighting.LightingThreads;
			if (num3 > 0)
			{
				num3++;
			}
			for (int i = num; i < num2; i++)
			{
				stopwatch.Restart();
				switch (i)
				{
				case 0:
					Lighting.swipe.innerLoop1Start = Lighting.minY7 - Lighting.firstToLightY7;
					Lighting.swipe.innerLoop1End = Lighting.lastToLightY27 + Lighting.maxRenderCount - Lighting.firstToLightY7;
					Lighting.swipe.innerLoop2Start = Lighting.maxY7 - Lighting.firstToLightY;
					Lighting.swipe.innerLoop2End = Lighting.firstTileY7 - Lighting.maxRenderCount - Lighting.firstToLightY7;
					Lighting.swipe.outerLoopStart = Lighting.minX7 - Lighting.firstToLightX7;
					Lighting.swipe.outerLoopEnd = Lighting.maxX7 - Lighting.firstToLightX7;
					Lighting.swipe.jaggedArray = Lighting.states;
					break;
				case 1:
					Lighting.swipe.innerLoop1Start = Lighting.minX7 - Lighting.firstToLightX7;
					Lighting.swipe.innerLoop1End = Lighting.lastTileX7 + Lighting.maxRenderCount - Lighting.firstToLightX7;
					Lighting.swipe.innerLoop2Start = Lighting.maxX7 - Lighting.firstToLightX7;
					Lighting.swipe.innerLoop2End = Lighting.firstTileX7 - Lighting.maxRenderCount - Lighting.firstToLightX7;
					Lighting.swipe.outerLoopStart = Lighting.firstToLightY7 - Lighting.firstToLightY7;
					Lighting.swipe.outerLoopEnd = Lighting.lastToLightY7 - Lighting.firstToLightY7;
					Lighting.swipe.jaggedArray = Lighting.axisFlipStates;
					break;
				case 2:
					Lighting.swipe.innerLoop1Start = Lighting.firstToLightY27 - Lighting.firstToLightY7;
					Lighting.swipe.innerLoop1End = Lighting.lastTileY7 + Lighting.maxRenderCount - Lighting.firstToLightY7;
					Lighting.swipe.innerLoop2Start = Lighting.lastToLightY27 - Lighting.firstToLightY;
					Lighting.swipe.innerLoop2End = Lighting.firstTileY7 - Lighting.maxRenderCount - Lighting.firstToLightY7;
					Lighting.swipe.outerLoopStart = Lighting.firstToLightX27 - Lighting.firstToLightX7;
					Lighting.swipe.outerLoopEnd = Lighting.lastToLightX27 - Lighting.firstToLightX7;
					Lighting.swipe.jaggedArray = Lighting.states;
					break;
				case 3:
					Lighting.swipe.innerLoop1Start = Lighting.firstToLightX27 - Lighting.firstToLightX7;
					Lighting.swipe.innerLoop1End = Lighting.lastTileX7 + Lighting.maxRenderCount - Lighting.firstToLightX7;
					Lighting.swipe.innerLoop2Start = Lighting.lastToLightX27 - Lighting.firstToLightX7;
					Lighting.swipe.innerLoop2End = Lighting.firstTileX7 - Lighting.maxRenderCount - Lighting.firstToLightX7;
					Lighting.swipe.outerLoopStart = Lighting.firstToLightY27 - Lighting.firstToLightY7;
					Lighting.swipe.outerLoopEnd = Lighting.lastToLightY27 - Lighting.firstToLightY7;
					Lighting.swipe.jaggedArray = Lighting.axisFlipStates;
					break;
				}
				switch (Lighting.lightMode)
				{
				case 0:
					Lighting.swipe.function = new Action<Lighting.LightingSwipeData>(Lighting.doColors_Mode0_Swipe);
					break;
				case 1:
					Lighting.swipe.function = new Action<Lighting.LightingSwipeData>(Lighting.doColors_Mode1_Swipe);
					break;
				case 2:
					Lighting.swipe.function = new Action<Lighting.LightingSwipeData>(Lighting.doColors_Mode2_Swipe);
					break;
				case 3:
					Lighting.swipe.function = new Action<Lighting.LightingSwipeData>(Lighting.doColors_Mode3_Swipe);
					break;
				default:
					Lighting.swipe.function = null;
					break;
				}
				if (num3 == 0)
				{
					Lighting.swipe.function(Lighting.swipe);
				}
				else
				{
					int num4 = Lighting.swipe.outerLoopEnd - Lighting.swipe.outerLoopStart;
					int num5 = num4 / num3;
					int num6 = num4 % num3;
					int num7 = Lighting.swipe.outerLoopStart;
					Lighting.countdown.Reset(num3);
					for (int j = 0; j < num3; j++)
					{
						Lighting.LightingSwipeData lightingSwipeData = Lighting.threadSwipes[j];
						lightingSwipeData.CopyFrom(Lighting.swipe);
						lightingSwipeData.outerLoopStart = num7;
						num7 += num5;
						if (num6 > 0)
						{
							num7++;
							num6--;
						}
						lightingSwipeData.outerLoopEnd = num7;
						ThreadPool.QueueUserWorkItem(new WaitCallback(Lighting.callback_LightingSwipe), lightingSwipeData);
					}
					Lighting.countdown.Wait();
				}
				Main.lightTimer[i + 1] = (float)stopwatch.Elapsed.TotalMilliseconds;
				if (i == 3)
				{
					float num8 = 0f;
					for (int k = 0; k < Main.lightTimer.Length; k++)
					{
						num8 += Main.lightTimer[k];
					}
				}
			}
		}
		private static void callback_LightingSwipe(object obj)
		{
			Lighting.LightingSwipeData lightingSwipeData = obj as Lighting.LightingSwipeData;
			try
			{
				lightingSwipeData.function(lightingSwipeData);
			}
			catch
			{
			}
			Lighting.countdown.Signal();
		}
		private static void doColors_Mode0_Swipe(Lighting.LightingSwipeData swipeData)
		{
			try
			{
				bool flag = true;
				while (true)
				{
					int num;
					int num2;
					int num3;
					if (flag)
					{
						num = 1;
						num2 = swipeData.innerLoop1Start;
						num3 = swipeData.innerLoop1End;
					}
					else
					{
						num = -1;
						num2 = swipeData.innerLoop2Start;
						num3 = swipeData.innerLoop2End;
					}
					int outerLoopStart = swipeData.outerLoopStart;
					int outerLoopEnd = swipeData.outerLoopEnd;
					for (int i = outerLoopStart; i < outerLoopEnd; i++)
					{
						Lighting.LightingState[] array = swipeData.jaggedArray[i];
						float num4 = 0f;
						float num5 = 0f;
						float num6 = 0f;
						if (num2 * num < num3 * num)
						{
							int num7 = num2;
							while (num7 != num3)
							{
								Lighting.LightingState lightingState = array[num7];
								Lighting.LightingState lightingState2 = array[num7 + num];
								bool flag3;
								bool flag2 = flag3 = false;
								if (lightingState.r2 > num4)
								{
									num4 = lightingState.r2;
								}
								else
								{
									if ((double)num4 <= 0.0185)
									{
										flag3 = true;
									}
									else
									{
										if (lightingState.r2 < num4)
										{
											lightingState.r2 = num4;
										}
									}
								}
								if (!flag3 && lightingState2.r2 <= num4)
								{
									if (lightingState.stopLight)
									{
										num4 *= Lighting.negLight2;
									}
									else
									{
										if (lightingState.wetLight)
										{
											if (lightingState.honeyLight)
											{
												num4 *= Lighting.honeyLightR * (float)swipeData.rand.Next(98, 100) * 0.01f;
											}
											else
											{
												num4 *= Lighting.wetLightR * (float)swipeData.rand.Next(98, 100) * 0.01f;
											}
										}
										else
										{
											num4 *= Lighting.negLight;
										}
									}
								}
								if (lightingState.g2 > num5)
								{
									num5 = lightingState.g2;
								}
								else
								{
									if ((double)num5 <= 0.0185)
									{
										flag2 = true;
									}
									else
									{
										lightingState.g2 = num5;
									}
								}
								if (!flag2 && lightingState2.g2 <= num5)
								{
									if (lightingState.stopLight)
									{
										num5 *= Lighting.negLight2;
									}
									else
									{
										if (lightingState.wetLight)
										{
											if (lightingState.honeyLight)
											{
												num5 *= Lighting.honeyLightG * (float)swipeData.rand.Next(97, 100) * 0.01f;
											}
											else
											{
												num5 *= Lighting.wetLightG * (float)swipeData.rand.Next(97, 100) * 0.01f;
											}
										}
										else
										{
											num5 *= Lighting.negLight;
										}
									}
								}
								if (lightingState.b2 > num6)
								{
									num6 = lightingState.b2;
									goto IL_23A;
								}
								if ((double)num6 > 0.0185)
								{
									lightingState.b2 = num6;
									goto IL_23A;
								}
								IL_2BC:
								num7 += num;
								continue;
								IL_23A:
								if (lightingState2.b2 >= num6)
								{
									goto IL_2BC;
								}
								if (lightingState.stopLight)
								{
									num6 *= Lighting.negLight2;
									goto IL_2BC;
								}
								if (!lightingState.wetLight)
								{
									num6 *= Lighting.negLight;
									goto IL_2BC;
								}
								if (lightingState.honeyLight)
								{
									num6 *= Lighting.honeyLightB * (float)swipeData.rand.Next(97, 100) * 0.01f;
									goto IL_2BC;
								}
								num6 *= Lighting.wetLightB * (float)swipeData.rand.Next(97, 100) * 0.01f;
								goto IL_2BC;
							}
						}
					}
					if (!flag)
					{
						break;
					}
					flag = false;
				}
			}
			catch
			{
			}
		}
		private static void doColors_Mode1_Swipe(Lighting.LightingSwipeData swipeData)
		{
			try
			{
				bool flag = true;
				while (true)
				{
					int num;
					int num2;
					int num3;
					if (flag)
					{
						num = 1;
						num2 = swipeData.innerLoop1Start;
						num3 = swipeData.innerLoop1End;
					}
					else
					{
						num = -1;
						num2 = swipeData.innerLoop2Start;
						num3 = swipeData.innerLoop2End;
					}
					int outerLoopStart = swipeData.outerLoopStart;
					int outerLoopEnd = swipeData.outerLoopEnd;
					for (int i = outerLoopStart; i < outerLoopEnd; i++)
					{
						Lighting.LightingState[] array = swipeData.jaggedArray[i];
						float num4 = 0f;
						int num5 = num2;
						while (num5 != num3)
						{
							Lighting.LightingState lightingState = array[num5];
							if (lightingState.r2 > num4)
							{
								num4 = lightingState.r2;
								goto IL_9C;
							}
							if ((double)num4 > 0.0185)
							{
								if (lightingState.r2 < num4)
								{
									lightingState.r2 = num4;
									goto IL_9C;
								}
								goto IL_9C;
							}
							IL_123:
							num5 += num;
							continue;
							IL_9C:
							if (array[num5 + num].r2 > num4)
							{
								goto IL_123;
							}
							if (lightingState.stopLight)
							{
								num4 *= Lighting.negLight2;
								goto IL_123;
							}
							if (!lightingState.wetLight)
							{
								num4 *= Lighting.negLight;
								goto IL_123;
							}
							if (lightingState.honeyLight)
							{
								num4 *= Lighting.honeyLightR * (float)swipeData.rand.Next(98, 100) * 0.01f;
								goto IL_123;
							}
							num4 *= Lighting.wetLightR * (float)swipeData.rand.Next(98, 100) * 0.01f;
							goto IL_123;
						}
					}
					if (!flag)
					{
						break;
					}
					flag = false;
				}
			}
			catch
			{
			}
		}
		private static void doColors_Mode2_Swipe(Lighting.LightingSwipeData swipeData)
		{
			try
			{
				bool flag = true;
				while (true)
				{
					int num;
					int num2;
					int num3;
					if (flag)
					{
						num = 1;
						num2 = swipeData.innerLoop1Start;
						num3 = swipeData.innerLoop1End;
					}
					else
					{
						num = -1;
						num2 = swipeData.innerLoop2Start;
						num3 = swipeData.innerLoop2End;
					}
					int outerLoopStart = swipeData.outerLoopStart;
					int outerLoopEnd = swipeData.outerLoopEnd;
					for (int i = outerLoopStart; i < outerLoopEnd; i++)
					{
						Lighting.LightingState[] array = swipeData.jaggedArray[i];
						float num4 = 0f;
						int num5 = num2;
						while (num5 != num3)
						{
							Lighting.LightingState lightingState = array[num5];
							if (lightingState.r2 > num4)
							{
								num4 = lightingState.r2;
								goto IL_86;
							}
							if (num4 > 0f)
							{
								lightingState.r2 = num4;
								goto IL_86;
							}
							IL_BA:
							num5 += num;
							continue;
							IL_86:
							if (lightingState.stopLight)
							{
								num4 -= Lighting.negLight2;
								goto IL_BA;
							}
							if (lightingState.wetLight)
							{
								num4 -= Lighting.wetLightR;
								goto IL_BA;
							}
							num4 -= Lighting.negLight;
							goto IL_BA;
						}
					}
					if (!flag)
					{
						break;
					}
					flag = false;
				}
			}
			catch
			{
			}
		}
		private static void doColors_Mode3_Swipe(Lighting.LightingSwipeData swipeData)
		{
			try
			{
				bool flag = true;
				while (true)
				{
					int num;
					int num2;
					int num3;
					if (flag)
					{
						num = 1;
						num2 = swipeData.innerLoop1Start;
						num3 = swipeData.innerLoop1End;
					}
					else
					{
						num = -1;
						num2 = swipeData.innerLoop2Start;
						num3 = swipeData.innerLoop2End;
					}
					int outerLoopStart = swipeData.outerLoopStart;
					int outerLoopEnd = swipeData.outerLoopEnd;
					for (int i = outerLoopStart; i < outerLoopEnd; i++)
					{
						Lighting.LightingState[] array = swipeData.jaggedArray[i];
						float num4 = 0f;
						float num5 = 0f;
						float num6 = 0f;
						int num7 = num2;
						while (num7 != num3)
						{
							Lighting.LightingState lightingState = array[num7];
							bool flag3;
							bool flag2 = flag3 = false;
							if (lightingState.r2 > num4)
							{
								num4 = lightingState.r2;
							}
							else
							{
								if (num4 <= 0f)
								{
									flag3 = true;
								}
								else
								{
									lightingState.r2 = num4;
								}
							}
							if (!flag3)
							{
								if (lightingState.stopLight)
								{
									num4 -= Lighting.negLight2;
								}
								else
								{
									if (lightingState.wetLight)
									{
										num4 -= Lighting.wetLightR;
									}
									else
									{
										num4 -= Lighting.negLight;
									}
								}
							}
							if (lightingState.g2 > num5)
							{
								num5 = lightingState.g2;
							}
							else
							{
								if (num5 <= 0f)
								{
									flag2 = true;
								}
								else
								{
									lightingState.g2 = num5;
								}
							}
							if (!flag2)
							{
								if (lightingState.stopLight)
								{
									num5 -= Lighting.negLight2;
								}
								else
								{
									if (lightingState.wetLight)
									{
										num5 -= Lighting.wetLightG;
									}
									else
									{
										num5 -= Lighting.negLight;
									}
								}
							}
							if (lightingState.b2 > num6)
							{
								num6 = lightingState.b2;
								goto IL_167;
							}
							if (num6 > 0f)
							{
								lightingState.b2 = num6;
								goto IL_167;
							}
							IL_186:
							num7 += num;
							continue;
							IL_167:
							if (lightingState.stopLight)
							{
								num6 -= Lighting.negLight2;
								goto IL_186;
							}
							num6 -= Lighting.negLight;
							goto IL_186;
						}
					}
					if (!flag)
					{
						break;
					}
					flag = false;
				}
			}
			catch
			{
			}
		}
		public static void addLight(int i, int j, float Lightness)
		{
			if (Main.netMode == 2)
			{
				return;
			}
			if (i - Lighting.firstTileX + Lighting.offScreenTiles >= 0 && i - Lighting.firstTileX + Lighting.offScreenTiles < Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10 && j - Lighting.firstTileY + Lighting.offScreenTiles >= 0 && j - Lighting.firstTileY + Lighting.offScreenTiles < Main.screenHeight / 16 + Lighting.offScreenTiles * 2 + 10)
			{
				if (Lighting.tempLightCount == Lighting.maxTempLights)
				{
					return;
				}
				if (!Lighting.RGB)
				{
					for (int k = 0; k < Lighting.tempLightCount; k++)
					{
						if (Lighting.tempLightX[k] == i && Lighting.tempLightY[k] == j && Lightness <= Lighting.tempLight[k])
						{
							return;
						}
					}
					Lighting.tempLightX[Lighting.tempLightCount] = i;
					Lighting.tempLightY[Lighting.tempLightCount] = j;
					Lighting.tempLight[Lighting.tempLightCount] = Lightness;
					Lighting.tempLightG[Lighting.tempLightCount] = Lightness;
					Lighting.tempLightB[Lighting.tempLightCount] = Lightness;
					Lighting.tempLightCount++;
					return;
				}
				Lighting.tempLight[Lighting.tempLightCount] = Lightness;
				Lighting.tempLightG[Lighting.tempLightCount] = Lightness;
				Lighting.tempLightB[Lighting.tempLightCount] = Lightness;
				Lighting.tempLightX[Lighting.tempLightCount] = i;
				Lighting.tempLightY[Lighting.tempLightCount] = j;
				Lighting.tempLightCount++;
			}
		}
		public static void addLight(int i, int j, float R, float G, float B)
		{
			if (Main.netMode == 2)
			{
				return;
			}
			if (!Lighting.RGB)
			{
				Lighting.addLight(i, j, (R + G + B) / 3f);
				return;
			}
			if (i - Lighting.firstTileX + Lighting.offScreenTiles >= 0 && i - Lighting.firstTileX + Lighting.offScreenTiles < Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10 && j - Lighting.firstTileY + Lighting.offScreenTiles >= 0 && j - Lighting.firstTileY + Lighting.offScreenTiles < Main.screenHeight / 16 + Lighting.offScreenTiles * 2 + 10)
			{
				if (Lighting.tempLightCount == Lighting.maxTempLights)
				{
					return;
				}
				for (int k = 0; k < Lighting.tempLightCount; k++)
				{
					if (Lighting.tempLightX[k] == i && Lighting.tempLightY[k] == j)
					{
						if (Lighting.tempLight[k] < R)
						{
							Lighting.tempLight[k] = R;
						}
						if (Lighting.tempLightG[k] < G)
						{
							Lighting.tempLightG[k] = G;
						}
						if (Lighting.tempLightB[k] < B)
						{
							Lighting.tempLightB[k] = B;
						}
						return;
					}
				}
				Lighting.tempLight[Lighting.tempLightCount] = R;
				Lighting.tempLightG[Lighting.tempLightCount] = G;
				Lighting.tempLightB[Lighting.tempLightCount] = B;
				Lighting.tempLightX[Lighting.tempLightCount] = i;
				Lighting.tempLightY[Lighting.tempLightCount] = j;
				Lighting.tempLightCount++;
			}
		}
		public static void BlackOut()
		{
			int num = Main.screenWidth / 16 + Lighting.offScreenTiles * 2;
			int num2 = Main.screenHeight / 16 + Lighting.offScreenTiles * 2;
			for (int i = 0; i < num; i++)
			{
				Lighting.LightingState[] array = Lighting.states[i];
				for (int j = 0; j < num2; j++)
				{
					Lighting.LightingState lightingState = array[j];
					lightingState.r = 0f;
					lightingState.g = 0f;
					lightingState.b = 0f;
				}
			}
		}
		private static void ResetRange()
		{
			Lighting.minX = Main.screenWidth + Lighting.offScreenTiles * 2 + 10;
			Lighting.maxX = 0;
			Lighting.minY = Main.screenHeight + Lighting.offScreenTiles * 2 + 10;
			Lighting.maxY = 0;
		}
		public static int LightingX(int lightX)
		{
			if (lightX < 0)
			{
				return 0;
			}
			if (lightX >= Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10)
			{
				return Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10 - 1;
			}
			return lightX;
		}
		public static int LightingY(int lightY)
		{
			if (lightY < 0)
			{
				return 0;
			}
			if (lightY >= Main.screenHeight / 16 + Lighting.offScreenTiles * 2 + 10)
			{
				return Main.screenHeight / 16 + Lighting.offScreenTiles * 2 + 10 - 1;
			}
			return lightY;
		}
		public static Color GetColor(int x, int y, Color oldColor)
		{
			int num = x - Lighting.firstTileX + Lighting.offScreenTiles;
			int num2 = y - Lighting.firstTileY + Lighting.offScreenTiles;
			if (Main.gameMenu)
			{
				return oldColor;
			}
			if (num < 0 || num2 < 0 || num >= Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10 || num2 >= Main.screenHeight / 16 + Lighting.offScreenTiles * 2 + 10)
			{
				return Color.Black;
			}
			Color white = Color.White;
			Lighting.LightingState lightingState = Lighting.states[num][num2];
			int num3 = (int)((float)oldColor.R * lightingState.r * Lighting.brightness);
			int num4 = (int)((float)oldColor.G * lightingState.g * Lighting.brightness);
			int num5 = (int)((float)oldColor.B * lightingState.b * Lighting.brightness);
			if (num3 > 255)
			{
				num3 = 255;
			}
			if (num4 > 255)
			{
				num4 = 255;
			}
			if (num5 > 255)
			{
				num5 = 255;
			}
			white.R = (byte)num3;
			white.G = (byte)num4;
			white.B = (byte)num5;
			return white;
		}
		public static Color GetColor(int x, int y)
		{
			int num = x - Lighting.firstTileX + Lighting.offScreenTiles;
			int num2 = y - Lighting.firstTileY + Lighting.offScreenTiles;
			if (num < 0 || num2 < 0 || num >= Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10 || num2 >= Main.screenHeight / 16 + Lighting.offScreenTiles * 2)
			{
				return Color.Black;
			}
			Lighting.LightingState lightingState = Lighting.states[num][num2];
			int num3 = (int)(255f * lightingState.r * Lighting.brightness);
			int num4 = (int)(255f * lightingState.g * Lighting.brightness);
			int num5 = (int)(255f * lightingState.b * Lighting.brightness);
			if (num3 > 255)
			{
				num3 = 255;
			}
			if (num4 > 255)
			{
				num4 = 255;
			}
			if (num5 > 255)
			{
				num5 = 255;
			}
			Color result = new Color((int)((byte)num3), (int)((byte)num4), (int)((byte)num5), 255);
			return result;
		}
		public static void GetColor9Slice(int centerX, int centerY, ref Color[] slices)
		{
			int num = centerX - Lighting.firstTileX + Lighting.offScreenTiles;
			int num2 = centerY - Lighting.firstTileY + Lighting.offScreenTiles;
			if (num <= 0 || num2 <= 0 || num >= Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10 - 1 || num2 >= Main.screenHeight / 16 + Lighting.offScreenTiles * 2 - 1)
			{
				for (int i = 0; i < 9; i++)
				{
					slices[i] = Color.Black;
				}
				return;
			}
			int num3 = 0;
			for (int j = num - 1; j <= num + 1; j++)
			{
				Lighting.LightingState[] array = Lighting.states[j];
				for (int k = num2 - 1; k <= num2 + 1; k++)
				{
					Lighting.LightingState lightingState = array[k];
					int num4 = (int)(255f * lightingState.r * Lighting.brightness);
					int num5 = (int)(255f * lightingState.g * Lighting.brightness);
					int num6 = (int)(255f * lightingState.b * Lighting.brightness);
					if (num4 > 255)
					{
						num4 = 255;
					}
					if (num5 > 255)
					{
						num5 = 255;
					}
					if (num6 > 255)
					{
						num6 = 255;
					}
					slices[num3] = new Color((int)((byte)num4), (int)((byte)num5), (int)((byte)num6), 255);
					num3 += 3;
				}
				num3 -= 8;
			}
		}
		public static void GetColor4Slice(int centerX, int centerY, ref Color[] slices)
		{
			int i = centerX - Lighting.firstTileX + Lighting.offScreenTiles;
			int num = centerY - Lighting.firstTileY + Lighting.offScreenTiles;
			if (i <= 0 || num <= 0 || i >= Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10 - 1 || num >= Main.screenHeight / 16 + Lighting.offScreenTiles * 2 - 1)
			{
				for (i = 0; i < 4; i++)
				{
					slices[i] = Color.Black;
				}
			}
			Lighting.LightingState lightingState = Lighting.states[i][num - 1];
			Lighting.LightingState lightingState2 = Lighting.states[i][num + 1];
			Lighting.LightingState lightingState3 = Lighting.states[i - 1][num];
			Lighting.LightingState lightingState4 = Lighting.states[i + 1][num];
			float num2 = lightingState.r + lightingState.g + lightingState.b;
			float num3 = lightingState2.r + lightingState2.g + lightingState2.b;
			float num4 = lightingState4.r + lightingState4.g + lightingState4.b;
			float num5 = lightingState3.r + lightingState3.g + lightingState3.b;
			if (num2 >= num5)
			{
				int num6 = (int)(255f * lightingState3.r * Lighting.brightness);
				int num7 = (int)(255f * lightingState3.g * Lighting.brightness);
				int num8 = (int)(255f * lightingState3.b * Lighting.brightness);
				if (num6 > 255)
				{
					num6 = 255;
				}
				if (num7 > 255)
				{
					num7 = 255;
				}
				if (num8 > 255)
				{
					num8 = 255;
				}
				slices[0] = new Color((int)((byte)num6), (int)((byte)num7), (int)((byte)num8), 255);
			}
			else
			{
				int num9 = (int)(255f * lightingState.r * Lighting.brightness);
				int num10 = (int)(255f * lightingState.g * Lighting.brightness);
				int num11 = (int)(255f * lightingState.b * Lighting.brightness);
				if (num9 > 255)
				{
					num9 = 255;
				}
				if (num10 > 255)
				{
					num10 = 255;
				}
				if (num11 > 255)
				{
					num11 = 255;
				}
				slices[0] = new Color((int)((byte)num9), (int)((byte)num10), (int)((byte)num11), 255);
			}
			if (num2 >= num4)
			{
				int num12 = (int)(255f * lightingState4.r * Lighting.brightness);
				int num13 = (int)(255f * lightingState4.g * Lighting.brightness);
				int num14 = (int)(255f * lightingState4.b * Lighting.brightness);
				if (num12 > 255)
				{
					num12 = 255;
				}
				if (num13 > 255)
				{
					num13 = 255;
				}
				if (num14 > 255)
				{
					num14 = 255;
				}
				slices[1] = new Color((int)((byte)num12), (int)((byte)num13), (int)((byte)num14), 255);
			}
			else
			{
				int num15 = (int)(255f * lightingState.r * Lighting.brightness);
				int num16 = (int)(255f * lightingState.g * Lighting.brightness);
				int num17 = (int)(255f * lightingState.b * Lighting.brightness);
				if (num15 > 255)
				{
					num15 = 255;
				}
				if (num16 > 255)
				{
					num16 = 255;
				}
				if (num17 > 255)
				{
					num17 = 255;
				}
				slices[1] = new Color((int)((byte)num15), (int)((byte)num16), (int)((byte)num17), 255);
			}
			if (num3 >= num5)
			{
				int num18 = (int)(255f * lightingState3.r * Lighting.brightness);
				int num19 = (int)(255f * lightingState3.g * Lighting.brightness);
				int num20 = (int)(255f * lightingState3.b * Lighting.brightness);
				if (num18 > 255)
				{
					num18 = 255;
				}
				if (num19 > 255)
				{
					num19 = 255;
				}
				if (num20 > 255)
				{
					num20 = 255;
				}
				slices[2] = new Color((int)((byte)num18), (int)((byte)num19), (int)((byte)num20), 255);
			}
			else
			{
				int num21 = (int)(255f * lightingState2.r * Lighting.brightness);
				int num22 = (int)(255f * lightingState2.g * Lighting.brightness);
				int num23 = (int)(255f * lightingState2.b * Lighting.brightness);
				if (num21 > 255)
				{
					num21 = 255;
				}
				if (num22 > 255)
				{
					num22 = 255;
				}
				if (num23 > 255)
				{
					num23 = 255;
				}
				slices[2] = new Color((int)((byte)num21), (int)((byte)num22), (int)((byte)num23), 255);
			}
			if (num3 >= num4)
			{
				int num24 = (int)(255f * lightingState4.r * Lighting.brightness);
				int num25 = (int)(255f * lightingState4.g * Lighting.brightness);
				int num26 = (int)(255f * lightingState4.b * Lighting.brightness);
				if (num24 > 255)
				{
					num24 = 255;
				}
				if (num25 > 255)
				{
					num25 = 255;
				}
				if (num26 > 255)
				{
					num26 = 255;
				}
				slices[3] = new Color((int)((byte)num24), (int)((byte)num25), (int)((byte)num26), 255);
				return;
			}
			int num27 = (int)(255f * lightingState2.r * Lighting.brightness);
			int num28 = (int)(255f * lightingState2.g * Lighting.brightness);
			int num29 = (int)(255f * lightingState2.b * Lighting.brightness);
			if (num27 > 255)
			{
				num27 = 255;
			}
			if (num28 > 255)
			{
				num28 = 255;
			}
			if (num29 > 255)
			{
				num29 = 255;
			}
			slices[3] = new Color((int)((byte)num27), (int)((byte)num28), (int)((byte)num29), 255);
		}
		public static Color GetBlackness(int x, int y)
		{
			int num = x - Lighting.firstTileX + Lighting.offScreenTiles;
			int num2 = y - Lighting.firstTileY + Lighting.offScreenTiles;
			if (num < 0 || num2 < 0 || num >= Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10 || num2 >= Main.screenHeight / 16 + Lighting.offScreenTiles * 2 + 10)
			{
				return Color.Black;
			}
			Color result = new Color(0, 0, 0, (int)((byte)(255f - 255f * Lighting.states[num][num2].r)));
			return result;
		}
		public static float Brightness(int x, int y)
		{
			int num = x - Lighting.firstTileX + Lighting.offScreenTiles;
			int num2 = y - Lighting.firstTileY + Lighting.offScreenTiles;
			if (num < 0 || num2 < 0 || num >= Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10 || num2 >= Main.screenHeight / 16 + Lighting.offScreenTiles * 2 + 10)
			{
				return 0f;
			}
			Lighting.LightingState lightingState = Lighting.states[num][num2];
			return (lightingState.r + lightingState.g + lightingState.b) / 3f;
		}
		public static bool Brighter(int x, int y, int x2, int y2)
		{
			bool result;
			try
			{
				Lighting.LightingState lightingState = Lighting.states[x - Lighting.firstTileX + Lighting.offScreenTiles][y - Lighting.firstTileY + Lighting.offScreenTiles];
				Lighting.LightingState lightingState2 = Lighting.states[x2 - Lighting.firstTileX + Lighting.offScreenTiles][y2 - Lighting.firstTileY + Lighting.offScreenTiles];
				if (lightingState.r + lightingState.g + lightingState.b >= lightingState2.r + lightingState2.g + lightingState2.b)
				{
					result = true;
				}
				else
				{
					result = false;
				}
			}
			catch
			{
				result = false;
			}
			return result;
		}
	}
}
