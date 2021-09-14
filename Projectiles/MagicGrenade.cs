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
	public class MagicGrenade : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magic Grenade");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/MagicGrenade");
			projectile.width = dims.Width * 20 / 20;
			projectile.height = dims.Height / Main.projFrames[projectile.type];
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.light = 0.9f;
			projectile.alpha = 0;
			projectile.scale = 1f;
			projectile.timeLeft = 240;
			projectile.magic = true;
			projectile.tileCollide = true;
		}

		public override void AI()
		{
			
			if (projectile.type != ProjectileID.StickyBomb && projectile.type != ProjectileID.StickyGrenade)
			{
			    goto IL_CA7F;
			}
			try
			{
				var num272 = (int)(projectile.position.X / 16f) - 1;
				var num273 = (int)((projectile.position.X + projectile.width) / 16f) + 2;
				var num274 = (int)(projectile.position.Y / 16f) - 1;
				var num275 = (int)((projectile.position.Y + projectile.height) / 16f) + 2;
				if (num272 < 0)
				{
					num272 = 0;
				}
				if (num273 > Main.maxTilesX)
				{
					num273 = Main.maxTilesX;
				}
				if (num274 < 0)
				{
					num274 = 0;
				}
				if (num275 > Main.maxTilesY)
				{
					num275 = Main.maxTilesY;
				}
				for (var num276 = num272; num276 < num273; num276++)
				{
					for (var num277 = num274; num277 < num275; num277++)
					{
						if (Main.tile[num276, num277] != null && Main.tile[num276, num277].nactive() && (Main.tileSolid[Main.tile[num276, num277].type] || (Main.tileSolidTop[Main.tile[num276, num277].type] && Main.tile[num276, num277].frameY == 0)))
						{
							Vector2 vector20;
							vector20.X = num276 * 16;
							vector20.Y = num277 * 16;
							if (projectile.position.X + projectile.width - 4f > vector20.X && projectile.position.X + 4f < vector20.X + 16f && projectile.position.Y + projectile.height - 4f > vector20.Y && projectile.position.Y + 4f < vector20.Y + 16f)
							{
								projectile.velocity.X = 0f;
								projectile.velocity.Y = -0.2f;
							}
						}
					}
				}
			}
			catch
			{
			}
			IL_CA7F:
			if (projectile.type == ModContent.ProjectileType<BombSkeleton>())
			{
				if (projectile.velocity.Y > 10f)
				{
					projectile.velocity.Y = 10f;
				}
				if (projectile.localAI[0] == 0f)
				{
					projectile.localAI[0] = 1f;
					Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 10);
				}
				projectile.frameCounter++;
				if (projectile.frameCounter > 3)
				{
					projectile.frame++;
					projectile.frameCounter = 0;
				}
				if (projectile.frame > 1)
				{
					projectile.frame = 0;
				}
				if (projectile.velocity.Y == 0f)
				{
					projectile.position.X = projectile.position.X + projectile.width / 2;
					projectile.position.Y = projectile.position.Y + projectile.height / 2;
					projectile.width = 128;
					projectile.height = 128;
					projectile.position.X = projectile.position.X - projectile.width / 2;
					projectile.position.Y = projectile.position.Y - projectile.height / 2;
					projectile.damage = 70;
					projectile.knockBack = 8f;
					projectile.timeLeft = 3;
					projectile.netUpdate = true;
				}
			}
			if (true && projectile.timeLeft <= 3 && projectile.hostile)
			{
				projectile.position.X = projectile.position.X + projectile.width / 2;
				projectile.position.Y = projectile.position.Y + projectile.height / 2;
				projectile.width = 128;
				projectile.height = 128;
				projectile.position.X = projectile.position.X - projectile.width / 2;
				projectile.position.Y = projectile.position.Y - projectile.height / 2;
			}
			if (projectile.owner == Main.myPlayer && projectile.timeLeft <= 3)
			{
				projectile.tileCollide = false;
				projectile.ai[1] = 0f;
				projectile.alpha = 255;
				if (projectile.type == ProjectileID.Bomb || projectile.type == ProjectileID.StickyBomb || projectile.type == ProjectileID.HappyBomb || projectile.type == ModContent.ProjectileType<SkeletonHeadbomb>())
				{
					projectile.position.X = projectile.position.X + projectile.width / 2;
					projectile.position.Y = projectile.position.Y + projectile.height / 2;
					projectile.width = 128;
					projectile.height = 128;
					projectile.position.X = projectile.position.X - projectile.width / 2;
					projectile.position.Y = projectile.position.Y - projectile.height / 2;
					projectile.damage = ((projectile.type == ModContent.ProjectileType<SkeletonHeadbomb>()) ? 90 : 100);
					projectile.knockBack = 8f;
				}
				else if (projectile.type == ProjectileID.Grenade || projectile.type == ProjectileID.StickyGrenade || projectile.type == ModContent.ProjectileType<MagicGrenade>())
				{
					projectile.position.X = projectile.position.X + projectile.width / 2;
					projectile.position.Y = projectile.position.Y + projectile.height / 2;
					projectile.width = 128;
					projectile.height = 128;
					projectile.position.X = projectile.position.X - projectile.width / 2;
					projectile.position.Y = projectile.position.Y - projectile.height / 2;
					projectile.knockBack = 8f;
				}
			}
			else
			{
				if (projectile.type != ProjectileID.Grenade && projectile.type != ProjectileID.StickyGrenade && projectile.type != ProjectileID.Explosives && projectile.type != ProjectileID.RocketI && projectile.type != ProjectileID.ProximityMineI && projectile.type != ProjectileID.RocketII && projectile.type != ProjectileID.ProximityMineII && projectile.type != ProjectileID.RocketIII && projectile.type != ProjectileID.ProximityMineIII && projectile.type != ProjectileID.RocketIV && projectile.type != ProjectileID.ProximityMineIV && projectile.type != ProjectileID.Landmine)
				{
					projectile.damage = 0;
				}
				if (projectile.type == ProjectileID.RocketI || projectile.type == ProjectileID.RocketII || projectile.type == ProjectileID.RocketIII || projectile.type == ProjectileID.RocketIV || true)
				{
					if (Math.Abs(projectile.velocity.X) >= 8f || Math.Abs(projectile.velocity.Y) >= 8f)
					{
						for (var num294 = 0; num294 < 2; num294++)
						{
							var num295 = 0f;
							var num296 = 0f;
							if (num294 == 1)
							{
								num295 = projectile.velocity.X * 0.5f;
								num296 = projectile.velocity.Y * 0.5f;
							}
							var num297 = Dust.NewDust(new Vector2(projectile.position.X + 3f + num295, projectile.position.Y + 3f + num296) - projectile.velocity * 0.5f, projectile.width - 8, projectile.height - 8, DustID.Fire, 0f, 0f, 100, default(Color), 1f);
							Main.dust[num297].scale *= 2f + Main.rand.Next(10) * 0.1f;
							Main.dust[num297].velocity *= 0.2f;
							Main.dust[num297].noGravity = true;
							num297 = Dust.NewDust(new Vector2(projectile.position.X + 3f + num295, projectile.position.Y + 3f + num296) - projectile.velocity * 0.5f, projectile.width - 8, projectile.height - 8, DustID.Smoke, 0f, 0f, 100, default(Color), 0.5f);
							Main.dust[num297].fadeIn = 1f + Main.rand.Next(5) * 0.1f;
							Main.dust[num297].velocity *= 0.05f;
						}
					}
					if (Math.Abs(projectile.velocity.X) < 15f && Math.Abs(projectile.velocity.Y) < 15f)
					{
						projectile.velocity *= 1.1f;
					}
				}
				else if (projectile.type == ProjectileID.ProximityMineI || projectile.type == ProjectileID.ProximityMineII || projectile.type == ProjectileID.ProximityMineIII || projectile.type == ProjectileID.ProximityMineIV)
				{
					if (projectile.velocity.X > -0.2 && projectile.velocity.X < 0.2 && projectile.velocity.Y > -0.2 && projectile.velocity.Y < 0.2)
					{
						projectile.alpha += 2;
						if (projectile.alpha > 200)
						{
							projectile.alpha = 200;
						}
					}
					else
					{
						projectile.alpha = 0;
						var num299 = Dust.NewDust(new Vector2(projectile.position.X + 3f, projectile.position.Y + 3f) - projectile.velocity * 0.5f, projectile.width - 8, projectile.height - 8, DustID.Smoke, 0f, 0f, 100, default(Color), 1f);
						Main.dust[num299].scale *= 1.6f + Main.rand.Next(5) * 0.1f;
						Main.dust[num299].velocity *= 0.05f;
						Main.dust[num299].noGravity = true;
					}
				}
				else if (projectile.type != ProjectileID.Grenade && projectile.type != ProjectileID.StickyGrenade && Main.rand.Next(2) == 0)
				{
					var num300 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Smoke, 0f, 0f, 100, default(Color), 1f);
					Main.dust[num300].scale = 0.1f + Main.rand.Next(5) * 0.1f;
					Main.dust[num300].fadeIn = 1.5f + Main.rand.Next(5) * 0.1f;
					Main.dust[num300].noGravity = true;
					Main.dust[num300].position = projectile.Center + new Vector2(0f, -projectile.height / 2f).RotatedBy(projectile.rotation, default(Vector2)) * 1.1f;
					Main.rand.Next(2);
					num300 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Fire, 0f, 0f, 100, default(Color), 1f);
					Main.dust[num300].scale = 1f + Main.rand.Next(5) * 0.1f;
					Main.dust[num300].noGravity = true;
					Main.dust[num300].position = projectile.Center + new Vector2(0f, -projectile.height / 2f - 6f).RotatedBy(projectile.rotation, default(Vector2)) * 1.1f;
				}
			}
			projectile.ai[0] += 1f;
            if (projectile.type == ProjectileID.RocketI || projectile.type == ProjectileID.RocketII || projectile.type == ProjectileID.RocketIII || projectile.type == ProjectileID.RocketIV || true)
			{
				projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
			}
			else if (projectile.type == ProjectileID.ProximityMineI || projectile.type == ProjectileID.ProximityMineII || projectile.type == ProjectileID.ProximityMineIII || projectile.type == ProjectileID.ProximityMineIV)
			{
				projectile.velocity.Y = projectile.velocity.Y + 0.2f;
				projectile.velocity *= 0.97f;
				if (projectile.velocity.X > -0.1 && projectile.velocity.X < 0.1)
				{
					projectile.velocity.X = 0f;
				}
				if (projectile.velocity.Y > -0.1 && projectile.velocity.Y < 0.1)
				{
					projectile.velocity.Y = 0f;
				}
			}
			else if (((projectile.type == ProjectileID.Grenade || projectile.type == ProjectileID.StickyGrenade) && projectile.ai[0] > 10f) || (projectile.type != ProjectileID.Grenade && projectile.type != ProjectileID.StickyGrenade && projectile.ai[0] > 5f))
			{
				projectile.ai[0] = 10f;
				if (projectile.velocity.Y == 0f && projectile.velocity.X != 0f)
				{
					projectile.velocity.X = projectile.velocity.X * 0.97f;
					if (projectile.type == ProjectileID.Dynamite)
					{
						projectile.velocity.X = projectile.velocity.X * 0.99f;
					}
					if (projectile.velocity.X > -0.01 && projectile.velocity.X < 0.01)
					{
						projectile.velocity.X = 0f;
						projectile.netUpdate = true;
					}
				}
				projectile.velocity.Y = projectile.velocity.Y + 0.2f;
			}
			if (projectile.type != ProjectileID.RocketI && projectile.type != ProjectileID.RocketII && projectile.type != ProjectileID.RocketIII && projectile.type != ProjectileID.RocketIV)
			{
				projectile.rotation += projectile.velocity.X * 0.1f;
			}
		}
	}
}