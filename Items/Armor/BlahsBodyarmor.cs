using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor;

[AutoloadEquip(EquipType.Body)]
class BlahsBodyarmor : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Blah's Bodyarmor");
        Tooltip.SetDefault("30% decreased mana usage and increases your max number of minions by 6\nIncreases maximum mana by 500");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.defense = 50;
        Item.rare = ItemRarityID.Red;
        Item.width = dims.Width;
        Item.value = Item.sellPrice(1, 0, 0, 0);
        Item.height = dims.Height;
    }

    public override void UpdateEquip(Player player)
    {
        player.aggro += 1000;
        player.manaCost -= 0.3f;
        player.statManaMax2 += 500;
        player.maxMinions += 12;
    }
}