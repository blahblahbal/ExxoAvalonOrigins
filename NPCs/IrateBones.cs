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
	public class IrateBones : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Irate Bones");
			Main.npcFrameCount[npc.type] = 15;
		}
		public override void SetDefaults()
		{
			npc.damage = 35;
			npc.lifeMax = 350;
			npc.defense = 15;
			npc.lavaImmune = true;
			npc.width = 18;
			npc.aiStyle = 3;
			npc.value = 1000f;
			npc.height = 40;
			npc.knockBackResist = 0.5f;
            npc.HitSound = SoundID.NPCHit2;
	        npc.DeathSound = SoundID.NPCDeath2;
			npc.buffImmune[BuffID.Confused] = true;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.IrateBonesBanner>();
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.7f);
            npc.damage = (int)(npc.damage * 0.5f);
        }
        public override void FindFrame(int frameHeight)
        {
            if (npc.velocity.Y == 0f)
            {
                if (npc.direction == 1)
                {
                    npc.spriteDirection = 1;
                }
                if (npc.direction == -1)
                {
                    npc.spriteDirection = -1;
                }
                if (npc.velocity.X == 0f)
                {
                    npc.frame.Y = 0;
                    npc.frameCounter = 0.0;
                }
                else
                {
                    npc.frameCounter += Math.Abs(npc.velocity.X) * 2f;
                    npc.frameCounter += 1.0;
                    if (npc.frameCounter > 6.0)
                    {
                        npc.frame.Y = npc.frame.Y + frameHeight;
                        npc.frameCounter = 0.0;
                    }
                    if (npc.frame.Y / frameHeight >= Main.npcFrameCount[npc.type])
                    {
                        npc.frame.Y = frameHeight * 2;
                    }
                }
            }
            else
            {
                npc.frameCounter = 0.0;
                npc.frame.Y = frameHeight;
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return Main.hardMode && spawnInfo.player.ZoneDungeon ? 0.6f * ExxoAvalonOriginsGlobalNPC.endoSpawnRate : 0f;
        }
        public override void NPCLoot()
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/IrateBonesHelmet"), 1f);
                Gore.NewGore(npc.position, npc.velocity, 43, 1f);
                Gore.NewGore(npc.position, npc.velocity, 43, 1f);
                Gore.NewGore(npc.position, npc.velocity, 44, 1f);
                Gore.NewGore(npc.position, npc.velocity, 44, 1f);
                //Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MagmaChestplate"), 1f);
            }
        }
    }
}
