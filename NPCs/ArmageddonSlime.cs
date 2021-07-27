using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace ExxoAvalonOrigins.NPCs
{
	public class ArmageddonSlime : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Armageddon Slime");
			Main.npcFrameCount[npc.type] = 5;
		}

		public override void SetDefaults()
		{
			npc.damage = 130;
			npc.boss = true;
			npc.netAlways = true;
			npc.scale = 1.8f;
			npc.lifeMax = 37500;
			npc.defense = 46;
			npc.width = 98;
			npc.aiStyle = -1;
			npc.npcSlots = 10f;
			npc.value = 200000f;
			npc.timeLeft = 750;
			npc.height = 92;
			npc.knockBackResist = 0f;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
			npc.buffImmune[BuffID.Confused] = true;
			npc.buffImmune[BuffID.OnFire] = true;
			npc.buffImmune[BuffID.CursedInferno] = true;
			npc.buffImmune[BuffID.Frostburn] = true;
			npc.buffImmune[mod.BuffType("Freeze")] = true;
		    //music = mod.GetSoundSlot(SoundType.Music, "Music/ArmageddonSlime");
		}

        public override void AI()
        {
            npc.aiAction = 0;
            if (npc.ai[3] == 0f && npc.life > 0)
            {
                npc.ai[3] = npc.lifeMax;
            }
            if (npc.ai[2] == 0f)
            {
                npc.ai[0] = -100f;
                npc.ai[2] = 1f;
                npc.TargetClosest(true);
            }
            if (npc.velocity.Y == 0f)
            {
                npc.velocity.X = npc.velocity.X * 0.8f;
                if (npc.velocity.X > -0.1 && npc.velocity.X < 0.1)
                {
                    npc.velocity.X = 0f;
                }
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
                }
                else if (npc.ai[0] >= -30f)
                {
                    npc.aiAction = 1;
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
            var dust = Dust.NewDust(npc.position, npc.width, npc.height, DustID.t_Slime, npc.velocity.X, npc.velocity.Y, 255, new Color(0, 80, 255, 80), npc.scale * 1.2f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].velocity *= 0.5f;
            if (npc.life <= 0)
            {
                return;
            }
            var lifeFraction = npc.life / (float)npc.lifeMax;
            lifeFraction = lifeFraction * 0.5f + 0.75f;
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
            if (Main.netMode == 1)
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
                    var vector155 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height / 2);
                    Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 33);
                    var num1166 = (float)Math.Atan2(vector155.Y - (Main.player[npc.target].position.Y + Main.player[npc.target].height * 0.5f), vector155.X - (Main.player[npc.target].position.X + Main.player[npc.target].width * 0.5f));
                    for (var num1167 = 0f; num1167 <= 4f; num1167 += 0.4f)
                    {
                        var num1168 = Projectile.NewProjectile(vector155.X, vector155.Y, (float)(Math.Cos(num1166 + num1167) * 12f * -1.0), (float)(Math.Sin(num1166 + num1167) * 12f * -1.0), ModContent.ProjectileType<Projectiles.DarkFlame>(), 50, 0f, npc.target, 0f, 0f);
                        Main.projectile[num1168].timeLeft = 600;
                        Main.projectile[num1168].tileCollide = false;
                        num1168 = Projectile.NewProjectile(vector155.X, vector155.Y, (float)(Math.Cos(num1166 - num1167) * 12f * -1.0), (float)(Math.Sin(num1166 - num1167) * 12f * -1.0), ModContent.ProjectileType<Projectiles.DarkFlame>(), 50, 0f, npc.target, 0f, 0f);
                        Main.projectile[num1168].timeLeft = 600;
                        Main.projectile[num1168].tileCollide = false;
                    }
                    npc.ai[1] = -90f;
                    if (Main.netMode == 2 && newNPC < 200)
                    {
                        NetMessage.SendData(23, -1, -1, NetworkText.FromLiteral(""), newNPC, 0f, 0f, 0f, 0);
                    }
                }
                return;
            }
            return;
        }

        public override void NPCLoot()
		{
			ExxoAvalonOriginsGlobalNPC.stoppedArmageddon = true;
			ExxoAvalonOriginsWorld.InitiateSuperHardmode();
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.SoulofBlight>(), Main.rand.Next(20, 26), false, 0, false);
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.DarkMatterSoilBlock>(), Main.rand.Next(100, 210), false, 0, false);
			if (Main.rand.Next(10) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.ArmageddonSlimeTrophy>(), 1, false, 0, false);
			}
			if (Main.rand.Next(7) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.ArmageddonSlimeMask>(), 1, false, 0, false);
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
    }
}