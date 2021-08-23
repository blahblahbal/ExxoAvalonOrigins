using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Projectiles{
    public class ElectricBolt : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Electric Bolt");
        }

        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 10;
            projectile.aiStyle = -1;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.magic = true;
            projectile.penetrate = 2;
            Main.projFrames[projectile.type] = 4;
        }        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            if (Main.rand.Next(8) == 0) target.AddBuff(ModContent.BuffType<Buffs.Electrified>(), 60 * 6);
        }        public override void Kill(int timeLeft)
        {
            int num279 = Main.rand.Next(5, 10);
            int num4;
            for (int num280 = 0; num280 < num279; num280 = num4 + 1)
            {
                int num281 = Dust.NewDust(projectile.Center, 0, 0, DustID.GoldCritter_LessOutline, 0f, 0f, 100, default(Color), 0.5f);
                Dust dust = Main.dust[num281];
                dust.velocity *= 1.6f;
                Main.dust[num281].velocity.Y -= 1f;
                Main.dust[num281].position = Vector2.Lerp(Main.dust[num281].position, projectile.Center, 0.5f);
                Main.dust[num281].noGravity = true;
                num4 = num280;
            }
        }        public override void AI()        {            if (projectile.type == ModContent.ProjectileType<ElectricBolt>())
            {
                if (projectile.ai[1] == 0f)
                {
                    projectile.ai[1] = 1f;
                    Main.PlaySound(SoundID.Item, (int)projectile.Center.X, (int)projectile.Center.Y, 12);
                }
                projectile.alpha -= 40;
                if (projectile.alpha < 0)
                {
                    projectile.alpha = 0;
                }
                projectile.spriteDirection = projectile.direction;
                projectile.frameCounter++;
                if (projectile.frameCounter >= 3)
                {
                    projectile.frame++;
                    projectile.frameCounter = 0;
                    if (projectile.frame >= 4)
                    {
                        projectile.frame = 0;
                    }
                }
                projectile.rotation = projectile.velocity.ToRotation() + MathHelper.Pi / 4;
                if (projectile.direction == -1)
                {
                    projectile.rotation += MathHelper.Pi;
                }
                Lighting.AddLight((int)projectile.Center.X / 16, (int)projectile.Center.Y / 16, 0.3f, 0.8f, 1.1f);
                projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
                if (projectile.velocity.Y > 16f)
                {
                    projectile.velocity.Y = 16f;
                }
            }        }    }}