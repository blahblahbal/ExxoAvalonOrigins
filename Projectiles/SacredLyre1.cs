using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class SacredLyre1 : ModProjectile
    {
        int timer = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lyre Note");
        }
        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/SacredLyre1");
            projectile.width = 16;
            projectile.height = 16;
            projectile.aiStyle = 21;
            projectile.magic = true;
            projectile.light = 0.8f;
            projectile.penetrate = -1;
            projectile.friendly = true;
            timer = 0;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.type == ModContent.ProjectileType<SacredLyre1>())
            {
                //Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 10);
                timer++;
                if (timer % 4 == 0)
                {
                    Vector2 c = projectile.Center;
                    float rot = (float)Math.Atan2(c.Y - 1, c.X - 1);
                    for (float f = 0; f < 3.6f; f += 0.4f)
                    {
                        Projectile.NewProjectile(c.X, c.Y, (float)(Math.Cos(rot + f) * 4f * -1.0), (float)(Math.Sin(rot + f) * 4f * -1.0), ModContent.ProjectileType<Shockwave>(), projectile.damage / 2, projectile.knockBack, projectile.owner);
                        Projectile.NewProjectile(c.X, c.Y, (float)(Math.Cos(rot - f) * 4f * -1.0), (float)(Math.Sin(rot - f) * 4f * -1.0), ModContent.ProjectileType<Shockwave>(), projectile.damage / 2, projectile.knockBack, projectile.owner);
                    }
                }
                //int p = Projectile.NewProjectile(projectile.position, Vector2.Zero, ModContent.ProjectileType<Shockwave2>(), projectile.damage / 2, projectile.knockBack, projectile.owner);
                //Main.projectile[p].Center = projectile.Center;
                //Main.projectile[p].ai[0] = projectile.Center.X;
                //Main.projectile[p].ai[1] = projectile.Center.Y;
                //else
                //{
                //    for (int num133 = 0; num133 < 4; num133++)
                //    {
                //        float num134 = -projectile.velocity.X * Main.rand.Next(40, 70) * 0.01f + Main.rand.Next(-20, 21) * 0.4f;
                //        float num135 = -projectile.velocity.Y * Main.rand.Next(40, 70) * 0.01f + Main.rand.Next(-20, 21) * 0.4f;
                //        int proj = Projectile.NewProjectile(projectile.position.X + num134, projectile.position.Y + num135, num134, num135, ProjectileID.CrystalShard, (int)(projectile.damage * 0.8), 0f, projectile.owner, 0f, 0f);
                //        Main.projectile[proj].ranged = false;
                //        Main.projectile[proj].magic = true;
                //    }
                //}
                projectile.ai[0] += 1f;
                if (projectile.ai[0] >= 9f)
                {
                    projectile.position += projectile.velocity;
                    projectile.Kill();
                }
                else
                {
                    if (projectile.velocity.Y != oldVelocity.Y)
                    {
                        projectile.velocity.Y = -oldVelocity.Y;
                    }
                    if (projectile.velocity.X != oldVelocity.X)
                    {
                        projectile.velocity.X = -oldVelocity.X;
                    }
                }
            }
            return false;
        }
    }
}
