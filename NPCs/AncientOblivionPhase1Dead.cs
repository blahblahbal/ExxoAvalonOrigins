using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs;

public class AncientOblivionPhase1Dead : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Ancient Oblivion");
        Main.npcFrameCount[NPC.type] = 1;
    }

    public override void SetDefaults()
    {
        NPC.damage = 0;
        NPC.noTileCollide = false;
        NPC.dontTakeDamage = true;
        NPC.lifeMax = 1;
        NPC.defense = 0;
        NPC.noGravity = false;
        NPC.width = 48;
        NPC.aiStyle = -1;
        NPC.npcSlots = 1f;
        NPC.value = 0f;
        NPC.timeLeft = 750;
        NPC.height = 26;
        NPC.knockBackResist = 0f;
    }

    public override void AI()
    {
        NPC.life = 1;
        NPC.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().oRebirth++;
        if (NPC.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().oRebirth == 300)
        {
            NPC.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().oRebirth = 0;
            NPC.life = 0;
            NPC.active = false;
            NPC.NPCLoot();
            return;
        }
        return;
    }

    public override void NPCLoot()
    {
        NPC.NewNPC((int)NPC.position.X, (int)NPC.position.Y, ModContent.NPCType<AncientOblivionHead1>(), 0);
        Main.NewText("Ancient Oblivion has been reborn!", 175, 75, 255, false);
        if (Main.netMode == NetmodeID.Server)
        {
            NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Ancient Oblivion has been reborn!"), new Color(175, 75, 255));
        }
    }
}