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
	public class MagmafrostBolt : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magmafrost Bolt");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/MagmafrostBolt");
			projectile.width = dims.Width * 12 / 16;
			projectile.height = dims.Height * 12 / 16 / Main.projFrames[projectile.type];
			projectile.aiStyle = -1;
			projectile.tileCollide = true;
			projectile.friendly = true;
			projectile.alpha = 255;
			projectile.light = 0.8f;
			projectile.penetrate = 15;
			projectile.magic = true;
			projectile.timeLeft = 2400;
			projectile.ignoreWater = true;
		}

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.type == ModContent.ProjectileType<MagmafrostBolt>())
            {
                Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 10);
                projectile.ai[0] += 1f;
                if (projectile.ai[0] >= 10f)
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
			if (projectile.type == ModContent.ProjectileType<MagmafrostBolt>())
			{
				for (var num905 = 0; num905 < 3; num905++)
				{
					var num906 = projectile.velocity.X / 3f * num905;
					var num907 = projectile.velocity.Y / 3f * num905;
					var num908 = 4;
					var num909 = Dust.NewDust(new Vector2(projectile.position.X + num908, projectile.position.Y + num908), projectile.width - num908 * 2, projectile.height - num908 * 2, DustID.Fire, 0f, 0f, 100, default(Color), 1.2f);
					Main.dust[num909].noGravity = true;
					Main.dust[num909].velocity *= 0.1f;
					Main.dust[num909].velocity += projectile.velocity * 0.1f;
					var dust101 = Main.dust[num909];
					dust101.position.X = dust101.position.X - num906;
					var dust102 = Main.dust[num909];
					dust102.position.Y = dust102.position.Y - num907;
				}
				for (var num910 = 0; num910 < 3; num910++)
				{
					var num911 = projectile.velocity.X / 3f * num910;
					var num912 = projectile.velocity.Y / 3f * num910;
					var num913 = 4;
					var num914 = Dust.NewDust(new Vector2(projectile.position.X + num913, projectile.position.Y + num913), projectile.width - num913 * 2, projectile.height - num913 * 2, DustID.IceTorch, 0f, 0f, 100, default(Color), 1.2f);
					Main.dust[num914].noGravity = true;
					Main.dust[num914].velocity *= 0.1f;
					Main.dust[num914].velocity += projectile.velocity * 0.1f;
					var dust103 = Main.dust[num914];
					dust103.position.X = dust103.position.X - num911;
					var dust104 = Main.dust[num914];
					dust104.position.Y = dust104.position.Y - num912;
				}
				if (Main.rand.Next(2) == 0)
				{
					var num915 = 4;
					var num916 = Dust.NewDust(new Vector2(projectile.position.X + num915, projectile.position.Y + num915), projectile.width - num915 * 2, projectile.height - num915 * 2, DustID.IceTorch, 0f, 0f, 100, default(Color), 0.6f);
					Main.dust[num916].velocity *= 0.25f;
					Main.dust[num916].velocity += projectile.velocity * 0.5f;
				}
			}
			else
			{
				for (var num926 = 0; num926 < 2; num926++)
				{
					var num927 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Fire, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 2f);
					Main.dust[num927].noGravity = true;
					var dust107 = Main.dust[num927];
					dust107.velocity.X = dust107.velocity.X * 0.3f;
					var dust108 = Main.dust[num927];
					dust108.velocity.Y = dust108.velocity.Y * 0.3f;
				}
			}
			if (projectile.type != ModContent.ProjectileType<FreezeBolt>() && projectile.type != ModContent.ProjectileType<ChaosBolt>() && projectile.type != ModContent.ProjectileType<MagmafrostBolt>())
			{
				projectile.ai[1] += 1f;
			}
			if (projectile.ai[1] >= 20f)
			{
				projectile.velocity.Y = projectile.velocity.Y + 0.2f;
			}
			projectile.rotation += 0.3f * projectile.direction;
			if (projectile.velocity.Y > 16f)
			{
				projectile.velocity.Y = 16f;
				return;
			}
		}
	}
}