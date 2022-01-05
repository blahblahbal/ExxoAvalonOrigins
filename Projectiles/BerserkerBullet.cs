using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Projectiles
{
	public class BerserkerBullet : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Berserker Bullet");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/BerserkerBullet");
			projectile.width = dims.Width * 4 / 20;
			projectile.height = dims.Height * 4 / 20 / Main.projFrames[projectile.type];
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.penetrate = 1;
			projectile.light = 0.8f;
			projectile.alpha = 255;
			projectile.MaxUpdates = 2;
			projectile.scale = 1.2f;
			projectile.timeLeft = 600;
			projectile.ranged = true;
		}

        public override void AI()
        {
            projectile.ai[0] += 1f;
            if (projectile.alpha < 170)
            {
                for (var num26 = 0; num26 < 10; num26++)
                {
                    var x2 = projectile.position.X - projectile.velocity.X / 10f * num26;
                    var y2 = projectile.position.Y - projectile.velocity.Y / 10f * num26;
                    int num27;
                    num27 = Dust.NewDust(new Vector2(x2, y2), 1, 1, DustID.Ice_Pink, 0f, 0f, 0, default(Color), 1f);
                    Main.dust[num27].alpha = projectile.alpha;
                    Main.dust[num27].position.X = x2;
                    Main.dust[num27].position.Y = y2;
                    Main.dust[num27].velocity *= 0f;
                    Main.dust[num27].noGravity = true;
                }
            }
            var num28 = (float)Math.Sqrt(projectile.velocity.X * projectile.velocity.X + projectile.velocity.Y * projectile.velocity.Y);
            var num29 = projectile.localAI[0];
            if (num29 == 0f)
            {
                projectile.localAI[0] = num28;
                num29 = num28;
            }
            if (projectile.alpha > 0)
            {
                projectile.alpha -= 25;
            }
            if (projectile.alpha < 0)
            {
                projectile.alpha = 0;
            }
            var projPosStoredX = projectile.position.X;
            var projPosStoredY = projectile.position.Y;
            var num32 = 300f;
            var flag = false;
            var num33 = 0;
            if (projectile.ai[1] == 0f)
            {
                for (var npcArrayIndex = 0; npcArrayIndex < 200; npcArrayIndex++)
                {
                    if (Main.npc[npcArrayIndex].active && !Main.npc[npcArrayIndex].dontTakeDamage && !Main.npc[npcArrayIndex].friendly && Main.npc[npcArrayIndex].lifeMax > 5 && (projectile.ai[1] == 0f || projectile.ai[1] == npcArrayIndex + 1))
                    {
                        var npcCenterX = Main.npc[npcArrayIndex].position.X + Main.npc[npcArrayIndex].width / 2;
                        var npcCenterY = Main.npc[npcArrayIndex].position.Y + Main.npc[npcArrayIndex].height / 2;
                        var num37 = Math.Abs(projectile.position.X + projectile.width / 2 - npcCenterX) + Math.Abs(projectile.position.Y + projectile.height / 2 - npcCenterY);
                        if (num37 < num32 && Collision.CanHit(new Vector2(projectile.position.X + projectile.width / 2, projectile.position.Y + projectile.height / 2), 1, 1, Main.npc[npcArrayIndex].position, Main.npc[npcArrayIndex].width, Main.npc[npcArrayIndex].height))
                        {
                            num32 = num37;
                            projPosStoredX = npcCenterX;
                            projPosStoredY = npcCenterY;
                            flag = true;
                            num33 = npcArrayIndex;
                        }
                    }
                }
                if (flag)
                {
                    projectile.ai[1] = num33 + 1;
                }
                flag = false;
            }
            if (projectile.ai[1] != 0f)
            {
                var num38 = (int)(projectile.ai[1] - 1f);
                if (Main.npc[num38].active)
                {
                    var num39 = Main.npc[num38].position.X + Main.npc[num38].width / 2;
                    var num40 = Main.npc[num38].position.Y + Main.npc[num38].height / 2;
                    var num41 = Math.Abs(projectile.position.X + projectile.width / 2 - num39) + Math.Abs(projectile.position.Y + projectile.height / 2 - num40);
                    if (num41 < 1000f)
                    {
                        flag = true;
                        projPosStoredX = Main.npc[num38].position.X + Main.npc[num38].width / 2;
                        projPosStoredY = Main.npc[num38].position.Y + Main.npc[num38].height / 2;
                    }
                }
            }
            if (flag)
            {
                var num42 = num29;
                var projCenter = new Vector2(projectile.position.X + projectile.width * 0.5f, projectile.position.Y + projectile.height * 0.5f);
                var num43 = projPosStoredX - projCenter.X;
                var num44 = projPosStoredY - projCenter.Y;
                var num45 = (float)Math.Sqrt(num43 * num43 + num44 * num44);
                num45 = num42 / num45;
                num43 *= num45;
                num44 *= num45;
                var num46 = 8;
                projectile.velocity.X = (projectile.velocity.X * (num46 - 1) + num43) / num46;
                projectile.velocity.Y = (projectile.velocity.Y * (num46 - 1) + num44) / num46;
            }
            projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
            if (projectile.velocity.Y > 16f)
            {
                projectile.velocity.Y = 16f;
            }
        }
    }
}
