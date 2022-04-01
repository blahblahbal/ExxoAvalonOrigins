using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
    public class BloodiedSpike : ModTile
    {
        public override void SetStaticDefaults()
        {
            AddMapEntry(new Color(195, 61, 40), LanguageManager.Instance.GetText("Bloodied Spike"));
            Main.tileSolid[Type] = true;
            drop = ModContent.ItemType<Items.Placeable.Tile.BloodiedSpike>();
            dustType = DustID.Palladium;
            soundType = SoundID.Tink;
            soundStyle = 1;
        }
    }
}
