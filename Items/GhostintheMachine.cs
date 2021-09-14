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
    class GhostintheMachine : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ghost in the Machine");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/GhostintheMachine");
            item.rare = ItemRarityID.Lime;
            item.width = dims.Width;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 0, 50, 0);
            item.height = dims.Height;
        }
    }
}