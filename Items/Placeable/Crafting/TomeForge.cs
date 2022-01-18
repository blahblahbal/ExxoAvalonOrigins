using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Crafting
{
    class TomeForge : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tome Forge");
            Tooltip.SetDefault("Used to craft Mystical Tomes");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.autoReuse = true;
            item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.TomeForge>();
            item.rare = ItemRarityID.Orange;
            item.width = dims.Width;
            item.useTurn = true;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.maxStack = 99;
            item.value = Item.sellPrice(0, 1);
            item.useAnimation = 15;
            item.height = dims.Height;
        }
    }
}
