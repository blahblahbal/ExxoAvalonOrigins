﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Tile
{
    class BloodiedSpike : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloodied Spike");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.autoReuse = true;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tiles.BloodiedSpike>();
            Item.rare = ItemRarityID.Orange;
            Item.width = dims.Width;
            Item.useTime = 10;
            Item.useTurn = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.maxStack = 999;
            Item.value = Item.sellPrice(0, 0, 1, 0);
            Item.useAnimation = 15;
            Item.height = dims.Height;
            Item.notAmmo = true;
            Item.ammo = ItemID.Spike;
            Item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().spike = 2;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ItemID.Spike).AddIngredient(ItemID.TissueSample).AddTile(TileID.Anvils).Register();
        }
    }
}
