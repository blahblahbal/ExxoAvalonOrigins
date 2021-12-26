using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExxoAvalonOrigins.Items.Material;
using ExxoAvalonOrigins.Items.Placeable.Seed;
using ExxoAvalonOrigins.Items.Weapons.Ranged;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins
{
    class ExxoAvalonOriginsGlobalTile : GlobalTile
    {

        public override void SetDefaults()
        {
            int[] spelunkers =
            {
                TileID.Crimtane,
                TileID.Meteorite,
                TileID.Obsidian,
                TileID.Hellstone
            };
            foreach (var tile in spelunkers)
            {
                Main.tileSpelunker[tile] = true;
            }
        }
        public override void NearbyEffects(int i, int j, int type, bool closer)
        {
            if (type == ModContent.TileType<Tiles.PyroscoricOre>())
            {
            Dust.NewDust(new Vector2(j * 16, i * 16), 16, 16, DustID.InfernoFork, 0f, 0f);
            }
        }
        public override bool Slope(int i, int j, int type)
        {
            if (Main.tile[i, j - 1].type == ModContent.TileType<Tiles.IckyAltar>() ||
                Main.tile[i, j - 1].type == ModContent.TileType<Tiles.HallowedAltar>())
            {
                return false;
            }
            return base.Slope(i, j, type);
        }
        public override void KillTile(int i, int j, int type, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (type == ModContent.TileType<Tiles.ImperviousBrick>())
            {
                if (Main.tile[i, j - 1].type == ModContent.TileType<Tiles.LockedImperviousDoor>() ||
                    Main.tile[i, j + 1].type == ModContent.TileType<Tiles.LockedImperviousDoor>())
                {
                    fail = true;
                }
            }
            if (Main.tile[i, j - 1].type == ModContent.TileType<Tiles.IckyAltar>() && Main.tile[i, j].type != ModContent.TileType<Tiles.IckyAltar>() ||
                Main.tile[i, j - 1].type == ModContent.TileType<Tiles.HallowedAltar>() && Main.tile[i, j].type != ModContent.TileType<Tiles.HallowedAltar>())
            {
                fail = true;
            }

            int[] blowPipes =
            {
                ItemID.Blowpipe,
                ItemID.Blowgun,
                ModContent.ItemType<ReinforcedBlowpipe>(),
                ModContent.ItemType<HallowedBlowpipe>(),
                ModContent.ItemType<SunsShadow>(),
                ModContent.ItemType<OrichythrilBlowpipe>(),
                ModContent.ItemType<HallowedBlowpipe>()
            };
            if (type == TileID.CorruptPlants || type == TileID.JunglePlants || type == TileID.JunglePlants2 || type == TileID.FleshWeeds || type == TileID.Plants)
            {
                Main.PlaySound(SoundID.Grass, i * 16, j * 16, 1);
                if (Main.rand.Next(8000) == 0)
                {
                    int a = Item.NewItem(i * 16, j * 16, 16, 16, ModContent.ItemType<FourLeafClover>(), 1, false, 0);
                    NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.FromLiteral(""), a, 0f, 0f, 0f, 0);
                }
                if (Main.rand.Next(500) == 0)
                {
                    int a = Item.NewItem(i * 16, j * 16, 16, 16, ModContent.ItemType<FakeFourLeafClover>(), 1, false, 0);
                    NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.FromLiteral(""), a, 0f, 0f, 0f, 0);
                }
            }
            if (type == TileID.CorruptPlants || type == TileID.JunglePlants || type == TileID.JunglePlants2 || type == TileID.FleshWeeds || type == TileID.Plants)
            {
                Main.PlaySound(SoundID.Grass, i * 16, j * 16, 1);
                var flag = false;
                var inventory = Main.player[Main.myPlayer].inventory;
                for (var l = 0; l < inventory.Length; l++)
                {
                    var item = inventory[l];
                    if (item != null && item.type != ItemID.None && blowPipes.Contains(item.type))
                    {
                        if (type == TileID.Plants && (item.type == ItemID.Blowpipe || item.type == ItemID.Blowgun))
                        {
                            flag = false;
                            break;
                        }
                        flag = true;
                    }
                }
                if (flag && Main.rand.Next(2) == 0)
                {
                    var number2 = Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Seed, 1, false, 0, false);
                    switch (type)
                    {
                        case TileID.CorruptPlants:
                            number2 = Item.NewItem(i * 16, j * 16, 16, 16, ModContent.ItemType<CorruptionSeed>(), 1, false, 0, false);
                            break;
                        case TileID.JunglePlants:
                        case TileID.JunglePlants2:
                            number2 = Item.NewItem(i * 16, j * 16, 16, 16, ModContent.ItemType<JungleSeed>(), 1, false, 0, false);
                            break;
                        case TileID.FleshWeeds:
                            number2 = Item.NewItem(i * 16, j * 16, 16, 16, ModContent.ItemType<CrimsonSeed>(), 1, false, 0, false);
                            break;
                        case TileID.Plants:
                            number2 = Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Seed, 1, false, 0, false);
                            break;
                    }
                    NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.FromLiteral(""), number2, 0f, 0f, 0f, 0);
                }
            }
        }
    }
}
