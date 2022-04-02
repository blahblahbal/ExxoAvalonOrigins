using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories;

class EtherealHeart : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Ethereal Heart");
        Tooltip.SetDefault("Grants a 10% chance for enemies to drop a platinum heart");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Lime;
        Item.width = dims.Width;
        Item.accessory = true;
        Item.value = Item.sellPrice(0, 1, 0, 0);
        Item.height = dims.Height;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.Avalon().ethHeart = true;
    }
}