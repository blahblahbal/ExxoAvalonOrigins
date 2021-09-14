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
	class TroxiniumDrill : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Troxinium Drill");
			Tooltip.SetDefault("Can mine Ferozium");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/TroxiniumDrill");
			item.damage = 14;
			item.noUseGraphic = true;
			item.channel = true;
			item.shootSpeed = 32f;
			item.pick = 185;
			item.rare = ItemRarityID.Pink;
			item.noMelee = true;
			item.width = dims.Width;
			item.useTime = 13;
			item.knockBack = 0f;
			item.shoot = ModContent.ProjectileType<Projectiles.TroxiniumDrill>();
			item.melee = true;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.value = 54000;
			item.useAnimation = 25;
			item.height = dims.Height;
		}
	}
}