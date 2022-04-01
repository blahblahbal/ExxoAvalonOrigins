﻿using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Projectiles
{
    public class UltrabrightRazorbladeBullet : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ultrabright Razorblade Bullet");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/UltrabrightRazorbladeBullet");
            Projectile.width = dims.Width * 4 / 20;
            Projectile.height = dims.Height * 4 / 20 / Main.projFrames[Projectile.type];
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.penetrate = 1;
            Projectile.light = 3f;
            Projectile.alpha = 0;
            Projectile.scale = 1.2f;
            Projectile.timeLeft = 1200;
            Projectile.DamageType = DamageClass.Ranged;
        }
        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item, (int)Projectile.position.X, (int)Projectile.position.Y, 14);
            for (int num200 = 0; num200 < 7; num200++)
            {
                Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.DungeonSpirit, 0f, 0f, 100, default(Color), 1.5f);
            }
            for (int i = 0; i < 2; i++)
            {
                float num134 = -Projectile.velocity.X * (float)Main.rand.Next(40, 70) * 0.01f + (float)Main.rand.Next(-20, 21) * 0.9f;
                float num135 = -Projectile.velocity.Y * (float)Main.rand.Next(40, 70) * 0.01f + (float)Main.rand.Next(-20, 21) * 0.9f;
                Projectile.NewProjectile(Projectile.position.X + num134, Projectile.position.Y + num135, num134, num135, ModContent.ProjectileType<UltrabrightRazorbladeBulletTyphoon>(), Projectile.damage, 0f, Projectile.owner, 0f, 0f);
            }
        }
        public override void AI()
        {
            if (Projectile.type != ModContent.ProjectileType<UltrabrightRazorbladeBullet>())
            {
                Projectile.ai[0] += 1f;
            }
            Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.57f;
            if (Projectile.velocity.Y > 16f)
            {
                Projectile.velocity.Y = 16f;
            }
        }
    }
}
