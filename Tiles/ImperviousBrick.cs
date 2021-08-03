using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.ObjectData;namespace ExxoAvalonOrigins.Tiles{	public class ImperviousBrick : ModTile	{		public override void SetDefaults()		{			AddMapEntry(new Color(10, 10, 10));			Main.tileSolid[Type] = true;			Main.tileMergeDirt[Type] = true;			Main.tileBrick[Type] = true;			Main.tileBlockLight[Type] = true;            Main.tileMerge[TileID.Ash][Type] = true;            Main.tileMerge[Type][TileID.Ash] = true;
            drop = mod.ItemType("ImperviousBrick");            soundType = SoundID.Tink;            soundStyle = 1;            minPick = 100;        }        public override bool Slope(int i, int j)
        {
            if (!ExxoAvalonOriginsWorld.downedPhantasm) return false;
            return true;
        }
    }}