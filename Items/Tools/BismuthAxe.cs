﻿using Microsoft.Xna.Framework;
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
            Item.UseSound = SoundID.Item1;
            Item.damage = 9;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.scale = 1.05f;
            Item.axe = 13;
            Item.width = dims.Width;
            Item.useTime = 17;
            Item.knockBack = 4f;
            Item.DamageType = DamageClass.Melee;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = 11000;
            Item.UseSound = SoundID.Item1;
            Item.useAnimation = 25;
            Item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ModContent.ItemType<Placeable.Bar.BismuthBar>(), 9).AddRecipeGroup(RecipeGroupID.Wood, 3).AddTile(TileID.Anvils).Register();
        }
    }
}
