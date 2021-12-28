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
using Microsoft.Xna.Framework.Graphics;

namespace ExxoAvalonOrigins.Tiles
{
	public class FrightsoulBlock : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(Color.Orange);
			Main.tileSolid[Type] = true;
			drop = ItemID.SoulofFright;
            dustType = ModContent.DustType<Dusts.SoulofFright>();
		}
        public override void NearbyEffects(int i, int j, bool closer)
        {
            int p = Player.FindClosest(new Vector2(i, j), 24, 24);
            if (p != 255)
            {
                if (WorldGen.tileCounts[Type] > 15)
                {
                    Main.player[p].statDefense += 8;
                }
            }
            if (Main.rand.Next(100) == 0)
            {
				int num162 = Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, ModContent.DustType<Dusts.SoulofFright>(), 0f, 0f, 0, default, 1f);
				Main.dust[num162].noGravity = true;
			}
        }
    }
}
