using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class EyeoftheGods : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eye of the Gods");
            Tooltip.SetDefault("Shows the location and stats of enemies");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.LightRed;
            item.width = dims.Width;
            item.accessory = true;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.height = dims.Height;
        }
    }
}
