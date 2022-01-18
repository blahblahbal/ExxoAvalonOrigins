using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class PriminiLaser : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Primini");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/PriminiLaser");
            projectile.netImportant = true;
            projectile.width = dims.Width;
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
                Main.player[projectile.owner].GetModPlayer<ExxoAvalonOriginsModPlayer>().primeMinion = false;
            }
            if (Main.player[projectile.owner].GetModPlayer<ExxoAvalonOriginsModPlayer>().primeMinion)
            {
                projectile.timeLeft = 2;
            }
            if (projectile.type == ModContent.ProjectileType<PriminiLaser>())
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
                if (projectile.Center.X > Main.player[projectile.owner].Center.X - Main.rand.Next(45, 65))
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
                if (projectile.Center.X < Main.player[projectile.owner].Center.X - Main.rand.Next(45, 65))
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
                var num957 = ExxoAvalonOriginsGlobalNPC.FindClosest(projectile.position, 640f);
                if (num957 == -1)
                {
                    projectile.rotation = -0.785398164f; // -2.3561945f;
                    return;
                }
                projectile.rotation = Vector2.Normalize(Main.npc[num957].Center - projectile.Center).ToRotation() + 1.57079637f;
                if (Collision.CanHit(projectile.position, projectile.width, projectile.height, Main.npc[num957].position, Main.npc[num957].width, Main.npc[num957].height))
                {
                    if (!Main.npc[num957].active)
                    {
                        projectile.ai[1] = 0f;
                        return;
                    }
                    projectile.ai[1] += 1f;
                    if (projectile.ai[1] <= 50f)
                    {
                        projectile.velocity = Vector2.Normalize(Main.npc[num957].Center - projectile.Center) * 9f;
                        if (projectile.ai[1] == 50f)
                        {
                            projectile.ai[1] = 95f;
                            return;
                        }
                    }
                    else if (projectile.ai[1] >= 95f)
                    {
                        var num958 = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 1.5f, 1.5f, ProjectileID.MiniRetinaLaser, 70, 4.5f, projectile.owner, 0f, 0f);
                        Main.projectile[num958].velocity = Vector2.Normalize(Main.npc[num957].Center - projectile.Center) * 8f;
                        projectile.ai[1] = 51f;
                        return;
                    }
                }
            }
        }
    }
}
