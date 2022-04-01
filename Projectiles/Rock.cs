using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Projectiles
{
    public class Rock : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rock");
        }
        public override void SetDefaults()
        {
            Projectile.netImportant = true;
            Projectile.width = 32;
            Projectile.height = 32;
            Projectile.aiStyle = 25;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 1200;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
            Projectile.friendly = true;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (Projectile.velocity.Y != oldVelocity.Y && oldVelocity.Y > 5f)
            {
                Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);
                SoundEngine.PlaySound(SoundID.Dig, (int)Projectile.position.X, (int)Projectile.position.Y, 1);
                Projectile.velocity.Y = -oldVelocity.Y * 0.2f;
            }
            if (Projectile.velocity.X != oldVelocity.X)
            {
                Projectile.Kill();
            }
            return false;
        }

        //    public override void AI()
        //    {
        //        if (projectile.ai[0] != 0f && projectile.velocity.Y <= 0f && projectile.velocity.X == 0f)
        //        {
        //            float num157 = 0.5f;
        //            int i2 = (int)((projectile.position.X - 8f) / 16f);
        //            int num158 = (int)(projectile.position.Y / 16f);
        //            bool flag3 = false;
        //            bool flag4 = false;
        //            if (WorldGen.SolidTile(i2, num158) || WorldGen.SolidTile(i2, num158 + 1))
        //            {
        //                flag3 = true;
        //            }
        //            i2 = (int)((projectile.position.X + (float)projectile.width + 8f) / 16f);
        //            if (WorldGen.SolidTile(i2, num158) || WorldGen.SolidTile(i2, num158 + 1))
        //            {
        //                flag4 = true;
        //            }
        //            if (flag3)
        //            {
        //                projectile.velocity.X = num157;
        //            }
        //            else
        //            {
        //                if (flag4)
        //                {
        //                    projectile.velocity.X = -num157;
        //                }
        //                else
        //                {
        //                    i2 = (int)((projectile.position.X - 8f - 16f) / 16f);
        //                    num158 = (int)(projectile.position.Y / 16f);
        //                    flag3 = false;
        //                    flag4 = false;
        //                    if (WorldGen.SolidTile(i2, num158) || WorldGen.SolidTile(i2, num158 + 1))
        //                    {
        //                        flag3 = true;
        //                    }
        //                    i2 = (int)((projectile.position.X + (float)projectile.width + 8f + 16f) / 16f);
        //                    if (WorldGen.SolidTile(i2, num158) || WorldGen.SolidTile(i2, num158 + 1))
        //                    {
        //                        flag4 = true;
        //                    }
        //                    if (flag3)
        //                    {
        //                        projectile.velocity.X = num157;
        //                    }
        //                    else
        //                    {
        //                        if (flag4)
        //                        {
        //                            projectile.velocity.X = -num157;
        //                        }
        //                        else
        //                        {
        //                            i2 = (int)((projectile.position.X + 4f) / 16f);
        //                            num158 = (int)((projectile.position.Y + (float)projectile.height + 8f) / 16f);
        //                            if (WorldGen.SolidTile(i2, num158) || WorldGen.SolidTile(i2, num158 + 1))
        //                            {
        //                                flag3 = true;
        //                            }
        //                            if (!flag3)
        //                            {
        //                                projectile.velocity.X = num157;
        //                            }
        //                            else
        //                            {
        //                                projectile.velocity.X = -num157;
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        projectile.rotation += projectile.velocity.X * 0.06f;
        //        projectile.ai[0] = 1f;
        //        if (projectile.velocity.Y > 16f)
        //        {
        //            projectile.velocity.Y = 16f;
        //        }
        //        if (projectile.velocity.Y <= 6f)
        //        {
        //            if (projectile.velocity.X > 0f && projectile.velocity.X < 7f)
        //            {
        //                projectile.velocity.X = projectile.velocity.X + 0.05f;
        //            }
        //            if (projectile.velocity.X < 0f && projectile.velocity.X > -7f)
        //            {
        //                projectile.velocity.X = projectile.velocity.X - 0.05f;
        //            }
        //        }
        //        projectile.velocity.Y = projectile.velocity.Y + 0.3f;
        //    }
        //}
    }
}
