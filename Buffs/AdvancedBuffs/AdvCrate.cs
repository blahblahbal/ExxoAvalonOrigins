using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.DataStructures;namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs{
    public class AdvCrate : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Crate");
            Description.SetDefault("Greater chance of fishing up a crate");
        }

        public override void Update(Player player, ref int k)
        {
            player.cratePotion = true;
        }
    }}