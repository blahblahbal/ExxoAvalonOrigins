using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories;

public class BubbleBoost : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Bubble Boost");
        Tooltip.SetDefault("Allows the holder to bubble boost\nHold JUMP and a directional key to fly\n'A relic of starbound times past'");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Cyan;
        Item.width = dims.Width;
        Item.accessory = true;
        Item.value = Item.sellPrice(0, 15, 0, 0);
        Item.height = dims.Height;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.Avalon().bubbleBoost = true;
        player.Avalon().activateBubble = true;
    }
}
