using System;
using ExxoAvalonOrigins.Items.Armor;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using Terraria.DataStructures;

namespace ExxoAvalonOrigins.NPCs;

public class FallenHero : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Fallen Hero");
        Main.npcFrameCount[NPC.type] = 3;
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
        NPC.damage = 30;
        NPC.lifeMax = 180;
        NPC.defense = 6;
        NPC.width = 18;
        NPC.aiStyle = 3;
        NPC.value = 10000f;
        NPC.height = 40;
        NPC.knockBackResist = 0.5f;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath2;
    }
    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.55f);
        NPC.damage = (int)(NPC.damage * 0.5f);
    }
    public override void FindFrame(int frameHeight)
    {
        if (NPC.velocity.Y == 0f)
        {
            if (NPC.direction == 1)
            {
                NPC.spriteDirection = 1;
            }
            if (NPC.direction == -1)
            {
                NPC.spriteDirection = -1;
            }
        }
        if (NPC.velocity.Y != 0f || (NPC.direction == -1 && NPC.velocity.X > 0f) || (NPC.direction == 1 && NPC.velocity.X < 0f))
        {
            NPC.frameCounter = 0.0;
            NPC.frame.Y = frameHeight * 2;
        }
        else if (NPC.velocity.X == 0f)
        {
            NPC.frameCounter = 0.0;
            NPC.frame.Y = 0;
        }
        else
        {
            NPC.frameCounter += Math.Abs(NPC.velocity.X);
            if (NPC.frameCounter < 8.0)
            {
                NPC.frame.Y = 0;
            }
            else if (NPC.frameCounter < 16.0)
            {
                NPC.frame.Y = frameHeight;
            }
            else if (NPC.frameCounter < 24.0)
            {
                NPC.frame.Y = frameHeight * 2;
            }
            else if (NPC.frameCounter < 32.0)
            {
                NPC.frame.Y = frameHeight;
            }
            else
            {
                NPC.frameCounter = 0.0;
            }
        }
    }

    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(ItemDropRule.OneFromOptions(18, new int[] { ModContent.ItemType<BloodstainedHelmet>(), ModContent.ItemType<Items.Vanity.BloodstainedChestplate>(), ModContent.ItemType<Items.Vanity.BloodstainedGreaves>() }));
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapons.Melee.MinersSword>(), 12));
    }
    public override void HitEffect(int hitDirection, double damage)
    {
        if (NPC.life <= 0)
        {
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("FallenHeroGore1").Type, 0.9f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("FallenHeroGore2").Type, 0.9f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("FallenHeroGore2").Type, 0.9f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("FallenHeroGore3").Type, 0.9f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("FallenHeroGore3").Type, 0.9f);
        }
    }
    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        return spawnInfo.player.ZoneOverworldHeight && !spawnInfo.player.InPillarZone() && Main.bloodMoon ? 0.1f * ExxoAvalonOriginsGlobalNPC.endoSpawnRate : 0f;
    }
}
