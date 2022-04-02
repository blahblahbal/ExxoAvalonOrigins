using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic;

class TheGoldenFlames : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("The Golden Flames");
        Tooltip.SetDefault("'The flames are made of gold!'");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.DamageType = DamageClass.Magic;
        Item.damage = 72;
        Item.channel = true;
        Item.shootSpeed = 10f;
        Item.crit += 11;
        Item.mana = 14;
        Item.noMelee = true;
        Item.rare = ItemRarityID.Lime;
        Item.width = dims.Width;
        Item.knockBack = 7f;
        Item.useTime = 50;
        Item.shoot = ModContent.ProjectileType<Projectiles.GoldenFire>();
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.value = 250000;
        Item.useAnimation = 50;
        Item.height = dims.Height;
    }
}