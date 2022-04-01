using Microsoft.Xna.Framework;
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
        public override void SetStaticDefaults()
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
			drop = Mod.Find<ModItem>("CrystalStoneBlock").Type;
            soundType = SoundID.Tink;
            soundStyle = 1;
            dustType = DustID.PinkCrystalShard;
        }
        public override void DrawEffects(int i, int j, SpriteBatch spriteBatch, ref Color drawColor, ref int nextSpecialDrawIndex)
        {
            if (i % 14 == 0 || i % 14 == 13)
            {
                drawColor = c1;
            }
            else if (i % 14 == 1 || i % 14 == 12)
            {
                drawColor = c2;
            }
            else if (i % 14 == 2 || i % 14 == 11)
            {
                drawColor = c3;
            }
            else if (i % 14 == 3 || i % 14 == 10)
            {
                drawColor = c4;
            }
            else if (i % 14 == 4 || i % 14 == 9)
            {
                drawColor = c5;
            }
            else if (i % 14 == 5 || i % 14 == 8)
            {
                drawColor = c6;
            }
            else if (i % 14 == 6 || i % 14 == 7)
            {
                drawColor = c7;
            }
            else if (i % 14 == 7)
            {
                drawColor = c8;
            }
        }
        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            if ((i + j) % 5 == 0)
            {
                Tile tile = Main.tile[i, j];
                Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
                if (Main.drawToScreen)
                {
                    zero = Vector2.Zero;
                }
                Vector2 pos = new Vector2(i * 16, j * 16) + zero - Main.screenPosition;
                Rectangle frame = new Rectangle(tile.TileFrameX, tile.TileFrameY, 16, 16);
                Main.spriteBatch.Draw(Mod.Assets.Request<Texture2D>("Tiles/CrystalStone_Glow").Value, pos, frame, Color.White);
            }
        }
    }
}


