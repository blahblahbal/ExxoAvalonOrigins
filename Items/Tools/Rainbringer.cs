using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
    class Rainbringer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rainbringer");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.rare = ItemRarityID.LightRed;
            Item.width = dims.Width;
            Item.useTime = 30;
            Item.shoot = ModContent.ProjectileType<Projectiles.Rainbringer>();
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = Item.sellPrice(0, 2, 70, 0);
            Item.useAnimation = 15;
            Item.height = dims.Height;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ItemID.RainCloud, 50).AddRecipeGroup(RecipeGroup.recipeGroupIDs["ExxoAvalonOrigins:CopperBar"], 10).AddIngredient(ItemID.SoulofNight, 10).AddTile(TileID.MythrilAnvil).ReplaceResult(item.type);
        }
    }
}
