﻿using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Tile
{
    class HeartstoneBrick : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heartstone Brick");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.autoReuse = true;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tiles.HeartstoneBrick>();
            Item.rare = ItemRarityID.Green;
            Item.width = dims.Width;
            Item.useTime = 10;
            Item.useTurn = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.maxStack = 999;
            Item.value = 0;
            Item.useAnimation = 15;
            Item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ModContent.ItemType<Heartstone>()).AddIngredient(ItemID.StoneBlock).AddTile(TileID.Furnaces).Register();
        }
    }
}
