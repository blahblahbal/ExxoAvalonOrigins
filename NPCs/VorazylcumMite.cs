using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace ExxoAvalonOrigins.NPCs;

public class VorazylcumMite : ModNPC
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
    public override void SetDefaults()
    {
        NPC.damage = 77;
        NPC.lifeMax = 1300;
        NPC.defense = 6;
        NPC.width = 18;
        NPC.aiStyle = -1;
        NPC.value = 10000f;
        NPC.height = 40;
        NPC.knockBackResist = 0f;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
        NPC.lavaImmune = true;
    }
    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.55f);
        NPC.damage = (int)(NPC.damage * 0.5f);
    }
    public override void OnHitPlayer(Player target, int damage, bool crit)
    {
        target.AddBuff(ModContent.BuffType<Buffs.VorazylcumThorned>(), 10 * 60);
    }
    public override void HitEffect(int hitDirection, double damage)
    {
        if (NPC.life <= 0)
        {
            Gore.NewGore(NPC.Center, NPC.velocity, Mod.Find<ModGore>("VorazylcumMiteGore1").Type, NPC.scale);
            Gore.NewGore(NPC.Center, NPC.velocity, Mod.Find<ModGore>("VorazylcumMiteGore2").Type, NPC.scale);
        }
    }
    public override void AI()
    {
        NPC.spriteDirection = NPC.direction;
        NPC.TargetClosest(true);
        if (NPC.ai[1] < 1200f)
        {
            NPC.ai[1]++;
        }
        if (NPC.ai[1] == 1200f && Main.netMode != 1)
        {
            NPC.position.Y = NPC.position.Y + 16f;
            NPC.Transform(ModContent.NPCType<VorazylcumMiteDigger>());
            NPC.netUpdate = true;
            return;
        }
        if (NPC.velocity.Y == 0f)
        {
            if (NPC.ai[0] == 1f)
            {
                if (NPC.direction == 0)
                {
                    NPC.TargetClosest(true);
                }
                if (NPC.collideX)
                {
                    NPC.direction *= -1;
                }
                NPC.velocity.X = 0.2f * (float)NPC.direction;
                if (NPC.type == ModContent.NPCType<VorazylcumMite>())
                {
                    NPC.velocity.X = NPC.velocity.X * 3f;
                }
            }
            else
            {
                NPC.velocity.X = 0f;
            }
            if (Main.netMode != 1)
            {
                NPC.localAI[1] -= 1f;
                if (NPC.localAI[1] <= 0f)
                {
                    if (NPC.ai[0] == 1f)
                    {
                        NPC.ai[0] = 0f;
                        NPC.localAI[1] = Main.rand.Next(300, 900);
                    }
                    else
                    {
                        NPC.ai[0] = 1f;
                        NPC.localAI[1] = Main.rand.Next(600, 1800);
                    }
                    NPC.netUpdate = true;
                }
            }
        }

    }
}
