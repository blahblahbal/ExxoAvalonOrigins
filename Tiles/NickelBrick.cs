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
	public class NickelBrick : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(new Color(82, 112, 122));
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
			Main.tileShine2[Type] = true;
            Main.tileShine[Type] = 2000;
			drop = ModContent.ItemType<Items.Placeable.Tile.NickelBrick>();
            soundType = SoundID.Tink;
            soundStyle = 1;
			dustType = ModContent.DustType<Dusts.NickelDust>();
		}
	}
}
