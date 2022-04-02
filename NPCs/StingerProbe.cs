using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs;

public class StingerProbe : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Stinger Probe");
        Main.npcFrameCount[NPC.type] = 1;
    }
    public override void SetDefaults()
    {
        NPC.npcSlots = 1;
        NPC.width = 46;
        NPC.height = 32;
        NPC.aiStyle = -1;
        NPC.timeLeft = 750;
        NPC.damage = 60;
        NPC.defense = 23;
        NPC.HitSound = SoundID.NPCHit4;
        NPC.DeathSound = SoundID.NPCDeath14;
        NPC.lifeMax = 300;
        NPC.scale = 1;
        NPC.knockBackResist = 0.1f;
        NPC.noGravity = true;
        NPC.noTileCollide = true;
    }
    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.55f);
        NPC.damage = (int)(NPC.damage * 0.65f);
    }
    public override void AI()
    {
        if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead)
        {
            NPC.TargetClosest(true);
        }
        float num146 = 6f;
        float num147 = 0.05f;
        Vector2 vector17 = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
        float num149 = Main.player[NPC.target].position.X + (float)(Main.player[NPC.target].width / 2);
        float num150 = Main.player[NPC.target].position.Y + (float)(Main.player[NPC.target].height / 2);
        num149 = (float)((int)(num149 / 8f) * 8);
        num150 = (float)((int)(num150 / 8f) * 8);
        vector17.X = (float)((int)(vector17.X / 8f) * 8);
        vector17.Y = (float)((int)(vector17.Y / 8f) * 8);
        num149 -= vector17.X;
        num150 -= vector17.Y;
        float num151 = (float)Math.Sqrt((double)(num149 * num149 + num150 * num150));
        float num152 = num151;
        if (num151 == 0f)
        {
            num149 = NPC.velocity.X;
            num150 = NPC.velocity.Y;
        }
        else
        {
            num151 = num146 / num151;
            num149 *= num151;
            num150 *= num151;
        }
        if (Main.player[NPC.target].dead)
        {
            num149 = (float)NPC.direction * num146 / 2f;
            num150 = -num146 / 2f;
        }
        if (NPC.velocity.X < num149)
        {
            NPC.velocity.X = NPC.velocity.X + num147;
        }
        else if (NPC.velocity.X > num149)
        {
            NPC.velocity.X = NPC.velocity.X - num147;
        }
        if (NPC.velocity.Y < num150)
        {
            NPC.velocity.Y = NPC.velocity.Y + num147;
        }
        else if (NPC.velocity.Y > num150)
        {
            NPC.velocity.Y = NPC.velocity.Y - num147;
        }
        if (NPC.type == ModContent.NPCType<StingerProbe>())
        {
            NPC.localAI[0] += 1f;
            if (NPC.justHit)
            {
                NPC.localAI[0] = 0f;
            }
            if (Main.netMode != NetmodeID.MultiplayerClient && NPC.localAI[0] >= 120f)
            {
                NPC.localAI[0] = 0f;
                if (Collision.CanHit(NPC.position, NPC.width, NPC.height, Main.player[NPC.target].position, Main.player[NPC.target].width, Main.player[NPC.target].height))
                {
                    int num153 = 57;
                    int num154 = ModContent.ProjectileType<Projectiles.StingerLaser>();
                    int proj = Projectile.NewProjectile(NPC.GetSpawnSource_ForProjectile(), vector17.X, vector17.Y, num149, num150, num154, num153, 0f, Main.myPlayer, 0f, 0f);
                    Main.projectile[proj].velocity = Vector2.Normalize(NPC.position - Main.npc[NPC.target].position) * 14f;
                    //if (type == 480) Main.projectile[proj].notReflect = true;
                }
            }
            int num155 = (int)NPC.position.X + NPC.width / 2;
            int num156 = (int)NPC.position.Y + NPC.height / 2;
            num155 /= 16;
            num156 /= 16;
            if (!WorldGen.SolidTile(num155, num156))
            {
                Lighting.AddLight((int)((NPC.position.X + (float)(NPC.width / 2)) / 16f), (int)((NPC.position.Y + (float)(NPC.height / 2)) / 16f), 0.3f, 0.1f, 0.05f);
            }
            if (num149 > 0f)
            {
                NPC.spriteDirection = 1;
                NPC.rotation = (float)Math.Atan2((double)num150, (double)num149);
            }
            if (num149 < 0f)
            {
                NPC.spriteDirection = -1;
                NPC.rotation = (float)Math.Atan2((double)num150, (double)num149) + 3.14f;
            }
        }
    }
}