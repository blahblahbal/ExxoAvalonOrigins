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
	public class HellboundLizard : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hellbound Lizard");
			Main.npcFrameCount[npc.type] = 16;
		}
		public override void SetDefaults()
		{
			npc.damage = 60;
			npc.lifeMax = 540;
			npc.defense = 20;
			npc.lavaImmune = true;
			npc.width = 18;
			npc.aiStyle = 3;
			npc.value = 1000f;
			npc.height = 40;
			npc.knockBackResist = 0.4f;
            npc.HitSound = SoundID.NPCHit1;
	        npc.DeathSound = SoundID.NPCDeath1;
			npc.buffImmune[BuffID.Confused] = true;
            npc.buffImmune[BuffID.OnFire] = true;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.HellboundLizardBanner>();
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(255, 255, 255);
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
        public override void AI()
        {
            Lighting.AddLight((int)((npc.position.X + (float)(npc.width / 2)) / 16f), (int)((npc.position.Y + (float)(npc.height / 2)) / 16f), 0.9f, 0.25f, 0.05f);
            if (Main.rand.Next(7) == 0)
            {
                int num10 = Dust.NewDust(npc.position, npc.width, npc.height, 6, 0f, 0f, 0, default(Color), 1.2f);
                Main.dust[num10].noGravity = true;
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.player.GetModPlayer<ExxoAvalonOriginsModPlayer>().zoneHellcastle)
                return (spawnInfo.player.GetModPlayer<ExxoAvalonOriginsModPlayer>().zoneHellcastle) ? 1f : 0f;
            return 0f;
        }
        public override void NPCLoot()
        {
            for (int i = 0; i < 20; i++)
            {
                int num890 = Dust.NewDust(npc.position, npc.width, npc.height, 6, 0f, 0f, 0, default(Color), 1f);
                Main.dust[num890].velocity *= 5f;
                Main.dust[num890].scale = 1.2f;
                Main.dust[num890].noGravity = true;
            }
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/HellboundLizardGore1"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/HellboundLizardGore2"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/HellboundLizardGore2"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/HellboundLizardGore3"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/HellboundLizardGore3"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/HellboundLizardGore4"), 1f);
            }
        }
    }
}