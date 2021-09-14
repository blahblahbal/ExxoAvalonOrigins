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
    public class AdvMining : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Mining");
            Description.SetDefault("50% increased mining speed");
        }

        public override void Update(Player player, ref int k)
        {
            player.pickSpeed -= 0.5f;
        }
    }
}