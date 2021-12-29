using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs
{
    internal class VorazylcumMiteDigger : VorazylcumMiteDiggerWorm
    {
        public override string Texture => "ExxoAvalonOrigins/NPCs/VorazylcumMiteDigger";

        public override void SetDefaults()
        {
            npc.width = 14;
            npc.height = 14;
            npc.aiStyle = 6;
            npc.netAlways = true;
            npc.damage = 80;
            npc.defense = 6;
            npc.lifeMax = 1450;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.knockBackResist = 0f;
            npc.behindTiles = true;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.55f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.8f);
        }
        public override void NPCLoot()
        {
            Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/VorazylcumMiteGore1"), npc.scale);
            Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/VorazylcumMiteGore2"), npc.scale);
        }
        public override void CustomBehavior()
        {
            int xpos = npc.position.ToTileCoordinates().X;
            int ypos = npc.position.ToTileCoordinates().Y;

            if (npc.ai[2] <= 300) npc.ai[2]++;
            if (npc.ai[2] > 300)
            {
                npc.ai[3] = 1;
            }

            if (!Main.tile[xpos, ypos].active() && Main.tile[xpos, ypos + 1].active() && npc.ai[3] == 1)
            {
                npc.Transform(ModContent.NPCType<VorazylcumMite>());
                npc.ai[3] = 0;
                npc.ai[2] = 0;
            }

        }
        public override void Init()
        {
            base.Init();
            head = true;
        }
    }

    public abstract class VorazylcumMiteDiggerWorm : SingleSegmentWorm
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vorazylcum Mite");
        }

        public override void Init()
        {
            headType = ModContent.NPCType<VorazylcumMiteDigger>();
            speed = 5.5f;
            turnSpeed = 0.045f;
        }
    }
}
