using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{
    class FakeFourLeafClover : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fake Four Leaf Clover");
            Tooltip.SetDefault("Aww... it's fake!");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/FakeFourLeafClover");
            item.rare = ItemRarityID.Green;
            item.width = dims.Width;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 0, 30);
            item.height = dims.Height;
        }
    }}