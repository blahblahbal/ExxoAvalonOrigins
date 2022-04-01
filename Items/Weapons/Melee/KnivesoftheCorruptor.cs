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
            Item.UseSound = SoundID.Item1;
            Item.damage = 45;
            Item.noUseGraphic = true;
            Item.autoReuse = true;
            Item.shootSpeed = 15f;
            Item.noMelee = true;
            Item.rare = ItemRarityID.Cyan;
            Item.width = dims.Width;
            Item.useTime = 16;
            Item.knockBack = 5.75f;
            Item.shoot = ModContent.ProjectileType<Projectiles.Melee.CorruptKnife>();
            Item.DamageType = DamageClass.Melee;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = Item.sellPrice(0, 50, 0, 0);
            Item.useAnimation = 16;
            Item.height = dims.Height;
            Item.UseSound = SoundID.Item39;
        }

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
