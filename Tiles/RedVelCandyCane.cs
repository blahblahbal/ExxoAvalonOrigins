using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
    public class RedVelCandyCane : ModTile
    {
        public override void SetStaticDefaults()
        {
            AddMapEntry(Color.GreenYellow);
            Main.tileSolid[Type] = true;
            drop = Mod.Find<ModItem>("RedVelvetCandyCaneBlock").Type;
        }
    }
}