﻿using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.DataStructures;

namespace ExxoAvalonOrigins.NPCs;

public class Gargoyle : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Gargoyle");
        Main.npcFrameCount[NPC.type] = 5;
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
        NPC.damage = 105;
        NPC.netAlways = true;
        NPC.scale = 1.1f;
        NPC.lifeMax = 2400;
        NPC.defense = 30;
        NPC.lavaImmune = true;
        NPC.width = 34;
        NPC.aiStyle = -1;
        NPC.value = Item.buyPrice(0, 1, 0, 0);
        NPC.height = 50;
        NPC.knockBackResist = 0f;
        NPC.HitSound = null;
        NPC.DeathSound = null;
        Banner = NPC.type;
        BannerItem = ModContent.ItemType<Items.Banners.GargoyleBanner>();
    }
    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.55f);
        NPC.damage = (int)(NPC.damage * 0.5f);
    }
    public override void AI()
    {
        NPC.noGravity = true;
        if (NPC.ai[0] == 0f)
        {
            NPC.noGravity = false;
            NPC.TargetClosest(true);
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                if (NPC.velocity.X != 0f || NPC.velocity.Y < 0f || (double)NPC.velocity.Y > 0.3)
                {
                    NPC.ai[0] = 1f;
                    NPC.netUpdate = true;
                }
                else
                {
                    Rectangle rectangle5 = new Rectangle((int)Main.player[NPC.target].position.X, (int)Main.player[NPC.target].position.Y, Main.player[NPC.target].width, Main.player[NPC.target].height);
                    Rectangle rectangle6 = new Rectangle((int)NPC.position.X - 100, (int)NPC.position.Y - 100, NPC.width + 200, NPC.height + 200);
                    if (rectangle6.Intersects(rectangle5) || NPC.life < NPC.lifeMax)
                    {
                        NPC.ai[0] = 1f;
                        NPC.velocity.Y = NPC.velocity.Y - 6f;
                        NPC.netUpdate = true;
                    }
                }
            }
        }
        else if (!Main.player[NPC.target].dead)
        {
            if (NPC.collideX)
            {
                NPC.velocity.X = NPC.oldVelocity.X * -0.5f;
                if (NPC.direction == -1 && NPC.velocity.X > 0f && NPC.velocity.X < 2f)
                {
                    NPC.velocity.X = 2f;
                }
                if (NPC.direction == 1 && NPC.velocity.X < 0f && NPC.velocity.X > -2f)
                {
                    NPC.velocity.X = -2f;
                }
            }
            if (NPC.collideY)
            {
                NPC.velocity.Y = NPC.oldVelocity.Y * -0.5f;
                if (NPC.velocity.Y > 0f && NPC.velocity.Y < 1f)
                {
                    NPC.velocity.Y = 1f;
                }
                if (NPC.velocity.Y < 0f && NPC.velocity.Y > -1f)
                {
                    NPC.velocity.Y = -1f;
                }
            }
            NPC.TargetClosest(true);
            if (NPC.direction == -1 && NPC.velocity.X > -3f)
            {
                NPC.velocity.X = NPC.velocity.X - 0.1f;
                if (NPC.velocity.X > 9f)
                {
                    NPC.velocity.X = NPC.velocity.X - 0.1f;
                }
                else if (NPC.velocity.X > 0f)
                {
                    NPC.velocity.X = NPC.velocity.X - 0.05f;
                }
                if (NPC.velocity.X < -9f)
                {
                    NPC.velocity.X = -9f;
                }
            }
            else if (NPC.direction == 1 && NPC.velocity.X < 3f)
            {
                NPC.velocity.X = NPC.velocity.X + 0.1f;
                if (NPC.velocity.X < -9f)
                {
                    NPC.velocity.X = NPC.velocity.X + 0.1f;
                }
                else if (NPC.velocity.X < 0f)
                {
                    NPC.velocity.X = NPC.velocity.X + 0.05f;
                }
                if (NPC.velocity.X > 9f)
                {
                    NPC.velocity.X = 9f;
                }
            }
            float num365 = Math.Abs(NPC.position.X + (float)(NPC.width / 2) - (Main.player[NPC.target].position.X + (float)(Main.player[NPC.target].width / 2)));
            float num366 = Main.player[NPC.target].position.Y - (float)(NPC.height / 2);
            if (num365 > 50f)
            {
                num366 -= 100f;
            }
            if (NPC.position.Y < num366)
            {
                NPC.velocity.Y = NPC.velocity.Y + 0.05f;
                if (NPC.velocity.Y < 0f)
                {
                    NPC.velocity.Y = NPC.velocity.Y + 0.01f;
                }
            }
            else
            {
                NPC.velocity.Y = NPC.velocity.Y - 0.05f;
                if (NPC.velocity.Y > 0f)
                {
                    NPC.velocity.Y = NPC.velocity.Y - 0.01f;
                }
            }
            if (NPC.velocity.Y < -3f)
            {
                NPC.velocity.Y = -3f;
            }
            if (NPC.velocity.Y > 3f)
            {
                NPC.velocity.Y = 3f;
            }
        }
        if (NPC.wet)
        {
            if (NPC.velocity.Y > 0f)
            {
                NPC.velocity.Y = NPC.velocity.Y * 0.95f;
            }
            NPC.velocity.Y = NPC.velocity.Y - 0.5f;
            if (NPC.velocity.Y < -4f)
            {
                NPC.velocity.Y = -4f;
            }
            NPC.TargetClosest(true);
            return;
        }
    }
    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        if (spawnInfo.player.Avalon().ZoneHellcastle && Main.tile[spawnInfo.spawnTileX, spawnInfo.spawnTileY].WallType == (ushort)ModContent.WallType<Walls.ImperviousBrickWallUnsafe>())
        {
            return 2f;
        }
        return 0f;
    }
    public override void FindFrame(int frameHeight)
    {
        NPC.spriteDirection = NPC.direction;
        NPC.rotation = NPC.velocity.X * 0.1f;
        if (NPC.velocity.X == 0f && NPC.velocity.Y == 0f)
        {
            NPC.frame.Y = 0;
            NPC.frameCounter = 0.0;
        }
        else
        {
            NPC.frameCounter += 1.0;
            if (NPC.frameCounter <= 5)
            {
                NPC.frame.Y = frameHeight;
            }
            else if (NPC.frameCounter <= 10)
            {
                NPC.frame.Y = frameHeight * 2;
            }
            else if (NPC.frameCounter <= 15)
            {
                NPC.frame.Y = frameHeight * 3;
            }
            else if (NPC.frameCounter <= 20)
            {
                NPC.frame.Y = frameHeight * 4;
            }
            else
            {
                NPC.frameCounter = 0;
            }
        }
    }

    public override void HitEffect(int hitDirection, double damage)
    {
        if (NPC.life > 0)
        {
            SoundEngine.PlaySound(SoundID.NPCHit, (int)NPC.Center.X, (int)NPC.Center.Y, 41, 1f, -0.25f);
        }
        if (NPC.life <= 0)
        {
            SoundEngine.PlaySound(SoundID.NPCKilled, (int)NPC.Center.X, (int)NPC.Center.Y, 5, 1f, -0.25f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("GargoyleGore3").Type, 1f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("GargoyleGore3").Type, 1f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("GargoyleGore4").Type, 1f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("GargoyleWing").Type, 1f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("GargoyleWing").Type, 1f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("GargoyleHead").Type, 1f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("GargoyleGore5").Type, 1f);
        }
    }
}
