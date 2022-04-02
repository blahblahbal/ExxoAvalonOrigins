using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Projectiles;

public class BerserkerBullet : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Berserker Bullet");
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/BerserkerBullet");
        Projectile.width = dims.Width * 4 / 20;
        Projectile.height = dims.Height * 4 / 20 / Main.projFrames[Projectile.type];
        Projectile.aiStyle = -1;
        Projectile.friendly = true;
        Projectile.penetrate = 1;
        Projectile.light = 0.8f;
        Projectile.alpha = 255;
        Projectile.MaxUpdates = 2;
        Projectile.scale = 1.2f;
        Projectile.timeLeft = 600;
        Projectile.DamageType = DamageClass.Ranged;
    }

    public override void Kill(int timeLeft)
    {
        SoundEngine.PlaySound(SoundID.Item, (int)Projectile.position.X, (int)Projectile.position.Y, 10);
        for (int num133 = 0; num133 < 3; num133++)
        {
            float num134 = -Projectile.velocity.X * Main.rand.Next(40, 70) * 0.01f + Main.rand.Next(-20, 21) * 0.4f;
            float num135 = -Projectile.velocity.Y * Main.rand.Next(40, 70) * 0.01f + Main.rand.Next(-20, 21) * 0.4f;
            Projectile.NewProjectile(Projectile.position.X + num134, Projectile.position.Y + num135, num134, num135, ModContent.ProjectileType<BerserkerCrystal>(), (int)((double)Projectile.damage * 0.5), 0f, Projectile.owner, 0f, 0f);
        }
    }

    public override void AI()
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
        var projPosStoredX = Projectile.position.X;
        var projPosStoredY = Projectile.position.Y;
        var distance = 300f;
        var flag = false;
        var npcArrayIndexStored = 0;
        if (Projectile.ai[1] == 0f)
        {
            for (var npcArrayIndex = 0; npcArrayIndex < 200; npcArrayIndex++)
            {
                if (Main.npc[npcArrayIndex].active && !Main.npc[npcArrayIndex].dontTakeDamage && !Main.npc[npcArrayIndex].friendly && Main.npc[npcArrayIndex].lifeMax > 5 && (Projectile.ai[1] == 0f || Projectile.ai[1] == npcArrayIndex + 1))
                {
                    var npcCenterX = Main.npc[npcArrayIndex].position.X + Main.npc[npcArrayIndex].width / 2;
                    var npcCenterY = Main.npc[npcArrayIndex].position.Y + Main.npc[npcArrayIndex].height / 2;
                    var num37 = Math.Abs(Projectile.position.X + Projectile.width / 2 - npcCenterX) + Math.Abs(Projectile.position.Y + Projectile.height / 2 - npcCenterY);
                    if (num37 < distance && Collision.CanHit(new Vector2(Projectile.position.X + Projectile.width / 2, Projectile.position.Y + Projectile.height / 2), 1, 1, Main.npc[npcArrayIndex].position, Main.npc[npcArrayIndex].width, Main.npc[npcArrayIndex].height))
                    {
                        distance = num37;
                        projPosStoredX = npcCenterX;
                        projPosStoredY = npcCenterY;
                        flag = true;
                        npcArrayIndexStored = npcArrayIndex;
                    }
                }
            }
            if (flag)
            {
                Projectile.ai[1] = npcArrayIndexStored + 1;
            }
            flag = false;
        }
        if (Projectile.ai[1] != 0f)
        {
            var npcArrayIndexAgain = (int)(Projectile.ai[1] - 1f);
            if (Main.npc[npcArrayIndexAgain].active)
            {
                var npcCenterX = Main.npc[npcArrayIndexAgain].position.X + Main.npc[npcArrayIndexAgain].width / 2;
                var npcCenterY = Main.npc[npcArrayIndexAgain].position.Y + Main.npc[npcArrayIndexAgain].height / 2;
                var num41 = Math.Abs(Projectile.position.X + Projectile.width / 2 - npcCenterX) + Math.Abs(Projectile.position.Y + Projectile.height / 2 - npcCenterY);
                if (num41 < 1000f)
                {
                    flag = true;
                    projPosStoredX = Main.npc[npcArrayIndexAgain].position.X + Main.npc[npcArrayIndexAgain].width / 2;
                    projPosStoredY = Main.npc[npcArrayIndexAgain].position.Y + Main.npc[npcArrayIndexAgain].height / 2;
                }
            }
        }
        if (flag)
        {
            var num42 = num29;
            var projCenter = new Vector2(Projectile.position.X + Projectile.width * 0.5f, Projectile.position.Y + Projectile.height * 0.5f);
            var num43 = projPosStoredX - projCenter.X;
            var num44 = projPosStoredY - projCenter.Y;
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