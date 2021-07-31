using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.DataStructures;namespace ExxoAvalonOrigins.Buffs{
    public class Starbright : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Starbright");
            Description.SetDefault("Fallen stars fall more frequently");
        }
    }}