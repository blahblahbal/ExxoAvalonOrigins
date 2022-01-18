using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
    class KnivesoftheCorruptor : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Knives of the Corruptor");
            Tooltip.SetDefault("Rapidly throws daggers that explode into tiny eaters");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.UseSound = SoundID.Item1;
            item.damage = 45;
            item.noUseGraphic = true;
            item.autoReuse = true;
            item.shootSpeed = 15f;
            item.noMelee = true;
            item.rare = ItemRarityID.Cyan;
            item.width = dims.Width;
            item.useTime = 16;
            item.knockBack = 5.75f;
            item.shoot = ModContent.ProjectileType<Projectiles.CorruptKnife>();
            item.melee = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = Item.sellPrice(0, 50, 0, 0);
            item.useAnimation = 16;
            item.height = dims.Height;
            item.UseSound = SoundID.Item39;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float numberProjectiles = ExxoAvalonOriginsGlobalProjectile.howManyProjectiles(4, 8);
            float shootSpeed = (float)Math.Sqrt((double)speedX * speedX + speedY * speedY);
            position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
            for (int i = 0; i < numberProjectiles; i++)
            {
                float newSpeedX = speedX * 2f + Main.rand.Next(-35, 36) * 0.05f * i;
                float newSpeedY = speedY * 2f + Main.rand.Next(-35, 36) * 0.05f * i;
                float multiMod = shootSpeed / (float)Math.Sqrt((double)newSpeedX * newSpeedX + newSpeedY * newSpeedY);
                newSpeedX *= multiMod;
                newSpeedY *= multiMod;
                Projectile.NewProjectile(position.X, position.Y, newSpeedX, newSpeedY, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
    }
}
