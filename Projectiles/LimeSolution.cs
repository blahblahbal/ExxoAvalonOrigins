﻿using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class LimeSolution : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lime Spray");
        }
        public override void SetDefaults()
        {
            projectile.width = 6;
            projectile.height = 6;
            projectile.friendly = true;
            projectile.alpha = 255;
            projectile.penetrate = -1;
            projectile.extraUpdates = 2;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
        }
        public override bool? CanCutTiles()
        {
            return false;
        }
        public override void AI()
        {

            int dustType = ModContent.DustType<Dusts.JungleSpray>();

            if (projectile.timeLeft > 133)
                projectile.timeLeft = 133;

            if (projectile.ai[0] > 7f)
            {
                float dustScale = 1f;

                if (projectile.ai[0] == 8f)
                    dustScale = 0.2f;
                else if (projectile.ai[0] == 9f)
                    dustScale = 0.4f;
                else if (projectile.ai[0] == 10f)
                    dustScale = 0.6f;
                else if (projectile.ai[0] == 11f)
                    dustScale = 0.8f;

                projectile.ai[0] += 1f;

                for (int i = 0; i < 1; i++)
                {
                    int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, dustType, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100);
                    Dust dust = Main.dust[dustIndex];
                    dust.noGravity = true;
                    dust.scale *= 1.75f;
                    dust.velocity.X *= 2f;
                    dust.velocity.Y *= 2f;
                    dust.scale *= dustScale;
                }
            }
            else
                projectile.ai[0] += 1f;

            projectile.rotation += 0.3f * projectile.direction;
        }
    }
}
