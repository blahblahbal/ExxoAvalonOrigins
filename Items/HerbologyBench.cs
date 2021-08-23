using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{
    class HerbologyBench : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Herbology Bench");
            Tooltip.SetDefault("Used for herb-related exchange");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/HerbologyBench");
            item.autoReuse = true;
            item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.HerbologyBench>();
            item.rare = ItemRarityID.Green;
            item.width = dims.Width;
            item.useTurn = true;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.maxStack = 99;
            item.value = Item.sellPrice(0, 0, 20);
            item.useAnimation = 15;
            item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronBar, 8);
            recipe.AddIngredient(ItemID.Wood, 45);
            recipe.AddIngredient(ItemID.GrassSeeds, 20);
            recipe.AddIngredient(ItemID.Daybloom, 15);
            recipe.AddRecipeGroup("ExxoAvalonOrigins:Herbs");
            recipe.AddRecipeGroup(RecipeGroupID.Wood);
            recipe.AddRecipeGroup(RecipeGroupID.IronBar);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }}