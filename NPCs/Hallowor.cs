using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace ExxoAvalonOrigins.NPCs
{
	public class Hallowor : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hallowor");
			Main.npcFrameCount[npc.type] = 4;
		}
		public override void SetDefaults()
		{
			npc.npcSlots = 1;
			npc.width = 40;
			npc.height = 38;
			npc.aiStyle = -1;
			npc.timeLeft = 1750;
			animationType = 75;
			npc.damage = 62;
			npc.defense = 28;
			npc.HitSound = SoundID.NPCHit5;
			npc.DeathSound = SoundID.NPCDeath7;
			npc.lifeMax = 530;
			npc.scale = 1.8f;
			npc.knockBackResist = 0.35f;
			npc.noGravity = true;
			npc.noTileCollide = false;
			npc.value = 900;
			npc.buffImmune[BuffID.Confused] = true;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.HalloworBanner>();
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.55);
            npc.damage = (int)(npc.damage * 0.5f);
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return Main.hardMode && !spawnInfo.player.InPillarZone() && spawnInfo.player.ZoneHoly && spawnInfo.spawnTileY < (Main.maxTilesY - 200) ? 0.13f : 0f;
		}
		public override void NPCLoot()
		{
			if (Main.rand.Next(3) == 0)
			{
				Item.NewItem(npc.position, new Vector2(npc.width, npc.height), ItemID.PixieDust, 1);
			}
			if (Main.rand.Next(50) == 0)
            {
				Item.NewItem(npc.position, new Vector2(npc.width, npc.height), ItemID.Megaphone, 1);
			}
		}
		public override void AI()
		{
			if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead)
			{
				npc.TargetClosest(true);
			}
			float num73 = 4.2f;
			float num74 = 0.022f;
			Vector2 vector11 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
			float num75 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2);
			float num76 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2);
			num75 = (float)((int)(num75 / 8f) * 8);
			num76 = (float)((int)(num76 / 8f) * 8);
			vector11.X = (float)((int)(vector11.X / 8f) * 8);
			vector11.Y = (float)((int)(vector11.Y / 8f) * 8);
			num75 -= vector11.X;
			num76 -= vector11.Y;
			float num77 = (float)Math.Sqrt((double)(num75 * num75 + num76 * num76));
			float num78 = num77;
			if (num77 == 0f)
			{
				num75 = npc.velocity.X;
				num76 = npc.velocity.Y;
			}
			else
			{
				num77 = num73 / num77;
				num75 *= num77;
				num76 *= num77;
			}
			npc.ai[0] += 1f;
			if (npc.ai[0] > 0f)
			{
				npc.velocity.Y = npc.velocity.Y + 0.023f;
			}
			else
			{
				npc.velocity.Y = npc.velocity.Y - 0.023f;
			}
			if (npc.ai[0] < -100f || npc.ai[0] > 100f)
			{
				npc.velocity.X = npc.velocity.X + 0.023f;
			}
			else
			{
				npc.velocity.X = npc.velocity.X - 0.023f;
			}
			if (npc.ai[0] > 200f)
			{
				npc.ai[0] = -200f;
			}
			npc.velocity.X = npc.velocity.X + num75 * 0.007f;
			npc.velocity.Y = npc.velocity.Y + num76 * 0.007f;
			if (Main.player[npc.target].dead)
			{
				num75 = (float)npc.direction * num73 / 2f;
				num76 = -num73 / 2f;
			}
			if (npc.velocity.X < num75)
			{
				npc.velocity.X = npc.velocity.X + num74;
				if (npc.velocity.X < 0f && num75 > 0f)
				{
					npc.velocity.X = npc.velocity.X + num74;
				}
			}
			else
			{
				if (npc.velocity.X > num75)
				{
					npc.velocity.X = npc.velocity.X - num74;
					if (npc.velocity.X > 0f && num75 < 0f)
					{
						npc.velocity.X = npc.velocity.X - num74;
					}
				}
			}
			if (npc.velocity.Y < num76)
			{
				npc.velocity.Y = npc.velocity.Y + num74;
				if (npc.velocity.Y < 0f && num76 > 0f)
				{
					npc.velocity.Y = npc.velocity.Y + num74;
				}
			}
			else
			{
				if (npc.velocity.Y > num76)
				{
					npc.velocity.Y = npc.velocity.Y - num74;
					if (npc.velocity.Y > 0f && num76 < 0f)
					{
						npc.velocity.Y = npc.velocity.Y - num74;
					}
				}
			}
			npc.rotation = (float)Math.Atan2((double)num76, (double)num75) - 1.57f;
			float num83 = 0.7f;
			if (npc.collideX)
			{
				npc.netUpdate = true;
				npc.velocity.X = npc.oldVelocity.X * -num83;
				if (npc.direction == -1 && npc.velocity.X > 0f && npc.velocity.X < 2f)
				{
					npc.velocity.X = 2f;
				}
				if (npc.direction == 1 && npc.velocity.X < 0f && npc.velocity.X > -2f)
				{
					npc.velocity.X = -2f;
				}
			}
			if (npc.collideY)
			{
				npc.netUpdate = true;
				npc.velocity.Y = npc.oldVelocity.Y * -num83;
				if (npc.velocity.Y > 0f && (double)npc.velocity.Y < 1.5)
				{
					npc.velocity.Y = 2f;
				}
				if (npc.velocity.Y < 0f && (double)npc.velocity.Y > -1.5)
				{
					npc.velocity.Y = -2f;
				}
			}
			if (Main.rand.Next(20) == 0)
			{
				// Was originally vile dust but I changed it
				int num85 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + (float)npc.height * 0.25f), npc.width, (int)((float)npc.height * 0.5f), DustID.Pixie, npc.velocity.X, 2f, 75, npc.color, npc.scale);
				Dust expr_5B51_cp_0 = Main.dust[num85];
				expr_5B51_cp_0.velocity.X = expr_5B51_cp_0.velocity.X * 0.5f;
				Dust expr_5B6F_cp_0 = Main.dust[num85];
				expr_5B6F_cp_0.velocity.Y = expr_5B6F_cp_0.velocity.Y * 0.1f;
			}
			if (npc.wet)
			{
				if (npc.velocity.Y > 0f)
				{
					npc.velocity.Y = npc.velocity.Y * 0.95f;
				}
				npc.velocity.Y = npc.velocity.Y - 0.3f;
				if (npc.velocity.Y < -2f)
				{
					npc.velocity.Y = -2f;
				}
			}
			if (Main.netMode != NetmodeID.MultiplayerClient && !Main.player[npc.target].dead)
			{
				if (npc.justHit)
				{
					npc.localAI[0] = 0f;
				}
				npc.localAI[0] += 1f;
				if (npc.localAI[0] == 180f)
				{
					if (Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
					{
						NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2) + npc.velocity.X), (int)(npc.position.Y + (float)(npc.height / 2) + npc.velocity.Y), ModContent.NPCType<NPCs.HallowSpit>(), 0);
					}
					npc.localAI[0] = 0f;
				}
			}
			if (((npc.velocity.X > 0f && npc.oldVelocity.X < 0f) || (npc.velocity.X < 0f && npc.oldVelocity.X > 0f) || (npc.velocity.Y > 0f && npc.oldVelocity.Y < 0f) || (npc.velocity.Y < 0f && npc.oldVelocity.Y > 0f)) && !npc.justHit)
			{
				npc.netUpdate = true;
				return;
			}
		}
		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Rectangle R = new Rectangle((int)npc.position.X, (int)(npc.position.Y + ((npc.height - npc.width) / 2)), npc.width, npc.width);
				int C = 50;
				float vR = .4f;
				for (int i = 1; i <= C; i++)
				{
					int D = Dust.NewDust(npc.position, R.Width, R.Height, DustID.Enchanted_Gold, 0, 0, 100, new Color(), 2f);
					Main.dust[D].noGravity = true;
					Main.dust[D].velocity.X = vR * (Main.dust[D].position.X - (npc.position.X + (npc.width / 2)));
					Main.dust[D].velocity.Y = vR * (Main.dust[D].position.Y - (npc.position.Y + (npc.height / 2)));
				}
				for (int i2 = 1; i2 <= C; i2++)
				{
					int D2 = Dust.NewDust(npc.position, R.Width, R.Height, DustID.MagicMirror, 0, 0, 100, new Color(), 2f);
					Main.dust[D2].noGravity = true;
					Main.dust[D2].velocity.X = vR * (Main.dust[D2].position.X - (npc.position.X + (npc.width / 2)));
					Main.dust[D2].velocity.Y = vR * (Main.dust[D2].position.Y - (npc.position.Y + (npc.height / 2)));
				}
			}
		}
	}
}
