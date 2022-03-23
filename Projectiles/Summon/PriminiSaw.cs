using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles.Summon
{
    public class PriminiSaw : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Primini");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/Summon/PriminiSaw");
            projectile.netImportant = true;
            projectile.width = dims.Width * 30 / 18;
            projectile.height = dims.Height * 30 / 18 / Main.projFrames[projectile.type];
            projectile.aiStyle = -1;
            projectile.penetrate = -1;
            projectile.timeLeft *= 5;
            projectile.minion = true;
            projectile.minionSlots = 0.25f;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.friendly = true;
            Main.projPet[projectile.type] = true;
        }

        public override void AI()
        {
            if (Main.player[projectile.owner].dead)
            {
                Main.player[projectile.owner].Avalon().primeMinion = false;
            }
            if (Main.player[projectile.owner].Avalon().primeMinion)
            {
                projectile.timeLeft = 2;
            }
            if (projectile.type == ModContent.ProjectileType<PriminiSaw>())
            {
                if (projectile.position.Y > Main.player[projectile.owner].Center.Y - Main.rand.Next(60, 80))
                {
                    if (projectile.velocity.Y > 0f)
                    {
                        projectile.velocity.Y = projectile.velocity.Y * 0.96f;
                    }
                    projectile.velocity.Y = projectile.velocity.Y - 0.3f;
                    if (projectile.velocity.Y > 6f)
                    {
                        projectile.velocity.Y = 6f;
                    }
                }
                else if (projectile.position.Y < Main.player[projectile.owner].Center.Y - Main.rand.Next(60, 80))
                {
                    if (projectile.velocity.Y < 0f)
                    {
                        projectile.velocity.Y = projectile.velocity.Y * 0.96f;
                    }
                    projectile.velocity.Y = projectile.velocity.Y + 0.2f;
                    if (projectile.velocity.Y < -6f)
                    {
                        projectile.velocity.Y = -6f;
                    }
                }
                if (projectile.Center.X > Main.player[projectile.owner].Center.X + Main.rand.Next(45, 65))
                {
                    if (projectile.velocity.X > 0f)
                    {
                        projectile.velocity.X = projectile.velocity.X * 0.94f;
                    }
                    projectile.velocity.X = projectile.velocity.X - 0.3f;
                    if (projectile.velocity.X > 9f)
                    {
                        projectile.velocity.X = 9f;
                    }
                }
                if (projectile.Center.X < Main.player[projectile.owner].Center.X + Main.rand.Next(45, 65))
                {
                    if (projectile.velocity.X < 0f)
                    {
                        projectile.velocity.X = projectile.velocity.X * 0.94f;
                    }
                    projectile.velocity.X = projectile.velocity.X + 0.2f;
                    if (projectile.velocity.X < -8f)
                    {
                        projectile.velocity.X = -8f;
                    }
                }
                var num956 = ExxoAvalonOriginsGlobalNPC.FindClosest(projectile.position, 640f);
                if (num956 == -1)
                {
                    projectile.rotation = 2.35619449f; // +
                    return;
                }

                //Vector2 vector56 = projectile.position;
                //float num768 = 400f;
                //bool flag31 = false;
                //for (int num769 = 0; num769 < 200; num769++)
                //{
                //    NPC nPC4 = Main.npc[num769];
                //    if (nPC4.active && !nPC4.dontTakeDamage && !nPC4.friendly && nPC4.lifeMax > 5)
                //    {
                //        float num770 = Vector2.Distance(nPC4.Center, projectile.Center);
                //        if (((Vector2.Distance(projectile.Center, vector56) > num770 && num770 < num768) || !flag31) && Collision.CanHitLine(projectile.position, projectile.width, projectile.height, nPC4.position, nPC4.width, nPC4.height))
                //        {
                //            num768 = num770;
                //            vector56 = nPC4.Center;
                //            flag31 = true;
                //        }
                //    }
                //}
                //if (flag31 && projectile.ai[0] == 0f)
                //{
                //    Vector2 vector57 = vector56 - projectile.Center;
                //    float num772 = vector57.Length();
                //    vector57.Normalize();
                //    if (num772 > 200f)
                //    {
                //        float scaleFactor5 = 6f;
                //        vector57 *= scaleFactor5;
                //        projectile.velocity = (projectile.velocity * 40f + vector57) / 41f;
                //    }
                //    else
                //    {
                //        float num773 = 4f;
                //        vector57 *= -num773;
                //        projectile.velocity = (projectile.velocity * 40f + vector57) / 41f;
                //    }
                //}
                //projectile.rotation = projectile.velocity.ToRotation() + 3.14159274f;
                //if (projectile.ai[0] == 0)
                //{
                //    if (projectile.ai[1] == 0f && flag31 && num768 < 500f)
                //    {
                //        projectile.ai[1] += 1f;
                //        if (Main.myPlayer == projectile.owner)
                //        {
                //            projectile.ai[0] = 2f;
                //            Vector2 value21 = vector56 - projectile.Center;
                //            value21.Normalize();
                //            projectile.velocity = value21 * 8f;
                //            projectile.netUpdate = true;
                //        }
                //    }
                //}
                projectile.rotation = Vector2.Normalize(Main.npc[num956].Center - projectile.Center).ToRotation() + 1.57079637f;
                if (Collision.CanHit(projectile.position, projectile.width, projectile.height, Main.npc[num956].position, Main.npc[num956].width, Main.npc[num956].height))
                {
                    if (!Main.npc[num956].active)
                    {
                        projectile.ai[1] = 0f;
                        return;
                    }
                    projectile.ai[1] += 1f;
                    if (projectile.ai[1] >= 50f)
                    {
                        projectile.velocity = Vector2.Normalize(Main.npc[num956].Center - projectile.Center) * 9f;
                        return;
                    }
                }
            }
        }
    }
}
