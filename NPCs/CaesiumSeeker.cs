using ExxoAvalonOrigins.Items.Placeable.Tile;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs
{
    public class CaesiumSeekerHead : CaesiumSeekerWorm
    {
        public override string Texture => "ExxoAvalonOrigins/NPCs/CaesiumSeekerHead";
        public override void SetDefaults()
        {
            NPC.width = 50;
            NPC.height = 50;
            NPC.aiStyle = 6;
            NPC.scale = 0.8f;
            NPC.netAlways = true;
            NPC.damage = 65;
            NPC.defense = 15;
            NPC.lifeMax = 1800;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.value = 1000;
            NPC.knockBackResist = 0f;
            NPC.behindTiles = true;
            NPC.buffImmune[BuffID.OnFire] = true;
            NPC.buffImmune[BuffID.CursedInferno] = true;
            NPC.buffImmune[BuffID.Daybreak] = true;
            DrawOffsetY = 25;
            //Banner = npc.type;
            //BannerItem = ModContent.ItemType<Items.Banners.CaesiumSeekerBanner>();
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.player.Avalon().ZoneCaesium && spawnInfo.player.ZoneUnderworldHeight && !NPC.AnyNPCs(NPCID.WallofFlesh) && !NPC.AnyNPCs(ModContent.NPCType<NPCs.Bosses.WallofSteel>()))
                return 0.6f;
            return 0;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.55f);
            NPC.damage = (int)(NPC.damage * 0.5f);
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CaesiumOre>(), 10, 2, 5));
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (NPC.life <= 0)
            {
                Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("Gores/CaesiumSeekerHead").Type, 0.8f);
            }
        }
        public override void Init()
        {
            base.Init();
            head = true;
            minLength = 10;
            maxLength = 18;
        }
    }

    public class CaesiumSeekerBody : CaesiumSeekerWorm
    {
        public override string Texture => "ExxoAvalonOrigins/NPCs/CaesiumSeekerBody";

        public override void SetDefaults()
        {
            NPC.width = 50;
            NPC.height = 50;
            NPC.aiStyle = 6;
            NPC.netAlways = true;
            NPC.damage = 60;
            NPC.scale = 0.8f;
            NPC.defense = 45;
            NPC.lifeMax = 1800;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.knockBackResist = 0f;
            NPC.behindTiles = true;
            NPC.buffImmune[BuffID.OnFire] = true;
            NPC.buffImmune[BuffID.CursedInferno] = true;
            NPC.buffImmune[BuffID.Daybreak] = true;
            DrawOffsetY = 25;
        }
        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            return false;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.55f * bossLifeScale);
            NPC.damage = (int)(NPC.damage * 0.5f);
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (NPC.life <= 0)
            {
                Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("Gores/CaesiumSeekerBody").Type, 0.8f);
            }
        }
    }

    public class CaesiumSeekerTail : CaesiumSeekerWorm
    {
        public override string Texture => "ExxoAvalonOrigins/NPCs/CaesiumSeekerTail";

        public override void SetDefaults()
        {
            NPC.width = 50;
            NPC.height = 50;
            NPC.aiStyle = 6;
            NPC.scale = 0.8f;
            NPC.netAlways = true;
            NPC.damage = 49;
            NPC.defense = 15;
            NPC.lifeMax = 1800;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.knockBackResist = 0f;
            NPC.behindTiles = true;
            NPC.buffImmune[BuffID.OnFire] = true;
            NPC.buffImmune[BuffID.CursedInferno] = true;
            NPC.buffImmune[BuffID.Daybreak] = true;
            DrawOffsetY = 25;
        }
        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            return false;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.55f * bossLifeScale);
            NPC.damage = (int)(NPC.damage * 0.5f);
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (NPC.life <= 0)
            {
                Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("Gores/CaesiumSeekerTail").Type, 0.8f);
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
            minLength = 10;
            maxLength = 18;
            tailType = ModContent.NPCType<CaesiumSeekerTail>();
            bodyType = ModContent.NPCType<CaesiumSeekerBody>();
            headType = ModContent.NPCType<CaesiumSeekerHead>();
            speed = 15f;
            turnSpeed = 0.15f;
        }
    }
}
