using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.NPCs
{
	public class Dragonfly : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dragonfly");
			Main.npcFrameCount[npc.type] = 7;
		}

		public override void SetDefaults()
		{
			npc.damage = 130;
			npc.scale = 1f;
			npc.lifeMax = 1700;
			npc.defense = 34;
			npc.noGravity = true;
			npc.width = 56;
			npc.aiStyle = -1;
			npc.npcSlots = 1f;
			npc.value = 10000f;
			npc.timeLeft = 750;
			npc.height = 12;
			npc.knockBackResist = 0f;
            npc.HitSound = SoundID.NPCHit1;
	        npc.DeathSound = SoundID.NPCDeath1;
			npc.buffImmune[BuffID.Poisoned] = true;
			npc.buffImmune[BuffID.OnFire] = true;
			npc.buffImmune[BuffID.Confused] = true;
			npc.buffImmune[BuffID.CursedInferno] = true;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.DragonflyBanner>();
        }

        public int frames = 4;

        public override void AI()
        {
            var flag33 = false;
            frames += 16;
            if (frames > 448)
            {
                frames = 4;
            }
            if (Math.Round(npc.velocity.X) == 0.0)
            {
                npc.spriteDirection = npc.direction;
            }
            if (npc.justHit)
            {
                npc.ai[2] = 0f;
            }
            if (npc.ai[2] >= 0f)
            {
                var num403 = 16;
                var flag34 = false;
                var flag35 = false;
                if (npc.position.X > npc.ai[0] - num403 && npc.position.X < npc.ai[0] + num403)
                {
                    flag34 = true;
                }
                else if ((npc.velocity.X < 0f && npc.direction > 0) || (npc.velocity.X > 0f && npc.direction < 0))
                {
                    flag34 = true;
                }
                num403 += 24;
                if (npc.position.Y > npc.ai[1] - num403 && npc.position.Y < npc.ai[1] + num403)
                {
                    flag35 = true;
                }
                if (flag34 && flag35)
                {
                    npc.ai[2] += 1f;
                    if (npc.ai[2] >= 30f && num403 == 16)
                    {
                        flag33 = true;
                    }
                    if (npc.ai[2] >= 60f)
                    {
                        npc.ai[2] = -200f;
                        npc.direction *= -1;
                        npc.velocity.X = npc.velocity.X * -1f;
                        npc.collideX = false;
                    }
                }
                else
                {
                    npc.ai[0] = npc.position.X;
                    npc.ai[1] = npc.position.Y;
                    npc.ai[2] = 0f;
                }
                npc.TargetClosest(true);
            }
            else
            {
                npc.ai[2] += 1f;
                if (Main.player[npc.target].position.X + Main.player[npc.target].width / 2 > npc.position.X + npc.width / 2)
                {
                    npc.direction = -1;
                }
                else
                {
                    npc.direction = 1;
                }
            }
            var num404 = (int)((npc.position.X + npc.width / 2) / 16f) + npc.direction * 2;
            var num405 = (int)((npc.position.Y + npc.height) / 16f);
            var flag36 = true;
            var num406 = 3;
            for (var num428 = num405; num428 < num405 + num406; num428++)
            {
                if (Main.tile[num404, num428] == null)
                {
                    Main.tile[num404, num428] = new Tile();
                }
                if ((Main.tile[num404, num428].nactive() && Main.tileSolid[Main.tile[num404, num428].type]) || Main.tile[num404, num428].liquid > 0)
                {
                    flag36 = false;
                    break;
                }
            }
            if (flag33)
            {
                flag36 = true;
            }
            if (flag36)
            {
                npc.velocity.Y = npc.velocity.Y + 0.1f;
                if (npc.velocity.Y > 3f)
                {
                    npc.velocity.Y = 3f;
                }
            }
            else
            {
                if (npc.directionY < 0 && npc.velocity.Y > 0f)
                {
                    npc.velocity.Y = npc.velocity.Y - 0.1f;
                }
                if (npc.velocity.Y < -4f)
                {
                    npc.velocity.Y = -4f;
                }
            }
            if (npc.collideX)
            {
                npc.velocity.X = npc.oldVelocity.X * -0.4f;
                if (npc.direction == -1 && npc.velocity.X > 0f && npc.velocity.X < 1f)
                {
                    npc.velocity.X = 1f;
                }
                if (npc.direction == 1 && npc.velocity.X < 0f && npc.velocity.X > -1f)
                {
                    npc.velocity.X = -1f;
                }
            }
            if (npc.collideY)
            {
                npc.velocity.Y = npc.oldVelocity.Y * -0.25f;
                if (npc.velocity.Y > 0f && npc.velocity.Y < 1f)
                {
                    npc.velocity.Y = 1f;
                }
                if (npc.velocity.Y < 0f && npc.velocity.Y > -1f)
                {
                    npc.velocity.Y = -1f;
                }
            }
            var num430 = 2f;
            if (npc.direction == -1 && npc.velocity.X > -num430)
            {
                npc.velocity.X = npc.velocity.X - 0.1f;
                if (npc.velocity.X > num430)
                {
                    npc.velocity.X = npc.velocity.X - 0.1f;
                }
                else if (npc.velocity.X > 0f)
                {
                    npc.velocity.X = npc.velocity.X + 0.05f;
                }
                if (npc.velocity.X < -num430)
                {
                    npc.velocity.X = -num430;
                }
            }
            else if (npc.direction == 1 && npc.velocity.X < num430)
            {
                npc.velocity.X = npc.velocity.X + 0.1f;
                if (npc.velocity.X < -num430)
                {
                    npc.velocity.X = npc.velocity.X + 0.1f;
                }
                else if (npc.velocity.X < 0f)
                {
                    npc.velocity.X = npc.velocity.X - 0.05f;
                }
                if (npc.velocity.X > num430)
                {
                    npc.velocity.X = num430;
                }
            }
            if (npc.directionY == -1 && npc.velocity.Y > -1.5)
            {
                npc.velocity.Y = npc.velocity.Y - 0.04f;
                if (npc.velocity.Y > 1.5)
                {
                    npc.velocity.Y = npc.velocity.Y - 0.05f;
                }
                else if (npc.velocity.Y > 0f)
                {
                    npc.velocity.Y = npc.velocity.Y + 0.03f;
                }
                if (npc.velocity.Y < -1.5)
                {
                    npc.velocity.Y = -1.5f;
                }
            }
            else if (npc.directionY == 1 && npc.velocity.Y < 1.5)
            {
                npc.velocity.Y = npc.velocity.Y + 0.04f;
                if (npc.velocity.Y < -1.5)
                {
                    npc.velocity.Y = npc.velocity.Y + 0.05f;
                }
                else if (npc.velocity.Y < 0f)
                {
                    npc.velocity.Y = npc.velocity.Y - 0.03f;
                }
                if (npc.velocity.Y > 1.5)
                {
                    npc.velocity.Y = 1.5f;
                }
            }
            return;
        }

        public override void FindFrame(int frameHeight)
        {
            var frameHeightX = 1;
            if (!Main.dedServ)
            {
                frameHeightX = Main.npcTexture[npc.type].Height / Main.npcFrameCount[npc.type];
            }
            if (frames == 4 || frames == 68 || frames == 132 || frames == 196 || frames == 260 || frames == 324 || frames == 388)
            {
                npc.frame.Y = frames;
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.player.ZoneOverworldHeight && !Main.dayTime && !spawnInfo.player.GetModPlayer<ExxoAvalonOriginsModPlayer>().InPillarZone() && Main.hardMode && ExxoAvalonOrigins.superHardmode ? 0.05f * ExxoAvalonOriginsGlobalNPC.endoSpawnRate : 0f;
        }
    }
}