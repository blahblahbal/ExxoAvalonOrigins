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
	public class SlimeGolem : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Slime Golem");
			Main.npcFrameCount[npc.type] = 15;
		}

		public override void SetDefaults()
		{
			npc.damage = 60;
			npc.lifeMax = 10000;
			npc.boss = true;
			npc.defense = 30;
			npc.width = 30;
			npc.aiStyle = -1;
			npc.value = 10000f;
			npc.knockBackResist = 0.3f;
			npc.height = 114;
            npc.HitSound = SoundID.NPCHit1;
	        npc.DeathSound = SoundID.NPCDeath1;
		}

        public override void AI()
        {
            if (npc.justHit)
            {
                npc.life = ExxoAvalonOriginsGlobalNPC.slimeLife;
                npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().slimeHitCounter += 1;
            }
            if (npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().slimeHitCounter >= 15)
            {
                for (var num1228 = 0; num1228 < 10; num1228++)
                {
                    var num1229 = NPC.NewNPC((int)npc.position.X + num1228 * 10, (int)npc.position.Y, ModContent.NPCType<GolemSlime>(), 0);
                    Main.npc[num1229].life = npc.life / 10;
                }
                npc.active = false;
                npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().slimeHitCounter = 0;
            }
            var num1230 = 1.5f;
            var num1231 = 0.1f;
            num1230 += (1f - npc.life / (float)npc.lifeMax) * 1.5f;
            num1231 += (1f - npc.life / (float)npc.lifeMax) * 0.15f;
            if (npc.velocity.X < -num1230 || npc.velocity.X > num1230)
            {
                if (npc.velocity.Y == 0f)
                {
                    npc.velocity *= 0.7f;
                    return;
                }
                return;
            }
            else if (npc.velocity.X < num1230 && npc.direction == 1)
            {
                npc.velocity.X = npc.velocity.X + num1231;
                if (npc.velocity.X > num1230)
                {
                    npc.velocity.X = num1230;
                    return;
                }
                return;
            }
            else
            {
                if (npc.velocity.X <= -num1230 || npc.direction != -1)
                {
                    return;
                }
                npc.velocity.X = npc.velocity.X - num1231;
                if (npc.velocity.X < -num1230)
                {
                    npc.velocity.X = -num1230;
                    return;
                }
                return;
            }
        }

        public override void FindFrame(int frameHeight)
        {
            if (npc.frameCounter < 0.0)
            {
                if (npc.velocity.Y == 0f)
                {
                    npc.frameCounter += 1.0;
                    if (npc.frameCounter < -12.0)
                    {
                        if (npc.frame.Y > frameHeight * 9)
                        {
                            npc.frame.Y = frameHeight * 11;
                        }
                    }
                    else if (npc.frameCounter < -6.0)
                    {
                        if (npc.frame.Y > frameHeight * 9)
                        {
                            npc.frame.Y = frameHeight * 12;
                        }
                    }
                    else if (npc.frameCounter < 0.0)
                    {
                        npc.frameCounter = 0.0;
                        if (npc.frame.Y > frameHeight * 9)
                        {
                            npc.frame.Y = frameHeight * 11;
                        }
                    }
                }
                else
                {
                    npc.frameCounter = -18.0;
                    if (npc.velocity.Y < 0f)
                    {
                        npc.frame.Y = frameHeight * 14;
                    }
                    else
                    {
                        npc.frame.Y = frameHeight * 13;
                    }
                }
            }
            else
            {
                npc.spriteDirection = npc.direction;
                npc.frameCounter += Math.Abs(npc.velocity.X * 1.1f);
                if (npc.frameCounter >= 6.0)
                {
                    npc.frameCounter = 0.0;
                    npc.frame.Y = npc.frame.Y + frameHeight;
                    if (npc.frame.Y > frameHeight * 9)
                    {
                        npc.frame.Y = 0;
                    }
                }
                if (npc.velocity.Y < -2f || npc.velocity.Y > 5f)
                {
                    npc.frameCounter = -18.0;
                }
            }
        }
    }
}