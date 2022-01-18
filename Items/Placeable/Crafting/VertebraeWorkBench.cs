using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Crafting
{
    class VertebraeWorkBench : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vertebrae Work Bench");
            Tooltip.SetDefault("Used for basic crafting");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.autoReuse = true;
            item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.VertebraeWorkbench>();
            item.width = dims.Width;
            item.useTurn = true;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.maxStack = 99;
            item.value = 150;
            item.useAnimation = 15;
            item.height = dims.Height;
        }
    }
}
