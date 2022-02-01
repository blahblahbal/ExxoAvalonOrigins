using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class PumpkinHead : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pumpkin Head");
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(255, 255, 255, 100);
        }
        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/PumpkinHead");
            projectile.width = dims.Width;
            projectile.height = dims.Height * 30 / 36 / Main.projFrames[projectile.type];
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
        }

        public override void AI()
        {
            if (projectile.type == ProjectileID.FlamingJack)
            {
                projectile.frameCounter++;
                if (projectile.frameCounter > 0)
                {
                    projectile.frame++;
                    projectile.frameCounter = 0;
                    if (projectile.frame > 2)
                    {
                        projectile.frame = 0;
                    }
                }
            }
            if (projectile.velocity.X < 0f)
            {
                projectile.spriteDirection = -1;
                projectile.rotation = (float)Math.Atan2(-projectile.velocity.Y, -projectile.velocity.X);
            }
            else
            {
                projectile.spriteDirection = 1;
                projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X);
            }
            if (projectile.ai[0] >= 0f && projectile.ai[0] < 200f)
            {
                var num710 = (int)projectile.ai[0];
                if (Main.npc[num710].active)
                {
                    var num711 = 8f;
                    var vector46 = new Vector2(projectile.position.X + projectile.width * 0.5f, projectile.position.Y + projectile.height * 0.5f);
                    var num712 = Main.npc[num710].position.X - vector46.X;
                    var num713 = Main.npc[num710].position.Y - vector46.Y;
                    var num714 = (float)Math.Sqrt(num712 * num712 + num713 * num713);
                    num714 = num711 / num714;
                    num712 *= num714;
                    num713 *= num714;
                    projectile.velocity.X = (projectile.velocity.X * 14f + num712) / 15f;
                    projectile.velocity.Y = (projectile.velocity.Y * 14f + num713) / 15f;
                }
                else
                {
                    var num715 = 1000f;
                    for (var num716 = 0; num716 < 200; num716++)
                    {
                        if (Main.npc[num716].active && !Main.npc[num716].dontTakeDamage && !Main.npc[num716].friendly && Main.npc[num716].lifeMax > 5)
                        {
                            var num717 = Main.npc[num716].position.X + Main.npc[num716].width / 2;
                            var num718 = Main.npc[num716].position.Y + Main.npc[num716].height / 2;
                            var num719 = Math.Abs(projectile.position.X + projectile.width / 2 - num717) + Math.Abs(projectile.position.Y + projectile.height / 2 - num718);
                            if (num719 < num715 && Collision.CanHit(projectile.position, projectile.width, projectile.height, Main.npc[num716].position, Main.npc[num716].width, Main.npc[num716].height))
                            {
                                num715 = num719;
                                projectile.ai[0] = num716;
                            }
                        }
                    }
                }
                var num720 = 8;
                var num721 = Dust.NewDust(new Vector2(projectile.position.X + num720, projectile.position.Y + num720), projectile.width - num720 * 2, projectile.height - num720 * 2, DustID.Fire, 0f, 0f, 0, default(Color), 1f);
                Main.dust[num721].velocity *= 0.5f;
                Main.dust[num721].velocity += projectile.velocity * 0.5f;
                Main.dust[num721].noGravity = true;
                Main.dust[num721].noLight = true;
                Main.dust[num721].scale = 1.4f;
            }
            else
            {
                projectile.Kill();
            }
        }
    }
}