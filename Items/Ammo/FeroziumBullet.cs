using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Ammo;

class FeroziumBullet : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Ferozium Bullet");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.shootSpeed = 5.25f;
        Item.damage = 15;
        Item.ammo = AmmoID.Bullet;
        Item.DamageType = DamageClass.Ranged;
        Item.consumable = true;
        Item.rare = ItemRarityID.Lime;
        Item.width = dims.Width;
        Item.knockBack = 5f;
        Item.shoot = ModContent.ProjectileType<Projectiles.FeroziumBullet>();
        Item.maxStack = 2000;
        Item.value = 200;
        Item.height = dims.Height;
    }
}