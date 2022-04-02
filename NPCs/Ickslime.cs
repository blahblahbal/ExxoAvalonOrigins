using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;

namespace ExxoAvalonOrigins.NPCs
{
    public class Ickslime : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ickslime");
            Main.npcFrameCount[NPC.type] = 2;
        }

        public override void SetDefaults()
        {
            NPC.damage = 57;
            NPC.lifeMax = 186;
            NPC.defense = 30;
            NPC.alpha = 55;
            NPC.width = 40;
            NPC.aiStyle = 1;
            NPC.scale = 1.1f;
            NPC.value = 400f;
            NPC.height = 30;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.buffImmune[BuffID.Poisoned] = true;
            NPC.buffImmune[BuffID.Confused] = true;
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<Items.Banners.IckslimeBanner>();
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.Vitamins, 90));
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.65f);
            NPC.damage = (int)(NPC.damage * 0.45f);
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.player.Avalon().ZoneBooger && !spawnInfo.player.InPillarZone() && Main.hardMode)
                return (spawnInfo.player.Avalon().ZoneBooger && !spawnInfo.player.InPillarZone() && Main.hardMode) ? 0.7f : 0f;
            return 0f;
        }
        public override void FindFrame(int frameHeight)
        {
            var num2 = 0;
            if (NPC.aiAction == 0)
            {
                if (NPC.velocity.Y < 0f)
                {
                    num2 = 2;
                }
                else if (NPC.velocity.Y > 0f)
                {
                    num2 = 3;
                }
                else if (NPC.velocity.X != 0f)
                {
                    num2 = 1;
                }
                else
                {
                    num2 = 0;
                }
            }
            else if (NPC.aiAction == 1)
            {
                num2 = 4;
            }
            NPC.frameCounter += 1.0;
            if (num2 > 0)
            {
                NPC.frameCounter += 1.0;
            }
            if (num2 == 4)
            {
                NPC.frameCounter += 1.0;
            }
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
    }
}
