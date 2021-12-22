using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExxoAvalonOrigins.Items.Material;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.ObjectData;

namespace ExxoAvalonOrigins.Tiles
{
	public class DelightsoulBlock : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(Color.DarkViolet);
			Main.tileSolid[Type] = true;
			drop = ModContent.ItemType<SoulofDelight>();
            dustType = DustID.MartianHit;
        }
    }
}
