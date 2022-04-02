using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material;

class ToxinShard : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Toxin Shard");
        Tooltip.SetDefault("'A fragment of jungle creatures'");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Green;
        Item.width = dims.Width;
        Item.maxStack = 999;
        Item.value = Item.sellPrice(0, 0, 6, 0);
        Item.height = dims.Height;
    }
}