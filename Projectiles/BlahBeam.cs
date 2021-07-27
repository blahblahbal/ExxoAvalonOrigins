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
	public class BlahBeam : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blah Beam");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/BlahBeam");
            projectile.width = 16;
			projectile.height = 16;
			projectile.aiStyle = -1;
			projectile.melee = true;
			projectile.penetrate = 5;
			projectile.light = 0.8f;
			projectile.alpha = 255;
			projectile.friendly = true;
        }
        public static int FindClosest(Vector2 pos, float dist)
        {
            int closest = -1;
            float last = dist;
            for (int i = 0; i < Main.npc.Length; i++)
            {
                NPC N = Main.npc[i];
                if (!N.active || N.townNPC) continue;
                if (Vector2.Distance(pos, N.Center) < last)
                {
                    last = Vector2.Distance(pos, N.Center);
                    closest = i;
                }
                else continue;
            }
            return closest;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.type == ModContent.ProjectileType<BlahBeam>())
            {
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
                projectile.ai[0] += 1f;
                if (projectile.ai[0] >= 4f)
                {
                    projectile.position += projectile.velocity;
                    projectile.Kill();
                }
                else
                {
                    if (projectile.velocity.Y != oldVelocity.Y)
                    {
                        projectile.velocity.Y = -oldVelocity.Y;
                    }
                    if (projectile.velocity.X != oldVelocity.X)
                    {
                        projectile.velocity.X = -oldVelocity.X;
                    }
                }
            }
            return false;
        }
        public override void AI()
        {
            int closest = FindClosest(projectile.position, 16 * 20);
            if (closest != -1)
            {
                if (Main.npc[closest].lifeMax > 5 && !Main.npc[closest].friendly && !Main.npc[closest].townNPC)
                {
                    Vector2 v = Main.npc[closest].position;
                    if (Collision.CanHit(projectile.position, projectile.width, projectile.height, v, Main.npc[closest].width, Main.npc[closest].height))
                    {
                        projectile.velocity = Vector2.Normalize(v - projectile.position) * 9f;
                    }
                }
            }
            if (projectile.localAI[1] > 7f)
            {
                var num483 = Dust.NewDust(new Vector2(projectile.position.X - projectile.velocity.X * 4f + 2f, projectile.position.Y + 2f - projectile.velocity.Y * 4f), 8, 8, 6, projectile.oldVelocity.X, projectile.oldVelocity.Y, 100, default(Color), 1.25f);
                Main.dust[num483].velocity *= -0.25f;
                num483 = Dust.NewDust(new Vector2(projectile.position.X - projectile.velocity.X * 4f + 2f, projectile.position.Y + 2f - projectile.velocity.Y * 4f), 8, 8, 6, projectile.oldVelocity.X, projectile.oldVelocity.Y, 100, default(Color), 1.25f);
                Main.dust[num483].velocity *= -0.25f;
                Main.dust[num483].position -= projectile.velocity * 0.5f;
            }
            if (projectile.localAI[1] < 15f)
            {
                projectile.localAI[1] += 1f;
            }
            else
            {
                if (projectile.localAI[0] == 0f)
                {
                    projectile.scale -= 0.02f;
                    projectile.alpha += 30;
                    if (projectile.alpha >= 250)
                    {
                        projectile.alpha = 255;
                        projectile.localAI[0] = 1f;
                    }
                }
                else if (projectile.localAI[0] == 1f)
                {
                    projectile.scale += 0.02f;
                    projectile.alpha -= 30;
                    if (projectile.alpha <= 0)
                    {
                        projectile.alpha = 0;
                        projectile.localAI[0] = 0f;
                    }
                }
            }
            if (projectile.ai[1] == 0f)
            {
                projectile.ai[1] = 1f;
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 8);
            }
            else
            {
                projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 0.785f;
            }
            if (projectile.velocity.Y > 16f)
            {
                projectile.velocity.Y = 16f;
            }
        }
    }
}