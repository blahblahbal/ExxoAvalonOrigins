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
	public class MechanicalDiggerBody : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mechanical Digger Body");
			Main.npcFrameCount[npc.type] = 3;
		}

		public override void SetDefaults()
		{
			npc.damage = 90;
			npc.netAlways = true;
			npc.scale = 1f;
			npc.noTileCollide = true;
			npc.lifeMax = 5000;
			npc.defense = 80;
			npc.noGravity = true;
			npc.width = 22;
			npc.aiStyle = -1;
			npc.behindTiles = true;
			npc.value = 20000f;
			npc.height = 22;
			npc.knockBackResist = 0f;
            npc.HitSound = SoundID.NPCHit4;
	        npc.DeathSound = SoundID.NPCDeath14;
			npc.buffImmune[BuffID.Frostburn] = true;
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
                if (!Main.npc[(int)npc.ai[0]].active)
                {
                    npc.life = 0;
                    npc.HitEffect(0, 10.0);
                    npc.active = false;
                }
                if (!Main.npc[(int)npc.ai[1]].active)
                {
                    npc.life = 0;
                    npc.HitEffect(0, 10.0);
                    npc.active = false;
                }
                if (!npc.active && Main.netMode == 2)
                {
                    NetMessage.SendData(28, -1, -1, NetworkText.FromLiteral(""), npc.whoAmI, -1f, 0f, 0f, 0);
                }
            }
            var num182 = (int)(npc.position.X / 16f) - 1;
            var num183 = (int)((npc.position.X + npc.width) / 16f) + 2;
            var num184 = (int)(npc.position.Y / 16f) - 1;
            var num185 = (int)((npc.position.Y + npc.height) / 16f) + 2;
            if (num182 < 0)
            {
                num182 = 0;
            }
            if (num183 > Main.maxTilesX)
            {
                num183 = Main.maxTilesX;
            }
            if (num184 < 0)
            {
                num184 = 0;
            }
            if (num185 > Main.maxTilesY)
            {
                num185 = Main.maxTilesY;
            }
            var flag18 = false;
            if (!flag18)
            {
                for (var num186 = num182; num186 < num183; num186++)
                {
                    for (var num187 = num184; num187 < num185; num187++)
                    {
                        if (Main.tile[num186, num187] != null && ((Main.tile[num186, num187].nactive() && (Main.tileSolid[Main.tile[num186, num187].type] || (Main.tileSolidTop[Main.tile[num186, num187].type] && Main.tile[num186, num187].frameY == 0))) || Main.tile[num186, num187].liquid > 64))
                        {
                            Vector2 vector19;
                            vector19.X = num186 * 16;
                            vector19.Y = num187 * 16;
                            if (npc.position.X + npc.width > vector19.X && npc.position.X < vector19.X + 16f && npc.position.Y + npc.height > vector19.Y && npc.position.Y < vector19.Y + 16f)
                            {
                                flag18 = true;
                                if (Main.rand.Next(100) == 0 && Main.tile[num186, num187].nactive())
                                {
                                    WorldGen.KillTile(num186, num187, true, true, false);
                                }
                                if (Main.netMode != 1 && Main.tile[num186, num187].type == 2)
                                {
                                    var arg_BB6F_0 = Main.tile[num186, num187 - 1].type;
                                }
                            }
                        }
                    }
                }
            }
            var num190 = 8f;
            var num191 = 0.07f;
            var vector20 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
            var num193 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2;
            var num194 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2;
            num193 = (int)(num193 / 16f) * 16;
            num194 = (int)(num194 / 16f) * 16;
            vector20.X = (int)(vector20.X / 16f) * 16;
            vector20.Y = (int)(vector20.Y / 16f) * 16;
            num193 -= vector20.X;
            num194 -= vector20.Y;
            var num195 = (float)Math.Sqrt(num193 * num193 + num194 * num194);
            if (npc.ai[1] > 0f && npc.ai[1] < Main.npc.Length)
            {
                try
                {
                    vector20 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                    num193 = Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 - vector20.X;
                    num194 = Main.npc[(int)npc.ai[1]].position.Y + Main.npc[(int)npc.ai[1]].height / 2 - vector20.Y;
                }
                catch
                {
                }
                npc.rotation = (float)Math.Atan2(num194, num193) + 1.57f;
                num195 = (float)Math.Sqrt(num193 * num193 + num194 * num194);
                var num196 = npc.width;
                num195 = (num195 - num196) / num195;
                num193 *= num195;
                num194 *= num195;
                npc.velocity = Vector2.Zero;
                npc.position.X = npc.position.X + num193;
                npc.position.Y = npc.position.Y + num194;
            }
            else
            {
                if (!flag18)
                {
                    npc.TargetClosest(true);
                    npc.velocity.Y = npc.velocity.Y + 0.11f;
                    if (npc.velocity.Y > num190)
                    {
                        npc.velocity.Y = num190;
                    }
                    if (Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y) < num190 * 0.4)
                    {
                        if (npc.velocity.X < 0f)
                        {
                            npc.velocity.X = npc.velocity.X - num191 * 1.1f;
                        }
                        else
                        {
                            npc.velocity.X = npc.velocity.X + num191 * 1.1f;
                        }
                    }
                    else if (npc.velocity.Y == num190)
                    {
                        if (npc.velocity.X < num193)
                        {
                            npc.velocity.X = npc.velocity.X + num191;
                        }
                        else if (npc.velocity.X > num193)
                        {
                            npc.velocity.X = npc.velocity.X - num191;
                        }
                    }
                    else if (npc.velocity.Y > 4f)
                    {
                        if (npc.velocity.X < 0f)
                        {
                            npc.velocity.X = npc.velocity.X + num191 * 0.9f;
                        }
                        else
                        {
                            npc.velocity.X = npc.velocity.X - num191 * 0.9f;
                        }
                    }
                }
                else
                {
                    if (npc.soundDelay == 0)
                    {
                        var num197 = num195 / 40f;
                        if (num197 < 10f)
                        {
                            num197 = 10f;
                        }
                        if (num197 > 20f)
                        {
                            num197 = 20f;
                        }
                        npc.soundDelay = (int)num197;
                        Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 1);
                    }
                    num195 = (float)Math.Sqrt(num193 * num193 + num194 * num194);
                    var num198 = Math.Abs(num193);
                    var num199 = Math.Abs(num194);
                    var num200 = num190 / num195;
                    num193 *= num200;
                    num194 *= num200;
                    var flag21 = false;
                    if (!flag21)
                    {
                        if ((npc.velocity.X > 0f && num193 > 0f) || (npc.velocity.X < 0f && num193 < 0f) || (npc.velocity.Y > 0f && num194 > 0f) || (npc.velocity.Y < 0f && num194 < 0f))
                        {
                            if (npc.velocity.X < num193)
                            {
                                npc.velocity.X = npc.velocity.X + num191;
                            }
                            else if (npc.velocity.X > num193)
                            {
                                npc.velocity.X = npc.velocity.X - num191;
                            }
                            if (npc.velocity.Y < num194)
                            {
                                npc.velocity.Y = npc.velocity.Y + num191;
                            }
                            else if (npc.velocity.Y > num194)
                            {
                                npc.velocity.Y = npc.velocity.Y - num191;
                            }
                            if (Math.Abs(num194) < num190 * 0.2 && ((npc.velocity.X > 0f && num193 < 0f) || (npc.velocity.X < 0f && num193 > 0f)))
                            {
                                if (npc.velocity.Y > 0f)
                                {
                                    npc.velocity.Y = npc.velocity.Y + num191 * 2f;
                                }
                                else
                                {
                                    npc.velocity.Y = npc.velocity.Y - num191 * 2f;
                                }
                            }
                            if (Math.Abs(num193) < num190 * 0.2 && ((npc.velocity.Y > 0f && num194 < 0f) || (npc.velocity.Y < 0f && num194 > 0f)))
                            {
                                if (npc.velocity.X > 0f)
                                {
                                    npc.velocity.X = npc.velocity.X + num191 * 2f;
                                }
                                else
                                {
                                    npc.velocity.X = npc.velocity.X - num191 * 2f;
                                }
                            }
                        }
                        else if (num198 > num199)
                        {
                            if (npc.velocity.X < num193)
                            {
                                npc.velocity.X = npc.velocity.X + num191 * 1.1f;
                            }
                            else if (npc.velocity.X > num193)
                            {
                                npc.velocity.X = npc.velocity.X - num191 * 1.1f;
                            }
                            if (Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y) < num190 * 0.5)
                            {
                                if (npc.velocity.Y > 0f)
                                {
                                    npc.velocity.Y = npc.velocity.Y + num191;
                                }
                                else
                                {
                                    npc.velocity.Y = npc.velocity.Y - num191;
                                }
                            }
                        }
                        else
                        {
                            if (npc.velocity.Y < num194)
                            {
                                npc.velocity.Y = npc.velocity.Y + num191 * 1.1f;
                            }
                            else if (npc.velocity.Y > num194)
                            {
                                npc.velocity.Y = npc.velocity.Y - num191 * 1.1f;
                            }
                            if (Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y) < num190 * 0.5)
                            {
                                if (npc.velocity.X > 0f)
                                {
                                    npc.velocity.X = npc.velocity.X + num191;
                                }
                                else
                                {
                                    npc.velocity.X = npc.velocity.X - num191;
                                }
                            }
                        }
                    }
                }
                npc.rotation = (float)Math.Atan2(npc.velocity.Y, npc.velocity.X) + 1.57f;
            }
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 1;
            if (npc.frameCounter < 4.0)
            {
                npc.frame.Y = 0;
            }
            else if (npc.frameCounter < 8.0)
            {
                npc.frame.Y = frameHeight;
            }
            else if (npc.frameCounter < 12.0)
            {
                npc.frame.Y = frameHeight * 2;
            }
            else if (npc.frameCounter < 16.0)
            {
                npc.frame.Y = frameHeight;
            }
            else
            {
                npc.frameCounter = 0.0;
            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MechanicalDiggerBody"), 1f);
            }
        }
    }
}