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
	public class CaesiumBrute : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Caesium Brute");
			Main.npcFrameCount[npc.type] = 5;
		}

		public override void SetDefaults()
		{
			npc.damage = 62;
            npc.lifeMax = 780;
			npc.defense = 45;
			npc.noGravity = true;
			npc.width = 28;
			npc.aiStyle = 14;
			npc.npcSlots = 2f;
			npc.value = 15000f;
			npc.height = 48;
            npc.HitSound = SoundID.NPCHit1;
	        npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.4f;
            npc.buffImmune[BuffID.OnFire] = true;
            npc.buffImmune[BuffID.CursedInferno] = true;
            npc.lavaImmune = true;
            //banner = npc.type;
            //bannerItem = ModContent.ItemType<Items.Banners.BactusBanner>();
        }

        public override void NPCLoot()
        {
            if (Main.rand.Next(6) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.CaesiumOre>(), Main.rand.Next(3, 7), false, 0, false);
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.player.GetModPlayer<ExxoAvalonOriginsModPlayer>().zoneCaesium && spawnInfo.player.ZoneUnderworldHeight)
               return 1;
            return 0;
        }
        public override void AI()
        {
            npc.ai[0]++;
            if (npc.ai[0] > 240)
            {
                if (Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
                {
                    var player5 = Main.player[npc.target];
                    var vector158 = new Vector2(npc.position.X + npc.width / 2, npc.position.Y + npc.height / 2);
                    var num1191 = (float)Math.Atan2(vector158.Y - (player5.position.Y + player5.height * 0.5f + 40f), vector158.X - (player5.position.X + player5.width * 0.5f + 40f));
                    var number2 = Projectile.NewProjectile(npc.position.X + npc.width / 2, npc.position.Y + npc.height * 0.5f, -(float)Math.Cos(num1191) * 7f, -(float)Math.Sin(num1191) * 7f, ModContent.ProjectileType<Projectiles.CaesiumFireball>(), 55, 1f, npc.target, 0f, 0f);
                    if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.FromLiteral(""), number2, 0f, 0f, 0f, 0);
                    }
                    var num1192 = (float)Math.Atan2(vector158.Y - (player5.position.Y + player5.height * 0.5f - 40f), vector158.X - (player5.position.X + player5.width * 0.5f - 40f));
                    var num1193 = Projectile.NewProjectile(npc.position.X + npc.width / 2, npc.position.Y + npc.height * 0.5f, -(float)Math.Cos(num1192), -(float)Math.Sin(num1192), ModContent.ProjectileType<Projectiles.CaesiumFireball>(), 55, 1f, npc.target, 0f, 0f);
                    Main.projectile[num1193].velocity *= 7f;
                    if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.FromLiteral(""), num1193, 0f, 0f, 0f, 0);
                    }
                    var mainproj = (float)Math.Atan2(npc.Center.Y - (player5.Center.Y), npc.Center.X - (player5.Center.X));
                    int p = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -(float)Math.Cos(mainproj), -(float)Math.Sin(mainproj), ModContent.ProjectileType<Projectiles.CaesiumFireball>(), 55, 1f, npc.target, 0f, 0f);
                    Main.projectile[p].velocity *= 7f;
                }
                npc.ai[0] = 0;
            }
        }

        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;
            npc.rotation = npc.velocity.X * 0.1f;
            npc.frameCounter += 1.0;
            if (npc.frameCounter < 6.0)
            {
                npc.frame.Y = 0;
            }
            else
            {
                npc.frame.Y = frameHeight;
                if (npc.frameCounter >= 11.0)
                {
                    npc.frameCounter = 0.0;
                }
            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity * 0.8f, mod.GetGoreSlot("Gores/CaesiumBruteHead"), 1f);
                Gore.NewGore(npc.position, npc.velocity * 0.8f, mod.GetGoreSlot("Gores/CaesiumBruteWing"), 1f);
                Gore.NewGore(npc.position, npc.velocity * 0.8f, mod.GetGoreSlot("Gores/CaesiumBruteWing"), 1f);
            }
        }
    }
}