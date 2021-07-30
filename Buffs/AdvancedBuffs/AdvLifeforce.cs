using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.DataStructures;namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs{
    public class AdvLifeforce : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Lifeforce");
            Description.SetDefault("40% increased max life");
        }

        public override void Update(Player player, ref int k)
        {
            player.lifeForce = true;
            player.statLifeMax2 += player.statLifeMax / 5 / 20 * 40;
        }
    }}