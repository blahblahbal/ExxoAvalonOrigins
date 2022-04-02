using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Seed;

class JungleSeed : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Jungle Seed");
        Tooltip.SetDefault("For use with Blowpipes");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.damage = 3;
        Item.ammo = AmmoID.Dart;
        Item.consumable = true;
        Item.DamageType = DamageClass.Ranged;
        Item.rare = ItemRarityID.Orange;
        Item.width = dims.Width;
        Item.shoot = ModContent.ProjectileType<Projectiles.JungleSeed>();
        Item.maxStack = 999;
        Item.height = dims.Height;
    }
}