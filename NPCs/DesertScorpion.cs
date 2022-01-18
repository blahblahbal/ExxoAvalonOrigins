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
            Main.npcFrameCount[npc.type] = 20;
        }

        public override void SetDefaults()
        {
            npc.damage = 65;
            npc.scale = 1f;
            npc.noTileCollide = false;
            npc.lifeMax = 570;
            npc.defense = 46;
            npc.noGravity = false;
            npc.width = 18;
            npc.aiStyle = 3;
            npc.value = 900f;
            npc.height = 40;
            npc.knockBackResist = 0.1f;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.buffImmune[BuffID.Poisoned] = true;
        }

        public override void NPCLoot()
        {
            if (Main.rand.Next(9) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Stinger, 1, false, 0, false);
            }
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.35f);
            npc.damage = (int)(npc.damage * 0.35f);
        }
        public override void FindFrame(int frameHeight)
        {
            if (npc.velocity.Y == 0f)
            {
                if (npc.direction == 1)
                {
                    npc.spriteDirection = 1;
                }
                if (npc.direction == -1)
                {
                    npc.spriteDirection = -1;
                }
                if (npc.ai[2] > 0f)
                {
                    npc.spriteDirection = npc.direction;
                    npc.frame.Y = frameHeight * (int)npc.ai[2];
                    npc.frameCounter = 0.0;
                }
                else
                {
                    if (npc.frame.Y < frameHeight * 6)
                    {
                        npc.frame.Y = frameHeight * 6;
                    }
                    npc.frameCounter += Math.Abs(npc.velocity.X) * 2f;
                    npc.frameCounter += npc.velocity.X;
                    if (npc.frameCounter > 6.0)
                    {
                        npc.frame.Y = npc.frame.Y + frameHeight;
                        npc.frameCounter = 0.0;
                    }
                    if (npc.frame.Y / frameHeight >= Main.npcFrameCount[npc.type])
                    {
                        npc.frame.Y = frameHeight * 6;
                    }
                }
            }
            else
            {
                npc.frameCounter = 0.0;
                npc.frame.Y = 0;
            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DesertScorpionBody"), 1f);
                for (var things = 0; things < 8; things++)
                {
                    Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DesertScorpionLeg"), 1f);
                }
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DesertScorpionClaw"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DesertScorpionClaw"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DesertScorpionSting"), 1f);
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.player.ZoneDesert && !spawnInfo.player.InPillarZone() && Main.hardMode ? 0.05f * ExxoAvalonOriginsGlobalNPC.endoSpawnRate : 0f;
        }
    }
}
