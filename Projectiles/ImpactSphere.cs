using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class ImpactSphere : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Impact Sphere");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/ImpactSphere");
            Projectile.width = dims.Width;
            Projectile.height = dims.Height * 38 / 220 / Main.projFrames[Projectile.type];
            Projectile.aiStyle = -1;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.hostile = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 600;
            Projectile.light = 0.9f;
            Main.projFrames[Projectile.type] = 5;
        }
        public override bool PreAI()
        {
            Lighting.AddLight(Projectile.position, 2 / 255, 254 / 255, 201 / 255);
            return true;
        }
        public override void AI()
        {
            if (Projectile.type == ModContent.ProjectileType<ImpactSphere>())
            {
                if (Projectile.ai[0] == 0f)
                {
                    Projectile.ai[0] = Projectile.velocity.X;
                    Projectile.ai[1] = Projectile.velocity.Y;
                }
                if (Projectile.velocity.X > 0f)
                {
                    Projectile.rotation += (Math.Abs(Projectile.velocity.Y) + Math.Abs(Projectile.velocity.X)) * 0.001f;
                }
                else
                {
                    Projectile.rotation -= (Math.Abs(Projectile.velocity.Y) + Math.Abs(Projectile.velocity.X)) * 0.001f;
                }
                Projectile.frameCounter++;
                if (Projectile.frameCounter > 6)
                {
                    Projectile.frameCounter = 0;
                    Projectile.frame++;
                    if (Projectile.frame > 4)
                    {
                        Projectile.frame = 0;
                    }
                }
                if (Math.Sqrt(Projectile.velocity.X * Projectile.velocity.X + Projectile.velocity.Y * Projectile.velocity.Y) > 2.0)
                {
                    Projectile.velocity *= 0.98f;
                }
                for (var num598 = 0; num598 < 1000; num598++)
                {
                    if (num598 != Projectile.whoAmI && Main.projectile[num598].active && Main.projectile[num598].owner == Projectile.owner && Main.projectile[num598].type == Projectile.type && Projectile.timeLeft > Main.projectile[num598].timeLeft && Main.projectile[num598].timeLeft > 30)
                    {
                        Main.projectile[num598].timeLeft = 30;
                    }
                }
                var array2 = new int[20];
                var num599 = 0;
                var flag22 = false;
                for (var num600 = 0; num600 < 200; num600++)
                {
                    if (Main.npc[num600].active && !Main.npc[num600].dontTakeDamage && !Main.npc[num600].friendly && Main.npc[num600].lifeMax > 5)
                    {
                        var num601 = Main.npc[num600].position.X + Main.npc[num600].width / 2;
                        var num602 = Main.npc[num600].position.Y + Main.npc[num600].height / 2;
                        Math.Abs(Projectile.position.X + Projectile.width / 2 - num601);
                        Math.Abs(Projectile.position.Y + Projectile.height / 2 - num602);
                        if (Vector2.Distance(Projectile.Center, Main.player[Player.FindClosest(Projectile.position, Projectile.width, Projectile.height)].Center) < 160f)
                        {
                            if (num599 < 20)
                            {
                                array2[num599] = num600;
                                num599++;
                            }
                            flag22 = true;
                        }
                    }
                }
                if (Projectile.timeLeft < 30)
                {
                    flag22 = false;
                }
                if (flag22)
                {
                    var num603 = Main.rand.Next(num599);
                    num603 = array2[num603];
                    var num604 = Main.npc[num603].position.X + Main.npc[num603].width / 2;
                    var num605 = Main.npc[num603].position.Y + Main.npc[num603].height / 2;
                    Projectile.localAI[0]++;
                    if (Projectile.localAI[0] > 14f)
                    {
                        Projectile.localAI[0] = 0f;
                        var num606 = 6f;
                        var value8 = Projectile.Center;
                        var num607 = num604 - value8.X;
                        var num608 = num605 - value8.Y;
                        var num609 = (float)Math.Sqrt(num607 * num607 + num608 * num608);
                        num609 = num606 / num609;
                        num607 *= num609;
                        num608 *= num609;
                        var num610 = Projectile.NewProjectile(value8.X, value8.Y, num607, num608, ModContent.ProjectileType<ImpactBolt>(), Projectile.damage, Projectile.knockBack, Projectile.owner, 0f, 0f);
                        Main.projectile[num610].velocity = Vector2.Normalize(Main.player[Player.FindClosest(Projectile.Center, Projectile.width, Projectile.height)].Center - Projectile.Center) * 3f;
                    }
                }
            }
        }
    }
}
