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
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rift");
            Main.npcFrameCount[npc.type] = 1;
        }

        public override void SetDefaults()
        {
            npc.width = npc.height = 70;
            npc.noTileCollide = npc.noGravity = true;
            npc.npcSlots = 1f;
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

        public override void AI()        {
            npc.velocity *= 0f;
            npc.ai[0]++;
            if (npc.ai[1] == 0)
            {
                if (npc.ai[0] % 60 == 0)
                {
                    Player p = Main.player[Player.FindClosest(npc.position, npc.width, npc.height)];
                    if (!WorldGen.crimson && !ExxoAvalonOriginsWorld.contaigon) // corruption world
                    {
                        if (p.ZoneCorrupt)
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
                    }
                    else if (!WorldGen.crimson && ExxoAvalonOriginsWorld.contaigon) // contagion world
                    {
                        if (p.GetModPlayer<ExxoAvalonOriginsModPlayer>().zoneBooger)
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
                    }
                    else if (WorldGen.crimson) // crimson
                    {
                        if (p.ZoneCrimson)
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
                    }
                    for (int i = 0; i < 10; i++)
                    {
                        int num893 = Dust.NewDust(npc.position, npc.width, npc.height, 58, 0f, 0f, 0, default, 1f);
                        Main.dust[num893].velocity *= 2f;
                        Main.dust[num893].scale = 0.9f;
                        Main.dust[num893].noGravity = true;
                        Main.dust[num893].fadeIn = 3f;
                    }
                    Main.PlaySound(2, npc.position, 8);
                }
            }
            else if (npc.ai[1] == 1)
            {
                ushort t1 = (ushort)ExxoAvalonOriginsWorld.phmOreTier1;
                ushort t2 = (ushort)ExxoAvalonOriginsWorld.phmOreTier2;
                ushort t3 = (ushort)ExxoAvalonOriginsWorld.phmOreTier3;
                ushort t4 = (ushort)ExxoAvalonOriginsWorld.phmOreTier4;

                int rand = Main.rand.Next(3);
                if (rand == 0)
                {
                    if (t1 == TileID.Copper || t1 == ModContent.TileType<Tiles.BronzeOre>()) t1 = TileID.Tin;
                    if (t2 == TileID.Iron || t2 == ModContent.TileType<Tiles.NickelOre>()) t2 = TileID.Lead;
                    if (t3 == TileID.Silver || t3 == ModContent.TileType<Tiles.ZincOre>()) t3 = TileID.Tungsten;
                    if (t4 == TileID.Gold || t4 == ModContent.TileType<Tiles.BismuthOre>()) t4 = TileID.Platinum;
                }
                else if (rand == 1)
                {
                    if (t1 == TileID.Tin || t1 == ModContent.TileType<Tiles.BronzeOre>()) t1 = TileID.Copper;
                    if (t2 == TileID.Lead || t2 == ModContent.TileType<Tiles.NickelOre>()) t2 = TileID.Iron;
                    if (t3 == TileID.Tungsten || t3 == ModContent.TileType<Tiles.ZincOre>()) t3 = TileID.Silver;
                    if (t4 == TileID.Platinum || t4 == ModContent.TileType<Tiles.BismuthOre>()) t4 = TileID.Gold;
                }
                else if (rand == 2)
                {
                    if (t1 == TileID.Tin || t1 == TileID.Copper) t1 = (ushort)ModContent.TileType<Tiles.BronzeOre>();
                    if (t2 == TileID.Lead || t2 == TileID.Iron) t2 = (ushort)ModContent.TileType<Tiles.NickelOre>();
                    if (t3 == TileID.Tungsten || t3 == TileID.Silver) t3 = (ushort)ModContent.TileType<Tiles.ZincOre>();
                    if (t4 == TileID.Platinum || t4 == TileID.Gold) t4 = (ushort)ModContent.TileType<Tiles.BismuthOre>();
                }
                Point tile = npc.position.ToTileCoordinates();
                for (int x = tile.X - 10; x < tile.X + 10; x++)
                {
                    for (int y = tile.Y - 10; x < tile.Y + 10; y++)
                    {
                        if (Main.tile[x, y].type == (ushort)ExxoAvalonOriginsWorld.phmOreTier1)
                        {
                            Main.tile[x, y].type = t1;
                            WorldGen.SquareTileFrame(x, y);
                        }
                        if (Main.tile[x, y].type == (ushort)ExxoAvalonOriginsWorld.phmOreTier2)
                        {
                            Main.tile[x, y].type = t2;
                            WorldGen.SquareTileFrame(x, y);
                        }
                        if (Main.tile[x, y].type == (ushort)ExxoAvalonOriginsWorld.phmOreTier3)
                        {
                            Main.tile[x, y].type = t3;
                            WorldGen.SquareTileFrame(x, y);
                        }
                        if (Main.tile[x, y].type == (ushort)ExxoAvalonOriginsWorld.phmOreTier4)
                        {
                            Main.tile[x, y].type = t4;
                            WorldGen.SquareTileFrame(x, y);
                        }
                    }
                }
            }
            if (npc.ai[0] >= 200) npc.active = false;
        }
    }
}
