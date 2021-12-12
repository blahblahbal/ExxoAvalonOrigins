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
	public class CursedScepter : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed Scepter");
			Main.npcFrameCount[npc.type] = 6;
		}
		public override void SetDefaults()
		{
			npc.damage = 61;
			npc.lifeMax = 226;
			npc.defense = 18;
			npc.lavaImmune = true;
			npc.width = 18;
			npc.aiStyle = 23;
			npc.value = 1000f;
            npc.scale = 1.3f;
			npc.height = 40;
			npc.knockBackResist = 0.3f;
            npc.HitSound = SoundID.NPCHit4;
	        npc.DeathSound = SoundID.NPCDeath6;
			npc.buffImmune[BuffID.Confused] = true;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.CursedScepterBanner>();
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.75f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.5f);
        }
        public override void FindFrame(int frameHeight)
        {
            if (npc.ai[0] == 2f)
            {
                npc.frameCounter = 0.0;
                npc.frame.Y = 0;
            }
            else
            {
                npc.frameCounter += 1.0;
                if (npc.frameCounter >= 4.0)
                {
                    npc.frameCounter = 0.0;
                    npc.frame.Y = npc.frame.Y + frameHeight;
                    if (npc.frame.Y / frameHeight >= Main.npcFrameCount[npc.type])
                    {
                        npc.frame.Y = 0;
                    }
                }
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return Main.hardMode && spawnInfo.player.ZoneDungeon ? 0.1f * ExxoAvalonOriginsGlobalNPC.endoSpawnRate : 0f;
        }
        public override void NPCLoot()
        {
            if (Main.rand.Next(100) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Nazar, 1, false, -1, false);
            }
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/IrateBonesHelmet"), 1f);
                //Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MagmaChestplate"), 1f);
            }
        }
    }
}