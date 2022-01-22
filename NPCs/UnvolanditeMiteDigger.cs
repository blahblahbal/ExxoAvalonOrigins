using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs
{
    public class UnvolanditeMiteDigger : UnvolanditeMiteDiggerWorm
    {
        public override string Texture => "ExxoAvalonOrigins/NPCs/UnvolanditeMiteDigger";

        public override void SetDefaults()
        {
            npc.width = 14;
            npc.height = 14;
            npc.aiStyle = 6;
            npc.netAlways = true;
            npc.damage = 40;
            npc.defense = 6;
            npc.lifeMax = 1300;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.knockBackResist = 0f;
            npc.behindTiles = true;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.55f);
            npc.damage = (int)(npc.damage * 0.8f);
        }
        public override void NPCLoot()
        {
            Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/UnvolanditeMiteGore1"), npc.scale);
            Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/UnvolanditeMiteGore2"), npc.scale);
        }
        public override void CustomBehavior()
        {
            int xpos = npc.position.ToTileCoordinates().X;
            int ypos = npc.position.ToTileCoordinates().Y;

            if (npc.ai[2] <= 300) npc.ai[2]++;
            if (npc.ai[2] > 300)
            {
                npc.ai[3] = 1;
            }

            if (!Main.tile[xpos, ypos].active() && Main.tile[xpos, ypos + 1].active() && npc.ai[3] == 1)
            {
                npc.Transform(ModContent.NPCType<UnvolanditeMite>());
                npc.ai[3] = 0;
                npc.ai[2] = 0;
            }

        }
        public override void Init()
        {
            base.Init();
            head = true;
        }
    }

    public abstract class UnvolanditeMiteDiggerWorm : SingleSegmentWorm
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Unvolandite Mite");
        }

        public override void Init()
        {
            headType = ModContent.NPCType<UnvolanditeMiteDigger>();
            speed = 5.5f;
            turnSpeed = 0.045f;
        }
    }

    public abstract class SingleSegmentWorm : ModNPC
    {
        /* ai[0] = follower
		 * ai[1] = following
		 * ai[2] = distanceFromTail
		 * ai[3] = head
		 */
        public bool head;
        public int headType;
        public bool flies = false;
        public bool directional = false;
        public float speed;
        public float turnSpeed;

        public override void AI()
        {
            if (npc.localAI[1] == 0f)
            {
                npc.localAI[1] = 1f;
                Init();
            }
            //if (npc.ai[3] > 0f)
            //{
            //    npc.realLife = (int)npc.ai[3];
            //}
            if (!head && npc.timeLeft < 300)
            {
                npc.timeLeft = 300;
            }
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead)
            {
                npc.TargetClosest(true);
            }
            if (Main.player[npc.target].dead && npc.timeLeft > 300)
            {
                npc.timeLeft = 300;
            }
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                //if (!tail && npc.ai[0] == 0f)
                //{
                //    if (head)
                //    {
                //        npc.ai[3] = (float)npc.whoAmI;
                //        npc.realLife = npc.whoAmI;
                //        npc.ai[2] = (float)Main.rand.Next(minLength, maxLength + 1);
                //        npc.ai[0] = (float)NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)(npc.position.Y + (float)npc.height), bodyType, npc.whoAmI);
                //    }
                //    else if (npc.ai[2] > 0f)
                //    {
                //        npc.ai[0] = (float)NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)(npc.position.Y + (float)npc.height), npc.type, npc.whoAmI);
                //    }
                //    else
                //    {
                //        npc.ai[0] = (float)NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)(npc.position.Y + (float)npc.height), tailType, npc.whoAmI);
                //    }
                //    Main.npc[(int)npc.ai[0]].ai[3] = npc.ai[3];
                //    Main.npc[(int)npc.ai[0]].realLife = npc.realLife;
                //    Main.npc[(int)npc.ai[0]].ai[1] = (float)npc.whoAmI;
                //    Main.npc[(int)npc.ai[0]].ai[2] = npc.ai[2] - 1f;
                //    npc.netUpdate = true;
                //}
                //if (!head && (!Main.npc[(int)npc.ai[1]].active || Main.npc[(int)npc.ai[1]].type != headType && Main.npc[(int)npc.ai[1]].type != bodyType))
                //{
                //    npc.life = 0;
                //    npc.HitEffect(0, 10.0);
                //    npc.active = false;
                //}
                //if (!tail && (!Main.npc[(int)npc.ai[0]].active || Main.npc[(int)npc.ai[0]].type != bodyType && Main.npc[(int)npc.ai[0]].type != tailType))
                //{
                //    npc.life = 0;
                //    npc.HitEffect(0, 10.0);
                //    npc.active = false;
                //}
                if (!npc.active && Main.netMode == NetmodeID.Server)
                {
                    NetMessage.SendData(MessageID.StrikeNPC, -1, -1, null, npc.whoAmI, -1f, 0f, 0f, 0, 0, 0);
                }
            }
            int num180 = (int)(npc.position.X / 16f) - 1;
            int num181 = (int)((npc.position.X + (float)npc.width) / 16f) + 2;
            int num182 = (int)(npc.position.Y / 16f) - 1;
            int num183 = (int)((npc.position.Y + (float)npc.height) / 16f) + 2;
            if (num180 < 0)
            {
                num180 = 0;
            }
            if (num181 > Main.maxTilesX)
            {
                num181 = Main.maxTilesX;
            }
            if (num182 < 0)
            {
                num182 = 0;
            }
            if (num183 > Main.maxTilesY)
            {
                num183 = Main.maxTilesY;
            }
            bool flag18 = flies;
            if (!flag18)
            {
                for (int num184 = num180; num184 < num181; num184++)
                {
                    for (int num185 = num182; num185 < num183; num185++)
                    {
                        if (Main.tile[num184, num185] != null && (Main.tile[num184, num185].nactive() && (Main.tileSolid[(int)Main.tile[num184, num185].type] || Main.tileSolidTop[(int)Main.tile[num184, num185].type] && Main.tile[num184, num185].frameY == 0) || Main.tile[num184, num185].liquid > 64))
                        {
                            Vector2 vector17;
                            vector17.X = (float)(num184 * 16);
                            vector17.Y = (float)(num185 * 16);
                            if (npc.position.X + (float)npc.width > vector17.X && npc.position.X < vector17.X + 16f && npc.position.Y + (float)npc.height > vector17.Y && npc.position.Y < vector17.Y + 16f)
                            {
                                flag18 = true;
                                if (Main.rand.NextBool(100) && npc.behindTiles && Main.tile[num184, num185].nactive())
                                {
                                    WorldGen.KillTile(num184, num185, true, true, false);
                                }
                                if (Main.netMode != NetmodeID.MultiplayerClient && Main.tile[num184, num185].type == 2)
                                {
                                    ushort arg_BFCA_0 = Main.tile[num184, num185 - 1].type;
                                }
                            }
                        }
                    }
                }
            }
            if (!flag18 && head)
            {
                Rectangle rectangle = new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height);
                int num186 = 1000;
                bool flag19 = true;
                for (int num187 = 0; num187 < 255; num187++)
                {
                    if (Main.player[num187].active)
                    {
                        Rectangle rectangle2 = new Rectangle((int)Main.player[num187].position.X - num186, (int)Main.player[num187].position.Y - num186, num186 * 2, num186 * 2);
                        if (rectangle.Intersects(rectangle2))
                        {
                            flag19 = false;
                            break;
                        }
                    }
                }
                if (flag19)
                {
                    flag18 = true;
                }
            }
            if (directional)
            {
                if (npc.velocity.X < 0f)
                {
                    npc.spriteDirection = 1;
                }
                else if (npc.velocity.X > 0f)
                {
                    npc.spriteDirection = -1;
                }
            }
            float wormSpeed = speed;
            float wormTurnSpeed = turnSpeed;
            Vector2 vector18 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
            float num191 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2);
            float num192 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2);
            num191 = (float)((int)(num191 / 16f) * 16);
            num192 = (float)((int)(num192 / 16f) * 16);
            vector18.X = (float)((int)(vector18.X / 16f) * 16);
            vector18.Y = (float)((int)(vector18.Y / 16f) * 16);
            num191 -= vector18.X;
            num192 -= vector18.Y;
            float num193 = (float)System.Math.Sqrt((double)(num191 * num191 + num192 * num192));
            if (npc.ai[1] > 0f && npc.ai[1] < (float)Main.npc.Length)
            {
                try
                {
                    vector18 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                    num191 = Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2) - vector18.X;
                    num192 = Main.npc[(int)npc.ai[1]].position.Y + (float)(Main.npc[(int)npc.ai[1]].height / 2) - vector18.Y;
                }
                catch
                {
                }
                npc.rotation = (float)System.Math.Atan2((double)num192, (double)num191) + 1.57f;
                num193 = (float)System.Math.Sqrt((double)(num191 * num191 + num192 * num192));
                int num194 = npc.width;
                num193 = (num193 - (float)num194) / num193;
                num191 *= num193;
                num192 *= num193;
                npc.velocity = Vector2.Zero;
                npc.position.X = npc.position.X + num191;
                npc.position.Y = npc.position.Y + num192;
                if (directional)
                {
                    if (num191 < 0f)
                    {
                        npc.spriteDirection = 1;
                    }
                    if (num191 > 0f)
                    {
                        npc.spriteDirection = -1;
                    }
                }
            }
            else
            {
                if (!flag18)
                {
                    npc.TargetClosest(true);
                    npc.velocity.Y = npc.velocity.Y + 0.11f;
                    if (npc.velocity.Y > wormSpeed)
                    {
                        npc.velocity.Y = wormSpeed;
                    }
                    if ((double)(System.Math.Abs(npc.velocity.X) + System.Math.Abs(npc.velocity.Y)) < (double)wormSpeed * 0.4)
                    {
                        if (npc.velocity.X < 0f)
                        {
                            npc.velocity.X = npc.velocity.X - wormTurnSpeed * 1.1f;
                        }
                        else
                        {
                            npc.velocity.X = npc.velocity.X + wormTurnSpeed * 1.1f;
                        }
                    }
                    else if (npc.velocity.Y == wormSpeed)
                    {
                        if (npc.velocity.X < num191)
                        {
                            npc.velocity.X = npc.velocity.X + wormTurnSpeed;
                        }
                        else if (npc.velocity.X > num191)
                        {
                            npc.velocity.X = npc.velocity.X - wormTurnSpeed;
                        }
                    }
                    else if (npc.velocity.Y > 4f)
                    {
                        if (npc.velocity.X < 0f)
                        {
                            npc.velocity.X = npc.velocity.X + wormTurnSpeed * 0.9f;
                        }
                        else
                        {
                            npc.velocity.X = npc.velocity.X - wormTurnSpeed * 0.9f;
                        }
                    }
                }
                else
                {
                    if (!flies && npc.behindTiles && npc.soundDelay == 0)
                    {
                        float num195 = num193 / 40f;
                        if (num195 < 10f)
                        {
                            num195 = 10f;
                        }
                        if (num195 > 20f)
                        {
                            num195 = 20f;
                        }
                        npc.soundDelay = (int)num195;
                        Main.PlaySound(SoundID.Roar, npc.position, 1);
                    }
                    num193 = (float)System.Math.Sqrt((double)(num191 * num191 + num192 * num192));
                    float num196 = System.Math.Abs(num191);
                    float num197 = System.Math.Abs(num192);
                    float num198 = wormSpeed / num193;
                    num191 *= num198;
                    num192 *= num198;
                    if (ShouldRun())
                    {
                        bool flag20 = true;
                        for (int num199 = 0; num199 < 255; num199++)
                        {
                            if (Main.player[num199].active && !Main.player[num199].dead && Main.player[num199].ZoneCorrupt)
                            {
                                flag20 = false;
                            }
                        }
                        if (flag20)
                        {
                            if (Main.netMode != NetmodeID.MultiplayerClient && (double)(npc.position.Y / 16f) > (Main.rockLayer + (double)Main.maxTilesY) / 2.0)
                            {
                                npc.active = false;
                                int num200 = (int)npc.ai[0];
                                while (num200 > 0 && num200 < 200 && Main.npc[num200].active && Main.npc[num200].aiStyle == npc.aiStyle)
                                {
                                    int num201 = (int)Main.npc[num200].ai[0];
                                    Main.npc[num200].active = false;
                                    npc.life = 0;
                                    if (Main.netMode == NetmodeID.Server)
                                    {
                                        NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, num200, 0f, 0f, 0f, 0, 0, 0);
                                    }
                                    num200 = num201;
                                }
                                if (Main.netMode == NetmodeID.Server)
                                {
                                    NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, npc.whoAmI, 0f, 0f, 0f, 0, 0, 0);
                                }
                            }
                            num191 = 0f;
                            num192 = wormSpeed;
                        }
                    }
                    bool flag21 = false;
                    if (npc.type == NPCID.WyvernHead)
                    {
                        if ((npc.velocity.X > 0f && num191 < 0f || npc.velocity.X < 0f && num191 > 0f || npc.velocity.Y > 0f && num192 < 0f || npc.velocity.Y < 0f && num192 > 0f) && System.Math.Abs(npc.velocity.X) + System.Math.Abs(npc.velocity.Y) > wormTurnSpeed / 2f && num193 < 300f)
                        {
                            flag21 = true;
                            if (System.Math.Abs(npc.velocity.X) + System.Math.Abs(npc.velocity.Y) < wormSpeed)
                            {
                                npc.velocity *= 1.1f;
                            }
                        }
                        if (npc.position.Y > Main.player[npc.target].position.Y || (double)(Main.player[npc.target].position.Y / 16f) > Main.worldSurface || Main.player[npc.target].dead)
                        {
                            flag21 = true;
                            if (System.Math.Abs(npc.velocity.X) < wormSpeed / 2f)
                            {
                                if (npc.velocity.X == 0f)
                                {
                                    npc.velocity.X = npc.velocity.X - (float)npc.direction;
                                }
                                npc.velocity.X = npc.velocity.X * 1.1f;
                            }
                            else
                            {
                                if (npc.velocity.Y > -wormSpeed)
                                {
                                    npc.velocity.Y = npc.velocity.Y - wormTurnSpeed;
                                }
                            }
                        }
                    }
                    if (!flag21)
                    {
                        if (npc.velocity.X > 0f && num191 > 0f || npc.velocity.X < 0f && num191 < 0f || npc.velocity.Y > 0f && num192 > 0f || npc.velocity.Y < 0f && num192 < 0f)
                        {
                            if (npc.velocity.X < num191)
                            {
                                npc.velocity.X = npc.velocity.X + wormTurnSpeed;
                            }
                            else
                            {
                                if (npc.velocity.X > num191)
                                {
                                    npc.velocity.X = npc.velocity.X - wormTurnSpeed;
                                }
                            }
                            if (npc.velocity.Y < num192)
                            {
                                npc.velocity.Y = npc.velocity.Y + wormTurnSpeed;
                            }
                            else
                            {
                                if (npc.velocity.Y > num192)
                                {
                                    npc.velocity.Y = npc.velocity.Y - wormTurnSpeed;
                                }
                            }
                            if ((double)System.Math.Abs(num192) < (double)wormSpeed * 0.2 && (npc.velocity.X > 0f && num191 < 0f || npc.velocity.X < 0f && num191 > 0f))
                            {
                                if (npc.velocity.Y > 0f)
                                {
                                    npc.velocity.Y = npc.velocity.Y + wormTurnSpeed * 2f;
                                }
                                else
                                {
                                    npc.velocity.Y = npc.velocity.Y - wormTurnSpeed * 2f;
                                }
                            }
                            if ((double)System.Math.Abs(num191) < (double)wormSpeed * 0.2 && (npc.velocity.Y > 0f && num192 < 0f || npc.velocity.Y < 0f && num192 > 0f))
                            {
                                if (npc.velocity.X > 0f)
                                {
                                    npc.velocity.X = npc.velocity.X + wormTurnSpeed * 2f;
                                }
                                else
                                {
                                    npc.velocity.X = npc.velocity.X - wormTurnSpeed * 2f;
                                }
                            }
                        }
                        else
                        {
                            if (num196 > num197)
                            {
                                if (npc.velocity.X < num191)
                                {
                                    npc.velocity.X = npc.velocity.X + wormTurnSpeed * 1.1f;
                                }
                                else if (npc.velocity.X > num191)
                                {
                                    npc.velocity.X = npc.velocity.X - wormTurnSpeed * 1.1f;
                                }
                                if ((double)(System.Math.Abs(npc.velocity.X) + System.Math.Abs(npc.velocity.Y)) < (double)wormSpeed * 0.5)
                                {
                                    if (npc.velocity.Y > 0f)
                                    {
                                        npc.velocity.Y = npc.velocity.Y + wormTurnSpeed;
                                    }
                                    else
                                    {
                                        npc.velocity.Y = npc.velocity.Y - wormTurnSpeed;
                                    }
                                }
                            }
                            else
                            {
                                if (npc.velocity.Y < num192)
                                {
                                    npc.velocity.Y = npc.velocity.Y + wormTurnSpeed * 1.1f;
                                }
                                else if (npc.velocity.Y > num192)
                                {
                                    npc.velocity.Y = npc.velocity.Y - wormTurnSpeed * 1.1f;
                                }
                                if ((double)(System.Math.Abs(npc.velocity.X) + System.Math.Abs(npc.velocity.Y)) < (double)wormSpeed * 0.5)
                                {
                                    if (npc.velocity.X > 0f)
                                    {
                                        npc.velocity.X = npc.velocity.X + wormTurnSpeed;
                                    }
                                    else
                                    {
                                        npc.velocity.X = npc.velocity.X - wormTurnSpeed;
                                    }
                                }
                            }
                        }
                    }
                }
                npc.rotation = (float)System.Math.Atan2((double)npc.velocity.Y, (double)npc.velocity.X) + 1.57f;
                if (head)
                {
                    if (flag18)
                    {
                        if (npc.localAI[0] != 1f)
                        {
                            npc.netUpdate = true;
                        }
                        npc.localAI[0] = 1f;
                    }
                    else
                    {
                        if (npc.localAI[0] != 0f)
                        {
                            npc.netUpdate = true;
                        }
                        npc.localAI[0] = 0f;
                    }
                    if ((npc.velocity.X > 0f && npc.oldVelocity.X < 0f || npc.velocity.X < 0f && npc.oldVelocity.X > 0f || npc.velocity.Y > 0f && npc.oldVelocity.Y < 0f || npc.velocity.Y < 0f && npc.oldVelocity.Y > 0f) && !npc.justHit)
                    {
                        npc.netUpdate = true;
                        return;
                    }
                }
            }
            CustomBehavior();
        }

        public virtual void Init()
        {
        }

        public virtual bool ShouldRun()
        {
            return false;
        }

        public virtual void CustomBehavior()
        {
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            return head ? (bool?)null : false;
        }
    }
}
