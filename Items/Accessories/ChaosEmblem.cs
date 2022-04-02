using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories;

class ChaosEmblem : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Chaos Emblem");
        Tooltip.SetDefault("10% increased critical strike damage\n10% increased damage");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Yellow;
        Item.width = dims.Width;
        Item.accessory = true;
        Item.value = Item.sellPrice(0, 6, 0, 0);
        Item.height = dims.Height;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.Avalon().critDamageMult += 0.1f;
        player.allDamage += 0.1f;
    }
}