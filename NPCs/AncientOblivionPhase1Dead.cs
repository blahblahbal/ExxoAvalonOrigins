using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs
{
    public class AncientOblivionPhase1Dead : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Oblivion");
            Main.npcFrameCount[npc.type] = 1;
        }

        public override void SetDefaults()
        {
            npc.damage = 0;
            npc.noTileCollide = false;
            npc.dontTakeDamage = true;
            npc.lifeMax = 1;
            npc.defense = 0;
            npc.noGravity = false;
            npc.width = 48;
            npc.aiStyle = -1;
            npc.npcSlots = 1f;
            npc.value = 0f;
            npc.timeLeft = 750;
            npc.height = 26;
            npc.knockBackResist = 0f;
        }

        public override void AI()
        {
            npc.life = 1;
            npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().oRebirth++;
            if (npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().oRebirth == 300)
            {
                npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().oRebirth = 0;
                npc.life = 0;
                npc.active = false;
                npc.NPCLoot();
                return;
            }
            return;
        }

        public override void NPCLoot()
        {
            NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, ModContent.NPCType<AncientOblivionHead1>(), 0);
            Main.NewText("Ancient Oblivion has been reborn!", 175, 75, 255, false);
            if (Main.netMode == NetmodeID.Server)
            {
                NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Ancient Oblivion has been reborn!"), new Color(175, 75, 255));
            }
        }
    }
}