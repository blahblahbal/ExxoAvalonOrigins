using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs
{
    public class Malaria : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Malaria");
            Description.SetDefault("Itchy Bastards");
            Main.debuff[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().malaria = true;
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().malaria = true;
        }
    }
}
