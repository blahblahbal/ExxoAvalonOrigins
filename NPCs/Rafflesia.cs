using System;
using ExxoAvalonOrigins.Items.Material;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs;

public class Rafflesia : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Rafflesia");
        Main.npcFrameCount[NPC.type] = 4;
    }

    public override void SetDefaults()
    {
        NPC.damage = 31;
        NPC.lifeMax = 160;
        NPC.defense = 7;
        NPC.width = 54;
        NPC.aiStyle = -1;
        NPC.npcSlots = 1f;
        NPC.value = 110f;
        NPC.height = 30;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
        NPC.knockBackResist = 0f;
        Banner = NPC.type;
        BannerItem = ModContent.ItemType<Items.Banners.RafflesiaBanner>();
        //drawOffsetY = 10;
    }

    public override void ModifyNPCLoot(NPCLoot loot)
    {

    }
    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        if (spawnInfo.player.Avalon().ZoneTropics)
        {
            if (Main.tile[spawnInfo.spawnTileX, spawnInfo.spawnTileY + 2].TileType == ModContent.TileType<Tiles.TropicalGrass>())
                //&&
                //!Main.tile[spawnInfo.spawnTileX + 1, spawnInfo.spawnTileY].HasTile && !Main.tile[spawnInfo.spawnTileX, spawnInfo.spawnTileY].HasTile &&
                //!Main.tile[spawnInfo.spawnTileX - 1, spawnInfo.spawnTileY].HasTile)
            {
                return 1f;
            }
        }
        return 0;
    }
    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.55f);
        NPC.damage = (int)(NPC.damage * 0.65f);
    }
    public override void AI()
    {
        NPC.ai[0]++;
        if (NPC.ai[0] >= 240)
        {
            NPC.ai[1] = 1;
                
        }
        if (NPC.ai[1] == 1)
        {
            NPC.ai[2]++;
            if (NPC.ai[2] == 60 || NPC.ai[2] == 120 || NPC.ai[2] == 180) NPC.NewNPC(NPC.GetSpawnSourceForNPCFromNPCAI(), (int)NPC.Center.X, (int)NPC.position.Y + 8, NPCID.Bee);
            if (NPC.ai[2] == 188)
            {
                NPC.ai[2] = 0;
                NPC.ai[0] = 0;
                NPC.ai[1] = 0;
                return;
            }
        }
    }

    public override void FindFrame(int frameHeight)
    {
        if (NPC.ai[1] == 0)
        {
            NPC.frameCounter++;
            if (NPC.frameCounter < 16)
            {
                NPC.frame.Y = 0;
            }
            else if (NPC.frameCounter < 32)
            {
                NPC.frame.Y = frameHeight;
            }
            else NPC.frameCounter = 0;
        }
        else if (NPC.ai[1] == 1)
        {
            if (NPC.ai[2] < 30 || NPC.ai[2] >= 70 && NPC.ai[2] < 90 || NPC.ai[2] >= 130 && NPC.ai[2] < 150) // squish frame
            {
                NPC.frame.Y = frameHeight * 2;
            }
            else if (NPC.ai[2] >= 30 && NPC.ai[2] < 50 || NPC.ai[2] >= 90 && NPC.ai[2] < 110 || NPC.ai[2] >= 150 && NPC.ai[2] < 170)
            {
                NPC.frame.Y = frameHeight * 3;
            }
            else if (NPC.ai[2] >= 50 && NPC.ai[2] < 70 || NPC.ai[2] >= 110 && NPC.ai[2] < 130)
            {
                if (NPC.ai[2] % 6 == 0 || NPC.ai[2] % 6 == 1 || NPC.ai[2] % 8 == 6 || NPC.ai[2] % 6 == 3) NPC.frame.Y = 0;
                else NPC.frame.Y = frameHeight;
            }
        }
    }

    public override void HitEffect(int hitDirection, double damage)
    {
        //if (npc.life <= 0)
        //{
        //    Gore.NewGore(npc.position, npc.velocity * 0.8f, Mod.Find<ModGore>("Rafflesia").Type, 1f);
        //}
    }
}
