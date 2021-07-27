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
	public class PyrasiteBody : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pyrasite Body");
			Main.npcFrameCount[npc.type] = 1;
		}

		public override void SetDefaults()
		{
			npc.damage = 8;
			npc.netAlways = true;
			npc.noTileCollide = true;
			npc.lifeMax = 70;
			npc.defense = 4;
			npc.noGravity = true;
			npc.width = 26;
			npc.aiStyle = -1;
			npc.behindTiles = true;
			npc.value = 500f;
			npc.height = 26;
			npc.knockBackResist = 0f;
            npc.HitSound = SoundID.NPCHit1;
	        npc.DeathSound = SoundID.NPCDeath1;
        }

        public override void AI()
        {
            if (npc.ai[3] > 0f)
            {
                npc.realLife = (int)npc.ai[3];
            }
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead)
            {
                npc.TargetClosest(true);
            }
            if (Main.player[npc.target].dead && npc.timeLeft > 300)
            {
                npc.timeLeft = 300;
            }
            if (Main.netMode != 1)
            {
                if (npc.ai[0] == 0f)
                {
                    if (npc.ai[2] > 0f)
                    {
                        npc.ai[0] = NPC.NewNPC((int)(npc.position.X + npc.width / 2), (int)(npc.position.Y + npc.height), ModContent.NPCType<PyrasiteBody>(), npc.whoAmI);
                    }
                    else
                    {
                        npc.ai[0] = NPC.NewNPC((int)(npc.position.X + npc.width / 2), (int)(npc.position.Y + npc.height), ModContent.NPCType<PyrasiteTail>(), npc.whoAmI);
                    }
                    Main.npc[(int)npc.ai[0]].ai[1] = npc.whoAmI;
                    Main.npc[(int)npc.ai[0]].ai[2] = npc.ai[2] - 1f;
                    npc.netUpdate = true;
                }
                if (!npc.active && Main.netMode == 2)
                {
                    NetMessage.SendData(28, -1, -1, NetworkText.FromLiteral(""), npc.whoAmI, -1f, 0f, 0f, 0);
                }
            }
            var num193 = (int)(npc.position.X / 16f) - 1;
            var num194 = (int)((npc.position.X + npc.width) / 16f) + 2;
            var num195 = (int)(npc.position.Y / 16f) - 1;
            var num196 = (int)((npc.position.Y + npc.height) / 16f) + 2;
            if (num193 < 0)
            {
                num193 = 0;
            }
            if (num194 > Main.maxTilesX)
            {
                num194 = Main.maxTilesX;
            }
            if (num195 < 0)
            {
                num195 = 0;
            }
            if (num196 > Main.maxTilesY)
            {
                num196 = Main.maxTilesY;
            }
            var flag18 = false;
            if (!flag18)
            {
                for (var num197 = num193; num197 < num194; num197++)
                {
                    for (var num198 = num195; num198 < num196; num198++)
                    {
                        if (Main.tile[num197, num198] != null && ((Main.tile[num197, num198].nactive() && (Main.tileSolid[Main.tile[num197, num198].type] || (Main.tileSolidTop[Main.tile[num197, num198].type] && Main.tile[num197, num198].frameY == 0))) || Main.tile[num197, num198].liquid > 64))
                        {
                            Vector2 vector20;
                            vector20.X = num197 * 16;
                            vector20.Y = num198 * 16;
                            if (npc.position.X + npc.width > vector20.X && npc.position.X < vector20.X + 16f && npc.position.Y + npc.height > vector20.Y && npc.position.Y < vector20.Y + 16f)
                            {
                                flag18 = true;
                                if (Main.rand.Next(100) == 0 && Main.tile[num197, num198].nactive())
                                {
                                    WorldGen.KillTile(num197, num198, true, true, false);
                                }
                                if (Main.netMode != 1 && Main.tile[num197, num198].type == 2)
                                {
                                    var arg_CCAE_0 = Main.tile[num197, num198 - 1].type;
                                }
                            }
                        }
                    }
                }
            }
            var num201 = 8f;
            var num202 = 0.07f;
            var vector21 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
            var num204 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2;
            var num205 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2;
            num204 = (int)(num204 / 16f) * 16;
            num205 = (int)(num205 / 16f) * 16;
            vector21.X = (int)(vector21.X / 16f) * 16;
            vector21.Y = (int)(vector21.Y / 16f) * 16;
            num204 -= vector21.X;
            num205 -= vector21.Y;
            var num206 = (float)Math.Sqrt(num204 * num204 + num205 * num205);
            if (npc.ai[1] > 0f && npc.ai[1] < Main.npc.Length)
            {
                try
                {
                    vector21 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                    num204 = Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 - vector21.X;
                    num205 = Main.npc[(int)npc.ai[1]].position.Y + Main.npc[(int)npc.ai[1]].height / 2 - vector21.Y;
                }
                catch
                {
                }
                npc.rotation = (float)Math.Atan2(num205, num204) + 1.57f;
                num206 = (float)Math.Sqrt(num204 * num204 + num205 * num205);
                var num207 = npc.width;
                num206 = (num206 - num207) / num206;
                num204 *= num206;
                num205 *= num206;
                npc.velocity = Vector2.Zero;
                npc.position.X = npc.position.X + num204;
                npc.position.Y = npc.position.Y + num205;
            }
            else
            {
                if (!flag18)
                {
                    npc.TargetClosest(true);
                    npc.velocity.Y = npc.velocity.Y + 0.11f;
                    if (npc.velocity.Y > num201)
                    {
                        npc.velocity.Y = num201;
                    }
                    if (Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y) < num201 * 0.4)
                    {
                        if (npc.velocity.X < 0f)
                        {
                            npc.velocity.X = npc.velocity.X - num202 * 1.1f;
                        }
                        else
                        {
                            npc.velocity.X = npc.velocity.X + num202 * 1.1f;
                        }
                    }
                    else if (npc.velocity.Y == num201)
                    {
                        if (npc.velocity.X < num204)
                        {
                            npc.velocity.X = npc.velocity.X + num202;
                        }
                        else if (npc.velocity.X > num204)
                        {
                            npc.velocity.X = npc.velocity.X - num202;
                        }
                    }
                    else if (npc.velocity.Y > 4f)
                    {
                        if (npc.velocity.X < 0f)
                        {
                            npc.velocity.X = npc.velocity.X + num202 * 0.9f;
                        }
                        else
                        {
                            npc.velocity.X = npc.velocity.X - num202 * 0.9f;
                        }
                    }
                }
                else
                {
                    if (npc.soundDelay == 0)
                    {
                        var num208 = num206 / 40f;
                        if (num208 < 10f)
                        {
                            num208 = 10f;
                        }
                        if (num208 > 20f)
                        {
                            num208 = 20f;
                        }
                        npc.soundDelay = (int)num208;
                        Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 1);
                    }
                    num206 = (float)Math.Sqrt(num204 * num204 + num205 * num205);
                    var num209 = Math.Abs(num204);
                    var num210 = Math.Abs(num205);
                    var num211 = num201 / num206;
                    num204 *= num211;
                    num205 *= num211;
                    var flag21 = false;
                    if (!flag21)
                    {
                        if ((npc.velocity.X > 0f && num204 > 0f) || (npc.velocity.X < 0f && num204 < 0f) || (npc.velocity.Y > 0f && num205 > 0f) || (npc.velocity.Y < 0f && num205 < 0f))
                        {
                            if (npc.velocity.X < num204)
                            {
                                npc.velocity.X = npc.velocity.X + num202;
                            }
                            else if (npc.velocity.X > num204)
                            {
                                npc.velocity.X = npc.velocity.X - num202;
                            }
                            if (npc.velocity.Y < num205)
                            {
                                npc.velocity.Y = npc.velocity.Y + num202;
                            }
                            else if (npc.velocity.Y > num205)
                            {
                                npc.velocity.Y = npc.velocity.Y - num202;
                            }
                            if (Math.Abs(num205) < num201 * 0.2 && ((npc.velocity.X > 0f && num204 < 0f) || (npc.velocity.X < 0f && num204 > 0f)))
                            {
                                if (npc.velocity.Y > 0f)
                                {
                                    npc.velocity.Y = npc.velocity.Y + num202 * 2f;
                                }
                                else
                                {
                                    npc.velocity.Y = npc.velocity.Y - num202 * 2f;
                                }
                            }
                            if (Math.Abs(num204) < num201 * 0.2 && ((npc.velocity.Y > 0f && num205 < 0f) || (npc.velocity.Y < 0f && num205 > 0f)))
                            {
                                if (npc.velocity.X > 0f)
                                {
                                    npc.velocity.X = npc.velocity.X + num202 * 2f;
                                }
                                else
                                {
                                    npc.velocity.X = npc.velocity.X - num202 * 2f;
                                }
                            }
                        }
                        else if (num209 > num210)
                        {
                            if (npc.velocity.X < num204)
                            {
                                npc.velocity.X = npc.velocity.X + num202 * 1.1f;
                            }
                            else if (npc.velocity.X > num204)
                            {
                                npc.velocity.X = npc.velocity.X - num202 * 1.1f;
                            }
                            if (Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y) < num201 * 0.5)
                            {
                                if (npc.velocity.Y > 0f)
                                {
                                    npc.velocity.Y = npc.velocity.Y + num202;
                                }
                                else
                                {
                                    npc.velocity.Y = npc.velocity.Y - num202;
                                }
                            }
                        }
                        else
                        {
                            if (npc.velocity.Y < num205)
                            {
                                npc.velocity.Y = npc.velocity.Y + num202 * 1.1f;
                            }
                            else if (npc.velocity.Y > num205)
                            {
                                npc.velocity.Y = npc.velocity.Y - num202 * 1.1f;
                            }
                            if (Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y) < num201 * 0.5)
                            {
                                if (npc.velocity.X > 0f)
                                {
                                    npc.velocity.X = npc.velocity.X + num202;
                                }
                                else
                                {
                                    npc.velocity.X = npc.velocity.X - num202;
                                }
                            }
                        }
                    }
                }
                npc.rotation = (float)Math.Atan2(npc.velocity.Y, npc.velocity.X) + 1.57f;
            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PyrasiteBody"), 1f);
        }
    }
}