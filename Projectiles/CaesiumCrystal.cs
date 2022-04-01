using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Projectiles
{
	public class CaesiumCrystal : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Caesium Crystal");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/CaesiumCrystal");
			Projectile.width = dims.Width;
			Projectile.height = dims.Height / Main.projFrames[Projectile.type];
			Projectile.aiStyle = -1;
			Projectile.tileCollide = true;
			Projectile.friendly = false;
            Projectile.hostile = true;
			Projectile.timeLeft = 540;
			Projectile.light = 1f;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.ignoreWater = true;
            Projectile.GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().notReflect = true;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            SoundEngine.PlaySound(SoundID.Item, (int)Projectile.position.X, (int)Projectile.position.Y, 10);
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] >= 2f)
            {
                Projectile.position += Projectile.velocity;
                Projectile.Kill();
            }
            else
            {
                if (Projectile.velocity.Y != oldVelocity.Y)
                {
                    Projectile.velocity.Y = -oldVelocity.Y;
                }
                if (Projectile.velocity.X != oldVelocity.X)
                {
                    Projectile.velocity.X = -oldVelocity.X;
                }
            }
            return false;
        }
        public override void AI()
        {
            var num924 = Dust.NewDust(new Vector2(Projectile.position.X + Projectile.velocity.X, Projectile.position.Y + Projectile.velocity.Y), Projectile.width, Projectile.height, ModContent.DustType<Dusts.CaesiumDust>(), Projectile.velocity.X, Projectile.velocity.Y, 100, default, 1f);
            Main.dust[num924].noGravity = true;
            if (Main.rand.Next(10) == 0)
            {
                num924 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, ModContent.DustType<Dusts.CaesiumDust>(), Projectile.velocity.X, Projectile.velocity.Y, 100, default, 1.4f);
            }
            if (Projectile.ai[1] >= 20f)
            {
                Projectile.velocity.Y = Projectile.velocity.Y + 0.2f;
            }
            Projectile.rotation += 0.3f * Projectile.direction;
            if (Projectile.velocity.Y > 16f)
            {
                Projectile.velocity.Y = 16f;
                return;
            }
        }
    }
}
