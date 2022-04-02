using System;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace ExxoAvalonOrigins.NPCs;

public class Dragonfly : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Dragonfly");
        Main.npcFrameCount[NPC.type] = 7;
        NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData
        {
            SpecificallyImmuneTo = new int[]
            {
                BuffID.Confused,
                BuffID.Poisoned,
                BuffID.OnFire,
                BuffID.CursedInferno
            }
        };
        NPCID.Sets.DebuffImmunitySets[Type] = debuffData;
    }

    public override void SetDefaults()
    {
        NPC.damage = 151;
        NPC.scale = 1f;
        NPC.lifeMax = 2100;
        NPC.defense = 55;
        NPC.noGravity = true;
        NPC.width = 56;
        NPC.aiStyle = -1;
        NPC.npcSlots = 1f;
        NPC.value = 10000f;
        NPC.gfxOffY = 25f;
        NPC.timeLeft = 750;
        NPC.height = 12;
        NPC.knockBackResist = 0f;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
        Banner = NPC.type;
        BannerItem = ModContent.ItemType<Items.Banners.DragonflyBanner>();
    }

    public int frames = 4;
    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.35f);
        NPC.damage = (int)(NPC.damage * 0.5f);
    }
    public override void AI()
    {
        var flag33 = false;
        frames += 16;
        if (frames > 448)
        {
            frames = 4;
        }
        if (Math.Round(NPC.velocity.X) == 0.0)
        {
            NPC.spriteDirection = NPC.direction;
        }
        if (NPC.justHit)
        {
            NPC.ai[2] = 0f;
        }
        if (NPC.ai[2] >= 0f)
        {
            var num403 = 16;
            var flag34 = false;
            var flag35 = false;
            if (NPC.position.X > NPC.ai[0] - num403 && NPC.position.X < NPC.ai[0] + num403)
            {
                flag34 = true;
            }
            else if ((NPC.velocity.X < 0f && NPC.direction > 0) || (NPC.velocity.X > 0f && NPC.direction < 0))
            {
                flag34 = true;
            }
            num403 += 24;
            if (NPC.position.Y > NPC.ai[1] - num403 && NPC.position.Y < NPC.ai[1] + num403)
            {
                flag35 = true;
            }
            if (flag34 && flag35)
            {
                NPC.ai[2] += 1f;
                if (NPC.ai[2] >= 30f && num403 == 16)
                {
                    flag33 = true;
                }
                if (NPC.ai[2] >= 60f)
                {
                    NPC.ai[2] = -200f;
                    NPC.direction *= -1;
                    NPC.velocity.X = NPC.velocity.X * -1f;
                    NPC.collideX = false;
                }
            }
            else
            {
                NPC.ai[0] = NPC.position.X;
                NPC.ai[1] = NPC.position.Y;
                NPC.ai[2] = 0f;
            }
            NPC.TargetClosest(true);
        }
        else
        {
            NPC.ai[2] += 1f;
            if (Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 > NPC.position.X + NPC.width / 2)
            {
                NPC.direction = -1;
            }
            else
            {
                NPC.direction = 1;
            }
        }
        var num404 = (int)((NPC.position.X + NPC.width / 2) / 16f) + NPC.direction * 2;
        var num405 = (int)((NPC.position.Y + NPC.height) / 16f);
        var flag36 = true;
        var num406 = 3;
        for (var num428 = num405; num428 < num405 + num406; num428++)
        {
            if ((Main.tile[num404, num428].HasUnactuatedTile && Main.tileSolid[Main.tile[num404, num428].TileType]) || Main.tile[num404, num428].LiquidAmount > 0)
            {
                flag36 = false;
                break;
            }
        }
        if (flag33)
        {
            flag36 = true;
        }
        if (flag36)
        {
            NPC.velocity.Y = NPC.velocity.Y + 0.1f;
            if (NPC.velocity.Y > 3f)
            {
                NPC.velocity.Y = 3f;
            }
        }
        else
        {
            if (NPC.directionY < 0 && NPC.velocity.Y > 0f)
            {
                NPC.velocity.Y = NPC.velocity.Y - 0.1f;
            }
            if (NPC.velocity.Y < -4f)
            {
                NPC.velocity.Y = -4f;
            }
        }
        if (NPC.collideX)
        {
            NPC.velocity.X = NPC.oldVelocity.X * -0.4f;
            if (NPC.direction == -1 && NPC.velocity.X > 0f && NPC.velocity.X < 1f)
            {
                NPC.velocity.X = 1f;
            }
            if (NPC.direction == 1 && NPC.velocity.X < 0f && NPC.velocity.X > -1f)
            {
                NPC.velocity.X = -1f;
            }
        }
        if (NPC.collideY)
        {
            NPC.velocity.Y = NPC.oldVelocity.Y * -0.25f;
            if (NPC.velocity.Y > 0f && NPC.velocity.Y < 1f)
            {
                NPC.velocity.Y = 1f;
            }
            if (NPC.velocity.Y < 0f && NPC.velocity.Y > -1f)
            {
                NPC.velocity.Y = -1f;
            }
        }
        var num430 = 2f;
        if (NPC.direction == -1 && NPC.velocity.X > -num430)
        {
            NPC.velocity.X = NPC.velocity.X - 0.1f;
            if (NPC.velocity.X > num430)
            {
                NPC.velocity.X = NPC.velocity.X - 0.1f;
            }
            else if (NPC.velocity.X > 0f)
            {
                NPC.velocity.X = NPC.velocity.X + 0.05f;
            }
            if (NPC.velocity.X < -num430)
            {
                NPC.velocity.X = -num430;
            }
        }
        else if (NPC.direction == 1 && NPC.velocity.X < num430)
        {
            NPC.velocity.X = NPC.velocity.X + 0.1f;
            if (NPC.velocity.X < -num430)
            {
                NPC.velocity.X = NPC.velocity.X + 0.1f;
            }
            else if (NPC.velocity.X < 0f)
            {
                NPC.velocity.X = NPC.velocity.X - 0.05f;
            }
            if (NPC.velocity.X > num430)
            {
                NPC.velocity.X = num430;
            }
        }
        if (NPC.directionY == -1 && NPC.velocity.Y > -1.5)
        {
            NPC.velocity.Y = NPC.velocity.Y - 0.04f;
            if (NPC.velocity.Y > 1.5)
            {
                NPC.velocity.Y = NPC.velocity.Y - 0.05f;
            }
            else if (NPC.velocity.Y > 0f)
            {
                NPC.velocity.Y = NPC.velocity.Y + 0.03f;
            }
            if (NPC.velocity.Y < -1.5)
            {
                NPC.velocity.Y = -1.5f;
            }
        }
        else if (NPC.directionY == 1 && NPC.velocity.Y < 1.5)
        {
            NPC.velocity.Y = NPC.velocity.Y + 0.04f;
            if (NPC.velocity.Y < -1.5)
            {
                NPC.velocity.Y = NPC.velocity.Y + 0.05f;
            }
            else if (NPC.velocity.Y < 0f)
            {
                NPC.velocity.Y = NPC.velocity.Y - 0.03f;
            }
            if (NPC.velocity.Y > 1.5)
            {
                NPC.velocity.Y = 1.5f;
            }
        }
        return;
    }

    public override void FindFrame(int frameHeight)
    {
        var frameHeightX = 1;
        if (!Main.dedServ)
        {
            frameHeightX = TextureAssets.Npc[NPC.type].Height / Main.npcFrameCount[NPC.type];
        }
        if (frames == 4 || frames == 68 || frames == 132 || frames == 196 || frames == 260 || frames == 324 || frames == 388)
        {
            NPC.frame.Y = frames;
        }
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        return spawnInfo.player.ZoneOverworldHeight && !spawnInfo.player.InPillarZone() && !Main.dayTime && Main.hardMode && ModContent.GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode ? 0.05f * ExxoAvalonOriginsGlobalNPC.endoSpawnRate : 0f;
    }
}
