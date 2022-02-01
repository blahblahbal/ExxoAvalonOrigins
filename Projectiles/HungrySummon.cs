using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class HungrySummon : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hungry");
            Main.projFrames[projectile.type] = 3;
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/HungrySummon");
            projectile.netImportant = true;
            projectile.width = 22;
            projectile.height = 36;
            //projectile.aiStyle = -1;
            projectile.penetrate = -1;
            projectile.timeLeft *= 5;
            projectile.minion = true;
            projectile.minionSlots = 1f;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.friendly = true;
            //Main.projPet[projectile.type] = true;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return false;
        }
        public override void AI()
        {
            Main.player[projectile.owner].AddBuff(ModContent.BuffType<Buffs.Hungry>(), 3600);
            if (projectile.type == ModContent.ProjectileType<HungrySummon>())
            {
                if (Main.player[projectile.owner].dead)
                {
                    Main.player[projectile.owner].Avalon().hungryMinion = false;
                }
                if (Main.player[projectile.owner].Avalon().hungryMinion)
                {
                    projectile.timeLeft = 2;
                }
            }
            var num820 = 0.05f;
            for (var num821 = 0; num821 < 1000; num821++)
            {
                if (num821 != projectile.whoAmI && Main.projectile[num821].active && Main.projectile[num821].owner == projectile.owner && (Main.projectile[num821].type == 387 || Main.projectile[num821].type == 388 || Main.projectile[num821].type == 485 || Main.projectile[num821].type == 498) && Math.Abs(projectile.position.X - Main.projectile[num821].position.X) + Math.Abs(projectile.position.Y - Main.projectile[num821].position.Y) < projectile.width)
                {
                    if (projectile.position.X < Main.projectile[num821].position.X)
                    {
                        projectile.velocity.X = projectile.velocity.X - num820;
                    }
                    else
                    {
                        projectile.velocity.X = projectile.velocity.X + num820;
                    }
                    if (projectile.position.Y < Main.projectile[num821].position.Y)
                    {
                        projectile.velocity.Y = projectile.velocity.Y - num820;
                    }
                    else
                    {
                        projectile.velocity.Y = projectile.velocity.Y + num820;
                    }
                }
            }
            if (projectile.ai[0] == 2f && (projectile.type == ModContent.ProjectileType<HungrySummon>()))
            {
                projectile.ai[1] += 1f;
                projectile.MaxUpdates = 1;
                projectile.rotation = projectile.velocity.ToRotation() + 3.14159274f;
                projectile.frameCounter++;
                if (projectile.frameCounter > 1)
                {
                    projectile.frame++;
                    projectile.frameCounter = 0;
                }
                if (projectile.frame > 2)
                {
                    projectile.frame = 0;
                }
                if (projectile.ai[1] <= 40f)
                {
                    return;
                }
                projectile.ai[1] = 1f;
                projectile.ai[0] = 0f;
                projectile.MaxUpdates = 0;
                projectile.numUpdates = 0;
                projectile.netUpdate = true;
            }
            var vector57 = projectile.position;
            var num822 = 400f;
            var flag32 = false;
            //if (projectile.ai[0] != 1f)
            //{
            //	projectile.tileCollide = true;
            //}
            for (var num823 = 0; num823 < 200; num823++)
            {
                var nPC5 = Main.npc[num823];
                if (nPC5.active && !nPC5.dontTakeDamage && !nPC5.friendly && nPC5.lifeMax > 5)
                {
                    var num824 = Vector2.Distance(nPC5.Center, projectile.Center);
                    if (((Vector2.Distance(projectile.Center, vector57) > num824 && num824 < num822) || !flag32) && Collision.CanHitLine(projectile.position, projectile.width, projectile.height, nPC5.position, nPC5.width, nPC5.height))
                    {
                        num822 = num824;
                        vector57 = nPC5.Center;
                        flag32 = true;
                    }
                }
            }
            var num825 = 500;
            if (flag32)
            {
                num825 = 1000;
            }
            var player2 = Main.player[projectile.owner];
            if (Vector2.Distance(player2.Center, projectile.Center) > num825)
            {
                projectile.ai[0] = 1f;
                projectile.tileCollide = false;
                projectile.netUpdate = true;
            }
            if (flag32 && projectile.ai[0] == 0f)
            {
                var vector58 = vector57 - projectile.Center;
                var num826 = vector58.Length();
                vector58.Normalize();
                if (num826 > 200f)
                {
                    var scaleFactor5 = 6f;
                    if (projectile.type == ProjectileID.Spazmamini || projectile.type == ModContent.ProjectileType<HungrySummon>())
                    {
                        scaleFactor5 = 8f;
                    }
                    vector58 *= scaleFactor5;
                    projectile.velocity = (projectile.velocity * 40f + vector58) / 41f;
                }
                else
                {
                    var num827 = 4f;
                    vector58 *= -num827;
                    projectile.velocity = (projectile.velocity * 40f + vector58) / 41f;
                }
            }
            else
            {
                var num828 = 6f;
                if (projectile.ai[0] == 1f)
                {
                    num828 = 15f;
                }
                var value22 = projectile.Center;
                var vector59 = player2.Center - value22 + new Vector2(0f, -60f);
                var num829 = vector59.Length();
                if (num829 > 200f && num828 < 8f)
                {
                    num828 = 8f;
                }
                if (num829 < 150f && projectile.ai[0] == 1f && !Collision.SolidCollision(projectile.position, projectile.width, projectile.height))
                {
                    projectile.ai[0] = 0f;
                    projectile.netUpdate = true;
                }
                if (num829 > 2000f)
                {
                    projectile.position.X = Main.player[projectile.owner].Center.X - projectile.width / 2;
                    projectile.position.Y = Main.player[projectile.owner].Center.Y - projectile.height / 2;
                    projectile.netUpdate = true;
                }
                if (num829 > 70f)
                {
                    vector59.Normalize();
                    vector59 *= num828;
                    projectile.velocity = (projectile.velocity * 40f + vector59) / 41f;
                }
                else if (projectile.velocity.X == 0f && projectile.velocity.Y == 0f)
                {
                    projectile.velocity.X = -0.15f;
                    projectile.velocity.Y = -0.05f;
                }
            }
            if (projectile.type == ProjectileID.Spazmamini || projectile.type == ModContent.ProjectileType<HungrySummon>())
            {
                projectile.rotation = projectile.velocity.ToRotation() + 3.14159274f;
            }
            if (projectile.type == ProjectileID.Retanimini)
            {
                if (flag32)
                {
                    projectile.rotation = (vector57 - projectile.Center).ToRotation() + 3.14159274f;
                }
                else
                {
                    projectile.rotation = projectile.velocity.ToRotation() + 3.14159274f;
                }
            }
            projectile.frameCounter++;
            if (projectile.frameCounter > 3)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame > 2)
            {
                projectile.frame = 0;
            }
            if (projectile.ai[1] > 0f)
            {
                projectile.ai[1] += Main.rand.Next(1, 4);
            }
            if ((projectile.ai[1] > 40f && projectile.type == ProjectileID.Spazmamini) || (projectile.ai[1] > 50f && projectile.type == ModContent.ProjectileType<HungrySummon>()))
            {
                projectile.ai[1] = 0f;
                projectile.netUpdate = true;
            }
            if (projectile.ai[0] == 0f)
            {
                if (projectile.type == ModContent.ProjectileType<HungrySummon>() && projectile.ai[1] == 0f && flag32 && num822 < 500f)
                {
                    projectile.ai[1] += 1f;
                    if (Main.myPlayer == projectile.owner)
                    {
                        projectile.ai[0] = 2f;
                        var value25 = vector57 - projectile.Center;
                        value25.Normalize();
                        if (projectile.type == ModContent.ProjectileType<HungrySummon>())
                        {
                            projectile.velocity = value25 * 5f;
                        }
                        projectile.netUpdate = true;
                    }
                }
            }
        }
    }
}
