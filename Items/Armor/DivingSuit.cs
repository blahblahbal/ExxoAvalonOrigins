using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor;

[AutoloadEquip(EquipType.Body)]
class DivingSuit : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Diving Suit");
        Tooltip.SetDefault("Greatly extends underwater breathing\n10% increased damage while in water");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.defense = 4;
        Item.rare = ItemRarityID.Green;
        Item.width = dims.Width;
        Item.value = Item.sellPrice(0, 0, 20, 0);
        Item.height = dims.Height;
    }

    public override void UpdateEquip(Player player)
    {
        player.breathMax *= 3; //TODO: fix.
        if (player.wet)
        {
            player.GetDamage(DamageClass.Melee) += 0.1f;
            player.GetDamage(DamageClass.Magic) += 0.1f;
            player.GetDamage(DamageClass.Ranged) += 0.1f;
        }
    }
}