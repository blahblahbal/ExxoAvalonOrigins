using System.Net.NetworkInformation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoMod.Cil;
using ReLogic.Graphics;
using Terraria;
using Terraria.UI;

namespace ExxoAvalonOrigins.Hooks
{
    public class ExtraHealth
    {
        public static void OnDrawInterface_Resources_Life(On.Terraria.Main.orig_DrawInterface_Resources_Life orig)
        {
	        if (Main.player[Main.myPlayer].statLifeMax <= 500)
            {
                orig();
            }
            else
            {
			float heartLife = 20f;
			int sX = Main.screenWidth - 800;
			if (Main.LocalPlayer.ghost)
			{
				return;
			}
			int num = Main.player[Main.myPlayer].statLifeMax / 20;
			int num2 = (Main.player[Main.myPlayer].statLifeMax - 400) / 5;
			int num3 = (Main.player[Main.myPlayer].statLifeMax - 500) / 5;
			if (num2 < 0)
			{
				num2 = 0;
			}
			if (num3 < 0)
			{
				num3 = 0;
			}
			if (num2 > 0)
			{
				num = Main.player[Main.myPlayer].statLifeMax / (20 + num2 / 4);
				heartLife = (float)Main.player[Main.myPlayer].statLifeMax / 20f;
			}
			if (num3 > 0)
			{
				num = Main.player[Main.myPlayer].statLifeMax / (20 + num2 / 4);
				heartLife = (float)Main.player[Main.myPlayer].statLifeMax / 20f;
			}
			int num4 = Main.player[Main.myPlayer].statLifeMax2 - Main.player[Main.myPlayer].statLifeMax;
			heartLife += (float)(num4 / num);
			int num5 = (int)((float)Main.player[Main.myPlayer].statLifeMax2 / heartLife);
			if (num5 >= 10)
			{
				num5 = 10;
			}
			string text = string.Concat(new object[]
			{
				Lang.inter[0],
				" ",
				Main.player[Main.myPlayer].statLifeMax2,
				"/",
				Main.player[Main.myPlayer].statLifeMax2
			});
			Vector2 vector = Main.fontMouseText.MeasureString(text);
			if (!Main.player[Main.myPlayer].ghost)
			{
				DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, Main.fontMouseText, Lang.inter[0].Value, new Vector2((float)(500 + 13 * num5) - vector.X * 0.5f + (float)sX, 6f), new Microsoft.Xna.Framework.Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor), 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
				Main.spriteBatch.DrawString(Main.fontMouseText, Main.player[Main.myPlayer].statLife + "/" + Main.player[Main.myPlayer].statLifeMax2, new Vector2((float)(500 + 13 * num5) + vector.X * 0.5f + (float)sX, 6f), new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor), 0f, new Vector2(Main.fontMouseText.MeasureString(Main.player[Main.myPlayer].statLife + "/" + Main.player[Main.myPlayer].statLifeMax2).X, 0f), 1f, SpriteEffects.None, 0f);
			}
			for (int i = 1; i < (int)((float)Main.player[Main.myPlayer].statLifeMax2 / heartLife) + 1; i++)
			{
				float num6 = 1f;
				bool flag = false;
				int num7;
				if ((float)Main.player[Main.myPlayer].statLife >= (float)i * heartLife)
				{
					num7 = 255;
					if ((float)Main.player[Main.myPlayer].statLife == (float)i * heartLife)
					{
						flag = true;
					}
				}
				else
				{
					float num8 = ((float)Main.player[Main.myPlayer].statLife - (float)(i - 1) * heartLife) / heartLife;
					num7 = (int)(30f + 225f * num8);
					if (num7 < 30)
					{
						num7 = 30;
					}
					num6 = num8 / 4f + 0.75f;
					if ((double)num6 < 0.75)
					{
						num6 = 0.75f;
					}
					if (num8 > 0f)
					{
						flag = true;
					}
				}
				if (flag)
				{
					num6 += Main.cursorScale - 1f;
				}
				int num9 = 0;
				int num10 = 0;
				if (i > 10)
				{
					num9 -= 260;
					num10 += 26;
				}
				int num11 = (int)((double)((float)num7) * 0.9);
				if (!Main.player[Main.myPlayer].ghost)
				{
					if (num3 > 0)
					{
						num3--;
						Main.spriteBatch.Draw(ExxoAvalonOrigins.heart3Texture, new Vector2((float)(500 + 26 * (i - 1) + num9 + sX + Main.heartTexture.Width / 2), 32f + ((float)Main.heartTexture.Height - (float)Main.heartTexture.Height * num6) / 2f + (float)num10 + (float)(Main.heartTexture.Height / 2)), new Rectangle?(new Rectangle(0, 0, Main.heartTexture.Width, Main.heartTexture.Height)), new Color(num7, num7, num7, num11), 0f, new Vector2((float)(Main.heartTexture.Width / 2), (float)(Main.heartTexture.Height / 2)), num6, SpriteEffects.None, 0f);
					}
					else if (num2 > 0)
					{
						num2--;
						Main.spriteBatch.Draw(Main.heart2Texture, new Vector2((float)(500 + 26 * (i - 1) + num9 + sX + Main.heartTexture.Width / 2), 32f + ((float)Main.heartTexture.Height - (float)Main.heartTexture.Height * num6) / 2f + (float)num10 + (float)(Main.heartTexture.Height / 2)), new Rectangle?(new Rectangle(0, 0, Main.heartTexture.Width, Main.heartTexture.Height)), new Color(num7, num7, num7, num11), 0f, new Vector2((float)(Main.heartTexture.Width / 2), (float)(Main.heartTexture.Height / 2)), num6, SpriteEffects.None, 0f);
					}
					else
					{
						Main.spriteBatch.Draw(Main.heartTexture, new Vector2((float)(500 + 26 * (i - 1) + num9 + sX + Main.heartTexture.Width / 2), 32f + ((float)Main.heartTexture.Height - (float)Main.heartTexture.Height * num6) / 2f + (float)num10 + (float)(Main.heartTexture.Height / 2)), new Rectangle?(new Rectangle(0, 0, Main.heartTexture.Width, Main.heartTexture.Height)), new Color(num7, num7, num7, num11), 0f, new Vector2((float)(Main.heartTexture.Width / 2), (float)(Main.heartTexture.Height / 2)), num6, SpriteEffects.None, 0f);
					}
				}
			}
            }
        }

        public static void OnDrawInterface_Resources_Mana(On.Terraria.Main.orig_DrawInterface_Resources_Mana orig)
        {
			int starMana = 20;
			int sX = Main.screenWidth - 800;
			if (Main.player[Main.myPlayer].statManaMax2 > 0)
			{
				//int arg_6FC_0 = Main.player[Main.myPlayer].statManaMax2 / 20;
				int num12 = (Main.player[Main.myPlayer].statManaMax2 - 200) / 20;
				int num13 = (Main.player[Main.myPlayer].statManaMax2 - 400) / 20;
				int num14 = (Main.player[Main.myPlayer].statManaMax2 - 600) / 20;
				int num15 = (Main.player[Main.myPlayer].statManaMax2 - 800) / 20;
				int num16 = (Main.player[Main.myPlayer].statManaMax2 - 1000) / 20;
				DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, Main.fontMouseText, Lang.inter[2].Value, new Vector2((float)(750 + sX), 6f), new Microsoft.Xna.Framework.Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor), 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
				if (num12 < 0)
				{
					num12 = 0;
				}
				if (num13 < 0)
				{
					num13 = 0;
				}
				if (num14 < 0)
				{
					num14 = 0;
				}
				if (num15 < 0)
				{
					num15 = 0;
				}
				if (num16 < 0)
				{
					num16 = 0;
				}
				if (num12 > 0)
				{
					//int arg_828_0 = Main.player[Main.myPlayer].statManaMax2 / (10 + num12 / 8);
					starMana = Main.player[Main.myPlayer].statManaMax2 / 10;
				}
				if (num13 > 0)
				{
					//int arg_85E_0 = Main.player[Main.myPlayer].statManaMax2 / (10 + num13 / 8);
					starMana = Main.player[Main.myPlayer].statManaMax2 / 10;
				}
				if (num14 > 0)
				{
					//int arg_894_0 = Main.player[Main.myPlayer].statManaMax2 / (10 + num14 / 8);
					starMana = Main.player[Main.myPlayer].statManaMax2 / 10;
				}
				if (num15 > 0)
				{
					//int arg_8CA_0 = Main.player[Main.myPlayer].statManaMax2 / (10 + num15 / 8);
					starMana = Main.player[Main.myPlayer].statManaMax2 / 10;
				}
				if (num16 > 0)
				{
					//int arg_900_0 = Main.player[Main.myPlayer].statManaMax2 / (10 + num16 / 8);
					starMana = Main.player[Main.myPlayer].statManaMax2 / 10;
				}
				for (int j = 1; j < Main.player[Main.myPlayer].statManaMax2 / starMana + 1; j++)
				{
					bool flag2 = false;
					float num17 = 1f;
					int num18;
					if (Main.player[Main.myPlayer].statMana >= j * starMana)
					{
						num18 = 255;
						if (Main.player[Main.myPlayer].statMana == j * starMana)
						{
							flag2 = true;
						}
					}
					else
					{
						float num19 = (float)(Main.player[Main.myPlayer].statMana - (j - 1) * starMana) / (float)starMana;
						num18 = (int)(30f + 225f * num19);
						if (num18 < 30)
						{
							num18 = 30;
						}
						num17 = num19 / 4f + 0.75f;
						if ((double)num17 < 0.75)
						{
							num17 = 0.75f;
						}
						if (num19 > 0f)
						{
							flag2 = true;
						}
					}
					if (flag2)
					{
						num17 += Main.cursorScale - 1f;
					}
					int num20 = (int)((double)((float)num18) * 0.9);
					if (num16 > 0)
					{
						num16--;
						Main.spriteBatch.Draw(ExxoAvalonOrigins.mana6Texture, new Vector2((float)(775 + sX), (float)(30 + Main.manaTexture.Height / 2) + ((float)Main.manaTexture.Height - (float)Main.manaTexture.Height * num17) / 2f + (float)(28 * (j - 1))), new Rectangle?(new Rectangle(0, 0, Main.manaTexture.Width, Main.manaTexture.Height)), new Color(num18, num18, num18, num20), 0f, new Vector2((float)(Main.manaTexture.Width / 2), (float)(Main.manaTexture.Height / 2)), num17, SpriteEffects.None, 0f);
					}
					else if (num15 > 0)
					{
						num15--;
						Main.spriteBatch.Draw(ExxoAvalonOrigins.mana5Texture, new Vector2((float)(775 + sX), (float)(30 + Main.manaTexture.Height / 2) + ((float)Main.manaTexture.Height - (float)Main.manaTexture.Height * num17) / 2f + (float)(28 * (j - 1))), new Rectangle?(new Rectangle(0, 0, Main.manaTexture.Width, Main.manaTexture.Height)), new Color(num18, num18, num18, num20), 0f, new Vector2((float)(Main.manaTexture.Width / 2), (float)(Main.manaTexture.Height / 2)), num17, SpriteEffects.None, 0f);
					}
					else if (num14 > 0)
					{
						num14--;
						Main.spriteBatch.Draw(ExxoAvalonOrigins.mana4Texture, new Vector2((float)(775 + sX), (float)(30 + Main.manaTexture.Height / 2) + ((float)Main.manaTexture.Height - (float)Main.manaTexture.Height * num17) / 2f + (float)(28 * (j - 1))), new Rectangle?(new Rectangle(0, 0, Main.manaTexture.Width, Main.manaTexture.Height)), new Color(num18, num18, num18, num20), 0f, new Vector2((float)(Main.manaTexture.Width / 2), (float)(Main.manaTexture.Height / 2)), num17, SpriteEffects.None, 0f);
					}
					else if (num13 > 0)
					{
						num13--;
						Main.spriteBatch.Draw(ExxoAvalonOrigins.mana3Texture, new Vector2((float)(775 + sX), (float)(30 + Main.manaTexture.Height / 2) + ((float)Main.manaTexture.Height - (float)Main.manaTexture.Height * num17) / 2f + (float)(28 * (j - 1))), new Rectangle?(new Rectangle(0, 0, Main.manaTexture.Width, Main.manaTexture.Height)), new Color(num18, num18, num18, num20), 0f, new Vector2((float)(Main.manaTexture.Width / 2), (float)(Main.manaTexture.Height / 2)), num17, SpriteEffects.None, 0f);
					}
					else if (num12 > 0)
					{
						num12--;
						Main.spriteBatch.Draw(ExxoAvalonOrigins.mana2Texture, new Vector2((float)(775 + sX), (float)(30 + Main.manaTexture.Height / 2) + ((float)Main.manaTexture.Height - (float)Main.manaTexture.Height * num17) / 2f + (float)(28 * (j - 1))), new Rectangle?(new Rectangle(0, 0, Main.manaTexture.Width, Main.manaTexture.Height)), new Color(num18, num18, num18, num20), 0f, new Vector2((float)(Main.manaTexture.Width / 2), (float)(Main.manaTexture.Height / 2)), num17, SpriteEffects.None, 0f);
					}
					else
					{
						Main.spriteBatch.Draw(Main.manaTexture, new Vector2((float)(775 + sX), (float)(30 + Main.manaTexture.Height / 2) + ((float)Main.manaTexture.Height - (float)Main.manaTexture.Height * num17) / 2f + (float)(28 * (j - 1))), new Rectangle?(new Rectangle(0, 0, Main.manaTexture.Width, Main.manaTexture.Height)), new Color(num18, num18, num18, num20), 0f, new Vector2((float)(Main.manaTexture.Width / 2), (float)(Main.manaTexture.Height / 2)), num17, SpriteEffects.None, 0f);
					}
				}
			}
			DrawStaminaBar();
        }

		public static void ILUpdate(ILContext il)
        {
			var c = new ILCursor(il);

			// Move il cursor into positon
			if (!c.TryGotoNext(i => i.MatchLdloca(67)))
				return;
			if (!c.TryGotoNext(i => i.MatchLdfld<Player>("statManaMax2")))
				return;
			if (!c.TryGotoNext(i => i.MatchLdarg(0)))
				return;

			c.RemoveRange(3);
		}

        private static void DrawStaminaBar()
        {
			ExxoAvalonOrigins.barStamina = 20;
			if (Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().statStamMax2 > 0)
			{
				int num21 = Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().statStamMax / 20;
				int num22 = Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().statStamMax2 - Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().statStamMax;
				ExxoAvalonOrigins.barStamina += num22 / num21;
				int num23 = (int)((float)Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().statStamMax2 / (float)ExxoAvalonOrigins.barStamina);
				if (num23 >= 15)
				{
				}
				for (int k = 1; k < (int)((float)Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().statStamMax2 / (float)ExxoAvalonOrigins.barStamina) + 1; k++)
				{
					float num24 = 1f;
					bool flag3 = false;
					int num25;
					if ((float)Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().statStam >= (float)k * (float)ExxoAvalonOrigins.barStamina)
					{
						num25 = 255;
						if ((float)Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().statStam == (float)k * (float)ExxoAvalonOrigins.barStamina)
						{
							flag3 = true;
						}
					}
					else
					{
						float num26 = ((float)Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().statStam - (float)(k - 1) * (float)ExxoAvalonOrigins.barStamina) / (float)ExxoAvalonOrigins.barStamina;
						num25 = (int)(30f + 225f * num26);
						if (num25 < 30)
						{
							num25 = 30;
						}
						num24 = num26 / 4f + 0.75f;
						if ((double)num24 < 0.75)
						{
							num24 = 0.75f;
						}
						if (num26 > 0f)
						{
							flag3 = true;
						}
					}
					if (flag3)
					{
						num24 += Main.cursorScale - 1f;
					}
					int num27 = 0;
					int num28 = 0;
					int num29 = (int)((double)((float)num25) * 0.9);
					if (!Main.player[Main.myPlayer].ghost && ExxoAvalonOrigins.subInterface)
					{
						Main.spriteBatch.Draw(ExxoAvalonOrigins.stamTexture, new Vector2((float)(50 + 26 * (k - 1) + num27 + ExxoAvalonOrigins.sX + ExxoAvalonOrigins.stamTexture.Width / 2), (float)(Main.screenHeight - 75) + ((float)ExxoAvalonOrigins.stamTexture.Height - (float)ExxoAvalonOrigins.stamTexture.Height * num24) / 2f + (float)num28 + (float)(ExxoAvalonOrigins.stamTexture.Height / 2)), new Rectangle?(new Rectangle(0, 0, ExxoAvalonOrigins.stamTexture.Width, ExxoAvalonOrigins.stamTexture.Height)), new Color(num25, num25, num25, num29), 0f, new Vector2((float)(ExxoAvalonOrigins.stamTexture.Width / 2), (float)(ExxoAvalonOrigins.stamTexture.Height / 2)), num24, SpriteEffects.None, 0f);
					}
				}
			}
        }
    }
}