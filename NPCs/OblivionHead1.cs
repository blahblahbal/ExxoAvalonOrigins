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
	public class OblivionHead1 : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Oblivion");
			Main.npcFrameCount[npc.type] = 3;
		}

		public override void SetDefaults()
		{
			npc.damage = 180;
			npc.boss = true;
			npc.netAlways = true;
			npc.noTileCollide = true;
			npc.lifeMax = 150000;
			npc.defense = 95;
			npc.noGravity = true;
			npc.width = 80;
			npc.aiStyle = -1;
			npc.npcSlots = 10f;
			npc.value = 2500000f;
			npc.timeLeft = 22500;
			npc.height = 102;
			npc.knockBackResist = 0f;
            npc.HitSound = SoundID.NPCHit4;
	        npc.DeathSound = SoundID.NPCDeath14;
            bossBag = ModContent.ItemType<Items.BossBags.OblivionBossBag>();
		}
        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ModContent.ItemType<Items.ElixirofLife>();
        }
        public override void AI()
        {
            var instance = npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>();
            npc.damage = npc.defDamage;
            npc.defense = npc.defDefense;
            if (npc.ai[0] == 0f && Main.netMode != NetmodeID.MultiplayerClient)
            {
                npc.TargetClosest(true);
                npc.ai[0] = 1f;
                instance.infernaSpawned = false;
                var num559 = NPC.NewNPC((int)(npc.position.X + npc.width / 2), (int)npc.position.Y + npc.height / 2, ModContent.NPCType<OblivionHead2>(), npc.whoAmI);
                Main.npc[num559].ai[3] = npc.whoAmI;
                Main.npc[num559].target = npc.target;
                Main.npc[num559].netUpdate = true;
                var num560 = NPC.NewNPC((int)(npc.position.X + npc.width / 2), (int)npc.position.Y + npc.height / 2, ModContent.NPCType<OblivionCannon>(), npc.whoAmI);
                Main.npc[num560].ai[0] = -1f;
                Main.npc[num560].ai[1] = npc.whoAmI;
                Main.npc[num560].target = npc.target;
                Main.npc[num560].netUpdate = true;
                num560 = NPC.NewNPC((int)(npc.position.X + npc.width / 2), (int)npc.position.Y + npc.height / 2, ModContent.NPCType<OblivionLaser>(), npc.whoAmI);
                Main.npc[num560].ai[0] = 1f;
                Main.npc[num560].ai[1] = npc.whoAmI;
                Main.npc[num560].target = npc.target;
                Main.npc[num560].netUpdate = true;
                num560 = NPC.NewNPC((int)(npc.position.X + npc.width / 2), (int)npc.position.Y + npc.height / 2, ModContent.NPCType<OblivionSaw>(), npc.whoAmI);
                Main.npc[num560].ai[0] = -1f;
                Main.npc[num560].ai[1] = npc.whoAmI;
                Main.npc[num560].target = npc.target;
                Main.npc[num560].ai[3] = 150f;
                Main.npc[num560].netUpdate = true;
                num560 = NPC.NewNPC((int)(npc.position.X + npc.width / 2), (int)npc.position.Y + npc.height / 2, ModContent.NPCType<OblivionVice>(), npc.whoAmI);
                Main.npc[num560].ai[0] = 1f;
                Main.npc[num560].ai[1] = npc.whoAmI;
                Main.npc[num560].target = npc.target;
                Main.npc[num560].netUpdate = true;
                Main.npc[num560].ai[3] = 150f;
            }
            if (Main.player[npc.target].dead || Math.Abs(npc.position.X - Main.player[npc.target].position.X) > 6000f || Math.Abs(npc.position.Y - Main.player[npc.target].position.Y) > 6000f)
            {
                npc.TargetClosest(true);
                if (Main.player[npc.target].dead || Math.Abs(npc.position.X - Main.player[npc.target].position.X) > 6000f || Math.Abs(npc.position.Y - Main.player[npc.target].position.Y) > 6000f)
                {
                    npc.ai[1] = 3f;
                }
            }
            if (npc.life < npc.lifeMax / 2 && !instance.infernaSpawned)
            {
                var num561 = NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, ModContent.NPCType<Infernaspaz>(), 0);
                Main.npc[num561].target = npc.target;
                if (Main.netMode != NetmodeID.SinglePlayer)
                {
                    NetMessage.SendData(25, -1, -1, NetworkText.FromLiteral("Infernaspaz has awoken!"), 255, 175f, 75f, 255f, 0);
                }
                else Main.NewText("Infernaspaz has awoken!", 175, 75, 255);
                NPC.SpawnOnPlayer(npc.target, NPCID.Retinazer);
                instance.infernaSpawned = true;
            }
            if (npc.life < 50000)
            {
                npc.localAI[0] += 1f;
                if (npc.localAI[0] >= 500f)
                {
                    var num569 = 12f;
                    var vector55 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height / 2);
                    var num570 = 100;
                    int num571 = ProjectileID.DeathLaser;
                    Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 33);
                    var num572 = (float)Math.Atan2(vector55.Y - (Main.player[npc.target].position.Y + Main.player[npc.target].height * 0.5f), vector55.X - (Main.player[npc.target].position.X + Main.player[npc.target].width * 0.5f));
                    for (var num573 = 0f; num573 <= 4f; num573 += 0.4f)
                    {
                        var num574 = Projectile.NewProjectile(vector55.X, vector55.Y, (float)(Math.Cos(num572 + num573) * num569 * -1.0), (float)(Math.Sin(num572 + num573) * num569 * -1.0), num571, num570, 0f, 0, 0f, 0f);
                        Main.projectile[num574].timeLeft = 600;
                        Main.projectile[num574].tileCollide = false;
                        if (Main.netMode == NetmodeID.Server)
                        {
                            NetMessage.SendData(27, -1, -1, NetworkText.FromLiteral(""), num574, 0f, 0f, 0f, 0);
                        }
                        num574 = Projectile.NewProjectile(vector55.X, vector55.Y, (float)(Math.Cos(num572 - num573) * num569 * -1.0), (float)(Math.Sin(num572 - num573) * num569 * -1.0), num571, num570, 0f, 0, 0f, 0f);
                        Main.projectile[num574].timeLeft = 600;
                        Main.projectile[num574].tileCollide = false;
                        if (Main.netMode == NetmodeID.Server)
                        {
                            NetMessage.SendData(27, -1, -1, NetworkText.FromLiteral(""), num574, 0f, 0f, 0f, 0);
                        }
                    }
                    npc.localAI[0] = 0f;
                }
            }
            if (npc.ai[1] == 0f)
            {
                npc.ai[2] += 1f;
                if (npc.ai[2] >= 600f)
                {
                    npc.ai[2] = 0f;
                    npc.ai[1] = 1f;
                    npc.TargetClosest(true);
                    npc.netUpdate = true;
                }
                npc.rotation = npc.velocity.X / 15f;
                if (npc.position.Y > Main.player[npc.target].position.Y - 200f)
                {
                    if (npc.velocity.Y > 0f)
                    {
                        npc.velocity.Y = npc.velocity.Y * 0.98f;
                    }
                    npc.velocity.Y = npc.velocity.Y - 0.1f;
                    if (npc.velocity.Y > 2f)
                    {
                        npc.velocity.Y = 2f;
                    }
                }
                else if (npc.position.Y < Main.player[npc.target].position.Y - 500f)
                {
                    if (npc.velocity.Y < 0f)
                    {
                        npc.velocity.Y = npc.velocity.Y * 0.98f;
                    }
                    npc.velocity.Y = npc.velocity.Y + 0.1f;
                    if (npc.velocity.Y < -2f)
                    {
                        npc.velocity.Y = -2f;
                    }
                }
                if (npc.position.X + npc.width / 2 > Main.player[npc.target].position.X + Main.player[npc.target].width / 2 + 100f)
                {
                    if (npc.velocity.X > 0f)
                    {
                        npc.velocity.X = npc.velocity.X * 0.98f;
                    }
                    npc.velocity.X = npc.velocity.X - 0.1f;
                    if (npc.velocity.X > 8f)
                    {
                        npc.velocity.X = 8f;
                    }
                }
                if (npc.position.X + npc.width / 2 >= Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - 100f)
                {
                    return;
                }
                if (npc.velocity.X < 0f)
                {
                    npc.velocity.X = npc.velocity.X * 0.98f;
                }
                npc.velocity.X = npc.velocity.X + 0.1f;
                if (npc.velocity.X < -8f)
                {
                    npc.velocity.X = -8f;
                    return;
                }
                return;
            }
            else
            {
                if (npc.ai[1] == 1f)
                {
                    npc.defense *= 2;
                    npc.damage *= 2;
                    npc.ai[2] += 1f;
                    if (npc.ai[2] == 2f)
                    {
                        Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
                    }
                    if (npc.ai[2] >= 400f)
                    {
                        npc.ai[2] = 0f;
                        npc.ai[1] = 0f;
                    }
                    npc.rotation += npc.direction * 0.3f;
                    var vector56 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                    var num575 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - vector56.X;
                    var num576 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - vector56.Y;
                    var num577 = (float)Math.Sqrt(num575 * num575 + num576 * num576);
                    num577 = 2f / num577;
                    npc.velocity.X = num575 * num577;
                    npc.velocity.Y = num576 * num577;
                    return;
                }
                if (npc.ai[1] == 2f)
                {
                    npc.damage = 1000;
                    npc.defense = 9999;
                    npc.rotation += npc.direction * 0.3f;
                    var vector57 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                    var num578 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - vector57.X;
                    var num579 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - vector57.Y;
                    var num580 = (float)Math.Sqrt(num578 * num578 + num579 * num579);
                    num580 = 8f / num580;
                    npc.velocity.X = num578 * num580;
                    npc.velocity.Y = num579 * num580;
                    return;
                }
                if (npc.ai[1] != 3f)
                {
                    return;
                }
                npc.velocity.Y = npc.velocity.Y + 0.1f;
                if (npc.velocity.Y < 0f)
                {
                    npc.velocity.Y = npc.velocity.Y * 0.95f;
                }
                npc.velocity.X = npc.velocity.X * 0.95f;
                if (npc.timeLeft > 500)
                {
                    npc.timeLeft = 500;
                    return;
                }
                return;
            }
        }

        public override void NPCLoot()
        {
            ExxoAvalonOriginsGlobalNPC.oblivionDead = true;
            if (Main.rand.Next(7) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.OblivionTrophy>(), 1, false, 0, false);
            }
            if (Main.expertMode)
            {
                npc.DropBossBags();
            }
            else
            {
                if (Main.rand.Next(4) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.CurseofOblivion>(), 1, false, 0, false);
                }
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.AccelerationDrill>(), 1, false, -2, false);
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.SoulofTorture>(), Main.rand.Next(60, 121), false, 0, false);
                if (Main.rand.Next(5) > 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.VictoryPiece>(), 1, false, 0, false);
                }
                else
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.VictoryPiece>(), 2, false, 0, false);
                }
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.OblivionOre>(), Main.rand.Next(100, 201), false, 0, false);
            }

            if (!ExxoAvalonOriginsWorld.downedOblivion)
                ExxoAvalonOriginsWorld.downedOblivion = true;
        }

        public override void FindFrame(int frameHeight)
        {
            if (npc.ai[1] == 0f)
            {
                npc.frameCounter += 1.0;
                if (npc.frameCounter >= 12.0)
                {
                    npc.frameCounter = 0.0;
                    npc.frame.Y = npc.frame.Y + frameHeight;
                    if (npc.frame.Y / frameHeight >= 2)
                    {
                        npc.frame.Y = 0;
                    }
                }
            }
            else
            {
                npc.frameCounter = 0.0;
                npc.frame.Y = frameHeight * 2;
            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/OblivionTop"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/OblivionMouth"), 1f);
            }
        }
    }
}