using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories;

class ThunderboltinaBottle : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Thunderbolt in a Bottle");
        Tooltip.SetDefault("Allows the holder to double jump");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Lime;
        Item.width = dims.Width;
        Item.accessory = true;
        Item.value = 100000;
        Item.height = dims.Height;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.Avalon().doubleJump5 = true;
    }
}