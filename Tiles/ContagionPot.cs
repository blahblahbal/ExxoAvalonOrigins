using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ExxoAvalonOrigins.Tiles
{
	public class ContagionPot : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileLavaDeath[Type] = true;
			Main.tileWaterDeath[Type] = false;
			Main.tileValue[Type] = 100;
			Main.tileSpelunker[Type] = true;
			Main.tileCut[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Pot");
			AddMapEntry(new Color(33, 38, 97), name);
			dustType = 29;
			soundType = 13;
		}
	
		public override bool CreateDust(int i, int j, ref int type)
		{
			return false;
		}

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            _ = j - Main.tile[i, j].frameY / 18;
            _ = i - Main.tile[i, j].frameX / 18;
            Main.PlaySound(4, i * 16, j * 16, 1);
            Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, 22, 0f, 0f, 0, default, 1f);
            //Gore.NewGore(new Vector2((float)(i * 16), (float)(j * 16)), default(Vector2), base.mod.GetGoreSlot("Gores/DepthsPotGore1"));
            //Gore.NewGore(new Vector2((float)(i * 16), (float)(j * 16)), default(Vector2), base.mod.GetGoreSlot("Gores/DepthsPotGore2"));
            //Gore.NewGore(new Vector2((float)(i * 16), (float)(j * 16)), default(Vector2), base.mod.GetGoreSlot("Gores/DepthsPotGore3"));
            if (!WorldGen.gen && Main.netMode != 1)
            {
                if (WorldGen.genRand.Next(15) == 0)
                {
                    if (j < Main.worldSurface)
                    {
                        int num6 = WorldGen.genRand.Next(8);
                        if (num6 == 0)
                        {
                            if (Main.hardMode && WorldGen.genRand.Next(2) == 0)
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, ItemID.SummoningPotion, 1, false, 0, false);
                            }
                            else Item.NewItem(i * 16, j * 16, 16, 16, 292, 1, false, 0, false);
                        }
                        if (num6 == 1)
                        {
                            if (Main.hardMode && WorldGen.genRand.Next(2) == 0)
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, ModContent.ItemType<Items.Potions.CrimsonPotion>(), 1, false, 0, false);
                            }
                            else Item.NewItem(i * 16, j * 16, 16, 16, 298, 1, false, 0, false);
                        }
                        if (num6 == 2)
                        {
                            if (Main.hardMode && WorldGen.genRand.Next(2) == 0)
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, ItemID.AmmoReservationPotion, 1, false, 0, false);
                            }
                            else Item.NewItem(i * 16, j * 16, 16, 16, 299, 1, false, 0, false);
                        }
                        if (num6 == 3)
                        {
                            if (Main.hardMode && WorldGen.genRand.Next(2) == 0)
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, ModContent.ItemType<Items.Potions.ShockwavePotion>(), 1, false, 0, false);
                            }
                            else Item.NewItem(i * 16, j * 16, 16, 16, 290, 1, false, 0, false);
                        }
                        if (num6 == 4)
                        {
                            if (Main.hardMode && WorldGen.genRand.Next(2) == 0)
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, ModContent.ItemType<Items.Potions.TimeShiftPotion>(), 1, false, 0, false);
                            }
                            else Item.NewItem(i * 16, j * 16, 16, 16, 2322, 1, false, 0, false);
                        }
                        if (num6 == 5)
                        {
                            Item.NewItem(i * 16, j * 16, 16, 16, 2324, 1, false, 0, false);
                        }
                        if (num6 == 6)
                        {
                            Item.NewItem(i * 16, j * 16, 16, 16, 2325, 1, false, 0, false);
                        }
                        if (num6 == 7)
                        {
                            Item.NewItem(i * 16, j * 16, 16, 16, 2350, 1, false, 0, false);
                        }
                    }
                    else if ((double)j < Main.rockLayer)
                    {
                        int num7 = WorldGen.genRand.Next(10);
                        if (num7 == 0)
                        {
                            if (WorldGen.genRand.Next(2) == 0)
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, ModContent.ItemType<Items.Potions.ShockwavePotion>(), 1, false, 0, false);
                            }
                            else Item.NewItem(i * 16, j * 16, 16, 16, 289, 1, false, 0, false);
                        }
                        if (num7 == 1)
                        {
                            if (WorldGen.genRand.Next(2) == 0)
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, ModContent.ItemType<Items.Potions.CrimsonPotion>(), 1, false, 0, false);
                            }
                            else Item.NewItem(i * 16, j * 16, 16, 16, 298, 1, false, 0, false);
                        }
                        if (num7 == 2)
                        {
                            if (Main.hardMode && WorldGen.genRand.Next(2) == 0)
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, ModContent.ItemType<Items.Potions.BloodCastPotion>(), 1, false, 0, false);
                            }
                            else Item.NewItem(i * 16, j * 16, 16, 16, 299, 1, false, 0, false);
                        }
                        if (num7 == 3)
                        {
                            if (Main.hardMode && WorldGen.genRand.Next(2) == 0)
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, ModContent.ItemType<Items.Potions.LuckPotion>(), 1, false, 0, false);
                            }
                            else Item.NewItem(i * 16, j * 16, 16, 16, 290, 1, false, 0, false);
                        }
                        if (num7 == 4)
                        {
                            if (Main.hardMode && WorldGen.genRand.Next(2) == 0)
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, ItemID.AmmoReservationPotion, 1, false, 0, false);
                            }
                            else Item.NewItem(i * 16, j * 16, 16, 16, 303, 1, false, 0, false);
                        }
                        if (num7 == 5)
                        {
                            if (WorldGen.genRand.Next(2) == 0)
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, ItemID.WrathPotion, 1, false, 0, false);
                            }
                            else Item.NewItem(i * 16, j * 16, 16, 16, 291, 1, false, 0, false);
                        }
                        if (num7 == 6)
                        {
                            if (WorldGen.genRand.Next(2) == 0)
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, ModContent.ItemType<Items.Potions.GPSPotion>(), 1, false, 0, false);
                            }
                            else Item.NewItem(i * 16, j * 16, 16, 16, 304, 1, false, 0, false);
                        }
                        if (num7 == 7)
                        {
                            Item.NewItem(i * 16, j * 16, 16, 16, 2322, 1, false, 0, false);
                        }
                        if (num7 == 8)
                        {
                            Item.NewItem(i * 16, j * 16, 16, 16, 2329, 1, false, 0, false);
                        }
                        if (num7 == 9)
                        {
                            Item.NewItem(i * 16, j * 16, 16, 16, 2350, 1, false, 0, false);
                        }
                    }
                }
                else
                {
                    int num10 = Main.rand.Next(9);
                    if (num10 == 0 && Main.player[Player.FindClosest(new Vector2(i * 16, j * 16), 16, 16)].statLife < Main.player[Player.FindClosest(new Vector2(i * 16, j * 16), 16, 16)].statLifeMax2)
                    {
                        Item.NewItem(i * 16, j * 16, 16, 16, 58, 1, false, 0, false);
                    }
                    else if (num10 == 1 && Main.player[Player.FindClosest(new Vector2(i * 16, j * 16), 16, 16)].statMana < Main.player[Player.FindClosest(new Vector2(i * 16, j * 16), 16, 16)].statManaMax2)
                    {
                        Item.NewItem(i * 16, j * 16, 16, 16, 184, 1, false, 0, false);
                    }
                    else if (num10 == 2)
                    {
                        int stack = Main.rand.Next(1, 6);
                        if (Main.tile[i, j].liquid > 0)
                        {
                            Item.NewItem(i * 16, j * 16, 16, 16, 282, stack, false, 0, false);
                        }
                        else
                        {
                            Item.NewItem(i * 16, j * 16, 16, 16, 8, stack, false, 0, false);
                        }
                    }
                    else if (num10 == 3)
                    {
                        int stack2 = Main.rand.Next(8) + 3;
                        int type2 = 40;
                        if (j < Main.rockLayer && WorldGen.genRand.Next(2) == 0)
                        {
                            if (Main.hardMode)
                            {
                                type2 = ItemID.Grenade;
                            }
                            else
                            {
                                type2 = ItemID.Shuriken;
                            }
                        }
                        if (Main.hardMode)
                        {
                            if (Main.rand.Next(2) == 0)
                            {
                                if (WorldGen.silverBar == ItemID.TungstenBar)
                                {
                                    type2 = ModContent.ItemType<Items.Ammo.TungstenBullet>();
                                }
                                else if (WorldGen.silverBar == ModContent.ItemType<Items.Placeable.Bar.ZincBar>())
                                {
                                    type2 = ModContent.ItemType<Items.Ammo.TungstenBullet>();
                                }
                                else type2 = ItemID.SilverBullet;
                            }
                            else
                            {
                                if (!WorldGen.crimson && !ExxoAvalonOriginsWorld.contagion) type2 = ItemID.UnholyArrow;
                                else if (WorldGen.crimson) type2 = ModContent.ItemType<Items.Ammo.BloodyArrow>();
                                else if (ExxoAvalonOriginsWorld.contagion) type2 = ModContent.ItemType<Items.Ammo.BloodyArrow>(); // contagion arrow
                            }
                        }
                        Item.NewItem(i * 16, j * 16, 16, 16, type2, stack2, false, 0, false);
                    }
                    else if (num10 == 4)
                    {
                        int type3 = ItemID.LesserHealingPotion;
                        if (ModContent.GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode && j > Main.rockLayer && Main.rand.Next(2) == 0)
                        {
                            type3 = ItemID.GreaterHealingPotion;
                        }
                        else if (j > Main.maxTilesY - 200 || (Main.hardMode && !ModContent.GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode))
                        {
                            type3 = ItemID.HealingPotion;
                        }
                        Item.NewItem(i * 16, j * 16, 16, 16, type3, 1, false, 0, false);
                    }
                    else if (num10 == 5 && j > Main.rockLayer)
                    {
                        int stack3 = Main.rand.Next(4) + 1;
                        Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Bomb, stack3, false, 0, false);
                    }
                    else if (num10 == 6 && j < Main.maxTilesY - 200 && !Main.hardMode)
                    {
                        int stack4 = Main.rand.Next(20, 41);
                        Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Rope, stack4, false, 0, false);
                    }
                    else
                    {
                        float num11 = 200 + WorldGen.genRand.Next(-100, 101);
                        if (j < Main.worldSurface)
                        {
                            num11 *= 0.5f;
                        }
                        else if (j < Main.rockLayer)
                        {
                            num11 *= 0.75f;
                        }
                        else if (j > Main.maxTilesY - 250)
                        {
                            num11 *= 1.25f;
                        }
                        num11 *= 1f + Main.rand.Next(-20, 21) * 0.01f;
                        if (Main.rand.Next(5) == 0)
                        {
                            num11 *= 1f + Main.rand.Next(5, 11) * 0.01f;
                        }
                        if (Main.rand.Next(10) == 0)
                        {
                            num11 *= 1f + Main.rand.Next(10, 21) * 0.01f;
                        }
                        if (Main.rand.Next(15) == 0)
                        {
                            num11 *= 1f + Main.rand.Next(20, 41) * 0.01f;
                        }
                        if (Main.rand.Next(20) == 0)
                        {
                            num11 *= 1f + Main.rand.Next(40, 81) * 0.01f;
                        }
                        if (Main.rand.Next(25) == 0)
                        {
                            num11 *= 1f + Main.rand.Next(50, 101) * 0.01f;
                        }
                        while ((int)num11 > 0)
                        {
                            if (num11 > 1000000f)
                            {
                                int num12 = (int)(num11 / 1000000f);
                                if (num12 > 50 && Main.rand.Next(2) == 0)
                                {
                                    num12 /= Main.rand.Next(3) + 1;
                                }
                                if (Main.rand.Next(2) == 0)
                                {
                                    num12 /= Main.rand.Next(3) + 1;
                                }
                                num11 -= 1000000 * num12;
                                Item.NewItem(i * 16, j * 16, 16, 16, 74, num12, false, 0, false);
                            }
                            else if (num11 > 10000f)
                            {
                                int num13 = (int)(num11 / 10000f);
                                if (num13 > 50 && Main.rand.Next(2) == 0)
                                {
                                    num13 /= Main.rand.Next(3) + 1;
                                }
                                if (Main.rand.Next(2) == 0)
                                {
                                    num13 /= Main.rand.Next(3) + 1;
                                }
                                num11 -= 10000 * num13;
                                Item.NewItem(i * 16, j * 16, 16, 16, 73, num13, false, 0, false);
                            }
                            else if (num11 > 100f)
                            {
                                int num14 = (int)(num11 / 100f);
                                if (num14 > 50 && Main.rand.Next(2) == 0)
                                {
                                    num14 /= Main.rand.Next(3) + 1;
                                }
                                if (Main.rand.Next(2) == 0)
                                {
                                    num14 /= Main.rand.Next(3) + 1;
                                }
                                num11 -= 100 * num14;
                                Item.NewItem(i * 16, j * 16, 16, 16, 72, num14, false, 0, false);
                            }
                            else
                            {
                                int num15 = (int)num11;
                                if (num15 > 50 && Main.rand.Next(2) == 0)
                                {
                                    num15 /= Main.rand.Next(3) + 1;
                                }
                                if (Main.rand.Next(2) == 0)
                                {
                                    num15 /= Main.rand.Next(4) + 1;
                                }
                                if (num15 < 1)
                                {
                                    num15 = 1;
                                }
                                num11 -= num15;
                                Item.NewItem(i * 16, j * 16, 16, 16, 71, num15, false, 0, false);
                            }
                        }
                    }
                }
            }
        }
	}
}
