using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace ExxoAvalonOrigins.Buffs
{
	public class Shadows : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Shadows");
			Description.SetDefault("You can teleport to the cursor, press V");
		}

		public override void Update(Player player, ref int k)
		{
			if (player.GetModPlayer<ExxoAvalonOriginsModPlayer>().shadowPotCd > 300)
			{
				player.GetModPlayer<ExxoAvalonOriginsModPlayer>().shadowPotCd = 300;
			}
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().shadowPotCd++;
            if (ExxoAvalonOrigins.mod.shadowHotkey.JustPressed && player.GetModPlayer<ExxoAvalonOriginsModPlayer>().shadowPotCd >= 300 && !Main.editChest && !Main.editSign && !Main.drawingPlayerChat)
            {
                player.GetModPlayer<ExxoAvalonOriginsModPlayer>().shadowPotCd = 0;
                for (int num10 = 0; num10 < 70; num10++)
                {
                    Dust.NewDust(player.position, player.width, player.height, DustID.MagicMirror, player.velocity.X * 0.5f, player.velocity.Y * 0.5f, 150, default(Color), 1.1f);
                }
                if (Main.tile[(int)(Main.mouseX + Main.screenPosition.X), (int)(Main.mouseY + Main.screenPosition.Y)].wall != ModContent.WallType<Walls.ImperviousBrickWallUnsafe>())
                {
                    player.position.X = Main.mouseX + Main.screenPosition.X;
                    player.position.Y = Main.mouseY + Main.screenPosition.Y;
                }
                for (int num11 = 0; num11 < 70; num11++)
                {
                    Dust.NewDust(player.position, player.width, player.height, DustID.MagicMirror, 0f, 0f, 150, default, 1.1f);
                }
            }
		}
	}
}
