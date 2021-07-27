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
	public class ImpactWizard : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Impact Wizard");
			Main.npcFrameCount[npc.type] = 3;
		}

		public override void SetDefaults()
		{
			npc.damage = 110;
			npc.lifeMax = 1200;
			npc.defense = 50;
			npc.width = 18;
			npc.aiStyle = -1;
			npc.npcSlots = 2f;
			npc.value = 20000f;
			npc.height = 40;
			npc.knockBackResist = 0.4f;
            npc.HitSound = SoundID.NPCHit2;
	        npc.DeathSound = SoundID.NPCDeath2;
			npc.buffImmune[BuffID.OnFire] = true;
		}

        public override void NPCLoot()
        {
            if (Main.rand.Next(10) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Phantoplasm>(), 1, false, 0, false);
            }
        }

        public override void AI()
        {
            npc.TargetClosest(true);
            npc.velocity.X = npc.velocity.X * 0.93f;
            if (npc.velocity.X > -0.1 && npc.velocity.X < 0.1)
            {
                npc.velocity.X = 0f;
            }
            if (npc.ai[0] == 0f)
            {
                npc.ai[0] = 500f;
            }
            if (npc.ai[2] != 0f && npc.ai[3] != 0f)
            {
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 8);
                for (var num231 = 0; num231 < 50; num231++)
                {
                    var num234 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 173, 0f, 0f, 0, default(Color), 1f);
                    Main.dust[num234].velocity *= 2f;
                    Main.dust[num234].scale = 1.4f;
                }
                npc.position.X = npc.ai[2] * 16f - npc.width / 2 + 8f;
                npc.position.Y = npc.ai[3] * 16f - npc.height;
                npc.velocity.X = 0f;
                npc.velocity.Y = 0f;
                npc.ai[2] = 0f;
                npc.ai[3] = 0f;
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 8);
                for (var num239 = 0; num239 < 50; num239++)
                {
                    var num243 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 173, 0f, 0f, 0, default(Color), 1f);
                    Main.dust[num243].velocity *= 2f;
                    Main.dust[num243].scale = 1.4f;
                }
            }
            npc.ai[0] += 1f;
            if (npc.ai[0] == 50f || npc.ai[0] == 100f || npc.ai[0] == 150f || npc.ai[0] == 200f || npc.ai[0] == 250f)
            {
                npc.ai[1] = 30f;
                npc.netUpdate = true;
            }
            if (npc.ai[0] >= 400f)
            {
                npc.ai[0] = 700f;
            }
            if (npc.ai[0] == 100f || npc.ai[0] == 200f || npc.ai[0] == 300f)
            {
                npc.ai[1] = 30f;
                npc.netUpdate = true;
            }
            if (npc.ai[0] >= 650f && Main.netMode != 1)
            {
                npc.ai[0] = 1f;
                var num247 = (int)Main.player[npc.target].position.X / 16;
                var num248 = (int)Main.player[npc.target].position.Y / 16;
                var num249 = (int)npc.position.X / 16;
                var num250 = (int)npc.position.Y / 16;
                var num251 = 20;
                var num252 = 0;
                var flag28 = false;
                if (Math.Abs(npc.position.X - Main.player[npc.target].position.X) + Math.Abs(npc.position.Y - Main.player[npc.target].position.Y) > 2000f)
                {
                    num252 = 100;
                    flag28 = true;
                }
                while (!flag28 && num252 < 100)
                {
                    num252++;
                    var num253 = Main.rand.Next(num247 - num251, num247 + num251);
                    var num254 = Main.rand.Next(num248 - num251, num248 + num251);
                    for (var num255 = num254; num255 < num248 + num251; num255++)
                    {
                        if ((num255 < num248 - 4 || num255 > num248 + 4 || num253 < num247 - 4 || num253 > num247 + 4) && (num255 < num250 - 1 || num255 > num250 + 1 || num253 < num249 - 1 || num253 > num249 + 1) && Main.tile[num253, num255].nactive())
                        {
                            var flag29 = true;
                            if (!Main.wallDungeon[Main.tile[num253, num255 - 1].wall])
                            {
                                flag29 = false;
                            }
                            else if (Main.tile[num253, num255 - 1].lava())
                            {
                                flag29 = false;
                            }
                            if (flag29 && Main.tileSolid[Main.tile[num253, num255].type] && !Collision.SolidTiles(num253 - 1, num253 + 1, num255 - 4, num255 - 1))
                            {
                                npc.ai[1] = 20f;
                                npc.ai[2] = num253;
                                npc.ai[3] = num255;
                                flag28 = true;
                                break;
                            }
                        }
                    }
                }
                npc.netUpdate = true;
            }
            if (npc.ai[1] > 0f)
            {
                npc.ai[1] -= 1f;
                if (npc.ai[1] == 25f)
                {
                    if (Main.netMode != 1)
                    {
                        var num256 = 6f;
                        var vector23 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y);
                        var num257 = Main.player[npc.target].position.X + Main.player[npc.target].width * 0.5f - vector23.X;
                        var num258 = Main.player[npc.target].position.Y + Main.player[npc.target].height * 0.5f - vector23.Y;
                        var num259 = (float)Math.Sqrt(num257 * num257 + num258 * num258);
                        num259 = num256 / num259;
                        num257 *= num259;
                        num258 *= num259;
                        num257 *= 1.4f;
                        num258 *= 1.4f;
                        if (!npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().silenced)
                        {
                            var num262 = Projectile.NewProjectile(vector23.X, vector23.Y, num257, num258, ModContent.ProjectileType<Projectiles.ImpactSphere>(), 65, 0f, Main.myPlayer, 0f, 0f);
                            Main.projectile[num262].timeLeft = 300;
                        }
                        npc.localAI[0] = 0f;
                    }
                }
            }
            if (Main.rand.Next(2) == 0)
            {
                var num275 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + 2f), npc.width, npc.height, 173, 0f, 0f, 0, default(Color), 1f);
                var dust23 = Main.dust[num275];
                dust23.velocity.X = dust23.velocity.X * 0.5f;
                var dust24 = Main.dust[num275];
                dust24.velocity.Y = dust24.velocity.Y * 0.5f;
                return;
            }
        }

        public override void FindFrame(int frameHeight)
        {
            if (npc.velocity.Y == 0f)
            {
                if (npc.direction == 1)
                {
                    npc.spriteDirection = 1;
                }
                if (npc.direction == -1)
                {
                    npc.spriteDirection = -1;
                }
            }
            npc.frame.Y = 0;
            if (npc.velocity.Y != 0f)
            {
                npc.frame.Y = npc.frame.Y + frameHeight;
            }
            else if (npc.ai[1] > 0f)
            {
                npc.frame.Y = npc.frame.Y + frameHeight * 2;
            }
        }
    }
}