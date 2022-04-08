using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee;

class ShatterLance : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Shatter Lance");
    }
    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.UseSound = SoundID.Item1;
        Item.damage = 171;
        Item.noUseGraphic = true;
        Item.scale = 1.1f;
        Item.shootSpeed = 5f;
        Item.rare = ItemRarityID.Pink;
        Item.noMelee = true;
        Item.width = dims.Width;
        Item.useTime = 16;
        Item.knockBack = 5.6f;
        Item.shoot = ModContent.ProjectileType<Projectiles.Melee.ShatterLance>();
        Item.DamageType = DamageClass.Melee;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.value = 105000;
        Item.useAnimation = 16;
        Item.height = dims.Height;
        Item.autoReuse = true;
    }
    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        Vector2 pos = player.Center + new Vector2(100, 0).RotatedBy(player.AngleTo(Main.MouseWorld));
        Projectile.NewProjectile(source, pos.X, pos.Y, velocity.X * 3, velocity.Y * 3, ModContent.ProjectileType<Projectiles.Melee.ShatterShard>(), damage, knockback, player.whoAmI);
        return true;
    }
    public override Color? GetAlpha(Color lightColor)
    {
        return new Color(255, 255, 255, 150);
    }
    public override bool CanUseItem(Player player)
    {
        return player.ownedProjectileCounts[Item.shoot] < 1;
    }
}
