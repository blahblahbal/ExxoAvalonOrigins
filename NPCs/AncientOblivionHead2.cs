using System;
using ExxoAvalonOrigins.Items.Potions;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.NPCs;

public class AncientOblivionHead2 : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Ancient Oblivion");
        Main.npcFrameCount[NPC.type] = 3;
    }

    public override void SetDefaults()
    {
        NPC.damage = 120;
        NPC.boss = true;
        NPC.netAlways = true;
        NPC.noTileCollide = true;
        NPC.lifeMax = 100000;
        NPC.defense = 80;
        NPC.noGravity = true;
        NPC.width = 80;
        NPC.aiStyle = -1;
        NPC.npcSlots = 10f;
        NPC.value = 50000f;
        NPC.timeLeft = 22500;
        NPC.height = 102;
        NPC.knockBackResist = 0f;
        NPC.HitSound = SoundID.NPCHit4;
        NPC.DeathSound = SoundID.NPCDeath14;
    }
    public override void BossLoot(ref string name, ref int potionType)
    {
        potionType = ModContent.ItemType<ElixirofLife>();
    }
    public override void AI()
    {
        var instance = NPC.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>();
        NPC.damage = NPC.defDamage;
        NPC.defense = NPC.defDefense;
        Vector2 head1Pos = Main.npc[(int)NPC.ai[3]].position;
        if (NPC.ai[0] == 0f && Main.netMode != NetmodeID.MultiplayerClient)
        {
            NPC.TargetClosest(true);
            NPC.ai[0] = 1f;
            instance.astigSpawned = false;
            if (Vector2.Distance(head1Pos, NPC.position) < 160)
            {
                NPC.velocity = Vector2.Normalize(NPC.position - head1Pos) * 3f;
            }
        }
        if (Main.player[NPC.target].dead || Math.Abs(NPC.position.X - Main.player[NPC.target].position.X) > 6000f || Math.Abs(NPC.position.Y - Main.player[NPC.target].position.Y) > 6000f)
        {
            NPC.TargetClosest(true);
            if (Main.player[NPC.target].dead || Math.Abs(NPC.position.X - Main.player[NPC.target].position.X) > 6000f || Math.Abs(NPC.position.Y - Main.player[NPC.target].position.Y) > 6000f)
            {
                NPC.ai[1] = 3f;
            }
        }
        if (NPC.life < NPC.lifeMax / 2 && !instance.astigSpawned)
        {
            var num562 = NPC.NewNPC((int)NPC.position.X, (int)NPC.position.Y, ModContent.NPCType<Astigmatazer>(), 0);
            Main.npc[num562].target = NPC.target;
            if (Main.netMode != NetmodeID.SinglePlayer)
            {
                NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Astigmatazer has awoken!"), new Color(175, 75, 255));
            }
            else Main.NewText("Astigmatazer has awoken!", 175, 75, 255);
            NPC.SpawnOnPlayer(NPC.target, NPCID.TheDestroyer);
            instance.astigSpawned = true;
        }
        if (NPC.life < 40000)
        {
            NPC.localAI[0] += 1f;
            if (NPC.localAI[0] >= 500f)
            {
                var num563 = 12f;
                var vector54 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height / 2);
                var num564 = 60;
                int num565 = ProjectileID.BombSkeletronPrime;
                SoundEngine.PlaySound(SoundID.Item, (int)NPC.position.X, (int)NPC.position.Y, 33);
                var num566 = (float)Math.Atan2(vector54.Y - (Main.player[NPC.target].position.Y + Main.player[NPC.target].height * 0.5f), vector54.X - (Main.player[NPC.target].position.X + Main.player[NPC.target].width * 0.5f));
                for (var num567 = 0f; num567 <= 4f; num567 += 0.4f)
                {
                    var num568 = Projectile.NewProjectile(vector54.X, vector54.Y, (float)(Math.Cos(num566 + num567) * num563 * -1.0), (float)(Math.Sin(num566 + num567) * num563 * -1.0), num565, num564, 0f, 0, 0f, 0f);
                    Main.projectile[num568].timeLeft = 600;
                    Main.projectile[num568].tileCollide = false;
                    if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.FromLiteral(""), num568, 0f, 0f, 0f, 0);
                    }
                    num568 = Projectile.NewProjectile(vector54.X, vector54.Y, (float)(Math.Cos(num566 - num567) * num563 * -1.0), (float)(Math.Sin(num566 - num567) * num563 * -1.0), num565, num564, 0f, 0, 0f, 0f);
                    Main.projectile[num568].timeLeft = 600;
                    Main.projectile[num568].tileCollide = false;
                    if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.FromLiteral(""), num568, 0f, 0f, 0f, 0);
                    }
                }
                NPC.localAI[0] = 0f;
            }
        }
        if (NPC.ai[1] == 0f)
        {
            NPC.ai[2] += 1f;
            if (NPC.ai[2] >= 400f)
            {
                NPC.ai[2] = 0f;
                NPC.ai[1] = 1f;
                NPC.TargetClosest(true);
                NPC.netUpdate = true;
            }
            NPC.rotation = NPC.velocity.X / 15f;
            if (NPC.position.Y > Main.player[NPC.target].position.Y - 200f)
            {
                if (NPC.velocity.Y > 0f)
                {
                    NPC.velocity.Y = NPC.velocity.Y * 0.98f;
                }
                NPC.velocity.Y = NPC.velocity.Y - 0.1f;
                if (NPC.velocity.Y > 2f)
                {
                    NPC.velocity.Y = 2f;
                }
            }
            else if (NPC.position.Y < Main.player[NPC.target].position.Y - 500f)
            {
                if (NPC.velocity.Y < 0f)
                {
                    NPC.velocity.Y = NPC.velocity.Y * 0.98f;
                }
                NPC.velocity.Y = NPC.velocity.Y + 0.1f;
                if (NPC.velocity.Y < -2f)
                {
                    NPC.velocity.Y = -2f;
                }
            }
            if (NPC.position.X + NPC.width / 2 > Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 + 100f)
            {
                if (NPC.velocity.X > 0f)
                {
                    NPC.velocity.X = NPC.velocity.X * 0.98f;
                }
                NPC.velocity.X = NPC.velocity.X - 0.1f;
                if (NPC.velocity.X > 8f)
                {
                    NPC.velocity.X = 8f;
                }
            }
            if (NPC.position.X + NPC.width / 2 >= Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 - 100f)
            {
                return;
            }
            if (NPC.velocity.X < 0f)
            {
                NPC.velocity.X = NPC.velocity.X * 0.98f;
            }
            NPC.velocity.X = NPC.velocity.X + 0.1f;
            if (NPC.velocity.X < -8f)
            {
                NPC.velocity.X = -8f;
                return;
            }
            if (Vector2.Distance(head1Pos, NPC.position) < 160)
            {
                NPC.velocity = Vector2.Normalize(NPC.position - head1Pos) * 3f;
            }
            return;
        }
        else
        {
            if (NPC.ai[1] == 1f)
            {
                NPC.defense *= 2;
                NPC.damage *= 2;
                NPC.ai[2] += 1f;
                if (NPC.ai[2] == 2f)
                {
                    SoundEngine.PlaySound(SoundID.Roar, (int)NPC.position.X, (int)NPC.position.Y, 0);
                }
                if (NPC.ai[2] >= 400f)
                {
                    NPC.ai[2] = 0f;
                    NPC.ai[1] = 0f;
                }
                NPC.rotation += NPC.direction * 0.3f;
                var vector56 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
                var num575 = Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 - vector56.X;
                var num576 = Main.player[NPC.target].position.Y + Main.player[NPC.target].height / 2 - vector56.Y;
                var num577 = (float)Math.Sqrt(num575 * num575 + num576 * num576);
                num577 = 2f / num577;
                NPC.velocity.X = num575 * num577;
                NPC.velocity.Y = num576 * num577;
                return;
            }
            if (NPC.ai[1] == 2f)
            {
                NPC.damage = 1000;
                NPC.defense = 9999;
                NPC.rotation += NPC.direction * 0.3f;
                var vector57 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
                var num578 = Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 - vector57.X;
                var num579 = Main.player[NPC.target].position.Y + Main.player[NPC.target].height / 2 - vector57.Y;
                var num580 = (float)Math.Sqrt(num578 * num578 + num579 * num579);
                num580 = 8f / num580;
                NPC.velocity.X = num578 * num580;
                NPC.velocity.Y = num579 * num580;
                return;
            }
            if (NPC.ai[1] != 3f)
            {
                return;
            }
            NPC.velocity.Y = NPC.velocity.Y + 0.1f;
            if (NPC.velocity.Y < 0f)
            {
                NPC.velocity.Y = NPC.velocity.Y * 0.95f;
            }
            NPC.velocity.X = NPC.velocity.X * 0.95f;
            if (NPC.timeLeft > 500)
            {
                NPC.timeLeft = 500;
                return;
            }
            return;
        }
    }

    public override void FindFrame(int frameHeight)
    {
        if (NPC.ai[1] == 0f)
        {
            NPC.frameCounter += 1.0;
            if (NPC.frameCounter >= 12.0)
            {
                NPC.frameCounter = 0.0;
                NPC.frame.Y = NPC.frame.Y + frameHeight;
                if (NPC.frame.Y / frameHeight >= 2)
                {
                    NPC.frame.Y = 0;
                }
            }
        }
        else
        {
            NPC.frameCounter = 0.0;
            NPC.frame.Y = frameHeight * 2;
        }
    }

    public override void HitEffect(int hitDirection, double damage)
    {
        if (NPC.life <= 0)
        {
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("OblivionTop"), 1f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("OblivionMouth"), 1f);
        }
    }
}