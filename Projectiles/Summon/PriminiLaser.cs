using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles.Summon
{
    public class PriminiLaser : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Primini");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/Summon/PriminiLaser");
            Projectile.netImportant = true;
            Projectile.width = dims.Width;
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
            if (Projectile.type == ModContent.ProjectileType<PriminiLaser>())
            {
                if (Projectile.position.Y > Main.player[Projectile.owner].Center.Y + Main.rand.Next(-10, 0))
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
                else if (Projectile.position.Y < Main.player[Projectile.owner].Center.Y + Main.rand.Next(-10, 0))
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
                if (Projectile.Center.X > Main.player[Projectile.owner].Center.X - Main.rand.Next(45, 65))
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
                if (Projectile.Center.X < Main.player[Projectile.owner].Center.X - Main.rand.Next(45, 65))
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
                var num957 = ExxoAvalonOriginsGlobalNPC.FindClosest(Projectile.position, 640f);
                if (num957 == -1)
                {
                    Projectile.rotation = -0.785398164f; // -2.3561945f;
                    return;
                }
                Projectile.rotation = Vector2.Normalize(Main.npc[num957].Center - Projectile.Center).ToRotation() + 1.57079637f;
                if (Collision.CanHit(Projectile.position, Projectile.width, Projectile.height, Main.npc[num957].position, Main.npc[num957].width, Main.npc[num957].height))
                {
                    if (!Main.npc[num957].active)
                    {
                        Projectile.ai[1] = 0f;
                        return;
                    }
                    Projectile.ai[1] += 1f;
                    if (Projectile.ai[1] <= 50f)
                    {
                        Projectile.velocity = Vector2.Normalize(Main.npc[num957].Center - Projectile.Center) * 9f;
                        if (Projectile.ai[1] == 50f)
                        {
                            Projectile.ai[1] = 95f;
                            return;
                        }
                    }
                    else if (Projectile.ai[1] >= 95f)
                    {
                        var num958 = Projectile.NewProjectile(Projectile.position.X, Projectile.position.Y, 1.5f, 1.5f, ProjectileID.MiniRetinaLaser, 70, 4.5f, Projectile.owner, 0f, 0f);
                        Main.projectile[num958].velocity = Vector2.Normalize(Main.npc[num957].Center - Projectile.Center) * 8f;
                        Projectile.ai[1] = 51f;
                        return;
                    }
                }
            }
        }
    }
}
