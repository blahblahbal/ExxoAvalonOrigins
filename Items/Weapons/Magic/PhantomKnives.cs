using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic
{
    class PhantomKnives : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Phantom Knives");
            Tooltip.SetDefault("Rapidly throws daggers that compound damage upon hitting a target");
        }
        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.UseSound = SoundID.Item1;
            Item.DamageType = DamageClass.Magic;
            Item.damage = 51;
            Item.noUseGraphic = true;
            Item.autoReuse = true;
            Item.shootSpeed = 15f;
            Item.mana = 18;
            Item.noMelee = true;
            Item.rare = ItemRarityID.Cyan;
            Item.width = dims.Width;
            Item.useTime = 16;
            Item.knockBack = 3.75f;
            Item.shoot = ModContent.ProjectileType<Projectiles.PhantomKnife>();
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = Item.sellPrice(0, 30, 0, 0);
            Item.useAnimation = 16;
            Item.height = dims.Height;
            Item.UseSound = SoundID.Item39;
        }
        /*public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float numberProjectiles = ExxoAvalonOriginsGlobalProjectile.howManyProjectiles(4, 8);
			float shootSpeed = (float) Math.Sqrt((double) speedX * speedX + speedY * speedY);
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				float newSpeedX = speedX * 2f + Main.rand.Next(-35, 36) * 0.05f * i;
				float newSpeedY = speedY * 2f + Main.rand.Next(-35, 36) * 0.05f * i;
				float multiMod = shootSpeed / (float) Math.Sqrt((double) newSpeedX * newSpeedX + newSpeedY * newSpeedY);
				newSpeedX *= multiMod;
				newSpeedY *= multiMod;
				Projectile.NewProjectile(position.X, position.Y, newSpeedX, newSpeedY, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}*/
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = ExxoAvalonOriginsGlobalProjectile.howManyProjectiles(4, 8);
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(20));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
    }
}
