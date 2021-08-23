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
	class CrimsonBomb : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crimson Bomb");
			Tooltip.SetDefault("Converts tiles to the Crimson in a large radius");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/CrimsonBomb");
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.maxStack = 999;
			item.mech = true;
			item.createTile = ModContent.TileType<Tiles.BiomeBombs>();
			item.placeStyle = 3;
			item.consumable = true;
			item.rare = ItemRarityID.LightRed;
			item.width = dims.Width;
			item.useTime = 15;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 15;
			item.height = dims.Height;
		}
	}
}