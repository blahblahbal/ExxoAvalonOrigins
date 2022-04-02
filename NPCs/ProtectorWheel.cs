using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs;

public class ProtectorWheel : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Protector Wheel");
        Main.npcFrameCount[NPC.type] = 4;
    }

    public override void SetDefaults()
    {
        NPC.damage = 65;
        NPC.scale = 1f;
        NPC.lifeMax = 500;
        NPC.defense = 100;
        NPC.noGravity = true;
        NPC.width = 22;
        NPC.aiStyle = -1;
        NPC.behindTiles = true;
        NPC.npcSlots = 1f;
        NPC.value = 0f;
        NPC.timeLeft = 750;
        NPC.height = 22;
        NPC.knockBackResist = 0f;
        NPC.HitSound = SoundID.NPCHit3;
        NPC.DeathSound = SoundID.NPCDeath3;
        NPC.buffImmune[BuffID.Poisoned] = true;
        NPC.buffImmune[BuffID.OnFire] = true;
        NPC.buffImmune[BuffID.Confused] = true;
        NPC.buffImmune[BuffID.CursedInferno] = true;
    }
    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.55f);
        NPC.damage = (int)(NPC.damage * 0.8f);
    }
    public override void AI()
    {
        if (NPC.ai[0] == 0f)
        {
            NPC.TargetClosest(true);
            NPC.directionY = 1;
            NPC.ai[0] = 1f;
        }
        var num401 = 6;
        if (NPC.ai[1] == 0f)
        {
            NPC.rotation += (NPC.direction * NPC.directionY) * 0.13f;
            if (NPC.collideY)
            {
                NPC.ai[0] = 2f;
            }
            if (!NPC.collideY && NPC.ai[0] == 2f)
            {
                NPC.direction = -NPC.direction;
                NPC.ai[1] = 1f;
                NPC.ai[0] = 1f;
            }
            if (NPC.collideX)
            {
                NPC.TargetClosest(true);
                NPC.directionY = -NPC.directionY;
                NPC.ai[1] = 1f;
            }
        }
        else
        {
            NPC.rotation -= (NPC.direction * NPC.directionY) * 0.13f;
            if (NPC.collideX)
            {
                NPC.ai[0] = 2f;
            }
            if (!NPC.collideX && NPC.ai[0] == 2f)
            {
                NPC.directionY = -NPC.directionY;
                NPC.ai[1] = 0f;
                NPC.ai[0] = 1f;
            }
            if (NPC.collideY)
            {
                NPC.TargetClosest(true);
                NPC.direction = -NPC.direction;
                NPC.ai[1] = 0f;
            }
        }
        NPC.velocity.X = num401 * NPC.direction;
        NPC.velocity.Y = num401 * NPC.directionY;
        var num402 = (270 - Main.mouseTextColor) / 400f;
        Lighting.AddLight((int)(NPC.position.X + NPC.width / 2) / 16, (int)(NPC.position.Y + NPC.height / 2) / 16, 0.9f, 0.3f + num402, 0.2f);
        return;
    }

    public override void FindFrame(int frameHeight)
    {
        NPC.frameCounter += 1.0;
        if (NPC.frameCounter >= 3.0)
        {
            NPC.frameCounter = 0.0;
            NPC.frame.Y = NPC.frame.Y + frameHeight;
            if (NPC.frame.Y / frameHeight >= Main.npcFrameCount[NPC.type])
            {
                NPC.frame.Y = 0;
            }
        }
    }
    /*Replaces Blazing Wheels
    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        return spawnInfo.player.ZoneDungeon && Main.hardMode && ExxoAvalonOrigins.superHardmode ? 0.083f * ExxoAvalonOriginsGlobalNPC.endoSpawnRate : 0f;
    }*/
}