using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs
{
    public class Larvae : ModNPC
    {
        int splitTimer;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Larvae");
            Main.npcFrameCount[npc.type] = 1;
        }

        public override void SetDefaults()
        {
            npc.damage = 0;
            npc.lifeMax = 200;
            npc.defense = 10;
            npc.noGravity = false;
            npc.width = 38;
            npc.aiStyle = -1;
            npc.noTileCollide = false;
            npc.height = 18;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.05f;

            splitTimer = 0;
        }

        public override void AI()
        {
            splitTimer++;

            npc.velocity.X *= 0.8f;

            int threshold;

            if (Main.expertMode)
                threshold = 180;
            else
                threshold = 240;

            if (splitTimer >= threshold)
            {
                npc.ai[0] = 1;
                npc.NPCLoot();
                npc.active = false;
            }
        }

        public override void NPCLoot()
        {
            float halfWidth = npc.width / 2;
            float halfHeight = npc.height / 2;
            Vector2 origin = npc.Center + new Vector2(Main.rand.NextFloat(-halfWidth, halfWidth + 1f), Main.rand.NextFloat(-halfHeight, halfHeight + 1f));
            if (npc.ai[0] == 1)
            {
                NPC.NewNPC((int)origin.X, (int)origin.Y, NPCID.Hornet, default, default, default, default, default, npc.target);
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    NPC.NewNPC((int)origin.X, (int)origin.Y, NPCID.Bee, default, default, default, default, default, npc.target);
                }
            }
        }
    }
}