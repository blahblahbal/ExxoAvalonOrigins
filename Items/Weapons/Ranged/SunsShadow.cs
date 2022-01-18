using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Ranged
{
    class SunsShadow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sun's Shadow");
            Tooltip.SetDefault("Fires a spread of twelve seeds\nAllows the collection of seeds for ammo");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.damage = 21;
            item.autoReuse = true;
            item.useAmmo = AmmoID.Dart;
            item.UseSound = SoundID.Item63;
            item.shootSpeed = 11f;
            item.ranged = true;
            item.rare = ItemRarityID.Yellow;
            item.noMelee = true;
            item.width = dims.Width;
            item.useTime = 28;
            item.knockBack = 4f;
            item.shoot = ProjectileID.PurificationPowder;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = 10000;
            item.useAnimation = 28;
            item.height = dims.Height;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage,
            ref float knockBack)
        {
            for (int num203 = 0; num203 < 12; num203++)
            {
                float num204 = speedX;
                float num205 = speedY;
                num204 += (float)Main.rand.Next(-35, 36) * 0.05f;
                num205 += (float)Main.rand.Next(-35, 36) * 0.05f;
                Projectile.NewProjectile(position.X, position.Y, num204, num205, type, damage, knockBack, player.whoAmI, 0f, 0f);
            }

            return false;
        }
    }
}
