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
	public class GrossyFloat : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Grossy Float");
			Main.npcFrameCount[npc.type] = 5;
		}

		public override void SetDefaults()
		{
			npc.damage = 70;
			npc.noTileCollide = true;
			npc.lifeMax = 200;
			npc.defense = 10;
			npc.noGravity = true;
			npc.alpha = 100;
			npc.width = 24;
			npc.aiStyle = 22;
			npc.value = 500f;
			npc.height = 56;
			npc.knockBackResist = 0.7f;
            npc.HitSound = SoundID.NPCHit1;
	        npc.DeathSound = SoundID.NPCDeath2;
			npc.buffImmune[BuffID.Poisoned] = true;
			npc.buffImmune[BuffID.OnFire] = true;
			npc.buffImmune[BuffID.CursedInferno] = true;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.GrossyFloatBanner>();
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.55f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.5f);
        }
        public override void FindFrame(int frameHeight)
        {
            if (npc.velocity.X > 0f)
            {
                npc.spriteDirection = 1;
            }
            if (npc.velocity.X < 0f)
            {
                npc.spriteDirection = -1;
            }
            npc.rotation = npc.velocity.X * 0.1f;
            if (npc.type == NPCID.Bee || npc.type == NPCID.BeeSmall)
            {
                npc.frameCounter += 1.0;
                npc.rotation = npc.velocity.X * 0.2f;
            }
            npc.frameCounter += 1.0;
            if (npc.frameCounter >= 6.0)
            {
                npc.frame.Y = npc.frame.Y + frameHeight;
                npc.frameCounter = 0.0;
            }
            if (npc.frame.Y >= frameHeight * Main.npcFrameCount[npc.type])
            {
                npc.frame.Y = 0;
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.player.GetModPlayer<ExxoAvalonOriginsModPlayer>().zoneBooger && spawnInfo.player.ZoneRockLayerHeight)
                return (spawnInfo.player.GetModPlayer<ExxoAvalonOriginsModPlayer>().zoneBooger && spawnInfo.player.ZoneRockLayerHeight) ? 1f : 0f;
            return 0f;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GrossyFloatHead"), 0.9f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GrossyFloatTail"), 0.9f);
            }
        }
    }
}