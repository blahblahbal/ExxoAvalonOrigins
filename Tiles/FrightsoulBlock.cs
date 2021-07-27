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
	public class FrightsoulBlock : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(Color.Orange);
			Main.tileSolid[Type] = true;
			drop = ItemID.SoulofFright;
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
            base.NearbyEffects(i, j, closer);
        }
    }
}