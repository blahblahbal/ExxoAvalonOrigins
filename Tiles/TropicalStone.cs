using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
    public class TropicalStone : ModTile
    {
        public override void SetDefaults()
        {
            AddMapEntry(new Color(234, 234, 234));
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBrick[Type] = true;
            Main.tileBlockLight[Type] = true;
            drop = mod.ItemType("TropicalStoneBlock");
            soundType = SoundID.Tink;
            soundStyle = 1;
            dustType = DustID.SnowBlock;
        }
    }
}