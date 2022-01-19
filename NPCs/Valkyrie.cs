using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs
{
    public class Valkyrie : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Valkyrie");
            Main.npcFrameCount[npc.type] = 4;
        }

        public override void SetDefaults()
        {
            npc.damage = 80;
            npc.lifeMax = 2421;
            npc.defense = 35;
            npc.width = 24;
            npc.aiStyle = 14;
            npc.value = 1000f;
            npc.knockBackResist = 0.05f;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.height = 34;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.ValkyrieBanner>();
            animationType = 48;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.65f);
            npc.damage = (int)(npc.damage * 0.45f);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.player.Avalon().ZoneSkyFortress ? 0.26f * ExxoAvalonOriginsGlobalNPC.endoSpawnRate : 0f;
        }
    }
}
