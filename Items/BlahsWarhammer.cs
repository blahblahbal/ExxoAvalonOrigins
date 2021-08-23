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
	class BlahsWarhammer : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blah's Warhammer");
			Tooltip.SetDefault("You shouldn't have this");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/BlahsWarhammer");
			item.UseSound = SoundID.Item1;
			item.damage = 80;
			item.autoReuse = true;
			item.hammer = 250;
			item.useTurn = true;
			item.scale = 1.15f;
			item.rare = ItemRarityID.Red;
			item.width = dims.Width;
			item.useTime = 9;
			item.knockBack = 20f;
			item.melee = true;
			item.tileBoost += 6;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = 1016000;
			item.useAnimation = 9;
			item.height = dims.Height;
		}
	}
}