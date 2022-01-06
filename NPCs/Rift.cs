using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using System;

namespace ExxoAvalonOrigins.NPCs
{
    public class Rift : ModNPC
    {
        bool[,] copperDone = new bool[21, 21];
        bool[,] ironDone = new bool[21, 21];
        bool[,] silverDone = new bool[21, 21];
        bool[,] goldDone = new bool[21, 21];
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rift");
            Main.npcFrameCount[npc.type] = 1;
        }

        public override void SetDefaults()
        {
            npc.width = npc.height = 70;
            npc.noTileCollide = npc.noGravity = true;
            npc.npcSlots = 0f;
            npc.damage = 0;
            npc.lifeMax = 100;
            npc.dontTakeDamage = true;
            npc.defense = 0;
            npc.aiStyle = -1;
            npc.value = 0;
            npc.knockBackResist = 0f;
            npc.scale = 1f;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath39;
        }

        public override void AI()
        {
            npc.velocity *= 0f;
            npc.ai[0]++;
            if (npc.ai[1] == 0)
            {
                if (npc.ai[0] % 60 == 0)
                {
                    Player p = Main.player[Player.FindClosest(npc.position, npc.width, npc.height)];
                    if (!WorldGen.crimson && !ExxoAvalonOriginsWorld.contagion) // corruption world
                    {
                        if (Main.rand.Next(2) == 0) // crimson mobs
                        {
                            if (Main.hardMode)
                            {
                                if (p.position.Y < Main.worldSurface)
                                {
                                    int t = Main.rand.Next(2);
                                    if (t == 0) NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.Crimslime);
                                    if (t == 1) NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.Herpling);
                                }
                                else if (p.ZoneRockLayerHeight)
                                {
                                    int t = Main.rand.Next(2);
                                    if (t == 0) NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.IchorSticker);
                                    if (t == 1) NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.FloatyGross);
                                }
                            }
                            else
                            {
                                int t = Main.rand.Next(3);
                                if (t == 0) NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.Crimera);
                                if (t == 1) NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.FaceMonster);
                                if (t == 2) NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.BloodCrawler);
                            }
                        }
                        else // contagion mobs
                        {
                            if (Main.hardMode)
                            {
                                if (p.position.Y < Main.worldSurface)
                                {
                                    int t = Main.rand.Next(2);
                                    if (t == 0) NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, ModContent.NPCType<NPCs.Ickslime>());
                                    if (t == 1) NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, ModContent.NPCType<NPCs.Cougher>());
                                }
                                else if (p.ZoneRockLayerHeight)
                                {
                                    int t = Main.rand.Next(2);
                                    if (t == 0) NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, ModContent.NPCType<NPCs.Virus>());
                                    if (t == 1) NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, ModContent.NPCType<NPCs.GrossyFloat>());
                                }
                            }
                            else
                            {
                                int t = Main.rand.Next(2);
                                if (t == 0) NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, ModContent.NPCType<NPCs.Bactus>());
                                if (t == 1) NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, ModContent.NPCType<NPCs.PyrasiteHead>());
                                //if (t == 2) NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.BloodCrawler);
                            }
                        }
                    }
                    else if (!WorldGen.crimson && ExxoAvalonOriginsWorld.contagion) // contagion world
                    {
                        if (Main.rand.Next(2) == 0) // crimson mobs
                        {
                            if (Main.hardMode)
                            {
                                if (p.position.Y < Main.worldSurface)
                                {
                                    int t = Main.rand.Next(2);
                                    if (t == 0) NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.Crimslime);
                                    if (t == 1) NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.Herpling);
                                }
                                else if (p.ZoneRockLayerHeight)
                                {
                                    int t = Main.rand.Next(2);
                                    if (t == 0) NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.IchorSticker);
                                    if (t == 1) NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.FloatyGross);
                                }
                            }
                            else
                            {
                                int t = Main.rand.Next(3);
                                if (t == 0) NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.Crimera);
                                if (t == 1) NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.FaceMonster);
                                if (t == 2) NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.BloodCrawler);
                            }
                        }
                        else // corruption mobs
                        {
                            if (Main.hardMode)
                            {
                                if (p.position.Y < Main.worldSurface)
                                {
                                    int t = Main.rand.Next(3);
                                    if (t == 0) NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.CorruptSlime);
                                    if (t == 1) NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.Slimer);
                                    if (t == 2) NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.Corruptor);
                                }
                                else if (p.ZoneRockLayerHeight)
                                {
                                    int t = Main.rand.Next(3);
                                    if (t == 0) NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.SeekerHead);
                                    if (t == 1) NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.CorruptSlime);
                                    if (t == 2) NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.Corruptor);
                                }
                            }
                            else
                            {
                                int t = Main.rand.Next(2);
                                if (t == 0) NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.EaterofSouls);
                                if (t == 1) NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.DevourerHead);
                                //if (t == 2) NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.BloodCrawler);
                            }
                        }
                    }
                    else if (WorldGen.crimson) // crimson
                    {
                        if (Main.rand.Next(2) == 0) // corruption mobs
                        {
                            if (Main.hardMode)
                            {
                                if (p.position.Y < Main.worldSurface)
                                {
                                    int t = Main.rand.Next(3);
                                    if (t == 0) NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.CorruptSlime);
                                    if (t == 1) NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.Slimer);
                                    if (t == 2) NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.Corruptor);
                                }
                                else if (p.ZoneRockLayerHeight)
                                {
                                    int t = Main.rand.Next(3);
                                    if (t == 0) NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.SeekerHead);
                                    if (t == 1) NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.CorruptSlime);
                                    if (t == 2) NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.Corruptor);
                                }
                            }
                            else
                            {
                                int t = Main.rand.Next(2);
                                if (t == 0) NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.EaterofSouls);
                                if (t == 1) NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.DevourerHead);
                                //if (t == 2) NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.BloodCrawler);
                            }
                        }
                        else // contagion mobs
                        {
                            if (Main.hardMode)
                            {
                                if (p.position.Y < Main.worldSurface)
                                {
                                    int t = Main.rand.Next(2);
                                    if (t == 0) NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, ModContent.NPCType<NPCs.Ickslime>());
                                    if (t == 1) NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, ModContent.NPCType<NPCs.Cougher>());
                                }
                                else if (p.ZoneRockLayerHeight)
                                {
                                    int t = Main.rand.Next(2);
                                    if (t == 0) NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, ModContent.NPCType<NPCs.Virus>());
                                    if (t == 1) NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, ModContent.NPCType<NPCs.GrossyFloat>());
                                }
                            }
                            else
                            {
                                int t = Main.rand.Next(2);
                                if (t == 0) NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, ModContent.NPCType<NPCs.Bactus>());
                                if (t == 1) NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, ModContent.NPCType<NPCs.PyrasiteHead>());
                                //if (t == 2) NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.BloodCrawler);
                            }
                        }
                    }
                    for (int i = 0; i < 10; i++)
                    {
                        int num893 = Dust.NewDust(npc.position, npc.width, npc.height, DustID.Enchanted_Pink, 0f, 0f, 0, default, 1f);
                        Main.dust[num893].velocity *= 2f;
                        Main.dust[num893].scale = 0.9f;
                        Main.dust[num893].noGravity = true;
                        Main.dust[num893].fadeIn = 3f;
                    }
                    Main.PlaySound(SoundID.Item, npc.position, 8);
                }
            }
            else if (npc.ai[1] == 1)
            {
                Point tile = npc.position.ToTileCoordinates();
                for (int x = tile.X - 10; x < tile.X + 10; x++)
                {
                    for (int y = tile.Y - 10; y < tile.Y + 10; y++)
                    {
                        #region phm ore tier 1
                        if (Main.tile[x, y].type == TileID.Copper && !copperDone[x - (tile.X - 10), y - (tile.Y - 10)])
                        {
                            Main.tile[x, y].type = TileID.Tin;
                            WorldGen.SquareTileFrame(x, y);
                            copperDone[x - (tile.X - 10), y - (tile.Y - 10)] = true;
                            if (Main.netMode == NetmodeID.Server) NetMessage.SendTileSquare(-1, x, y, 2);
                        }
                        if (Main.tile[x, y].type == TileID.Tin && !copperDone[x - (tile.X - 10), y - (tile.Y - 10)])
                        {
                            Main.tile[x, y].type = (ushort)ModContent.TileType<Tiles.BronzeOre>();
                            WorldGen.SquareTileFrame(x, y);
                            copperDone[x - (tile.X - 10), y - (tile.Y - 10)] = true;
                            if (Main.netMode == NetmodeID.Server) NetMessage.SendTileSquare(-1, x, y, 2);
                        }
                        if (Main.tile[x, y].type == (ushort)ModContent.TileType<Tiles.BronzeOre>() && !copperDone[x - (tile.X - 10), y - (tile.Y - 10)])
                        {
                            Main.tile[x, y].type = TileID.Copper;
                            WorldGen.SquareTileFrame(x, y);
                            copperDone[x - (tile.X - 10), y - (tile.Y - 10)] = true;
                            if (Main.netMode == NetmodeID.Server) NetMessage.SendTileSquare(-1, x, y, 2);
                        }
                        #endregion
                        #region phm ore tier 2
                        if (Main.tile[x, y].type == TileID.Iron && !ironDone[x - (tile.X - 10), y - (tile.Y - 10)])
                        {
                            Main.tile[x, y].type = TileID.Lead;
                            WorldGen.SquareTileFrame(x, y);
                            ironDone[x - (tile.X - 10), y - (tile.Y - 10)] = true;
                            if (Main.netMode == NetmodeID.Server) NetMessage.SendTileSquare(-1, x, y, 2);
                        }
                        if (Main.tile[x, y].type == TileID.Lead && !ironDone[x - (tile.X - 10), y - (tile.Y - 10)])
                        {
                            Main.tile[x, y].type = (ushort)ModContent.TileType<Tiles.NickelOre>();
                            WorldGen.SquareTileFrame(x, y);
                            ironDone[x - (tile.X - 10), y - (tile.Y - 10)] = true;
                            if (Main.netMode == NetmodeID.Server) NetMessage.SendTileSquare(-1, x, y, 2);
                        }
                        if (Main.tile[x, y].type == (ushort)ModContent.TileType<Tiles.NickelOre>() && !ironDone[x - (tile.X - 10), y - (tile.Y - 10)])
                        {
                            Main.tile[x, y].type = TileID.Iron;
                            WorldGen.SquareTileFrame(x, y);
                            ironDone[x - (tile.X - 10), y - (tile.Y - 10)] = true;
                            if (Main.netMode == NetmodeID.Server) NetMessage.SendTileSquare(-1, x, y, 2);
                        }
                        #endregion
                        #region phm ore tier 3
                        if (Main.tile[x, y].type == TileID.Silver && !silverDone[x - (tile.X - 10), y - (tile.Y - 10)])
                        {
                            Main.tile[x, y].type = TileID.Tungsten;
                            WorldGen.SquareTileFrame(x, y);
                            silverDone[x - (tile.X - 10), y - (tile.Y - 10)] = true;
                            if (Main.netMode == NetmodeID.Server) NetMessage.SendTileSquare(-1, x, y, 2);
                        }
                        if (Main.tile[x, y].type == TileID.Tungsten && !silverDone[x - (tile.X - 10), y - (tile.Y - 10)])
                        {
                            Main.tile[x, y].type = (ushort)ModContent.TileType<Tiles.ZincOre>();
                            WorldGen.SquareTileFrame(x, y);
                            silverDone[x - (tile.X - 10), y - (tile.Y - 10)] = true;
                            if (Main.netMode == NetmodeID.Server) NetMessage.SendTileSquare(-1, x, y, 2);
                        }
                        if (Main.tile[x, y].type == (ushort)ModContent.TileType<Tiles.ZincOre>() && !silverDone[x - (tile.X - 10), y - (tile.Y - 10)])
                        {
                            Main.tile[x, y].type = TileID.Silver;
                            WorldGen.SquareTileFrame(x, y);
                            silverDone[x - (tile.X - 10), y - (tile.Y - 10)] = true;
                            if (Main.netMode == NetmodeID.Server) NetMessage.SendTileSquare(-1, x, y, 2);
                        }
                        #endregion
                        #region phm ore tier 4
                        if (Main.tile[x, y].type == TileID.Gold && !goldDone[x - (tile.X - 10), y - (tile.Y - 10)])
                        {
                            Main.tile[x, y].type = TileID.Platinum;
                            WorldGen.SquareTileFrame(x, y);
                            goldDone[x - (tile.X - 10), y - (tile.Y - 10)] = true;
                            if (Main.netMode == NetmodeID.Server) NetMessage.SendTileSquare(-1, x, y, 2);
                        }
                        if (Main.tile[x, y].type == TileID.Platinum && !goldDone[x - (tile.X - 10), y - (tile.Y - 10)])
                        {
                            Main.tile[x, y].type = (ushort)ModContent.TileType<Tiles.BismuthOre>();
                            WorldGen.SquareTileFrame(x, y);
                            goldDone[x - (tile.X - 10), y - (tile.Y - 10)] = true;
                            if (Main.netMode == NetmodeID.Server) NetMessage.SendTileSquare(-1, x, y, 2);
                        }
                        if (Main.tile[x, y].type == (ushort)ModContent.TileType<Tiles.BismuthOre>() && !goldDone[x - (tile.X - 10), y - (tile.Y - 10)])
                        {
                            Main.tile[x, y].type = TileID.Gold;
                            WorldGen.SquareTileFrame(x, y);
                            goldDone[x - (tile.X - 10), y - (tile.Y - 10)] = true;
                            if (Main.netMode == NetmodeID.Server) NetMessage.SendTileSquare(-1, x, y, 2);
                        }
                        #endregion
                        #region phm ore tier 5
                        if (Main.tile[x, y].type == (ushort)ModContent.TileType<Tiles.RhodiumOre>())
                        {
                            Main.tile[x, y].type = (ushort)ModContent.TileType<Tiles.OsmiumOre>();
                            WorldGen.SquareTileFrame(x, y);
                            if (Main.netMode == NetmodeID.Server) NetMessage.SendTileSquare(-1, x, y, 2);
                            continue;
                        }
                        if (Main.tile[x, y].type == (ushort)ModContent.TileType<Tiles.OsmiumOre>())
                        {
                            Main.tile[x, y].type = (ushort)ModContent.TileType<Tiles.IridiumOre>();
                            WorldGen.SquareTileFrame(x, y);
                            if (Main.netMode == NetmodeID.Server) NetMessage.SendTileSquare(-1, x, y, 2);
                            continue;
                        }
                        if (Main.tile[x, y].type == (ushort)ModContent.TileType<Tiles.IridiumOre>())
                        {
                            Main.tile[x, y].type = (ushort)ModContent.TileType<Tiles.RhodiumOre>();
                            WorldGen.SquareTileFrame(x, y);
                            if (Main.netMode == NetmodeID.Server) NetMessage.SendTileSquare(-1, x, y, 2);
                            continue;
                        }
                        #endregion
                    }
                }
                npc.ai[1] = 4;
            }
            if (npc.ai[0] >= 200) npc.active = false;
        }
    }
}
