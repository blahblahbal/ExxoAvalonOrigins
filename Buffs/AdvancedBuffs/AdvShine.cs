using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.DataStructures;namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs{
    public class AdvShine : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Shine");
            Description.SetDefault("Emitting a lot of light");
        }

        public override void Update(Player player, ref int k)
        {
            Lighting.AddLight((int)(player.position.X + (player.width / 2)) / 16, (int)(player.position.Y + (player.height / 2)) / 16, 2f, 2f, 2f);
        }
    }}