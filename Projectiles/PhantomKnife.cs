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
            Projectile.width = 30;
            Projectile.height = 30;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.penetrate = 1;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.ignoreWater = true;
            Projectile.extraUpdates = 0;
        }
        public override bool PreAI()
        {
            Lighting.AddLight(Projectile.position, 145 / 255, 1, 1);
            return true;
        }
        public override void AI()
        {
            Projectile.localAI[1]++;

            Projectile.rotation += (Math.Abs(Projectile.velocity.X) + Math.Abs(Projectile.velocity.Y)) * 0.03f * Projectile.direction;

            if (Projectile.type == ModContent.ProjectileType<PhantomKnife>())
            {
                Projectile.ai[0] += 1f;
                if (Projectile.ai[0] >= 30f)
                {
                    Projectile.alpha += 10;
                    if (Projectile.alpha >= 255)
                    {
                        Projectile.active = false;
                    }
                }
                if (Projectile.ai[0] < 30f)
                {
                    Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.57f;
                }
            }
            if (Projectile.velocity.Y > 16f)
            {
                Projectile.velocity.Y = 16f;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            ghostHurt(Projectile.damage, Projectile.position);
        }

        public override void OnHitPvp(Player target, int damage, bool crit)
        {
            ghostHurt(Projectile.damage, Projectile.position);
        }

        public void ghostHurt(int dmg, Vector2 Position)
        {
            if (!Projectile.magic || Projectile.damage <= 0)
            {
                return;
            }
            int num = Projectile.damage;
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
                float num6 = Math.Abs(Main.npc[i].position.X + (float)(Main.npc[i].width / 2) - Projectile.position.X + (float)(Projectile.width / 2)) + Math.Abs(Main.npc[i].position.Y + (float)(Main.npc[i].height / 2) - Projectile.position.Y + (float)(Projectile.height / 2));
                if (num6 < 800f)
                {
                    if (Collision.CanHit(Projectile.position, 1, 1, Main.npc[i].position, Main.npc[i].width, Main.npc[i].height) && num6 > 50f)
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
                Projectile.NewProjectile(Position, new Vector2(num7, num8), ModContent.ProjectileType<Projectiles.SpectreSplit>(), num, 0f, Projectile.owner, num2);
            }
        }
    }
}
