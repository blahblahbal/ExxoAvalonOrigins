using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee;

class Sporalash : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Sporalash");
        Tooltip.SetDefault("Has a chance to poison");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.damage = 33;
        Item.noUseGraphic = true;
        Item.channel = true;
        Item.scale = 1.1f;
        Item.shootSpeed = 10f;
        Item.noMelee = true;
        Item.rare = ItemRarityID.Orange;
        Item.width = dims.Width;
        Item.useTime = 46;
        Item.knockBack = 6.75f;
        Item.shoot = ModContent.ProjectileType<Projectiles.Sporalash>();
        Item.DamageType = DamageClass.Melee;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.value = 27000;
        Item.useAnimation = 46;
        Item.height = dims.Height;
    }
}