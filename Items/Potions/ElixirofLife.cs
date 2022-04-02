using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Potions;

class ElixirofLife : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Elixir of Life");
        Tooltip.SetDefault("'It refreshes you'");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.potion = true;
        Item.useTurn = true;
        Item.maxStack = 60;
        Item.healLife = 350;
        Item.consumable = true;
        Item.rare = ItemRarityID.Lime;
        Item.width = dims.Width;
        Item.useTime = 17;
        Item.useStyle = ItemUseStyleID.EatFood;
        Item.value = 10000;
        Item.useAnimation = 17;
        Item.height = dims.Height;
        Item.UseSound = SoundID.Item3;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<Material.LifeDew>()).AddIngredient(ItemID.SuperHealingPotion).AddIngredient(ModContent.ItemType<Material.DarkMatterGel>(), 3).AddTile(TileID.Bottles).Register();
    }
}