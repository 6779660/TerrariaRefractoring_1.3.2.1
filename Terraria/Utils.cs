using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
namespace Terraria
{
	public static class Utils
	{
		public static Dictionary<SpriteFont, float[]> charLengths = new Dictionary<SpriteFont, float[]>();
		public static bool FloatIntersect(float r1StartX, float r1StartY, float r1Width, float r1Height, float r2StartX, float r2StartY, float r2Width, float r2Height)
		{
			return r1StartX <= r2StartX + r2Width && r1StartY <= r2StartY + r2Height && r1StartX + r1Width >= r2StartX && r1StartY + r1Height >= r2StartY;
		}
		public static string[] WordwrapString(string inputString, SpriteFont font, int maxWidth, int maxLines, out int lines)
		{
			string[] array = new string[maxLines];
			int num = 0;
			inputString += ' ';
			if (!Utils.charLengths.ContainsKey(font))
			{
				float[] array2 = new float[256];
				for (int i = 0; i < 256; i++)
				{
					array2[i] = font.MeasureString(string.Concat((char)i)).X;
				}
				Utils.charLengths.Add(font, array2);
			}
			byte[] bytes = Encoding.ASCII.GetBytes(inputString);
			StringBuilder stringBuilder = new StringBuilder();
			StringBuilder stringBuilder2 = new StringBuilder();
			float num2 = 0f;
			bool flag = true;
			for (int j = 0; j < bytes.Length; j++)
			{
				if (bytes[j] == 10)
				{
					num++;
					if (num == maxLines)
					{
						break;
					}
					stringBuilder.Append(stringBuilder2);
					stringBuilder2.Clear();
					stringBuilder.Append('\n');
					num2 = 0f;
					flag = true;
				}
				else
				{
					float num3 = Utils.charLengths[font][(int)bytes[j]];
					if (num2 + num3 >= (float)(maxWidth - 20))
					{
						if (!flag)
						{
							num++;
							if (num == maxLines)
							{
								break;
							}
							stringBuilder.Append('\n');
							stringBuilder.Append(stringBuilder2);
							stringBuilder.Append((char)bytes[j]);
							stringBuilder2.Clear();
							num2 = 0f;
							flag = true;
						}
						else
						{
							stringBuilder.Append(stringBuilder2);
							stringBuilder.Append('-');
							num++;
							if (num == maxLines)
							{
								break;
							}
							stringBuilder2.Clear();
							stringBuilder2.Append('\n');
							stringBuilder2.Append((char)bytes[j]);
							num2 = num3;
							flag = true;
						}
					}
					else
					{
						stringBuilder2.Append((char)bytes[j]);
						if (bytes[j] == 32)
						{
							stringBuilder.Append(stringBuilder2);
							stringBuilder2.Clear();
							flag = false;
						}
						num2 += num3;
					}
				}
			}
			stringBuilder.Remove(stringBuilder.Length - 1, 1);
			array = stringBuilder.ToString().Split(new char[]
			{
				'\n'
			});
			int k = array.Length;
			Array.Resize<string>(ref array, maxLines);
			while (k < maxLines)
			{
				array[k++] = "";
			}
			lines = Math.Min(num, maxLines - 1);
			return array;
		}
		public static string[] ConstrainStringSolsund(string inputString, SpriteFont font, int maxWidth, int maxLines, out int lines)
		{
			string[] array = new string[maxLines];
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < inputString.Length; i++)
			{
				byte[] bytes = Encoding.ASCII.GetBytes(inputString.Substring(i, 1));
				if (bytes[0] == 10)
				{
					if (font.MeasureString(inputString.Substring(num2, i - num2)).X > (float)maxWidth)
					{
						array[num] = inputString.Substring(num2, num3 - num2);
						num++;
						num2 = num3 + 1;
					}
					array[num] = inputString.Substring(num2, i - num2);
					num++;
					num2 = i + 1;
					num3 = i + 1;
				}
				else
				{
					if (inputString.Substring(i, 1) == " " || i == inputString.Length - 1)
					{
						if (font.MeasureString(inputString.Substring(num2, i - num2)).X > (float)maxWidth)
						{
							array[num] = inputString.Substring(num2, num3 - num2);
							num++;
							num2 = num3 + 1;
						}
						num3 = i;
					}
				}
				if (num == maxLines)
				{
					inputString = inputString.Substring(0, i - 1);
					num2 = i - 1;
					num = maxLines - 1;
					break;
				}
			}
			if (num < maxLines)
			{
				array[num] = inputString.Substring(num2, inputString.Length - num2);
			}
			lines = num;
			return array;
		}
		public static void DrawBorderStringFourWay(SpriteBatch sb, SpriteFont font, string text, float x, float y, Color textColor, Color borderColor, Vector2 origin, float scale = 1f)
		{
			Color color = borderColor;
			Vector2 zero = Vector2.Zero;
			int i = 0;
			while (i < 5)
			{
				switch (i)
				{
				case 0:
					zero.X = x - 2f;
					zero.Y = y;
					break;
				case 1:
					zero.X = x + 2f;
					zero.Y = y;
					break;
				case 2:
					zero.X = x;
					zero.Y = y - 2f;
					break;
				case 3:
					zero.X = x;
					zero.Y = y + 2f;
					break;
				case 4:
					goto IL_92;
				default:
					goto IL_92;
				}
				IL_A6:
				sb.DrawString(font, text, zero, color, 0f, origin, scale, SpriteEffects.None, 0f);
				i++;
				continue;
				IL_92:
				zero.X = x;
				zero.Y = y;
				color = textColor;
				goto IL_A6;
			}
		}
		public static Vector2 DrawBorderString(SpriteBatch sb, string text, Vector2 pos, Color color, float scale = 1f, float anchorx = 0f, float anchory = 0f, int stringLimit = -1)
		{
			if (stringLimit != -1 && text.Length > stringLimit)
			{
				text.Substring(0, stringLimit);
			}
			SpriteFont fontMouseText = Main.fontMouseText;
			for (int i = -1; i < 2; i++)
			{
				for (int j = -1; j < 2; j++)
				{
					sb.DrawString(fontMouseText, text, pos + new Vector2((float)i, (float)j) * 1f, Color.Black, 0f, new Vector2(anchorx, anchory) * fontMouseText.MeasureString(text), scale, SpriteEffects.None, 0f);
				}
			}
			sb.DrawString(fontMouseText, text, pos, color, 0f, new Vector2(anchorx, anchory) * fontMouseText.MeasureString(text), scale, SpriteEffects.None, 0f);
			return fontMouseText.MeasureString(text) * scale;
		}
		public static Vector2 DrawBorderStringBig(SpriteBatch sb, string text, Vector2 pos, Color color, float scale = 1f, float anchorx = 0f, float anchory = 0f, int stringLimit = -1)
		{
			if (stringLimit != -1 && text.Length > stringLimit)
			{
				text.Substring(0, stringLimit);
			}
			SpriteFont fontDeathText = Main.fontDeathText;
			for (int i = -1; i < 2; i++)
			{
				for (int j = -1; j < 2; j++)
				{
					sb.DrawString(fontDeathText, text, pos + new Vector2((float)i, (float)j) * 1f, Color.Black, 0f, new Vector2(anchorx, anchory) * fontDeathText.MeasureString(text), scale, SpriteEffects.None, 0f);
				}
			}
			sb.DrawString(fontDeathText, text, pos, color, 0f, new Vector2(anchorx, anchory) * fontDeathText.MeasureString(text), scale, SpriteEffects.None, 0f);
			return fontDeathText.MeasureString(text) * scale;
		}
		public static void DrawInvBG(SpriteBatch sb, Rectangle R, Color c = default(Color))
		{
			Utils.DrawInvBG(sb, R.X, R.Y, R.Width, R.Height, c);
		}
		public static void DrawInvBG(SpriteBatch sb, float x, float y, float w, float h, Color c = default(Color))
		{
			Utils.DrawInvBG(sb, (int)x, (int)y, (int)w, (int)h, c);
		}
		public static void DrawInvBG(SpriteBatch sb, int x, int y, int w, int h, Color c = default(Color))
		{
			if (c == default(Color))
			{
				c = new Color(63, 65, 151, 255) * 0.785f;
			}
			Texture2D inventoryBack13Texture = Main.inventoryBack13Texture;
			if (w < 20)
			{
				w = 20;
			}
			if (h < 20)
			{
				h = 20;
			}
			sb.Draw(inventoryBack13Texture, new Rectangle(x, y, 10, 10), new Rectangle?(new Rectangle(0, 0, 10, 10)), c);
			sb.Draw(inventoryBack13Texture, new Rectangle(x + 10, y, w - 20, 10), new Rectangle?(new Rectangle(10, 0, 10, 10)), c);
			sb.Draw(inventoryBack13Texture, new Rectangle(x + w - 10, y, 10, 10), new Rectangle?(new Rectangle(inventoryBack13Texture.Width - 10, 0, 10, 10)), c);
			sb.Draw(inventoryBack13Texture, new Rectangle(x, y + 10, 10, h - 20), new Rectangle?(new Rectangle(0, 10, 10, 10)), c);
			sb.Draw(inventoryBack13Texture, new Rectangle(x + 10, y + 10, w - 20, h - 20), new Rectangle?(new Rectangle(10, 10, 10, 10)), c);
			sb.Draw(inventoryBack13Texture, new Rectangle(x + w - 10, y + 10, 10, h - 20), new Rectangle?(new Rectangle(inventoryBack13Texture.Width - 10, 10, 10, 10)), c);
			sb.Draw(inventoryBack13Texture, new Rectangle(x, y + h - 10, 10, 10), new Rectangle?(new Rectangle(0, inventoryBack13Texture.Height - 10, 10, 10)), c);
			sb.Draw(inventoryBack13Texture, new Rectangle(x + 10, y + h - 10, w - 20, 10), new Rectangle?(new Rectangle(10, inventoryBack13Texture.Height - 10, 10, 10)), c);
			sb.Draw(inventoryBack13Texture, new Rectangle(x + w - 10, y + h - 10, 10, 10), new Rectangle?(new Rectangle(inventoryBack13Texture.Width - 10, inventoryBack13Texture.Height - 10, 10, 10)), c);
		}
	}
}
