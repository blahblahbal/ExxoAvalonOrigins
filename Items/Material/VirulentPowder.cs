using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material;

class VirulentPowder : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Virulent Powder");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.width = dims.Width;
        Item.maxStack = 999;
        Item.height = dims.Height;
    }

    public override void AddRecipes()
    {
        CreateRecipe(5).AddIngredient(ModContent.ItemType<ContaminatedMushroom>()).AddTile(TileID.Bottles).Register();
    }
}