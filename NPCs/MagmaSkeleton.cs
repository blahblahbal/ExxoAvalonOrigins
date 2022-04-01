using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs
{
    public class MagmaSkeleton : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magma Skeleton");
            Main.npcFrameCount[NPC.type] = 15;
        }
        public override void SetDefaults()
        {
            NPC.damage = 42;
            NPC.lifeMax = 540;
            NPC.defense = 21;
            NPC.lavaImmune = true;
            NPC.width = 18;
            NPC.aiStyle = 3;
            NPC.value = 1000f;
            NPC.height = 40;
            NPC.knockBackResist = 0.15f;
            NPC.HitSound = SoundID.NPCHit2;
            NPC.DeathSound = SoundID.NPCDeath2;
            NPC.buffImmune[BuffID.Confused] = true;
            NPC.buffImmune[BuffID.OnFire] = true;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(255, 255, 255);
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.55f);
            NPC.damage = (int)(NPC.damage * 0.5f);
        }
        public override void FindFrame(int frameHeight)
        {
            if (NPC.velocity.Y == 0f)
            {
                if (NPC.direction == 1)
                {
                    NPC.spriteDirection = 1;
                }
                if (NPC.direction == -1)
                {
                    NPC.spriteDirection = -1;
                }
                if (NPC.velocity.X == 0f)
                {
                    NPC.frame.Y = 0;
                    NPC.frameCounter = 0.0;
                }
                else
                {
                    NPC.frameCounter += Math.Abs(NPC.velocity.X) * 2f;
                    NPC.frameCounter += 1.0;
                    if (NPC.frameCounter > 6.0)
                    {
                        NPC.frame.Y = NPC.frame.Y + frameHeight;
                        NPC.frameCounter = 0.0;
                    }
                    if (NPC.frame.Y / frameHeight >= Main.npcFrameCount[NPC.type])
                    {
                        NPC.frame.Y = frameHeight * 2;
                    }
                }
            }
            else
            {
                NPC.frameCounter = 0.0;
                NPC.frame.Y = frameHeight;
            }
        }
        public override void AI()
        {
            Lighting.AddLight((int)((NPC.position.X + (float)(NPC.width / 2)) / 16f), (int)((NPC.position.Y + (float)(NPC.height / 2)) / 16f), 0.9f, 0.25f, 0.05f);
            if (Main.rand.Next(7) == 0)
            {
                int num10 = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Torch, 0f, 0f, 0, default(Color), 1.2f);
                Main.dust[num10].noGravity = true;
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return Main.hardMode && !spawnInfo.player.ZoneDungeon && spawnInfo.player.ZoneRockLayerHeight ? 0.1f * ExxoAvalonOriginsGlobalNPC.endoSpawnRate : 0f;
        }
        public override void NPCLoot()
        {
            for (int i = 0; i < 20; i++)
            {
                int num890 = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Torch, 0f, 0f, 0, default(Color), 1f);
                Main.dust[num890].velocity *= 5f;
                Main.dust[num890].scale = 1.2f;
                Main.dust[num890].noGravity = true;
            }
            if (NPC.life <= 0)
            {
                Gore.NewGore(NPC.position, NPC.velocity, 43, 1f);
                Gore.NewGore(NPC.position, NPC.velocity, 43, 1f);
                Gore.NewGore(NPC.position, NPC.velocity, 44, 1f);
                Gore.NewGore(NPC.position, NPC.velocity, 44, 1f);
                Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("Gores/MagmaHelmet"), 1f);
                //Gore.NewGore(npc.position, npc.velocity, Mod.Find<ModGore>("Gores/MagmaChestplate"), 1f);
            }
        }
    }
}
