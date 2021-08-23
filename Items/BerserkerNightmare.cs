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
	class BerserkerNightmare : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Berserker Nightmare");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/BerserkerNightmare");
			item.noUseGraphic = true;
			item.damage = 84;
			item.autoReuse = true;
			item.channel = true;
			item.scale = 1.1f;
			item.shootSpeed = 10f;
			item.noMelee = true;
			item.rare = ItemRarityID.Cyan;
			item.width = dims.Width;
			item.useTime = 38;
			item.knockBack = 10f;
			item.shoot = ModContent.ProjectileType<Projectiles.BerserkerSphere>();
			item.UseSound = SoundID.Item1;
			item.melee = true;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.value = Item.sellPrice(0, 50, 0, 0);
			item.useAnimation = 38;
			item.height = dims.Height;
		}
	}
}