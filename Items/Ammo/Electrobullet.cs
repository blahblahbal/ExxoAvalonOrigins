using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Ammo;

class Electrobullet : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Electrobullet");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.shootSpeed = 5.25f;
        Item.damage = 13;
        Item.ammo = AmmoID.Bullet;
        Item.DamageType = DamageClass.Ranged;
        Item.consumable = true;
        Item.rare = ItemRarityID.Red;
        Item.width = dims.Width;
        Item.knockBack = 5f;
        Item.shoot = ModContent.ProjectileType<Projectiles.Electrobullet>();
        Item.maxStack = 2000;
        Item.value = 400;
        Item.height = dims.Height;
    }
}