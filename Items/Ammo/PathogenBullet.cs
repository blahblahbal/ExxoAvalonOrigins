using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Ammo;

class PathogenBullet : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Pathogen Bullet");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.shootSpeed = 7f;
        Item.damage = 11;
        Item.ammo = AmmoID.Bullet;
        Item.DamageType = DamageClass.Ranged;
        Item.consumable = true;
        Item.rare = ItemRarityID.Orange;
        Item.width = dims.Width;
        Item.knockBack = 3f;
        Item.shoot = ModContent.ProjectileType<Projectiles.PathogenBullet>();
        Item.maxStack = 2000;
        Item.value = 100;
        Item.height = dims.Height;
    }
    public override void AddRecipes()
    {
        CreateRecipe(60).AddIngredient(ItemID.MusketBall, 60).AddIngredient(ModContent.ItemType<Material.Pathogen>()).AddTile(TileID.MythrilAnvil).Register();
    }
}