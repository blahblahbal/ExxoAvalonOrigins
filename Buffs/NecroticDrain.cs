using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs
{
    public class NecroticDrain : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Necrotic Drain");
            Description.SetDefault("Rapidly wasting away");
            Main.debuff[Type] = true;
        }
    }
}
