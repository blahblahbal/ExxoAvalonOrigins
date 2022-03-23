using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class BlahKnife : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blah's Knife");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/BlahKnife");
            projectile.width = 30;
            projectile.height = 30;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.melee = true;
            projectile.ignoreWater = true;
            projectile.extraUpdates = 0;
        }
        public override void AI()
        {
            //projectile.localAI[1]++;
            var num28 = (float)Math.Sqrt(projectile.velocity.X * projectile.velocity.X + projectile.velocity.Y * projectile.velocity.Y);
            var num29 = projectile.localAI[0];
            if (num29 == 0f)
            {
                projectile.localAI[0] = num28;
                num29 = num28;
            }
            var projPosStoredX = projectile.position.X;
            var projPosStoredY = projectile.position.Y;
            var distance = 320f;
            var flag = false;
            var npcArrayIndexStored = 0;
            if (projectile.ai[1] == 0f)
            {
                for (var npcArrayIndex = 0; npcArrayIndex < 200; npcArrayIndex++)
                {
                    if (Main.npc[npcArrayIndex].active && !Main.npc[npcArrayIndex].dontTakeDamage && !Main.npc[npcArrayIndex].friendly && Main.npc[npcArrayIndex].lifeMax > 5 && (projectile.ai[1] == 0f || projectile.ai[1] == npcArrayIndex + 1))
                    {
                        var npcCenterX = Main.npc[npcArrayIndex].position.X + Main.npc[npcArrayIndex].width / 2;
                        var npcCenterY = Main.npc[npcArrayIndex].position.Y + Main.npc[npcArrayIndex].height / 2;
                        var num37 = Math.Abs(projectile.position.X + projectile.width / 2 - npcCenterX) + Math.Abs(projectile.position.Y + projectile.height / 2 - npcCenterY);
                        if (num37 < distance && Collision.CanHit(new Vector2(projectile.position.X + projectile.width / 2, projectile.position.Y + projectile.height / 2), 1, 1, Main.npc[npcArrayIndex].position, Main.npc[npcArrayIndex].width, Main.npc[npcArrayIndex].height))
                        {
                            distance = num37;
                            projPosStoredX = npcCenterX;
                            projPosStoredY = npcCenterY;
                            flag = true;
                            npcArrayIndexStored = npcArrayIndex;
                        }
                    }
                }
                if (flag)
                {
                    projectile.ai[1] = npcArrayIndexStored + 1;
                }
                flag = false;
            }
            if (projectile.ai[1] != 0f)
            {
                var npcArrayIndexAgain = (int)(projectile.ai[1] - 1f);
                if (Main.npc[npcArrayIndexAgain].active)
                {
                    var npcCenterX = Main.npc[npcArrayIndexAgain].position.X + Main.npc[npcArrayIndexAgain].width / 2;
                    var npcCenterY = Main.npc[npcArrayIndexAgain].position.Y + Main.npc[npcArrayIndexAgain].height / 2;
                    var num41 = Math.Abs(projectile.position.X + projectile.width / 2 - npcCenterX) + Math.Abs(projectile.position.Y + projectile.height / 2 - npcCenterY);
                    if (num41 < 1000f)
                    {
                        flag = true;
                        projPosStoredX = Main.npc[npcArrayIndexAgain].position.X + Main.npc[npcArrayIndexAgain].width / 2;
                        projPosStoredY = Main.npc[npcArrayIndexAgain].position.Y + Main.npc[npcArrayIndexAgain].height / 2;
                    }
                }
            }
            if (flag)
            {
                var num42 = num29;
                var projCenter = new Vector2(projectile.position.X + projectile.width * 0.5f, projectile.position.Y + projectile.height * 0.5f);
                var num43 = projPosStoredX - projCenter.X;
                var num44 = projPosStoredY - projCenter.Y;
                var num45 = (float)Math.Sqrt(num43 * num43 + num44 * num44);
                num45 = num42 / num45;
                num43 *= num45;
                num44 *= num45;
                var num46 = 8;
                projectile.velocity.X = (projectile.velocity.X * (num46 - 1) + num43) / num46;
                projectile.velocity.Y = (projectile.velocity.Y * (num46 - 1) + num44) / num46;
            }
            projectile.rotation += (Math.Abs(projectile.velocity.X) + Math.Abs(projectile.velocity.Y)) * 0.03f * projectile.direction;
            if (projectile.velocity.Y > 16f)
            {
                projectile.velocity.Y = 16f;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            ghostHurt(projectile.damage, projectile.position);
            Main.player[projectile.owner].VampireHeal((int)(projectile.damage * 0.4f), projectile.position);
        }

        public override void OnHitPvp(Player target, int damage, bool crit)
        {
            ghostHurt(projectile.damage, projectile.position);
        }
        public void ghostHurt(int dmg, Vector2 Position)
        {
            if (!projectile.magic || projectile.damage <= 0)
            {
                return;
            }
            int num = projectile.damage;
            if (dmg <= 1)
            {
                return;
            }
            int[] array = new int[200];
            int num4 = 0;
            _ = new int[200];
            int num5 = 0;
            for (int i = 0; i < 200; i++)
            {
                if (!Main.npc[i].CanBeChasedBy(this))
                {
                    continue;
                }
                float num6 = Math.Abs(Main.npc[i].position.X + Main.npc[i].width / 2 - projectile.position.X + projectile.width / 2) + Math.Abs(Main.npc[i].position.Y + Main.npc[i].height / 2 - projectile.position.Y + projectile.height / 2);
                if (num6 < 800f)
                {
                    if (Collision.CanHit(projectile.position, 1, 1, Main.npc[i].position, Main.npc[i].width, Main.npc[i].height) && num6 > 50f)
                    {
                        array[num5] = i;
                        num5++;
                    }
                    else if (num5 == 0)
                    {
                        array[num4] = i;
                        num4++;
                    }
                }
            }
            if (num4 != 0 || num5 != 0)
            {
                int num2 = ((num5 <= 0) ? array[Main.rand.Next(num4)] : array[Main.rand.Next(num5)]);
                float num7 = Main.rand.Next(-100, 101);
                float num8 = Main.rand.Next(-100, 101);
                float num9 = (float)Math.Sqrt(num7 * num7 + num8 * num8);
                num9 = 4f / num9;
                num7 *= num9;
                num8 *= num9;
                Projectile.NewProjectile(Position, new Vector2(num7, num8), ModContent.ProjectileType<BlahKnifeSplit>(), num, 0f, projectile.owner, num2);
            }
        }
    }
}
