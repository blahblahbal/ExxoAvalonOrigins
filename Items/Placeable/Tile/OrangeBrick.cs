﻿using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Tile;

class OrangeBrick : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Orange Brick");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.autoReuse = true;
        Item.consumable = true;
        Item.createTile = ModContent.TileType<Tiles.OrangeBrick>();
        Item.width = dims.Width;
        Item.useTurn = true;
        Item.useTime = 10;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 999;
        Item.useAnimation = 15;
        Item.height = dims.Height;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<Wall.OrangeBrickWall>(), 4).AddTile(TileID.WorkBenches).Register();
        CreateRecipe(1).AddIngredient(ModContent.ItemType<Wall.OrangeSlabWall>(), 4).AddTile(TileID.WorkBenches).Register();
        CreateRecipe(1).AddIngredient(ModContent.ItemType<Wall.OrangeTiledWall>(), 4).AddTile(TileID.WorkBenches).Register();
    }
}