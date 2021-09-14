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
	class BirthofaMonster : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Birth of a Monster");
			Tooltip.SetDefault("'Sir E. Brum'");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/BirthofaMonster");
			item.autoReuse = true;
			item.consumable = true;
            item.rare = ItemRarityID.Blue;
            item.createTile = ModContent.TileType<Tiles.Paintings>();
			item.placeStyle = 3;
			item.width = dims.Width;
			item.useTurn = true;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.maxStack = 99;
			item.value = Item.sellPrice(0, 0, 10, 0);
			item.useAnimation = 15;
			item.height = dims.Height;
		}
	}
}