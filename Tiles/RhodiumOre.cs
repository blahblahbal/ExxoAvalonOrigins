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
	public class RhodiumOre : ModTile
	{
		public override void SetDefaults()
		{
			mineResist = 2f;
			AddMapEntry(new Color(142, 91, 91), LanguageManager.Instance.GetText("Rhodium"));
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileValue[Type] = 420;
			Main.tileShine2[Type] = true;
			Main.tileShine[Type] = 1150;
            drop = mod.ItemType("RhodiumOre");
            soundType = SoundID.Tink;
            soundStyle = 1;
            minPick = 60;
            dustType = DustID.t_LivingWood;
        }
	}
}