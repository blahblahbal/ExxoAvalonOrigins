using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles.Summon;

public class PriminiCannon : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Primini");
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/Summon/PriminiCannon");
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
        Main.player[Projectile.owner].AddBuff(ModContent.BuffType<Buffs.PrimeArms>(), 3600);
        if (Projectile.type == ModContent.ProjectileType<PriminiCannon>())
        {
            if (Main.player[Projectile.owner].dead)
            {
                Main.player[Projectile.owner].Avalon().primeMinion = false;
            }
            if (Main.player[Projectile.owner].Avalon().primeMinion)
            {
                Projectile.timeLeft = 2;
            }
        }
        if (Projectile.type == ModContent.ProjectileType<PriminiCannon>())
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
            Projectile.ai[0] += 1f;
            var num954 = ExxoAvalonOriginsGlobalNPC.FindClosest(Projectile.position, 640f);
            if (num954 == -1)
            {
                Projectile.rotation = 0.78539816f; // -
                return;
            }
            Projectile.rotation = Vector2.Normalize(Main.npc[num954].Center - Projectile.Center).ToRotation() + 1.57079637f;
            if (Projectile.ai[0] > 240f && Collision.CanHit(Projectile.position, Projectile.width, Projectile.height, Main.npc[num954].position, Main.npc[num954].width, Main.npc[num954].height))
            {
                var num955 = Projectile.NewProjectile(Projectile.position.X, Projectile.position.Y, 0f, 0f, ProjectileID.Grenade, 80, 4.5f, Projectile.owner, 0f, 0f);
                Main.projectile[num955].velocity = Vector2.Normalize(Main.npc[num954].Center - Projectile.Center) * new Vector2(12f, 1f);
                Main.projectile[num955].timeLeft = 100;
                Main.projectile[num955].friendly = true;
                Main.projectile[num955].hostile = false;
                Projectile.ai[0] = 0f;
                return;
            }
        }
    }
}