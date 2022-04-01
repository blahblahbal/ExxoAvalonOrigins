using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs
{
    public class DesertScorpion : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Desert Scorpion");
            Main.npcFrameCount[NPC.type] = 20;
        }

        public override void SetDefaults()
        {
            NPC.damage = 65;
            NPC.scale = 1f;
            NPC.noTileCollide = false;
            NPC.lifeMax = 570;
            NPC.defense = 46;
            NPC.noGravity = false;
            NPC.width = 18;
            NPC.aiStyle = 3;
            NPC.value = 900f;
            NPC.height = 40;
            NPC.knockBackResist = 0.1f;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.buffImmune[BuffID.Poisoned] = true;
        }

        public override void NPCLoot()
        {
            if (Main.rand.Next(9) == 0)
            {
                Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ItemID.Stinger, 1, false, 0, false);
            }
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.35f);
            NPC.damage = (int)(NPC.damage * 0.35f);
        }
        public override void FindFrame(int frameHeight)
        {
            if (NPC.velocity.Y == 0f)
            {
                if (NPC.direction == 1)
                {
                    NPC.spriteDirection = 1;
                }
                if (NPC.direction == -1)
                {
                    NPC.spriteDirection = -1;
                }
                if (NPC.ai[2] > 0f)
                {
                    NPC.spriteDirection = NPC.direction;
                    NPC.frame.Y = frameHeight * (int)NPC.ai[2];
                    NPC.frameCounter = 0.0;
                }
                else
                {
                    if (NPC.frame.Y < frameHeight * 6)
                    {
                        NPC.frame.Y = frameHeight * 6;
                    }
                    NPC.frameCounter += Math.Abs(NPC.velocity.X) * 2f;
                    NPC.frameCounter += NPC.velocity.X;
                    if (NPC.frameCounter > 6.0)
                    {
                        NPC.frame.Y = NPC.frame.Y + frameHeight;
                        NPC.frameCounter = 0.0;
                    }
                    if (NPC.frame.Y / frameHeight >= Main.npcFrameCount[NPC.type])
                    {
                        NPC.frame.Y = frameHeight * 6;
                    }
                }
            }
            else
            {
                NPC.frameCounter = 0.0;
                NPC.frame.Y = 0;
            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (NPC.life <= 0)
            {
                Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("Gores/DesertScorpionBody"), 1f);
                for (var things = 0; things < 8; things++)
                {
                    Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("Gores/DesertScorpionLeg"), 1f);
                }
                Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("Gores/DesertScorpionClaw"), 1f);
                Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("Gores/DesertScorpionClaw"), 1f);
                Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("Gores/DesertScorpionSting"), 1f);
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.player.ZoneDesert && !spawnInfo.player.InPillarZone() && Main.hardMode ? 0.05f * ExxoAvalonOriginsGlobalNPC.endoSpawnRate : 0f;
        }
    }
}
