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
	public class NastySpike : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(new Color(89, 69, 53), LanguageManager.Instance.GetText("Nasty Spike"));
			Main.tileSolid[Type] = true;
            drop = ModContent.ItemType<Items.Placeable.Tile.NastySpike>();
            dustType = DustID.ScourgeOfTheCorruptor;
            soundType = SoundID.Tink;
            soundStyle = 1;
        }
	}
}
