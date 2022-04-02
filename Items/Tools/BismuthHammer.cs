using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools;

class BismuthHammer : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Bismuth Hammer");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.damage = 11;
        Item.autoReuse = true;
        Item.hammer = 61;
        Item.useTurn = true;
        Item.scale = 1.2f;
        Item.width = dims.Width;
        Item.useTime = 18;
        Item.knockBack = 4.5f;
        Item.DamageType = DamageClass.Melee;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.value = 11000;
        Item.useAnimation = 28;
        Item.height = dims.Height;
        Item.UseSound = SoundID.Item1;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<Placeable.Bar.BismuthBar>(), 10).AddRecipeGroup(RecipeGroupID.Wood, 3).AddTile(TileID.Anvils).Register();
    }
}