using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using Terraria.DataStructures;

namespace ExxoAvalonOrigins.NPCs;

public class CursedScepter : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Cursed Scepter");
        Main.npcFrameCount[NPC.type] = 6;
        NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData
        {
            SpecificallyImmuneTo = new int[]
            {
                BuffID.Confused
            }
        };
        NPCID.Sets.DebuffImmunitySets[Type] = debuffData;
    }
    public override void SetDefaults()
    {
        NPC.damage = 61;
        NPC.lifeMax = 226;
        NPC.defense = 18;
        NPC.lavaImmune = true;
        NPC.width = 18;
        NPC.aiStyle = 23;
        NPC.value = 1000f;
        NPC.scale = 1.3f;
        NPC.height = 40;
        NPC.knockBackResist = 0.3f;
        NPC.HitSound = SoundID.NPCHit4;
        NPC.DeathSound = SoundID.NPCDeath6;
        Banner = NPC.type;
        BannerItem = ModContent.ItemType<Items.Banners.CursedScepterBanner>();
    }
    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.75f);
        NPC.damage = (int)(NPC.damage * 0.5f);
    }
    public override void AI()
    {
        Lighting.AddLight((int)((NPC.position.X + NPC.width / 2) / 16f), (int)((NPC.position.Y + NPC.height / 2) / 16f), 0.55f, 0.99f, 0.28f);
    }
    public override void FindFrame(int frameHeight)
    {
        if (NPC.ai[0] == 2f)
        {
            NPC.frameCounter = 0.0;
            NPC.frame.Y = 0;
        }
        else
        {
            NPC.frameCounter += 1.0;
            if (NPC.frameCounter >= 4.0)
            {
                NPC.frameCounter = 0.0;
                NPC.frame.Y = NPC.frame.Y + frameHeight;
                if (NPC.frame.Y / frameHeight >= Main.npcFrameCount[NPC.type])
                {
                    NPC.frame.Y = 0;
                }
            }
        }
    }
    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        return Main.hardMode && spawnInfo.player.ZoneDungeon ? 0.1f * ExxoAvalonOriginsGlobalNPC.endoSpawnRate : 0f;
    }
    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(ItemDropRule.Common(ItemID.Nazar, 75));
    }
}
