using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Ranged
{
	class TorchLauncher : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Torch Launcher");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.damage = 0;
			item.shootSpeed = 8f;
			item.useAmmo = 8;
			item.ranged = true;
			item.noMelee = true;
			item.rare = ItemRarityID.Green;
			item.width = dims.Width;
			item.useTime = 16;
			item.knockBack = 0f;
			//item.shoot = ModContent.ProjectileType<Projectiles.TorchProj>();
			item.value = 39000;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 16;
			item.height = dims.Height;
		}
	}
}
