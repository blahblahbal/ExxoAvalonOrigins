using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic
{
	class HallowedThorn : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hallowed Thorn");
			Tooltip.SetDefault("Summons a splitting, hallow thorn");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.magic = true;
			item.damage = 28;
			item.shootSpeed = 32f;
			item.mana = 20;
			item.rare = ItemRarityID.Pink;
			item.noMelee = true;
			item.width = dims.Width;
			item.useTime = 28;
			item.knockBack = 2f;
			item.shoot = ModContent.ProjectileType<Projectiles.HallowedThorn>();
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = 20000;
			item.useAnimation = 28;
			item.height = dims.Height;
		}
	}
}
