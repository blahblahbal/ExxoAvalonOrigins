using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.DataStructures;namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs{
    public class AdvWisdom : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Wisdom");
            Description.SetDefault("-4% magic damage, +120 mana");
        }

        public override void Update(Player player, ref int k)
        {
            player.magicDamage -= 0.04f;
            player.statManaMax2 += 120;
        }
    }}