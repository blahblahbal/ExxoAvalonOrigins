using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class PriminiVice : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Primini");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/PriminiVice");
            projectile.netImportant = true;
            projectile.width = dims.Width * 30 / 22;
            projectile.height = dims.Height * 30 / 22 / Main.projFrames[projectile.type];
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
                Main.player[projectile.owner].GetModPlayer<ExxoAvalonOriginsModPlayer>().primeMinion = false;
            }
            if (Main.player[projectile.owner].GetModPlayer<ExxoAvalonOriginsModPlayer>().primeMinion)
            {
                projectile.timeLeft = 2;
            }
            if (projectile.type == ModContent.ProjectileType<PriminiVice>())
            {
                if (projectile.position.Y > Main.player[projectile.owner].Center.Y + Main.rand.Next(-10, 0))
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
                else if (projectile.position.Y < Main.player[projectile.owner].Center.Y + Main.rand.Next(-10, 0))
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
                var num959 = ExxoAvalonOriginsGlobalNPC.FindClosest(projectile.position, 480f);
                if (num959 == -1)
                {
                    projectile.rotation = -2.3561945f;
                    return;
                }
                if (Collision.CanHit(projectile.position, projectile.width, projectile.height, Main.npc[num959].position, Main.npc[num959].width, Main.npc[num959].height))
                {
                    if (!Main.npc[num959].active)
                    {
                        projectile.ai[1] = 0f;
                        return;
                    }
                    projectile.ai[1] += 1f;
                    if (projectile.ai[1] >= 50f)
                    {
                        projectile.velocity = Vector2.Normalize(Main.npc[num959].Center - projectile.Center) * 9f;
                        return;
                    }
                    if (projectile.ai[1] >= 100f)
                    {
                        projectile.velocity = Vector2.Normalize(new Vector2(Main.npc[num959].Center.X - 50f, Main.npc[num959].Center.Y)) * 2.5f;
                        return;
                    }
                    if (projectile.ai[1] >= 150f)
                    {
                        projectile.velocity = Vector2.Normalize(new Vector2(Main.npc[num959].Center.X + 50f, Main.npc[num959].Center.Y)) * 2.5f;
                        return;
                    }
                }
            }
        }
    }
}
