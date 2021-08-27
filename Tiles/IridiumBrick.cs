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
	public class IridiumBrick : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(new Color(146, 167, 123));
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileShine2[Type] = true;
			Main.tileShine[Type] = 1900;
            Main.tileBlockLight[Type] = true;
            drop = ModContent.ItemType<Items.IridiumBrick>();
            soundType = SoundID.Tink;
            soundStyle = 1;
            dustType = ModContent.DustType<Dusts.IridiumDust>();
		}
	}
}