using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Ammo;

class BerserkerArrow : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Berserker Arrow");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.damage = 19;
        Item.shootSpeed = 4f;
        Item.ammo = AmmoID.Arrow;
        Item.DamageType = DamageClass.Ranged;
        Item.consumable = true;
        Item.rare = ItemRarityID.Cyan;
        Item.width = dims.Width;
        Item.knockBack = 4f;
        Item.shoot = ModContent.ProjectileType<Projectiles.BerserkerArrow>();
        Item.value = Item.sellPrice(0, 0, 2, 0);
        Item.maxStack = 2000;
        Item.height = dims.Height;
    }
}