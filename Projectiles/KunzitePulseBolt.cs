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
	public class KunzitePulseBolt : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Kunzite Pulse Bolt");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/KunzitePulseBolt");
			projectile.width = dims.Width * 4 / 1;
			projectile.height = dims.Height * 4 / 1 / Main.projFrames[projectile.type];
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.penetrate = 6;
			projectile.alpha = 255;
			projectile.MaxUpdates = 2;
			projectile.scale = 1.2f;
			projectile.timeLeft = 600;
			projectile.ranged = true;
		}

		public override void AI()
		{
			if (projectile.type == ModContent.ProjectileType<KunzitePulseBolt>())
			{
				if (projectile.alpha < 170)
				{
					for (var n = 0; n < 10; n++)
					{
						var x = projectile.position.X - projectile.velocity.X / 10f * n;
						var y = projectile.position.Y - projectile.velocity.Y / 10f * n;
						var num25 = Dust.NewDust(new Vector2(x, y), 1, 1, DustID.UnusedWhiteBluePurple, 0f, 0f, 0, default(Color), 1f);
						Main.dust[num25].alpha = projectile.alpha;
						Main.dust[num25].position.X = x;
						Main.dust[num25].position.Y = y;
						Main.dust[num25].velocity *= 0f;
						Main.dust[num25].noGravity = true;
					}
				}
				if (projectile.alpha > 0)
				{
					projectile.alpha -= 25;
				}
				if (projectile.alpha < 0)
				{
					projectile.alpha = 0;
				}
			}
			projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
			if (projectile.velocity.Y > 16f)
			{
				projectile.velocity.Y = 16f;
			}
		}
	}
}