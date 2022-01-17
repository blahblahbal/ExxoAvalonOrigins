using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ExxoAvalonOrigins.Tiles
{
    public class CrystalFruit : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = false;
            Main.tileCut[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.AnchorValidTiles = new int[]
            {
                ModContent.TileType<CrystalStone>()
            };
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(159, 190, 224), LanguageManager.Instance.GetText("Crystal Fruit"));
            disableSmartCursor = true;
            //dustType = DustID.BlueCrystalShard;
        }
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            if (Main.tile[i, j].frameX < 36) num = DustID.PinkCrystalShard;
            else if (Main.tile[i, j].frameX < 72) num = DustID.BlueCrystalShard;
            else num = DustID.PurpleCrystalShard;
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 32, 16, ModContent.ItemType<Items.Consumables.CrystalFruit>());
        }
    }
}
