using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.NPCs
{
	public class Blight : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blight");
			Main.npcFrameCount[npc.type] = 3;
		}

		public override void SetDefaults()
		{
			npc.damage = 110;
			npc.boss = true;
			npc.scale = 1f;
			npc.noTileCollide = true;
			npc.lifeMax = 75000;
			npc.defense = 50;
			npc.noGravity = true;
			npc.width = 110;
			npc.aiStyle = -1;
			npc.npcSlots = 30f;
			npc.value = Item.buyPrice(1, 0, 0, 0);
			npc.timeLeft = 1000;
			npc.height = 104;
			npc.knockBackResist = 0f;
            npc.HitSound = SoundID.NPCHit1;
	        npc.DeathSound = SoundID.NPCDeath52;
			npc.buffImmune[BuffID.Confused] = true;
			npc.buffImmune[BuffID.Frostburn] = true;
			npc.buffImmune[BuffID.Ichor] = true;
			npc.buffImmune[BuffID.Poisoned] = true;
		}

        public override void AI()
        {
            if (npc.target == 255 || npc.target < 0 || Main.player[npc.target].dead)
            {
                npc.TargetClosest(true);
            }
            npc.ai[0] += 1f;
            npc.ai[1] = 0f;
            if (npc.ai[0] <= 600f)
            {
                if (npc.ai[1] == 0f)
                {
                    npc.TargetClosest(true);
                    npc.position.Y = Main.player[npc.target].position.Y;
                    npc.ai[1] = 1f;
                }
                if (npc.ai[1] == 1f)
                {
                    if (npc.position.X >= Main.player[npc.target].position.X - 200f)
                    {
                        npc.velocity.X = npc.velocity.X - 1f;
                        if (npc.velocity.X < -12f)
                        {
                            npc.velocity.X = -12f;
                        }
                        if (npc.position.X == Main.player[npc.target].position.X - 200f)
                        {
                            npc.spriteDirection = npc.direction;
                            Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
                            npc.ai[3] += 1f;
                            if (npc.ai[3] >= 240f)
                            {
                                npc.ai[1] = 0f;
                                npc.ai[3] = 0f;
                                return;
                            }
                        }
                    }
                    if (npc.position.X <= Main.player[npc.target].position.X + 200f)
                    {
                        npc.velocity.X = npc.velocity.X + 1f;
                        if (npc.velocity.X > 12f)
                        {
                            npc.velocity.X = 12f;
                        }
                        if (npc.position.X == Main.player[npc.target].position.X + 200f)
                        {
                            npc.spriteDirection = npc.direction;
                            Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
                            if (npc.ai[3] >= 240f)
                            {
                                npc.ai[1] = 0f;
                                npc.ai[3] = 0f;
                                return;
                            }
                        }
                    }
                }
            }
            else if (npc.ai[0] > 600f && npc.ai[0] <= 1200f)
            {
                if (npc.ai[3] == 0f)
                {
                    Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
                    var vector159 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                    var num1195 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - vector159.X;
                    var num1196 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - vector159.Y;
                    var num1197 = (float)Math.Sqrt(num1195 * num1195 + num1196 * num1196);
                    num1197 = 14f / num1197;
                    npc.velocity.X = num1195 * num1197;
                    npc.velocity.Y = num1196 * num1197;
                    npc.ai[3] = 1f;
                    return;
                }
                if (npc.ai[3] == 1f)
                {
                    npc.ai[2] += 1f;
                    if (npc.ai[2] >= 50f)
                    {
                        npc.velocity *= 0.98f;
                    }
                    if (npc.ai[2] >= 80f)
                    {
                        npc.position.Y = npc.position.Y - 500f;
                        npc.ai[2] = 0f;
                        npc.ai[3] = 0f;
                        return;
                    }
                }
            }
            else if (npc.ai[0] > 1200f && npc.ai[0] <= 1600f)
            {
                npc.ai[3] += 1f;
                if (npc.ai[3] >= 100f)
                {
                    var vector160 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height / 2);
                    Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 33);
                    var num1201 = (float)Math.Atan2(vector160.Y - (Main.player[npc.target].position.Y + Main.player[npc.target].height * 0.5f), vector160.X - (Main.player[npc.target].position.X + Main.player[npc.target].width * 0.5f));
                    for (var num1202 = 0f; num1202 <= 4f; num1202 += 0.2f)
                    {
                        var num1203 = Projectile.NewProjectile(vector160.X, vector160.Y, (float)(Math.Cos(num1201 + num1202) * 12f * -1.0), (float)(Math.Sin(num1201 + num1202) * 12f * -1.0), ProjectileID.DeathLaser, 100, 0f, 0, 0f, 0f);
                        Main.projectile[num1203].timeLeft = 800;
                        num1203 = Projectile.NewProjectile(vector160.X, vector160.Y, (float)(Math.Cos(num1201 - num1202) * 12f * -1.0), (float)(Math.Sin(num1201 - num1202) * 12f * -1.0), ProjectileID.DeathLaser, 100, 0f, 0, 0f, 0f);
                        Main.projectile[num1203].timeLeft = 800;
                    }
                    npc.ai[3] = 0f;
                }
            }
            else if (npc.ai[0] > 1600f && npc.ai[0] <= 2100f)
            {
                npc.position.Y = Main.player[npc.target].position.Y - 200f;
                npc.position.X = Main.player[npc.target].position.X;
                npc.ai[3] += 1f;
                if (npc.ai[3] > 120f)
                {
                    var num1204 = 6f;
                    Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 33);
                    var vector161 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                    var num1207 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - vector161.X;
                    var num1208 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - vector161.Y;
                    var num1209 = (float)Math.Sqrt(num1207 * num1207 + num1208 * num1208);
                    num1209 = num1204 / num1209;
                    num1207 *= num1209;
                    num1208 *= num1209;
                    num1208 += npc.velocity.Y * 0.5f;
                    num1207 += npc.velocity.X * 0.5f;
                    vector161.X -= num1207 * 1f;
                    vector161.Y -= num1208 * 1f;
                    Projectile.NewProjectile(vector161.X, vector161.Y, num1207, num1208, ProjectileID.FrostWave, 50, 0f, Main.myPlayer, 0f, 0f);
                    npc.ai[3] = 0f;
                }
            }
            else
            {
                npc.ai[0] = 0f;
            }
            if (Main.player[npc.target].dead)
            {
                npc.TargetClosest(true);
            }
            if ((Main.player[npc.target].dead || npc.target == 255 || !Main.player[npc.target].active) && npc.timeLeft > 10)
            {
                npc.timeLeft = 10;
                return;
            }
            return;
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 1.0;
            if (npc.frameCounter < 2.0)
            {
                npc.frame.Y = 0;
            }
            else if (npc.frameCounter < 4.0)
            {
                npc.frame.Y = frameHeight;
            }
            else if (npc.frameCounter < 6.0)
            {
                npc.frame.Y = frameHeight * 2;
            }
            else if (npc.frameCounter < 8.0)
            {
                npc.frame.Y = frameHeight;
            }
            else
            {
                npc.frameCounter = 0.0;
            }
        }
    }
}