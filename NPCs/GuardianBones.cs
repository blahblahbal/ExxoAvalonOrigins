using System;
using ExxoAvalonOrigins.Items.Placeable.Tile;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs
{
    public class GuardianBones : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Guardian Bones");
            Main.npcFrameCount[npc.type] = 15;
        }

        public override void SetDefaults()
        {
            npc.damage = 140;
            npc.scale = 1f;
            npc.lifeMax = 6000;
            npc.defense = 90;
            npc.width = 31;
            npc.aiStyle = 3;
            npc.npcSlots = 4f;
            npc.value = 10000f;
            npc.timeLeft = 750;
            npc.height = 68;
            npc.knockBackResist = 0.2f;
            npc.HitSound = SoundID.NPCHit2;
            npc.DeathSound = SoundID.NPCDeath2;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.55f);
            npc.damage = (int)(npc.damage * 0.44f);
        }
        public override void NPCLoot()
        {
            if (Main.rand.Next(20) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Accessories.AegisofAges>(), 1, false, -2, false);
            }
            if (Main.rand.Next(10) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Phantoplasm>(), 1, false, 0, false);
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.player.ZoneDungeon && Main.hardMode && ExxoAvalonOriginsWorld.stoppedArmageddon && ModContent.GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode ? 0.083f * ExxoAvalonOriginsGlobalNPC.endoSpawnRate : 0f;
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
                if (npc.velocity.X == 0f)
                {
                    if (npc.type == NPCID.PossessedArmor)
                    {
                        npc.frame.Y = frameHeight;
                        npc.frameCounter = 0.0;
                    }
                    else
                    {
                        npc.frame.Y = 0;
                        npc.frameCounter = 0.0;
                    }
                }
                else
                {
                    npc.frameCounter += Math.Abs(npc.velocity.X) * 2f;
                    npc.frameCounter += 1.0;
                    if (npc.frameCounter > 6.0)
                    {
                        npc.frame.Y = npc.frame.Y + frameHeight;
                        npc.frameCounter = 0.0;
                    }
                    if (npc.frame.Y / frameHeight >= Main.npcFrameCount[npc.type])
                    {
                        npc.frame.Y = frameHeight * 2;
                    }
                }
            }
            else
            {
                npc.frameCounter = 0.0;
                npc.frame.Y = 0;
            }
        }
    }
}
