using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Vanity;

[AutoloadEquip(EquipType.Legs)]
class PossessedArmorGreaves : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Possessed Armor Greaves");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.LightRed;
        Item.width = dims.Width;
        Item.vanity = true;
        Item.value = Item.sellPrice(0, 0, 20, 0);
        Item.height = dims.Height;
    }
}