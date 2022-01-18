using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class YuckyKnife : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Yucky Knife");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/YuckyKnife");
            projectile.width = dims.Width * 8 / 30;
            projectile.height = dims.Height * 8 / 30 / Main.projFrames[projectile.type];
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.melee = true;
            projectile.light = 0.6f;
            projectile.ignoreWater = true;
            projectile.extraUpdates = 0;
            projectile.timeLeft = 300;
        }

        public override void AI()
        {
            projectile.rotation += (Math.Abs(projectile.velocity.X) + Math.Abs(projectile.velocity.Y)) * 0.03f * projectile.direction;
            projectile.ai[0] += 1f;
            if (projectile.ai[0] < 30f)
            {
                projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
            }
            var num81 = ExxoAvalonOriginsGlobalNPC.FindClosest(projectile.position, 208f);
            if (num81 != -1 && Main.npc[num81].lifeMax > 5 && !Main.npc[num81].friendly && !Main.npc[num81].townNPC)
            {
                var vector2 = Main.npc[num81].position;
                if (Collision.CanHit(projectile.position, projectile.width, projectile.height, vector2, Main.npc[num81].width, Main.npc[num81].height))
                {
                    projectile.velocity = Vector2.Normalize(vector2 - projectile.position) * 9f;
                }
            }
            if (projectile.velocity.Y > 16f)
            {
                projectile.velocity.Y = 16f;
            }
        }
    }
}