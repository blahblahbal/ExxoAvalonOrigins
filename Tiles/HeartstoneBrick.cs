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
	public class HeartstoneBrick : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(new Color(173, 0, 38));
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
			drop = mod.ItemType("HeartstoneBrick");
            soundType = SoundID.Tink;
            soundStyle = 1;
            dustType = DustID.Confetti_Pink;
        }
	}
}