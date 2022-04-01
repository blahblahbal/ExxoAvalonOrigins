using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
    public class HardenedSnotsand : ModTile
    {
        public override void SetStaticDefaults()
        {
            AddMapEntry(new Color(64, 78, 59));
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileMerge[Type][TileID.Sandstone] = true;
            Main.tileMerge[TileID.Sandstone][Type] = true;
            Main.tileMerge[Type][TileID.HardenedSand] = true;
            Main.tileMerge[TileID.HardenedSand][Type] = true;
            Main.tileMerge[Type][ModContent.TileType<HardenedSnotsand>()] = true;
            Main.tileMerge[ModContent.TileType<HardenedSnotsand>()][Type] = true;
            Main.tileMerge[ModContent.TileType<Snotsand>()][Type] = true;
            Main.tileMerge[Type][ModContent.TileType<Snotsand>()] = true;
            TileID.Sets.Conversion.HardenedSand[Type] = true;
            drop = Mod.Find<ModItem>("HardenedSnotsandBlock").Type;
            dustType = DustID.ScourgeOfTheCorruptor;
        }
    }
}