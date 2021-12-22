using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Ranged
{
	class Thompson : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Thompson");
			//Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.damage = 9;
			item.autoReuse = true;
			item.shootSpeed = 10f;
			item.useAmmo = AmmoID.Bullet;
			item.ranged = true;
			item.rare = ItemRarityID.Green;
			item.noMelee = true;
			item.width = dims.Width;
			item.useTime = 5;
			item.knockBack = 1f;
			item.shoot = ProjectileID.Bullet;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.value = Item.sellPrice(0, 2);
			item.reuseDelay = 5;
			item.useAnimation = 5;
			item.height = dims.Height;
            //item.UseSound = SoundID.Item11;
        }
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-12, 0);
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Main.PlaySound(SoundID.Item, (int)player.Center.X, (int)player.Center.Y, 11, 0.9f, 0.4f);
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
			speedX = perturbedSpeed.X;
			speedY = perturbedSpeed.Y;
			return true;
		}
	}
}
