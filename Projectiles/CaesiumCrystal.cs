using Microsoft.Xna.Framework;
        {
            Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 10);
            projectile.ai[0] += 1f;
            if (projectile.ai[0] >= 2f)
            {
                projectile.position += projectile.velocity;
                projectile.Kill();
            }
            else
            {
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y;
                }
                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -oldVelocity.X;
                }
            }
            return false;
        }