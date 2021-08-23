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
	class CoughwoodHammer : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Coughwood Hammer");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/CoughwoodHammer");
			item.UseSound = SoundID.Item1;
			item.damage = 7;
			item.autoReuse = true;
			item.hammer = 42;
			item.useTurn = true;
			item.scale = 1.2f;
			item.width = dims.Width;
			item.useTime = 20;
			item.knockBack = 5.5f;
			item.melee = true;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = 50;
			item.useAnimation = 30;
			item.height = dims.Height;
		}
	}
}