using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
    public class Snotsandstone : ModTile
    {
        public override void SetStaticDefaults()
        {
            AddMapEntry(new Color(91, 109, 86));
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
            TileID.Sets.Conversion.Sandstone[Type] = true;
            drop = Mod.Find<ModItem>("SnotsandstoneBlock").Type;
            dustType = DustID.ScourgeOfTheCorruptor;
        }
    }
}