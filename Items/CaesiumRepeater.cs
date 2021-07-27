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
	class CaesiumRepeater : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Caesium Repeater");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/CaesiumRepeater");
			item.UseSound = SoundID.Item5;
			item.damage = 53;
			item.autoReuse = true;
			item.useAmmo = AmmoID.Arrow;
			item.shootSpeed = 9.5f;
			item.ranged = true;
			item.noMelee = true;
			item.rare = 5;
			item.width = dims.Width;
			item.useTime = 20;
			item.knockBack = 2.75f;
			item.shoot = 1;
			item.useStyle = 5;
			item.value = 75000;
			item.useAnimation = 20;
			item.height = dims.Height;
		}
	}
}