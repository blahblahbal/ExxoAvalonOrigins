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
	class ContagionBomb : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Contaigon Bomb");
			Tooltip.SetDefault("Converts tiles to the Contagion in a large radius");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/ContagionBomb");
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.maxStack = 999;
			item.mech = true;
			item.createTile = ModContent.TileType<Tiles.BiomeBombs>();
			item.placeStyle = 4;
			item.consumable = true;
			item.rare = 4;
			item.width = dims.Width;
			item.useTime = 15;
			item.useStyle = 1;
			item.useAnimation = 15;
			item.height = dims.Height;
		}
	}
}