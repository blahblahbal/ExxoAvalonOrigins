using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Projectiles
{
    public class MagmafrostBolt : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magmafrost Bolt");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/MagmafrostBolt");
            Projectile.width = dims.Width * 12 / 16;
            Projectile.height = dims.Height * 12 / 16 / Main.projFrames[Projectile.type];
            Projectile.aiStyle = -1;
            Projectile.tileCollide = true;
            Projectile.friendly = true;
            Projectile.alpha = 255;
            Projectile.light = 0.8f;
            Projectile.penetrate = 15;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.timeLeft = 2400;
            Projectile.ignoreWater = true;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (Projectile.type == ModContent.ProjectileType<MagmafrostBolt>())
            {
                SoundEngine.PlaySound(SoundID.Item, (int)Projectile.position.X, (int)Projectile.position.Y, 10);
                Projectile.ai[0] += 1f;
                if (Projectile.ai[0] >= 10f)
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
            }
            return false;
        }

        public override void AI()
        {
            if (Projectile.type == ModContent.ProjectileType<MagmafrostBolt>())
            {
                for (var num905 = 0; num905 < 3; num905++)
                {
                    var num906 = Projectile.velocity.X / 3f * num905;
                    var num907 = Projectile.velocity.Y / 3f * num905;
                    var num908 = 4;
                    var num909 = Dust.NewDust(new Vector2(Projectile.position.X + num908, Projectile.position.Y + num908), Projectile.width - num908 * 2, Projectile.height - num908 * 2, DustID.Torch, 0f, 0f, 100, default(Color), 1.2f);
                    Main.dust[num909].noGravity = true;
                    Main.dust[num909].velocity *= 0.1f;
                    Main.dust[num909].velocity += Projectile.velocity * 0.1f;
                    var dust101 = Main.dust[num909];
                    dust101.position.X = dust101.position.X - num906;
                    var dust102 = Main.dust[num909];
                    dust102.position.Y = dust102.position.Y - num907;
                }
                for (var num910 = 0; num910 < 3; num910++)
                {
                    var num911 = Projectile.velocity.X / 3f * num910;
                    var num912 = Projectile.velocity.Y / 3f * num910;
                    var num913 = 4;
                    var num914 = Dust.NewDust(new Vector2(Projectile.position.X + num913, Projectile.position.Y + num913), Projectile.width - num913 * 2, Projectile.height - num913 * 2, DustID.IceTorch, 0f, 0f, 100, default(Color), 1.2f);
                    Main.dust[num914].noGravity = true;
                    Main.dust[num914].velocity *= 0.1f;
                    Main.dust[num914].velocity += Projectile.velocity * 0.1f;
                    var dust103 = Main.dust[num914];
                    dust103.position.X = dust103.position.X - num911;
                    var dust104 = Main.dust[num914];
                    dust104.position.Y = dust104.position.Y - num912;
                }
                if (Main.rand.Next(2) == 0)
                {
                    var num915 = 4;
                    var num916 = Dust.NewDust(new Vector2(Projectile.position.X + num915, Projectile.position.Y + num915), Projectile.width - num915 * 2, Projectile.height - num915 * 2, DustID.IceTorch, 0f, 0f, 100, default(Color), 0.6f);
                    Main.dust[num916].velocity *= 0.25f;
                    Main.dust[num916].velocity += Projectile.velocity * 0.5f;
                }
            }
            else
            {
                for (var num926 = 0; num926 < 2; num926++)
                {
                    var num927 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Torch, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100, default(Color), 2f);
                    Main.dust[num927].noGravity = true;
                    var dust107 = Main.dust[num927];
                    dust107.velocity.X = dust107.velocity.X * 0.3f;
                    var dust108 = Main.dust[num927];
                    dust108.velocity.Y = dust108.velocity.Y * 0.3f;
                }
            }
            if (Projectile.type != ModContent.ProjectileType<FreezeBolt>() && Projectile.type != ModContent.ProjectileType<ChaosBolt>() && Projectile.type != ModContent.ProjectileType<MagmafrostBolt>())
            {
                Projectile.ai[1] += 1f;
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