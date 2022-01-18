using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Tile
{
    class CompressedExtractBlock : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Compressed Extractination Block");
            Tooltip.SetDefault("Stick it in the Extractinator!");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.autoReuse = true;
            item.consumable = true;
            item.rare = ItemRarityID.Blue;
            item.width = dims.Width;
            item.useTurn = true;
            item.useTime = 40;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.maxStack = 999;
            item.useAnimation = 40;
            item.height = dims.Height;
        }
    }
}
