using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles.Summon;

public class PriminiVice : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Primini");
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/Summon/PriminiVice");
        Projectile.netImportant = true;
        Projectile.width = dims.Width * 30 / 22;
        Projectile.height = dims.Height * 30 / 22 / Main.projFrames[Projectile.type];
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
        if (Projectile.type == ModContent.ProjectileType<PriminiVice>())
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
            var num959 = ExxoAvalonOriginsGlobalNPC.FindClosest(Projectile.position, 480f);
            if (num959 == -1)
            {
                Projectile.rotation = -2.3561945f;
                return;
            }
            if (Collision.CanHit(Projectile.position, Projectile.width, Projectile.height, Main.npc[num959].position, Main.npc[num959].width, Main.npc[num959].height))
            {
                if (!Main.npc[num959].active)
                {
                    Projectile.ai[1] = 0f;
                    return;
                }
                Projectile.ai[1] += 1f;
                if (Projectile.ai[1] >= 50f)
                {
                    Projectile.velocity = Vector2.Normalize(Main.npc[num959].Center - Projectile.Center) * 9f;
                    return;
                }
                if (Projectile.ai[1] >= 100f)
                {
                    Projectile.velocity = Vector2.Normalize(new Vector2(Main.npc[num959].Center.X - 50f, Main.npc[num959].Center.Y)) * 2.5f;
                    return;
                }
                if (Projectile.ai[1] >= 150f)
                {
                    Projectile.velocity = Vector2.Normalize(new Vector2(Main.npc[num959].Center.X + 50f, Main.npc[num959].Center.Y)) * 2.5f;
                    return;
                }
            }
        }
    }
}