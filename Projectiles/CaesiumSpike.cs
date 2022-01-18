using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class CaesiumSpike : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Caesium Spike");
        }
        public override void SetDefaults()
        {
            projectile.penetrate = 1;
            projectile.width = 18;
            projectile.height = 18;
            projectile.aiStyle = -1;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.timeLeft = 90;
            projectile.scale = 1.2f;
        }
        public override void AI()
        {
            projectile.spriteDirection = projectile.direction;
            projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
            if (Main.rand.Next(2) == 0)
            {
                int num239 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), 18, 18, ModContent.DustType<Dusts.CaesiumDust>(), -0.5f, -0.5f, default, default, 1.3f);
                Dust dust30 = Main.dust[num239];
                dust30.noGravity = true;
            }
        }
        int counter = 0;
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = mod.GetTexture("Projectiles/CaesiumSpike");
            Vector2 origin = new Vector2(texture.Width * 0.5f, projectile.height * 0.5f);
            if (projectile.spriteDirection == -1)
            {
                Main.spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, null, Color.White * ((255f - projectile.alpha) / 255f), projectile.rotation, origin, projectile.scale, SpriteEffects.FlipHorizontally, 0);
            }
            else
            {
                Main.spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, null, Color.White * ((255f - projectile.alpha) / 255f), projectile.rotation, origin, projectile.scale, SpriteEffects.None, 0);
            }
            counter++;
            if (counter > 22)
                counter = 0;
            for (int j = 0; j < 2; j++)
            {
                float bonusAlphaMult = 1 - 1 * (counter / 12f);
                float dir = j * 2 - 1;
                Vector2 offset = new Vector2(counter * 0.8f * dir, 0).RotatedBy(projectile.rotation);
                if (projectile.spriteDirection == -1)
                {
                    Main.spriteBatch.Draw(texture, projectile.Center - Main.screenPosition + offset, null, new Color(100, 100, 100, 0) * bonusAlphaMult * ((255f - projectile.alpha) / 255f), projectile.rotation, origin, 1.00f, SpriteEffects.FlipHorizontally, 0.0f);
                }
                else
                {
                    Main.spriteBatch.Draw(texture, projectile.Center - Main.screenPosition + offset, null, new Color(100, 100, 100, 0) * bonusAlphaMult * ((255f - projectile.alpha) / 255f), projectile.rotation, origin, 1.00f, SpriteEffects.None, 0.0f);
                }
            }
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item, (int)projectile.Center.X, (int)projectile.Center.Y, 27, 0.8f, -0.25f);
            for (int num237 = 0; num237 < 10; num237++)
            {
                int num239 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), 18, 18, ModContent.DustType<Dusts.CaesiumDust>(), projectile.oldVelocity.X * 0.8f, projectile.oldVelocity.Y * 0.8f, default, default, 1.3f);
                Dust dust30 = Main.dust[num239];
                dust30.noGravity = true;
            }
            for (int num237 = 0; num237 < 5; num237++)
            {
                int num239 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), 18, 18, 110, projectile.oldVelocity.X * 0.8f, projectile.oldVelocity.Y * 0.8f, default, default, 1.3f);
                Dust dust30 = Main.dust[num239];
                dust30.noGravity = true;
            }
        }
    }
}