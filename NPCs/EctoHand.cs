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
	public class EctoHand : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ecto Hand");
			//Main.npcFrameCount[npc.type] = 2;
		}
		public override void SetDefaults()
		{
			npc.damage = 36;
			npc.lifeMax = 1600;
			npc.defense = 30;
			npc.width = 30;
			npc.height = 40;
			npc.aiStyle = 13;
			aiType = NPCID.Clinger;
			npc.value = 1000f;
			npc.knockBackResist = 0f;
            npc.HitSound = SoundID.NPCHit1;
	        npc.DeathSound = SoundID.NPCDeath1;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.behindTiles = true;
		}
        /*public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
			Vector2 vector12 = new Vector2(npc.position.X + (float)(npc.width / 2), npc.position.Y + (float)(npc.height / 2));
			float num193 = npc.ai[0] * 16f + 8f - vector12.X;
			float num204 = npc.ai[1] * 16f + 8f - vector12.Y;
			float rotation2 = (float)Math.Atan2(num204, num193) - 1.57f;
			bool flag7 = true;
			while (flag7)
			{
				int num214 = 28;
				int num225 = 40;
				float num236 = (float)Math.Sqrt(num193 * num193 + num204 * num204);
				if (num236 < (float)num225)
				{
					num214 = (int)num236 - num225 + num214;
					flag7 = false;
				}
				num236 = (float)num214 / num236;
				num193 *= num236;
				num204 *= num236;
				vector12.X += num193;
				vector12.Y += num204;
				num193 = npc.ai[0] * 16f + 8f - vector12.X;
				num204 = npc.ai[1] * 16f + 8f - vector12.Y;
				Microsoft.Xna.Framework.Color color12 = Lighting.GetColor((int)vector12.X / 16, (int)(vector12.Y / 16f));

				Texture2D texture = ModContent.GetTexture("NPCs/EctoArm");
				spriteBatch.Draw(texture, new Vector2(vector12.X - Main.screenPosition.X, vector12.Y - Main.screenPosition.Y), new Microsoft.Xna.Framework.Rectangle(0, 0, texture.Width, num214), color12, rotation2, new Vector2((float)texture.Width * 0.5f, (float)texture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
			}
			return true;
		}*/
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (spawnInfo.player.GetModPlayer<ExxoAvalonOriginsModPlayer>().zoneHellcastle && Main.tile[spawnInfo.spawnTileX, spawnInfo.spawnTileY].type == (ushort)ModContent.TileType<Tiles.ImperviousBrick>())
				return (spawnInfo.player.GetModPlayer<ExxoAvalonOriginsModPlayer>().zoneHellcastle && Main.tile[spawnInfo.spawnTileX, spawnInfo.spawnTileY].type == (ushort)ModContent.TileType<Tiles.ImperviousBrick>()) ? 1f : 0f;
			return 0f;
		}
		/*public override void AI()
        {
			if (npc.ai[0] < 0f || npc.ai[0] >= (float)Main.maxTilesX || npc.ai[1] < 0f || npc.ai[1] >= (float)Main.maxTilesX)
			{
				return;
			}
			if (Main.tile[(int)npc.ai[0], (int)npc.ai[1]] == null)
			{
				Main.tile[(int)npc.ai[0], (int)npc.ai[1]] = new Tile();
			}
			if (!Main.tile[(int)npc.ai[0], (int)npc.ai[1]].active())
			{
				npc.life = -1;
				npc.HitEffect();
				npc.active = false;
				return;
			}
			//Main.FixExploitManEaters.ProtectSpot((int)npc.ai[0], (int)npc.ai[1]);
			npc.TargetClosest();
			float num678 = 0.035f;
			float num679 = 150f;

			npc.ai[2] += 1f;
			if (npc.ai[2] > 300f)
			{
				num679 = (int)((double)num679 * 1.3);
				if (npc.ai[2] > 450f)
				{
					npc.ai[2] = 0f;
				}
			}
			Vector2 vector135 = new Vector2(npc.ai[0] * 16f + 8f, npc.ai[1] * 16f + 8f);
			float num680 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - (float)(npc.width / 2) - vector135.X;
			float num681 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - (float)(npc.height / 2) - vector135.Y;
			float num682 = (float)Math.Sqrt(num680 * num680 + num681 * num681);
			if (num682 > num679)
			{
				num682 = num679 / num682;
				num680 *= num682;
				num681 *= num682;
			}
			if (npc.position.X < npc.ai[0] * 16f + 8f + num680)
			{
				npc.velocity.X += num678;
				if (npc.velocity.X < 0f && num680 > 0f)
				{
					npc.velocity.X += num678 * 1.5f;
				}
			}
			else if (npc.position.X > npc.ai[0] * 16f + 8f + num680)
			{
				npc.velocity.X -= num678;
				if (npc.velocity.X > 0f && num680 < 0f)
				{
					npc.velocity.X -= num678 * 1.5f;
				}
			}
			if (npc.position.Y < npc.ai[1] * 16f + 8f + num681)
			{
				npc.velocity.Y += num678;
				if (npc.velocity.Y < 0f && num681 > 0f)
				{
					npc.velocity.Y += num678 * 1.5f;
				}
			}
			else if (npc.position.Y > npc.ai[1] * 16f + 8f + num681)
			{
				npc.velocity.Y -= num678;
				if (npc.velocity.Y > 0f && num681 < 0f)
				{
					npc.velocity.Y -= num678 * 1.5f;
				}
			}
			if (npc.type == 43)
			{
				if (npc.velocity.X > 3f)
				{
					npc.velocity.X = 3f;
				}
				if (npc.velocity.X < -3f)
				{
					npc.velocity.X = -3f;
				}
				if (npc.velocity.Y > 3f)
				{
					npc.velocity.Y = 3f;
				}
				if (npc.velocity.Y < -3f)
				{
					npc.velocity.Y = -3f;
				}
			}
			else if (npc.type == 175)
			{
				if (npc.velocity.X > 4f)
				{
					npc.velocity.X = 4f;
				}
				if (npc.velocity.X < -4f)
				{
					npc.velocity.X = -4f;
				}
				if (npc.velocity.Y > 4f)
				{
					npc.velocity.Y = 4f;
				}
				if (npc.velocity.Y < -4f)
				{
					npc.velocity.Y = -4f;
				}
			}
			else
			{
				if (npc.velocity.X > 2f)
				{
					npc.velocity.X = 2f;
				}
				if (npc.velocity.X < -2f)
				{
					npc.velocity.X = -2f;
				}
				if (npc.velocity.Y > 2f)
				{
					npc.velocity.Y = 2f;
				}
				if (npc.velocity.Y < -2f)
				{
					npc.velocity.Y = -2f;
				}
			}
			if (npc.type == 259 || npc.type == 260)
			{
				npc.rotation = (float)Math.Atan2(num681, num680) + 1.57f;
			}
			else
			{
				if (num680 > 0f)
				{
					npc.spriteDirection = 1;
					npc.rotation = (float)Math.Atan2(num681, num680);
				}
				if (num680 < 0f)
				{
					npc.spriteDirection = -1;
					npc.rotation = (float)Math.Atan2(num681, num680) + 3.14f;
				}
			}
			if (npc.collideX)
			{
				npc.netUpdate = true;
				npc.velocity.X = npc.oldVelocity.X * -0.7f;
				if (npc.velocity.X > 0f && npc.velocity.X < 2f)
				{
					npc.velocity.X = 2f;
				}
				if (npc.velocity.X < 0f && npc.velocity.X > -2f)
				{
					npc.velocity.X = -2f;
				}
			}
			if (npc.collideY)
			{
				npc.netUpdate = true;
				npc.velocity.Y = npc.oldVelocity.Y * -0.7f;
				if (npc.velocity.Y > 0f && npc.velocity.Y < 2f)
				{
					npc.velocity.Y = 2f;
				}
				if (npc.velocity.Y < 0f && npc.velocity.Y > -2f)
				{
					npc.velocity.Y = -2f;
				}
			}
			if (Main.netMode == 1)
			{
				return;
			}
			if (npc.type == 101 && !Main.player[npc.target].dead)
			{
				if (npc.justHit)
				{
					npc.localAI[0] = 0f;
				}
				npc.localAI[0] += 1f;
				if (npc.localAI[0] >= 120f)
				{
					if (!Collision.SolidCollision(npc.position, npc.width, npc.height) && Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
					{
						float num683 = 10f;
						vector135 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
						num680 = Main.player[npc.target].position.X + (float)Main.player[npc.target].width * 0.5f - vector135.X + (float)Main.rand.Next(-10, 11);
						num681 = Main.player[npc.target].position.Y + (float)Main.player[npc.target].height * 0.5f - vector135.Y + (float)Main.rand.Next(-10, 11);
						num682 = (float)Math.Sqrt(num680 * num680 + num681 * num681);
						num682 = num683 / num682;
						num680 *= num682;
						num681 *= num682;
						int num684 = 22;
						if (Main.expertMode)
						{
							num684 = (int)((double)num684 * 0.8);
						}
						int num685 = 96;
						int num686 = Projectile.NewProjectile(vector135.X, vector135.Y, num680, num681, num685, num684, 0f, Main.myPlayer);
						Main.projectile[num686].timeLeft = 300;
						npc.localAI[0] = 0f;
					}
					else
					{
						npc.localAI[0] = 100f;
					}
				}
			}
			if (npc.type != 260 || Main.player[npc.target].dead)
			{
				return;
			}
			if (npc.justHit)
			{
				npc.localAI[0] = 0f;
			}
			npc.localAI[0] += 1f;
			if (!(npc.localAI[0] >= 150f))
			{
				return;
			}
			if (!Collision.SolidCollision(npc.position, npc.width, npc.height))
			{
				float num687 = 14f;
				vector135 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
				num680 = Main.player[npc.target].position.X + (float)Main.player[npc.target].width * 0.5f - vector135.X + (float)Main.rand.Next(-10, 11);
				float num690 = Math.Abs(num680 * 0.1f);
				if (num681 > 0f)
				{
					num690 = 0f;
				}
				num681 = Main.player[npc.target].position.Y + (float)Main.player[npc.target].height * 0.5f - vector135.Y + (float)Main.rand.Next(-10, 11) - num690;
				num682 = (float)Math.Sqrt(num680 * num680 + num681 * num681);
				num682 = num687 / num682;
				num680 *= num682;
				num681 *= num682;
				int num691 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, 261);
				Main.npc[num691].velocity.X = num680;
				Main.npc[num691].velocity.Y = num681;
				Main.npc[num691].netUpdate = true;
				npc.localAI[0] = 0f;
			}
			else
			{
				npc.localAI[0] = 250f;
			}
		}*/
	}
}
