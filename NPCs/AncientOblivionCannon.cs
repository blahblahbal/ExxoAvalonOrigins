using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs;

public class AncientOblivionCannon : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Ancient Oblivion Cannon");
        Main.npcFrameCount[NPC.type] = 1;
    }

    public override void SetDefaults()
    {
        NPC.damage = 80;
        NPC.noTileCollide = true;
        NPC.lifeMax = 60000;
        NPC.defense = 55;
        NPC.noGravity = true;
        NPC.width = 52;
        NPC.aiStyle = -1;
        NPC.npcSlots = 6f;
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
        if (NPC.ai[2] == 0f)
        {
            if (Main.npc[(int)NPC.ai[1]].ai[1] == 3f && NPC.timeLeft > 10)
            {
                NPC.timeLeft = 10;
            }
            if (Main.npc[(int)NPC.ai[1]].ai[1] != 0f)
            {
                NPC.localAI[0] += 2f;
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
                if (NPC.ai[3] >= 1100f)
                {
                    NPC.localAI[0] = 0f;
                    NPC.ai[2] = 1f;
                    NPC.ai[3] = 0f;
                    NPC.netUpdate = true;
                }
                if (NPC.position.Y > Main.npc[(int)NPC.ai[1]].position.Y - 150f)
                {
                    if (NPC.velocity.Y > 0f)
                    {
                        NPC.velocity.Y = NPC.velocity.Y * 0.96f;
                    }
                    NPC.velocity.Y = NPC.velocity.Y - 0.04f;
                    if (NPC.velocity.Y > 3f)
                    {
                        NPC.velocity.Y = 3f;
                    }
                }
                else if (NPC.position.Y < Main.npc[(int)NPC.ai[1]].position.Y - 150f)
                {
                    if (NPC.velocity.Y < 0f)
                    {
                        NPC.velocity.Y = NPC.velocity.Y * 0.96f;
                    }
                    NPC.velocity.Y = NPC.velocity.Y + 0.04f;
                    if (NPC.velocity.Y < -3f)
                    {
                        NPC.velocity.Y = -3f;
                    }
                }
                if (NPC.position.X + NPC.width / 2 > Main.npc[(int)NPC.ai[1]].position.X + Main.npc[(int)NPC.ai[1]].width / 2 + 200f)
                {
                    if (NPC.velocity.X > 0f)
                    {
                        NPC.velocity.X = NPC.velocity.X * 0.96f;
                    }
                    NPC.velocity.X = NPC.velocity.X - 0.2f;
                    if (NPC.velocity.X > 8f)
                    {
                        NPC.velocity.X = 8f;
                    }
                }
                if (NPC.position.X + NPC.width / 2 < Main.npc[(int)NPC.ai[1]].position.X + Main.npc[(int)NPC.ai[1]].width / 2 + 160f)
                {
                    if (NPC.velocity.X < 0f)
                    {
                        NPC.velocity.X = NPC.velocity.X * 0.96f;
                    }
                    NPC.velocity.X = NPC.velocity.X + 0.2f;
                    if (NPC.velocity.X < -8f)
                    {
                        NPC.velocity.X = -8f;
                    }
                }
            }
            var vector68 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
            var num609 = Main.npc[(int)NPC.ai[1]].position.X + Main.npc[(int)NPC.ai[1]].width / 2 - 200f * NPC.ai[0] - vector68.X;
            var num610 = Main.npc[(int)NPC.ai[1]].position.Y + 230f - vector68.Y;
            var num611 = (float)Math.Sqrt(num609 * num609 + num610 * num610);
            NPC.rotation = (float)Math.Atan2(num610, num609) + 1.57f;
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                return;
            }
            NPC.localAI[0] += 1f;
            if (NPC.localAI[0] > 340f)
            {
                NPC.localAI[0] = 0f;
                var num612 = 12f;
                var num613 = 0;
                int num614 = /*ModContent.ProjectileType<Projectiles.BombSkeleton>();*/ ProjectileID.BombSkeletronPrime;
                num611 = num612 / num611;
                num609 = -num609 * num611;
                num610 = -num610 * num611;
                num609 += Main.rand.Next(-40, 41) * 0.01f;
                num610 += Main.rand.Next(-40, 41) * 0.01f;
                vector68.X += num609 * 4f;
                vector68.Y += num610 * 4f;
                Projectile.NewProjectile(vector68.X, vector68.Y, num609, num610, num614, num613, 0f, Main.myPlayer, 0f, 0f);
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
            if (NPC.ai[3] >= 300f)
            {
                NPC.localAI[0] = 0f;
                NPC.ai[2] = 0f;
                NPC.ai[3] = 0f;
                NPC.netUpdate = true;
            }
            var vector69 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
            var num615 = Main.npc[(int)NPC.ai[1]].position.X + Main.npc[(int)NPC.ai[1]].width / 2 - vector69.X;
            var num616 = Main.npc[(int)NPC.ai[1]].position.Y - vector69.Y;
            num616 = Main.player[NPC.target].position.Y + Main.player[NPC.target].height / 2 - 80f - vector69.Y;
            var num617 = (float)Math.Sqrt(num615 * num615 + num616 * num616);
            num617 = 6f / num617;
            num615 *= num617;
            num616 *= num617;
            if (NPC.velocity.X > num615)
            {
                if (NPC.velocity.X > 0f)
                {
                    NPC.velocity.X = NPC.velocity.X * 0.9f;
                }
                NPC.velocity.X = NPC.velocity.X - 0.04f;
            }
            if (NPC.velocity.X < num615)
            {
                if (NPC.velocity.X < 0f)
                {
                    NPC.velocity.X = NPC.velocity.X * 0.9f;
                }
                NPC.velocity.X = NPC.velocity.X + 0.04f;
            }
            if (NPC.velocity.Y > num616)
            {
                if (NPC.velocity.Y > 0f)
                {
                    NPC.velocity.Y = NPC.velocity.Y * 0.9f;
                }
                NPC.velocity.Y = NPC.velocity.Y - 0.08f;
            }
            if (NPC.velocity.Y < num616)
            {
                if (NPC.velocity.Y < 0f)
                {
                    NPC.velocity.Y = NPC.velocity.Y * 0.9f;
                }
                NPC.velocity.Y = NPC.velocity.Y + 0.08f;
            }
            NPC.TargetClosest(true);
            vector69 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
            num615 = Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 - vector69.X;
            num616 = Main.player[NPC.target].position.Y + Main.player[NPC.target].height / 2 - vector69.Y;
            num617 = (float)Math.Sqrt(num615 * num615 + num616 * num616);
            NPC.rotation = (float)Math.Atan2(num616, num615) - 1.57f;
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                return;
            }
            NPC.localAI[0] += 1f;
            if (NPC.localAI[0] > 40f)
            {
                NPC.localAI[0] = 0f;
                var num618 = 10f;
                var num619 = 0;
                num617 = num618 / num617;
                num615 *= num617;
                num616 *= num617;
                num615 += Main.rand.Next(-40, 41) * 0.01f;
                num616 += Main.rand.Next(-40, 41) * 0.01f;
                vector69.X += num615 * 4f;
                vector69.Y += num616 * 4f;
                Projectile.NewProjectile(vector69.X, vector69.Y, num615, num616, ProjectileID.BombSkeletronPrime, num619, 0f, Main.myPlayer, 0f, 0f);
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