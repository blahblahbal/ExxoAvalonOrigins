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
	public class AncientAdamantiteBrick : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(new Color(202, 66, 133));
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileShine[Type] = 1150;
            Main.tileBlockLight[Type] = true;
            drop = ModContent.ItemType<Items.Placeable.AncientAdamantiteBrick>();
            soundType = SoundID.Tink;
            soundStyle = 1;
            dustType = DustID.Adamantite;
		}
	}
}