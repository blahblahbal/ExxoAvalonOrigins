using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles.Melee
{
    public class TritonWave : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Triton Wave");
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 3;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 1;
        }
        public override void SetDefaults()
        {
            Projectile.width = 32;
            Projectile.height = 32;
            Projectile.friendly = true;
            Projectile.timeLeft = 20;
            Projectile.alpha = 0;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            DrawOffsetX = -24;
        }
        public override void AI()
        {
            Projectile.alpha += 20;
            Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.57f;
            Projectile.velocity *= 0.94f;
            if (Projectile.timeLeft <= 25)
            {
                Projectile.scale *= 0.97f;
            }
            if (Projectile.timeLeft <= 20)
            {
                Projectile.scale *= 0.95f;
            }
            if (Projectile.timeLeft <= 15)
            {
                Projectile.scale *= 0.93f;
            }
            if (Projectile.timeLeft <= 10)
            {
                Projectile.scale *= 0.91f;
            }
            //int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, ModContent.DustType<Dusts.TritanoriumFlame>(), 0f, 0f, default, default, 1f);
            //Main.dust[dust].noGravity = true;
            /*if (Main.rand.Next(4) == 0)
            {
                int dust1 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Smoke, 0f, 0f, default, default, 1.3f);
                Main.dust[dust1].noGravity = true;
            }
            if (Main.rand.Next(80) == 1)
            {
                int randomSize = Main.rand.Next(1, 4) / 2;
                int num161 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64));
                Gore gore30 = Main.gore[num161];
                Gore gore40 = gore30;
                gore40.velocity *= 0.3f;
                gore40.scale *= randomSize;
                Main.gore[num161].velocity.X += Main.rand.Next(-1, 2);
                Main.gore[num161].velocity.Y += Main.rand.Next(-1, 2);
            }*/
        }
        public override void ModifyDamageHitbox(ref Rectangle hitbox)
        {
            if (Projectile.timeLeft >= 15)
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
            return new Color(255, 255, 255, this.Projectile.alpha);
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[Projectile.type].Width * 0.5f, Projectile.height * 0.5f);
            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(-24f, Projectile.gfxOffY);
                Color color = Projectile.GetAlpha(lightColor) * ((float)(Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[Projectile.type], drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            }
            Texture2D texture = Mod.Assets.Request<Texture2D>("Projectiles/Melee/FireWave").Value;
            Vector2 origin = new Vector2(texture.Width / 2, texture.Height / 2);
            spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition, null, new Color(50, 50, 50, 50), Projectile.rotation, origin, Projectile.scale, SpriteEffects.None, 0.0f);
            return true;
        }
    }
}
