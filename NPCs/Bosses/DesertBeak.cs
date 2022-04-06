using System;
using ExxoAvalonOrigins.Items.Material;
using ExxoAvalonOrigins.Items.Placeable.Trophy;
using ExxoAvalonOrigins.Items.Vanity;
using ExxoAvalonOrigins.Items.Weapons.Magic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.GameContent.ItemDropRules;
using Terraria.DataStructures;

namespace ExxoAvalonOrigins.NPCs.Bosses;

[AutoloadBossHead]
public class DesertBeak : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Desert Beak");
        Main.npcFrameCount[NPC.type] = 3;
        NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData
        {
            SpecificallyImmuneTo = new int[]
            {
                ModContent.BuffType<Buffs.Frozen>()
            }
        };
        NPCID.Sets.DebuffImmunitySets[Type] = debuffData;
    }

    public override void SetDefaults()
    {
        NPC.damage = 40;
        NPC.boss = true;
        NPC.noTileCollide = true;
        NPC.lifeMax = 3500;
        NPC.defense = 18;
        NPC.noGravity = true;
        NPC.width = 130;
        NPC.aiStyle = -1;
        NPC.npcSlots = 100f;
        NPC.value = 50000f;
        NPC.timeLeft = 22500;
        NPC.height = 78;
        NPC.knockBackResist = 0f;
        NPC.HitSound = SoundID.NPCHit28;
        NPC.DeathSound = SoundID.NPCDeath31;
        Music = ExxoAvalonOrigins.Mod.MusicMod == null ? MusicID.Boss2 : MusicLoader.GetMusicSlot(ExxoAvalonOrigins.Mod.MusicMod, "Sounds/Music/DesertBeak");
    }
    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.57f * bossLifeScale);
        NPC.damage = (int)(NPC.damage * 0.55f);
    }
    public override void OnKill()
    {
        if (!ExxoAvalonOriginsWorld.downedDesertBeak)
            ExxoAvalonOriginsWorld.downedDesertBeak = true;
    }
    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ItemID.SandBlock, 1, 22, 55));
        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<DesertBeakMask>(), 7));
        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<DesertFeather>(), 1, 6, 10));
        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ExxoAvalonOriginsWorld.rhodiumOre.GetItemOre(), 1, 15, 26));
        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<TomeoftheDistantPast>(), 3));
        npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<Items.BossBags.DesertBeakBossBag>()));
    }

    public override void AI()
    {
        int stageFactor = 30;
        if (Main.expertMode) stageFactor = 15;
        NPC.ai[0]++;
        if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
        {
            NPC.TargetClosest(true);
        }
        if (Main.player[NPC.target].dead)
        {
            NPC.velocity.Y = NPC.velocity.Y - 0.04f;
            if (NPC.timeLeft > 10)
            {
                NPC.timeLeft = 10;
                return;
            }
        }
        if (NPC.ai[0] < stageFactor * 10)
        {
            Vector2 pVel = Main.player[NPC.target].velocity;
            Vector2 pPos = Main.player[NPC.target].position;
            if (NPC.position.X + NPC.width / 2 > Main.player[NPC.target].Center.X)
            {
                NPC.direction = -1;
                if (NPC.velocity.X > 0f)
                {
                    NPC.velocity.X *= 0.96f;
                }
                NPC.velocity.X -= 0.05f;
                if (NPC.velocity.X > 8f) NPC.velocity.X = 8f;
            }
            if (NPC.position.X + NPC.width / 2 < Main.player[NPC.target].Center.X)
            {
                NPC.direction = 1;
                if (NPC.velocity.X < 0f)
                {
                    NPC.velocity.X *= 0.96f;
                }
                NPC.velocity.X += 0.05f;
                if (NPC.velocity.X < -8f) NPC.velocity.X = -8f;
            }
            if (pPos.Y + 75 < NPC.position.Y)
            {
                NPC.dontTakeDamage = true;
                NPC.ai[1]++;
                if (NPC.ai[1] >= 60)
                {
                    float Speed = 8f;
                    SoundEngine.PlaySound(2, (int)NPC.position.X, (int)NPC.position.Y, 17);
                    float rotation = (float)Math.Atan2(NPC.Center.Y - (pPos.Y + (Main.player[NPC.target].height * 0.5f)), NPC.Center.X - (pPos.X + (Main.player[NPC.target].width * 0.5f)));
                    Projectile.NewProjectile(NPC.GetSpawnSource_ForProjectile(), NPC.Center.X, NPC.Center.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), 83, 40, 0f, 0);
                    NPC.ai[1] = 0;
                }
            }
            if (pPos.Y - 250 < NPC.position.Y)
            {
                if (NPC.velocity.Y > 0)
                {
                    NPC.velocity.Y *= 0.98f;
                }
                NPC.velocity.Y -= 0.02f;
                if (NPC.velocity.Y > 2.2f) NPC.velocity.Y = 2.2f;
            }
            if (pPos.Y - 250 > NPC.position.Y)
            {
                NPC.dontTakeDamage = false;
                if (NPC.velocity.Y < 0)
                {
                    NPC.velocity.Y *= 0.98f;
                }
                NPC.velocity.Y += 0.02f;
                if (NPC.velocity.Y < -2.2f) NPC.velocity.Y = -2.2f;
            }
        }
        else if (NPC.ai[0] >= stageFactor * 10 && NPC.ai[0] < stageFactor * 11)
        {
            NPC.dontTakeDamage = false;
            float num131 = 6f;
            Vector2 vector14 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
            float num132 = Main.player[NPC.target].position.X + (Main.player[NPC.target].width / 2) - vector14.X;
            float num133 = Main.player[NPC.target].position.Y + (Main.player[NPC.target].height / 2) - vector14.Y;
            float num134 = (float)Math.Sqrt(num132 * num132 + num133 * num133);
            num134 = num131 / num134;
            NPC.velocity.X = num132 * num134;
            NPC.velocity.Y = num133 * num134;
            if (Main.expertMode && NPC.ai[3] < 3)
            {
                NPC.ai[0] = stageFactor * 10;
                NPC.ai[3]++;
                return;
            }
        }
        else if (NPC.ai[0] >= stageFactor * 11 && NPC.ai[0] < stageFactor * 20)
        {
            NPC.dontTakeDamage = false;
            NPC.ai[3] = 0;
            Vector2 pVel = Main.player[NPC.target].velocity;
            Vector2 pPos = Main.player[NPC.target].position;
            if (NPC.position.X + NPC.width / 2 > Main.player[NPC.target].Center.X)
            {
                NPC.direction = -1;
                if (NPC.velocity.X > 0f)
                {
                    NPC.velocity.X *= 0.98f;
                }
                NPC.velocity.X -= 0.05f;
                if (NPC.velocity.X > 8f) NPC.velocity.X = 8f;
            }
            if (NPC.position.X + NPC.width / 2 < Main.player[NPC.target].Center.X)
            {
                NPC.direction = 1;
                if (NPC.velocity.X < 0f)
                {
                    NPC.velocity.X *= 0.98f;
                }
                NPC.velocity.X += 0.05f;
                if (NPC.velocity.X < -8f) NPC.velocity.X = -8f;
            }
            if (pPos.Y - 250 < NPC.position.Y)
            {
                if (NPC.velocity.Y > 0)
                {
                    NPC.velocity.Y *= 0.98f;
                }
                NPC.velocity.Y -= 0.02f;
                if (NPC.velocity.Y > 2.2f) NPC.velocity.Y = 2.2f;
            }
            if (pPos.Y - 250 > NPC.position.Y)
            {
                NPC.dontTakeDamage = false;
                if (NPC.velocity.Y < 0)
                {
                    NPC.velocity.Y *= 0.98f;
                }
                NPC.velocity.Y += 0.02f;
                if (NPC.velocity.Y < -2.2f) NPC.velocity.Y = -2.2f;
            }
            NPC.ai[2]++;
            if (NPC.ai[2] >= 90)
            {
                for (int i = 0; i < (Main.expertMode ? 4 : 1); i++)
                {
                    float Speed = 5f;
                    Vector2 npcPosRefined = new Vector2(NPC.position.X + (NPC.width * 0.5f), NPC.position.Y + (NPC.height / 2));
                    float rotation = (float)Math.Atan2(npcPosRefined.Y - (pPos.Y + (Main.player[NPC.target].height * 0.5f)), npcPosRefined.X - (pPos.X + (Main.player[NPC.target].width * 0.5f)));
                    float speedX = (float)((Math.Cos(rotation) * Speed) * -1);
                    float speedY = (float)((Math.Sin(rotation) * Speed) * -1);
                    float num78 = speedX + Main.rand.Next(-50, 51) * 0.05f;
                    float num79 = speedY + Main.rand.Next(-50, 51) * 0.05f;
                    SoundEngine.PlaySound(2, (int)NPC.position.X, (int)NPC.position.Y, 11);
                    int bomb = Projectile.NewProjectile(NPC.GetSpawnSource_ForProjectile(), npcPosRefined.X, npcPosRefined.Y, num78, num79, 102, 20, 0f, 0);
                }
                NPC.ai[2] = 0;
            }
        }
        else NPC.ai[0] = 0;
    }

    public override void FindFrame(int frameHeight)
    {
        {
            NPC.spriteDirection = NPC.direction;
            NPC.rotation = NPC.velocity.X * 0.1f;
            if (NPC.velocity.X == 0f && NPC.velocity.Y == 0f)
            {
                NPC.frame.Y = 0;
                NPC.frameCounter = 0.0;
            }
            else
            {
                NPC.frameCounter += 1.0;
                if (NPC.frameCounter < 4.0)
                {
                    NPC.frame.Y = frameHeight;
                }
                else
                {
                    NPC.frame.Y = frameHeight * 2;
                    if (NPC.frameCounter >= 7.0)
                    {
                        NPC.frameCounter = 0.0;
                    }
                }
            }
        }
    }

    public override void HitEffect(int hitDirection, double damage)
    {
        if (NPC.life <= 0)
        {
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("DesertBeakHead").Type, 0.9f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("DesertBeakWing").Type, 0.9f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("DesertBeakWing").Type, 0.9f);
        }
    }
}
