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
	public class Spike : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spike");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/Spike");
			projectile.width = dims.Width * 8 / 16;
			projectile.height = dims.Height * 8 / 16 / Main.projFrames[projectile.type];
			projectile.aiStyle = -1;
			projectile.friendly = false;
            projectile.hostile = true;
            projectile.tileCollide = false;
			projectile.penetrate = -1;
			projectile.alpha = 0;
			projectile.MaxUpdates = 1;
			projectile.scale = 1f;
			projectile.timeLeft = 300;
			projectile.ranged = true;
            projectile.GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().notReflect = true;
        }

		public override void AI()
		{
			projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
			if (projectile.velocity.Y > 16f)
			{
				projectile.velocity.Y = 16f;
			}
		}
	}
}
