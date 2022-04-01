using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Projectiles
{
    public class ElectricBolt : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Electric Bolt");
        }

        public override void SetDefaults()
        {
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.aiStyle = -1;
            Projectile.hostile = true;
            Projectile.ignoreWater = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.penetrate = 2;
            Projectile.GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().notReflect = true;
            Main.projFrames[Projectile.type] = 4;
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            if (Main.rand.Next(8) == 0) target.AddBuff(ModContent.BuffType<Buffs.Electrified>(), 60 * 6);
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(8) == 0) target.AddBuff(ModContent.BuffType<Buffs.Electrified>(), 60 * 8);
        }
        public override void Kill(int timeLeft)
        {
            int num279 = Main.rand.Next(5, 10);
            int num4;
            for (int num280 = 0; num280 < num279; num280 = num4 + 1)
            {
                int num281 = Dust.NewDust(Projectile.Center, 0, 0, DustID.GoldCritter_LessOutline, 0f, 0f, 100, default(Color), 0.5f);
                Dust dust = Main.dust[num281];
                dust.velocity *= 1.6f;
                Main.dust[num281].velocity.Y -= 1f;
                Main.dust[num281].position = Vector2.Lerp(Main.dust[num281].position, Projectile.Center, 0.5f);
                Main.dust[num281].noGravity = true;
                num4 = num280;
            }
        }
        public override void AI()
        {
            if (Projectile.type == ModContent.ProjectileType<ElectricBolt>())
            {
                if (Projectile.ai[1] == 0f && Projectile.hostile)
                {
                    Projectile.ai[1] = 1f;
                    SoundEngine.PlaySound(SoundID.Item, (int)Projectile.Center.X, (int)Projectile.Center.Y, 12);
                }
                Projectile.alpha -= 40;
                if (Projectile.alpha < 0)
                {
                    Projectile.alpha = 0;
                }
                Projectile.spriteDirection = Projectile.direction;
                Projectile.frameCounter++;
                if (Projectile.frameCounter >= 3)
                {
                    Projectile.frame++;
                    Projectile.frameCounter = 0;
                    if (Projectile.frame >= 4)
                    {
                        Projectile.frame = 0;
                    }
                }
                Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.Pi / 4;
                if (Projectile.direction == -1)
                {
                    Projectile.rotation += MathHelper.Pi;
                }
                Lighting.AddLight((int)Projectile.Center.X / 16, (int)Projectile.Center.Y / 16, 0.3f, 0.8f, 1.1f);
                Projectile.rotation = (float)Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X) + 1.57f;
                if (Projectile.velocity.Y > 16f)
                {
                    Projectile.velocity.Y = 16f;
                }
            }
        }
    }
}
