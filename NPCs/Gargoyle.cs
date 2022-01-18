using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs
{
    public class Gargoyle : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gargoyle");
            Main.npcFrameCount[npc.type] = 5;
        }
        public override void SetDefaults()
        {
            npc.damage = 85;
            npc.netAlways = true;
            npc.scale = 1.1f;
            npc.lifeMax = 2400;
            npc.defense = 30;
            npc.lavaImmune = true;
            npc.width = 34;
            npc.aiStyle = -1;
            npc.value = Item.buyPrice(0, 1, 0, 0);
            npc.height = 50;
            npc.knockBackResist = 0f;
            npc.HitSound = null;
            npc.DeathSound = null;
            npc.buffImmune[BuffID.Confused] = true;
            npc.buffImmune[BuffID.OnFire] = true;
            npc.buffImmune[BuffID.CursedInferno] = true;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.GargoyleBanner>();
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.55f);
            npc.damage = (int)(npc.damage * 0.5f);
        }
        public override void NPCLoot()
        {
            // todo - add drops
        }
        public override void AI()
        {
            npc.noGravity = true;
            if (npc.ai[0] == 0f)
            {
                npc.noGravity = false;
                npc.TargetClosest(true);
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    if (npc.velocity.X != 0f || npc.velocity.Y < 0f || (double)npc.velocity.Y > 0.3)
                    {
                        npc.ai[0] = 1f;
                        npc.netUpdate = true;
                    }
                    else
                    {
                        Rectangle rectangle5 = new Rectangle((int)Main.player[npc.target].position.X, (int)Main.player[npc.target].position.Y, Main.player[npc.target].width, Main.player[npc.target].height);
                        Rectangle rectangle6 = new Rectangle((int)npc.position.X - 100, (int)npc.position.Y - 100, npc.width + 200, npc.height + 200);
                        if (rectangle6.Intersects(rectangle5) || npc.life < npc.lifeMax)
                        {
                            npc.ai[0] = 1f;
                            npc.velocity.Y = npc.velocity.Y - 6f;
                            npc.netUpdate = true;
                        }
                    }
                }
            }
            else if (!Main.player[npc.target].dead)
            {
                if (npc.collideX)
                {
                    npc.velocity.X = npc.oldVelocity.X * -0.5f;
                    if (npc.direction == -1 && npc.velocity.X > 0f && npc.velocity.X < 2f)
                    {
                        npc.velocity.X = 2f;
                    }
                    if (npc.direction == 1 && npc.velocity.X < 0f && npc.velocity.X > -2f)
                    {
                        npc.velocity.X = -2f;
                    }
                }
                if (npc.collideY)
                {
                    npc.velocity.Y = npc.oldVelocity.Y * -0.5f;
                    if (npc.velocity.Y > 0f && npc.velocity.Y < 1f)
                    {
                        npc.velocity.Y = 1f;
                    }
                    if (npc.velocity.Y < 0f && npc.velocity.Y > -1f)
                    {
                        npc.velocity.Y = -1f;
                    }
                }
                npc.TargetClosest(true);
                if (npc.direction == -1 && npc.velocity.X > -3f)
                {
                    npc.velocity.X = npc.velocity.X - 0.1f;
                    if (npc.velocity.X > 9f)
                    {
                        npc.velocity.X = npc.velocity.X - 0.1f;
                    }
                    else if (npc.velocity.X > 0f)
                    {
                        npc.velocity.X = npc.velocity.X - 0.05f;
                    }
                    if (npc.velocity.X < -9f)
                    {
                        npc.velocity.X = -9f;
                    }
                }
                else if (npc.direction == 1 && npc.velocity.X < 3f)
                {
                    npc.velocity.X = npc.velocity.X + 0.1f;
                    if (npc.velocity.X < -9f)
                    {
                        npc.velocity.X = npc.velocity.X + 0.1f;
                    }
                    else if (npc.velocity.X < 0f)
                    {
                        npc.velocity.X = npc.velocity.X + 0.05f;
                    }
                    if (npc.velocity.X > 9f)
                    {
                        npc.velocity.X = 9f;
                    }
                }
                float num365 = Math.Abs(npc.position.X + (float)(npc.width / 2) - (Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2)));
                float num366 = Main.player[npc.target].position.Y - (float)(npc.height / 2);
                if (num365 > 50f)
                {
                    num366 -= 100f;
                }
                if (npc.position.Y < num366)
                {
                    npc.velocity.Y = npc.velocity.Y + 0.05f;
                    if (npc.velocity.Y < 0f)
                    {
                        npc.velocity.Y = npc.velocity.Y + 0.01f;
                    }
                }
                else
                {
                    npc.velocity.Y = npc.velocity.Y - 0.05f;
                    if (npc.velocity.Y > 0f)
                    {
                        npc.velocity.Y = npc.velocity.Y - 0.01f;
                    }
                }
                if (npc.velocity.Y < -3f)
                {
                    npc.velocity.Y = -3f;
                }
                if (npc.velocity.Y > 3f)
                {
                    npc.velocity.Y = 3f;
                }
            }
            if (npc.wet)
            {
                if (npc.velocity.Y > 0f)
                {
                    npc.velocity.Y = npc.velocity.Y * 0.95f;
                }
                npc.velocity.Y = npc.velocity.Y - 0.5f;
                if (npc.velocity.Y < -4f)
                {
                    npc.velocity.Y = -4f;
                }
                npc.TargetClosest(true);
                return;
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.player.GetModPlayer<ExxoAvalonOriginsModPlayer>().ZoneHellcastle && Main.tile[spawnInfo.spawnTileX, spawnInfo.spawnTileY].wall == (ushort)ModContent.WallType<Walls.ImperviousBrickWallUnsafe>())
            {
                return 2f;
            }
            return 0f;
        }
        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;
            npc.rotation = npc.velocity.X * 0.1f;
            if (npc.velocity.X == 0f && npc.velocity.Y == 0f)
            {
                npc.frame.Y = 0;
                npc.frameCounter = 0.0;
            }
            else
            {
                npc.frameCounter += 1.0;
                if (npc.frameCounter <= 5)
                {
                    npc.frame.Y = frameHeight;
                }
                else if (npc.frameCounter <= 10)
                {
                    npc.frame.Y = frameHeight * 2;
                }
                else if (npc.frameCounter <= 15)
                {
                    npc.frame.Y = frameHeight * 3;
                }
                else if (npc.frameCounter <= 20)
                {
                    npc.frame.Y = frameHeight * 4;
                }
                else
                {
                    npc.frameCounter = 0;
                }
            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life > 0)
            {
                Main.PlaySound(SoundID.NPCHit, (int)npc.Center.X, (int)npc.Center.Y, 41, 1f, -0.25f);
            }
            if (npc.life <= 0)
            {
                Main.PlaySound(SoundID.NPCKilled, (int)npc.Center.X, (int)npc.Center.Y, 5, 1f, -0.25f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GargoyleGore3"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GargoyleGore3"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GargoyleGore4"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GargoyleWing"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GargoyleWing"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GargoyleHead"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GargoyleGore5"), 1f);
            }
        }
    }
}
