﻿using ExxoAvalonOrigins.Items.Material;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tomes;

class MistyPeachBlossoms : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Misty Peach Blossoms");
        Tooltip.SetDefault("Tome\n+20 HP\n+20 mana");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Green;
        Item.width = dims.Width;
        Item.value = 15000;
        Item.height = dims.Height;
        Item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().tome = true;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.statLifeMax2 += 20;
        player.statManaMax2 += 20;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<StrongVenom>(), 2).AddIngredient(ModContent.ItemType<FineLumber>(), 20).AddIngredient(ItemID.FallenStar, 10).AddIngredient(ModContent.ItemType<MysticalTomePage>(), 2).AddTile(ModContent.TileType<Tiles.TomeForge>()).Register();
    }
}