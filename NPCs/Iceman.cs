using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExxoAvalonOrigins.Items.Accessories;
using ExxoAvalonOrigins.Items.Consumables;
using ExxoAvalonOrigins.Items.Material;
using ExxoAvalonOrigins.Items.Placeable.Painting;
using ExxoAvalonOrigins.Items.Weapons.Magic;
using ExxoAvalonOrigins.Items.Weapons.Ranged;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace ExxoAvalonOrigins.NPCs
{
    [AutoloadHead]
	public class Iceman : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Iceman");
			Main.npcFrameCount[npc.type] = 16;
		}

		public override void SetDefaults()
		{
			npc.damage = 10;
			npc.lifeMax = 300;
			npc.townNPC = true;
			npc.defense = 15;
			npc.friendly = true;
			npc.width = 18;
			npc.aiStyle = -1;
			npc.scale = 1f;
			npc.height = 40;
			npc.knockBackResist = 0.5f;
            npc.HitSound = SoundID.NPCHit1;
	        npc.DeathSound = SoundID.NPCDeath1;
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
            if (npc.homeless)
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
            var num216 = (int)(npc.position.X + npc.width / 2) / 16;
            var num217 = (int)(npc.position.Y + npc.height + 1f) / 16;
            ExxoAvalonOriginsGlobalNPC.savedIceman = true;
            if (npc.homeTileX == -1 && npc.homeTileY == -1 && npc.velocity.Y == 0f)
            {
                npc.homeTileX = (int)npc.Center.X / 16;
                npc.homeTileY = (int)(npc.position.Y + npc.height + 4f) / 16;
            }
            var flag23 = false;
            npc.directionY = -1;
            if (npc.direction == 0)
            {
                npc.direction = 1;
            }
            for (var num218 = 0; num218 < 255; num218++)
            {
                if (Main.player[num218].active && Main.player[num218].talkNPC == npc.whoAmI)
                {
                    flag23 = true;
                    if (npc.ai[0] != 0f)
                    {
                        npc.netUpdate = true;
                    }
                    npc.ai[0] = 0f;
                    npc.ai[1] = 300f;
                    npc.ai[2] = 100f;
                    if (Main.player[num218].position.X + Main.player[num218].width / 2 < npc.position.X + npc.width / 2)
                    {
                        npc.direction = -1;
                    }
                    else
                    {
                        npc.direction = 1;
                    }
                }
            }
            if (npc.ai[3] > 0f)
            {
                npc.life = -1;
                npc.HitEffect(0, 10.0);
                npc.active = false;
            }
            var num219 = npc.homeTileY;
            if (Main.netMode != NetmodeID.MultiplayerClient && npc.homeTileY > 0)
            {
                while (!WorldGen.SolidTile(npc.homeTileX, num219) && num219 < Main.maxTilesY - 20)
                {
                    num219++;
                }
            }
            if (Main.tile[num216, num217] == null)
            {
                return;
            }
            if (Main.netMode != NetmodeID.MultiplayerClient && npc.townNPC && (flag22 || Main.tileDungeon[Main.tile[num216, num217].type]) && (num216 != npc.homeTileX || num217 != num219) && !npc.homeless)
            {
                var flag24 = true;
                for (var num220 = 0; num220 < 2; num220++)
                {
                    var rectangle3 = new Rectangle((int)(npc.position.X + npc.width / 2 - NPC.sWidth / 2 - NPC.safeRangeX), (int)(npc.position.Y + npc.height / 2 - NPC.sHeight / 2 - NPC.safeRangeY), NPC.sWidth + NPC.safeRangeX * 2, NPC.sHeight + NPC.safeRangeY * 2);
                    if (num220 == 1)
                    {
                        rectangle3 = new Rectangle(npc.homeTileX * 16 + 8 - NPC.sWidth / 2 - NPC.safeRangeX, num219 * 16 + 8 - NPC.sHeight / 2 - NPC.safeRangeY, NPC.sWidth + NPC.safeRangeX * 2, NPC.sHeight + NPC.safeRangeY * 2);
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
                    if (!Collision.SolidTiles(npc.homeTileX - 1, npc.homeTileX + 1, num219 - 3, num219 - 1))
                    {
                        npc.velocity.X = 0f;
                        npc.velocity.Y = 0f;
                        npc.position.X = npc.homeTileX * 16 + 8 - npc.width / 2;
                        npc.position.Y = num219 * 16 - npc.height - 0.1f;
                        npc.netUpdate = true;
                    }
                    else
                    {
                        npc.homeless = true;
                        WorldGen.QuickFindHome(npc.whoAmI);
                    }
                }
            }
            if (npc.ai[0] == 0f)
            {
                if (npc.ai[2] > 0f)
                {
                    npc.ai[2] -= 1f;
                }
                if (flag22 && !flag23)
                {
                    if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        if (num216 == npc.homeTileX && num217 == num219)
                        {
                            if (npc.velocity.X != 0f)
                            {
                                npc.netUpdate = true;
                            }
                            if (npc.velocity.X > 0.1)
                            {
                                npc.velocity.X = npc.velocity.X - 0.1f;
                            }
                            else if (npc.velocity.X < -0.1)
                            {
                                npc.velocity.X = npc.velocity.X + 0.1f;
                            }
                            else
                            {
                                npc.velocity.X = 0f;
                            }
                        }
                        else if (!flag23)
                        {
                            if (num216 > npc.homeTileX)
                            {
                                npc.direction = -1;
                            }
                            else
                            {
                                npc.direction = 1;
                            }
                            npc.ai[0] = 1f;
                            npc.ai[1] = 200 + Main.rand.Next(200);
                            npc.ai[2] = 0f;
                            npc.netUpdate = true;
                        }
                    }
                }
                else
                {
                    if (npc.velocity.X > 0.1)
                    {
                        npc.velocity.X = npc.velocity.X - 0.1f;
                    }
                    else if (npc.velocity.X < -0.1)
                    {
                        npc.velocity.X = npc.velocity.X + 0.1f;
                    }
                    else
                    {
                        npc.velocity.X = 0f;
                    }
                    if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        if (npc.ai[1] > 0f)
                        {
                            npc.ai[1] -= 1f;
                        }
                        if (npc.ai[1] <= 0f)
                        {
                            npc.ai[0] = 1f;
                            npc.ai[1] = 200 + Main.rand.Next(200);
                            npc.ai[2] = 0f;
                            npc.netUpdate = true;
                        }
                    }
                }
                if (Main.netMode != NetmodeID.MultiplayerClient && (!flag22 || (num216 == npc.homeTileX && num217 == num219)))
                {
                    if (num216 < npc.homeTileX - 25 || num216 > npc.homeTileX + 25)
                    {
                        if (npc.ai[2] == 0f)
                        {
                            if (num216 < npc.homeTileX - 50 && npc.direction == -1)
                            {
                                npc.direction = 1;
                                npc.netUpdate = true;
                                return;
                            }
                            if (num216 > npc.homeTileX + 50 && npc.direction == 1)
                            {
                                npc.direction = -1;
                                npc.netUpdate = true;
                                return;
                            }
                        }
                    }
                    else if (Main.rand.Next(80) == 0 && npc.ai[2] == 0f)
                    {
                        npc.ai[2] = 200f;
                        npc.direction *= -1;
                        npc.netUpdate = true;
                        return;
                    }
                }
            }
            else if (npc.ai[0] == 1f)
            {
                if (Main.netMode != NetmodeID.MultiplayerClient && flag22 && num216 == npc.homeTileX && num217 == npc.homeTileY)
                {
                    npc.ai[0] = 0f;
                    npc.ai[1] = 200 + Main.rand.Next(200);
                    npc.ai[2] = 60f;
                    npc.netUpdate = true;
                    return;
                }
                if (Main.netMode != NetmodeID.MultiplayerClient && !npc.homeless && !Main.tileDungeon[Main.tile[num216, num217].type] && (num216 < npc.homeTileX - 35 || num216 > npc.homeTileX + 35))
                {
                    if (npc.position.X < npc.homeTileX * 16 && npc.direction == -1)
                    {
                        npc.ai[1] -= 5f;
                    }
                    else if (npc.position.X > npc.homeTileX * 16 && npc.direction == 1)
                    {
                        npc.ai[1] -= 5f;
                    }
                }
                npc.ai[1] -= 1f;
                if (npc.ai[1] <= 0f)
                {
                    npc.ai[0] = 0f;
                    npc.ai[1] = 300 + Main.rand.Next(300);
                    npc.ai[1] -= Main.rand.Next(100);
                    npc.ai[2] = 60f;
                    npc.netUpdate = true;
                }
                if (npc.closeDoor && ((npc.position.X + npc.width / 2) / 16f > npc.doorX + 2 || (npc.position.X + npc.width / 2) / 16f < npc.doorX - 2))
                {
                    var flag25 = WorldGen.CloseDoor(npc.doorX, npc.doorY, false);
                    if (flag25)
                    {
                        npc.closeDoor = false;
                        NetMessage.SendData(MessageID.ChangeDoor, -1, -1, NetworkText.FromLiteral(""), 1, npc.doorX, npc.doorY, npc.direction, 0);
                    }
                    if ((npc.position.X + npc.width / 2) / 16f > npc.doorX + 4 || (npc.position.X + npc.width / 2) / 16f < npc.doorX - 4 || (npc.position.Y + npc.height / 2) / 16f > npc.doorY + 4 || (npc.position.Y + npc.height / 2) / 16f < npc.doorY - 4)
                    {
                        npc.closeDoor = false;
                    }
                }
                var num222 = 1f;
                var num223 = 0.07f;
                if (npc.velocity.X < -num222 || npc.velocity.X > num222)
                {
                    if (npc.velocity.Y == 0f)
                    {
                        npc.velocity *= 0.8f;
                    }
                }
                else if (npc.velocity.X < num222 && npc.direction == 1)
                {
                    npc.velocity.X = npc.velocity.X + num223;
                    if (npc.velocity.X > num222)
                    {
                        npc.velocity.X = num222;
                    }
                }
                else if (npc.velocity.X > -num222 && npc.direction == -1)
                {
                    npc.velocity.X = npc.velocity.X - num223;
                    if (npc.velocity.X > num222)
                    {
                        npc.velocity.X = num222;
                    }
                }
                var flag26 = (npc.homeTileY - 2) * 16 <= npc.position.Y;
                if ((npc.direction == 1 && npc.position.Y + npc.width / 2 > npc.homeTileX * 16) || (npc.direction == -1 && npc.position.Y + npc.width / 2 < npc.homeTileX * 16))
                {
                    flag26 = true;
                }
                if (npc.velocity.Y >= 0f)
                {
                    var num224 = 0;
                    if (npc.velocity.X < 0f)
                    {
                        num224 = -1;
                    }
                    if (npc.velocity.X > 0f)
                    {
                        num224 = 1;
                    }
                    var vector22 = npc.position;
                    vector22.X += npc.velocity.X;
                    var num225 = (int)((vector22.X + npc.width / 2 + (npc.width / 2 + 1) * num224) / 16f);
                    var num226 = (int)((vector22.Y + npc.height - 1f) / 16f);
                    if (num225 * 16 < vector22.X + npc.width && num225 * 16 + 16 > vector22.X)
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
                        if (((Main.tile[num225, num226].nactive() && !Main.tile[num225, num226].topSlope() && !Main.tile[num225, num226 - 1].topSlope() && ((Main.tileSolid[Main.tile[num225, num226].type] && !Main.tileSolidTop[Main.tile[num225, num226].type]) || (flag26 && Main.tileSolidTop[Main.tile[num225, num226].type] && Main.tile[num225, num226].frameY == 0 && (!Main.tileSolid[Main.tile[num225, num226 - 1].type] || !Main.tile[num225, num226 - 1].nactive()) && Main.tile[num225, num226].type != 16 && Main.tile[num225, num226].type != 18 && Main.tile[num225, num226].type != 134 && Main.tile[num225, num226].type != 360))) || (Main.tile[num225, num226 - 1].halfBrick() && Main.tile[num225, num226 - 1].nactive())) && (!Main.tile[num225, num226 - 1].nactive() || !Main.tileSolid[Main.tile[num225, num226 - 1].type] || Main.tileSolidTop[Main.tile[num225, num226 - 1].type] || (Main.tile[num225, num226 - 1].halfBrick() && (!Main.tile[num225, num226 - 4].nactive() || !Main.tileSolid[Main.tile[num225, num226 - 4].type] || Main.tileSolidTop[Main.tile[num225, num226 - 4].type]))) && (!Main.tile[num225, num226 - 2].nactive() || !Main.tileSolid[Main.tile[num225, num226 - 2].type] || Main.tileSolidTop[Main.tile[num225, num226 - 2].type]) && (!Main.tile[num225, num226 - 3].nactive() || !Main.tileSolid[Main.tile[num225, num226 - 3].type] || Main.tileSolidTop[Main.tile[num225, num226 - 3].type]) && (!Main.tile[num225 - num224, num226 - 3].nactive() || !Main.tileSolid[Main.tile[num225 - num224, num226 - 3].type] || Main.tileSolidTop[Main.tile[num225 - num224, num226 - 3].type]))
                        {
                            float num227 = num226 * 16;
                            if (Main.tile[num225, num226].halfBrick())
                            {
                                num227 += 8f;
                            }
                            if (Main.tile[num225, num226 - 1].halfBrick())
                            {
                                num227 -= 8f;
                            }
                            if (num227 < vector22.Y + npc.height)
                            {
                                var num228 = vector22.Y + npc.height - num227;
                                if (num228 <= 16.1)
                                {
                                    npc.gfxOffY += npc.position.Y + npc.height - num227;
                                    npc.position.Y = num227 - npc.height;
                                    if (num228 < 9f)
                                    {
                                        npc.stepSpeed = 1f;
                                    }
                                    else
                                    {
                                        npc.stepSpeed = 2f;
                                    }
                                }
                            }
                        }
                    }
                }
                if (npc.velocity.Y == 0f)
                {
                    if (npc.position.X == npc.ai[2])
                    {
                        npc.direction *= -1;
                    }
                    npc.ai[2] = -1f;
                    var num229 = (int)((npc.position.X + npc.width / 2 + 15 * npc.direction) / 16f);
                    var num230 = (int)((npc.position.Y + npc.height - 16f) / 16f);
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
                    if (Main.tile[num229 - npc.direction, num230 + 1] == null)
                    {
                        Main.tile[num229 - npc.direction, num230 + 1] = new Tile();
                    }
                    if (Main.tile[num229 + npc.direction, num230 - 1] == null)
                    {
                        Main.tile[num229 + npc.direction, num230 - 1] = new Tile();
                    }
                    if (Main.tile[num229 + npc.direction, num230 + 1] == null)
                    {
                        Main.tile[num229 + npc.direction, num230 + 1] = new Tile();
                    }
                    Main.tile[num229 - npc.direction, num230 + 1].halfBrick();
                    if (npc.townNPC && Main.tile[num229, num230 - 2].nactive() && Main.tile[num229, num230 - 2].type == 10 && (Main.rand.Next(10) == 0 || flag22))
                    {
                        if (Main.netMode != NetmodeID.MultiplayerClient)
                        {
                            var flag27 = WorldGen.OpenDoor(num229, num230 - 2, npc.direction);
                            if (flag27)
                            {
                                npc.closeDoor = true;
                                npc.doorX = num229;
                                npc.doorY = num230 - 2;
                                NetMessage.SendData(MessageID.ChangeDoor, -1, -1, NetworkText.FromLiteral(""), 0, num229, num230 - 2, npc.direction, 0);
                                npc.netUpdate = true;
                                npc.ai[1] += 80f;
                                return;
                            }
                            if (WorldGen.OpenDoor(num229, num230 - 2, -npc.direction))
                            {
                                npc.closeDoor = true;
                                npc.doorX = num229;
                                npc.doorY = num230 - 2;
                                NetMessage.SendData(MessageID.ChangeDoor, -1, -1, NetworkText.FromLiteral(""), 0, num229, num230 - 2, -npc.direction, 0);
                                npc.netUpdate = true;
                                npc.ai[1] += 80f;
                                return;
                            }
                            npc.direction *= -1;
                            npc.netUpdate = true;
                            return;
                        }
                    }
                    else
                    {
                        if ((npc.velocity.X < 0f && npc.spriteDirection == -1) || (npc.velocity.X > 0f && npc.spriteDirection == 1))
                        {
                            if (Main.tile[num229, num230 - 2].nactive() && Main.tileSolid[Main.tile[num229, num230 - 2].type] && !Main.tileSolidTop[Main.tile[num229, num230 - 2].type])
                            {
                                if ((npc.direction == 1 && !Collision.SolidTiles(num229 - 2, num229 - 1, num230 - 5, num230 - 1)) || (npc.direction == -1 && !Collision.SolidTiles(num229 + 1, num229 + 2, num230 - 5, num230 - 1)))
                                {
                                    if (!Collision.SolidTiles(num229, num229, num230 - 5, num230 - 3))
                                    {
                                        npc.velocity.Y = -6f;
                                        npc.netUpdate = true;
                                    }
                                    else
                                    {
                                        npc.direction *= -1;
                                        npc.netUpdate = true;
                                    }
                                }
                                else
                                {
                                    npc.direction *= -1;
                                    npc.netUpdate = true;
                                }
                            }
                            else if (Main.tile[num229, num230 - 1].nactive() && Main.tileSolid[Main.tile[num229, num230 - 1].type] && !Main.tileSolidTop[Main.tile[num229, num230 - 1].type])
                            {
                                if ((npc.direction == 1 && !Collision.SolidTiles(num229 - 2, num229 - 1, num230 - 4, num230 - 1)) || (npc.direction == -1 && !Collision.SolidTiles(num229 + 1, num229 + 2, num230 - 4, num230 - 1)))
                                {
                                    if (!Collision.SolidTiles(num229, num229, num230 - 4, num230 - 2))
                                    {
                                        npc.velocity.Y = -5f;
                                        npc.netUpdate = true;
                                    }
                                    else
                                    {
                                        npc.direction *= -1;
                                        npc.netUpdate = true;
                                    }
                                }
                                else
                                {
                                    npc.direction *= -1;
                                    npc.netUpdate = true;
                                }
                            }
                            else if (npc.position.Y + npc.height - num230 * 16 > 20f && Main.tile[num229, num230].nactive() && Main.tileSolid[Main.tile[num229, num230].type] && !Main.tile[num229, num230].topSlope())
                            {
                                if ((npc.direction == 1 && !Collision.SolidTiles(num229 - 2, num229, num230 - 3, num230 - 1)) || (npc.direction == -1 && !Collision.SolidTiles(num229, num229 + 2, num230 - 3, num230 - 1)))
                                {
                                    npc.velocity.Y = -4.4f;
                                    npc.netUpdate = true;
                                }
                                else
                                {
                                    npc.direction *= -1;
                                    npc.netUpdate = true;
                                }
                            }
                            try
                            {
                                if (Main.tile[num229, num230 + 1] == null)
                                {
                                    Main.tile[num229, num230 + 1] = new Tile();
                                }
                                if (Main.tile[num229 - npc.direction, num230 + 1] == null)
                                {
                                    Main.tile[num229 - npc.direction, num230 + 1] = new Tile();
                                }
                                if (Main.tile[num229, num230 + 2] == null)
                                {
                                    Main.tile[num229, num230 + 2] = new Tile();
                                }
                                if (Main.tile[num229 - npc.direction, num230 + 2] == null)
                                {
                                    Main.tile[num229 - npc.direction, num230 + 2] = new Tile();
                                }
                                if (Main.tile[num229, num230 + 3] == null)
                                {
                                    Main.tile[num229, num230 + 3] = new Tile();
                                }
                                if (Main.tile[num229 - npc.direction, num230 + 3] == null)
                                {
                                    Main.tile[num229 - npc.direction, num230 + 3] = new Tile();
                                }
                                if (Main.tile[num229, num230 + 4] == null)
                                {
                                    Main.tile[num229, num230 + 4] = new Tile();
                                }
                                if (Main.tile[num229 - npc.direction, num230 + 4] == null)
                                {
                                    Main.tile[num229 - npc.direction, num230 + 4] = new Tile();
                                }
                                else if (num216 >= npc.homeTileX - 35 && num216 <= npc.homeTileX + 35 && (!Main.tile[num229, num230 + 1].nactive() || !Main.tileSolid[Main.tile[num229, num230 + 1].type]) && (!Main.tile[num229 - npc.direction, num230 + 1].active() || !Main.tileSolid[Main.tile[num229 - npc.direction, num230 + 1].type]) && (!Main.tile[num229, num230 + 2].nactive() || !Main.tileSolid[Main.tile[num229, num230 + 2].type]) && (!Main.tile[num229 - npc.direction, num230 + 2].active() || !Main.tileSolid[Main.tile[num229 - npc.direction, num230 + 2].type]) && (!Main.tile[num229, num230 + 3].nactive() || !Main.tileSolid[Main.tile[num229, num230 + 3].type]) && (!Main.tile[num229 - npc.direction, num230 + 3].active() || !Main.tileSolid[Main.tile[num229 - npc.direction, num230 + 3].type]) && (!Main.tile[num229, num230 + 4].nactive() || !Main.tileSolid[Main.tile[num229, num230 + 4].type]) && (!Main.tile[num229 - npc.direction, num230 + 4].nactive() || !Main.tileSolid[Main.tile[num229 - npc.direction, num230 + 4].type]))
                                {
                                    npc.direction *= -1;
                                    npc.velocity.X = npc.velocity.X * -1f;
                                    npc.netUpdate = true;
                                }
                            }
                            catch
                            {
                            }
                            if (npc.velocity.Y < 0f)
                            {
                                npc.ai[2] = npc.position.X;
                            }
                        }
                        if (npc.velocity.Y < 0f && npc.wet)
                        {
                            npc.velocity.Y = npc.velocity.Y * 1.2f;
                        }
                    }
                }
            }
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
        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 40;
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
}
