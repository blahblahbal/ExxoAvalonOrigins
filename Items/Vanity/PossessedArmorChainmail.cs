using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Vanity;

[AutoloadEquip(EquipType.Body)]
class PossessedArmorChainmail : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Possessed Armor Chainmail");
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