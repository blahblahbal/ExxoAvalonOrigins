using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.ObjectData;
using Terraria.Localization;
using Microsoft.Xna.Framework.Graphics;

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
            soundStyle = 1;
            dustType = 1;
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];
            Texture2D texture;
            if (Main.canDrawColorTile(i, j))
            {
                texture = Main.tileAltTexture[Type, (int)tile.color()];
            }
            else
            {
                texture = Main.tileTexture[Type];
            }
            Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
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
            int result = Main.rand.Next(20);
            int a = 0;
            if (result == 0)
            {
                a = Item.NewItem(x * 16, y * 16, 16, 16, Main.rand.Next(2) == 0 ? ItemID.CopperOre : ItemID.TinOre, 5, false);
                NetMessage.SendData(21, -1, -1, NetworkText.FromLiteral(""), a, 0f, 0f, 0f, 0);
            }
            else if (result == 1)
            {
                a = Item.NewItem(x * 16, y * 16, 16, 16, Main.rand.Next(2) == 0 ? ItemID.IronOre : ItemID.LeadOre, 4, false);
                NetMessage.SendData(21, -1, -1, NetworkText.FromLiteral(""), a, 0f, 0f, 0f, 0);
            }
            else if (result == 2)
            {
                a = Item.NewItem(x * 16, y * 16, 16, 16, Main.rand.Next(2) == 0 ? ItemID.SilverOre : ItemID.TungstenOre, 3, false);
                NetMessage.SendData(21, -1, -1, NetworkText.FromLiteral(""), a, 0f, 0f, 0f, 0);
            }
            else if (result == 3)
            {
                a = Item.NewItem(x * 16, y * 16, 16, 16, Main.rand.Next(2) == 0 ? ItemID.GoldOre : ItemID.PlatinumOre, 2, false);
                NetMessage.SendData(21, -1, -1, NetworkText.FromLiteral(""), a, 0f, 0f, 0f, 0);
            }
            else if (result == 4)
            {
                int oren = Main.rand.Next(3);
                if (oren == 0) oren = ItemID.DemoniteOre;
                else if (oren == 1) oren = ItemID.CrimtaneOre;
                else oren = mod.ItemType("BacciliteOre");
                a = Item.NewItem(x * 16, y * 16, 16, 16, oren, 2, false);
                NetMessage.SendData(21, -1, -1, NetworkText.FromLiteral(""), a, 0f, 0f, 0f, 0);
            }
            else if (result == 5)
            {
                a = Item.NewItem(x * 16, y * 16, 16, 16, ItemID.Meteorite, 2, false);
                NetMessage.SendData(21, -1, -1, NetworkText.FromLiteral(""), a, 0f, 0f, 0f, 0);
            }
            else if (result == 6)
            {
                a = Item.NewItem(x * 16, y * 16, 16, 16, ItemID.Hellstone, 2, false);
                NetMessage.SendData(21, -1, -1, NetworkText.FromLiteral(""), a, 0f, 0f, 0f, 0);
            }
            else if (result == 7)
            {
                a = Item.NewItem(x * 16, y * 16, 16, 16, ItemID.Obsidian, 2, false);
                NetMessage.SendData(21, -1, -1, NetworkText.FromLiteral(""), a, 0f, 0f, 0f, 0);
            }
            else if (result == 8)
            {
                int oren = Main.rand.Next(3);
                if (oren == 0) oren = ItemID.CobaltOre;
                else if (oren == 1) oren = ItemID.PalladiumOre;
                else oren = mod.ItemType("DurataniumOre");
                a = Item.NewItem(x * 16, y * 16, 16, 16, oren, 1, false);
                NetMessage.SendData(21, -1, -1, NetworkText.FromLiteral(""), a, 0f, 0f, 0f, 0);
            }
            else if (result == 9)
            {
                int oren = Main.rand.Next(3);
                if (oren == 0) oren = ItemID.MythrilOre;
                else if (oren == 1) oren = ItemID.OrichalcumOre;
                else oren = mod.ItemType("NaquadahOre");
                a = Item.NewItem(x * 16, y * 16, 16, 16, oren, 1, false);
                NetMessage.SendData(21, -1, -1, NetworkText.FromLiteral(""), a, 0f, 0f, 0f, 0);
            }
            else if (result == 10)
            {
                int oren = Main.rand.Next(3);
                if (oren == 0) oren = ItemID.AdamantiteOre;
                else if (oren == 1) oren = ItemID.TitaniumOre;
                else oren = mod.ItemType("TroxiniumOre");
                a = Item.NewItem(x * 16, y * 16, 16, 16, oren, 1, false);
                NetMessage.SendData(21, -1, -1, NetworkText.FromLiteral(""), a, 0f, 0f, 0f, 0);
            }
            else if (result == 11)
            {
                a = Item.NewItem(x * 16, y * 16, 16, 16, mod.ItemType("CaesiumOre"), 2);
                NetMessage.SendData(21, -1, -1, NetworkText.FromLiteral(""), a, 0f, 0f, 0f, 0);
            }
            else if (result == 12)
            {
                a = Item.NewItem(x * 16, y * 16, 16, 16, mod.ItemType("OsmiumOre"), 3);
                NetMessage.SendData(21, -1, -1, NetworkText.FromLiteral(""), a, 0f, 0f, 0f, 0);
            }
            else if (result == 13)
            {
                a = Item.NewItem(x * 16, y * 16, 16, 16, mod.ItemType("RhodiumOre"), 3);
                NetMessage.SendData(21, -1, -1, NetworkText.FromLiteral(""), a, 0f, 0f, 0f, 0);
            }
            else if (result == 14)
            {
                a = Item.NewItem(x * 16, y * 16, 16, 16, mod.ItemType("HydrolythOre"), 2);
                NetMessage.SendData(21, -1, -1, NetworkText.FromLiteral(""), a, 0f, 0f, 0f, 0);
            }
            else if (result == 15)
            {
                a = Item.NewItem(x * 16, y * 16, 16, 16, mod.ItemType("Heartstone"), 3);
                NetMessage.SendData(21, -1, -1, NetworkText.FromLiteral(""), a, 0f, 0f, 0f, 0);
            }
            else if (result == 16)
            {
                a = Item.NewItem(x * 16, y * 16, 16, 16, mod.ItemType("OblivionOre"), 1);
                NetMessage.SendData(21, -1, -1, NetworkText.FromLiteral(""), a, 0f, 0f, 0f, 0);
            }
            else if (result == 17)
            {
                a = Item.NewItem(x * 16, y * 16, 16, 16, ItemID.ChlorophyteOre, 1);
                NetMessage.SendData(21, -1, -1, NetworkText.FromLiteral(""), a, 0f, 0f, 0f, 0);
            }
            else if (result == 18)
            {
                a = Item.NewItem(x * 16, y * 16, 16, 16, mod.ItemType("FeroziumOre"), 1);
                NetMessage.SendData(21, -1, -1, NetworkText.FromLiteral(""), a, 0f, 0f, 0f, 0);
            }
            else if (result == 19)
            {
                a = Item.NewItem(x * 16, y * 16, 16, 16, mod.ItemType("ShroomiteOre"), 1);
                NetMessage.SendData(21, -1, -1, NetworkText.FromLiteral(""), a, 0f, 0f, 0f, 0);
            }
            return base.Drop(i, j);
        }
    }
}