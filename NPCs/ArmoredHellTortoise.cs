using ExxoAvalonOrigins.Items.Material;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace ExxoAvalonOrigins.NPCs;

public class ArmoredHellTortoise : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Armored Hell Tortoise");
        Main.npcFrameCount[NPC.type] = 8;
        NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData
        {
            SpecificallyImmuneTo = new int[]
            {
                BuffID.Confused,
                BuffID.OnFire
            }
        };
        NPCID.Sets.DebuffImmunitySets[Type] = debuffData;
    }

    public override void SetDefaults()
    {
        NPC.damage = 130;
        NPC.lifeMax = 1600;
        NPC.defense = 30;
        NPC.lavaImmune = true;
        NPC.noGravity = false;
        NPC.width = 46;
        NPC.aiStyle = 39;
        NPC.npcSlots = 2f;
        NPC.value = 10000f;
        NPC.height = 32;
        NPC.knockBackResist = 0.2f;
        NPC.HitSound = SoundID.NPCHit24;
        NPC.DeathSound = SoundID.NPCDeath27;
        Banner = NPC.type;
        BannerItem = ModContent.ItemType<Items.Banners.ArmoredHellTortoiseBanner>();
    }
    public override void ModifyNPCLoot(NPCLoot loot)
    {
        loot.Add(ItemDropRule.Common(ModContent.ItemType<SpikedBlastShell>(), 9));
    }

    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.35f);
        NPC.damage = (int)(NPC.damage * 0.5f);
    }
    public override void HitEffect(int hitDirection, double damage)
    {
        if (NPC.life <= 0)
        {
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("ArmoredHellTortoiseGore1").Type, 0.9f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("ArmoredHellTortoiseGore2").Type, 0.9f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("ArmoredHellTortoiseGore3").Type, 0.9f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("ArmoredHellTortoiseGore3").Type, 0.9f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("ArmoredHellTortoiseGore3").Type, 0.9f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("ArmoredHellTortoiseGore3").Type, 0.9f);
        }
    }
    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        return Main.hardMode && ModContent.GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode && spawnInfo.player.ZoneUnderworldHeight ? 0.125f * ExxoAvalonOriginsGlobalNPC.endoSpawnRate : 0f;
    }
}
