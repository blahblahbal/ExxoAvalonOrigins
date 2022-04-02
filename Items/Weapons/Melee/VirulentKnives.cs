using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee;

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
        Item.UseSound = SoundID.Item1;
        Item.damage = 46;
        Item.noUseGraphic = true;
        Item.autoReuse = true;
        Item.shootSpeed = 11f;
        Item.noMelee = true;
        Item.rare = ItemRarityID.Yellow;
        Item.width = dims.Width;
        Item.useTime = 18;
        Item.knockBack = 3f;
        Item.shoot = ModContent.ProjectileType<Projectiles.Melee.YuckyKnife>();
        Item.DamageType = DamageClass.Melee;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.value = Item.sellPrice(0, 20, 0, 0);
        Item.useAnimation = 18;
        Item.height = dims.Height;
        Item.UseSound = SoundID.Item39;
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