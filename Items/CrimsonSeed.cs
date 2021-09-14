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
	class CrimsonSeed : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crimson Seed");
			Tooltip.SetDefault("For use with Blowpipes");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/CrimsonSeed");
			item.damage = 4;
            item.ammo = AmmoID.Dart;
            item.ranged = true;
            item.consumable = true;
            item.rare = ItemRarityID.Blue;
			item.width = dims.Width;
			item.shoot = ModContent.ProjectileType<Projectiles.CrimsonSeed>();
			item.maxStack = 999;
			item.height = dims.Height;
		}
	}
}