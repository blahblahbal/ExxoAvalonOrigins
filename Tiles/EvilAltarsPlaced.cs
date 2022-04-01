using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ExxoAvalonOrigins.Tiles
{
    public class EvilAltarsPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            AddMapEntry(new Color(0, 250, 50), LanguageManager.Instance.GetText("Evil Altar"));
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.newTile.CoordinateHeights = new int[]
            {
                16,
                18
            };
            TileObjectData.addTile(Type);
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            adjTiles = new int[] { TileID.DemonAltar };
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int item = 0;
            switch (frameX / 54)
            {
                case 0:
                    item = ModContent.ItemType<Items.Placeable.Crafting.DemonAltar>();
                    break;
                case 1:
                    item = ModContent.ItemType<Items.Placeable.Crafting.CrimsonAltar>();
                    break;
                case 2:
                    item = ModContent.ItemType<Items.Placeable.Crafting.IckyAltar>();
                    break;
            }
            if (item > 0)
                Item.NewItem(i * 16, j * 16, 48, 32, item);
        }
    }
}
