using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material;

class MysticalTomePage : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Mystical Tome Page");
        Tooltip.SetDefault("Used to craft tomes");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Green;
        Item.width = dims.Width;
        Item.maxStack = 999;
        Item.value = Item.sellPrice(0, 0, 2, 0);
        Item.height = dims.Height;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ItemID.FallenStar, 2).AddIngredient(ItemID.IronBar).AddIngredient(ItemID.Wood, 3).AddTile(ModContent.TileType<Tiles.TomeForge>()).Register();
    }
}