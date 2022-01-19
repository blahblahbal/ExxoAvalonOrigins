using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class CloakofAssists : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cloak of Assists");
            Tooltip.SetDefault("Increases movement speed after being damaged and releases bees when injured\nStars fall and lightning strikes when damaged");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Yellow;
            item.width = dims.Width;
            item.accessory = true;
            item.value = Item.sellPrice(0, 8, 0, 0);
            item.height = dims.Height;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.bee = (player.starCloak = (player.panic = (player.Avalon().LightningInABottle = true)));
        }
    }
}
