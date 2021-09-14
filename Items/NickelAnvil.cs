using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Items
{
    class NickelAnvil : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nickel Anvil");
            Tooltip.SetDefault("Used to craft items from metal bars");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.LeadAnvil);
            //Rectangle dims = ExxoAvalonOrigins.getDims("Items/NickelAnvil");
            //item.autoReuse = true;
            //item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.NickelAnvil>();
            //item.rare = 7;
            //item.width = dims.Width;
            //item.useTurn = true;
            item.placeStyle = 0;
            //item.useTime = 10;
            //item.useStyle = 1;
            //item.maxStack = 99;
            //item.value = 75000;
            //item.useAnimation = 15;
            //item.height = dims.Height;
        }
    }
}