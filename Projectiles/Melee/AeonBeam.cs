using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Projectiles.Melee
{
    public class AeonBeam : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aeon Beam");
        }
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 27;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.alpha = 255;
            Projectile.friendly = true;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            if (this.Projectile.localAI[1] >= 15f)
            {
                return new Color(255, 255, 255, this.Projectile.alpha);
            }
            if (this.Projectile.localAI[1] < 5f)
            {
                return Color.Transparent;
            }
            int num7 = (int)((this.Projectile.localAI[1] - 5f) / 10f * 255f);
            return new Color(num7, num7, num7, num7);
        }
        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item, (int)Projectile.position.X, (int)Projectile.position.Y, 10);
            for (int num949 = 4; num949 < 31; num949++)
            {
                float num950 = Projectile.oldVelocity.X * (30f / (float)num949);
                float num951 = Projectile.oldVelocity.Y * (30f / (float)num949);
                int num952 = Dust.NewDust(new Vector2(Projectile.oldPosition.X - num950, Projectile.oldPosition.Y - num951), 8, 8, DustID.PinkFairy, Projectile.oldVelocity.X, Projectile.oldVelocity.Y, 255, default(Color), 1.8f);
                Main.dust[num952].noGravity = true;
                Dust dust = Main.dust[num952];
                dust.velocity *= 0.5f;
                num952 = Dust.NewDust(new Vector2(Projectile.oldPosition.X - num950, Projectile.oldPosition.Y - num951), 8, 8, DustID.PinkFairy, Projectile.oldVelocity.X, Projectile.oldVelocity.Y, 255, default(Color), 1.4f);
                dust = Main.dust[num952];
                dust.velocity *= 0.05f;
                Main.dust[num952].noGravity = true;
            }
        }
    }
}
