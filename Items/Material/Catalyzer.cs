using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
    class Catalyzer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Catalyzer");
            Tooltip.SetDefault("Used to convert items to their counterparts");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.autoReuse = true;
            item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.Catalyzer>();
            item.rare = ItemRarityID.LightRed;
            item.width = dims.Width;
            item.useTurn = true;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.maxStack = 99;
            item.value = 50000;
            item.useAnimation = 15;
            item.height = dims.Height;
        }
    }
}
