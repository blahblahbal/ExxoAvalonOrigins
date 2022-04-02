using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Seed;

class HellstoneSeed : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Hellstone Dart");
        Tooltip.SetDefault("For use with Blowpipes");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.damage = 9;
        Item.consumable = true;
        Item.ammo = AmmoID.Dart;
        Item.DamageType = DamageClass.Ranged;
        Item.rare = ItemRarityID.Green;
        Item.width = dims.Width;
        Item.shoot = ModContent.ProjectileType<Projectiles.HellstoneSeed>();
        Item.maxStack = 999;
        Item.height = dims.Height;
    }
}