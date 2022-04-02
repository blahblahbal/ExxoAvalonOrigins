using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools;

class TourmalineHook : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Tourmaline Hook");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.noUseGraphic = true;
        Item.useTurn = true;
        Item.shootSpeed = 16f;
        Item.rare = ItemRarityID.Blue;
        Item.noMelee = true;
        Item.width = dims.Width;
        Item.useTime = 20;
        Item.shoot = ModContent.ProjectileType<Projectiles.TourmalineHook>();
        Item.value = Item.sellPrice(0, 0, 54, 0);
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.useAnimation = 20;
        Item.height = dims.Height;
    }
}