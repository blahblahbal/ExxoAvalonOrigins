using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Projectiles
{
    public class BloodyTear : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloody Tear");
        }
        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/BloodyTear");
            Projectile.penetrate = 1;
            Projectile.width = 12;
            Projectile.height = 12;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.timeLeft = 70;
            Projectile.scale = 1.4f;
        }
        public override void AI()
        {
            Projectile.spriteDirection = Projectile.direction;
            Projectile.scale *= 0.99f;
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] == 4f)
            {
                for (int num257 = 0; num257 < 10; num257++)
                {
                    int newDust = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), 8, 8, DustID.Blood, Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 0.5f, 100, default(Color), 1f);
                    Main.dust[newDust].position = (Main.dust[newDust].position + Projectile.Center) / 2f;
                    Main.dust[newDust].noGravity = true;
                    Main.dust[newDust].velocity *= 0.5f;
                }
            }
            if (Main.rand.Next(6) == 5)
            {
                Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), 8, 8, DustID.Blood, Projectile.oldVelocity.X * 0.1f, Projectile.oldVelocity.Y * 0.1f, 100, default(Color), 1f);
            }
        }
        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.NPCDeath9, Projectile.position);
            for (int num237 = 0; num237 < 10; num237++)
            {
                int num239 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), 8, 8, DustID.Blood, Projectile.oldVelocity.X * 0.2f, Projectile.oldVelocity.Y * 0.2f, 100, default(Color), 1.5f);
                Dust dust30 = Main.dust[num239];
                dust30.noGravity = false;
                dust30.scale = 1f;
            }
        }
    }
}
