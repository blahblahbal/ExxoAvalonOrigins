using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material;

class LifeDew : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Life Dew");
        Tooltip.SetDefault("'The essence of living creatures'");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Yellow;
        Item.width = dims.Width;
        Item.maxStack = 999;
        Item.value = 400000;
        Item.height = dims.Height;
    }
}