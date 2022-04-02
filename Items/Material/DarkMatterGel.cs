using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material;

class DarkMatterGel : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Dark Matter Gel");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.White;
        Item.width = dims.Width;
        Item.scale = 1f;
        Item.maxStack = 999;
        Item.value = 20;
        Item.height = dims.Height;
    }
}