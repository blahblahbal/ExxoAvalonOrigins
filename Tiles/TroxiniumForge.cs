using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.ObjectData;

namespace ExxoAvalonOrigins.Tiles
{
	public class TroxiniumForge : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(new Color(255, 216, 0));
            animationFrameHeight = 38;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.newTile.CoordinateHeights = new int[]
            {
                16,
                18
            };
            TileObjectData.newTile.DrawYOffset = 2;
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.addTile(Type);
			Main.tileLighted[Type] = true;
			Main.tileFrameImportant[Type] = true;
            dustType = ModContent.DustType<Dusts.TroxiniumDust>();
            adjTiles = new int[] {TileID.AdamantiteForge, TileID.Hellforge, TileID.Furnaces};
		}
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0.83f;
            g = 0.6f;
            b = 0.5f;
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {   
            Item.NewItem(i * 16, j * 16, 48, 32, ModContent.ItemType<Items.TroxiniumForge>());
        }
        public override void RandomUpdate(int i, int j)
        {
            if (Main.rand.Next(40) == 0)
            {
                int num306 = Dust.NewDust(new Vector2(j * 16 - 4, i * 16 - 6), 8, 6, 6, 0f, 0f, 100);
                if (Main.rand.Next(3) != 0)
                {
                    Main.dust[num306].noGravity = true;
                }        
            }
        }
        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            frame = Main.tileFrame[TileID.AdamantiteForge];
        }
    }
}