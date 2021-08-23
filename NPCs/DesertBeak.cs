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
    [AutoloadBossHead]
    public class DesertBeak : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Desert Beak");
			Main.npcFrameCount[npc.type] = 3;
		}

		public override void SetDefaults()
		{
			npc.damage = 40;
			npc.boss = true;
			npc.noTileCollide = true;
			npc.lifeMax = 3500;
			npc.defense = 18;
			npc.noGravity = true;
			npc.width = 130;
			npc.aiStyle = -1;
			npc.npcSlots = 100f;
			npc.value = 50000f;
			npc.timeLeft = 750;
			npc.height = 78;
			npc.knockBackResist = 0f;
            npc.HitSound = SoundID.NPCHit28;
	        npc.DeathSound = SoundID.NPCDeath31;
			npc.buffImmune[mod.BuffType("Freeze")] = true;
            bossBag = ModContent.ItemType<Items.BossBags.DesertBeakBossBag>();
        }

		public override void NPCLoot()
		{
			if (Main.rand.Next(7) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.DesertBeakMask>(), 1, false, 0, false);
			}
			if (Main.rand.Next(10) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.DesertBeakTrophy>(), 1, false, 0, false);
			}
            if (Main.expertMode)
            {
                npc.DropBossBags();
            }
            else
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SandBlock, Main.rand.Next(22, 55), false, 0, false);
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.DesertFeather>(), Main.rand.Next(2, 4), false, 0, false);
                if (Main.rand.Next(10) <= 5)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ExxoAvalonOriginsWorld.osmiumOre.GetItemOre(), Main.rand.Next(15, 26), false, 0, false);
                }
                if (Main.rand.Next(3) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.TomeoftheDistantPast>(), 1, false, -2, false);
                }
            }

            if (!ExxoAvalonOriginsWorld.downedDesertBeak)
                ExxoAvalonOriginsWorld.downedDesertBeak = true;
        }

        public override void AI()
        {
            npc.ai[0] += 1f;
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
            {
                npc.TargetClosest(true);
            }
            if (Main.player[npc.target].dead)
            {
                npc.velocity.Y = npc.velocity.Y - 0.04f;
                if (npc.timeLeft > 10)
                {
                    npc.timeLeft = 10;
                    return;
                }
            }
            if (npc.ai[0] < 300f)
            {
                var arg_3FD3A_0 = Main.player[npc.target].velocity;
                var vector150 = Main.player[npc.target].position;
                if (vector150.X > npc.position.X && npc.velocity.X < 8f)
                {
                    npc.velocity.X = npc.velocity.X + 0.22f;
                }
                if (vector150.X < npc.position.X && npc.velocity.X > -8f)
                {
                    npc.velocity.X = npc.velocity.X - 0.22f;
                }
                if (vector150.Y > npc.position.Y + 300f)
                {
                    npc.dontTakeDamage = false;
                    if (npc.velocity.Y > 0f)
                    {
                        if (npc.velocity.Y < 4f)
                        {
                            npc.velocity.Y = npc.velocity.Y + 0.7f;
                        }
                    }
                    else
                    {
                        npc.velocity.Y = npc.velocity.Y + 0.6f;
                    }
                }
                if (vector150.Y < npc.position.Y + 200f)
                {
                    if (npc.velocity.Y < 0f)
                    {
                        if (npc.velocity.Y > -3f)
                        {
                            npc.velocity.Y = npc.velocity.Y - 0.6f;
                        }
                    }
                    else
                    {
                        npc.velocity.Y = npc.velocity.Y - 0.5f;
                    }
                }
                if (vector150.Y + 75f >= npc.position.Y)
                {
                    return;
                }
                npc.dontTakeDamage = true;
                npc.ai[1] += 1f;
                if (npc.ai[1] >= 60f)
                {
                    var num1152 = 8f;
                    var vector151 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height / 2);
                    Main.PlaySound(SoundID.Item, (int)npc.position.X, (int)npc.position.Y, 17);
                    var num1153 = (float)Math.Atan2(vector151.Y - (vector150.Y + Main.player[npc.target].height * 0.5f), vector151.X - (vector150.X + Main.player[npc.target].width * 0.5f));
                    Projectile.NewProjectile(vector151.X, vector151.Y, (float)(Math.Cos(num1153) * num1152 * -1.0), (float)(Math.Sin(num1153) * num1152 * -1.0), ProjectileID.EyeLaser, 20, 0f, 0, 0f, 0f);
                    npc.ai[1] = 0f;
                    return;
                }
                return;
            }
            else if (npc.ai[0] >= 300f && npc.ai[0] < 330f)
            {
                npc.dontTakeDamage = false;
                if (npc.velocity.X == 0f)
                {
                    npc.velocity.X = 1f;
                }
                if (npc.velocity.Y == 0f)
                {
                    npc.velocity.Y = 1f;
                }
                npc.velocity.X = npc.velocity.X * 0.95f;
                npc.velocity.Y = npc.velocity.Y * 0.95f;
                var vector152 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height / 2);
                if (npc.velocity.X < 2f && npc.velocity.X > -2f && npc.velocity.Y < 2f && npc.velocity.Y > -2f)
                {
                    var num1154 = (float)Math.Atan2(vector152.Y - (Main.player[npc.target].position.Y + Main.player[npc.target].height * 0.5f), vector152.X - (Main.player[npc.target].position.X + Main.player[npc.target].width * 0.5f));
                    npc.velocity.X = (float)(Math.Cos(num1154) * 25.0) * -1f;
                    npc.velocity.Y = (float)(Math.Sin(num1154) * 25.0) * -1f;
                    return;
                }
                return;
            }
            else
            {
                if (npc.ai[0] < 330f || npc.ai[0] >= 600f)
                {
                    npc.ai[0] = 0f;
                    return;
                }
                npc.dontTakeDamage = false;
                var arg_4031B_0 = Main.player[npc.target].velocity;
                var vector153 = Main.player[npc.target].position;
                if (vector153.X > npc.position.X && npc.velocity.X < 7f)
                {
                    npc.velocity.X = npc.velocity.X + 0.22f;
                }
                if (vector153.X < npc.position.X && npc.velocity.X > -7f)
                {
                    npc.velocity.X = npc.velocity.X - 0.22f;
                }
                if (vector153.Y > npc.position.Y + 300f)
                {
                    if (npc.velocity.Y > 0f)
                    {
                        if (npc.velocity.Y < 4f)
                        {
                            npc.velocity.Y = npc.velocity.Y + 0.7f;
                        }
                    }
                    else
                    {
                        npc.velocity.Y = npc.velocity.Y + 0.6f;
                    }
                }
                if (vector153.Y < npc.position.Y + 250f)
                {
                    if (npc.velocity.Y < 0f)
                    {
                        if (npc.velocity.Y > -3f)
                        {
                            npc.velocity.Y = npc.velocity.Y - 0.6f;
                        }
                    }
                    else
                    {
                        npc.velocity.Y = npc.velocity.Y - 0.5f;
                    }
                }
                npc.ai[2] += 1f;
                if (npc.ai[2] >= 90f)
                {
                    var num1155 = 5f;
                    var vector154 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height / 2);
                    Main.PlaySound(SoundID.Item, (int)npc.position.X, (int)npc.position.Y, 11);
                    var num1156 = (float)Math.Atan2(vector154.Y - (vector153.Y + Main.player[npc.target].height * 0.5f), vector154.X - (vector153.X + Main.player[npc.target].width * 0.5f));
                    Projectile.NewProjectile(vector154.X, vector154.Y, (float)(Math.Cos(num1156) * num1155 * -1.0), (float)(Math.Sin(num1156) * num1155 * -1.0), ProjectileID.BombSkeletronPrime, 20, 0f, 0, 0f, 0f);
                    npc.ai[2] = 0f;
                    return;
                }
                return;
            }
        }

        public override void FindFrame(int frameHeight)
        {
            {
                npc.spriteDirection = npc.direction;
                npc.rotation = npc.velocity.X * 0.1f;
                if (npc.velocity.X == 0f && npc.velocity.Y == 0f)
                {
                    npc.frame.Y = 0;
                    npc.frameCounter = 0.0;
                }
                else
                {
                    npc.frameCounter += 1.0;
                    if (npc.frameCounter < 4.0)
                    {
                        npc.frame.Y = frameHeight;
                    }
                    else
                    {
                        npc.frame.Y = frameHeight * 2;
                        if (npc.frameCounter >= 7.0)
                        {
                            npc.frameCounter = 0.0;
                        }
                    }
                }
            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DesertBeakHead"), 0.9f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DesertBeakWing"), 0.9f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DesertBeakWing"), 0.9f);
            }
        }
    }
}