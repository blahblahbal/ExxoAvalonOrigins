using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories;

class LightninginaBottle : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Lightning in a Bottle");
        Tooltip.SetDefault("Lightning strikes you when damaged");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Pink;
        Item.width = dims.Width;
        Item.accessory = true;
        Item.value = Item.sellPrice(0, 1, 44, 0);
        Item.height = dims.Height;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.Avalon().LightningInABottle = true;
    }
}