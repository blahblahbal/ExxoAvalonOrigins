using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Vanity;

[AutoloadEquip(EquipType.Head)]
class DesertBeakMask : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Desert Beak Mask");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Blue;
        Item.width = dims.Width;
        Item.vanity = true;
        Item.value = Item.sellPrice(0, 2, 0, 0);
        Item.height = dims.Height;
    }
}