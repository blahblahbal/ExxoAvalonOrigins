using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Crafting
{
    class NaquadahAnvil : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Naquadah Anvil");
            Tooltip.SetDefault("Used to craft items from mythril, orichalcum, naquadah, adamantite, titanium, and troxinium bars");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.autoReuse = true;
            item.useTurn = true;
            item.maxStack = 99;
            item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.NaquadahAnvil>();
            item.rare = ItemRarityID.LightRed;
            item.width = dims.Width;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = 25000;
            item.useAnimation = 15;
            item.height = dims.Height;
        }
    }
}
