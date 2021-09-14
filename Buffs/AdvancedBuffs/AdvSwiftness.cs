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
    public class AdvSwiftness : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Swiftness");
            Description.SetDefault("Increases stats");
        }

        public override void Update(Player player, ref int k)
        {
            player.moveSpeed += 0.5f;
        }
    }
}