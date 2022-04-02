using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories;

class NaturesEndowment : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Nature's Endowment");
        Tooltip.SetDefault("25% decreased mana usage\n+20 mana");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Pink;
        Item.width = dims.Width;
        Item.accessory = true;
        Item.value = Item.sellPrice(0, 2, 36, 0);
        Item.height = dims.Height;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.manaCost -= 0.25f;
        player.statManaMax2 += 20;
    }
}