﻿using System.Collections.Generic;
using System.Linq;
using ExxoAvalonOrigins.Items.Accessories;
using ExxoAvalonOrigins.Items.Armor;
using ExxoAvalonOrigins.Items.Consumables;
using ExxoAvalonOrigins.Items.Material;
using ExxoAvalonOrigins.Items.Placeable.Crafting;
using ExxoAvalonOrigins.Items.Placeable.Painting;
using ExxoAvalonOrigins.Items.Placeable.Tile;
using ExxoAvalonOrigins.Items.Potions;
using ExxoAvalonOrigins.Items.Tools;
using ExxoAvalonOrigins.Items.Vanity;
using ExxoAvalonOrigins.Items.Weapons.Magic;
using ExxoAvalonOrigins.Items.Weapons.Melee;
using ExxoAvalonOrigins.Items.Weapons.Ranged;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins
{
    internal class ExxoAvalonOriginsGlobalNPC : GlobalNPC
    {
        public static float endoSpawnRate = 0.25f;
        public static bool stoppedArmageddon = false;
        public static bool oblivionDead = false;
        public static int oblivionTimes = 0;
        public static bool downedPhantasm = false;
        public static bool initialised = false;
        public static List<int> slimes = new List<int>();
        public static List<int> toxic = new List<int>();
        public static List<int> undead = new List<int>();
        public static List<int> fiery = new List<int>();
        public static List<int> watery = new List<int>();
        public static List<int> earthen = new List<int>();
        public static List<int> flyer = new List<int>();
        public static List<int> frozen = new List<int>();
        public static List<int> wicked = new List<int>();
        public static List<int> arcane = new List<int>();
        public static int boogerBoss = 0;
        public static int boogerBossCounter = 0;
        public static bool savedIceman = false;
        public static int slimeLife = 10000;

        public static List<int> hornets = new List<int> {
            NPCID.Hornet,
            NPCID.MossHornet,
            NPCID.HornetFatty,
            NPCID.HornetHoney,
            NPCID.HornetLeafy,
            NPCID.HornetSpikey,
            NPCID.HornetStingy
        };

        //public override void SetupTravelShop(int[] shop, ref int nextSlot)
        //{
        //    shop[nextSlot] = ModContent.ItemType<TomeForge>();
        //    nextSlot++;
        //}
        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.player.GetModPlayer<ExxoAvalonOriginsModPlayer>().zoneBooger)
            {
                pool.Clear();
                pool.Add(ModContent.NPCType<NPCs.Bactus>(), 1f);
                pool.Add(ModContent.NPCType<NPCs.PyrasiteHead>(), 0.1f);
                if (Main.hardMode)
                {
                    pool.Add(ModContent.NPCType<NPCs.Cougher>(), 0.8f);
                    pool.Add(ModContent.NPCType<NPCs.Ickslime>(), 0.7f);
                    if (spawnInfo.player.ZoneRockLayerHeight)
                    {
                        pool.Add(ModContent.NPCType<NPCs.Virus>(), 1f);
                        pool.Add(ModContent.NPCType<NPCs.GrossyFloat>(), 0.6f);
                    }
                    if (spawnInfo.player.ZoneDesert)
                    {
                        pool.Add(NPCID.DarkMummy, 0.3f);
                        pool.Add(ModContent.NPCType<NPCs.CorruptVulture>(), 0.4f);
                    }
                }
            }
            if (spawnInfo.player.GetModPlayer<ExxoAvalonOriginsModPlayer>().zoneCaesium)
            {
                if (Main.hardMode)
                {
                    pool.Clear();
                    pool.Add(ModContent.NPCType<NPCs.CaesiumBrute>(), 1f);
                    pool.Add(ModContent.NPCType<NPCs.CaesiumSeekerHead>(), 0.05f);
                    pool.Add(ModContent.NPCType<NPCs.CaesiumStalker>(), 0.9f);
                }
            }
            if (spawnInfo.player.GetModPlayer<ExxoAvalonOriginsModPlayer>().zoneHellcastle)
            {
                pool.Clear();
                pool.Add(NPCID.Demon, 0.2f);
                pool.Add(NPCID.RedDevil, 0.2f);
                pool.Add(ModContent.NPCType<NPCs.EctoHand>(), 0.5f);
                pool.Add(ModContent.NPCType<NPCs.HellboundLizard>(), 1f);
                pool.Add(ModContent.NPCType<NPCs.Gargoyle>(), 1f);
                if (ModContent.GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode && Main.hardMode)
                {
                    pool.Add(ModContent.NPCType<NPCs.ArmoredHellTortoise>(), 1f);
                }
            }
        }

        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            if (type == 19 && ModContent.GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode && Main.hardMode)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<MissileBolt>());
                nextSlot++;
            }
            if (type == 368)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<TomeForge>());
                nextSlot++;
            }
        }

        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
            // Advanced battle potion buff changes
            if (player.GetModPlayer<ExxoAvalonOriginsModPlayer>().advBattleBuff)
            {
                spawnRate = (int)(spawnRate * 0.35f);
                maxSpawns = (int)(maxSpawns * 2.5f);
            }
            // Advanced calming potion buff changes
            if (player.GetModPlayer<ExxoAvalonOriginsModPlayer>().advCalmingBuff)
            {
                spawnRate = (int)(spawnRate * 1.5f);
                maxSpawns = (int)(maxSpawns * 0.65f);
            }
            if (ModContent.GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode && Main.hardMode)
            {
                spawnRate = (int)(spawnRate * 0.6);
                maxSpawns += 3;
                if (player.position.Y <= (Main.worldSurface * 16.0) + NPC.sHeight)
                {
                    spawnRate = (int)(spawnRate * 0.55);
                    maxSpawns = (int)(maxSpawns * 1.11);
                }
            }
            if (player.GetModPlayer<ExxoAvalonOriginsModPlayer>().enemySpawns2)
            {
                spawnRate = (int)(spawnRate * 0.2);
                maxSpawns = (int)(maxSpawns * 3f);
            }
            if (player.GetModPlayer<ExxoAvalonOriginsModPlayer>().zoneBooger)
            {
                spawnRate = (int)(spawnRate * 0.65f);
                maxSpawns = (int)(maxSpawns * 1.3f);

                if (player.ZoneRockLayerHeight)
                {
                    spawnRate = (int)(spawnRate * 0.65f);
                    maxSpawns = (int)(maxSpawns * 1.3f);
                }
            }
            else if (player.GetModPlayer<ExxoAvalonOriginsModPlayer>().zoneHellcastle)
            {
                spawnRate = (int)(spawnRate * 0.4f);
                maxSpawns = (int)(maxSpawns * 1.7f);
            }
        }

        /// <summary>
        /// Spawns the Wall of Steel at the given position.
        /// </summary>
        /// <param name="pos">The position to spawn the boss at.</param>
        /// <param name="essence">Whether or not the method will broadcast the "has awoken!" message.</param>
        public static void SpawnWOS(Vector2 pos, bool essence = false)
        {
            if (pos.Y / 16f < Main.maxTilesY - 205)
            {
                return;
            }
            if (ExxoAvalonOriginsWorld.wos >= 0 || Main.wof >= 0)
            {
                return;
            }
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                return;
            }
            int num = 1;
            if (pos.X / 16f > Main.maxTilesX / 2)
            {
                num = -1;
            }
            bool flag = false;
            int num2 = (int)pos.X;
            while (!flag)
            {
                flag = true;
                for (int i = 0; i < 255; i++)
                {
                    if (Main.player[i].active && Main.player[i].position.X > num2 - 1200 && Main.player[i].position.X < num2 + 1200)
                    {
                        num2 -= num * 16;
                        flag = false;
                    }
                }
                if (num2 / 16 < 20 || num2 / 16 > Main.maxTilesX - 20)
                {
                    flag = true;
                }
            }
            int num3 = (int)pos.Y;
            int num4 = num2 / 16;
            int num5 = num3 / 16;
            int num6 = 0;
            try
            {
                while (WorldGen.SolidTile(num4, num5 - num6) || Main.tile[num4, num5 - num6].liquid >= 100)
                {
                    if (!WorldGen.SolidTile(num4, num5 + num6) && Main.tile[num4, num5 + num6].liquid < 100)
                    {
                        num5 += num6;
                        goto IL_162;
                    }
                    num6++;
                }
                num5 -= num6;
            }
            catch
            {
            }
IL_162:
            num3 = num5 * 16;
            int num7 = NPC.NewNPC(num2, num3, ModContent.NPCType<NPCs.WallofSteel>(), 0);
            if (Main.netMode == NetmodeID.Server && num7 < 200)
            {
                NetMessage.SendData(MessageID.SyncNPC, -1, -1, NetworkText.Empty, num7);
            }
            //if (Main.npc[num7].displayName == "")
            //{
            //    Main.npc[num7].DisplayName = "Wall of Steel";
            //}
            if (!essence)
            {
                if (Main.netMode == NetmodeID.SinglePlayer)
                {
                    Main.NewText("Wall of Steel has awoken!", 175, 75, 255, false);
                    return;
                }
                if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Wall of Steel has awoken!"), new Color(175, 75, 255));
                }
            }
        }

        /// <summary>
        /// Finds the closest NPC to the given position.
        /// </summary>
        /// <param name="pos">The origin position.</param>
        /// <param name="dist">The desired distance for the method to find the NPC from.</param>
        /// <returns>Returns the int in the Main.npc[] array.</returns>
        public static int FindClosest(Vector2 pos, float dist)
        {
            int result = -1;
            float num = dist;
            for (int i = 0; i < Main.npc.Length; i++)
            {
                NPC nPC = Main.npc[i];
                if (nPC.active && !nPC.townNPC && nPC.lifeMax > 5 && Vector2.Distance(pos, nPC.Center) < num)
                {
                    num = Vector2.Distance(pos, nPC.Center);
                    result = i;
                }
            }
            return result;
        }

        public static void InitialiseNPCGroups()
        {
            slimes.Add(NPCID.BlueSlime);
            slimes.Add(NPCID.MotherSlime);
            slimes.Add(NPCID.LavaSlime);
            slimes.Add(NPCID.DungeonSlime);
            slimes.Add(NPCID.CorruptSlime);
            slimes.Add(NPCID.Slimer);
            slimes.Add(NPCID.IlluminantSlime);
            slimes.Add(NPCID.IceSlime);
            slimes.Add(NPCID.Crimslime);
            slimes.Add(NPCID.SpikedIceSlime);
            slimes.Add(NPCID.SpikedJungleSlime);
            slimes.Add(NPCID.UmbrellaSlime);
            slimes.Add(NPCID.RainbowSlime);
            slimes.Add(NPCID.SlimeMasked);
            slimes.Add(NPCID.SlimeRibbonWhite);
            slimes.Add(NPCID.SlimeRibbonYellow);
            slimes.Add(NPCID.SlimeRibbonGreen);
            slimes.Add(NPCID.SlimeRibbonRed);
            slimes.Add(NPCID.SlimeSpiked);
            slimes.Add(NPCID.SandSlime);
            slimes.Add(ModContent.NPCType<NPCs.DarkMotherSlime>());
            slimes.Add(ModContent.NPCType<NPCs.DarkMatterSlime>());
            toxic.Add(NPCID.Hornet);
            toxic.Add(NPCID.ManEater);
            toxic.Add(NPCID.GiantTortoise);
            toxic.Add(NPCID.AngryTrapper);
            toxic.Add(NPCID.MossHornet);
            toxic.Add(NPCID.SpikedJungleSlime);
            toxic.Add(NPCID.HornetFatty);
            toxic.Add(NPCID.HornetHoney);
            toxic.Add(NPCID.HornetLeafy);
            toxic.Add(NPCID.HornetSpikey);
            toxic.Add(NPCID.HornetStingy);
            toxic.Add(NPCID.JungleCreeper);
            undead.Add(NPCID.Zombie);
            undead.Add(NPCID.Skeleton);
            undead.Add(NPCID.AngryBones);
            undead.Add(NPCID.DarkCaster);
            undead.Add(NPCID.CursedSkull);
            undead.Add(NPCID.UndeadMiner);
            undead.Add(NPCID.Tim);
            undead.Add(NPCID.DoctorBones);
            undead.Add(NPCID.TheGroom);
            undead.Add(NPCID.ArmoredSkeleton);
            undead.Add(NPCID.Mummy);
            undead.Add(NPCID.Wraith);
            undead.Add(NPCID.SkeletonArcher);
            undead.Add(NPCID.BaldZombie);
            undead.Add(NPCID.PossessedArmor);
            undead.Add(NPCID.VampireBat);
            undead.Add(NPCID.Vampire);
            undead.Add(NPCID.ZombieEskimo);
            undead.Add(NPCID.UndeadViking);
            undead.Add(NPCID.RuneWizard);
            undead.Add(NPCID.PincushionZombie);
            undead.Add(NPCID.SlimedZombie);
            undead.Add(NPCID.SwampZombie);
            undead.Add(NPCID.TwiggyZombie);
            undead.Add(NPCID.ArmoredViking);
            undead.Add(NPCID.FemaleZombie);
            undead.Add(NPCID.HeadacheSkeleton);
            undead.Add(NPCID.MisassembledSkeleton);
            undead.Add(NPCID.PantlessSkeleton);
            undead.Add(NPCID.ZombieRaincoat);
            undead.Add(NPCID.Eyezor);
            undead.Add(NPCID.Reaper);
            undead.Add(NPCID.ZombieMushroom);
            undead.Add(NPCID.ZombieMushroomHat);
            undead.Add(NPCID.ZombieDoctor);
            undead.Add(NPCID.ZombieSuperman);
            undead.Add(NPCID.ZombiePixie);
            undead.Add(NPCID.SkeletonTopHat);
            undead.Add(NPCID.SkeletonAstonaut);
            undead.Add(NPCID.SkeletonAlien);
            undead.Add(NPCID.ZombieXmas);
            undead.Add(NPCID.ZombieSweater);
            fiery.Add(NPCID.FireImp);
            fiery.Add(NPCID.LavaSlime);
            fiery.Add(NPCID.Hellbat);
            fiery.Add(NPCID.Demon);
            fiery.Add(NPCID.VoodooDemon);
            fiery.Add(NPCID.Lavabat);
            fiery.Add(NPCID.RedDevil);
            fiery.Add(ModContent.NPCType<NPCs.Blaze>());
            fiery.Add(ModContent.NPCType<NPCs.ArmoredHellTortoise>());
            watery.Add(NPCID.Piranha);
            watery.Add(NPCID.BlueJellyfish);
            watery.Add(NPCID.PinkJellyfish);
            watery.Add(NPCID.Shark);
            watery.Add(NPCID.Crab);
            watery.Add(NPCID.GreenJellyfish);
            watery.Add(NPCID.Arapaima);
            watery.Add(NPCID.SeaSnail);
            watery.Add(NPCID.Squid);
            watery.Add(NPCID.AnglerFish);
            earthen.Add(NPCID.GiantWormHead);
            earthen.Add(NPCID.MotherSlime);
            earthen.Add(NPCID.ManEater);
            earthen.Add(NPCID.CaveBat);
            earthen.Add(NPCID.Snatcher);
            earthen.Add(NPCID.Antlion);
            earthen.Add(NPCID.GiantBat);
            earthen.Add(NPCID.DiggerHead);
            earthen.Add(NPCID.GiantTortoise);
            earthen.Add(NPCID.WallCreeper);
            earthen.Add(NPCID.WallCreeperWall);
            flyer.Add(NPCID.DemonEye);
            flyer.Add(NPCID.EaterofSouls);
            flyer.Add(NPCID.Harpy);
            flyer.Add(NPCID.CaveBat);
            flyer.Add(NPCID.JungleBat);
            flyer.Add(NPCID.Pixie);
            flyer.Add(NPCID.WyvernHead);
            flyer.Add(NPCID.GiantBat);
            flyer.Add(NPCID.Crimera);
            flyer.Add(NPCID.CataractEye);
            flyer.Add(NPCID.SleepyEye);
            flyer.Add(NPCID.DialatedEye);
            flyer.Add(NPCID.GreenEye);
            flyer.Add(NPCID.PurpleEye);
            flyer.Add(NPCID.Moth);
            flyer.Add(NPCID.FlyingFish);
            flyer.Add(NPCID.FlyingSnake);
            flyer.Add(NPCID.AngryNimbus);
            flyer.Add(ModContent.NPCType<NPCs.VampireHarpy>());
            flyer.Add(ModContent.NPCType<NPCs.Dragonfly>());
            frozen.Add(NPCID.IceSlime);
            frozen.Add(NPCID.IceBat);
            frozen.Add(NPCID.IceTortoise);
            frozen.Add(NPCID.Wolf);
            frozen.Add(NPCID.UndeadViking);
            frozen.Add(NPCID.IceElemental);
            frozen.Add(NPCID.PigronCorruption);
            frozen.Add(NPCID.PigronHallow);
            frozen.Add(NPCID.PigronCrimson);
            frozen.Add(NPCID.SpikedIceSlime);
            frozen.Add(NPCID.SnowFlinx);
            frozen.Add(NPCID.IcyMerman);
            frozen.Add(NPCID.IceGolem);
            wicked.Add(NPCID.EaterofSouls);
            wicked.Add(NPCID.DevourerHead);
            wicked.Add(NPCID.CorruptBunny);
            wicked.Add(NPCID.CorruptGoldfish);
            wicked.Add(NPCID.DarkMummy);
            wicked.Add(NPCID.CorruptSlime);
            wicked.Add(NPCID.CursedHammer);
            wicked.Add(NPCID.Corruptor);
            wicked.Add(NPCID.SeekerHead);
            wicked.Add(NPCID.Clinger);
            wicked.Add(NPCID.Slimer);
            wicked.Add(NPCID.PigronCorruption);
            wicked.Add(NPCID.Crimera);
            wicked.Add(NPCID.Herpling);
            wicked.Add(NPCID.CrimsonAxe);
            wicked.Add(NPCID.PigronCrimson);
            wicked.Add(NPCID.FaceMonster);
            wicked.Add(NPCID.FloatyGross);
            wicked.Add(NPCID.Crimslime);
            wicked.Add(NPCID.BloodCrawler);
            wicked.Add(NPCID.BloodCrawlerWall);
            wicked.Add(NPCID.BloodFeeder);
            wicked.Add(NPCID.BloodJelly);
            wicked.Add(NPCID.IchorSticker);
            wicked.Add(ModContent.NPCType<NPCs.GuardianCorruptor>());
            wicked.Add(ModContent.NPCType<NPCs.Bactus>());
            wicked.Add(ModContent.NPCType<NPCs.Cougher>());
            wicked.Add(ModContent.NPCType<NPCs.PyrasiteHead>());
            wicked.Add(ModContent.NPCType<NPCs.PyrasiteBody>());
            wicked.Add(ModContent.NPCType<NPCs.PyrasiteTail>());
            wicked.Add(ModContent.NPCType<NPCs.Virus>());
            wicked.Add(ModContent.NPCType<NPCs.Ickslime>());
            wicked.Add(ModContent.NPCType<NPCs.Pigron>());
            wicked.Add(ModContent.NPCType<NPCs.GrossyFloat>());
            arcane.Add(NPCID.Pixie);
            arcane.Add(NPCID.LightMummy);
            arcane.Add(NPCID.EnchantedSword);
            arcane.Add(NPCID.Unicorn);
            arcane.Add(NPCID.ChaosElemental);
            arcane.Add(NPCID.Gastropod);
            arcane.Add(NPCID.IlluminantBat);
            arcane.Add(NPCID.IlluminantSlime);
            arcane.Add(NPCID.PigronHallow);
            arcane.Add(NPCID.RainbowSlime);
            arcane.Add(ModContent.NPCType<NPCs.Mime>());
        }

        public override void NPCLoot(NPC npc)
        {
            if (!initialised)
            {
                InitialiseNPCGroups();
                initialised = true;
            }
            int maxValue = 100;
            int maxValue3 = 1000;
            if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].GetModPlayer<ExxoAvalonOriginsModPlayer>().lucky)
            {
                maxValue = 50;
                maxValue3 = 500;
            }
            if (ExxoAvalonOriginsWorld.downedDesertBeak && Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneDesert && Main.rand.Next(125) == 0)
            {
                int item = Main.rand.Next(3);
                if (item == 0) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<AncientTitaniumHeadgear>(), 1, false, 0, false);
                else if (item == 1) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<AncientTitaniumPlateMail>(), 1, false, 0, false);
                else Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<AncientTitaniumGreaves>(), 1, false, 0, false);
            }
            if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneRockLayerHeight && Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].GetModPlayer<ExxoAvalonOriginsModPlayer>().zoneBooger && Main.rand.Next(5) == 0 && npc.lifeMax > 5 && !npc.friendly && Main.hardMode)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SoulofNight, 1, false, 0, false);
            }
            if (npc.type == NPCID.DungeonSpirit && Main.rand.Next(7) == 0)
            {
                int proj = Projectile.NewProjectile(npc.position, npc.velocity, ModContent.ProjectileType<Projectiles.SpiritPoppy>(), 0, 0, Main.myPlayer);
                Main.projectile[proj].velocity.Y = -3.5f;
                Main.projectile[proj].velocity.X = Main.rand.Next(-45, 46) * 0.1f;
            }
            if (npc.type == NPCID.KingSlime && Main.rand.Next(5) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Accessories.BandofSlime>(), 1, false, -1, false);
            }
            if (npc.type == NPCID.Golem && !Main.expertMode)
            {
                //if (Main.rand.Next(7) == 0)
                //{
                //    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2110, 1, false, -1, false);
                //}
                //int num14 = Main.rand.Next(6);
                if (!NPC.downedGolemBoss)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Picksaw, 1, false, -1, false);
                }
                else
                {
                    var list = new List<int>
                    {
                        ItemID.Stynger,
                        ItemID.StaffofEarth,
                        ItemID.EyeoftheGolem,
                        ItemID.Picksaw,
                        ItemID.PossessedHatchet,
                        ItemID.GolemFist,
                        ItemID.SunStone,
                        ItemID.HeatRay,
                        ModContent.ItemType<Sunstorm>(),
                        ModContent.ItemType<EarthenInsignia>(),
                        ModContent.ItemType<HeartoftheGolem>()
                    };
                    int item1 = list.RemoveAtIndex(Main.rand.Next(list.Count));
                    //int item2 = list.RemoveAtIndex(Main.rand.Next(list.Count));
                    if (item1 == ItemID.Stynger) // || item2 == ItemID.Stynger)
                    {
                        Item.NewItem(npc.getRect(), ItemID.StyngerBolt, Main.rand.Next(60, 100), false, 0, false);
                    }
                    Item.NewItem(npc.getRect(), item1, 1, false, -1, false);
                    //Item.NewItem(npc.getRect(), item2, 1, false, -1, false);
                }
                Item.NewItem(npc.getRect(), ModContent.ItemType<EarthStone>(), Main.rand.Next(2) + 1, false, 0, false);
                Item.NewItem(npc.getRect(), ItemID.BeetleHusk, Main.rand.Next(4, 9), false, 0, false);
                return;
            }

            if (Main.hardMode && npc.lifeMax > 1 && npc.damage > 0 && !npc.friendly && npc.position.Y > Main.rockLayer * 16.0 && npc.type != NPCID.Slimer && npc.value > 0f && Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneSnow && Main.rand.Next(10) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<SoulofIce>());
            }
            if (Main.shroomTiles > 30 && Main.rand.Next(11) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GlowingMushroom, Main.rand.Next(2) + 1);
            }
            if ((npc.type == NPCID.Duck || npc.type == NPCID.Duck2 || npc.type == NPCID.DuckWhite || npc.type == NPCID.DuckWhite2) && Main.rand.Next(maxValue3) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Quack>());
            }
            if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneDungeon && Main.hardMode && Main.rand.Next(120) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.CobaltShield, 1, false, -2, false);
            }
            if (Main.rand.Next(600) == 0)
            {
                int potionToDrop = 0;
                switch (Main.rand.Next(22))
                {
                    case 0:
                        potionToDrop = ItemID.EndurancePotion;
                        break;

                    case 1:
                        potionToDrop = ItemID.GravitationPotion;
                        break;

                    case 2:
                        potionToDrop = ItemID.InfernoPotion;
                        break;

                    case 3:
                        potionToDrop = ModContent.ItemType<StarbrightPotion>();
                        break;

                    case 4:
                        potionToDrop = ModContent.ItemType<StrengthPotion>();
                        break;

                    case 5:
                        potionToDrop = ModContent.ItemType<CrimsonPotion>();
                        break;

                    case 6:
                        potionToDrop = ItemID.IronskinPotion;
                        break;

                    case 7:
                        potionToDrop = ItemID.SwiftnessPotion;
                        break;

                    case 8:
                        potionToDrop = ModContent.ItemType<ShockwavePotion>();
                        break;

                    case 9:
                        potionToDrop = ItemID.MiningPotion;
                        break;

                    case 10:
                        potionToDrop = ItemID.ObsidianSkinPotion;
                        break;

                    case 11:
                        potionToDrop = ItemID.NightOwlPotion;
                        break;

                    case 12:
                        potionToDrop = ItemID.RagePotion;
                        break;

                    case 13:
                        potionToDrop = ItemID.RegenerationPotion;
                        break;

                    case 14:
                        potionToDrop = ItemID.SpelunkerPotion;
                        break;

                    case 15:
                        potionToDrop = ItemID.SonarPotion;
                        break;

                    case 16:
                        potionToDrop = ItemID.WrathPotion;
                        break;

                    case 17:
                        potionToDrop = ItemID.SummoningPotion;
                        break;

                    case 18:
                        potionToDrop = ItemID.HunterPotion;
                        break;

                    case 19:
                        potionToDrop = ItemID.FlipperPotion;
                        break;

                    case 20:
                        potionToDrop = ModContent.ItemType<GPSPotion>();
                        break;

                    case 21:
                        potionToDrop = ItemID.GillsPotion;
                        break;
                }
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, potionToDrop, 1, false, 0, false);
            }
            if (Main.eclipse && Main.rand.Next(90) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<SolarFragment>());
            }
            if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneJungle && npc.lifeMax >= 100 && Main.rand.Next(9) == 0 && ModContent.GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode && ExxoAvalonOriginsGlobalNPC.stoppedArmageddon && NPC.downedGolemBoss)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<SouloftheJungle>());
            }
            if (npc.type == NPCID.EaterofSouls && Main.rand.Next(7) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<RottenEye>());
            }
            if (npc.type == NPCID.DialatedEye && Main.rand.Next(40) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BlackLens, 1, false, 0, false);
            }
            if ((npc.type == NPCID.Crimera || npc.type == NPCID.FaceMonster || npc.type == NPCID.BloodCrawler || npc.type == NPCID.BloodCrawlerWall) && Main.rand.Next(7) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Patella>());
            }
            if ((npc.type == NPCID.PincushionZombie || npc.type == NPCID.SlimedZombie || npc.type == NPCID.SwampZombie || npc.type == NPCID.TwiggyZombie || npc.type == NPCID.Zombie || npc.type == NPCID.ZombieEskimo || npc.type == NPCID.FemaleZombie || npc.type == NPCID.ZombieRaincoat) && Main.rand.Next(7) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<RottenFlesh>());
            }
            if (npc.type == NPCID.UndeadMiner)
            {
                if (Main.rand.Next(30) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<MinersPickaxe>(), 1, false, -2, false);
                }
                if (Main.rand.Next(30) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<MinersSword>(), 1, false, -2, false);
                }
            }
            if (npc.type == ModContent.NPCType<NPCs.FallenHero>())
            {
                if (Main.rand.Next(30) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<MinersSword>(), 1, false, -2, false);
                }
            }
            if (npc.type == NPCID.HellArmoredBones || npc.type == NPCID.HellArmoredBonesSpikeShield || npc.type == NPCID.HellArmoredBonesMace || npc.type == NPCID.HellArmoredBonesSword)
            {
                int hellArmourToDrop = Main.rand.Next(66);
                if (hellArmourToDrop == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<HellArmoredHelmet>());
                }
                if (hellArmourToDrop == 1)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<HellBlazingChestplate>());
                }
                if (hellArmourToDrop == 2)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<HellArmoredGreaves>());
                }
            }
            if (npc.type == NPCID.FloatyGross && Main.rand.Next(5) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Patella>(), Main.rand.Next(1, 3));
            }
            if (slimes.Contains(npc.type) && Main.rand.Next(500) == 0 && Main.hardMode)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.RoyalGel, 1, false, -2);
            }
            if (Main.rand.Next(600) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Rock>());
            }
            if (Main.hardMode && Main.rand.Next(650) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<PointingLaser>());
            }
            if (Main.hardMode && ModContent.GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode && Main.rand.Next(700) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<AlienDevice>(), 1, false, 0, false);
            }
            if ((npc.type == NPCID.Clinger || npc.type == NPCID.Spazmatism) && Main.rand.Next(maxValue) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<GreekExtinguisher>(), 1, false, -2);
            }
            if (npc.type == NPCID.RaggedCaster && Main.rand.Next(50) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<SixHundredWattLightbulb>(), 1, false, -2);
            }
            if (npc.type == NPCID.ChaosElemental && NPC.downedMechBossAny && Main.rand.Next(30) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<ChaosEye>(), 1, false, -2, false);
            }
            if (npc.type == NPCID.ChaosElemental && Main.rand.Next(7) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<ChaosDust>(), Main.rand.Next(2, 5));
            }
            if (npc.type == NPCID.BoneSerpentHead && Main.rand.Next(20) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Sunfury, 1, false, -2, false);
            }
            if (toxic.Contains(npc.type))
            {
                if (Main.hardMode)
                {
                    if (Main.rand.Next(7) == 0)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<ToxinShard>(), 1, false, 0, false);
                    }
                }
                else if (Main.rand.Next(15) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<ToxinShard>(), 1, false, 0, false);
                }
            }
            if (undead.Contains(npc.type) && Main.hardMode && Main.rand.Next(300) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Accessories.UndeadTalisman>(), 1, false, -1, false);
            }
            if (undead.Contains(npc.type))
            {
                if (Main.hardMode)
                {
                    if (Main.rand.Next(14) == 0)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<UndeadShard>(), 1, false, 0, false);
                    }
                }
                else if (Main.rand.Next(26) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<UndeadShard>(), 1, false, 0, false);
                }
            }
            if (fiery.Contains(npc.type))
            {
                if (Main.hardMode)
                {
                    if (Main.rand.Next(7) == 0)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<FireShard>(), 1, false, 0, false);
                    }
                }
                else if (Main.rand.Next(10) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<FireShard>(), 1, false, 0, false);
                }
            }
            if (watery.Contains(npc.type))
            {
                if (Main.hardMode)
                {
                    if (Main.rand.Next(7) == 0)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<WaterShard>(), 1, false, 0, false);
                    }
                }
                else if (Main.rand.Next(13) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<WaterShard>(), 1, false, 0, false);
                }
            }
            if (earthen.Contains(npc.type))
            {
                if (Main.hardMode)
                {
                    if (Main.rand.Next(10) == 0)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<EarthShard>(), 1, false, 0, false);
                    }
                }
                else if (Main.rand.Next(18) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<EarthShard>(), 1, false, 0, false);
                }
            }
            if (flyer.Contains(npc.type))
            {
                if (Main.hardMode)
                {
                    if (Main.rand.Next(12) == 0)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<BreezeShard>(), 1, false, 0, false);
                    }
                }
                else if (Main.rand.Next(26) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<BreezeShard>(), 1, false, 0, false);
                }
            }
            if (frozen.Contains(npc.type))
            {
                if (Main.hardMode)
                {
                    if (Main.rand.Next(10) == 0)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<FrostShard>(), 1, false, 0, false);
                    }
                }
                else if (Main.rand.Next(15) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<FrostShard>(), 1, false, 0, false);
                }
            }
            if (wicked.Contains(npc.type))
            {
                if (Main.hardMode)
                {
                    if (Main.rand.Next(10) == 0)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<CorruptShard>(), 1, false, 0, false);
                    }
                }
                else if (Main.rand.Next(15) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<CorruptShard>(), 1, false, 0, false);
                }
            }
            if (arcane.Contains(npc.type))
            {
                if (Main.hardMode)
                {
                    if (Main.rand.Next(7) == 0)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<ArcaneShard>(), 1, false, 0, false);
                    }
                }
                else if (Main.rand.Next(26) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<ArcaneShard>(), 1, false, 0, false);
                }
            }
            if (npc.type == NPCID.Harpy && Main.rand.Next(6) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<RubybeadHerb>(), 1, false, 0, false);
            }
            if (npc.type == NPCID.CaveBat || npc.type == NPCID.GiantBat)
            {
                if (Main.rand.Next(6) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<MysticalClaw>(), 1, false, 0, false);
                }
                if (Main.rand.Next(7) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<RubybeadHerb>(), 1, false, 0, false);
                }
            }
            if (npc.type == NPCID.JungleBat)
            {
                if (Main.rand.Next(12) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<RubybeadHerb>(), 1, false, 0, false);
                }
                if (Main.rand.Next(11) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<MysticalClaw>(), 1, false, 0, false);
                }
            }
            if ((npc.type == NPCID.Corruptor) && Main.rand.Next(3) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<RottenEye>(), Main.rand.Next(2) + 1, false, 0, false);
            }
            if ((npc.type == NPCID.SeekerHead) && Main.rand.Next(3) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<RottenEye>(), Main.rand.Next(2) + 1, false, 0, false);
            }
            if ((npc.type == NPCID.ChaosElemental || npc.type == NPCID.IceElemental || npc.type == NPCID.IchorSticker || npc.type == NPCID.Corruptor || npc.type == ModContent.NPCType<NPCs.Virus>()) && Main.rand.Next(6) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<ElementDiamond>(), 1, false, 0, false);
            }
            if ((npc.type == NPCID.Hornet || npc.type == NPCID.BlackRecluse || npc.type == NPCID.MossHornet || npc.type == NPCID.HornetFatty || npc.type == NPCID.HornetHoney || npc.type == NPCID.HornetLeafy || npc.type == NPCID.HornetSpikey || npc.type == NPCID.HornetStingy || npc.type == NPCID.JungleCreeper || npc.type == NPCID.JungleCreeperWall || npc.type == NPCID.BlackRecluseWall) && Main.rand.Next(7) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<StrongVenom>(), 1, false, 0, false);
            }
            if ((npc.type == NPCID.Retinazer || npc.type == NPCID.Spazmatism || npc.type == NPCID.SkeletronPrime || npc.type == NPCID.TheDestroyer) && Main.rand.Next(3) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<ScrollofTome>(), 1, false, 0, false);
            }
            if (npc.type == NPCID.WyvernHead && Main.rand.Next(2) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<MysticalTotem>(), 1, false, 0, false);
            }
            if ((npc.type == NPCID.ManEater || npc.type == NPCID.Snatcher || npc.type == NPCID.AngryTrapper) && Main.rand.Next(100) < 16)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<DewOrb>(), 1, false, 0, false);
            }
            if ((npc.type == NPCID.GiantTortoise || npc.type == NPCID.IceTortoise) && Main.rand.Next(10) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<ElementDust>(), 1, false, 0, false);
            }
            if ((npc.type == NPCID.Vulture || npc.type == NPCID.FlyingFish || npc.type == NPCID.Unicorn) && Main.rand.Next(5) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<ElementDust>(), 1, false, 0, false);
            }
            if ((npc.type == NPCID.CorruptSlime || npc.type == NPCID.Gastropod || npc.type == NPCID.IlluminantSlime || npc.type == NPCID.ToxicSludge || npc.type == NPCID.Crimslime || npc.type == NPCID.RainbowSlime || npc.type == NPCID.FloatyGross) && Main.rand.Next(100) <= 15)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<DewofHerbs>(), 1, false, 0, false);
            }
            if (npc.type == NPCID.Harpy && Main.rand.Next(50) == 0 && Main.hardMode)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ShinyRedBalloon, 1, false, -1, false);
            }
            if ((npc.type == NPCID.Corruptor || npc.type == NPCID.IchorSticker || npc.type == NPCID.ChaosElemental || npc.type == NPCID.IceElemental || npc.type == NPCID.AngryNimbus || npc.type == NPCID.GiantTortoise || npc.type == NPCID.RedDevil) && Main.rand.Next(100) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<ChaosCrystal>(), 1, false, -1, false);
            }
            if (npc.type == NPCID.Vulture && Main.rand.Next(3) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Beak>(), 1, false, 0, false);
            }
            if (npc.type == NPCID.KingSlime && Main.rand.Next(9) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<BirthofaMonster>(), 1, false, 0, false);
            }
            if ((npc.type == NPCID.CrimsonAxe || npc.type == NPCID.CursedHammer || npc.type == NPCID.EnchantedSword) && Main.rand.Next(80) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Clash>(), 1, false, 0, false);
            }
            if (npc.type == NPCID.EaterofSouls && (Main.rand.Next(250) == 0 || (Main.rand.Next(125) == 0 && Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].GetModPlayer<ExxoAvalonOriginsModPlayer>().lucky)))
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<EvilOuroboros>(), 1, false, 0, false);
            }
            if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].GetModPlayer<ExxoAvalonOriginsModPlayer>().zoneBooger && Main.rand.Next(250) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<RingofDisgust>(), 1, false, 0, false);
            }
            if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneDungeon && Main.rand.Next(400) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Trespassing>(), 1, false, 0, false);
            }
            if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneDungeon && Main.rand.Next(300) == 0 && Main.hardMode)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Placeable.Painting.ACometHasStruckGround>(), 1, false, 0, false);
            }
            if (Main.eclipse && Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].position.Y < (Main.worldSurface * 16.0) + (Main.screenHeight / 2) && (Main.rand.Next(500) == 0 || (Main.rand.Next(400) == 0 && Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].GetModPlayer<ExxoAvalonOriginsModPlayer>().lucky)))
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<EclipseofDoom>(), 1, false, 0, false);
            }
            if (npc.type == NPCID.GoblinSorcerer && Main.rand.Next(40) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<ChaosTome>(), 1, false, -2, false);
            }
            if (npc.type == NPCID.RedDevil && Main.rand.Next(20) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<ForsakenRelic>(), 1, false, -2, false);
            }
            if (npc.type == NPCID.Plantera && !Main.expertMode)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<LifeDew>(), Main.rand.Next(10, 18), false, 0, false);
            }
            if (npc.type == NPCID.PossessedArmor)
            {
                int possessedArmourToDrop = Main.rand.Next(111);
                if (possessedArmourToDrop == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<PossessedArmorHelmet>(), 1, false, 0, false);
                }
                if (possessedArmourToDrop == 1)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<PossessedArmorChainmail>(), 1, false, 0, false);
                }
                if (possessedArmourToDrop == 2)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<PossessedArmorGreaves>(), 1, false, 0, false);
                }
            }
            if ((npc.type == NPCID.SkeletonArcher || npc.type == NPCID.LavaSlime || npc.type == NPCID.MeteorHead || npc.type == NPCID.FireImp || npc.type == NPCID.Hellbat || npc.type == NPCID.Demon || npc.type == NPCID.HellArmoredBones || npc.type == NPCID.HellArmoredBonesSpikeShield || npc.type == NPCID.HellArmoredBonesMace || npc.type == NPCID.HellArmoredBonesSword || npc.type == ModContent.NPCType<NPCs.QuickCaribe>()) && Main.rand.Next(200) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Vortex>(), 1, false, -1, false);
            }
            if (npc.type == NPCID.IchorSticker && Main.rand.Next(70) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<GoldenShield>(), 1, false, -1, false);
            }
            if (npc.boss && Main.rand.Next(7) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<StaminaCrystal>(), 1, false, 0, false);
            }
            if (Main.hardMode && (Main.rand.Next(2500) == 0 || (Main.rand.Next(1250) == 0 && Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].GetModPlayer<ExxoAvalonOriginsModPlayer>().lucky)) && Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].position.Y > (Main.maxTilesY - 190) * 16f)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<UnderworldKey>(), 1, false, 0, false);
            }
            if (Main.hardMode && (Main.rand.Next(2000) == 0 || (Main.rand.Next(1000) == 0 && Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].GetModPlayer<ExxoAvalonOriginsModPlayer>().lucky)) && Main.sandTiles > 50)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<DesertKey>(), 1, false, 0, false);
            }
            if (Main.xMas && npc.lifeMax > 1 && npc.damage > 0 && !npc.friendly && npc.type != NPCID.Slimer && npc.value > 0f && Main.rand.Next(60) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<RedPresent>(), 1, false, 0, false);
            }
            if (npc.lifeMax > 1 && npc.damage > 0 && !npc.friendly && npc.type != NPCID.Slimer && npc.value > 0f && Main.rand.Next(1000) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<RedPresent>(), 1, false, 0, false);
            }
            if (npc.type == NPCID.DungeonSpirit)
            {
                int phantomeItemToDrop = Main.rand.Next(40);
                if (phantomeItemToDrop == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<PhantomMask>(), 1, false, 0, false);
                }
                else if (phantomeItemToDrop == 1)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<PhantomShirt>(), 1, false, 0, false);
                }
                else if (phantomeItemToDrop == 2)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<PhantomPants>(), 1, false, 0, false);
                }
                if (Main.rand.Next(5) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Ectoplasm, 1, false, 0, false);
                }
            }
            if ((npc.type == NPCID.Frankenstein || npc.type == NPCID.SwampThing) && Main.rand.Next(250) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<BrokenVigilanteTome>(), 1, false, 0, false);
            }
            if (npc.type == NPCID.AngryNimbus)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<LivingLightningBlock>(), Main.rand.Next(8, 16), false, 0, false);
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Cloud, Main.rand.Next(10, 16), false, 0, false);
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.RainCloud, Main.rand.Next(6), false, 0, false);
            }
            if (npc.type == NPCID.WallofFlesh)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<FleshyTendril>(), Main.rand.Next(13, 19), false, 0, false);
            }
            if (npc.type == NPCID.EyeofCthulhu)
            {
                if (!Main.hardMode && !ModContent.GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode && Main.rand.Next(10) < 3)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<BloodyAmulet>(), 1, false, 0, false);
                }
                if (Main.hardMode && !ModContent.GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode && Main.rand.Next(100) < 15)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<BloodyAmulet>(), 1, false, 0, false);
                }
                if (Main.hardMode && ModContent.GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode && Main.rand.Next(100) < 7)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<BloodyAmulet>(), 1, false, 0, false);
                }
            }
            if (npc.type == NPCID.QueenBee)
            {
                if (Main.rand.Next(8) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<FightoftheBumblebee>(), 1, false, 0, false);
                }
            }
            if (npc.type == NPCID.Shark)
            {
                if (Main.rand.Next(60) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<DivingSuit>(), 1, false, -2, false);
                }
                if (Main.rand.Next(40) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<DivingPants>(), 1, false, -2, false);
                }
            }
            if (npc.type == NPCID.Plantera)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ChlorophyteOre, Main.rand.Next(60, 121), false, -1, false);
                if (Main.rand.Next(15) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<PlanterasRage>(), 1, false, -1, false);
                }
            }
            if ((Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().ethHeart && Main.rand.Next(30) == 0) ||
                (Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().heartGolem && Main.rand.Next(50) == 0 && npc.lifeMax > 5))
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<PlatinumHeart>(), 1, false, 0, false);
            }

            if (npc.type == NPCID.EyeofCthulhu && ExxoAvalonOriginsWorld.contaigon)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height,
                    ModContent.ItemType<BacciliteOre>(), Main.rand.Next(30, 87), false, 0, false);
            }
        }

        public override void AI(NPC npc)
        {
            if (npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().lavaWalk)
            {
                npc.velocity = ExxoAvalonOrigins.LavaCollision(npc.position, npc.velocity, npc.width, npc.height, false);
            }
            if (npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().electrified && !npc.buffImmune[BuffID.Electrified])
            {
                npc.velocity.X *= 0.05f;
                npc.color = new Color(20, 240, 0, 100);
            }
            if (npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().frozen && !npc.buffImmune[ModContent.BuffType<Buffs.Frozen>()])
            {
                npc.velocity.X *= 0.2f;
                npc.color = new Color(0, 144, 255, 100);
            }
        }

        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (npc.HasBuff(ModContent.BuffType<Buffs.NecroticDrain>()))
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 90;
                if (damage < 3)
                {
                    damage = 3;
                }
            }
            if (npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().malaria)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 30;
                if (damage < 1)
                {
                    damage = 1;
                }
            }
        }

        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            if (npc.HasBuff(ModContent.BuffType<Buffs.NecroticDrain>()))
            {
                Dust.NewDust(npc.position, npc.width, npc.height, DustID.Blood);
            }
            if (npc.HasBuff(ModContent.BuffType<Buffs.AstralCurse>()))
            {
                Dust.NewDust(npc.position, npc.width, npc.height, DustID.DungeonSpirit);
            }

            // This code breaks so much that I just commented it out
            /*
            if (npc.type != NPCID.BlueSlime || npc.type != ModContent.NPCType<NPCs.DarkMotherSlime>())
            {
                if (npc.HasBuff(ModContent.BuffType<Buffs.Frozen>()) || npc.HasBuff(ModContent.BuffType<Buffs.MinionFrozen>()))
                {
                    Color color = new Color(0, 144, 255, 100);
                    npc.color = color;
                }
                else
                {
                    if (npc.color != default(Color))
                    {
                        Color color = default(Color);
                        npc.color = color;
                    }
                }
			}
            */
        }

        public override bool CanHitPlayer(NPC npc, Player target, ref int cooldownSlot)
        {
            if (hornets.Contains(npc.type) && target.GetModPlayer<ExxoAvalonOriginsModPlayer>().beeRepel)
            {
                return false;
            }
            if (slimes.Contains(npc.type) && target.GetModPlayer<ExxoAvalonOriginsModPlayer>().slimeImmune)
            {
                return false;
            }

            return true;
        }

        public override void OnHitByItem(NPC npc, Player player, Item item, int damage, float knockback, bool crit)
        {
            if (player.GetModPlayer<ExxoAvalonOriginsModPlayer>().oblivionKill && Main.rand.Next(35) == 0 && !npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().noOneHitKill)
            {
                npc.life = 0;
                npc.NPCLoot();
                npc.checkDead();
            }
        }

        public override void SetDefaults(NPC npc)
        {
            int[] vanillaNoOneHitKills = {
                NPCID.Everscream,
                NPCID.IceQueen,
                NPCID.SantaNK1,
                NPCID.MourningWood,
                NPCID.Pumpking,
                NPCID.PumpkingBlade,
                NPCID.DungeonGuardian
            };
            if (npc.boss || vanillaNoOneHitKills.Contains(npc.type))
            {
                npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().noOneHitKill = true;
            }
        }

        public override bool PreNPCLoot(NPC npc)
        {
            if (npc.type == NPCID.Golem && !NPC.downedGolemBoss)
            {
                for (int a = 0; a < (int)(Main.maxTilesX * Main.maxTilesY * 0.00008); a++)
                {
                    int x = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
                    int y = WorldGen.genRand.Next((int)Main.rockLayer, Main.maxTilesY - 200);
                    WorldGen.OreRunner(x, y, WorldGen.genRand.Next(4, 7), WorldGen.genRand.Next(4, 8), (ushort)ModContent.TileType<Tiles.SolariumOre>());
                }
                if (Main.netMode == NetmodeID.SinglePlayer)
                {
                    Main.NewText("Your world has been energized with Solarium!", 244, 167, 0);
                }
                else if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Your world has been energized with Solarium!"), new Color(244, 167, 0));
                }
            }

            if (npc.type == NPCID.TheDestroyer || npc.type == NPCID.Retinazer || npc.type == NPCID.Spazmatism || npc.type == NPCID.SkeletronPrime)
            {
                if (!NPC.downedMechBossAny)
                {
                    if ((npc.type == NPCID.Spazmatism && NPC.AnyNPCs(NPCID.Retinazer)) || (npc.type == NPCID.Retinazer && NPC.AnyNPCs(NPCID.Spazmatism)))
                    {
                        return base.PreNPCLoot(npc);
                    }

                    double num5 = Main.rockLayer;
                    int xloc = -100 + Main.maxTilesX - 100;
                    int yloc = -(int)num5 + Main.maxTilesY - 200;
                    int sum = xloc * yloc;
                    int amount = (sum / 10000) * 10;
                    for (int zz = 0; zz < amount; zz++)
                    {
                        int i2 = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
                        double num6 = Main.rockLayer;
                        int j2 = WorldGen.genRand.Next((int)num6, Main.maxTilesY - 200);
                        WorldGen.OreRunner(i2, j2, WorldGen.genRand.Next(WorldGen.genRand.Next(2, 4), WorldGen.genRand.Next(4, 6)), WorldGen.genRand.Next(WorldGen.genRand.Next(3, 5), WorldGen.genRand.Next(4, 8)), (ushort)ModContent.TileType<Tiles.HallowedOre>());
                    }
                    if (Main.netMode == NetmodeID.SinglePlayer)
                    {
                        Main.NewText("Your world has been blessed with Hallowed Ore!", 220, 170, 0);
                    }
                    else if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Your world has been blessed with Hallowed Ore!"), new Color(220, 170, 0));
                    }
                }
            }
            if (npc.type == NPCID.EyeofCthulhu && ExxoAvalonOriginsWorld.contaigon)
            {
                NPCLoader.blockLoot.Add(ItemID.DemoniteOre);
                NPCLoader.blockLoot.Add(ItemID.CorruptSeeds);
            }

            return base.PreNPCLoot(npc);
        }

        public override void ResetEffects(NPC npc)
        {
            npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().spikeTimer++;
            if (npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().spikeTimer >= 60 && !npc.townNPC && npc.lifeMax > 5 && !npc.dontTakeDamage && !npc.noTileCollide && ExxoAvalonOriginsCollisions.SpikeCollision2(npc.position, npc.width, npc.height))
            {
                npc.StrikeNPC(30 + (npc.defense / 2), 0f, 0, false, false);
                npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().spikeTimer = 0;
            }
        }
    }
}
