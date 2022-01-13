﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Light
{
	class BlightCandle : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Candle of Blight");
            //Tooltip.SetDefault("Nearby players become werewolves");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = ModContent.TileType<Tiles.SoulCandles.BlightCandle>();
			item.rare = ItemRarityID.Yellow;
			item.width = dims.Width;
			item.useTime = 10;
			item.useTurn = true;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.maxStack = 999;
			item.value = Item.sellPrice(0, 0, 10);
			item.useAnimation = 15;
			item.height = dims.Height;
		}

        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ModContent.ItemType<Material.SoulofBlight>(), 15);
            r.AddIngredient(ItemID.Candle);
            r.AddTile(TileID.MythrilAnvil);
            r.SetResult(this);
            r.AddRecipe();

            r = new ModRecipe(mod);
            r.AddIngredient(ModContent.ItemType<Material.SoulofBlight>(), 15);
            r.AddIngredient(ItemID.PlatinumCandle);
            r.AddTile(TileID.MythrilAnvil);
            r.SetResult(this);
            r.AddRecipe();

            r = new ModRecipe(mod);
            r.AddIngredient(ModContent.ItemType<Material.SoulofBlight>(), 15);
            r.AddIngredient(ModContent.ItemType<Placeable.Light.BismuthCandle>());
            r.AddTile(TileID.MythrilAnvil);
            r.SetResult(this);
            r.AddRecipe();
        }
    }
}
