using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class BlackWhetstone : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Black Whetstone");
            Tooltip.SetDefault("Increases melee armor penetration by 10");
        }
        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Green;
            item.width = dims.Width;
            item.accessory = true;
            item.value = Item.sellPrice(0, 1);
            item.height = dims.Height;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.inventory[player.selectedItem].melee)
            {
                player.armorPenetration += 10;
            }
        }
    }
}
