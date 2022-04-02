using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Throw;

class HallowedKunai : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Hallowed Kunai");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.noUseGraphic = true;
        Item.damage = 38;
        Item.maxStack = 999;
        Item.shootSpeed = 11f;
        Item.crit += 2;
        Item.DamageType = DamageClass.Ranged;
        Item.consumable = true;
        Item.noMelee = true;
        Item.rare = ItemRarityID.Pink;
        Item.width = dims.Width;
        Item.useTime = 10;
        Item.knockBack = 2.5f;
        Item.shoot = ModContent.ProjectileType<Projectiles.HallowedKunai>();
        Item.value = 400;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useAnimation = 10;
        Item.height = dims.Height;
    }
}