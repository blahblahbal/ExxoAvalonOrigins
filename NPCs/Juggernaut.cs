using System;
using ExxoAvalonOrigins.Items.Material;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;

namespace ExxoAvalonOrigins.NPCs;

public class Juggernaut : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Juggernaut");
        Main.npcFrameCount[NPC.type] = 15;
    }

    public override void SetDefaults()
    {
        NPC.damage = 180;
        NPC.scale = 1f;
        NPC.lifeMax = 11000;
        NPC.defense = 70;
        NPC.lavaImmune = true;
        NPC.width = 31;
        NPC.aiStyle = -1;
        NPC.npcSlots = 3f;
        NPC.value = 700000f;
        NPC.timeLeft = 10000;
        NPC.height = 68;
        NPC.knockBackResist = 0f;
        NPC.HitSound = SoundID.NPCHit2;
        NPC.DeathSound = SoundID.NPCDeath2;
    }
    public override void OnKill()
    {
        NPC.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().jugRunonce = false;
        if (Main.netMode == NetmodeID.SinglePlayer)
        {
            Main.NewText("A Juggernaut has been defeated!", new Color(175, 75, 255));
        }
        else if (Main.netMode == NetmodeID.Server)
        {
            ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("A Juggernaut has been defeated!"), new Color(175, 75, 255));
        }
    }
    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<IllegalWeaponInstructions>()));
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SoulofBlight>(), 1, 1, 3));
    }
    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.65f * bossLifeScale);
        NPC.damage = (int)(NPC.damage * 0.45f);
    }

    public override void AI()
    {
        var num441 = 30;
        var flag40 = false;
        if (!NPC.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().jugRunonce)
        {
            NPC.position = Main.player[Player.FindClosest(NPC.position, NPC.width, NPC.height)].position;
            NPC.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().jugRunonce = true;
            if (Main.netMode == NetmodeID.SinglePlayer) Main.NewText("A Juggernaut has awoken!", new Color(175, 75, 255));
            else if (Main.netMode == NetmodeID.Server) ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("A Juggernaut has awoken!"), new Color(175, 75, 255));
        }
        if (NPC.justHit)
        {
            if (Main.rand.Next(20) == 0)
            {
                NPC.NewNPC(NPC.GetSpawnSourceForNPCFromNPCAI(), (int)NPC.position.X, (int)NPC.position.Y, ModContent.NPCType<JuggernautSorcerer>(), 0);
            }
            if (Main.rand.Next(20) == 0)
            {
                NPC.NewNPC(NPC.GetSpawnSourceForNPCFromNPCAI(), (int)NPC.position.X, (int)NPC.position.Y, ModContent.NPCType<EyeBones>(), 0);
            }
            //if (Main.rand.Next(10) == 1)
            //{
            //    NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.ArmoredSkeleton, 0);
            //}
            if (Main.rand.Next(45) == 0)
            {
                NPC.NewNPC(NPC.GetSpawnSourceForNPCFromNPCAI(), (int)NPC.position.X, (int)NPC.position.Y, ModContent.NPCType<CursedMagmaSkeleton>(), 0);
            }
            //if (Main.rand.Next(33) == 1)
            //{
            //    NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.ArmoredViking, 0);
            //}
        }
        if (NPC.velocity.Y == 0f && ((NPC.velocity.X > 0f && NPC.direction < 0) || (NPC.velocity.X < 0f && NPC.direction > 0)))
        {
            flag40 = true;
            NPC.ai[3] += 1f;
        }
        if (NPC.position.X == NPC.oldPosition.X || NPC.ai[3] >= num441 || flag40)
        {
            NPC.ai[3] += 1f;
        }
        else if (NPC.ai[3] > 0f)
        {
            NPC.ai[3] -= 1f;
        }
        if (NPC.ai[3] > num441 * 10)
        {
            NPC.ai[3] = 0f;
        }
        if (NPC.justHit)
        {
            NPC.ai[3] = 0f;
        }
        if (NPC.ai[3] == num441)
        {
            NPC.netUpdate = true;
        }
        var vector41 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
        var num442 = Main.player[NPC.target].position.X + Main.player[NPC.target].width * 0.5f - vector41.X;
        var num443 = Main.player[NPC.target].position.Y - vector41.Y;
        var num444 = (float)Math.Sqrt(num442 * num442 + num443 * num443);
        if (num444 < 200f)
        {
            NPC.ai[3] = 0f;
        }
        if (NPC.ai[3] < num441)
        {
            NPC.TargetClosest(true);
        }
        else
        {
            if (NPC.velocity.X == 0f)
            {
                if (NPC.velocity.Y == 0f)
                {
                    NPC.ai[0] += 1f;
                    if (NPC.ai[0] >= 2f)
                    {
                        NPC.direction *= -1;
                        NPC.spriteDirection = NPC.direction;
                        NPC.ai[0] = 0f;
                    }
                }
            }
            else
            {
                NPC.ai[0] = 0f;
            }
            NPC.directionY = -1;
            if (NPC.direction == 0)
            {
                NPC.direction = 1;
            }
        }
        var num445 = 6f;
        if (NPC.velocity.Y == 0f || NPC.wet || (NPC.velocity.X <= 0f && NPC.direction < 0) || (NPC.velocity.X >= 0f && NPC.direction > 0))
        {
            if (NPC.velocity.X < -num445 || NPC.velocity.X > num445)
            {
                if (NPC.velocity.Y == 0f)
                {
                    NPC.velocity *= 0.8f;
                }
            }
            else if (NPC.velocity.X < num445 && NPC.direction == 1)
            {
                NPC.velocity.X = NPC.velocity.X + 0.07f;
                if (NPC.velocity.X > num445)
                {
                    NPC.velocity.X = num445;
                }
            }
            else if (NPC.velocity.X > -num445 && NPC.direction == -1)
            {
                NPC.velocity.X = NPC.velocity.X - 0.07f;
                if (NPC.velocity.X < -num445)
                {
                    NPC.velocity.X = -num445;
                }
            }
        }
        if (NPC.velocity.Y >= 0f)
        {
            var num446 = 0;
            if (NPC.velocity.X < 0f)
            {
                num446 = -1;
            }
            if (NPC.velocity.X > 0f)
            {
                num446 = 1;
            }
            var vector42 = NPC.position;
            vector42.X += NPC.velocity.X;
            var num447 = (int)((vector42.X + NPC.width / 2 + (NPC.width / 2 + 1) * num446) / 16f);
            var num448 = (int)((vector42.Y + NPC.height - 1f) / 16f);
            //if (Main.tile[num447, num448] == null)
            //{
            //    Main.tile[num447, num448] = new Tile();
            //}
            //if (Main.tile[num447, num448 - 1] == null)
            //{
            //    Main.tile[num447, num448 - 1] = new Tile();
            //}
            //if (Main.tile[num447, num448 - 2] == null)
            //{
            //    Main.tile[num447, num448 - 2] = new Tile();
            //}
            //if (Main.tile[num447, num448 - 3] == null)
            //{
            //    Main.tile[num447, num448 - 3] = new Tile();
            //}
            //if (Main.tile[num447, num448 + 1] == null)
            //{
            //    Main.tile[num447, num448 + 1] = new Tile();
            //}
            if (num447 * 16 < vector42.X + NPC.width && num447 * 16 + 16 > vector42.X && ((Main.tile[num447, num448].HasUnactuatedTile && !Main.tile[num447, num448].topSlope() && !Main.tile[num447, num448 - 1].TopSlope && Main.tileSolid[Main.tile[num447, num448].TileType] && !Main.tileSolidTop[Main.tile[num447, num448].TileType]) || (Main.tile[num447, num448 - 1].IsHalfBlock && Main.tile[num447, num448 - 1].HasUnactuatedTile)) && (!Main.tile[num447, num448 - 1].HasUnactuatedTile || !Main.tileSolid[Main.tile[num447, num448 - 1].TileType] || Main.tileSolidTop[Main.tile[num447, num448 - 1].TileType] || (Main.tile[num447, num448 - 1].IsHalfBlock && (!Main.tile[num447, num448 - 4].HasUnactuatedTile || !Main.tileSolid[Main.tile[num447, num448 - 4].TileType] || Main.tileSolidTop[Main.tile[num447, num448 - 4].TileType]))) && (!Main.tile[num447, num448 - 2].HasUnactuatedTile || !Main.tileSolid[Main.tile[num447, num448 - 2].TileType] || Main.tileSolidTop[Main.tile[num447, num448 - 2].TileType]) && (!Main.tile[num447, num448 - 3].HasUnactuatedTile || !Main.tileSolid[Main.tile[num447, num448 - 3].TileType] || Main.tileSolidTop[Main.tile[num447, num448 - 3].TileType]) && (!Main.tile[num447 - num446, num448 - 3].HasUnactuatedTile || !Main.tileSolid[Main.tile[num447 - num446, num448 - 3].TileType]))
            {
                float num449 = num448 * 16;
                if (Main.tile[num447, num448].IsHalfBlock)
                {
                    num449 += 8f;
                }
                if (Main.tile[num447, num448 - 1].IsHalfBlock)
                {
                    num449 -= 8f;
                }
                if (num449 < vector42.Y + NPC.height)
                {
                    var num450 = vector42.Y + NPC.height - num449;
                    if (num450 <= 16.1)
                    {
                        NPC.gfxOffY += NPC.position.Y + NPC.height - num449;
                        NPC.position.Y = num449 - NPC.height;
                        if (num450 < 9f)
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
        if (NPC.velocity.Y != 0f)
        {
            return;
        }
        var num451 = (int)((NPC.position.X + NPC.width / 2 + (NPC.width / 2 + 2) * NPC.direction + NPC.velocity.X * 5f) / 16f);
        var num452 = (int)((NPC.position.Y + NPC.height - 15f) / 16f);
        //if (Main.tile[num451, num452] == null)
        //{
        //    Main.tile[num451, num452] = new Tile();
        //}
        //if (Main.tile[num451, num452 - 1] == null)
        //{
        //    Main.tile[num451, num452 - 1] = new Tile();
        //}
        //if (Main.tile[num451, num452 - 2] == null)
        //{
        //    Main.tile[num451, num452 - 2] = new Tile();
        //}
        //if (Main.tile[num451, num452 - 3] == null)
        //{
        //    Main.tile[num451, num452 - 3] = new Tile();
        //}
        //if (Main.tile[num451, num452 + 1] == null)
        //{
        //    Main.tile[num451, num452 + 1] = new Tile();
        //}
        //if (Main.tile[num451 + NPC.direction, num452 - 1] == null)
        //{
        //    Main.tile[num451 + NPC.direction, num452 - 1] = new Tile();
        //}
        //if (Main.tile[num451 + NPC.direction, num452 + 1] == null)
        //{
        //    Main.tile[num451 + NPC.direction, num452 + 1] = new Tile();
        //}
        //if (Main.tile[num451 - NPC.direction, num452 + 1] == null)
        //{
        //    Main.tile[num451 - NPC.direction, num452 + 1] = new Tile();
        //}
        if ((NPC.velocity.X >= 0f || NPC.spriteDirection != -1) && (NPC.velocity.X <= 0f || NPC.spriteDirection != 1))
        {
            return;
        }
        if (Main.tile[num451, num452 - 2].HasUnactuatedTile && Main.tileSolid[Main.tile[num451, num452 - 2].TileType])
        {
            if (Main.tile[num451, num452 - 3].HasUnactuatedTile && Main.tileSolid[Main.tile[num451, num452 - 3].TileType])
            {
                NPC.velocity.Y = -8.5f;
                NPC.netUpdate = true;
                return;
            }
            NPC.velocity.Y = -7.5f;
            NPC.netUpdate = true;
            return;
        }
        else
        {
            if (Main.tile[num451, num452 - 1].HasUnactuatedTile && !Main.tile[num451, num452 - 1].TopSlope && Main.tileSolid[Main.tile[num451, num452 - 1].TileType])
            {
                NPC.velocity.Y = -7f;
                NPC.netUpdate = true;
                return;
            }
            if (NPC.position.Y + NPC.height - num452 * 16 > 20f && Main.tile[num451, num452].HasUnactuatedTile && !Main.tile[num451, num452].TopSlope && Main.tileSolid[Main.tile[num451, num452].TileType])
            {
                NPC.velocity.Y = -6f;
                NPC.netUpdate = true;
                return;
            }
            if ((NPC.directionY < 0 || Math.Abs(NPC.velocity.X) > 3f) && (!Main.tile[num451, num452 + 2].HasUnactuatedTile || !Main.tileSolid[Main.tile[num451, num452 + 2].TileType]) && (!Main.tile[num451 + NPC.direction, num452 + 3].HasUnactuatedTile || !Main.tileSolid[Main.tile[num451 + NPC.direction, num452 + 3].TileType]))
            {
                NPC.velocity.Y = -8f;
                NPC.netUpdate = true;
                return;
            }
            return;
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

    public override void HitEffect(int hitDirection, double damage)
    {
        if (NPC.life <= 0)
        {
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("JuggernautHead").Type, 1f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("Bone1").Type, 1.7f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("Bone2").Type, 1.7f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("Bone1").Type, 1.7f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("Bone2").Type, 1.7f);
        }
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        return spawnInfo.player.ZoneRockLayerHeight && !spawnInfo.player.ZoneDungeon && Main.hardMode && ModContent.GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode ? 0.015f * ExxoAvalonOriginsGlobalNPC.endoSpawnRate : 0f;
    }
}