using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{
    class HellboundRemote : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hellbound Remote");
            Tooltip.SetDefault("Summons the Wall of Steel\nToss into lava in the Underworld");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/HellboundRemote");
            item.rare = 6;
            item.width = dims.Width;
            item.maxStack = 999;
            item.value = 0;
            item.height = dims.Height;
        }
    }}