﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExxoAvalonOrigins.Items.Material;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace ExxoAvalonOrigins.NPCs
{
	public class Cougher : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cougher");
			Main.npcFrameCount[npc.type] = 3;
		}

		public override void SetDefaults()
		{
			npc.damage = 35;
			npc.lifeMax = 230;
			npc.defense = 12;
			npc.noGravity = true;
			npc.width = 28;
			npc.aiStyle = -1;
			npc.npcSlots = 1f;
			npc.value = 510f;
			npc.height = 38;
            npc.HitSound = SoundID.NPCHit1;
	        npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.3f;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.CougherBanner>();
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.55f);
            npc.damage = (int)(npc.damage * 0.5f);
        }
        public override void NPCLoot()
        {
            if (Main.rand.Next(2) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<YuckyBit>(), 1, false, 0, false);
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.player.GetModPlayer<ExxoAvalonOriginsModPlayer>().zoneBooger && Main.hardMode && !spawnInfo.player.InPillarZone())
                return (spawnInfo.player.GetModPlayer<ExxoAvalonOriginsModPlayer>().zoneBooger && Main.hardMode && !spawnInfo.player.InPillarZone()) ? 1f : 0f;
            return 0f;
        }
        public override void AI()
        {
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead)
            {
                npc.TargetClosest(true);
            }
            var num146 = 4f;
            var num147 = 0.02f;
            var vector17 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
            var num149 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2;
            var num150 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2;
            num149 = (int)(num149 / 8f) * 8;
            num150 = (int)(num150 / 8f) * 8;
            vector17.X = (int)(vector17.X / 8f) * 8;
            vector17.Y = (int)(vector17.Y / 8f) * 8;
            num149 -= vector17.X;
            num150 -= vector17.Y;
            var num151 = (float)Math.Sqrt(num149 * num149 + num150 * num150);
            var num152 = num151;
            if (num151 == 0f)
            {
                num149 = npc.velocity.X;
                num150 = npc.velocity.Y;
            }
            else
            {
                num151 = num146 / num151;
                num149 *= num151;
                num150 *= num151;
            }
            if (num152 > 100f)
            {
                npc.ai[0] += 1f;
                if (npc.ai[0] > 0f)
                {
                    npc.velocity.Y = npc.velocity.Y + 0.023f;
                }
                else
                {
                    npc.velocity.Y = npc.velocity.Y - 0.023f;
                }
                if (npc.ai[0] < -100f || npc.ai[0] > 100f)
                {
                    npc.velocity.X = npc.velocity.X + 0.023f;
                }
                else
                {
                    npc.velocity.X = npc.velocity.X - 0.023f;
                }
                if (npc.ai[0] > 200f)
                {
                    npc.ai[0] = -200f;
                }
            }
            if (num152 < 150f && (npc.type == NPCID.GoldMouse || npc.type == NPCID.GoldWorm))
            {
                npc.velocity.X = npc.velocity.X + num149 * 0.007f;
                npc.velocity.Y = npc.velocity.Y + num150 * 0.007f;
            }
            if (Main.player[npc.target].dead)
            {
                num149 = npc.direction * num146 / 2f;
                num150 = -num146 / 2f;
            }
            if (npc.velocity.X < num149)
            {
                npc.velocity.X = npc.velocity.X + num147;
                if (npc.velocity.X < 0f && num149 > 0f)
                {
                    npc.velocity.X = npc.velocity.X + num147;
                }
            }
            else if (npc.velocity.X > num149)
            {
                npc.velocity.X = npc.velocity.X - num147;
                if (npc.velocity.X > 0f && num149 < 0f)
                {
                    npc.velocity.X = npc.velocity.X - num147;
                }
            }
            if (npc.velocity.Y < num150)
            {
                npc.velocity.Y = npc.velocity.Y + num147;
                if (npc.velocity.Y < 0f && num150 > 0f)
                {
                    npc.velocity.Y = npc.velocity.Y + num147;
                }
            }
            else if (npc.velocity.Y > num150)
            {
                npc.velocity.Y = npc.velocity.Y - num147;
                if (npc.velocity.Y > 0f && num150 < 0f)
                {
                    npc.velocity.Y = npc.velocity.Y - num147;
                }
            }
            if (num149 > 0f)
            {
                npc.spriteDirection = 1;
                //npc.rotation = (float)Math.Atan2(num150, num149);
            }
            else if (num149 < 0f)
            {
                npc.spriteDirection = -1;
                //npc.rotation = (float)Math.Atan2(num150, num149) + 3.14f;
            }
            var num157 = 0.7f;
            if (npc.collideX)
            {
                npc.netUpdate = true;
                npc.velocity.X = npc.oldVelocity.X * -num157;
                if (npc.direction == -1 && npc.velocity.X > 0f && npc.velocity.X < 2f)
                {
                    npc.velocity.X = 2f;
                }
                if (npc.direction == 1 && npc.velocity.X < 0f && npc.velocity.X > -2f)
                {
                    npc.velocity.X = -2f;
                }
            }
            if (npc.collideY)
            {
                npc.netUpdate = true;
                npc.velocity.Y = npc.oldVelocity.Y * -num157;
                if (npc.velocity.Y > 0f && npc.velocity.Y < 1.5)
                {
                    npc.velocity.Y = 2f;
                }
                if (npc.velocity.Y < 0f && npc.velocity.Y > -1.5)
                {
                    npc.velocity.Y = -2f;
                }
            }
            else if (npc.type == NPCID.VortexLarva)
            {
                var num159 = Dust.NewDust(new Vector2(npc.position.X - npc.velocity.X, npc.position.Y - npc.velocity.Y), npc.width, npc.height, DustID.MagicMirror, npc.velocity.X * 0.2f, npc.velocity.Y * 0.2f, 100, default(Color), 2f);
                Main.dust[num159].noGravity = true;
                var dust11 = Main.dust[num159];
                dust11.velocity.X = dust11.velocity.X * 0.3f;
                var dust12 = Main.dust[num159];
                dust12.velocity.Y = dust12.velocity.Y * 0.3f;
            }
            else if (Main.rand.Next(20) == 0)
            {
                var num160 = 18;
                var num161 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + npc.height * 0.25f), npc.width, (int)(npc.height * 0.5f), num160, npc.velocity.X, 2f, 75, npc.color, npc.scale);
                var dust13 = Main.dust[num161];
                dust13.velocity.X = dust13.velocity.X * 0.5f;
                var dust14 = Main.dust[num161];
                dust14.velocity.Y = dust14.velocity.Y * 0.1f;
            }
            if (Main.dayTime || Main.player[npc.target].dead)
            {
                npc.velocity.Y = npc.velocity.Y - num147 * 2f;
                if (npc.timeLeft > 10)
                {
                    npc.timeLeft = 10;
                }
            }
            if (((npc.velocity.X > 0f && npc.oldVelocity.X < 0f) || (npc.velocity.X < 0f && npc.oldVelocity.X > 0f) || (npc.velocity.Y > 0f && npc.oldVelocity.Y < 0f) || (npc.velocity.Y < 0f && npc.oldVelocity.Y > 0f)) && !npc.justHit)
            {
                npc.netUpdate = true;
                return;
            }
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 1.0;
            if (npc.frameCounter >= 8.0)
            {
                npc.frame.Y = npc.frame.Y + frameHeight;
                npc.frameCounter = 0.0;
            }
            if (npc.frame.Y >= frameHeight * Main.npcFrameCount[npc.type])
            {
                npc.frame.Y = 0;
            }
        }
    }
}
