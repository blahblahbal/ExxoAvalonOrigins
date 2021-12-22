using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Seed
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
			Rectangle dims = this.GetDims();
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
