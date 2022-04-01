using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Ammo
{
    class TritonBullet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Triton Bullet");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.shootSpeed = 11f;
            Item.damage = 17;
            Item.ammo = AmmoID.Bullet;
            Item.DamageType = DamageClass.Ranged;
            Item.consumable = true;
            Item.rare = ItemRarityID.Yellow;
            Item.width = dims.Width;
            Item.knockBack = 20f;
            Item.shoot = ModContent.ProjectileType<Projectiles.TritonBullet>();
            Item.maxStack = 2000;
            Item.value = 1200;
            Item.height = dims.Height;
        }
    }
}
