using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;

namespace ExxoAvalonOrigins.NPCs;

public class EyeBones : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Eye Bones");
        Main.npcFrameCount[NPC.type] = 2;
    }

    public override void SetDefaults()
    {
        NPC.damage = 85;
        NPC.lifeMax = 700;
        NPC.defense = 20;
        NPC.width = 30;
        NPC.aiStyle = 2;
        NPC.value = 10000f;
        NPC.height = 32;
        NPC.knockBackResist = 0.5f;
        NPC.HitSound = SoundID.NPCHit2;
        NPC.DeathSound = SoundID.NPCDeath2;
        NPC.buffImmune[BuffID.Confused] = true;
        Banner = NPC.type;
        BannerItem = ModContent.ItemType<Items.Banners.EyeBonesBanner>();
    }

    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.55f);
        NPC.damage = (int)(NPC.damage * 0.5f);
    }
    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(ItemDropRule.Common(ItemID.Bone, 1, 0, 3));
    }
    public override void FindFrame(int frameHeight)
    {
        if (NPC.velocity.X > 0f)
        {
            NPC.spriteDirection = 1;
            NPC.rotation = (float)Math.Atan2(NPC.velocity.Y, NPC.velocity.X);
        }
        if (NPC.velocity.X < 0f)
        {
            NPC.spriteDirection = -1;
            NPC.rotation = (float)Math.Atan2(NPC.velocity.Y, NPC.velocity.X) + 3.14f;
        }
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

    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        return spawnInfo.player.ZoneRockLayerHeight && !spawnInfo.player.ZoneDungeon && Main.hardMode && ModContent.GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode ? 0.1f * ExxoAvalonOriginsGlobalNPC.endoSpawnRate : 0f;
    }
}