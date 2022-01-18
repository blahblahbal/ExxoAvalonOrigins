using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
    public class RainbowCandyCane : ModTile
    {
        public override void SetDefaults()
        {
            AddMapEntry(Color.Indigo);
            Main.tileSolid[Type] = true;
            drop = mod.ItemType("RainbowCandyCaneBlock");
        }
    }
}