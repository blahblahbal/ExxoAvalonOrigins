using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
    public class DarkSlimeBlock : ModTile
    {
        public override void SetStaticDefaults()
        {
            AddMapEntry(new Color(63, 0, 63));
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBrick[Type] = true;
            Main.tileBlockLight[Type] = true;
            drop = Mod.Find<ModItem>("DarkSlimeBlock").Type;
            dustType = DustID.UnholyWater;
        }
    }
}