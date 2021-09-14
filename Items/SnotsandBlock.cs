using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Items
{
	class SnotsandBlock : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Snotsand Block");
            Tooltip.SetDefault("'Disgustingly sticky'");
		}
		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/SnotsandBlock");
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = ModContent.TileType<Tiles.Snotsand>();
			item.width = dims.Width;
			item.useTurn = true;
			item.useTime = 10;
			item.scale = 1f;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.maxStack = 999;
			item.useAnimation = 15;
			item.height = dims.Height;
		}
	}
}