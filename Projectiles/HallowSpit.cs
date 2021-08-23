using Microsoft.Xna.Framework;using System;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Projectiles{	public class HallowSpit : ModProjectile	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Hallow Spit");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/HallowSpit");			projectile.width = dims.Width;			projectile.height = dims.Height / Main.projFrames[projectile.type];			projectile.aiStyle = -1;			projectile.hostile = true;			projectile.light = 0f;			projectile.ranged = true;			projectile.penetrate = -1;			projectile.scale = 1f;			projectile.tileCollide = true;		}		public override void AI()		{
			if (projectile.alpha > 0)
			{
				projectile.alpha -= 15;
			}
			if (projectile.alpha < 0)
			{
				projectile.alpha = 0;
			}
			for (int num168 = 0; num168 < 2; num168++)
			{
				int num171 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), projectile.width, projectile.height, 58, projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 80, default(Color), 1.3f);
				Main.dust[num171].velocity *= 0.3f;
				Main.dust[num171].noGravity = true;
			}			if (projectile.ai[0] >= 15f)			{				projectile.ai[0] = 15f;				projectile.velocity.Y = projectile.velocity.Y + 0.1f;			}			projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;			if (projectile.velocity.Y > 16f)			{				projectile.velocity.Y = 16f;			}		}		public override void Kill(int timeLeft)		{			Main.PlaySound(SoundID.NPCKilled, (int)projectile.position.X, (int)projectile.position.Y, 9);			projectile.active = false;		}	}}