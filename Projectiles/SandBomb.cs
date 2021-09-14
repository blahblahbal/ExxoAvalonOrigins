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
	public class SandBomb : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sand Bomb");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/SandBomb");
			projectile.width = dims.Width;
			projectile.height = dims.Height * 22 / 30 / Main.projFrames[projectile.type];
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.ranged = true;
			projectile.hostile = false;
			projectile.penetrate = 1;
			projectile.aiStyle = -1;
			projectile.timeLeft = 240;
			projectile.MaxUpdates = 2;
		}

		public override void AI()
		{
			if (projectile.type == ProjectileID.Spike)
			{
				if (projectile.localAI[1] == 0f)
				{
					projectile.localAI[1] = 1f;
				}
				projectile.alpha += (int)(25f * projectile.localAI[1]);
				if (projectile.alpha <= 0)
				{
					projectile.alpha = 0;
					projectile.localAI[1] = 1f;
				}
				else if (projectile.alpha >= 255)
				{
					projectile.alpha = 255;
					projectile.localAI[1] = -1f;
				}
				projectile.scale += projectile.localAI[1] * 0.01f;
			}
			if (projectile.type == ProjectileID.OrnamentHostile)
			{
				if (projectile.localAI[0] == 0f)
				{
					projectile.localAI[0] = 1f;
					Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 1);
				}
				projectile.frame = (int)projectile.ai[1];
				if (projectile.owner == Main.myPlayer && projectile.timeLeft == 1)
				{
					for (var num230 = 0; num230 < 5; num230++)
					{
						var num231 = 10f;
						var vector17 = new Vector2(projectile.Center.X, projectile.Center.Y);
						float num232 = Main.rand.Next(-20, 21);
						float num233 = Main.rand.Next(-20, 0);
						var num234 = (float)Math.Sqrt(num232 * num232 + num233 * num233);
						num234 = num231 / num234;
						num232 *= num234;
						num233 *= num234;
						num232 *= 1f + Main.rand.Next(-30, 31) * 0.01f;
						num233 *= 1f + Main.rand.Next(-30, 31) * 0.01f;
						Projectile.NewProjectile(vector17.X, vector17.Y, num232, num233, ProjectileID.OrnamentHostileShrapnel, 40, 0f, Main.myPlayer, 0f, projectile.ai[1]);
					}
				}
			}
			if (projectile.type == ProjectileID.SmokeBomb)
			{
				var num235 = Main.rand.Next(1, 3);
				for (var num236 = 0; num236 < num235; num236++)
				{
					var num237 = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Smoke, 0f, 0f, 100, default(Color), 1f);
					Main.dust[num237].alpha += Main.rand.Next(100);
					Main.dust[num237].velocity *= 0.3f;
					var dust31 = Main.dust[num237];
					dust31.velocity.X = dust31.velocity.X + Main.rand.Next(-10, 11) * 0.025f;
					var dust32 = Main.dust[num237];
					dust32.velocity.Y = dust32.velocity.Y - (0.4f + Main.rand.Next(-3, 14) * 0.15f);
					Main.dust[num237].fadeIn = 1.25f + Main.rand.Next(20) * 0.15f;
				}
			}
			if (projectile.type == ProjectileID.StickyGlowstick)
			{
				try
				{
					Collision.TileCollision(projectile.position, projectile.velocity, projectile.width, projectile.height, false, false, 1);
					var num238 = (int)(projectile.position.X / 16f) - 1;
					var num239 = (int)((projectile.position.X + projectile.width) / 16f) + 2;
					var num240 = (int)(projectile.position.Y / 16f) - 1;
					var num241 = (int)((projectile.position.Y + projectile.height) / 16f) + 2;
					if (num238 < 0)
					{
						num238 = 0;
					}
					if (num239 > Main.maxTilesX)
					{
						num239 = Main.maxTilesX;
					}
					if (num240 < 0)
					{
						num240 = 0;
					}
					if (num241 > Main.maxTilesY)
					{
						num241 = Main.maxTilesY;
					}
					for (var num242 = num238; num242 < num239; num242++)
					{
						for (var num243 = num240; num243 < num241; num243++)
						{
							if (Main.tile[num242, num243] != null && Main.tile[num242, num243].nactive() && (Main.tileSolid[Main.tile[num242, num243].type] || (Main.tileSolidTop[Main.tile[num242, num243].type] && Main.tile[num242, num243].frameY == 0)))
							{
								Vector2 vector18;
								vector18.X = num242 * 16;
								vector18.Y = num243 * 16;
								if (projectile.position.X + projectile.width > vector18.X && projectile.position.X < vector18.X + 16f && projectile.position.Y + projectile.height > vector18.Y && projectile.position.Y < vector18.Y + 16f)
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
			}
			if (projectile.type == ProjectileID.ThornBall && projectile.alpha > 0)
			{
				projectile.alpha -= 30;
				if (projectile.alpha < 0)
				{
					projectile.alpha = 0;
				}
			}
            if (projectile.type == ProjectileID.SpiderEgg)
			{
				if (projectile.localAI[0] == 0f)
				{
					Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 17);
					projectile.localAI[0] += 1f;
				}
				var rectangle2 = new Rectangle((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height);
				for (var num244 = 0; num244 < 200; num244++)
				{
					if (Main.npc[num244].active && !Main.npc[num244].friendly && Main.npc[num244].lifeMax > 5)
					{
						var value5 = new Rectangle((int)Main.npc[num244].position.X, (int)Main.npc[num244].position.Y, Main.npc[num244].width, Main.npc[num244].height);
						if (rectangle2.Intersects(value5))
						{
							projectile.Kill();
							return;
						}
					}
				}
				projectile.ai[0] += 1f;
				if (projectile.ai[0] > 10f)
				{
					projectile.ai[0] = 90f;
					if (projectile.velocity.Y == 0f && projectile.velocity.X != 0f)
					{
						projectile.velocity.X = projectile.velocity.X * 0.96f;
						if (projectile.velocity.X > -0.01 && projectile.velocity.X < 0.01)
						{
							projectile.Kill();
						}
					}
					projectile.velocity.Y = projectile.velocity.Y + 0.2f;
				}
				projectile.rotation += projectile.velocity.X * 0.1f;
			}
			else
			{
				projectile.ai[0] += 1f;
				if (projectile.ai[0] > 5f)
				{
					projectile.ai[0] = 5f;
					if (projectile.velocity.Y == 0f && projectile.velocity.X != 0f)
					{
						projectile.velocity.X = projectile.velocity.X * 0.97f;
						if (projectile.velocity.X > -0.01 && projectile.velocity.X < 0.01)
						{
							projectile.velocity.X = 0f;
							projectile.netUpdate = true;
						}
					}
					projectile.velocity.Y = projectile.velocity.Y + 0.2f;
				}
				projectile.rotation += projectile.velocity.X * 0.1f;
			}
			if ((projectile.type >= ProjectileID.GreekFire1 && projectile.type <= ProjectileID.GreekFire3))
			{
				if (projectile.wet)
				{
					projectile.Kill();
				}
				if (projectile.ai[1] == 0f && projectile.type >= ProjectileID.GreekFire1 && projectile.type <= ProjectileID.GreekFire3)
				{
					projectile.ai[1] = 1f;
					Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 13);
				}
				var num245 = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Fire, 0f, 0f, 100, default(Color), 1f);
				var dust33 = Main.dust[num245];
				dust33.position.X = dust33.position.X - 2f;
				var dust34 = Main.dust[num245];
				dust34.position.Y = dust34.position.Y + 2f;
				Main.dust[num245].scale += Main.rand.Next(50) * 0.01f;
				Main.dust[num245].noGravity = true;
				var dust35 = Main.dust[num245];
				dust35.velocity.Y = dust35.velocity.Y - 2f;
				if (Main.rand.Next(2) == 0)
				{
					var num246 = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Fire, 0f, 0f, 100, default(Color), 1f);
					var dust36 = Main.dust[num246];
					dust36.position.X = dust36.position.X - 2f;
					var dust37 = Main.dust[num246];
					dust37.position.Y = dust37.position.Y + 2f;
					Main.dust[num246].scale += 0.3f + Main.rand.Next(50) * 0.01f;
					Main.dust[num246].noGravity = true;
					Main.dust[num246].velocity *= 0.1f;
				}
				if (projectile.velocity.Y < 0.25 && projectile.velocity.Y > 0.15)
				{
					projectile.velocity.X = projectile.velocity.X * 0.8f;
				}
				projectile.rotation = -projectile.velocity.X * 0.05f;
			}
			if (projectile.velocity.Y > 16f)
			{
				projectile.velocity.Y = 16f;
			}
		}
	}
}