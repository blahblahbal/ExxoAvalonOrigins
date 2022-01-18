using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
    public class Coughwood : ModTile
    {
        public override void SetDefaults()
        {
            AddMapEntry(new Color(116, 138, 106));
            Main.tileSolid[Type] = true;
            drop = mod.ItemType("Coughwood");
            dustType = ModContent.DustType<Dusts.CoughwoodDust>();
        }
    }
}