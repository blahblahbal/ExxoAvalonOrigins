using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Projectiles.Melee
{
    public class Shell : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shell");
            Main.projFrames[Projectile.type] = 4;
        }
        public override void SetDefaults()
        {
            Projectile.width = 32;
            Projectile.height = 24;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = -1;
            Projectile.tileCollide = true;
            Projectile.timeLeft = 900;
            Projectile.damage = 87;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (Projectile.velocity.Y != oldVelocity.Y && oldVelocity.Y > 5f)
            {
                Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);
                SoundEngine.PlaySound(0, (int)Projectile.position.X, (int)Projectile.position.Y, 1);
                Projectile.velocity.Y = -oldVelocity.Y * 0.2f;
            }
            if (Projectile.velocity.X != oldVelocity.X)
            {
                Projectile.velocity.X = -oldVelocity.X * 0.85f;
            }
            return false;
        }
        public override void AI()
        {
            Projectile.ai[0]++;
            if (Projectile.ai[0] >= 10 && !Collision.SolidCollision(Projectile.position, Projectile.width, Projectile.height))
            {
                Projectile.velocity.Y += 3.6f;
                Projectile.ai[0] = 0;
            }
            if (Projectile.velocity.Y >= 0f)
            {
                int num97 = 0;
                if (Projectile.velocity.X < 0f)
                {
                    num97 = -1;
                }
                if (Projectile.velocity.X > 0f)
                {
                    num97 = 1;
                }
                Vector2 vector10 = Projectile.position;
                vector10.X += Projectile.velocity.X;
                int num98 = (int)((vector10.X + (float)(Projectile.width / 2) + (float)((Projectile.width / 2 + 1) * num97)) / 16f);
                int num99 = (int)((vector10.Y + (float)Projectile.height - 1f) / 16f);
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
                if ((float)(num98 * 16) < vector10.X + (float)Projectile.width && (float)(num98 * 16 + 16) > vector10.X && ((Main.tile[num98, num99].HasUnactuatedTile && !Main.tile[num98, num99].topSlope() && !Main.tile[num98, num99 - 1].topSlope() && Main.tileSolid[(int)Main.tile[num98, num99].TileType] && !Main.tileSolidTop[(int)Main.tile[num98, num99].TileType]) || (Main.tile[num98, num99 - 1].IsHalfBlock && Main.tile[num98, num99 - 1].HasUnactuatedTile)) && (!Main.tile[num98, num99 - 1].HasUnactuatedTile || !Main.tileSolid[(int)Main.tile[num98, num99 - 1].TileType] || Main.tileSolidTop[(int)Main.tile[num98, num99 - 1].TileType] || (Main.tile[num98, num99 - 1].IsHalfBlock && (!Main.tile[num98, num99 - 4].HasUnactuatedTile || !Main.tileSolid[(int)Main.tile[num98, num99 - 4].TileType] || Main.tileSolidTop[(int)Main.tile[num98, num99 - 4].TileType]))) && (!Main.tile[num98, num99 - 2].HasUnactuatedTile || !Main.tileSolid[(int)Main.tile[num98, num99 - 2].TileType] || Main.tileSolidTop[(int)Main.tile[num98, num99 - 2].TileType]) && (!Main.tile[num98, num99 - 3].HasUnactuatedTile || !Main.tileSolid[(int)Main.tile[num98, num99 - 3].TileType] || Main.tileSolidTop[(int)Main.tile[num98, num99 - 3].TileType]) && (!Main.tile[num98 - num97, num99 - 3].HasUnactuatedTile || !Main.tileSolid[(int)Main.tile[num98 - num97, num99 - 3].TileType]))
                {
                    float num100 = (float)(num99 * 16);
                    if (Main.tile[num98, num99].IsHalfBlock)
                    {
                        num100 += 8f;
                    }
                    if (Main.tile[num98, num99 - 1].IsHalfBlock)
                    {
                        num100 -= 8f;
                    }
                    if (num100 < vector10.Y + (float)Projectile.height)
                    {
                        float num101 = vector10.Y + (float)Projectile.height - num100;
                        float num102 = 16.1f;
                        if (num101 <= num102)
                        {
                            Projectile.gfxOffY += Projectile.position.Y + (float)Projectile.height - num100;
                            Projectile.position.Y = num100 - (float)Projectile.height;
                            if (num101 < 9f)
                            {
                                Projectile.stepSpeed = 1f;
                            }
                            else
                            {
                                Projectile.stepSpeed = 2f;
                            }
                        }
                    }
                }
            }
            Collision.StepUp(ref Projectile.position, ref Projectile.velocity, Projectile.width, Projectile.height, ref Projectile.stepSpeed, ref Projectile.gfxOffY);
            if (Projectile.velocity.Y > 16f)
            {
                Projectile.velocity.Y = 16f;
            }
            if (Projectile.velocity.Y <= 6f)
            {
                if (Projectile.velocity.X > 0f && Projectile.velocity.X < 7f)
                {
                    Projectile.velocity.X = Projectile.velocity.X + 0.05f;
                }
                if (Projectile.velocity.X < 0f && Projectile.velocity.X > -7f)
                {
                    Projectile.velocity.X = Projectile.velocity.X - 0.05f;
                }
            }
            Projectile.frameCounter += (int)Math.Abs(Projectile.velocity.X);
            if (Projectile.frameCounter > 10)
            {
                Projectile.frame++;
                Projectile.frameCounter = 0;
            }
            if (Projectile.frame > 3)
            {
                Projectile.frame = 0;
            }
        }
    }
}
