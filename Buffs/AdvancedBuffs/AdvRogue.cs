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
    public class AdvRogue : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Rogue");
            Description.SetDefault("-5% ranged damage, 25% chance to not consume ammo");
        }

        public override void Update(Player player, ref int k)
        {
            player.ammoCost75 = true;
            player.rangedDamage -= 0.05f;
        }
    }
}