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
	public class TorturesoulBlock : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(Color.DarkRed);
			Main.tileSolid[Type] = true;
			drop = ModContent.ItemType<SoulofTorture>();
            dustType = ModContent.DustType<Dusts.Dust236>();
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            int p = Player.FindClosest(new Vector2(i, j), 24, 24);
            if (p != 255)
            {
                if (WorldGen.tileCounts[Type] > 15)
                {
                    Main.player[p].meleeCrit += 6;
                    Main.player[p].rangedCrit += 6;
                    Main.player[p].magicCrit += 6;
                    Main.player[p].thrownCrit += 6;
                }
            }
            base.NearbyEffects(i, j, closer);
        }
    }
}
