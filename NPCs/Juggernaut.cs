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
	public class Juggernaut : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Juggernaut");
			Main.npcFrameCount[npc.type] = 15;
		}

		public override void SetDefaults()
		{
			npc.damage = 180;
			npc.scale = 1f;
			npc.lifeMax = 11000;
			npc.defense = 70;
			npc.lavaImmune = true;
			npc.width = 31;
			npc.aiStyle = -1;
			npc.npcSlots = 3f;
			npc.value = 700000f;
			npc.timeLeft = 10000;
			npc.height = 68;
			npc.knockBackResist = 0.05f;
            npc.HitSound = SoundID.NPCHit2;
	        npc.DeathSound = SoundID.NPCDeath2;
		}

		public override void NPCLoot()
		{
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.OblivionOre>(), Main.rand.Next(22, 34), false, 0, false);
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.IllegalWeaponInstructions>(), 1, false, 0, false);
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.SoulofBlight>(), Main.rand.Next(3) + 1, false, 0, false);
			npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().jugRunonce = false;
			if (Main.netMode == NetmodeID.SinglePlayer)
			{
				Main.NewText("A Juggernaut has been defeated!", 175, 75, 255, false);
			}
			else if (Main.netMode == NetmodeID.Server)
			{
                NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("A Juggernaut has been defeated!"), new Color(175, 75, 255));
				//NetMessage.SendData(25, -1, -1, NetworkText.FromLiteral("A Juggernaut has been defeated!"), 255, 175f, 75f, 255f, 0);
			}
		}

        public override void AI()
        {
            var num441 = 30;
            var flag40 = false;
            if (!npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().jugRunonce)
            {
                npc.position = Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].position;
                npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().jugRunonce = true;
                if (Main.netMode == NetmodeID.SinglePlayer) Main.NewText("A Juggernaut has awoken!", 175, 75, 255, false);
                else if (Main.netMode == NetmodeID.Server) NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("A Juggernaut has awoken!"), new Color(175, 75, 255));
            }
            if (npc.justHit)
            {
                if (Main.rand.Next(2) == 1)
                {
                    NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.Skeleton, 0);
                }
                if (Main.rand.Next(4) == 1)
                {
                    NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, ModContent.NPCType<EyeBones>(), 0);
                }
                if (Main.rand.Next(10) == 1)
                {
                    NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.ArmoredSkeleton, 0);
                }
                if (Main.rand.Next(25) == 1)
                {
                    NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, ModContent.NPCType<CursedMagmaSkeleton>(), 0);
                }
                if (Main.rand.Next(33) == 1)
                {
                    NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.ArmoredViking, 0);
                }
            }
            if (npc.velocity.Y == 0f && ((npc.velocity.X > 0f && npc.direction < 0) || (npc.velocity.X < 0f && npc.direction > 0)))
            {
                flag40 = true;
                npc.ai[3] += 1f;
            }
            if (npc.position.X == npc.oldPosition.X || npc.ai[3] >= num441 || flag40)
            {
                npc.ai[3] += 1f;
            }
            else if (npc.ai[3] > 0f)
            {
                npc.ai[3] -= 1f;
            }
            if (npc.ai[3] > num441 * 10)
            {
                npc.ai[3] = 0f;
            }
            if (npc.justHit)
            {
                npc.ai[3] = 0f;
            }
            if (npc.ai[3] == num441)
            {
                npc.netUpdate = true;
            }
            var vector41 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
            var num442 = Main.player[npc.target].position.X + Main.player[npc.target].width * 0.5f - vector41.X;
            var num443 = Main.player[npc.target].position.Y - vector41.Y;
            var num444 = (float)Math.Sqrt(num442 * num442 + num443 * num443);
            if (num444 < 200f)
            {
                npc.ai[3] = 0f;
            }
            if (npc.ai[3] < num441)
            {
                npc.TargetClosest(true);
            }
            else
            {
                if (npc.velocity.X == 0f)
                {
                    if (npc.velocity.Y == 0f)
                    {
                        npc.ai[0] += 1f;
                        if (npc.ai[0] >= 2f)
                        {
                            npc.direction *= -1;
                            npc.spriteDirection = npc.direction;
                            npc.ai[0] = 0f;
                        }
                    }
                }
                else
                {
                    npc.ai[0] = 0f;
                }
                npc.directionY = -1;
                if (npc.direction == 0)
                {
                    npc.direction = 1;
                }
            }
            var num445 = 6f;
            if (npc.velocity.Y == 0f || npc.wet || (npc.velocity.X <= 0f && npc.direction < 0) || (npc.velocity.X >= 0f && npc.direction > 0))
            {
                if (npc.velocity.X < -num445 || npc.velocity.X > num445)
                {
                    if (npc.velocity.Y == 0f)
                    {
                        npc.velocity *= 0.8f;
                    }
                }
                else if (npc.velocity.X < num445 && npc.direction == 1)
                {
                    npc.velocity.X = npc.velocity.X + 0.07f;
                    if (npc.velocity.X > num445)
                    {
                        npc.velocity.X = num445;
                    }
                }
                else if (npc.velocity.X > -num445 && npc.direction == -1)
                {
                    npc.velocity.X = npc.velocity.X - 0.07f;
                    if (npc.velocity.X < -num445)
                    {
                        npc.velocity.X = -num445;
                    }
                }
            }
            if (npc.velocity.Y >= 0f)
            {
                var num446 = 0;
                if (npc.velocity.X < 0f)
                {
                    num446 = -1;
                }
                if (npc.velocity.X > 0f)
                {
                    num446 = 1;
                }
                var vector42 = npc.position;
                vector42.X += npc.velocity.X;
                var num447 = (int)((vector42.X + npc.width / 2 + (npc.width / 2 + 1) * num446) / 16f);
                var num448 = (int)((vector42.Y + npc.height - 1f) / 16f);
                if (Main.tile[num447, num448] == null)
                {
                    Main.tile[num447, num448] = new Tile();
                }
                if (Main.tile[num447, num448 - 1] == null)
                {
                    Main.tile[num447, num448 - 1] = new Tile();
                }
                if (Main.tile[num447, num448 - 2] == null)
                {
                    Main.tile[num447, num448 - 2] = new Tile();
                }
                if (Main.tile[num447, num448 - 3] == null)
                {
                    Main.tile[num447, num448 - 3] = new Tile();
                }
                if (Main.tile[num447, num448 + 1] == null)
                {
                    Main.tile[num447, num448 + 1] = new Tile();
                }
                if (num447 * 16 < vector42.X + npc.width && num447 * 16 + 16 > vector42.X && ((Main.tile[num447, num448].nactive() && !Main.tile[num447, num448].topSlope() && !Main.tile[num447, num448 - 1].topSlope() && Main.tileSolid[Main.tile[num447, num448].type] && !Main.tileSolidTop[Main.tile[num447, num448].type]) || (Main.tile[num447, num448 - 1].halfBrick() && Main.tile[num447, num448 - 1].nactive())) && (!Main.tile[num447, num448 - 1].nactive() || !Main.tileSolid[Main.tile[num447, num448 - 1].type] || Main.tileSolidTop[Main.tile[num447, num448 - 1].type] || (Main.tile[num447, num448 - 1].halfBrick() && (!Main.tile[num447, num448 - 4].nactive() || !Main.tileSolid[Main.tile[num447, num448 - 4].type] || Main.tileSolidTop[Main.tile[num447, num448 - 4].type]))) && (!Main.tile[num447, num448 - 2].nactive() || !Main.tileSolid[Main.tile[num447, num448 - 2].type] || Main.tileSolidTop[Main.tile[num447, num448 - 2].type]) && (!Main.tile[num447, num448 - 3].nactive() || !Main.tileSolid[Main.tile[num447, num448 - 3].type] || Main.tileSolidTop[Main.tile[num447, num448 - 3].type]) && (!Main.tile[num447 - num446, num448 - 3].nactive() || !Main.tileSolid[Main.tile[num447 - num446, num448 - 3].type]))
                {
                    float num449 = num448 * 16;
                    if (Main.tile[num447, num448].halfBrick())
                    {
                        num449 += 8f;
                    }
                    if (Main.tile[num447, num448 - 1].halfBrick())
                    {
                        num449 -= 8f;
                    }
                    if (num449 < vector42.Y + npc.height)
                    {
                        var num450 = vector42.Y + npc.height - num449;
                        if (num450 <= 16.1)
                        {
                            npc.gfxOffY += npc.position.Y + npc.height - num449;
                            npc.position.Y = num449 - npc.height;
                            if (num450 < 9f)
                            {
                                npc.stepSpeed = 1f;
                            }
                            else
                            {
                                npc.stepSpeed = 2f;
                            }
                        }
                    }
                }
            }
            if (npc.velocity.Y != 0f)
            {
                return;
            }
            var num451 = (int)((npc.position.X + npc.width / 2 + (npc.width / 2 + 2) * npc.direction + npc.velocity.X * 5f) / 16f);
            var num452 = (int)((npc.position.Y + npc.height - 15f) / 16f);
            if (Main.tile[num451, num452] == null)
            {
                Main.tile[num451, num452] = new Tile();
            }
            if (Main.tile[num451, num452 - 1] == null)
            {
                Main.tile[num451, num452 - 1] = new Tile();
            }
            if (Main.tile[num451, num452 - 2] == null)
            {
                Main.tile[num451, num452 - 2] = new Tile();
            }
            if (Main.tile[num451, num452 - 3] == null)
            {
                Main.tile[num451, num452 - 3] = new Tile();
            }
            if (Main.tile[num451, num452 + 1] == null)
            {
                Main.tile[num451, num452 + 1] = new Tile();
            }
            if (Main.tile[num451 + npc.direction, num452 - 1] == null)
            {
                Main.tile[num451 + npc.direction, num452 - 1] = new Tile();
            }
            if (Main.tile[num451 + npc.direction, num452 + 1] == null)
            {
                Main.tile[num451 + npc.direction, num452 + 1] = new Tile();
            }
            if (Main.tile[num451 - npc.direction, num452 + 1] == null)
            {
                Main.tile[num451 - npc.direction, num452 + 1] = new Tile();
            }
            if ((npc.velocity.X >= 0f || npc.spriteDirection != -1) && (npc.velocity.X <= 0f || npc.spriteDirection != 1))
            {
                return;
            }
            if (Main.tile[num451, num452 - 2].nactive() && Main.tileSolid[Main.tile[num451, num452 - 2].type])
            {
                if (Main.tile[num451, num452 - 3].nactive() && Main.tileSolid[Main.tile[num451, num452 - 3].type])
                {
                    npc.velocity.Y = -8.5f;
                    npc.netUpdate = true;
                    return;
                }
                npc.velocity.Y = -7.5f;
                npc.netUpdate = true;
                return;
            }
            else
            {
                if (Main.tile[num451, num452 - 1].nactive() && !Main.tile[num451, num452 - 1].topSlope() && Main.tileSolid[Main.tile[num451, num452 - 1].type])
                {
                    npc.velocity.Y = -7f;
                    npc.netUpdate = true;
                    return;
                }
                if (npc.position.Y + npc.height - num452 * 16 > 20f && Main.tile[num451, num452].nactive() && !Main.tile[num451, num452].topSlope() && Main.tileSolid[Main.tile[num451, num452].type])
                {
                    npc.velocity.Y = -6f;
                    npc.netUpdate = true;
                    return;
                }
                if ((npc.directionY < 0 || Math.Abs(npc.velocity.X) > 3f) && (!Main.tile[num451, num452 + 2].nactive() || !Main.tileSolid[Main.tile[num451, num452 + 2].type]) && (!Main.tile[num451 + npc.direction, num452 + 3].nactive() || !Main.tileSolid[Main.tile[num451 + npc.direction, num452 + 3].type]))
                {
                    npc.velocity.Y = -8f;
                    npc.netUpdate = true;
                    return;
                }
                return;
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
                npc.frame.Y = frameHeight;
            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/JuggernautHead"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Bone1"), 1.7f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Bone2"), 1.7f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Bone1"), 1.7f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Bone2"), 1.7f);
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.player.ZoneRockLayerHeight && Main.hardMode && ExxoAvalonOrigins.superHardmode ? 0.025f * ExxoAvalonOriginsGlobalNPC.endoSpawnRate : 0f;
        }
    }
}