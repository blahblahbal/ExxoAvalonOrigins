using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.DataStructures;namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs{
    public class AdvWrath : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Wrath");
            Description.SetDefault("20% increased damage");
        }

        public override void Update(Player player, ref int k)
        {
            player.magicDamage += 0.2f;
            player.rangedDamage += 0.2f;
            player.meleeDamage += 0.2f;
            player.thrownDamage += 0.2f;
        }
    }}