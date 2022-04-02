using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace ExxoAvalonOrigins.NPCs;

public class Pigron : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Pigron");
        Main.npcFrameCount[NPC.type] = 14;
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
        NPC.damage = 70;
        NPC.lifeMax = 230;
        NPC.defense = 16;
        NPC.width = 44;
        NPC.aiStyle = 2;
        NPC.value = 2000f;
        NPC.height = 36;
        NPC.knockBackResist = 0.5f;
        NPC.HitSound = SoundID.NPCHit27;
        NPC.DeathSound = SoundID.NPCDeath30;
    }
    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.55f * bossLifeScale);
        NPC.damage = (int)(NPC.damage * 0.8f);
    }
    public override void FindFrame(int frameHeight)
    {
        NPC.spriteDirection = NPC.direction;
        NPC.frameCounter += 1.0;
        if (NPC.frameCounter >= 4.0)
        {
            NPC.frame.Y = NPC.frame.Y + frameHeight;
            NPC.frameCounter = 0.0;
        }
        if (NPC.frame.Y >= frameHeight * 14)
        {
            NPC.frame.Y = 0;
        }
    }
}
