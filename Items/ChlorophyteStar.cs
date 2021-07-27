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
	class ChlorophyteStar : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chlorophyte Star");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/ChlorophyteStar");
			item.UseSound = SoundID.Item1;
			item.noUseGraphic = true;
			item.damage = 45;
			item.maxStack = 999;
			item.shootSpeed = 9f;
			item.crit += 4;
			item.ranged = true;
			item.consumable = true;
			item.noMelee = true;
			item.rare = 7;
			item.width = dims.Width;
			item.useTime = 10;
			item.knockBack = 3.75f;
			item.shoot = ModContent.ProjectileType<Projectiles.ChlorophyteStar>();
			item.value = 500;
			item.useStyle = 1;
			item.useAnimation = 10;
			item.height = dims.Height;
		}
	}
}