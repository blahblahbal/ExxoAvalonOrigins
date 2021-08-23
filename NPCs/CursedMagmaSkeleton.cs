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
	public class CursedMagmaSkeleton : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed Magma Skeleton");
			Main.npcFrameCount[npc.type] = 15;
		}
        public override void SetDefaults()
		{
			npc.damage = 120;
			npc.netAlways = true;
			npc.scale = 1.35f;
			npc.lifeMax = 2000;
			npc.defense = 40;
			npc.lavaImmune = true;
			npc.width = 18;
			npc.aiStyle = 3;
			npc.npcSlots = 1.1f;
			npc.value = Item.buyPrice(0, 1, 0, 0);
			npc.timeLeft = 750;
			npc.height = 40;
			npc.knockBackResist = 0.1f;
            npc.HitSound = SoundID.NPCHit2;
	        npc.DeathSound = SoundID.NPCDeath2;
			npc.buffImmune[BuffID.Confused] = true;
			npc.buffImmune[BuffID.OnFire] = true;
			npc.buffImmune[BuffID.CursedInferno] = true;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.CursedMagmaSkeletonBanner>();
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(255, 255, 255);
        }
        public override void NPCLoot()
		{
			if (Main.rand.Next(75) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.GreekExtinguisher>(), 1, false, 0, false);
			}
			if (Main.rand.Next(10) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.SoulofBlight>(), Main.rand.Next(4, 7), false, 0, false);
			}
		}

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.player.ZoneRockLayerHeight && !spawnInfo.player.ZoneDungeon && ExxoAvalonOrigins.superHardmode ? 0.03f : 0f;
        }
        public override void AI()
        {
            Lighting.AddLight((int)((npc.position.X + (float)(npc.width / 2)) / 16f), (int)((npc.position.Y + (float)(npc.height / 2)) / 16f), 0.6f, 0.87f, 0.0f);
            if (Main.rand.Next(5) == 0)
            {
                int num10 = Dust.NewDust(npc.position, npc.width, npc.height, DustID.CursedTorch, 0f, 0f, 0, default(Color), 1.6f);
                Main.dust[num10].noGravity = true;
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
                npc.frame.Y = 0;
            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 3; i++)
            {
                int num890 = Dust.NewDust(npc.position, npc.width, npc.height, DustID.CursedTorch, 0f, 0f, 0, default(Color), 1f);
                Main.dust[num890].velocity *= 5f;
                Main.dust[num890].scale = 1f;
                Main.dust[num890].noGravity = true;
                Main.dust[num890].fadeIn = 2f;
            }
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CursedMagmaSkeletonHelmet"), 1.2f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Bone1"), 1.2f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Bone2"), 1.2f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Bone1"), 1.2f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Bone2"), 1.2f);
                for (int i = 0; i < 20; i++)
                {
                    int num890 = Dust.NewDust(npc.position, npc.width, npc.height, DustID.CursedTorch, 0f, 0f, 0, default(Color), 1f);
                    Main.dust[num890].velocity *= 7f;
                    Main.dust[num890].scale = 1.6f;
                    Main.dust[num890].noGravity = true;
                }
            }
        }
    }
}