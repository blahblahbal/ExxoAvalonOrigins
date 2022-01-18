using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Tile
{
    class ContagionBomb : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Contagion Bomb");
            Tooltip.SetDefault("Converts tiles to the Contagion in a large radius");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = true;
            item.maxStack = 999;
            item.mech = true;
            item.createTile = ModContent.TileType<Tiles.BiomeBombs>();
            item.placeStyle = 4;
            item.consumable = true;
            item.rare = ItemRarityID.LightRed;
            item.width = dims.Width;
            item.useTime = 15;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 15;
            item.height = dims.Height;
        }
    }
}
