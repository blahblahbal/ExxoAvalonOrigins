using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{
    class ZincBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zinc Bar");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/ZincBar");
            item.autoReuse = true;
            item.useTurn = true;
            item.maxStack = 999;
            item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.PlacedBars>();
            item.placeStyle = 20;
            item.width = dims.Width;
            item.useTime = 10;
            item.value = Item.sellPrice(0, 0, 4, 0);
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 15;
            item.height = dims.Height;
        }
    }}