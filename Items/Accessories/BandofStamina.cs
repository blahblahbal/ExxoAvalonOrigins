using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories;

class BandofStamina : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Band of Stamina");
        Tooltip.SetDefault("Increases maximum stamina by 90");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Blue;
        Item.width = dims.Width;
        Item.accessory = true;
        Item.value = 50000;
        Item.height = dims.Height;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.Avalon().statStamMax2 += 90;
    }
}