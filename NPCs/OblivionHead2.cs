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
	public class OblivionHead2 : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Oblivion");
			Main.npcFrameCount[npc.type] = 3;
		}

		public override void SetDefaults()
		{
			npc.damage = 120;
			npc.boss = true;
			npc.netAlways = true;
			npc.noTileCollide = true;
			npc.lifeMax = 100000;
			npc.defense = 80;
			npc.noGravity = true;
			npc.width = 80;
			npc.aiStyle = -1;
			npc.npcSlots = 10f;
			npc.value = 50000f;
			npc.timeLeft = 22500;
			npc.height = 102;
			npc.knockBackResist = 0.1f;
            npc.HitSound = SoundID.NPCHit4;
	        npc.DeathSound = SoundID.NPCDeath14;
        }

        public override void AI()
        {
            var instance = npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>();
            npc.damage = npc.defDamage;
            npc.defense = npc.defDefense;
            if (npc.ai[0] == 0f && Main.netMode != 1)
            {
                npc.TargetClosest(true);
                npc.ai[0] = 1f;
                instance.astigSpawned = false;
            }
            if (Main.player[npc.target].dead || Math.Abs(npc.position.X - Main.player[npc.target].position.X) > 6000f || Math.Abs(npc.position.Y - Main.player[npc.target].position.Y) > 6000f)
            {
                npc.TargetClosest(true);
                if (Main.player[npc.target].dead || Math.Abs(npc.position.X - Main.player[npc.target].position.X) > 6000f || Math.Abs(npc.position.Y - Main.player[npc.target].position.Y) > 6000f)
                {
                    npc.ai[1] = 3f;
                }
            }
            if (npc.life < npc.lifeMax / 2 && !instance.astigSpawned)
            {
                var num562 = NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, ModContent.NPCType<Astigmatazer>(), 0);
                Main.npc[num562].target = npc.target;
                NPC.SpawnOnPlayer(npc.target, NPCID.TheDestroyer);
                instance.astigSpawned = true;
            }
            if (npc.life < 40000)
            {
                npc.localAI[0] += 1f;
                if (npc.localAI[0] >= 500f)
                {
                    var num563 = 12f;
                    var vector54 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height / 2);
                    var num564 = 60;
                    int num565 = ProjectileID.BombSkeletronPrime;
                    Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 33);
                    var num566 = (float)Math.Atan2(vector54.Y - (Main.player[npc.target].position.Y + Main.player[npc.target].height * 0.5f), vector54.X - (Main.player[npc.target].position.X + Main.player[npc.target].width * 0.5f));
                    for (var num567 = 0f; num567 <= 4f; num567 += 0.4f)
                    {
                        var num568 = Projectile.NewProjectile(vector54.X, vector54.Y, (float)(Math.Cos(num566 + num567) * num563 * -1.0), (float)(Math.Sin(num566 + num567) * num563 * -1.0), num565, num564, 0f, 0, 0f, 0f);
                        Main.projectile[num568].timeLeft = 600;
                        Main.projectile[num568].tileCollide = false;
                        if (Main.netMode == 2)
                        {
                            NetMessage.SendData(27, -1, -1, NetworkText.FromLiteral(""), num568, 0f, 0f, 0f, 0);
                        }
                        num568 = Projectile.NewProjectile(vector54.X, vector54.Y, (float)(Math.Cos(num566 - num567) * num563 * -1.0), (float)(Math.Sin(num566 - num567) * num563 * -1.0), num565, num564, 0f, 0, 0f, 0f);
                        Main.projectile[num568].timeLeft = 600;
                        Main.projectile[num568].tileCollide = false;
                        if (Main.netMode == 2)
                        {
                            NetMessage.SendData(27, -1, -1, NetworkText.FromLiteral(""), num568, 0f, 0f, 0f, 0);
                        }
                    }
                    npc.localAI[0] = 0f;
                }
            }
            if (npc.ai[1] == 0f)
            {
                npc.ai[2] += 1f;
                if (npc.ai[2] >= 600f)
                {
                    npc.ai[2] = 0f;
                    npc.ai[1] = 1f;
                    npc.TargetClosest(true);
                    npc.netUpdate = true;
                }
                npc.rotation = npc.velocity.X / 15f;
                if (npc.position.Y > Main.player[npc.target].position.Y - 200f)
                {
                    if (npc.velocity.Y > 0f)
                    {
                        npc.velocity.Y = npc.velocity.Y * 0.98f;
                    }
                    npc.velocity.Y = npc.velocity.Y - 0.1f;
                    if (npc.velocity.Y > 2f)
                    {
                        npc.velocity.Y = 2f;
                    }
                }
                else if (npc.position.Y < Main.player[npc.target].position.Y - 500f)
                {
                    if (npc.velocity.Y < 0f)
                    {
                        npc.velocity.Y = npc.velocity.Y * 0.98f;
                    }
                    npc.velocity.Y = npc.velocity.Y + 0.1f;
                    if (npc.velocity.Y < -2f)
                    {
                        npc.velocity.Y = -2f;
                    }
                }
                if (npc.position.X + npc.width / 2 > Main.player[npc.target].position.X + Main.player[npc.target].width / 2 + 100f)
                {
                    if (npc.velocity.X > 0f)
                    {
                        npc.velocity.X = npc.velocity.X * 0.98f;
                    }
                    npc.velocity.X = npc.velocity.X - 0.1f;
                    if (npc.velocity.X > 8f)
                    {
                        npc.velocity.X = 8f;
                    }
                }
                if (npc.position.X + npc.width / 2 >= Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - 100f)
                {
                    return;
                }
                if (npc.velocity.X < 0f)
                {
                    npc.velocity.X = npc.velocity.X * 0.98f;
                }
                npc.velocity.X = npc.velocity.X + 0.1f;
                if (npc.velocity.X < -8f)
                {
                    npc.velocity.X = -8f;
                    return;
                }
                return;
            }
            else
            {
                if (npc.ai[1] == 1f)
                {
                    npc.defense *= 2;
                    npc.damage *= 2;
                    npc.ai[2] += 1f;
                    if (npc.ai[2] == 2f)
                    {
                        Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
                    }
                    if (npc.ai[2] >= 400f)
                    {
                        npc.ai[2] = 0f;
                        npc.ai[1] = 0f;
                    }
                    npc.rotation += npc.direction * 0.3f;
                    var vector56 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                    var num575 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - vector56.X;
                    var num576 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - vector56.Y;
                    var num577 = (float)Math.Sqrt(num575 * num575 + num576 * num576);
                    num577 = 2f / num577;
                    npc.velocity.X = num575 * num577;
                    npc.velocity.Y = num576 * num577;
                    return;
                }
                if (npc.ai[1] == 2f)
                {
                    npc.damage = 1000;
                    npc.defense = 9999;
                    npc.rotation += npc.direction * 0.3f;
                    var vector57 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                    var num578 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - vector57.X;
                    var num579 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - vector57.Y;
                    var num580 = (float)Math.Sqrt(num578 * num578 + num579 * num579);
                    num580 = 8f / num580;
                    npc.velocity.X = num578 * num580;
                    npc.velocity.Y = num579 * num580;
                    return;
                }
                if (npc.ai[1] != 3f)
                {
                    return;
                }
                npc.velocity.Y = npc.velocity.Y + 0.1f;
                if (npc.velocity.Y < 0f)
                {
                    npc.velocity.Y = npc.velocity.Y * 0.95f;
                }
                npc.velocity.X = npc.velocity.X * 0.95f;
                if (npc.timeLeft > 500)
                {
                    npc.timeLeft = 500;
                    return;
                }
                return;
            }
        }

        public override void FindFrame(int frameHeight)
        {
            if (npc.ai[1] == 0f)
            {
                npc.frameCounter += 1.0;
                if (npc.frameCounter >= 12.0)
                {
                    npc.frameCounter = 0.0;
                    npc.frame.Y = npc.frame.Y + frameHeight;
                    if (npc.frame.Y / frameHeight >= 2)
                    {
                        npc.frame.Y = 0;
                    }
                }
            }
            else
            {
                npc.frameCounter = 0.0;
                npc.frame.Y = frameHeight * 2;
            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/OblivionTop"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/OblivionMouth"), 1f);
            }
        }
    }
}