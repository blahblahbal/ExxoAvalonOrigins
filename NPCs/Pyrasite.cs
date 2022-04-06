using ExxoAvalonOrigins.Items.Material;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;

namespace ExxoAvalonOrigins.NPCs;

public class PyrasiteHead : PyrasiteWorm
{
    public override string Texture => "ExxoAvalonOrigins/NPCs/PyrasiteHead";

    public override void SetDefaults()
    {
        NPC.damage = 15;
        NPC.netAlways = true;
        NPC.noTileCollide = true;
        NPC.lifeMax = 70;
        NPC.defense = 0;
        NPC.noGravity = true;
        NPC.width = 26;
        NPC.aiStyle = -1;
        NPC.behindTiles = true;
        NPC.value = 500f;
        NPC.height = 26;
        NPC.knockBackResist = 0f;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
        Banner = NPC.type;
        BannerItem = ModContent.ItemType<Items.Banners.PyrasiteBanner>();
    }
    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.55f);
        NPC.damage = (int)(NPC.damage * 0.8f);
    }
    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        if (spawnInfo.player.Avalon().ZoneContagion && !spawnInfo.player.InPillarZone() && spawnInfo.player.ZoneOverworldHeight)
            return (spawnInfo.player.Avalon().ZoneContagion && !spawnInfo.player.InPillarZone() && spawnInfo.player.ZoneOverworldHeight) ? 0.5f : 0f;
        return 0f;
    }
    public override void HitEffect(int hitDirection, double damage)
    {
        if (NPC.life <= 0)
        {
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("PyrasiteHead").Type, 1f);
        }
    }
    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<YuckyBit>()));
    }
    public override void Init()
    {
        base.Init();
        head = true;
        minLength = 10;
        maxLength = 15;
    }
}

public class PyrasiteBody : PyrasiteWorm
{
    public override string Texture => "ExxoAvalonOrigins/NPCs/PyrasiteBody";

    public override void SetDefaults()
    {
        NPC.damage = 8;
        NPC.netAlways = true;
        NPC.noTileCollide = true;
        NPC.lifeMax = 70;
        NPC.defense = 4;
        NPC.noGravity = true;
        NPC.width = 26;
        NPC.aiStyle = -1;
        NPC.behindTiles = true;
        NPC.value = 500f;
        NPC.height = 26;
        NPC.knockBackResist = 0f;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
    }
    public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
    {
        return false;
    }
    public override void HitEffect(int hitDirection, double damage)
    {
        if (NPC.life <= 0)
        {
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("PyrasiteBody").Type, 1f);
        }
    }

}

public class PyrasiteTail : PyrasiteWorm
{
    public override string Texture => "ExxoAvalonOrigins/NPCs/PyrasiteTail";

    public override void SetDefaults()
    {
        NPC.damage = 8;
        NPC.netAlways = true;
        NPC.noTileCollide = true;
        NPC.lifeMax = 70;
        NPC.defense = 6;
        NPC.noGravity = true;
        NPC.width = 26;
        NPC.aiStyle = -1;
        NPC.behindTiles = true;
        NPC.value = 500f;
        NPC.height = 26;
        NPC.knockBackResist = 0f;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
    }

    public override void HitEffect(int hitDirection, double damage)
    {
        if (NPC.life <= 0)
        {
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("PyrasiteTail").Type, 1f);
        }
    }
    public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
    {
        return false;
    }
    public override void Init()
    {
        base.Init();
        tail = true;
    }
}
public abstract class PyrasiteWorm : Worm
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Pyrasite");
    }

    public override void Init()
    {
        minLength = 10;
        maxLength = 15;
        tailType = ModContent.NPCType<PyrasiteTail>();
        bodyType = ModContent.NPCType<PyrasiteBody>();
        headType = ModContent.NPCType<PyrasiteHead>();
        speed = 5.5f;
        turnSpeed = 0.045f;
    }
}