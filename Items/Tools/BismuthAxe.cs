using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
    class BismuthAxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bismuth Axe");
        }
        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.UseSound = SoundID.Item1;
            item.damage = 9;
            item.autoReuse = true;
            item.useTurn = true;
            item.scale = 1.05f;
            item.axe = 13;
            item.width = dims.Width;
            item.useTime = 17;
            item.knockBack = 4f;
            item.melee = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = 11000;
            item.UseSound = SoundID.Item1;
            item.useAnimation = 25;
            item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Bar.BismuthBar>(), 9);
            recipe.AddRecipeGroup(RecipeGroupID.Wood, 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
