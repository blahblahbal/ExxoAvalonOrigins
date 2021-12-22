using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Seed
{
	class JungleSeed : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Jungle Seed");
			Tooltip.SetDefault("For use with Blowpipes");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.damage = 3;
            item.ammo = AmmoID.Dart;
            item.consumable = true;
            item.ranged = true;
			item.rare = ItemRarityID.Orange;
			item.width = dims.Width;
			item.shoot = ModContent.ProjectileType<Projectiles.JungleSeed>();
			item.maxStack = 999;
			item.height = dims.Height;
		}
	}
}
