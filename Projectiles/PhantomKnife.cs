using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class PhantomKnife : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Phantom Knife");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/PhantomKnife");
            projectile.width = 30;
            projectile.height = 30;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.magic = true;
            projectile.ignoreWater = true;
            projectile.extraUpdates = 0;
        }
        public override bool PreAI()
        {
            Lighting.AddLight(projectile.position, 145 / 255, 1, 1);
            return true;
        }
        public override void AI()
        {
            projectile.localAI[1]++;

            projectile.rotation += (Math.Abs(projectile.velocity.X) + Math.Abs(projectile.velocity.Y)) * 0.03f * projectile.direction;

            if (projectile.type == ModContent.ProjectileType<PhantomKnife>())
            {
                projectile.ai[0] += 1f;
                if (projectile.ai[0] >= 30f)
                {
                    projectile.alpha += 10;
                    if (projectile.alpha >= 255)
                    {
                        projectile.active = false;
                    }
                }
                if (projectile.ai[0] < 30f)
                {
                    projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
                }
            }
            if (projectile.velocity.Y > 16f)
            {
                projectile.velocity.Y = 16f;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            ghostHurt(projectile.damage, projectile.position);
        }

        public override void OnHitPvp(Player target, int damage, bool crit)
        {
            ghostHurt(projectile.damage, projectile.position);
        }

        public void ghostHurt(int dmg, Vector2 Position)
        {
            if (!projectile.magic || projectile.damage <= 0)
            {
                return;
            }
            int num = projectile.damage;
            if (dmg <= 1)
            {
                return;
            }
            int[] array = new int[200];
            int num4 = 0;
            _ = new int[200];
            int num5 = 0;
            for (int i = 0; i < 200; i++)
            {
                if (!Main.npc[i].CanBeChasedBy(this))
                {
                    continue;
                }
                float num6 = Math.Abs(Main.npc[i].position.X + (float)(Main.npc[i].width / 2) - projectile.position.X + (float)(projectile.width / 2)) + Math.Abs(Main.npc[i].position.Y + (float)(Main.npc[i].height / 2) - projectile.position.Y + (float)(projectile.height / 2));
                if (num6 < 800f)
                {
                    if (Collision.CanHit(projectile.position, 1, 1, Main.npc[i].position, Main.npc[i].width, Main.npc[i].height) && num6 > 50f)
                    {
                        array[num5] = i;
                        num5++;
                    }
                    else if (num5 == 0)
                    {
                        array[num4] = i;
                        num4++;
                    }
                }
            }
            if (num4 != 0 || num5 != 0)
            {
                int num2 = ((num5 <= 0) ? array[Main.rand.Next(num4)] : array[Main.rand.Next(num5)]);
                float num7 = Main.rand.Next(-100, 101);
                float num8 = Main.rand.Next(-100, 101);
                float num9 = (float)Math.Sqrt(num7 * num7 + num8 * num8);
                num9 = 4f / num9;
                num7 *= num9;
                num8 *= num9;
                Projectile.NewProjectile(Position, new Vector2(num7, num8), ModContent.ProjectileType<Projectiles.SpectreSplit>(), num, 0f, projectile.owner, num2);
            }
        }
    }
}
