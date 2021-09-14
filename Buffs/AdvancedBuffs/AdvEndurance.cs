using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs
{
    public class AdvEndurance : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Endurance");
            Description.SetDefault("20% reduced damage taken");
        }

        public override void Update(Player player, ref int k)
        {
            player.endurance += 0.2f;
        }
    }
}