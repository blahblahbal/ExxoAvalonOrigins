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
	public class AncientOblivionSaw : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ancient Oblivion Saw");
			Main.npcFrameCount[npc.type] = 1;
		}

		public override void SetDefaults()
		{
			npc.damage = 75;
			npc.noTileCollide = true;
			npc.lifeMax = 45000;
			npc.defense = 70;
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
            var vector58 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
            var num581 = Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 - 200f * npc.ai[0] - vector58.X;
            var num582 = Main.npc[(int)npc.ai[1]].position.Y + 230f - vector58.Y;
            var num583 = (float)Math.Sqrt(num581 * num581 + num582 * num582);
            if (npc.ai[2] != 99f)
            {
                if (num583 > 800f)
                {
                    npc.ai[2] = 99f;
                }
            }
            else if (num583 < 400f)
            {
                npc.ai[2] = 0f;
            }
            npc.spriteDirection = -(int)npc.ai[0];
            if (!Main.npc[(int)npc.ai[1]].active || !(Main.npc[(int)npc.ai[1]].type == ModContent.NPCType<AncientOblivionHead1>() || Main.npc[(int)npc.ai[1]].type == ModContent.NPCType<AncientOblivionHead2>()))
            {
                npc.ai[2] += 10f;
                if (npc.ai[2] > 50f || Main.netMode != NetmodeID.Server)
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
                            var vector59 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                            var num584 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - vector59.X;
                            var num585 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - vector59.Y;
                            var num586 = (float)Math.Sqrt(num584 * num584 + num585 * num585);
                            num586 = 7f / num586;
                            num584 *= num586;
                            num585 *= num586;
                            npc.rotation = (float)Math.Atan2(num585, num584) - 1.57f;
                            if (npc.velocity.X > num584)
                            {
                                if (npc.velocity.X > 0f)
                                {
                                    npc.velocity.X = npc.velocity.X * 0.97f;
                                }
                                npc.velocity.X = npc.velocity.X - 0.05f;
                            }
                            if (npc.velocity.X < num584)
                            {
                                if (npc.velocity.X < 0f)
                                {
                                    npc.velocity.X = npc.velocity.X * 0.97f;
                                }
                                npc.velocity.X = npc.velocity.X + 0.05f;
                            }
                            if (npc.velocity.Y > num585)
                            {
                                if (npc.velocity.Y > 0f)
                                {
                                    npc.velocity.Y = npc.velocity.Y * 0.97f;
                                }
                                npc.velocity.Y = npc.velocity.Y - 0.05f;
                            }
                            if (npc.velocity.Y < num585)
                            {
                                if (npc.velocity.Y < 0f)
                                {
                                    npc.velocity.Y = npc.velocity.Y * 0.97f;
                                }
                                npc.velocity.Y = npc.velocity.Y + 0.05f;
                            }
                        }
                        npc.ai[3] += 1f;
                        if (npc.ai[3] >= 600f)
                        {
                            npc.ai[2] = 0f;
                            npc.ai[3] = 0f;
                            npc.netUpdate = true;
                        }
                    }
                    else
                    {
                        npc.ai[3] += 1f;
                        if (npc.ai[3] >= 300f)
                        {
                            npc.ai[2] += 1f;
                            npc.ai[3] = 0f;
                            npc.netUpdate = true;
                        }
                        if (npc.position.Y > Main.npc[(int)npc.ai[1]].position.Y + 320f)
                        {
                            if (npc.velocity.Y > 0f)
                            {
                                npc.velocity.Y = npc.velocity.Y * 0.96f;
                            }
                            npc.velocity.Y = npc.velocity.Y - 0.04f;
                            if (npc.velocity.Y > 3f)
                            {
                                npc.velocity.Y = 3f;
                            }
                        }
                        else if (npc.position.Y < Main.npc[(int)npc.ai[1]].position.Y + 260f)
                        {
                            if (npc.velocity.Y < 0f)
                            {
                                npc.velocity.Y = npc.velocity.Y * 0.96f;
                            }
                            npc.velocity.Y = npc.velocity.Y + 0.04f;
                            if (npc.velocity.Y < -3f)
                            {
                                npc.velocity.Y = -3f;
                            }
                        }
                        if (npc.position.X + npc.width / 2 > Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2)
                        {
                            if (npc.velocity.X > 0f)
                            {
                                npc.velocity.X = npc.velocity.X * 0.96f;
                            }
                            npc.velocity.X = npc.velocity.X - 0.3f;
                            if (npc.velocity.X > 12f)
                            {
                                npc.velocity.X = 12f;
                            }
                        }
                        if (npc.position.X + npc.width / 2 < Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 - 250f)
                        {
                            if (npc.velocity.X < 0f)
                            {
                                npc.velocity.X = npc.velocity.X * 0.96f;
                            }
                            npc.velocity.X = npc.velocity.X + 0.3f;
                            if (npc.velocity.X < -12f)
                            {
                                npc.velocity.X = -12f;
                            }
                        }
                    }
                    var vector60 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                    var num587 = Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 - 200f * npc.ai[0] - vector60.X;
                    var num588 = Main.npc[(int)npc.ai[1]].position.Y + 230f - vector60.Y;
                    Math.Sqrt(num587 * num587 + num588 * num588);
                    npc.rotation = (float)Math.Atan2(num588, num587) + 1.57f;
                    return;
                }
                if (npc.ai[2] == 1f)
                {
                    var vector61 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                    var num589 = Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 - 200f * npc.ai[0] - vector61.X;
                    var num590 = Main.npc[(int)npc.ai[1]].position.Y + 230f - vector61.Y;
                    var num591 = (float)Math.Sqrt(num589 * num589 + num590 * num590);
                    npc.rotation = (float)Math.Atan2(num590, num589) + 1.57f;
                    npc.velocity.X = npc.velocity.X * 0.95f;
                    npc.velocity.Y = npc.velocity.Y - 0.1f;
                    if (npc.velocity.Y < -8f)
                    {
                        npc.velocity.Y = -8f;
                    }
                    if (npc.position.Y < Main.npc[(int)npc.ai[1]].position.Y - 200f)
                    {
                        npc.TargetClosest(true);
                        npc.ai[2] = 2f;
                        vector61 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                        num589 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - vector61.X;
                        num590 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - vector61.Y;
                        num591 = (float)Math.Sqrt(num589 * num589 + num590 * num590);
                        num591 = 22f / num591;
                        npc.velocity.X = num589 * num591;
                        npc.velocity.Y = num590 * num591;
                        npc.netUpdate = true;
                        return;
                    }
                    return;
                }
                else if (npc.ai[2] == 2f)
                {
                    if (npc.position.Y > Main.player[npc.target].position.Y || npc.velocity.Y < 0f)
                    {
                        npc.ai[2] = 3f;
                        return;
                    }
                    return;
                }
                else
                {
                    if (npc.ai[2] == 4f)
                    {
                        npc.TargetClosest(true);
                        var vector62 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                        var num592 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - vector62.X;
                        var num593 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - vector62.Y;
                        var num594 = (float)Math.Sqrt(num592 * num592 + num593 * num593);
                        num594 = 7f / num594;
                        num592 *= num594;
                        num593 *= num594;
                        if (npc.velocity.X > num592)
                        {
                            if (npc.velocity.X > 0f)
                            {
                                npc.velocity.X = npc.velocity.X * 0.97f;
                            }
                            npc.velocity.X = npc.velocity.X - 0.05f;
                        }
                        if (npc.velocity.X < num592)
                        {
                            if (npc.velocity.X < 0f)
                            {
                                npc.velocity.X = npc.velocity.X * 0.97f;
                            }
                            npc.velocity.X = npc.velocity.X + 0.05f;
                        }
                        if (npc.velocity.Y > num593)
                        {
                            if (npc.velocity.Y > 0f)
                            {
                                npc.velocity.Y = npc.velocity.Y * 0.97f;
                            }
                            npc.velocity.Y = npc.velocity.Y - 0.05f;
                        }
                        if (npc.velocity.Y < num593)
                        {
                            if (npc.velocity.Y < 0f)
                            {
                                npc.velocity.Y = npc.velocity.Y * 0.97f;
                            }
                            npc.velocity.Y = npc.velocity.Y + 0.05f;
                        }
                        npc.ai[3] += 1f;
                        if (npc.ai[3] >= 600f)
                        {
                            npc.ai[2] = 0f;
                            npc.ai[3] = 0f;
                            npc.netUpdate = true;
                        }
                        vector62 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                        num592 = Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 - 200f * npc.ai[0] - vector62.X;
                        num593 = Main.npc[(int)npc.ai[1]].position.Y + 230f - vector62.Y;
                        num594 = (float)Math.Sqrt(num592 * num592 + num593 * num593);
                        npc.rotation = (float)Math.Atan2(num593, num592) + 1.57f;
                        return;
                    }
                    if (npc.ai[2] == 5f && ((npc.velocity.X > 0f && npc.position.X + npc.width / 2 > Main.player[npc.target].position.X + Main.player[npc.target].width / 2) || (npc.velocity.X < 0f && npc.position.X + npc.width / 2 < Main.player[npc.target].position.X + Main.player[npc.target].width / 2)))
                    {
                        npc.ai[2] = 0f;
                        return;
                    }
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
                    var num39 = Dust.NewDust(new Vector2(vector10.X, vector10.Y), 30, 10, DustID.Fire, num36 * 0.02f, num37 * 0.02f, 0, default(Color), 2.5f);
                    Main.dust[num39].noGravity = true;
                }
            }
            return true;
        }
    }
}