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
    public class AdvManaRegeneration : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Mana Regeneration");
            Description.SetDefault("Increased mana regeneration");
        }

        public override void Update(Player player, ref int k)
        {
            player.manaRegenBuff = true;
        }
    }
}