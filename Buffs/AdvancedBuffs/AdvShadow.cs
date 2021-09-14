using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs
{
    public class AdvShadow : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Shadows");
            Description.SetDefault("You can teleport to the cursor, press V");
        }

        public override void Update(Player player, ref int k)
        {
            if (player.GetModPlayer<ExxoAvalonOriginsModPlayer>().shadowPotCd > 300)
            {
                player.GetModPlayer<ExxoAvalonOriginsModPlayer>().shadowPotCd = 300;
            }
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().shadowPotCd++;
            if (ExxoAvalonOrigins.shadowHotkey.JustPressed && player.GetModPlayer<ExxoAvalonOriginsModPlayer>().shadowPotCd >= 300 && !Main.editChest && !Main.editSign && !Main.drawingPlayerChat)
            {
                player.GetModPlayer<ExxoAvalonOriginsModPlayer>().shadowPotCd = 0;
                for (var num10 = 0; num10 < 70; num10++)
                {
                    Dust.NewDust(player.position, player.width, player.height, DustID.MagicMirror, player.velocity.X * 0.5f, player.velocity.Y * 0.5f, 150, default(Color), 1.1f);
                }
                player.position.X = Main.mouseX + Main.screenPosition.X;
                player.position.Y = Main.mouseY + Main.screenPosition.Y;
                for (var num11 = 0; num11 < 70; num11++)
                {
                    Dust.NewDust(player.position, player.width, player.height, DustID.MagicMirror, 0f, 0f, 150, default(Color), 1.1f);
                }
            }
        }
    }
}