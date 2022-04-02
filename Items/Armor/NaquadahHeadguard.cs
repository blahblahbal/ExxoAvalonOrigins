using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor;

[AutoloadEquip(EquipType.Head)]
class NaquadahHeadguard : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Naquadah Headguard");
        Tooltip.SetDefault("7% increased ranged damage\n10% chance to not consume ammo");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.defense = 10;
        Item.rare = ItemRarityID.LightRed;
        Item.width = dims.Width;
        Item.value = Item.sellPrice(0, 2, 40, 0);
        Item.height = dims.Height;
    }

    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
        return body.type == ModContent.ItemType<NaquadahBreastplate>() && legs.type == ModContent.ItemType<NaquadahShinguards>();
    }

    public override void UpdateArmorSet(Player player)
    {
        player.setBonus = "Nearby enemies receive damage when you are damaged";
        player.Avalon().auraThorns = true;
    }

    public override void UpdateEquip(Player player)
    {
        player.GetDamage(DamageClass.Ranged) += 0.07f;
        player.ammoCost80 = true;
    }
}