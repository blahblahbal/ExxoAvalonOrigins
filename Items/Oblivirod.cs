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
	class Oblivirod : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Oblivirod");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/Oblivirod");
			item.shootSpeed = 15.5f;
			item.rare = 12;
			item.width = dims.Width;
			item.useTime = 8;
			item.fishingPole = 110;
			item.shoot = ProjectileID.BobberHotline;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.sellPrice(0, 40, 0, 0);
			item.useAnimation = 8;
			item.height = dims.Height;
		}
	}
}