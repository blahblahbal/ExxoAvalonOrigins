using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles;

public class FeroziumBullet : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Ferozium Bullet");
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/FeroziumBullet");
        Projectile.width = dims.Width * 4 / 20;
        Projectile.height = dims.Height * 4 / 20 / Main.projFrames[Projectile.type];
        Projectile.aiStyle = -1;
        Projectile.friendly = true;
        Projectile.penetrate = 1;
        Projectile.light = 0.5f;
        Projectile.alpha = 0;
        Projectile.MaxUpdates = 1;
        Projectile.scale = 1.2f;
        Projectile.timeLeft = 900;
        Projectile.DamageType = DamageClass.Ranged;
    }

    public override void AI()
    {
        if (Projectile.type == ModContent.ProjectileType<Boomlash>() || Projectile.type == ModContent.ProjectileType<VileSpit>())
        {
            if (Projectile.alpha > 0)
            {
                Projectile.alpha -= 15;
            }
            if (Projectile.alpha < 0)
            {
                Projectile.alpha = 0;
            }
        }
        if ((Projectile.type == ModContent.ProjectileType<MissileBolt>() && Projectile.ai[1] < 45f) || (Projectile.type != ModContent.ProjectileType<VileSpit>() && Projectile.type != ModContent.ProjectileType<RottenBullet>() && Projectile.type != ModContent.ProjectileType<PatellaBullet>() && Projectile.type != ModContent.ProjectileType<Soundwave>() && Projectile.type != ModContent.ProjectileType<FeroziumBullet>() && Projectile.type != ModContent.ProjectileType<Electrobullet>() && Projectile.type != ModContent.ProjectileType<SpikeCannon>() && Projectile.type != ModContent.ProjectileType<PathogenBullet>() && Projectile.type != ModContent.ProjectileType<MagmaticBullet>() && Projectile.type != ModContent.ProjectileType<TritonBullet>() && Projectile.type != ModContent.ProjectileType<FocusBeam>() && Projectile.type != ModContent.ProjectileType<VileSpit>() && Projectile.type != ModContent.ProjectileType<InfectiousSpore>()))
        {
            Projectile.ai[0] += 1f;
        }
        if (Projectile.type == ModContent.ProjectileType<VileSpit>())
        {
            for (var j = 0; j < 2; j++)
            {
                var num19 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y + 2f), Projectile.width, Projectile.height, DustID.CorruptGibs, Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 80, default(Color), 1.3f);
                Main.dust[num19].velocity *= 0.3f;
                Main.dust[num19].noGravity = true;
            }
        }
        if (Projectile.type == ModContent.ProjectileType<InfectiousSpore>())
        {
            Projectile.frameCounter++;
            if (Projectile.frameCounter >= 6)
            {
                Projectile.frame++;
                Projectile.frameCounter = 0;
            }
            if (Projectile.frame >= 4)
            {
                Projectile.frame = 0;
            }
        }
        if (Projectile.type == ModContent.ProjectileType<KunzitePulseBolt>())
        {
            if (Projectile.alpha < 170)
            {
                for (var n = 0; n < 10; n++)
                {
                    var x = Projectile.position.X - Projectile.velocity.X / 10f * n;
                    var y = Projectile.position.Y - Projectile.velocity.Y / 10f * n;
                    var num25 = Dust.NewDust(new Vector2(x, y), 1, 1, DustID.UnusedWhiteBluePurple, 0f, 0f, 0, default(Color), 1f);
                    Main.dust[num25].alpha = Projectile.alpha;
                    Main.dust[num25].position.X = x;
                    Main.dust[num25].position.Y = y;
                    Main.dust[num25].velocity *= 0f;
                    Main.dust[num25].noGravity = true;
                }
            }
            if (Projectile.alpha > 0)
            {
                Projectile.alpha -= 25;
            }
            if (Projectile.alpha < 0)
            {
                Projectile.alpha = 0;
            }
        }
        else if (Projectile.type == ModContent.ProjectileType<BerserkerBullet>())
        {
            if (Projectile.alpha < 170)
            {
                for (var num26 = 0; num26 < 10; num26++)
                {
                    var x2 = Projectile.position.X - Projectile.velocity.X / 10f * num26;
                    var y2 = Projectile.position.Y - Projectile.velocity.Y / 10f * num26;
                    int num27;
                    num27 = Dust.NewDust(new Vector2(x2, y2), 1, 1, DustID.Ice_Pink, 0f, 0f, 0, default(Color), 1f);
                    Main.dust[num27].alpha = Projectile.alpha;
                    Main.dust[num27].position.X = x2;
                    Main.dust[num27].position.Y = y2;
                    Main.dust[num27].velocity *= 0f;
                    Main.dust[num27].noGravity = true;
                }
            }
            var num28 = (float)Math.Sqrt(Projectile.velocity.X * Projectile.velocity.X + Projectile.velocity.Y * Projectile.velocity.Y);
            var num29 = Projectile.localAI[0];
            if (num29 == 0f)
            {
                Projectile.localAI[0] = num28;
                num29 = num28;
            }
            if (Projectile.alpha > 0)
            {
                Projectile.alpha -= 25;
            }
            if (Projectile.alpha < 0)
            {
                Projectile.alpha = 0;
            }
            var num30 = Projectile.position.X;
            var num31 = Projectile.position.Y;
            var num32 = 300f;
            var flag = false;
            var num33 = 0;
            if (Projectile.ai[1] == 0f)
            {
                for (var num34 = 0; num34 < 200; num34++)
                {
                    if (Main.npc[num34].active && !Main.npc[num34].dontTakeDamage && !Main.npc[num34].friendly && Main.npc[num34].lifeMax > 5 && (Projectile.ai[1] == 0f || Projectile.ai[1] == num34 + 1))
                    {
                        var num35 = Main.npc[num34].position.X + Main.npc[num34].width / 2;
                        var num36 = Main.npc[num34].position.Y + Main.npc[num34].height / 2;
                        var num37 = Math.Abs(Projectile.position.X + Projectile.width / 2 - num35) + Math.Abs(Projectile.position.Y + Projectile.height / 2 - num36);
                        if (num37 < num32 && Collision.CanHit(new Vector2(Projectile.position.X + Projectile.width / 2, Projectile.position.Y + Projectile.height / 2), 1, 1, Main.npc[num34].position, Main.npc[num34].width, Main.npc[num34].height))
                        {
                            num32 = num37;
                            num30 = num35;
                            num31 = num36;
                            flag = true;
                            num33 = num34;
                        }
                    }
                }
                if (flag)
                {
                    Projectile.ai[1] = num33 + 1;
                }
                flag = false;
            }
            if (Projectile.ai[1] != 0f)
            {
                var num38 = (int)(Projectile.ai[1] - 1f);
                if (Main.npc[num38].active)
                {
                    var num39 = Main.npc[num38].position.X + Main.npc[num38].width / 2;
                    var num40 = Main.npc[num38].position.Y + Main.npc[num38].height / 2;
                    var num41 = Math.Abs(Projectile.position.X + Projectile.width / 2 - num39) + Math.Abs(Projectile.position.Y + Projectile.height / 2 - num40);
                    if (num41 < 1000f)
                    {
                        flag = true;
                        num30 = Main.npc[num38].position.X + Main.npc[num38].width / 2;
                        num31 = Main.npc[num38].position.Y + Main.npc[num38].height / 2;
                    }
                }
            }
            if (flag)
            {
                var num42 = num29;
                var vector = new Vector2(Projectile.position.X + Projectile.width * 0.5f, Projectile.position.Y + Projectile.height * 0.5f);
                var num43 = num30 - vector.X;
                var num44 = num31 - vector.Y;
                var num45 = (float)Math.Sqrt(num43 * num43 + num44 * num44);
                num45 = num42 / num45;
                num43 *= num45;
                num44 *= num45;
                var num46 = 8;
                Projectile.velocity.X = (Projectile.velocity.X * (num46 - 1) + num43) / num46;
                Projectile.velocity.Y = (Projectile.velocity.Y * (num46 - 1) + num44) / num46;
            }
        }
        else if (Projectile.type == ModContent.ProjectileType<MissileBolt>())
        {
            if (Projectile.localAI[0] == 0f)
            {
                Projectile.localAI[1] = Projectile.velocity.ToRotation();
                Projectile.localAI[0] = Projectile.velocity.Length();
            }
            Projectile.ai[1] += 1f;
            if (Projectile.ai[1] < 45f)
            {
                Projectile.velocity.Y = Projectile.velocity.Y + 0.02f;
            }
            if (Projectile.ai[1] == 45f)
            {
                var value = Projectile.Center;
                Dust.NewDust(value - Projectile.velocity, Projectile.width, Projectile.height, DustID.Torch, Projectile.direction * -0.4f, -1.4f, 0, default(Color), 1f);
                var num48 = 1.5f;
                Dust.NewDust(value - Projectile.velocity, Projectile.width, Projectile.height, DustID.Smoke, Projectile.direction * -0.4f, -1.4f, 0, default(Color), num48);
                Dust.NewDust(value - Projectile.velocity, Projectile.width, Projectile.height, DustID.Torch, Projectile.direction * -0.4f, 1.4f, 0, default(Color), 1f);
                num48 = 1.5f;
                Dust.NewDust(value - Projectile.velocity, Projectile.width, Projectile.height, DustID.Smoke, Projectile.direction * -0.4f, 1.4f, 0, default(Color), num48);
                Projectile.velocity = Projectile.localAI[1].ToRotationVector2() * Projectile.localAI[0] * 2.1f;
            }
            else
            {
                for (var num49 = 0; num49 < 5; num49++)
                {
                    var num50 = Projectile.velocity.X / 3f * num49;
                    var num51 = Projectile.velocity.Y / 3f * num49;
                    var num52 = 4;
                    var num53 = Dust.NewDust(new Vector2(Projectile.position.X + num52, Projectile.position.Y + num52), Projectile.width - num52 * 2, Projectile.height - num52 * 2, DustID.Torch, 0f, 0f, 100, default(Color), 1.2f);
                    Main.dust[num53].noGravity = true;
                    Main.dust[num53].velocity *= 0.1f;
                    Main.dust[num53].velocity += Projectile.velocity * 0.1f;
                    var dust5 = Main.dust[num53];
                    dust5.position.X = dust5.position.X - num50;
                    var dust6 = Main.dust[num53];
                    dust6.position.Y = dust6.position.Y - num51;
                }
                if (Main.rand.Next(5) == 0)
                {
                    var num54 = 4;
                    var num55 = Dust.NewDust(new Vector2(Projectile.position.X + num54, Projectile.position.Y + num54), Projectile.width - num54 * 2, Projectile.height - num54 * 2, DustID.Smoke, 0f, 0f, 100, default(Color), 0.6f);
                    Main.dust[num55].velocity *= 0.25f;
                    Main.dust[num55].velocity += Projectile.velocity * 0.5f;
                }
            }
        }
        else
        {
            if (Projectile.ai[0] >= 15f)
            {
                Projectile.ai[0] = 15f;
                Projectile.velocity.Y = Projectile.velocity.Y + 0.1f;
            }
        }
        if (Projectile.type == ModContent.ProjectileType<Soundwave>())
        {
            Projectile.scale = Math.Min(11f, 185.08197f * (float)Math.Pow(0.99111479520797729, Projectile.timeLeft));
            Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.57f;
            var v = Projectile.Center - new Vector2(Projectile.width * Projectile.scale / 2f, Projectile.height * Projectile.scale / 2f);
            var wH = new Vector2(Projectile.width * Projectile.scale, Projectile.height * Projectile.scale);
            var value2 = ExxoAvalonOrigins.NewRectVector2(v, wH);
            var npc = Main.npc;
            for (var num57 = 0; num57 < npc.Length; num57++)
            {
                var nPC = npc[num57];
                if (nPC.active && !nPC.dontTakeDamage && !nPC.friendly && nPC.life >= 1 && nPC.getRect().Intersects(value2))
                {
                    nPC.StrikeNPC(Projectile.damage, Projectile.knockBack, (nPC.Center.X < Projectile.Center.X) ? -1 : 1, false, false);
                }
            }
        }
        Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.57f;
        if (Projectile.velocity.Y > 16f)
        {
            Projectile.velocity.Y = 16f;
        }
    }
}