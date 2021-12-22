using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExxoAvalonOrigins.Items.Accessories;
using ExxoAvalonOrigins.Items.Material;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.NPCs
{
	public class Mime : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mime");
			Main.npcFrameCount[npc.type] = 3;
		}

		public override void SetDefaults()
		{
			npc.damage = 75;
			npc.scale = 1.4f;
			npc.noTileCollide = false;
			npc.lifeMax = 630;
			npc.defense = 46;
			npc.noGravity = false;
			npc.width = 18;
			npc.aiStyle = 3;
			npc.value = 1500f;
			npc.height = 40;
			npc.knockBackResist = 0.6f;
            npc.HitSound = SoundID.NPCHit1;
	        npc.DeathSound = SoundID.NPCDeath1;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.MimeBanner>();
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.55f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.75f);
        }
        public override void NPCLoot()
		{
			if (Main.rand.Next(3) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<SoulofTime>(), Main.rand.Next(5) + 1, false, 0, false);
			}
			if (Main.rand.Next(100) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<ManaCompromise>(), 1, false, -2, false);
			}
			if (Main.rand.Next(8) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<ConfusionTalisman>(), 1, false, -2, false);
			}
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
            }
            if (npc.velocity.Y != 0f || (npc.direction == -1 && npc.velocity.X > 0f) || (npc.direction == 1 && npc.velocity.X < 0f))
            {
                npc.frameCounter = 0.0;
                npc.frame.Y = frameHeight * 2;
            }
            else if (npc.velocity.X == 0f)
            {
                npc.frameCounter = 0.0;
                npc.frame.Y = 0;
            }
            else
            {
                npc.frameCounter += Math.Abs(npc.velocity.X);
                if (npc.frameCounter < 8.0)
                {
                    npc.frame.Y = 0;
                }
                else if (npc.frameCounter < 16.0)
                {
                    npc.frame.Y = frameHeight;
                }
                else if (npc.frameCounter < 24.0)
                {
                    npc.frame.Y = frameHeight * 2;
                }
                else if (npc.frameCounter < 32.0)
                {
                    npc.frame.Y = frameHeight;
                }
                else
                {
                    npc.frameCounter = 0.0;
                }
            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gore/MimeHead"), 0.9f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gore/Girder1"), 0.9f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gore/Girder1"), 0.9f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gore/Girder2"), 0.9f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gore/Girder2"), 0.9f);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.player.ZoneRockLayerHeight && spawnInfo.player.ZoneHoly && Main.hardMode ? 0.5f: 0f;
        }
    }
}
