using ExxoAvalonOrigins.Items;
using ExxoAvalonOrigins.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BloodiedSpike = ExxoAvalonOrigins.Tiles.BloodiedSpike;
using NastySpike = ExxoAvalonOrigins.Tiles.NastySpike;
using PoisonSpike = ExxoAvalonOrigins.Tiles.PoisonSpike;

namespace ExxoAvalonOrigins
{
    public class ExxoAvalonOriginsCollisions
    {
        public static Vector2 HurtExtraTiles(On.Terraria.Collision.orig_HurtTiles orig, Vector2 Position,
            Vector2 Velocity, int Width, int Height, bool fireImmune = false)
        {
            Vector2 output = orig(Position, Velocity, Width, Height, fireImmune);
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
					if (Main.tile[i, j] != null && Main.tile[i, j].slope() == 0 && !Main.tile[i, j].inActive() && Main.tile[i, j].active() && Main.tile[i, j].type == ModContent.TileType<PoisonSpike>())
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
							if (!Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().trapImmune && !Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().HasItemInArmor(ModContent.ItemType<PalladiumShield>()) && !Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().HasItemInArmor(ModContent.ItemType<CobaltOmegaShield>()) && !Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().HasItemInArmor(ModContent.ItemType<PalladiumOmegaShield>()) && !Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().HasItemInArmor(ModContent.ItemType<DurataniumOmegaShield>()) && type == ModContent.TileType<PoisonSpike>())
							{
								num5 = 35;
								Main.player[Main.myPlayer].AddBuff(BuffID.Poisoned, 180, true);
							}
							return new Vector2((float)num9, (float)num5);
						}
					}
				}
			}
			return default(Vector2);
        }

		public static bool SpikeCollision(Vector2 Position, int Width, int Height)
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
					if ((Main.tile[i, j] != null && !Main.tile[i, j].inActive() && Main.tile[i, j].active() && Main.tileSolid[(int)Main.tile[i, j].type] && !Main.tileSolidTop[(int)Main.tile[i, j].type] && Main.tile[i, j].type == ModContent.TileType<DemonSpikescale>()) || Main.tile[i, j].type == ModContent.TileType<BloodiedSpike>())
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

		public static bool SpikeCollision2(Vector2 Position, int Width, int Height)
		{
			int num = (int)((Position.X - 2f) / 16f);
			int num2 = (int)((Position.X + (float)Width) / 16f);
			int num3 = (int)((Position.Y - 2f) / 16f);
			int num4 = (int)((Position.Y + (float)Height) / 16f);
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
			for (int i = num; i <= num2; i++)
			{
				for (int j = num3; j <= num4; j++)
				{
					if (Main.tile[i, j] != null && Main.tile[i, j].active() && (Main.tile[i, j].type == ModContent.TileType<DemonSpikescale>() || Main.tile[i, j].type == ModContent.TileType<BloodiedSpike>() || Main.tile[i, j].type == ModContent.TileType<NastySpike>()))
					{
						return true;
					}
				}
			}
			return false;
		}
    }
}