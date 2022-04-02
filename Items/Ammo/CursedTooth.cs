using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Ammo;

class CursedTooth : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Cursed Seed");
        Tooltip.SetDefault("For use with Blowpipes");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.damage = 9;
        Item.ammo = 51;
        Item.DamageType = DamageClass.Ranged;
        Item.rare = ItemRarityID.Orange;
        Item.width = dims.Width;
        Item.shoot = ModContent.ProjectileType<Projectiles.CursedTooth>();
        Item.maxStack = 999;
        Item.height = dims.Height;
    }

    public override void AddRecipes()
    {
        CreateRecipe(50).AddIngredient(ItemID.Seed, 50).AddIngredient(ItemID.CursedFlame).AddTile(TileID.MythrilAnvil).Register();
    }
}