using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Seed;

class CorruptionSeed : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Corruption Seed");
        Tooltip.SetDefault("For use with Blowpipes");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.damage = 2;
        Item.ammo = AmmoID.Dart;
        Item.DamageType = DamageClass.Ranged;
        Item.consumable = true;
        Item.rare = ItemRarityID.Blue;
        Item.width = dims.Width;
        Item.shoot = ModContent.ProjectileType<Projectiles.CorruptionSeed>();
        Item.maxStack = 999;
        Item.height = dims.Height;
    }
}