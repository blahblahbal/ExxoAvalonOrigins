using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Ammo
{
	class CursedTooth : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed Seed");
			Tooltip.SetDefault("For use with Blowpipes");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.damage = 9;
			item.ammo = 51;
			item.ranged = true;
			item.rare = ItemRarityID.Orange;
			item.width = dims.Width;
			item.shoot = ModContent.ProjectileType<Projectiles.CursedTooth>();
			item.maxStack = 999;
			item.height = dims.Height;
		}
	}
}
