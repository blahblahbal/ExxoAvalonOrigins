using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs
{
    public class Bleeding : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Bleeding");
            Description.SetDefault("Losing life");
            Main.debuff[Type] = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().bleeding = true;
        }
    }
}
