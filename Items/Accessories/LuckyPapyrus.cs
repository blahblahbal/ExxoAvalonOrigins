using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories;

class LuckyPapyrus : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Lucky Papyrus");
        Tooltip.SetDefault("Provides immunity to Pyroscoric and Tritanorium burns\n7% increased critical strike chance\n40% increased critical strike damage");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Lime;
        Item.width = dims.Width;
        Item.value = Item.sellPrice(0, 5, 0, 0);
        Item.height = dims.Height;
        Item.accessory = true;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.AllCrit(7);
        player.Avalon().critDamageMult += 0.4f;
    }
}
