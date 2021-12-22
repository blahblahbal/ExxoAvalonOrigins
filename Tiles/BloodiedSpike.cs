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
	public class BloodiedSpike : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(new Color(195, 61, 40), LanguageManager.Instance.GetText("Bloodied Spike"));
			Main.tileSolid[Type] = true;
			drop = ModContent.ItemType<Items.Placeable.Tile.BloodiedSpike>();
            dustType = DustID.Palladium;
            soundType = SoundID.Tink;
            soundStyle = 1;
        }
	}
}
