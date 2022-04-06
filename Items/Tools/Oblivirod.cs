using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools;

class Oblivirod : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Oblivirod");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.shootSpeed = 15.5f;
        Item.rare = ModContent.RarityType<Rarities.RainbowRarity>();
        Item.width = dims.Width;
        Item.useTime = 8;
        Item.fishingPole = 110;
        Item.shoot = ModContent.ProjectileType<Projectiles.OblivirodBobber>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.value = Item.sellPrice(0, 40, 0, 0);
        Item.useAnimation = 8;
        Item.height = dims.Height;
    }
}
