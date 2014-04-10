using Microsoft.Xna.Framework;
using System;
namespace Terraria
{
	public class Dust
	{
		public static float dCount;
		public Vector2 position;
		public Vector2 velocity;
		public static int lavaBubbles;
		public float fadeIn;
		public bool noGravity;
		public float scale;
		public float rotation;
		public bool noLight;
		public bool active;
		public int type;
		public Color color;
		public int alpha;
		public Rectangle frame;
		public static int NewDust(Vector2 Position, int Width, int Height, int Type, float SpeedX = 0f, float SpeedY = 0f, int Alpha = 0, Color newColor = default(Color), float Scale = 1f)
		{
			if (Main.gameMenu)
			{
				return 6000;
			}
			if (Main.rand == null)
			{
				Main.rand = new Random((int)DateTime.Now.Ticks);
			}
			if (Main.gamePaused)
			{
				return 6000;
			}
			if (WorldGen.gen)
			{
				return 6000;
			}
			if (Main.netMode == 2)
			{
				return 6000;
			}
			int num = (int)(400f * (1f - Dust.dCount));
			Rectangle rectangle = new Rectangle((int)(Main.screenPosition.X - (float)num), (int)(Main.screenPosition.Y - (float)num), Main.screenWidth + num * 2, Main.screenHeight + num * 2);
			Rectangle value = new Rectangle((int)Position.X, (int)Position.Y, 10, 10);
			if (!rectangle.Intersects(value))
			{
				return 6000;
			}
			int result = 6000;
			int i = 0;
			while (i < 6000)
			{
				if (!Main.dust[i].active)
				{
					if ((double)i > (double)Main.numDust * 0.9)
					{
						if (Main.rand.Next(4) != 0)
						{
							return 5999;
						}
					}
					else
					{
						if ((double)i > (double)Main.numDust * 0.8)
						{
							if (Main.rand.Next(3) != 0)
							{
								return 5999;
							}
						}
						else
						{
							if ((double)i > (double)Main.numDust * 0.7)
							{
								if (Main.rand.Next(2) == 0)
								{
									return 5999;
								}
							}
							else
							{
								if ((double)i > (double)Main.numDust * 0.6)
								{
									if (Main.rand.Next(4) == 0)
									{
										return 5999;
									}
								}
								else
								{
									if ((double)i > (double)Main.numDust * 0.5)
									{
										if (Main.rand.Next(5) == 0)
										{
											return 5999;
										}
									}
									else
									{
										Dust.dCount = 0f;
									}
								}
							}
						}
					}
					int num2 = Width;
					int num3 = Height;
					if (num2 < 5)
					{
						num2 = 5;
					}
					if (num3 < 5)
					{
						num3 = 5;
					}
					result = i;
					Main.dust[i].fadeIn = 0f;
					Main.dust[i].active = true;
					Main.dust[i].type = Type;
					Main.dust[i].noGravity = false;
					Main.dust[i].color = newColor;
					Main.dust[i].alpha = Alpha;
					Main.dust[i].position.X = Position.X + (float)Main.rand.Next(num2 - 4) + 4f;
					Main.dust[i].position.Y = Position.Y + (float)Main.rand.Next(num3 - 4) + 4f;
					Main.dust[i].velocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + SpeedX;
					Main.dust[i].velocity.Y = (float)Main.rand.Next(-20, 21) * 0.1f + SpeedY;
					Main.dust[i].frame.X = 10 * Type;
					Main.dust[i].frame.Y = 10 * Main.rand.Next(3);
					int j = Type;
					while (j >= 100)
					{
						j -= 100;
						Dust expr_334_cp_0 = Main.dust[i];
						expr_334_cp_0.frame.X = expr_334_cp_0.frame.X - 1000;
						Dust expr_352_cp_0 = Main.dust[i];
						expr_352_cp_0.frame.Y = expr_352_cp_0.frame.Y + 30;
					}
					Main.dust[i].frame.Width = 8;
					Main.dust[i].frame.Height = 8;
					Main.dust[i].rotation = 0f;
					Main.dust[i].scale = 1f + (float)Main.rand.Next(-20, 21) * 0.01f;
					Main.dust[i].scale *= Scale;
					Main.dust[i].noLight = false;
					if (Main.dust[i].type == 135 || Main.dust[i].type == 6 || Main.dust[i].type == 75 || Main.dust[i].type == 169 || Main.dust[i].type == 29 || (Main.dust[i].type >= 59 && Main.dust[i].type <= 65) || Main.dust[i].type == 158)
					{
						Main.dust[i].velocity.Y = (float)Main.rand.Next(-10, 6) * 0.1f;
						Dust expr_4AD_cp_0 = Main.dust[i];
						expr_4AD_cp_0.velocity.X = expr_4AD_cp_0.velocity.X * 0.3f;
						Main.dust[i].scale *= 0.7f;
					}
					if (Main.dust[i].type == 127 || Main.dust[i].type == 187)
					{
						Main.dust[i].velocity *= 0.3f;
						Main.dust[i].scale *= 0.7f;
					}
					if (Main.dust[i].type == 33 || Main.dust[i].type == 52 || Main.dust[i].type == 98 || Main.dust[i].type == 99 || Main.dust[i].type == 100 || Main.dust[i].type == 101 || Main.dust[i].type == 102 || Main.dust[i].type == 103 || Main.dust[i].type == 104 || Main.dust[i].type == 105)
					{
						Main.dust[i].alpha = 170;
						Main.dust[i].velocity *= 0.5f;
						Dust expr_61E_cp_0 = Main.dust[i];
						expr_61E_cp_0.velocity.Y = expr_61E_cp_0.velocity.Y + 1f;
					}
					if (Main.dust[i].type == 41)
					{
						Main.dust[i].velocity *= 0f;
					}
					if (Main.dust[i].type == 80)
					{
						Main.dust[i].alpha = 50;
					}
					if (Main.dust[i].type != 34 && Main.dust[i].type != 35 && Main.dust[i].type != 152)
					{
						break;
					}
					Main.dust[i].velocity *= 0.1f;
					Main.dust[i].velocity.Y = -0.5f;
					if (Main.dust[i].type == 34 && !Collision.WetCollision(new Vector2(Main.dust[i].position.X, Main.dust[i].position.Y - 8f), 4, 4))
					{
						Main.dust[i].active = false;
						break;
					}
					break;
				}
				else
				{
					i++;
				}
			}
			return result;
		}
		public static int dustWater()
		{
			if (Main.waterStyle == 2)
			{
				return 98;
			}
			if (Main.waterStyle == 3)
			{
				return 99;
			}
			if (Main.waterStyle == 4)
			{
				return 100;
			}
			if (Main.waterStyle == 5)
			{
				return 101;
			}
			if (Main.waterStyle == 6)
			{
				return 102;
			}
			if (Main.waterStyle == 7)
			{
				return 103;
			}
			if (Main.waterStyle == 8)
			{
				return 104;
			}
			if (Main.waterStyle == 9)
			{
				return 105;
			}
			if (Main.waterStyle == 10)
			{
				return 123;
			}
			return 33;
		}
		public static void UpdateDust()
		{
			int num = 0;
			Dust.lavaBubbles = 0;
			Main.snowDust = 0;
			for (int i = 0; i < 6000; i++)
			{
				if (i < Main.numDust)
				{
					if (Main.dust[i].active)
					{
						Dust.dCount += 1f;
						if (Main.dust[i].scale > 10f)
						{
							Main.dust[i].active = false;
						}
						if (Main.dust[i].type == 35)
						{
							Dust.lavaBubbles++;
						}
						Main.dust[i].position += Main.dust[i].velocity;
						if (Main.dust[i].type >= 86 && Main.dust[i].type <= 92 && !Main.dust[i].noLight)
						{
							float num2 = Main.dust[i].scale * 0.6f;
							int num3 = Main.dust[i].type - 85;
							float num4 = num2;
							float num5 = num2;
							float num6 = num2;
							if (num3 == 3)
							{
								num4 *= 0f;
								num5 *= 0.1f;
								num6 *= 1.3f;
							}
							else
							{
								if (num3 == 5)
								{
									num4 *= 1f;
									num5 *= 0.1f;
									num6 *= 0.1f;
								}
								else
								{
									if (num3 == 4)
									{
										num4 *= 0f;
										num5 *= 1f;
										num6 *= 0.1f;
									}
									else
									{
										if (num3 == 1)
										{
											num4 *= 0.9f;
											num5 *= 0f;
											num6 *= 0.9f;
										}
										else
										{
											if (num3 == 6)
											{
												num4 *= 1.3f;
												num5 *= 1.3f;
												num6 *= 1.3f;
											}
											else
											{
												if (num3 == 2)
												{
													num4 *= 0.9f;
													num5 *= 0.9f;
													num6 *= 0f;
												}
											}
										}
									}
								}
							}
							Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num2 * num4, num2 * num5, num2 * num6);
						}
						if (Main.dust[i].type == 154)
						{
							Main.dust[i].rotation += Main.dust[i].velocity.X * 0.3f;
							Main.dust[i].scale -= 0.03f;
						}
						if (Main.dust[i].type == 172)
						{
							float num7 = Main.dust[i].scale * 0.5f;
							if (num7 > 1f)
							{
								num7 = 1f;
							}
							float num8 = num7;
							float num9 = num7;
							float num10 = num7;
							num8 *= 0f;
							num9 *= 0.25f;
							num10 *= 1f;
							Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num7 * num8, num7 * num9, num7 * num10);
						}
						if (Main.dust[i].type == 182)
						{
							Main.dust[i].rotation += 1f;
							float num11 = Main.dust[i].scale * 0.25f;
							if (num11 > 1f)
							{
								num11 = 1f;
							}
							float num12 = num11;
							float num13 = num11;
							float num14 = num11;
							num12 *= 1f;
							num13 *= 0.2f;
							num14 *= 0.1f;
							Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num11 * num12, num11 * num13, num11 * num14);
						}
						if (Main.dust[i].type == 211 && Main.dust[i].noLight && Collision.SolidCollision(Main.dust[i].position, 4, 4))
						{
							Main.dust[i].active = false;
						}
						if (Main.dust[i].type == 157)
						{
							float num15 = Main.dust[i].scale * 0.2f;
							float num16 = num15;
							float num17 = num15;
							float num18 = num15;
							num16 *= 0.25f;
							num17 *= 1f;
							num18 *= 0.5f;
							Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num15 * num16, num15 * num17, num15 * num18);
						}
						if (Main.dust[i].type == 206)
						{
							Main.dust[i].scale -= 0.1f;
							float num19 = Main.dust[i].scale * 0.4f;
							float num20 = num19;
							float num21 = num19;
							float num22 = num19;
							num20 *= 0.1f;
							num21 *= 0.6f;
							num22 *= 1f;
							Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num19 * num20, num19 * num21, num19 * num22);
						}
						if (Main.dust[i].type == 163)
						{
							float num23 = Main.dust[i].scale * 0.25f;
							float num24 = num23;
							float num25 = num23;
							float num26 = num23;
							num24 *= 0.25f;
							num25 *= 1f;
							num26 *= 0.05f;
							Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num23 * num24, num23 * num25, num23 * num26);
						}
						if (Main.dust[i].type == 205)
						{
							float num27 = Main.dust[i].scale * 0.25f;
							float num28 = num27;
							float num29 = num27;
							float num30 = num27;
							num28 *= 1f;
							num29 *= 0.05f;
							num30 *= 1f;
							Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num27 * num28, num27 * num29, num27 * num30);
						}
						if (Main.dust[i].type == 170)
						{
							float num31 = Main.dust[i].scale * 0.5f;
							float num32 = num31;
							float num33 = num31;
							float num34 = num31;
							num32 *= 1f;
							num33 *= 1f;
							num34 *= 0.05f;
							Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num31 * num32, num31 * num33, num31 * num34);
						}
						if (Main.dust[i].type == 156)
						{
							float num35 = Main.dust[i].scale * 0.6f;
							int arg_766_0 = Main.dust[i].type;
							float num36 = num35;
							float num37 = num35;
							float num38 = num35;
							num36 *= 0.5f;
							num37 *= 0.9f;
							num38 *= 1f;
							Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num35 * num36, num35 * num37, num35 * num38);
						}
						if (Main.dust[i].type == 175)
						{
							Main.dust[i].scale -= 0.05f;
						}
						if (Main.dust[i].type == 174)
						{
							Main.dust[i].scale -= 0.01f;
							float num39 = Main.dust[i].scale * 1f;
							if (num39 > 0.6f)
							{
								num39 = 0.6f;
							}
							Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num39, num39 * 0.4f, 0f);
						}
						if (Main.dust[i].type == 6 || Main.dust[i].type == 135 || Main.dust[i].type == 127 || Main.dust[i].type == 187 || Main.dust[i].type == 75 || Main.dust[i].type == 169 || Main.dust[i].type == 29 || (Main.dust[i].type >= 59 && Main.dust[i].type <= 65) || Main.dust[i].type == 158)
						{
							if (!Main.dust[i].noGravity)
							{
								Dust expr_964_cp_0 = Main.dust[i];
								expr_964_cp_0.velocity.Y = expr_964_cp_0.velocity.Y + 0.05f;
							}
							if (!Main.dust[i].noLight)
							{
								float num40 = Main.dust[i].scale * 1.4f;
								if (Main.dust[i].type == 29)
								{
									if (num40 > 1f)
									{
										num40 = 1f;
									}
									Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num40 * 0.1f, num40 * 0.4f, num40);
								}
								if (Main.dust[i].type == 75)
								{
									if (num40 > 1f)
									{
										num40 = 1f;
									}
									Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num40 * 0.7f, num40, num40 * 0.2f);
								}
								if (Main.dust[i].type == 169)
								{
									if (num40 > 1f)
									{
										num40 = 1f;
									}
									Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num40 * 1.1f, num40 * 1.1f, num40 * 0.2f);
								}
								else
								{
									if (Main.dust[i].type == 135)
									{
										if (num40 > 1f)
										{
											num40 = 1f;
										}
										Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num40 * 0.2f, num40 * 0.7f, num40);
									}
									else
									{
										if (Main.dust[i].type == 158)
										{
											if (num40 > 1f)
											{
												num40 = 1f;
											}
											Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num40 * 1f, num40 * 0.5f, 0f);
										}
										else
										{
											if (Main.dust[i].type >= 59 && Main.dust[i].type <= 65)
											{
												if (num40 > 0.8f)
												{
													num40 = 0.8f;
												}
												int num41 = Main.dust[i].type - 58;
												float num42 = 1f;
												float num43 = 1f;
												float num44 = 1f;
												if (num41 == 1)
												{
													num42 = 0f;
													num43 = 0.1f;
													num44 = 1.3f;
												}
												else
												{
													if (num41 == 2)
													{
														num42 = 1f;
														num43 = 0.1f;
														num44 = 0.1f;
													}
													else
													{
														if (num41 == 3)
														{
															num42 = 0f;
															num43 = 1f;
															num44 = 0.1f;
														}
														else
														{
															if (num41 == 4)
															{
																num42 = 0.9f;
																num43 = 0f;
																num44 = 0.9f;
															}
															else
															{
																if (num41 == 5)
																{
																	num42 = 1.3f;
																	num43 = 1.3f;
																	num44 = 1.3f;
																}
																else
																{
																	if (num41 == 6)
																	{
																		num42 = 0.9f;
																		num43 = 0.9f;
																		num44 = 0f;
																	}
																	else
																	{
																		if (num41 == 7)
																		{
																			num42 = 0.5f * Main.demonTorch + 1f * (1f - Main.demonTorch);
																			num43 = 0.3f;
																			num44 = 1f * Main.demonTorch + 0.5f * (1f - Main.demonTorch);
																		}
																	}
																}
															}
														}
													}
												}
												Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num40 * num42, num40 * num43, num40 * num44);
											}
											else
											{
												if (Main.dust[i].type == 127)
												{
													num40 *= 1.3f;
													if (num40 > 1f)
													{
														num40 = 1f;
													}
													Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num40, num40 * 0.45f, num40 * 0.2f);
												}
												else
												{
													if (Main.dust[i].type == 187)
													{
														num40 *= 1.3f;
														if (num40 > 1f)
														{
															num40 = 1f;
														}
														Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num40 * 0.2f, num40 * 0.45f, num40);
													}
													else
													{
														if (num40 > 0.6f)
														{
															num40 = 0.6f;
														}
														Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num40, num40 * 0.65f, num40 * 0.4f);
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
							if (Main.dust[i].type == 159)
							{
								float num45 = Main.dust[i].scale * 1.3f;
								if (num45 > 1f)
								{
									num45 = 1f;
								}
								Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num45, num45, num45 * 0.1f);
								if (Main.dust[i].noGravity)
								{
									if (Main.dust[i].scale < 0.7f)
									{
										Main.dust[i].velocity *= 1.075f;
									}
									else
									{
										if (Main.rand.Next(2) == 0)
										{
											Main.dust[i].velocity *= -0.95f;
										}
										else
										{
											Main.dust[i].velocity *= 1.05f;
										}
									}
									Main.dust[i].scale -= 0.03f;
								}
								else
								{
									Main.dust[i].scale += 0.005f;
									Main.dust[i].velocity *= 0.9f;
									Dust expr_100D_cp_0 = Main.dust[i];
									expr_100D_cp_0.velocity.X = expr_100D_cp_0.velocity.X + (float)Main.rand.Next(-10, 11) * 0.02f;
									Dust expr_103A_cp_0 = Main.dust[i];
									expr_103A_cp_0.velocity.Y = expr_103A_cp_0.velocity.Y + (float)Main.rand.Next(-10, 11) * 0.02f;
									if (Main.rand.Next(5) == 0)
									{
										int num46 = Dust.NewDust(Main.dust[i].position, 4, 4, Main.dust[i].type, 0f, 0f, 0, default(Color), 1f);
										Main.dust[num46].noGravity = true;
										Main.dust[num46].scale = Main.dust[i].scale * 2.5f;
									}
								}
							}
							else
							{
								if (Main.dust[i].type == 164)
								{
									float num47 = Main.dust[i].scale;
									if (num47 > 1f)
									{
										num47 = 1f;
									}
									Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num47, num47 * 0.1f, num47 * 0.8f);
									if (Main.dust[i].noGravity)
									{
										if (Main.dust[i].scale < 0.7f)
										{
											Main.dust[i].velocity *= 1.075f;
										}
										else
										{
											if (Main.rand.Next(2) == 0)
											{
												Main.dust[i].velocity *= -0.95f;
											}
											else
											{
												Main.dust[i].velocity *= 1.05f;
											}
										}
										Main.dust[i].scale -= 0.03f;
									}
									else
									{
										Main.dust[i].scale -= 0.005f;
										Main.dust[i].velocity *= 0.9f;
										Dust expr_1239_cp_0 = Main.dust[i];
										expr_1239_cp_0.velocity.X = expr_1239_cp_0.velocity.X + (float)Main.rand.Next(-10, 11) * 0.02f;
										Dust expr_1266_cp_0 = Main.dust[i];
										expr_1266_cp_0.velocity.Y = expr_1266_cp_0.velocity.Y + (float)Main.rand.Next(-10, 11) * 0.02f;
										if (Main.rand.Next(5) == 0)
										{
											int num48 = Dust.NewDust(Main.dust[i].position, 4, 4, Main.dust[i].type, 0f, 0f, 0, default(Color), 1f);
											Main.dust[num48].noGravity = true;
											Main.dust[num48].scale = Main.dust[i].scale * 2.5f;
										}
									}
								}
								else
								{
									if (Main.dust[i].type == 173)
									{
										float num49 = Main.dust[i].scale;
										if (num49 > 1f)
										{
											num49 = 1f;
										}
										Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num49 * 0.4f, num49 * 0.1f, num49);
										if (Main.dust[i].noGravity)
										{
											Main.dust[i].velocity *= 0.8f;
											Dust expr_13B8_cp_0 = Main.dust[i];
											expr_13B8_cp_0.velocity.X = expr_13B8_cp_0.velocity.X + (float)Main.rand.Next(-20, 21) * 0.01f;
											Dust expr_13E5_cp_0 = Main.dust[i];
											expr_13E5_cp_0.velocity.Y = expr_13E5_cp_0.velocity.Y + (float)Main.rand.Next(-20, 21) * 0.01f;
											Main.dust[i].scale -= 0.01f;
										}
										else
										{
											Main.dust[i].scale -= 0.015f;
											Main.dust[i].velocity *= 0.8f;
											Dust expr_1463_cp_0 = Main.dust[i];
											expr_1463_cp_0.velocity.X = expr_1463_cp_0.velocity.X + (float)Main.rand.Next(-10, 11) * 0.005f;
											Dust expr_1490_cp_0 = Main.dust[i];
											expr_1490_cp_0.velocity.Y = expr_1490_cp_0.velocity.Y + (float)Main.rand.Next(-10, 11) * 0.005f;
											if (Main.rand.Next(10) == 10)
											{
												int num50 = Dust.NewDust(Main.dust[i].position, 4, 4, Main.dust[i].type, 0f, 0f, 0, default(Color), 1f);
												Main.dust[num50].noGravity = true;
												Main.dust[num50].scale = Main.dust[i].scale;
											}
										}
									}
									else
									{
										if (Main.dust[i].type == 184)
										{
											if (!Main.dust[i].noGravity)
											{
												Main.dust[i].velocity *= 0f;
												Main.dust[i].scale -= 0.01f;
											}
										}
										else
										{
											if (Main.dust[i].type == 160 || Main.dust[i].type == 162)
											{
												float num51 = Main.dust[i].scale * 1.3f;
												if (num51 > 1f)
												{
													num51 = 1f;
												}
												if (Main.dust[i].type == 162)
												{
													Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num51, num51 * 0.7f, num51 * 0.1f);
												}
												else
												{
													Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num51 * 0.1f, num51, num51);
												}
												if (Main.dust[i].noGravity)
												{
													Main.dust[i].velocity *= 0.8f;
													Dust expr_16AB_cp_0 = Main.dust[i];
													expr_16AB_cp_0.velocity.X = expr_16AB_cp_0.velocity.X + (float)Main.rand.Next(-20, 21) * 0.04f;
													Dust expr_16D8_cp_0 = Main.dust[i];
													expr_16D8_cp_0.velocity.Y = expr_16D8_cp_0.velocity.Y + (float)Main.rand.Next(-20, 21) * 0.04f;
													Main.dust[i].scale -= 0.1f;
												}
												else
												{
													Main.dust[i].scale -= 0.1f;
													Dust expr_173A_cp_0 = Main.dust[i];
													expr_173A_cp_0.velocity.X = expr_173A_cp_0.velocity.X + (float)Main.rand.Next(-10, 11) * 0.02f;
													Dust expr_1767_cp_0 = Main.dust[i];
													expr_1767_cp_0.velocity.Y = expr_1767_cp_0.velocity.Y + (float)Main.rand.Next(-10, 11) * 0.02f;
													if ((double)Main.dust[i].scale > 0.3 && Main.rand.Next(50) == 0)
													{
														int num52 = Dust.NewDust(new Vector2(Main.dust[i].position.X - 4f, Main.dust[i].position.Y - 4f), 1, 1, Main.dust[i].type, 0f, 0f, 0, default(Color), 1f);
														Main.dust[num52].noGravity = true;
														Main.dust[num52].scale = Main.dust[i].scale * 1.5f;
													}
												}
											}
											else
											{
												if (Main.dust[i].type == 168)
												{
													float num53 = Main.dust[i].scale * 0.8f;
													if ((double)num53 > 0.55)
													{
														num53 = 0.55f;
													}
													Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num53, 0f, num53 * 0.8f);
													Main.dust[i].scale += 0.03f;
													Dust expr_18EF_cp_0 = Main.dust[i];
													expr_18EF_cp_0.velocity.X = expr_18EF_cp_0.velocity.X + (float)Main.rand.Next(-10, 11) * 0.02f;
													Dust expr_191C_cp_0 = Main.dust[i];
													expr_191C_cp_0.velocity.Y = expr_191C_cp_0.velocity.Y + (float)Main.rand.Next(-10, 11) * 0.02f;
													Main.dust[i].velocity *= 0.99f;
												}
												else
												{
													if (Main.dust[i].type >= 139 && Main.dust[i].type < 143)
													{
														Dust expr_1996_cp_0 = Main.dust[i];
														expr_1996_cp_0.velocity.X = expr_1996_cp_0.velocity.X * 0.98f;
														Dust expr_19B3_cp_0 = Main.dust[i];
														expr_19B3_cp_0.velocity.Y = expr_19B3_cp_0.velocity.Y * 0.98f;
														if (Main.dust[i].velocity.Y < 1f)
														{
															Dust expr_19E8_cp_0 = Main.dust[i];
															expr_19E8_cp_0.velocity.Y = expr_19E8_cp_0.velocity.Y + 0.05f;
														}
														Main.dust[i].scale += 0.009f;
														Main.dust[i].rotation -= Main.dust[i].velocity.X * 0.4f;
														if (Main.dust[i].velocity.X > 0f)
														{
															Main.dust[i].rotation += 0.005f;
														}
														else
														{
															Main.dust[i].rotation -= 0.005f;
														}
													}
													else
													{
														if (Main.dust[i].type == 14 || Main.dust[i].type == 16 || Main.dust[i].type == 31 || Main.dust[i].type == 46 || Main.dust[i].type == 124 || Main.dust[i].type == 186 || Main.dust[i].type == 188)
														{
															Dust expr_1B12_cp_0 = Main.dust[i];
															expr_1B12_cp_0.velocity.Y = expr_1B12_cp_0.velocity.Y * 0.98f;
															Dust expr_1B2F_cp_0 = Main.dust[i];
															expr_1B2F_cp_0.velocity.X = expr_1B2F_cp_0.velocity.X * 0.98f;
															if (Main.dust[i].type == 31 && Main.dust[i].noGravity)
															{
																Main.dust[i].velocity *= 1.02f;
																Main.dust[i].scale += 0.02f;
																Main.dust[i].alpha += 4;
																if (Main.dust[i].alpha > 255)
																{
																	Main.dust[i].scale = 0.0001f;
																	Main.dust[i].alpha = 255;
																}
															}
														}
														else
														{
															if (Main.dust[i].type == 32)
															{
																Main.dust[i].scale -= 0.01f;
																Dust expr_1C1D_cp_0 = Main.dust[i];
																expr_1C1D_cp_0.velocity.X = expr_1C1D_cp_0.velocity.X * 0.96f;
																if (!Main.dust[i].noGravity)
																{
																	Dust expr_1C4B_cp_0 = Main.dust[i];
																	expr_1C4B_cp_0.velocity.Y = expr_1C4B_cp_0.velocity.Y + 0.1f;
																}
															}
															else
															{
																if (Main.dust[i].type == 43)
																{
																	Main.dust[i].rotation += 0.1f * Main.dust[i].scale;
																	Color color = Lighting.GetColor((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f));
																	float num54 = (float)color.R / 270f;
																	float num55 = (float)color.G / 270f;
																	float num56 = (float)color.B / 270f;
																	float num57 = (float)(Main.dust[i].color.R / 255);
																	float num58 = (float)(Main.dust[i].color.G / 255);
																	float num59 = (float)(Main.dust[i].color.B / 255);
																	num54 *= Main.dust[i].scale * 1.07f * num57;
																	num55 *= Main.dust[i].scale * 1.07f * num58;
																	num56 *= Main.dust[i].scale * 1.07f * num59;
																	if (Main.dust[i].alpha < 255)
																	{
																		Main.dust[i].scale += 0.09f;
																		if (Main.dust[i].scale >= 1f)
																		{
																			Main.dust[i].scale = 1f;
																			Main.dust[i].alpha = 255;
																		}
																	}
																	else
																	{
																		if ((double)Main.dust[i].scale < 0.8)
																		{
																			Main.dust[i].scale -= 0.01f;
																		}
																		if ((double)Main.dust[i].scale < 0.5)
																		{
																			Main.dust[i].scale -= 0.01f;
																		}
																	}
																	if ((double)num54 < 0.05 && (double)num55 < 0.05 && (double)num56 < 0.05)
																	{
																		Main.dust[i].active = false;
																	}
																	else
																	{
																		Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num54, num55, num56);
																	}
																}
																else
																{
																	if (Main.dust[i].type == 15 || Main.dust[i].type == 57 || Main.dust[i].type == 58)
																	{
																		Dust expr_1F1C_cp_0 = Main.dust[i];
																		expr_1F1C_cp_0.velocity.Y = expr_1F1C_cp_0.velocity.Y * 0.98f;
																		Dust expr_1F39_cp_0 = Main.dust[i];
																		expr_1F39_cp_0.velocity.X = expr_1F39_cp_0.velocity.X * 0.98f;
																		float num60 = Main.dust[i].scale;
																		if (Main.dust[i].type != 15)
																		{
																			num60 = Main.dust[i].scale * 0.8f;
																		}
																		if (Main.dust[i].noLight)
																		{
																			Main.dust[i].velocity *= 0.95f;
																		}
																		if (num60 > 1f)
																		{
																			num60 = 1f;
																		}
																		if (Main.dust[i].type == 15)
																		{
																			Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num60 * 0.45f, num60 * 0.55f, num60);
																		}
																		else
																		{
																			if (Main.dust[i].type == 57)
																			{
																				Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num60 * 0.95f, num60 * 0.95f, num60 * 0.45f);
																			}
																			else
																			{
																				if (Main.dust[i].type == 58)
																				{
																					Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num60, num60 * 0.55f, num60 * 0.75f);
																				}
																			}
																		}
																	}
																	else
																	{
																		if (Main.dust[i].type == 204)
																		{
																			if (Main.dust[i].fadeIn > Main.dust[i].scale)
																			{
																				Main.dust[i].scale += 0.02f;
																			}
																			else
																			{
																				Main.dust[i].scale -= 0.02f;
																			}
																			Main.dust[i].velocity *= 0.95f;
																		}
																		else
																		{
																			if (Main.dust[i].type == 110)
																			{
																				float num61 = Main.dust[i].scale * 0.1f;
																				if (num61 > 1f)
																				{
																					num61 = 1f;
																				}
																				Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num61 * 0.2f, num61, num61 * 0.5f);
																			}
																			else
																			{
																				if (Main.dust[i].type == 111)
																				{
																					float num62 = Main.dust[i].scale * 0.125f;
																					if (num62 > 1f)
																					{
																						num62 = 1f;
																					}
																					Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num62 * 0.2f, num62 * 0.7f, num62);
																				}
																				else
																				{
																					if (Main.dust[i].type == 112)
																					{
																						float num63 = Main.dust[i].scale * 0.1f;
																						if (num63 > 1f)
																						{
																							num63 = 1f;
																						}
																						Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num63 * 0.8f, num63 * 0.2f, num63 * 0.8f);
																					}
																					else
																					{
																						if (Main.dust[i].type == 113)
																						{
																							float num64 = Main.dust[i].scale * 0.1f;
																							if (num64 > 1f)
																							{
																								num64 = 1f;
																							}
																							Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num64 * 0.2f, num64 * 0.3f, num64 * 1.3f);
																						}
																						else
																						{
																							if (Main.dust[i].type == 114)
																							{
																								float num65 = Main.dust[i].scale * 0.1f;
																								if (num65 > 1f)
																								{
																									num65 = 1f;
																								}
																								Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num65 * 1.2f, num65 * 0.5f, num65 * 0.4f);
																							}
																							else
																							{
																								if (Main.dust[i].type == 66)
																								{
																									if (Main.dust[i].velocity.X < 0f)
																									{
																										Main.dust[i].rotation -= 1f;
																									}
																									else
																									{
																										Main.dust[i].rotation += 1f;
																									}
																									Dust expr_244E_cp_0 = Main.dust[i];
																									expr_244E_cp_0.velocity.Y = expr_244E_cp_0.velocity.Y * 0.98f;
																									Dust expr_246B_cp_0 = Main.dust[i];
																									expr_246B_cp_0.velocity.X = expr_246B_cp_0.velocity.X * 0.98f;
																									Main.dust[i].scale += 0.02f;
																									float num66 = Main.dust[i].scale;
																									if (Main.dust[i].type != 15)
																									{
																										num66 = Main.dust[i].scale * 0.8f;
																									}
																									if (num66 > 1f)
																									{
																										num66 = 1f;
																									}
																									Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num66 * ((float)Main.dust[i].color.R / 255f), num66 * ((float)Main.dust[i].color.G / 255f), num66 * ((float)Main.dust[i].color.B / 255f));
																								}
																								else
																								{
																									if (Main.dust[i].type == 20 || Main.dust[i].type == 21)
																									{
																										Main.dust[i].scale += 0.005f;
																										Dust expr_25A8_cp_0 = Main.dust[i];
																										expr_25A8_cp_0.velocity.Y = expr_25A8_cp_0.velocity.Y * 0.94f;
																										Dust expr_25C5_cp_0 = Main.dust[i];
																										expr_25C5_cp_0.velocity.X = expr_25C5_cp_0.velocity.X * 0.94f;
																										float num67 = Main.dust[i].scale * 0.8f;
																										if (num67 > 1f)
																										{
																											num67 = 1f;
																										}
																										if (Main.dust[i].type == 21)
																										{
																											num67 = Main.dust[i].scale * 0.4f;
																											Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num67 * 0.8f, num67 * 0.3f, num67);
																										}
																										else
																										{
																											Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num67 * 0.3f, num67 * 0.6f, num67);
																										}
																									}
																									else
																									{
																										if (Main.dust[i].type == 27 || Main.dust[i].type == 45)
																										{
																											Main.dust[i].velocity *= 0.94f;
																											Main.dust[i].scale += 0.002f;
																											float num68 = Main.dust[i].scale;
																											if (Main.dust[i].noLight)
																											{
																												num68 *= 0.1f;
																												Main.dust[i].scale -= 0.06f;
																												if (Main.dust[i].scale < 1f)
																												{
																													Main.dust[i].scale -= 0.06f;
																												}
																												if (Main.player[Main.myPlayer].wet)
																												{
																													Main.dust[i].position += Main.player[Main.myPlayer].velocity * 0.5f;
																												}
																												else
																												{
																													Main.dust[i].position += Main.player[Main.myPlayer].velocity;
																												}
																											}
																											if (num68 > 1f)
																											{
																												num68 = 1f;
																											}
																											Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num68 * 0.6f, num68 * 0.2f, num68);
																										}
																										else
																										{
																											if (Main.dust[i].type == 55 || Main.dust[i].type == 56 || Main.dust[i].type == 73 || Main.dust[i].type == 74)
																											{
																												Main.dust[i].velocity *= 0.98f;
																												float num69 = Main.dust[i].scale * 0.8f;
																												if (Main.dust[i].type == 55)
																												{
																													if (num69 > 1f)
																													{
																														num69 = 1f;
																													}
																													Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num69, num69, num69 * 0.6f);
																												}
																												else
																												{
																													if (Main.dust[i].type == 73)
																													{
																														if (num69 > 1f)
																														{
																															num69 = 1f;
																														}
																														Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num69, num69 * 0.35f, num69 * 0.5f);
																													}
																													else
																													{
																														if (Main.dust[i].type == 74)
																														{
																															if (num69 > 1f)
																															{
																																num69 = 1f;
																															}
																															Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num69 * 0.35f, num69, num69 * 0.5f);
																														}
																														else
																														{
																															num69 = Main.dust[i].scale * 1.2f;
																															if (num69 > 1f)
																															{
																																num69 = 1f;
																															}
																															Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num69 * 0.35f, num69 * 0.5f, num69);
																														}
																													}
																												}
																											}
																											else
																											{
																												if (Main.dust[i].type == 71 || Main.dust[i].type == 72)
																												{
																													Main.dust[i].velocity *= 0.98f;
																													float num70 = Main.dust[i].scale;
																													if (num70 > 1f)
																													{
																														num70 = 1f;
																													}
																													Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num70 * 0.2f, 0f, num70 * 0.1f);
																												}
																												else
																												{
																													if (Main.dust[i].type == 76)
																													{
																														int arg_2B36_0 = (int)Main.dust[i].position.X / 16;
																														int arg_2B4C_0 = (int)Main.dust[i].position.Y / 16;
																														Main.snowDust++;
																														Main.dust[i].scale += 0.009f;
																														if (!Main.dust[i].noLight)
																														{
																															Main.dust[i].position += Main.player[Main.myPlayer].velocity * 0.2f;
																														}
																													}
																													else
																													{
																														if (!Main.dust[i].noGravity && Main.dust[i].type != 41 && Main.dust[i].type != 44)
																														{
																															if (Main.dust[i].type == 107)
																															{
																																Main.dust[i].velocity *= 0.9f;
																															}
																															else
																															{
																																Dust expr_2C1D_cp_0 = Main.dust[i];
																																expr_2C1D_cp_0.velocity.Y = expr_2C1D_cp_0.velocity.Y + 0.1f;
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
						if (Main.dust[i].type == 5 && Main.dust[i].noGravity)
						{
							Main.dust[i].scale -= 0.04f;
						}
						if (Main.dust[i].type == 33 || Main.dust[i].type == 52 || Main.dust[i].type == 98 || Main.dust[i].type == 99 || Main.dust[i].type == 100 || Main.dust[i].type == 101 || Main.dust[i].type == 102 || Main.dust[i].type == 103 || Main.dust[i].type == 104 || Main.dust[i].type == 105 || Main.dust[i].type == 123)
						{
							if (Main.dust[i].velocity.X == 0f)
							{
								if (Collision.SolidCollision(Main.dust[i].position, 2, 2))
								{
									Main.dust[i].scale = 0f;
								}
								Main.dust[i].rotation += 0.5f;
								Main.dust[i].scale -= 0.01f;
							}
							bool flag = Collision.WetCollision(new Vector2(Main.dust[i].position.X, Main.dust[i].position.Y), 4, 4);
							if (flag)
							{
								Main.dust[i].alpha += 20;
								Main.dust[i].scale -= 0.1f;
							}
							Main.dust[i].alpha += 2;
							Main.dust[i].scale -= 0.005f;
							if (Main.dust[i].alpha > 255)
							{
								Main.dust[i].scale = 0f;
							}
							if (Main.dust[i].velocity.Y > 4f)
							{
								Main.dust[i].velocity.Y = 4f;
							}
							if (Main.dust[i].noGravity)
							{
								if (Main.dust[i].velocity.X < 0f)
								{
									Main.dust[i].rotation -= 0.2f;
								}
								else
								{
									Main.dust[i].rotation += 0.2f;
								}
								Main.dust[i].scale += 0.03f;
								Dust expr_2EEB_cp_0 = Main.dust[i];
								expr_2EEB_cp_0.velocity.X = expr_2EEB_cp_0.velocity.X * 1.05f;
								Dust expr_2F08_cp_0 = Main.dust[i];
								expr_2F08_cp_0.velocity.Y = expr_2F08_cp_0.velocity.Y + 0.15f;
							}
						}
						if (Main.dust[i].type == 35 && Main.dust[i].noGravity)
						{
							Main.dust[i].scale += 0.03f;
							if (Main.dust[i].scale < 1f)
							{
								Dust expr_2F74_cp_0 = Main.dust[i];
								expr_2F74_cp_0.velocity.Y = expr_2F74_cp_0.velocity.Y + 0.075f;
							}
							Dust expr_2F91_cp_0 = Main.dust[i];
							expr_2F91_cp_0.velocity.X = expr_2F91_cp_0.velocity.X * 1.08f;
							if (Main.dust[i].velocity.X > 0f)
							{
								Main.dust[i].rotation += 0.01f;
							}
							else
							{
								Main.dust[i].rotation -= 0.01f;
							}
							float num71 = Main.dust[i].scale * 0.6f;
							if (num71 > 1f)
							{
								num71 = 1f;
							}
							Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f + 1f), num71, num71 * 0.3f, num71 * 0.1f);
						}
						else
						{
							if (Main.dust[i].type == 152 && Main.dust[i].noGravity)
							{
								Main.dust[i].scale += 0.03f;
								if (Main.dust[i].scale < 1f)
								{
									Dust expr_30C0_cp_0 = Main.dust[i];
									expr_30C0_cp_0.velocity.Y = expr_30C0_cp_0.velocity.Y + 0.075f;
								}
								Dust expr_30DD_cp_0 = Main.dust[i];
								expr_30DD_cp_0.velocity.X = expr_30DD_cp_0.velocity.X * 1.08f;
								if (Main.dust[i].velocity.X > 0f)
								{
									Main.dust[i].rotation += 0.01f;
								}
								else
								{
									Main.dust[i].rotation -= 0.01f;
								}
							}
							else
							{
								if (Main.dust[i].type == 67 || Main.dust[i].type == 92)
								{
									float num72 = Main.dust[i].scale;
									if (num72 > 1f)
									{
										num72 = 1f;
									}
									if (Main.dust[i].noLight)
									{
										num72 *= 0.1f;
									}
									Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), 0f, num72 * 0.8f, num72);
								}
								else
								{
									if (Main.dust[i].type == 185)
									{
										float num73 = Main.dust[i].scale;
										if (num73 > 1f)
										{
											num73 = 1f;
										}
										if (Main.dust[i].noLight)
										{
											num73 *= 0.1f;
										}
										Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num73 * 0.1f, num73 * 0.7f, num73);
									}
									else
									{
										if (Main.dust[i].type == 107)
										{
											float num74 = Main.dust[i].scale * 0.5f;
											if (num74 > 1f)
											{
												num74 = 1f;
											}
											Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num74 * 0.1f, num74, num74 * 0.4f);
										}
										else
										{
											if (Main.dust[i].type == 34 || Main.dust[i].type == 35 || Main.dust[i].type == 152)
											{
												if (!Collision.WetCollision(new Vector2(Main.dust[i].position.X, Main.dust[i].position.Y - 8f), 4, 4))
												{
													Main.dust[i].scale = 0f;
												}
												else
												{
													Main.dust[i].alpha += Main.rand.Next(2);
													if (Main.dust[i].alpha > 255)
													{
														Main.dust[i].scale = 0f;
													}
													Main.dust[i].velocity.Y = -0.5f;
													if (Main.dust[i].type == 34)
													{
														Main.dust[i].scale += 0.005f;
													}
													else
													{
														Main.dust[i].alpha++;
														Main.dust[i].scale -= 0.01f;
														Main.dust[i].velocity.Y = -0.2f;
													}
													Dust expr_344D_cp_0 = Main.dust[i];
													expr_344D_cp_0.velocity.X = expr_344D_cp_0.velocity.X + (float)Main.rand.Next(-10, 10) * 0.002f;
													if ((double)Main.dust[i].velocity.X < -0.25)
													{
														Main.dust[i].velocity.X = -0.25f;
													}
													if ((double)Main.dust[i].velocity.X > 0.25)
													{
														Main.dust[i].velocity.X = 0.25f;
													}
												}
												if (Main.dust[i].type == 35)
												{
													float num75 = Main.dust[i].scale * 0.3f + 0.4f;
													if (num75 > 1f)
													{
														num75 = 1f;
													}
													Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num75, num75 * 0.5f, num75 * 0.3f);
												}
											}
										}
									}
								}
							}
						}
						if (Main.dust[i].type == 68)
						{
							float num76 = Main.dust[i].scale * 0.3f;
							if (num76 > 1f)
							{
								num76 = 1f;
							}
							Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num76 * 0.1f, num76 * 0.2f, num76);
						}
						if (Main.dust[i].type == 70)
						{
							float num77 = Main.dust[i].scale * 0.3f;
							if (num77 > 1f)
							{
								num77 = 1f;
							}
							Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num77 * 0.5f, 0f, num77);
						}
						if (Main.dust[i].type == 41)
						{
							Dust expr_3667_cp_0 = Main.dust[i];
							expr_3667_cp_0.velocity.X = expr_3667_cp_0.velocity.X + (float)Main.rand.Next(-10, 11) * 0.01f;
							Dust expr_3694_cp_0 = Main.dust[i];
							expr_3694_cp_0.velocity.Y = expr_3694_cp_0.velocity.Y + (float)Main.rand.Next(-10, 11) * 0.01f;
							if ((double)Main.dust[i].velocity.X > 0.75)
							{
								Main.dust[i].velocity.X = 0.75f;
							}
							if ((double)Main.dust[i].velocity.X < -0.75)
							{
								Main.dust[i].velocity.X = -0.75f;
							}
							if ((double)Main.dust[i].velocity.Y > 0.75)
							{
								Main.dust[i].velocity.Y = 0.75f;
							}
							if ((double)Main.dust[i].velocity.Y < -0.75)
							{
								Main.dust[i].velocity.Y = -0.75f;
							}
							Main.dust[i].scale += 0.007f;
							float num78 = Main.dust[i].scale * 0.7f;
							if (num78 > 1f)
							{
								num78 = 1f;
							}
							Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num78 * 0.4f, num78 * 0.9f, num78);
						}
						else
						{
							if (Main.dust[i].type == 44)
							{
								Dust expr_3828_cp_0 = Main.dust[i];
								expr_3828_cp_0.velocity.X = expr_3828_cp_0.velocity.X + (float)Main.rand.Next(-10, 11) * 0.003f;
								Dust expr_3855_cp_0 = Main.dust[i];
								expr_3855_cp_0.velocity.Y = expr_3855_cp_0.velocity.Y + (float)Main.rand.Next(-10, 11) * 0.003f;
								if ((double)Main.dust[i].velocity.X > 0.35)
								{
									Main.dust[i].velocity.X = 0.35f;
								}
								if ((double)Main.dust[i].velocity.X < -0.35)
								{
									Main.dust[i].velocity.X = -0.35f;
								}
								if ((double)Main.dust[i].velocity.Y > 0.35)
								{
									Main.dust[i].velocity.Y = 0.35f;
								}
								if ((double)Main.dust[i].velocity.Y < -0.35)
								{
									Main.dust[i].velocity.Y = -0.35f;
								}
								Main.dust[i].scale += 0.0085f;
								float num79 = Main.dust[i].scale * 0.7f;
								if (num79 > 1f)
								{
									num79 = 1f;
								}
								Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num79 * 0.7f, num79, num79 * 0.8f);
							}
							else
							{
								Dust expr_39D3_cp_0 = Main.dust[i];
								expr_39D3_cp_0.velocity.X = expr_39D3_cp_0.velocity.X * 0.99f;
							}
						}
						if (Main.dust[i].type != 79)
						{
							Main.dust[i].rotation += Main.dust[i].velocity.X * 0.5f;
						}
						if (Main.dust[i].fadeIn > 0f)
						{
							if (Main.dust[i].type == 46)
							{
								Main.dust[i].scale += 0.1f;
							}
							else
							{
								Main.dust[i].scale += 0.03f;
							}
							if (Main.dust[i].scale > Main.dust[i].fadeIn)
							{
								Main.dust[i].fadeIn = 0f;
							}
						}
						else
						{
							Main.dust[i].scale -= 0.01f;
						}
						if (Main.dust[i].type >= 130 && Main.dust[i].type <= 134)
						{
							float num80 = Main.dust[i].scale;
							if (num80 > 1f)
							{
								num80 = 1f;
							}
							if (Main.dust[i].type == 130)
							{
								Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num80 * 1f, num80 * 0.5f, num80 * 0.4f);
							}
							if (Main.dust[i].type == 131)
							{
								Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num80 * 0.4f, num80 * 1f, num80 * 0.6f);
							}
							if (Main.dust[i].type == 132)
							{
								Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num80 * 0.3f, num80 * 0.5f, num80 * 1f);
							}
							if (Main.dust[i].type == 133)
							{
								Lighting.addLight((int)(Main.dust[i].position.X / 16f), (int)(Main.dust[i].position.Y / 16f), num80 * 0.9f, num80 * 0.9f, num80 * 0.3f);
							}
							if (Main.dust[i].noGravity)
							{
								Main.dust[i].velocity *= 0.93f;
								if (Main.dust[i].fadeIn == 0f)
								{
									Main.dust[i].scale += 0.0025f;
								}
							}
							else
							{
								if (Main.dust[i].type == 131)
								{
									Main.dust[i].velocity *= 0.98f;
									Dust expr_3D1A_cp_0 = Main.dust[i];
									expr_3D1A_cp_0.velocity.Y = expr_3D1A_cp_0.velocity.Y - 0.1f;
									Main.dust[i].scale += 0.0025f;
								}
								else
								{
									Main.dust[i].velocity *= 0.95f;
									Main.dust[i].scale -= 0.0025f;
								}
							}
						}
						else
						{
							if (Main.dust[i].noGravity)
							{
								Main.dust[i].velocity *= 0.92f;
								if (Main.dust[i].fadeIn == 0f)
								{
									Main.dust[i].scale -= 0.04f;
								}
							}
						}
						if (Main.dust[i].position.Y > Main.screenPosition.Y + (float)Main.screenHeight)
						{
							Main.dust[i].active = false;
						}
						float num81 = 0.1f;
						if ((double)Dust.dCount == 0.5)
						{
							Main.dust[i].scale -= 0.001f;
						}
						if ((double)Dust.dCount == 0.6)
						{
							Main.dust[i].scale -= 0.0025f;
						}
						if ((double)Dust.dCount == 0.7)
						{
							Main.dust[i].scale -= 0.005f;
						}
						if ((double)Dust.dCount == 0.8)
						{
							Main.dust[i].scale -= 0.01f;
						}
						if ((double)Dust.dCount == 0.9)
						{
							Main.dust[i].scale -= 0.02f;
						}
						if ((double)Dust.dCount == 0.5)
						{
							num81 = 0.11f;
						}
						if ((double)Dust.dCount == 0.6)
						{
							num81 = 0.13f;
						}
						if ((double)Dust.dCount == 0.7)
						{
							num81 = 0.16f;
						}
						if ((double)Dust.dCount == 0.8)
						{
							num81 = 0.22f;
						}
						if ((double)Dust.dCount == 0.9)
						{
							num81 = 0.25f;
						}
						if (Main.dust[i].scale < num81)
						{
							Main.dust[i].active = false;
						}
					}
				}
				else
				{
					Main.dust[i].active = false;
				}
			}
			int num82 = num;
			if ((double)num82 > (double)Main.numDust * 0.9)
			{
				Dust.dCount = 0.9f;
				return;
			}
			if ((double)num82 > (double)Main.numDust * 0.8)
			{
				Dust.dCount = 0.8f;
				return;
			}
			if ((double)num82 > (double)Main.numDust * 0.7)
			{
				Dust.dCount = 0.7f;
				return;
			}
			if ((double)num82 > (double)Main.numDust * 0.6)
			{
				Dust.dCount = 0.6f;
				return;
			}
			if ((double)num82 > (double)Main.numDust * 0.5)
			{
				Dust.dCount = 0.5f;
				return;
			}
			Dust.dCount = 0f;
		}
		public Color GetAlpha(Color newColor)
		{
			float num = (float)(255 - this.alpha) / 255f;
			if (this.type >= 86 && this.type <= 91 && !this.noLight)
			{
				return new Color(255, 255, 255, 0);
			}
			if (this.type == 64 && this.alpha == 255 && this.noLight)
			{
				return new Color(255, 255, 255, 0);
			}
			if (this.type == 197)
			{
				return new Color(250, 250, 250, 150);
			}
			if (this.type >= 110 && this.type <= 114)
			{
				return new Color(200, 200, 200, 0);
			}
			if (this.type == 204)
			{
				return new Color(255, 255, 255, 0);
			}
			if (this.type == 181)
			{
				return new Color(200, 200, 200, 0);
			}
			if (this.type == 182 || this.type == 206)
			{
				return new Color(255, 255, 255, 0);
			}
			if (this.type == 159)
			{
				return new Color(250, 250, 250, 50);
			}
			if (this.type == 163 || this.type == 205)
			{
				return new Color(250, 250, 250, 0);
			}
			if (this.type == 170)
			{
				return new Color(200, 200, 200, 100);
			}
			if (this.type == 180)
			{
				return new Color(200, 200, 200, 0);
			}
			if (this.type == 175)
			{
				return new Color(200, 200, 200, 0);
			}
			if (this.type == 183)
			{
				return new Color(50, 0, 0, 0);
			}
			if (this.type == 172)
			{
				return new Color(250, 250, 250, 150);
			}
			if (this.type == 160 || this.type == 162 || this.type == 164 || this.type == 173)
			{
				int num2 = (int)(250f * this.scale);
				return new Color(num2, num2, num2, 0);
			}
			if (this.type == 92 || this.type == 106 || this.type == 107)
			{
				return new Color(255, 255, 255, 0);
			}
			if (this.type == 185)
			{
				return new Color(200, 200, 255, 125);
			}
			if (this.type == 127 || this.type == 187)
			{
				return new Color((int)newColor.R, (int)newColor.G, (int)newColor.B, 25);
			}
			if (this.type == 156)
			{
				return new Color(255, 255, 255, 0);
			}
			if (this.type == 6 || this.type == 174 || this.type == 135 || this.type == 75 || this.type == 20 || this.type == 21 || this.type == 169 || (this.type >= 130 && this.type <= 134) || this.type == 158)
			{
				return new Color((int)newColor.R, (int)newColor.G, (int)newColor.B, 25);
			}
			if ((this.type == 68 || this.type == 70) && this.noGravity)
			{
				return new Color(255, 255, 255, 0);
			}
			int num5;
			int num4;
			int num3;
			if (this.type == 157)
			{
				num3 = (num4 = (num5 = 255));
				float num6 = (float)Main.mouseTextColor / 100f - 1.6f;
				num4 = (int)((float)num4 * num6);
				num3 = (int)((float)num3 * num6);
				num5 = (int)((float)num5 * num6);
				int a = (int)(100f * num6);
				num4 += 50;
				if (num4 > 255)
				{
					num4 = 255;
				}
				num3 += 50;
				if (num3 > 255)
				{
					num3 = 255;
				}
				num5 += 50;
				if (num5 > 255)
				{
					num5 = 255;
				}
				return new Color(num4, num3, num5, a);
			}
			if (this.type == 15 || this.type == 20 || this.type == 21 || this.type == 29 || this.type == 35 || this.type == 41 || this.type == 44 || this.type == 27 || this.type == 45 || this.type == 55 || this.type == 56 || this.type == 57 || this.type == 58 || this.type == 73 || this.type == 74)
			{
				num = (num + 3f) / 4f;
			}
			else
			{
				if (this.type == 43)
				{
					num = (num + 9f) / 10f;
				}
				else
				{
					if (this.type == 66)
					{
						return new Color((int)newColor.R, (int)newColor.G, (int)newColor.B, 0);
					}
					if (this.type == 71)
					{
						return new Color(200, 200, 200, 0);
					}
					if (this.type == 72)
					{
						return new Color(200, 200, 200, 200);
					}
				}
			}
			num4 = (int)((float)newColor.R * num);
			num3 = (int)((float)newColor.G * num);
			num5 = (int)((float)newColor.B * num);
			int num7 = (int)newColor.A - this.alpha;
			if (num7 < 0)
			{
				num7 = 0;
			}
			if (num7 > 255)
			{
				num7 = 255;
			}
			return new Color(num4, num3, num5, num7);
		}
		public Color GetColor(Color newColor)
		{
			int num = (int)(this.color.R - (255 - newColor.R));
			int num2 = (int)(this.color.G - (255 - newColor.G));
			int num3 = (int)(this.color.B - (255 - newColor.B));
			int num4 = (int)(this.color.A - (255 - newColor.A));
			if (num < 0)
			{
				num = 0;
			}
			if (num > 255)
			{
				num = 255;
			}
			if (num2 < 0)
			{
				num2 = 0;
			}
			if (num2 > 255)
			{
				num2 = 255;
			}
			if (num3 < 0)
			{
				num3 = 0;
			}
			if (num3 > 255)
			{
				num3 = 255;
			}
			if (num4 < 0)
			{
				num4 = 0;
			}
			if (num4 > 255)
			{
				num4 = 255;
			}
			return new Color(num, num2, num3, num4);
		}
	}
}
