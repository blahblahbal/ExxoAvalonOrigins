using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs
{
    public class ProtectorWheel : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Protector Wheel");
            Main.npcFrameCount[npc.type] = 4;
        }

        public override void SetDefaults()
        {
            npc.damage = 65;
            npc.scale = 1f;
            npc.lifeMax = 500;
            npc.defense = 100;
            npc.noGravity = true;
            npc.width = 22;
            npc.aiStyle = -1;
            npc.behindTiles = true;
            npc.npcSlots = 1f;
            npc.value = 0f;
            npc.timeLeft = 750;
            npc.height = 22;
            npc.knockBackResist = 0f;
            npc.HitSound = SoundID.NPCHit3;
            npc.DeathSound = SoundID.NPCDeath3;
            npc.buffImmune[BuffID.Poisoned] = true;
            npc.buffImmune[BuffID.OnFire] = true;
            npc.buffImmune[BuffID.Confused] = true;
            npc.buffImmune[BuffID.CursedInferno] = true;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.55f);
            npc.damage = (int)(npc.damage * 0.8f);
        }
        public override void AI()
        {
            if (npc.ai[0] == 0f)
            {
                npc.TargetClosest(true);
                npc.directionY = 1;
                npc.ai[0] = 1f;
            }
            var num401 = 6;
            if (npc.ai[1] == 0f)
            {
                npc.rotation += (npc.direction * npc.directionY) * 0.13f;
                if (npc.collideY)
                {
                    npc.ai[0] = 2f;
                }
                if (!npc.collideY && npc.ai[0] == 2f)
                {
                    npc.direction = -npc.direction;
                    npc.ai[1] = 1f;
                    npc.ai[0] = 1f;
                }
                if (npc.collideX)
                {
                    npc.TargetClosest(true);
                    npc.directionY = -npc.directionY;
                    npc.ai[1] = 1f;
                }
            }
            else
            {
                npc.rotation -= (npc.direction * npc.directionY) * 0.13f;
                if (npc.collideX)
                {
                    npc.ai[0] = 2f;
                }
                if (!npc.collideX && npc.ai[0] == 2f)
                {
                    npc.directionY = -npc.directionY;
                    npc.ai[1] = 0f;
                    npc.ai[0] = 1f;
                }
                if (npc.collideY)
                {
                    npc.TargetClosest(true);
                    npc.direction = -npc.direction;
                    npc.ai[1] = 0f;
                }
            }
            npc.velocity.X = num401 * npc.direction;
            npc.velocity.Y = num401 * npc.directionY;
            var num402 = (270 - Main.mouseTextColor) / 400f;
            Lighting.AddLight((int)(npc.position.X + npc.width / 2) / 16, (int)(npc.position.Y + npc.height / 2) / 16, 0.9f, 0.3f + num402, 0.2f);
            return;
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 1.0;
            if (npc.frameCounter >= 3.0)
            {
                npc.frameCounter = 0.0;
                npc.frame.Y = npc.frame.Y + frameHeight;
                if (npc.frame.Y / frameHeight >= Main.npcFrameCount[npc.type])
                {
                    npc.frame.Y = 0;
                }
            }
        }
        /*Replaces Blazing Wheels
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.player.ZoneDungeon && Main.hardMode && ExxoAvalonOrigins.superHardmode ? 0.083f * ExxoAvalonOriginsGlobalNPC.endoSpawnRate : 0f;
        }*/
    }
}
