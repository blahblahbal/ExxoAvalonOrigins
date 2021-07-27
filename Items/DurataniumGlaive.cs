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
	class DurataniumGlaive : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Duratanium Glaive");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/DurataniumGlaive");
			item.UseSound = SoundID.Item1;
			item.damage = 31;
			item.noUseGraphic = true;
			item.scale = 1.1f;
			item.shootSpeed = 5f;
			item.rare = 4;
			item.noMelee = true;
			item.width = dims.Width;
			item.useTime = 23;
			item.knockBack = 5.1f;
			item.shoot = ModContent.ProjectileType<Projectiles.DurataniumGlaive>();
			item.melee = true;
			item.useStyle = 5;
			item.value = 105000;
			item.useAnimation = 23;
			item.height = dims.Height;
		}
	}
}