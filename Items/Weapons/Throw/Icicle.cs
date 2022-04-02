using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Throw;

class Icicle : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Icicle");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.damage = 11;
        Item.noUseGraphic = true;
        Item.maxStack = 999;
        Item.shootSpeed = 9f;
        Item.DamageType = DamageClass.Ranged;
        Item.consumable = true;
        Item.noMelee = true;
        Item.width = dims.Width;
        Item.useTime = 15;
        Item.knockBack = 3f;
        Item.shoot = ModContent.ProjectileType<Projectiles.Icicle>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.value = 0;
        Item.useAnimation = 15;
        Item.height = dims.Height;
    }
    public override void AddRecipes()
    {
        CreateRecipe(10).AddIngredient(ModContent.ItemType<Material.FrostShard>()).AddTile(TileID.Anvils).Register();
    }
}