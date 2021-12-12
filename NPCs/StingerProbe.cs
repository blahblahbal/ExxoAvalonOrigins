using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;

namespace ExxoAvalonOrigins.NPCs
{
    public class StingerProbe : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stinger Probe");
            Main.npcFrameCount[npc.type] = 1;
        }
        public override void SetDefaults()
        {
            npc.npcSlots = 1;
            npc.width = 46;
            npc.height = 32;
            npc.aiStyle = -1;
            npc.timeLeft = 750;
            npc.damage = 60;
            npc.defense = 23;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.lifeMax = 300;
            npc.scale = 1;
            npc.knockBackResist = 0.1f;
            npc.noGravity = true;
            npc.noTileCollide = true;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.55f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.65f);
        }
        public override void AI()
        {
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead)
            {
                npc.TargetClosest(true);
            }
            float num146 = 6f;
            float num147 = 0.05f;
            Vector2 vector17 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
            float num149 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2);
            float num150 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2);
            num149 = (float)((int)(num149 / 8f) * 8);
            num150 = (float)((int)(num150 / 8f) * 8);
            vector17.X = (float)((int)(vector17.X / 8f) * 8);
            vector17.Y = (float)((int)(vector17.Y / 8f) * 8);
            num149 -= vector17.X;
            num150 -= vector17.Y;
            float num151 = (float)Math.Sqrt((double)(num149 * num149 + num150 * num150));
            float num152 = num151;
            bool flag16 = false;
            if (num151 > 600f)
            {
                flag16 = true;
            }
            if (num151 == 0f)
            {
                num149 = npc.velocity.X;
                num150 = npc.velocity.Y;
            }
            else
            {
                num151 = num146 / num151;
                num149 *= num151;
                num150 *= num151;
            }
            if (Main.player[npc.target].dead)
            {
                num149 = (float)npc.direction * num146 / 2f;
                num150 = -num146 / 2f;
            }
            if (npc.velocity.X < num149)
            {
                npc.velocity.X = npc.velocity.X + num147;
            }
            else if (npc.velocity.X > num149)
            {
                npc.velocity.X = npc.velocity.X - num147;
            }
            if (npc.velocity.Y < num150)
            {
                npc.velocity.Y = npc.velocity.Y + num147;
            }
            else if (npc.velocity.Y > num150)
            {
                npc.velocity.Y = npc.velocity.Y - num147;
            }
            if (npc.type == ModContent.NPCType<StingerProbe>())
            {
                npc.localAI[0] += 1f;
                if (npc.justHit)
                {
                    npc.localAI[0] = 0f;
                }
                if (Main.netMode != NetmodeID.MultiplayerClient && npc.localAI[0] >= 120f)
                {
                    npc.localAI[0] = 0f;
                    if (Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
                    {
                        int num153 = 57;
                        int num154 = ModContent.ProjectileType<Projectiles.StingerLaser>();
                        int proj = Projectile.NewProjectile(vector17.X, vector17.Y, num149, num150, num154, num153, 0f, Main.myPlayer, 0f, 0f);
                        Main.projectile[proj].velocity = Vector2.Normalize(npc.position - Main.npc[npc.target].position) * 14f;
                        //if (type == 480) Main.projectile[proj].notReflect = true;
                    }
                }
                int num155 = (int)npc.position.X + npc.width / 2;
                int num156 = (int)npc.position.Y + npc.height / 2;
                num155 /= 16;
                num156 /= 16;
                if (!WorldGen.SolidTile(num155, num156))
                {
                    Lighting.AddLight((int)((npc.position.X + (float)(npc.width / 2)) / 16f), (int)((npc.position.Y + (float)(npc.height / 2)) / 16f), 0.3f, 0.1f, 0.05f);
                }
                if (num149 > 0f)
                {
                    npc.spriteDirection = 1;
                    npc.rotation = (float)Math.Atan2((double)num150, (double)num149);
                }
                if (num149 < 0f)
                {
                    npc.spriteDirection = -1;
                    npc.rotation = (float)Math.Atan2((double)num150, (double)num149) + 3.14f;
                }
            }
        }
    }
}
