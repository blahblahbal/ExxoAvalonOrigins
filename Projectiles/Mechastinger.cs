using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class Mechastinger : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mechastinger");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/Mechastinger");
            Projectile.width = dims.Width * 4 / 20;
            Projectile.height = dims.Height * 4 / 20 / Main.projFrames[Projectile.type];
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.penetrate = 2;
            Projectile.scale = 1.2f;
            Projectile.timeLeft = 1200;
            Projectile.DamageType = DamageClass.Ranged;
        }

        public override void AI()
        {
            int num12 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.CorruptGibs, 0f, 0f, 0, default, 0.9f);
            Main.dust[num12].noGravity = true;
            Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.57f;
            if (Projectile.velocity.Y > 16f)
            {
                Projectile.velocity.Y = 16f;
            }
        }
    }
}
