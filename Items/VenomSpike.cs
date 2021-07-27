using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{
    class VenomSpike : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Venom Spike");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/VenomSpike");
            item.autoReuse = true;
            item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.VenomSpike>();
            item.width = dims.Width;
            item.useTime = 10;
            item.useTurn = true;
            item.maxStack = 999;
            item.value = 50;
            item.useStyle = 1;
            item.useAnimation = 15;
            item.height = dims.Height;
        }
    }}