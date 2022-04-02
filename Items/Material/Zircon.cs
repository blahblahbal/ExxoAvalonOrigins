using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material;

class Zircon : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Zircon");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Blue;
        Item.width = dims.Width;
        Item.value = 4400;
        Item.maxStack = 999;
        Item.height = dims.Height;
    }
}