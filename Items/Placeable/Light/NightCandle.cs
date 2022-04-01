﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Light
{
    class NightCandle : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Candle of Night");
            Tooltip.SetDefault("Nearby players become werewolves");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.autoReuse = true;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tiles.SoulCandles.NightCandle>();
            Item.rare = ItemRarityID.Yellow;
            Item.width = dims.Width;
            Item.useTime = 10;
            Item.useTurn = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.maxStack = 999;
            Item.value = Item.sellPrice(0, 0, 0, 50);
            Item.useAnimation = 15;
            Item.height = dims.Height;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ItemID.SoulofNight, 15).AddIngredient(ItemID.Candle).AddTile(TileID.MythrilAnvil).Register();
            CreateRecipe(1).AddIngredient(ItemID.SoulofNight, 15).AddIngredient(ItemID.PlatinumCandle).AddTile(TileID.MythrilAnvil).Register();
            CreateRecipe(1).AddIngredient(ItemID.SoulofNight, 15).AddIngredient(ModContent.ItemType<BismuthCandle>()).AddTile(TileID.MythrilAnvil).Register();
        }
    }
}
