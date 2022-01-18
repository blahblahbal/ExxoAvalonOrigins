using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
    public class DemonSpikescale : ModTile
    {
        public override void SetDefaults()
        {
            AddMapEntry((Color.Indigo), LanguageManager.Instance.GetText("Demon Spikescale"));
            Main.tileSolid[Type] = true;
            drop = ModContent.ItemType<Items.Placeable.Tile.DemonSpikeScale>();
            dustType = DustID.CorruptionThorns;
            soundType = SoundID.Tink;
            soundStyle = 1;
        }
    }
}
