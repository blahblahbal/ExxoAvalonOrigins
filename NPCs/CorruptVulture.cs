using ExxoAvalonOrigins.Items.Placeable.Tile;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using Terraria.DataStructures;

namespace ExxoAvalonOrigins.NPCs;

public class CorruptVulture : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Evil Vulture");
        Main.npcFrameCount[NPC.type] = 3;
        NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData
        {
            SpecificallyImmuneTo = new int[]
            {
                ModContent.BuffType<Buffs.Frozen>()
            }
        };
        NPCID.Sets.DebuffImmunitySets[Type] = debuffData;
    }

    public override void SetDefaults()
    {
        NPC.damage = 45;
        NPC.noTileCollide = false;
        NPC.lifeMax = 300;
        NPC.defense = 15;
        NPC.width = 36;
        NPC.aiStyle = 17;
        NPC.value = 750;
        NPC.timeLeft = 750;
        NPC.height = 36;
        AnimationType = 61;
        AIType = 61;
        NPC.knockBackResist = 0.6f;
        NPC.HitSound = SoundID.NPCHit28;
        NPC.DeathSound = SoundID.NPCDeath31;
        //Banner = npc.type;
        //BannerItem = ModContent.ItemType<Items.Banners.CorruptVultureBanner>();
    }
    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.5f);
        NPC.damage = (int)(NPC.damage * 0.5f);
    }
    public override void ModifyNPCLoot(NPCLoot loot)
    {
        loot.Add(ItemDropRule.Common(ModContent.ItemType<Beak>(), 2));
    }

    //public override void AI()
    //{
    //    npc.noGravity = true;
    //    if (npc.ai[0] == 0f)
    //    {
    //        npc.noGravity = false;
    //        npc.TargetClosest(true);
    //        if (Main.netMode != 1)
    //        {
    //            if (npc.velocity.X != 0f || npc.velocity.Y < 0f || (double)npc.velocity.Y > 0.3)
    //            {
    //                npc.ai[0] = 1f;
    //                npc.netUpdate = true;
    //            }
    //            else
    //            {
    //                Rectangle rectangle5 = new Rectangle((int)Main.player[npc.target].position.X, (int)Main.player[npc.target].position.Y, Main.player[npc.target].width, Main.player[npc.target].height);
    //                Rectangle rectangle6 = new Rectangle((int)npc.position.X - 100, (int)npc.position.Y - 100, npc.width + 200, npc.height + 200);
    //                if (rectangle6.Intersects(rectangle5) || npc.life < npc.lifeMax)
    //                {
    //                    npc.ai[0] = 1f;
    //                    npc.velocity.Y = npc.velocity.Y - 6f;
    //                    npc.netUpdate = true;
    //                }
    //            }
    //        }
    //    }
    //    else if (!Main.player[npc.target].dead)
    //    {
    //        if (npc.collideX)
    //        {
    //            npc.velocity.X = npc.oldVelocity.X * -0.5f;
    //            if (npc.direction == -1 && npc.velocity.X > 0f && npc.velocity.X < 2f)
    //            {
    //                npc.velocity.X = 2f;
    //            }
    //            if (npc.direction == 1 && npc.velocity.X < 0f && npc.velocity.X > -2f)
    //            {
    //                npc.velocity.X = -2f;
    //            }
    //        }
    //        if (npc.collideY)
    //        {
    //            npc.velocity.Y = npc.oldVelocity.Y * -0.5f;
    //            if (npc.velocity.Y > 0f && npc.velocity.Y < 1f)
    //            {
    //                npc.velocity.Y = 1f;
    //            }
    //            if (npc.velocity.Y < 0f && npc.velocity.Y > -1f)
    //            {
    //                npc.velocity.Y = -1f;
    //            }
    //        }
    //        npc.TargetClosest(true);
    //        if (npc.direction == -1 && npc.velocity.X > -3f)
    //        {
    //            npc.velocity.X = npc.velocity.X - 0.1f;
    //            if (npc.velocity.X > 3f)
    //            {
    //                npc.velocity.X = npc.velocity.X - 0.1f;
    //            }
    //            else if (npc.velocity.X > 0f)
    //            {
    //                npc.velocity.X = npc.velocity.X - 0.05f;
    //            }
    //            if (npc.velocity.X < -3f)
    //            {
    //                npc.velocity.X = -3f;
    //            }
    //        }
    //        else if (npc.direction == 1 && npc.velocity.X < 3f)
    //        {
    //            npc.velocity.X = npc.velocity.X + 0.1f;
    //            if (npc.velocity.X < -3f)
    //            {
    //                npc.velocity.X = npc.velocity.X + 0.1f;
    //            }
    //            else if (npc.velocity.X < 0f)
    //            {
    //                npc.velocity.X = npc.velocity.X + 0.05f;
    //            }
    //            if (npc.velocity.X > 3f)
    //            {
    //                npc.velocity.X = 3f;
    //            }
    //        }
    //        float num365 = Math.Abs(npc.position.X + (float)(npc.width / 2) - (Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2)));
    //        float num366 = Main.player[npc.target].position.Y - (float)(npc.height / 2);
    //        if (num365 > 50f)
    //        {
    //            num366 -= 100f;
    //        }
    //        if (npc.position.Y < num366)
    //        {
    //            npc.velocity.Y = npc.velocity.Y + 0.05f;
    //            if (npc.velocity.Y < 0f)
    //            {
    //                npc.velocity.Y = npc.velocity.Y + 0.01f;
    //            }
    //        }
    //        else
    //        {
    //            npc.velocity.Y = npc.velocity.Y - 0.05f;
    //            if (npc.velocity.Y > 0f)
    //            {
    //                npc.velocity.Y = npc.velocity.Y - 0.01f;
    //            }
    //        }
    //        if (npc.velocity.Y < -3f)
    //        {
    //            npc.velocity.Y = -3f;
    //        }
    //        if (npc.velocity.Y > 3f)
    //        {
    //            npc.velocity.Y = 3f;
    //        }
    //    }
    //    if (npc.wet)
    //    {
    //        if (npc.velocity.Y > 0f)
    //        {
    //            npc.velocity.Y = npc.velocity.Y * 0.95f;
    //        }
    //        npc.velocity.Y = npc.velocity.Y - 0.5f;
    //        if (npc.velocity.Y < -4f)
    //        {
    //            npc.velocity.Y = -4f;
    //        }
    //        npc.TargetClosest(true);
    //        return;
    //    }
    //}

    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        if (spawnInfo.player.Avalon().ZoneContagion || spawnInfo.player.ZoneCorrupt || spawnInfo.player.ZoneCrimson)
        {
            if (Main.hardMode)
            {
                if (Main.tile[spawnInfo.spawnTileX, spawnInfo.spawnTileY + 1].TileType == TileID.Ebonsand ||
                    Main.tile[spawnInfo.spawnTileX, spawnInfo.spawnTileY + 1].TileType == TileID.Crimsand ||
                    Main.tile[spawnInfo.spawnTileX, spawnInfo.spawnTileY + 1].TileType == ModContent.TileType<Tiles.Snotsand>())
                {
                    return 1f;
                }
            }
        }
        return 0f;
    }

    //public override void FindFrame(int frameHeight)
    //{
    //    {
    //        npc.spriteDirection = npc.direction;
    //        npc.rotation = npc.velocity.X * 0.1f;
    //        if (npc.velocity.X == 0f && npc.velocity.Y == 0f)
    //        {
    //            npc.frame.Y = 0;
    //            npc.frameCounter = 0.0;
    //        }
    //        else
    //        {
    //            npc.frameCounter += 1.0;
    //            if (npc.frameCounter < 4.0)
    //            {
    //                npc.frame.Y = frameHeight;
    //            }
    //            else
    //            {
    //                npc.frame.Y = frameHeight * 2;
    //                if (npc.frameCounter >= 7.0)
    //                {
    //                    npc.frameCounter = 0.0;
    //                }
    //            }
    //        }
    //    }
    //}

    public override void HitEffect(int hitDirection, double damage)
    {
        if (NPC.life <= 0)
        {
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("CorruptVultureHead").Type, 0.9f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("CorruptVultureWing").Type, 0.9f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("CorruptVultureWing").Type, 0.9f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("CorruptVultureTalon").Type, 0.9f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("CorruptVultureTalon").Type, 0.9f);
        }
    }
}
