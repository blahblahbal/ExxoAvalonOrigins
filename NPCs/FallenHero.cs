using System;
using ExxoAvalonOrigins.Items.Armor;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs
{
    public class FallenHero : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fallen Hero");
            Main.npcFrameCount[NPC.type] = 3;
        }

        public override void SetDefaults()
        {
            NPC.damage = 30;
            NPC.lifeMax = 180;
            NPC.defense = 6;
            NPC.width = 18;
            NPC.aiStyle = 3;
            NPC.value = 10000f;
            NPC.height = 40;
            NPC.knockBackResist = 0.5f;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath2;
            NPC.buffImmune[BuffID.Confused] = true;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.55f);
            NPC.damage = (int)(NPC.damage * 0.5f);
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
            }
            if (NPC.velocity.Y != 0f || (NPC.direction == -1 && NPC.velocity.X > 0f) || (NPC.direction == 1 && NPC.velocity.X < 0f))
            {
                NPC.frameCounter = 0.0;
                NPC.frame.Y = frameHeight * 2;
            }
            else if (NPC.velocity.X == 0f)
            {
                NPC.frameCounter = 0.0;
                NPC.frame.Y = 0;
            }
            else
            {
                NPC.frameCounter += Math.Abs(NPC.velocity.X);
                if (NPC.frameCounter < 8.0)
                {
                    NPC.frame.Y = 0;
                }
                else if (NPC.frameCounter < 16.0)
                {
                    NPC.frame.Y = frameHeight;
                }
                else if (NPC.frameCounter < 24.0)
                {
                    NPC.frame.Y = frameHeight * 2;
                }
                else if (NPC.frameCounter < 32.0)
                {
                    NPC.frame.Y = frameHeight;
                }
                else
                {
                    NPC.frameCounter = 0.0;
                }
            }
        }
        public override void NPCLoot()
        {

            if (Main.rand.Next(18) == 0)
            {
                switch (Main.rand.Next(3))
                {
                    case 0:
                        Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType<BloodstainedHelmet>(), 1, false, 0, false);
                        break;
                    case 1:
                        Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType<Items.Vanity.BloodstainedChestplate>(), 1, false, 0, false);
                        break;
                    case 2:
                        Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType<Items.Vanity.BloodstainedGreaves>(), 1, false, 0, false);
                        break;
                }
            }
            if (Main.rand.Next(12) == 0)
            {
                Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType<Items.Weapons.Melee.MinersSword>(), 1, false, -1, false);
            }
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (NPC.life <= 0)
            {
                Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("Gores/FallenHeroGore1"), 0.9f);
                Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("Gores/FallenHeroGore2"), 0.9f);
                Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("Gores/FallenHeroGore2"), 0.9f);
                Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("Gores/FallenHeroGore3"), 0.9f);
                Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("Gores/FallenHeroGore3"), 0.9f);
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.player.ZoneOverworldHeight && !spawnInfo.player.InPillarZone() && Main.bloodMoon ? 0.1f * ExxoAvalonOriginsGlobalNPC.endoSpawnRate : 0f;
        }
    }
}
