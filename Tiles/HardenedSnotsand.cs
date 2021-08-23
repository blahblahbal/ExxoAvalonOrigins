using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.ObjectData;namespace ExxoAvalonOrigins.Tiles{
    public class HardenedSnotsand : ModTile
    {
        public override void SetDefaults()
        {
            AddMapEntry(new Color(64, 78, 59));
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;            Main.tileMerge[Type][TileID.Sandstone] = true;
            Main.tileMerge[TileID.Sandstone][Type] = true;
            Main.tileMerge[Type][TileID.HardenedSand] = true;
            Main.tileMerge[TileID.HardenedSand][Type] = true;
            Main.tileMerge[Type][ModContent.TileType<HardenedSnotsand>()] = true;
            Main.tileMerge[ModContent.TileType<HardenedSnotsand>()][Type] = true;
            TileID.Sets.Conversion.HardenedSand[Type] = true;
            drop = mod.ItemType("HardenedSnotsandBlock");            dustType = DustID.ScourgeOfTheCorruptor;        }
    }}