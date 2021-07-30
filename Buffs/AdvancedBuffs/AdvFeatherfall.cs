using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.DataStructures;namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs{
    public class AdvFeatherfall : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Featherfall");
            Description.SetDefault("Press UP or DOWN to control speed of descent");
        }

        public override void Update(Player player, ref int k)
        {
            player.slowFall = true;
        }
    }}