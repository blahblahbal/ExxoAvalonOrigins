using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
    public class Coughwood : ModTile
    {
        public override void SetStaticDefaults()
        {
            AddMapEntry(new Color(116, 138, 106));
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            drop = Mod.Find<ModItem>("Coughwood").Type;
            dustType = ModContent.DustType<Dusts.CoughwoodDust>();
        }
    }
}
