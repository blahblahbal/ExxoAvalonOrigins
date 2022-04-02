using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Ranged;

class SunlightKunai : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Sunlight Kunai");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.noUseGraphic = true;
        Item.damage = 49;
        Item.maxStack = 999;
        Item.shootSpeed = 12f;
        Item.crit += 6;
        Item.DamageType = DamageClass.Ranged;
        Item.consumable = true;
        Item.noMelee = true;
        Item.rare = ItemRarityID.Yellow;
        Item.width = dims.Width;
        Item.useTime = 15;
        Item.knockBack = 4f;
        Item.shoot = ModContent.ProjectileType<Projectiles.SunlightKunai>();
        Item.value = 550;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useAnimation = 15;
        Item.height = dims.Height;
    }
}