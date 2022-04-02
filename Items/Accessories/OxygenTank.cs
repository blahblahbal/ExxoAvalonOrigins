using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories;

class OxygenTank : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Oxygen Tank");
        Tooltip.SetDefault("Immunity to Suffocation");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.LightRed;
        Item.width = dims.Width;
        Item.accessory = true;
        Item.value = 100000;
        Item.height = dims.Height;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.buffImmune[BuffID.Suffocation] = true;
    }
}