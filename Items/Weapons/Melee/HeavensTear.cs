using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
	class HeavensTear : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Heaven's Tear");
			Tooltip.SetDefault("'Heaven splits with each swing'");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.damage = 54;
			item.noUseGraphic = true;
			item.channel = true;
			item.scale = 1.1f;
			item.shootSpeed = 12f;
			item.noMelee = true;
			item.rare = ItemRarityID.Pink;
			item.width = dims.Width;
			item.useTime = 45;
			item.knockBack = 8f;
			item.shoot = ModContent.ProjectileType<Projectiles.HeavensTear>();
			item.melee = true;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.value = 54000;
			item.useAnimation = 45;
			item.height = dims.Height;
		}
	}
}
