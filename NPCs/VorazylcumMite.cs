﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.NPCs
{
    public class VorazylcumMite : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vorazylcum Mite");
        }
        public override void SetDefaults()
        {
            npc.damage = 77;
            npc.lifeMax = 1300;
            npc.defense = 6;
            npc.width = 18;
            npc.aiStyle = -1;
            npc.value = 10000f;
            npc.height = 40;
            npc.knockBackResist = 0f;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.buffImmune[BuffID.Confused] = true;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.55f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.5f);
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(ModContent.BuffType<Buffs.VorazylcumThorned>(), 10 * 60);
        }
        public override void NPCLoot()
        {
            Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/VorazylcumMiteGore1"), npc.scale);
            Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/VorazylcumMiteGore2"), npc.scale);
        }
        public override void AI()
        {
            npc.spriteDirection = npc.direction;
            npc.TargetClosest(true);
            if (npc.ai[1] < 1200f)
            {
                npc.ai[1]++;
            }
            if (npc.ai[1] == 1200f && Main.netMode != 1)
            {
                npc.position.Y = npc.position.Y + 16f;
                npc.Transform(ModContent.NPCType<VorazylcumMiteDigger>());
                npc.netUpdate = true;
                return;
            }
            if (npc.velocity.Y == 0f)
            {
                if (npc.ai[0] == 1f)
                {
                    if (npc.direction == 0)
                    {
                        npc.TargetClosest(true);
                    }
                    if (npc.collideX)
                    {
                        npc.direction *= -1;
                    }
                    npc.velocity.X = 0.2f * (float)npc.direction;
                    if (npc.type == ModContent.NPCType<VorazylcumMite>())
                    {
                        npc.velocity.X = npc.velocity.X * 3f;
                    }
                }
                else
                {
                    npc.velocity.X = 0f;
                }
                if (Main.netMode != 1)
                {
                    npc.localAI[1] -= 1f;
                    if (npc.localAI[1] <= 0f)
                    {
                        if (npc.ai[0] == 1f)
                        {
                            npc.ai[0] = 0f;
                            npc.localAI[1] = Main.rand.Next(300, 900);
                        }
                        else
                        {
                            npc.ai[0] = 1f;
                            npc.localAI[1] = Main.rand.Next(600, 1800);
                        }
                        npc.netUpdate = true;
                    }
                }
            }

        }
    }
}