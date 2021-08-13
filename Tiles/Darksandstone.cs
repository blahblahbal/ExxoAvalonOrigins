using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.ObjectData;namespace ExxoAvalonOrigins.Tiles{
    public class Darksandstone : ModTile
    {
        public override void SetDefaults()
        {
            AddMapEntry(new Color(63, 0, 63));
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;            Main.tileMerge[Type][TileID.Sandstone] = true;
            Main.tileMerge[TileID.Sandstone][Type] = true;
            Main.tileMerge[Type][TileID.HardenedSand] = true;
            Main.tileMerge[TileID.HardenedSand][Type] = true;
            drop = mod.ItemType("DarksandstoneBlock");            dustType = 52;        }
    }}