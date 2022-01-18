using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
    public class HeartstoneBrick : ModTile
    {
        public override void SetDefaults()
        {
            AddMapEntry(new Color(173, 0, 38));
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            drop = mod.ItemType("HeartstoneBrick");
            soundType = SoundID.Tink;
            soundStyle = 1;
            dustType = DustID.Confetti_Pink;
        }
    }
}