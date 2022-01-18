using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
    class TimechangerMkII : ModItem
    {
        enum Time
        {
            day,
            midday,
            night,
            midnight
        }
        Time selectedTime;
        int time;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Timechanger Mk II");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.LightPurple;
            item.width = dims.Width;
            item.height = dims.Height;
            item.useTime = 35;
            item.useAnimation = 35;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.value = Item.sellPrice(0, 3, 70, 0);
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool UseItem(Player player)
        {
            if (player.altFunctionUse == 2) // right click
            {
                selectedTime = (Time)(((int)selectedTime + 1) % 4);
            }

            string selectedString = "";
            switch (selectedTime)
            {
                case Time.day:
                    selectedString = "Day";
                    time = 0;
                    break;
                case Time.midday:
                    selectedString = "Noon";
                    time = 1;
                    break;
                case Time.night:
                    selectedString = "Night";
                    time = 2;
                    break;
                case Time.midnight:
                    selectedString = "Midnight";
                    time = 3;
                    break;
            }

            if (player.altFunctionUse == 2) // right click
            {
                Main.NewText(String.Format("Mode set to {0}.", selectedString), 50, 255, 130, false);
                //           if (Main.netMode == NetmodeID.SinglePlayer)
                //               Main.NewText(String.Format("Mode set to {0}.", selectedString), 50, 255, 130, false);
                //           else if (Main.netMode == NetmodeID.Server)
                //NetMessage.BroadcastChatMessage(NetworkText.FromLiteral(String.Format("Mode set to {0}.", selectedString)), new Color(50, 255, 130));
            }
            else
            {
                if (player.itemAnimation > 0 && player.whoAmI == Main.myPlayer)
                {
                    int p = Projectile.NewProjectile(player.position, Vector2.Zero, ModContent.ProjectileType<Projectiles.TimechangerMkII>(), 0, 0);
                    Main.projectile[p].ai[0] = time;
                }
                //switch (selectedTime)
                //{
                //	case Time.day:
                //		Main.dayTime = true;
                //		Main.time = 0;
                //                    Logic.ChangeTime.TimeChange(0, dayTime: true);
                //                    break;
                //	case Time.midday:
                //		Main.dayTime = true;
                //		Main.time = 27000;
                //                    Logic.ChangeTime.TimeChange(27000, dayTime: true);
                //                    break;
                //	case Time.night:
                //		Main.dayTime = false;
                //		Main.time = 0;
                //                    Logic.ChangeTime.TimeChange(0, dayTime: false);
                //                    break;
                //	case Time.midnight:
                //		Main.dayTime = false;
                //		Main.time = 16200;
                //                    Logic.ChangeTime.TimeChange(16200, dayTime: false);
                //                    break;
                //}

                //if (Main.netMode == NetmodeID.SinglePlayer)
                //	Main.NewText(String.Format("It is now {0}.", selectedString), 50, 255, 130, false);
                //else if (Main.netMode == NetmodeID.Server)
                //	NetMessage.BroadcastChatMessage(NetworkText.FromLiteral(String.Format("It is now {0}.", selectedString)), new Color(50, 255, 130));
            }

            return true;
        }
    }
}
