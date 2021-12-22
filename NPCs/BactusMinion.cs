using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExxoAvalonOrigins.Items.Material;
using ExxoAvalonOrigins.Items.Placeable.Tile;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.NPCs
{
	public class BactusMinion : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bactus Minion");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.damage = 25;
			npc.lifeMax = 125;
			npc.defense = 5;
			npc.noGravity = true;
			npc.width = 30;
			npc.aiStyle = -1;
			npc.noTileCollide = true;
			npc.height = 30;
            npc.HitSound = SoundID.NPCHit1;
	        npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.8f;
		}

        public override void NPCLoot()
        {
            if (NPC.AnyNPCs(ModContent.NPCType<BacteriumPrime>()))
            {
                if (Main.rand.Next(3) != 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Booger>(), Main.rand.Next(1, 4), false, 0, false);
                }
                if (Main.rand.Next(3) != 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<BacciliteOre>(), Main.rand.Next(4, 11), false, 0, false);
                }
                if (Main.rand.Next(2) == 0 && Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].statLife < Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].statLifeMax2)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Heart, 1, false, 0, false);
                }
            }
        }

        public override void AI()
        {
            if (ExxoAvalonOriginsGlobalNPC.boogerBoss < 0)
            {
                npc.active = false;
                npc.netUpdate = true;
                return;
            }
            if (npc.ai[0] == 0f)
            {
                var vector107 = new Vector2(npc.Center.X, npc.Center.Y);
                var num880 = Main.npc[ExxoAvalonOriginsGlobalNPC.boogerBoss].Center.X - vector107.X;
                var num881 = Main.npc[ExxoAvalonOriginsGlobalNPC.boogerBoss].Center.Y - vector107.Y;
                var num882 = (float)Math.Sqrt(num880 * num880 + num881 * num881);
                if (num882 > 90f)
                {
                    num882 = 8f / num882;
                    num880 *= num882;
                    num881 *= num882;
                    npc.velocity.X = (npc.velocity.X * 15f + num880) / 16f;
                    npc.velocity.Y = (npc.velocity.Y * 15f + num881) / 16f;
                    return;
                }
                if (Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y) < 8f)
                {
                    npc.velocity.Y = npc.velocity.Y * 1.05f;
                    npc.velocity.X = npc.velocity.X * 1.05f;
                }
                if (Main.netMode != NetmodeID.MultiplayerClient && Main.rand.Next(200) == 0)
                {
                    npc.TargetClosest(true);
                    vector107 = new Vector2(npc.Center.X, npc.Center.Y);
                    num880 = Main.player[npc.target].Center.X - vector107.X;
                    num881 = Main.player[npc.target].Center.Y - vector107.Y;
                    num882 = (float)Math.Sqrt(num880 * num880 + num881 * num881);
                    num882 = 8f / num882;
                    npc.velocity.X = num880 * num882;
                    npc.velocity.Y = num881 * num882;
                    npc.ai[0] = 1f;
                    npc.netUpdate = true;
                    return;
                }
            }
            else
            {
                var vector108 = new Vector2(npc.Center.X, npc.Center.Y);
                var num883 = Main.npc[ExxoAvalonOriginsGlobalNPC.boogerBoss].Center.X - vector108.X;
                var num884 = Main.npc[ExxoAvalonOriginsGlobalNPC.boogerBoss].Center.Y - vector108.Y;
                var num885 = (float)Math.Sqrt(num883 * num883 + num884 * num884);
                if (num885 > 700f || npc.justHit)
                {
                    npc.ai[0] = 0f;
                    return;
                }
            }
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 1.0;
            if (npc.frameCounter >= 8.0)
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
