using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.NPCs;

public class JuggernautSorcerer : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Juggernaut Sorcerer");
        Main.npcFrameCount[NPC.type] = 1; // change later
    }

    public override void SetDefaults()
    {
        NPC.damage = 110;
        NPC.lifeMax = 1500;
        NPC.defense = 50;
        NPC.width = 18;
        NPC.aiStyle = -1;
        NPC.npcSlots = 2f;
        NPC.value = 1000f;
        NPC.height = 40;
        NPC.knockBackResist = 0.1f;
        NPC.HitSound = SoundID.NPCHit2;
        NPC.DeathSound = SoundID.NPCDeath2;
        NPC.buffImmune[BuffID.OnFire] = true;
        //Banner = npc.type;
        //BannerItem = ModContent.ItemType<Items.Banners.ImpactWizardBanner>();
    }
    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.55f);
        NPC.damage = (int)(NPC.damage * 0.55f);
    }
    public override void AI()
    {
        NPC.TargetClosest(true);
        NPC.velocity.X = NPC.velocity.X * 0.93f;
        if (NPC.velocity.X > -0.1 && NPC.velocity.X < 0.1)
        {
            NPC.velocity.X = 0f;
        }
        if (NPC.ai[0] == 0f)
        {
            NPC.ai[0] = 500f;
        }
        if (NPC.ai[2] != 0f && NPC.ai[3] != 0f)
        {
            SoundEngine.PlaySound(SoundID.Item, (int)NPC.position.X, (int)NPC.position.Y, 8);
            NPC.position.X = NPC.ai[2] * 16f - NPC.width / 2 + 8f;
            NPC.position.Y = NPC.ai[3] * 16f - NPC.height;
            NPC.velocity.X = 0f;
            NPC.velocity.Y = 0f;
            NPC.ai[2] = 0f;
            NPC.ai[3] = 0f;
            SoundEngine.PlaySound(SoundID.Item, (int)NPC.position.X, (int)NPC.position.Y, 8);
            for (int num239 = 0; num239 < 50; num239++)
            {
                int num243 = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, DustID.MagnetSphere, 0f, 0f, 0, default(Color), 1f);
                Main.dust[num243].velocity *= 2f;
                Main.dust[num243].scale = 1.4f;
            }
        }
        NPC.ai[0] += 1f;
        if (NPC.ai[0] == 50f || NPC.ai[0] == 100f || NPC.ai[0] == 150f || NPC.ai[0] == 200f || NPC.ai[0] == 250f)
        {
            NPC.ai[1] = 30f;
            NPC.netUpdate = true;
        }
        if (NPC.ai[0] >= 400f)
        {
            NPC.ai[0] = 700f;
        }
        if (NPC.ai[0] == 100f || NPC.ai[0] == 200f || NPC.ai[0] == 300f)
        {
            NPC.ai[1] = 30f;
            NPC.netUpdate = true;
        }
        if (NPC.ai[0] >= 650f && Main.netMode != NetmodeID.MultiplayerClient)
        {
            NPC.ai[0] = 1f;
            int num247 = (int)Main.player[NPC.target].position.X / 16;
            int num248 = (int)Main.player[NPC.target].position.Y / 16;
            int num249 = (int)NPC.position.X / 16;
            int num250 = (int)NPC.position.Y / 16;
            int num251 = 20;
            int num252 = 0;
            bool flag28 = false;
            if (Math.Abs(NPC.position.X - Main.player[NPC.target].position.X) + Math.Abs(NPC.position.Y - Main.player[NPC.target].position.Y) > 2000f)
            {
                num252 = 100;
                flag28 = true;
            }
            while (!flag28 && num252 < 100)
            {
                num252++;
                int num253 = Main.rand.Next(num247 - num251, num247 + num251);
                int num254 = Main.rand.Next(num248 - num251, num248 + num251);
                for (int num255 = num254; num255 < num248 + num251; num255++)
                {
                    if ((num255 < num248 - 4 || num255 > num248 + 4 || num253 < num247 - 4 || num253 > num247 + 4) && (num255 < num250 - 1 || num255 > num250 + 1 || num253 < num249 - 1 || num253 > num249 + 1) && Main.tile[num253, num255].HasUnactuatedTile)
                    {
                        bool flag29 = true;
                        if (!Main.wallDungeon[Main.tile[num253, num255 - 1].WallType])
                        {
                            flag29 = false;
                        }
                        else if (Main.tile[num253, num255 - 1].LiquidType == LiquidID.Lava)
                        {
                            flag29 = false;
                        }
                        if (flag29 && Main.tileSolid[Main.tile[num253, num255].TileType] && !Collision.SolidTiles(num253 - 1, num253 + 1, num255 - 4, num255 - 1))
                        {
                            NPC.ai[1] = 20f;
                            NPC.ai[2] = num253;
                            NPC.ai[3] = num255;
                            flag28 = true;
                            break;
                        }
                    }
                }
            }
            NPC.netUpdate = true;
        }
        if (NPC.ai[1] > 0f)
        {
            NPC.ai[1] -= 1f;
            if (NPC.ai[1] == 25f)
            {
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    float num256 = 6f;
                    Vector2 vector23 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y);
                    float num257 = Main.player[NPC.target].position.X + Main.player[NPC.target].width * 0.5f - vector23.X;
                    float num258 = Main.player[NPC.target].position.Y + Main.player[NPC.target].height * 0.5f - vector23.Y;
                    float num259 = (float)Math.Sqrt(num257 * num257 + num258 * num258);
                    num259 = num256 / num259;
                    num257 *= num259;
                    num258 *= num259;
                    num257 *= 1.4f;
                    num258 *= 1.4f;
                    if (!NPC.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().silenced)
                    {
                        int num262 = Projectile.NewProjectile(NPC.GetSpawnSource_ForProjectile(), vector23.X, vector23.Y, num257, num258, ModContent.ProjectileType<Projectiles.SpikyBall>(), 78, 0f, Main.myPlayer, 0f, 0f);
                        Main.projectile[num262].timeLeft = 300;
                        if (Main.netMode == NetmodeID.Server)
                        {
                            NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, num262);
                        }
                    }
                    NPC.localAI[0] = 0f;
                }
            }
        }
        if (Main.rand.Next(2) == 0)
        {
            int num275 = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y + 2f), NPC.width, NPC.height, DustID.MagnetSphere, 0f, 0f, 0, default(Color), 1f);
            Main.dust[num275].velocity *= 0.5f;
            return;
        }
    }

    //public override void FindFrame(int frameHeight)
    //{
    //    if (npc.velocity.Y == 0f)
    //    {
    //        if (npc.direction == 1)
    //        {
    //            npc.spriteDirection = 1;
    //        }
    //        if (npc.direction == -1)
    //        {
    //            npc.spriteDirection = -1;
    //        }
    //    }
    //    npc.frame.Y = 0;
    //    if (npc.velocity.Y != 0f)
    //    {
    //        npc.frame.Y = npc.frame.Y + frameHeight;
    //    }
    //    else if (npc.ai[1] > 0f)
    //    {
    //        npc.frame.Y = npc.frame.Y + frameHeight * 2;
    //    }
    //}
}