using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;

namespace ExxoAvalonOrigins.NPCs
{
	public class Gargoyle : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gargoyle");
			Main.npcFrameCount[npc.type] = 5;
		}
        public override void SetDefaults()
		{
			npc.damage = 85;
			npc.netAlways = true;
			npc.scale = 1.35f;
			npc.lifeMax = 1400;
			npc.defense = 28;
			npc.lavaImmune = true;
			npc.width = 34;
			npc.aiStyle = 17;
			npc.value = Item.buyPrice(0, 1, 0, 0);
			npc.height = 50;
			npc.knockBackResist = 0.1f;
            npc.HitSound = SoundID.NPCHit2;
	        npc.DeathSound = SoundID.NPCDeath2;
			npc.buffImmune[BuffID.Confused] = true;
			npc.buffImmune[BuffID.OnFire] = true;
			npc.buffImmune[BuffID.CursedInferno] = true;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.GargoyleBanner>();
        }
        public override void NPCLoot()
		{
			
		}

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.player.GetModPlayer<ExxoAvalonOriginsModPlayer>().zoneHellcastle)
                return (spawnInfo.player.GetModPlayer<ExxoAvalonOriginsModPlayer>().zoneHellcastle) ? 1f : 0f;
            return 0f;
        }
        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;
            npc.rotation = npc.velocity.X * 0.1f;
            if (npc.velocity.X == 0f && npc.velocity.Y == 0f)
            {
                npc.frame.Y = 0;
                npc.frameCounter = 0.0;
            }
            else
            {
                npc.frameCounter += 1.0;
                if (npc.frameCounter <= 7)
                {
                    npc.frame.Y = frameHeight;
                }
                else if (npc.frameCounter <= 14)
                {
                    npc.frame.Y = frameHeight * 2;
                }
                else if (npc.frameCounter <= 21)
                {
                    npc.frame.Y = frameHeight * 3;
                }
                else if (npc.frameCounter <= 28)
                {
                    npc.frame.Y = frameHeight * 4;
                }
                else
                {
                    npc.frameCounter = 0;
                }
            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GargoyleGore3"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GargoyleGore3"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GargoyleGore4"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GargoyleWing"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GargoyleWing"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GargoyleHead"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GargoyleGore5"), 1f);
            }
        }
    }
}