using Microsoft.Xna.Framework;using Microsoft.Xna.Framework.Graphics;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;

namespace ExxoAvalonOrigins.Projectiles{	public class CaesiumExplosion : ModProjectile	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Caesium Explosion");		}		public override void SetDefaults()		{
			for (int i = 0; i < 6; i++)
			{
				Dust dust;
				Vector2 position = projectile.Center;
				dust = Main.dust[Dust.NewDust(position, 0, 0, DustID.CursedTorch, Main.rand.Next(-5, 6), Main.rand.Next(-5, 6), 0, new Color(255, 255, 255), 3.552631f)];
				dust.noGravity = true;
				dust.noLight = true;
			}
			projectile.width = 70;
			projectile.height = 70;
			projectile.friendly = true;
			projectile.aiStyle = 0;
			projectile.penetrate = -1;
			projectile.extraUpdates = 1;
			projectile.knockBack = 0;
			projectile.timeLeft = 200;
			Main.projFrames[projectile.type] = 7;
			projectile.tileCollide = false;
			projectile.ignoreWater = false;		}
		public override void AI()		{
			projectile.velocity *= 0.95f;
			projectile.ai[0]++;

			Lighting.AddLight(projectile.position, new Vector3(0, MathHelper.Lerp(1f, 0f, projectile.ai[0] / (3 * 7)), 0));			if (projectile.ai[0] >= (3 * 7)) projectile.Kill();		}

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			spriteBatch.End();
			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive, null, null, null, null, Main.GameViewMatrix.ZoomMatrix);

			Texture2D tex = Main.projectileTexture[projectile.type];

			float frame = (float)Math.Floor(projectile.ai[0] / 3) * 70;

			spriteBatch.Draw(tex, projectile.Center - Main.screenPosition,
				   new Rectangle(0, (int)frame, 70, 70), Color.White, 0f,
				   new Vector2(70 / 2, 70 / 2), projectile.scale, SpriteEffects.None, 0f);

			spriteBatch.End();
			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, Main.GameViewMatrix.ZoomMatrix);

			return false;
		}
    }}