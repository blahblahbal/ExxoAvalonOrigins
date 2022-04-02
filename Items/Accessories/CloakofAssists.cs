using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories;

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
        Item.rare = ItemRarityID.Yellow;
        Item.width = dims.Width;
        Item.accessory = true;
        Item.value = Item.sellPrice(0, 8, 0, 0);
        Item.height = dims.Height;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.bee = (player.starCloak = (player.panic = (player.Avalon().LightningInABottle = true)));
    }
}