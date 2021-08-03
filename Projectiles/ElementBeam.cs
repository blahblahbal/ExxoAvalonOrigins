using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Projectiles{	public class ElementBeam : ModProjectile	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Element Beam");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/ElementBeam");			projectile.width = 16;			projectile.height = 16;			projectile.aiStyle = 27;			projectile.melee = true;			projectile.penetrate = 5;			projectile.light = 0.3f;			projectile.friendly = true;		}
		public override Color? GetAlpha(Color lightColor)		{			if (this.projectile.localAI[1] >= 15f)			{				return new Color(255, 255, 255, this.projectile.alpha);			}			if (this.projectile.localAI[1] < 5f)			{				return Color.Transparent;			}			int num7 = (int)((this.projectile.localAI[1] - 5f) / 10f * 255f);			return new Color(num7, num7, num7, num7);		}
		public override bool OnTileCollide(Vector2 oldVelocity)        {            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);            return true;        }        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)        {            int randomNum = Main.rand.Next(7);            if (randomNum == 0) target.AddBuff(20, 300);            else if (randomNum == 1) target.AddBuff(24, 200);            else if (randomNum == 2) target.AddBuff(31, 120);            else if (randomNum == 3) target.AddBuff(39, 300);            else if (randomNum == 4) target.AddBuff(44, 300);            else if (randomNum == 5) target.AddBuff(70, 240);            else if (randomNum == 6) target.AddBuff(69, 300);        }        public override void AI()		{
			if (projectile.localAI[1] > 7f)
			{
				int num208 = Main.rand.Next(3);
				if (num208 == 0)
				{
					num208 = 181;
				}
				else if (num208 == 1)
				{
					num208 = 182;
				}
				else if (num208 == 2)
				{
					num208 = 259;
				}
				var num484 = Dust.NewDust(new Vector2(projectile.position.X - projectile.velocity.X * 3f + 2f, projectile.position.Y + 2f - projectile.velocity.Y * 3f), 8, 8, num208, projectile.oldVelocity.X, projectile.oldVelocity.Y, 100, default(Color), 1.25f);
				Main.dust[num484].velocity *= -0.25f;
				Main.dust[num484].noGravity = true;
				num484 = Dust.NewDust(new Vector2(projectile.position.X - projectile.velocity.X * 3f + 2f, projectile.position.Y + 2f - projectile.velocity.Y * 3f), 8, 8, num208, projectile.oldVelocity.X, projectile.oldVelocity.Y, 100, default(Color), 1.25f);
				Main.dust[num484].velocity *= -0.25f;
				Main.dust[num484].noGravity = true;
				Main.dust[num484].position -= projectile.velocity * 0.5f;
			}		}
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
			for (int num394 = 4; num394 < 24; num394++)
			{
				float num395 = projectile.oldVelocity.X * (30f / (float)num394);
				float num396 = projectile.oldVelocity.Y * (30f / (float)num394);
				int num208 = Main.rand.Next(3);
				if (num208 == 0)
				{
					num208 = 181;
				}
				else if (num208 == 1)
				{
					num208 = 182;
				}
				else if (num208 == 2)
				{
					num208 = 259;
				}
				int num398 = Dust.NewDust(new Vector2(projectile.position.X - num395, projectile.position.Y - num396), 8, 8, num208, projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f, 100, default(Color), 1.8f);
				Main.dust[num398].velocity *= 1f;
				Main.dust[num398].noGravity = true;
			}
		}	}}