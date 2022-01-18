using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Tile
{
    class PoisonSpike : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Poison Spike");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.autoReuse = true;
            item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.PoisonSpike>();
            item.rare = ItemRarityID.Green;
            item.width = dims.Width;
            item.useTime = 10;
            item.useTurn = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.maxStack = 999;
            item.value = 0;
            item.useAnimation = 15;
            item.height = dims.Height;
            item.notAmmo = true;
            item.ammo = ItemID.Spike;
            item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().spike = 6;
        }
    }
}
