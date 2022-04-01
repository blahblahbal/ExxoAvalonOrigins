using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

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
            Projectile.penetrate = 1;
            Projectile.width = 18;
            Projectile.height = 18;
            Projectile.aiStyle = -1;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.timeLeft = 90;
            Projectile.scale = 1.2f;
        }
        public override void AI()
        {
            Projectile.spriteDirection = Projectile.direction;
            Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.57f;
            if (Main.rand.Next(2) == 0)
            {
                int num239 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), 18, 18, ModContent.DustType<Dusts.CaesiumDust>(), -0.5f, -0.5f, default, default, 1.3f);
                Dust dust30 = Main.dust[num239];
                dust30.noGravity = true;
            }
        }
        int counter = 0;
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = Mod.Assets.Request<Texture2D>("Projectiles/CaesiumSpike").Value;
            Vector2 origin = new Vector2(texture.Width * 0.5f, Projectile.height * 0.5f);
            if (Projectile.spriteDirection == -1)
            {
                Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition, null, Color.White * ((255f - Projectile.alpha) / 255f), Projectile.rotation, origin, Projectile.scale, SpriteEffects.FlipHorizontally, 0);
            }
            else
            {
                Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition, null, Color.White * ((255f - Projectile.alpha) / 255f), Projectile.rotation, origin, Projectile.scale, SpriteEffects.None, 0);
            }
            counter++;
            if (counter > 22)
                counter = 0;
            for (int j = 0; j < 2; j++)
            {
                float bonusAlphaMult = 1 - 1 * (counter / 12f);
                float dir = j * 2 - 1;
                Vector2 offset = new Vector2(counter * 0.8f * dir, 0).RotatedBy(Projectile.rotation);
                if (Projectile.spriteDirection == -1)
                {
                    Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + offset, null, new Color(100, 100, 100, 0) * bonusAlphaMult * ((255f - Projectile.alpha) / 255f), Projectile.rotation, origin, 1.00f, SpriteEffects.FlipHorizontally, 0.0f);
                }
                else
                {
                    Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + offset, null, new Color(100, 100, 100, 0) * bonusAlphaMult * ((255f - Projectile.alpha) / 255f), Projectile.rotation, origin, 1.00f, SpriteEffects.None, 0.0f);
                }
            }
        }
        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item, (int)Projectile.Center.X, (int)Projectile.Center.Y, 27, 0.8f, -0.25f);
            for (int num237 = 0; num237 < 10; num237++)
            {
                int num239 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), 18, 18, ModContent.DustType<Dusts.CaesiumDust>(), Projectile.oldVelocity.X * 0.8f, Projectile.oldVelocity.Y * 0.8f, default, default, 1.3f);
                Dust dust30 = Main.dust[num239];
                dust30.noGravity = true;
            }
            for (int num237 = 0; num237 < 5; num237++)
            {
                int num239 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), 18, 18, 110, Projectile.oldVelocity.X * 0.8f, Projectile.oldVelocity.Y * 0.8f, default, default, 1.3f);
                Dust dust30 = Main.dust[num239];
                dust30.noGravity = true;
            }
        }
    }
}