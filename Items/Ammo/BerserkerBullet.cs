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
            item.shootSpeed = 6f;
            item.damage = 18;
            item.ammo = AmmoID.Bullet;
            item.ranged = true;
            item.consumable = true;
            item.rare = ItemRarityID.Cyan;
            item.width = dims.Width;
            item.knockBack = 4f;
            item.shoot = ModContent.ProjectileType<Projectiles.BerserkerBullet>();
            item.maxStack = 2000;
            item.value = 200;
            item.height = dims.Height;
        }
    }
}
