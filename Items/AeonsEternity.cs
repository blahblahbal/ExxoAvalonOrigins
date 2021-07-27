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
	class AeonsEternity : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Aeon's Eternity");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/AeonsEternity");
			item.damage = 39;
			item.autoReuse = true;
			item.useTurn = true;
			item.scale = 1.1f;
			item.shootSpeed = 9f;
			item.rare = 5;
			item.width = dims.Width;
			item.useTime = 20;
			item.knockBack = 5.5f;
			item.shoot = ModContent.ProjectileType<Projectiles.AeonBeam2>();
			item.UseSound = SoundID.Item1;
			item.melee = true;
			item.useStyle = 1;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.useAnimation = 20;
			item.height = dims.Height;
		}
	}
}