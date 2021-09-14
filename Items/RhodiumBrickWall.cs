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
	class RhodiumBrickWall : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rhodium Brick Wall");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/RhodiumBrickWall");
			item.autoReuse = true;
			item.consumable = true;
			item.rare = ItemRarityID.White;
			item.width = dims.Width;
			item.useTurn = true;
			item.useTime = 10;
			item.createWall = ModContent.WallType<Walls.RhodiumBrickWall>();
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.maxStack = 999;
			item.useAnimation = 15;
			item.height = dims.Height;
		}
	}
}