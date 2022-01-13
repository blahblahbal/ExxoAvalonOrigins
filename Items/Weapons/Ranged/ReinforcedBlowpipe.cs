using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Ranged
{
	class ReinforcedBlowpipe : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Reinforced Blowpipe");
			Tooltip.SetDefault("Fires a spread of two seeds\nAllows the collection of seeds for ammo");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.damage = 11;
			item.autoReuse = true;
            item.useAmmo = AmmoID.Dart;
            item.UseSound = SoundID.Item63;
            item.shootSpeed = 11f;
			item.ranged = true;
			item.rare = ItemRarityID.Blue;
			item.noMelee = true;
			item.width = dims.Width;
			item.useTime = 40;
			item.knockBack = 3.25f;
			item.shoot = ProjectileID.PurificationPowder;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.value = 10000;
			item.useAnimation = 40;
			item.height = dims.Height;
            item.UseSound = SoundID.Item5;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("ExxoAvalonOrigins:SilverBar", 5);
            recipe.AddIngredient(ItemID.Blowpipe);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage,
			ref float knockBack)
		{
			for (int num197 = 0; num197 < 2; num197++)
			{
				float num198 = speedX;
				float num199 = speedY;
				num198 += (float)Main.rand.Next(-35, 36) * 0.05f;
				num199 += (float)Main.rand.Next(-35, 36) * 0.05f;
				Projectile.NewProjectile(position.X, position.Y, num198, num199, type, damage, knockBack, player.whoAmI, 0f, 0f);
			}

			return false;
		}
	}
}
