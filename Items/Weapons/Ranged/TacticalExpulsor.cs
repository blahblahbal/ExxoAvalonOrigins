using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Ranged
{
    class TacticalExpulsor : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tactical Expulsor");
            Tooltip.SetDefault("Fires a spread of eight bullets");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.damage = 35;
            Item.autoReuse = true;
            Item.useTurn = false;
            Item.useAmmo = AmmoID.Bullet;
            Item.shootSpeed = 7f;
            Item.crit += 1;
            Item.DamageType = DamageClass.Ranged;
            Item.rare = ItemRarityID.Cyan;
            Item.noMelee = true;
            Item.width = dims.Width;
            Item.knockBack = 3f;
            Item.useTime = 19;
            Item.shoot = ProjectileID.Bullet;
            Item.value = Item.sellPrice(0, 20, 0, 0);
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 19;
            Item.height = dims.Height;
            Item.UseSound = SoundID.Item38;

        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10f, 0f);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage,
            ref float knockBack)
        {
            for (int num194 = 0; num194 < 8; num194++)
            {
                float num195 = speedX;
                float num196 = speedY;
                num195 += (float)Main.rand.Next(-40, 41) * 0.05f;
                num196 += (float)Main.rand.Next(-40, 41) * 0.05f;
                Projectile.NewProjectile(position.X, position.Y, num195, num196, type, damage, knockBack, player.whoAmI, 0f, 0f);
            }

            return false;
        }
    }
}
