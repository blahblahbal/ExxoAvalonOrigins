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
    public class AdvObsidianSkin : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Obsidian Skin");
            Description.SetDefault("Immune to lava");
        }

        public override void Update(Player player, ref int k)
        {
            player.lavaImmune = true;
        }
    }
}