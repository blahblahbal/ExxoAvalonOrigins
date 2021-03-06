using System.Collections.Generic;
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
using ExxoAvalonOrigins.Items.Weapons.Throw;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.GameContent.ItemDropRules;
using ExxoAvalonOrigins.Systems;

namespace ExxoAvalonOrigins;

public class ExxoAvalonOriginsGlobalNPC : GlobalNPC
{
    public static float endoSpawnRate = 0.25f;
    public static bool oblivionDead = false;
    public static int oblivionTimes = 0;
    public static bool initialized = false;
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
    public static int bleedTime = 60 * 7;
    public static bool imkCompat = false;

    public static List<int> shmMobs = new List<int>
    {
        NPCID.Creeper,
        NPCID.Pumpking,
        NPCID.SantaNK1,
        ModContent.NPCType<NPCs.AegisHallowor>(),
        ModContent.NPCType<NPCs.AncientOblivionCannon>(),
        ModContent.NPCType<NPCs.AncientOblivionHead1>(),
        ModContent.NPCType<NPCs.AncientOblivionHead2>(),
        ModContent.NPCType<NPCs.AncientOblivionLaser>(),
        ModContent.NPCType<NPCs.AncientOblivionPhase1>(),
        ModContent.NPCType<NPCs.AncientOblivionSaw>(),
        ModContent.NPCType<NPCs.AncientOblivionVice>(),
        ModContent.NPCType<NPCs.Bosses.ArmageddonSlime>(),
        ModContent.NPCType<NPCs.ArmoredHellTortoise>(),
        ModContent.NPCType<NPCs.ArmoredWraith>(),
        ModContent.NPCType<NPCs.Astigmatazer>(),
        ModContent.NPCType<NPCs.BactusMinion>(), // remove later
        ModContent.NPCType<NPCs.BombBones>(),
        ModContent.NPCType<NPCs.BombSkeleton>(),
        ModContent.NPCType<NPCs.CloudBat>(),
        ModContent.NPCType<NPCs.CometTail>(),
        ModContent.NPCType<NPCs.CrystalBones>(),
        ModContent.NPCType<NPCs.CrystalSpectre>(),
        ModContent.NPCType<NPCs.CursedMagmaSkeleton>(),
        ModContent.NPCType<NPCs.DarkMatterSlime>(),
        ModContent.NPCType<NPCs.DarkMotherSlime>(),
        ModContent.NPCType<NPCs.Dragonfly>(),
        ModContent.NPCType<NPCs.DragonLordBody>(),
        ModContent.NPCType<NPCs.DragonLordBody2>(),
        ModContent.NPCType<NPCs.DragonLordBody3>(),
        ModContent.NPCType<NPCs.DragonLordHead>(),
        ModContent.NPCType<NPCs.DragonLordLegs>(),
        ModContent.NPCType<NPCs.DragonLordTail>(),
        ModContent.NPCType<NPCs.Ectosphere>(),
        ModContent.NPCType<NPCs.EyeBones>(),
        ModContent.NPCType<NPCs.GuardianBones>(),
        ModContent.NPCType<NPCs.GuardianCorruptor>(),
        ModContent.NPCType<NPCs.ImpactWizard>(),
        ModContent.NPCType<NPCs.Infernaspaz>(),
        ModContent.NPCType<NPCs.Juggernaut>(),
        ModContent.NPCType<NPCs.JuggernautSorcerer>(),
        ModContent.NPCType<NPCs.MatterMan>(),
        ModContent.NPCType<NPCs.MechanicalDiggerBody>(),
        ModContent.NPCType<NPCs.MechanicalDiggerHead>(),
        ModContent.NPCType<NPCs.MechanicalDiggerTail>(),
        ModContent.NPCType<NPCs.Bosses.Mechasting>(),
        ModContent.NPCType<NPCs.ProtectorWheel>(),
        ModContent.NPCType<NPCs.QuickCaribe>(),
        ModContent.NPCType<NPCs.RedAegisBonesHelmet>(),
        ModContent.NPCType<NPCs.RedAegisBonesHorned>(),
        ModContent.NPCType<NPCs.RedAegisBonesSparta>(),
        ModContent.NPCType<NPCs.RedAegisBonesSpike>(),
        ModContent.NPCType<NPCs.UnstableAnomaly>(),
        ModContent.NPCType<NPCs.UnvolanditeMite>(),
        ModContent.NPCType<NPCs.UnvolanditeMiteDigger>(),
        ModContent.NPCType<NPCs.Valkyrie>(),
        ModContent.NPCType<NPCs.VampireHarpy>(),
        ModContent.NPCType<NPCs.VorazylcumMite>(),
        ModContent.NPCType<NPCs.VorazylcumMiteDigger>(),
    };

    public static List<int> hornets = new List<int>
    {
        NPCID.Hornet,
        NPCID.MossHornet,
        NPCID.HornetFatty,
        NPCID.HornetHoney,
        NPCID.HornetLeafy,
        NPCID.HornetSpikey,
        NPCID.HornetStingy
    };

    public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
    {
        if (spawnInfo.player.Avalon().ZoneSkyFortress)
        {
            pool.Clear();
            pool.Add(ModContent.NPCType<NPCs.Valkyrie>(), 0.6f);
            pool.Add(ModContent.NPCType<NPCs.CloudBat>(), 0.9f);
        }
        if (spawnInfo.player.Avalon().ZoneContagion && !spawnInfo.player.InPillarZone())
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
        if (spawnInfo.player.Avalon().ZoneCaesium)
        {
            if (Main.hardMode)
            {
                pool.Clear();
                pool.Add(ModContent.NPCType<NPCs.CaesiumBrute>(), 1f);
                pool.Add(ModContent.NPCType<NPCs.CaesiumSeekerHead>(), 0.05f);
                pool.Add(ModContent.NPCType<NPCs.CaesiumStalker>(), 0.9f);
            }
        }
        if (spawnInfo.player.Avalon().ZoneDarkMatter && !spawnInfo.player.InPillarZone())
        {
            pool.Clear();
            pool.Add(ModContent.NPCType<NPCs.DarkMotherSlime>(), 0.5f);
            pool.Add(ModContent.NPCType<NPCs.DarkMatterSlime>(), 0.9f);
            pool.Add(ModContent.NPCType<NPCs.VampireHarpy>(), 0.9f);
            pool.Add(ModContent.NPCType<NPCs.MatterMan>(), 0.9f);
            pool.Add(ModContent.NPCType<NPCs.UnstableAnomaly>(), 0.9f);
        }
        if (spawnInfo.player.Avalon().ZoneHellcastle)
        {
            pool.Clear();
            pool.Add(NPCID.Demon, 0.2f);
            pool.Add(NPCID.RedDevil, 0.2f);
            pool.Add(ModContent.NPCType<NPCs.EctoHand>(), 0.3f);
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
        if (type == NPCID.Steampunker)
        {
            if (Main.bloodMoon || Main.eclipse)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Ammo.YellowSolution>());
                nextSlot++;
            }
            if (Main.LocalPlayer.ZoneJungle)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Ammo.LimeGreenSolution>());
                nextSlot++;
            }
            if (ExxoAvalonOriginsWorld.downedMechasting)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Ammo.BlackSolution>());
                shop.item[nextSlot].value = Item.buyPrice(0, 1);
                nextSlot++;
            }
        }
        if (type == NPCID.Pirate && NPC.downedPirates)
        {
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<FalseTreasureMap>());
            shop.item[nextSlot].value = Item.buyPrice(0, 4);
            nextSlot++;
        }
        if (type == NPCID.GoblinTinkerer && NPC.downedGoblins)
        {
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<GoblinRetreatOrder>());
            shop.item[nextSlot].value = Item.buyPrice(0, 4);
            nextSlot++;
        }
        if (type == NPCID.ArmsDealer && ModContent.GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode && Main.hardMode)
        {
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<MissileBolt>());
            nextSlot++;
        }
    }

    public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
    {
        // Advanced battle potion buff changes
        if (player.Avalon().advBattleBuff)
        {
            spawnRate = (int)(spawnRate * 0.35f);
            maxSpawns = (int)(maxSpawns * 2.5f);
        }
        // Advanced calming potion buff changes
        if (player.Avalon().advCalmingBuff)
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
        if (player.Avalon().enemySpawns2)
        {
            spawnRate = (int)(spawnRate * 0.2);
            maxSpawns = (int)(maxSpawns * 3f);
        }
        if (player.Avalon().ZoneContagion)
        {
            spawnRate = (int)(spawnRate * 0.65f);
            maxSpawns = (int)(maxSpawns * 1.3f);

            if (player.ZoneRockLayerHeight)
            {
                spawnRate = (int)(spawnRate * 0.65f);
                maxSpawns = (int)(maxSpawns * 1.3f);
            }
        }
        else if (player.Avalon().ZoneHellcastle)
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
        if (ExxoAvalonOriginsWorld.wos >= 0 || Main.wofNPCIndex >= 0)
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
            while (WorldGen.SolidTile(num4, num5 - num6) || Main.tile[num4, num5 - num6].LiquidAmount >= 100)
            {
                if (!WorldGen.SolidTile(num4, num5 + num6) && Main.tile[num4, num5 + num6].LiquidAmount < 100)
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
        int num7 = NPC.NewNPC(NPC.GetBossSpawnSource(Player.FindClosest(pos, 16, 16)), num2, num3, ModContent.NPCType<NPCs.Bosses.WallofSteel>(), 0);
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
                Main.NewText("Wall of Steel has awoken!", new Color(175, 75, 255));
                return;
            }
            if (Main.netMode == NetmodeID.Server)
            {
                ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("Wall of Steel has awoken!"), new Color(175, 75, 255));
            }
        }
    }

    /// <summary>
    /// Finds the closest NPC to the given position.
    /// </summary>
    /// <param name="pos">The origin position.</param>
    /// <param name="dist">The desired distance for the method to find the NPC from (in pixels).</param>
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

    /// <summary>
    /// Finds the closest NPC to the given position, excluding the given index of the NPC array.
    /// </summary>
    /// <param name="pos">The origin position.</param>
    /// <param name="dist">The desired distance for the method to find the NPC from (in pixels).</param>
    /// <param name="indexToExclude">The index of the NPC array to exclude.</param>
    /// <returns></returns>
    public static int FindClosestExcludeAnIndex(Vector2 pos, float dist, int indexToExclude)
    {
        int result = -1;
        float num = dist;
        for (int i = 0; i < Main.npc.Length; i++)
        {
            NPC nPC = Main.npc[i];
            if (nPC.active && !nPC.townNPC && nPC.lifeMax > 5 && Vector2.Distance(pos, nPC.Center) < num && nPC.whoAmI != indexToExclude)
            {
                num = Vector2.Distance(pos, nPC.Center);
                result = i;
            }
        }
        return result;
    }

    /// <summary>
    /// A method to choose a random Town NPC death messages.
    /// </summary>
    /// <param name="Type">The Town NPC's type.</param>
    /// <returns>The string containing the death message.</returns>
    public static string TownDeathMSG(int Type)
    {
        string result = "";
        if (Type == NPCID.Merchant)
        {
            int r = Main.rand.Next(5);
            if (r == 0) result += " tried to sell torches to a zombie.";
            if (r == 1) result += " made a grave error...";
            if (r == 2) result += " was slain...";
            if (r == 3) result += " was hanged with a bug net.";
            if (r == 4) result += " tried gold dust for the first time.";
        }
        else if (Type == NPCID.Nurse)
        {
            int r = Main.rand.Next(5);
            if (r == 0) result += " couldn't heal herself in a timely manner.";
            if (r == 1) result += " was expected to make a full recovery.";
            if (r == 2) result += "'s face wasn't sewn on well enough.";
            if (r == 3) result += " encountered a complication.";
            if (r == 4) result += "'s surgical strike was in error.";
        }
        else if (Type == NPCID.OldMan)
        {
            int r = Main.rand.Next(2);
            if (r == 0) result += " died of old age.";
            if (r == 1) result += " was slain...";

        }
        else if (Type == NPCID.ArmsDealer)
        {
            int r = Main.rand.Next(6);
            if (r == 0) result += "'s gun jammed.";
            if (r == 1) result += " fired a meteor bullet...";
            if (r == 2) result += " ran out of ammo.";
            if (r == 3) result += " was slain...";
            if (r == 4) result += " shot himself.";
            if (r == 5)
            {
                if (!Main.dayTime) result += " was caught.";
                else result += " shot himself.";
            }
        }
        else if (Type == NPCID.Dryad)
        {
            int r = Main.rand.Next(7);
            if (r == 0) result += "'s time was up...";
            if (r == 1) result += " choked on an herb.";
            if (r == 2) result += " turned into grass.";
            if (r == 3) result += " died.";
            if (r == 4) result += " was reduced to a fine paste...";
            if (r == 5) result += " was mauled by an unknown creature.";
            if (r == 6) result += " tripped on a corrupt vine.";
        }
        else if (Type == NPCID.Guide)
        {
            int r = Main.rand.Next(7);
            if (r == 0) result += " let too many zombies in.";
            if (r == 1) result += " was reading a history book...";
            if (r == 2) result += " was slain...";
            if (r == 3) result += " got impaled...";
            if (r == 4) result += " was the victim of dark magic.";
            if (r == 5) result += " was voodoo'd.";
            if (r == 6) result += " opened a door.";
        }
        else if (Type == NPCID.Demolitionist)
        {
            int r = Main.rand.Next(7);
            if (r == 0) result += " blew up.";
            if (r == 1) result += " threw a bomb at a mob, but it bounced back.";
            if (r == 2) result += "'s explosives were a little too sensitive...";
            if (r == 3) result += " made a dirty bomb.";
            if (r == 4) result += " was bombed.";
            if (r == 5) result += " went out with a bang.";
            if (r == 6) result += " became a true martyr.";
        }
        else if (Type == NPCID.Clothier)
        {
            int r = Main.rand.Next(6);
            if (r == 0) result += " was unknowningly cursed...";
            if (r == 1) result += " died from unknown causes.";
            if (r == 2) result += " was unravelled...";
            if (r == 3) result += " was eviscerated...";
            if (r == 4) result += " went back to the dungeon.";
            if (r == 5) result += " stitched himself up.";
        }
        else if (Type == NPCID.GoblinTinkerer)
        {
            int r = Main.rand.Next(6);
            if (r == 0) result += "'s contraption exploded.";
            if (r == 1) result += " tinkered with his life.";
            if (r == 2) result += " was crushed...";
            if (r == 3) result += " rocketed into the ceiling.";
            if (r == 4) result += " died from platinum poisoning.";
            if (r == 5) result += " was approached from the north.";
        }
        else if (Type == NPCID.Wizard)
        {
            int r = Main.rand.Next(7);
            if (r == 0) result += " forgot how to live.";
            if (r == 1) result += " cast too many spells...";
            if (r == 2) result += " was crushed...";
            if (r == 3) result += " watched his innards become outards...";
            if (r == 4) result += " made himself 'disappear.'";
            if (r == 5) result += " became a frog.";
            if (r == 6) result += "'s low armor class failed him.";
        }
        else if (Type == NPCID.SantaClaus)
        {
            int r = Main.rand.Next(2);
            if (r == 0) result += " had too much milk and cookies.";
            if (r == 1) result += " wasn't believed in.";
        }
        else if (Type == NPCID.Mechanic)
        {
            int r = Main.rand.Next(6);
            if (r == 0) result += "'s spine cracked...";
            if (r == 1) result += "'s engine broke down.";
            if (r == 2) result += " ran out of wire...";
            if (r == 3) result += " died.";
            if (r == 4) result += " dropped her contacts...";
            if (r == 5) result += " was removed from " + Main.worldName + ".";
        }
        else if (Type == NPCID.Truffle)
        {
            int r = Main.rand.Next(4);
            if (r == 0) result += " bit himself.";
            if (r == 1) result += " was eaten.";
            if (r == 2) result += " was slain...";
            if (r == 3) result += " is no longer a fun guy.";
        }
        else if (Type == NPCID.Steampunker)
        {
            int r = Main.rand.Next(5);
            if (r == 0) result += "'s time machine created a paradox...";
            if (r == 1) result += " slipped a cog.";
            if (r == 2) result += " died from unknown causes.";
            if (r == 3) result += " fell off an airship.";
            if (r == 4) result += " used her teleporter too fast.";
        }
        else if (Type == NPCID.DyeTrader)
        {
            int r = Main.rand.Next(6);
            if (r == 0) result += " fell into his dye.";
            if (r == 1) result += " was killed.";
            if (r == 2) result += " died from unknown causes.";
            if (r == 3) result += " was decapitated.";
            if (r == 4) result += " has dyed.";
            if (r == 5) result += " was dyed a deep chartreuse.";
        }
        else if (Type == NPCID.PartyGirl)
        {
            int r = Main.rand.Next(6);
            if (r == 0) result += " partied too hard.";
            if (r == 1) result += " inhaled too much confetti...";
            if (r == 2) result += " was crushed.";
            if (r == 3) result += " left the party.";
            if (r == 4) result += " was eaten.";
            if (r == 5) result += " was dissolved into the punch.";
        }
        else if (Type == NPCID.Cyborg)
        {
            int r = Main.rand.Next(7);
            if (r == 0) result += " was assimilated.";
            if (r == 1) result += "'s mechanisms were damaged beyond repair.";
            if (r == 2) result += " was crushed.";
            if (r == 3) result += " is '404 not found.'";
            if (r == 4) result += "'s implants were ripped out.";
            if (r == 5) result += " short-circuited.";
            if (r == 6) result += " malfunctioned.";
        }
        else if (Type == NPCID.Painter)
        {
            int r = Main.rand.Next(6);
            if (r == 0) result += " inhaled paint fumes.";
            if (r == 1) result += " tried to paint himself.";
            if (r == 2) result += "'s body was mangled.";
            if (r == 3) result += "'s paint was ripped off the canvas...";
            if (r == 4) result += "'s paint cracked.";
            if (r == 5) result += " inhaled asbestos.";
        }
        else if (Type == NPCID.WitchDoctor)
        {
            int r = Main.rand.Next(5);
            if (r == 0) result += "'s practice lead to his demise.";
            if (r == 1) result += " tried to embody life.";
            if (r == 2) result += "'s body was mangled.";
            if (r == 3) result += " was chopped up.";
            if (r == 4) result += " was eaten by an exotic insect.";
        }
        else if (Type == NPCID.Pirate)
        {
            int r = Main.rand.Next(5);
            if (r == 0) result += " choked on his gold tooth.";
            if (r == 1) result += " was hit by a cannonball.";
            if (r == 2) result += " was eviscerated.";
            if (r == 3) result += "'s other eye was removed.";
            if (r == 4) result += " lost his peg leg.";
        }
        else if (Type == NPCID.Stylist)
        {
            int r = Main.rand.Next(6);
            if (r == 0) result += " attempted to give a spider a trim.";
            if (r == 1) result += " was tied up.";
            if (r == 2) result += " was eviscerated.";
            if (r == 3) result += " got a little too snippy.";
            if (r == 4) result += " tried to give Cousin It a trim.";
            if (r == 5) result += " couldn't take the sight of spiders anymore.";
        }
        else if (Type == NPCID.TravellingMerchant)
        {
            int r = Main.rand.Next(6);
            if (r == 0) result += " has departed...";
            if (r == 1) result += " had INTERPOL problems.";
            if (r == 2) result += " was vaporized.";
            if (r == 3) result += " did not need a monster there.";
            if (r == 4) result += " tried to sell an exotic pitcher plant...";
            if (r == 5) result += " failed to make any sales.";
        }
        else if (Type == NPCID.Angler)
        {
            int r = Main.rand.Next(9);
            if (r == 0) result += " has left!";
            if (r == 1) result += " caught a fish!";
            if (r == 2) result += " fell into a ditch!";
            if (r == 3) result += " failed a test!";
            if (r == 4) result += " lost the game!";
            if (r == 5) result += " took off!";
            if (r == 6) result += " died.";
            if (r == 7) result += " found someone better to harass.";
            if (r == 8)
            {
                if (NPC.AnyNPCs(NPCID.Pirate))
                {
                    result += " was thrown overboard by " + Main.npc[FindATypeOfNPC(NPCID.Pirate)].GivenName + ".";
                }
                else result += " died.";
            }
        }
        else if (Type == NPCID.TaxCollector)
        {
            int r = Main.rand.Next(5);
            if (r == 0) result += " went to the wrong house.";
            if (r == 1) result += " collected counterfeit money.";
            if (r == 2) result += " had a hole in his pocket.";
            if (r == 3) result += " saw the ghost of " + Main.worldName + "'s past.";
            if (r == 4) result += " overtaxed himself.";
        }
        else if (Type == NPCID.DD2Bartender)
        {
            int r = Main.rand.Next(5);
            if (r == 0) result += " found himself on the wrong side of the bar.";
            if (r == 1) result += "'s sentries stopped working.";
            if (r == 2) result += " spontaneously combusted.";
            if (r == 3) result += " went through the wrong portal.";
            if (r == 4) result += " drank his feelings away.";
        }
        else if (Type == NPCID.Princess)
        {
            int r = Main.rand.Next(4);
            if (r == 0) result += " was taken away by a dragon.";
            if (r == 1) result += " was chained up in a tower.";
            if (r == 2) result += " swallowed her scepter.";
            if (r == 3) result += " tripped on her dress.";
        }
        else if (Type == NPCID.Golfer)
        {
            int r = Main.rand.Next(6);
            if (r == 0) result += " didn't yell \"fore!\"";
            if (r == 1) result += " was hit in the head by a golfball.";
            if (r == 2) result += " got a triple bogey.";
            if (r == 3) result += " went over par.";
            if (r == 4) result += " fell in a hole.";
            if (r == 5) result += "'s club hit back.";
        }
        else if (Type == NPCID.BestiaryGirl)
        {
            int r = Main.rand.Next(3);
            if (r == 0) result += " got rabies.";
            if (r == 1) result += " was put down.";
            if (r == 2) result += " got too comfortable with an exotic beast.";
        }
        else if (Type == ModContent.NPCType<NPCs.Iceman>())
        {
            int r = Main.rand.Next(7);
            if (r == 0) result += " froze.";
            if (r == 1) result += " melted.";
            if (r == 2) result += " has died.";
            if (r == 3) result += "'s ice was cracked.";
            if (r == 4)
            {
                if (NPC.AnyNPCs(NPCID.ArmsDealer))
                {
                    result += " was used to cool " + Main.npc[FindATypeOfNPC(NPCID.ArmsDealer)].GivenName + "'s drink.";
                }
                else result += " fell into a crevasse.";
            }
            if (r == 5) result += " fell into a crevasse";
            if (r == 6) result += " slipped.";
        }
        else if (Type == ModContent.NPCType<NPCs.Librarian>())
        {
            int r = Main.rand.Next(4);
            if (r == 0) result += " was nuked by a full squad.";
            if (r == 1) result += " fell victim to toxic world chat.";
            if (r == 2) result += " couldn't afford grade eighteen.";
            if (r == 3) result += " was slain by a boss cone attack.";
        }
        else result += " was slain...";
        return result;
    }

    /// <summary>
    /// Finds a type of NPC.
    /// </summary>
    /// <param name="type">The type of NPC to find.</param>
    /// <returns>The index of the found NPC in the Main.npc[] array.</returns>
    public static int FindATypeOfNPC(int type)
    {
        for (int i = 0; i < 200; i++)
        {
            if (type == Main.npc[i].type && Main.npc[i].active)
            {
                return i;
            }
        }
        return 0;
    }
    public override bool CheckDead(NPC npc)
    {
        if (npc.townNPC && npc.life <= 0)
        {
            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                Main.NewText(npc.FullName + TownDeathMSG(npc.type), new Color(178, 0, 90));
                npc.life = 0;
                npc.HitEffect(0, 10);
                npc.active = false;
                npc.NPCLoot();
                SoundEngine.PlaySound(SoundID.NPCKilled, (int)npc.position.X, (int)npc.position.Y, 1);
            }
            else
            {
                ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(npc.FullName + TownDeathMSG(npc.type)), new Color(178, 0, 90));
                NetMessage.SendData(MessageID.DamageNPC, -1, -1, null, npc.whoAmI, -1);
                int t = 0;
                int s = 1;
                switch (npc.type)
                {
                    case NPCID.Guide:
                        if (npc.GivenName == "Andrew") t = ItemID.GreenCap;
                        break;
                    case NPCID.DyeTrader:
                        if (Main.rand.Next(8) == 0) t = ItemID.DyeTradersScimitar;
                        break;
                    case NPCID.Painter:
                        if (Main.rand.Next(10) == 0) t = ItemID.PainterPaintballGun;
                        break;
                    case NPCID.DD2Bartender:
                        if (Main.rand.Next(8) == 0) t = ItemID.AleThrowingGlove;
                        break;
                    case NPCID.Stylist:
                        if (Main.rand.Next(8) == 0) t = ItemID.StylistKilLaKillScissorsIWish;
                        break;
                    case NPCID.Clothier:
                        t = ItemID.RedHat;
                        break;
                    case NPCID.PartyGirl:
                        if (Main.rand.Next(4) == 0)
                        {
                            t = ItemID.PartyGirlGrenade;
                            s = Main.rand.Next(30, 61);
                        }
                        break;
                    case NPCID.TaxCollector:
                        if (Main.rand.Next(8) == 0) t = 3351;
                        break;
                    case NPCID.TravellingMerchant:
                        t = ItemID.PeddlersHat;
                        break;
                }
                if (t > 0)
                {
                    int a = Item.NewItem(npc.GetItemSource_Loot(), npc.position, 16, 16, t, s, false);
                    NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.FromLiteral(""), a);
                }
                //Main.npc[npc.whoAmI].NPCLoot();
                SoundEngine.PlaySound(SoundID.NPCKilled, (int)npc.position.X, (int)npc.position.Y, 1);
            }
            return false;
        }
        return base.CheckDead(npc);
    }

    public static void InitializeNPCGroups()
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

    public override void OnKill(NPC npc)
    {
        if (!initialized)
        {
            InitializeNPCGroups();
            initialized = true;
        }
        if (npc.type == NPCID.SkeletronHead && !NPC.downedBoss3)
        {
            ExxoAvalonOriginsWorld.GenerateSulphur();
        }
        if (npc.type == NPCID.DungeonSpirit && Main.rand.Next(15) == 0 && Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneDungeon)
        {
            int proj = Projectile.NewProjectile(npc.GetSpawnSource_ForProjectile(), npc.position, npc.velocity, ModContent.ProjectileType<Projectiles.SpiritPoppy>(), 0, 0, Main.myPlayer);
            Main.projectile[proj].velocity.Y = -3.5f;
            Main.projectile[proj].velocity.X = Main.rand.Next(-45, 46) * 0.1f;
        }
    }
    public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
    {
        int maxValue50 = 50;
        int maxValue700 = 700;
        int maxValue1000 = 1000;
        if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].Avalon().lucky)
        {
            maxValue50 = 25;
            maxValue700 = 350;
            maxValue1000 = 500;
        }
        #region blocking imk tokens after phantasm
        if (imkCompat && DownedBossSystem.downedPhantasm)
        {
            Mod imk = ModLoader.GetMod("imkSushisMod");
            if (imk != null)
            {
                NPCLoader.blockLoot.Add(imk.Find<ModItem>("LootMartiansToken").Type);
                NPCLoader.blockLoot.Add(imk.Find<ModItem>("LootPlanteraToken").Type);
                NPCLoader.blockLoot.Add(imk.Find<ModItem>("LootHardmodeToken").Type);
            }
        }
        #endregion
        #region golem drops
        if (npc.type == NPCID.Golem && !Main.expertMode)
        {
            if (!NPC.downedGolemBoss)
            {
                Item.NewItem(npc.GetItemSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Picksaw, 1, false, -1, false);
                var list = new List<int>
                {
                    ItemID.Stynger,
                    ItemID.StaffofEarth,
                    ItemID.EyeoftheGolem,
                    ItemID.PossessedHatchet,
                    ItemID.GolemFist,
                    ItemID.SunStone,
                    ItemID.HeatRay,
                    ModContent.ItemType<Sunstorm>(),
                    ModContent.ItemType<EarthenInsignia>(),
                    ModContent.ItemType<HeartoftheGolem>()
                };
                int item1 = list.RemoveAtIndex(Main.rand.Next(list.Count));
                if (item1 == ItemID.Stynger)
                {
                    Item.NewItem(npc.GetItemSource_Loot(), npc.getRect(), ItemID.StyngerBolt, Main.rand.Next(60, 100), false, 0, false);
                }
                Item.NewItem(npc.GetItemSource_Loot(), npc.getRect(), item1, 1, false, -1, false);
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
                int item2 = list.RemoveAtIndex(Main.rand.Next(list.Count));
                if (item1 == ItemID.Stynger || item2 == ItemID.Stynger)
                {
                    Item.NewItem(npc.GetItemSource_Loot(), npc.getRect(), ItemID.StyngerBolt, Main.rand.Next(60, 100), false, 0, false);
                }
                Item.NewItem(npc.GetItemSource_Loot(), npc.getRect(), item1, 1, false, -1, false);
                Item.NewItem(npc.GetItemSource_Loot(), npc.getRect(), item2, 1, false, -1, false);
            }
            Item.NewItem(npc.GetItemSource_Loot(), npc.getRect(), ModContent.ItemType<EarthStone>(), Main.rand.Next(2) + 1, false, 0, false);
            Item.NewItem(npc.GetItemSource_Loot(), npc.getRect(), ItemID.BeetleHusk, Main.rand.Next(4, 9), false, 0, false);
            return;
        }
        #endregion
        if (npc.type == NPCID.WallofFlesh && !Main.expertMode)
        {
            NPCLoader.blockLoot.Add(ItemID.RangerEmblem);
            NPCLoader.blockLoot.Add(ItemID.SummonerEmblem);
            NPCLoader.blockLoot.Add(ItemID.WarriorEmblem);
            NPCLoader.blockLoot.Add(ItemID.SorcererEmblem);
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<NullEmblem>()));
        }
        if (imkCompat && !NPCID.Sets.CountsAsCritter[npc.type] && !npc.townNPC)
        {
            npcLoot.Add(ItemDropRule.ByCondition(new DropConditions.PostPhantasmHellcastleDrop(), ModContent.ItemType<Items.Tokens.HellcastleToken>(), 15));
            npcLoot.Add(ItemDropRule.ByCondition(new DropConditions.SuperhardmodePreArmaDrop(), ModContent.ItemType<Items.Tokens.SuperhardmodeToken>(), 15));
            npcLoot.Add(ItemDropRule.ByCondition(new DropConditions.PostArmageddonDrop(), ModContent.ItemType<Items.Tokens.DarkMatterToken>(), 15));
            npcLoot.Add(ItemDropRule.ByCondition(new DropConditions.PostMechastingDrop(), ModContent.ItemType<Items.Tokens.MechastingToken>(), 15));
            npcLoot.Add(ItemDropRule.ByCondition(new DropConditions.TropicsDrop(), ModContent.ItemType<Items.Tokens.TropicsToken>(), 15));
            npcLoot.Add(ItemDropRule.ByCondition(new DropConditions.ContagionDrop(), ModContent.ItemType<Items.Tokens.ContagionToken>(), 15));
        }
        npcLoot.Add(ItemDropRule.ByCondition(new DropConditions.DesertPostBeakDrop(), ModContent.ItemType<AncientTitaniumHeadgear>(), 150));
        npcLoot.Add(ItemDropRule.ByCondition(new DropConditions.DesertPostBeakDrop(), ModContent.ItemType<AncientTitaniumPlateMail>(), 150));
        npcLoot.Add(ItemDropRule.ByCondition(new DropConditions.DesertPostBeakDrop(), ModContent.ItemType<AncientTitaniumGreaves>(), 150));
        if (Main.hardMode && !NPCID.Sets.CountsAsCritter[npc.type] && !npc.townNPC)
        {
            npcLoot.Add(ItemDropRule.ByCondition(new DropConditions.ContagionDrop(), ItemID.SoulofNight, 5));
        }
        if (npc.type == NPCID.AngryBones || npc.type == NPCID.AngryBonesBig || npc.type == NPCID.AngryBonesBigHelmet || npc.type == NPCID.AngryBonesBigMuscle)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BlackWhetstone>(), 50));
        }
        if (Main.hardMode) npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsBloodMoonAndNotFromStatue(), ModContent.ItemType<BloodyWhetstone>(), 50));
        if (npc.type == NPCID.KingSlime) npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<BandofSlime>(), 3));
        npcLoot.Add(ItemDropRule.ByCondition(new DropConditions.IceBiomeDrop(), ModContent.ItemType<SoulofIce>(), 10));
        if (npc.type == NPCID.Duck || npc.type == NPCID.Duck2 || npc.type == NPCID.DuckWhite || npc.type == NPCID.DuckWhite2)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Other.Quack>(), maxValue1000));
        }
        if (!NPCID.Sets.CountsAsCritter[npc.type] && !npc.townNPC && Main.hardMode)
        {
            npcLoot.Add(ItemDropRule.ByCondition(new DropConditions.DungeonDrop(), ItemID.CobaltShield, 120));
        }
        if (!NPCID.Sets.CountsAsCritter[npc.type] && !npc.townNPC)
        {
            npcLoot.Add(ItemDropRule.OneFromOptions(600, new int[]
            {
                ItemID.EndurancePotion,
                ItemID.GravitationPotion,
                ItemID.InfernoPotion,
                ModContent.ItemType<StarbrightPotion>(),
                ModContent.ItemType<StrengthPotion>(),
                ModContent.ItemType<CrimsonPotion>(),
                ItemID.IronskinPotion,
                ItemID.SwiftnessPotion,
                ModContent.ItemType<ShockwavePotion>(),
                ItemID.MiningPotion,
                ItemID.ObsidianSkinPotion,
                ItemID.NightOwlPotion,
                ItemID.RagePotion,
                ItemID.RegenerationPotion,
                ItemID.SpelunkerPotion,
                ItemID.SonarPotion,
                ItemID.WrathPotion,
                ItemID.SummoningPotion,
                ItemID.HunterPotion,
                ItemID.FlipperPotion,
                ModContent.ItemType<GPSPotion>(),
                ItemID.GillsPotion
            }));
        }
        if (npc.type == NPCID.EaterofSouls)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RottenEye>(), 7));
        }
        if (npc.type == NPCID.DialatedEye)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.BlackLens, 40));
        }
        if (npc.type == NPCID.Crimera || npc.type == NPCID.FaceMonster || npc.type == NPCID.BloodCrawler || npc.type == NPCID.BloodCrawlerWall)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Patella>(), 7));
        }
        if (npc.type == NPCID.PincushionZombie || npc.type == NPCID.SlimedZombie || npc.type == NPCID.SwampZombie || npc.type == NPCID.TwiggyZombie || npc.type == NPCID.Zombie || npc.type == NPCID.ZombieEskimo || npc.type == NPCID.FemaleZombie || npc.type == NPCID.ZombieRaincoat)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RottenFlesh>(), 7));
        }
        if (npc.type == NPCID.UndeadMiner)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MinersPickaxe>(), 30));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MinersSword>(), 30));
        }
        if (npc.type == NPCID.HellArmoredBones || npc.type == NPCID.HellArmoredBonesSpikeShield || npc.type == NPCID.HellArmoredBonesMace || npc.type == NPCID.HellArmoredBonesSword)
        {
            npcLoot.Add(ItemDropRule.OneFromOptions(55, new int[]
            {
                ModContent.ItemType<HellArmoredHelmet>(),
                ModContent.ItemType<HellBlazingChestplate>(),
                ModContent.ItemType<HellArmoredGreaves>()
            }));
        }
        if (npc.type == NPCID.FloatyGross)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Patella>(), 5, 1, 2));
        }
        if (slimes.Contains(npc.type) && Main.hardMode)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.RoyalGel, 500));
        }
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Rock>(), 600));
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PointingLaser>(), 650));
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AlienDevice>(), 700));
        if (npc.type == NPCID.Clinger || npc.type == NPCID.Spazmatism)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GreekExtinguisher>(), maxValue50));
        }
        if (npc.type == NPCID.RaggedCaster)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SixHundredWattLightbulb>(), maxValue50));
        }
        if (npc.type == NPCID.ChaosElemental)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ChaosDust>(), 7, 2, 4));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ChaosCharm>(), 30));
        }
        if (npc.lifeMax >= 100)
        {
            npcLoot.Add(ItemDropRule.ByCondition(new DropConditions.SoulofHumidityDrop(), ModContent.ItemType<SoulofHumidity>(), 9));
        }
        if (npc.type == NPCID.BoneSerpentHead)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.Sunfury, 20));
        }
        if (undead.Contains(npc.type) && Main.hardMode)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<UndeadTalisman>(), 550));
        }
        #region shards
        if (toxic.Contains(npc.type))
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ToxinShard>(), 8));
        }
        if (undead.Contains(npc.type))
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<UndeadShard>(), 11));
        }
        if (fiery.Contains(npc.type))
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FireShard>(), 8));
        }
        if (watery.Contains(npc.type))
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<WaterShard>(), 8));
        }
        if (earthen.Contains(npc.type))
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EarthShard>(), 12));
        }
        if (flyer.Contains(npc.type))
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BreezeShard>(), 13));
        }
        if (frozen.Contains(npc.type))
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FrostShard>(), 10));
        }
        if (wicked.Contains(npc.type))
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CorruptShard>(), 9));
        }
        if (arcane.Contains(npc.type))
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ArcaneShard>(), 7));
        }
        #endregion
        #region tome mats
        if (npc.type == NPCID.Harpy || npc.type == NPCID.CaveBat || npc.type == NPCID.GiantBat || npc.type == NPCID.JungleBat)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RubybeadHerb>(), 7));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MysticalClaw>(), 9));
        }
        if (npc.type == NPCID.ChaosElemental || npc.type == NPCID.IceElemental || npc.type == NPCID.IchorSticker || npc.type == NPCID.Corruptor || npc.type == ModContent.NPCType<NPCs.Virus>())
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ElementDiamond>(), 6));
        }
        if (npc.type == NPCID.Hornet || npc.type == NPCID.BlackRecluse || npc.type == NPCID.MossHornet || npc.type == NPCID.HornetFatty || npc.type == NPCID.HornetHoney || npc.type == NPCID.HornetLeafy || npc.type == NPCID.HornetSpikey || npc.type == NPCID.HornetStingy || npc.type == NPCID.JungleCreeper || npc.type == NPCID.JungleCreeperWall || npc.type == NPCID.BlackRecluseWall)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<StrongVenom>(), 7));
        }
        if (npc.type == NPCID.Retinazer || npc.type == NPCID.Spazmatism || npc.type == NPCID.SkeletronPrime || npc.type == NPCID.TheDestroyer)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ScrollofTome>(), 3));
        }
        if (npc.type == NPCID.WyvernHead)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MysticalTotem>(), 2));
        }
        if (npc.type == NPCID.ManEater || npc.type == NPCID.Snatcher || npc.type == NPCID.AngryTrapper)
        {
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotFromStatue(), ModContent.ItemType<DewOrb>(), 25, 1, 1, 4));
        }
        if (npc.type == NPCID.GiantTortoise || npc.type == NPCID.IceTortoise || npc.type == NPCID.Vulture || npc.type == NPCID.FlyingFish || npc.type == NPCID.Unicorn)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ElementDust>(), 7));
        }
        if (npc.type == NPCID.CorruptSlime || npc.type == NPCID.Gastropod || npc.type == NPCID.IlluminantSlime || npc.type == NPCID.ToxicSludge || npc.type == NPCID.Crimslime || npc.type == NPCID.RainbowSlime || npc.type == NPCID.FloatyGross)
        {
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotFromStatue(), ModContent.ItemType<DewofHerbs>(), 25, 1, 1, 4));
        }
        #endregion
        if (npc.type == NPCID.Corruptor || npc.type == NPCID.SeekerHead)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RottenEye>(), 3, 1, 2));
        }
        if (npc.type == NPCID.Clown)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ClownBomb>(), 3, 2, 6));
        }
        if (npc.type == NPCID.Harpy)
        {
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsHardmode(), ItemID.ShinyRedBalloon, 50));
        }
        if (npc.type == NPCID.Corruptor || npc.type == NPCID.IchorSticker || npc.type == NPCID.ChaosElemental || npc.type == NPCID.IceElemental || npc.type == NPCID.AngryNimbus || npc.type == NPCID.GiantTortoise || npc.type == NPCID.RedDevil)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ChaosCrystal>(), 100));
        }
        if (npc.type == NPCID.Vulture)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Beak>(), 3));
        }
        #region paintings
        if (npc.type == NPCID.KingSlime)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BirthofaMonster>(), 9));
        }
        if (npc.type == NPCID.CrimsonAxe || npc.type == NPCID.CursedHammer || npc.type == NPCID.EnchantedSword)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Clash>(), 100));
        }
        if (npc.type == NPCID.EaterofSouls)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EvilOuroboros>(), maxValue700));
        }
        if (npc.type == NPCID.QueenBee)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FightoftheBumblebee>(), 8));
        }
        if (npc.type == NPCID.Plantera)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PlanterasRage>(), 15));
        }
        npcLoot.Add(ItemDropRule.ByCondition(new DropConditions.ContagionDrop(), ModContent.ItemType<RingofDisgust>(), maxValue700));
        npcLoot.Add(ItemDropRule.ByCondition(new DropConditions.DungeonDrop(), ModContent.ItemType<Trespassing>(), maxValue700));
        if (Main.hardMode) npcLoot.Add(ItemDropRule.ByCondition(new DropConditions.DungeonDrop(), ModContent.ItemType<ACometHasStruckGround>(), maxValue700));
        if (Main.eclipse) npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EclipseofDoom>(), maxValue700));
        #endregion
        if (npc.type == NPCID.GoblinSorcerer)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ChaosTome>(), 40));
        }
        if (npc.type == NPCID.RedDevil)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ForsakenRelic>(), 20));
        }
        if (npc.type == NPCID.PossessedArmor)
        {
            npcLoot.Add(ItemDropRule.OneFromOptions(80, new int[]
            {
                ModContent.ItemType<PossessedArmorHelmet>(),
                ModContent.ItemType<PossessedArmorChainmail>(),
                ModContent.ItemType<PossessedArmorGreaves>()
            }));
        }
        if (npc.type == NPCID.Plantera)
        {
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<LifeDew>(), 1, 10, 18));
        }
        if (npc.type == NPCID.SkeletonArcher || npc.type == NPCID.LavaSlime || npc.type == NPCID.MeteorHead || npc.type == NPCID.FireImp || npc.type == NPCID.Hellbat || npc.type == NPCID.Demon || npc.type == NPCID.HellArmoredBones || npc.type == NPCID.HellArmoredBonesSpikeShield || npc.type == NPCID.HellArmoredBonesMace || npc.type == NPCID.HellArmoredBonesSword)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Vortex>(), 200));
        }
        if (npc.type == NPCID.IchorSticker)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GoldenShield>(), 70));
        }
        if (npc.boss)
        {
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<StaminaCrystal>(), 4));
        }
        if (npc.type == NPCID.DungeonSpirit)
        {
            npcLoot.Add(ItemDropRule.OneFromOptions(33, new int[]
            {
                ModContent.ItemType<PhantomMask>(),
                ModContent.ItemType<PhantomShirt>(),
                ModContent.ItemType<PhantomPants>()
            }));
            npcLoot.Add(ItemDropRule.Common(ItemID.Ectoplasm, 5));
        }
        if (npc.type == NPCID.Mothron)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BrokenVigilanteTome>(), 5));
        }
        if (npc.type == NPCID.AngryNimbus)
        {
            NPCLoader.blockLoot.Add(ItemID.NimbusRod);
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<LivingLightningBlock>(), 1, 8, 16));
            npcLoot.Add(ItemDropRule.Common(ItemID.Cloud, 1, 10, 16));
            npcLoot.Add(ItemDropRule.Common(ItemID.RainCloud, 1, 2, 6));
        }
        if (npc.type == NPCID.WallofFlesh)
        {
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<FleshyTendril>(), 1, 13, 19));
        }
        if (npc.type == NPCID.EyeofCthulhu)
        {
            if (!Main.hardMode && !ModContent.GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode)
                npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<BloodyAmulet>(), 10, 1, 1, 3));
            if (Main.hardMode && !ModContent.GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode)
                npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<BloodyAmulet>(), 100, 1, 1, 15));
            if (Main.hardMode && ModContent.GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode)
                npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<BloodyAmulet>(), 100, 1, 1, 7));
        }
        if (npc.type == NPCID.Plantera)
        {
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ItemID.ChlorophyteOre, 1, 60, 120));
        }
        if (npc.type == NPCID.Shark)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DivingSuit>(), 60));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DivingPants>(), 40));
        }
        if (!NPCID.Sets.CountsAsCritter[npc.type] && !npc.townNPC)
        {
            if (Main.player[Main.myPlayer].Avalon().ethHeart)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Other.PlatinumHeart>(), 30));
            }
            if (Main.player[Main.myPlayer].Avalon().heartGolem)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Other.PlatinumHeart>(), 50));
            }
        }
        if (npc.type == NPCID.EyeofCthulhu && ExxoAvalonOriginsWorld.contagion)
        {
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<BacciliteOre>(), 1, 30, 87));
        }
    }
        //if (Main.shroomTiles > 30 && Main.rand.Next(11) == 0)
        //{
        //    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GlowingMushroom, Main.rand.Next(2) + 1);
        //}



        //if (Main.hardMode && (Main.rand.Next(2500) == 0 || (Main.rand.Next(1250) == 0 && Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].Avalon().lucky)) && Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].position.Y > (Main.maxTilesY - 190) * 16f)
        //{
        //    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Other.UnderworldKey>(), 1, false, 0, false);
        //}
        //if (Main.hardMode && (Main.rand.Next(2000) == 0 || (Main.rand.Next(1000) == 0 && Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].Avalon().lucky)) && Main.sandTiles > 50)
        //{
        //    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Other.DesertKey>(), 1, false, 0, false);
        //}

        // SHOULD RED PRESENT EVEN EXIST?
        //if (Main.xMas && npc.lifeMax > 1 && npc.damage > 0 && !npc.friendly && npc.type != NPCID.Slimer && npc.value > 0f && Main.rand.Next(60) == 0)
        //{
        //    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<RedPresent>(), 1, false, 0, false);
        //}
        //if (npc.lifeMax > 1 && npc.damage > 0 && !npc.friendly && npc.type != NPCID.Slimer && npc.value > 0f && Main.rand.Next(1000) == 0)
        //{
        //    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<RedPresent>(), 1, false, 0, false);
        //}

        

    public override void AI(NPC npc)
    {
        if (npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().lavaWalk)
        {
            npc.velocity = ExxoAvalonOrigins.LavaCollision(npc.position, npc.velocity, npc.width, npc.height, false);
        }
        if (npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().electrified && !npc.buffImmune[BuffID.Electrified])
        {
            npc.color = new Color(20, 240, 0, 100);
        }
        if (npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().frozen && !npc.buffImmune[ModContent.BuffType<Buffs.Frozen>()])
        {
            npc.velocity.X *= 0.2f;
            npc.color = new Color(0, 144, 255, 100);
        }
        if (npc.HasBuff(ModContent.BuffType<Buffs.IcySlowdown>()))
        {
            if (!npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().slowed)
            {
                npc.velocity.X *= 0.3f;
                npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().slowed = true;
            }
            npc.color = new Color(0, 144, 255, 100);
        }
    }

    public override void UpdateLifeRegen(NPC npc, ref int damage)
    {
        if (npc.HasBuff(ModContent.BuffType<Buffs.Electrified>()))
        {
            if (npc.lifeRegen > 0)
            {
                npc.lifeRegen = 0;
            }
            npc.lifeRegen -= 8;
            if (npc.velocity.X != 0)
            {
                npc.lifeRegen -= 32;
            }
            if (damage < 8) damage = 8;
        }
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
        if (npc.HasBuff(ModContent.BuffType<Buffs.Bleeding>()))
        {
            if (npc.lifeRegen > 0)
            {
                npc.lifeRegen = 0;
            }
            int mult = 4;
            if (npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().isBleedingHMBleed)
            {
                mult = 6;
            }
            npc.lifeRegen -= mult * npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().bleedStacks;
            if (damage < npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().bleedStacks)
            {
                damage = npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().bleedStacks;
            }
        }
        if (npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().malaria)
        {
            if (npc.lifeRegen > 0)
            {
                npc.lifeRegen = 0;
            }
            npc.lifeRegen -= 30;
            if (damage < 2)
            {
                damage = 2;
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
        if (npc.HasBuff(ModContent.BuffType<Buffs.Bleeding>()))
        {
            Dust.NewDust(npc.position, npc.width, npc.height, DustID.Blood);
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
        if (hornets.Contains(npc.type) && target.Avalon().beeRepel)
        {
            return false;
        }
        if (slimes.Contains(npc.type) && target.Avalon().slimeImmune)
        {
            return false;
        }

        return true;
    }

    public override void OnHitByItem(NPC npc, Player player, Item item, int damage, float knockback, bool crit)
    {
        if (player.Avalon().oblivionKill && Main.rand.Next(35) == 0 && !npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().noOneHitKill)
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
        #region shm mob scaling
        if (ModContent.GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode)
        {
            if (!shmMobs.Contains(npc.type))
            {
                if (Main.expertMode)
                {
                    if (npc.townNPC)
                    {
                        npc.lifeMax *= 2;
                    }
                    else if (npc.boss)
                    {
                        npc.lifeMax = (int)(npc.lifeMax * 1.2);
                        npc.damage = (int)(npc.damage * 1.3);
                    }
                    else
                    {
                        npc.lifeMax = (int)(npc.lifeMax * 1.6);
                        npc.damage = (int)(npc.damage * 1.5);
                    }
                }
                else
                {
                    if (npc.townNPC)
                    {
                        npc.lifeMax *= 2;
                    }
                    else if (npc.boss)
                    {
                        npc.lifeMax = (int)(npc.lifeMax * 1.5);
                        npc.damage *= 2;
                    }
                    else
                    {
                        npc.damage *= 2;
                        npc.lifeMax *= 2;
                    }
                }
            }
        }
        #endregion
    }
    public override bool PreKill(NPC npc)
    {
        if (npc.type == NPCID.Golem && !NPC.downedGolemBoss)
        {
            for (int a = 0; a < (int)(Main.maxTilesX * Main.maxTilesY * 0.00008); a++)
            {
                int x = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
                int y = WorldGen.genRand.Next((int)Main.rockLayer, Main.maxTilesY - 200);
                WorldGen.OreRunner(x, y, WorldGen.genRand.Next(4, 7), WorldGen.genRand.Next(4, 8), (ushort)ModContent.TileType<Tiles.Ores.SolariumOre>());
            }
            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                Main.NewText("Your world has been energized with Solarium!", 244, 167, 0);
            }
            else if (Main.netMode == NetmodeID.Server)
            {
                ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("Your world has been energized with Solarium!"), new Color(244, 167, 0));
            }
        }

        if (npc.type == NPCID.TheDestroyer || npc.type == NPCID.Retinazer || npc.type == NPCID.Spazmatism || npc.type == NPCID.SkeletronPrime)
        {
            if (!NPC.downedMechBossAny)
            {
                if ((npc.type == NPCID.Spazmatism && NPC.AnyNPCs(NPCID.Retinazer)) || (npc.type == NPCID.Retinazer && NPC.AnyNPCs(NPCID.Spazmatism)))
                {
                    return base.PreKill(npc);
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
                    WorldGen.OreRunner(i2, j2, WorldGen.genRand.Next(WorldGen.genRand.Next(2, 4), WorldGen.genRand.Next(4, 6)), WorldGen.genRand.Next(WorldGen.genRand.Next(3, 5), WorldGen.genRand.Next(4, 8)), (ushort)ModContent.TileType<Tiles.Ores.HallowedOre>());
                }
                if (Main.netMode == NetmodeID.SinglePlayer)
                {
                    Main.NewText("Your world has been blessed with Hallowed Ore!", new Color(220, 170, 0));
                }
                else if (Main.netMode == NetmodeID.Server)
                {
                    ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("Your world has been blessed with Hallowed Ore!"), new Color(220, 170, 0));
                }
            }
        }
        if (npc.type == NPCID.EyeofCthulhu && ExxoAvalonOriginsWorld.contagion)
        {
            NPCLoader.blockLoot.Add(ItemID.DemoniteOre);
            NPCLoader.blockLoot.Add(ItemID.CorruptSeeds);
        }

        return base.PreKill(npc);
    }

    public override void ResetEffects(NPC npc)
    {
        //npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().bleeding = false;
        npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().spikeTimer++;
        if (npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().spikeTimer >= 60 && !npc.townNPC && npc.lifeMax > 5 && !npc.dontTakeDamage && !npc.noTileCollide && ExxoAvalonOriginsCollisions.SpikeCollision2(npc.position, npc.width, npc.height))
        {
            npc.StrikeNPC(30 + (npc.defense / 2), 0f, 0, false, false);
            npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().spikeTimer = 0;
        }
    }
}
