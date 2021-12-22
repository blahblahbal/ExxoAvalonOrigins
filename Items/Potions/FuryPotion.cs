﻿using ExxoAvalonOrigins.Items.Fish;
using ExxoAvalonOrigins.Items.Material;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Potions
{
    internal class FuryPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fury Potion");
            Tooltip.SetDefault("Increases critical strike damage by 20%");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.buffType = ModContent.BuffType<Buffs.Fury>();
            item.UseSound = SoundID.Item3;
            item.consumable = true;
            item.rare = ItemRarityID.Blue;
            item.width = dims.Width;
            item.useTime = 15;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.maxStack = 100;
            item.value = Item.sellPrice(0, 0, 2, 0);
            item.useAnimation = 15;
            item.height = dims.Height;
            item.buffTime = 14400;
        }

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ModContent.ItemType<Ickfish>());
            recipe.AddIngredient(ModContent.ItemType<Barfbush>());
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ModContent.ItemType<FuryPotion>());
            recipe.AddRecipe();
        }
    }
}
