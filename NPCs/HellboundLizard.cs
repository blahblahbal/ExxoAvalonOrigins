using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace ExxoAvalonOrigins.NPCs;

public class HellboundLizard : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Hellbound Lizard");
        Main.npcFrameCount[NPC.type] = 16;
        NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData
        {
            SpecificallyImmuneTo = new int[]
            {
                BuffID.Confused,
                BuffID.OnFire
            }
        };
        NPCID.Sets.DebuffImmunitySets[Type] = debuffData;
    }
    public override void SetDefaults()
    {
        NPC.damage = 90;
        NPC.lifeMax = 780;
        NPC.defense = 20;
        NPC.lavaImmune = true;
        NPC.width = 18;
        NPC.aiStyle = 3;
        NPC.value = 1000f;
        NPC.height = 40;
        NPC.knockBackResist = 0.02f;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
        Banner = NPC.type;
        BannerItem = ModContent.ItemType<Items.Banners.HellboundLizardBanner>();
    }
    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.55f);
        NPC.damage = (int)(NPC.damage * 0.85f);
    }
    public override Color? GetAlpha(Color lightColor)
    {
        return new Color(255, 255, 255);
    }
    public override void FindFrame(int frameHeight)
    {
        if (NPC.velocity.Y == 0f)
        {
            if (NPC.direction == 1)
            {
                NPC.spriteDirection = 1;
            }
            if (NPC.direction == -1)
            {
                NPC.spriteDirection = -1;
            }
            if (NPC.velocity.X == 0f)
            {
                NPC.frame.Y = 0;
                NPC.frameCounter = 0.0;
            }
            else
            {
                NPC.frameCounter += Math.Abs(NPC.velocity.X) * 2f;
                NPC.frameCounter += 1.0;
                if (NPC.frameCounter > 6.0)
                {
                    NPC.frame.Y = NPC.frame.Y + frameHeight;
                    NPC.frameCounter = 0.0;
                }
                if (NPC.frame.Y / frameHeight >= Main.npcFrameCount[NPC.type])
                {
                    NPC.frame.Y = frameHeight * 2;
                }
            }
        }
        else
        {
            NPC.frameCounter = 0.0;
            NPC.frame.Y = frameHeight;
        }
    }
    /*public override void AI()
    {
        if (Main.rand.Next(100) == 0)
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                float speed = 11f;
                Vector2 vector = Main.player[npc.target].Center - npc.Center;
                vector.Normalize();
                vector *= speed;

                int fireBall = Projectile.NewProjectile(npc.Center.X + (npc.direction * 12), npc.Center.Y, vector.X, vector.Y, ProjectileID.Fireball, npc.damage, 1, Main.myPlayer, 0, 0);
                Main.projectile[fireBall].damage = npc.damage;
                Main.projectile[fireBall].hostile = true;
                Main.projectile[fireBall].friendly = false;
            }
        }
        Lighting.AddLight((int)((npc.position.X + (float)(npc.width / 2)) / 16f), (int)((npc.position.Y + (float)(npc.height / 2)) / 16f), 0.9f, 0.25f, 0.05f);
        if (Main.rand.Next(7) == 0)
        {
            int num10 = Dust.NewDust(npc.position, npc.width, npc.height, 6, 0f, 0f, 0, default(Color), 1.2f);
            Main.dust[num10].noGravity = true;
        }

        bool flag3 = false;
        if (npc.velocity.X == 0f)
        {
            flag3 = true;
        }
        if (npc.justHit)
        {
            flag3 = false;
        }
        int num22 = 60;
        bool flag4 = false;
        bool flag5 = true;
        if ((npc.type != 387 && npc.type != 110 && npc.type != 111 && npc.type != 206 && npc.type != 216 && npc.type != 214 && npc.type != 215 && npc.type != 291 && npc.type != 292 && npc.type != 293 && npc.type != 350) || npc.ai[2] <= 0f)
        {
            if (npc.velocity.Y == 0f && ((npc.velocity.X > 0f && npc.direction < 0) || (npc.velocity.X < 0f && npc.direction > 0)))
            {
                flag4 = true;
            }
            if (npc.position.X == npc.oldPosition.X || npc.ai[3] >= (float)num22 || flag4)
            {
                npc.ai[3] += 1f;
            }
            else if ((double)Math.Abs(npc.velocity.X) > 0.9 && npc.ai[3] > 0f)
            {
                npc.ai[3] -= 1f;
            }
            if (npc.ai[3] > (float)(num22 * 10))
            {
                npc.ai[3] = 0f;
            }
            if (npc.justHit)
            {
                npc.ai[3] = 0f;
            }
            if (npc.ai[3] == (float)num22)
            {
                npc.netUpdate = true;
            }
        }
        if ((npc.type != 110 && npc.type != 111 && npc.type != 206 && npc.type != 216 && npc.type != 214 && npc.type != 215 && npc.type != 291 && npc.type != 292 && npc.type != 293 && npc.type != 350) || npc.ai[2] <= 0f)
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
            if (npc.direction == 0)
            {
                npc.direction = 1;
            }
        }
        if (npc.type == 21 || npc.type == 26 || npc.type == 31 || npc.type == 482 || npc.type == 294 || npc.type == 295 || npc.type == 296 || npc.type == 47 || npc.type == 73 || npc.type == 140 || npc.type == 164 || npc.type == 239 || npc.type == 167 || npc.type == 168 || npc.type == 185 || npc.type == 198 || npc.type == 201 || npc.type == 202 || npc.type == 203 || npc.type == 217 || npc.type == 218 || npc.type == 219 || npc.type == 226 || npc.type == 181 || npc.type == 254 || npc.type == 338 || npc.type == 339 || npc.type == 340 || npc.type == 342 || npc.type == 484 || npc.type == ModContent.NPCType<HellboundLizard>() || npc.type == 486)
        {
            float num28 = 4.5f;
            if (npc.velocity.X < -num28 || npc.velocity.X > num28)
            {
                if (npc.velocity.Y == 0f)
                {
                    npc.velocity *= 0.8f;
                }
            }
            else if (npc.velocity.X < num28 && npc.direction == 1)
            {
                npc.velocity.X = npc.velocity.X + 0.27f;
                if (npc.velocity.X > num28)
                {
                    npc.velocity.X = num28;
                }
            }
            else if (npc.velocity.X > -num28 && npc.direction == -1)
            {
                npc.velocity.X = npc.velocity.X - 0.27f;
                if (npc.velocity.X < -num28)
                {
                    npc.velocity.X = -num28;
                }
            }
        }
        if (npc.type != 110 && npc.type != 111 && npc.type != 206 && npc.type != 214 && npc.type != 215 && npc.type != 216 && npc.type != 290 && npc.type != 291 && npc.type != 292 && npc.type != 293 && npc.type != 350 && npc.type != 387)
        {
            float num39 = 1f;
            if (npc.type == 186)
            {
                num39 = 1.1f;
            }
            if (npc.type == 187)
            {
                num39 = 0.9f;
            }
            if (npc.type == 188)
            {
                num39 = 1.2f;
            }
            if (npc.type == 189)
            {
                num39 = 0.8f;
            }
            if (npc.type == 132)
            {
                num39 = 0.95f;
            }
            if (npc.type == 200)
            {
                num39 = 0.87f;
            }
            if (npc.type == 223)
            {
                num39 = 1.05f;
            }
            if (npc.velocity.X < -num39 || npc.velocity.X > num39)
            {
                if (npc.velocity.Y == 0f)
                {
                    npc.velocity *= 0.8f;
                }
            }
            else if (npc.velocity.X < num39 && npc.direction == 1)
            {
                npc.velocity.X = npc.velocity.X + 0.27f;
                if (npc.velocity.X > num39)
                {
                    npc.velocity.X = num39;
                }
            }
            else if (npc.velocity.X > -num39 && npc.direction == -1)
            {
                npc.velocity.X = npc.velocity.X - 0.27f;
                if (npc.velocity.X < -num39)
                {
                    npc.velocity.X = -num39;
                }
            }
        }
        bool flag11 = false;
        if (npc.velocity.Y == 0f)
        {
            int num93 = (int)(npc.position.Y + (float)npc.height + 7f) / 16;
            int num94 = (int)npc.position.X / 16;
            int num95 = (int)(npc.position.X + (float)npc.width) / 16;
            for (int num96 = num94; num96 <= num95; num96++)
            {
                if (Main.tile[num96, num93] == null)
                {
                    return;
                }
                if (Main.tile[num96, num93].HasUnactuatedTile && Main.tileSolid[(int)Main.tile[num96, num93].type])
                {
                    flag11 = true;
                    break;
                }
            }
        }
        if (npc.velocity.Y >= 0f)
        {
            int num97 = 0;
            if (npc.velocity.X < 0f)
            {
                num97 = -1;
            }
            if (npc.velocity.X > 0f)
            {
                num97 = 1;
            }
            Vector2 vector10 = npc.position;
            vector10.X += npc.velocity.X;
            int num98 = (int)((vector10.X + (float)(npc.width / 2) + (float)((npc.width / 2 + 1) * num97)) / 16f);
            int num99 = (int)((vector10.Y + (float)npc.height - 1f) / 16f);
            if (Main.tile[num98, num99] == null)
            {
                Main.tile[num98, num99] = new Tile();
            }
            if (Main.tile[num98, num99 - 1] == null)
            {
                Main.tile[num98, num99 - 1] = new Tile();
            }
            if (Main.tile[num98, num99 - 2] == null)
            {
                Main.tile[num98, num99 - 2] = new Tile();
            }
            if (Main.tile[num98, num99 - 3] == null)
            {
                Main.tile[num98, num99 - 3] = new Tile();
            }
            if (Main.tile[num98, num99 + 1] == null)
            {
                Main.tile[num98, num99 + 1] = new Tile();
            }
            if (Main.tile[num98 - num97, num99 - 3] == null)
            {
                Main.tile[num98 - num97, num99 - 3] = new Tile();
            }
            if ((float)(num98 * 16) < vector10.X + (float)npc.width && (float)(num98 * 16 + 16) > vector10.X && ((Main.tile[num98, num99].HasUnactuatedTile && !Main.tile[num98, num99].topSlope() && !Main.tile[num98, num99 - 1].topSlope() && Main.tileSolid[(int)Main.tile[num98, num99].type] && !Main.tileSolidTop[(int)Main.tile[num98, num99].type]) || (Main.tile[num98, num99 - 1].IsHalfBlock && Main.tile[num98, num99 - 1].HasUnactuatedTile)) && (!Main.tile[num98, num99 - 1].HasUnactuatedTile || !Main.tileSolid[(int)Main.tile[num98, num99 - 1].type] || Main.tileSolidTop[(int)Main.tile[num98, num99 - 1].type] || (Main.tile[num98, num99 - 1].IsHalfBlock && (!Main.tile[num98, num99 - 4].HasUnactuatedTile || !Main.tileSolid[(int)Main.tile[num98, num99 - 4].type] || Main.tileSolidTop[(int)Main.tile[num98, num99 - 4].type]))) && (!Main.tile[num98, num99 - 2].HasUnactuatedTile || !Main.tileSolid[(int)Main.tile[num98, num99 - 2].type] || Main.tileSolidTop[(int)Main.tile[num98, num99 - 2].type]) && (!Main.tile[num98, num99 - 3].HasUnactuatedTile || !Main.tileSolid[(int)Main.tile[num98, num99 - 3].type] || Main.tileSolidTop[(int)Main.tile[num98, num99 - 3].type]) && (!Main.tile[num98 - num97, num99 - 3].HasUnactuatedTile || !Main.tileSolid[(int)Main.tile[num98 - num97, num99 - 3].type]))
            {
                float num100 = (float)(num99 * 16);
                if (Main.tile[num98, num99].IsHalfBlock)
                {
                    num100 += 80f; //f8
                }
                if (Main.tile[num98, num99 - 1].IsHalfBlock)
                {
                    num100 -= 80f; //f8
                }
                if (num100 < vector10.Y + (float)npc.height)
                {
                    float num101 = vector10.Y + (float)npc.height - num100;
                    float num102 = 100f; // 16.1f
                    if (num101 <= num102)
                    {
                        npc.gfxOffY += npc.position.Y + (float)npc.height - num100;
                        npc.position.Y = num100 - (float)npc.height;
                        if (num101 < 9f)
                        {
                            npc.stepSpeed = 10f; //1f
                        }
                        else
                        {
                            npc.stepSpeed = 20f; //2f
                        }
                    }
                }
            }
        }
        if (flag11)
        {
            int num103 = (int)((npc.position.X + (float)(npc.width / 2) + (float)(15 * npc.direction)) / 16f);
            int num104 = (int)((npc.position.Y + (float)npc.height - 15f) / 16f);
            if (npc.type == 109 || npc.type == 163 || npc.type == 164 || npc.type == 199 || npc.type == 236 || npc.type == 239 || npc.type == 257 || npc.type == 258 || npc.type == 290)
            {
                num103 = (int)((npc.position.X + (float)(npc.width / 2) + (float)((npc.width / 2 + 16) * npc.direction)) / 16f);
            }
            if (Main.tile[num103, num104] == null)
            {
                Main.tile[num103, num104] = new Tile();
            }
            if (Main.tile[num103, num104 - 1] == null)
            {
                Main.tile[num103, num104 - 1] = new Tile();
            }
            if (Main.tile[num103, num104 - 2] == null)
            {
                Main.tile[num103, num104 - 2] = new Tile();
            }
            if (Main.tile[num103, num104 - 3] == null)
            {
                Main.tile[num103, num104 - 3] = new Tile();
            }
            if (Main.tile[num103, num104 + 1] == null)
            {
                Main.tile[num103, num104 + 1] = new Tile();
            }
            if (Main.tile[num103 + npc.direction, num104 - 1] == null)
            {
                Main.tile[num103 + npc.direction, num104 - 1] = new Tile();
            }
            if (Main.tile[num103 + npc.direction, num104 + 1] == null)
            {
                Main.tile[num103 + npc.direction, num104 + 1] = new Tile();
            }
            if (Main.tile[num103 - npc.direction, num104 + 1] == null)
            {
                Main.tile[num103 - npc.direction, num104 + 1] = new Tile();
            }
            Main.tile[num103, num104 + 1].IsHalfBlock;
            if (Main.tile[num103, num104 - 1].HasUnactuatedTile && (Main.tile[num103, num104 - 1].type == 10 || Main.tile[num103, num104 - 1].type == 485) && flag5)
            {
                npc.ai[2] += 1f;
                npc.ai[3] = 0f;
                if (npc.ai[2] >= 60f)
                {
                    if (!Main.bloodMoon && (npc.type == 3 || npc.type == 331 || npc.type == 332 || npc.type == 132 || npc.type == 161 || npc.type == 186 || npc.type == 187 || npc.type == 188 || npc.type == 189 || npc.type == 200 || npc.type == 223 || npc.type == 320 || npc.type == 321 || npc.type == 319))
                    {
                        npc.ai[1] = 0f;
                    }
                    npc.velocity.X = 0.5f * (float)(-(float)npc.direction);
                    npc.ai[1] += 5f;
                    if (npc.type == 27)
                    {
                        npc.ai[1] += 1f;
                    }
                    if (npc.type == 31 || npc.type == 294 || npc.type == 295 || npc.type == 296)
                    {
                        npc.ai[1] += 6f;
                    }
                    npc.ai[2] = 0f;
                    bool flag12 = false;
                    if (npc.ai[1] >= 10f)
                    {
                        flag12 = true;
                        npc.ai[1] = 10f;
                    }
                    WorldGen.KillTile(num103, num104 - 1, true, false, false);
                    if ((Main.netMode != NetmodeID.MultiplayerClient || !flag12) && flag12 && Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        if (npc.type == 26)
                        {
                            WorldGen.KillTile(num103, num104 - 1, false, false, false);
                            if (Main.netMode == NetmodeID.Server)
                            {
                                NetMessage.SendData(17, -1, -1, NetworkText.Empty, 0, (float)num103, (float)(num104 - 1), 0f, 0);
                            }
                        }
                        else
                        {
                            bool flag13 = WorldGen.OpenDoor(num103, num104 - 1, npc.direction);
                            if (!flag13)
                            {
                                npc.ai[3] = (float)num22;
                                npc.netUpdate = true;
                            }
                            if (Main.netMode == NetmodeID.Server && flag13)
                            {
                                NetMessage.SendData(19, -1, -1, NetworkText.Empty, 0, (float)num103, (float)(num104 - 1), (float)npc.direction, 0);
                            }
                        }
                    }
                }
            }
            else
            {
                if ((npc.velocity.X < 0f && npc.spriteDirection == -1) || (npc.velocity.X > 0f && npc.spriteDirection == 1))
                {
                    if (Main.tile[num103, num104 - 2].HasUnactuatedTile && Main.tileSolid[(int)Main.tile[num103, num104 - 2].type])
                    {
                        if (Main.tile[num103, num104 - 3].HasUnactuatedTile && Main.tileSolid[(int)Main.tile[num103, num104 - 3].type])
                        {
                            npc.velocity.Y = -8f;
                            npc.netUpdate = true;
                        }
                        else
                        {
                            npc.velocity.Y = -7f;
                            npc.netUpdate = true;
                        }
                    }
                    else if (Main.tile[num103, num104 - 1].HasUnactuatedTile && Main.tileSolid[(int)Main.tile[num103, num104 - 1].type])
                    {
                        npc.velocity.Y = -6f;
                        npc.netUpdate = true;
                    }
                    else if (npc.position.Y + (float)npc.height - (float)(num104 * 16) > 20f && Main.tile[num103, num104].HasUnactuatedTile && !Main.tile[num103, num104].topSlope() && Main.tileSolid[(int)Main.tile[num103, num104].type])
                    {
                        npc.velocity.Y = -5f;
                        npc.netUpdate = true;
                    }
                    else if (npc.directionY < 0 && npc.type != 67 && (!Main.tile[num103, num104 + 1].HasUnactuatedTile || !Main.tileSolid[(int)Main.tile[num103, num104 + 1].type]) && (!Main.tile[num103 + npc.direction, num104 + 1].HasUnactuatedTile || !Main.tileSolid[(int)Main.tile[num103 + npc.direction, num104 + 1].type]))
                    {
                        npc.velocity.Y = -8f;
                        npc.velocity.X = npc.velocity.X * 1.5f;
                        npc.netUpdate = true;
                    }
                    else if (flag5)
                    {
                        npc.ai[1] = 0f;
                        npc.ai[2] = 0f;
                    }
                    if (npc.velocity.Y == 0f && flag3 && npc.ai[3] == 1f)
                    {
                        npc.velocity.Y = -5f;
                    }
                }
            }
        }
        else if (flag5)
        {
            npc.ai[1] = 0f;
            npc.ai[2] = 0f;
        }
        if (Main.netMode != NetmodeID.MultiplayerClient && npc.type == 120 && npc.ai[3] >= (float)num22)
        {
            int num105 = (int)Main.player[npc.target].position.X / 16;
            int num106 = (int)Main.player[npc.target].position.Y / 16;
            int num107 = (int)npc.position.X / 16;
            int num108 = (int)npc.position.Y / 16;
            int num109 = 20;
            int num110 = 0;
            bool flag14 = false;
            if (Math.Abs(npc.position.X - Main.player[npc.target].position.X) + Math.Abs(npc.position.Y - Main.player[npc.target].position.Y) > 2000f)
            {
                num110 = 100;
                flag14 = true;
            }
            while (!flag14)
            {
                if (num110 >= 100)
                {
                    return;
                }
                num110++;
                int num111 = Main.rand.Next(num105 - num109, num105 + num109);
                int num112 = Main.rand.Next(num106 - num109, num106 + num109);
                for (int num113 = num112; num113 < num106 + num109; num113++)
                {
                    if ((num113 < num106 - 4 || num113 > num106 + 4 || num111 < num105 - 4 || num111 > num105 + 4) && (num113 < num108 - 1 || num113 > num108 + 1 || num111 < num107 - 1 || num111 > num107 + 1) && Main.tile[num111, num113].HasUnactuatedTile)
                    {
                        bool flag15 = true;
                        if (npc.type == 32 && Main.tile[num111, num113 - 1].wall == 0)
                        {
                            flag15 = false;
                        }
                        else if (Main.tile[num111, num113 - 1].lava())
                        {
                            flag15 = false;
                        }
                        if (flag15 && Main.tileSolid[(int)Main.tile[num111, num113].type] && !Collision.SolidTiles(num111 - 1, num111 + 1, num113 - 4, num113 - 1))
                        {
                            npc.position.X = (float)(num111 * 16 - npc.width / 2);
                            npc.position.Y = (float)(num113 * 16 - npc.height);
                            npc.netUpdate = true;
                            npc.ai[3] = -120f;
                        }
                    }
                }
            }
        }
    }*/
    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        if (spawnInfo.player.Avalon().ZoneHellcastle && Main.tile[spawnInfo.spawnTileX, spawnInfo.spawnTileY].WallType == (ushort)ModContent.WallType<Walls.ImperviousBrickWallUnsafe>())
        {
            return 3f;
        }
        return 0f;
    }
    public override void HitEffect(int hitDirection, double damage)
    {
        for (int i = 0; i < 20; i++)
        {
            int num890 = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Torch, 0f, 0f, 0, default(Color), 1f);
            Main.dust[num890].velocity *= 5f;
            Main.dust[num890].scale = 1.2f;
            Main.dust[num890].noGravity = true;
        }
        if (NPC.life <= 0)
        {
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("HellboundLizardGore1").Type, 1f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("HellboundLizardGore2").Type, 1f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("HellboundLizardGore2").Type, 1f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("HellboundLizardGore3").Type, 1f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("HellboundLizardGore3").Type, 1f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("HellboundLizardGore4").Type, 1f);
        }
    }
}
