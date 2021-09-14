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
	public class LeadBrick : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(new Color(62, 82, 114));
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBrick[Type] = true;
            Main.tileBlockLight[Type] = true;
            drop = mod.ItemType("LeadBrick");
            soundType = SoundID.Tink;
            soundStyle = 1;
            dustType = DustID.Lead;
        }
	}
}