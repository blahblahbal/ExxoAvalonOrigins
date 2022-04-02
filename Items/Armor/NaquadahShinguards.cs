using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor;

[AutoloadEquip(EquipType.Legs)]
class NaquadahShinguards : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Naquadah Shinguards");
        Tooltip.SetDefault("6% increased movement speed");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.defense = 12;
        Item.rare = ItemRarityID.LightRed;
        Item.width = dims.Width;
        Item.value = Item.sellPrice(0, 2, 30, 0);
        Item.height = dims.Height;
    }

    public override void UpdateEquip(Player player)
    {
        player.moveSpeed += 0.06f;
    }
}