using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ExxoAvalonOrigins.Tiles
{
    public class SolariumAnvil : ModTile
    {
        public override void SetDefaults()
        {
            AddMapEntry(new Color(251, 199, 86), LanguageManager.Instance.GetText("Solarium Anvil"));
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.addTile(Type);
            Main.tileObsidianKill[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileFrameImportant[Type] = true;
            adjTiles = new int[] { TileID.Anvils, TileID.MythrilAnvil };
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 32, 16, ModContent.ItemType<Items.Placeable.Crafting.SolariumAnvil>());
        }
    }
}
