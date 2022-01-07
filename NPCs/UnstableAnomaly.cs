using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;

namespace ExxoAvalonOrigins.NPCs
{
    public class UnstableAnomaly : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Unstable Anomaly");
            Main.npcFrameCount[npc.type] = 8;
        }

        public override void SetDefaults()
        {
            npc.damage = 108;
            npc.scale = 1f;
            npc.lifeMax = 2000;
            npc.defense = 37;
            npc.width = 32;
            npc.aiStyle = 22;
            npc.value = Item.buyPrice(0, 1, 0, 0);
            npc.height = 24;
            npc.noTileCollide = npc.noGravity = true;
            npc.knockBackResist = 0.3f;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath6;
            npc.buffImmune[BuffID.Confused] = true;
            npc.buffImmune[BuffID.OnFire] = true;
            npc.buffImmune[BuffID.CursedInferno] = true;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.UnstableAnomalyBanner>();
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.55f);
            npc.damage = (int)(npc.damage * 0.65f);
        }

        public override void NPCLoot()
        {
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.player.GetModPlayer<ExxoAvalonOriginsModPlayer>().zoneDarkMatter && !spawnInfo.player.InPillarZone() && ModContent.GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode)
            {
                return 1f;
            }
            return 0f;
        }

        public override void FindFrame(int frameHeight)
        {
            if (npc.velocity.X > 0f)
            {
                npc.spriteDirection = 1;
            }
            if (npc.velocity.X < 0f)
            {
                npc.spriteDirection = -1;
            }
            npc.rotation = npc.velocity.X * 0.15f;
            npc.frameCounter += 1.0;
            if (npc.frameCounter >= 8.0)
            {
                npc.frame.Y = npc.frame.Y + frameHeight;
                npc.frameCounter = 0.0;
            }
            if (npc.frame.Y >= frameHeight * Main.npcFrameCount[npc.type])
            {
                npc.frame.Y = 0;
            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/UnstableAnomalyTable"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/UnstableAnomalyChair"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/UnstableAnomalyChair"), 1f);
                for (int i = 0; i < 30; i++)
                {
                    int num890 = Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<Dusts.SoulofLight>(), 0f, 0f, 0, default(Color), 1f);
                    Main.dust[num890].velocity *= 5f;
                    Main.dust[num890].scale = 1f;
                    Main.dust[num890].noGravity = true;
                    Main.dust[num890].fadeIn = 2f;
                }
            }
        }
    }
}
