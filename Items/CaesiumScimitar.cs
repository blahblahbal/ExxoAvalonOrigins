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
	class CaesiumScimitar : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Caesium Spatha");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/CaesiumScimitar");
			item.UseSound = SoundID.Item1;
			item.damage = 58;
			item.useTurn = true;
			item.scale = 1.1f;
			item.rare = 5;
			item.width = dims.Width;
			item.useTime = 16;
			item.knockBack = 5f;
			item.melee = true;
			item.useStyle = 1;
			item.value = Item.sellPrice(0, 5, 0, 0);
			item.useAnimation = 16;
			item.height = dims.Height;
		}
	}
}