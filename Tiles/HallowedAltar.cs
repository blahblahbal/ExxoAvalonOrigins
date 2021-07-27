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
	public class HallowedAltar : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(new Color(255, 216, 0));
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.newTile.CoordinateHeights = new int[]
            {
                16,
                18
            };
            TileObjectData.addTile(Type);
            Main.tileHammer[Type] = true;
			Main.tileLighted[Type] = true;
			Main.tileFrameImportant[Type] = true;
		}

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 1f;
            g = 0.9f;
            b = 0f;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {   
            Item.NewItem(i * 16, j * 16, 48, 32, ModContent.ItemType<Items.HallowedAltar>());
        }
    }
}