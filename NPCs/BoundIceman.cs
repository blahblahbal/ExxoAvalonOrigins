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
    public class BoundIceman : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bound Iceman");
            Main.npcFrameCount[npc.type] = 1;
        }

        public override void SetDefaults()
        {
            npc.damage = 10;
            npc.lifeMax = 300;
            npc.defense = 15;
            npc.friendly = true;
            npc.width = 18;
            npc.aiStyle = -1;
            npc.height = 40;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.player.ZoneSnow && spawnInfo.player.ZoneRockLayerHeight && !ExxoAvalonOriginsGlobalNPC.savedIceman && ModContent.GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode ? 0.0526f : 0f;
        }

        public override bool CanChat()
        {
            return true;
        }

        public override string GetChat()
        {
            switch (Main.rand.Next(3))
            {
                case 0:
                    return "Thanks for dislodging me from that glacier bit. If you hadn't, I'd have probably gone dormant and stayed there for eons!";

                case 1:
                    return "Wow! A human! I haven't seen one of you for... I don't know how long!";

                case 2:
                    return "Thanks for not flinging matches at me. I hate it when people do that.";
            }
            return string.Empty;
        }

        public override void AI()
        {
            for (var i = 0; i < 255; i++)
            {
                if (Main.player[i].active && Main.player[i].talkNPC == npc.whoAmI)
                {
                    npc.Transform(ModContent.NPCType<Iceman>());
                    ExxoAvalonOriginsGlobalNPC.savedIceman = true;
                }
            }
            npc.TargetClosest(true);
            npc.spriteDirection = npc.direction;
            npc.velocity.X = npc.velocity.X * 0.93f;
            if (npc.velocity.X > -0.1 && npc.velocity.X < 0.1)
            {
                npc.velocity.X = 0f;
                return;
            }
        }
    }
}