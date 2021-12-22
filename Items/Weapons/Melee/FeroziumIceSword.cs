using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
	class FeroziumIceSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ferozium Icesword");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.damage = 50;
			item.autoReuse = true;
			item.useTurn = true;
			item.scale = 1.5f;
			item.shootSpeed = 15f;
			item.crit += 2;
			item.rare = ItemRarityID.Lime;
			item.width = dims.Width;
			item.useTime = 20;
			item.knockBack = 6f;
			item.shoot = ModContent.ProjectileType<Projectiles.Icicle>();
			item.melee = true;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = 350000;
			item.useAnimation = 20;
			item.height = dims.Height;
            item.UseSound = SoundID.Item1;
        }
	}
}
