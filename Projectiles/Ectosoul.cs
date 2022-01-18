using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class Ectosoul : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ectosoul");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/Ectosoul");
            projectile.width = dims.Width * 12 / 1;
            projectile.height = dims.Height * 12 / 1 / Main.projFrames[projectile.type];
            projectile.aiStyle = -1;
            projectile.hostile = true;
            projectile.alpha = 255;
            projectile.magic = true;
            projectile.tileCollide = true;
            projectile.MaxUpdates = 1;
            projectile.penetrate = -1;
        }

        public override void AI()
        {
            if (projectile.localAI[0] == 0f)
            {
                Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 8);
                projectile.localAI[0] += 1f;
            }
            for (var num641 = 0; num641 < 9; num641++)
            {
                var num642 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.SpectreStaff, 0f, 0f, 100, default(Color), 1.3f);
                Main.dust[num642].noGravity = true;
                Main.dust[num642].velocity *= 0f;
            }
            var num643 = projectile.Center.X;
            var num644 = projectile.Center.Y;
            var num645 = 400f;
            var flag25 = false;
            num645 = 200f;
            for (var num650 = 0; num650 < 255; num650++)
            {
                if (Main.player[num650].active && !Main.player[num650].dead)
                {
                    var num651 = Main.player[num650].position.X + Main.player[num650].width / 2;
                    var num652 = Main.player[num650].position.Y + Main.player[num650].height / 2;
                    var num653 = Math.Abs(projectile.position.X + projectile.width / 2 - num651) + Math.Abs(projectile.position.Y + projectile.height / 2 - num652);
                    if (num653 < num645)
                    {
                        num645 = num653;
                        num643 = num651;
                        num644 = num652;
                        flag25 = true;
                    }
                }
            }
            if (flag25)
            {
                var num654 = 3f;
                var vector41 = new Vector2(projectile.position.X + projectile.width * 0.5f, projectile.position.Y + projectile.height * 0.5f);
                var num655 = num643 - vector41.X;
                var num656 = num644 - vector41.Y;
                var num657 = (float)Math.Sqrt(num655 * num655 + num656 * num656);
                num657 = num654 / num657;
                num655 *= num657;
                num656 *= num657;
                projectile.velocity.X = (projectile.velocity.X * 100f + num655) / 101f;
                projectile.velocity.Y = (projectile.velocity.Y * 100f + num656) / 101f;
            }
        }
    }
}