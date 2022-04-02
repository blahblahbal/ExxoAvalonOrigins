using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools;

class TroxiniumDrill : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Troxinium Drill");
        Tooltip.SetDefault("Can mine Ferozium");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.damage = 14;
        Item.noUseGraphic = true;
        Item.channel = true;
        Item.shootSpeed = 32f;
        Item.pick = 185;
        Item.rare = ItemRarityID.Pink;
        Item.noMelee = true;
        Item.width = dims.Width;
        Item.useTime = 13;
        Item.knockBack = 0f;
        Item.shoot = ModContent.ProjectileType<Projectiles.TroxiniumDrill>();
        Item.DamageType = DamageClass.Melee;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.value = 114000;
        Item.useAnimation = 25;
        Item.height = dims.Height;
    }
}