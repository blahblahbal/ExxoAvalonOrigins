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
    [AutoloadBossHead]
    public class BacteriumPrime : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bacterium Prime");
			Main.npcFrameCount[npc.type] = 8;
		}

		public override void SetDefaults()
		{
			npc.damage = 31;
			npc.boss = true;
			npc.noTileCollide = true;
			npc.lifeMax = 1500;
			npc.defense = 10;
			npc.noGravity = true;
			npc.width = 120;
			npc.aiStyle = -1;
			npc.npcSlots = 6f;
			npc.value = 50000f;
			npc.timeLeft = NPC.activeTime * 30;
			npc.height = 120;
            npc.HitSound = SoundID.NPCHit8;
	        npc.DeathSound = SoundID.NPCDeath10;
			npc.knockBackResist = 0f;
		}

        public override void NPCLoot()
        {
            if (Main.rand.Next(10) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.BacteriumPrimeTrophy>(), 1, false, 0, false);
            }
            if (Main.rand.Next(7) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.BacteriumPrimeMask>(), 1, false, 0, false);
            }
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.BacciliteOre>(), Main.rand.Next(15, 41) + Main.rand.Next(15, 41), false, 0, false);
        }

        public override void AI()
        {
            if (npc.type == ModContent.NPCType<BacteriumPrime>())
            {
                ExxoAvalonOriginsGlobalNPC.boogerBoss = npc.whoAmI;
            }
            if (Main.netMode != 1 && npc.localAI[0] == 0f)
            {
                npc.localAI[0] = 1f;
                for (var num898 = 0; num898 < 20; num898++)
                {
                    var num899 = npc.Center.X;
                    var num900 = npc.Center.Y;
                    num899 += Main.rand.Next(-npc.width, npc.width);
                    num900 += Main.rand.Next(-npc.height, npc.height);
                    var num901 = NPC.NewNPC((int)num899, (int)num900, ModContent.NPCType<BactusMinion>(), 0);
                    Main.npc[num901].velocity = new Vector2(Main.rand.Next(-30, 31) * 0.1f, Main.rand.Next(-30, 31) * 0.1f);
                    Main.npc[num901].netUpdate = true;
                }
            }
            if (Main.netMode != 1)
            {
                npc.TargetClosest(true);
                var num902 = 6000;
                if (Math.Abs(npc.Center.X - Main.player[npc.target].Center.X) + Math.Abs(npc.Center.Y - Main.player[npc.target].Center.Y) > num902)
                {
                    npc.active = false;
                    npc.life = 0;
                    if (Main.netMode == 2)
                    {
                        NetMessage.SendData(23, -1, -1, NetworkText.FromLiteral(""), npc.whoAmI, 0f, 0f, 0f, 0);
                    }
                }
            }
            if (npc.ai[0] < 0f)
            {
                if (npc.localAI[2] == 0f)
                {
                    Main.PlaySound(3, (int)npc.position.X, (int)npc.position.Y, 1);
                    npc.localAI[2] = 1f;
                    for (var num903 = 0; num903 < 20; num903++)
                    {
                        Dust.NewDust(npc.position, npc.width, npc.height, 5, Main.rand.Next(-30, 31) * 0.2f, Main.rand.Next(-30, 31) * 0.2f, 0, default(Color), 1f);
                    }
                    if (npc.type == ModContent.NPCType<BacteriumPrime>())
                    {
                        npc.lifeMax = 1500;
                        npc.life = 1500;
                    }
                    Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
                }
                npc.dontTakeDamage = false;
                npc.knockBackResist = 0.5f;
                npc.TargetClosest(true);
                var vector109 = new Vector2(npc.Center.X, npc.Center.Y);
                var num904 = Main.player[npc.target].Center.X - vector109.X;
                var num905 = Main.player[npc.target].Center.Y - vector109.Y;
                var num906 = (float)Math.Sqrt(num904 * num904 + num905 * num905);
                var num907 = 8f;
                num906 = num907 / num906;
                num904 *= num906;
                num905 *= num906;
                npc.velocity.X = (npc.velocity.X * 50f + num904) / 51f;
                npc.velocity.Y = (npc.velocity.Y * 50f + num905) / 51f;
                if (npc.ai[0] == -1f)
                {
                    if (Main.netMode == 1)
                    {
                        return;
                    }
                    npc.localAI[1] += 1f;
                    if (npc.localAI[1] >= 60 + Main.rand.Next(120))
                    {
                        npc.localAI[1] = 0f;
                        npc.TargetClosest(true);
                        var num908 = 0;
                        int num909;
                        int num910;
                        do
                        {
                            num908++;
                            num909 = (int)Main.player[npc.target].Center.X / 16;
                            num910 = (int)Main.player[npc.target].Center.Y / 16;
                            if (Main.rand.Next(2) == 0)
                            {
                                num909 += Main.rand.Next(7, 13);
                            }
                            else
                            {
                                num909 -= Main.rand.Next(7, 13);
                            }
                            if (Main.rand.Next(2) == 0)
                            {
                                num910 += Main.rand.Next(7, 13);
                            }
                            else
                            {
                                num910 -= Main.rand.Next(7, 13);
                            }
                            if (!WorldGen.SolidTile(num909, num910))
                            {
                                goto IL_3556C;
                            }
                        }
                        while (num908 <= 100);
                        return;
                    IL_3556C:
                        npc.ai[0] = -2f;
                        npc.ai[1] = num909;
                        npc.ai[2] = num910;
                        npc.netUpdate = true;
                        return;
                    }
                    return;
                }
                else if (npc.ai[0] == -2f)
                {
                    npc.velocity *= 0.9f;
                    npc.alpha += 25;
                    if (npc.alpha >= 255)
                    {
                        npc.alpha = 255;
                        npc.position.X = npc.ai[1] * 16f - npc.width / 2;
                        npc.position.Y = npc.ai[2] * 16f - npc.height / 2;
                        Main.PlaySound(2, (int)npc.Center.X, (int)npc.Center.Y, 8);
                        npc.ai[0] = -3f;
                        return;
                    }
                    return;
                }
                else
                {
                    if (npc.ai[0] != -3f)
                    {
                        return;
                    }
                    npc.alpha -= 25;
                    if (npc.alpha <= 0)
                    {
                        npc.alpha = 0;
                        npc.ai[0] = -1f;
                        return;
                    }
                    return;
                }
            }
            else
            {
                npc.TargetClosest(true);
                if (npc.justHit && Main.netMode != 1 && npc.type == ModContent.NPCType<BacteriumPrime>())
                {
                    npc.life = npc.lifeMax;
                    ExxoAvalonOriginsGlobalNPC.boogerBossCounter++;
                    if (ExxoAvalonOriginsGlobalNPC.boogerBossCounter >= 12)
                    {
                        NPC.NewNPC((int)npc.position.X - 160, (int)npc.position.Y - 160, ModContent.NPCType<BactusMinion>(), 0);
                        ExxoAvalonOriginsGlobalNPC.boogerBossCounter = 0;
                    }
                }
                var vector110 = new Vector2(npc.Center.X, npc.Center.Y);
                var num911 = Main.player[npc.target].Center.X - vector110.X;
                var num912 = Main.player[npc.target].Center.Y - vector110.Y;
                var num913 = (float)Math.Sqrt(num911 * num911 + num912 * num912);
                var num914 = 1f;
                if (num913 < num914)
                {
                    npc.velocity.X = num911;
                    npc.velocity.Y = num912;
                }
                else
                {
                    num913 = num914 / num913;
                    npc.velocity.X = num911 * num913;
                    npc.velocity.Y = num912 * num913;
                }
                if (npc.ai[0] == 0f)
                {
                    if (Main.netMode == 1)
                    {
                        return;
                    }
                    var num915 = 0;
                    for (var num916 = 0; num916 < 200; num916++)
                    {
                        if (Main.npc[num916].active && ((Main.npc[num916].type == NPCID.Creeper && npc.type == NPCID.BrainofCthulhu) || (Main.npc[num916].type == ModContent.NPCType<BactusMinion>() && npc.type == ModContent.NPCType<BacteriumPrime>())))
                        {
                            num915++;
                        }
                    }
                    if (num915 == 0)
                    {
                        npc.ai[0] = -1f;
                        npc.localAI[1] = 0f;
                        npc.alpha = 0;
                        npc.netUpdate = true;
                    }
                    npc.localAI[1] += 1f;
                    if (npc.localAI[1] >= 120 + Main.rand.Next(300))
                    {
                        npc.localAI[1] = 0f;
                        npc.TargetClosest(true);
                        var num917 = 0;
                        int num918;
                        int num919;
                        do
                        {
                            num917++;
                            num918 = (int)Main.player[npc.target].Center.X / 16;
                            num919 = (int)Main.player[npc.target].Center.Y / 16;
                            num918 += Main.rand.Next(-50, 51);
                            num919 += Main.rand.Next(-50, 51);
                            if (!WorldGen.SolidTile(num918, num919) && Collision.CanHit(new Vector2(num918 * 16, num919 * 16), 1, 1, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
                            {
                                goto IL_35A0D;
                            }
                        }
                        while (num917 <= 100);
                        return;
                    IL_35A0D:
                        npc.ai[0] = 1f;
                        npc.ai[1] = num918;
                        npc.ai[2] = num919;
                        npc.netUpdate = true;
                        return;
                    }
                    return;
                }
                else if (npc.ai[0] == 1f)
                {
                    npc.alpha += 5;
                    if (npc.alpha >= 255)
                    {
                        Main.PlaySound(2, (int)npc.Center.X, (int)npc.Center.Y, 8);
                        npc.alpha = 255;
                        npc.position.X = npc.ai[1] * 16f - npc.width / 2;
                        npc.position.Y = npc.ai[2] * 16f - npc.height / 2;
                        npc.ai[0] = 2f;
                        return;
                    }
                    return;
                }
                else
                {
                    if (npc.ai[0] != 2f)
                    {
                        return;
                    }
                    npc.alpha -= 5;
                    if (npc.alpha <= 0)
                    {
                        npc.alpha = 0;
                        npc.ai[0] = 0f;
                        return;
                    }
                    return;
                }
            }
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 1.0;
            if (npc.frameCounter > 6.0)
            {
                npc.frameCounter = 0.0;
                npc.frame.Y = npc.frame.Y + frameHeight;
            }
            if (npc.ai[0] >= 0f)
            {
                if (npc.frame.Y > frameHeight * 3)
                {
                    npc.frame.Y = 0;
                }
            }
            else
            {
                if (npc.frame.Y < frameHeight * 4)
                {
                    npc.frame.Y = frameHeight * 4;
                }
                if (npc.frame.Y > frameHeight * 7)
                {
                    npc.frame.Y = frameHeight * 4;
                }
            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity * 0.8f, mod.GetGoreSlot("Gores/BacteriumPrime1"), 1f);
                Gore.NewGore(npc.position, npc.velocity * 0.8f, mod.GetGoreSlot("Gores/BacteriumPrime2"), 1f);
                Gore.NewGore(npc.position, npc.velocity * 0.8f, mod.GetGoreSlot("Gores/BacteriumPrime3"), 1f);
            }
        }
    }
}