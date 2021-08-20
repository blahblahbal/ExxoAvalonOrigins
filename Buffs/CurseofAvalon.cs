using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs
{
    public class CurseofAvalon : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Curse of Avalon");
            Description.SetDefault("You take quadruple damage");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.buffTime[buffIndex] = 18000;
        }
    }
}
