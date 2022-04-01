using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class CaesiumExplosion : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Caesium Explosion");
        }
        public override void SetDefaults()
        {
            for (int i = 0; i < 6; i++)
            {
                Dust dust;
                Vector2 position = Projectile.Center;
                dust = Main.dust[Dust.NewDust(position, 0, 0, DustID.CursedTorch, Main.rand.Next(-5, 6), Main.rand.Next(-5, 6), 0, new Color(255, 255, 255), 3.552631f)];
                dust.noGravity = true;
                dust.noLight = true;
            }
            Projectile.width = 70;
            Projectile.height = 70;
            Projectile.friendly = true;
            Projectile.aiStyle = 0;
            Projectile.penetrate = -1;
            Projectile.extraUpdates = 1;
            Projectile.knockBack = 0;
            Projectile.timeLeft = 200;
            Main.projFrames[Projectile.type] = 7;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = false;
        }
        public override void AI()
        {
            Projectile.velocity *= 0.95f;
            Projectile.ai[0]++;

            Lighting.AddLight(Projectile.position, new Vector3(0, MathHelper.Lerp(1f, 0f, Projectile.ai[0] / (3 * 7)), 0));

            if (Projectile.ai[0] >= (3 * 7)) Projectile.Kill();
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive, null, null, null, null, Main.GameViewMatrix.ZoomMatrix);

            Texture2D tex = Main.projectileTexture[Projectile.type];

            float frame = (float)Math.Floor(Projectile.ai[0] / 3) * 70;

            spriteBatch.Draw(tex, Projectile.Center - Main.screenPosition,
                   new Rectangle(0, (int)frame, 70, 70), Color.White, 0f,
                   new Vector2(70 / 2, 70 / 2), Projectile.scale, SpriteEffects.None, 0f);

            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, Main.GameViewMatrix.ZoomMatrix);

            return false;
        }
    }
}