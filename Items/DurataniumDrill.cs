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
	class DurataniumDrill : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Duratanium Drill");
			Tooltip.SetDefault("Can mine Mythril, Orichalcum, and Naquadah");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/DurataniumDrill");
			item.UseSound = SoundID.Item23;
			item.damage = 10;
			item.noUseGraphic = true;
			item.channel = true;
			item.shootSpeed = 32f;
			item.pick = 110;
			item.rare = 4;
			item.noMelee = true;
			item.width = dims.Width;
			item.useTime = 13;
			item.knockBack = 0f;
			item.shoot = ModContent.ProjectileType<Projectiles.DurataniumDrill>();
			item.melee = true;
			item.useStyle = 5;
			item.value = 54000;
			item.useAnimation = 25;
			item.height = dims.Height;
		}
	}
}