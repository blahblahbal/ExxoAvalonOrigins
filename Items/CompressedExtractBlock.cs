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
	class CompressedExtractBlock : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Compressed Extractination Block");
			Tooltip.SetDefault("Stick it in the Extractinator!");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/CompressedExtractBlock");
			item.autoReuse = true;
			item.consumable = true;
			item.rare = ItemRarityID.Blue;
			item.width = dims.Width;
			item.useTurn = true;
			item.useTime = 40;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.maxStack = 999;
			item.useAnimation = 40;
			item.height = dims.Height;
		}
	}
}