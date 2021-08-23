using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{	class MysticalTomePage : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Mystical Tome Page");			Tooltip.SetDefault("Used to craft tomes");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Items/MysticalTomePage");			item.rare = ItemRarityID.Green;			item.width = dims.Width;			item.maxStack = 999;			item.value = Item.sellPrice(0, 0, 2, 0);			item.height = dims.Height;		}        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FallenStar, 2);
            recipe.AddIngredient(ItemID.IronBar);
            recipe.AddIngredient(ItemID.Wood, 3);
            recipe.AddRecipeGroup(RecipeGroupID.Wood);
            recipe.AddRecipeGroup(RecipeGroupID.IronBar);
            recipe.SetResult(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }}