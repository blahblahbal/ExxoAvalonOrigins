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
	public class VampireHarpy : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vampire Harpy");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.damage = 110;
			npc.scale = 1.3f;
			npc.lifeMax = 953;
			npc.defense = 25;
			npc.noGravity = true;
			npc.alpha = 50;
			npc.width = 38;
			npc.aiStyle = 14;
			npc.npcSlots = 2f;
			npc.value = 10000f;
			npc.timeLeft = 750;
			npc.height = 34;
			npc.knockBackResist = 0.4f;
            npc.HitSound = SoundID.NPCHit1;
	        npc.DeathSound = SoundID.NPCDeath1;
			npc.buffImmune[BuffID.Confused] = true;
			npc.buffImmune[BuffID.OnFire] = true;
			npc.buffImmune[BuffID.CursedInferno] = true;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.VampireHarpyBanner>();
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

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/VampireHarpyHead"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/VampireHarpyWing"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/VampireHarpyHead"), 1f);
            }
        }
    }
}