﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor;

[AutoloadEquip(EquipType.Legs)]
class ZincGreaves : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Zinc Greaves");
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<Placeable.Bar.ZincBar>(), 20).AddTile(TileID.Anvils).Register();
    }
    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.defense = 4;
        Item.width = dims.Width;
        Item.value = Item.sellPrice(0, 0, 25);
        Item.height = dims.Height;
    }
}