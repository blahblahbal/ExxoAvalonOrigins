using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
    public class MintChocCandyCane : ModTile
    {
        public override void SetDefaults()
        {
            AddMapEntry(Color.IndianRed);
            Main.tileSolid[Type] = true;
            drop = mod.ItemType("MintChocolateCandyCaneBlock");
        }
    }
}