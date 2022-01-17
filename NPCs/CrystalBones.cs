using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace ExxoAvalonOrigins.NPCs
{
	public class CrystalBones : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Bones");
			Main.npcFrameCount[npc.type] = 15;
		}
		public override void SetDefaults()
		{
			npc.damage = 122;
            npc.lifeMax = 3500;
			npc.defense = 15;
			npc.lavaImmune = true;
			npc.width = 18;
			npc.aiStyle = 3;
			npc.value = 50000f;
			npc.height = 40;
			npc.knockBackResist = 0f;
            npc.HitSound = SoundID.NPCHit2;
	        npc.DeathSound = SoundID.NPCDeath2;
            //banner = npc.type;
            //bannerItem = ModContent.ItemType<Items.Banners.IrateBonesBanner>();
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.7f);
            npc.damage = (int)(npc.damage * 0.5f);
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
                if (npc.velocity.X == 0f)
                {
                    npc.frame.Y = 0;
                    npc.frameCounter = 0.0;
                }
                else
                {
                    npc.frameCounter += Math.Abs(npc.velocity.X) * 2f;
                    npc.frameCounter += 1.0;
                    if (npc.frameCounter > 6.0)
                    {
                        npc.frame.Y = npc.frame.Y + frameHeight;
                        npc.frameCounter = 0.0;
                    }
                    if (npc.frame.Y / frameHeight >= Main.npcFrameCount[npc.type])
                    {
                        npc.frame.Y = frameHeight * 2;
                    }
                }
            }
            else
            {
                npc.frameCounter = 0.0;
                npc.frame.Y = frameHeight;
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return Main.hardMode && spawnInfo.player.GetModPlayer<ExxoAvalonOriginsModPlayer>().ZoneCrystal ? 0.8f * ExxoAvalonOriginsGlobalNPC.endoSpawnRate : 0f;
        }
        public override void NPCLoot()
        {
            for (int i = 0; i < 8; i++)
            {
                float speedX = npc.velocity.X + Main.rand.Next(-51, 51) * 0.2f;
                float speedY = npc.velocity.Y + Main.rand.Next(-51, 51) * 0.2f;
                int proj = Projectile.NewProjectile(npc.position, new Vector2(speedX, speedY), ModContent.ProjectileType<Projectiles.CrystalShard>(), (int)(npc.damage * 0.8f), 0.3f, Main.myPlayer);
                Main.projectile[proj].hostile = true;
                Main.projectile[proj].friendly = false;
                Main.projectile[proj].timeLeft = 300;
            }
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CrystalBonesHead"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CrystalBonesArm"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CrystalBonesArm"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CrystalBonesLeg"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CrystalBonesLeg"), 1f);
            }
        }
    }
}
