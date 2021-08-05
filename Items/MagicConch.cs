using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{
    class MagicConch : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magic Conch");
            Tooltip.SetDefault("If you listen closely, you can hear the ocean");
        }

        public override void SetDefaults()
        {
            item.rare = 1;
            item.width = 24;
            item.useTime = 90;
            item.useTurn = true;
            item.value = Item.sellPrice(0, 1);
            item.useStyle = 4;            item.UseSound = SoundID.Item6;
            item.useAnimation = 90;
            item.height = 24;
        }        public override void HoldItem(Player player)
        {
            if (player.itemAnimation > 0 && player.whoAmI == Main.myPlayer)
            {
                if (Main.rand.Next(2) == 0)
                {
                    Dust.NewDust(player.position, player.width, player.height, 15, 0f, 0f, 150, default(Color), 1.1f);
                }
                if (player.itemTime == 0)
                {
                    player.itemTime = player.inventory[player.selectedItem].useTime;
                }
                else if (player.itemTime == player.inventory[player.selectedItem].useTime / 2)
                {
                    for (int num365 = 0; num365 < 70; num365++)
                    {
                        Dust.NewDust(player.position, player.width, player.height, 15, player.velocity.X * 0.5f, player.velocity.Y * 0.5f, 150, default(Color), 1.5f);
                    }
                    player.grappling[0] = -1;
                    player.grapCount = 0;
                    for (int num366 = 0; num366 < 1000; num366++)
                    {
                        if (Main.projectile[num366].active && Main.projectile[num366].owner == player.whoAmI && Main.projectile[num366].aiStyle == 7)
                        {
                            Main.projectile[num366].Kill();
                        }
                    }
                    player.GetModPlayer<ExxoAvalonOriginsModPlayer>().shadowTele = true;
                    if (Main.rand.Next(2) == 0) player.GetModPlayer<ExxoAvalonOriginsModPlayer>().ShadowTP(3, player.whoAmI);
                    else player.GetModPlayer<ExxoAvalonOriginsModPlayer>().ShadowTP(4, player.whoAmI);
                    player.GetModPlayer<ExxoAvalonOriginsModPlayer>().shadowTele = false;
                    for (int num367 = 0; num367 < 70; num367++)
                    {
                        Dust.NewDust(player.position, player.width, player.height, 15, 0f, 0f, 150, default(Color), 1.5f);
                    }
                }
            }
        }
    }}