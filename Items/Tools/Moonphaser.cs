using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools;

class Moonphaser : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Moonphaser");
        Tooltip.SetDefault("Changes the phases of the Moon\nHas a chance to trigger a Blood Moon if night");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.LightRed;
        Item.width = dims.Width;
        Item.useTime = 30;
        Item.shoot = ModContent.ProjectileType<Projectiles.Moonphaser>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.value = Item.sellPrice(0, 2, 70, 0);
        Item.useAnimation = 15;
        Item.height = dims.Height;
    }
}