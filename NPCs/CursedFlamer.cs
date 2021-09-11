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
	public class CursedFlamer : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed Flamer");
			Main.npcFrameCount[npc.type] = 2;
		}
		public override void SetDefaults()
		{
			npc.npcSlots = 1;
			npc.width = 46;
			npc.height = 90;
			npc.aiStyle = -1;
			npc.timeLeft = 1750;
			//animationType = 75;
			npc.damage = 50;
			npc.defense = 35;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.lifeMax = 210;
			npc.scale = 1f;
			npc.knockBackResist = 0.35f;
			npc.noGravity = true;
			npc.noTileCollide = false;
			npc.value = 500;
			npc.buffImmune[BuffID.Confused] = true;
            npc.buffImmune[BuffID.OnFire] = true;
            npc.buffImmune[BuffID.CursedInferno] = true;
            npc.buffImmune[BuffID.Poisoned] = true;
            //banner = npc.type;
            //bannerItem = ModContent.ItemType<Items.Banners.CursedFlamerBanner>();
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return Main.hardMode && spawnInfo.player.ZoneCorrupt && spawnInfo.spawnTileY < (Main.maxTilesY - 200) && !spawnInfo.player.GetModPlayer<ExxoAvalonOriginsModPlayer>().InPillarZone() ? 1f : 0f;
		}
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 1.0;
            if (npc.frameCounter >= 8.0)
            {
                npc.frame.Y = npc.frame.Y + frameHeight;
                npc.frameCounter = 0.0;
            }
            if (npc.frame.Y >= frameHeight * Main.npcFrameCount[npc.type])
            {
                npc.frame.Y = 0;
            }
        }
        public override void NPCLoot()
		{
			if (Main.rand.Next(3) == 0)
			{
				Item.NewItem(npc.position, new Vector2(npc.width, npc.height), ItemID.CursedFlame, 1);
			}
			if (Main.rand.Next(50) == 0)
            {
				Item.NewItem(npc.position, new Vector2(npc.width, npc.height), ModContent.ItemType<Items.GreekExtinguisher>(), 1);
			}
		}
        public Vector2 RotateAboutOrigin(Vector2 point, Vector2 origin, float rotation)
        {
            return Vector2.Transform(point - origin, Matrix.CreateRotationZ(rotation)) + origin;
        }
        public override void AI()
		{
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead)
            {
                npc.TargetClosest(true);
            }
            var num1169 = 4.2f;
            var num1170 = 0.022f;
            var vector156 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
            var num1171 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2;
            var num1172 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2;
            num1171 = (int)(num1171 / 8f) * 8;
            num1172 = (int)(num1172 / 8f) * 8;
            vector156.X = (int)(vector156.X / 8f) * 8;
            vector156.Y = (int)(vector156.Y / 8f) * 8;
            num1171 -= vector156.X;
            num1172 -= vector156.Y;
            var num1173 = (float)Math.Sqrt(num1171 * num1171 + num1172 * num1172);
            var num1174 = num1173;
            if (num1173 == 0f)
            {
                num1171 = npc.velocity.X;
                num1172 = npc.velocity.Y;
            }
            else
            {
                num1173 = num1169 / num1173;
                num1171 *= num1173;
                num1172 *= num1173;
            }
            npc.ai[0] += 1f;
            if (npc.ai[0] > 0f)
            {
                npc.velocity.Y = npc.velocity.Y + 0.023f;
            }
            else
            {
                npc.velocity.Y = npc.velocity.Y - 0.023f;
            }
            if (npc.ai[0] < -100f || npc.ai[0] > 100f)
            {
                npc.velocity.X = npc.velocity.X + 0.023f;
            }
            else
            {
                npc.velocity.X = npc.velocity.X - 0.023f;
            }
            if (npc.ai[0] > 200f)
            {
                npc.ai[0] = -200f;
            }
            if (num1174 < 150f)
            {
                npc.velocity.X = npc.velocity.X + num1171 * 0.007f;
                npc.velocity.Y = npc.velocity.Y + num1172 * 0.007f;
            }
            if (Main.player[npc.target].dead)
            {
                num1171 = npc.direction * num1169 / 2f;
                num1172 = -num1169 / 2f;
            }
            if (npc.velocity.X < num1171)
            {
                npc.velocity.X = npc.velocity.X + num1170;
                if (npc.velocity.X < 0f && num1171 > 0f)
                {
                    npc.velocity.X = npc.velocity.X + num1170;
                }
            }
            else if (npc.velocity.X > num1171)
            {
                npc.velocity.X = npc.velocity.X - num1170;
                if (npc.velocity.X > 0f && num1171 < 0f)
                {
                    npc.velocity.X = npc.velocity.X - num1170;
                }
            }
            if (npc.velocity.Y < num1172)
            {
                npc.velocity.Y = npc.velocity.Y + num1170;
                if (npc.velocity.Y < 0f && num1172 > 0f)
                {
                    npc.velocity.Y = npc.velocity.Y + num1170;
                }
            }
            else if (npc.velocity.Y > num1172)
            {
                npc.velocity.Y = npc.velocity.Y - num1170;
                if (npc.velocity.Y > 0f && num1172 < 0f)
                {
                    npc.velocity.Y = npc.velocity.Y - num1170;
                }
            }
            npc.rotation = (float)Math.Atan2(num1172, num1171) - 1.57f;
            Vector2 asdf = new Vector2(npc.Center.X, npc.position.Y + npc.height - 6);
            Vector2 asdf2 = RotateAboutOrigin(asdf, npc.Center, npc.rotation);
            int dusty = Dust.NewDust(asdf2, 14, 12, DustID.CursedTorch, (float)((Math.Cos(npc.rotation)) * -1), (float)((Math.Sin(npc.rotation)) * -1), 100, new Color(), 1.5f);
            var num1179 = 0.7f;
            if (npc.collideX)
            {
                npc.netUpdate = true;
                npc.velocity.X = npc.oldVelocity.X * -num1179;
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
                npc.velocity.Y = npc.oldVelocity.Y * -num1179;
                if (npc.velocity.Y > 0f && npc.velocity.Y < 1.5)
                {
                    npc.velocity.Y = 2f;
                }
                if (npc.velocity.Y < 0f && npc.velocity.Y > -1.5)
                {
                    npc.velocity.Y = -2f;
                }
            }
            else if (Main.rand.Next(20) == 0)
            {
                var num1182 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + npc.height * 0.25f), npc.width, (int)(npc.height * 0.5f), DustID.Vile, npc.velocity.X, 2f, 75, npc.color, npc.scale);
                var dust52 = Main.dust[num1182];
                dust52.velocity.X = dust52.velocity.X * 0.5f;
                var dust53 = Main.dust[num1182];
                dust53.velocity.Y = dust53.velocity.Y * 0.1f;
            }
            if (npc.wet)
            {
                if (npc.velocity.Y > 0f)
                {
                    npc.velocity.Y = npc.velocity.Y * 0.95f;
                }
                npc.velocity.Y = npc.velocity.Y - 0.3f;
                if (npc.velocity.Y < -2f)
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
                        var mainproj = (float)Math.Atan2(npc.Center.Y - (Main.player[npc.target].Center.Y), npc.Center.X - (Main.player[npc.target].Center.X));
                        int p = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -(float)Math.Cos(mainproj), -(float)Math.Sin(mainproj), ProjectileID.CursedFlameHostile, 50, 1f, npc.target, 0f, 0f);
                        Main.projectile[p].velocity *= 7f;
                        if (Main.netMode == NetmodeID.Server)
                        {
                            NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, p, 0f, 0f, 0f, 0);
                        }
                    }
                    npc.localAI[0] = 0f;
                }
            }
            if (((npc.velocity.X > 0f && npc.oldVelocity.X < 0f) || (npc.velocity.X < 0f && npc.oldVelocity.X > 0f) || (npc.velocity.Y > 0f && npc.oldVelocity.Y < 0f) || (npc.velocity.Y < 0f && npc.oldVelocity.Y > 0f)) && !npc.justHit)
            {
                npc.netUpdate = true;
                return;
            }
        }
		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Rectangle R = new Rectangle((int)npc.position.X, (int)(npc.position.Y + ((npc.height - npc.width) / 2)), npc.width, npc.width);
				int C = 50;
				float vR = .4f;
				for (int i = 1; i <= C; i++)
				{
					int D = Dust.NewDust(npc.position, R.Width, R.Height, DustID.CursedTorch, 0, 0, 100, new Color(), 2f);
					Main.dust[D].noGravity = true;
					Main.dust[D].velocity.X = vR * (Main.dust[D].position.X - (npc.position.X + (npc.width / 2)));
					Main.dust[D].velocity.Y = vR * (Main.dust[D].position.Y - (npc.position.Y + (npc.height / 2)));
				}
				for (int i2 = 1; i2 <= C; i2++)
				{
					int D2 = Dust.NewDust(npc.position, R.Width, R.Height, DustID.CursedTorch, 0, 0, 100, new Color(), 2f);
					Main.dust[D2].noGravity = true;
					Main.dust[D2].velocity.X = vR * (Main.dust[D2].position.X - (npc.position.X + (npc.width / 2)));
					Main.dust[D2].velocity.Y = vR * (Main.dust[D2].position.Y - (npc.position.Y + (npc.height / 2)));
				}
                for (int i2 = 1; i2 <= C; i2++)
                {
                    int D2 = Dust.NewDust(npc.position, R.Width, R.Height, DustID.Vile, 0, 0, 100, new Color(), 2f);
                    Main.dust[D2].noGravity = true;
                    Main.dust[D2].velocity.X = vR * (Main.dust[D2].position.X - (npc.position.X + (npc.width / 2)));
                    Main.dust[D2].velocity.Y = vR * (Main.dust[D2].position.Y - (npc.position.Y + (npc.height / 2)));
                }
            }
		}
	}
}