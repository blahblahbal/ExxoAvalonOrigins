using System;
using System.Collections.Generic;
using ExxoAvalonOrigins.Items.Accessories;
using ExxoAvalonOrigins.Items.Consumables;
using ExxoAvalonOrigins.Items.Material;
using ExxoAvalonOrigins.Items.Placeable.Painting;
using ExxoAvalonOrigins.Items.Weapons.Magic;
using ExxoAvalonOrigins.Items.Weapons.Ranged;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs;

[AutoloadHead]
public class Iceman : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Iceman");
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
        NPC.lifeMax = 300;
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
        switch (Main.rand.Next(9))
        {
            case 0:
                return "Icik";
            case 1:
                return "Paul";
            case 2:
                return "Skaldak";
            case 3:
                return "Tom";
            case 4:
                return "Sisko";
            case 5:
                return "Lance";
            case 6:
                return "Adrian";
            case 7:
                return "Fred";
            default:
                return "Jules";
        }
    }
    public override string GetChat()
    {
        if (NPC.homeless)
        {
            switch (Main.rand.Next(3))
            {
                case 0:
                    return "Thanks for dislodging me from that glacier bit. If you hadn't, I'd have probably gone dormant and stayed there for eons!";
                case 1:
                    return "Wow! A human! I haven't seen one of you for... I don't know how long!";
                case 2:
                    return "Thanks for not flinging matches at me. I hate it when people do that.";
            }
        }
        else
        {
            if (!Main.dayTime && Main.rand.Next(5) == 0)
            {
                return "You turned off the sun! Awesome. Now I won't melt.";
            }
            switch (Main.rand.Next(11))
            {
                case 0:
                    return "Frigid waters are my home, but I feel more welcome in here.";
                case 1:
                    return "Could you turn down the sun? It's getting too hot in here. I'll melt!";
                case 2:
                    return "I hope you keep a spare bag of ice on you. I'm about to chunk off and I need something to replace my mass.";
                case 3:
                    return "Go long! I just made an ice football-- Get it?";
                case 4:
                    return "Can you move the hellstone in that chest away from me? I'm feeling ill from all the heat.";
                case 5:
                    return "Are you going to buy things? It makes me feel all warm and fuzzy inside when you do. Oh shoot, now I'm melting...";
                case 6:
                    return "My people are very cold sometimes. I remember one of them standing in the way of a large sea liner.";
                case 7:
                    return "You know what I think? That people don't notice my kind because we're ice to everyone.";
                case 8:
                    return "Contrary to popular belief, my people are warm-blooded. We just like the cold.";
                case 9:
                    return "Really?! I didn't know that-- Oh, sorry. Just talking to that bucket of ice over there.";
                case 10:
                    return "Elta ia jiopa kol nib rtiufaba. Oops, my translator broke. Oh, there it goes.";
            }
        }
        return "";
    }
    public static List<Item> CreateNewShop()
    {
        // create a list of item ids
        var itemIds = new List<int>();

        itemIds.Add(ItemID.FrostCore);
        itemIds.Add(ItemID.FrostMinnow);
        itemIds.Add(ModContent.ItemType<SoulofIce>());
        if (Main.LocalPlayer.ZoneSnow) itemIds.Add(ModContent.ItemType<Freezethrower>());
        itemIds.Add(ModContent.ItemType<FrostySpectacle>());
        itemIds.Add(ModContent.ItemType<BagofFrost>());
        itemIds.Add(ItemID.IceTorch);
        if (ExxoAvalonOriginsGlobalNPC.oblivionDead) itemIds.Add(ModContent.ItemType<HydrolythTrace>());
        if (Main.LocalPlayer.ZoneSnow) itemIds.Add(ModContent.ItemType<FreezeBolt>());
        // convert to a list of items
        var items = new List<Item>();
        foreach (int itemId in itemIds)
        {
            Item item = new Item();
            item.SetDefaults(itemId);
            items.Add(item);
        }
        return items;
    }
    public override void SetChatButtons(ref string button, ref string button2)
    {
        button = Language.GetTextValue("LegacyInterface.28");
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
        foreach (Item item in CreateNewShop())
        {
            // We dont want "empty" items and unloaded items to appear
            if (item == null || item.type == ItemID.None)
                continue;

            shop.item[nextSlot].SetDefaults(item.type);
            nextSlot++;
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
                    if (Main.tile[num225, num226] == null)
                    {
                        Main.tile[num225, num226] = new Tile();
                    }
                    if (Main.tile[num225, num226 - 1] == null)
                    {
                        Main.tile[num225, num226 - 1] = new Tile();
                    }
                    if (Main.tile[num225, num226 - 2] == null)
                    {
                        Main.tile[num225, num226 - 2] = new Tile();
                    }
                    if (Main.tile[num225, num226 - 3] == null)
                    {
                        Main.tile[num225, num226 - 3] = new Tile();
                    }
                    if (Main.tile[num225, num226 + 1] == null)
                    {
                        Main.tile[num225, num226 + 1] = new Tile();
                    }
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
                if (Main.tile[num229, num230] == null)
                {
                    Main.tile[num229, num230] = new Tile();
                }
                if (Main.tile[num229, num230 - 1] == null)
                {
                    Main.tile[num229, num230 - 1] = new Tile();
                }
                if (Main.tile[num229, num230 - 2] == null)
                {
                    Main.tile[num229, num230 - 2] = new Tile();
                }
                if (Main.tile[num229, num230 - 3] == null)
                {
                    Main.tile[num229, num230 - 3] = new Tile();
                }
                if (Main.tile[num229, num230 + 1] == null)
                {
                    Main.tile[num229, num230 + 1] = new Tile();
                }
                if (Main.tile[num229 - NPC.direction, num230 + 1] == null)
                {
                    Main.tile[num229 - NPC.direction, num230 + 1] = new Tile();
                }
                if (Main.tile[num229 + NPC.direction, num230 - 1] == null)
                {
                    Main.tile[num229 + NPC.direction, num230 - 1] = new Tile();
                }
                if (Main.tile[num229 + NPC.direction, num230 + 1] == null)
                {
                    Main.tile[num229 + NPC.direction, num230 + 1] = new Tile();
                }
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
                        else if (NPC.position.Y + NPC.height - num230 * 16 > 20f && Main.tile[num229, num230].HasUnactuatedTile && Main.tileSolid[Main.tile[num229, num230].TileType] && !Main.tile[num229, num230].topSlope())
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
                            if (Main.tile[num229, num230 + 1] == null)
                            {
                                Main.tile[num229, num230 + 1] = new Tile();
                            }
                            if (Main.tile[num229 - NPC.direction, num230 + 1] == null)
                            {
                                Main.tile[num229 - NPC.direction, num230 + 1] = new Tile();
                            }
                            if (Main.tile[num229, num230 + 2] == null)
                            {
                                Main.tile[num229, num230 + 2] = new Tile();
                            }
                            if (Main.tile[num229 - NPC.direction, num230 + 2] == null)
                            {
                                Main.tile[num229 - NPC.direction, num230 + 2] = new Tile();
                            }
                            if (Main.tile[num229, num230 + 3] == null)
                            {
                                Main.tile[num229, num230 + 3] = new Tile();
                            }
                            if (Main.tile[num229 - NPC.direction, num230 + 3] == null)
                            {
                                Main.tile[num229 - NPC.direction, num230 + 3] = new Tile();
                            }
                            if (Main.tile[num229, num230 + 4] == null)
                            {
                                Main.tile[num229, num230 + 4] = new Tile();
                            }
                            if (Main.tile[num229 - NPC.direction, num230 + 4] == null)
                            {
                                Main.tile[num229 - NPC.direction, num230 + 4] = new Tile();
                            }
                            else if (num216 >= NPC.homeTileX - 35 && num216 <= NPC.homeTileX + 35 && (!Main.tile[num229, num230 + 1].HasUnactuatedTile || !Main.tileSolid[Main.tile[num229, num230 + 1].TileType]) && (!Main.tile[num229 - NPC.direction, num230 + 1].HasTile || !Main.tileSolid[Main.tile[num229 - NPC.direction, num230 + 1].TileType]) && (!Main.tile[num229, num230 + 2].HasUnactuatedTile || !Main.tileSolid[Main.tile[num229, num230 + 2].TileType]) && (!Main.tile[num229 - NPC.direction, num230 + 2].HasTile || !Main.tileSolid[Main.tile[num229 - NPC.direction, num230 + 2].TileType]) && (!Main.tile[num229, num230 + 3].HasUnactuatedTile || !Main.tileSolid[Main.tile[num229, num230 + 3].TileType]) && (!Main.tile[num229 - NPC.direction, num230 + 3].HasTile || !Main.tileSolid[Main.tile[num229 - NPC.direction, num230 + 3].TileType]) && (!Main.tile[num229, num230 + 4].HasUnactuatedTile || !Main.tileSolid[Main.tile[num229, num230 + 4].TileType]) && (!Main.tile[num229 - NPC.direction, num230 + 4].HasUnactuatedTile || !Main.tileSolid[Main.tile[num229 - NPC.direction, num230 + 4].TileType]))
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
        damage = 65;
        knockback = 4f;
    }
    public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
    {
        cooldown = 30;
        randExtraCooldown = 30;
    }
    public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
    {
        projType = ModContent.ProjectileType<Projectiles.Icicle>();
        attackDelay = 1;
    }
    public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
    {
        multiplier = 12f;
        randomOffset = 2f;
    }
}