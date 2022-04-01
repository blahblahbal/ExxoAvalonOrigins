using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles.Melee
{
    public class PumpkinHead : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pumpkin Head");
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(255, 255, 255, 100);
        }
        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/Melee/PumpkinHead");
            Projectile.width = dims.Width;
            Projectile.height = dims.Height * 30 / 36 / Main.projFrames[Projectile.type];
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
        }

        public override void AI()
        {
            if (Projectile.type == ProjectileID.FlamingJack)
            {
                Projectile.frameCounter++;
                if (Projectile.frameCounter > 0)
                {
                    Projectile.frame++;
                    Projectile.frameCounter = 0;
                    if (Projectile.frame > 2)
                    {
                        Projectile.frame = 0;
                    }
                }
            }
            if (Projectile.velocity.X < 0f)
            {
                Projectile.spriteDirection = -1;
                Projectile.rotation = (float)Math.Atan2(-Projectile.velocity.Y, -Projectile.velocity.X);
            }
            else
            {
                Projectile.spriteDirection = 1;
                Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X);
            }
            if (Projectile.ai[0] >= 0f && Projectile.ai[0] < 200f)
            {
                var num710 = (int)Projectile.ai[0];
                if (Main.npc[num710].active)
                {
                    var num711 = 8f;
                    var vector46 = new Vector2(Projectile.position.X + Projectile.width * 0.5f, Projectile.position.Y + Projectile.height * 0.5f);
                    var num712 = Main.npc[num710].position.X - vector46.X;
                    var num713 = Main.npc[num710].position.Y - vector46.Y;
                    var num714 = (float)Math.Sqrt(num712 * num712 + num713 * num713);
                    num714 = num711 / num714;
                    num712 *= num714;
                    num713 *= num714;
                    Projectile.velocity.X = (Projectile.velocity.X * 14f + num712) / 15f;
                    Projectile.velocity.Y = (Projectile.velocity.Y * 14f + num713) / 15f;
                }
                else
                {
                    var num715 = 1000f;
                    for (var num716 = 0; num716 < 200; num716++)
                    {
                        if (Main.npc[num716].active && !Main.npc[num716].dontTakeDamage && !Main.npc[num716].friendly && Main.npc[num716].lifeMax > 5)
                        {
                            var num717 = Main.npc[num716].position.X + Main.npc[num716].width / 2;
                            var num718 = Main.npc[num716].position.Y + Main.npc[num716].height / 2;
                            var num719 = Math.Abs(Projectile.position.X + Projectile.width / 2 - num717) + Math.Abs(Projectile.position.Y + Projectile.height / 2 - num718);
                            if (num719 < num715 && Collision.CanHit(Projectile.position, Projectile.width, Projectile.height, Main.npc[num716].position, Main.npc[num716].width, Main.npc[num716].height))
                            {
                                num715 = num719;
                                Projectile.ai[0] = num716;
                            }
                        }
                    }
                }
                var num720 = 8;
                var num721 = Dust.NewDust(new Vector2(Projectile.position.X + num720, Projectile.position.Y + num720), Projectile.width - num720 * 2, Projectile.height - num720 * 2, DustID.Torch, 0f, 0f, 0, default(Color), 1f);
                Main.dust[num721].velocity *= 0.5f;
                Main.dust[num721].velocity += Projectile.velocity * 0.5f;
                Main.dust[num721].noGravity = true;
                Main.dust[num721].noLight = true;
                Main.dust[num721].scale = 1.4f;
            }
            else
            {
                Projectile.Kill();
            }
        }
    }
}
