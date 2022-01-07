using Microsoft.Xna.Framework;
using System;
using ExxoAvalonOrigins.Items.Placeable.Tile;
using ExxoAvalonOrigins.Items.Placeable.Trophy;
using ExxoAvalonOrigins.Items.Potions;
using ExxoAvalonOrigins.Items.Vanity;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

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
            Main.npcFrameCount[npc.type] = 5;
        }

        public override void SetDefaults()
        {
            npc.damage = 170;
            npc.boss = true;
            npc.netAlways = true;
            npc.scale = 1.8f;
            npc.lifeMax = 61000;
            npc.defense = 55;
            npc.width = 170;
            npc.aiStyle = -1;
            npc.npcSlots = 10f;
            npc.value = 200000f;
            npc.timeLeft = 750;
            npc.height = 120;
            npc.knockBackResist = 0f;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.buffImmune[BuffID.Confused] = true;
            npc.buffImmune[BuffID.OnFire] = true;
            npc.buffImmune[BuffID.CursedInferno] = true;
            npc.buffImmune[BuffID.Frostburn] = true;
            npc.buffImmune[mod.BuffType("Freeze")] = true;
            //music = mod.GetSoundSlot(SoundType.Music, "Music/ArmageddonSlime");
            bossBag = ModContent.ItemType<Items.BossBags.ArmageddonSlimeBossBag>();

            cindersOnce = false;
            newLanding = true;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.25f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.25f);
        }

        public override void AI()
        {
            float num236 = 1f;
            bool teleporting = false;
            bool dontCreateDust = false;
            npc.aiAction = 0;
            if (npc.ai[3] == 0f && npc.life > 0)
            {
                npc.ai[3] = npc.lifeMax;
            }
            if (npc.localAI[3] == 0f)
            {
                npc.ai[0] = -100f;
                npc.localAI[3] = 1f;
                npc.TargetClosest(true);
                npc.netUpdate = true;
            }
            if (Main.player[npc.target].dead || Vector2.Distance(npc.Center, Main.player[npc.target].Center) > 3000f)
            {
                npc.TargetClosest();
                if (Main.player[npc.target].dead || Vector2.Distance(npc.Center, Main.player[npc.target].Center) > 3000f)
                {
                    if (npc.timeLeft > 10)
                        npc.timeLeft = 10;

                    if (Main.player[npc.target].Center.X < npc.Center.X)
                    {
                        npc.direction = 1;
                    }
                    else
                    {
                        npc.direction = -1;
                    }
                    if (Main.netMode != NetmodeID.MultiplayerClient && npc.ai[1] != 5f)
                    {
                        npc.netUpdate = true;
                        npc.ai[2] = 0f;
                        npc.ai[0] = 0f;
                        npc.ai[1] = 5f;
                        npc.localAI[1] = Main.maxTilesX * 16;
                        npc.localAI[2] = Main.maxTilesY * 16;
                    }
                }
            }

            #region teleport

            if (!Main.player[npc.target].dead && npc.timeLeft > 10 && npc.ai[2] >= 300f && npc.ai[1] < 5f && npc.velocity.Y == 0) // king slime teleport reqs
            {
                npc.ai[2] = 0f;
                npc.ai[0] = 0f;
                npc.ai[1] = 5f;
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    npc.TargetClosest(false);
                    Point npcTileCenter = npc.Center.ToTileCoordinates();
                    Point playerTileCenter = Main.player[npc.target].Center.ToTileCoordinates();
                    Vector2 distance = Main.player[npc.target].Center - npc.Center;

                    int teleportSpeed = 0;
                    bool done = false;

                    if (npc.localAI[0] >= 360f || distance.Length() > 2000f) // skip finding destination if despawning
                    {
                        if (npc.localAI[0] >= 360f)
                            npc.localAI[0] = 360f;

                        done = true;
                        teleportSpeed = 100;
                    }

                    while (!done && teleportSpeed < 100) // finding destination to teleport to
                    {
                        teleportSpeed++;
                        Vector2 randomTarget = new Vector2(Main.rand.Next(playerTileCenter.X - 10, playerTileCenter.X + 11), Main.rand.Next(playerTileCenter.Y - 10, playerTileCenter.Y + 1));

                        if (((int)randomTarget.Y >= playerTileCenter.Y - 7 && (int)randomTarget.Y <= playerTileCenter.Y + 7 && (int)randomTarget.X >= playerTileCenter.X - 7 && (int)randomTarget.X <= playerTileCenter.X + 7) || ((int)randomTarget.Y >= npcTileCenter.Y && (int)randomTarget.Y <= playerTileCenter.Y && (int)randomTarget.X >= playerTileCenter.X && (int)randomTarget.X <= playerTileCenter.X) || Main.tile[(int)randomTarget.X, (int)randomTarget.Y].nactive())
                            continue;

                        int randomTargetYWhy = (int)randomTarget.Y;
                        int tileCounter = 0;

                        if (Main.tile[(int)randomTarget.X, randomTargetYWhy].nactive() && Main.tileSolid[Main.tile[(int)randomTarget.X, randomTargetYWhy].type] && !Main.tileSolidTop[Main.tile[(int)randomTarget.X, randomTargetYWhy].type])
                        {
                            tileCounter = 1;
                        }
                        else
                        {
                            for (; tileCounter < 150 && randomTargetYWhy + tileCounter < Main.maxTilesY; tileCounter++)
                            {
                                int total = randomTargetYWhy + tileCounter;
                                if (Main.tile[(int)randomTarget.X, total].nactive() && Main.tileSolid[Main.tile[(int)randomTarget.X, total].type] && !Main.tileSolidTop[Main.tile[(int)randomTarget.X, total].type])
                                {
                                    tileCounter--;
                                    break;
                                }
                            }
                        }
                        randomTarget.Y += tileCounter;
                        bool foundDestination = true;

                        if (foundDestination && Main.tile[(int)randomTarget.X, (int)randomTarget.Y].lava())
                            foundDestination = false;

                        if (foundDestination && !Collision.CanHitLine(npc.Center, 0, 0, Main.player[npc.target].Center, 0, 0))
                            foundDestination = false;

                        if (foundDestination)
                        {
                            npc.localAI[1] = randomTarget.X * 16 + 8;
                            npc.localAI[2] = randomTarget.Y * 16 + 16;
                            done = true;
                            break;
                        }
                    }

                    if (teleportSpeed >= 100)
                    {
                        Vector2 playerBottom = Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].Bottom;
                        npc.localAI[1] = playerBottom.X;
                        npc.localAI[2] = playerBottom.Y;
                    }
                }
            }

            if (!Collision.CanHitLine(npc.Center, 0, 0, Main.player[npc.target].Center, 0, 0) || Math.Abs(npc.Top.Y - Main.player[npc.target].Bottom.Y) > 160f)
            {
                npc.ai[2]++;

                if (Main.netMode != NetmodeID.MultiplayerClient)
                    npc.localAI[0]++;
            }
            else if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                npc.localAI[0]--;

                if (npc.localAI[0] < 0)
                    npc.localAI[0] = 0;
            }
            if (npc.timeLeft < 10 && (npc.ai[0] != 0f || npc.ai[1] != 0f))
            {
                npc.ai[0] = 0f;
                npc.ai[1] = 0f;
                npc.netUpdate = true;
                teleporting = false;
            }
            Dust teleportDust;
            int dustType;
            if (Main.rand.NextBool(2))
                dustType = 58;
            else
                dustType = 36;
            if (npc.ai[1] == 5f)
            {
                teleporting = true;
                npc.aiAction = 1;
                npc.ai[0]++;
                num236 = MathHelper.Clamp((60f - npc.ai[0]) / 60f, 0f, 1f);
                num236 = 0.5f + num236 * 0.5f;

                if (npc.ai[0] >= 60f)
                    dontCreateDust = true;

                if (npc.ai[0] >= 60f && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    FireProjectiles(1, Main.player[npc.target]);
                    npc.Bottom = new Vector2(npc.localAI[1], npc.localAI[2]);
                    npc.ai[1] = 6f;
                    npc.ai[0] = 0f;
                    npc.netUpdate = true;
                }
                if (Main.netMode == NetmodeID.MultiplayerClient && npc.ai[0] >= 120)
                {
                    npc.ai[1] = 6f;
                    npc.ai[0] = 0f;
                }
                if (!dontCreateDust)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        int newTeleportDust = Dust.NewDust(npc.position + Vector2.UnitX * -20f, npc.width + 40, npc.height, dustType, npc.velocity.X, npc.velocity.Y, 150, default(Color), 2f);
                        Main.dust[newTeleportDust].noGravity = true;
                        teleportDust = Main.dust[newTeleportDust];
                        teleportDust.velocity *= 0.5f;
                    }
                }
            }
            else if (npc.ai[1] == 6f)
            {
                teleporting = true;
                npc.aiAction = 0;
                npc.ai[0]++;
                num236 = MathHelper.Clamp(npc.ai[0] / 30f, 0f, 1f);
                num236 = 0.5f + num236 * 0.5f;

                if (npc.ai[0] >= 30f && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    npc.ai[1] = 0f;
                    npc.ai[0] = 0f;
                    npc.netUpdate = true;
                    npc.TargetClosest();
                }
                if (Main.netMode == NetmodeID.MultiplayerClient && npc.ai[0] >= 60f)
                {
                    npc.ai[1] = 0f;
                    npc.ai[0] = 0f;
                    npc.TargetClosest();
                }
                for (int i = 0; i < 10; i++)
                {
                    int newTeleportDust = Dust.NewDust(npc.position + Vector2.UnitX * -20f, npc.width + 40, npc.height, dustType, npc.velocity.X, npc.velocity.Y, 150, default(Color), 2f);
                    Main.dust[newTeleportDust].noGravity = true;
                    teleportDust = Main.dust[newTeleportDust];
                    teleportDust.velocity *= 2f;
                }
            }
            npc.dontTakeDamage = (npc.hide = dontCreateDust);

            #endregion teleport

            if (npc.velocity.Y == 0f)
            {
                npc.velocity.X = npc.velocity.X * 0.8f;
                if (npc.velocity.X > -0.1 && npc.velocity.X < 0.1)
                {
                    npc.velocity.X = 0f;
                }
                if (!teleporting)
                {
                    npc.ai[0] += 2f;
                    if (npc.life < npc.lifeMax * 0.8)
                    {
                        npc.ai[0] += 1f;
                    }
                    if (npc.life < npc.lifeMax * 0.6)
                    {
                        npc.ai[0] += 1f;
                    }
                    if (npc.life < npc.lifeMax * 0.4)
                    {
                        npc.ai[0] += 2f;
                    }
                    if (npc.life < npc.lifeMax * 0.2)
                    {
                        npc.ai[0] += 3f;
                    }
                    if (npc.life < npc.lifeMax * 0.1)
                    {
                        npc.ai[0] += 4f;
                    }
                    if (npc.ai[0] >= 0f)
                    {
                        npc.netUpdate = true;
                        npc.TargetClosest(true);
                        if (npc.ai[1] == 3f)
                        {
                            npc.velocity.Y = -13f;
                            npc.velocity.X = npc.velocity.X + 3.5f * npc.direction;
                            npc.ai[0] = -200f;
                            npc.ai[1] = 0f;
                        }
                        else if (npc.ai[1] == 2f)
                        {
                            npc.velocity.Y = -6f;
                            npc.velocity.X = npc.velocity.X + 4.5f * npc.direction;
                            npc.ai[0] = -120f;
                            npc.ai[1] += 1f;
                        }
                        else
                        {
                            npc.velocity.Y = -8f;
                            npc.velocity.X = npc.velocity.X + 4f * npc.direction;
                            npc.ai[0] = -120f;
                            npc.ai[1] += 1f;
                        }
                        if (Vector2.Distance(Main.player[npc.target].position, npc.position) > 16 * 20)
                        {
                            npc.velocity.X = npc.velocity.X + 7f * (float)npc.direction;
                        }
                        cindersOnce = false;
                        Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().screenShakeTimer = 0;
                    }
                    else if (npc.ai[0] >= -30f)
                    {
                        npc.aiAction = 1;
                    }
                }
            }
            else if (npc.target < 255 && ((npc.direction == 1 && npc.velocity.X < 3f) || (npc.direction == -1 && npc.velocity.X > -3f)))
            {
                if ((npc.direction == -1 && npc.velocity.X < 0.1) || (npc.direction == 1 && npc.velocity.X > -0.1))
                {
                    npc.velocity.X = npc.velocity.X + 0.2f * npc.direction;
                }
                else
                {
                    npc.velocity.X = npc.velocity.X * 0.93f;
                }
            }

            #region projectiles / slime spawn

            ExxoAvalonOriginsModPlayer myModPlayer = Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>();

            if (ExxoAvalonOriginsCollisions.SolidCollisionArma(npc.position, (int)(npc.width * npc.scale), (int)(npc.height * npc.scale)) && npc.oldVelocity.Y > 0f)
            {
                if (newLanding && Vector2.Distance(npc.position, Main.player[Main.myPlayer].position) <= 100 * 16)
                {
                    newLanding = false;
                    myModPlayer.screenShakeTimer = 10;
                }
                if (!cindersOnce)
                {
                    for (int i = 0; i < 4 + Main.rand.Next(3); i++)
                    {
                        Vector2 origin = new Vector2(npc.Center.X + Main.rand.Next(-(npc.width / 2), (npc.width / 2) + 1), npc.Center.Y + (npc.height / 2));
                        Vector2 velocity = new Vector2(npc.velocity.X / 4, Main.rand.NextFloat(-3f, -5f)).RotatedBy(MathHelper.ToRadians(Main.rand.Next(-5, 6)));
                        Projectile.NewProjectile(origin, velocity, ModContent.ProjectileType<Projectiles.DarkCinder>(), npc.damage / 4, 0.5f, npc.target);
                    }
                    cindersOnce = true;
                }
            }
            else
            {
                newLanding = true;
            }

            if (Vector2.Distance(npc.Center, Main.player[Main.myPlayer].Center) < 5000)
            {
                Main.player[Main.myPlayer].AddBuff(ModContent.BuffType<Buffs.CurseofIcarus>(), 300);
            }

            var dust = Dust.NewDust(npc.position, npc.width, npc.height, DustID.t_Slime, npc.velocity.X, npc.velocity.Y, 255, new Color(0, 80, 255, 80), npc.scale * 1.2f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].velocity *= 0.5f;
            if (npc.life <= 0)
            {
                return;
            }
            var lifeFraction = npc.life / (float)npc.lifeMax;
            lifeFraction = lifeFraction * 0.5f + 0.75f;
            lifeFraction *= num236;
            if (lifeFraction != npc.scale)
            {
                npc.position.X = npc.position.X + npc.width / 2;
                npc.position.Y = npc.position.Y + npc.height;
                npc.scale = lifeFraction;
                npc.width = (int)(98f * npc.scale);
                npc.height = (int)(92f * npc.scale);
                npc.position.X = npc.position.X - npc.width / 2;
                npc.position.Y = npc.position.Y - npc.height;
            }
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                return;
            }
            var num1159 = (int)(npc.lifeMax * 0.05);
            if (npc.life + num1159 < npc.ai[3])
            {
                npc.ai[3] = npc.life;
                var cycles = Main.rand.Next(1, 4);
                for (var i = 0; i < cycles; i++)
                {
                    var x2 = (int)(npc.position.X + Main.rand.Next(npc.width - 32));
                    var y2 = (int)(npc.position.Y + Main.rand.Next(npc.height - 32));
                    var newNPC = NPC.NewNPC(x2, y2, ModContent.NPCType<DarkMotherSlime>(), 0);
                    Main.npc[newNPC].velocity.X = Main.rand.Next(-15, 16) * 0.1f;
                    Main.npc[newNPC].velocity.Y = Main.rand.Next(-30, 1) * 0.1f;
                    Main.npc[newNPC].ai[1] = Main.rand.Next(3);
                    if (i == 1) // seems to be doing multiple projectile attacks sometimes because of the for loop, this is the fix I made
                    {
                        int rand = Main.rand.Next(1, 4);
                        switch (rand)
                        {
                            case 3:
                                FireProjectiles(2, Main.player[npc.target]);
                                break;

                            default:
                                FireProjectiles(1, Main.player[npc.target]);
                                break;
                        }
                    }
                    npc.ai[1] = -90f;
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

                    var vector155 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height / 2);
                    Main.PlaySound(SoundID.Item, (int)npc.position.X, (int)npc.position.Y, 33);
                    var num1166 = (float)Math.Atan2(vector155.Y - (Main.player[npc.target].position.Y + Main.player[npc.target].height * 0.5f), vector155.X - (Main.player[npc.target].position.X + Main.player[npc.target].width * 0.5f));
                    for (var num1167 = 0f; num1167 <= 3.6f; num1167 += increment)
                    {
                        var num1168 = Projectile.NewProjectile(vector155.X, vector155.Y, (float)(Math.Cos(num1166 + num1167) * 16f * -1.0), (float)(Math.Sin(num1166 + num1167) * 16f * -1.0), ModContent.ProjectileType<Projectiles.DarkFlame>(), 60, 0f, npc.target, 0f, 0f);
                        Main.projectile[num1168].timeLeft = 600;
                        Main.projectile[num1168].tileCollide = false;
                        if (Main.netMode != NetmodeID.SinglePlayer)
                        {
                            NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, num1168);
                        }
                        num1168 = Projectile.NewProjectile(vector155.X, vector155.Y, (float)(Math.Cos(num1166 - num1167) * 16f * -1.0), (float)(Math.Sin(num1166 - num1167) * 16f * -1.0), ModContent.ProjectileType<Projectiles.DarkFlame>(), 60, 0f, npc.target, 0f, 0f);
                        Main.projectile[num1168].timeLeft = 600;
                        Main.projectile[num1168].tileCollide = false;
                        if (Main.netMode != NetmodeID.SinglePlayer)
                        {
                            NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, num1168);
                        }
                    }
                    break;

                case 2:
                    Main.PlaySound(SoundID.Item, (int)npc.position.X, (int)npc.position.Y, 33);

                    int increments; // Old spray had ~25? weird pattern tho
                    if (Main.expertMode)
                        increments = 11;
                    else
                        increments = 7;

                    float degrees = 45f;
                    float offset = (float)((float)(degrees / increments) / 2f); // IF YOU WANT THE ATTACK TO BE AIMED WITH EVEN INCREMENTS, REMOVE OFFSET FROM THE VELOCITY CALCULATION
                    Vector2 rotation = (target.Center - npc.Center).SafeNormalize(-Vector2.UnitY);
                    float speed = 16f;
                    for (int i = 0; i < increments; i++)
                    {
                        Vector2 velocity = rotation.RotatedBy(MathHelper.ToRadians(((float)(degrees / 2f) * -1f) + ((float)(degrees / increments) * i) + offset)) * speed;
                        int spray = Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.DarkFlame>(), 70, 0f, npc.target, 0f, 0f);
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

        public override void NPCLoot()
        {
            ExxoAvalonOriginsGlobalNPC.stoppedArmageddon = true;
            if (Main.expertMode)
            {
                npc.DropBossBags();
            }
            else
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<DarkMatterSoilBlock>(), Main.rand.Next(100, 210), false, 0, false);
            }
            if (Main.rand.Next(10) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<ArmageddonSlimeTrophy>(), 1, false, 0, false);
            }
            if (Main.rand.Next(7) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<ArmageddonSlimeMask>(), 1, false, 0, false);
            }
        }

        public override void FindFrame(int frameHeight)
        {
            var num2 = 0;
            if (npc.aiAction == 0)
            {
                if (npc.velocity.Y < 0f)
                {
                    num2 = 2;
                }
                else if (npc.velocity.Y > 0f)
                {
                    num2 = 3;
                }
                else if (npc.velocity.X != 0f)
                {
                    num2 = 1;
                }
                else
                {
                    num2 = 0;
                }
            }
            else if (npc.aiAction == 1)
            {
                num2 = 4;
            }
            if (npc.velocity.Y != 0f)
            {
                npc.frame.Y = frameHeight * 4;
            }
            else
            {
                npc.frameCounter += 1.0;
                if (num2 > 0)
                {
                    npc.frameCounter += 1.0;
                }
                if (num2 == 4)
                {
                    npc.frameCounter += 1.0;
                }
                if (npc.frameCounter >= 8.0)
                {
                    npc.frame.Y = npc.frame.Y + frameHeight;
                    npc.frameCounter = 0.0;
                }
                if (npc.frame.Y >= frameHeight * 4)
                {
                    npc.frame.Y = 0;
                }
            }
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(ModContent.BuffType<Buffs.DarkInferno>(), 300);
        }
    }
}
