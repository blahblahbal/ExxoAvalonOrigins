using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Ammo
{
    class BerserkerBullet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Berserker Bullet");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.shootSpeed = 6f;
            Item.damage = 18;
            Item.ammo = AmmoID.Bullet;
            Item.DamageType = DamageClass.Ranged;
            Item.consumable = true;
            Item.rare = ItemRarityID.Cyan;
            Item.width = dims.Width;
            Item.knockBack = 4f;
            Item.shoot = ModContent.ProjectileType<Projectiles.BerserkerBullet>();
            Item.maxStack = 2000;
            Item.value = 200;
            Item.height = dims.Height;
        }
    }
}
