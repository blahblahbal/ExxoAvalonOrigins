using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.DataStructures;

namespace ExxoAvalonOrigins.NPCs;

public class UnvolanditeMiteDigger : UnvolanditeMiteDiggerWorm
{
    public override string Texture => "ExxoAvalonOrigins/NPCs/UnvolanditeMiteDigger";

    public override void SetDefaults()
    {
        NPC.width = 14;
        NPC.height = 14;
        NPC.aiStyle = 6;
        NPC.netAlways = true;
        NPC.damage = 40;
        NPC.defense = 6;
        NPC.lifeMax = 1300;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
        NPC.noGravity = true;
        NPC.noTileCollide = true;
        NPC.knockBackResist = 0f;
        NPC.behindTiles = true;
    }
    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.55f);
        NPC.damage = (int)(NPC.damage * 0.8f);
    }
    public override void HitEffect(int hitDirection, double damage)
    {
        if (NPC.life <= 0)
        {
            Gore.NewGore(NPC.Center, NPC.velocity, Mod.Find<ModGore>("UnvolanditeMiteGore1").Type, NPC.scale);
            Gore.NewGore(NPC.Center, NPC.velocity, Mod.Find<ModGore>("UnvolanditeMiteGore2").Type, NPC.scale);
        }
    }
    public override void CustomBehavior()
    {
        int xpos = NPC.position.ToTileCoordinates().X;
        int ypos = NPC.position.ToTileCoordinates().Y;

        if (NPC.ai[2] <= 300) NPC.ai[2]++;
        if (NPC.ai[2] > 300)
        {
            NPC.ai[3] = 1;
        }

        if (!Main.tile[xpos, ypos].HasTile && Main.tile[xpos, ypos + 1].HasTile && NPC.ai[3] == 1)
        {
            NPC.Transform(ModContent.NPCType<UnvolanditeMite>());
            NPC.ai[3] = 0;
            NPC.ai[2] = 0;
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
        NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData
        {
            SpecificallyImmuneTo = new int[]
            {
                BuffID.Confused
            }
        };
        NPCID.Sets.DebuffImmunitySets[Type] = debuffData;
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
        if (NPC.localAI[1] == 0f)
        {
            NPC.localAI[1] = 1f;
            Init();
        }
        if (!head && NPC.timeLeft < 300)
        {
            NPC.timeLeft = 300;
        }
        if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead)
        {
            NPC.TargetClosest(true);
        }
        if (Main.player[NPC.target].dead && NPC.timeLeft > 300)
        {
            NPC.timeLeft = 300;
        }
        if (Main.netMode != NetmodeID.MultiplayerClient)
        {
            if (!NPC.active && Main.netMode == NetmodeID.Server)
            {
                NetMessage.SendData(MessageID.DamageNPC, -1, -1, null, NPC.whoAmI, -1f, 0f, 0f, 0, 0, 0);
            }
        }
        int num180 = (int)(NPC.position.X / 16f) - 1;
        int num181 = (int)((NPC.position.X + (float)NPC.width) / 16f) + 2;
        int num182 = (int)(NPC.position.Y / 16f) - 1;
        int num183 = (int)((NPC.position.Y + (float)NPC.height) / 16f) + 2;
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
                    if (Main.tile[num184, num185] != null && (Main.tile[num184, num185].HasUnactuatedTile && (Main.tileSolid[(int)Main.tile[num184, num185].TileType] || Main.tileSolidTop[(int)Main.tile[num184, num185].TileType] && Main.tile[num184, num185].TileFrameY == 0) || Main.tile[num184, num185].LiquidAmount > 64))
                    {
                        Vector2 vector17;
                        vector17.X = (float)(num184 * 16);
                        vector17.Y = (float)(num185 * 16);
                        if (NPC.position.X + (float)NPC.width > vector17.X && NPC.position.X < vector17.X + 16f && NPC.position.Y + (float)NPC.height > vector17.Y && NPC.position.Y < vector17.Y + 16f)
                        {
                            flag18 = true;
                            if (Main.rand.NextBool(100) && NPC.behindTiles && Main.tile[num184, num185].HasUnactuatedTile)
                            {
                                WorldGen.KillTile(num184, num185, true, true, false);
                            }
                            if (Main.netMode != NetmodeID.MultiplayerClient && Main.tile[num184, num185].TileType == 2)
                            {
                                ushort arg_BFCA_0 = Main.tile[num184, num185 - 1].TileType;
                            }
                        }
                    }
                }
            }
        }
        if (!flag18 && head)
        {
            Rectangle rectangle = new Rectangle((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height);
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
            if (NPC.velocity.X < 0f)
            {
                NPC.spriteDirection = 1;
            }
            else if (NPC.velocity.X > 0f)
            {
                NPC.spriteDirection = -1;
            }
        }
        float wormSpeed = speed;
        float wormTurnSpeed = turnSpeed;
        Vector2 vector18 = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
        float num191 = Main.player[NPC.target].position.X + (float)(Main.player[NPC.target].width / 2);
        float num192 = Main.player[NPC.target].position.Y + (float)(Main.player[NPC.target].height / 2);
        num191 = (float)((int)(num191 / 16f) * 16);
        num192 = (float)((int)(num192 / 16f) * 16);
        vector18.X = (float)((int)(vector18.X / 16f) * 16);
        vector18.Y = (float)((int)(vector18.Y / 16f) * 16);
        num191 -= vector18.X;
        num192 -= vector18.Y;
        float num193 = (float)System.Math.Sqrt((double)(num191 * num191 + num192 * num192));
        if (NPC.ai[1] > 0f && NPC.ai[1] < (float)Main.npc.Length)
        {
            try
            {
                vector18 = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
                num191 = Main.npc[(int)NPC.ai[1]].position.X + (float)(Main.npc[(int)NPC.ai[1]].width / 2) - vector18.X;
                num192 = Main.npc[(int)NPC.ai[1]].position.Y + (float)(Main.npc[(int)NPC.ai[1]].height / 2) - vector18.Y;
            }
            catch
            {
            }
            NPC.rotation = (float)System.Math.Atan2((double)num192, (double)num191) + 1.57f;
            num193 = (float)System.Math.Sqrt((double)(num191 * num191 + num192 * num192));
            int num194 = NPC.width;
            num193 = (num193 - (float)num194) / num193;
            num191 *= num193;
            num192 *= num193;
            NPC.velocity = Vector2.Zero;
            NPC.position.X = NPC.position.X + num191;
            NPC.position.Y = NPC.position.Y + num192;
            if (directional)
            {
                if (num191 < 0f)
                {
                    NPC.spriteDirection = 1;
                }
                if (num191 > 0f)
                {
                    NPC.spriteDirection = -1;
                }
            }
        }
        else
        {
            if (!flag18)
            {
                NPC.TargetClosest(true);
                NPC.velocity.Y = NPC.velocity.Y + 0.11f;
                if (NPC.velocity.Y > wormSpeed)
                {
                    NPC.velocity.Y = wormSpeed;
                }
                if ((double)(System.Math.Abs(NPC.velocity.X) + System.Math.Abs(NPC.velocity.Y)) < (double)wormSpeed * 0.4)
                {
                    if (NPC.velocity.X < 0f)
                    {
                        NPC.velocity.X = NPC.velocity.X - wormTurnSpeed * 1.1f;
                    }
                    else
                    {
                        NPC.velocity.X = NPC.velocity.X + wormTurnSpeed * 1.1f;
                    }
                }
                else if (NPC.velocity.Y == wormSpeed)
                {
                    if (NPC.velocity.X < num191)
                    {
                        NPC.velocity.X = NPC.velocity.X + wormTurnSpeed;
                    }
                    else if (NPC.velocity.X > num191)
                    {
                        NPC.velocity.X = NPC.velocity.X - wormTurnSpeed;
                    }
                }
                else if (NPC.velocity.Y > 4f)
                {
                    if (NPC.velocity.X < 0f)
                    {
                        NPC.velocity.X = NPC.velocity.X + wormTurnSpeed * 0.9f;
                    }
                    else
                    {
                        NPC.velocity.X = NPC.velocity.X - wormTurnSpeed * 0.9f;
                    }
                }
            }
            else
            {
                if (!flies && NPC.behindTiles && NPC.soundDelay == 0)
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
                    NPC.soundDelay = (int)num195;
                    SoundEngine.PlaySound(SoundID.Roar, NPC.position, 1);
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
                        if (Main.netMode != NetmodeID.MultiplayerClient && (double)(NPC.position.Y / 16f) > (Main.rockLayer + (double)Main.maxTilesY) / 2.0)
                        {
                            NPC.active = false;
                            int num200 = (int)NPC.ai[0];
                            while (num200 > 0 && num200 < 200 && Main.npc[num200].active && Main.npc[num200].aiStyle == NPC.aiStyle)
                            {
                                int num201 = (int)Main.npc[num200].ai[0];
                                Main.npc[num200].active = false;
                                NPC.life = 0;
                                if (Main.netMode == NetmodeID.Server)
                                {
                                    NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, num200, 0f, 0f, 0f, 0, 0, 0);
                                }
                                num200 = num201;
                            }
                            if (Main.netMode == NetmodeID.Server)
                            {
                                NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, NPC.whoAmI, 0f, 0f, 0f, 0, 0, 0);
                            }
                        }
                        num191 = 0f;
                        num192 = wormSpeed;
                    }
                }
                bool flag21 = false;
                if (NPC.type == NPCID.WyvernHead)
                {
                    if ((NPC.velocity.X > 0f && num191 < 0f || NPC.velocity.X < 0f && num191 > 0f || NPC.velocity.Y > 0f && num192 < 0f || NPC.velocity.Y < 0f && num192 > 0f) && System.Math.Abs(NPC.velocity.X) + System.Math.Abs(NPC.velocity.Y) > wormTurnSpeed / 2f && num193 < 300f)
                    {
                        flag21 = true;
                        if (System.Math.Abs(NPC.velocity.X) + System.Math.Abs(NPC.velocity.Y) < wormSpeed)
                        {
                            NPC.velocity *= 1.1f;
                        }
                    }
                    if (NPC.position.Y > Main.player[NPC.target].position.Y || (double)(Main.player[NPC.target].position.Y / 16f) > Main.worldSurface || Main.player[NPC.target].dead)
                    {
                        flag21 = true;
                        if (System.Math.Abs(NPC.velocity.X) < wormSpeed / 2f)
                        {
                            if (NPC.velocity.X == 0f)
                            {
                                NPC.velocity.X = NPC.velocity.X - (float)NPC.direction;
                            }
                            NPC.velocity.X = NPC.velocity.X * 1.1f;
                        }
                        else
                        {
                            if (NPC.velocity.Y > -wormSpeed)
                            {
                                NPC.velocity.Y = NPC.velocity.Y - wormTurnSpeed;
                            }
                        }
                    }
                }
                if (!flag21)
                {
                    if (NPC.velocity.X > 0f && num191 > 0f || NPC.velocity.X < 0f && num191 < 0f || NPC.velocity.Y > 0f && num192 > 0f || NPC.velocity.Y < 0f && num192 < 0f)
                    {
                        if (NPC.velocity.X < num191)
                        {
                            NPC.velocity.X = NPC.velocity.X + wormTurnSpeed;
                        }
                        else
                        {
                            if (NPC.velocity.X > num191)
                            {
                                NPC.velocity.X = NPC.velocity.X - wormTurnSpeed;
                            }
                        }
                        if (NPC.velocity.Y < num192)
                        {
                            NPC.velocity.Y = NPC.velocity.Y + wormTurnSpeed;
                        }
                        else
                        {
                            if (NPC.velocity.Y > num192)
                            {
                                NPC.velocity.Y = NPC.velocity.Y - wormTurnSpeed;
                            }
                        }
                        if ((double)System.Math.Abs(num192) < (double)wormSpeed * 0.2 && (NPC.velocity.X > 0f && num191 < 0f || NPC.velocity.X < 0f && num191 > 0f))
                        {
                            if (NPC.velocity.Y > 0f)
                            {
                                NPC.velocity.Y = NPC.velocity.Y + wormTurnSpeed * 2f;
                            }
                            else
                            {
                                NPC.velocity.Y = NPC.velocity.Y - wormTurnSpeed * 2f;
                            }
                        }
                        if ((double)System.Math.Abs(num191) < (double)wormSpeed * 0.2 && (NPC.velocity.Y > 0f && num192 < 0f || NPC.velocity.Y < 0f && num192 > 0f))
                        {
                            if (NPC.velocity.X > 0f)
                            {
                                NPC.velocity.X = NPC.velocity.X + wormTurnSpeed * 2f;
                            }
                            else
                            {
                                NPC.velocity.X = NPC.velocity.X - wormTurnSpeed * 2f;
                            }
                        }
                    }
                    else
                    {
                        if (num196 > num197)
                        {
                            if (NPC.velocity.X < num191)
                            {
                                NPC.velocity.X = NPC.velocity.X + wormTurnSpeed * 1.1f;
                            }
                            else if (NPC.velocity.X > num191)
                            {
                                NPC.velocity.X = NPC.velocity.X - wormTurnSpeed * 1.1f;
                            }
                            if ((double)(System.Math.Abs(NPC.velocity.X) + System.Math.Abs(NPC.velocity.Y)) < (double)wormSpeed * 0.5)
                            {
                                if (NPC.velocity.Y > 0f)
                                {
                                    NPC.velocity.Y = NPC.velocity.Y + wormTurnSpeed;
                                }
                                else
                                {
                                    NPC.velocity.Y = NPC.velocity.Y - wormTurnSpeed;
                                }
                            }
                        }
                        else
                        {
                            if (NPC.velocity.Y < num192)
                            {
                                NPC.velocity.Y = NPC.velocity.Y + wormTurnSpeed * 1.1f;
                            }
                            else if (NPC.velocity.Y > num192)
                            {
                                NPC.velocity.Y = NPC.velocity.Y - wormTurnSpeed * 1.1f;
                            }
                            if ((double)(System.Math.Abs(NPC.velocity.X) + System.Math.Abs(NPC.velocity.Y)) < (double)wormSpeed * 0.5)
                            {
                                if (NPC.velocity.X > 0f)
                                {
                                    NPC.velocity.X = NPC.velocity.X + wormTurnSpeed;
                                }
                                else
                                {
                                    NPC.velocity.X = NPC.velocity.X - wormTurnSpeed;
                                }
                            }
                        }
                    }
                }
            }
            NPC.rotation = (float)System.Math.Atan2((double)NPC.velocity.Y, (double)NPC.velocity.X) + 1.57f;
            if (head)
            {
                if (flag18)
                {
                    if (NPC.localAI[0] != 1f)
                    {
                        NPC.netUpdate = true;
                    }
                    NPC.localAI[0] = 1f;
                }
                else
                {
                    if (NPC.localAI[0] != 0f)
                    {
                        NPC.netUpdate = true;
                    }
                    NPC.localAI[0] = 0f;
                }
                if ((NPC.velocity.X > 0f && NPC.oldVelocity.X < 0f || NPC.velocity.X < 0f && NPC.oldVelocity.X > 0f || NPC.velocity.Y > 0f && NPC.oldVelocity.Y < 0f || NPC.velocity.Y < 0f && NPC.oldVelocity.Y > 0f) && !NPC.justHit)
                {
                    NPC.netUpdate = true;
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
