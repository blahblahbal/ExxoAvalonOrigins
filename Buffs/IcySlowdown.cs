using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs
{
    public class IcySlowdown : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Icy Slowdown");
            Description.SetDefault("You are slow");
            Main.debuff[Type] = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            //npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().slowed = true;
            npc.velocity.X = npc.direction == 1 ? 0.7f : -0.7f;
        }
    }
}
