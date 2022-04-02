using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Fish;

class NauSeaFish : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Nau-Sea-a Fish");
        Tooltip.SetDefault("'Get it?'");
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Items/Fish/NauSeaFish");
        Item.maxStack = 999;
        Item.width = dims.Width;
        Item.height = dims.Height;
        Item.rare = ItemRarityID.Blue;
        Item.value = 7500;
    }
}