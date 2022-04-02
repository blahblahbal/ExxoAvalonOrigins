using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor;

[AutoloadEquip(EquipType.Legs)]
class CaesiumGreaves : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Caesium Greaves");
        Tooltip.SetDefault("15% increased melee and movement speed");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.defense = 21;
        Item.rare = ItemRarityID.Lime;
        Item.width = dims.Width;
        Item.value = Item.sellPrice(0, 8, 0, 0);
        Item.height = dims.Height;
    }

    public override void UpdateEquip(Player player)
    {
        player.meleeSpeed += 0.15f;
        player.moveSpeed += 0.15f;
    }
}