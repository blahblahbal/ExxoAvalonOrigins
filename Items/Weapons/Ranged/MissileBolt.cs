using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Ranged;

class MissileBolt : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Missile Bolt");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.shootSpeed = -1f;
        Item.damage = 50;
        Item.ammo = AmmoID.StyngerBolt;
        Item.DamageType = DamageClass.Ranged;
        Item.consumable = true;
        Item.rare = ItemRarityID.Yellow;
        Item.width = dims.Width;
        Item.knockBack = 3f;
        Item.shoot = ModContent.ProjectileType<Projectiles.MissileBolt>();
        Item.maxStack = 2000;
        Item.value = 150;
        Item.height = dims.Height;
    }
}