using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material;

class GhostintheMachine : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Ghost in the Machine");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Lime;
        Item.width = dims.Width;
        Item.maxStack = 999;
        Item.value = Item.sellPrice(0, 0, 50, 0);
        Item.height = dims.Height;
    }
}