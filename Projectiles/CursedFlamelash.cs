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
	public class CursedFlamelash : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed Flamelash");
		}

		public override void SetDefaults() {
			Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/CursedFlamelash");
			projectile.width = dims.Width * 14 / 16;
			projectile.height = dims.Height * 14 / 16 / Main.projFrames[projectile.type];
			projectile.friendly = true;
			projectile.light = 0.8f;
			projectile.magic = true;
			drawOriginOffsetY = -6;
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.CursedInferno, 180);
        }
        public override Color? GetAlpha(Color lightColor) => new Color(96, 248, 2, 0);

		public override void AI() {
			if (projectile.soundDelay == 0 && Math.Abs(projectile.velocity.X) + Math.Abs(projectile.velocity.Y) > 2f) {
				projectile.soundDelay = 10;
				Main.PlaySound(SoundID.Item9, projectile.position);
			}

			Dust dust;
			Vector2 position = projectile.Center + new Vector2(Main.rand.Next(-4, 5), Main.rand.Next(-4, 5));
			dust = Main.dust[Terraria.Dust.NewDust(position, 0, 0, 107, 0f, 0f, 0, new Color(255,255,255), 1f)];

			
			if (Main.myPlayer == projectile.owner && projectile.ai[0] == 0f) {

				Player player = Main.player[projectile.owner];
				if (player.channel) {
					float maxDistance = 18f; 
					Vector2 vectorToCursor = Main.MouseWorld - projectile.Center;
					float distanceToCursor = vectorToCursor.Length();

					if (distanceToCursor > maxDistance) {
						distanceToCursor = maxDistance / distanceToCursor;
						vectorToCursor *= distanceToCursor;
					}

					int velocityXBy1000 = (int)(vectorToCursor.X * 1000f);
					int oldVelocityXBy1000 = (int)(projectile.velocity.X * 1000f);
					int velocityYBy1000 = (int)(vectorToCursor.Y * 1000f);
					int oldVelocityYBy1000 = (int)(projectile.velocity.Y * 1000f);

					if (velocityXBy1000 != oldVelocityXBy1000 || velocityYBy1000 != oldVelocityYBy1000) {
						projectile.netUpdate = true;
					}

					projectile.velocity = vectorToCursor;

				}
				else if (projectile.ai[0] == 0f) {

					projectile.netUpdate = true;
					
					float maxDistance = 14f; 
					Vector2 vectorToCursor = Main.MouseWorld - projectile.Center;
					float distanceToCursor = vectorToCursor.Length();

					if (distanceToCursor == 0f) {
						vectorToCursor = projectile.Center - player.Center;
						distanceToCursor = vectorToCursor.Length();
					}

					distanceToCursor = maxDistance / distanceToCursor;
					vectorToCursor *= distanceToCursor;

					projectile.velocity = vectorToCursor;

					if (projectile.velocity == Vector2.Zero) {
						projectile.Kill();
					}

					projectile.ai[0] = 1f;
				}
			}
			
			if (projectile.velocity != Vector2.Zero) {
				projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver4;
			}
		}

		public override void Kill(int timeLeft) {
			if (projectile.penetrate == 1) {
				projectile.maxPenetrate = -1;
				projectile.penetrate = -1;

				int explosionArea = 60;
				Vector2 oldSize = projectile.Size;
				projectile.position = projectile.Center;
				projectile.Size += new Vector2(explosionArea);
				projectile.Center = projectile.position;

				projectile.tileCollide = false;
				projectile.velocity *= 0.01f;
				projectile.Damage();
				projectile.scale = 0.01f;

				projectile.position = projectile.Center;
				projectile.Size = new Vector2(10);
				projectile.Center = projectile.position;
			}

			Main.PlaySound(SoundID.Item10, projectile.position);
			for (int i = 0; i < 10; i++) {
				Dust dust;
				Vector2 position = projectile.Center + new Vector2(Main.rand.Next(-4, 5), Main.rand.Next(-4, 5));
				dust = Main.dust[Terraria.Dust.NewDust(position, 0, 0, 107, 0f, 0f, 0, new Color(255,255,255), 1f)];
				dust.noGravity = true;
				dust.velocity *= 2f;
			    dust = Main.dust[Terraria.Dust.NewDust(position, 0, 0, 107, 0f, 0f, 0, new Color(255,255,255), 1f)];
			}
		}
    }
}
