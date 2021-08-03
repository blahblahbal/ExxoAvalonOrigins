using Microsoft.Xna.Framework;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs
{
    internal class PyrasiteHead : PyrasiteWorm
    {
        public override string Texture => "ExxoAvalonOrigins/NPCs/PyrasiteHead";

        public override void SetDefaults()
        {
            npc.damage = 15;
            npc.netAlways = true;
            npc.noTileCollide = true;
            npc.lifeMax = 70;
            npc.defense = 0;
            npc.noGravity = true;
            npc.width = 26;
            npc.aiStyle = -1;
            npc.behindTiles = true;
            npc.value = 500f;
            npc.height = 26;
            npc.knockBackResist = 0f;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return (spawnInfo.player.GetModPlayer<ExxoAvalonOriginsModPlayer>().zoneBooger && spawnInfo.player.position.Y < Main.worldSurface) ? 0.05f : 0f;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PyrasiteHead"), 1f);
            }
        }

        public override void Init()
        {
            base.Init();
            head = true;
            minLength = 10;
            maxLength = 15;
        }
    }

    internal class PyrasiteBody : PyrasiteWorm
    {
        public override string Texture => "ExxoAvalonOrigins/NPCs/PyrasiteBody";

        public override void SetDefaults()
        {
            npc.damage = 8;
            npc.netAlways = true;
            npc.noTileCollide = true;
            npc.lifeMax = 70;
            npc.defense = 4;
            npc.noGravity = true;
            npc.width = 26;
            npc.aiStyle = -1;
            npc.behindTiles = true;
            npc.value = 500f;
            npc.height = 26;
            npc.knockBackResist = 0f;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PyrasiteBody"), 1f);
            }
        }

    }

    internal class PyrasiteTail : PyrasiteWorm
    {
        public override string Texture => "ExxoAvalonOrigins/NPCs/PyrasiteTail";

        public override void SetDefaults()
        {
            npc.damage = 8;
            npc.netAlways = true;
            npc.noTileCollide = true;
            npc.lifeMax = 70;
            npc.defense = 6;
            npc.noGravity = true;
            npc.width = 26;
            npc.aiStyle = -1;
            npc.behindTiles = true;
            npc.value = 500f;
            npc.height = 26;
            npc.knockBackResist = 0f;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PyrasiteTail"), 1f);
            }
        }

        public override void Init()
        {
            base.Init();
            tail = true;
        }
    }
    public abstract class PyrasiteWorm : Worm
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mechanical Digger");
        }

        public override void Init()
        {
            minLength = 6;
            maxLength = 10;
            tailType = ModContent.NPCType<PyrasiteTail>();
            bodyType = ModContent.NPCType<PyrasiteBody>();
            headType = ModContent.NPCType<PyrasiteHead>();
            speed = 5.5f;
            turnSpeed = 0.045f;
        }
    }
}