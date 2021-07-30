using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.DataStructures;namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs{
    public class AdvFlipper : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Flipper");
            Description.SetDefault("Move like normal in water");
        }

        public override void Update(Player player, ref int k)
        {
            player.accFlipper = true;
        }
    }}