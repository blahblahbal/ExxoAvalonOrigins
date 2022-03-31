using System;
using ExxoAvalonOrigins.Items.Material;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs
{
    public class Rafflesia : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rafflesia");
            Main.npcFrameCount[npc.type] = 4;
        }

        public override void SetDefaults()
        {
            npc.damage = 31;
            npc.lifeMax = 160;
            npc.defense = 7;
            npc.width = 54;
            npc.aiStyle = -1;
            npc.npcSlots = 1f;
            npc.value = 110f;
            npc.height = 30;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0f;
            //banner = npc.type;
            //bannerItem = ModContent.ItemType<Items.Banners.RafflesiaBanner>();
            //drawOffsetY = 10;
        }

        public override void NPCLoot()
        {
            //if (Main.rand.Next(2) == 0)
            //{
            //    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<YuckyBit>(), 1, false, 0, false);
            //}
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.player.Avalon().ZoneTropics)
            {
                if (Main.tile[spawnInfo.spawnTileX, spawnInfo.spawnTileY + 2].type == ModContent.TileType<Tiles.TropicalGrass>())
                    //&&
                    //!Main.tile[spawnInfo.spawnTileX + 1, spawnInfo.spawnTileY].active() && !Main.tile[spawnInfo.spawnTileX, spawnInfo.spawnTileY].active() &&
                    //!Main.tile[spawnInfo.spawnTileX - 1, spawnInfo.spawnTileY].active())
                {
                    return 1f;
                }
            }
            return 0;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.55f);
            npc.damage = (int)(npc.damage * 0.65f);
        }
        public override void AI()
        {
            npc.ai[0]++;
            if (npc.ai[0] >= 240)
            {
                npc.ai[1] = 1;
                
            }
            if (npc.ai[1] == 1)
            {
                npc.ai[2]++;
                if (npc.ai[2] == 60 || npc.ai[2] == 120 || npc.ai[2] == 180) NPC.NewNPC((int)npc.Center.X, (int)npc.position.Y + 8, NPCID.Bee);
                if (npc.ai[2] == 188)
                {
                    npc.ai[2] = 0;
                    npc.ai[0] = 0;
                    npc.ai[1] = 0;
                    return;
                }
            }
        }

        public override void FindFrame(int frameHeight)
        {
            if (npc.ai[1] == 0)
            {
                npc.frameCounter++;
                if (npc.frameCounter < 16)
                {
                    npc.frame.Y = 0;
                }
                else if (npc.frameCounter < 32)
                {
                    npc.frame.Y = frameHeight;
                }
                else npc.frameCounter = 0;
            }
            else if (npc.ai[1] == 1)
            {
                if (npc.ai[2] < 30 || npc.ai[2] >= 70 && npc.ai[2] < 90 || npc.ai[2] >= 130 && npc.ai[2] < 150) // squish frame
                {
                    npc.frame.Y = frameHeight * 2;
                }
                else if (npc.ai[2] >= 30 && npc.ai[2] < 50 || npc.ai[2] >= 90 && npc.ai[2] < 110 || npc.ai[2] >= 150 && npc.ai[2] < 170)
                {
                    npc.frame.Y = frameHeight * 3;
                }
                else if (npc.ai[2] >= 50 && npc.ai[2] < 70 || npc.ai[2] >= 110 && npc.ai[2] < 130)
                {
                    if (npc.ai[2] % 6 == 0 || npc.ai[2] % 6 == 1 || npc.ai[2] % 8 == 6 || npc.ai[2] % 6 == 3) npc.frame.Y = 0;
                    else npc.frame.Y = frameHeight;
                }
            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            //if (npc.life <= 0)
            //{
            //    Gore.NewGore(npc.position, npc.velocity * 0.8f, mod.GetGoreSlot("Gores/Bactus"), 1f);
            //}
        }
    }
}
