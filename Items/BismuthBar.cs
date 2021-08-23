using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{
    class BismuthBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bismuth Bar");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/BismuthBar");
            item.autoReuse = true;
            item.useTurn = true;
            item.maxStack = 999;
            item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.PlacedBars>();
            item.placeStyle = 21;
            item.rare = ItemRarityID.White;
            item.width = dims.Width;
            item.useTime = 10;
            item.value = Item.sellPrice(0, 0, 8, 0);
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 15;
            item.height = dims.Height;
        }
    }}