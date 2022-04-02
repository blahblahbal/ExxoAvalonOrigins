using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Consumables;

class HydrolythTrace : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Hydrolyth Trace");
        Tooltip.SetDefault("Calls forth a comet");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.consumable = true;
        Item.rare = ItemRarityID.Yellow;
        Item.width = dims.Width;
        Item.useTime = 45;
        Item.useStyle = ItemUseStyleID.HoldUp;
        Item.value = 0;
        Item.maxStack = 999;
        Item.useAnimation = 45;
        Item.height = dims.Height;
    }
}