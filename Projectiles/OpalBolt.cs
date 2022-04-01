﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Projectiles
{
    public class OpalBolt : ModProjectile
    {
        private Color color;
        private int dustId;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Opal Bolt");
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.SapphireBolt);
            Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/OpalBolt");
            Projectile.width = dims.Width * 10 / 16;
            Projectile.height = dims.Height * 10 / 16 / Main.projFrames[Projectile.type];
            Projectile.aiStyle = -1;
            Projectile.penetrate = 1;

            color = new Color(86, 39, 255) * 0.7f;
            dustId = ModContent.DustType<Dusts.OpalDust>();
        }

        public override void AI()
        {
            for (var i = 0; i < 2; i++)
            {
                if (Main.rand.NextFloat() < 0.85f)
                {
                    var dust = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, dustId, Projectile.velocity.X, Projectile.velocity.Y, 50, default, 1.2f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 0.3f;
                }
            }
            if (Projectile.ai[1] == 0f)
            {
                Projectile.ai[1] = 1f;
                SoundEngine.PlaySound(SoundID.Item, (int)Projectile.position.X, (int)Projectile.position.Y, 8);
            }

            Lighting.AddLight(new Vector2((int)((Projectile.position.X + (float)(Projectile.width / 2)) / 16f), (int)((Projectile.position.Y + (float)(Projectile.height / 2)) / 16f)), color.ToVector3());
        }

        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Dig, (int)Projectile.position.X, (int)Projectile.position.Y);
            for (int num453 = 0; num453 < 15; num453++)
            {
                int num454 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, dustId, Projectile.oldVelocity.X, Projectile.oldVelocity.Y, 50, default, 1.2f);
                Main.dust[num454].noGravity = true;
                Dust dust152 = Main.dust[num454];
                Dust dust226 = dust152;
                dust226.scale *= 1.25f;
                dust152 = Main.dust[num454];
                dust226 = dust152;
                dust226.velocity *= 0.5f;
            }
        }
    }
}
