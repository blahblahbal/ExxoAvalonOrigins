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
	public class Blaze : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blaze");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.damage = 69;
			npc.scale = 1.2f;
			npc.noTileCollide = false;
			npc.lifeMax = 460;
			npc.lavaImmune = true;
			npc.defense = 35;
			npc.noGravity = true;
			npc.aiStyle = -1;
			npc.width = 24;
			npc.value = Item.buyPrice(0, 0, 45, 0);
			npc.timeLeft = 750;
			npc.knockBackResist = 0.5f;
			npc.height = 32;
            npc.HitSound = SoundID.NPCHit2;
	        npc.DeathSound = SoundID.NPCDeath6;
			npc.buffImmune[BuffID.OnFire] = true;
			npc.buffImmune[BuffID.Confused] = true;
		}

		public override void NPCLoot()
		{
			if (Main.rand.Next(10) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Hellstone, Main.rand.Next(1, 5), false, 0, false);
			}
			var rectangle = new Rectangle((int)npc.position.X, (int)(npc.position.Y + (npc.height - npc.width) / 2), npc.width, npc.width);
			var num8 = 50;
			var num9 = 0.4f;
			for (var i = 1; i <= num8; i++)
			{
				var num10 = Dust.NewDust(npc.position, rectangle.Width, rectangle.Height, 6, 0f, 0f, 100, default(Color), 2f);
				Main.dust[num10].noGravity = true;
				Main.dust[num10].velocity.X = num9 * (Main.dust[num10].position.X - (npc.position.X + npc.width / 2));
				Main.dust[num10].velocity.Y = num9 * (Main.dust[num10].position.Y - (npc.position.Y + npc.height / 2));
			}
			for (var j = 1; j <= num8; j++)
			{
				var num11 = Dust.NewDust(npc.position, rectangle.Width, rectangle.Height, 54, 0f, 0f, 100, default(Color), 1f);
				Main.dust[num11].noGravity = true;
				Main.dust[num11].velocity.X = num9 * (Main.dust[num11].position.X - (npc.position.X + npc.width / 2));
				Main.dust[num11].velocity.Y = num9 * (Main.dust[num11].position.Y - (npc.position.Y + npc.height / 2));
			}
			var num12 = Projectile.NewProjectile(npc.position.X + npc.width / 2, npc.position.Y + npc.height / 2, 0f, 0f, ProjectileID.Grenade, 0, 0f, npc.target, 0f, 0f);
			Main.projectile[num12].Kill();
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
            npc.rotation = (float)Math.Atan2(num1223, num1222) - 1.57f;
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
            if (Main.rand.Next(20) == 0)
            {
                var num1225 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + npc.height * 0.25f), npc.width, (int)(npc.height * 0.5f), 6, npc.velocity.X, 2f, 75, npc.color, npc.scale);
                var dust56 = Main.dust[num1225];
                dust56.velocity.X = dust56.velocity.X * 0.5f;
                var dust57 = Main.dust[num1225];
                dust57.velocity.Y = dust57.velocity.Y * 0.1f;
            }
            if (Main.rand.Next(40) == 0)
            {
                var num1226 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + npc.height * 0.25f), npc.width, (int)(npc.height * 0.5f), 55, npc.velocity.X, 2f, 0, default(Color), 1f);
                var dust58 = Main.dust[num1226];
                dust58.velocity.X = dust58.velocity.X * 0.5f;
                var dust59 = Main.dust[num1226];
                dust59.velocity.Y = dust59.velocity.Y * 0.1f;
            }
            if (npc.wet && !npc.lavaWet)
            {
                npc.StrikeNPC(50, 0f, 0, false, false);
            }
            if (Main.netMode != 1 && !Main.player[npc.target].dead)
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
                        NPC.NewNPC((int)(npc.position.X + npc.width / 2 + npc.velocity.X), (int)(npc.position.Y + npc.height / 2 + npc.velocity.Y), ModContent.NPCType<BlazeOrb>(), 0);
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
            if (npc.velocity.X > 0f)
            {
                npc.spriteDirection = 1;
            }
            if (npc.velocity.X < 0f)
            {
                npc.spriteDirection = -1;
            }
            npc.rotation = npc.velocity.X * 0.1f;
            if (npc.type == 210 || npc.type == 211)
            {
                npc.frameCounter += 1.0;
                npc.rotation = npc.velocity.X * 0.2f;
            }
            npc.frameCounter += 1.0;
            if (npc.frameCounter >= 6.0)
            {
                npc.frame.Y = npc.frame.Y + frameHeight;
                npc.frameCounter = 0.0;
            }
            if (npc.frame.Y >= frameHeight * Main.npcFrameCount[npc.type])
            {
                npc.frame.Y = 0;
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.player.ZoneUnderworldHeight && Main.hardMode ? 0.1f * ExxoAvalonOriginsGlobalNPC.endoSpawnRate : 0f;
        }
    }
}