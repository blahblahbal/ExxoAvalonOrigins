using System;
using ExxoAvalonOrigins.Items.Accessories;
using ExxoAvalonOrigins.Items.Material;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using Terraria.DataStructures;

namespace ExxoAvalonOrigins.NPCs;

public class CursedMagmaSkeleton : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Cursed Magma Skeleton");
        Main.npcFrameCount[NPC.type] = 15;
        NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData
        {
            SpecificallyImmuneTo = new int[]
            {
                BuffID.Confused,
                BuffID.OnFire,
                BuffID.CursedInferno
            }
        };
        NPCID.Sets.DebuffImmunitySets[Type] = debuffData;
    }

    public override void SetDefaults()
    {
        NPC.damage = 120;
        NPC.netAlways = true;
        NPC.scale = 1.35f;
        NPC.lifeMax = 2000;
        NPC.defense = 40;
        NPC.lavaImmune = true;
        NPC.width = 18;
        NPC.aiStyle = 3;
        NPC.npcSlots = 1.1f;
        NPC.value = Item.buyPrice(0, 1, 0, 0);
        NPC.timeLeft = 750;
        NPC.height = 40;
        NPC.knockBackResist = 0.1f;
        NPC.HitSound = SoundID.NPCHit2;
        NPC.DeathSound = SoundID.NPCDeath2;
        Banner = NPC.type;
        BannerItem = ModContent.ItemType<Items.Banners.CursedMagmaSkeletonBanner>();
    }

    public override Color? GetAlpha(Color lightColor)
    {
        return new Color(255, 255, 255);
    }

    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.7f);
        NPC.damage = (int)(NPC.damage * 0.7f);
    }
    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GreekExtinguisher>(), 60));
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SoulofBlight>(), 10));
    }
    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        return spawnInfo.player.ZoneRockLayerHeight && !spawnInfo.player.ZoneDungeon && ModContent.GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode ? 0.03f : 0f;
    }

    public override void AI()
    {
        Lighting.AddLight((int)((NPC.position.X + (float)(NPC.width / 2)) / 16f), (int)((NPC.position.Y + (float)(NPC.height / 2)) / 16f), 0.6f, 0.87f, 0.0f);
        if (Main.rand.Next(5) == 0)
        {
            int num10 = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.CursedTorch, 0f, 0f, 0, default(Color), 1.6f);
            Main.dust[num10].noGravity = true;
        }
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
            if (NPC.velocity.X == 0f)
            {
                NPC.frame.Y = 0;
                NPC.frameCounter = 0.0;
            }
            else
            {
                NPC.frameCounter += Math.Abs(NPC.velocity.X) * 2f;
                NPC.frameCounter += 1.0;
                if (NPC.frameCounter > 6.0)
                {
                    NPC.frame.Y = NPC.frame.Y + frameHeight;
                    NPC.frameCounter = 0.0;
                }
                if (NPC.frame.Y / frameHeight >= Main.npcFrameCount[NPC.type])
                {
                    NPC.frame.Y = frameHeight * 2;
                }
            }
        }
        else
        {
            NPC.frameCounter = 0.0;
            NPC.frame.Y = 0;
        }
    }

    public override void HitEffect(int hitDirection, double damage)
    {
        for (int i = 0; i < 3; i++)
        {
            int num890 = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.CursedTorch, 0f, 0f, 0, default(Color), 1f);
            Main.dust[num890].velocity *= 5f;
            Main.dust[num890].scale = 1f;
            Main.dust[num890].noGravity = true;
            Main.dust[num890].fadeIn = 2f;
        }
        if (NPC.life <= 0)
        {
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("CursedMagmaSkeletonHelmet").Type, 1.2f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("Bone1").Type, 1.2f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("Bone2").Type, 1.2f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("Bone1").Type, 1.2f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("Bone2").Type, 1.2f);
            for (int i = 0; i < 20; i++)
            {
                int num890 = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.CursedTorch, 0f, 0f, 0, default(Color), 1f);
                Main.dust[num890].velocity *= 7f;
                Main.dust[num890].scale = 1.6f;
                Main.dust[num890].noGravity = true;
            }
        }
    }
}
