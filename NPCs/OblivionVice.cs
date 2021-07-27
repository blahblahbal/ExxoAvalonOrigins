using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;

namespace ExxoAvalonOrigins.NPCs
{
	public class OblivionVice : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Oblivion Vice");
			Main.npcFrameCount[npc.type] = 1;
		}

		public override void SetDefaults()
		{
			npc.damage = 80;
			npc.noTileCollide = true;
			npc.lifeMax = 20000;
			npc.defense = 40;
            npc.noGravity = true;
            npc.width = 52;
			npc.aiStyle = -1;
			npc.npcSlots = 1f;
			npc.value = 0f;
			npc.timeLeft = 750;
			npc.height = 52;
			npc.knockBackResist = 0f;
            npc.HitSound = SoundID.NPCHit4;
	        npc.DeathSound = SoundID.NPCDeath14;
			npc.buffImmune[BuffID.Frostburn] = true;
			npc.buffImmune[BuffID.Poisoned] = true;
			npc.buffImmune[BuffID.OnFire] = true;
		    npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().noOneHitKill = true;
		}

		public override void NPCLoot()
		{
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Heart, Main.rand.Next(3, 6), false, 0, false);
		}

        public override void AI()
        {
            npc.spriteDirection = -(int)npc.ai[0];
            var vector63 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
            var num595 = Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 - 200f * npc.ai[0] - vector63.X;
            var num596 = Main.npc[(int)npc.ai[1]].position.Y + 230f - vector63.Y;
            var num597 = (float)Math.Sqrt(num595 * num595 + num596 * num596);
            if (npc.ai[2] != 99f)
            {
                if (num597 > 800f)
                {
                    npc.ai[2] = 99f;
                }
            }
            else if (num597 < 400f)
            {
                npc.ai[2] = 0f;
            }
            if (!Main.npc[(int)npc.ai[1]].active || !(Main.npc[(int)npc.ai[1]].type == ModContent.NPCType<OblivionHead1>() || Main.npc[(int)npc.ai[1]].type == ModContent.NPCType<OblivionHead2>()))
            {
                npc.ai[2] += 10f;
                if (npc.ai[2] > 50f || Main.netMode != 2)
                {
                    npc.life = -1;
                    npc.HitEffect(0, 10.0);
                    npc.active = false;
                }
            }
            if (npc.ai[2] == 99f)
            {
                if (npc.position.Y > Main.npc[(int)npc.ai[1]].position.Y)
                {
                    if (npc.velocity.Y > 0f)
                    {
                        npc.velocity.Y = npc.velocity.Y * 0.96f;
                    }
                    npc.velocity.Y = npc.velocity.Y - 0.1f;
                    if (npc.velocity.Y > 8f)
                    {
                        npc.velocity.Y = 8f;
                    }
                }
                else if (npc.position.Y < Main.npc[(int)npc.ai[1]].position.Y)
                {
                    if (npc.velocity.Y < 0f)
                    {
                        npc.velocity.Y = npc.velocity.Y * 0.96f;
                    }
                    npc.velocity.Y = npc.velocity.Y + 0.1f;
                    if (npc.velocity.Y < -8f)
                    {
                        npc.velocity.Y = -8f;
                    }
                }
                if (npc.position.X + npc.width / 2 > Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2)
                {
                    if (npc.velocity.X > 0f)
                    {
                        npc.velocity.X = npc.velocity.X * 0.96f;
                    }
                    npc.velocity.X = npc.velocity.X - 0.5f;
                    if (npc.velocity.X > 12f)
                    {
                        npc.velocity.X = 12f;
                    }
                }
                if (npc.position.X + npc.width / 2 >= Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2)
                {
                    return;
                }
                if (npc.velocity.X < 0f)
                {
                    npc.velocity.X = npc.velocity.X * 0.96f;
                }
                npc.velocity.X = npc.velocity.X + 0.5f;
                if (npc.velocity.X < -12f)
                {
                    npc.velocity.X = -12f;
                    return;
                }
                return;
            }
            else
            {
                if (npc.ai[2] == 0f || npc.ai[2] == 3f)
                {
                    if (Main.npc[(int)npc.ai[1]].ai[1] == 3f && npc.timeLeft > 10)
                    {
                        npc.timeLeft = 10;
                    }
                    if (Main.npc[(int)npc.ai[1]].ai[1] != 0f)
                    {
                        npc.TargetClosest(true);
                        npc.TargetClosest(true);
                        if (Main.player[npc.target].dead)
                        {
                            npc.velocity.Y = npc.velocity.Y + 0.1f;
                            if (npc.velocity.Y > 16f)
                            {
                                npc.velocity.Y = 16f;
                            }
                        }
                        else
                        {
                            var vector64 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                            var num598 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - vector64.X;
                            var num599 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - vector64.Y;
                            var num600 = (float)Math.Sqrt(num598 * num598 + num599 * num599);
                            num600 = 12f / num600;
                            num598 *= num600;
                            num599 *= num600;
                            npc.rotation = (float)Math.Atan2(num599, num598) - 1.57f;
                            if (Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y) < 2f)
                            {
                                npc.rotation = (float)Math.Atan2(num599, num598) - 1.57f;
                                npc.velocity.X = num598;
                                npc.velocity.Y = num599;
                                npc.netUpdate = true;
                            }
                            else
                            {
                                npc.velocity *= 0.97f;
                            }
                            npc.ai[3] += 1f;
                            if (npc.ai[3] >= 600f)
                            {
                                npc.ai[2] = 0f;
                                npc.ai[3] = 0f;
                                npc.netUpdate = true;
                            }
                        }
                    }
                    else
                    {
                        npc.ai[3] += 1f;
                        if (npc.ai[3] >= 600f)
                        {
                            npc.ai[2] += 1f;
                            npc.ai[3] = 0f;
                            npc.netUpdate = true;
                        }
                        if (npc.position.Y > Main.npc[(int)npc.ai[1]].position.Y + 300f)
                        {
                            if (npc.velocity.Y > 0f)
                            {
                                npc.velocity.Y = npc.velocity.Y * 0.96f;
                            }
                            npc.velocity.Y = npc.velocity.Y - 0.1f;
                            if (npc.velocity.Y > 3f)
                            {
                                npc.velocity.Y = 3f;
                            }
                        }
                        else if (npc.position.Y < Main.npc[(int)npc.ai[1]].position.Y + 230f)
                        {
                            if (npc.velocity.Y < 0f)
                            {
                                npc.velocity.Y = npc.velocity.Y * 0.96f;
                            }
                            npc.velocity.Y = npc.velocity.Y + 0.1f;
                            if (npc.velocity.Y < -3f)
                            {
                                npc.velocity.Y = -3f;
                            }
                        }
                        if (npc.position.X + npc.width / 2 > Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 + 250f)
                        {
                            if (npc.velocity.X > 0f)
                            {
                                npc.velocity.X = npc.velocity.X * 0.94f;
                            }
                            npc.velocity.X = npc.velocity.X - 0.3f;
                            if (npc.velocity.X > 9f)
                            {
                                npc.velocity.X = 9f;
                            }
                        }
                        if (npc.position.X + npc.width / 2 < Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2)
                        {
                            if (npc.velocity.X < 0f)
                            {
                                npc.velocity.X = npc.velocity.X * 0.94f;
                            }
                            npc.velocity.X = npc.velocity.X + 0.2f;
                            if (npc.velocity.X < -8f)
                            {
                                npc.velocity.X = -8f;
                            }
                        }
                    }
                    var vector65 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                    var num601 = Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 - 200f * npc.ai[0] - vector65.X;
                    var num602 = Main.npc[(int)npc.ai[1]].position.Y + 230f - vector65.Y;
                    Math.Sqrt(num601 * num601 + num602 * num602);
                    npc.rotation = (float)Math.Atan2(num602, num601) + 1.57f;
                    return;
                }
                if (npc.ai[2] == 1f)
                {
                    if (npc.velocity.Y > 0f)
                    {
                        npc.velocity.Y = npc.velocity.Y * 0.9f;
                    }
                    var vector66 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                    var num603 = Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 - 280f * npc.ai[0] - vector66.X;
                    var num604 = Main.npc[(int)npc.ai[1]].position.Y + 230f - vector66.Y;
                    var num605 = (float)Math.Sqrt(num603 * num603 + num604 * num604);
                    npc.rotation = (float)Math.Atan2(num604, num603) + 1.57f;
                    npc.velocity.X = (npc.velocity.X * 5f + Main.npc[(int)npc.ai[1]].velocity.X) / 6f;
                    npc.velocity.X = npc.velocity.X + 0.5f;
                    npc.velocity.Y = npc.velocity.Y - 0.5f;
                    if (npc.velocity.Y < -9f)
                    {
                        npc.velocity.Y = -9f;
                    }
                    if (npc.position.Y < Main.npc[(int)npc.ai[1]].position.Y - 280f)
                    {
                        npc.TargetClosest(true);
                        npc.ai[2] = 2f;
                        vector66 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                        num603 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - vector66.X;
                        num604 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - vector66.Y;
                        num605 = (float)Math.Sqrt(num603 * num603 + num604 * num604);
                        num605 = 20f / num605;
                        npc.velocity.X = num603 * num605;
                        npc.velocity.Y = num604 * num605;
                        npc.netUpdate = true;
                        return;
                    }
                    return;
                }
                else if (npc.ai[2] == 2f)
                {
                    if (npc.position.Y <= Main.player[npc.target].position.Y && npc.velocity.Y >= 0f)
                    {
                        return;
                    }
                    if (npc.ai[3] >= 4f)
                    {
                        npc.ai[2] = 3f;
                        npc.ai[3] = 0f;
                        return;
                    }
                    npc.ai[2] = 1f;
                    npc.ai[3] += 1f;
                    return;
                }
                else if (npc.ai[2] == 4f)
                {
                    var vector67 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                    var num606 = Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 - 200f * npc.ai[0] - vector67.X;
                    var num607 = Main.npc[(int)npc.ai[1]].position.Y + 230f - vector67.Y;
                    var num608 = (float)Math.Sqrt(num606 * num606 + num607 * num607);
                    npc.rotation = (float)Math.Atan2(num607, num606) + 1.57f;
                    npc.velocity.Y = (npc.velocity.Y * 5f + Main.npc[(int)npc.ai[1]].velocity.Y) / 6f;
                    npc.velocity.X = npc.velocity.X + 0.5f;
                    if (npc.velocity.X > 12f)
                    {
                        npc.velocity.X = 12f;
                    }
                    if (npc.position.X + npc.width / 2 < Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 - 500f || npc.position.X + npc.width / 2 > Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 + 500f)
                    {
                        npc.TargetClosest(true);
                        npc.ai[2] = 5f;
                        vector67 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                        num606 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - vector67.X;
                        num607 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - vector67.Y;
                        num608 = (float)Math.Sqrt(num606 * num606 + num607 * num607);
                        num608 = 17f / num608;
                        npc.velocity.X = num606 * num608;
                        npc.velocity.Y = num607 * num608;
                        npc.netUpdate = true;
                        return;
                    }
                    return;
                }
                else
                {
                    if (npc.ai[2] != 5f || npc.position.X + npc.width / 2 >= Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - 100f)
                    {
                        return;
                    }
                    if (npc.ai[3] >= 4f)
                    {
                        npc.ai[2] = 0f;
                        npc.ai[3] = 0f;
                        return;
                    }
                    npc.ai[2] = 4f;
                    npc.ai[3] += 1f;
                    return;
                }
            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            var vector10 = new Vector2(npc.position.X + npc.width * 0.5f - 5f * npc.ai[0], npc.position.Y + 20f);
            for (var m = 0; m < 2; m++)
            {
                var num36 = Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 - vector10.X;
                var num37 = Main.npc[(int)npc.ai[1]].position.Y + Main.npc[(int)npc.ai[1]].height / 2 - vector10.Y;
                float num38;
                if (m == 0)
                {
                    num36 -= 200f * npc.ai[0];
                    num37 += 130f;
                    num38 = (float)Math.Sqrt(num36 * num36 + num37 * num37);
                    num38 = 92f / num38;
                    vector10.X += num36 * num38;
                    vector10.Y += num37 * num38;
                }
                else
                {
                    num36 -= 50f * npc.ai[0];
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
                    var num39 = Dust.NewDust(new Vector2(vector10.X, vector10.Y), 30, 10, 6, num36 * 0.02f, num37 * 0.02f, 0, default(Color), 2.5f);
                    Main.dust[num39].noGravity = true;
                }
            }
            return true;
        }
    }
}