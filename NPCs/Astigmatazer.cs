using System;
using ExxoAvalonOrigins.Items.Material;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.NPCs;

public class Astigmatazer : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Astigmatazer");
        Main.npcFrameCount[NPC.type] = 6;
    }

    public override void SetDefaults()
    {
        NPC.damage = 90;
        NPC.boss = true;
        NPC.netAlways = true;
        NPC.noTileCollide = true;
        NPC.lifeMax = 60000;
        NPC.defense = 30;
        NPC.noGravity = true;
        NPC.width = 100;
        NPC.aiStyle = -1;
        NPC.npcSlots = 2f;
        NPC.value = 50000f;
        NPC.timeLeft = 750;
        NPC.height = 110;
        NPC.knockBackResist = 0f;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath14;
        NPC.buffImmune[BuffID.Confused] = true;
    }

    public override void NPCLoot()
    {
        Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType<SoulofBlight>(), Main.rand.Next(5) + 1, false, 0, false);
        Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ItemID.SoulofMight, Main.rand.Next(5) + 1, false, 0, false);
        Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ItemID.SoulofSight, Main.rand.Next(5) + 1, false, 0, false);
    }

    public override void AI()
    {
        if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
        {
            NPC.TargetClosest(true);
        }
        var dead2 = Main.player[NPC.target].dead;
        var num485 = NPC.position.X + NPC.width / 2 - Main.player[NPC.target].position.X - Main.player[NPC.target].width / 2;
        var num486 = NPC.position.Y + NPC.height - 59f - Main.player[NPC.target].position.Y - Main.player[NPC.target].height / 2;
        var num487 = (float)Math.Atan2(num486, num485) + 1.57f;
        if (num487 < 0f)
        {
            num487 += 6.283f;
        }
        else if (num487 > 6.283)
        {
            num487 -= 6.283f;
        }
        if (NPC.rotation < num487)
        {
            if (num487 - NPC.rotation > 3.1415)
            {
                NPC.rotation -= 0.1f;
            }
            else
            {
                NPC.rotation += 0.1f;
            }
        }
        else if (NPC.rotation > num487)
        {
            if (NPC.rotation - num487 > 3.1415)
            {
                NPC.rotation += 0.1f;
            }
            else
            {
                NPC.rotation -= 0.1f;
            }
        }
        if (NPC.rotation > num487 - 0.1f && NPC.rotation < num487 + 0.1f)
        {
            NPC.rotation = num487;
        }
        if (NPC.rotation < 0f)
        {
            NPC.rotation += 6.283f;
        }
        else if (NPC.rotation > 6.283)
        {
            NPC.rotation -= 6.283f;
        }
        if (NPC.rotation > num487 - 0.1f && NPC.rotation < num487 + 0.1f)
        {
            NPC.rotation = num487;
        }
        if (Main.rand.Next(5) == 0)
        {
            var num489 = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y + NPC.height * 0.25f), NPC.width, (int)(NPC.height * 0.5f), DustID.Blood, NPC.velocity.X, 2f, 0, default(Color), 1f);
            var dust40 = Main.dust[num489];
            dust40.velocity.X = dust40.velocity.X * 0.5f;
            var dust41 = Main.dust[num489];
            dust41.velocity.Y = dust41.velocity.Y * 0.1f;
        }
        if (Main.netMode != NetmodeID.MultiplayerClient && !Main.dayTime && !dead2 && NPC.timeLeft < 10)
        {
            for (var num490 = 0; num490 < 200; num490++)
            {
                if (num490 != NPC.whoAmI && Main.npc[num490].active && (Main.npc[num490].type == NPCID.Retinazer || Main.npc[num490].type == NPCID.Spazmatism) && Main.npc[num490].timeLeft - 1 > NPC.timeLeft)
                {
                    NPC.timeLeft = Main.npc[num490].timeLeft - 1;
                }
            }
        }
        if (Main.dayTime || dead2)
        {
            NPC.velocity.Y = NPC.velocity.Y - 0.04f;
            if (NPC.timeLeft > 10)
            {
                NPC.timeLeft = 10;
                return;
            }
            return;
        }
        else if (NPC.ai[0] == 0f)
        {
            if (NPC.ai[1] == 0f)
            {
                var num493 = 1;
                if (NPC.position.X + NPC.width / 2 < Main.player[NPC.target].position.X + Main.player[NPC.target].width)
                {
                    num493 = -1;
                }
                var vector46 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
                var num494 = Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 + num493 * 300 - vector46.X;
                var num495 = Main.player[NPC.target].position.Y + Main.player[NPC.target].height / 2 - 300f - vector46.Y;
                var num496 = (float)Math.Sqrt(num494 * num494 + num495 * num495);
                num496 = 7f / num496;
                num494 *= num496;
                num495 *= num496;
                if (NPC.velocity.X < num494)
                {
                    NPC.velocity.X = NPC.velocity.X + 0.1f;
                    if (NPC.velocity.X < 0f && num494 > 0f)
                    {
                        NPC.velocity.X = NPC.velocity.X + 0.1f;
                    }
                }
                else if (NPC.velocity.X > num494)
                {
                    NPC.velocity.X = NPC.velocity.X - 0.1f;
                    if (NPC.velocity.X > 0f && num494 < 0f)
                    {
                        NPC.velocity.X = NPC.velocity.X - 0.1f;
                    }
                }
                if (NPC.velocity.Y < num495)
                {
                    NPC.velocity.Y = NPC.velocity.Y + 0.1f;
                    if (NPC.velocity.Y < 0f && num495 > 0f)
                    {
                        NPC.velocity.Y = NPC.velocity.Y + 0.1f;
                    }
                }
                else if (NPC.velocity.Y > num495)
                {
                    NPC.velocity.Y = NPC.velocity.Y - 0.1f;
                    if (NPC.velocity.Y > 0f && num495 < 0f)
                    {
                        NPC.velocity.Y = NPC.velocity.Y - 0.1f;
                    }
                }
                NPC.ai[2] += 1f;
                if (NPC.ai[2] >= 600f)
                {
                    NPC.ai[1] = 1f;
                    NPC.ai[2] = 0f;
                    NPC.ai[3] = 0f;
                    NPC.target = 255;
                    NPC.netUpdate = true;
                }
                else if (NPC.position.Y + NPC.height < Main.player[NPC.target].position.Y && num496 < 400f)
                {
                    if (!Main.player[NPC.target].dead)
                    {
                        NPC.ai[3] += 1f;
                    }
                    if (NPC.ai[3] >= 60f)
                    {
                        NPC.ai[3] = 0f;
                        vector46 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
                        num494 = Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 - vector46.X;
                        num495 = Main.player[NPC.target].position.Y + Main.player[NPC.target].height / 2 - vector46.Y;
                        if (Main.netMode != NetmodeID.MultiplayerClient)
                        {
                            var num499 = (NPC.type == ModContent.NPCType<Astigmatazer>()) ? 49 : 20;
                            num496 = (float)Math.Sqrt(num494 * num494 + num495 * num495);
                            num496 = 9f / num496;
                            num494 *= num496;
                            num495 *= num496;
                            num494 += Main.rand.Next(-40, 41) * 0.08f;
                            num495 += Main.rand.Next(-40, 41) * 0.08f;
                            vector46.X += num494 * 15f;
                            vector46.Y += num495 * 15f;
                            Projectile.NewProjectile(vector46.X, vector46.Y, num494, num495, ProjectileID.EyeLaser, num499, 0f, Main.myPlayer, 0f, 0f);
                        }
                    }
                }
            }
            else if (NPC.ai[1] == 1f)
            {
                NPC.rotation = num487;
                var vector47 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
                var num502 = Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 - vector47.X;
                var num503 = Main.player[NPC.target].position.Y + Main.player[NPC.target].height / 2 - vector47.Y;
                var num504 = (float)Math.Sqrt(num502 * num502 + num503 * num503);
                num504 = 12f / num504;
                NPC.velocity.X = num502 * num504;
                NPC.velocity.Y = num503 * num504;
                NPC.ai[1] = 2f;
            }
            else if (NPC.ai[1] == 2f)
            {
                NPC.ai[2] += 1f;
                if (NPC.ai[2] >= 25f)
                {
                    NPC.velocity.X = NPC.velocity.X * 0.96f;
                    NPC.velocity.Y = NPC.velocity.Y * 0.96f;
                    if (NPC.velocity.X > -0.1 && NPC.velocity.X < 0.1)
                    {
                        NPC.velocity.X = 0f;
                    }
                    if (NPC.velocity.Y > -0.1 && NPC.velocity.Y < 0.1)
                    {
                        NPC.velocity.Y = 0f;
                    }
                }
                else
                {
                    NPC.rotation = (float)Math.Atan2(NPC.velocity.Y, NPC.velocity.X) - 1.57f;
                }
                if (NPC.ai[2] >= 70f)
                {
                    NPC.ai[3] += 1f;
                    NPC.ai[2] = 0f;
                    NPC.target = 255;
                    NPC.rotation = num487;
                    if (NPC.ai[3] >= 4f)
                    {
                        NPC.ai[1] = 0f;
                        NPC.ai[3] = 0f;
                    }
                    else
                    {
                        NPC.ai[1] = 1f;
                    }
                }
            }
            if (NPC.life < NPC.lifeMax * 0.4)
            {
                NPC.ai[0] = 1f;
                NPC.ai[1] = 0f;
                NPC.ai[2] = 0f;
                NPC.ai[3] = 0f;
                NPC.netUpdate = true;
                return;
            }
            return;
        }
        else if (NPC.ai[0] == 1f || NPC.ai[0] == 2f)
        {
            if (NPC.ai[0] == 1f)
            {
                NPC.ai[2] += 0.005f;
                if (NPC.ai[2] > 0.5)
                {
                    NPC.ai[2] = 0.5f;
                }
            }
            else
            {
                NPC.ai[2] -= 0.005f;
                if (NPC.ai[2] < 0f)
                {
                    NPC.ai[2] = 0f;
                }
            }
            NPC.rotation += NPC.ai[2];
            NPC.ai[1] += 1f;
            if (NPC.ai[1] == 100f)
            {
                NPC.ai[0] += 1f;
                NPC.ai[1] = 0f;
                if (NPC.ai[0] == 3f)
                {
                    NPC.ai[2] = 0f;
                }
                else
                {
                    SoundEngine.PlaySound(SoundID.NPCHit, (int)NPC.position.X, (int)NPC.position.Y, 1);
                    for (var num505 = 0; num505 < 2; num505++)
                    {
                        Gore.NewGore(NPC.position, new Vector2(Main.rand.Next(-30, 31) * 0.2f, Main.rand.Next(-30, 31) * 0.2f), 143, 1f);
                        Gore.NewGore(NPC.position, new Vector2(Main.rand.Next(-30, 31) * 0.2f, Main.rand.Next(-30, 31) * 0.2f), 7, 1f);
                        Gore.NewGore(NPC.position, new Vector2(Main.rand.Next(-30, 31) * 0.2f, Main.rand.Next(-30, 31) * 0.2f), 6, 1f);
                    }
                    for (var num506 = 0; num506 < 20; num506++)
                    {
                        Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Blood, Main.rand.Next(-30, 31) * 0.2f, Main.rand.Next(-30, 31) * 0.2f, 0, default(Color), 1f);
                    }
                    SoundEngine.PlaySound(SoundID.Roar, (int)NPC.position.X, (int)NPC.position.Y, 0);
                    NPC.HitSound = SoundID.NPCHit4;
                }
            }
            Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Blood, Main.rand.Next(-30, 31) * 0.2f, Main.rand.Next(-30, 31) * 0.2f, 0, default(Color), 1f);
            NPC.velocity.X = NPC.velocity.X * 0.98f;
            NPC.velocity.Y = NPC.velocity.Y * 0.98f;
            if (NPC.velocity.X > -0.1 && NPC.velocity.X < 0.1)
            {
                NPC.velocity.X = 0f;
            }
            if (NPC.velocity.Y > -0.1 && NPC.velocity.Y < 0.1)
            {
                NPC.velocity.Y = 0f;
                return;
            }
            return;
        }
        else
        {
            NPC.HitSound = SoundID.NPCHit4;
            NPC.damage = (int)(NPC.defDamage * 1.5);
            NPC.defense = NPC.defDefense + 10;
            if (NPC.ai[1] == 0f)
            {
                var vector48 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
                var num509 = Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 - vector48.X;
                var num510 = Main.player[NPC.target].position.Y + Main.player[NPC.target].height / 2 - 300f - vector48.Y;
                var num511 = (float)Math.Sqrt(num509 * num509 + num510 * num510);
                num511 = 8f / num511;
                num509 *= num511;
                num510 *= num511;
                if (NPC.velocity.X < num509)
                {
                    NPC.velocity.X = NPC.velocity.X + 0.15f;
                    if (NPC.velocity.X < 0f && num509 > 0f)
                    {
                        NPC.velocity.X = NPC.velocity.X + 0.15f;
                    }
                }
                else if (NPC.velocity.X > num509)
                {
                    NPC.velocity.X = NPC.velocity.X - 0.15f;
                    if (NPC.velocity.X > 0f && num509 < 0f)
                    {
                        NPC.velocity.X = NPC.velocity.X - 0.15f;
                    }
                }
                if (NPC.velocity.Y < num510)
                {
                    NPC.velocity.Y = NPC.velocity.Y + 0.15f;
                    if (NPC.velocity.Y < 0f && num510 > 0f)
                    {
                        NPC.velocity.Y = NPC.velocity.Y + 0.15f;
                    }
                }
                else if (NPC.velocity.Y > num510)
                {
                    NPC.velocity.Y = NPC.velocity.Y - 0.15f;
                    if (NPC.velocity.Y > 0f && num510 < 0f)
                    {
                        NPC.velocity.Y = NPC.velocity.Y - 0.15f;
                    }
                }
                NPC.ai[2] += 1f;
                if (NPC.ai[2] >= 300f)
                {
                    NPC.ai[1] = 1f;
                    NPC.ai[2] = 0f;
                    NPC.ai[3] = 0f;
                    NPC.TargetClosest(true);
                    NPC.netUpdate = true;
                }
                vector48 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
                num509 = Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 - vector48.X;
                num510 = Main.player[NPC.target].position.Y + Main.player[NPC.target].height / 2 - vector48.Y;
                NPC.rotation = (float)Math.Atan2(num510, num509) - 1.57f;
                if (Main.netMode == NetmodeID.MultiplayerClient)
                {
                    return;
                }
                NPC.localAI[1] += 1f;
                if (NPC.life < NPC.lifeMax * 0.75)
                {
                    NPC.localAI[1] += 1f;
                }
                if (NPC.life < NPC.lifeMax * 0.5)
                {
                    NPC.localAI[1] += 1f;
                }
                if (NPC.life < NPC.lifeMax * 0.25)
                {
                    NPC.localAI[1] += 1f;
                }
                if (NPC.life < NPC.lifeMax * 0.1)
                {
                    NPC.localAI[1] += 2f;
                }
                if (NPC.localAI[1] > 180f && Collision.CanHit(NPC.position, NPC.width, NPC.height, Main.player[NPC.target].position, Main.player[NPC.target].width, Main.player[NPC.target].height))
                {
                    NPC.localAI[1] = 0f;
                    var num513 = (NPC.type == ModContent.NPCType<Astigmatazer>()) ? 50 : 25;
                    num511 = (float)Math.Sqrt(num509 * num509 + num510 * num510);
                    num511 = 8.5f / num511;
                    num509 *= num511;
                    num510 *= num511;
                    vector48.X += num509 * 15f;
                    vector48.Y += num510 * 15f;
                    Projectile.NewProjectile(vector48.X, vector48.Y, num509, num510, ProjectileID.DeathLaser, num513, 0f, Main.myPlayer, 0f, 0f);
                    return;
                }
                return;
            }
            else
            {
                var num515 = 1;
                if (NPC.position.X + NPC.width / 2 < Main.player[NPC.target].position.X + Main.player[NPC.target].width)
                {
                    num515 = -1;
                }
                var vector49 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
                var num518 = Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 + num515 * 340 - vector49.X;
                var num519 = Main.player[NPC.target].position.Y + Main.player[NPC.target].height / 2 - vector49.Y;
                var num520 = (float)Math.Sqrt(num518 * num518 + num519 * num519);
                num520 = 8f / num520;
                num518 *= num520;
                num519 *= num520;
                if (NPC.velocity.X < num518)
                {
                    NPC.velocity.X = NPC.velocity.X + 0.2f;
                    if (NPC.velocity.X < 0f && num518 > 0f)
                    {
                        NPC.velocity.X = NPC.velocity.X + 0.2f;
                    }
                }
                else if (NPC.velocity.X > num518)
                {
                    NPC.velocity.X = NPC.velocity.X - 0.2f;
                    if (NPC.velocity.X > 0f && num518 < 0f)
                    {
                        NPC.velocity.X = NPC.velocity.X - 0.2f;
                    }
                }
                if (NPC.velocity.Y < num519)
                {
                    NPC.velocity.Y = NPC.velocity.Y + 0.2f;
                    if (NPC.velocity.Y < 0f && num519 > 0f)
                    {
                        NPC.velocity.Y = NPC.velocity.Y + 0.2f;
                    }
                }
                else if (NPC.velocity.Y > num519)
                {
                    NPC.velocity.Y = NPC.velocity.Y - 0.2f;
                    if (NPC.velocity.Y > 0f && num519 < 0f)
                    {
                        NPC.velocity.Y = NPC.velocity.Y - 0.2f;
                    }
                }
                vector49 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
                num518 = Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 - vector49.X;
                num519 = Main.player[NPC.target].position.Y + Main.player[NPC.target].height / 2 - vector49.Y;
                NPC.rotation = (float)Math.Atan2(num519, num518) - 1.57f;
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    NPC.localAI[1] += 1f;
                    if (NPC.life < NPC.lifeMax * 0.75)
                    {
                        NPC.localAI[1] += 1f;
                    }
                    if (NPC.life < NPC.lifeMax * 0.5)
                    {
                        NPC.localAI[1] += 1f;
                    }
                    if (NPC.life < NPC.lifeMax * 0.25)
                    {
                        NPC.localAI[1] += 1f;
                    }
                    if (NPC.life < NPC.lifeMax * 0.1)
                    {
                        NPC.localAI[1] += 2f;
                    }
                    if (NPC.localAI[1] > 60f && Collision.CanHit(NPC.position, NPC.width, NPC.height, Main.player[NPC.target].position, Main.player[NPC.target].width, Main.player[NPC.target].height))
                    {
                        NPC.localAI[1] = 0f;
                        var num521 = 9f;
                        var num522 = 18;
                        var num523 = 100;
                        num520 = (float)Math.Sqrt(num518 * num518 + num519 * num519);
                        num520 = num521 / num520;
                        num518 *= num520;
                        num519 *= num520;
                        vector49.X += num518 * 15f;
                        vector49.Y += num519 * 15f;
                        Projectile.NewProjectile(vector49.X, vector49.Y, num518, num519, num523, num522, 0f, Main.myPlayer, 0f, 0f);
                    }
                }
                NPC.ai[2] += 1f;
                if (NPC.ai[2] >= 180f)
                {
                    NPC.ai[1] = 0f;
                    NPC.ai[2] = 0f;
                    NPC.ai[3] = 0f;
                    NPC.TargetClosest(true);
                    NPC.netUpdate = true;
                    return;
                }
                return;
            }
        }
    }

    public override void FindFrame(int frameHeight)
    {
        NPC.frameCounter += 1.0;
        if (NPC.frameCounter < 7.0)
        {
            NPC.frame.Y = 0;
        }
        else if (NPC.frameCounter < 14.0)
        {
            NPC.frame.Y = frameHeight;
        }
        else if (NPC.frameCounter < 21.0)
        {
            NPC.frame.Y = frameHeight * 2;
        }
        else
        {
            NPC.frameCounter = 0.0;
            NPC.frame.Y = 0;
        }
        if (NPC.ai[0] > 1f)
        {
            NPC.frame.Y = NPC.frame.Y + frameHeight * 3;
        }
    }
}