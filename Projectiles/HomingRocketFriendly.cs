using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Projectiles;

public class HomingRocketFriendly : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Homing Rocket");
    }

    public override void SetDefaults()
    {
        Projectile.width = 14;
        Projectile.height = 14;
        Projectile.aiStyle = -1;
        Projectile.friendly = true;
        Projectile.hostile = false;
        Projectile.DamageType = DamageClass.Ranged;
        Projectile.penetrate = 1;
    }
    public override void Kill(int timeLeft)
    {
        foreach (NPC P in Main.npc)
        {
            if (P.getRect().Intersects(Projectile.getRect()))
            {
                P.StrikeNPC(Projectile.damage, Projectile.knockBack, 0);
            }
        }
        SoundEngine.PlaySound(SoundID.Item, (int)Projectile.position.X, (int)Projectile.position.Y, 14);
        Projectile.position.X = Projectile.position.X + (float)(Projectile.width / 2);
        Projectile.position.Y = Projectile.position.Y + (float)(Projectile.height / 2);
        Projectile.width = 22;
        Projectile.height = 22;
        Projectile.position.X = Projectile.position.X - (float)(Projectile.width / 2);
        Projectile.position.Y = Projectile.position.Y - (float)(Projectile.height / 2);
        for (int num341 = 0; num341 < 30; num341++)
        {
            int num342 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Smoke, 0f, 0f, 100, default(Color), 1.5f);
            Main.dust[num342].velocity *= 1.4f;
        }
        for (int num343 = 0; num343 < 20; num343++)
        {
            int num344 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default(Color), 3.5f);
            Main.dust[num344].noGravity = true;
            Main.dust[num344].velocity *= 7f;
            num344 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default(Color), 1.5f);
            Main.dust[num344].velocity *= 3f;
        }
        for (int num345 = 0; num345 < 2; num345++)
        {
            float scaleFactor8 = 0.4f;
            if (num345 == 1)
            {
                scaleFactor8 = 0.8f;
            }
            int num346 = Gore.NewGore(new Vector2(Projectile.position.X, Projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
            Main.gore[num346].velocity *= scaleFactor8;
            Gore expr_A0B0_cp_0 = Main.gore[num346];
            expr_A0B0_cp_0.velocity.X = expr_A0B0_cp_0.velocity.X + 1f;
            Gore expr_A0D0_cp_0 = Main.gore[num346];
            expr_A0D0_cp_0.velocity.Y = expr_A0D0_cp_0.velocity.Y + 1f;
            num346 = Gore.NewGore(new Vector2(Projectile.position.X, Projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
            Main.gore[num346].velocity *= scaleFactor8;
            Gore expr_A153_cp_0 = Main.gore[num346];
            expr_A153_cp_0.velocity.X = expr_A153_cp_0.velocity.X - 1f;
            Gore expr_A173_cp_0 = Main.gore[num346];
            expr_A173_cp_0.velocity.Y = expr_A173_cp_0.velocity.Y + 1f;
            num346 = Gore.NewGore(new Vector2(Projectile.position.X, Projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
            Main.gore[num346].velocity *= scaleFactor8;
            Gore expr_A1F6_cp_0 = Main.gore[num346];
            expr_A1F6_cp_0.velocity.X = expr_A1F6_cp_0.velocity.X + 1f;
            Gore expr_A216_cp_0 = Main.gore[num346];
            expr_A216_cp_0.velocity.Y = expr_A216_cp_0.velocity.Y - 1f;
            num346 = Gore.NewGore(new Vector2(Projectile.position.X, Projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
            Main.gore[num346].velocity *= scaleFactor8;
            Gore expr_A299_cp_0 = Main.gore[num346];
            expr_A299_cp_0.velocity.X = expr_A299_cp_0.velocity.X - 1f;
            Gore expr_A2B9_cp_0 = Main.gore[num346];
            expr_A2B9_cp_0.velocity.Y = expr_A2B9_cp_0.velocity.Y - 1f;
        }
    }
    public override void AI()
    {
        if (Math.Abs(Projectile.velocity.X) >= 5f || Math.Abs(Projectile.velocity.Y) >= 5f)
        {
            for (int num264 = 0; num264 < 2; num264++)
            {
                float num265 = 0f;
                float num266 = 0f;
                if (num264 == 1)
                {
                    num265 = Projectile.velocity.X * 0.5f;
                    num266 = Projectile.velocity.Y * 0.5f;
                }
                int num267 = Dust.NewDust(new Vector2(Projectile.position.X + 3f + num265, Projectile.position.Y + 3f + num266) - Projectile.velocity * 0.5f, Projectile.width - 8, Projectile.height - 8, DustID.Torch, 0f, 0f, 100, default(Color), 1f);
                Main.dust[num267].scale *= 2f + (float)Main.rand.Next(10) * 0.1f;
                Main.dust[num267].velocity *= 0.2f;
                Main.dust[num267].noGravity = true;
                num267 = Dust.NewDust(new Vector2(Projectile.position.X + 3f + num265, Projectile.position.Y + 3f + num266) - Projectile.velocity * 0.5f, Projectile.width - 8, Projectile.height - 8, DustID.Smoke, 0f, 0f, 100, default(Color), 0.5f);
                Main.dust[num267].fadeIn = 1f + (float)Main.rand.Next(5) * 0.1f;
                Main.dust[num267].velocity *= 0.05f;
            }
        }
        if (Math.Abs(Projectile.velocity.X) < 15f && Math.Abs(Projectile.velocity.Y) < 15f)
        {
            Projectile.velocity *= 1.1f;
        }
        Projectile.rotation = (float)Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X) + 1.57f;
        for (int p = 0; p < Main.npc.Length; p++)
        {
            if (Main.npc[p].active)
            {
                if (ClassExtensions.NewRectVector2(Main.npc[p].position, new Vector2(Main.npc[p].width, Main.npc[p].height)).Intersects(ClassExtensions.NewRectVector2(Projectile.position, new Vector2(Projectile.width, Projectile.height))))
                {
                    Projectile.timeLeft = 3;
                    break;
                }
            }
        }
        if (Projectile.timeLeft <= 3)
        {
            Projectile.position.X = Projectile.position.X + Projectile.width / 2;
            Projectile.position.Y = Projectile.position.Y + Projectile.height / 2;
            Projectile.width = 128;
            Projectile.height = 128;
            Projectile.position.X = Projectile.position.X - Projectile.width / 2;
            Projectile.position.Y = Projectile.position.Y - Projectile.height / 2;
            Projectile.knockBack = 8f;
            Projectile.Kill();
        }
        float num26 = (float)Math.Sqrt(Projectile.velocity.X * Projectile.velocity.X + Projectile.velocity.Y * Projectile.velocity.Y);
        float num27 = Projectile.localAI[0];
        if (num27 == 0f)
        {
            Projectile.localAI[0] = num26;
            num27 = num26;
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
            var num42 = num27;
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
    }
}