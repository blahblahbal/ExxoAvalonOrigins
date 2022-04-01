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
            Projectile.netImportant = true;
            Projectile.width = dims.Width * 30 / 18;
            Projectile.height = dims.Height * 30 / 18 / Main.projFrames[Projectile.type];
            Projectile.aiStyle = -1;
            Projectile.penetrate = -1;
            Projectile.timeLeft *= 5;
            Projectile.minion = true;
            Projectile.minionSlots = 0.25f;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.friendly = true;
            Main.projPet[Projectile.type] = true;
        }

        public override void AI()
        {
            if (Main.player[Projectile.owner].dead)
            {
                Main.player[Projectile.owner].Avalon().primeMinion = false;
            }
            if (Main.player[Projectile.owner].Avalon().primeMinion)
            {
                Projectile.timeLeft = 2;
            }
            if (Projectile.type == ModContent.ProjectileType<PriminiSaw>())
            {
                if (Projectile.position.Y > Main.player[Projectile.owner].Center.Y - Main.rand.Next(60, 80))
                {
                    if (Projectile.velocity.Y > 0f)
                    {
                        Projectile.velocity.Y = Projectile.velocity.Y * 0.96f;
                    }
                    Projectile.velocity.Y = Projectile.velocity.Y - 0.3f;
                    if (Projectile.velocity.Y > 6f)
                    {
                        Projectile.velocity.Y = 6f;
                    }
                }
                else if (Projectile.position.Y < Main.player[Projectile.owner].Center.Y - Main.rand.Next(60, 80))
                {
                    if (Projectile.velocity.Y < 0f)
                    {
                        Projectile.velocity.Y = Projectile.velocity.Y * 0.96f;
                    }
                    Projectile.velocity.Y = Projectile.velocity.Y + 0.2f;
                    if (Projectile.velocity.Y < -6f)
                    {
                        Projectile.velocity.Y = -6f;
                    }
                }
                if (Projectile.Center.X > Main.player[Projectile.owner].Center.X + Main.rand.Next(45, 65))
                {
                    if (Projectile.velocity.X > 0f)
                    {
                        Projectile.velocity.X = Projectile.velocity.X * 0.94f;
                    }
                    Projectile.velocity.X = Projectile.velocity.X - 0.3f;
                    if (Projectile.velocity.X > 9f)
                    {
                        Projectile.velocity.X = 9f;
                    }
                }
                if (Projectile.Center.X < Main.player[Projectile.owner].Center.X + Main.rand.Next(45, 65))
                {
                    if (Projectile.velocity.X < 0f)
                    {
                        Projectile.velocity.X = Projectile.velocity.X * 0.94f;
                    }
                    Projectile.velocity.X = Projectile.velocity.X + 0.2f;
                    if (Projectile.velocity.X < -8f)
                    {
                        Projectile.velocity.X = -8f;
                    }
                }
                var num956 = ExxoAvalonOriginsGlobalNPC.FindClosest(Projectile.position, 640f);
                if (num956 == -1)
                {
                    Projectile.rotation = 2.35619449f; // +
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
                Projectile.rotation = Vector2.Normalize(Main.npc[num956].Center - Projectile.Center).ToRotation() + 1.57079637f;
                if (Collision.CanHit(Projectile.position, Projectile.width, Projectile.height, Main.npc[num956].position, Main.npc[num956].width, Main.npc[num956].height))
                {
                    if (!Main.npc[num956].active)
                    {
                        Projectile.ai[1] = 0f;
                        return;
                    }
                    Projectile.ai[1] += 1f;
                    if (Projectile.ai[1] >= 50f)
                    {
                        Projectile.velocity = Vector2.Normalize(Main.npc[num956].Center - Projectile.Center) * 9f;
                        return;
                    }
                }
            }
        }
    }
}
