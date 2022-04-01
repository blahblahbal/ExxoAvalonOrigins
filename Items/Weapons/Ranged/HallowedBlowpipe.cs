using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Ranged
{
    class HallowedBlowpipe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hallowed Blowpipe");
            Tooltip.SetDefault("Fires a spread of ten seeds\nAllows the collection of seeds for ammo");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.damage = 17;
            Item.autoReuse = true;
            Item.useAmmo = AmmoID.Dart;
            Item.UseSound = SoundID.Item63;
            Item.shootSpeed = 11f;
            Item.DamageType = DamageClass.Ranged;
            Item.rare = ItemRarityID.Pink;
            Item.noMelee = true;
            Item.width = dims.Width;
            Item.useTime = 30;
            Item.knockBack = 3.25f;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.value = 10000;
            Item.useAnimation = 30;
            Item.height = dims.Height;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage,
            ref float knockBack)
        {
            for (int num200 = 0; num200 < 10; num200++)
            {
                float num201 = speedX;
                float num202 = speedY;
                num201 += (float)Main.rand.Next(-35, 36) * 0.05f;
                num202 += (float)Main.rand.Next(-35, 36) * 0.05f;
                Projectile.NewProjectile(position.X, position.Y, num201, num202, type, damage, knockBack, player.whoAmI, 0f, 0f);
            }

            return false;
        }
    }
}
