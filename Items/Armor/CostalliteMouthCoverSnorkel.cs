using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor;

[AutoloadEquip(EquipType.Head)]
class CostalliteMouthCoverSnorkel : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Costallite Mouth Cover Snorkel");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Cyan;
        Item.width = dims.Width;
        Item.defense = 3;
        Item.value = Item.sellPrice(0, 1, 50, 0);
        Item.height = dims.Height;
    }

    public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
    {
        drawHair = (drawAltHair = true);
    }
}