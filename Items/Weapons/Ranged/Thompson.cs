using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

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
            Item.damage = 9;
            Item.autoReuse = true;
            Item.shootSpeed = 10f;
            Item.useAmmo = AmmoID.Bullet;
            Item.DamageType = DamageClass.Ranged;
            Item.rare = ItemRarityID.Green;
            Item.noMelee = true;
            Item.width = dims.Width;
            Item.useTime = 5;
            Item.knockBack = 1f;
            Item.shoot = ProjectileID.Bullet;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.value = Item.sellPrice(0, 2);
            Item.reuseDelay = 5;
            Item.useAnimation = 5;
            Item.height = dims.Height;
            //item.UseSound = SoundID.Item11;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-12, 0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            SoundEngine.PlaySound(SoundID.Item, (int)player.Center.X, (int)player.Center.Y, 11, 0.9f, 0.4f);
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
            speedX = perturbedSpeed.X;
            speedY = perturbedSpeed.Y;
            return true;
        }
    }
}
