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
    class FourLeafClover : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Four Leaf Clover");
            Tooltip.SetDefault("You are very lucky to have found this!");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/FourLeafClover");
            item.rare = ItemRarityID.Lime;
            item.width = dims.Width;
            item.maxStack = 999;
            item.value = Item.sellPrice(5);
            item.height = dims.Height;
        }
    }
}