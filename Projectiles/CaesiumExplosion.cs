using Microsoft.Xna.Framework;using Microsoft.Xna.Framework.Graphics;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;

namespace ExxoAvalonOrigins.Projectiles{	public class CaesiumExplosion : ModProjectile	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Caesium Explosion");		}		public override void SetDefaults()		{			projectile.width = 14;			projectile.height = 14;			projectile.alpha = 255;			projectile.friendly = true;			projectile.timeLeft = 1;			projectile.penetrate = -1;			projectile.scale = 1f;			projectile.melee = true;		}
		public override void AI()		{
					}
        public override void Kill(int timeLeft)
        {
			Main.PlaySound(SoundID.Item14, projectile.position);
			if (projectile.owner == Main.myPlayer)
			{
				int num143 = Main.rand.Next(4, 8);
				int[] array = new int[num143];
				int num144 = 0;
				for (int num145 = 0; num145 < 200; num145++)
				{
					if (Main.npc[num145].CanBeChasedBy(this, ignoreDontTakeDamage: true) && Collision.CanHitLine(projectile.position, projectile.width, projectile.height, Main.npc[num145].position, Main.npc[num145].width, Main.npc[num145].height))
					{
						array[num144] = num145;
						num144++;
						if (num144 == num143)
						{
							break;
						}
					}
				}
				if (num144 > 1)
				{
					for (int num147 = 0; num147 < 100; num147++)
					{
						int num148 = Main.rand.Next(num144);
						int num149;
						for (num149 = num148; num149 == num148; num149 = Main.rand.Next(num144))
						{
						}
						int num150 = array[num148];
						array[num148] = array[num149];
						array[num149] = num150;
					}
				}
				Vector2 vector19 = new Vector2(-1f, -1f);
				for (int num151 = 0; num151 < num144; num151++)
				{
					Vector2 vector20 = Main.npc[array[num151]].Center - projectile.Center;
					vector20.Normalize();
					vector19 += vector20;
				}
				vector19.Normalize();
				//for (int num152 = 0; num152 < num143; num152++)
				//{
				//	float num153 = Main.rand.Next(8, 15);
				//	Vector2 vector21 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
				//	vector21.Normalize();
				//	if (num144 > 0)
				//	{
				//		vector21 += vector19;
				//		vector21.Normalize();
				//	}
				//	vector21 *= num153;
				//	if (num144 > 0)
				//	{
				//		num144--;
				//		vector21 = Main.npc[array[num144]].Center - projectile.Center;
				//		vector21.Normalize();
				//		vector21 *= num153;
				//	}
				//	Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vector21.X, vector21.Y, 484, (int)((double)projectile.damage * 0.7), projectile.knockBack * 0.7f, projectile.owner);
				//}
			}
			for (int num156 = 0; num156 < 7; num156++)
			{
				int num158 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 1.5f);
				Dust dust141 = Main.dust[num158];
				Dust dust226 = dust141;
				dust226.velocity *= 0.9f;
				Main.dust[num158].scale = 0.9f;
			}
			for (int num159 = 0; num159 < 3; num159++)
			{
				int num160 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 2.5f);
				Main.dust[num160].noGravity = true;
				Dust dust140 = Main.dust[num160];
				Dust dust226 = dust140;
				dust226.velocity *= 3f;
				num160 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 1.5f);
				dust140 = Main.dust[num160];
				dust226 = dust140;
				dust226.velocity *= 2f;
			}
			int num161 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64));
			Gore gore30 = Main.gore[num161];
			Gore gore40 = gore30;
			gore40.velocity *= 0.3f;
			Main.gore[num161].velocity.X += Main.rand.Next(-1, 2);
			Main.gore[num161].velocity.Y += Main.rand.Next(-1, 2);
			if (projectile.owner == Main.myPlayer)
			{
				int num162 = 100;
				projectile.position.X -= num162 / 2;
				projectile.position.Y -= num162 / 2;
				projectile.width += num162;
				projectile.height++;
				projectile.penetrate = -1;
				projectile.Damage();
			}
		}
    }}