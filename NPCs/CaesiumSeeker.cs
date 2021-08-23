using Microsoft.Xna.Framework;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs
{
    internal class CaesiumSeekerHead : CaesiumSeekerWorm
    {
        public override string Texture => "ExxoAvalonOrigins/NPCs/CaesiumSeekerHead";

        public override void SetDefaults()
        {
            npc.width = 14;
            npc.height = 14;
            npc.aiStyle = 6;
            npc.scale = 2f;
            npc.netAlways = true;
            npc.damage = 65;
            npc.defense = 15;
            npc.lifeMax = 1400;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.knockBackResist = 0f;
            npc.behindTiles = true;
            npc.buffImmune[BuffID.OnFire] = true;
            npc.buffImmune[BuffID.CursedInferno] = true;
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.player.GetModPlayer<ExxoAvalonOriginsModPlayer>().zoneCaesium && spawnInfo.player.ZoneUnderworldHeight)
                return 1;
            return 0;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CaesiumSeekerHead"), 1f);
            }
        }
        public override void Init()
        {
            base.Init();
            head = true;
            minLength = 40;
            maxLength = 60;
        }
    }

    internal class CaesiumSeekerBody : CaesiumSeekerWorm
    {
        public override string Texture => "ExxoAvalonOrigins/NPCs/CaesiumSeekerBody";

        public override void SetDefaults()
        {
            npc.width = 14;
            npc.height = 14;
            npc.aiStyle = 6;
            npc.netAlways = true;
            npc.damage = 60;
            npc.scale = 2f;
            npc.defense = 13;
            npc.lifeMax = 1400;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.knockBackResist = 0f;
            npc.behindTiles = true;
            npc.buffImmune[BuffID.OnFire] = true;
            npc.buffImmune[BuffID.CursedInferno] = true;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CaesiumSeekerBody"), 1f);
            }
        }
    }

    internal class CaesiumSeekerTail : CaesiumSeekerWorm
    {
        public override string Texture => "ExxoAvalonOrigins/NPCs/CaesiumSeekerTail";

        public override void SetDefaults()
        {
            npc.width = 14;
            npc.height = 14;
            npc.aiStyle = 6;
            npc.scale = 2f;
            npc.netAlways = true;
            npc.damage = 49;
            npc.defense = 15;
            npc.lifeMax = 1400;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.knockBackResist = 0f;
            npc.behindTiles = true;
            npc.buffImmune[BuffID.OnFire] = true;
            npc.buffImmune[BuffID.CursedInferno] = true;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CaesiumSeekerTail"), 1f);
            }
        }
        public override void Init()
        {
            base.Init();
            tail = true;
        }
    }
    public abstract class CaesiumSeekerWorm : Worm
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Caesium Seeker");
        }

        public override void Init()
        {
            minLength = 40;
            maxLength = 60;
            tailType = ModContent.NPCType<CaesiumSeekerTail>();
            bodyType = ModContent.NPCType<CaesiumSeekerBody>();
            headType = ModContent.NPCType<CaesiumSeekerHead>();
            speed = 5.5f;
            turnSpeed = 0.045f;
        }
    }
}