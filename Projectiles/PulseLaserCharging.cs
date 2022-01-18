using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class PulseLaserCharging : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pulse Laser Charging");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/PulseLaserCharging");
            projectile.width = dims.Width;
            projectile.height = dims.Height / Main.projFrames[projectile.type];
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.light = 0.5f;
            projectile.alpha = 50;
            projectile.scale = 1.2f;
            projectile.timeLeft = 10;
            projectile.ranged = true;
            projectile.tileCollide = false;
            projectile.damage = 0;
        }

        public override void AI()
        {
            projectile.ai[0]++;
            Projectile P = projectile;
            Player O = Main.player[P.owner];
            if (P.ai[0] == 5)
            {
                Projectile.NewProjectile(P.Center, P.velocity, ModContent.ProjectileType<PulseLaser>(), P.damage, P.knockBack);
            }
            float MY = Main.mouseY + Main.screenPosition.Y;
            float MX = Main.mouseX + Main.screenPosition.X;
            if (Main.myPlayer == P.owner)
            {
                if (O.channel)
                {
                    float num119 = 0f;
                    if (O.inventory[O.selectedItem].shoot == P.type)
                    {
                        num119 = O.inventory[O.selectedItem].shootSpeed * P.scale;
                    }
                    float num120 = MX - O.Center.X;
                    float num121 = MY - O.Center.Y;
                    float num122 = (float)Math.Sqrt(num120 * num120 + num121 * num121);
                    num122 = num119 / num122;
                    num120 *= num122;
                    num121 *= num122;
                    if (num120 != P.velocity.X || num121 != P.velocity.Y)
                    {
                        P.netUpdate = true;
                    }
                    P.velocity.X = num120;
                    P.velocity.Y = num121;
                    P.timeLeft = 20;
                }
                else
                {
                    P.Kill();
                    return;
                }
            }
        }
    }
}
