using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace ExxoAvalonOrigins.NPCs;

public class VorazylcumMiteDigger : VorazylcumMiteDiggerWorm
{
    public override string Texture => "ExxoAvalonOrigins/NPCs/VorazylcumMiteDigger";

    public override void SetDefaults()
    {
        NPC.width = 14;
        NPC.height = 14;
        NPC.aiStyle = 6;
        NPC.netAlways = true;
        NPC.damage = 80;
        NPC.defense = 6;
        NPC.lifeMax = 1450;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
        NPC.noGravity = true;
        NPC.noTileCollide = true;
        NPC.knockBackResist = 0f;
        NPC.behindTiles = true;
    }
    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.55f);
        NPC.damage = (int)(NPC.damage * 0.8f);
    }
    public override void HitEffect(int hitDirection, double damage)
    {
        if (NPC.life <= 0)
        {
            Gore.NewGore(NPC.Center, NPC.velocity, Mod.Find<ModGore>("VorazylcumMiteGore1").Type, NPC.scale);
            Gore.NewGore(NPC.Center, NPC.velocity, Mod.Find<ModGore>("VorazylcumMiteGore2").Type, NPC.scale);
        }
    }
    public override void CustomBehavior()
    {
        int xpos = NPC.position.ToTileCoordinates().X;
        int ypos = NPC.position.ToTileCoordinates().Y;

        if (NPC.ai[2] <= 300) NPC.ai[2]++;
        if (NPC.ai[2] > 300)
        {
            NPC.ai[3] = 1;
        }

        if (!Main.tile[xpos, ypos].HasTile && Main.tile[xpos, ypos + 1].HasTile && NPC.ai[3] == 1)
        {
            NPC.Transform(ModContent.NPCType<VorazylcumMite>());
            NPC.ai[3] = 0;
            NPC.ai[2] = 0;
        }

    }
    public override void Init()
    {
        base.Init();
        head = true;
    }
}

public abstract class VorazylcumMiteDiggerWorm : SingleSegmentWorm
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Vorazylcum Mite");
        NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData
        {
            SpecificallyImmuneTo = new int[]
            {
                BuffID.Confused
            }
        };
        NPCID.Sets.DebuffImmunitySets[Type] = debuffData;
    }

    public override void Init()
    {
        headType = ModContent.NPCType<VorazylcumMiteDigger>();
        speed = 5.5f;
        turnSpeed = 0.045f;
    }
}
