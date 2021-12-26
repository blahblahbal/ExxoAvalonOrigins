﻿using Microsoft.Xna.Framework;
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
	public class OpalBolt : ModProjectile
	{
		private Color color;
		private int dustId;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Opal Bolt");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.SapphireBolt);
			Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/OpalBolt");
			projectile.width = dims.Width * 10 / 16;
			projectile.height = dims.Height * 10 / 16 / Main.projFrames[projectile.type];
			projectile.aiStyle = -1;
			projectile.penetrate = 1;
	
			color = new Color(86, 39, 255) * 0.7f;
			dustId = ModContent.DustType<Dusts.OpalDust>();
		}

		public override void AI()
		{
			for (var i = 0; i < 2; i++)
			{
				if (Main.rand.NextFloat() < 0.85f)
				{
					var dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, dustId, projectile.velocity.X, projectile.velocity.Y, 50, default, 1.2f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 0.3f;
				}
			}
			if (projectile.ai[1] == 0f)
			{
				projectile.ai[1] = 1f;
				Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 8);
			}

			Lighting.AddLight(new Vector2((int)((projectile.position.X + (float)(projectile.width / 2)) / 16f), (int)((projectile.position.Y + (float)(projectile.height / 2)) / 16f)), color.ToVector3());
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Dig, (int)projectile.position.X, (int)projectile.position.Y);
			for (int num453 = 0; num453 < 15; num453++)
			{
				int num454 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, dustId, projectile.oldVelocity.X, projectile.oldVelocity.Y, 50, default, 1.2f);
				Main.dust[num454].noGravity = true;
				Dust dust152 = Main.dust[num454];
				Dust dust226 = dust152;
				dust226.scale *= 1.25f;
				dust152 = Main.dust[num454];
				dust226 = dust152;
				dust226.velocity *= 0.5f;
			}
		}
	}
}
