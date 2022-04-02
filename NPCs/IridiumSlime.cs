﻿using ExxoAvalonOrigins.Items.Placeable.Tile;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;

namespace ExxoAvalonOrigins.NPCs
{
    public class IridiumSlime : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Iridium Slime");
            Main.npcFrameCount[NPC.type] = 2;
        }

        public override void SetDefaults()
        {
            NPC.damage = 36;
            NPC.lifeMax = 543;
            NPC.defense = 5;
            NPC.width = 36;
            NPC.aiStyle = 1;
            NPC.value = 1000f;
            NPC.knockBackResist = 0.4f;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.height = 24;
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<Items.Banners.IridiumSlimeBanner>();
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<IridiumOre>(), 1, 10, 16));
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.65f);
            NPC.damage = (int)(NPC.damage * 0.45f);
        }
        public override void FindFrame(int frameHeight)
        {
            var num2 = 0;
            if (NPC.aiAction == 0)
            {
                if (NPC.velocity.Y < 0f)
                {
                    num2 = 2;
                }
                else if (NPC.velocity.Y > 0f)
                {
                    num2 = 3;
                }
                else if (NPC.velocity.X != 0f)
                {
                    num2 = 1;
                }
                else
                {
                    num2 = 0;
                }
            }
            else if (NPC.aiAction == 1)
            {
                num2 = 4;
            }
            NPC.frameCounter += 1.0;
            if (num2 > 0)
            {
                NPC.frameCounter += 1.0;
            }
            if (num2 == 4)
            {
                NPC.frameCounter += 1.0;
            }
            if (NPC.frameCounter >= 8.0)
            {
                NPC.frame.Y = NPC.frame.Y + frameHeight;
                NPC.frameCounter = 0.0;
            }
            if (NPC.frame.Y >= frameHeight * Main.npcFrameCount[NPC.type])
            {
                NPC.frame.Y = 0;
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.player.ZoneRockLayerHeight && !spawnInfo.player.ZoneDungeon && (Main.hardMode || ExxoAvalonOriginsWorld.rhodiumOre == ExxoAvalonOriginsWorld.RhodiumVariant.iridium) ? 0.00526f * ExxoAvalonOriginsGlobalNPC.endoSpawnRate : 0f;
        }
    }
}
