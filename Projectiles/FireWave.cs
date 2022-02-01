using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class FireWave : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fire Wave");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 3;
            ProjectileID.Sets.TrailingMode[projectile.type] = 1;
        }
        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/FireWave");
            projectile.width = 32;
            projectile.height = 32;
            projectile.friendly = true;
            projectile.timeLeft = 40;
            projectile.alpha = 0;
            projectile.melee = true;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
            drawOffsetX = -24;
        }
        public override void AI()
        {
            projectile.alpha += 20;
            projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
            projectile.velocity *= 0.94f;
            if (projectile.timeLeft <= 25)
            {
                projectile.scale *= 0.97f;
            }
            if (projectile.timeLeft <= 20)
            {
                projectile.scale *= 0.95f;
            }
            if (projectile.timeLeft <= 15)
            {
                projectile.scale *= 0.93f;
            }
            if (projectile.timeLeft <= 10)
            {
                projectile.scale *= 0.91f;
            }
            float num1 = 1f;
            if (projectile.timeLeft <= 15)
            {
                num1 = 0.5f;
            }
            int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Fire, num1, num1, default, default, 2f);
            Main.dust[dust].noGravity = true;
            if (Main.rand.Next(3) == 0)
            {
                int dust1 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Smoke, 0f, 0f, default, default, 1.3f);
                Main.dust[dust1].noGravity = true;
            }
            if (Main.rand.Next(40) == 1)
            {
                int randomSize = Main.rand.Next(1, 4) / 2;
                int num161 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64));
                Gore gore30 = Main.gore[num161];
                Gore gore40 = gore30;
                gore40.velocity *= 0.3f;
                gore40.scale *= randomSize;
                Main.gore[num161].velocity.X += Main.rand.Next(-1, 2);
                Main.gore[num161].velocity.Y += Main.rand.Next(-1, 2);
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Daybreak, 180);
        }
        public override void ModifyDamageHitbox(ref Rectangle hitbox)
        {
            if (projectile.timeLeft >= 15)
            {
                int size = 20;
                hitbox.X -= size;
                hitbox.Y -= size;
                hitbox.Width += size * 2;
                hitbox.Height += size * 2;
            }
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(255, 255, 255, this.projectile.alpha);
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(-24f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            }
            Texture2D texture = mod.GetTexture("Projectiles/FireWave");
            Vector2 origin = new Vector2(texture.Width / 2, texture.Height / 2);
            spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, null, new Color(50, 50, 50, 50), projectile.rotation, origin, projectile.scale, SpriteEffects.None, 0.0f);
            return true;
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 2; i++)
            {
                int randomSize = Main.rand.Next(1, 4) / 2;
                int num161 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64));
                Gore gore30 = Main.gore[num161];
                Gore gore40 = gore30;
                gore40.velocity *= 0.3f;
                gore40.scale *= randomSize;
                Main.gore[num161].velocity.X += Main.rand.Next(-1, 2);
                Main.gore[num161].velocity.Y += Main.rand.Next(-1, 2);
            }
        }
    }
}
