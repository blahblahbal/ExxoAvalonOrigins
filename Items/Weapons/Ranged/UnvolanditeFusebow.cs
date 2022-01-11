using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Ranged
{
    class UnvolanditeFusebow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Unvolandite Fusebow");
            Tooltip.SetDefault("Fires a spread of pulse arrows that explode on the final impact");
        }

        public override void SetDefaults()
        { 
		    Rectangle dims = this.GetDims();
            item.damage = 98;
            item.ranged = true;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 16;
            item.value = Item.sellPrice(0, 20, 0, 0);
            item.rare = ItemRarityID.Cyan;
            item.UseSound = SoundID.Item75;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<Projectiles.UnvolanditeBolt>();
            item.shootSpeed = 9f;
            item.useAmmo = AmmoID.Arrow;
			item.height = dims.Height;
			item.width = dims.Width;
        }
 
  //      public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
  //      {
		//if (type == ProjectileID.WoodenArrowFriendly)
		//	{
		//		type = ModContent.ProjectileType<Projectiles.UnvolanditeBolt>();
		//	}
		//return true;
		//}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 2 + Main.rand.Next(2);
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<Projectiles.UnvolanditeBolt>(), damage, knockBack, player.whoAmI);
            }
            return false;
        }
    }
}
