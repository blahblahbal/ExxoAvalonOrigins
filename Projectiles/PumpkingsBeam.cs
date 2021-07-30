using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Projectiles{	public class PumpkingsBeam : ModProjectile	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Pumpking's Beam");		}		public override void SetDefaults()		{			projectile.width = 16;			projectile.height = 16;			projectile.aiStyle = 27;			projectile.melee = true;			projectile.penetrate = 1;			projectile.friendly = true;		}
		public override Color? GetAlpha(Color lightColor)
		{
				return new Color(255, 255, 255, 100);
		}		public override void AI()		{			if (projectile.type == ModContent.ProjectileType<PumpkingsBeam>())			{				var num974 = ExxoAvalonOriginsGlobalNPC.FindClosest(projectile.position, 320f);				if (num974 != -1 && Main.npc[num974].lifeMax > 5 && !Main.npc[num974].friendly && !Main.npc[num974].townNPC)				{					var vector76 = Main.npc[num974].position;					if (Collision.CanHit(projectile.position, projectile.width, projectile.height, vector76, Main.npc[num974].width, Main.npc[num974].height))					{						projectile.velocity = Vector2.Normalize(vector76 - projectile.position) * 9f;					}				}			}			if (projectile.localAI[1] > 7f)
			{
				var Fire = Dust.NewDust(new Vector2(projectile.position.X - projectile.velocity.X * 4f, projectile.position.Y - projectile.velocity.Y * 4f), 8, 8, 6, 0f, 0f, 100, default(Color), 1.8f);
				Main.dust[Fire].velocity *= 0.2f;
				Main.dust[Fire].noGravity = true;
			}		}
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
					num397 = 6; //extremely lazy fix lol
				}
				else if (num397 == 1)
				{
					num397 = 6;
				}
				else
				{
					num397 = 6;
				}
				int num398 = Dust.NewDust(new Vector2(projectile.position.X - num395, projectile.position.Y - num396), 8, 8, num397, projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f, 100, default(Color), 1.8f);
				Main.dust[num398].velocity *= 1.5f;
				Main.dust[num398].noGravity = true;
			}
		}	}}