using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.NPCs
{
	public class EyeBones : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eye Bones");
			Main.npcFrameCount[npc.type] = 2;
		}

		public override void SetDefaults()
		{
			npc.damage = 85;
			npc.lifeMax = 700;
			npc.defense = 20;
			npc.width = 30;
			npc.aiStyle = 2;
			npc.value = 10000f;
			npc.height = 32;
			npc.knockBackResist = 0.5f;
            npc.HitSound = SoundID.NPCHit2;
	        npc.DeathSound = SoundID.NPCDeath39;
			npc.buffImmune[BuffID.Confused] = true;
		}

		public override void NPCLoot()
		{
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Bone, Main.rand.Next(3), false, 0, false);
        }

        public override void FindFrame(int frameHeight)
        {
            if (npc.velocity.X > 0f)
            {
                npc.spriteDirection = 1;
                npc.rotation = (float)Math.Atan2(npc.velocity.Y, npc.velocity.X);
            }
            if (npc.velocity.X < 0f)
            {
                npc.spriteDirection = -1;
                npc.rotation = (float)Math.Atan2(npc.velocity.Y, npc.velocity.X) + 3.14f;
            }
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

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.player.ZoneRockLayerHeight && Main.hardMode && ExxoAvalonOrigins.superHardmode ? 0.1f * ExxoAvalonOriginsGlobalNPC.endoSpawnRate : 0f;
        }
    }
}