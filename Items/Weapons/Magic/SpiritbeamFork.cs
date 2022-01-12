using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic
{
	class SpiritbeamFork : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spiritbeam Fork");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.magic = true;
			item.damage = 60;
			item.autoReuse = true;
			item.shootSpeed = 6f;
			item.mana = 15;
			item.rare = ItemRarityID.Cyan;
			item.noMelee = true;
			item.width = dims.Width;
			item.useTime = 19;
			item.knockBack = 4.25f;
			item.shoot = ProjectileID.ShadowBeamFriendly;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.value = Item.sellPrice(0, 30, 0, 0);
			item.useAnimation = 19;
			item.height = dims.Height;
            item.UseSound = SoundID.Item43;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.InfernoFork);
            recipe.AddIngredient(ItemID.SpectreStaff);
            recipe.AddIngredient(ItemID.ShadowbeamStaff);
            recipe.AddIngredient(ModContent.ItemType<Material.SoulofBlight>(), 20);
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage,
			ref float knockBack)
		{
			for (int num172 = 0; num172 < 3; num172++)
			{
				float num173 = speedX;
				float num174 = speedY;
				num173 += (float)Main.rand.Next(-30, 31) * 0.05f;
				num174 += (float)Main.rand.Next(-30, 31) * 0.05f;
				switch (num172)
				{
					case 0:
						Projectile.NewProjectile(position.X, position.Y, num173, num174, ProjectileID.InfernoFriendlyBolt, damage, knockBack, player.whoAmI, 0f, 0f);
						break;
					case 1:
						Projectile.NewProjectile(position.X, position.Y, num173, num174, ProjectileID.LostSoulFriendly, damage, knockBack, player.whoAmI, 0f, 0f);
						break;
					case 2:
						Projectile.NewProjectile(position.X, position.Y, num173, num174, ProjectileID.ShadowBeamFriendly, damage, knockBack, player.whoAmI, 0f, 0f);
						break;
				}
			}

			return false;
		}
	}
}
