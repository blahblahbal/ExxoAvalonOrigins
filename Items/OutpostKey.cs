using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;

namespace ExxoAvalonOrigins.Items
{
    public class OutpostKey : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Outpost Key");
            Tooltip.SetDefault("Opens the Tuhrtl Outpost door");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/OutpostKey");
            item.maxStack = 999;
            item.width = dims.Width;
            item.value = 0;
            item.height = dims.Height;
            item.rare = ItemRarityID.Lime;
        }
    }
}
