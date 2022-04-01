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
            Item.consumable = false;
            Item.rare = ItemRarityID.Yellow;
            Item.width = dims.Width;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.maxStack = 1;
            Item.useAnimation = 15;
            Item.height = dims.Height;
        }
    }
}
