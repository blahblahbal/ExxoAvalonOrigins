using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.DataStructures;namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs{
    public class AdvMagicPower : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Magic Power");
            Description.SetDefault("40% increased magic damage");
        }

        public override void Update(Player player, ref int k)
        {
            player.magicDamage += 0.4f;
        }
    }}