using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
    public class CrystalStone : ModTile
    {
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
                drawColor = new Color(123, 186, 228);
            }
            else if (i % 14 == 1 || i % 14 == 12)
            {
                drawColor = new Color(144, 171, 221);
            }
            else if (i % 14 == 2 || i % 14 == 11)
            {
                drawColor = new Color(163, 160, 216);
            }
            else if (i % 14 == 3 || i % 14 == 10)
            {
                drawColor = new Color(176, 153, 214);
            }
            else if (i % 14 == 4 || i % 14 == 9)
            {
                drawColor = new Color(186, 146, 212);
            }
            else if (i % 14 == 5 || i % 14 == 8)
            {
                drawColor = new Color(200, 138, 209);
            }
            else if (i % 14 == 6 || i % 14 == 7)
            {
                drawColor = new Color(216, 129, 205);
            }
            else if (i % 14 == 7)
            {
                drawColor = new Color(227, 123, 203);
            }
        }
    }
}


