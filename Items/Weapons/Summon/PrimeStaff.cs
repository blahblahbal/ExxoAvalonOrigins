using ExxoAvalonOrigins.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Summon;

class PrimeStaff : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Prime Staff");
        Tooltip.SetDefault("Summons the might of Skeletron to fight for you");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.DamageType = DamageClass.Summon;
        Item.damage = 50;
        Item.shootSpeed = 14f;
        Item.mana = 14;
        Item.noMelee = true;
        Item.rare = ItemRarityID.Yellow;
        Item.width = dims.Width;
        Item.useTime = 30;
        Item.knockBack = 6.5f;
        Item.shoot = ModContent.ProjectileType<Projectiles.Summon.PriminiCannon>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.value = Item.sellPrice(0, 10, 0, 0);
        Item.useAnimation = 30;
        Item.height = dims.Height;
        Item.UseSound = SoundID.Item44;
    }

    public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage,
                               ref float knockBack)
    {
        Projectile.NewProjectile(player.Center.X - 40f, player.Center.Y - 40f, 0f, 0f, ModContent.ProjectileType<Projectiles.Summon.PriminiCannon>(), damage, knockBack, player.whoAmI, 0f, 0f);
        Projectile.NewProjectile(player.Center.X + 40f, player.Center.Y - 40f, 0f, 0f, ModContent.ProjectileType<Projectiles.Summon.PriminiLaser>(), damage, knockBack, player.whoAmI, 0f, 0f);
        Projectile.NewProjectile(player.Center.X - 40f, player.Center.Y + 40f, 0f, 0f, ModContent.ProjectileType<Projectiles.Summon.PriminiSaw>(), damage, knockBack, player.whoAmI, 0f, 0f);
        Projectile.NewProjectile(player.Center.X + 40f, player.Center.Y + 40f, 0f, 0f, ModContent.ProjectileType<Projectiles.Summon.PriminiVice>(), damage, knockBack, player.whoAmI, 0f, 0f);
        return false;
    }
}