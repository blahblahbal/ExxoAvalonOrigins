using System;
using ExxoAvalonOrigins.Items.Accessories;
using ExxoAvalonOrigins.Items.Material;
using ExxoAvalonOrigins.Items.Placeable.Painting;
using ExxoAvalonOrigins.Items.Placeable.Tile;
using ExxoAvalonOrigins.Items.Placeable.Trophy;
using ExxoAvalonOrigins.Items.Potions;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.NPCs;

public class AncientOblivionHead1 : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Ancient Oblivion");
        Main.npcFrameCount[NPC.type] = 3;
    }

    public override void SetDefaults()
    {
        NPC.damage = 180;
        NPC.boss = true;
        NPC.netAlways = true;
        NPC.noTileCollide = true;
        NPC.lifeMax = 150000;
        NPC.defense = 95;
        NPC.noGravity = true;
        NPC.width = 80;
        NPC.aiStyle = -1;
        NPC.npcSlots = 10f;
        NPC.value = 2500000f;
        NPC.timeLeft = 22500;
        NPC.height = 102;
        NPC.knockBackResist = 0f;
        NPC.HitSound = SoundID.NPCHit4;
        NPC.DeathSound = SoundID.NPCDeath14;
        bossBag = ModContent.ItemType<Items.BossBags.OblivionBossBag>();
    }
    public override void BossLoot(ref string name, ref int potionType)
    {
        potionType = ModContent.ItemType<ElixirofLife>();
    }
    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.55f * bossLifeScale);
        NPC.damage = (int)(NPC.damage * 0.45f);
    }
    public override void AI()
    {
        ExxoAvalonOriginsGlobalNPCInstance instance = NPC.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>();
        NPC.damage = NPC.defDamage;
        NPC.defense = NPC.defDefense;
        if (NPC.ai[0] == 0f && Main.netMode != NetmodeID.MultiplayerClient)
        {
            NPC.TargetClosest(true);
            NPC.ai[0] = 1f;
            instance.infernaSpawned = false;
            int num559 = NPC.NewNPC((int)(NPC.position.X + NPC.width / 2), (int)NPC.position.Y + NPC.height / 2, ModContent.NPCType<AncientOblivionHead2>(), NPC.whoAmI);
            Main.npc[num559].ai[3] = NPC.whoAmI;
            Main.npc[num559].target = NPC.target;
            Main.npc[num559].netUpdate = true;
            int num560 = NPC.NewNPC((int)(NPC.position.X + NPC.width / 2), (int)NPC.position.Y + NPC.height / 2, ModContent.NPCType<AncientOblivionCannon>(), NPC.whoAmI);
            Main.npc[num560].ai[0] = -1f;
            Main.npc[num560].ai[1] = NPC.whoAmI;
            Main.npc[num560].target = NPC.target;
            Main.npc[num560].netUpdate = true;
            num560 = NPC.NewNPC((int)(NPC.position.X + NPC.width / 2), (int)NPC.position.Y + NPC.height / 2, ModContent.NPCType<AncientOblivionLaser>(), NPC.whoAmI);
            Main.npc[num560].ai[0] = 1f;
            Main.npc[num560].ai[1] = NPC.whoAmI;
            Main.npc[num560].target = NPC.target;
            Main.npc[num560].netUpdate = true;
            num560 = NPC.NewNPC((int)(NPC.position.X + NPC.width / 2), (int)NPC.position.Y + NPC.height / 2, ModContent.NPCType<AncientOblivionSaw>(), NPC.whoAmI);
            Main.npc[num560].ai[0] = -1f;
            Main.npc[num560].ai[1] = NPC.whoAmI;
            Main.npc[num560].target = NPC.target;
            Main.npc[num560].ai[3] = 150f;
            Main.npc[num560].netUpdate = true;
            num560 = NPC.NewNPC((int)(NPC.position.X + NPC.width / 2), (int)NPC.position.Y + NPC.height / 2, ModContent.NPCType<AncientOblivionVice>(), NPC.whoAmI);
            Main.npc[num560].ai[0] = 1f;
            Main.npc[num560].ai[1] = NPC.whoAmI;
            Main.npc[num560].target = NPC.target;
            Main.npc[num560].netUpdate = true;
            Main.npc[num560].ai[3] = 150f;
        }
        if (Main.player[NPC.target].dead || Math.Abs(NPC.position.X - Main.player[NPC.target].position.X) > 6000f || Math.Abs(NPC.position.Y - Main.player[NPC.target].position.Y) > 6000f)
        {
            NPC.TargetClosest(true);
            if (Main.player[NPC.target].dead || Math.Abs(NPC.position.X - Main.player[NPC.target].position.X) > 6000f || Math.Abs(NPC.position.Y - Main.player[NPC.target].position.Y) > 6000f)
            {
                NPC.ai[1] = 3f;
            }
        }
        if (NPC.life < NPC.lifeMax / 2 && !instance.infernaSpawned)
        {
            int num561 = NPC.NewNPC((int)NPC.position.X, (int)NPC.position.Y, ModContent.NPCType<Infernaspaz>(), 0);
            Main.npc[num561].target = NPC.target;
            if (Main.netMode != NetmodeID.SinglePlayer)
            {
                NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Infernaspaz has awoken!"), new Color(175, 75, 255));
            }
            else
            {
                Main.NewText("Infernaspaz has awoken!", 175, 75, 255);
            }

            NPC.SpawnOnPlayer(NPC.target, NPCID.Retinazer);
            instance.infernaSpawned = true;
        }
        if (NPC.life < 50000)
        {
            NPC.localAI[0] += 1f;
            if (NPC.localAI[0] >= 500f)
            {
                float num569 = 12f;
                var vector55 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height / 2);
                int num570 = 100;
                int num571 = ProjectileID.DeathLaser;
                SoundEngine.PlaySound(SoundID.Item, (int)NPC.position.X, (int)NPC.position.Y, 33);
                float num572 = (float)Math.Atan2(vector55.Y - (Main.player[NPC.target].position.Y + Main.player[NPC.target].height * 0.5f), vector55.X - (Main.player[NPC.target].position.X + Main.player[NPC.target].width * 0.5f));
                for (float num573 = 0f; num573 <= 4f; num573 += 0.4f)
                {
                    int num574 = Projectile.NewProjectile(vector55.X, vector55.Y, (float)(Math.Cos(num572 + num573) * num569 * -1.0), (float)(Math.Sin(num572 + num573) * num569 * -1.0), num571, num570, 0f, 0, 0f, 0f);
                    Main.projectile[num574].timeLeft = 600;
                    Main.projectile[num574].tileCollide = false;
                    if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.FromLiteral(""), num574, 0f, 0f, 0f, 0);
                    }
                    num574 = Projectile.NewProjectile(vector55.X, vector55.Y, (float)(Math.Cos(num572 - num573) * num569 * -1.0), (float)(Math.Sin(num572 - num573) * num569 * -1.0), num571, num570, 0f, 0, 0f, 0f);
                    Main.projectile[num574].timeLeft = 600;
                    Main.projectile[num574].tileCollide = false;
                    if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.FromLiteral(""), num574, 0f, 0f, 0f, 0);
                    }
                }
                NPC.localAI[0] = 0f;
            }
        }
        if (NPC.ai[1] == 0f)
        {
            NPC.ai[2] += 1f;
            if (NPC.ai[2] >= 600f)
            {
                NPC.ai[2] = 0f;
                NPC.ai[1] = 1f;
                NPC.TargetClosest(true);
                NPC.netUpdate = true;
            }
            NPC.rotation = NPC.velocity.X / 15f;
            if (NPC.position.Y > Main.player[NPC.target].position.Y - 200f)
            {
                if (NPC.velocity.Y > 0f)
                {
                    NPC.velocity.Y = NPC.velocity.Y * 0.98f;
                }
                NPC.velocity.Y = NPC.velocity.Y - 0.1f;
                if (NPC.velocity.Y > 2f)
                {
                    NPC.velocity.Y = 2f;
                }
            }
            else if (NPC.position.Y < Main.player[NPC.target].position.Y - 500f)
            {
                if (NPC.velocity.Y < 0f)
                {
                    NPC.velocity.Y = NPC.velocity.Y * 0.98f;
                }
                NPC.velocity.Y = NPC.velocity.Y + 0.1f;
                if (NPC.velocity.Y < -2f)
                {
                    NPC.velocity.Y = -2f;
                }
            }
            if (NPC.position.X + NPC.width / 2 > Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 + 100f)
            {
                if (NPC.velocity.X > 0f)
                {
                    NPC.velocity.X = NPC.velocity.X * 0.98f;
                }
                NPC.velocity.X = NPC.velocity.X - 0.1f;
                if (NPC.velocity.X > 8f)
                {
                    NPC.velocity.X = 8f;
                }
            }
            if (NPC.position.X + NPC.width / 2 >= Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 - 100f)
            {
                return;
            }
            if (NPC.velocity.X < 0f)
            {
                NPC.velocity.X = NPC.velocity.X * 0.98f;
            }
            NPC.velocity.X = NPC.velocity.X + 0.1f;
            if (NPC.velocity.X < -8f)
            {
                NPC.velocity.X = -8f;
                return;
            }
            return;
        }
        else
        {
            if (NPC.ai[1] == 1f)
            {
                NPC.defense *= 2;
                NPC.damage *= 2;
                NPC.ai[2] += 1f;
                if (NPC.ai[2] == 2f)
                {
                    SoundEngine.PlaySound(SoundID.Roar, (int)NPC.position.X, (int)NPC.position.Y, 0);
                }
                if (NPC.ai[2] >= 400f)
                {
                    NPC.ai[2] = 0f;
                    NPC.ai[1] = 0f;
                }
                NPC.rotation += NPC.direction * 0.3f;
                var vector56 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
                float num575 = Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 - vector56.X;
                float num576 = Main.player[NPC.target].position.Y + Main.player[NPC.target].height / 2 - vector56.Y;
                float num577 = (float)Math.Sqrt(num575 * num575 + num576 * num576);
                num577 = 2f / num577;
                NPC.velocity.X = num575 * num577;
                NPC.velocity.Y = num576 * num577;
                return;
            }
            if (NPC.ai[1] == 2f)
            {
                NPC.damage = 1000;
                NPC.defense = 9999;
                NPC.rotation += NPC.direction * 0.3f;
                var vector57 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
                float num578 = Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 - vector57.X;
                float num579 = Main.player[NPC.target].position.Y + Main.player[NPC.target].height / 2 - vector57.Y;
                float num580 = (float)Math.Sqrt(num578 * num578 + num579 * num579);
                num580 = 8f / num580;
                NPC.velocity.X = num578 * num580;
                NPC.velocity.Y = num579 * num580;
                return;
            }
            if (NPC.ai[1] != 3f)
            {
                return;
            }
            NPC.velocity.Y = NPC.velocity.Y + 0.1f;
            if (NPC.velocity.Y < 0f)
            {
                NPC.velocity.Y = NPC.velocity.Y * 0.95f;
            }
            NPC.velocity.X = NPC.velocity.X * 0.95f;
            if (NPC.timeLeft > 500)
            {
                NPC.timeLeft = 500;
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
            Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType<OblivionTrophy>(), 1, false, 0, false);
        }
        if (Main.expertMode)
        {
            NPC.DropBossBags();
        }
        else
        {
            if (Main.rand.Next(4) == 0)
            {
                Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType<CurseofOblivion>(), 1, false, 0, false);
            }
            Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType<Items.Tools.AccelerationDrill>(), 1, false, -2, false);
            Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType<SoulofTorture>(), Main.rand.Next(60, 121), false, 0, false);
            if (Main.rand.Next(5) > 0)
            {
                Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType<VictoryPiece>(), 1, false, 0, false);
            }
            else
            {
                Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType<VictoryPiece>(), 2, false, 0, false);
            }
            if (Main.rand.Next(20) == 0)
            {
                Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType<LuckyPapyrus>(), 1, false, -1, false);
            }
            Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType<OblivionOre>(), Main.rand.Next(100, 201), false, 0, false);
        }

        if (!ExxoAvalonOriginsWorld.oblivionDead)
        {
            ExxoAvalonOriginsWorld.oblivionDead = true;
            ModContent.GetInstance<ExxoAvalonOriginsWorld>().GenerateCrystalMines();
        }
    }

    public override void FindFrame(int frameHeight)
    {
        if (NPC.ai[1] == 0f)
        {
            NPC.frameCounter += 1.0;
            if (NPC.frameCounter >= 12.0)
            {
                NPC.frameCounter = 0.0;
                NPC.frame.Y = NPC.frame.Y + frameHeight;
                if (NPC.frame.Y / frameHeight >= 2)
                {
                    NPC.frame.Y = 0;
                }
            }
        }
        else
        {
            NPC.frameCounter = 0.0;
            NPC.frame.Y = frameHeight * 2;
        }
    }

    public override void HitEffect(int hitDirection, double damage)
    {
        if (NPC.life <= 0)
        {
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("OblivionTop"), 1f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("OblivionMouth"), 1f);
        }
    }
}
