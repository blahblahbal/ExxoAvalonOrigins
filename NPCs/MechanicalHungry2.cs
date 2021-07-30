using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.NPCs
{
    public class MechanicalHungry2 : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mechanical Hungry");
            Main.npcFrameCount[npc.type] = 2;
        }

        public override void SetDefaults()
        {
            npc.damage = 46;
            npc.lifeMax = 300;
            npc.defense = 20;
            npc.width = 36;
            npc.aiStyle = -1;
            npc.value = 0;
            npc.knockBackResist = 0.2f;
            npc.noGravity = true;
            npc.height = 24;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath14;
        }
        public override void NPCLoot()
        {
            Item.NewItem(npc.getRect(), ItemID.Heart);
        }
        public override void AI()
        {
            if (npc.justHit)
            {
                npc.ai[1] = 10f;
            }
            if (ExxoAvalonOriginsWorld.wos < 0)
            {
                npc.active = false;
                return;
            }
            npc.TargetClosest(true);
            float num465 = 0.1f;
            float num466 = 300f;
            if ((double)Main.npc[ExxoAvalonOriginsWorld.wos].life < (double)Main.npc[ExxoAvalonOriginsWorld.wos].lifeMax * 0.25)
            {
                npc.damage = 75;
                npc.defense = 40;
                num466 = 900f;
            }
            else if ((double)Main.npc[ExxoAvalonOriginsWorld.wos].life < (double)Main.npc[ExxoAvalonOriginsWorld.wos].lifeMax * 0.5)
            {
                npc.damage = 60;
                npc.defense = 30;
                num466 = 700f;
            }
            else if ((double)Main.npc[ExxoAvalonOriginsWorld.wos].life < (double)Main.npc[ExxoAvalonOriginsWorld.wos].lifeMax * 0.75)
            {
                npc.damage = 45;
                npc.defense = 20;
                num466 = 500f;
            }
            float num467 = Main.npc[ExxoAvalonOriginsWorld.wos].position.X + (float)(Main.npc[ExxoAvalonOriginsWorld.wos].width / 2);
            float num468 = Main.npc[ExxoAvalonOriginsWorld.wos].position.Y;
            float num469 = (float)(ExxoAvalonOriginsWorld.wosB - ExxoAvalonOriginsWorld.wosT);
            num468 = (float)ExxoAvalonOriginsWorld.wosT + num469 * npc.ai[0];
            npc.ai[2] += 1f;
            if (npc.ai[2] > 100f)
            {
                num466 = (float)((int)(num466 * 1.3f));
                if (npc.ai[2] > 200f)
                {
                    npc.ai[2] = 0f;
                }
            }
            Vector2 vector45 = new Vector2(num467, num468);
            float num470 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - (float)(npc.width / 2) - vector45.X;
            float num471 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - (float)(npc.height / 2) - vector45.Y;
            float num472 = (float)Math.Sqrt((double)(num470 * num470 + num471 * num471));
            if (npc.ai[1] == 0f)
            {
                if (num472 > num466)
                {
                    num472 = num466 / num472;
                    num470 *= num472;
                    num471 *= num472;
                }
                if (npc.position.X < num467 + num470)
                {
                    npc.velocity.X = npc.velocity.X + num465;
                    if (npc.velocity.X < 0f && num470 > 0f)
                    {
                        npc.velocity.X = npc.velocity.X + num465 * 2.5f;
                    }
                }
                else if (npc.position.X > num467 + num470)
                {
                    npc.velocity.X = npc.velocity.X - num465;
                    if (npc.velocity.X > 0f && num470 < 0f)
                    {
                        npc.velocity.X = npc.velocity.X - num465 * 2.5f;
                    }
                }
                if (npc.position.Y < num468 + num471)
                {
                    npc.velocity.Y = npc.velocity.Y + num465;
                    if (npc.velocity.Y < 0f && num471 > 0f)
                    {
                        npc.velocity.Y = npc.velocity.Y + num465 * 2.5f;
                    }
                }
                else if (npc.position.Y > num468 + num471)
                {
                    npc.velocity.Y = npc.velocity.Y - num465;
                    if (npc.velocity.Y > 0f && num471 < 0f)
                    {
                        npc.velocity.Y = npc.velocity.Y - num465 * 2.5f;
                    }
                }
                if (npc.velocity.X > 4f)
                {
                    npc.velocity.X = 4f;
                }
                if (npc.velocity.X < -4f)
                {
                    npc.velocity.X = -4f;
                }
                if (npc.velocity.Y > 4f)
                {
                    npc.velocity.Y = 4f;
                }
                if (npc.velocity.Y < -4f)
                {
                    npc.velocity.Y = -4f;
                }
            }
            else if (npc.ai[1] > 0f)
            {
                npc.ai[1] -= 1f;
            }
            else
            {
                npc.ai[1] = 0f;
            }
            if (num470 > 0f)
            {
                npc.spriteDirection = 1;
                npc.rotation = (float)Math.Atan2((double)num471, (double)num470);
            }
            if (num470 < 0f)
            {
                npc.spriteDirection = -1;
                npc.rotation = (float)Math.Atan2((double)num471, (double)num470) + 3.14f;
            }
            Lighting.AddLight((int)(npc.position.X + (float)(npc.width / 2)) / 16, (int)(npc.position.Y + (float)(npc.height / 2)) / 16, 0.3f, 0.2f, 0.1f);
            return;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life > 0)
            {
                for (int num192 = 0; num192 < 5; num192++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 4, (float)hitDirection, -1f, 0, default(Color), 1f);
                }
                return;
            }
            if (Main.netMode != 1)
            {
                for (int num193 = 0; num193 < 10; num193++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 4, (float)hitDirection, -1f, 0, default(Color), 1f);
                }
                return;
            }
            for (int num194 = 0; num194 < 20; num194++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 4, (float)hitDirection, -1f, 0, default(Color), 1f);
            }
        }
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter++;
            if (npc.frameCounter < 5)
            {
                npc.frame.Y = 0;
            }
            else if (npc.frameCounter < 10)
            {
                npc.frame.Y = frameHeight;
            }
            else if (npc.frameCounter < 15)
            {
                npc.frame.Y = frameHeight * 2;
            }
            else if (npc.frameCounter < 20)
            {
                npc.frame.Y = frameHeight * 3;
            }
            else if (npc.frameCounter == 20)
            {
                npc.frameCounter = 0;
            }
        }
    }
}