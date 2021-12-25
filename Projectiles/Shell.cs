using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class Shell : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shell");
            Main.projFrames[projectile.type] = 4;
        }
        public override void SetDefaults()
        {
            projectile.width = 32;
            projectile.height = 24;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.penetrate = -1;
            projectile.tileCollide = true;
            projectile.timeLeft = 900;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.velocity.Y != oldVelocity.Y && oldVelocity.Y > 5f)
            {
                Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
                Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 1);
                projectile.velocity.Y = -oldVelocity.Y * 0.2f;
            }
            if (projectile.velocity.X != oldVelocity.X)
            {
                projectile.velocity.X = -oldVelocity.X * 0.85f;
            }
            return false;
        }
        public override void AI()
        {
            projectile.ai[0]++;
            if (projectile.ai[0] >= 10 && !Collision.SolidCollision(projectile.position, projectile.width, projectile.height))
            {
                projectile.velocity.Y += 3.6f;
                projectile.ai[0] = 0;
            }
            if (projectile.velocity.Y >= 0f)
            {
                int num97 = 0;
                if (projectile.velocity.X < 0f)
                {
                    num97 = -1;
                }
                if (projectile.velocity.X > 0f)
                {
                    num97 = 1;
                }
                Vector2 vector10 = projectile.position;
                vector10.X += projectile.velocity.X;
                int num98 = (int)((vector10.X + (float)(projectile.width / 2) + (float)((projectile.width / 2 + 1) * num97)) / 16f);
                int num99 = (int)((vector10.Y + (float)projectile.height - 1f) / 16f);
                if (Main.tile[num98, num99] == null)
                {
                    Main.tile[num98, num99] = new Tile();
                }
                if (Main.tile[num98, num99 - 1] == null)
                {
                    Main.tile[num98, num99 - 1] = new Tile();
                }
                if (Main.tile[num98, num99 - 2] == null)
                {
                    Main.tile[num98, num99 - 2] = new Tile();
                }
                if (Main.tile[num98, num99 - 3] == null)
                {
                    Main.tile[num98, num99 - 3] = new Tile();
                }
                if (Main.tile[num98, num99 + 1] == null)
                {
                    Main.tile[num98, num99 + 1] = new Tile();
                }
                if (Main.tile[num98 - num97, num99 - 3] == null)
                {
                    Main.tile[num98 - num97, num99 - 3] = new Tile();
                }
                if ((float)(num98 * 16) < vector10.X + (float)projectile.width && (float)(num98 * 16 + 16) > vector10.X && ((Main.tile[num98, num99].nactive() && !Main.tile[num98, num99].topSlope() && !Main.tile[num98, num99 - 1].topSlope() && Main.tileSolid[(int)Main.tile[num98, num99].type] && !Main.tileSolidTop[(int)Main.tile[num98, num99].type]) || (Main.tile[num98, num99 - 1].halfBrick() && Main.tile[num98, num99 - 1].nactive())) && (!Main.tile[num98, num99 - 1].nactive() || !Main.tileSolid[(int)Main.tile[num98, num99 - 1].type] || Main.tileSolidTop[(int)Main.tile[num98, num99 - 1].type] || (Main.tile[num98, num99 - 1].halfBrick() && (!Main.tile[num98, num99 - 4].nactive() || !Main.tileSolid[(int)Main.tile[num98, num99 - 4].type] || Main.tileSolidTop[(int)Main.tile[num98, num99 - 4].type]))) && (!Main.tile[num98, num99 - 2].nactive() || !Main.tileSolid[(int)Main.tile[num98, num99 - 2].type] || Main.tileSolidTop[(int)Main.tile[num98, num99 - 2].type]) && (!Main.tile[num98, num99 - 3].nactive() || !Main.tileSolid[(int)Main.tile[num98, num99 - 3].type] || Main.tileSolidTop[(int)Main.tile[num98, num99 - 3].type]) && (!Main.tile[num98 - num97, num99 - 3].nactive() || !Main.tileSolid[(int)Main.tile[num98 - num97, num99 - 3].type]))
                {
                    float num100 = (float)(num99 * 16);
                    if (Main.tile[num98, num99].halfBrick())
                    {
                        num100 += 8f;
                    }
                    if (Main.tile[num98, num99 - 1].halfBrick())
                    {
                        num100 -= 8f;
                    }
                    if (num100 < vector10.Y + (float)projectile.height)
                    {
                        float num101 = vector10.Y + (float)projectile.height - num100;
                        float num102 = 16.1f;
                        if (num101 <= num102)
                        {
                            projectile.gfxOffY += projectile.position.Y + (float)projectile.height - num100;
                            projectile.position.Y = num100 - (float)projectile.height;
                            if (num101 < 9f)
                            {
                                projectile.stepSpeed = 1f;
                            }
                            else
                            {
                                projectile.stepSpeed = 2f;
                            }
                        }
                    }
                }
            }
            Collision.StepUp(ref projectile.position, ref projectile.velocity, projectile.width, projectile.height, ref projectile.stepSpeed, ref projectile.gfxOffY);
            if (projectile.velocity.Y > 16f)
            {
                projectile.velocity.Y = 16f;
            }
            if (projectile.velocity.Y <= 6f)
            {
                if (projectile.velocity.X > 0f && projectile.velocity.X < 7f)
                {
                    projectile.velocity.X = projectile.velocity.X + 0.05f;
                }
                if (projectile.velocity.X < 0f && projectile.velocity.X > -7f)
                {
                    projectile.velocity.X = projectile.velocity.X - 0.05f;
                }
            }
            projectile.frameCounter += (int)Math.Abs(projectile.velocity.X);
            if (projectile.frameCounter > 10)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame > 3)
            {
                projectile.frame = 0;
            }
        }
    }
}
