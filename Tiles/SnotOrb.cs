﻿using Microsoft.Xna.Framework;

namespace ExxoAvalonOrigins.Tiles
    public class SnotOrb : ModTile
    {
        public override void SetDefaults()
        {
            AddMapEntry(new Color(144, 160, 38), LanguageManager.Instance.GetText("Snot Orb"));
            animationFrameHeight = 36;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
            TileObjectData.newTile.Width = 2;
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.addTile(Type);
            Main.tileHammer[Type] = true;
        }
        {
            var brightness = Main.rand.Next(-5, 6) * 0.0025f;
            r = 0f;
            g = 0.9f + brightness * 2f;
            b = 0f;
        }
        {
            frameCounter++;
            if (frameCounter > 4)
            {
                frameCounter = 0;
                frame++;
                if (frame > 1) frame = 0;
            }
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            if (Main.netMode != 1 && !WorldGen.noTileActions)
            {
                if (WorldGen.genRand.Next(2) == 0)
                {
                    WorldGen.spawnMeteor = true;
                }
                int num3 = Main.rand.Next(3);
                if (!WorldGen.shadowOrbSmashed)
                {
                    num3 = 0;
                }
                if (num3 == 0)
                {
                    Item.NewItem(i * 16, j * 16, 32, 32, ModContent.ItemType<Items.PeeShooter>(), 1, false, -1, false);
                    Item.NewItem(i * 16, j * 16, 32, 32, 97, 100, false, 0, false);
                }
                else if (num3 == 1)
                {
                    Item.NewItem(i * 16, j * 16, 32, 32, ModContent.ItemType<Items.VirulentPike>(), 1, false, -1, false);
                }
                else if (num3 == 2)
                {
                    Item.NewItem(i * 16, j * 16, 32, 32, ModContent.ItemType<Items.BandofStamina>(), 1, false, -1, false);
                }
                WorldGen.shadowOrbSmashed = true;
                WorldGen.shadowOrbCount++;
                if (WorldGen.shadowOrbCount >= 3)
                {
                    WorldGen.shadowOrbCount = 0;
                    float num5 = (float)(i * 16);
                    float num6 = (float)(j * 16);
                    float num7 = -1f;
                    int plr = 0;
                    for (int k = 0; k < 255; k++)
                    {
                        float num8 = Math.Abs(Main.player[k].position.X - num5) + Math.Abs(Main.player[k].position.Y - num6);
                        if (num8 < num7 || num7 == -1f)
                        {
                            plr = k;
                            num7 = num8;
                        }
                    }
                    NPC.SpawnOnPlayer(plr, ModContent.NPCType<NPCs.BacteriumPrime>());
                }
                else
                {
                    string text = Lang.misc[10].Value;
                    if (WorldGen.shadowOrbCount == 2)
                    {
                        text = Lang.misc[11].Value;
                    }
                    if (Main.netMode == 0)
                    {
                        Main.NewText(text, 50, 255, 130, false);
                    }
                    else if (Main.netMode == 2)
                    {
                        NetMessage.BroadcastChatMessage(NetworkText.FromLiteral(text), new Color(50f, 255f, 130f));
                    }
                }
                Main.PlaySound(4, i * 16, j * 16, 1);
            }
        }
    }