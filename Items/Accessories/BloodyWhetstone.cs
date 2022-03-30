using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class BloodyWhetstone : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloody Whetstone");
            Tooltip.SetDefault("Melee attacks inflict bleeding");
        }
        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.LightRed;
            item.width = dims.Width;
            item.accessory = true;
            item.value = Item.sellPrice(0, 3);
            item.height = dims.Height;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.Avalon().bloodywhetstone = true;
        }
    }
}
