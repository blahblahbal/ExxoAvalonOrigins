﻿using System;
using ExxoAvalonOrigins.Items.Accessories;
using ExxoAvalonOrigins.Items.Material;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs
{
    public class Mime : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mime");
            Main.npcFrameCount[NPC.type] = 3;
        }

        public override void SetDefaults()
        {
            NPC.damage = 75;
            NPC.scale = 1.4f;
            NPC.noTileCollide = false;
            NPC.lifeMax = 630;
            NPC.defense = 46;
            NPC.noGravity = false;
            NPC.width = 18;
            NPC.aiStyle = 3;
            NPC.value = 1500f;
            NPC.height = 40;
            NPC.knockBackResist = 0.15f;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<Items.Banners.MimeBanner>();
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.55f);
            NPC.damage = (int)(NPC.damage * 0.75f);
        }
        public override void NPCLoot()
        {
            if (Main.rand.Next(3) == 0)
            {
                Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType<SoulofTime>(), Main.rand.Next(5) + 1, false, 0, false);
            }
            if (Main.rand.Next(100) == 0)
            {
                Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType<ManaCompromise>(), 1, false, -2, false);
            }
            if (Main.rand.Next(8) == 0)
            {
                Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType<ConfusionTalisman>(), 1, false, -2, false);
            }
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

        public override void HitEffect(int hitDirection, double damage)
        {
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("Gore/MimeHead"), 0.9f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("Gore/Girder1"), 0.9f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("Gore/Girder1"), 0.9f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("Gore/Girder2"), 0.9f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("Gore/Girder2"), 0.9f);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.player.ZoneRockLayerHeight && spawnInfo.player.ZoneHallow && Main.hardMode ? 0.14f : 0f;
        }
    }
}
