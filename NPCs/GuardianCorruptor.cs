using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs
{
    public class GuardianCorruptor : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Guardian Corruptor");
            Main.npcFrameCount[npc.type] = 3;
        }

        public override void SetDefaults()
        {
            npc.damage = 95;
            npc.scale = 0.9f;
            npc.lifeMax = 700;
            npc.defense = 40;
            npc.noGravity = true;
            npc.width = 70;
            npc.aiStyle = -1;
            npc.npcSlots = 1f;
            npc.value = 6500f;
            npc.timeLeft = 1750;
            npc.height = 100;
            npc.knockBackResist = 0.15f;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.buffImmune[BuffID.Confused] = true;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.55f);
            npc.damage = (int)(npc.damage * 0.5f);
        }

        public override void NPCLoot()
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.RottenChunk, Main.rand.Next(3) + 1, false, 0, false);
        }

        public override void AI()
        {
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead)
            {
                npc.TargetClosest(true);
            }
            var num1169 = 4.2f;
            var num1170 = 0.022f;
            var vector156 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
            var num1171 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2;
            var num1172 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2;
            num1171 = (int)(num1171 / 8f) * 8;
            num1172 = (int)(num1172 / 8f) * 8;
            vector156.X = (int)(vector156.X / 8f) * 8;
            vector156.Y = (int)(vector156.Y / 8f) * 8;
            num1171 -= vector156.X;
            num1172 -= vector156.Y;
            var num1173 = (float)Math.Sqrt(num1171 * num1171 + num1172 * num1172);
            var num1174 = num1173;
            if (num1173 == 0f)
            {
                num1171 = npc.velocity.X;
                num1172 = npc.velocity.Y;
            }
            else
            {
                num1173 = num1169 / num1173;
                num1171 *= num1173;
                num1172 *= num1173;
            }
            npc.ai[0] += 1f;
            if (npc.ai[0] > 0f)
            {
                npc.velocity.Y = npc.velocity.Y + 0.023f;
            }
            else
            {
                npc.velocity.Y = npc.velocity.Y - 0.023f;
            }
            if (npc.ai[0] < -100f || npc.ai[0] > 100f)
            {
                npc.velocity.X = npc.velocity.X + 0.023f;
            }
            else
            {
                npc.velocity.X = npc.velocity.X - 0.023f;
            }
            if (npc.ai[0] > 200f)
            {
                npc.ai[0] = -200f;
            }
            if (num1174 < 150f)
            {
                npc.velocity.X = npc.velocity.X + num1171 * 0.007f;
                npc.velocity.Y = npc.velocity.Y + num1172 * 0.007f;
            }
            if (Main.player[npc.target].dead)
            {
                num1171 = npc.direction * num1169 / 2f;
                num1172 = -num1169 / 2f;
            }
            if (npc.velocity.X < num1171)
            {
                npc.velocity.X = npc.velocity.X + num1170;
                if (npc.velocity.X < 0f && num1171 > 0f)
                {
                    npc.velocity.X = npc.velocity.X + num1170;
                }
            }
            else if (npc.velocity.X > num1171)
            {
                npc.velocity.X = npc.velocity.X - num1170;
                if (npc.velocity.X > 0f && num1171 < 0f)
                {
                    npc.velocity.X = npc.velocity.X - num1170;
                }
            }
            if (npc.velocity.Y < num1172)
            {
                npc.velocity.Y = npc.velocity.Y + num1170;
                if (npc.velocity.Y < 0f && num1172 > 0f)
                {
                    npc.velocity.Y = npc.velocity.Y + num1170;
                }
            }
            else if (npc.velocity.Y > num1172)
            {
                npc.velocity.Y = npc.velocity.Y - num1170;
                if (npc.velocity.Y > 0f && num1172 < 0f)
                {
                    npc.velocity.Y = npc.velocity.Y - num1170;
                }
            }
            npc.rotation = (float)Math.Atan2(num1172, num1171) - 1.57f;
            var num1179 = 0.7f;
            if (npc.collideX)
            {
                npc.netUpdate = true;
                npc.velocity.X = npc.oldVelocity.X * -num1179;
                if (npc.direction == -1 && npc.velocity.X > 0f && npc.velocity.X < 2f)
                {
                    npc.velocity.X = 2f;
                }
                if (npc.direction == 1 && npc.velocity.X < 0f && npc.velocity.X > -2f)
                {
                    npc.velocity.X = -2f;
                }
            }
            if (npc.collideY)
            {
                npc.netUpdate = true;
                npc.velocity.Y = npc.oldVelocity.Y * -num1179;
                if (npc.velocity.Y > 0f && npc.velocity.Y < 1.5)
                {
                    npc.velocity.Y = 2f;
                }
                if (npc.velocity.Y < 0f && npc.velocity.Y > -1.5)
                {
                    npc.velocity.Y = -2f;
                }
            }
            else if (Main.rand.Next(20) == 0)
            {
                var num1182 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + npc.height * 0.25f), npc.width, (int)(npc.height * 0.5f), DustID.Vile, npc.velocity.X, 2f, 75, npc.color, npc.scale);
                var dust52 = Main.dust[num1182];
                dust52.velocity.X = dust52.velocity.X * 0.5f;
                var dust53 = Main.dust[num1182];
                dust53.velocity.Y = dust53.velocity.Y * 0.1f;
            }
            else if (Main.rand.Next(40) == 0)
            {
                var num1183 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + npc.height * 0.25f), npc.width, (int)(npc.height * 0.5f), DustID.Blood, npc.velocity.X, 2f, 0, default(Color), 1f);
                var dust54 = Main.dust[num1183];
                dust54.velocity.X = dust54.velocity.X * 0.5f;
                var dust55 = Main.dust[num1183];
                dust55.velocity.Y = dust55.velocity.Y * 0.1f;
            }
            if (npc.wet)
            {
                if (npc.velocity.Y > 0f)
                {
                    npc.velocity.Y = npc.velocity.Y * 0.95f;
                }
                npc.velocity.Y = npc.velocity.Y - 0.3f;
                if (npc.velocity.Y < -2f)
                {
                    npc.velocity.Y = -2f;
                }
            }
            if (Main.netMode != NetmodeID.MultiplayerClient && !Main.player[npc.target].dead)
            {
                if (npc.justHit)
                {
                    npc.localAI[0] = 0f;
                }
                npc.localAI[0] += 1f;
                if (npc.localAI[0] == 180f)
                {
                    if (Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
                    {
                        var player5 = Main.player[npc.target];
                        var vector158 = new Vector2(npc.position.X + npc.width / 2, npc.position.Y + npc.height / 2);
                        var num1191 = (float)Math.Atan2(vector158.Y - (player5.position.Y + player5.height * 0.5f + 40f), vector158.X - (player5.position.X + player5.width * 0.5f + 40f));
                        var number2 = Projectile.NewProjectile(npc.position.X + npc.width / 2, npc.position.Y + npc.height * 0.5f, -(float)Math.Cos(num1191) * 7f, -(float)Math.Sin(num1191) * 7f, ModContent.ProjectileType<Projectiles.VileSpit>(), 70, 1f, npc.target, 0f, 0f);
                        if (Main.netMode == NetmodeID.Server)
                        {
                            NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.FromLiteral(""), number2, 0f, 0f, 0f, 0);
                        }
                        var num1192 = (float)Math.Atan2(vector158.Y - (player5.position.Y + player5.height * 0.5f - 40f), vector158.X - (player5.position.X + player5.width * 0.5f - 40f));
                        var num1193 = Projectile.NewProjectile(npc.position.X + npc.width / 2, npc.position.Y + npc.height * 0.5f, -(float)Math.Cos(num1192), -(float)Math.Sin(num1192), ModContent.ProjectileType<Projectiles.VileSpit>(), 70, 1f, npc.target, 0f, 0f);
                        var expr_4284B_cp_0 = Main.projectile[num1193];
                        expr_4284B_cp_0.velocity.X = expr_4284B_cp_0.velocity.X * 7f;
                        var expr_4286B_cp_0 = Main.projectile[num1193];
                        expr_4286B_cp_0.velocity.Y = expr_4286B_cp_0.velocity.Y * 7f;
                        if (Main.netMode == NetmodeID.Server)
                        {
                            NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.FromLiteral(""), num1193, 0f, 0f, 0f, 0);
                        }
                        NPC.NewNPC((int)(npc.position.X + npc.width / 2 + npc.velocity.X), (int)(npc.position.Y + npc.height / 2 + npc.velocity.Y), NPCID.VileSpit, 0);
                    }
                    npc.localAI[0] = 0f;
                }
            }
            if (((npc.velocity.X > 0f && npc.oldVelocity.X < 0f) || (npc.velocity.X < 0f && npc.oldVelocity.X > 0f) || (npc.velocity.Y > 0f && npc.oldVelocity.Y < 0f) || (npc.velocity.Y < 0f && npc.oldVelocity.Y > 0f)) && !npc.justHit)
            {
                npc.netUpdate = true;
                return;
            }
            return;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GuardianCorruptor1"), 0.9f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GuardianCorruptor2"), 0.9f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GuardianCorruptor3"), 0.9f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GuardianCorruptor4"), 0.9f);
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.player.ZoneCorrupt && !spawnInfo.player.InPillarZone() && Main.hardMode && ModContent.GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode ? 0.066f * ExxoAvalonOriginsGlobalNPC.endoSpawnRate : 0f;
        }
    }
}
