using Microsoft.Xna.Framework;
using System;
using ExxoAvalonOrigins.Items.Material;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace ExxoAvalonOrigins.NPCs
{
    [AutoloadHead]
	public class Librarian : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Librarian");
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
                    return "Richard";
                case 1:
                    return "John";
                case 2:
                    return "Cameron";
                case 3:
                    return "Benjamin";
                case 4:
                    return "Samuel";
                case 5:
                    return "Miles";
                case 6:
                    return "Julian";
                case 7:
                    return "Roger";
                case 8:
                    return "Steven";
                case 9:
                    return "Arnold";
                case 10:
                    return "Thomas";
                default:
                    return "Peter";
            }
        }
        public override string GetChat()
        {
            if (!Main.dayTime && Main.rand.Next(5) == 0)
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
                    return "買點東西，什麼都買。Oops, sorry about that. I was just speaking to a friend of mine from home.";
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
                    return "It's very strange to not see fairies flying around everyone. Why don't you buy one from me?";
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
            shop.item[nextSlot].value = Item.buyPrice(0, 5);
            nextSlot++;
            if (Main.hardMode)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<MysticalTomePage>());
                shop.item[nextSlot].value = Item.buyPrice(0, 1);
                nextSlot++;
            }
            if (NPC.downedBoss1)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<MysticalClaw>());
                shop.item[nextSlot].value = Item.buyPrice(0, 1);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<RubybeadHerb>());
                shop.item[nextSlot].value = Item.buyPrice(0, 1);
                nextSlot++;
            }
            if (Main.LocalPlayer.ZoneJungle)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<StrongVenom>());
                shop.item[nextSlot].value = Item.buyPrice(0, 1);
                nextSlot++;
            }
            if (NPC.downedBoss3)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<ElementDust>());
                shop.item[nextSlot].value = Item.buyPrice(0, 1);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<DewOrb>());
                shop.item[nextSlot].value = Item.buyPrice(0, 1);
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
                shop.item[nextSlot].value = Item.buyPrice(0, 4);
                nextSlot++;
            }
            if (NPC.downedPlantBoss && Main.hardMode)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<ElementDiamond>());
                shop.item[nextSlot].value = Item.buyPrice(0, 1);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<DewofHerbs>());
                shop.item[nextSlot].value = Item.buyPrice(0, 1);
                nextSlot++;
            }
            if (ModContent.GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode && Main.hardMode)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<ScrollofTome>());
                shop.item[nextSlot].value = Item.buyPrice(0, 10);
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
            projType = ProjectileID.GreenLaser;
            attackDelay = 1;
        }
        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
            randomOffset = 2f;
        }
    }
}
