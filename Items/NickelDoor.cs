using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{
    class NickelDoor : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nickel Door");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/NickelDoor");
            item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.ClosedNickelDoor>();
            item.width = dims.Width;
            item.useTurn = true;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.maxStack = 99;
            item.value = 200;
            item.useAnimation = 15;
            item.height = dims.Height;
        }
    }}