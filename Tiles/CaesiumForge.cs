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
using Terraria.Localization;
using Microsoft.Xna.Framework.Graphics;

namespace ExxoAvalonOrigins.Tiles
{
	public class CaesiumForge : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(new Color(76, 255, 0), LanguageManager.Instance.GetText("Caesium Forge"));
            Main.tileFrameImportant[Type] = true;
            animationFrameHeight = 36;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.newTile.DrawYOffset = 2;
            TileObjectData.newTile.LavaDeath = false;
			TileObjectData.addTile(Type);
			Main.tileLighted[Type] = true;
			adjTiles = new int[] {TileID.AdamantiteForge, TileID.Hellforge, TileID.Furnaces};
		}

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            frameCounter++;
            if (frameCounter > 4)
            {
                frameCounter = 0;
                frame++;
                if (frame > 3) frame = 0;
            }
            //frame = Main.tileFrame[TileID.AdamantiteForge];
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{   
			Item.NewItem(i * 16, j * 16, 48, 32, ModContent.ItemType<Items.Placeable.Crafting.CaesiumForge>());
		}
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 254 / 255;
            g = 121 / 255;
            b = 2 / 255;
        }
        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (Main.rand.Next(40) == 0)
            {
                int num56 = Dust.NewDust(new Vector2(j * 16 - 4, i * 16 - 6), 8, 6, 6, 0f, 0f, 100, default, 1f);
                if (Main.rand.Next(3) != 0)
                {
                    Main.dust[num56].noGravity = true;
                }
            }
        }
    }
}
