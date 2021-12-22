using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Tile
{
    class ResistantWoodPlatform : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Resistant Wood Platform");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.autoReuse = true;
            item.createTile = ModContent.TileType<Tiles.ResistantWoodPlatform>();
            item.consumable = true;
            item.width = dims.Width;
            item.useTurn = true;
            item.useTime = 10;
            item.scale = 1f;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.maxStack = 999;
            item.useAnimation = 15;
            item.height = dims.Height;
        }
        public override bool CanBurnInLava()
        {
            return true;
        }
    }
}
