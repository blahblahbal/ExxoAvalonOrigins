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
    public class AdvThorns : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Thorns");
            Description.SetDefault("Attackers also take full damage");
        }

        public override void Update(Player player, ref int k)
        {
            player.turtleArmor = true;
            player.thorns = 1f;
        }
    }
}