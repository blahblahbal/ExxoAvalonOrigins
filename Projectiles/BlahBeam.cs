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
			projectile.aiStyle = 27;
			projectile.melee = true;
			projectile.penetrate = 2;
			projectile.light = 0.8f;
			projectile.penetrate = 2;
			projectile.alpha = 255;
			projectile.friendly = true;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            if (this.projectile.localAI[1] >= 15f)
            {
                return new Color(255, 255, 255, this.projectile.alpha);
            }
            if (this.projectile.localAI[1] < 5f)
            {
                return Color.Transparent;
            }
            int num7 = (int)((this.projectile.localAI[1] - 5f) / 10f * 255f);
            return new Color(num7, num7, num7, num7);
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            int randomNum = Main.rand.Next(7);
            if (randomNum == 0) target.AddBuff(20, 300);
            else if (randomNum == 1) target.AddBuff(24, 200);
            else if (randomNum == 2) target.AddBuff(31, 120);
            else if (randomNum == 3) target.AddBuff(39, 300);
            else if (randomNum == 4) target.AddBuff(44, 300);
            else if (randomNum == 5) target.AddBuff(70, 240);
            else if (randomNum == 6) target.AddBuff(69, 300);
        }
        public static int FindClosest(Vector2 pos, float dist)
        {
            int closest = -1;
            float last = dist;
            for (int i = 0; i < Main.npc.Length; i++)
            {
                NPC N = Main.npc[i];
                if (!N.active || N.townNPC || N.dontTakeDamage) continue;
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
                Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 10);
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
                        projectile.velocity = Vector2.Normalize(v - projectile.position) * 13f;
                    }
                }
            }
            if (projectile.localAI[1] > 7f)
            {
                var num483 = Dust.NewDust(new Vector2(projectile.position.X - projectile.velocity.X * 4f + 2f, projectile.position.Y + 2f - projectile.velocity.Y * 4f), 8, 8, DustID.Fire, projectile.oldVelocity.X, projectile.oldVelocity.Y, 100, default(Color), 1.5f);
                Main.dust[num483].velocity *= -0.25f;
                Main.dust[num483].noGravity = true;
                num483 = Dust.NewDust(new Vector2(projectile.position.X - projectile.velocity.X * 4f + 2f, projectile.position.Y + 2f - projectile.velocity.Y * 4f), 8, 8, DustID.Fire, projectile.oldVelocity.X, projectile.oldVelocity.Y, 100, default(Color), 1.5f);
                Main.dust[num483].velocity *= -0.25f;
                Main.dust[num483].position -= projectile.velocity * 0.5f;
                Main.dust[num483].noGravity = true;
            }
        }
    }
}