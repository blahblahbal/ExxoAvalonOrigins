using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor;

[AutoloadEquip(EquipType.Head)]
class VorazylcumHeadpiece : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Vorazylcum Headpiece");
        Tooltip.SetDefault("20% increased damage\n7% increased critical strike chance");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.defense = 33;
        Item.rare = ItemRarityID.Cyan;
        Item.width = dims.Width;
        Item.value = Item.sellPrice(0, 50, 0, 0);
        Item.height = dims.Height;
    }

    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
        return body.type == ModContent.ItemType<VorazylcumBodyplate>() && legs.type == ModContent.ItemType<VorazylcumLeggings>();
    }

    public override void UpdateArmorSet(Player player)
    {
        player.Avalon().auraThorns = true;
        player.onHitDodge = true;
        player.setBonus = "Thorns Aura and Shadow Dodge";
    }

    public override void UpdateEquip(Player player)
    {
        player.GetDamage(DamageClass.Ranged) += 0.2f;
        player.GetDamage(DamageClass.Melee) += 0.2f;
        player.GetDamage(DamageClass.Summon) += 0.2f;
        player.GetDamage(DamageClass.Magic) += 0.2f;
        player.GetCritChance(DamageClass.Magic) += 7;
        player.GetCritChance(DamageClass.Melee) += 7;
        player.GetCritChance(DamageClass.Ranged) += 7;
    }
}