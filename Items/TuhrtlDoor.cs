using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{
    class TuhrtlDoor : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tuhrtl Door");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/TuhrtlDoor");
            item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.ClosedTuhrtlDoor>();
            item.width = dims.Width;
            item.useTurn = true;
            item.useTime = 10;
            item.useStyle = 1;
            item.maxStack = 99;
            item.value = 200;
            item.useAnimation = 15;
            item.height = dims.Height;
        }
    }}