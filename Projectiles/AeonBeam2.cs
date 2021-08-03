using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Projectiles{	public class AeonBeam2 : ModProjectile	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Aeon Beam");		}		public override void SetDefaults()		{			projectile.width = 16;			projectile.height = 16;			projectile.aiStyle = 27;			projectile.melee = true;			projectile.penetrate = 1;			projectile.light = 0.2f;			projectile.alpha = 0;			projectile.friendly = true;        }
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
		public override void AI()        {
			if (projectile.localAI[1] > 5f)
			{
				int num208 = Main.rand.Next(3);
				if (num208 == 0)
				{
					num208 = 15;
				}
				else if (num208 == 1)
				{
					num208 = 57;
				}
				else if (num208 == 2)
				{
					num208 = 58;
				}
				int num209 = Dust.NewDust(new Vector2(projectile.position.X - projectile.velocity.X * 2f + 2f, projectile.position.Y + 2f - projectile.velocity.Y * 2f), 8, 8, num208, 0f, 0f, 100, default(Color), 1.25f);
				Dust dust = Main.dust[num209];
				dust.velocity *= 0.1f;
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