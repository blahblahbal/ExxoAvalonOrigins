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
	class VictoryPiece : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Victory Piece");
			Tooltip.SetDefault("Victory is yours!");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/VictoryPiece");
			item.rare = ItemRarityID.Cyan;
			item.width = dims.Width;
			item.maxStack = 100;
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.height = dims.Height;
		}
	}
}