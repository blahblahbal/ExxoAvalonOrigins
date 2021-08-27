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

namespace ExxoAvalonOrigins.Tiles
{
	public class AncientCobaltBrick : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(new Color(37, 118, 171));
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileShine2[Type] = true;
			Main.tileShine[Type] = 1850;
            Main.tileBlockLight[Type] = true;
            drop = ModContent.ItemType<Items.Placeable.AncientCobaltBrick>();
            soundType = SoundID.Tink;
            soundStyle = 1;
            dustType = DustID.Cobalt;
		}
	}
}