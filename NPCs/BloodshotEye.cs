using System;
using ExxoAvalonOrigins.Items.Material;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;

namespace ExxoAvalonOrigins.NPCs;

public class BloodshotEye : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Bloodshot Eye");
        Main.npcFrameCount[NPC.type] = 3;
    }

    public override void SetDefaults()
    {
        NPC.damage = 25;
        NPC.lifeMax = 110;
        NPC.defense = 5;
        NPC.width = 48;
        NPC.aiStyle = 2;
        NPC.value = 150f;
        NPC.height = 34;
        NPC.knockBackResist = 0.4f;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath6;
        NPC.buffImmune[BuffID.Confused] = true;
        Banner = NPC.type;
        BannerItem = ModContent.ItemType<Items.Banners.BloodshotEyeBanner>();
    }
    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(new CommonDrop(ModContent.ItemType<BloodshotLens>(), 100, 1, 1, 45));
        npcLoot.Add(ItemDropRule.Common(ItemID.BlackLens, 33));
    }
    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.65f);
        NPC.damage = (int)(NPC.damage * 0.6f);
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
    public override void HitEffect(int hitDirection, double damage)
    {
        if (NPC.life <= 0)
        {
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("BloodshotEye1").Type, 1f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("BloodshotEye2").Type, 1f);
        }
    }
    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        return Main.bloodMoon && !spawnInfo.player.InPillarZone() ? 0.091f * ExxoAvalonOriginsGlobalNPC.endoSpawnRate : 0f;
    }
}