using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs;

public class AncientOblivionSaw : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Ancient Oblivion Saw");
        Main.npcFrameCount[NPC.type] = 1;
    }

    public override void SetDefaults()
    {
        NPC.damage = 75;
        NPC.noTileCollide = true;
        NPC.lifeMax = 45000;
        NPC.defense = 70;
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
    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.35f * bossLifeScale);
        NPC.damage = (int)(NPC.damage * 0.3f);
    }
    public override void NPCLoot()
    {
        Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ItemID.Heart, Main.rand.Next(3, 6), false, 0, false);
        if (Main.expertMode) Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ItemID.Heart, Main.rand.Next(5, 8), false, 0, false);
    }

    public override void AI()
    {
        var vector58 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
        var num581 = Main.npc[(int)NPC.ai[1]].position.X + Main.npc[(int)NPC.ai[1]].width / 2 - 200f * NPC.ai[0] - vector58.X;
        var num582 = Main.npc[(int)NPC.ai[1]].position.Y + 230f - vector58.Y;
        var num583 = (float)Math.Sqrt(num581 * num581 + num582 * num582);
        if (NPC.ai[2] != 99f)
        {
            if (num583 > 800f)
            {
                NPC.ai[2] = 99f;
            }
        }
        else if (num583 < 400f)
        {
            NPC.ai[2] = 0f;
        }
        NPC.spriteDirection = -(int)NPC.ai[0];
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
                        var vector59 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
                        var num584 = Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 - vector59.X;
                        var num585 = Main.player[NPC.target].position.Y + Main.player[NPC.target].height / 2 - vector59.Y;
                        var num586 = (float)Math.Sqrt(num584 * num584 + num585 * num585);
                        num586 = 7f / num586;
                        num584 *= num586;
                        num585 *= num586;
                        NPC.rotation = (float)Math.Atan2(num585, num584) - 1.57f;
                        if (NPC.velocity.X > num584)
                        {
                            if (NPC.velocity.X > 0f)
                            {
                                NPC.velocity.X = NPC.velocity.X * 0.97f;
                            }
                            NPC.velocity.X = NPC.velocity.X - 0.05f;
                        }
                        if (NPC.velocity.X < num584)
                        {
                            if (NPC.velocity.X < 0f)
                            {
                                NPC.velocity.X = NPC.velocity.X * 0.97f;
                            }
                            NPC.velocity.X = NPC.velocity.X + 0.05f;
                        }
                        if (NPC.velocity.Y > num585)
                        {
                            if (NPC.velocity.Y > 0f)
                            {
                                NPC.velocity.Y = NPC.velocity.Y * 0.97f;
                            }
                            NPC.velocity.Y = NPC.velocity.Y - 0.05f;
                        }
                        if (NPC.velocity.Y < num585)
                        {
                            if (NPC.velocity.Y < 0f)
                            {
                                NPC.velocity.Y = NPC.velocity.Y * 0.97f;
                            }
                            NPC.velocity.Y = NPC.velocity.Y + 0.05f;
                        }
                    }
                    NPC.ai[3] += 1f;
                    if (NPC.ai[3] >= 600f)
                    {
                        NPC.ai[2] = 0f;
                        NPC.ai[3] = 0f;
                        NPC.netUpdate = true;
                    }
                }
                else
                {
                    NPC.ai[3] += 1f;
                    if (NPC.ai[3] >= 300f)
                    {
                        NPC.ai[2] += 1f;
                        NPC.ai[3] = 0f;
                        NPC.netUpdate = true;
                    }
                    if (NPC.position.Y > Main.npc[(int)NPC.ai[1]].position.Y + 320f)
                    {
                        if (NPC.velocity.Y > 0f)
                        {
                            NPC.velocity.Y = NPC.velocity.Y * 0.96f;
                        }
                        NPC.velocity.Y = NPC.velocity.Y - 0.04f;
                        if (NPC.velocity.Y > 3f)
                        {
                            NPC.velocity.Y = 3f;
                        }
                    }
                    else if (NPC.position.Y < Main.npc[(int)NPC.ai[1]].position.Y + 260f)
                    {
                        if (NPC.velocity.Y < 0f)
                        {
                            NPC.velocity.Y = NPC.velocity.Y * 0.96f;
                        }
                        NPC.velocity.Y = NPC.velocity.Y + 0.04f;
                        if (NPC.velocity.Y < -3f)
                        {
                            NPC.velocity.Y = -3f;
                        }
                    }
                    if (NPC.position.X + NPC.width / 2 > Main.npc[(int)NPC.ai[1]].position.X + Main.npc[(int)NPC.ai[1]].width / 2)
                    {
                        if (NPC.velocity.X > 0f)
                        {
                            NPC.velocity.X = NPC.velocity.X * 0.96f;
                        }
                        NPC.velocity.X = NPC.velocity.X - 0.3f;
                        if (NPC.velocity.X > 12f)
                        {
                            NPC.velocity.X = 12f;
                        }
                    }
                    if (NPC.position.X + NPC.width / 2 < Main.npc[(int)NPC.ai[1]].position.X + Main.npc[(int)NPC.ai[1]].width / 2 - 250f)
                    {
                        if (NPC.velocity.X < 0f)
                        {
                            NPC.velocity.X = NPC.velocity.X * 0.96f;
                        }
                        NPC.velocity.X = NPC.velocity.X + 0.3f;
                        if (NPC.velocity.X < -12f)
                        {
                            NPC.velocity.X = -12f;
                        }
                    }
                }
                var vector60 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
                var num587 = Main.npc[(int)NPC.ai[1]].position.X + Main.npc[(int)NPC.ai[1]].width / 2 - 200f * NPC.ai[0] - vector60.X;
                var num588 = Main.npc[(int)NPC.ai[1]].position.Y + 230f - vector60.Y;
                Math.Sqrt(num587 * num587 + num588 * num588);
                NPC.rotation = (float)Math.Atan2(num588, num587) + 1.57f;
                return;
            }
            if (NPC.ai[2] == 1f)
            {
                var vector61 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
                var num589 = Main.npc[(int)NPC.ai[1]].position.X + Main.npc[(int)NPC.ai[1]].width / 2 - 200f * NPC.ai[0] - vector61.X;
                var num590 = Main.npc[(int)NPC.ai[1]].position.Y + 230f - vector61.Y;
                var num591 = (float)Math.Sqrt(num589 * num589 + num590 * num590);
                NPC.rotation = (float)Math.Atan2(num590, num589) + 1.57f;
                NPC.velocity.X = NPC.velocity.X * 0.95f;
                NPC.velocity.Y = NPC.velocity.Y - 0.1f;
                if (NPC.velocity.Y < -8f)
                {
                    NPC.velocity.Y = -8f;
                }
                if (NPC.position.Y < Main.npc[(int)NPC.ai[1]].position.Y - 200f)
                {
                    NPC.TargetClosest(true);
                    NPC.ai[2] = 2f;
                    vector61 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
                    num589 = Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 - vector61.X;
                    num590 = Main.player[NPC.target].position.Y + Main.player[NPC.target].height / 2 - vector61.Y;
                    num591 = (float)Math.Sqrt(num589 * num589 + num590 * num590);
                    num591 = 22f / num591;
                    NPC.velocity.X = num589 * num591;
                    NPC.velocity.Y = num590 * num591;
                    NPC.netUpdate = true;
                    return;
                }
                return;
            }
            else if (NPC.ai[2] == 2f)
            {
                if (NPC.position.Y > Main.player[NPC.target].position.Y || NPC.velocity.Y < 0f)
                {
                    NPC.ai[2] = 3f;
                    return;
                }
                return;
            }
            else
            {
                if (NPC.ai[2] == 4f)
                {
                    NPC.TargetClosest(true);
                    var vector62 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
                    var num592 = Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 - vector62.X;
                    var num593 = Main.player[NPC.target].position.Y + Main.player[NPC.target].height / 2 - vector62.Y;
                    var num594 = (float)Math.Sqrt(num592 * num592 + num593 * num593);
                    num594 = 7f / num594;
                    num592 *= num594;
                    num593 *= num594;
                    if (NPC.velocity.X > num592)
                    {
                        if (NPC.velocity.X > 0f)
                        {
                            NPC.velocity.X = NPC.velocity.X * 0.97f;
                        }
                        NPC.velocity.X = NPC.velocity.X - 0.05f;
                    }
                    if (NPC.velocity.X < num592)
                    {
                        if (NPC.velocity.X < 0f)
                        {
                            NPC.velocity.X = NPC.velocity.X * 0.97f;
                        }
                        NPC.velocity.X = NPC.velocity.X + 0.05f;
                    }
                    if (NPC.velocity.Y > num593)
                    {
                        if (NPC.velocity.Y > 0f)
                        {
                            NPC.velocity.Y = NPC.velocity.Y * 0.97f;
                        }
                        NPC.velocity.Y = NPC.velocity.Y - 0.05f;
                    }
                    if (NPC.velocity.Y < num593)
                    {
                        if (NPC.velocity.Y < 0f)
                        {
                            NPC.velocity.Y = NPC.velocity.Y * 0.97f;
                        }
                        NPC.velocity.Y = NPC.velocity.Y + 0.05f;
                    }
                    NPC.ai[3] += 1f;
                    if (NPC.ai[3] >= 600f)
                    {
                        NPC.ai[2] = 0f;
                        NPC.ai[3] = 0f;
                        NPC.netUpdate = true;
                    }
                    vector62 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
                    num592 = Main.npc[(int)NPC.ai[1]].position.X + Main.npc[(int)NPC.ai[1]].width / 2 - 200f * NPC.ai[0] - vector62.X;
                    num593 = Main.npc[(int)NPC.ai[1]].position.Y + 230f - vector62.Y;
                    num594 = (float)Math.Sqrt(num592 * num592 + num593 * num593);
                    NPC.rotation = (float)Math.Atan2(num593, num592) + 1.57f;
                    return;
                }
                if (NPC.ai[2] == 5f && ((NPC.velocity.X > 0f && NPC.position.X + NPC.width / 2 > Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2) || (NPC.velocity.X < 0f && NPC.position.X + NPC.width / 2 < Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2)))
                {
                    NPC.ai[2] = 0f;
                    return;
                }
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