using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ExxoAvalonOrigins.Items;

namespace ExxoAvalonOrigins.Hooks
{
    class TrapCollision
    {
		public static Vector2 OnHurtTiles(On.Terraria.Collision.orig_HurtTiles orig, Vector2 Position,
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
					if (Main.tile[i, j] != null && Main.tile[i, j].slope() == 0 && !Main.tile[i, j].inActive() && Main.tile[i, j].active() && (Main.tile[i, j].type == ModContent.TileType<Tiles.PoisonSpike>() || Main.tile[i, j].type == ModContent.TileType<Tiles.VenomSpike>() || Main.tile[i, j].type == TileID.Spikes || Main.tile[i, j].type == TileID.WoodenSpikes))
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
							if ((!Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().HasItemInArmor(ModContent.ItemType<BlahsWings>()) && !Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().HasItemInArmor(ModContent.ItemType<GuardianBoots>()) && !Main.player[Main.myPlayer].HasBuff(ModContent.BuffType<Buffs.Blah>())) &&
								!Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().HasItemInArmor(ModContent.ItemType<PalladiumShield>()) && !Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().HasItemInArmor(ModContent.ItemType<CobaltOmegaShield>()) && !Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().HasItemInArmor(ModContent.ItemType<PalladiumOmegaShield>()) && !Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().HasItemInArmor(ModContent.ItemType<DurataniumOmegaShield>()) && type == TileID.Spikes)
							{
								num5 = 40;
							}
							if ((!Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().HasItemInArmor(ModContent.ItemType<BlahsWings>()) && !Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().HasItemInArmor(ModContent.ItemType<GuardianBoots>()) && !Main.player[Main.myPlayer].HasBuff(ModContent.BuffType<Buffs.Blah>())) &&
								!Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().HasItemInArmor(ModContent.ItemType<PalladiumShield>()) && !Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().HasItemInArmor(ModContent.ItemType<CobaltOmegaShield>()) && !Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().HasItemInArmor(ModContent.ItemType<PalladiumOmegaShield>()) && !Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().HasItemInArmor(ModContent.ItemType<DurataniumOmegaShield>()) && type == TileID.WoodenSpikes)
							{
								num5 = 60;
							}
							if ((!Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().HasItemInArmor(ModContent.ItemType<BlahsWings>()) && !Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().HasItemInArmor(ModContent.ItemType<GuardianBoots>()) && !Main.player[Main.myPlayer].HasBuff(ModContent.BuffType<Buffs.Blah>())) &&
								!Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().HasItemInArmor(ModContent.ItemType<PalladiumShield>()) && !Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().HasItemInArmor(ModContent.ItemType<CobaltOmegaShield>()) && !Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().HasItemInArmor(ModContent.ItemType<PalladiumOmegaShield>()) && !Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().HasItemInArmor(ModContent.ItemType<DurataniumOmegaShield>()) && (type == ModContent.TileType<Tiles.PyroscoricOre>() || type == ModContent.TileType<Tiles.TritanoriumOre>()))
							{
								num5 = 30 + Main.player[Main.myPlayer].statDefense / 2;
							}
							if ((!Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().HasItemInArmor(ModContent.ItemType<BlahsWings>()) && !Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().HasItemInArmor(ModContent.ItemType<GuardianBoots>()) && !Main.player[Main.myPlayer].HasBuff(ModContent.BuffType<Buffs.Blah>())) &&
								!Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().HasItemInArmor(ModContent.ItemType<PalladiumShield>()) && !Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().HasItemInArmor(ModContent.ItemType<CobaltOmegaShield>()) && !Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().HasItemInArmor(ModContent.ItemType<PalladiumOmegaShield>()) && !Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().HasItemInArmor(ModContent.ItemType<DurataniumOmegaShield>()) && type == ModContent.TileType<Tiles.PoisonSpike>())
							{
								num5 = 35;
								Main.player[Main.myPlayer].AddBuff(BuffID.Poisoned, 180, true);
							}
							if (/*!Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().trapImmune*/(!Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().HasItemInArmor(ModContent.ItemType<BlahsWings>()) && !Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().HasItemInArmor(ModContent.ItemType<GuardianBoots>()) && !Main.player[Main.myPlayer].HasBuff(ModContent.BuffType<Buffs.Blah>())) &&
								!Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().HasItemInArmor(ModContent.ItemType<PalladiumShield>()) && !Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().HasItemInArmor(ModContent.ItemType<CobaltOmegaShield>()) && !Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().HasItemInArmor(ModContent.ItemType<PalladiumOmegaShield>()) && !Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().HasItemInArmor(ModContent.ItemType<DurataniumOmegaShield>()) && type == ModContent.TileType<Tiles.VenomSpike>())
							{
								num5 = 45;
								Main.player[Main.myPlayer].AddBuff(BuffID.Venom, 180, true);
							}
							return new Vector2((float)num9, (float)num5);
						}
					}
				}
			}
			return output;
		}
	}
}
