using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{
    class SnotsandstoneBlock : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Snotsandstone Block");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/SnotsandstoneBlock");
            item.autoReuse = true;
            item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.Snotsandstone>();
            item.width = dims.Width;
            item.useTurn = true;
            item.useTime = 10;
            item.useStyle = 1;
            item.maxStack = 999;
            item.useAnimation = 15;
            item.height = dims.Height;
        }
    }}