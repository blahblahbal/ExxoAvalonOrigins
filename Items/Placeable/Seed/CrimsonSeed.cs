using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Seed;

class CrimsonSeed : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Crimson Seed");
        Tooltip.SetDefault("For use with Blowpipes");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.damage = 4;
        Item.ammo = AmmoID.Dart;
        Item.DamageType = DamageClass.Ranged;
        Item.consumable = true;
        Item.rare = ItemRarityID.Blue;
        Item.width = dims.Width;
        Item.shoot = ModContent.ProjectileType<Projectiles.CrimsonSeed>();
        Item.maxStack = 999;
        Item.height = dims.Height;
    }
}