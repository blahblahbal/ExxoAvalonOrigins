using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Projectiles;

public class BlahBullet : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Blah Bullet");
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/BlahBullet");
        Projectile.width = dims.Width * 4 / 20;
        Projectile.height = dims.Height * 4 / 20 / Main.projFrames[Projectile.type];
        Projectile.aiStyle = -1;
        Projectile.friendly = true;
        Projectile.penetrate = 1;
        Projectile.light = 0.8f;
        Projectile.alpha = 255;
        Projectile.MaxUpdates = 2;
        Projectile.scale = 1f;
        Projectile.timeLeft = 600;
        Projectile.DamageType = DamageClass.Ranged;
    }
    public override void Kill(int timeLeft)
    {
        SoundEngine.PlaySound(SoundID.Item, (int)Projectile.position.X, (int)Projectile.position.Y, 14);
        for (int num200 = 0; num200 < 7; num200++)
        {
            Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Smoke, 0f, 0f, 100, default(Color), 1.5f);
        }
        for (int num201 = 0; num201 < 3; num201++)
        {
            int num202 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default(Color), 2.5f);
            Main.dust[num202].noGravity = true;
            Main.dust[num202].velocity *= 3f;
            num202 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default(Color), 1.5f);
            Main.dust[num202].velocity *= 2f;
        }
        int num203 = Gore.NewGore(new Vector2(Projectile.position.X - 10f, Projectile.position.Y - 10f), default(Vector2), Main.rand.Next(61, 64), 1f);
        Main.gore[num203].velocity *= 0.3f;
        Gore expr_639C_cp_0 = Main.gore[num203];
        expr_639C_cp_0.velocity.X = expr_639C_cp_0.velocity.X + (float)Main.rand.Next(-10, 11) * 0.05f;
        Gore expr_63CA_cp_0 = Main.gore[num203];
        expr_63CA_cp_0.velocity.Y = expr_63CA_cp_0.velocity.Y + (float)Main.rand.Next(-10, 11) * 0.05f;
        if (Projectile.owner == Main.myPlayer)
        {
            for (int num133 = 0; num133 < 3; num133++)
            {
                float num134 = -Projectile.velocity.X * (float)Main.rand.Next(40, 70) * 0.01f + (float)Main.rand.Next(-20, 21) * 0.9f;
                float num135 = -Projectile.velocity.Y * (float)Main.rand.Next(40, 70) * 0.01f + (float)Main.rand.Next(-20, 21) * 0.9f;
                Projectile.NewProjectile(Projectile.position.X + num134, Projectile.position.Y + num135, num134, num135, ModContent.ProjectileType<BlahBulletOffspring>(), Projectile.damage, 0f, Projectile.owner, 0f, 0f);
            }
        }
        if (Projectile.owner == Main.myPlayer)
        {
            Projectile.localAI[1] = -1f;
            Projectile.maxPenetrate = 0;
            Projectile.position.X = Projectile.position.X + (float)(Projectile.width / 2);
            Projectile.position.Y = Projectile.position.Y + (float)(Projectile.height / 2);
            Projectile.width = 80;
            Projectile.height = 80;
            Projectile.position.X = Projectile.position.X - (float)(Projectile.width / 2);
            Projectile.position.Y = Projectile.position.Y - (float)(Projectile.height / 2);
            Projectile.Damage();
        }
    }
    public override void AI()
    {
        Projectile.ai[0] += 1f;
        if (Projectile.alpha < 170)
        {
            for (var num26 = 0; num26 < 10; num26++)
            {
                var x2 = Projectile.position.X - Projectile.velocity.X / 10f * num26;
                var y2 = Projectile.position.Y - Projectile.velocity.Y / 10f * num26;
                int num27;
                num27 = Dust.NewDust(new Vector2(x2, y2), 1, 1, DustID.Torch, 0f, 0f, 0, default(Color), 1f);
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
        Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.57f;
        if (Projectile.velocity.Y > 16f)
        {
            Projectile.velocity.Y = 16f;
        }
    }
}