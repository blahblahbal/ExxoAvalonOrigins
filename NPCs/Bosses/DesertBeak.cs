using Microsoft.Xna.Framework;
using System;
using ExxoAvalonOrigins.Items.Material;
using ExxoAvalonOrigins.Items.Placeable.Trophy;
using ExxoAvalonOrigins.Items.Vanity;
using ExxoAvalonOrigins.Items.Weapons.Magic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.NPCs.Bosses
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
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.57f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.55f);
        }
        public override void NPCLoot()
		{
			if (Main.rand.Next(7) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<DesertBeakMask>(), 1, false, 0, false);
			}
			if (Main.rand.Next(10) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<DesertBeakTrophy>(), 1, false, 0, false);
			}
            if (Main.expertMode)
            {
                npc.DropBossBags();
            }
            else
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SandBlock, Main.rand.Next(22, 55), false, 0, false);
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<DesertFeather>(), Main.rand.Next(2, 4), false, 0, false);
                if (Main.rand.Next(10) <= 5)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ExxoAvalonOriginsWorld.rhodiumOre.GetItemOre(), Main.rand.Next(15, 26), false, 0, false);
                }
                if (Main.rand.Next(3) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<TomeoftheDistantPast>(), 1, false, -2, false);
                }
            }

            if (!ExxoAvalonOriginsWorld.downedDesertBeak)
                ExxoAvalonOriginsWorld.downedDesertBeak = true;
        }

        public override void AI()
        {
            int stageFactor = 30;
            if (Main.expertMode) stageFactor = 15;
            npc.ai[0]++;
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
            if (npc.ai[0] < stageFactor * 10)
            {
                Vector2 pVel = Main.player[npc.target].velocity;
                Vector2 pPos = Main.player[npc.target].position;
                if (npc.position.X + npc.width / 2 > Main.player[npc.target].Center.X)
                {
                    npc.direction = -1;
                    if (npc.velocity.X > 0f)
                    {
                        npc.velocity.X *= 0.96f;
                    }
                    npc.velocity.X -= 0.05f;
                    if (npc.velocity.X > 8f) npc.velocity.X = 8f;
                }
                if (npc.position.X + npc.width / 2 < Main.player[npc.target].Center.X)
                {
                    npc.direction = 1;
                    if (npc.velocity.X < 0f)
                    {
                        npc.velocity.X *= 0.96f;
                    }
                    npc.velocity.X += 0.05f;
                    if (npc.velocity.X < -8f) npc.velocity.X = -8f;
                }
                if (pPos.Y + 75 < npc.position.Y)
                {
                    npc.dontTakeDamage = true;
                    npc.ai[1]++;
                    if (npc.ai[1] >= 60)
                    {
                        float Speed = 8f;
                        Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 17);
                        float rotation = (float)Math.Atan2(npc.Center.Y - (pPos.Y + (Main.player[npc.target].height * 0.5f)), npc.Center.X - (pPos.X + (Main.player[npc.target].width * 0.5f)));
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), 83, 40, 0f, 0);
                        npc.ai[1] = 0;
                    }
                }
                if (pPos.Y - 250 < npc.position.Y)
                {
                    if (npc.velocity.Y > 0)
                    {
                        npc.velocity.Y *= 0.98f;
                    }
                    npc.velocity.Y -= 0.02f;
                    if (npc.velocity.Y > 2.2f) npc.velocity.Y = 2.2f;
                }
                if (pPos.Y - 250 > npc.position.Y)
                {
                    npc.dontTakeDamage = false;
                    if (npc.velocity.Y < 0)
                    {
                        npc.velocity.Y *= 0.98f;
                    }
                    npc.velocity.Y += 0.02f;
                    if (npc.velocity.Y < -2.2f) npc.velocity.Y = -2.2f;
                }
            }
            else if (npc.ai[0] >= stageFactor * 10 && npc.ai[0] < stageFactor * 11)
            {
                npc.dontTakeDamage = false;
                float num131 = 6f;
                Vector2 vector14 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                float num132 = Main.player[npc.target].position.X + (Main.player[npc.target].width / 2) - vector14.X;
                float num133 = Main.player[npc.target].position.Y + (Main.player[npc.target].height / 2) - vector14.Y;
                float num134 = (float)Math.Sqrt(num132 * num132 + num133 * num133);
                num134 = num131 / num134;
                npc.velocity.X = num132 * num134;
                npc.velocity.Y = num133 * num134;
                if (Main.expertMode && npc.ai[3] < 3)
                {
                    npc.ai[0] = stageFactor * 10;
                    npc.ai[3]++;
                    return;
                }
            }
            else if (npc.ai[0] >= stageFactor * 11 && npc.ai[0] < stageFactor * 20)
            {
                npc.dontTakeDamage = false;
                npc.ai[3] = 0;
                Vector2 pVel = Main.player[npc.target].velocity;
                Vector2 pPos = Main.player[npc.target].position;
                if (npc.position.X + npc.width / 2 > Main.player[npc.target].Center.X)
                {
                    npc.direction = -1;
                    if (npc.velocity.X > 0f)
                    {
                        npc.velocity.X *= 0.98f;
                    }
                    npc.velocity.X -= 0.05f;
                    if (npc.velocity.X > 8f) npc.velocity.X = 8f;
                }
                if (npc.position.X + npc.width / 2 < Main.player[npc.target].Center.X)
                {
                    npc.direction = 1;
                    if (npc.velocity.X < 0f)
                    {
                        npc.velocity.X *= 0.98f;
                    }
                    npc.velocity.X += 0.05f;
                    if (npc.velocity.X < -8f) npc.velocity.X = -8f;
                }
                if (pPos.Y - 250 < npc.position.Y)
                {
                    if (npc.velocity.Y > 0)
                    {
                        npc.velocity.Y *= 0.98f;
                    }
                    npc.velocity.Y -= 0.02f;
                    if (npc.velocity.Y > 2.2f) npc.velocity.Y = 2.2f;
                }
                if (pPos.Y - 250 > npc.position.Y)
                {
                    npc.dontTakeDamage = false;
                    if (npc.velocity.Y < 0)
                    {
                        npc.velocity.Y *= 0.98f;
                    }
                    npc.velocity.Y += 0.02f;
                    if (npc.velocity.Y < -2.2f) npc.velocity.Y = -2.2f;
                }
                npc.ai[2]++;
                if (npc.ai[2] >= 90)
                {
                    for (int i = 0; i < (Main.expertMode ? 4 : 1); i++)
                    {
                        float Speed = 5f;
                        Vector2 npcPosRefined = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
                        float rotation = (float)Math.Atan2(npcPosRefined.Y - (pPos.Y + (Main.player[npc.target].height * 0.5f)), npcPosRefined.X - (pPos.X + (Main.player[npc.target].width * 0.5f)));
                        float speedX = (float)((Math.Cos(rotation) * Speed) * -1);
                        float speedY = (float)((Math.Sin(rotation) * Speed) * -1);
                        float num78 = speedX + Main.rand.Next(-50, 51) * 0.05f;
                        float num79 = speedY + Main.rand.Next(-50, 51) * 0.05f;
                        Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 11);
                        int bomb = Projectile.NewProjectile(npcPosRefined.X, npcPosRefined.Y, num78, num79, 102, 20, 0f, 0);
                    }
                    npc.ai[2] = 0;
                }
            }
            else npc.ai[0] = 0;
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
