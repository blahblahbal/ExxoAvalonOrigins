using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories;

[AutoloadEquip(EquipType.Neck)]
class AngerTalisman : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Anger Talisman");
        Tooltip.SetDefault("27% increased damage and minus 10 defense\n'Can you say, \"Grrr!\"?'");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.defense = -10;
        Item.rare = ItemRarityID.Pink;
        Item.width = dims.Width;
        Item.accessory = true;
        Item.value = Item.sellPrice(0, 9, 0, 0);
        Item.height = dims.Height;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.GetDamage(DamageClass.Melee) += 0.27f;
        player.GetDamage(DamageClass.Ranged) += 0.27f;
        player.GetDamage(DamageClass.Magic) += 0.27f;
        player.GetDamage(DamageClass.Summon) += 0.27f;
    }
}