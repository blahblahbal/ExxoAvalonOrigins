using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class MidairRift : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rift");
        }

        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.aiStyle = -1;
            projectile.melee = true;
            projectile.penetrate = -1;
            projectile.light = 0.7f;
            projectile.friendly = true;
            projectile.tileCollide = false;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(255, 255, 255);
        }
        public override void AI()
        {
            projectile.velocity *= 0f;
            projectile.ai[0]++;
            if (projectile.ai[1] == 0)
            {
                if (projectile.ai[0] % 60 == 0)
                {
                    Player p = Main.player[Player.FindClosest(projectile.position, projectile.width, projectile.height)];
                    if (!WorldGen.crimson && !ExxoAvalonOriginsWorld.contagion) // corruption world
                    {
                        if (p.ZoneCorrupt)
                        {
                            if (Main.rand.Next(2) == 0) // crimson mobs
                            {
                                if (Main.hardMode)
                                {
                                    if (p.position.Y < Main.worldSurface)
                                    {
                                        int t = Main.rand.Next(2);
                                        if (t == 0) NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, NPCID.Crimslime);
                                        if (t == 1) NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, NPCID.Herpling);
                                    }
                                    else if (p.ZoneRockLayerHeight)
                                    {
                                        int t = Main.rand.Next(2);
                                        if (t == 0) NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, NPCID.IchorSticker);
                                        if (t == 1) NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, NPCID.FloatyGross);
                                    }
                                }
                                else
                                {
                                    int t = Main.rand.Next(3);
                                    if (t == 0) NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, NPCID.Crimera);
                                    if (t == 1) NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, NPCID.FaceMonster);
                                    if (t == 2) NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, NPCID.BloodCrawler);
                                }
                            }
                            else // contagion mobs
                            {
                                if (Main.hardMode)
                                {
                                    if (p.position.Y < Main.worldSurface)
                                    {
                                        int t = Main.rand.Next(2);
                                        if (t == 0) NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, ModContent.NPCType<NPCs.Ickslime>());
                                        if (t == 1) NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, ModContent.NPCType<NPCs.Cougher>());
                                    }
                                    else if (p.ZoneRockLayerHeight)
                                    {
                                        int t = Main.rand.Next(2);
                                        if (t == 0) NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, ModContent.NPCType<NPCs.Virus>());
                                        if (t == 1) NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, ModContent.NPCType<NPCs.GrossyFloat>());
                                    }
                                }
                                else
                                {
                                    int t = Main.rand.Next(2);
                                    if (t == 0) NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, ModContent.NPCType<NPCs.Bactus>());
                                    if (t == 1) NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, ModContent.NPCType<NPCs.PyrasiteHead>());
                                    //if (t == 2) NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, NPCID.BloodCrawler);
                                }
                            }
                        }
                    }
                    else if (!WorldGen.crimson && ExxoAvalonOriginsWorld.contagion) // contagion world
                    {
                        if (p.GetModPlayer<ExxoAvalonOriginsModPlayer>().ZoneBooger)
                        {
                            if (Main.rand.Next(2) == 0) // crimson mobs
                            {
                                if (Main.hardMode)
                                {
                                    if (p.position.Y < Main.worldSurface)
                                    {
                                        int t = Main.rand.Next(2);
                                        if (t == 0) NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, NPCID.Crimslime);
                                        if (t == 1) NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, NPCID.Herpling);
                                    }
                                    else if (p.ZoneRockLayerHeight)
                                    {
                                        int t = Main.rand.Next(2);
                                        if (t == 0) NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, NPCID.IchorSticker);
                                        if (t == 1) NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, NPCID.FloatyGross);
                                    }
                                }
                                else
                                {
                                    int t = Main.rand.Next(3);
                                    if (t == 0) NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, NPCID.Crimera);
                                    if (t == 1) NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, NPCID.FaceMonster);
                                    if (t == 2) NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, NPCID.BloodCrawler);
                                }
                            }
                            else // corruption mobs
                            {
                                if (Main.hardMode)
                                {
                                    if (p.position.Y < Main.worldSurface)
                                    {
                                        int t = Main.rand.Next(3);
                                        if (t == 0) NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, NPCID.CorruptSlime);
                                        if (t == 1) NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, NPCID.Slimer);
                                        if (t == 2) NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, NPCID.Corruptor);
                                    }
                                    else if (p.ZoneRockLayerHeight)
                                    {
                                        int t = Main.rand.Next(3);
                                        if (t == 0) NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, NPCID.SeekerHead);
                                        if (t == 1) NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, NPCID.CorruptSlime);
                                        if (t == 2) NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, NPCID.Corruptor);
                                    }
                                }
                                else
                                {
                                    int t = Main.rand.Next(2);
                                    if (t == 0) NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, NPCID.EaterofSouls);
                                    if (t == 1) NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, NPCID.DevourerHead);
                                    //if (t == 2) NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, NPCID.BloodCrawler);
                                }
                            }
                        }
                    }
                    else if (WorldGen.crimson) // crimson
                    {
                        if (p.ZoneCrimson)
                        {
                            if (Main.rand.Next(2) == 0) // corruption mobs
                            {
                                if (Main.hardMode)
                                {
                                    if (p.position.Y < Main.worldSurface)
                                    {
                                        int t = Main.rand.Next(3);
                                        if (t == 0) NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, NPCID.CorruptSlime);
                                        if (t == 1) NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, NPCID.Slimer);
                                        if (t == 2) NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, NPCID.Corruptor);
                                    }
                                    else if (p.ZoneRockLayerHeight)
                                    {
                                        int t = Main.rand.Next(3);
                                        if (t == 0) NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, NPCID.SeekerHead);
                                        if (t == 1) NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, NPCID.CorruptSlime);
                                        if (t == 2) NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, NPCID.Corruptor);
                                    }
                                }
                                else
                                {
                                    int t = Main.rand.Next(2);
                                    if (t == 0) NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, NPCID.EaterofSouls);
                                    if (t == 1) NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, NPCID.DevourerHead);
                                    //if (t == 2) NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, NPCID.BloodCrawler);
                                }
                            }
                            else // contagion mobs
                            {
                                if (Main.hardMode)
                                {
                                    if (p.position.Y < Main.worldSurface)
                                    {
                                        int t = Main.rand.Next(2);
                                        if (t == 0) NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, ModContent.NPCType<NPCs.Ickslime>());
                                        if (t == 1) NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, ModContent.NPCType<NPCs.Cougher>());
                                    }
                                    else if (p.ZoneRockLayerHeight)
                                    {
                                        int t = Main.rand.Next(2);
                                        if (t == 0) NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, ModContent.NPCType<NPCs.Virus>());
                                        if (t == 1) NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, ModContent.NPCType<NPCs.GrossyFloat>());
                                    }
                                }
                                else
                                {
                                    int t = Main.rand.Next(2);
                                    if (t == 0) NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, ModContent.NPCType<NPCs.Bactus>());
                                    if (t == 1) NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, ModContent.NPCType<NPCs.PyrasiteHead>());
                                    //if (t == 2) NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, NPCID.BloodCrawler);
                                }
                            }
                        }
                    }
                    for (int i = 0; i < 10; i++)
                    {
                        int num893 = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Enchanted_Pink, 0f, 0f, 0, default, 1f);
                        Main.dust[num893].velocity *= 2f;
                        Main.dust[num893].scale = 0.9f;
                        Main.dust[num893].noGravity = true;
                        Main.dust[num893].fadeIn = 3f;
                    }
                    Main.PlaySound(SoundID.Item, projectile.position, 8);
                }
            }
            else if (projectile.ai[1] == 1)
            {
                Point tile = projectile.position.ToTileCoordinates();
                for (int x = tile.X - 10; x < tile.X + 10; x++)
                {
                    for (int y = tile.Y - 10; x < tile.Y + 10; y++)
                    {

                    }
                }
            }
            if (projectile.ai[0] >= 200) projectile.Kill();
        }
        //public override void Kill(int timeLeft)
        //{
        //    Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
        //    for (int num394 = 4; num394 < 24; num394++)
        //    {
        //        float num395 = projectile.oldVelocity.X * (30f / (float)num394);
        //        float num396 = projectile.oldVelocity.Y * (30f / (float)num394);
        //        int num397 = Main.rand.Next(3);
        //        if (num397 == 0)
        //        {
        //            num397 = 15;
        //        }
        //        else if (num397 == 1)
        //        {
        //            num397 = 57;
        //        }
        //        else
        //        {
        //            num397 = 58;
        //        }
        //        int num398 = Dust.NewDust(new Vector2(projectile.position.X - num395, projectile.position.Y - num396), 8, 8, num397, projectile.oldVelocity.X * 0.2f, projectile.oldVelocity.Y * 0.2f, 100, default(Color), 1.8f);
        //        Main.dust[num398].velocity *= 1.5f;
        //        Main.dust[num398].noGravity = true;
        //    }
        //}
    }
}
