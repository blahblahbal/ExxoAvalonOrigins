using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ExxoAvalonOrigins.Tiles
{
    public class SpiritPoppy : ModTile
    {
        public override void SetStaticDefaults()
        {
            AddMapEntry(new Color(0, 0, 200), LanguageManager.Instance.GetText("Spirit Poppy"));
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.addTile(Type);
            Main.tileObsidianKill[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileFrameImportant[Type] = true;
            soundType = SoundID.Shatter;
            soundStyle = 1;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 32, 16, ModContent.ItemType<Items.Consumables.SpiritPoppy>());
        }
    }
}
