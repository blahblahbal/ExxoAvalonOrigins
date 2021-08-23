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
	public class ArmoredWraith : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Armored Wraith");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.damage = 105;
			npc.netAlways = true;
			npc.scale = 1f;
			npc.noTileCollide = true;
			npc.lifeMax = 1000;
			npc.defense = 35;
			npc.noGravity = true;
			npc.alpha = 50;
			npc.width = 24;
			npc.aiStyle = 22;
			npc.npcSlots = 1f;
			npc.value = Item.buyPrice(0, 1, 0, 0);
			npc.timeLeft = 750;
			npc.height = 44;
            npc.HitSound = SoundID.NPCHit54;
	        npc.DeathSound = SoundID.NPCDeath52;
			npc.knockBackResist = 0.5f;
			npc.buffImmune[BuffID.Confused] = true;
			npc.buffImmune[BuffID.OnFire] = true;
			npc.buffImmune[BuffID.CursedInferno] = true;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.ArmoredWraithBanner>();
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
    }
}