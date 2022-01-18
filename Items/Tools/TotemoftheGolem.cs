using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
    class TotemoftheGolem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Totem of the Golem");
            Tooltip.SetDefault("Teleports you to the Hidden Temple");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.consumable = false;
            item.rare = ItemRarityID.Yellow;
            item.width = dims.Width;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.maxStack = 1;
            item.useAnimation = 15;
            item.height = dims.Height;
        }
    }
}
