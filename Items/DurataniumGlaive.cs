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
			item.rare = ItemRarityID.LightRed;
			item.noMelee = true;
			item.width = dims.Width;
			item.useTime = 22;
			item.useAnimation = 22;
			item.knockBack = 5.1f;
			item.shoot = ModContent.ProjectileType<Projectiles.DurataniumGlaive>();
			item.melee = true;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.value = 105000;
			item.height = dims.Height;
		}
	}
}