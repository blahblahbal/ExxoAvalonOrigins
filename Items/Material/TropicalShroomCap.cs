using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material;

class TropicalShroomCap : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Tropical Shroom Cap");
        Item.staff[Item.type] = true;
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.width = dims.Width;
        Item.height = dims.Height;
        Item.rare = ItemRarityID.White;
        Item.maxStack = 999;
        Item.value = Item.buyPrice(0, 0, 1, 0);
    }
}