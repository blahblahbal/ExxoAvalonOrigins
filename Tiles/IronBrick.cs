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
	public class IronBrick : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(new Color(140, 101, 80));
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBrick[Type] = true;
            Main.tileBlockLight[Type] = true;
            drop = mod.ItemType("IronBrick");
            soundType = SoundID.Tink;
            soundStyle = 1;
            dustType = DustID.Iron;
        }
	}
}