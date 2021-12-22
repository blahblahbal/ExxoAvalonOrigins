using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
    public class PrimordialOre : ModTile
    {
        public override void SetDefaults()
        {
            AddMapEntry(new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), LanguageManager.Instance.GetText("Primordial Ore"));
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileValue[Type] = 815;
            soundType = SoundID.Tink;
            minPick = 210;
            soundStyle = 1;
            dustType = DustID.Stone;
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];
            Texture2D texture;
            if (Main.canDrawColorTile(i, j))
            {
                texture = Main.tileAltTexture[Type, tile.color()];
            }
            else
            {
                texture = Main.tileTexture[Type];
            }
            var zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
            if (Main.drawToScreen)
            {
                zero = Vector2.Zero;
            }
            Main.spriteBatch.Draw(texture, new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.frameX, tile.frameY, 16, 16), new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
        }

        public override bool Drop(int i, int j)
        {
            int x = i;
            int y = j;
            int result = Main.rand.Next(18);
            int a = 0;
            if (result == 0)
            {
                int ore = Main.rand.Next(3);
                if (ore == 0)
                {
                    ore = ItemID.CopperOre;
                }
                else if (ore == 1)
                {
                    ore = ItemID.TinOre;
                }
                else
                {
                    ore = ModContent.ItemType<Items.Placeable.Tile.BronzeOre>();
                }

                a = Item.NewItem(x * 16, y * 16, 16, 16, ore, 5, false);
                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.FromLiteral(""), a, 0f, 0f, 0f, 0);
            }
            else if (result == 1)
            {
                int ore = Main.rand.Next(3);
                if (ore == 0)
                {
                    ore = ItemID.IronOre;
                }
                else if (ore == 1)
                {
                    ore = ItemID.LeadOre;
                }
                else
                {
                    ore = ModContent.ItemType<Items.Placeable.Tile.NickelOre>();
                }

                a = Item.NewItem(x * 16, y * 16, 16, 16, ore, 4, false);
                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.FromLiteral(""), a, 0f, 0f, 0f, 0);
            }
            else if (result == 2)
            {
                int ore = Main.rand.Next(3);
                if (ore == 0)
                {
                    ore = ItemID.SilverOre;
                }
                else if (ore == 1)
                {
                    ore = ItemID.TungstenOre;
                }
                else
                {
                    ore = ModContent.ItemType<Items.Placeable.Tile.ZincOre>();
                }

                a = Item.NewItem(x * 16, y * 16, 16, 16, Main.rand.Next(2) == 0 ? ItemID.SilverOre : ItemID.TungstenOre, 3, false);
                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.FromLiteral(""), a, 0f, 0f, 0f, 0);
            }
            else if (result == 3)
            {
                int ore = Main.rand.Next(3);
                if (ore == 0)
                {
                    ore = ItemID.GoldOre;
                }
                else if (ore == 1)
                {
                    ore = ItemID.PlatinumOre;
                }
                else
                {
                    ore = ModContent.ItemType<Items.Placeable.Tile.BismuthOre>();
                }

                a = Item.NewItem(x * 16, y * 16, 16, 16, Main.rand.Next(2) == 0 ? ItemID.GoldOre : ItemID.PlatinumOre, 2, false);
                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.FromLiteral(""), a, 0f, 0f, 0f, 0);
            }
            else if (result == 4)
            {
                int oren = Main.rand.Next(3);
                if (oren == 0)
                {
                    oren = ItemID.DemoniteOre;
                }
                else if (oren == 1)
                {
                    oren = ItemID.CrimtaneOre;
                }
                else
                {
                    oren = ModContent.ItemType<Items.Placeable.Tile.BacciliteOre>();
                }

                a = Item.NewItem(x * 16, y * 16, 16, 16, oren, 2, false);
                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.FromLiteral(""), a, 0f, 0f, 0f, 0);
            }
            else if (result == 5)
            {
                a = Item.NewItem(x * 16, y * 16, 16, 16, ItemID.Meteorite, 2, false);
                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.FromLiteral(""), a, 0f, 0f, 0f, 0);
            }
            else if (result == 6)
            {
                a = Item.NewItem(x * 16, y * 16, 16, 16, ItemID.Hellstone, 2, false);
                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.FromLiteral(""), a, 0f, 0f, 0f, 0);
            }
            else if (result == 7)
            {
                a = Item.NewItem(x * 16, y * 16, 16, 16, ItemID.Obsidian, 2, false);
                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.FromLiteral(""), a, 0f, 0f, 0f, 0);
            }
            else if (result == 8)
            {
                int oren = Main.rand.Next(3);
                if (oren == 0)
                {
                    oren = ItemID.CobaltOre;
                }
                else if (oren == 1)
                {
                    oren = ItemID.PalladiumOre;
                }
                else
                {
                    oren = ModContent.ItemType<Items.Placeable.Tile.DurataniumOre>();
                }

                a = Item.NewItem(x * 16, y * 16, 16, 16, oren, 1, false);
                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.FromLiteral(""), a, 0f, 0f, 0f, 0);
            }
            else if (result == 9)
            {
                int oren = Main.rand.Next(3);
                if (oren == 0)
                {
                    oren = ItemID.MythrilOre;
                }
                else if (oren == 1)
                {
                    oren = ItemID.OrichalcumOre;
                }
                else
                {
                    oren = ModContent.ItemType<Items.Placeable.Tile.NaquadahOre>();
                }

                a = Item.NewItem(x * 16, y * 16, 16, 16, oren, 1, false);
                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.FromLiteral(""), a, 0f, 0f, 0f, 0);
            }
            else if (result == 10)
            {
                int oren = Main.rand.Next(3);
                if (oren == 0)
                {
                    oren = ItemID.AdamantiteOre;
                }
                else if (oren == 1)
                {
                    oren = ItemID.TitaniumOre;
                }
                else
                {
                    oren = ModContent.ItemType<Items.Placeable.Tile.TroxiniumOre>();
                }

                a = Item.NewItem(x * 16, y * 16, 16, 16, oren, 1, false);
                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.FromLiteral(""), a, 0f, 0f, 0f, 0);
            }
            else if (result == 11)
            {
                a = Item.NewItem(x * 16, y * 16, 16, 16, ModContent.ItemType<Items.Placeable.Tile.CaesiumOre>(), 2);
                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.FromLiteral(""), a, 0f, 0f, 0f, 0);
            }
            else if (result == 12)
            {
                int ore = Main.rand.Next(3);
                if (ore == 0)
                {
                    ore = ModContent.ItemType<Items.Placeable.Tile.RhodiumOre>();
                }
                else if (ore == 1)
                {
                    ore = ModContent.ItemType<Items.Placeable.Tile.OsmiumOre>();
                }
                else
                {
                    ore = ModContent.ItemType<Items.Placeable.Tile.IridiumOre>();
                }

                a = Item.NewItem(x * 16, y * 16, 16, 16, ore, 3);
                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.FromLiteral(""), a, 0f, 0f, 0f, 0);
            }
            else if (result == 13)
            {
                a = Item.NewItem(x * 16, y * 16, 16, 16, ModContent.ItemType<Items.Placeable.Tile.HydrolythOre>(), 2);
                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.FromLiteral(""), a, 0f, 0f, 0f, 0);
            }
            else if (result == 14)
            {
                a = Item.NewItem(x * 16, y * 16, 16, 16, ModContent.ItemType<Items.Placeable.Tile.Heartstone>(), 3);
                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.FromLiteral(""), a, 0f, 0f, 0f, 0);
            }
            else if (result == 15)
            {
                int ore = WorldGen.genRand.Next(2);
                if (ore == 0)
                {
                    ore = ItemID.ChlorophyteOre;
                }
                else
                {
                    ore = ModContent.ItemType<Items.Placeable.Tile.XanthophyteOre>();
                }

                a = Item.NewItem(x * 16, y * 16, 16, 16, ore, 1);
                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.FromLiteral(""), a, 0f, 0f, 0f, 0);
            }
            else if (result == 16)
            {
                a = Item.NewItem(x * 16, y * 16, 16, 16, ModContent.ItemType<Items.Placeable.Tile.FeroziumOre>(), 1);
                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.FromLiteral(""), a, 0f, 0f, 0f, 0);
            }
            else if (result == 17)
            {
                a = Item.NewItem(x * 16, y * 16, 16, 16, ModContent.ItemType<Items.Placeable.Tile.ShroomiteOre>(), 1);
                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.FromLiteral(""), a, 0f, 0f, 0f, 0);
            }
            return base.Drop(i, j);
        }
    }
}
