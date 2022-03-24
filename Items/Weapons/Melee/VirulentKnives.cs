using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
    class VirulentKnives : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Virulent Knives");
            Tooltip.SetDefault("Throws homing knives");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.UseSound = SoundID.Item1;
            item.damage = 46;
            item.noUseGraphic = true;
            item.autoReuse = true;
            item.shootSpeed = 11f;
            item.noMelee = true;
            item.rare = ItemRarityID.Yellow;
            item.width = dims.Width;
            item.useTime = 18;
            item.knockBack = 3f;
            item.shoot = ModContent.ProjectileType<Projectiles.Melee.YuckyKnife>();
            item.melee = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = Item.sellPrice(0, 20, 0, 0);
            item.useAnimation = 18;
            item.height = dims.Height;
            item.UseSound = SoundID.Item39;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = ExxoAvalonOriginsGlobalProjectile.howManyProjectiles(1, 5);
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(20));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
    }
}
