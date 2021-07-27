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
	class CoughwoodSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Coughwood Sword");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/CoughwoodSword");
			item.UseSound = SoundID.Item1;
			item.damage = 10;
			item.width = dims.Width;
			item.useTurn = true;
			item.useTime = 18;
			item.scale = 1f;
			item.knockBack = 3f;
			item.melee = true;
			item.useStyle = 1;
			item.value = Item.sellPrice(0, 0, 4, 0);
			item.useAnimation = 18;
			item.height = dims.Height;
		}
	}
}