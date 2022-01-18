using ExxoAvalonOrigins.Items.Material;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs
{
    public class ArmoredHellTortoise : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Armored Hell Tortoise");
            Main.npcFrameCount[npc.type] = 8;
        }

        public override void SetDefaults()
        {
            npc.damage = 130;
            npc.lifeMax = 1600;
            npc.defense = 30;
            npc.lavaImmune = true;
            npc.noGravity = false;
            npc.width = 46;
            npc.aiStyle = 39;
            npc.npcSlots = 2f;
            npc.value = 10000f;
            npc.height = 32;
            npc.knockBackResist = 0.2f;
            npc.HitSound = SoundID.NPCHit24;
            npc.DeathSound = SoundID.NPCDeath27;
            npc.buffImmune[BuffID.Confused] = true;
            npc.buffImmune[BuffID.OnFire] = true;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.ArmoredHellTortoiseBanner>();
        }

        public override void NPCLoot()
        {
            if (Main.rand.Next(9) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<SpikedBlastShell>(), 1, false, 0, false);
            }
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.35f);
            npc.damage = (int)(npc.damage * 0.5f);
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ArmoredHellTortoiseGore1"), 0.9f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ArmoredHellTortoiseGore2"), 0.9f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ArmoredHellTortoiseGore3"), 0.9f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ArmoredHellTortoiseGore3"), 0.9f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ArmoredHellTortoiseGore3"), 0.9f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ArmoredHellTortoiseGore3"), 0.9f);
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return Main.hardMode && ModContent.GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode && spawnInfo.player.ZoneUnderworldHeight ? 0.125f * ExxoAvalonOriginsGlobalNPC.endoSpawnRate : 0f;
        }
    }
}
