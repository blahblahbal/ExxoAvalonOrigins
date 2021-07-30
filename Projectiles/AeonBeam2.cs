using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Projectiles{	public class AeonBeam2 : ModProjectile	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Aeon Beam");		}		public override void SetDefaults()		{			projectile.width = 16;			projectile.height = 16;			projectile.aiStyle = 27;			projectile.melee = true;			projectile.penetrate = 1;			projectile.light = 0.2f;			projectile.alpha = 0;			projectile.friendly = true;        }
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color(255, 255, 255, 100);
		}
		public override void AI()        {
			if (projectile.localAI[1] > 7f)
			{
				var num480 = Main.rand.Next(3);
				if (num480 == 0)
				{
					num480 = 15;
				}
				else if (num480 == 1)
				{
					num480 = 57;
				}
				else
				{
					num480 = 58;
				}
				var Sparkle = Dust.NewDust(new Vector2(projectile.position.X - projectile.velocity.X * 2f, projectile.position.Y - projectile.velocity.Y * 2f), 8, 8, num480, 0f, 0f, 100, default(Color), 1.25f);
				Main.dust[Sparkle].velocity *= 0.1f;
			}
		}
        public override void Kill(int timeLeft)
        {
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
			for (int num394 = 4; num394 < 24; num394++)
			{
				float num395 = projectile.oldVelocity.X * (30f / (float)num394);
				float num396 = projectile.oldVelocity.Y * (30f / (float)num394);
				int num397 = Main.rand.Next(3);
				if (num397 == 0)
				{
					num397 = 15;
				}
				else if (num397 == 1)
				{
					num397 = 57;
				}
				else
				{
					num397 = 58;
				}
				int num398 = Dust.NewDust(new Vector2(projectile.position.X - num395, projectile.position.Y - num396), 8, 8, num397, projectile.oldVelocity.X * 0.2f, projectile.oldVelocity.Y * 0.2f, 100, default(Color), 1.8f);
				Main.dust[num398].velocity *= 1.5f;
				Main.dust[num398].noGravity = true;
			}
		}
	}}