using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;namespace ExxoAvalonOrigins.Projectiles{	public class MagicCleaver : ModProjectile	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Magic Cleaver");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/MagicCleaver");			projectile.width = 44;			projectile.height = 44;			projectile.aiStyle = 2;			projectile.friendly = true;			projectile.penetrate = 5;			projectile.light = 0.15f;			projectile.alpha = 0;			projectile.scale = 1f;			projectile.timeLeft = 3600;			projectile.magic = true;			projectile.tileCollide = true;		}
        public override Color? GetAlpha(Color lightColor)
        {
			return new Color(255, 255, 255, 200);
		}
        public override void AI()		{
			if (Main.rand.Next(4) == 0)
			{
				int num = Dust.NewDust(projectile.position, projectile.width, projectile.height, 57, projectile.velocity.X * 0.2f + (float)(projectile.direction * 3), projectile.velocity.Y * 0.2f, 100, default(Color), 0.5f);
				Main.dust[num].velocity.X *= 0.1f;
				Main.dust[num].velocity.Y *= 0.1f;
			}		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			for (int num410 = 0; num410 < 5; num410++)
			{
				int num411 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 57, 0f, 0f, 100, default(Color), 1f);
				Main.dust[num411].velocity *= 1f;
			}
		}
        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
        {
			height = 25;
			width = 25;
			return true;
		}
        public override void Kill(int timeLeft)
        {
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
			for (int num410 = 0; num410 < 10; num410++)
			{
				int num411 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 57, 0f, 0f, 100, default(Color), 1f);
				Main.dust[num411].velocity *= 1f;
			}
		}
	}}