﻿using ExxoAvalonOrigins.Items.Material;
using ExxoAvalonOrigins.Items.Placeable.Bar;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tomes;

class SceneofCarnage : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Scene of Carnage");
        Tooltip.SetDefault("Tome\n15% increased melee damage and speed");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Yellow;
        Item.width = dims.Width;
        Item.value = Item.sellPrice(0, 0, 40);
        Item.height = dims.Height;
        Item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().tome = true;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.meleeSpeed += 0.15f;
        player.GetDamage(DamageClass.Melee) += 0.15f;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<DragonOrb>()).AddIngredient(ModContent.ItemType<BerserkerBar>(), 25).AddIngredient(ModContent.ItemType<SoulofBlight>(), 10).AddIngredient(ModContent.ItemType<DarkMatterGel>(), 100).AddIngredient(ModContent.ItemType<MysticalTomePage>(), 5).AddTile(ModContent.TileType<Tiles.TomeForge>()).Register();
    }
}