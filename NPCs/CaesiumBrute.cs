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
                    int increments = 3;
                    float degrees = 15f;
                    float offset = (float)((float)(degrees / increments) / 2f); // IF YOU WANT THE ATTACK TO BE AIMED WITH EVEN INCREMENTS, REMOVE OFFSET FROM THE VELOCITY CALCULATION
                    Vector2 rotation = (Main.player[npc.target].Center - npc.Center).SafeNormalize(-Vector2.UnitY);
                    float speed = 7f;
                    for (int i = 0; i < increments; i++)
                    {
                        Vector2 velocity = rotation.RotatedBy(MathHelper.ToRadians(((float)(degrees / 2f) * -1f) + ((float)(degrees / increments) * i) + offset)) * speed;
                        int spray = Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.CaesiumFireball>(), 55, 0f, npc.target, 1f, 0f);
                        if (Main.netMode != NetmodeID.SinglePlayer)
                        {
                            NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, spray);
                        }
                    }
                    Main.PlaySound(SoundID.Item, (int)npc.position.X, (int)npc.position.Y, 8);
                }
                npc.ai[0] = 0;
            }
        }

        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;
            npc.rotation = npc.velocity.X * 0.1f;
            int num226 = 5;
            int num227 = 5;
            npc.frameCounter += 1.0;
            if (npc.frameCounter >= (double)(num226 * num227))
            {
                npc.frameCounter = 0.0;
            }
            int num228 = (int)(npc.frameCounter / (double)num226);
            npc.frame.Y = num228 * frameHeight;
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