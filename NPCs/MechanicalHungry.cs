using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs;

public class MechanicalHungry : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Mechanical Hungry");
        Main.npcFrameCount[NPC.type] = 4;
    }

    public override void SetDefaults()
    {
        NPC.damage = 50;
        NPC.lifeMax = 660;
        NPC.defense = 50;
        NPC.width = 36;
        NPC.aiStyle = -1;
        NPC.value = 0;
        NPC.knockBackResist = 0f;
        NPC.noTileCollide = NPC.noGravity = true;
        NPC.height = 24;
        NPC.HitSound = SoundID.NPCHit4;
        NPC.DeathSound = SoundID.NPCDeath14;
    }
    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.66f);
        NPC.damage = (int)(NPC.damage * 0.4f);
    }
    public override void AI()
    {
        if (NPC.justHit)
        {
            NPC.ai[1] = 10f;
        }
        if (ExxoAvalonOriginsWorld.wos < 0)
        {
            NPC.active = false;
            return;
        }
        NPC.TargetClosest(true);
        float num465 = 0.1f;
        float num466 = 300f;
        if ((double)Main.npc[ExxoAvalonOriginsWorld.wos].life < (double)Main.npc[ExxoAvalonOriginsWorld.wos].lifeMax * 0.25)
        {
            NPC.damage = 75;
            NPC.defense = 40;
            num466 = 900f;
        }
        else if ((double)Main.npc[ExxoAvalonOriginsWorld.wos].life < (double)Main.npc[ExxoAvalonOriginsWorld.wos].lifeMax * 0.5)
        {
            NPC.damage = 60;
            NPC.defense = 30;
            num466 = 700f;
        }
        else if ((double)Main.npc[ExxoAvalonOriginsWorld.wos].life < (double)Main.npc[ExxoAvalonOriginsWorld.wos].lifeMax * 0.75)
        {
            NPC.damage = 45;
            NPC.defense = 20;
            num466 = 500f;
        }
        float num467 = Main.npc[ExxoAvalonOriginsWorld.wos].position.X + (float)(Main.npc[ExxoAvalonOriginsWorld.wos].width / 2);
        float num468 = Main.npc[ExxoAvalonOriginsWorld.wos].position.Y;
        float num469 = (float)(ExxoAvalonOriginsWorld.wosB - ExxoAvalonOriginsWorld.wosT);
        num468 = (float)ExxoAvalonOriginsWorld.wosT + num469 * NPC.ai[0];
        NPC.ai[2] += 1f;
        if (NPC.ai[2] > 100f)
        {
            num466 = (float)((int)(num466 * 1.3f));
            if (NPC.ai[2] > 200f)
            {
                NPC.ai[2] = 0f;
            }
        }
        Vector2 vector45 = new Vector2(num467, num468);
        float num470 = Main.player[NPC.target].position.X + (float)(Main.player[NPC.target].width / 2) - (float)(NPC.width / 2) - vector45.X;
        float num471 = Main.player[NPC.target].position.Y + (float)(Main.player[NPC.target].height / 2) - (float)(NPC.height / 2) - vector45.Y;
        float num472 = (float)Math.Sqrt((double)(num470 * num470 + num471 * num471));
        if (NPC.ai[1] == 0f)
        {
            if (num472 > num466)
            {
                num472 = num466 / num472;
                num470 *= num472;
                num471 *= num472;
            }
            if (NPC.position.X < num467 + num470)
            {
                NPC.velocity.X = NPC.velocity.X + num465;
                if (NPC.velocity.X < 0f && num470 > 0f)
                {
                    NPC.velocity.X = NPC.velocity.X + num465 * 2.5f;
                }
            }
            else if (NPC.position.X > num467 + num470)
            {
                NPC.velocity.X = NPC.velocity.X - num465;
                if (NPC.velocity.X > 0f && num470 < 0f)
                {
                    NPC.velocity.X = NPC.velocity.X - num465 * 2.5f;
                }
            }
            if (NPC.position.Y < num468 + num471)
            {
                NPC.velocity.Y = NPC.velocity.Y + num465;
                if (NPC.velocity.Y < 0f && num471 > 0f)
                {
                    NPC.velocity.Y = NPC.velocity.Y + num465 * 2.5f;
                }
            }
            else if (NPC.position.Y > num468 + num471)
            {
                NPC.velocity.Y = NPC.velocity.Y - num465;
                if (NPC.velocity.Y > 0f && num471 < 0f)
                {
                    NPC.velocity.Y = NPC.velocity.Y - num465 * 2.5f;
                }
            }
            if (NPC.velocity.X > 4f)
            {
                NPC.velocity.X = 4f;
            }
            if (NPC.velocity.X < -4f)
            {
                NPC.velocity.X = -4f;
            }
            if (NPC.velocity.Y > 4f)
            {
                NPC.velocity.Y = 4f;
            }
            if (NPC.velocity.Y < -4f)
            {
                NPC.velocity.Y = -4f;
            }
        }
        else if (NPC.ai[1] > 0f)
        {
            NPC.ai[1] -= 1f;
        }
        else
        {
            NPC.ai[1] = 0f;
        }
        if (num470 > 0f)
        {
            NPC.spriteDirection = 1;
            NPC.rotation = (float)Math.Atan2((double)num471, (double)num470);
        }
        if (num470 < 0f)
        {
            NPC.spriteDirection = -1;
            NPC.rotation = (float)Math.Atan2((double)num471, (double)num470) + 3.14f;
        }
        Lighting.AddLight((int)(NPC.position.X + (float)(NPC.width / 2)) / 16, (int)(NPC.position.Y + (float)(NPC.height / 2)) / 16, 0.3f, 0.2f, 0.1f);
        return;
    }
    public override void HitEffect(int hitDirection, double damage)
    {
        if (NPC.life > 0)
        {
            for (int num192 = 0; num192 < 5; num192++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.t_Slime, (float)hitDirection, -1f, 0, default(Color), 1f);
            }
            return;
        }
        if (Main.netMode != NetmodeID.MultiplayerClient)
        {
            NPC.NewNPC(NPC.GetSpawnSourceForNPCFromNPCAI(), (int)(NPC.position.X + (float)(NPC.width / 2)), (int)(NPC.position.Y + NPC.height), ModContent.NPCType<MechanicalHungry2>(), 0);
            for (int num193 = 0; num193 < 10; num193++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.t_Slime, (float)hitDirection, -1f, 0, default(Color), 1f);
            }
            return;
        }
        for (int num194 = 0; num194 < 20; num194++)
        {
            Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.t_Slime, (float)hitDirection, -1f, 0, default(Color), 1f);
        }
    }
    public override void FindFrame(int frameHeight)
    {
        NPC.frameCounter++;
        if (NPC.frameCounter < 5)
        {
            NPC.frame.Y = 0;
        }
        else if (NPC.frameCounter < 10)
        {
            NPC.frame.Y = frameHeight;
        }
        else if (NPC.frameCounter < 15)
        {
            NPC.frame.Y = frameHeight * 2;
        }
        else if (NPC.frameCounter < 20)
        {
            NPC.frame.Y = frameHeight * 3;
        }
        else if (NPC.frameCounter == 20)
        {
            NPC.frameCounter = 0;
        }
    }
}