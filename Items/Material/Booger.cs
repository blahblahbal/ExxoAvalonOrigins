using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material;

class Booger : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Booger");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Blue;
        Item.width = dims.Width;
        Item.maxStack = 999;
        Item.value = 750;
        Item.height = dims.Height;
    }
}