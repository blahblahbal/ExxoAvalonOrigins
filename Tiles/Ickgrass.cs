using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.ObjectData;namespace ExxoAvalonOrigins.Tiles{	public class Ickgrass : ModTile	{		public override void SetDefaults()		{			AddMapEntry(new Color(147, 166, 42));            SetModTree(new ContagionTree());
            Main.tileSolid[Type] = true;			Main.tileBrick[Type] = true;			Main.tileBlockLight[Type] = true;            Main.tileBlendAll[Type] = true;            Main.tileMergeDirt[Type] = true;			drop = ItemID.DirtBlock;		}        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (fail && !effectOnly)
            {
                Main.tile[i, j].type = TileID.Dirt;
                WorldGen.SquareTileFrame(i, j);
            }
        }
    }}