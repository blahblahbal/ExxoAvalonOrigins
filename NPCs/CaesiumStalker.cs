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
	public class CaesiumStalker : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Caesium Stalker");
			Main.npcFrameCount[npc.type] = 4;
		}
		public override void SetDefaults()
		{
			npc.damage = 73;
			npc.scale = 1.2f;
			npc.noTileCollide = false;
			npc.lifeMax = 575;
			npc.lavaImmune = true;
			npc.defense = 44;
			npc.noGravity = true;
			npc.aiStyle = -1;
			npc.width = 24;
			npc.value = Item.buyPrice(0, 0, 45, 0);
			npc.timeLeft = 750;
			npc.knockBackResist = 0f;
			npc.height = 32;
            //npc.HitSound = SoundID.NPCHit1;
	        //npc.DeathSound = SoundID.NPCDeath6;
			/*npc.buffImmune[BuffID.OnFire] = true;
            npc.buffImmune[BuffID.CursedInferno] = true;
			npc.buffImmune[BuffID.Confused] = true;
            npc.buffImmune[BuffID.Daybreak] = true;*/
            for(int i = 0; i < npc.buffImmune.Length; i++)
            {
                npc.buffImmune[i] = true;
            }
            //banner = npc.type;
            //bannerItem = ModContent.ItemType<Items.Banners.CaesiumStalkerBanner>();
        }
        //public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        //{
        //    SpriteEffects effects = SpriteEffects.None;
        //    if (npc.spriteDirection == 1)
        //    {
        //        effects = SpriteEffects.FlipHorizontally;
        //    }
        //    float num66 = Main.NPCAddHeight(npc.whoAmI);
        //    Vector2 vector13 = new Vector2((float)(Main.npcTexture[npc.type].Width / 2), (float)(Main.npcTexture[npc.type].Height / Main.npcFrameCount[npc.type] / 2));
        //    Main.spriteBatch.Draw(mod.GetTexture("Sprites/BlazeGlow"), new Vector2(npc.position.X - Main.screenPosition.X + (float)(npc.width / 2) - (float)Main.npcTexture[npc.type].Width * npc.scale / 2f + vector13.X * npc.scale, npc.position.Y - Main.screenPosition.Y + (float)npc.height - (float)Main.npcTexture[npc.type].Height * npc.scale / (float)Main.npcFrameCount[npc.type] + 4f + vector13.Y * npc.scale + num66), new Rectangle?(npc.frame), new Color(200, 200, 200, 0), npc.rotation, vector13, npc.scale, effects, 0f);
        //}
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.55f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.5f);
        }
        public override void NPCLoot()
		{
			if (Main.rand.Next(10) == 0 && NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.CaesiumOre>(), Main.rand.Next(2, 5), false, 0, false);
			}
			var rectangle = new Rectangle((int)npc.position.X, (int)(npc.position.Y + (npc.height - npc.width) / 2), npc.width, npc.width);
			for (var j = 1; j <= 25; j++)
			{
				var num11 = Dust.NewDust(npc.position, rectangle.Width, rectangle.Height, 110, 0f, 0f, 100, default, 0.6f);
				Main.dust[num11].noGravity = true;
                Main.dust[num11].velocity *= 2.5f;
                Main.dust[num11].fadeIn = 1.1f;
            }
            //var num12 = Projectile.NewProjectile(npc.position.X + npc.width / 2, npc.position.Y + npc.height / 2, 0f, 0f, ProjectileID.Grenade, npc.damage, 0f, npc.target, 0f, 0f);
			//Main.projectile[num12].Kill();
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
            if (Main.rand.Next(40) == 0)
            {
                var num1225 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + npc.height * 0.25f), npc.width, (int)(npc.height * 0.5f), 110, npc.velocity.X, 2f, 75, npc.color, npc.scale);
                var dust56 = Main.dust[num1225];
                dust56.noGravity = true;
                dust56.velocity.X = dust56.velocity.X * 0.5f;
                var dust57 = Main.dust[num1225];
                dust57.velocity.Y = dust57.velocity.Y * 0.1f;
            }
            if (npc.wet && !npc.lavaWet)
            {
                npc.StrikeNPC(50, 0f, 0, false, false);
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
                        var mainproj = (float)Math.Atan2(npc.Center.Y - (Main.player[npc.target].Center.Y), npc.Center.X - (Main.player[npc.target].Center.X));
                        int p = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -(float)Math.Cos(mainproj), -(float)Math.Sin(mainproj), ModContent.ProjectileType<Projectiles.CaesiumSpike>(), 50, 1f, npc.target, 0f, 0f);
                        Main.projectile[p].velocity *= 13f;
                        Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 8);
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
            /*if (npc.velocity.X > 0f)
            {
                npc.spriteDirection = 1;
            }
            if (npc.velocity.X < 0f)
            {
                npc.spriteDirection = -1;
            }*/
            npc.rotation = npc.velocity.X * 0.1f;
            /*if (npc.type == NPCID.Bee || npc.type == NPCID.BeeSmall) the hell is this lol
            {
                npc.frameCounter += 1.0;
                npc.rotation = npc.velocity.X * 0.2f;
            }*/
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
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life > 0)
            {
                Main.PlaySound(SoundID.NPCHit, (int)npc.Center.X, (int)npc.Center.Y, 4, 0.9f, -0.5f);
                Main.PlaySound(SoundID.Item, (int)npc.Center.X, (int)npc.Center.Y, 30, 0.2f, -0.5f);
            }
            if (npc.life <= 0)
            {
                Main.PlaySound(SoundID.Item, (int)npc.Center.X, (int)npc.Center.Y, 27, 1.2f, -0.5f);
                Main.PlaySound(SoundID.NPCHit, (int)npc.Center.X, (int)npc.Center.Y, 5, 1f, -0.5f);
                Gore.NewGore(npc.position, npc.velocity * 0f, mod.GetGoreSlot("Gores/StalkerGore1"), 1.2f);
                Gore.NewGore(npc.position, npc.velocity * 0f, mod.GetGoreSlot("Gores/StalkerGore2"), 1.2f);
                Gore.NewGore(npc.position, npc.velocity * 0f, mod.GetGoreSlot("Gores/StalkerGore3"), 1.2f);
                Gore.NewGore(npc.position, npc.velocity * 0f, mod.GetGoreSlot("Gores/StalkerGore4"), 1.2f);
                Gore.NewGore(npc.position, npc.velocity * 0f, mod.GetGoreSlot("Gores/StalkerGore5"), 1.2f);
                Gore.NewGore(npc.position, npc.velocity * 0f, mod.GetGoreSlot("Gores/StalkerGore5"), 1.2f);
                Gore.NewGore(npc.position, npc.velocity * 0f, mod.GetGoreSlot("Gores/StalkerGore6"), 1.2f);
                /*for (int k = 0; k < 7; k++)
                {
                    Vector2 value14 = new Vector2(Main.rand.Next(-10, 10), Main.rand.Next(-10, 10));
                    value14.Normalize();
                    value14 *= 13;
                    int p = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, value14.X, value14.Y, ModContent.ProjectileType<Projectiles.CaesiumSpike>(), 50, 1f, npc.target, 0f);
                    Main.projectile[p].timeLeft = 30;
                }*/
            }
        }
        int counter = 0;
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = mod.GetTexture("NPCs/CaesiumStalker");
            Vector2 origin = new Vector2(texture.Width * 0.5f, npc.height * 0.5f);
            Main.spriteBatch.Draw(texture, npc.Center - Main.screenPosition, npc.frame, Color.White * ((255f - npc.alpha) / 255f), npc.rotation, origin, npc.scale, SpriteEffects.None, 0);
            counter++;
            if (counter > 22)
                counter = 0;
            for (int j = 0; j < 2; j++)
            {
                float bonusAlphaMult = 1 - 1 * (counter / 12f);
                float dir = j * 2 - 1;
                Vector2 offset = new Vector2(counter * 0.8f * dir, 0).RotatedBy(npc.rotation);
                Main.spriteBatch.Draw(texture, npc.Center - Main.screenPosition + offset, npc.frame, new Color(100, 100, 100, 0) * bonusAlphaMult * ((255f - npc.alpha) / 255f), npc.rotation, origin, 1.00f, SpriteEffects.None, 0.0f);
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.player.GetModPlayer<ExxoAvalonOriginsModPlayer>().zoneCaesium && spawnInfo.player.ZoneUnderworldHeight)
                return 1f;
            return 0;
        }
    }
}