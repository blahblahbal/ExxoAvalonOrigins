using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories;

class ConfusionTalisman : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Confusion Talisman");
        Tooltip.SetDefault("12% chance for your attacks to confuse your enemies");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Pink;
        Item.width = dims.Width;
        Item.accessory = true;
        Item.value = Item.sellPrice(0, 3, 0, 0);
        Item.height = dims.Height;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.Avalon().confusionTal = true; //unimplemented
    }
}