using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.NPCs;

public class AncientOblivionLaser : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Ancient Oblivion Laser");
        Main.npcFrameCount[NPC.type] = 1;
    }

    public override void SetDefaults()
    {
        NPC.damage = 60;
        NPC.noTileCollide = true;
        NPC.lifeMax = 45000;
        NPC.defense = 20;
        NPC.noGravity = true;
        NPC.width = 52;
        NPC.aiStyle = -1;
        NPC.npcSlots = 1f;
        NPC.value = 0f;
        NPC.timeLeft = 750;
        NPC.height = 52;
        NPC.knockBackResist = 0f;
        NPC.HitSound = SoundID.NPCHit4;
        NPC.DeathSound = SoundID.NPCDeath14;
        NPC.buffImmune[BuffID.Frostburn] = true;
        NPC.buffImmune[BuffID.Poisoned] = true;
        NPC.buffImmune[BuffID.OnFire] = true;
        NPC.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().noOneHitKill = true;
    }

    public override void NPCLoot()
    {
        Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ItemID.Heart, Main.rand.Next(3, 6), false, 0, false);
        if (Main.expertMode) Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ItemID.Heart, Main.rand.Next(5, 8), false, 0, false);
    }
    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.35f * bossLifeScale);
        NPC.damage = (int)(NPC.damage * 0.3f);
    }
    public override void AI()
    {
        NPC.spriteDirection = -(int)NPC.ai[0];
        if (!Main.npc[(int)NPC.ai[1]].active || !(Main.npc[(int)NPC.ai[1]].type == ModContent.NPCType<AncientOblivionHead1>() || Main.npc[(int)NPC.ai[1]].type == ModContent.NPCType<AncientOblivionHead2>()))
        {
            NPC.ai[2] += 10f;
            if (NPC.ai[2] > 50f || Main.netMode != NetmodeID.Server)
            {
                NPC.life = -1;
                NPC.HitEffect(0, 10.0);
                NPC.active = false;
            }
        }
        if (NPC.ai[2] == 0f || NPC.ai[2] == 3f)
        {
            if (Main.npc[(int)NPC.ai[1]].ai[1] == 3f && NPC.timeLeft > 10)
            {
                NPC.timeLeft = 10;
            }
            if (Main.npc[(int)NPC.ai[1]].ai[1] != 0f)
            {
                NPC.localAI[0] += 3f;
                if (NPC.position.Y > Main.npc[(int)NPC.ai[1]].position.Y - 100f)
                {
                    if (NPC.velocity.Y > 0f)
                    {
                        NPC.velocity.Y = NPC.velocity.Y * 0.96f;
                    }
                    NPC.velocity.Y = NPC.velocity.Y - 0.07f;
                    if (NPC.velocity.Y > 6f)
                    {
                        NPC.velocity.Y = 6f;
                    }
                }
                else if (NPC.position.Y < Main.npc[(int)NPC.ai[1]].position.Y - 100f)
                {
                    if (NPC.velocity.Y < 0f)
                    {
                        NPC.velocity.Y = NPC.velocity.Y * 0.96f;
                    }
                    NPC.velocity.Y = NPC.velocity.Y + 0.07f;
                    if (NPC.velocity.Y < -6f)
                    {
                        NPC.velocity.Y = -6f;
                    }
                }
                if (NPC.position.X + NPC.width / 2 > Main.npc[(int)NPC.ai[1]].position.X + Main.npc[(int)NPC.ai[1]].width / 2 - 120f * NPC.ai[0])
                {
                    if (NPC.velocity.X > 0f)
                    {
                        NPC.velocity.X = NPC.velocity.X * 0.96f;
                    }
                    NPC.velocity.X = NPC.velocity.X - 0.1f;
                    if (NPC.velocity.X > 8f)
                    {
                        NPC.velocity.X = 8f;
                    }
                }
                if (NPC.position.X + NPC.width / 2 < Main.npc[(int)NPC.ai[1]].position.X + Main.npc[(int)NPC.ai[1]].width / 2 - 120f * NPC.ai[0])
                {
                    if (NPC.velocity.X < 0f)
                    {
                        NPC.velocity.X = NPC.velocity.X * 0.96f;
                    }
                    NPC.velocity.X = NPC.velocity.X + 0.1f;
                    if (NPC.velocity.X < -8f)
                    {
                        NPC.velocity.X = -8f;
                    }
                }
            }
            else
            {
                NPC.ai[3] += 1f;
                if (NPC.ai[3] >= 800f)
                {
                    NPC.ai[2] += 1f;
                    NPC.ai[3] = 0f;
                    NPC.netUpdate = true;
                }
                if (NPC.position.Y > Main.npc[(int)NPC.ai[1]].position.Y - 100f)
                {
                    if (NPC.velocity.Y > 0f)
                    {
                        NPC.velocity.Y = NPC.velocity.Y * 0.96f;
                    }
                    NPC.velocity.Y = NPC.velocity.Y - 0.1f;
                    if (NPC.velocity.Y > 3f)
                    {
                        NPC.velocity.Y = 3f;
                    }
                }
                else if (NPC.position.Y < Main.npc[(int)NPC.ai[1]].position.Y - 100f)
                {
                    if (NPC.velocity.Y < 0f)
                    {
                        NPC.velocity.Y = NPC.velocity.Y * 0.96f;
                    }
                    NPC.velocity.Y = NPC.velocity.Y + 0.1f;
                    if (NPC.velocity.Y < -3f)
                    {
                        NPC.velocity.Y = -3f;
                    }
                }
                if (NPC.position.X + NPC.width / 2 > Main.npc[(int)NPC.ai[1]].position.X + Main.npc[(int)NPC.ai[1]].width / 2 - 180f * NPC.ai[0])
                {
                    if (NPC.velocity.X > 0f)
                    {
                        NPC.velocity.X = NPC.velocity.X * 0.96f;
                    }
                    NPC.velocity.X = NPC.velocity.X - 0.14f;
                    if (NPC.velocity.X > 8f)
                    {
                        NPC.velocity.X = 8f;
                    }
                }
                if (NPC.position.X + NPC.width / 2 < Main.npc[(int)NPC.ai[1]].position.X + Main.npc[(int)NPC.ai[1]].width / 2 - 180f * NPC.ai[0])
                {
                    if (NPC.velocity.X < 0f)
                    {
                        NPC.velocity.X = NPC.velocity.X * 0.96f;
                    }
                    NPC.velocity.X = NPC.velocity.X + 0.14f;
                    if (NPC.velocity.X < -8f)
                    {
                        NPC.velocity.X = -8f;
                    }
                }
            }
            NPC.localAI[0] += 1f;
            if (NPC.localAI[0] >= 180f)
            {
                var num627 = 12f;
                var vector71 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height / 2);
                var num628 = 100;
                int num629 = ProjectileID.DeathLaser;
                SoundEngine.PlaySound(SoundID.Item, (int)NPC.position.X, (int)NPC.position.Y, 33);
                var num630 = (float)Math.Atan2(vector71.Y - (Main.player[NPC.target].position.Y + Main.player[NPC.target].height * 0.5f), vector71.X - (Main.player[NPC.target].position.X + Main.player[NPC.target].width * 0.5f));
                for (var num631 = 0f; num631 <= 4f; num631 += 0.4f)
                {
                    var num632 = Projectile.NewProjectile(vector71.X, vector71.Y, (float)(Math.Cos(num630 + num631) * num627 * -1.0), (float)(Math.Sin(num630 + num631) * num627 * -1.0), num629, num628, 0f, 0, 0f, 0f);
                    Main.projectile[num632].timeLeft = 600;
                    Main.projectile[num632].tileCollide = false;
                    if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.FromLiteral(""), num632, 0f, 0f, 0f, 0);
                    }
                    num632 = Projectile.NewProjectile(vector71.X, vector71.Y, (float)(Math.Cos(num630 - num631) * num627 * -1.0), (float)(Math.Sin(num630 - num631) * num627 * -1.0), num629, num628, 0f, 0, 0f, 0f);
                    Main.projectile[num632].timeLeft = 600;
                    Main.projectile[num632].tileCollide = false;
                    if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.FromLiteral(""), num632, 0f, 0f, 0f, 0);
                    }
                }
                NPC.localAI[0] = 0f;
                return;
            }
            return;
        }
        else
        {
            if (NPC.ai[2] != 1f)
            {
                return;
            }
            NPC.ai[3] += 1f;
            if (NPC.ai[3] >= 200f)
            {
                NPC.localAI[0] = 0f;
                NPC.ai[2] = 0f;
                NPC.ai[3] = 0f;
                NPC.netUpdate = true;
            }
            var vector72 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
            var num633 = Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 - 350f - vector72.X;
            var num634 = Main.player[NPC.target].position.Y + Main.player[NPC.target].height / 2 - 20f - vector72.Y;
            var num635 = (float)Math.Sqrt(num633 * num633 + num634 * num634);
            num635 = 7f / num635;
            num633 *= num635;
            num634 *= num635;
            if (NPC.velocity.X > num633)
            {
                if (NPC.velocity.X > 0f)
                {
                    NPC.velocity.X = NPC.velocity.X * 0.9f;
                }
                NPC.velocity.X = NPC.velocity.X - 0.1f;
            }
            if (NPC.velocity.X < num633)
            {
                if (NPC.velocity.X < 0f)
                {
                    NPC.velocity.X = NPC.velocity.X * 0.9f;
                }
                NPC.velocity.X = NPC.velocity.X + 0.1f;
            }
            if (NPC.velocity.Y > num634)
            {
                if (NPC.velocity.Y > 0f)
                {
                    NPC.velocity.Y = NPC.velocity.Y * 0.9f;
                }
                NPC.velocity.Y = NPC.velocity.Y - 0.03f;
            }
            if (NPC.velocity.Y < num634)
            {
                if (NPC.velocity.Y < 0f)
                {
                    NPC.velocity.Y = NPC.velocity.Y * 0.9f;
                }
                NPC.velocity.Y = NPC.velocity.Y + 0.03f;
            }
            NPC.localAI[0] += 1f;
            if (NPC.localAI[0] >= 100f)
            {
                var num639 = 12f;
                var vector73 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height / 2);
                var num640 = 50;
                int num641 = ProjectileID.DeathLaser;
                SoundEngine.PlaySound(SoundID.Item, (int)NPC.position.X, (int)NPC.position.Y, 33);
                var num642 = (float)Math.Atan2(vector73.Y - (Main.player[NPC.target].position.Y + Main.player[NPC.target].height * 0.5f), vector73.X - (Main.player[NPC.target].position.X + Main.player[NPC.target].width * 0.5f));
                for (var num643 = 0f; num643 <= 4f; num643 += 0.4f)
                {
                    var num644 = Projectile.NewProjectile(vector73.X, vector73.Y, (float)(Math.Cos(num642 + num643) * num639 * -1.0), (float)(Math.Sin(num642 + num643) * num639 * -1.0), num641, num640, 0f, 0, 0f, 0f);
                    Main.projectile[num644].timeLeft = 600;
                    Main.projectile[num644].tileCollide = false;
                    if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.FromLiteral(""), num644, 0f, 0f, 0f, 0);
                    }
                    num644 = Projectile.NewProjectile(vector73.X, vector73.Y, (float)(Math.Cos(num642 - num643) * num639 * -1.0), (float)(Math.Sin(num642 - num643) * num639 * -1.0), num641, num640, 0f, 0, 0f, 0f);
                    Main.projectile[num644].timeLeft = 600;
                    Main.projectile[num644].tileCollide = false;
                    if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.FromLiteral(""), num644, 0f, 0f, 0f, 0);
                    }
                }
                NPC.localAI[0] = 0f;
                return;
            }
            return;
        }
    }

    public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
    {
        var vector10 = new Vector2(NPC.position.X + NPC.width * 0.5f - 5f * NPC.ai[0], NPC.position.Y + 20f);
        for (var m = 0; m < 2; m++)
        {
            var num36 = Main.npc[(int)NPC.ai[1]].position.X + Main.npc[(int)NPC.ai[1]].width / 2 - vector10.X;
            var num37 = Main.npc[(int)NPC.ai[1]].position.Y + Main.npc[(int)NPC.ai[1]].height / 2 - vector10.Y;
            float num38;
            if (m == 0)
            {
                num36 -= 200f * NPC.ai[0];
                num37 += 130f;
                num38 = (float)Math.Sqrt(num36 * num36 + num37 * num37);
                num38 = 92f / num38;
                vector10.X += num36 * num38;
                vector10.Y += num37 * num38;
            }
            else
            {
                num36 -= 50f * NPC.ai[0];
                num37 += 80f;
                num38 = (float)Math.Sqrt(num36 * num36 + num37 * num37);
                num38 = 60f / num38;
                vector10.X += num36 * num38;
                vector10.Y += num37 * num38;
            }
            var rotation10 = (float)Math.Atan2(num37, num36) - 1.57f;
            var color10 = Lighting.GetColor((int)vector10.X / 16, (int)(vector10.Y / 16f));
            Main.spriteBatch.Draw(Main.boneArm2Texture, new Vector2(vector10.X - Main.screenPosition.X, vector10.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, Main.boneArmTexture.Width, Main.boneArmTexture.Height)), color10, rotation10, new Vector2(Main.boneArmTexture.Width * 0.5f, Main.boneArmTexture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
            if (m == 0)
            {
                vector10.X += num36 * num38 / 2f;
                vector10.Y += num37 * num38 / 2f;
            }
            else
            {
                vector10.X += num36 * num38 - 16f;
                vector10.Y += num37 * num38 - 6f;
                var num39 = Dust.NewDust(new Vector2(vector10.X, vector10.Y), 30, 10, DustID.Torch, num36 * 0.02f, num37 * 0.02f, 0, default(Color), 2.5f);
                Main.dust[num39].noGravity = true;
            }
        }
        return true;
    }
}