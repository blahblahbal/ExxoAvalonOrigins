using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Ammo;

class TungstenBullet : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Tungsten Bullet");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.shootSpeed = 3.25f;
        Item.damage = 12;
        Item.ammo = AmmoID.Bullet;
        Item.DamageType = DamageClass.Ranged;
        Item.consumable = true;
        Item.width = dims.Width;
        Item.knockBack = 3f;
        Item.shoot = ProjectileID.Bullet;
        Item.maxStack = 2000;
        Item.value = 15;
        Item.height = dims.Height;
    }
    public override void AddRecipes()
    {
        CreateRecipe(70).AddIngredient(ItemID.MusketBall, 70).AddIngredient(ItemID.TungstenBar).AddTile(TileID.Anvils).Register();
    }
}