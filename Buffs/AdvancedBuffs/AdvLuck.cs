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
    public class AdvLuck : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Luck");
            Description.SetDefault("Doubles rare drop chance");
        }

        public override void Update(Player player, ref int k)
        {
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().lucky = true;
            player.enemySpawns = true;
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().enemySpawns2 = true;
        }
    }
}