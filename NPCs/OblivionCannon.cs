using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;

namespace ExxoAvalonOrigins.NPCs
{
	public class OblivionCannon : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Oblivion Cannon");
			Main.npcFrameCount[npc.type] = 1;
		}

		public override void SetDefaults()
		{
			npc.damage = 80;
			npc.noTileCollide = true;
			npc.lifeMax = 60000;
			npc.defense = 55;
			npc.noGravity = true;
			npc.width = 52;
			npc.aiStyle = -1;
			npc.npcSlots = 6f;
			npc.value = 0f;
			npc.timeLeft = 750;
			npc.height = 52;
			npc.knockBackResist = 0f;
            npc.HitSound = SoundID.NPCHit4;
	        npc.DeathSound = SoundID.NPCDeath14;
			npc.buffImmune[BuffID.Frostburn] = true;
			npc.buffImmune[BuffID.Poisoned] = true;
			npc.buffImmune[BuffID.OnFire] = true;
		    npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().noOneHitKill = true;
		}

		public override void NPCLoot()
		{
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Heart, Main.rand.Next(3, 6), false, 0, false);
		}

        public override void AI()
        {
            npc.spriteDirection = -(int)npc.ai[0];
            if (!Main.npc[(int)npc.ai[1]].active || !(Main.npc[(int)npc.ai[1]].type == ModContent.NPCType<OblivionHead1>() || Main.npc[(int)npc.ai[1]].type == ModContent.NPCType<OblivionHead2>()))
            {
                npc.ai[2] += 10f;
                if (npc.ai[2] > 50f || Main.netMode != 2)
                {
                    npc.life = -1;
                    npc.HitEffect(0, 10.0);
                    npc.active = false;
                }
            }
            if (npc.ai[2] == 0f)
            {
                if (Main.npc[(int)npc.ai[1]].ai[1] == 3f && npc.timeLeft > 10)
                {
                    npc.timeLeft = 10;
                }
                if (Main.npc[(int)npc.ai[1]].ai[1] != 0f)
                {
                    npc.localAI[0] += 2f;
                    if (npc.position.Y > Main.npc[(int)npc.ai[1]].position.Y - 100f)
                    {
                        if (npc.velocity.Y > 0f)
                        {
                            npc.velocity.Y = npc.velocity.Y * 0.96f;
                        }
                        npc.velocity.Y = npc.velocity.Y - 0.07f;
                        if (npc.velocity.Y > 6f)
                        {
                            npc.velocity.Y = 6f;
                        }
                    }
                    else if (npc.position.Y < Main.npc[(int)npc.ai[1]].position.Y - 100f)
                    {
                        if (npc.velocity.Y < 0f)
                        {
                            npc.velocity.Y = npc.velocity.Y * 0.96f;
                        }
                        npc.velocity.Y = npc.velocity.Y + 0.07f;
                        if (npc.velocity.Y < -6f)
                        {
                            npc.velocity.Y = -6f;
                        }
                    }
                    if (npc.position.X + npc.width / 2 > Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 - 120f * npc.ai[0])
                    {
                        if (npc.velocity.X > 0f)
                        {
                            npc.velocity.X = npc.velocity.X * 0.96f;
                        }
                        npc.velocity.X = npc.velocity.X - 0.1f;
                        if (npc.velocity.X > 8f)
                        {
                            npc.velocity.X = 8f;
                        }
                    }
                    if (npc.position.X + npc.width / 2 < Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 - 120f * npc.ai[0])
                    {
                        if (npc.velocity.X < 0f)
                        {
                            npc.velocity.X = npc.velocity.X * 0.96f;
                        }
                        npc.velocity.X = npc.velocity.X + 0.1f;
                        if (npc.velocity.X < -8f)
                        {
                            npc.velocity.X = -8f;
                        }
                    }
                }
                else
                {
                    npc.ai[3] += 1f;
                    if (npc.ai[3] >= 1100f)
                    {
                        npc.localAI[0] = 0f;
                        npc.ai[2] = 1f;
                        npc.ai[3] = 0f;
                        npc.netUpdate = true;
                    }
                    if (npc.position.Y > Main.npc[(int)npc.ai[1]].position.Y - 150f)
                    {
                        if (npc.velocity.Y > 0f)
                        {
                            npc.velocity.Y = npc.velocity.Y * 0.96f;
                        }
                        npc.velocity.Y = npc.velocity.Y - 0.04f;
                        if (npc.velocity.Y > 3f)
                        {
                            npc.velocity.Y = 3f;
                        }
                    }
                    else if (npc.position.Y < Main.npc[(int)npc.ai[1]].position.Y - 150f)
                    {
                        if (npc.velocity.Y < 0f)
                        {
                            npc.velocity.Y = npc.velocity.Y * 0.96f;
                        }
                        npc.velocity.Y = npc.velocity.Y + 0.04f;
                        if (npc.velocity.Y < -3f)
                        {
                            npc.velocity.Y = -3f;
                        }
                    }
                    if (npc.position.X + npc.width / 2 > Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 + 200f)
                    {
                        if (npc.velocity.X > 0f)
                        {
                            npc.velocity.X = npc.velocity.X * 0.96f;
                        }
                        npc.velocity.X = npc.velocity.X - 0.2f;
                        if (npc.velocity.X > 8f)
                        {
                            npc.velocity.X = 8f;
                        }
                    }
                    if (npc.position.X + npc.width / 2 < Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 + 160f)
                    {
                        if (npc.velocity.X < 0f)
                        {
                            npc.velocity.X = npc.velocity.X * 0.96f;
                        }
                        npc.velocity.X = npc.velocity.X + 0.2f;
                        if (npc.velocity.X < -8f)
                        {
                            npc.velocity.X = -8f;
                        }
                    }
                }
                var vector68 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                var num609 = Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 - 200f * npc.ai[0] - vector68.X;
                var num610 = Main.npc[(int)npc.ai[1]].position.Y + 230f - vector68.Y;
                var num611 = (float)Math.Sqrt(num609 * num609 + num610 * num610);
                npc.rotation = (float)Math.Atan2(num610, num609) + 1.57f;
                if (Main.netMode == 1)
                {
                    return;
                }
                npc.localAI[0] += 1f;
                if (npc.localAI[0] > 340f)
                {
                    npc.localAI[0] = 0f;
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
                if (npc.ai[2] != 1f)
                {
                    return;
                }
                npc.ai[3] += 1f;
                if (npc.ai[3] >= 300f)
                {
                    npc.localAI[0] = 0f;
                    npc.ai[2] = 0f;
                    npc.ai[3] = 0f;
                    npc.netUpdate = true;
                }
                var vector69 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                var num615 = Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 - vector69.X;
                var num616 = Main.npc[(int)npc.ai[1]].position.Y - vector69.Y;
                num616 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - 80f - vector69.Y;
                var num617 = (float)Math.Sqrt(num615 * num615 + num616 * num616);
                num617 = 6f / num617;
                num615 *= num617;
                num616 *= num617;
                if (npc.velocity.X > num615)
                {
                    if (npc.velocity.X > 0f)
                    {
                        npc.velocity.X = npc.velocity.X * 0.9f;
                    }
                    npc.velocity.X = npc.velocity.X - 0.04f;
                }
                if (npc.velocity.X < num615)
                {
                    if (npc.velocity.X < 0f)
                    {
                        npc.velocity.X = npc.velocity.X * 0.9f;
                    }
                    npc.velocity.X = npc.velocity.X + 0.04f;
                }
                if (npc.velocity.Y > num616)
                {
                    if (npc.velocity.Y > 0f)
                    {
                        npc.velocity.Y = npc.velocity.Y * 0.9f;
                    }
                    npc.velocity.Y = npc.velocity.Y - 0.08f;
                }
                if (npc.velocity.Y < num616)
                {
                    if (npc.velocity.Y < 0f)
                    {
                        npc.velocity.Y = npc.velocity.Y * 0.9f;
                    }
                    npc.velocity.Y = npc.velocity.Y + 0.08f;
                }
                npc.TargetClosest(true);
                vector69 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                num615 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - vector69.X;
                num616 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - vector69.Y;
                num617 = (float)Math.Sqrt(num615 * num615 + num616 * num616);
                npc.rotation = (float)Math.Atan2(num616, num615) - 1.57f;
                if (Main.netMode == 1)
                {
                    return;
                }
                npc.localAI[0] += 1f;
                if (npc.localAI[0] > 40f)
                {
                    npc.localAI[0] = 0f;
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
            var vector10 = new Vector2(npc.position.X + npc.width * 0.5f - 5f * npc.ai[0], npc.position.Y + 20f);
            for (var m = 0; m < 2; m++)
            {
                var num36 = Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 - vector10.X;
                var num37 = Main.npc[(int)npc.ai[1]].position.Y + Main.npc[(int)npc.ai[1]].height / 2 - vector10.Y;
                float num38;
                if (m == 0)
                {
                    num36 -= 200f * npc.ai[0];
                    num37 += 130f;
                    num38 = (float)Math.Sqrt(num36 * num36 + num37 * num37);
                    num38 = 92f / num38;
                    vector10.X += num36 * num38;
                    vector10.Y += num37 * num38;
                }
                else
                {
                    num36 -= 50f * npc.ai[0];
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
                    var num39 = Dust.NewDust(new Vector2(vector10.X, vector10.Y), 30, 10, 6, num36 * 0.02f, num37 * 0.02f, 0, default(Color), 2.5f);
                    Main.dust[num39].noGravity = true;
                }
            }
            return true;
        }
    }
}