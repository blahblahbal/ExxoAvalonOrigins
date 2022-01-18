using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class BuildersToolbelt : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Builder's Toolbelt");
            Tooltip.SetDefault("Increases block range by 10 and wall and tile placement speed by 45% and tells time and shows position\nCan craft Tinkerer's Workshop, Anvil, Furnace, and Work Bench items by hand, and the holder can float");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Purple;
            item.width = dims.Width;
            item.accessory = true;
            item.value = Item.sellPrice(0, 30, 0, 0);
            item.height = dims.Height;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            Player.tileRangeX += 10;
            Player.tileRangeY += 10;
            player.carpet = true;
            player.wallSpeed += 4.5f;
            player.tileSpeed += 4.5f;
            player.accWatch = 3;
            player.accCompass = 1;
            player.accDepthMeter = 1;
        }
    }
}
