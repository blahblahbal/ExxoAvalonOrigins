using Microsoft.Xna.Framework;
			projectile.rotation += projectile.velocity.X * 0.2f;
			projectile.ai[1] += 1f;
			projectile.velocity *= 0.96f;
			if (projectile.ai[1] > 15f)
			{
				projectile.scale -= 0.05f;
				if ((double)projectile.scale <= 0.2)
				{
					projectile.scale = 0.2f;
					projectile.active = false;
				}
			}
		}