using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor;

[AutoloadEquip(EquipType.Legs)]
class AncientTitaniumGreaves : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Ancient Titanium Greaves");
        Tooltip.SetDefault("10% increased magic damage");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.defense = 7;
        Item.rare = ItemRarityID.Orange;
        Item.width = dims.Width;
        Item.value = 100000;
        Item.height = dims.Height;
    }

    public override void UpdateEquip(Player player)
    {
        player.GetDamage(DamageClass.Magic) += 0.1f;
    }
}