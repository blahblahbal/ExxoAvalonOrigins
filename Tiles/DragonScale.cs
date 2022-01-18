using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
    public class DragonScale : ModTile
    {
        public override void SetDefaults()
        {
            AddMapEntry(Color.MediumSpringGreen);
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileFrameImportant[Type] = true;
            drop = mod.ItemType("DragonScale");
            dustType = DustID.MagicMirror;
        }
    }
}