using Microsoft.Xna.Framework;
using System.IO;
using ExxoAvalonOrigins.Items.Placeable.Tile;
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
            npc.width = 50;
            npc.height = 50;
            npc.aiStyle = 6;
            npc.scale = 0.8f;
            npc.netAlways = true;
            npc.damage = 65;
            npc.defense = 15;
            npc.lifeMax = 1800;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.value = 1000;
            npc.knockBackResist = 0f;
            npc.behindTiles = true;
            npc.buffImmune[BuffID.OnFire] = true;
            npc.buffImmune[BuffID.CursedInferno] = true;
            npc.buffImmune[BuffID.Daybreak] = true;
            drawOffsetY = 25;
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.player.GetModPlayer<ExxoAvalonOriginsModPlayer>().zoneCaesium && spawnInfo.player.ZoneUnderworldHeight && !NPC.AnyNPCs(NPCID.WallofFlesh) && !NPC.AnyNPCs(ModContent.NPCType<NPCs.Bosses.WallofSteel>()))
                return 0.6f;
            return 0;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.55f);
            npc.damage = (int)(npc.damage * 0.5f);
        }
        public override void NPCLoot()
        {
            if (Main.rand.Next(10) == 0 && NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<CaesiumOre>(), Main.rand.Next(2, 5), false, 0, false);
            }
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CaesiumSeekerHead"), 0.8f);
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
            npc.width = 50;
            npc.height = 50;
            npc.aiStyle = 6;
            npc.netAlways = true;
            npc.damage = 60;
            npc.scale = 0.8f;
            npc.defense = 45;
            npc.lifeMax = 1800;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.knockBackResist = 0f;
            npc.behindTiles = true;
            npc.buffImmune[BuffID.OnFire] = true;
            npc.buffImmune[BuffID.CursedInferno] = true;
            npc.buffImmune[BuffID.Daybreak] = true;
            drawOffsetY = 25;
        }
        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            return false;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.55f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.5f);
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CaesiumSeekerBody"), 0.8f);
            }
        }
    }

    internal class CaesiumSeekerTail : CaesiumSeekerWorm
    {
        public override string Texture => "ExxoAvalonOrigins/NPCs/CaesiumSeekerTail";

        public override void SetDefaults()
        {
            npc.width = 50;
            npc.height = 50;
            npc.aiStyle = 6;
            npc.scale = 0.8f;
            npc.netAlways = true;
            npc.damage = 49;
            npc.defense = 15;
            npc.lifeMax = 1800;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.knockBackResist = 0f;
            npc.behindTiles = true;
            npc.buffImmune[BuffID.OnFire] = true;
            npc.buffImmune[BuffID.CursedInferno] = true;
            npc.buffImmune[BuffID.Daybreak] = true;
            drawOffsetY = 25;
        }
        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            return false;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.55f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.5f);
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CaesiumSeekerTail"), 0.8f);
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
            speed = 10f;
            turnSpeed = 0.075f;
        }
    }
}
