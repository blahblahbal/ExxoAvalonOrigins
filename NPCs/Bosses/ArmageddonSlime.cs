using System;
using ExxoAvalonOrigins.Items.Placeable.Tile;
using ExxoAvalonOrigins.Items.Placeable.Trophy;
using ExxoAvalonOrigins.Items.Potions;
using ExxoAvalonOrigins.Items.Vanity;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.GameContent.ItemDropRules;

namespace ExxoAvalonOrigins.NPCs.Bosses
{
    [AutoloadBossHead]
    public class ArmageddonSlime : ModNPC
    {
        private bool cindersOnce;
        private bool newLanding;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Armageddon Slime");
            Main.npcFrameCount[NPC.type] = 5;
        }

        public override void SetDefaults()
        {
            NPC.damage = 170;
            NPC.boss = true;
            NPC.netAlways = true;
            NPC.scale = 1.8f;
            NPC.lifeMax = 66000;
            NPC.defense = 72;
            NPC.width = 170;
            NPC.aiStyle = -1;
            NPC.npcSlots = 10f;
            NPC.value = 200000f;
            NPC.timeLeft = 75000;
            NPC.height = 120;
            NPC.knockBackResist = 0f;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.buffImmune[BuffID.Confused] = true;
            NPC.buffImmune[BuffID.OnFire] = true;
            NPC.buffImmune[BuffID.CursedInferno] = true;
            NPC.buffImmune[BuffID.Frostburn] = true;
            NPC.buffImmune[Mod.Find<ModBuff>("Freeze").Type] = true;
            //music = mod.GetSoundSlot(SoundType.Music, "Music/ArmageddonSlime");
            //bossBag = ModContent.ItemType<Items.BossBags.ArmageddonSlimeBossBag>();

            cindersOnce = false;
            newLanding = true;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.75f * bossLifeScale);
            NPC.damage = (int)(NPC.damage * 0.95f);
        }

        public override void AI()
        {
            float num236 = 1f;
            bool teleporting = false;
            bool dontCreateDust = false;
            NPC.aiAction = 0;
            if (NPC.ai[3] == 0f && NPC.life > 0)
            {
                NPC.ai[3] = NPC.lifeMax;
            }
            if (NPC.localAI[3] == 0f)
            {
                NPC.ai[0] = -100f;
                NPC.localAI[3] = 1f;
                NPC.TargetClosest(true);
                NPC.netUpdate = true;
            }
            if (Main.player[NPC.target].dead || Vector2.Distance(NPC.Center, Main.player[NPC.target].Center) > 3000f)
            {
                NPC.TargetClosest();
                if (Main.player[NPC.target].dead || Vector2.Distance(NPC.Center, Main.player[NPC.target].Center) > 3000f)
                {
                    if (NPC.timeLeft > 10)
                        NPC.timeLeft = 10;

                    if (Main.player[NPC.target].Center.X < NPC.Center.X)
                    {
                        NPC.direction = 1;
                    }
                    else
                    {
                        NPC.direction = -1;
                    }
                    if (Main.netMode != NetmodeID.MultiplayerClient && NPC.ai[1] != 5f)
                    {
                        NPC.netUpdate = true;
                        NPC.ai[2] = 0f;
                        NPC.ai[0] = 0f;
                        NPC.ai[1] = 5f;
                        NPC.localAI[1] = Main.maxTilesX * 16;
                        NPC.localAI[2] = Main.maxTilesY * 16;
                    }
                }
            }

            #region teleport

            if (!Main.player[NPC.target].dead && NPC.timeLeft > 10 && NPC.ai[2] >= 300f && NPC.ai[1] < 5f && NPC.velocity.Y == 0) // king slime teleport reqs
            {
                NPC.ai[2] = 0f;
                NPC.ai[0] = 0f;
                NPC.ai[1] = 5f;
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    NPC.TargetClosest(false);
                    Point npcTileCenter = NPC.Center.ToTileCoordinates();
                    Point playerTileCenter = Main.player[NPC.target].Center.ToTileCoordinates();
                    Vector2 distance = Main.player[NPC.target].Center - NPC.Center;

                    int teleportSpeed = 0;
                    bool done = false;

                    if (NPC.localAI[0] >= 360f || distance.Length() > 2000f) // skip finding destination if despawning
                    {
                        if (NPC.localAI[0] >= 360f)
                            NPC.localAI[0] = 360f;

                        done = true;
                        teleportSpeed = 100;
                    }

                    while (!done && teleportSpeed < 100) // finding destination to teleport to
                    {
                        teleportSpeed++;
                        Vector2 randomTarget = new Vector2(Main.rand.Next(playerTileCenter.X - 10, playerTileCenter.X + 11), Main.rand.Next(playerTileCenter.Y - 10, playerTileCenter.Y + 1));

                        if (((int)randomTarget.Y >= playerTileCenter.Y - 7 && (int)randomTarget.Y <= playerTileCenter.Y + 7 && (int)randomTarget.X >= playerTileCenter.X - 7 && (int)randomTarget.X <= playerTileCenter.X + 7) || ((int)randomTarget.Y >= npcTileCenter.Y && (int)randomTarget.Y <= playerTileCenter.Y && (int)randomTarget.X >= playerTileCenter.X && (int)randomTarget.X <= playerTileCenter.X) || Main.tile[(int)randomTarget.X, (int)randomTarget.Y].HasUnactuatedTile)
                            continue;

                        int randomTargetYWhy = (int)randomTarget.Y;
                        int tileCounter = 0;

                        if (Main.tile[(int)randomTarget.X, randomTargetYWhy].HasUnactuatedTile && Main.tileSolid[Main.tile[(int)randomTarget.X, randomTargetYWhy].TileType] && !Main.tileSolidTop[Main.tile[(int)randomTarget.X, randomTargetYWhy].TileType])
                        {
                            tileCounter = 1;
                        }
                        else
                        {
                            for (; tileCounter < 150 && randomTargetYWhy + tileCounter < Main.maxTilesY; tileCounter++)
                            {
                                int total = randomTargetYWhy + tileCounter;
                                if (Main.tile[(int)randomTarget.X, total].HasUnactuatedTile && Main.tileSolid[Main.tile[(int)randomTarget.X, total].TileType] && !Main.tileSolidTop[Main.tile[(int)randomTarget.X, total].TileType])
                                {
                                    tileCounter--;
                                    break;
                                }
                            }
                        }
                        randomTarget.Y += tileCounter;
                        bool foundDestination = true;

                        if (foundDestination && Main.tile[(int)randomTarget.X, (int)randomTarget.Y].LiquidType == LiquidID.Lava)
                            foundDestination = false;

                        if (foundDestination && !Collision.CanHitLine(NPC.Center, 0, 0, Main.player[NPC.target].Center, 0, 0))
                            foundDestination = false;

                        if (foundDestination)
                        {
                            NPC.localAI[1] = randomTarget.X * 16 + 8;
                            NPC.localAI[2] = randomTarget.Y * 16 + 16;
                            done = true;
                            break;
                        }
                    }

                    if (teleportSpeed >= 100)
                    {
                        Vector2 playerBottom = Main.player[Player.FindClosest(NPC.position, NPC.width, NPC.height)].Bottom;
                        NPC.localAI[1] = playerBottom.X;
                        NPC.localAI[2] = playerBottom.Y;
                    }
                }
            }

            if (!Collision.CanHitLine(NPC.Center, 0, 0, Main.player[NPC.target].Center, 0, 0) || Math.Abs(NPC.Top.Y - Main.player[NPC.target].Bottom.Y) > 160f)
            {
                NPC.ai[2]++;

                if (Main.netMode != NetmodeID.MultiplayerClient)
                    NPC.localAI[0]++;
            }
            else if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                NPC.localAI[0]--;

                if (NPC.localAI[0] < 0)
                    NPC.localAI[0] = 0;
            }
            if (NPC.timeLeft < 10 && (NPC.ai[0] != 0f || NPC.ai[1] != 0f))
            {
                NPC.ai[0] = 0f;
                NPC.ai[1] = 0f;
                NPC.netUpdate = true;
                teleporting = false;
            }
            Dust teleportDust;
            int dustType;
            if (Main.rand.NextBool(2))
                dustType = 58;
            else
                dustType = 36;
            if (NPC.ai[1] == 5f)
            {
                teleporting = true;
                NPC.aiAction = 1;
                NPC.ai[0]++;
                num236 = MathHelper.Clamp((60f - NPC.ai[0]) / 60f, 0f, 1f);
                num236 = 0.5f + num236 * 0.5f;

                if (NPC.ai[0] >= 60f)
                    dontCreateDust = true;

                if (NPC.ai[0] >= 60f && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    FireProjectiles(1, Main.player[NPC.target]);
                    NPC.Bottom = new Vector2(NPC.localAI[1], NPC.localAI[2]);
                    NPC.ai[1] = 6f;
                    NPC.ai[0] = 0f;
                    NPC.netUpdate = true;
                }
                if (Main.netMode == NetmodeID.MultiplayerClient && NPC.ai[0] >= 120)
                {
                    NPC.ai[1] = 6f;
                    NPC.ai[0] = 0f;
                }
                if (!dontCreateDust)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        int newTeleportDust = Dust.NewDust(NPC.position + Vector2.UnitX * -20f, NPC.width + 40, NPC.height, dustType, NPC.velocity.X, NPC.velocity.Y, 150, default(Color), 2f);
                        Main.dust[newTeleportDust].noGravity = true;
                        teleportDust = Main.dust[newTeleportDust];
                        teleportDust.velocity *= 0.5f;
                    }
                }
            }
            else if (NPC.ai[1] == 6f)
            {
                teleporting = true;
                NPC.aiAction = 0;
                NPC.ai[0]++;
                num236 = MathHelper.Clamp(NPC.ai[0] / 30f, 0f, 1f);
                num236 = 0.5f + num236 * 0.5f;

                if (NPC.ai[0] >= 30f && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    NPC.ai[1] = 0f;
                    NPC.ai[0] = 0f;
                    NPC.netUpdate = true;
                    NPC.TargetClosest();
                }
                if (Main.netMode == NetmodeID.MultiplayerClient && NPC.ai[0] >= 60f)
                {
                    NPC.ai[1] = 0f;
                    NPC.ai[0] = 0f;
                    NPC.TargetClosest();
                }
                for (int i = 0; i < 10; i++)
                {
                    int newTeleportDust = Dust.NewDust(NPC.position + Vector2.UnitX * -20f, NPC.width + 40, NPC.height, dustType, NPC.velocity.X, NPC.velocity.Y, 150, default(Color), 2f);
                    Main.dust[newTeleportDust].noGravity = true;
                    teleportDust = Main.dust[newTeleportDust];
                    teleportDust.velocity *= 2f;
                }
            }
            NPC.dontTakeDamage = (NPC.hide = dontCreateDust);

            #endregion teleport

            if (NPC.velocity.Y == 0f)
            {
                NPC.velocity.X = NPC.velocity.X * 0.8f;
                if (NPC.velocity.X > -0.1 && NPC.velocity.X < 0.1)
                {
                    NPC.velocity.X = 0f;
                }
                if (!teleporting)
                {
                    NPC.ai[0] += 2f;
                    if (NPC.life < NPC.lifeMax * 0.8)
                    {
                        NPC.ai[0] += 1f;
                    }
                    if (NPC.life < NPC.lifeMax * 0.6)
                    {
                        NPC.ai[0] += 1f;
                    }
                    if (NPC.life < NPC.lifeMax * 0.4)
                    {
                        NPC.ai[0] += 2f;
                    }
                    if (NPC.life < NPC.lifeMax * 0.2)
                    {
                        NPC.ai[0] += 3f;
                    }
                    if (NPC.life < NPC.lifeMax * 0.1)
                    {
                        NPC.ai[0] += 4f;
                    }
                    if (NPC.ai[0] >= 0f)
                    {
                        NPC.netUpdate = true;
                        NPC.TargetClosest(true);
                        if (NPC.ai[1] == 3f)
                        {
                            NPC.velocity.Y = -13f;
                            NPC.velocity.X = NPC.velocity.X + 3.5f * NPC.direction;
                            NPC.ai[0] = -200f;
                            NPC.ai[1] = 0f;
                        }
                        else if (NPC.ai[1] == 2f)
                        {
                            NPC.velocity.Y = -6f;
                            NPC.velocity.X = NPC.velocity.X + 4.5f * NPC.direction;
                            NPC.ai[0] = -120f;
                            NPC.ai[1] += 1f;
                        }
                        else
                        {
                            NPC.velocity.Y = -8f;
                            NPC.velocity.X = NPC.velocity.X + 4f * NPC.direction;
                            NPC.ai[0] = -120f;
                            NPC.ai[1] += 1f;
                        }
                        if (Vector2.Distance(Main.player[NPC.target].position, NPC.position) > 16 * 20)
                        {
                            NPC.velocity.X = NPC.velocity.X + 7f * (float)NPC.direction;
                        }
                        cindersOnce = false;
                        Main.player[Main.myPlayer].Avalon().screenShakeTimer = 0;
                    }
                    else if (NPC.ai[0] >= -30f)
                    {
                        NPC.aiAction = 1;
                    }
                }
            }
            else if (NPC.target < 255 && ((NPC.direction == 1 && NPC.velocity.X < 3f) || (NPC.direction == -1 && NPC.velocity.X > -3f)))
            {
                if ((NPC.direction == -1 && NPC.velocity.X < 0.1) || (NPC.direction == 1 && NPC.velocity.X > -0.1))
                {
                    NPC.velocity.X = NPC.velocity.X + 0.2f * NPC.direction;
                }
                else
                {
                    NPC.velocity.X = NPC.velocity.X * 0.93f;
                }
            }

            #region projectiles / slime spawn

            ExxoAvalonOriginsModPlayer myModPlayer = Main.player[Main.myPlayer].Avalon();

            if (ExxoAvalonOriginsCollisions.SolidCollisionArma(NPC.position, (int)(NPC.width * NPC.scale), (int)(NPC.height * NPC.scale)) && NPC.oldVelocity.Y > 0f)
            {
                if (newLanding && Vector2.Distance(NPC.position, Main.player[Main.myPlayer].position) <= 100 * 16)
                {
                    newLanding = false;
                    myModPlayer.screenShakeTimer = 10;
                }
                if (!cindersOnce)
                {
                    for (int i = 0; i < 4 + Main.rand.Next(3); i++)
                    {
                        Vector2 origin = new Vector2(NPC.Center.X + Main.rand.Next(-(NPC.width / 2), (NPC.width / 2) + 1), NPC.Center.Y + (NPC.height / 2));
                        Vector2 velocity = new Vector2(NPC.velocity.X / 4, Main.rand.NextFloat(-3f, -5f)).RotatedBy(MathHelper.ToRadians(Main.rand.Next(-5, 6)));
                        Projectile.NewProjectile(NPC.GetSpawnSource_ForProjectile(), origin, velocity, ModContent.ProjectileType<Projectiles.DarkCinder>(), NPC.damage / 4, 0.5f, NPC.target);
                    }
                    cindersOnce = true;
                }
            }
            else
            {
                newLanding = true;
            }

            if (Vector2.Distance(NPC.Center, Main.player[Main.myPlayer].Center) < 5000)
            {
                Main.player[Main.myPlayer].AddBuff(ModContent.BuffType<Buffs.CurseofIcarus>(), 300);
            }

            var dust = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.t_Slime, NPC.velocity.X, NPC.velocity.Y, 255, new Color(0, 80, 255, 80), NPC.scale * 1.2f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].velocity *= 0.5f;
            if (NPC.life <= 0)
            {
                return;
            }
            var lifeFraction = NPC.life / (float)NPC.lifeMax;
            lifeFraction = lifeFraction * 0.5f + 0.75f;
            lifeFraction *= num236;
            if (lifeFraction != NPC.scale)
            {
                NPC.position.X = NPC.position.X + NPC.width / 2;
                NPC.position.Y = NPC.position.Y + NPC.height;
                NPC.scale = lifeFraction;
                NPC.width = (int)(98f * NPC.scale);
                NPC.height = (int)(92f * NPC.scale);
                NPC.position.X = NPC.position.X - NPC.width / 2;
                NPC.position.Y = NPC.position.Y - NPC.height;
            }
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                return;
            }
            var num1159 = (int)(NPC.lifeMax * 0.05);
            if (NPC.life + num1159 < NPC.ai[3])
            {
                NPC.ai[3] = NPC.life;
                var cycles = Main.rand.Next(1, 4);
                for (var i = 0; i < cycles; i++)
                {
                    var x2 = (int)(NPC.position.X + Main.rand.Next(NPC.width - 32));
                    var y2 = (int)(NPC.position.Y + Main.rand.Next(NPC.height - 32));
                    var newNPC = NPC.NewNPC(NPC.GetSpawnSourceForNPCFromNPCAI(), x2, y2, ModContent.NPCType<DarkMotherSlime>(), 0);
                    Main.npc[newNPC].velocity.X = Main.rand.Next(-15, 16) * 0.1f;
                    Main.npc[newNPC].velocity.Y = Main.rand.Next(-30, 1) * 0.1f;
                    Main.npc[newNPC].ai[1] = Main.rand.Next(3);
                    if (i == 1) // seems to be doing multiple projectile attacks sometimes because of the for loop, this is the fix I made
                    {
                        int rand = Main.rand.Next(1, 4);
                        switch (rand)
                        {
                            case 3:
                                FireProjectiles(2, Main.player[NPC.target]);
                                break;

                            default:
                                FireProjectiles(1, Main.player[NPC.target]);
                                break;
                        }
                    }
                    NPC.ai[1] = -90f;
                    if (Main.netMode == NetmodeID.Server && newNPC < 200)
                    {
                        NetMessage.SendData(MessageID.SyncNPC, -1, -1, NetworkText.FromLiteral(""), newNPC, 0f, 0f, 0f, 0);
                    }
                }
                return;
            }
            return;

            #endregion projectiles / slime spawn
        }

        public void FireProjectiles(int attackType, Player target)
        {
            switch (attackType)
            {
                case 1:
                    float increment;
                    if (Main.expertMode)
                        increment = 0.2f;
                    else
                        increment = 0.4f;

                    var vector155 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height / 2);
                    SoundEngine.PlaySound(SoundID.Item, (int)NPC.position.X, (int)NPC.position.Y, 33);
                    var num1166 = (float)Math.Atan2(vector155.Y - (Main.player[NPC.target].position.Y + Main.player[NPC.target].height * 0.5f), vector155.X - (Main.player[NPC.target].position.X + Main.player[NPC.target].width * 0.5f));
                    for (var num1167 = 0f; num1167 <= 3.6f; num1167 += increment)
                    {
                        var num1168 = Projectile.NewProjectile(NPC.GetSpawnSource_ForProjectile(), vector155.X, vector155.Y, (float)(Math.Cos(num1166 + num1167) * 16f * -1.0), (float)(Math.Sin(num1166 + num1167) * 16f * -1.0), ModContent.ProjectileType<Projectiles.DarkFlame>(), 60, 0f, NPC.target, 0f, 0f);
                        Main.projectile[num1168].timeLeft = 600;
                        Main.projectile[num1168].tileCollide = false;
                        if (Main.netMode != NetmodeID.SinglePlayer)
                        {
                            NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, num1168);
                        }
                        num1168 = Projectile.NewProjectile(NPC.GetSpawnSource_ForProjectile(), vector155.X, vector155.Y, (float)(Math.Cos(num1166 - num1167) * 16f * -1.0), (float)(Math.Sin(num1166 - num1167) * 16f * -1.0), ModContent.ProjectileType<Projectiles.DarkFlame>(), 60, 0f, NPC.target, 0f, 0f);
                        Main.projectile[num1168].timeLeft = 600;
                        Main.projectile[num1168].tileCollide = false;
                        if (Main.netMode != NetmodeID.SinglePlayer)
                        {
                            NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, num1168);
                        }
                    }
                    break;

                case 2:
                    SoundEngine.PlaySound(SoundID.Item, (int)NPC.position.X, (int)NPC.position.Y, 33);

                    int increments; // Old spray had ~25? weird pattern tho
                    if (Main.expertMode)
                        increments = 11;
                    else
                        increments = 7;

                    float degrees = 45f;
                    float offset = (float)((float)(degrees / increments) / 2f); // IF YOU WANT THE ATTACK TO BE AIMED WITH EVEN INCREMENTS, REMOVE OFFSET FROM THE VELOCITY CALCULATION
                    Vector2 rotation = (target.Center - NPC.Center).SafeNormalize(-Vector2.UnitY);
                    float speed = 16f;
                    for (int i = 0; i < increments; i++)
                    {
                        Vector2 velocity = rotation.RotatedBy(MathHelper.ToRadians(((float)(degrees / 2f) * -1f) + ((float)(degrees / increments) * i) + offset)) * speed;
                        int spray = Projectile.NewProjectile(NPC.GetSpawnSource_ForProjectile(), NPC.Center, velocity, ModContent.ProjectileType<Projectiles.DarkFlame>(), 70, 0f, NPC.target, 0f, 0f);
                        Main.projectile[spray].timeLeft = 600;
                        Main.projectile[spray].tileCollide = false;
                        if (Main.netMode != NetmodeID.SinglePlayer)
                        {
                            NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, spray);
                        }
                    }
                    break;
            }
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ModContent.ItemType<ElixirofLife>();
        }
        public override void OnKill()
        {
            if (!ExxoAvalonOriginsWorld.stoppedArmageddon)
            {
                ModContent.GetInstance<ExxoAvalonOriginsWorld>().GenerateSkyFortress();
                ExxoAvalonOriginsWorld.stoppedArmageddon = true;
            }
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<DarkMatterSoilBlock>(), 1, 100, 210));
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<ArmageddonSlimeMask>(), 7));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ArmageddonSlimeTrophy>(), 10));
            npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<Items.BossBags.ArmageddonSlimeBossBag>()));
        }
        public override void FindFrame(int frameHeight)
        {
            var num2 = 0;
            if (NPC.aiAction == 0)
            {
                if (NPC.velocity.Y < 0f)
                {
                    num2 = 2;
                }
                else if (NPC.velocity.Y > 0f)
                {
                    num2 = 3;
                }
                else if (NPC.velocity.X != 0f)
                {
                    num2 = 1;
                }
                else
                {
                    num2 = 0;
                }
            }
            else if (NPC.aiAction == 1)
            {
                num2 = 4;
            }
            if (NPC.velocity.Y != 0f)
            {
                NPC.frame.Y = frameHeight * 4;
            }
            else
            {
                NPC.frameCounter += 1.0;
                if (num2 > 0)
                {
                    NPC.frameCounter += 1.0;
                }
                if (num2 == 4)
                {
                    NPC.frameCounter += 1.0;
                }
                if (NPC.frameCounter >= 8.0)
                {
                    NPC.frame.Y = NPC.frame.Y + frameHeight;
                    NPC.frameCounter = 0.0;
                }
                if (NPC.frame.Y >= frameHeight * 4)
                {
                    NPC.frame.Y = 0;
                }
            }
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(ModContent.BuffType<Buffs.DarkInferno>(), 300);
        }
    }
}
