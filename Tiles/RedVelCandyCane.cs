using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
    public class RedVelCandyCane : ModTile
    {
        public override void SetDefaults()
        {
            AddMapEntry(Color.GreenYellow);
            Main.tileSolid[Type] = true;
            drop = mod.ItemType("RedVelvetCandyCaneBlock");
        }
    }
}