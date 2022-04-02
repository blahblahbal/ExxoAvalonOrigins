using System;
using ExxoAvalonOrigins.Items.Accessories;
using ExxoAvalonOrigins.Items.Material;
using ExxoAvalonOrigins.Items.Placeable.Trophy;
using ExxoAvalonOrigins.Items.Weapons.Magic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.GameContent.ItemDropRules;
using ExxoAvalonOrigins.Systems;

namespace ExxoAvalonOrigins.NPCs.Bosses;

[AutoloadBossHead]
public class Phantasm : ModNPC
{
    bool transitionDone;
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Phantasm");
        Main.npcFrameCount[NPC.type] = 4;
    }

    public override void SetDefaults()
    {
        NPC.width = NPC.height = 70;
        NPC.boss = NPC.noTileCollide = NPC.noGravity = true;
        NPC.npcSlots = 100f;
        NPC.damage = 95;
        NPC.lifeMax = 62700;
        NPC.defense = 60;
        NPC.aiStyle = -1;
        NPC.value = 100000f;
        NPC.knockBackResist = 0f;
        NPC.scale = 1.5f;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath39;
        Music = ExxoAvalonOrigins.Mod.MusicMod == null ? MusicID.Boss5 : MusicLoader.GetMusicSlot(ExxoAvalonOrigins.Mod.MusicMod, "Sounds/Music/Phantasm");

        transitionDone = false;
    }
    public override void BossLoot(ref string name, ref int potionType)
    {
        potionType = ItemID.SuperHealingPotion;
    }
    private static void TeleportPhantasm(Vector2 coords, bool sync = false, int whoAmI = 0)
    {
        Main.npc[whoAmI].position = coords;
        if (sync) NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, whoAmI);
    }
    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.65f * bossLifeScale);
        NPC.damage = (int)(NPC.damage * 0.75f);
    }
    public override Color? GetAlpha(Color lightColor)
    {
        return new Color(255, 255, 255, 255);
    }
    public override void AI()
    {
        NPC.rotation = NPC.velocity.X * 0.02f;
        Lighting.AddLight((int)((NPC.position.X + (float)(NPC.width / 2)) / 16f), (int)((NPC.position.Y + (float)(NPC.height / 2)) / 16f), 2f, 2f, 2f);
        NPC.TargetClosest(true);
        if (Main.player[NPC.target].dead) // || !Main.player[target].zoneHellcastle)
        {
            NPC.velocity.Y = NPC.velocity.Y - 0.04f;
            if (NPC.timeLeft > 10)
            {
                NPC.timeLeft = 10;
                return;
            }
        }
        if (NPC.life > NPC.lifeMax * 0.75)
        {
            if (Main.player[NPC.target].position.X < NPC.position.X)
            {
                if (NPC.velocity.X > -8) NPC.velocity.X -= 0.22f;
            }
            if (Main.player[NPC.target].position.X > NPC.position.X)
            {
                if (NPC.velocity.X < 8) NPC.velocity.X += 0.22f;
            }
            if (Main.player[NPC.target].position.Y < NPC.position.Y + 300)
            {
                if (NPC.velocity.Y < 0)
                {
                    if (NPC.velocity.Y > -4) NPC.velocity.Y -= 0.8f;
                }
                else NPC.velocity.Y -= 0.6f;
                if (NPC.velocity.Y < -4) NPC.velocity.Y = -4;
            }
            if (Main.player[NPC.target].position.Y > NPC.position.Y + 300)
            {
                if (NPC.velocity.Y > 0)
                {
                    if (NPC.velocity.Y < 4) NPC.velocity.Y += 0.8f;
                }
                else NPC.velocity.Y += 0.6f;
                if (NPC.velocity.Y > 4) NPC.velocity.Y = 4;
            }
            NPC.ai[1]++;
            // fire ghostflame orbs
            if (NPC.ai[1] >= 120)
            {
                float rotation = (float)Math.Atan2(NPC.Center.Y - Main.player[NPC.target].Center.Y, NPC.Center.X - Main.player[NPC.target].Center.X);
                float speed = Main.expertMode ? 18f : 12f;
                float f = 0;
                int p;
                while (f <= 0.3f)
                {
                    p = Projectile.NewProjectile(NPC.GetSpawnSource_ForProjectile(), NPC.Center.X, NPC.Center.Y, (float)((Math.Cos(rotation + f) * speed) * -1), (float)((Math.Sin(rotation + f) * 12f) * -1), ModContent.ProjectileType<Projectiles.Ghostflame>(), 60, 0f, NPC.target);
                    Main.projectile[p].timeLeft = 600;
                    Main.projectile[p].friendly = false;
                    Main.projectile[p].hostile = true;
                    Main.projectile[p].tileCollide = false;
                    if (Main.netMode != NetmodeID.SinglePlayer)
                    {
                        NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, p);
                    }
                    p = Projectile.NewProjectile(NPC.GetSpawnSource_ForProjectile(), NPC.Center.X, NPC.Center.Y, (float)((Math.Cos(rotation - f) * speed) * -1), (float)((Math.Sin(rotation - f) * 12f) * -1), ModContent.ProjectileType<Projectiles.Ghostflame>(), 60, 0f, NPC.target);
                    Main.projectile[p].timeLeft = 600;
                    Main.projectile[p].friendly = false;
                    Main.projectile[p].hostile = true;
                    Main.projectile[p].tileCollide = false;
                    if (Main.netMode != NetmodeID.SinglePlayer)
                    {
                        NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, p);
                    }
                    f += 0.1f;
                }
                NPC.ai[1] = 0;
            }
        }
        // ai phase 2; swooping attack and charging mah laser
        /*else if (npc.life <= npc.lifeMax * 0.75 && npc.life > npc.lifeMax * 0.75 - 500)
        {
            if (!transitionDone)
            {
                npc.dontTakeDamage = true;
                Vector2 libraryCenter = new Vector2(Main.maxTilesX / 3 + 183, Main.maxTilesY - 140 + 57) * 16;

                if (Vector2.Distance(libraryCenter, npc.Center) <= 5)
                {
                    npc.velocity = Vector2.Zero;
                    npc.Center = libraryCenter;
                    transitionDone = true;
                }
                else
                {
                    Vector2 heading = libraryCenter - npc.Center;
                    heading.Normalize();
                    heading *= new Vector2(1.5f, 1.5f).Length(); // multiply by speed
                    npc.velocity = heading;
                }
            }
            else
            {
                npc.dontTakeDamage = false;
                npc.velocity *= 0f;
                npc.ai[0]++;
                Vector2 tpPos = new Vector2(Main.maxTilesX / 3 + 183, Main.maxTilesY - 140 + 57) * 16;
                if (npc.ai[0] < 150 && npc.position != tpPos)
                {
                    npc.velocity = Vector2.Normalize(npc.position - tpPos) * 6f;
                }
                if (npc.ai[0] >= 150)
                {
                    npc.velocity *= 0f;
                    npc.ai[0] = 0;
                }
            }
            //Teleport(new Vector2(Main.maxTilesX / 3 + 168, Main.maxTilesY - 140 + 57) * 16, false, NPC.FindFirstNPC(npc.type));
            //npc.position = new Vector2(Main.maxTilesX / 3 + 168, Main.maxTilesY - 140 + 57) * 16;
        }*/
        else if (NPC.life <= NPC.lifeMax * 0.75 && NPC.life > NPC.lifeMax / 3)
        {
            if (!transitionDone)
            {
                NPC.dontTakeDamage = true;
                Vector2 libraryCenter = new Vector2(Main.maxTilesX / 3 + 184, Main.maxTilesY - 140 + 57) * 16;

                if (Vector2.Distance(libraryCenter, NPC.Center) <= 5)
                {
                    NPC.velocity = Vector2.Zero;
                    NPC.Center = libraryCenter;
                    transitionDone = true;
                }
                else
                {
                    NPC.life = (int)(NPC.lifeMax * 0.75f);
                    Vector2 heading = libraryCenter - NPC.Center;
                    heading.Normalize();
                    heading *= new Vector2(3f, 3f).Length(); // multiply by speed
                    NPC.velocity = heading;
                }
            }
            else
            {
                NPC.dontTakeDamage = false;
                NPC.ai[0]++;
                /*Vector2 tpPos = new Vector2(Main.maxTilesX / 3 + 183, Main.maxTilesY - 140 + 57) * 16;
                if (npc.ai[0] < 150 && npc.position != tpPos)
                {
                    npc.velocity = Vector2.Normalize(npc.position - tpPos) * 6f;
                }*/
                if (NPC.ai[0] >= 150)
                {
                    NPC.velocity *= 0f;
                    NPC.ai[0] = 0;
                }
                NPC.velocity *= 0f;
                if (NPC.ai[1] <= 3)
                {
                    // swooping attack
                    // after swooping attack, increment ai[1]
                    // using ai[2] to create the swooping attack
                    NPC.ai[2]++;
                    //npc.ai[0] = 1;
                    if (NPC.ai[2] <= 300)
                    {
                        Player T = Main.player[NPC.target];
                        if (NPC.ai[2] % 20 == 0)
                        {
                            float Speed = 9f;
                            int damage = 65;
                            SoundEngine.PlaySound(SoundID.Item, (int)NPC.position.X, (int)NPC.position.Y, 33, 0.8f);
                            /*Vector2 offset = new Vector2(npc.Center.X + Main.rand.Next(5) * npc.direction, npc.Center.Y + Main.rand.Next(5, 10));
                            float rotation = (float)Math.Atan2(npc.Center.Y, npc.Center.X);
                            int num54 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), ModContent.ProjectileType<Projectiles.Ghostflame>(), damage, 0f, 0);
                            Main.projectile[num54].velocity = Vector2.Normalize(T.position - npc.position) * 9f;*/
                            Projectile.NewProjectile(NPC.GetSpawnSource_ForProjectile(), NPC.Center, (T.Center - NPC.Center).SafeNormalize(-Vector2.UnitY) * Speed, ModContent.ProjectileType<Projectiles.Ghostflame>(), damage, 0f, Main.myPlayer);
                        }
                    }
                    if (NPC.ai[2] == 301)
                    {
                        #region 360 degree spread
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
                            var num1168 = Projectile.NewProjectile(NPC.GetSpawnSource_ForProjectile(), vector155.X, vector155.Y, (float)(Math.Cos(num1166 + num1167) * 16f * -1.0), (float)(Math.Sin(num1166 + num1167) * 16f * -1.0), ModContent.ProjectileType<Projectiles.Ghostflame>(), 70, 0f, NPC.target, 0f, 0f);
                            Main.projectile[num1168].timeLeft = 600;
                            Main.projectile[num1168].tileCollide = false;
                            if (Main.netMode != NetmodeID.SinglePlayer)
                            {
                                NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, num1168);
                            }
                            num1168 = Projectile.NewProjectile(NPC.GetSpawnSource_ForProjectile(), vector155.X, vector155.Y, (float)(Math.Cos(num1166 - num1167) * 16f * -1.0), (float)(Math.Sin(num1166 - num1167) * 16f * -1.0), ModContent.ProjectileType<Projectiles.Ghostflame>(), 70, 0f, NPC.target, 0f, 0f);
                            Main.projectile[num1168].timeLeft = 600;
                            Main.projectile[num1168].tileCollide = false;
                            if (Main.netMode != NetmodeID.SinglePlayer)
                            {
                                NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, num1168);
                            }
                        }
                        #endregion
                        NPC.ai[1]++;
                        NPC.ai[2] = 0;
                    }
                }
                if (NPC.ai[1] >= 4 && NPC.ai[1] < 305)
                {
                    NPC.ai[1]++;
                    //npc.velocity *= 0f;
                    //Teleport(new Vector2(Main.maxTilesX / 3 + 168, Main.maxTilesY - 140 + 57) * 16, false, npc.whoAmI);
                    #region sweeping laser attack
                    if (NPC.ai[1] % 60 == 0)
                    {
                        SoundEngine.PlaySound(SoundID.Item, (int)NPC.position.X, (int)NPC.position.Y, SoundLoader.GetSoundSlot(Mod, "Sounds/Item/LaserFire"));
                        // fire laser
                        Vector2 velocityOfProj = Main.player[NPC.target].Center - NPC.Center;
                        velocityOfProj.Normalize();
                        float num1275 = -1f;
                        if (velocityOfProj.X < 0f)
                        {
                            num1275 = 1f;
                        }
                        velocityOfProj = velocityOfProj.RotatedBy((double)((0f - num1275) * MathHelper.TwoPi / 6f));
                        int p = Projectile.NewProjectile(NPC.GetSpawnSource_ForProjectile(), NPC.Center.X, NPC.Center.Y + NPC.width / 3, velocityOfProj.X, velocityOfProj.Y, ModContent.ProjectileType<Projectiles.PhantasmLaser>(), 95, 0f, Main.myPlayer, num1275 * MathHelper.TwoPi / 720f, (float)NPC.whoAmI);
                        NPC.localAI[1] += 0.05f;
                        if (NPC.localAI[1] > 1f)
                        {
                            NPC.localAI[1] = 1f;
                        }
                        float num1277 = 1;
                        if (num1277 < 0f)
                        {
                            num1277 *= -1f;
                        }
                        num1277 += MathHelper.Pi * -3;
                        num1277 += MathHelper.TwoPi / 720f;
                        NPC.localAI[0] = num1277;
                    }
                    #endregion
                    if (NPC.ai[1] == 304)
                    {
                        NPC.ai[1] = 0;
                    }
                }
            }
        }
        // ai phase 3, fire spiral spread of ghostflame orbs
        else if (NPC.life <= NPC.lifeMax / 3 && transitionDone)
        {
            NPC.velocity *= 0f;
            //npc.position = new Vector2(Main.maxTilesX / 3 + 183, Main.maxTilesY - 140 + 57) * 16;
            //Teleport(new Vector2(Main.maxTilesX / 3 + 168, Main.maxTilesY - 140 + 57) * 16, false, NPC.FindFirstNPC(npc.type));
            NPC.ai[3]++;
            if (NPC.ai[3] >= 300)
            {
                NPC.dontTakeDamage = true;
                //Teleport(new Vector2(Main.maxTilesX / 3 + 168, Main.maxTilesY - 140 + 57) * 16, false, npc.whoAmI);
                NPC.ai[1]++;
                if (NPC.ai[1] >= 250) NPC.ai[1] = 250;
                NPC.ai[0]++;
                Vector2 offset = new Vector2(NPC.Center.X + 20, NPC.Center.Y + 20);
                Vector2 offset2 = new Vector2(NPC.Center.X - 20, NPC.Center.Y - 20);
                Vector2 offset3 = new Vector2(NPC.Center.X + 20, NPC.Center.Y - 20);
                Vector2 offset4 = new Vector2(NPC.Center.X - 20, NPC.Center.Y + 20);
                float rotation = (float)Math.Atan2(NPC.Center.Y - offset.Y, NPC.Center.X - offset.X);
                float rotation2 = (float)Math.Atan2(NPC.Center.Y - offset2.Y, NPC.Center.X - offset2.X);
                float rotation3 = (float)Math.Atan2(NPC.Center.Y - offset3.Y, NPC.Center.X - offset3.X);
                float rotation4 = (float)Math.Atan2(NPC.Center.Y - offset4.Y, NPC.Center.X - offset4.X);
                float speed = 8f;
                int p;
                if (NPC.ai[1] == 50 || NPC.ai[1] == 100 || NPC.ai[1] == 150 || NPC.ai[1] == 200)
                {
                    NPC.NewNPC(NPC.GetSpawnSourceForNPCFromNPCAI(), (int)NPC.position.X, (int)NPC.position.Y, ModContent.NPCType<PhantasmMinion>());
                }
                if (NPC.ai[0] % 10 == 0)
                {
                    float increment;
                    if (Main.expertMode) increment = 0.09f;
                    else increment = 0.18f;
                    if (NPC.ai[2] <= 7.2f)
                    {
                        p = Projectile.NewProjectile(NPC.GetSpawnSource_ForProjectile(), NPC.Center.X, NPC.Center.Y, (float)((Math.Cos(rotation - NPC.ai[2]) * speed) * -1), (float)((Math.Sin(rotation - NPC.ai[2]) * speed) * -1), ModContent.ProjectileType<Projectiles.Ghostflame>(), 60, 0f, NPC.target);
                        Main.projectile[p].timeLeft = 600;
                        Main.projectile[p].friendly = false;
                        Main.projectile[p].hostile = true;
                        Main.projectile[p].tileCollide = false;
                        if (Main.netMode != NetmodeID.SinglePlayer)
                        {
                            NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, p);
                        }
                        p = Projectile.NewProjectile(NPC.GetSpawnSource_ForProjectile(), NPC.Center.X, NPC.Center.Y, (float)((Math.Cos(rotation2 - NPC.ai[2]) * speed) * -1), (float)((Math.Sin(rotation2 - NPC.ai[2]) * speed) * -1), ModContent.ProjectileType<Projectiles.Ghostflame>(), 60, 0f, NPC.target);
                        Main.projectile[p].timeLeft = 600;
                        Main.projectile[p].friendly = false;
                        Main.projectile[p].hostile = true;
                        Main.projectile[p].tileCollide = false;
                        if (Main.netMode != NetmodeID.SinglePlayer)
                        {
                            NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, p);
                        }
                        p = Projectile.NewProjectile(NPC.GetSpawnSource_ForProjectile(), NPC.Center.X, NPC.Center.Y, (float)((Math.Cos(rotation3 - NPC.ai[2]) * speed) * -1), (float)((Math.Sin(rotation3 - NPC.ai[2]) * speed) * -1), ModContent.ProjectileType<Projectiles.Ghostflame>(), 60, 0f, NPC.target);
                        Main.projectile[p].timeLeft = 600;
                        Main.projectile[p].friendly = false;
                        Main.projectile[p].hostile = true;
                        Main.projectile[p].tileCollide = false;
                        if (Main.netMode != NetmodeID.SinglePlayer)
                        {
                            NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, p);
                        }
                        p = Projectile.NewProjectile(NPC.GetSpawnSource_ForProjectile(), NPC.Center.X, NPC.Center.Y, (float)((Math.Cos(rotation4 - NPC.ai[2]) * speed) * -1), (float)((Math.Sin(rotation4 - NPC.ai[2]) * speed) * -1), ModContent.ProjectileType<Projectiles.Ghostflame>(), 60, 0f, NPC.target);
                        Main.projectile[p].timeLeft = 600;
                        Main.projectile[p].friendly = false;
                        Main.projectile[p].hostile = true;
                        Main.projectile[p].tileCollide = false;
                        if (Main.netMode != NetmodeID.SinglePlayer)
                        {
                            NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, p);
                        }
                        if (NPC.ai[2] >= 7.2f)
                        {
                            NPC.ai[2] = 0;
                            NPC.ai[0] = 0;
                            NPC.ai[1] = 0;
                            //return;
                        }
                    }
                    NPC.ai[2] += increment;
                }
                if (NPC.ai[0] == 400 || NPC.ai[0] == 450 || NPC.ai[0] == 500 || NPC.ai[0] == 550)
                {
                    SoundEngine.PlaySound(SoundID.Item, (int)NPC.position.X, (int)NPC.position.Y, SoundLoader.GetSoundSlot(Mod, "Sounds/Item/LaserFire"), 0.8f);
                    Vector2 velocityOfProj = Main.player[NPC.target].Center - NPC.Center;
                    velocityOfProj.Normalize();
                    float num1275 = -1f;
                    if (velocityOfProj.X < 0f)
                    {
                        num1275 = 1f;
                    }
                    velocityOfProj = velocityOfProj.RotatedBy((0f - num1275) * MathHelper.TwoPi / 6f);
                    int p2 = Projectile.NewProjectile(NPC.GetSpawnSource_ForProjectile(), NPC.Center.X, NPC.Center.Y, velocityOfProj.X, velocityOfProj.Y, ModContent.ProjectileType<Projectiles.PhantasmLaser>(), 95, 0f, Main.myPlayer, num1275 * MathHelper.TwoPi / 720f, (float)NPC.whoAmI);
                    Main.projectile[p2].localAI[0] += 120;
                    NPC.localAI[1] += 0.05f;
                    if (NPC.localAI[1] > 1f)
                    {
                        NPC.localAI[1] = 1f;
                    }
                    float num1277 = 1;
                    if (num1277 < 0f)
                    {
                        num1277 *= -1f;
                    }
                    num1277 += MathHelper.Pi * -3;
                    num1277 += MathHelper.TwoPi / 720f;
                    NPC.localAI[0] = num1277;
                }

                if (NPC.ai[0] == 600)
                {
                    NPC.ai[0] = 0;
                    NPC.ai[2] = 0;
                    NPC.ai[1] = 0;
                    NPC.ai[3] = 0;
                    if (NPC.AnyNPCs(ModContent.NPCType<PhantasmMinion>())) { }
                    else NPC.dontTakeDamage = false;
                }
            }
        }
    }
    public override void OnKill()
    {
        if (!DownedBossSystem.downedPhantasm)
        {
            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                Main.NewText("The spirits are stirring in the depths!", new Color(50, 255, 130));
            }
            else if (Main.netMode == NetmodeID.Server)
            {
                ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("The spirits are stirring in the depths!"), new Color(50, 255, 130));
            }
            NPC.SetEventFlagCleared(ref DownedBossSystem.downedPhantasm, -1);
        }
    }
    public override void HitEffect(int hitDirection, double damage)
    {
        if (NPC.life <= 0)
        {
            for (int i = 0; i < 40; i++)
            {
                int num890 = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.DungeonSpirit, 0f, 0f, 0, default(Color), 1f);
                Main.dust[num890].velocity *= 5f;
                Main.dust[num890].scale = 1.5f;
                Main.dust[num890].noGravity = true;
                Main.dust[num890].fadeIn = 2f;
            }
            for (int i = 0; i < 20; i++)
            {
                int num893 = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.DungeonSpirit, 0f, 0f, 0, default(Color), 1f);
                Main.dust[num893].velocity *= 2f;
                Main.dust[num893].scale = 1.5f;
                Main.dust[num893].noGravity = true;
                Main.dust[num893].fadeIn = 3f;
            }
            for (int i = 0; i < 40; i++)
            {
                int num892 = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.SpectreStaff, 0f, 0f, 0, default(Color), 1f);
                Main.dust[num892].velocity *= 5f;
                Main.dust[num892].scale = 1.5f;
                Main.dust[num892].noGravity = true;
                Main.dust[num892].fadeIn = 2f;
            }
            for (int i = 0; i < 40; i++)
            {
                int num891 = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.DungeonSpirit, 0f, 0f, 0, default(Color), 1f);
                Main.dust[num891].velocity *= 10f;
                Main.dust[num891].scale = 1.5f;
                Main.dust[num891].noGravity = true;
                Main.dust[num891].fadeIn = 1.5f;
            }
        }
    }
    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        if (!Main.expertMode)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GhostintheMachine>(), 1, 3, 6));
            npcLoot.Add(ItemDropRule.OneFromOptions(1, new int[] { ModContent.ItemType<PhantomKnives>(), ModContent.ItemType<EtherealHeart>(), ModContent.ItemType<VampireTeeth>() }));
        }
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PhantasmTrophy>(), 10));
        npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<Items.BossBags.PhantasmBossBag>()));
    }
    public override void FindFrame(int frameHeight)
    {
        NPC.frameCounter++;
        if (NPC.frameCounter >= 4.0)
        {
            NPC.frame.Y = NPC.frame.Y + frameHeight;
            NPC.frameCounter = 0.0;
        }
        if (NPC.frame.Y >= frameHeight * Main.npcFrameCount[NPC.type])
        {
            NPC.frame.Y = 0;
        }
    }
}
