using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
    public class ShadowScale : ModTile
    {
        public override void SetDefaults()
        {
            AddMapEntry(Color.LightSteelBlue);
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileFrameImportant[Type] = true;
            drop = ItemID.ShadowScale;
            dustType = DustID.CorruptionThorns;
        }
    }
}