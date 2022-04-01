using ExxoAvalonOrigins.Items.Material;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs
{
    public class Virus : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Viris");
            Main.npcFrameCount[NPC.type] = 4;
        }

        public override void SetDefaults()
        {
            NPC.damage = 40;
            NPC.lifeMax = 300;
            NPC.defense = 12;
            NPC.noGravity = true;
            NPC.width = 56;
            NPC.aiStyle = 22;
            NPC.npcSlots = 1f;
            NPC.value = 610f;
            NPC.height = 58;
            NPC.scale = 0.8f;
            NPC.knockBackResist = 0.2f;
            NPC.HitSound = SoundID.NPCHit18;
            NPC.DeathSound = SoundID.NPCDeath21;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.65f);
            NPC.damage = (int)(NPC.damage * 0.7f);
        }
        public override void NPCLoot()
        {
            Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType<Pathogen>(), 2 + Main.rand.Next(4), false, 0, false);
        }

        public override void FindFrame(int frameHeight)
        {
            NPC.frameCounter += 1.0;
            if (NPC.frameCounter >= 8.0)
            {
                NPC.frame.Y = NPC.frame.Y + frameHeight;
                NPC.frameCounter = 0.0;
            }
            if (NPC.frame.Y >= frameHeight * Main.npcFrameCount[NPC.type])
            {
                NPC.frame.Y = 0;
            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (NPC.life <= 0)
            {
                Gore.NewGore(NPC.position, NPC.velocity * 0.8f, Mod.Find<ModGore>("Gores/VirusTail"), 0.8f);
                Gore.NewGore(NPC.position, NPC.velocity * 0.8f, Mod.Find<ModGore>("Gores/VirusLimb"), 0.8f);
                Gore.NewGore(NPC.position, NPC.velocity * 0.8f, Mod.Find<ModGore>("Gores/VirusLimb"), 0.8f);
                Gore.NewGore(NPC.position, NPC.velocity * 0.8f, Mod.Find<ModGore>("Gores/VirusLimb"), 0.8f);
                Gore.NewGore(NPC.position, NPC.velocity * 0.8f, Mod.Find<ModGore>("Gores/VirusLimb"), 0.8f);
                Gore.NewGore(NPC.position, NPC.velocity * 0.8f, Mod.Find<ModGore>("Gores/VirusHead"), 0.8f);
                Gore.NewGore(NPC.position, NPC.velocity * 0.8f, Mod.Find<ModGore>("Gores/VirusHair"), 0.8f);
            }
        }
    }
}
