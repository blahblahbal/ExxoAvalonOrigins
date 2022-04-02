using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor;

[AutoloadEquip(EquipType.Head)]
class BlahsHelmet : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Blah's Helmet");
        Tooltip.SetDefault("29% increased damage\n10% increased critical strike chance");
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
        player.GetDamage(DamageClass.Melee) += 0.29f;
        player.GetDamage(DamageClass.Magic) += 0.29f;
        player.GetDamage(DamageClass.Ranged) += 0.29f;
        player.GetCritChance(DamageClass.Melee) += 10;
        player.GetCritChance(DamageClass.Ranged) += 10;
        player.GetCritChance(DamageClass.Magic) += 10;
    }
}