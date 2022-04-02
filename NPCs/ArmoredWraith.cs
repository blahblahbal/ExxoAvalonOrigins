using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace ExxoAvalonOrigins.NPCs;

public class ArmoredWraith : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Armored Wraith");
        Main.npcFrameCount[NPC.type] = 4;
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
        NPC.damage = 105;
        NPC.netAlways = true;
        NPC.scale = 1f;
        NPC.noTileCollide = true;
        NPC.lifeMax = 1000;
        NPC.defense = 35;
        NPC.noGravity = true;
        NPC.alpha = 50;
        NPC.width = 24;
        NPC.aiStyle = 22;
        NPC.npcSlots = 1f;
        NPC.value = Item.buyPrice(0, 1, 0, 0);
        NPC.timeLeft = 750;
        NPC.height = 44;
        NPC.HitSound = SoundID.NPCHit54;
        NPC.DeathSound = SoundID.NPCDeath52;
        NPC.knockBackResist = 0.1f;
        NPC.buffImmune[BuffID.Confused] = true;
        NPC.buffImmune[BuffID.OnFire] = true;
        NPC.buffImmune[BuffID.CursedInferno] = true;
        Banner = NPC.type;
        BannerItem = ModContent.ItemType<Items.Banners.ArmoredWraithBanner>();
    }
    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.35f);
        NPC.damage = (int)(NPC.damage * 0.5f);
    }
    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        return !Main.dayTime && Main.hardMode && ModContent.GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode ? 0.053f * ExxoAvalonOriginsGlobalNPC.endoSpawnRate : 0f;
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
        NPC.rotation = NPC.velocity.X * 0.1f;
        if (NPC.type == NPCID.Bee || NPC.type == NPCID.BeeSmall)
        {
            NPC.frameCounter += 1.0;
            NPC.rotation = NPC.velocity.X * 0.2f;
        }
        NPC.frameCounter += 1.0;
        if (NPC.frameCounter >= 6.0)
        {
            NPC.frame.Y = NPC.frame.Y + frameHeight;
            NPC.frameCounter = 0.0;
        }
        if (NPC.frame.Y >= frameHeight * Main.npcFrameCount[NPC.type])
        {
            NPC.frame.Y = 0;
        }
    }
}
