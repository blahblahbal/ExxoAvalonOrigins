using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
    public class Lifestone : ModTile
    {
        public override void SetDefaults()
        {
            AddMapEntry(new Color(52, 84, 1));
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            drop = mod.ItemType("Lifestone");
            soundType = SoundID.Tink;
            soundStyle = 1;
            dustType = DustID.GreenFairy;
        }
    }
}