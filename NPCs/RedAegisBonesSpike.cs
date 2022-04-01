﻿using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs
{
    public class RedAegisBonesSpike : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Red Aegis Bones");
            Main.npcFrameCount[NPC.type] = 15;
        }

        public override void SetDefaults()
        {
            NPC.damage = 120;
            NPC.lifeMax = 1500;
            NPC.defense = 67;
            NPC.width = 18;
            NPC.aiStyle = 3;
            NPC.value = 10000f;
            NPC.height = 40;
            NPC.knockBackResist = 0.2f;
            NPC.HitSound = SoundID.NPCHit2;
            NPC.DeathSound = SoundID.NPCDeath2;
            NPC.buffImmune[BuffID.Poisoned] = true;
            NPC.buffImmune[BuffID.Confused] = true;
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<Items.Banners.RedAegisBonesBanner>();
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.55f);
            NPC.damage = (int)(NPC.damage * 0.65f);
        }
        public override void NPCLoot()
        {
            if (Main.rand.Next(50) == 0)
            {
                Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType<Items.Accessories.AegisDash>(), 1, false, -2, false);
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
                    if (NPC.type == NPCID.PossessedArmor)
                    {
                        NPC.frame.Y = frameHeight;
                        NPC.frameCounter = 0.0;
                    }
                    else
                    {
                        NPC.frame.Y = 0;
                        NPC.frameCounter = 0.0;
                    }
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
    }
}
