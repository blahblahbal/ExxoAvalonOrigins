using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExxoAvalonOrigins.Items.Material;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.ObjectData;

namespace ExxoAvalonOrigins.Tiles
{
	public class TimesoulBlock : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(Color.LightYellow);
			Main.tileSolid[Type] = true;
			drop = ModContent.ItemType<SoulofTime>();
            dustType = ModContent.DustType<Dusts.Dust237>();
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            int p = Player.FindClosest(new Vector2(i, j), 24, 24);
            if (p != 255)
            {
                if (WorldGen.tileCounts[Type] > 15)
                {
                    Main.player[p].accWatch = 3;
                }
            }
            base.NearbyEffects(i, j, closer);
        }
    }
}
