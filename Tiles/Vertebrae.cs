using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
    public class Vertebrae : ModTile
    {
        public override void SetStaticDefaults()
        {
            AddMapEntry(new Color(255, 127, 127));
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            drop = ItemID.Vertebrae;
            soundType = SoundID.NPCHit;
            soundStyle = 2;
            dustType = DustID.HeartCrystal;
        }
    }
}