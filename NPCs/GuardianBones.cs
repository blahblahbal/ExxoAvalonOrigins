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
            Main.npcFrameCount[NPC.type] = 15;
        }

        public override void SetDefaults()
        {
            NPC.damage = 140;
            NPC.scale = 1f;
            NPC.lifeMax = 6000;
            NPC.defense = 90;
            NPC.width = 31;
            NPC.aiStyle = 3;
            NPC.npcSlots = 4f;
            NPC.value = 10000f;
            NPC.timeLeft = 750;
            NPC.height = 68;
            NPC.knockBackResist = 0.2f;
            NPC.HitSound = SoundID.NPCHit2;
            NPC.DeathSound = SoundID.NPCDeath2;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.55f);
            NPC.damage = (int)(NPC.damage * 0.44f);
        }
        public override void NPCLoot()
        {
            if (Main.rand.Next(20) == 0)
            {
                Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType<Items.Accessories.AegisofAges>(), 1, false, -2, false);
            }
            if (Main.rand.Next(10) == 0)
            {
                Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType<Phantoplasm>(), 1, false, 0, false);
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.player.ZoneDungeon && Main.hardMode && ExxoAvalonOriginsWorld.stoppedArmageddon && ModContent.GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode ? 0.083f * ExxoAvalonOriginsGlobalNPC.endoSpawnRate : 0f;
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
                if (NPC.velocity.X == 0f)
                {
                    if (NPC.type == NPCID.PossessedArmor)
                    {
                        NPC.frame.Y = frameHeight;
                        NPC.frameCounter = 0.0;
                    }
                    else
                    {
                        NPC.frame.Y = 0;
                        NPC.frameCounter = 0.0;
                    }
                }
                else
                {
                    NPC.frameCounter += Math.Abs(NPC.velocity.X) * 2f;
                    NPC.frameCounter += 1.0;
                    if (NPC.frameCounter > 6.0)
                    {
                        NPC.frame.Y = NPC.frame.Y + frameHeight;
                        NPC.frameCounter = 0.0;
                    }
                    if (NPC.frame.Y / frameHeight >= Main.npcFrameCount[NPC.type])
                    {
                        NPC.frame.Y = frameHeight * 2;
                    }
                }
            }
            else
            {
                NPC.frameCounter = 0.0;
                NPC.frame.Y = 0;
            }
        }
    }
}
