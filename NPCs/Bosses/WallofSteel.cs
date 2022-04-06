using System;
using ExxoAvalonOrigins.Items.Material;
using ExxoAvalonOrigins.Items.Placeable.Trophy;
using ExxoAvalonOrigins.Items.Weapons.Magic;
using ExxoAvalonOrigins.Items.Weapons.Ranged;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent;
using Terraria.DataStructures;
using ReLogic.Content;

namespace ExxoAvalonOrigins.NPCs.Bosses;

[AutoloadBossHead]
public class WallofSteel : ModNPC
{
    private static Asset<Texture2D> wosTexture;
    private static Asset<Texture2D> mechaHungryChainTexture;

    public override void Load()
    {
        wosTexture = ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Sprites/WallofSteel");
        mechaHungryChainTexture = ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Sprites/MechaHungryChain");
    }

    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Wall of Steel");
        Main.npcFrameCount[NPC.type] = 1;
        NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData
        {
            SpecificallyImmuneTo = new int[]
            {
                BuffID.Confused,
		        BuffID.Poisoned,
                BuffID.OnFire,
                BuffID.CursedInferno,
                BuffID.Ichor,
                BuffID.Frostburn,
                BuffID.Venom,
                ModContent.BuffType<Buffs.Frozen>(),
	        }
        };
        NPCID.Sets.DebuffImmunitySets[Type] = debuffData;
    }

    public override void SetDefaults()
    {
        NPC.width = 200;
        NPC.height = 580;
        NPC.boss = NPC.noTileCollide = NPC.noGravity = NPC.behindTiles = true;
        NPC.npcSlots = 100f;
        NPC.damage = 150;
        NPC.lifeMax = 87000;
        NPC.timeLeft = 750000;
        NPC.defense = 55;
        NPC.aiStyle = -1;
        NPC.value = Item.buyPrice(0, 10);
        NPC.knockBackResist = 0;
        NPC.scale = 1.4f;
        NPC.HitSound = SoundID.NPCHit4;
        NPC.DeathSound = SoundID.NPCDeath14;
        Music = ExxoAvalonOrigins.Mod.MusicMod == null ? MusicID.Boss2 : MusicID.Boss2; // MusicLoader.GetMusicSlot(ExxoAvalonOrigins.Mod.MusicMod, "Sounds/Music/WallofSteel");
    }

    public override void BossLoot(ref string name, ref int potionType)
    {
        potionType = ItemID.SuperHealingPotion;
    }

    public override Color? GetAlpha(Color lightColor)
    {
        return Color.Lerp(Color.White, Lighting.GetColor((int)NPC.position.X, (int)NPC.position.Y), 0.5f);
    }

    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.85f * bossLifeScale);
        NPC.damage = (int)(NPC.damage * 0.65f);
    }

    public override bool PreDraw(SpriteBatch spriteBatch, Vector2 v, Color drawColor)
    {
        if (ExxoAvalonOriginsWorld.wos >= 0)
        {
            for (int i = 0; i < 255; i++)
            {
                if (Main.player[i].gross && Main.player[i].active && Main.player[i].tongued && !Main.player[i].dead)
                {
                    float num = Main.npc[ExxoAvalonOriginsWorld.wos].position.X + Main.npc[ExxoAvalonOriginsWorld.wos].width / 2;
                    float num2 = Main.npc[ExxoAvalonOriginsWorld.wos].position.Y + Main.npc[ExxoAvalonOriginsWorld.wos].height / 2;
                    var vector = new Vector2(Main.player[i].position.X + Main.player[i].width * 0.5f, Main.player[i].position.Y + Main.player[i].height * 0.5f);
                    float num3 = num - vector.X;
                    float num4 = num2 - vector.Y;
                    float rotation = (float)Math.Atan2(num4, num3) - 1.57f;
                    bool flag = true;
                    while (flag)
                    {
                        float num5 = (float)Math.Sqrt(num3 * num3 + num4 * num4);
                        if (num5 < 40f)
                        {
                            flag = false;
                        }
                        else
                        {
                            num5 = TextureAssets.Chain38.Value.Height / num5;
                            num3 *= num5;
                            num4 *= num5;
                            vector.X += num3;
                            vector.Y += num4;
                            num3 = num - vector.X;
                            num4 = num2 - vector.Y;
                            Color color = Lighting.GetColor((int)vector.X / 16, (int)(vector.Y / 16f));
                            spriteBatch.Draw(TextureAssets.Chain8.Value, new Vector2(vector.X - Main.screenPosition.X, vector.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, TextureAssets.Chain8.Value.Width, TextureAssets.Chain8.Value.Height)), color, rotation, new Vector2(TextureAssets.Chain8.Value.Width * 0.5f, TextureAssets.Chain8.Value.Height * 0.5f), 1f, SpriteEffects.None, 0f);
                        }
                    }
                }
            }
            for (int j = 0; j < 200; j++)
            {
                if (Main.npc[j].active && (Main.npc[j].type == ModContent.NPCType<NPCs.MechanicalHungry>() || Main.npc[j].type == ModContent.NPCType<NPCs.MechanicalHungry2>()))
                {
                    float num6 = Main.npc[ExxoAvalonOriginsWorld.wos].position.X + Main.npc[ExxoAvalonOriginsWorld.wos].width / 2;
                    float num7 = Main.npc[ExxoAvalonOriginsWorld.wos].position.Y;
                    float num8 = ExxoAvalonOriginsWorld.wosB - ExxoAvalonOriginsWorld.wosT;
                    bool flag2 = false;
                    if (Main.npc[j].frameCounter > 7.0)
                    {
                        flag2 = true;
                    }
                    num7 = ExxoAvalonOriginsWorld.wosT + num8 * Main.npc[j].ai[0];
                    var vector2 = new Vector2(Main.npc[j].position.X + Main.npc[j].width / 2, Main.npc[j].position.Y + Main.npc[j].height / 2);
                    float num9 = num6 - vector2.X;
                    float num10 = num7 - vector2.Y;
                    float rotation2 = (float)Math.Atan2(num10, num9) - 1.57f;
                    bool flag3 = true;
                    while (flag3)
                    {
                        SpriteEffects effects = SpriteEffects.None;
                        if (flag2)
                        {
                            effects = SpriteEffects.FlipHorizontally;
                            flag2 = false;
                        }
                        else
                        {
                            flag2 = true;
                        }
                        int height = 28;
                        float num11 = (float)Math.Sqrt(num9 * num9 + num10 * num10);
                        if (num11 < 40f)
                        {
                            height = (int)num11 - 40 + 28;
                            flag3 = false;
                        }
                        num11 = 28f / num11;
                        num9 *= num11;
                        num10 *= num11;
                        vector2.X += num9;
                        vector2.Y += num10;
                        num9 = num6 - vector2.X;
                        num10 = num7 - vector2.Y;
                        Color color2 = Lighting.GetColor((int)vector2.X / 16, (int)(vector2.Y / 16f));
                        Main.EntitySpriteDraw(mechaHungryChainTexture.Value, new Vector2(vector2.X - Main.screenPosition.X, vector2.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, mechaHungryChainTexture.Value.Width, height)), color2, rotation2, new Vector2(mechaHungryChainTexture.Value.Width * 0.5f, mechaHungryChainTexture.Value.Height * 0.5f), 1f, effects, 0);
                    }
                }
            }
            int heightOfPartToTile = 120;
            float num13 = ExxoAvalonOriginsWorld.wosT;
            float screenYPos = ExxoAvalonOriginsWorld.wosB;
            screenYPos = Main.screenPosition.Y + Main.screenHeight;
            float num15 = (int)((num13 - Main.screenPosition.Y) / heightOfPartToTile) + 1;
            num15 *= heightOfPartToTile;
            if (num15 > 0f)
            {
                num13 -= num15;
            }
            float num16 = num13;
            float wosPosX = Main.npc[ExxoAvalonOriginsWorld.wos].position.X + 20;
            float num18 = screenYPos - num13;
            bool flag4 = true;
            SpriteEffects effects2 = SpriteEffects.None;
            if (Main.npc[ExxoAvalonOriginsWorld.wos].spriteDirection == -1)
            {
                wosPosX += 160; // going to the left
            }
            if (Main.npc[ExxoAvalonOriginsWorld.wos].spriteDirection == 1)
            {
                effects2 = SpriteEffects.FlipHorizontally;
            }
            if (Main.npc[ExxoAvalonOriginsWorld.wos].direction > 0)
            {
                wosPosX -= 110f; // going to the right
            }
            int num19 = 0;
            if (!Main.gamePaused)
            {
                ExxoAvalonOriginsWorld.wosF++;
            }
            if (ExxoAvalonOriginsWorld.wosF > 12)
            {
                num19 = 240;
                if (ExxoAvalonOriginsWorld.wosF > 17)
                {
                    ExxoAvalonOriginsWorld.wosF = 0;
                }
            }
            else if (ExxoAvalonOriginsWorld.wosF > 6)
            {
                num19 = 120;
            }
            while (flag4)
            {
                num18 = screenYPos - num16;
                if (num18 > heightOfPartToTile)
                {
                    num18 = heightOfPartToTile;
                }
                bool flag5 = true;
                int num20 = 0;
                while (flag5)
                {
                    int x = (int)(wosPosX + wosTexture.Value.Width / 2) / 16;
                    int y = (int)(num16 + num20) / 16;
                    Main.spriteBatch.Draw(wosTexture.Value, new Vector2(wosPosX - Main.screenPosition.X, num16 + num20 - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, num19 + num20, wosTexture.Value.Width, 16)), Lighting.GetColor(x, y), 0f, default(Vector2), 1f, effects2, 0f);
                    num20 += 16;
                    if (num20 >= num18)
                    {
                        flag5 = false;
                    }
                }
                num16 += heightOfPartToTile;
                if (num16 >= screenYPos)
                {
                    flag4 = false;
                }
            }
        }
        return true;
    }

    public override void AI()
    {
        bool expert = Main.expertMode;
        if (NPC.position.X < 160f || NPC.position.X > (Main.maxTilesX - 10) * 16)
        {
            NPC.active = false;
        }
        if (NPC.localAI[0] == 0f)
        {
            NPC.localAI[0] = 1f;
            ExxoAvalonOriginsWorld.wosB = -1;
            ExxoAvalonOriginsWorld.wosT = -1;
        }
        NPC.localAI[3] += 1f;
        if (NPC.localAI[3] >= 600 + Main.rand.Next(1000))
        {
            NPC.localAI[3] = -Main.rand.Next(200);
            //Main.PlaySound(4, (int)npc.position.X, (int)npc.position.Y, 10);
        }
        ExxoAvalonOriginsWorld.wos = NPC.whoAmI;
        int tilePosX = (int)(NPC.position.X / 16f);
        int tilePosXwidth = (int)((NPC.position.X + NPC.width) / 16f);
        int tilePosYCenter = (int)((NPC.position.Y + NPC.height / 2) / 16f);
        int num447 = tilePosYCenter + 7;
        num447 += 4;
        if (ExxoAvalonOriginsWorld.wosB == -1)
        {
            ExxoAvalonOriginsWorld.wosB = num447 * 16;
        }
        else if (ExxoAvalonOriginsWorld.wosB > num447 * 16)
        {
            ExxoAvalonOriginsWorld.wosB--;
            if (ExxoAvalonOriginsWorld.wosB < num447 * 16)
            {
                ExxoAvalonOriginsWorld.wosB = num447 * 16;
            }
        }
        else if (ExxoAvalonOriginsWorld.wosB < num447 * 16)
        {
            ExxoAvalonOriginsWorld.wosB++;
            if (ExxoAvalonOriginsWorld.wosB > num447 * 16)
            {
                ExxoAvalonOriginsWorld.wosB = num447 * 16;
            }
        }
        num447 = tilePosYCenter - 7;
        num447 -= 4;
        if (ExxoAvalonOriginsWorld.wosT == -1)
        {
            ExxoAvalonOriginsWorld.wosT = num447 * 16;
        }
        else if (ExxoAvalonOriginsWorld.wosT > num447 * 16)
        {
            ExxoAvalonOriginsWorld.wosT--;
            if (ExxoAvalonOriginsWorld.wosT < num447 * 16)
            {
                ExxoAvalonOriginsWorld.wosT = num447 * 16;
            }
        }
        else if (ExxoAvalonOriginsWorld.wosT < num447 * 16)
        {
            ExxoAvalonOriginsWorld.wosT++;
            if (ExxoAvalonOriginsWorld.wosT > num447 * 16)
            {
                ExxoAvalonOriginsWorld.wosT = num447 * 16;
            }
        }
        float num450 = (ExxoAvalonOriginsWorld.wosB + ExxoAvalonOriginsWorld.wosT) / 2 - NPC.height / 2;
        if (NPC.Center.Y > Main.player[NPC.target].Center.Y)
        {
            if (NPC.velocity.Y > 0)
            {
                NPC.velocity.Y *= 0.98f;
            }
            NPC.velocity.Y -= 0.02f;
            if (NPC.velocity.Y < -2.2f)
            {
                NPC.velocity.Y = -2.2f;
            }
        }
        if (NPC.Center.Y < Main.player[NPC.target].Center.Y)
        {
            if (NPC.velocity.Y < 0)
            {
                NPC.velocity.Y *= 0.98f;
            }
            NPC.velocity.Y += 0.02f;
            if (NPC.velocity.Y > 2.2f)
            {
                NPC.velocity.Y = 2.2f;
            }
        }
        //npc.velocity.Y = 0f;
        //npc.position.Y = num450;
        if (NPC.position.Y / 16 < Main.maxTilesY - 200)
        {
            NPC.position.Y = (Main.maxTilesY - 200) * 16;
        }

            float num451 = 2.5f;
            if (NPC.life < NPC.lifeMax * 0.75)
            {
                num451 += 0.25f;
            }
            if (NPC.life < NPC.lifeMax * 0.5)
            {
                num451 += 0.4f;
            }
            if (NPC.life < NPC.lifeMax * 0.25)
            {
                num451 += 0.5f;
            }
            if (NPC.life < NPC.lifeMax * 0.1)
            {
                num451 += 0.6f;
            }
            if (NPC.life < NPC.lifeMax * 0.66 && Main.expertMode)
            {
                num451 += 0.3f;
            }
            if (NPC.life < NPC.lifeMax * 0.33 && Main.expertMode)
            {
                num451 += 0.3f;
            }
            if (NPC.life < NPC.lifeMax * 0.05 && Main.expertMode)
            {
                num451 += 0.6f;
            }
            if (NPC.life < NPC.lifeMax * 0.035 && Main.expertMode)
            {
                num451 += 0.6f;
            }
            if (NPC.life < NPC.lifeMax * 0.025 && Main.expertMode)
            {
                num451 += 0.6f;
            }
            if (NPC.velocity.X == 0f)
            {
                NPC.TargetClosest(true);
                NPC.velocity.X = NPC.direction;
            }
            if (NPC.velocity.X < 0f)
            {
                NPC.velocity.X = -num451;
                NPC.direction = -1;
            }
            else
            {
                NPC.velocity.X = num451;
                NPC.direction = 1;
            }
            if (NPC.life > NPC.lifeMax / 3)
            {
                NPC.ai[1]++;
                if (NPC.ai[1] == 90)
                {
                    if (Main.netMode != NetmodeID.MultiplayerClient) // leeches
                    {
                        int num442 = NPC.NewNPC(NPC.GetSpawnSourceForNPCFromNPCAI(), (int)(NPC.position.X + NPC.width / 2), (int)(NPC.position.Y + NPC.height / 2 + 20f), ModContent.NPCType<MechanicalLeechHead>(), 1);
                        Main.npc[num442].velocity.X = NPC.direction * 8;
                    }
                }
                if (NPC.ai[1] > 90)
                {
                    int fire;
                    float f = 0f;
                    int dmg = Main.expertMode ? 75 : 60;
                    var laserPos = new Vector2((NPC.velocity.X < 0 ? NPC.position.X : NPC.position.X + NPC.width), ExxoAvalonOriginsWorld.wosT);
                    float rotation = (float)Math.Atan2(laserPos.Y - (Main.player[NPC.target].position.Y + (Main.player[NPC.target].height * 0.5f)), laserPos.X - (Main.player[NPC.target].position.X + (Main.player[NPC.target].width * 0.5f)));
                    SoundEngine.PlaySound(SoundID.Item, (int)NPC.position.X, ExxoAvalonOriginsWorld.wosT, 33);
                    while (f <= .1f)
                    {
                        fire = Projectile.NewProjectile(NPC.GetSpawnSource_ForProjectile(), laserPos.X, laserPos.Y, (float)((Math.Cos(rotation + f) * 12f) * -1), (float)((Math.Sin(rotation + f) * 12f) * -1), ProjectileID.CursedFlameHostile, dmg, 6f);
                        Main.projectile[fire].timeLeft = 600;
                        Main.projectile[fire].tileCollide = false;
                        if (Main.netMode != NetmodeID.SinglePlayer)
                        {
                            NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, fire);
                        }
                        fire = Projectile.NewProjectile(NPC.GetSpawnSource_ForProjectile(), laserPos.X, laserPos.Y, (float)((Math.Cos(rotation - f) * 12f) * -1), (float)((Math.Sin(rotation - f) * 12f) * -1), ProjectileID.CursedFlameHostile, dmg, 6f);
                        Main.projectile[fire].timeLeft = 600;
                        Main.projectile[fire].tileCollide = false;
                        if (Main.netMode != NetmodeID.SinglePlayer)
                        {
                            NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, fire);
                        }
                        f += .034f;
                    }
                    NPC.ai[1] = 0;
                }
                NPC.ai[2]++;
                if (NPC.ai[2] == 100)
                {
                    int laser = Projectile.NewProjectile(NPC.GetSpawnSource_ForProjectile(), NPC.velocity.X < 0 ? NPC.position.X : NPC.position.X + NPC.width, ExxoAvalonOriginsWorld.wosB, NPC.velocity.X, NPC.velocity.Y, ProjectileID.DeathLaser, Main.expertMode ? 70 : 55, 4f);
                    Main.projectile[laser].velocity = Vector2.Normalize(Main.player[NPC.target].Center - new Vector2(NPC.position.X, ExxoAvalonOriginsWorld.wosB)) * 5f;
                    Main.projectile[laser].hostile = true;
                    Main.projectile[laser].friendly = false;
                    Main.projectile[laser].tileCollide = false;
                    if (Main.netMode != NetmodeID.SinglePlayer)
                    {
                        NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, laser);
                    }

                    NPC.ai[2] = 0;
                }
                if (NPC.ai[2] == 90)
                {
                    int fire;
                    float f = 0f;
                    var laserPos = new Vector2((NPC.velocity.X < 0 ? NPC.position.X : NPC.position.X + NPC.width), ExxoAvalonOriginsWorld.wosT);
                    float rotation = (float)Math.Atan2(laserPos.Y - (Main.player[NPC.target].position.Y + (Main.player[NPC.target].height * 0.5f)), laserPos.X - (Main.player[NPC.target].position.X + (Main.player[NPC.target].width * 0.5f)));
                    SoundEngine.PlaySound(SoundID.Item, (int)NPC.position.X, ExxoAvalonOriginsWorld.wosT, 33);
                    //while (f <= .1f)
                    //{
                    fire = Projectile.NewProjectile(NPC.GetSpawnSource_ForProjectile(), laserPos.X, laserPos.Y, (float)((Math.Cos(rotation + f) * 12f) * -1), (float)((Math.Sin(rotation + f) * 12f) * -1), ProjectileID.CursedFlameFriendly, Main.expertMode ? 70 : 55, 6f);
                    Main.projectile[fire].timeLeft = 600;
                    if (Main.netMode != NetmodeID.SinglePlayer)
                    {
                        NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, fire);
                    }
                    fire = Projectile.NewProjectile(NPC.GetSpawnSource_ForProjectile(), laserPos.X, laserPos.Y, (float)((Math.Cos(rotation - f) * 12f) * -1), (float)((Math.Sin(rotation - f) * 12f) * -1), ProjectileID.CursedFlameFriendly, Main.expertMode ? 70 : 55, 6f);
                    Main.projectile[fire].timeLeft = 600;
                    if (Main.netMode != NetmodeID.SinglePlayer)
                    {
                        NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, fire);
                    }
                    f += .1f;
                    //}
                }
            }
            else
            {
                NPC.ai[3]++;
                if (NPC.ai[3] == 1)
                {
                    NPC.defense = 0;
                    SoundEngine.PlaySound(SoundLoader.GetLegacySoundSlot(Mod, "Sounds/Item/LaserCharge"), -1, -1);
                }
                if (NPC.ai[3] >= 60 && NPC.ai[3] <= 90)
                {
                    if (NPC.ai[3] == 60)
                    {
                        SoundEngine.PlaySound(SoundID.Item, (int)NPC.position.X, (int)NPC.Center.Y, 33);
                        NPC.ai[1] = (NPC.velocity.X < 0 ? NPC.position.X : NPC.position.X + NPC.width);
                        NPC.ai[2] = NPC.Center.Y;
                        NPC.localAI[1] = NPC.velocity.X;
                        NPC.localAI[2] = NPC.velocity.Y;
                    }
                    int t = ModContent.ProjectileType<Projectiles.WallofSteelLaser>(); // middle
                    if (NPC.ai[3] == 60) t = ModContent.ProjectileType<Projectiles.WallofSteelLaserStart>(); // start
                    if (NPC.ai[3] == 90) t = ModContent.ProjectileType<Projectiles.WallofSteelLaserEnd>(); // end
                    if (NPC.ai[3] % 3 == 0)
                    {
                        int wide = Projectile.NewProjectile(NPC.GetSpawnSource_ForProjectile(), NPC.ai[1], NPC.ai[2], NPC.localAI[1], NPC.localAI[2], t, 100, 4f);
                        if (NPC.velocity.X > 0)
                        {
                            Main.projectile[wide].velocity = Vector2.Normalize(new Vector2(NPC.ai[1], NPC.ai[2]) - new Vector2(NPC.ai[1] - 100, NPC.ai[2])) * 20f;
                        }
                        else if (NPC.velocity.X < 0)
                        {
                            Main.projectile[wide].velocity = Vector2.Normalize(new Vector2(NPC.ai[1] - 100, NPC.ai[2]) - new Vector2(NPC.ai[1], NPC.ai[2])) * 20f;
                        }

                        Main.projectile[wide].tileCollide = false;
                        if (Main.netMode != NetmodeID.SinglePlayer)
                        {
                            NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, wide);
                        }
                    }
                }
                if (NPC.ai[3] > 100 && NPC.ai[3] < 150)
                {
                    NPC.defense = 55;
                    int fire = Projectile.NewProjectile(NPC.GetSpawnSource_ForProjectile(), NPC.velocity.X < 0 ? NPC.position.X : NPC.position.X + NPC.width, ExxoAvalonOriginsWorld.wosT, NPC.velocity.X, NPC.velocity.Y, ProjectileID.EyeFire, 45, 4f);
                    Main.projectile[fire].velocity = Vector2.Normalize(Main.player[NPC.target].Center - new Vector2(NPC.position.X, ExxoAvalonOriginsWorld.wosT)) * 20f;
                    Main.projectile[fire].tileCollide = false;
                    if (Main.netMode != NetmodeID.SinglePlayer)
                    {
                        NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, fire);
                    }
                }
                if (NPC.ai[3] > 300)
                {
                    NPC.ai[3] = 0;
                }
            }
            NPC.spriteDirection = NPC.direction;
            if (NPC.localAI[0] == 1f && Main.netMode != NetmodeID.MultiplayerClient)
            {
                NPC.localAI[0] = 2f;
                for (int num456 = 0; num456 < 11; num456++)
                {
                    int hungry = NPC.NewNPC(NPC.GetSpawnSourceForNPCFromNPCAI(), (int)NPC.position.X, (int)num450, ModContent.NPCType<NPCs.MechanicalHungry>(), NPC.whoAmI);
                    Main.npc[hungry].ai[0] = num456 * 0.1f - 0.05f;
                }
                return;
            }
        }
    public override void HitEffect(int hitDirection, double damage)
    {
        Gore.NewGore(NPC.Center, NPC.velocity, Mod.Find<ModGore>("WallofSteelGore1").Type, NPC.scale);
        Gore.NewGore(NPC.Center, NPC.velocity, Mod.Find<ModGore>("WallofSteelGore2").Type, NPC.scale);
        Gore.NewGore(NPC.Center, NPC.velocity, Mod.Find<ModGore>("WallofSteelGore3").Type, NPC.scale);
        Gore.NewGore(NPC.Center, NPC.velocity, Mod.Find<ModGore>("WallofSteelGore3").Type, NPC.scale);
        Gore.NewGore(NPC.Center, NPC.velocity, Mod.Find<ModGore>("WallofSteelGore4").Type, NPC.scale);
        Gore.NewGore(NPC.Center, NPC.velocity, Mod.Find<ModGore>("WallofSteelGore5").Type, NPC.scale);
        Gore.NewGore(NPC.Center, NPC.velocity, Mod.Find<ModGore>("WallofSteelGore6").Type, NPC.scale);
        Gore.NewGore(NPC.Center, NPC.velocity, Mod.Find<ModGore>("WallofSteelGore6").Type, NPC.scale);
        Gore.NewGore(NPC.Center, NPC.velocity, Mod.Find<ModGore>("WallofSteelGore7").Type, NPC.scale);
        Gore.NewGore(NPC.Center, NPC.velocity, Mod.Find<ModGore>("WallofSteelGore8").Type, NPC.scale);
        Gore.NewGore(NPC.Center, NPC.velocity, Mod.Find<ModGore>("WallofSteelGore9").Type, NPC.scale);
        Gore.NewGore(NPC.Center, NPC.velocity, Mod.Find<ModGore>("WallofSteelGore10").Type, NPC.scale);
        Gore.NewGore(NPC.Center, NPC.velocity, Mod.Find<ModGore>("WallofSteelGore11").Type, NPC.scale);
        Gore.NewGore(NPC.Center, NPC.velocity, Mod.Find<ModGore>("WallofSteelGore12").Type, NPC.scale);
        Gore.NewGore(NPC.Center, NPC.velocity, Mod.Find<ModGore>("WallofSteelGore13").Type, NPC.scale);
        Gore.NewGore(NPC.Center, NPC.velocity, Mod.Find<ModGore>("WallofSteelGore14").Type, NPC.scale);
    }
    public override void OnKill()
    {
        ExxoAvalonOriginsWorld.wos = -1;
        if (!ModContent.GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode && Main.hardMode)
        {
            if (!Main.expertMode) NPC.DropItemInstanced(NPC.position, new Vector2(NPC.width, NPC.height), ModContent.ItemType<Items.Consumables.MechanicalHeart>());
            ModContent.GetInstance<ExxoAvalonOriginsWorld>().InitiateSuperHardmode();
        }
        if (Main.netMode != NetmodeID.MultiplayerClient)
        {
            int num22 = (int)(NPC.position.X + (NPC.width / 2)) / 16;
            int num23 = (int)(NPC.position.Y + (NPC.height / 2)) / 16;
            int num24 = NPC.width / 4 / 16 + 1;
            for (int k = num22 - num24; k <= num22 + num24; k++)
            {
                for (int l = num23 - num24; l <= num23 + num24; l++)
                {
                    if ((k == num22 - num24 || k == num22 + num24 || l == num23 - num24 || l == num23 + num24) && !Main.tile[k, l].HasTile)
                    {
                        Main.tile[k, l].TileType = (ushort)ModContent.TileType<Tiles.OblivionBrick>();
                    }
                    Main.tile[k, l].LiquidAmount = 0;
                    if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.SendTileSquare(-1, k, l, 1);
                    }
                    else
                    {
                        WorldGen.SquareTileFrame(k, l, true);
                    }
                }
            }
        }
    }
    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<Items.BossBags.WallofSteelBossBag>()));
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<WallofSteelTrophy>(), 10));
        if (!Main.expertMode)
        {
            npcLoot.Add(ItemDropRule.OneFromOptions(1, new int[] { ModContent.ItemType<FleshBoiler>(), ModContent.ItemType<MagicCleaver>(), ModContent.ItemType<Items.Accessories.BubbleBoost>() }));
        }
        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<SoulofBlight>(), 1, 40, 56));
        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<HellsteelPlate>(), 1, 20, 31));
    }
}
