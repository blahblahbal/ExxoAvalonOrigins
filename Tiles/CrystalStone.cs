using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;

namespace ExxoAvalonOrigins.Tiles
{
	public class CrystalStone : ModTile
	{
        Color c1 = new Color(123, 186, 228);
        Color c2 = new Color(144, 171, 221);
        Color c3 = new Color(163, 160, 216);
        Color c4 = new Color(176, 153, 214);
        Color c5 = new Color(186, 146, 212);
        Color c6 = new Color(200, 138, 209);
        Color c7 = new Color(216, 129, 205);
        Color c8 = new Color(227, 123, 203);
        public override void SetDefaults()
		{
			AddMapEntry(new Color(185, 115, 168));
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileMerge[Type][TileID.SnowBlock] = true;
			Main.tileMerge[TileID.SnowBlock][Type] = true;
			Main.tileMerge[Type][TileID.Ebonstone] = true;
			Main.tileMerge[TileID.Ebonstone][Type] = true;
			Main.tileMerge[Type][TileID.Crimstone] = true;
			Main.tileMerge[TileID.Crimstone][Type] = true;
			Main.tileMerge[Type][TileID.Stone] = true;
			Main.tileMerge[TileID.Stone][Type] = true;
			Main.tileMerge[Type][TileID.Mud] = true;
			Main.tileMerge[TileID.Mud][Type] = true;
			drop = mod.ItemType("CrystalStoneBlock");
            soundType = SoundID.Tink;
            soundStyle = 1;
            dustType = DustID.PinkCrystalShard;
        }
        public override void DrawEffects(int i, int j, SpriteBatch spriteBatch, ref Color drawColor, ref int nextSpecialDrawIndex)
        {
            if (i % 14 == 0 || i % 14 == 13)
            {
                drawColor = new Color(drawColor.R + c1.R, drawColor.G + c1.G, drawColor.B + c1.B);
            }
            else if (i % 14 == 1 || i % 14 == 12)
            {
                drawColor = new Color(drawColor.R + c2.R, drawColor.G + c2.G, drawColor.B + c2.B);
            }
            else if (i % 14 == 2 || i % 14 == 11)
            {
                drawColor = new Color(drawColor.R + c3.R, drawColor.G + c3.G, drawColor.B + c3.B);
            }
            else if (i % 14 == 3 || i % 14 == 10)
            {
                drawColor = new Color(drawColor.R + c4.R, drawColor.G + c4.G, drawColor.B + c4.B);
            }
            else if (i % 14 == 4 || i % 14 == 9)
            {
                drawColor = new Color(drawColor.R + c5.R, drawColor.G + c5.G, drawColor.B + c5.B);
            }
            else if (i % 14 == 5 || i % 14 == 8)
            {
                drawColor = new Color(drawColor.R + c6.R, drawColor.G + c6.G, drawColor.B + c6.B);
            }
            else if (i % 14 == 6 || i % 14 == 7)
            {
                drawColor = new Color(drawColor.R + c7.R, drawColor.G + c7.G, drawColor.B + c7.B);
            }
            else if (i % 14 == 7)
            {
                drawColor = new Color(drawColor.R + c8.R, drawColor.G + c8.G, drawColor.B + c8.B);
            }
        }
    }
}


