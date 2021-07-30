using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.DataStructures;namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs{
    public class AdvTitanskin : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Titanskin");
            Description.SetDefault("Defense is increased by 20 and damage is reduced by 6%");
        }

        public override void Update(Player player, ref int k)
        {
            player.magicDamage -= 0.6f;
            player.rangedDamage -= 0.6f;
            player.meleeDamage -= 0.6f;
            player.thrownDamage -= 0.6f;
            player.statDefense += 20;
        }
    }}