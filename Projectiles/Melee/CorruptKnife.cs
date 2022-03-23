using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles.Melee
{
    public class CorruptKnife : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Corrupt Knife");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/Melee/CorruptKnife");
            projectile.width = dims.Width * 30 / 30;
            projectile.height = dims.Height / Main.projFrames[projectile.type];
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.melee = true;
            projectile.light = 0.6f;
            projectile.ignoreWater = true;
            projectile.extraUpdates = 0;
        }

        public override void AI()
        {
            projectile.rotation += (Math.Abs(projectile.velocity.X) + Math.Abs(projectile.velocity.Y)) * 0.03f * projectile.direction;
            projectile.ai[0] += 1f;
            if (projectile.ai[0] < 30f)
            {
                projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
            }
            if (projectile.velocity.Y > 16f)
            {
                projectile.velocity.Y = 16f;
            }
        }

        public override void Kill(int timeLeft)
        {
            for (int num84 = 0; num84 < 2; num84++)
            {
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, projectile.velocity.X, projectile.velocity.Y, ProjectileID.TinyEater, projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
            }
            for (int num85 = 0; num85 < 3; num85++)
            {
                int num86 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Water_Hallowed, 0f, 0f, 100, default(Color), 0.8f);
                Main.dust[num86].noGravity = true;
                Main.dust[num86].velocity *= 1.2f;
                Main.dust[num86].velocity -= projectile.oldVelocity * 0.3f;
            }
        }
    }
}
