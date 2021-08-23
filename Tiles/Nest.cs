using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.ObjectData;namespace ExxoAvalonOrigins.Tiles{	public class Nest : ModTile	{		public override void SetDefaults()		{			AddMapEntry(new Color(198, 175, 132));			Main.tileSolid[Type] = true;			Main.tileBlockLight[Type] = true;			drop = mod.ItemType("NestBlock");            dustType = 241;            ExxoAvalonOrigins.MergeWith(Type, ModContent.TileType<TropicalMud>());
            ExxoAvalonOrigins.MergeWith(Type, ModContent.TileType<TropicalGrass>());
        }        public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
        {
            ExxoAvalonOrigins.MergeWithFrame(i, j, Type, ModContent.TileType<TropicalMud>(), false, false, false, false, resetFrame);
            return false;
        }
    }}