using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material;

class SpikedBlastShell : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Spiked Blast Shell");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Purple;
        Item.width = dims.Width;
        Item.value = 5000;
        Item.maxStack = 999;
        Item.height = dims.Height;
    }
}