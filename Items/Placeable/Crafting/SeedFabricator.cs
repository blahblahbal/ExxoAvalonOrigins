using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Crafting;

public class SeedFabricator : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Seed Fabricator");
        Tooltip.SetDefault("Used to fabricate most seeds");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.autoReuse = true;
        Item.consumable = true;
        Item.createTile = ModContent.TileType<Tiles.SeedFabricator>();
        Item.rare = ItemRarityID.Green;
        Item.width = dims.Width;
        Item.useTurn = true;
        Item.useTime = 10;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 99;
        Item.value = Item.sellPrice(0, 0, 20);
        Item.useAnimation = 15;
        Item.height = dims.Height;
    }
    //public override void AddRecipes()
    //{
    //    ModRecipe recipe = new ModRecipe(mod);
    //    recipe.AddIngredient(ItemID.HeavyWorkBench);
    //    recipe.AddIngredient(ItemID.Marble, 10);
    //    recipe.AddIngredient(ModContent.ItemType<EarthShard>(), 3);
    //    recipe.AddTile(TileID.Anvils);
    //    recipe.SetResult(this);
    //    recipe.AddRecipe();
    //}
}