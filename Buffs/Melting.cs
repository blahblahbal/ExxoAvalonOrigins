using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.DataStructures;namespace ExxoAvalonOrigins.Buffs{
    public class Melting : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Melting");
            Description.SetDefault("I'm melting...!");
            Main.debuff[Type] = true;
        }

        public override void Update(Player player, ref int k)
        {
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().melting = true;
        }
    }}