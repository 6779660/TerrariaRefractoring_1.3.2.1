using Microsoft.Xna.Framework;
using System;
namespace Terraria
{
	public class Collision
	{
		public static bool stair;
		public static bool stairFall;
		public static bool honey;
		public static bool sloping;
		public static bool landMine;
		public static bool up;
		public static bool down;
        public static bool CanHit(Vector2 Position1, int Width1, int Height1, Vector2 Position2, int Width2, int Height2)
        {
            bool flag;
            int x = (int)((Position1.X + (float)(Width1 / 2)) / 16f);
            int y = (int)((Position1.Y + (float)(Height1 / 2)) / 16f);
            int num = (int)((Position2.X + (float)(Width2 / 2)) / 16f);
            int y1 = (int)((Position2.Y + (float)(Height2 / 2)) / 16f);
            if (x <= 1)
            {
                x = 1;
            }
            if (x >= Main.maxTilesX)
            {
                x = Main.maxTilesX - 1;
            }
            if (num <= 1)
            {
                num = 1;
            }
            if (num >= Main.maxTilesX)
            {
                num = Main.maxTilesX - 1;
            }
            if (y <= 1)
            {
                y = 1;
            }
            if (y >= Main.maxTilesY)
            {
                y = Main.maxTilesY - 1;
            }
            if (y1 <= 1)
            {
                y1 = 1;
            }
            if (y1 >= Main.maxTilesY)
            {
                y1 = Main.maxTilesY - 1;
            }
            try
            {
                do
                {
                    int num1 = Math.Abs(x - num);
                    int num2 = Math.Abs(y - y1);
                    if (x != num || y != y1)
                    {
                        if (num1 <= num2)
                        {
                            y = (y >= y1 ? y - 1 : y + 1);
                            if (Main.tile[x - 1, y] == null)
                            {
                                Main.tile[x - 1, y] = new Tile();
                            }
                            if (Main.tile[x + 1, y] == null)
                            {
                                Main.tile[x + 1, y] = new Tile();
                            }
                            if (!Main.tile[x - 1, y].inActive() && Main.tile[x - 1, y].active() && Main.tileSolid[Main.tile[x - 1, y].type] && !Main.tileSolidTop[Main.tile[x - 1, y].type] && Main.tile[x - 1, y].slope() == 0 && !Main.tile[x - 1, y].halfBrick() && !Main.tile[x + 1, y].inActive() && Main.tile[x + 1, y].active() && Main.tileSolid[Main.tile[x + 1, y].type] && !Main.tileSolidTop[Main.tile[x + 1, y].type] && Main.tile[x + 1, y].slope() == 0 && !Main.tile[x + 1, y].halfBrick())
                            {
                                flag = false;
                                return flag;
                            }
                        }
                        else
                        {
                            x = (x >= num ? x - 1 : x + 1);
                            if (Main.tile[x, y - 1] == null)
                            {
                                Main.tile[x, y - 1] = new Tile();
                            }
                            if (Main.tile[x, y + 1] == null)
                            {
                                Main.tile[x, y + 1] = new Tile();
                            }
                            if (!Main.tile[x, y - 1].inActive() && Main.tile[x, y - 1].active() && Main.tileSolid[Main.tile[x, y - 1].type] && !Main.tileSolidTop[Main.tile[x, y - 1].type] && Main.tile[x, y - 1].slope() == 0 && !Main.tile[x, y - 1].halfBrick() && !Main.tile[x, y + 1].inActive() && Main.tile[x, y + 1].active() && Main.tileSolid[Main.tile[x, y + 1].type] && !Main.tileSolidTop[Main.tile[x, y + 1].type] && Main.tile[x, y + 1].slope() == 0 && !Main.tile[x, y + 1].halfBrick())
                            {
                                flag = false;
                                return flag;
                            }
                        }
                        if (Main.tile[x, y] != null)
                        {
                            continue;
                        }
                        Main.tile[x, y] = new Tile();
                    }
                    else
                    {
                        flag = true;
                        return flag;
                    }
                }
                while (Main.tile[x, y].inActive() || !Main.tile[x, y].active() || !Main.tileSolid[Main.tile[x, y].type] || Main.tileSolidTop[Main.tile[x, y].type]);
                flag = false;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }
		public static bool EmptyTile(int i, int j, bool ignoreTiles = false)
		{
			Rectangle rectangle = new Rectangle(i * 16, j * 16, 16, 16);
			if (Main.tile[i, j].active() && !ignoreTiles)
			{
				return false;
			}
			for (int k = 0; k < 255; k++)
			{
				if (Main.player[k].active && rectangle.Intersects(new Rectangle((int)Main.player[k].position.X, (int)Main.player[k].position.Y, Main.player[k].width, Main.player[k].height)))
				{
					return false;
				}
			}
			for (int l = 0; l < 200; l++)
			{
				if (Main.npc[l].active && rectangle.Intersects(new Rectangle((int)Main.npc[l].position.X, (int)Main.npc[l].position.Y, Main.npc[l].width, Main.npc[l].height)))
				{
					return false;
				}
			}
			return true;
		}
		public static bool DrownCollision(Vector2 Position, int Width, int Height, float gravDir = -1f)
		{
			Vector2 vector = new Vector2(Position.X + (float)(Width / 2), Position.Y + (float)(Height / 2));
			int num = 10;
			int num2 = 12;
			if (num > Width)
			{
				num = Width;
			}
			if (num2 > Height)
			{
				num2 = Height;
			}
			vector = new Vector2(vector.X - (float)(num / 2), Position.Y + -2f);
			if (gravDir == -1f)
			{
				vector.Y += (float)(Height / 2 - 6);
			}
			int num3 = (int)(Position.X / 16f) - 1;
			int num4 = (int)((Position.X + (float)Width) / 16f) + 2;
			int num5 = (int)(Position.Y / 16f) - 1;
			int num6 = (int)((Position.Y + (float)Height) / 16f) + 2;
			if (num3 < 0)
			{
				num3 = 0;
			}
			if (num4 > Main.maxTilesX)
			{
				num4 = Main.maxTilesX;
			}
			if (num5 < 0)
			{
				num5 = 0;
			}
			if (num6 > Main.maxTilesY)
			{
				num6 = Main.maxTilesY;
			}
			for (int i = num3; i < num4; i++)
			{
				for (int j = num5; j < num6; j++)
				{
					if (Main.tile[i, j] != null && Main.tile[i, j].liquid > 0 && !Main.tile[i, j].lava())
					{
						Vector2 vector2;
						vector2.X = (float)(i * 16);
						vector2.Y = (float)(j * 16);
						int num7 = 16;
						float num8 = (float)(256 - (int)Main.tile[i, j].liquid);
						num8 /= 32f;
						vector2.Y += num8 * 2f;
						num7 -= (int)(num8 * 2f);
						if (vector.X + (float)num > vector2.X && vector.X < vector2.X + 16f && vector.Y + (float)num2 > vector2.Y && vector.Y < vector2.Y + (float)num7)
						{
							return true;
						}
					}
				}
			}
			return false;
		}
		public static bool WetCollision(Vector2 Position, int Width, int Height)
		{
			Collision.honey = false;
			Vector2 vector = new Vector2(Position.X + (float)(Width / 2), Position.Y + (float)(Height / 2));
			int num = 10;
			int num2 = Height / 2;
			if (num > Width)
			{
				num = Width;
			}
			if (num2 > Height)
			{
				num2 = Height;
			}
			vector = new Vector2(vector.X - (float)(num / 2), vector.Y - (float)(num2 / 2));
			int num3 = (int)(Position.X / 16f) - 1;
			int num4 = (int)((Position.X + (float)Width) / 16f) + 2;
			int num5 = (int)(Position.Y / 16f) - 1;
			int num6 = (int)((Position.Y + (float)Height) / 16f) + 2;
			if (num3 < 0)
			{
				num3 = 0;
			}
			if (num4 > Main.maxTilesX)
			{
				num4 = Main.maxTilesX;
			}
			if (num5 < 0)
			{
				num5 = 0;
			}
			if (num6 > Main.maxTilesY)
			{
				num6 = Main.maxTilesY;
			}
			for (int i = num3; i < num4; i++)
			{
				for (int j = num5; j < num6; j++)
				{
					if (Main.tile[i, j] != null)
					{
						if (Main.tile[i, j].liquid > 0)
						{
							Vector2 vector2;
							vector2.X = (float)(i * 16);
							vector2.Y = (float)(j * 16);
							int num7 = 16;
							float num8 = (float)(256 - (int)Main.tile[i, j].liquid);
							num8 /= 32f;
							vector2.Y += num8 * 2f;
							num7 -= (int)(num8 * 2f);
							if (vector.X + (float)num > vector2.X && vector.X < vector2.X + 16f && vector.Y + (float)num2 > vector2.Y && vector.Y < vector2.Y + (float)num7)
							{
								if (Main.tile[i, j].honey())
								{
									Collision.honey = true;
								}
								return true;
							}
						}
						else
						{
							if (Main.tile[i, j].active() && Main.tile[i, j].slope() != 0 && Main.tile[i, j - 1].liquid > 0)
							{
								Vector2 vector2;
								vector2.X = (float)(i * 16);
								vector2.Y = (float)(j * 16);
								int num9 = 16;
								if (vector.X + (float)num > vector2.X && vector.X < vector2.X + 16f && vector.Y + (float)num2 > vector2.Y && vector.Y < vector2.Y + (float)num9)
								{
									if (Main.tile[i, j - 1].honey())
									{
										Collision.honey = true;
									}
									return true;
								}
							}
						}
					}
				}
			}
			return false;
		}
		public static bool LavaCollision(Vector2 Position, int Width, int Height)
		{
			int num = (int)(Position.X / 16f) - 1;
			int num2 = (int)((Position.X + (float)Width) / 16f) + 2;
			int num3 = (int)(Position.Y / 16f) - 1;
			int num4 = (int)((Position.Y + (float)Height) / 16f) + 2;
			if (num < 0)
			{
				num = 0;
			}
			if (num2 > Main.maxTilesX)
			{
				num2 = Main.maxTilesX;
			}
			if (num3 < 0)
			{
				num3 = 0;
			}
			if (num4 > Main.maxTilesY)
			{
				num4 = Main.maxTilesY;
			}
			for (int i = num; i < num2; i++)
			{
				for (int j = num3; j < num4; j++)
				{
					if (Main.tile[i, j] != null && Main.tile[i, j].liquid > 0 && Main.tile[i, j].lava())
					{
						Vector2 vector;
						vector.X = (float)(i * 16);
						vector.Y = (float)(j * 16);
						int num5 = 16;
						float num6 = (float)(256 - (int)Main.tile[i, j].liquid);
						num6 /= 32f;
						vector.Y += num6 * 2f;
						num5 -= (int)(num6 * 2f);
						if (Position.X + (float)Width > vector.X && Position.X < vector.X + 16f && Position.Y + (float)Height > vector.Y && Position.Y < vector.Y + (float)num5)
						{
							return true;
						}
					}
				}
			}
			return false;
		}
		public static Vector4 WalkDownSlope(Vector2 Position, Vector2 Velocity, int Width, int Height, float gravity = 0f)
		{
			if (Velocity.Y != gravity)
			{
				return new Vector4(Position, Velocity.X, Velocity.Y);
			}
			Vector2 vector = Position;
			int num = (int)(vector.X / 16f);
			int num2 = (int)((vector.X + (float)Width) / 16f);
			int num3 = (int)((Position.Y + (float)Height + 4f) / 16f);
			float num4 = (float)((num3 + 3) * 16);
			int num5 = 0;
			int num6 = 0;
			int num7 = 1;
			if (Velocity.X < 0f)
			{
				num7 = 2;
			}
			for (int i = num; i <= num2; i++)
			{
				for (int j = num3; j <= num3 + 1; j++)
				{
					if (Main.tile[i, j] == null)
					{
						Main.tile[i, j] = new Tile();
					}
					if (Main.tile[i, j].nactive() && (Main.tileSolid[(int)Main.tile[i, j].type] || Main.tileSolidTop[(int)Main.tile[i, j].type]))
					{
						int num8 = j * 16;
						if (Main.tile[i, j].halfBrick())
						{
							num8 += 8;
						}
						Rectangle rectangle = new Rectangle(i * 16, j * 16 - 17, 16, 16);
						if (rectangle.Intersects(new Rectangle((int)Position.X, (int)Position.Y, Width, Height)) && (float)num8 <= num4)
						{
							if (num4 == (float)num8)
							{
								if (Main.tile[i, j].slope() != 0)
								{
									if (Main.tile[num5, num6].slope() != 0)
									{
										if ((int)Main.tile[i, j].slope() == num7)
										{
											num4 = (float)num8;
											num5 = i;
											num6 = j;
										}
									}
									else
									{
										num4 = (float)num8;
										num5 = i;
										num6 = j;
									}
								}
							}
							else
							{
								num4 = (float)num8;
								num5 = i;
								num6 = j;
							}
						}
					}
				}
			}
			int num9 = num5;
			int num10 = num6;
			if (Main.tile[num9, num10] != null && Main.tile[num9, num10].slope() > 0)
			{
				int num11 = (int)Main.tile[num9, num10].slope();
				Vector2 vector2;
				vector2.X = (float)(num9 * 16);
				vector2.Y = (float)(num10 * 16);
				if (num11 == 2)
				{
					float num12 = vector2.X + 16f - (Position.X + (float)Width);
					if (Position.Y + (float)Height >= vector2.Y + num12 && Velocity.X < 0f)
					{
						Velocity.Y += Math.Abs(Velocity.X);
					}
				}
				else
				{
					if (num11 == 1)
					{
						float num12 = Position.X - vector2.X;
						if (Position.Y + (float)Height >= vector2.Y + num12 && Velocity.X > 0f)
						{
							Velocity.Y += Math.Abs(Velocity.X);
						}
					}
				}
			}
			return new Vector4(Position, Velocity.X, Velocity.Y);
		}
		public static Vector4 SlopeCollision_Yor(Vector2 Position, Vector2 Velocity, int Width, int Height, float gravity = 0f, bool fall = false)
		{
			Collision.stair = false;
			Collision.stairFall = false;
			bool[] array = new bool[5];
			float y = Position.Y;
			float y2 = Position.Y;
			Collision.sloping = false;
			Vector2 vector = Position;
			Vector2 vector2 = Position;
			Vector2 vector3 = Velocity;
			int num = (int)(Position.X / 16f) - 1;
			int num2 = (int)((Position.X + (float)Width) / 16f) + 2;
			int num3 = (int)(Position.Y / 16f) - 1;
			int num4 = (int)((Position.Y + (float)Height) / 16f) + 2;
			if (num < 0)
			{
				num = 0;
			}
			if (num2 > Main.maxTilesX)
			{
				num2 = Main.maxTilesX;
			}
			if (num3 < 0)
			{
				num3 = 0;
			}
			if (num4 > Main.maxTilesY)
			{
				num4 = Main.maxTilesY;
			}
			int num5 = 1;
			int num6 = 1;
			int num7 = num2;
			int num8 = num4;
			if (Velocity.X < 0f)
			{
				num5 = -1;
				num7 = num;
			}
			if (Velocity.Y < 0f)
			{
				num6 = -1;
				num8 = num3;
			}
			int num9 = (int)(Position.X + (float)(Width / 2)) / 16;
			int num10 = (int)(Position.Y + (float)(Height / 2)) / 16;
			for (int num11 = num9; num11 != num7; num11 += num5)
			{
				for (int i = num10; i < num8; i += num6)
				{
					if (Main.tile[num11, i] != null && Main.tile[num11, i].active() && !Main.tile[num11, i].inActive() && (Main.tileSolid[(int)Main.tile[num11, i].type] || (Main.tileSolidTop[(int)Main.tile[num11, i].type] && Main.tile[num11, i].frameY == 0)))
					{
						Vector2 vector4;
						vector4.X = (float)(num11 * 16);
						vector4.Y = (float)(i * 16);
						int num12 = 16;
						if (Main.tile[num11, i].halfBrick())
						{
							vector4.Y += 8f;
							num12 -= 8;
						}
						if (Position.X + (float)Width > vector4.X && Position.X < vector4.X + 16f && Position.Y + (float)Height > vector4.Y && Position.Y < vector4.Y + (float)num12)
						{
							bool flag = true;
							if (Main.tile[num11, i].slope() > 0)
							{
								if (Main.tile[num11, i].slope() > 2)
								{
									if (Main.tile[num11, i].slope() == 3 && vector.Y + Math.Abs(Velocity.X) + 1f >= vector4.Y && vector.X >= vector4.X)
									{
										flag = true;
									}
									if (Main.tile[num11, i].slope() == 4 && vector.Y + Math.Abs(Velocity.X) + 1f >= vector4.Y && vector.X + (float)Width <= vector4.X + 16f)
									{
										flag = true;
									}
								}
								else
								{
									if (Main.tile[num11, i].slope() == 1 && vector.Y + (float)Height - Math.Abs(Velocity.X) - 1f <= vector4.Y + (float)num12 && vector.X >= vector4.X)
									{
										flag = true;
									}
									if (Main.tile[num11, i].slope() == 2 && vector.Y + (float)Height - Math.Abs(Velocity.X) - 1f <= vector4.Y + (float)num12 && vector.X + (float)Width <= vector4.X + 16f)
									{
										flag = true;
									}
								}
							}
							if (Main.tile[num11, i].type == 19)
							{
								if (Velocity.Y < 0f)
								{
									flag = false;
								}
								if (Position.Y + (float)Height < (float)(i * 16) || Position.Y + (float)Height - (1f + Math.Abs(Velocity.X)) > (float)(i * 16 + 16))
								{
									flag = false;
								}
							}
							if (flag)
							{
								bool flag2 = false;
								if (fall && Main.tile[num11, i].type == 19)
								{
									flag2 = true;
								}
								int num13 = (int)Main.tile[num11, i].slope();
								vector4.X = (float)(num11 * 16);
								vector4.Y = (float)(i * 16);
								if (Position.X + (float)Width > vector4.X && Position.X < vector4.X + 16f && Position.Y + (float)Height > vector4.Y && Position.Y < vector4.Y + 16f)
								{
									float num14 = 0f;
									if (num13 == 3 || num13 == 4)
									{
										if (num13 == 3)
										{
											num14 = Position.X - vector4.X;
										}
										if (num13 == 4)
										{
											num14 = vector4.X + 16f - (Position.X + (float)Width);
										}
										if (num14 >= 0f)
										{
											if (Position.Y <= vector4.Y + 16f - num14)
											{
												float num15 = vector4.Y + 16f - vector.Y - num14;
												if (Position.Y + num15 > y2)
												{
													vector2.Y += num15;
													y2 = vector2.Y;
													if (vector3.Y < 0.0101f)
													{
														vector3.Y = 0.0101f;
													}
													array[num13] = true;
												}
											}
										}
										else
										{
											if (Position.Y > vector4.Y)
											{
												float num16 = vector4.Y + 16f;
												if (vector2.Y < num16)
												{
													vector2.Y = num16;
													if (vector3.Y < 0.0101f)
													{
														vector3.Y = 0.0101f;
													}
												}
											}
										}
									}
									if (num13 == 1 || num13 == 2)
									{
										if (num13 == 1)
										{
											num14 = Position.X - vector4.X;
										}
										if (num13 == 2)
										{
											num14 = vector4.X + 16f - (Position.X + (float)Width);
										}
										if (num14 >= 0f)
										{
											if (Position.Y + (float)Height >= vector4.Y + num14)
											{
												float num17 = vector4.Y - (vector.Y + (float)Height) + num14;
												if (Position.Y + num17 < y)
												{
													if (flag2)
													{
														Collision.stairFall = true;
													}
													else
													{
														if (Main.tile[num11, i].type == 19)
														{
															Collision.stair = true;
														}
														else
														{
															Collision.stair = false;
														}
														vector2.Y += num17;
														y = vector2.Y;
														if (vector3.Y > 0f)
														{
															vector3.Y = 0f;
														}
														array[num13] = true;
													}
												}
											}
										}
										else
										{
											if (Main.tile[num11, i].type == 19 && Position.Y + (float)Height - 4f - Math.Abs(Velocity.X) > vector4.Y)
											{
												if (flag2)
												{
													Collision.stairFall = true;
												}
											}
											else
											{
												float num18 = vector4.Y - (float)Height;
												if (vector2.Y > num18)
												{
													if (flag2)
													{
														Collision.stairFall = true;
													}
													else
													{
														if (Main.tile[num11, i].type == 19)
														{
															Collision.stair = true;
														}
														else
														{
															Collision.stair = false;
														}
														vector2.Y = num18;
														if (vector3.Y > 0f)
														{
															vector3.Y = 0f;
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
			Vector2 position = Position;
			Vector2 velocity = vector2 - Position;
			Vector2 vector5 = Collision.TileCollision(position, velocity, Width, Height, false, false, 1);
			if (vector5.Y > velocity.Y)
			{
				float num19 = velocity.Y - vector5.Y;
				vector2.Y = Position.Y + vector5.Y;
				if (array[1])
				{
					vector2.X = Position.X - num19;
				}
				if (array[2])
				{
					vector2.X = Position.X + num19;
				}
				vector3.X = 0f;
				vector3.Y = 0f;
				Collision.up = false;
			}
			else
			{
				if (vector5.Y < velocity.Y)
				{
					float num20 = vector5.Y - velocity.Y;
					vector2.Y = Position.Y + vector5.Y;
					if (array[3])
					{
						vector2.X = Position.X - num20;
					}
					if (array[4])
					{
						vector2.X = Position.X + num20;
					}
					vector3.X = 0f;
					vector3.Y = 0f;
				}
			}
			return new Vector4(vector2, vector3.X, vector3.Y);
		}
		public static Vector4 SlopeCollision(Vector2 Position, Vector2 Velocity, int Width, int Height, float gravity = 0f, bool fall = false)
		{
			Collision.stair = false;
			Collision.stairFall = false;
			bool[] array = new bool[5];
			float y = Position.Y;
			float y2 = Position.Y;
			Collision.sloping = false;
			Vector2 vector = Position;
			Vector2 vector2 = Position;
			Vector2 vector3 = Velocity;
			int num = (int)(Position.X / 16f) - 1;
			int num2 = (int)((Position.X + (float)Width) / 16f) + 2;
			int num3 = (int)(Position.Y / 16f) - 1;
			int num4 = (int)((Position.Y + (float)Height) / 16f) + 2;
			if (num < 0)
			{
				num = 0;
			}
			if (num2 > Main.maxTilesX)
			{
				num2 = Main.maxTilesX;
			}
			if (num3 < 0)
			{
				num3 = 0;
			}
			if (num4 > Main.maxTilesY)
			{
				num4 = Main.maxTilesY;
			}
			for (int i = num; i < num2; i++)
			{
				for (int j = num3; j < num4; j++)
				{
					if (Main.tile[i, j] != null && Main.tile[i, j].active() && !Main.tile[i, j].inActive() && (Main.tileSolid[(int)Main.tile[i, j].type] || (Main.tileSolidTop[(int)Main.tile[i, j].type] && Main.tile[i, j].frameY == 0)))
					{
						Vector2 vector4;
						vector4.X = (float)(i * 16);
						vector4.Y = (float)(j * 16);
						int num5 = 16;
						if (Main.tile[i, j].halfBrick())
						{
							vector4.Y += 8f;
							num5 -= 8;
						}
						if (Position.X + (float)Width > vector4.X && Position.X < vector4.X + 16f && Position.Y + (float)Height > vector4.Y && Position.Y < vector4.Y + (float)num5)
						{
							bool flag = true;
							if (Main.tile[i, j].slope() > 0)
							{
								if (Main.tile[i, j].slope() > 2)
								{
									if (Main.tile[i, j].slope() == 3 && vector.Y + Math.Abs(Velocity.X) + 1f >= vector4.Y && vector.X >= vector4.X)
									{
										flag = true;
									}
									if (Main.tile[i, j].slope() == 4 && vector.Y + Math.Abs(Velocity.X) + 1f >= vector4.Y && vector.X + (float)Width <= vector4.X + 16f)
									{
										flag = true;
									}
								}
								else
								{
									if (Main.tile[i, j].slope() == 1 && vector.Y + (float)Height - Math.Abs(Velocity.X) - 1f <= vector4.Y + (float)num5 && vector.X >= vector4.X)
									{
										flag = true;
									}
									if (Main.tile[i, j].slope() == 2 && vector.Y + (float)Height - Math.Abs(Velocity.X) - 1f <= vector4.Y + (float)num5 && vector.X + (float)Width <= vector4.X + 16f)
									{
										flag = true;
									}
								}
							}
							if (Main.tile[i, j].type == 19)
							{
								if (Velocity.Y < 0f)
								{
									flag = false;
								}
								if (Position.Y + (float)Height < (float)(j * 16) || Position.Y + (float)Height - (1f + Math.Abs(Velocity.X)) > (float)(j * 16 + 16))
								{
									flag = false;
								}
							}
							if (flag)
							{
								bool flag2 = false;
								if (fall && Main.tile[i, j].type == 19)
								{
									flag2 = true;
								}
								int num6 = (int)Main.tile[i, j].slope();
								vector4.X = (float)(i * 16);
								vector4.Y = (float)(j * 16);
								if (Position.X + (float)Width > vector4.X && Position.X < vector4.X + 16f && Position.Y + (float)Height > vector4.Y && Position.Y < vector4.Y + 16f)
								{
									float num7 = 0f;
									if (num6 == 3 || num6 == 4)
									{
										if (num6 == 3)
										{
											num7 = Position.X - vector4.X;
										}
										if (num6 == 4)
										{
											num7 = vector4.X + 16f - (Position.X + (float)Width);
										}
										if (num7 >= 0f)
										{
											if (Position.Y <= vector4.Y + 16f - num7)
											{
												float num8 = vector4.Y + 16f - vector.Y - num7;
												if (Position.Y + num8 > y2)
												{
													vector2.Y = Position.Y + num8;
													y2 = vector2.Y;
													if (vector3.Y < 0.0101f)
													{
														vector3.Y = 0.0101f;
													}
													array[num6] = true;
												}
											}
										}
										else
										{
											if (Position.Y > vector4.Y)
											{
												float num9 = vector4.Y + 16f;
												if (vector2.Y < num9)
												{
													vector2.Y = num9;
													if (vector3.Y < 0.0101f)
													{
														vector3.Y = 0.0101f;
													}
												}
											}
										}
									}
									if (num6 == 1 || num6 == 2)
									{
										if (num6 == 1)
										{
											num7 = Position.X - vector4.X;
										}
										if (num6 == 2)
										{
											num7 = vector4.X + 16f - (Position.X + (float)Width);
										}
										if (num7 >= 0f)
										{
											if (Position.Y + (float)Height >= vector4.Y + num7)
											{
												float num10 = vector4.Y - (vector.Y + (float)Height) + num7;
												if (Position.Y + num10 < y)
												{
													if (flag2)
													{
														Collision.stairFall = true;
													}
													else
													{
														if (Main.tile[i, j].type == 19)
														{
															Collision.stair = true;
														}
														else
														{
															Collision.stair = false;
														}
														vector2.Y = Position.Y + num10;
														y = vector2.Y;
														if (vector3.Y > 0f)
														{
															vector3.Y = 0f;
														}
														array[num6] = true;
													}
												}
											}
										}
										else
										{
											if (Main.tile[i, j].type == 19 && Position.Y + (float)Height - 4f - Math.Abs(Velocity.X) > vector4.Y)
											{
												if (flag2)
												{
													Collision.stairFall = true;
												}
											}
											else
											{
												float num11 = vector4.Y - (float)Height;
												if (vector2.Y > num11)
												{
													if (flag2)
													{
														Collision.stairFall = true;
													}
													else
													{
														if (Main.tile[i, j].type == 19)
														{
															Collision.stair = true;
														}
														else
														{
															Collision.stair = false;
														}
														vector2.Y = num11;
														if (vector3.Y > 0f)
														{
															vector3.Y = 0f;
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
			Vector2 position = Position;
			Vector2 velocity = vector2 - Position;
			Vector2 vector5 = Collision.TileCollision(position, velocity, Width, Height, false, false, 1);
			if (vector5.Y > velocity.Y)
			{
				float num12 = velocity.Y - vector5.Y;
				vector2.Y = Position.Y + vector5.Y;
				if (array[1])
				{
					vector2.X = Position.X - num12;
				}
				if (array[2])
				{
					vector2.X = Position.X + num12;
				}
				vector3.X = 0f;
				vector3.Y = 0f;
				Collision.up = false;
			}
			else
			{
				if (vector5.Y < velocity.Y)
				{
					float num13 = vector5.Y - velocity.Y;
					vector2.Y = Position.Y + vector5.Y;
					if (array[3])
					{
						vector2.X = Position.X - num13;
					}
					if (array[4])
					{
						vector2.X = Position.X + num13;
					}
					vector3.X = 0f;
					vector3.Y = 0f;
				}
			}
			return new Vector4(vector2, vector3.X, vector3.Y);
		}
		public static Vector2 noSlopeCollision(Vector2 Position, Vector2 Velocity, int Width, int Height, bool fallThrough = false, bool fall2 = false)
		{
			Collision.up = false;
			Collision.down = false;
			Vector2 result = Velocity;
			Vector2 vector = Velocity;
			Vector2 vector2 = Position + Velocity;
			Vector2 vector3 = Position;
			int num = (int)(Position.X / 16f) - 1;
			int num2 = (int)((Position.X + (float)Width) / 16f) + 2;
			int num3 = (int)(Position.Y / 16f) - 1;
			int num4 = (int)((Position.Y + (float)Height) / 16f) + 2;
			int num5 = -1;
			int num6 = -1;
			int num7 = -1;
			int num8 = -1;
			if (num < 0)
			{
				num = 0;
			}
			if (num2 > Main.maxTilesX)
			{
				num2 = Main.maxTilesX;
			}
			if (num3 < 0)
			{
				num3 = 0;
			}
			if (num4 > Main.maxTilesY)
			{
				num4 = Main.maxTilesY;
			}
			float num9 = (float)((num4 + 3) * 16);
			for (int i = num; i < num2; i++)
			{
				for (int j = num3; j < num4; j++)
				{
					if (Main.tile[i, j] != null && Main.tile[i, j].active() && (Main.tileSolid[(int)Main.tile[i, j].type] || (Main.tileSolidTop[(int)Main.tile[i, j].type] && Main.tile[i, j].frameY == 0)))
					{
						Vector2 vector4;
						vector4.X = (float)(i * 16);
						vector4.Y = (float)(j * 16);
						int num10 = 16;
						if (Main.tile[i, j].halfBrick())
						{
							vector4.Y += 8f;
							num10 -= 8;
						}
						if (vector2.X + (float)Width > vector4.X && vector2.X < vector4.X + 16f && vector2.Y + (float)Height > vector4.Y && vector2.Y < vector4.Y + (float)num10)
						{
							if (vector3.Y + (float)Height <= vector4.Y)
							{
								Collision.down = true;
								if ((!Main.tileSolidTop[(int)Main.tile[i, j].type] || !fallThrough || (Velocity.Y > 1f && !fall2)) && num9 > vector4.Y)
								{
									num7 = i;
									num8 = j;
									if (num10 < 16)
									{
										num8++;
									}
									if (num7 != num5)
									{
										result.Y = vector4.Y - (vector3.Y + (float)Height);
										num9 = vector4.Y;
									}
								}
							}
							else
							{
								if (vector3.X + (float)Width <= vector4.X && !Main.tileSolidTop[(int)Main.tile[i, j].type])
								{
									num5 = i;
									num6 = j;
									if (num6 != num8)
									{
										result.X = vector4.X - (vector3.X + (float)Width);
									}
									if (num7 == num5)
									{
										result.Y = vector.Y;
									}
								}
								else
								{
									if (vector3.X >= vector4.X + 16f && !Main.tileSolidTop[(int)Main.tile[i, j].type])
									{
										num5 = i;
										num6 = j;
										if (num6 != num8)
										{
											result.X = vector4.X + 16f - vector3.X;
										}
										if (num7 == num5)
										{
											result.Y = vector.Y;
										}
									}
									else
									{
										if (vector3.Y >= vector4.Y + (float)num10 && !Main.tileSolidTop[(int)Main.tile[i, j].type])
										{
											Collision.up = true;
											num7 = i;
											num8 = j;
											result.Y = vector4.Y + (float)num10 - vector3.Y + 0.01f;
											if (num8 == num6)
											{
												result.X = vector.X;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return result;
		}
		public static Vector2 TileCollision(Vector2 Position, Vector2 Velocity, int Width, int Height, bool fallThrough = false, bool fall2 = false, int gravDir = 1)
		{
			Collision.up = false;
			Collision.down = false;
			Vector2 result = Velocity;
			Vector2 vector = Velocity;
			Vector2 vector2 = Position + Velocity;
			Vector2 vector3 = Position;
			int num = (int)(Position.X / 16f) - 1;
			int num2 = (int)((Position.X + (float)Width) / 16f) + 2;
			int num3 = (int)(Position.Y / 16f) - 1;
			int num4 = (int)((Position.Y + (float)Height) / 16f) + 2;
			int num5 = -1;
			int num6 = -1;
			int num7 = -1;
			int num8 = -1;
			if (num < 0)
			{
				num = 0;
			}
			if (num2 > Main.maxTilesX)
			{
				num2 = Main.maxTilesX;
			}
			if (num3 < 0)
			{
				num3 = 0;
			}
			if (num4 > Main.maxTilesY)
			{
				num4 = Main.maxTilesY;
			}
			float num9 = (float)((num4 + 3) * 16);
			for (int i = num; i < num2; i++)
			{
				for (int j = num3; j < num4; j++)
				{
					if (Main.tile[i, j] != null && Main.tile[i, j].active() && !Main.tile[i, j].inActive() && (Main.tileSolid[(int)Main.tile[i, j].type] || (Main.tileSolidTop[(int)Main.tile[i, j].type] && Main.tile[i, j].frameY == 0)))
					{
						Vector2 vector4;
						vector4.X = (float)(i * 16);
						vector4.Y = (float)(j * 16);
						int num10 = 16;
						if (Main.tile[i, j].halfBrick())
						{
							vector4.Y += 8f;
							num10 -= 8;
						}
						if (vector2.X + (float)Width > vector4.X && vector2.X < vector4.X + 16f && vector2.Y + (float)Height > vector4.Y && vector2.Y < vector4.Y + (float)num10)
						{
							bool flag = false;
							bool flag2 = false;
							if (Main.tile[i, j].slope() > 2)
							{
								if (Main.tile[i, j].slope() == 3 && vector3.Y + Math.Abs(Velocity.X) >= vector4.Y && vector3.X >= vector4.X)
								{
									flag2 = true;
								}
								if (Main.tile[i, j].slope() == 4 && vector3.Y + Math.Abs(Velocity.X) >= vector4.Y && vector3.X + (float)Width <= vector4.X + 16f)
								{
									flag2 = true;
								}
							}
							else
							{
								if (Main.tile[i, j].slope() > 0)
								{
									flag = true;
									if (Main.tile[i, j].slope() == 1 && vector3.Y + (float)Height - Math.Abs(Velocity.X) <= vector4.Y + (float)num10 && vector3.X >= vector4.X)
									{
										flag2 = true;
									}
									if (Main.tile[i, j].slope() == 2 && vector3.Y + (float)Height - Math.Abs(Velocity.X) <= vector4.Y + (float)num10 && vector3.X + (float)Width <= vector4.X + 16f)
									{
										flag2 = true;
									}
								}
							}
							if (!flag2)
							{
								if (vector3.Y + (float)Height <= vector4.Y)
								{
									Collision.down = true;
									if ((!Main.tileSolidTop[(int)Main.tile[i, j].type] || !fallThrough || (Velocity.Y > 1f && !fall2)) && num9 > vector4.Y)
									{
										num7 = i;
										num8 = j;
										if (num10 < 16)
										{
											num8++;
										}
										if (num7 != num5 && !flag)
										{
											result.Y = vector4.Y - (vector3.Y + (float)Height) + ((gravDir == -1) ? -0.01f : 0f);
											num9 = vector4.Y;
										}
									}
								}
								else
								{
									if (vector3.X + (float)Width <= vector4.X && !Main.tileSolidTop[(int)Main.tile[i, j].type])
									{
										if (Main.tile[i - 1, j] == null)
										{
											Main.tile[i - 1, j] = new Tile();
										}
										if (Main.tile[i - 1, j].slope() != 2 && Main.tile[i - 1, j].slope() != 4)
										{
											num5 = i;
											num6 = j;
											if (num6 != num8)
											{
												result.X = vector4.X - (vector3.X + (float)Width);
											}
											if (num7 == num5)
											{
												result.Y = vector.Y;
											}
										}
									}
									else
									{
										if (vector3.X >= vector4.X + 16f && !Main.tileSolidTop[(int)Main.tile[i, j].type])
										{
											if (Main.tile[i + 1, j] == null)
											{
												Main.tile[i + 1, j] = new Tile();
											}
											if (Main.tile[i + 1, j].slope() != 1 && Main.tile[i + 1, j].slope() != 3)
											{
												num5 = i;
												num6 = j;
												if (num6 != num8)
												{
													result.X = vector4.X + 16f - vector3.X;
												}
												if (num7 == num5)
												{
													result.Y = vector.Y;
												}
											}
										}
										else
										{
											if (vector3.Y >= vector4.Y + (float)num10 && !Main.tileSolidTop[(int)Main.tile[i, j].type])
											{
												Collision.up = true;
												num7 = i;
												num8 = j;
												result.Y = vector4.Y + (float)num10 - vector3.Y + ((gravDir == 1) ? 0.01f : 0f);
												if (num8 == num6)
												{
													result.X = vector.X;
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
			return result;
		}
		public static bool SolidCollision(Vector2 Position, int Width, int Height)
		{
			int num = (int)(Position.X / 16f) - 1;
			int num2 = (int)((Position.X + (float)Width) / 16f) + 2;
			int num3 = (int)(Position.Y / 16f) - 1;
			int num4 = (int)((Position.Y + (float)Height) / 16f) + 2;
			if (num < 0)
			{
				num = 0;
			}
			if (num2 > Main.maxTilesX)
			{
				num2 = Main.maxTilesX;
			}
			if (num3 < 0)
			{
				num3 = 0;
			}
			if (num4 > Main.maxTilesY)
			{
				num4 = Main.maxTilesY;
			}
			for (int i = num; i < num2; i++)
			{
				for (int j = num3; j < num4; j++)
				{
					if (Main.tile[i, j] != null && !Main.tile[i, j].inActive() && Main.tile[i, j].active() && Main.tileSolid[(int)Main.tile[i, j].type] && !Main.tileSolidTop[(int)Main.tile[i, j].type])
					{
						Vector2 vector;
						vector.X = (float)(i * 16);
						vector.Y = (float)(j * 16);
						int num5 = 16;
						if (Main.tile[i, j].halfBrick())
						{
							vector.Y += 8f;
							num5 -= 8;
						}
						if (Position.X + (float)Width > vector.X && Position.X < vector.X + 16f && Position.Y + (float)Height > vector.Y && Position.Y < vector.Y + (float)num5)
						{
							return true;
						}
					}
				}
			}
			return false;
		}
		public static Vector2 WaterCollision(Vector2 Position, Vector2 Velocity, int Width, int Height, bool fallThrough = false, bool fall2 = false, bool lavaWalk = true)
		{
			Vector2 result = Velocity;
			Vector2 vector = Position + Velocity;
			Vector2 vector2 = Position;
			int num = (int)(Position.X / 16f) - 1;
			int num2 = (int)((Position.X + (float)Width) / 16f) + 2;
			int num3 = (int)(Position.Y / 16f) - 1;
			int num4 = (int)((Position.Y + (float)Height) / 16f) + 2;
			if (num < 0)
			{
				num = 0;
			}
			if (num2 > Main.maxTilesX)
			{
				num2 = Main.maxTilesX;
			}
			if (num3 < 0)
			{
				num3 = 0;
			}
			if (num4 > Main.maxTilesY)
			{
				num4 = Main.maxTilesY;
			}
			for (int i = num; i < num2; i++)
			{
				for (int j = num3; j < num4; j++)
				{
					if (Main.tile[i, j] != null && Main.tile[i, j].liquid > 0 && Main.tile[i, j - 1].liquid == 0 && (!Main.tile[i, j].lava() || lavaWalk))
					{
						int num5 = (int)(Main.tile[i, j].liquid / 32 * 2 + 2);
						Vector2 vector3;
						vector3.X = (float)(i * 16);
						vector3.Y = (float)(j * 16 + 16 - num5);
						if (vector.X + (float)Width > vector3.X && vector.X < vector3.X + 16f && vector.Y + (float)Height > vector3.Y && vector.Y < vector3.Y + (float)num5 && vector2.Y + (float)Height <= vector3.Y && !fallThrough)
						{
							result.Y = vector3.Y - (vector2.Y + (float)Height);
						}
					}
				}
			}
			return result;
		}
		public static Vector2 AnyCollision(Vector2 Position, Vector2 Velocity, int Width, int Height)
		{
			Vector2 result = Velocity;
			Vector2 vector = Velocity;
			Vector2 vector2 = Position + Velocity;
			Vector2 vector3 = Position;
			int num = (int)(Position.X / 16f) - 1;
			int num2 = (int)((Position.X + (float)Width) / 16f) + 2;
			int num3 = (int)(Position.Y / 16f) - 1;
			int num4 = (int)((Position.Y + (float)Height) / 16f) + 2;
			int num5 = -1;
			int num6 = -1;
			int num7 = -1;
			int num8 = -1;
			if (num < 0)
			{
				num = 0;
			}
			if (num2 > Main.maxTilesX)
			{
				num2 = Main.maxTilesX;
			}
			if (num3 < 0)
			{
				num3 = 0;
			}
			if (num4 > Main.maxTilesY)
			{
				num4 = Main.maxTilesY;
			}
			for (int i = num; i < num2; i++)
			{
				for (int j = num3; j < num4; j++)
				{
					if (Main.tile[i, j] != null && Main.tile[i, j].active() && !Main.tile[i, j].inActive())
					{
						Vector2 vector4;
						vector4.X = (float)(i * 16);
						vector4.Y = (float)(j * 16);
						int num9 = 16;
						if (Main.tile[i, j].halfBrick())
						{
							vector4.Y += 8f;
							num9 -= 8;
						}
						if (vector2.X + (float)Width > vector4.X && vector2.X < vector4.X + 16f && vector2.Y + (float)Height > vector4.Y && vector2.Y < vector4.Y + (float)num9)
						{
							if (vector3.Y + (float)Height <= vector4.Y)
							{
								num7 = i;
								num8 = j;
								if (num7 != num5)
								{
									result.Y = vector4.Y - (vector3.Y + (float)Height);
								}
							}
							else
							{
								if (vector3.X + (float)Width <= vector4.X && !Main.tileSolidTop[(int)Main.tile[i, j].type])
								{
									num5 = i;
									num6 = j;
									if (num6 != num8)
									{
										result.X = vector4.X - (vector3.X + (float)Width);
									}
									if (num7 == num5)
									{
										result.Y = vector.Y;
									}
								}
								else
								{
									if (vector3.X >= vector4.X + 16f && !Main.tileSolidTop[(int)Main.tile[i, j].type])
									{
										num5 = i;
										num6 = j;
										if (num6 != num8)
										{
											result.X = vector4.X + 16f - vector3.X;
										}
										if (num7 == num5)
										{
											result.Y = vector.Y;
										}
									}
									else
									{
										if (vector3.Y >= vector4.Y + (float)num9 && !Main.tileSolidTop[(int)Main.tile[i, j].type])
										{
											num7 = i;
											num8 = j;
											result.Y = vector4.Y + (float)num9 - vector3.Y + 0.01f;
											if (num8 == num6)
											{
												result.X = vector.X + 0.01f;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return result;
		}
		public static void HitTiles(Vector2 Position, Vector2 Velocity, int Width, int Height)
		{
			Vector2 vector = Position + Velocity;
			int num = (int)(Position.X / 16f) - 1;
			int num2 = (int)((Position.X + (float)Width) / 16f) + 2;
			int num3 = (int)(Position.Y / 16f) - 1;
			int num4 = (int)((Position.Y + (float)Height) / 16f) + 2;
			if (num < 0)
			{
				num = 0;
			}
			if (num2 > Main.maxTilesX)
			{
				num2 = Main.maxTilesX;
			}
			if (num3 < 0)
			{
				num3 = 0;
			}
			if (num4 > Main.maxTilesY)
			{
				num4 = Main.maxTilesY;
			}
			for (int i = num; i < num2; i++)
			{
				for (int j = num3; j < num4; j++)
				{
					if (Main.tile[i, j] != null && !Main.tile[i, j].inActive() && Main.tile[i, j].active() && (Main.tileSolid[(int)Main.tile[i, j].type] || (Main.tileSolidTop[(int)Main.tile[i, j].type] && Main.tile[i, j].frameY == 0)))
					{
						Vector2 vector2;
						vector2.X = (float)(i * 16);
						vector2.Y = (float)(j * 16);
						int num5 = 16;
						if (Main.tile[i, j].halfBrick())
						{
							vector2.Y += 8f;
							num5 -= 8;
						}
						if (vector.X + (float)Width >= vector2.X && vector.X <= vector2.X + 16f && vector.Y + (float)Height >= vector2.Y && vector.Y <= vector2.Y + (float)num5)
						{
							WorldGen.KillTile(i, j, true, true, false);
						}
					}
				}
			}
		}
		public static Vector2 HurtTiles(Vector2 Position, Vector2 Velocity, int Width, int Height, bool fireImmune = false)
		{
			Vector2 vector = Position;
			int num = (int)(Position.X / 16f) - 1;
			int num2 = (int)((Position.X + (float)Width) / 16f) + 2;
			int num3 = (int)(Position.Y / 16f) - 1;
			int num4 = (int)((Position.Y + (float)Height) / 16f) + 2;
			if (num < 0)
			{
				num = 0;
			}
			if (num2 > Main.maxTilesX)
			{
				num2 = Main.maxTilesX;
			}
			if (num3 < 0)
			{
				num3 = 0;
			}
			if (num4 > Main.maxTilesY)
			{
				num4 = Main.maxTilesY;
			}
			for (int i = num; i < num2; i++)
			{
				for (int j = num3; j < num4; j++)
				{
					if (Main.tile[i, j] != null && Main.tile[i, j].slope() == 0 && !Main.tile[i, j].inActive() && Main.tile[i, j].active() && (Main.tile[i, j].type == 32 || Main.tile[i, j].type == 37 || Main.tile[i, j].type == 48 || Main.tile[i, j].type == 232 || Main.tile[i, j].type == 53 || Main.tile[i, j].type == 57 || Main.tile[i, j].type == 58 || Main.tile[i, j].type == 69 || Main.tile[i, j].type == 76 || Main.tile[i, j].type == 112 || Main.tile[i, j].type == 116 || Main.tile[i, j].type == 123 || Main.tile[i, j].type == 224 || Main.tile[i, j].type == 234))
					{
						Vector2 vector2;
						vector2.X = (float)(i * 16);
						vector2.Y = (float)(j * 16);
						int num5 = 0;
						int type = (int)Main.tile[i, j].type;
						int num6 = 16;
						if (Main.tile[i, j].halfBrick())
						{
							vector2.Y += 8f;
							num6 -= 8;
						}
						if (type == 32 || type == 69 || type == 80)
						{
							if (vector.X + (float)Width > vector2.X && vector.X < vector2.X + 16f && vector.Y + (float)Height > vector2.Y && (double)vector.Y < (double)(vector2.Y + (float)num6) + 0.01)
							{
								int num7 = 1;
								if (vector.X + (float)(Width / 2) < vector2.X + 8f)
								{
									num7 = -1;
								}
								num5 = 10;
								if (type == 69)
								{
									num5 = 17;
								}
								else
								{
									if (type == 80)
									{
										num5 = 6;
									}
								}
								if (type == 32 || type == 69)
								{
									WorldGen.KillTile(i, j, false, false, false);
									if (Main.netMode == 1 && !Main.tile[i, j].active() && Main.netMode == 1)
									{
										NetMessage.SendData(17, -1, -1, "", 4, (float)i, (float)j, 0f, 0);
									}
								}
								return new Vector2((float)num7, (float)num5);
							}
						}
						else
						{
							if (type == 53 || type == 112 || type == 116 || type == 123 || type == 224 || type == 234)
							{
								if (vector.X + (float)Width - 2f >= vector2.X && vector.X + 2f <= vector2.X + 16f && vector.Y + (float)Height - 2f >= vector2.Y && vector.Y + 2f <= vector2.Y + (float)num6)
								{
									int num8 = 1;
									if (vector.X + (float)(Width / 2) < vector2.X + 8f)
									{
										num8 = -1;
									}
									num5 = 15;
									return new Vector2((float)num8, (float)num5);
								}
							}
							else
							{
								if (vector.X + (float)Width >= vector2.X && vector.X <= vector2.X + 16f && vector.Y + (float)Height >= vector2.Y && (double)vector.Y <= (double)(vector2.Y + (float)num6) + 0.01)
								{
									int num9 = 1;
									if (vector.X + (float)(Width / 2) < vector2.X + 8f)
									{
										num9 = -1;
									}
									if (!fireImmune && (type == 37 || type == 58 || type == 76))
									{
										num5 = 20;
									}
									if (type == 48)
									{
										num5 = 40;
									}
									if (type == 232)
									{
										num5 = 60;
									}
									return new Vector2((float)num9, (float)num5);
								}
							}
						}
					}
				}
			}
			return default(Vector2);
		}
		public static bool SwitchTiles(Vector2 Position, int Width, int Height, Vector2 oldPosition, int objType)
		{
			int num = (int)(Position.X / 16f) - 1;
			int num2 = (int)((Position.X + (float)Width) / 16f) + 2;
			int num3 = (int)(Position.Y / 16f) - 1;
			int num4 = (int)((Position.Y + (float)Height) / 16f) + 2;
			if (num < 0)
			{
				num = 0;
			}
			if (num2 > Main.maxTilesX)
			{
				num2 = Main.maxTilesX;
			}
			if (num3 < 0)
			{
				num3 = 0;
			}
			if (num4 > Main.maxTilesY)
			{
				num4 = Main.maxTilesY;
			}
			for (int i = num; i < num2; i++)
			{
				for (int j = num3; j < num4; j++)
				{
					if (Main.tile[i, j] != null && Main.tile[i, j].active() && (Main.tile[i, j].type == 135 || Main.tile[i, j].type == 210))
					{
						Vector2 vector;
						vector.X = (float)(i * 16);
						vector.Y = (float)(j * 16 + 12);
						if (Position.X + (float)Width > vector.X && Position.X < vector.X + 16f && Position.Y + (float)Height > vector.Y && (double)Position.Y < (double)vector.Y + 4.01)
						{
							if (Main.tile[i, j].type == 210)
							{
								WorldGen.ExplodeMine(i, j);
							}
							else
							{
								if (oldPosition.X + (float)Width <= vector.X || oldPosition.X >= vector.X + 16f || oldPosition.Y + (float)Height <= vector.Y || (double)oldPosition.Y >= (double)vector.Y + 16.01)
								{
									int num5 = (int)(Main.tile[i, j].frameY / 18);
									bool flag = true;
									if ((num5 == 4 || num5 == 2 || num5 == 3 || num5 == 6) && objType != 1)
									{
										flag = false;
									}
									if (num5 == 5 && objType == 1)
									{
										flag = false;
									}
									if (flag)
									{
										WorldGen.hitSwitch(i, j);
										NetMessage.SendData(59, -1, -1, "", i, (float)j, 0f, 0f, 0);
										return true;
									}
								}
							}
						}
					}
				}
			}
			return false;
		}
		public static Vector2 StickyTiles(Vector2 Position, Vector2 Velocity, int Width, int Height)
		{
			Vector2 vector = Position;
			int num = (int)(Position.X / 16f) - 1;
			int num2 = (int)((Position.X + (float)Width) / 16f) + 2;
			int num3 = (int)(Position.Y / 16f) - 1;
			int num4 = (int)((Position.Y + (float)Height) / 16f) + 2;
			if (num < 0)
			{
				num = 0;
			}
			if (num2 > Main.maxTilesX)
			{
				num2 = Main.maxTilesX;
			}
			if (num3 < 0)
			{
				num3 = 0;
			}
			if (num4 > Main.maxTilesY)
			{
				num4 = Main.maxTilesY;
			}
			for (int i = num; i < num2; i++)
			{
				for (int j = num3; j < num4; j++)
				{
					if (Main.tile[i, j] != null && Main.tile[i, j].active() && !Main.tile[i, j].inActive())
					{
						if (Main.tile[i, j].type == 51)
						{
							int num5 = 0;
							Vector2 vector2;
							vector2.X = (float)(i * 16);
							vector2.Y = (float)(j * 16);
							if (vector.X + (float)Width > vector2.X - (float)num5 && vector.X < vector2.X + 16f + (float)num5 && vector.Y + (float)Height > vector2.Y && (double)vector.Y < (double)vector2.Y + 16.01)
							{
								if (Main.tile[i, j].type == 51 && (double)(Math.Abs(Velocity.X) + Math.Abs(Velocity.Y)) > 0.7 && Main.rand.Next(30) == 0)
								{
									Dust.NewDust(new Vector2((float)(i * 16), (float)(j * 16)), 16, 16, 30, 0f, 0f, 0, default(Color), 1f);
								}
								return new Vector2((float)i, (float)j);
							}
						}
						else
						{
							if (Main.tile[i, j].type == 229 && Main.tile[i, j].slope() == 0)
							{
								int num6 = 1;
								Vector2 vector2;
								vector2.X = (float)(i * 16);
								vector2.Y = (float)(j * 16);
								float num7 = 16.01f;
								if (Main.tile[i, j].halfBrick())
								{
									vector2.Y += 8f;
									num7 -= 8f;
								}
								if (vector.X + (float)Width > vector2.X - (float)num6 && vector.X < vector2.X + 16f + (float)num6 && vector.Y + (float)Height > vector2.Y && vector.Y < vector2.Y + num7)
								{
									if (Main.tile[i, j].type == 51 && (double)(Math.Abs(Velocity.X) + Math.Abs(Velocity.Y)) > 0.7 && Main.rand.Next(30) == 0)
									{
										Dust.NewDust(new Vector2((float)(i * 16), (float)(j * 16)), 16, 16, 30, 0f, 0f, 0, default(Color), 1f);
									}
									return new Vector2((float)i, (float)j);
								}
							}
						}
					}
				}
			}
			return new Vector2(-1f, -1f);
		}
		public static bool SolidTiles(int startX, int endX, int startY, int endY)
		{
			if (startX < 0)
			{
				return true;
			}
			if (endX >= Main.maxTilesX)
			{
				return true;
			}
			if (startY < 0)
			{
				return true;
			}
			if (endY >= Main.maxTilesY)
			{
				return true;
			}
			for (int i = startX; i < endX + 1; i++)
			{
				for (int j = startY; j < endY + 1; j++)
				{
					if (Main.tile[i, j] == null)
					{
						return false;
					}
					if (Main.tile[i, j].active() && !Main.tile[i, j].inActive() && Main.tileSolid[(int)Main.tile[i, j].type] && !Main.tileSolidTop[(int)Main.tile[i, j].type])
					{
						return true;
					}
				}
			}
			return false;
		}
		public static void StepUp(ref Vector2 position, ref Vector2 velocity, int width, int height, ref float stepSpeed, ref float gfxOffY, int gravDir = 1, bool holdsMatching = false)
		{
			int num = 0;
			if (velocity.X < 0f)
			{
				num = -1;
			}
			if (velocity.X > 0f)
			{
				num = 1;
			}
			Vector2 vector = position;
			vector.X += velocity.X;
			int num2 = (int)((vector.X + (float)(width / 2) + (float)((width / 2 + 1) * num)) / 16f);
			int num3 = (int)(((double)vector.Y + 0.1) / 16.0);
			if (gravDir == 1)
			{
				num3 = (int)((vector.Y + (float)height - 1f) / 16f);
			}
			int num4 = height / 16 + ((height % 16 == 0) ? 0 : 1);
			bool flag = true;
			bool flag2 = true;
			if (Main.tile[num2, num3] == null)
			{
				Main.tile[num2, num3] = new Tile();
			}
			for (int i = 1; i < num4 + 2; i++)
			{
				if (num3 - i > 0 && Main.tile[num2, num3 - i * gravDir] == null)
				{
					Main.tile[num2, num3 + i] = new Tile();
				}
			}
			if (num3 - num4 > 0 && Main.tile[num2 - num, num3 - num4 * gravDir] == null)
			{
				Main.tile[num2 - num, num3 - num4 * gravDir] = new Tile();
			}
			Tile tile;
			for (int j = 2; j < num4 + 1; j++)
			{
				tile = Main.tile[num2, num3 - j * gravDir];
				flag = (flag && (!tile.nactive() || !Main.tileSolid[(int)tile.type] || Main.tileSolidTop[(int)tile.type]));
			}
			tile = Main.tile[num2 - num, num3 - num4 * gravDir];
			flag2 = (flag2 && (!tile.nactive() || !Main.tileSolid[(int)tile.type] || Main.tileSolidTop[(int)tile.type]));
			bool flag3 = true;
			bool flag4 = true;
			if (gravDir == 1)
			{
				tile = Main.tile[num2, num3 - gravDir];
				Tile tile2 = Main.tile[num2, num3 - (num4 + 1) * gravDir];
				flag3 = (flag3 && (!tile.nactive() || !Main.tileSolid[(int)tile.type] || Main.tileSolidTop[(int)tile.type] || (tile.slope() == 1 && position.X + (float)(width / 2) > (float)(num2 * 16)) || (tile.slope() == 2 && position.X + (float)(width / 2) < (float)(num2 * 16 + 16)) || (tile.halfBrick() && (!tile2.nactive() || !Main.tileSolid[(int)tile2.type] || Main.tileSolidTop[(int)tile2.type]))));
				tile = Main.tile[num2, num3];
				tile2 = Main.tile[num2, num3 - 1];
				flag4 = (flag4 && ((tile.nactive() && (!tile.topSlope() || (tile.slope() == 1 && position.X + (float)(width / 2) < (float)(num2 * 16)) || (tile.slope() == 2 && position.X + (float)(width / 2) > (float)(num2 * 16 + 16))) && (!tile.topSlope() || position.Y + (float)height > (float)(num3 * 16)) && ((Main.tileSolid[(int)tile.type] && !Main.tileSolidTop[(int)tile.type]) || (holdsMatching && ((Main.tileSolidTop[(int)tile.type] && tile.frameY == 0) || tile.type == 19) && (!Main.tileSolid[(int)tile2.type] || !tile2.nactive())))) || (tile2.halfBrick() && tile2.nactive())));
			}
			else
			{
				tile = Main.tile[num2, num3 - gravDir];
				Tile tile2 = Main.tile[num2, num3 - (num4 + 1) * gravDir];
				flag3 = (flag3 && (!tile.nactive() || !Main.tileSolid[(int)tile.type] || Main.tileSolidTop[(int)tile.type] || tile.slope() != 0 || (tile.halfBrick() && (!tile2.nactive() || !Main.tileSolid[(int)tile2.type] || Main.tileSolidTop[(int)tile2.type]))));
				tile = Main.tile[num2, num3];
				tile2 = Main.tile[num2, num3 + 1];
				flag4 = (flag4 && ((tile.nactive() && ((Main.tileSolid[(int)tile.type] && !Main.tileSolidTop[(int)tile.type]) || (holdsMatching && Main.tileSolidTop[(int)tile.type] && tile.frameY == 0 && (!Main.tileSolid[(int)tile2.type] || !tile2.nactive())))) || (tile2.halfBrick() && tile2.nactive())));
			}
			if ((float)(num2 * 16) < vector.X + (float)width && (float)(num2 * 16 + 16) > vector.X)
			{
				if (gravDir == 1)
				{
					if (flag4 && flag3 && flag && flag2)
					{
						float num5 = (float)(num3 * 16);
						if (Main.tile[num2, num3].halfBrick())
						{
							num5 += 8f;
						}
						if (Main.tile[num2, num3 - 1].halfBrick())
						{
							num5 -= 8f;
						}
						if (num5 < vector.Y + (float)height)
						{
							float num6 = vector.Y + (float)height - num5;
							if ((double)num6 <= 16.1)
							{
								gfxOffY += position.Y + (float)height - num5;
								position.Y = num5 - (float)height;
								if (num6 < 9f)
								{
									stepSpeed = 1f;
									return;
								}
								stepSpeed = 2f;
								return;
							}
						}
					}
				}
				else
				{
					if (flag4 && flag3 && flag && flag2 && !Main.tile[num2, num3].bottomSlope())
					{
						float num7 = (float)(num3 * 16 + 16);
						if (num7 > vector.Y)
						{
							float num8 = num7 - vector.Y;
							if ((double)num8 <= 16.1)
							{
								gfxOffY -= num7 - position.Y;
								position.Y = num7;
								velocity.Y = 0f;
								if (num8 < 9f)
								{
									stepSpeed = 1f;
									return;
								}
								stepSpeed = 2f;
							}
						}
					}
				}
			}
		}
	}
}
