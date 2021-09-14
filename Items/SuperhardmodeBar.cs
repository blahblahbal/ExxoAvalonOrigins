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
	class SuperhardmodeBar : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Superhardmode Bar");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/SuperhardmodeBar");
            item.autoReuse = true;
            item.useTurn = true;
            item.maxStack = 999;
            item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.PlacedBars>();
            item.placeStyle = 15;
            item.rare = ItemRarityID.Purple;
            item.width = dims.Width;
            item.useTime = 10;
            item.value = Item.sellPrice(0, 1, 30, 0);
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 15;
            item.height = dims.Height;
		}
	}
}