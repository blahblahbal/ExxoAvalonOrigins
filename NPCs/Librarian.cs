using System;
using ExxoAvalonOrigins.Items.Material;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs;

[AutoloadHead]
public class Librarian : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Librarian");
        Main.npcFrameCount[NPC.type] = 25;
        NPCID.Sets.ExtraFramesCount[NPC.type] = 9;
        NPCID.Sets.AttackFrameCount[NPC.type] = 4;
        NPCID.Sets.DangerDetectRange[NPC.type] = 600;
        NPCID.Sets.AttackType[NPC.type] = 0;
        NPCID.Sets.AttackTime[NPC.type] = 50;
        NPCID.Sets.AttackAverageChance[NPC.type] = 10;
    }

    public override void SetDefaults()
    {
        NPC.damage = 10;
        NPC.lifeMax = 250;
        NPC.townNPC = true;
        NPC.defense = 15;
        NPC.friendly = true;
        NPC.width = 18;
        NPC.aiStyle = 7;
        NPC.scale = 1f;
        NPC.height = 40;
        NPC.knockBackResist = 0.5f;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
        AnimationType = 22;
    }
    public override string TownNPCName()
    {
        switch (Main.rand.Next(12))
        {
            case 0:
                return "Juisefuss";
            case 1:
                return "Rob";
            case 2:
                return "Nasard";
            case 3:
                return "Helafrin";
            case 4:
                return "Ganjarule";
            case 5:
                return "Ryugrei";
            case 6:
                return "Baysh";
            case 7:
                return "Encanes";
            case 8:
                return "Dato";
            case 9:
                return "Callumn";
            case 10:
                return "Alkaido";
            default:
                return "Harry";
        }
    }
    public override string GetChat()
    {
        if (!Main.dayTime && Main.hardMode && Main.rand.Next(5) == 0)
        {
            return "My home is fraught with Wraiths. I'm deathly afraid of them; please keep them away.";
        }
        if (NPC.AnyNPCs(NPCID.DyeTrader) && Main.rand.Next(6) == 0)
        {
            return "Wow, " + Main.npc[ExxoAvalonOriginsGlobalNPC.FindATypeOfNPC(NPCID.DyeTrader)].GivenName + "'s services are free? Where I'm from, you have to pay an arm and a leg to dye clothes...";
        }
        switch (Main.rand.Next(11))
        {
            case 0:
                return "I come from a distant land, one where there are many races. It doesn't appear that you are any of those races, however.";
            case 1:
                return "This area is quite different from what I'm used to. People where I'm from spend loads to get virtual clothes.";
            case 2:
                return "...okay. I've got your grade seventeen fifth cast weapon materials ready. *click* Sorry, did you need something?";
            case 3:
                return "How do you people deal with being two-dimensional?";
            case 4:
                return "買點東西，什麼都買。 Oops, sorry about that. I was just speaking to a friend of mine from home.";
            case 5:
                return "Psionic Infusion, Spark, Chant of Chi, Tide Spirit, Sandburst Blast, Stone Smasher, macro. What? Just setting up my strategy for this nuke.";
            case 6:
                return "Pan Gu is the creator of my land. Who created yours? ... Redigit? Never heard of them.";
            case 7:
                return "You should consider the Tome Forge. It's my own invention!";
            case 8:
                return "When the Changelings took over the Western Steppes, I fled to this land. I already like it better.";
            case 9:
                return "Wait, you get loot after defeating a boss more than once per day?";
            case 10:
                return "It's very strange to not see fairies flying around everyone. Why don't you buy one from me?"; // add genie pets
        }
        return "";
    }
    public override void SetChatButtons(ref string button, ref string button2)
    {
        button = Language.GetTextValue("LegacyInterface.28");
    }
    public override bool CanTownNPCSpawn(int numTownNPCs, int money)
    {
        return NPC.downedBoss1;
    }
    public override void OnChatButtonClicked(bool firstButton, ref bool shop)
    {
        if (firstButton)
        {
            shop = true;
        }
    }
    public override void SetupShop(Chest shop, ref int nextSlot)
    {
        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Placeable.Crafting.TomeForge>());
        shop.item[nextSlot].value = Item.buyPrice(0, 7, 50);
        nextSlot++;
        if (Main.hardMode)
        {
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<MysticalTomePage>());
            shop.item[nextSlot].value = Item.buyPrice(0, 2);
            nextSlot++;
        }
        if (NPC.downedBoss1)
        {
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<MysticalClaw>());
            shop.item[nextSlot].value = Item.buyPrice(0, 2, 50);
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<RubybeadHerb>());
            shop.item[nextSlot].value = Item.buyPrice(0, 2, 50);
            nextSlot++;
        }
        if (Main.LocalPlayer.ZoneJungle)
        {
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<StrongVenom>());
            shop.item[nextSlot].value = Item.buyPrice(0, 2, 50);
            nextSlot++;
        }
        if (NPC.downedBoss3)
        {
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<ElementDust>());
            shop.item[nextSlot].value = Item.buyPrice(0, 2, 50);
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<DewOrb>());
            shop.item[nextSlot].value = Item.buyPrice(0, 2, 50);
            nextSlot++;
        }
        if (Main.hardMode)
        {
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<CarbonSteel>());
            shop.item[nextSlot].value = Item.buyPrice(0, 0, 20);
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<FineLumber>());
            shop.item[nextSlot].value = Item.buyPrice(0, 0, 20);
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Gravel>());
            shop.item[nextSlot].value = Item.buyPrice(0, 0, 20);
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Sandstone>());
            shop.item[nextSlot].value = Item.buyPrice(0, 0, 20);
            nextSlot++;
        }
        if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3 && Main.hardMode)
        {
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<MysticalTotem>());
            shop.item[nextSlot].value = Item.buyPrice(0, 7);
            nextSlot++;
        }
        if (NPC.downedPlantBoss && Main.hardMode)
        {
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<ElementDiamond>());
            shop.item[nextSlot].value = Item.buyPrice(0, 3, 50);
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<DewofHerbs>());
            shop.item[nextSlot].value = Item.buyPrice(0, 3, 50);
            nextSlot++;
        }
        if (ModContent.GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode && Main.hardMode)
        {
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<ScrollofTome>());
            shop.item[nextSlot].value = Item.buyPrice(0, 12, 50);
            nextSlot++;
            if (ExxoAvalonOriginsWorld.downedDragonLord)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<DragonOrb>());
                shop.item[nextSlot].value = Item.buyPrice(0, 30);
                nextSlot++;
            }
        }
    }
    public override void AI()
    {
        var flag22 = Main.raining;
        if (!Main.dayTime)
        {
            flag22 = true;
        }
        if (Main.eclipse)
        {
            flag22 = true;
        }
        var num216 = (int)(NPC.position.X + NPC.width / 2) / 16;
        var num217 = (int)(NPC.position.Y + NPC.height + 1f) / 16;
        ExxoAvalonOriginsGlobalNPC.savedIceman = true;
        if (NPC.homeTileX == -1 && NPC.homeTileY == -1 && NPC.velocity.Y == 0f)
        {
            NPC.homeTileX = (int)NPC.Center.X / 16;
            NPC.homeTileY = (int)(NPC.position.Y + NPC.height + 4f) / 16;
        }
        var flag23 = false;
        NPC.directionY = -1;
        if (NPC.direction == 0)
        {
            NPC.direction = 1;
        }
        for (var num218 = 0; num218 < 255; num218++)
        {
            if (Main.player[num218].active && Main.player[num218].talkNPC == NPC.whoAmI)
            {
                flag23 = true;
                if (NPC.ai[0] != 0f)
                {
                    NPC.netUpdate = true;
                }
                NPC.ai[0] = 0f;
                NPC.ai[1] = 300f;
                NPC.ai[2] = 100f;
                if (Main.player[num218].position.X + Main.player[num218].width / 2 < NPC.position.X + NPC.width / 2)
                {
                    NPC.direction = -1;
                }
                else
                {
                    NPC.direction = 1;
                }
            }
        }
        if (NPC.ai[3] > 0f)
        {
            NPC.life = -1;
            NPC.HitEffect(0, 10.0);
            NPC.active = false;
        }
        var num219 = NPC.homeTileY;
        if (Main.netMode != NetmodeID.MultiplayerClient && NPC.homeTileY > 0)
        {
            while (!WorldGen.SolidTile(NPC.homeTileX, num219) && num219 < Main.maxTilesY - 20)
            {
                num219++;
            }
        }
        if (Main.tile[num216, num217] == null)
        {
            return;
        }
        if (Main.netMode != NetmodeID.MultiplayerClient && NPC.townNPC && (flag22 || Main.tileDungeon[Main.tile[num216, num217].TileType]) && (num216 != NPC.homeTileX || num217 != num219) && !NPC.homeless)
        {
            var flag24 = true;
            for (var num220 = 0; num220 < 2; num220++)
            {
                var rectangle3 = new Rectangle((int)(NPC.position.X + NPC.width / 2 - NPC.sWidth / 2 - NPC.safeRangeX), (int)(NPC.position.Y + NPC.height / 2 - NPC.sHeight / 2 - NPC.safeRangeY), NPC.sWidth + NPC.safeRangeX * 2, NPC.sHeight + NPC.safeRangeY * 2);
                if (num220 == 1)
                {
                    rectangle3 = new Rectangle(NPC.homeTileX * 16 + 8 - NPC.sWidth / 2 - NPC.safeRangeX, num219 * 16 + 8 - NPC.sHeight / 2 - NPC.safeRangeY, NPC.sWidth + NPC.safeRangeX * 2, NPC.sHeight + NPC.safeRangeY * 2);
                }
                for (var num221 = 0; num221 < 255; num221++)
                {
                    if (Main.player[num221].active)
                    {
                        var rectangle4 = new Rectangle((int)Main.player[num221].position.X, (int)Main.player[num221].position.Y, Main.player[num221].width, Main.player[num221].height);
                        if (rectangle4.Intersects(rectangle3))
                        {
                            flag24 = false;
                            break;
                        }
                    }
                    if (!flag24)
                    {
                        break;
                    }
                }
            }
            if (flag24)
            {
                if (!Collision.SolidTiles(NPC.homeTileX - 1, NPC.homeTileX + 1, num219 - 3, num219 - 1))
                {
                    NPC.velocity.X = 0f;
                    NPC.velocity.Y = 0f;
                    NPC.position.X = NPC.homeTileX * 16 + 8 - NPC.width / 2;
                    NPC.position.Y = num219 * 16 - NPC.height - 0.1f;
                    NPC.netUpdate = true;
                }
                else
                {
                    NPC.homeless = true;
                    WorldGen.QuickFindHome(NPC.whoAmI);
                }
            }
        }
        if (NPC.ai[0] == 0f)
        {
            if (NPC.ai[2] > 0f)
            {
                NPC.ai[2] -= 1f;
            }
            if (flag22 && !flag23)
            {
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    if (num216 == NPC.homeTileX && num217 == num219)
                    {
                        if (NPC.velocity.X != 0f)
                        {
                            NPC.netUpdate = true;
                        }
                        if (NPC.velocity.X > 0.1)
                        {
                            NPC.velocity.X = NPC.velocity.X - 0.1f;
                        }
                        else if (NPC.velocity.X < -0.1)
                        {
                            NPC.velocity.X = NPC.velocity.X + 0.1f;
                        }
                        else
                        {
                            NPC.velocity.X = 0f;
                        }
                    }
                    else if (!flag23)
                    {
                        if (num216 > NPC.homeTileX)
                        {
                            NPC.direction = -1;
                        }
                        else
                        {
                            NPC.direction = 1;
                        }
                        NPC.ai[0] = 1f;
                        NPC.ai[1] = 200 + Main.rand.Next(200);
                        NPC.ai[2] = 0f;
                        NPC.netUpdate = true;
                    }
                }
            }
            else
            {
                if (NPC.velocity.X > 0.1)
                {
                    NPC.velocity.X = NPC.velocity.X - 0.1f;
                }
                else if (NPC.velocity.X < -0.1)
                {
                    NPC.velocity.X = NPC.velocity.X + 0.1f;
                }
                else
                {
                    NPC.velocity.X = 0f;
                }
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    if (NPC.ai[1] > 0f)
                    {
                        NPC.ai[1] -= 1f;
                    }
                    if (NPC.ai[1] <= 0f)
                    {
                        NPC.ai[0] = 1f;
                        NPC.ai[1] = 200 + Main.rand.Next(200);
                        NPC.ai[2] = 0f;
                        NPC.netUpdate = true;
                    }
                }
            }
            if (Main.netMode != NetmodeID.MultiplayerClient && (!flag22 || (num216 == NPC.homeTileX && num217 == num219)))
            {
                if (num216 < NPC.homeTileX - 25 || num216 > NPC.homeTileX + 25)
                {
                    if (NPC.ai[2] == 0f)
                    {
                        if (num216 < NPC.homeTileX - 50 && NPC.direction == -1)
                        {
                            NPC.direction = 1;
                            NPC.netUpdate = true;
                            return;
                        }
                        if (num216 > NPC.homeTileX + 50 && NPC.direction == 1)
                        {
                            NPC.direction = -1;
                            NPC.netUpdate = true;
                            return;
                        }
                    }
                }
                else if (Main.rand.Next(80) == 0 && NPC.ai[2] == 0f)
                {
                    NPC.ai[2] = 200f;
                    NPC.direction *= -1;
                    NPC.netUpdate = true;
                    return;
                }
            }
        }
        else if (NPC.ai[0] == 1f)
        {
            if (Main.netMode != NetmodeID.MultiplayerClient && flag22 && num216 == NPC.homeTileX && num217 == NPC.homeTileY)
            {
                NPC.ai[0] = 0f;
                NPC.ai[1] = 200 + Main.rand.Next(200);
                NPC.ai[2] = 60f;
                NPC.netUpdate = true;
                return;
            }
            if (Main.netMode != NetmodeID.MultiplayerClient && !NPC.homeless && !Main.tileDungeon[Main.tile[num216, num217].TileType] && (num216 < NPC.homeTileX - 35 || num216 > NPC.homeTileX + 35))
            {
                if (NPC.position.X < NPC.homeTileX * 16 && NPC.direction == -1)
                {
                    NPC.ai[1] -= 5f;
                }
                else if (NPC.position.X > NPC.homeTileX * 16 && NPC.direction == 1)
                {
                    NPC.ai[1] -= 5f;
                }
            }
            NPC.ai[1] -= 1f;
            if (NPC.ai[1] <= 0f)
            {
                NPC.ai[0] = 0f;
                NPC.ai[1] = 300 + Main.rand.Next(300);
                NPC.ai[1] -= Main.rand.Next(100);
                NPC.ai[2] = 60f;
                NPC.netUpdate = true;
            }
            if (NPC.closeDoor && ((NPC.position.X + NPC.width / 2) / 16f > NPC.doorX + 2 || (NPC.position.X + NPC.width / 2) / 16f < NPC.doorX - 2))
            {
                var flag25 = WorldGen.CloseDoor(NPC.doorX, NPC.doorY, false);
                if (flag25)
                {
                    NPC.closeDoor = false;
                    NetMessage.SendData(MessageID.ChangeDoor, -1, -1, NetworkText.FromLiteral(""), 1, NPC.doorX, NPC.doorY, NPC.direction, 0);
                }
                if ((NPC.position.X + NPC.width / 2) / 16f > NPC.doorX + 4 || (NPC.position.X + NPC.width / 2) / 16f < NPC.doorX - 4 || (NPC.position.Y + NPC.height / 2) / 16f > NPC.doorY + 4 || (NPC.position.Y + NPC.height / 2) / 16f < NPC.doorY - 4)
                {
                    NPC.closeDoor = false;
                }
            }
            var num222 = 1f;
            var num223 = 0.07f;
            if (NPC.velocity.X < -num222 || NPC.velocity.X > num222)
            {
                if (NPC.velocity.Y == 0f)
                {
                    NPC.velocity *= 0.8f;
                }
            }
            else if (NPC.velocity.X < num222 && NPC.direction == 1)
            {
                NPC.velocity.X = NPC.velocity.X + num223;
                if (NPC.velocity.X > num222)
                {
                    NPC.velocity.X = num222;
                }
            }
            else if (NPC.velocity.X > -num222 && NPC.direction == -1)
            {
                NPC.velocity.X = NPC.velocity.X - num223;
                if (NPC.velocity.X > num222)
                {
                    NPC.velocity.X = num222;
                }
            }
            var flag26 = (NPC.homeTileY - 2) * 16 <= NPC.position.Y;
            if ((NPC.direction == 1 && NPC.position.Y + NPC.width / 2 > NPC.homeTileX * 16) || (NPC.direction == -1 && NPC.position.Y + NPC.width / 2 < NPC.homeTileX * 16))
            {
                flag26 = true;
            }
            if (NPC.velocity.Y >= 0f)
            {
                var num224 = 0;
                if (NPC.velocity.X < 0f)
                {
                    num224 = -1;
                }
                if (NPC.velocity.X > 0f)
                {
                    num224 = 1;
                }
                var vector22 = NPC.position;
                vector22.X += NPC.velocity.X;
                var num225 = (int)((vector22.X + NPC.width / 2 + (NPC.width / 2 + 1) * num224) / 16f);
                var num226 = (int)((vector22.Y + NPC.height - 1f) / 16f);
                if (num225 * 16 < vector22.X + NPC.width && num225 * 16 + 16 > vector22.X)
                {
                    //if (Main.tile[num225, num226] == null)
                    //{
                    //    Main.tile[num225, num226] = new Tile();
                    //}
                    //if (Main.tile[num225, num226 - 1] == null)
                    //{
                    //    Main.tile[num225, num226 - 1] = new Tile();
                    //}
                    //if (Main.tile[num225, num226 - 2] == null)
                    //{
                    //    Main.tile[num225, num226 - 2] = new Tile();
                    //}
                    //if (Main.tile[num225, num226 - 3] == null)
                    //{
                    //    Main.tile[num225, num226 - 3] = new Tile();
                    //}
                    //if (Main.tile[num225, num226 + 1] == null)
                    //{
                    //    Main.tile[num225, num226 + 1] = new Tile();
                    //}
                    if (((Main.tile[num225, num226].HasUnactuatedTile && !Main.tile[num225, num226].TopSlope && !Main.tile[num225, num226 - 1].TopSlope && ((Main.tileSolid[Main.tile[num225, num226].TileType] && !Main.tileSolidTop[Main.tile[num225, num226].TileType]) || (flag26 && Main.tileSolidTop[Main.tile[num225, num226].TileType] && Main.tile[num225, num226].TileFrameY == 0 && (!Main.tileSolid[Main.tile[num225, num226 - 1].TileType] || !Main.tile[num225, num226 - 1].HasUnactuatedTile) && Main.tile[num225, num226].TileType != 16 && Main.tile[num225, num226].TileType != 18 && Main.tile[num225, num226].TileType != 134 && Main.tile[num225, num226].TileType != 360))) || (Main.tile[num225, num226 - 1].IsHalfBlock && Main.tile[num225, num226 - 1].HasUnactuatedTile)) && (!Main.tile[num225, num226 - 1].HasUnactuatedTile || !Main.tileSolid[Main.tile[num225, num226 - 1].TileType] || Main.tileSolidTop[Main.tile[num225, num226 - 1].TileType] || (Main.tile[num225, num226 - 1].IsHalfBlock && (!Main.tile[num225, num226 - 4].HasUnactuatedTile || !Main.tileSolid[Main.tile[num225, num226 - 4].TileType] || Main.tileSolidTop[Main.tile[num225, num226 - 4].TileType]))) && (!Main.tile[num225, num226 - 2].HasUnactuatedTile || !Main.tileSolid[Main.tile[num225, num226 - 2].TileType] || Main.tileSolidTop[Main.tile[num225, num226 - 2].TileType]) && (!Main.tile[num225, num226 - 3].HasUnactuatedTile || !Main.tileSolid[Main.tile[num225, num226 - 3].TileType] || Main.tileSolidTop[Main.tile[num225, num226 - 3].TileType]) && (!Main.tile[num225 - num224, num226 - 3].HasUnactuatedTile || !Main.tileSolid[Main.tile[num225 - num224, num226 - 3].TileType] || Main.tileSolidTop[Main.tile[num225 - num224, num226 - 3].TileType]))
                    {
                        float num227 = num226 * 16;
                        if (Main.tile[num225, num226].IsHalfBlock)
                        {
                            num227 += 8f;
                        }
                        if (Main.tile[num225, num226 - 1].IsHalfBlock)
                        {
                            num227 -= 8f;
                        }
                        if (num227 < vector22.Y + NPC.height)
                        {
                            var num228 = vector22.Y + NPC.height - num227;
                            if (num228 <= 16.1)
                            {
                                NPC.gfxOffY += NPC.position.Y + NPC.height - num227;
                                NPC.position.Y = num227 - NPC.height;
                                if (num228 < 9f)
                                {
                                    NPC.stepSpeed = 1f;
                                }
                                else
                                {
                                    NPC.stepSpeed = 2f;
                                }
                            }
                        }
                    }
                }
            }
            if (NPC.velocity.Y == 0f)
            {
                if (NPC.position.X == NPC.ai[2])
                {
                    NPC.direction *= -1;
                }
                NPC.ai[2] = -1f;
                var num229 = (int)((NPC.position.X + NPC.width / 2 + 15 * NPC.direction) / 16f);
                var num230 = (int)((NPC.position.Y + NPC.height - 16f) / 16f);
                //if (Main.tile[num229, num230] == null)
                //{
                //    Main.tile[num229, num230] = new Tile();
                //}
                //if (Main.tile[num229, num230 - 1] == null)
                //{
                //    Main.tile[num229, num230 - 1] = new Tile();
                //}
                //if (Main.tile[num229, num230 - 2] == null)
                //{
                //    Main.tile[num229, num230 - 2] = new Tile();
                //}
                //if (Main.tile[num229, num230 - 3] == null)
                //{
                //    Main.tile[num229, num230 - 3] = new Tile();
                //}
                //if (Main.tile[num229, num230 + 1] == null)
                //{
                //    Main.tile[num229, num230 + 1] = new Tile();
                //}
                //if (Main.tile[num229 - NPC.direction, num230 + 1] == null)
                //{
                //    Main.tile[num229 - NPC.direction, num230 + 1] = new Tile();
                //}
                //if (Main.tile[num229 + NPC.direction, num230 - 1] == null)
                //{
                //    Main.tile[num229 + NPC.direction, num230 - 1] = new Tile();
                //}
                //if (Main.tile[num229 + NPC.direction, num230 + 1] == null)
                //{
                //    Main.tile[num229 + NPC.direction, num230 + 1] = new Tile();
                //}
                if (NPC.townNPC && Main.tile[num229, num230 - 2].HasUnactuatedTile && Main.tile[num229, num230 - 2].TileType == 10 && (Main.rand.Next(10) == 0 || flag22))
                {
                    if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        var flag27 = WorldGen.OpenDoor(num229, num230 - 2, NPC.direction);
                        if (flag27)
                        {
                            NPC.closeDoor = true;
                            NPC.doorX = num229;
                            NPC.doorY = num230 - 2;
                            NetMessage.SendData(MessageID.ChangeDoor, -1, -1, NetworkText.FromLiteral(""), 0, num229, num230 - 2, NPC.direction, 0);
                            NPC.netUpdate = true;
                            NPC.ai[1] += 80f;
                            return;
                        }
                        if (WorldGen.OpenDoor(num229, num230 - 2, -NPC.direction))
                        {
                            NPC.closeDoor = true;
                            NPC.doorX = num229;
                            NPC.doorY = num230 - 2;
                            NetMessage.SendData(MessageID.ChangeDoor, -1, -1, NetworkText.FromLiteral(""), 0, num229, num230 - 2, -NPC.direction, 0);
                            NPC.netUpdate = true;
                            NPC.ai[1] += 80f;
                            return;
                        }
                        NPC.direction *= -1;
                        NPC.netUpdate = true;
                        return;
                    }
                }
                else
                {
                    if ((NPC.velocity.X < 0f && NPC.spriteDirection == -1) || (NPC.velocity.X > 0f && NPC.spriteDirection == 1))
                    {
                        if (Main.tile[num229, num230 - 2].HasUnactuatedTile && Main.tileSolid[Main.tile[num229, num230 - 2].TileType] && !Main.tileSolidTop[Main.tile[num229, num230 - 2].TileType])
                        {
                            if ((NPC.direction == 1 && !Collision.SolidTiles(num229 - 2, num229 - 1, num230 - 5, num230 - 1)) || (NPC.direction == -1 && !Collision.SolidTiles(num229 + 1, num229 + 2, num230 - 5, num230 - 1)))
                            {
                                if (!Collision.SolidTiles(num229, num229, num230 - 5, num230 - 3))
                                {
                                    NPC.velocity.Y = -6f;
                                    NPC.netUpdate = true;
                                }
                                else
                                {
                                    NPC.direction *= -1;
                                    NPC.netUpdate = true;
                                }
                            }
                            else
                            {
                                NPC.direction *= -1;
                                NPC.netUpdate = true;
                            }
                        }
                        else if (Main.tile[num229, num230 - 1].HasUnactuatedTile && Main.tileSolid[Main.tile[num229, num230 - 1].TileType] && !Main.tileSolidTop[Main.tile[num229, num230 - 1].TileType])
                        {
                            if ((NPC.direction == 1 && !Collision.SolidTiles(num229 - 2, num229 - 1, num230 - 4, num230 - 1)) || (NPC.direction == -1 && !Collision.SolidTiles(num229 + 1, num229 + 2, num230 - 4, num230 - 1)))
                            {
                                if (!Collision.SolidTiles(num229, num229, num230 - 4, num230 - 2))
                                {
                                    NPC.velocity.Y = -5f;
                                    NPC.netUpdate = true;
                                }
                                else
                                {
                                    NPC.direction *= -1;
                                    NPC.netUpdate = true;
                                }
                            }
                            else
                            {
                                NPC.direction *= -1;
                                NPC.netUpdate = true;
                            }
                        }
                        else if (NPC.position.Y + NPC.height - num230 * 16 > 20f && Main.tile[num229, num230].HasUnactuatedTile && Main.tileSolid[Main.tile[num229, num230].TileType] && !Main.tile[num229, num230].TopSlope)
                        {
                            if ((NPC.direction == 1 && !Collision.SolidTiles(num229 - 2, num229, num230 - 3, num230 - 1)) || (NPC.direction == -1 && !Collision.SolidTiles(num229, num229 + 2, num230 - 3, num230 - 1)))
                            {
                                NPC.velocity.Y = -4.4f;
                                NPC.netUpdate = true;
                            }
                            else
                            {
                                NPC.direction *= -1;
                                NPC.netUpdate = true;
                            }
                        }
                        try
                        {
                            //if (Main.tile[num229, num230 + 1] == null)
                            //{
                            //    Main.tile[num229, num230 + 1] = new Tile();
                            //}
                            //if (Main.tile[num229 - NPC.direction, num230 + 1] == null)
                            //{
                            //    Main.tile[num229 - NPC.direction, num230 + 1] = new Tile();
                            //}
                            //if (Main.tile[num229, num230 + 2] == null)
                            //{
                            //    Main.tile[num229, num230 + 2] = new Tile();
                            //}
                            //if (Main.tile[num229 - NPC.direction, num230 + 2] == null)
                            //{
                            //    Main.tile[num229 - NPC.direction, num230 + 2] = new Tile();
                            //}
                            //if (Main.tile[num229, num230 + 3] == null)
                            //{
                            //    Main.tile[num229, num230 + 3] = new Tile();
                            //}
                            //if (Main.tile[num229 - NPC.direction, num230 + 3] == null)
                            //{
                            //    Main.tile[num229 - NPC.direction, num230 + 3] = new Tile();
                            //}
                            //if (Main.tile[num229, num230 + 4] == null)
                            //{
                            //    Main.tile[num229, num230 + 4] = new Tile();
                            //}
                            //if (Main.tile[num229 - NPC.direction, num230 + 4] == null)
                            //{
                            //    Main.tile[num229 - NPC.direction, num230 + 4] = new Tile();
                            //}
                            if (num216 >= NPC.homeTileX - 35 && num216 <= NPC.homeTileX + 35 && (!Main.tile[num229, num230 + 1].HasUnactuatedTile || !Main.tileSolid[Main.tile[num229, num230 + 1].TileType]) && (!Main.tile[num229 - NPC.direction, num230 + 1].HasTile || !Main.tileSolid[Main.tile[num229 - NPC.direction, num230 + 1].TileType]) && (!Main.tile[num229, num230 + 2].HasUnactuatedTile || !Main.tileSolid[Main.tile[num229, num230 + 2].TileType]) && (!Main.tile[num229 - NPC.direction, num230 + 2].HasTile || !Main.tileSolid[Main.tile[num229 - NPC.direction, num230 + 2].TileType]) && (!Main.tile[num229, num230 + 3].HasUnactuatedTile || !Main.tileSolid[Main.tile[num229, num230 + 3].TileType]) && (!Main.tile[num229 - NPC.direction, num230 + 3].HasTile || !Main.tileSolid[Main.tile[num229 - NPC.direction, num230 + 3].TileType]) && (!Main.tile[num229, num230 + 4].HasUnactuatedTile || !Main.tileSolid[Main.tile[num229, num230 + 4].TileType]) && (!Main.tile[num229 - NPC.direction, num230 + 4].HasUnactuatedTile || !Main.tileSolid[Main.tile[num229 - NPC.direction, num230 + 4].TileType]))
                            {
                                NPC.direction *= -1;
                                NPC.velocity.X = NPC.velocity.X * -1f;
                                NPC.netUpdate = true;
                            }
                        }
                        catch
                        {
                        }
                        if (NPC.velocity.Y < 0f)
                        {
                            NPC.ai[2] = NPC.position.X;
                        }
                    }
                    if (NPC.velocity.Y < 0f && NPC.wet)
                    {
                        NPC.velocity.Y = NPC.velocity.Y * 1.2f;
                    }
                }
            }
        }
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
    public override void TownNPCAttackStrength(ref int damage, ref float knockback)
    {
        damage = 22;
        knockback = 2f;
    }
    public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
    {
        cooldown = 30;
        randExtraCooldown = 30;
    }
    public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
    {
        projType = ProjectileID.WaterBolt;
        attackDelay = 1;
    }
    public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
    {
        multiplier = 12f;
        randomOffset = 2f;
    }
}