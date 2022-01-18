using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs
{
    public class BlazeOrb : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blaze Orb");
            Main.npcFrameCount[npc.type] = 1;
        }

        public override void SetDefaults()
        {
            npc.damage = 65;
            npc.scale = 0.9f;
            npc.noTileCollide = true;
            npc.lifeMax = 1;
            npc.defense = 0;
            npc.noGravity = true;
            npc.alpha = 80;
            npc.width = 16;
            npc.aiStyle = -1;
            npc.height = 16;
            npc.HitSound = SoundID.NPCHit3;
            npc.DeathSound = SoundID.NPCDeath3;
            npc.knockBackResist = 0f;
        }

        public override void AI()
        {
            if (npc.target == 255)
            {
                npc.TargetClosest(true);
                var num279 = 6f;
                var vector25 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                var num280 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - vector25.X;
                var num281 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - vector25.Y;
                var num282 = (float)Math.Sqrt(num280 * num280 + num281 * num281);
                num282 = num279 / num282;
                npc.velocity.X = num280 * num282;
                npc.velocity.Y = num281 * num282;
            }
            npc.ai[0] += 1f;
            if (npc.ai[0] > 3f)
            {
                npc.ai[0] = 3f;
            }
            if (npc.ai[0] == 2f)
            {
                npc.position += npc.velocity;
                Main.PlaySound(SoundID.Item, (int)npc.position.X, (int)npc.position.Y, 20);
                for (var num285 = 0; num285 < 20; num285++)
                {
                    var num286 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + 2f), npc.width, npc.height, DustID.Fire, 0f, 0f, 100, default(Color), 1.8f);
                    Main.dust[num286].velocity *= 1.3f;
                    Main.dust[num286].velocity += npc.velocity;
                    Main.dust[num286].noGravity = true;
                }
            }
            if (Collision.SolidCollision(npc.position, npc.width, npc.height) && Main.netMode != NetmodeID.MultiplayerClient)
            {
                var num287 = (int)(npc.position.X + npc.width / 2) / 16;
                var num288 = (int)(npc.position.Y + npc.height / 2) / 16;
                var num289 = 8;
                for (var num290 = num287 - num289; num290 <= num287 + num289; num290++)
                {
                    for (var num291 = num288 - num289; num291 < num288 + num289; num291++)
                    {
                        if (Math.Abs(num290 - num287) + Math.Abs(num291 - num288) < num289 * 0.5)
                        {
                            var tile = Main.tile[num290, num291];
                            if (tile.type == TileID.Ash)
                            {
                                if (Main.rand.Next(3) == 0)
                                {
                                    Main.tile[num290, num291].type = TileID.Hellstone;
                                }
                                else
                                {
                                    Main.tile[num290, num291].type = (ushort)ModContent.TileType<Tiles.BrimstoneBlock>();
                                }
                                WorldGen.SquareTileFrame(num290, num291, true);
                                if (Main.netMode == NetmodeID.Server)
                                {
                                    NetMessage.SendTileSquare(-1, num290, num291, 1);
                                }
                            }
                            else if (tile.type == TileID.Hellstone)
                            {
                                if (Main.rand.Next(5) == 0 && ModContent.GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode && Main.hardMode)
                                {
                                    Main.tile[num290, num291].type = (ushort)ModContent.TileType<Tiles.Ores.CaesiumOre>();
                                }
                                WorldGen.SquareTileFrame(num290, num291);
                                if (Main.netMode == NetmodeID.Server)
                                {
                                    NetMessage.SendTileSquare(-1, num290, num291, 1);
                                }
                            }
                            else if (tile.type == TileID.Obsidian)
                            {
                                if (Main.rand.Next(10) == 0)
                                {
                                    Main.tile[num290, num291].type = TileID.Hellstone;
                                }
                                WorldGen.SquareTileFrame(num290, num291);
                                if (Main.netMode == NetmodeID.Server)
                                {
                                    NetMessage.SendTileSquare(-1, num290, num291, 1);
                                }
                            }
                        }
                    }
                }
            }
            if (Collision.SolidCollision(npc.position, npc.width, npc.height))
            {
                var arg_12ED7_0 = Main.netMode;
                npc.StrikeNPC(999, 0f, 0, false, false);
            }
            if (npc.timeLeft > 100)
            {
                npc.timeLeft = 100;
            }
            for (var num292 = 0; num292 < 2; num292++)
            {
                var num302 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + 2f), npc.width, npc.height, DustID.Fire, npc.velocity.X * 0.1f, npc.velocity.Y * 0.1f, 80, default(Color), 1.3f);
                Main.dust[num302].velocity *= 0.3f;
                Main.dust[num302].noGravity = true;
            }
            npc.rotation += 0.4f * npc.direction;
            return;
        }
    }
}
