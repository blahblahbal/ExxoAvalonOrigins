using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Tile;

class ResistantWoodPlatform : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Resistant Wood Platform");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.autoReuse = true;
        Item.createTile = ModContent.TileType<Tiles.ResistantWoodPlatform>();
        Item.consumable = true;
        Item.width = dims.Width;
        Item.useTurn = true;
        Item.useTime = 10;
        Item.scale = 1f;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 999;
        Item.useAnimation = 15;
        Item.height = dims.Height;
    }
    public override bool CanBurnInLava()
    {
        return true;
    }
    public override void AddRecipes()
    {
        CreateRecipe(2).AddIngredient(ModContent.ItemType<ResistantWood>()).Register();
        CreateRecipe(1).AddIngredient(this, 2).ReplaceResult(ModContent.ItemType<ResistantWood>());
    }
}