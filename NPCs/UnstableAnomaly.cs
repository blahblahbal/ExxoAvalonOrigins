using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace ExxoAvalonOrigins.NPCs;

public class UnstableAnomaly : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Unstable Anomaly");
        Main.npcFrameCount[NPC.type] = 8;
        NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData
        {
            SpecificallyImmuneTo = new int[]
            {
                BuffID.Confused,
                BuffID.CursedInferno,
                BuffID.OnFire
            }
        };
        NPCID.Sets.DebuffImmunitySets[Type] = debuffData;
    }

    public override void SetDefaults()
    {
        NPC.damage = 108;
        NPC.scale = 1f;
        NPC.lifeMax = 2000;
        NPC.defense = 37;
        NPC.width = 32;
        NPC.aiStyle = 22;
        NPC.value = Item.buyPrice(0, 1, 0, 0);
        NPC.height = 24;
        NPC.noTileCollide = NPC.noGravity = true;
        NPC.knockBackResist = 0.3f;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath6;
        Banner = NPC.type;
        BannerItem = ModContent.ItemType<Items.Banners.UnstableAnomalyBanner>();
    }

    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.55f);
        NPC.damage = (int)(NPC.damage * 0.65f);
    }
    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        if (spawnInfo.player.Avalon().ZoneDarkMatter && !spawnInfo.player.InPillarZone() && ModContent.GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode)
        {
            return 1f;
        }
        return 0f;
    }

    public override void FindFrame(int frameHeight)
    {
        if (NPC.velocity.X > 0f)
        {
            NPC.spriteDirection = 1;
        }
        if (NPC.velocity.X < 0f)
        {
            NPC.spriteDirection = -1;
        }
        NPC.rotation = NPC.velocity.X * 0.15f;
        NPC.frameCounter += 1.0;
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

    public override void HitEffect(int hitDirection, double damage)
    {
        if (NPC.life <= 0)
        {
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("UnstableAnomalyTable").Type, 1f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("UnstableAnomalyChair").Type, 1f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("UnstableAnomalyChair").Type, 1f);
            for (int i = 0; i < 30; i++)
            {
                int num890 = Dust.NewDust(NPC.position, NPC.width, NPC.height, ModContent.DustType<Dusts.SoulofLight>(), 0f, 0f, 0, default(Color), 1f);
                Main.dust[num890].velocity *= 5f;
                Main.dust[num890].scale = 1f;
                Main.dust[num890].noGravity = true;
                Main.dust[num890].fadeIn = 2f;
            }
        }
    }
}
