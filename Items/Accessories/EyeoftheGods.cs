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
            Item.rare = ItemRarityID.LightRed;
            Item.width = dims.Width;
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.height = dims.Height;
        }
    }
}
