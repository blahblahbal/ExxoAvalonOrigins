using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class StingerPack : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stinger Pack");
            Tooltip.SetDefault("Releases a 360 degree spread of stingers when struck");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Yellow;
            item.width = dims.Width;
            item.accessory = true;
            item.value = Item.sellPrice(0, 10);
            item.height = dims.Height;
            item.defense = 3;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.Avalon().stingerPack = true;
        }
    }
}
