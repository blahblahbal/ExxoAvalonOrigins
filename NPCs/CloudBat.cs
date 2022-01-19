﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs
{
    public class CloudBat : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cloud Bat");
            Main.npcFrameCount[npc.type] = 5;
        }

        public override void SetDefaults()
        {
            npc.damage = 80;
            npc.lifeMax = 1670;
            npc.defense = 35;
            npc.width = 10;
            npc.aiStyle = 14;
            npc.scale = 1.4f;
            npc.value = 10000f;
            npc.knockBackResist = 0.05f;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath4;
            npc.height = 12;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.CloudBatBanner>();
            animationType = 49;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.65f);
            npc.damage = (int)(npc.damage * 0.45f);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.player.Avalon().ZoneSkyFortress ? 0.3f * ExxoAvalonOriginsGlobalNPC.endoSpawnRate : 0f;
        }
    }
}
