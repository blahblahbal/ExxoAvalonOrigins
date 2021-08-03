using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Items
{
	class BloodstainedEye : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bloodstained Eye");
		}
		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/BloodstainedEye");
			item.damage = 22;
			item.scale = 1.1f;
			item.magic = true;
			item.autoReuse = true;
			item.noMelee = true;
			item.useTurn = false;
			item.rare = 1;
			item.width = dims.Width;
			item.height = dims.Height;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.knockBack = 2f;
			item.mana = 3;
			item.shoot = ModContent.ProjectileType<Projectiles.BloodyTear>();
			item.shootSpeed = 14f;
			item.UseSound = SoundID.NPCHit1;
			item.value = Item.sellPrice(0, 1, 0, 0);
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 1 + Main.rand.Next(2);
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
				float scale = 1f - (Main.rand.NextFloat() * .3f);
				perturbedSpeed = perturbedSpeed * scale; 
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<GlassEye>());
			recipe.AddIngredient(ModContent.ItemType<BloodshotLens>());
			recipe.AddIngredient(ModContent.ItemType<BottledLava>());
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(5, 0);
		}
	}
}