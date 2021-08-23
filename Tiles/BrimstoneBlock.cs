using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.ObjectData;namespace ExxoAvalonOrigins.Tiles{	public class BrimstoneBlock : ModTile	{		public override void SetDefaults()		{
            AddMapEntry(new Color(61, 49, 53));
            Main.tileSolid[Type] = true;			Main.tileBlockLight[Type] = true;            Main.tileMerge[Type][ModContent.TileType<Impgrass>()] = true;            Main.tileMerge[Type][TileID.Ash] = true;
            Main.tileMerge[TileID.Ash][Type] = true;
            drop = ModContent.ItemType<Items.BrimstoneBlock>();            soundType = SoundID.Tink;            soundStyle = 1;            dustType = DustID.HeartCrystal;        }
        public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
        {
            ExxoAvalonOrigins.MergeWithFrame(i, j, Type, TileID.Ash, false, false, false, false, resetFrame);
            return false;
        }
    }}