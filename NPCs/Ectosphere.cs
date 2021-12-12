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
	public class Ectosphere : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ectosphere");
			Main.npcFrameCount[npc.type] = 7;
		}

		public override void SetDefaults()
		{
			npc.damage = 120;
			npc.lifeMax = 6000;
			npc.defense = 10;
			npc.noGravity = true;
			npc.width = 46;
			npc.aiStyle = -1;
			npc.value = 20000f;
			npc.height = 46;
			npc.knockBackResist = 0.5f;
            npc.HitSound = SoundID.NPCHit36;
	        npc.DeathSound = SoundID.NPCDeath39;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.EctosphereBanner>();
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.45f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.67f);
        }
        public override void NPCLoot()
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Ectoplasm, Main.rand.Next(2, 5), false, 0, false);
            if (Main.rand.Next(4) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Phantoplasm>(), Main.rand.Next(3, 6), false, 0, false);
            }
        }

        public override void AI()
        {
            npc.netUpdate = true;
            npc.ai[1] += 1f;
            npc.TargetClosest(true);
            var player7 = Main.player[npc.target];
            var num1221 = 0.022f;
            var num1222 = player7.position.X + player7.width / 2;
            var num1223 = player7.position.Y + player7.height / 2;
            var vector164 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
            num1222 = (int)(num1222 / 8f) * 8;
            num1223 = (int)(num1223 / 8f) * 8;
            vector164.X = (int)(vector164.X / 8f) * 8;
            vector164.Y = (int)(vector164.Y / 8f) * 8;
            num1222 -= vector164.X;
            num1223 -= vector164.Y;
            if (player7.position.X + 300f < npc.position.X || player7.position.X - 300f > npc.position.X || player7.position.Y + 300f < npc.position.Y || player7.position.Y - 300f > npc.position.Y)
            {
                if (player7.position.X + 300f < npc.position.X)
                {
                    if (npc.velocity.X > -6f)
                    {
                        npc.velocity.X = npc.velocity.X - 0.2f;
                    }
                }
                else if (player7.position.X - 300f > npc.position.X && npc.velocity.X < 6f)
                {
                    npc.velocity.X = npc.velocity.X + 0.2f;
                }
                if (player7.position.Y + 300f < npc.position.Y)
                {
                    if (npc.velocity.Y > -6f)
                    {
                        npc.velocity.Y = npc.velocity.Y - 0.2f;
                    }
                }
                else if (player7.position.Y - 300f > npc.position.Y && npc.velocity.Y < 6f)
                {
                    npc.velocity.Y = npc.velocity.Y + 0.2f;
                }
            }
            else
            {
                npc.velocity.X = npc.velocity.X * 0.95f;
                npc.velocity.Y = npc.velocity.Y * 0.95f;
                npc.ai[2] += 1f;
                if (npc.ai[2] == 60f)
                {
                    npc.ai[0] = Main.rand.Next(-7, 7);
                    npc.velocity.X = npc.velocity.X + npc.ai[0];
                    npc.velocity.Y = npc.velocity.Y + npc.ai[0];
                    npc.ai[2] = 0f;
                }
            }
            var vector165 = npc.velocity;
            npc.velocity = Collision.TileCollision(npc.position, npc.velocity, npc.width, npc.height, false, false, 1);
            if (npc.velocity.X != vector165.X)
            {
                npc.velocity.X = -vector165.X;
            }
            if (npc.velocity.Y != vector165.Y)
            {
                npc.velocity.Y = -vector165.Y;
            }
            if (npc.type == NPCID.MoonLordHand)
            {
                npc.rotation = (float)Math.Atan2(num1223, num1222) - 1.57f;
            }
            var num1224 = 0.7f;
            if (npc.collideX)
            {
                npc.netUpdate = true;
                npc.velocity.X = npc.oldVelocity.X * -num1224;
                if (npc.direction == -1 && npc.velocity.X > 0f && npc.velocity.X < 2f)
                {
                    npc.velocity.X = 2f;
                }
                if (npc.direction == 1 && npc.velocity.X < 0f && npc.velocity.X > -2f)
                {
                    npc.velocity.X = -2f;
                }
            }
            if (npc.collideY)
            {
                npc.netUpdate = true;
                npc.velocity.Y = npc.oldVelocity.Y * -num1224;
                if (npc.velocity.Y > 0f && npc.velocity.Y < 1.5)
                {
                    npc.velocity.Y = 2f;
                }
                if (npc.velocity.Y < 0f && npc.velocity.Y > -1.5)
                {
                    npc.velocity.Y = -2f;
                }
            }
            if (Main.netMode != NetmodeID.MultiplayerClient && !Main.player[npc.target].dead)
            {
                if (npc.justHit)
                {
                    npc.localAI[0] = 0f;
                }
                npc.localAI[0] += 1f;
                if (npc.localAI[0] == 180f)
                {
                    if (Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
                    {
                        npc.localAI[1] = 1f;
                        var num1227 = Projectile.NewProjectile(npc.Center.X + npc.velocity.X, npc.Center.Y + npc.velocity.Y, 1f, 1f, ModContent.ProjectileType<Projectiles.Ectosoul>(), 75, 3f, npc.target, 0f, 0f);
                        Main.projectile[num1227].velocity = Vector2.Normalize(Main.player[npc.target].Center - npc.Center) * 7f;
                    }
                    npc.localAI[0] = 0f;
                    npc.localAI[1] = 0f;
                }
            }
            if (!Main.dayTime || !Main.player[npc.target].dead)
            {
                return;
            }
            npc.velocity.Y = npc.velocity.Y - num1221 * 2f;
            if (npc.timeLeft > 10)
            {
                npc.timeLeft = 10;
            }
            if (((npc.velocity.X > 0f && npc.oldVelocity.X < 0f) || (npc.velocity.X < 0f && npc.oldVelocity.X > 0f) || (npc.velocity.Y > 0f && npc.oldVelocity.Y < 0f) || (npc.velocity.Y < 0f && npc.oldVelocity.Y > 0f)) && !npc.justHit)
            {
                npc.netUpdate = true;
                return;
            }
            return;
        }

        public override void FindFrame(int frameHeight)
        {
            if (npc.localAI[1] > 0f)
            {
                npc.frame.Y = frameHeight * 6;
            }
            else
            {
                npc.frameCounter += 1.0;
                if (npc.frameCounter >= 6.0)
                {
                    npc.frame.Y = npc.frame.Y + frameHeight;
                    npc.frameCounter = 0.0;
                }
                if (npc.frame.Y >= frameHeight * (Main.npcFrameCount[npc.type] - 1))
                {
                    npc.frame.Y = 0;
                }
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.player.ZoneDungeon && Main.hardMode && ExxoAvalonOrigins.superHardmode ? 0.083f * ExxoAvalonOriginsGlobalNPC.endoSpawnRate : 0f;
        }
    }
}