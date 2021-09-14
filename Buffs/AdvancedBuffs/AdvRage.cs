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
    public class AdvRage : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Rage");
            Description.SetDefault("20% increased critical chance");
        }

        public override void Update(Player player, ref int k)
        {
            player.magicCrit += 20;
            player.meleeCrit += 20;
            player.rangedCrit += 20;
            player.thrownCrit += 20;
        }
    }
}