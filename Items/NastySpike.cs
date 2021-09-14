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
	class NastySpike : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nasty Spike");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/NastySpike");
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = ModContent.TileType<Tiles.NastySpike>();
			item.rare = ItemRarityID.LightRed;
			item.width = dims.Width;
			item.useTime = 10;
			item.useTurn = true;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.maxStack = 999;
			item.value = Item.sellPrice(0, 0, 1, 0);
			item.useAnimation = 15;
			item.height = dims.Height;
		}
	}
}