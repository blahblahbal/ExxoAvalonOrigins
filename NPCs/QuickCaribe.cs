using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace ExxoAvalonOrigins.NPCs
{
    public class QuickCaribe : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Quick Caribe");
            Main.npcFrameCount[npc.type] = 6;
        }

        public override void SetDefaults()
        {
            npc.damage = 80;
            npc.lifeMax = 150;
            npc.defense = 22;
            npc.noGravity = true;
            npc.width = 32;
            npc.aiStyle = -1;
            npc.value = Item.buyPrice(0, 0, 50, 0);
            npc.timeLeft = 750;
            npc.height = 24;
            npc.knockBackResist = 0.8f;
            npc.buffImmune[BuffID.Confused] = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.55f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.8f);
        }

        public override void AI()
        {
            if (npc.direction == 0)
            {
                npc.TargetClosest(true);
            }
            if (!npc.wet)
            {
                var flag78 = false;
                npc.TargetClosest(false);
                if (Main.player[npc.target].wet && !Main.player[npc.target].dead)
                {
                    flag78 = true;
                }
                var vector162 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                var num1210 = Main.player[npc.target].position.X + Main.player[npc.target].width * 0.5f - vector162.X;
                var num1211 = Main.player[npc.target].position.Y + Main.player[npc.target].height * 0.5f - vector162.Y;
                num1210 += Main.rand.Next(-20, 21);
                num1211 += Main.rand.Next(-20, 21);
                var num1212 = (float)Math.Sqrt(num1210 * num1210 + num1211 * num1211);
                if (num1212 <= 200f && npc.ai[1] <= 0f && npc.velocity.Y < 0.6f && !flag78)
                {
                    npc.TargetClosest(true);
                    var num1213 = (int)vector162.X / 16;
                    var num1214 = (int)vector162.Y / 16;
                    var num1215 = 10;
                    if (Main.tile[num1213, num1214 + 1] == null)
                    {
                        Main.tile[num1213, num1214 + 1] = new Tile();
                    }
                    if (Main.tile[num1213, num1214 + 1].liquid < 128)
                    {
                        num1215 = 5;
                    }
                    if (num1210 > 16f)
                    {
                        npc.velocity.X = 3f;
                    }
                    else if (num1210 < -16f)
                    {
                        npc.velocity.X = -3f;
                    }
                    npc.velocity.Y = -num1215;
                    npc.ai[1] = 70f;
                    if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        npc.netUpdate = true;
                        NetMessage.SendData(MessageID.SyncNPC, -1, -1, NetworkText.FromLiteral(""), npc.whoAmI, 0f, 0f, 0f, 0);
                    }
                }
                else if (npc.ai[1] > 0f)
                {
                    npc.ai[1] = npc.ai[1] - 1f;
                }
                if (npc.velocity.Y == 0f && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    npc.velocity.Y = Main.rand.Next(-50, -20) * 0.1f;
                    npc.velocity.X = Main.rand.Next(-20, 20) * 0.1f;
                    npc.netUpdate = true;
                    NetMessage.SendData(MessageID.SyncNPC, -1, -1, NetworkText.FromLiteral(""), npc.whoAmI, 0f, 0f, 0f, 0);
                }
                npc.velocity.Y = npc.velocity.Y + 0.3f;
                if (npc.velocity.Y > 10f)
                {
                    npc.velocity.Y = 10f;
                }
                npc.ai[0] = 1f;
                return;
            }
            var flag79 = false;
            npc.TargetClosest(false);
            if (Main.player[npc.target].wet && !Main.player[npc.target].dead)
            {
                flag79 = true;
            }
            var vector163 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
            var num1216 = Main.player[npc.target].position.X + Main.player[npc.target].width * 0.5f - vector163.X;
            var num1217 = Main.player[npc.target].position.Y + Main.player[npc.target].height * 0.5f - vector163.Y;
            num1216 += Main.rand.Next(-20, 21);
            num1217 += Main.rand.Next(-20, 21);
            var num1218 = (float)Math.Sqrt(num1216 * num1216 + num1217 * num1217);
            if (!flag79)
            {
                if (npc.collideX)
                {
                    npc.velocity.X = npc.velocity.X * -1f;
                    npc.direction *= -1;
                    npc.netUpdate = true;
                }
                if (npc.collideY)
                {
                    npc.netUpdate = true;
                    if (npc.velocity.Y > 0f)
                    {
                        npc.velocity.Y = Math.Abs(npc.velocity.Y) * -1f;
                        npc.directionY = -1;
                        npc.ai[0] = -1f;
                    }
                    else if (npc.velocity.Y < 0f)
                    {
                        npc.velocity.Y = Math.Abs(npc.velocity.Y);
                        npc.directionY = 1;
                        npc.ai[0] = 1f;
                    }
                }
            }
            if (flag79)
            {
                npc.TargetClosest(true);
                npc.velocity.X = npc.velocity.X + npc.direction * 0.15f;
                npc.velocity.Y = npc.velocity.Y + npc.directionY * 0.15f;
                if (npc.velocity.X > 6f)
                {
                    npc.velocity.X = 6f;
                }
                if (npc.velocity.X < -6f)
                {
                    npc.velocity.X = -6f;
                }
                if (npc.velocity.Y > 4f)
                {
                    npc.velocity.Y = 4f;
                }
                if (npc.velocity.Y < -4f)
                {
                    npc.velocity.Y = -4f;
                    return;
                }
                return;
            }
            else
            {
                npc.velocity.X = npc.velocity.X + npc.direction * 0.1f;
                if (npc.velocity.X < -2.5f || npc.velocity.X > 2.5f)
                {
                    npc.velocity.X = npc.velocity.X * 0.95f;
                }
                if (num1218 <= 300.0)
                {
                    npc.TargetClosest(true);
                    npc.velocity.Y = npc.velocity.Y - 0.15f;
                }
                else if (npc.ai[0] == -1f)
                {
                    npc.velocity.Y = npc.velocity.Y - 0.015f;
                    if (npc.velocity.Y < -0.50000002235174179)
                    {
                        npc.ai[0] = 1f;
                    }
                }
                else
                {
                    npc.velocity.Y = npc.velocity.Y + 0.015f;
                    if (npc.velocity.Y > 0.50000002235174179)
                    {
                        npc.ai[0] = -1f;
                    }
                }
                var num1219 = (int)(npc.position.X + npc.width / 2) / 16;
                var num1220 = (int)(npc.position.Y + npc.height / 2) / 16;
                if (Main.tile[num1219, num1220 - 1] == null)
                {
                    Main.tile[num1219, num1220 - 1] = new Tile();
                }
                if (Main.tile[num1219, num1220 + 1] == null)
                {
                    Main.tile[num1219, num1220 + 1] = new Tile();
                }
                if (Main.tile[num1219, num1220 + 2] == null)
                {
                    Main.tile[num1219, num1220 + 2] = new Tile();
                }
                if (Main.tile[num1219, num1220 - 1].liquid > 128)
                {
                    if (Main.tile[num1219, num1220 + 1].active())
                    {
                        npc.ai[0] = -1f;
                    }
                    else if (Main.tile[num1219, num1220 + 2].active())
                    {
                        npc.ai[0] = -1f;
                    }
                }
                if (npc.velocity.Y > 0.60000002384185791 || npc.velocity.Y < -0.60000002384185791)
                {
                    npc.velocity.Y = npc.velocity.Y * 0.95f;
                    return;
                }
                return;
            }
        }

        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;
            npc.frameCounter += 1.0;
            if (npc.wet)
            {
                if (npc.frameCounter < 6.0)
                {
                    npc.frame.Y = 0;
                }
                else if (npc.frameCounter < 12.0)
                {
                    npc.frame.Y = frameHeight;
                }
                else if (npc.frameCounter < 18.0)
                {
                    npc.frame.Y = frameHeight * 2;
                }
                else if (npc.frameCounter < 24.0)
                {
                    npc.frame.Y = frameHeight * 3;
                }
                else
                {
                    npc.frameCounter = 0.0;
                }
            }
            else if (npc.frameCounter < 6.0)
            {
                npc.frame.Y = frameHeight * 4;
            }
            else if (npc.frameCounter < 12.0)
            {
                npc.frame.Y = frameHeight * 5;
            }
            else
            {
                npc.frameCounter = 0.0;
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.player.ZoneJungle && Main.hardMode && ModContent.GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode ? 0.041f * ExxoAvalonOriginsGlobalNPC.endoSpawnRate : 0f;
        }
    }
}