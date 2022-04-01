using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
    public class RainbowCandyCane : ModTile
    {
        public override void SetStaticDefaults()
        {
            AddMapEntry(Color.Indigo);
            Main.tileSolid[Type] = true;
            drop = Mod.Find<ModItem>("RainbowCandyCaneBlock").Type;
        }
    }
}