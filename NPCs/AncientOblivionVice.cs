using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs;

public class AncientOblivionVice : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Ancient Oblivion Vice");
        Main.npcFrameCount[NPC.type] = 1;
    }

    public override void SetDefaults()
    {
        NPC.damage = 80;
        NPC.noTileCollide = true;
        NPC.lifeMax = 20000;
        NPC.defense = 40;
        NPC.noGravity = true;
        NPC.width = 52;
        NPC.aiStyle = -1;
        NPC.npcSlots = 1f;
        NPC.value = 0f;
        NPC.timeLeft = 750;
        NPC.height = 52;
        NPC.knockBackResist = 0f;
        NPC.HitSound = SoundID.NPCHit4;
        NPC.DeathSound = SoundID.NPCDeath14;
        NPC.buffImmune[BuffID.Frostburn] = true;
        NPC.buffImmune[BuffID.Poisoned] = true;
        NPC.buffImmune[BuffID.OnFire] = true;
        NPC.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().noOneHitKill = true;
    }

    public override void NPCLoot()
    {
        Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ItemID.Heart, Main.rand.Next(3, 6), false, 0, false);
        if (Main.expertMode) Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ItemID.Heart, Main.rand.Next(5, 8), false, 0, false);
    }
    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.35f * bossLifeScale);
        NPC.damage = (int)(NPC.damage * 0.3f);
    }
    public override void AI()
    {
        NPC.spriteDirection = -(int)NPC.ai[0];
        var vector63 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
        var num595 = Main.npc[(int)NPC.ai[1]].position.X + Main.npc[(int)NPC.ai[1]].width / 2 - 200f * NPC.ai[0] - vector63.X;
        var num596 = Main.npc[(int)NPC.ai[1]].position.Y + 230f - vector63.Y;
        var num597 = (float)Math.Sqrt(num595 * num595 + num596 * num596);
        if (NPC.ai[2] != 99f)
        {
            if (num597 > 800f)
            {
                NPC.ai[2] = 99f;
            }
        }
        else if (num597 < 400f)
        {
            NPC.ai[2] = 0f;
        }
        if (!Main.npc[(int)NPC.ai[1]].active || !(Main.npc[(int)NPC.ai[1]].type == ModContent.NPCType<AncientOblivionHead1>() || Main.npc[(int)NPC.ai[1]].type == ModContent.NPCType<AncientOblivionHead2>()))
        {
            NPC.ai[2] += 10f;
            if (NPC.ai[2] > 50f || Main.netMode != NetmodeID.Server)
            {
                NPC.life = -1;
                NPC.HitEffect(0, 10.0);
                NPC.active = false;
            }
        }
        if (NPC.ai[2] == 99f)
        {
            if (NPC.position.Y > Main.npc[(int)NPC.ai[1]].position.Y)
            {
                if (NPC.velocity.Y > 0f)
                {
                    NPC.velocity.Y = NPC.velocity.Y * 0.96f;
                }
                NPC.velocity.Y = NPC.velocity.Y - 0.1f;
                if (NPC.velocity.Y > 8f)
                {
                    NPC.velocity.Y = 8f;
                }
            }
            else if (NPC.position.Y < Main.npc[(int)NPC.ai[1]].position.Y)
            {
                if (NPC.velocity.Y < 0f)
                {
                    NPC.velocity.Y = NPC.velocity.Y * 0.96f;
                }
                NPC.velocity.Y = NPC.velocity.Y + 0.1f;
                if (NPC.velocity.Y < -8f)
                {
                    NPC.velocity.Y = -8f;
                }
            }
            if (NPC.position.X + NPC.width / 2 > Main.npc[(int)NPC.ai[1]].position.X + Main.npc[(int)NPC.ai[1]].width / 2)
            {
                if (NPC.velocity.X > 0f)
                {
                    NPC.velocity.X = NPC.velocity.X * 0.96f;
                }
                NPC.velocity.X = NPC.velocity.X - 0.5f;
                if (NPC.velocity.X > 12f)
                {
                    NPC.velocity.X = 12f;
                }
            }
            if (NPC.position.X + NPC.width / 2 >= Main.npc[(int)NPC.ai[1]].position.X + Main.npc[(int)NPC.ai[1]].width / 2)
            {
                return;
            }
            if (NPC.velocity.X < 0f)
            {
                NPC.velocity.X = NPC.velocity.X * 0.96f;
            }
            NPC.velocity.X = NPC.velocity.X + 0.5f;
            if (NPC.velocity.X < -12f)
            {
                NPC.velocity.X = -12f;
                return;
            }
            return;
        }
        else
        {
            if (NPC.ai[2] == 0f || NPC.ai[2] == 3f)
            {
                if (Main.npc[(int)NPC.ai[1]].ai[1] == 3f && NPC.timeLeft > 10)
                {
                    NPC.timeLeft = 10;
                }
                if (Main.npc[(int)NPC.ai[1]].ai[1] != 0f)
                {
                    NPC.TargetClosest(true);
                    NPC.TargetClosest(true);
                    if (Main.player[NPC.target].dead)
                    {
                        NPC.velocity.Y = NPC.velocity.Y + 0.1f;
                        if (NPC.velocity.Y > 16f)
                        {
                            NPC.velocity.Y = 16f;
                        }
                    }
                    else
                    {
                        var vector64 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
                        var num598 = Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 - vector64.X;
                        var num599 = Main.player[NPC.target].position.Y + Main.player[NPC.target].height / 2 - vector64.Y;
                        var num600 = (float)Math.Sqrt(num598 * num598 + num599 * num599);
                        num600 = 12f / num600;
                        num598 *= num600;
                        num599 *= num600;
                        NPC.rotation = (float)Math.Atan2(num599, num598) - 1.57f;
                        if (Math.Abs(NPC.velocity.X) + Math.Abs(NPC.velocity.Y) < 2f)
                        {
                            NPC.rotation = (float)Math.Atan2(num599, num598) - 1.57f;
                            NPC.velocity.X = num598;
                            NPC.velocity.Y = num599;
                            NPC.netUpdate = true;
                        }
                        else
                        {
                            NPC.velocity *= 0.97f;
                        }
                        NPC.ai[3] += 1f;
                        if (NPC.ai[3] >= 600f)
                        {
                            NPC.ai[2] = 0f;
                            NPC.ai[3] = 0f;
                            NPC.netUpdate = true;
                        }
                    }
                }
                else
                {
                    NPC.ai[3] += 1f;
                    if (NPC.ai[3] >= 600f)
                    {
                        NPC.ai[2] += 1f;
                        NPC.ai[3] = 0f;
                        NPC.netUpdate = true;
                    }
                    if (NPC.position.Y > Main.npc[(int)NPC.ai[1]].position.Y + 300f)
                    {
                        if (NPC.velocity.Y > 0f)
                        {
                            NPC.velocity.Y = NPC.velocity.Y * 0.96f;
                        }
                        NPC.velocity.Y = NPC.velocity.Y - 0.1f;
                        if (NPC.velocity.Y > 3f)
                        {
                            NPC.velocity.Y = 3f;
                        }
                    }
                    else if (NPC.position.Y < Main.npc[(int)NPC.ai[1]].position.Y + 230f)
                    {
                        if (NPC.velocity.Y < 0f)
                        {
                            NPC.velocity.Y = NPC.velocity.Y * 0.96f;
                        }
                        NPC.velocity.Y = NPC.velocity.Y + 0.1f;
                        if (NPC.velocity.Y < -3f)
                        {
                            NPC.velocity.Y = -3f;
                        }
                    }
                    if (NPC.position.X + NPC.width / 2 > Main.npc[(int)NPC.ai[1]].position.X + Main.npc[(int)NPC.ai[1]].width / 2 + 250f)
                    {
                        if (NPC.velocity.X > 0f)
                        {
                            NPC.velocity.X = NPC.velocity.X * 0.94f;
                        }
                        NPC.velocity.X = NPC.velocity.X - 0.3f;
                        if (NPC.velocity.X > 9f)
                        {
                            NPC.velocity.X = 9f;
                        }
                    }
                    if (NPC.position.X + NPC.width / 2 < Main.npc[(int)NPC.ai[1]].position.X + Main.npc[(int)NPC.ai[1]].width / 2)
                    {
                        if (NPC.velocity.X < 0f)
                        {
                            NPC.velocity.X = NPC.velocity.X * 0.94f;
                        }
                        NPC.velocity.X = NPC.velocity.X + 0.2f;
                        if (NPC.velocity.X < -8f)
                        {
                            NPC.velocity.X = -8f;
                        }
                    }
                }
                var vector65 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
                var num601 = Main.npc[(int)NPC.ai[1]].position.X + Main.npc[(int)NPC.ai[1]].width / 2 - 200f * NPC.ai[0] - vector65.X;
                var num602 = Main.npc[(int)NPC.ai[1]].position.Y + 230f - vector65.Y;
                Math.Sqrt(num601 * num601 + num602 * num602);
                NPC.rotation = (float)Math.Atan2(num602, num601) + 1.57f;
                return;
            }
            if (NPC.ai[2] == 1f)
            {
                if (NPC.velocity.Y > 0f)
                {
                    NPC.velocity.Y = NPC.velocity.Y * 0.9f;
                }
                var vector66 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
                var num603 = Main.npc[(int)NPC.ai[1]].position.X + Main.npc[(int)NPC.ai[1]].width / 2 - 280f * NPC.ai[0] - vector66.X;
                var num604 = Main.npc[(int)NPC.ai[1]].position.Y + 230f - vector66.Y;
                var num605 = (float)Math.Sqrt(num603 * num603 + num604 * num604);
                NPC.rotation = (float)Math.Atan2(num604, num603) + 1.57f;
                NPC.velocity.X = (NPC.velocity.X * 5f + Main.npc[(int)NPC.ai[1]].velocity.X) / 6f;
                NPC.velocity.X = NPC.velocity.X + 0.5f;
                NPC.velocity.Y = NPC.velocity.Y - 0.5f;
                if (NPC.velocity.Y < -9f)
                {
                    NPC.velocity.Y = -9f;
                }
                if (NPC.position.Y < Main.npc[(int)NPC.ai[1]].position.Y - 280f)
                {
                    NPC.TargetClosest(true);
                    NPC.ai[2] = 2f;
                    vector66 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
                    num603 = Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 - vector66.X;
                    num604 = Main.player[NPC.target].position.Y + Main.player[NPC.target].height / 2 - vector66.Y;
                    num605 = (float)Math.Sqrt(num603 * num603 + num604 * num604);
                    num605 = 20f / num605;
                    NPC.velocity.X = num603 * num605;
                    NPC.velocity.Y = num604 * num605;
                    NPC.netUpdate = true;
                    return;
                }
                return;
            }
            else if (NPC.ai[2] == 2f)
            {
                if (NPC.position.Y <= Main.player[NPC.target].position.Y && NPC.velocity.Y >= 0f)
                {
                    return;
                }
                if (NPC.ai[3] >= 4f)
                {
                    NPC.ai[2] = 3f;
                    NPC.ai[3] = 0f;
                    return;
                }
                NPC.ai[2] = 1f;
                NPC.ai[3] += 1f;
                return;
            }
            else if (NPC.ai[2] == 4f)
            {
                var vector67 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
                var num606 = Main.npc[(int)NPC.ai[1]].position.X + Main.npc[(int)NPC.ai[1]].width / 2 - 200f * NPC.ai[0] - vector67.X;
                var num607 = Main.npc[(int)NPC.ai[1]].position.Y + 230f - vector67.Y;
                var num608 = (float)Math.Sqrt(num606 * num606 + num607 * num607);
                NPC.rotation = (float)Math.Atan2(num607, num606) + 1.57f;
                NPC.velocity.Y = (NPC.velocity.Y * 5f + Main.npc[(int)NPC.ai[1]].velocity.Y) / 6f;
                NPC.velocity.X = NPC.velocity.X + 0.5f;
                if (NPC.velocity.X > 12f)
                {
                    NPC.velocity.X = 12f;
                }
                if (NPC.position.X + NPC.width / 2 < Main.npc[(int)NPC.ai[1]].position.X + Main.npc[(int)NPC.ai[1]].width / 2 - 500f || NPC.position.X + NPC.width / 2 > Main.npc[(int)NPC.ai[1]].position.X + Main.npc[(int)NPC.ai[1]].width / 2 + 500f)
                {
                    NPC.TargetClosest(true);
                    NPC.ai[2] = 5f;
                    vector67 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
                    num606 = Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 - vector67.X;
                    num607 = Main.player[NPC.target].position.Y + Main.player[NPC.target].height / 2 - vector67.Y;
                    num608 = (float)Math.Sqrt(num606 * num606 + num607 * num607);
                    num608 = 17f / num608;
                    NPC.velocity.X = num606 * num608;
                    NPC.velocity.Y = num607 * num608;
                    NPC.netUpdate = true;
                    return;
                }
                return;
            }
            else
            {
                if (NPC.ai[2] != 5f || NPC.position.X + NPC.width / 2 >= Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 - 100f)
                {
                    return;
                }
                if (NPC.ai[3] >= 4f)
                {
                    NPC.ai[2] = 0f;
                    NPC.ai[3] = 0f;
                    return;
                }
                NPC.ai[2] = 4f;
                NPC.ai[3] += 1f;
                return;
            }
        }
    }

    public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
    {
        var vector10 = new Vector2(NPC.position.X + NPC.width * 0.5f - 5f * NPC.ai[0], NPC.position.Y + 20f);
        for (var m = 0; m < 2; m++)
        {
            var num36 = Main.npc[(int)NPC.ai[1]].position.X + Main.npc[(int)NPC.ai[1]].width / 2 - vector10.X;
            var num37 = Main.npc[(int)NPC.ai[1]].position.Y + Main.npc[(int)NPC.ai[1]].height / 2 - vector10.Y;
            float num38;
            if (m == 0)
            {
                num36 -= 200f * NPC.ai[0];
                num37 += 130f;
                num38 = (float)Math.Sqrt(num36 * num36 + num37 * num37);
                num38 = 92f / num38;
                vector10.X += num36 * num38;
                vector10.Y += num37 * num38;
            }
            else
            {
                num36 -= 50f * NPC.ai[0];
                num37 += 80f;
                num38 = (float)Math.Sqrt(num36 * num36 + num37 * num37);
                num38 = 60f / num38;
                vector10.X += num36 * num38;
                vector10.Y += num37 * num38;
            }
            var rotation10 = (float)Math.Atan2(num37, num36) - 1.57f;
            var color10 = Lighting.GetColor((int)vector10.X / 16, (int)(vector10.Y / 16f));
            Main.spriteBatch.Draw(Main.boneArm2Texture, new Vector2(vector10.X - Main.screenPosition.X, vector10.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, Main.boneArmTexture.Width, Main.boneArmTexture.Height)), color10, rotation10, new Vector2(Main.boneArmTexture.Width * 0.5f, Main.boneArmTexture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
            if (m == 0)
            {
                vector10.X += num36 * num38 / 2f;
                vector10.Y += num37 * num38 / 2f;
            }
            else
            {
                vector10.X += num36 * num38 - 16f;
                vector10.Y += num37 * num38 - 6f;
                var num39 = Dust.NewDust(new Vector2(vector10.X, vector10.Y), 30, 10, DustID.Torch, num36 * 0.02f, num37 * 0.02f, 0, default(Color), 2.5f);
                Main.dust[num39].noGravity = true;
            }
        }
        return true;
    }
}