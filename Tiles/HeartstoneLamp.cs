using Microsoft.Xna.Framework;using Terraria;using Terraria.ID;using Terraria.ModLoader;using Terraria.ObjectData;namespace ExxoAvalonOrigins.Tiles{
    public class HeartstoneLamp : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2);
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 36;
            TileObjectData.addTile(Type);
            dustType = 7;
            Main.tileLighted[Type] = true;
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
            AddMapEntry(new Color(233, 211, 123));            dustType = 141;
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            Tile tile = Main.tile[i, j];
            if (tile.frameX == 0)
            {
                r = 0.9f;
                g = 0.5f;
                b = 0.7f;
            }
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 32, 16, ModContent.ItemType<Items.HeartstoneLamp>());
        }

        public override void HitWire(int i, int j)
        {
            Tile tile = Main.tile[i, j];
            int topY = j - tile.frameY / 18 % 3;
            short frameAdjustment = (short)(tile.frameX > 0 ? -18 : 18);
            Main.tile[i, topY].frameX += frameAdjustment;
            Main.tile[i, topY + 1].frameX += frameAdjustment;
            Main.tile[i, topY + 2].frameX += frameAdjustment;
            Wiring.SkipWire(i, topY);
            Wiring.SkipWire(i, topY + 1);
            Wiring.SkipWire(i, topY + 2);
            NetMessage.SendTileSquare(-1, i, topY + 1, 3, TileChangeType.None);
        }
    }
}