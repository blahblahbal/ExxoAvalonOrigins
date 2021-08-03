using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.ObjectData;namespace ExxoAvalonOrigins.Tiles{	public class BrimstoneBlock : ModTile	{		public override void SetDefaults()		{			AddMapEntry(Color.LightPink);			Main.tileSolid[Type] = true;			Main.tileBlockLight[Type] = true;            Main.tileMerge[Type][ModContent.TileType<Impgrass>()] = true;            ExxoAvalonOrigins.MergeWith(Type, TileID.Ash);
            drop = ModContent.ItemType<Items.BrimstoneBlock>();            soundType = SoundID.Tink;            soundStyle = 1;        }
        public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
        {
            ExxoAvalonOrigins.MergeWithFrame(i, j, Type, TileID.Ash, false, false, false, false, resetFrame);
            return false;
        }
    }}