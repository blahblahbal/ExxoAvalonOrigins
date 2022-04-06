using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs;

public class VampireHarpy : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Vampire Harpy");
        Main.npcFrameCount[NPC.type] = 4;
    }

    public override void SetDefaults()
    {
        NPC.damage = 110;
        NPC.scale = 1.3f;
        NPC.lifeMax = 953;
        NPC.defense = 25;
        NPC.noGravity = true;
        NPC.alpha = 50;
        NPC.width = 38;
        NPC.aiStyle = 14;
        NPC.npcSlots = 2f;
        NPC.value = 10000f;
        NPC.timeLeft = 750;
        NPC.height = 34;
        NPC.knockBackResist = 0.1f;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
        NPC.buffImmune[BuffID.Confused] = true;
        NPC.buffImmune[BuffID.OnFire] = true;
        NPC.buffImmune[BuffID.CursedInferno] = true;
        Banner = NPC.type;
        BannerItem = ModContent.ItemType<Items.Banners.VampireHarpyBanner>();
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
        NPC.rotation = NPC.velocity.X * 0.1f;
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

    public override void HitEffect(int hitDirection, double damage)
    {
        if (NPC.life <= 0)
        {
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("VampireHarpyHead").Type, 1f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("VampireHarpyWing").Type, 1f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("VampireHarpyHead").Type, 1f);
        }
    }
}