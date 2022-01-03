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
	public class DemonSpikescale : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry((Color.Indigo), LanguageManager.Instance.GetText("Demon Spikescale"));
			Main.tileSolid[Type] = true;
            drop = ModContent.ItemType<Items.Placeable.Tile.DemonSpikeScale>();
            dustType = DustID.CorruptionThorns;
            soundType = SoundID.Tink;
            soundStyle = 1;
        }
	}
}
