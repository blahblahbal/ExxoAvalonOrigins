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
	class DurataniumChainsaw : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Duratanium Chainsaw");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/DurataniumChainsaw");
			item.UseSound = SoundID.Item23;
			item.damage = 25;
			item.noUseGraphic = true;
			item.channel = true;
			item.axe = 15;
			item.shootSpeed = 40f;
			item.rare = 4;
			item.noMelee = true;
			item.width = dims.Width;
			item.useTime = 6;
			item.knockBack = 3.5f;
			item.shoot = ModContent.ProjectileType<Projectiles.DurataniumChainsaw>();
			item.melee = true;
			item.useStyle = 5;
			item.value = 88000;
			item.useAnimation = 25;
			item.height = dims.Height;
		}
	}
}