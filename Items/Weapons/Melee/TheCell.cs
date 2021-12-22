using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
	class TheCell : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Cell");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.UseSound = SoundID.Item1;
			item.damage = 17;
			item.noUseGraphic = true;
			item.channel = true;
			item.scale = 1f;
			item.shootSpeed = 12f;
			item.rare = ItemRarityID.Blue;
			item.noMelee = true;
			item.width = dims.Width;
			item.useTime = 45;
			item.knockBack = 6.5f;
			item.shoot = ModContent.ProjectileType<Projectiles.Cell>();
			item.melee = true;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.value = 27000;
			item.useAnimation = 45;
			item.height = dims.Height;
		}
	}
}
