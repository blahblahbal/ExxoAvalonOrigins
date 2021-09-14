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
	class TritonBullet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Triton Bullet");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/TritonBullet");
			item.shootSpeed = 11f;
			item.damage = 17;
			item.ammo = AmmoID.Bullet;
			item.ranged = true;
			item.consumable = true;
			item.rare = ItemRarityID.Yellow;
			item.width = dims.Width;
			item.knockBack = 20f;
			item.shoot = ModContent.ProjectileType<Projectiles.TritonBullet>();
			item.maxStack = 2000;
			item.value = 1200;
			item.height = dims.Height;
		}
	}
}