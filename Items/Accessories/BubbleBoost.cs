using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    public class BubbleBoost : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bubble Boost");
            Tooltip.SetDefault("Allows the holder to bubble boost\nHold JUMP and a directional key to fly");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/Accessories/BubbleBoost");
            item.rare = 11;
            item.width = dims.Width;
            item.accessory = true;
            item.value = Item.sellPrice(0, 15, 0, 0);
            item.height = dims.Height;
            item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().bubbleBoost = true;
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().activateBubble = true;
        }
    }
}
