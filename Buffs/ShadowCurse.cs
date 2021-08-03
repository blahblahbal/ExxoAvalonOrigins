using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.DataStructures;namespace ExxoAvalonOrigins.Buffs{
    public class ShadowCurse : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Shadow Curse");
            Description.SetDefault("You take double damage");
            Main.debuff[Type] = true;
            canBeCleared = false;
        }
    }}