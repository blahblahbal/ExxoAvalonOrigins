using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Items.Tools
{
    class WaterXeradonBucket : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Water Xeradon Bucket");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.autoReuse = true;
            Item.width = dims.Width;
            Item.useTurn = true;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.maxStack = 99;
            Item.useAnimation = 15;
            Item.height = dims.Height;
        }

        public override bool? UseItem(Player player)
        {
            if (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid < 200 &&
                (!Main.tile[Player.tileTargetX, Player.tileTargetY].HasUnactuatedTile ||
                 !Main.tileSolid[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type] ||
                 Main.tileSolidTop[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type]))
            {

                if (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid == 0 || Main.tile[Player.tileTargetX, Player.tileTargetY].liquidType() == 1)
                {
                    Main.PlaySound(SoundID.Splash, (int)player.position.X, (int)player.position.Y, 1);
                    for (int num257 = Player.tileTargetX - 1; num257 <= Player.tileTargetX + 1; num257++)
                    {
                        for (int num258 = Player.tileTargetY - 1; num258 <= Player.tileTargetY + 1; num258++)
                        {
                            Main.tile[num257, num258].liquidType(0);
                            Main.tile[num257, num258].liquid = 255;
                            WorldGen.SquareTileFrame(num257, num258, true);
                            if (Main.netMode == NetmodeID.MultiplayerClient)
                            {
                                NetMessage.sendWater(num257, num258);
                            }
                        }
                    }
                    player.inventory[player.selectedItem].stack--;
                    player.PutItemInInventory(ModContent.ItemType<EmptyXeradonBucket>(), player.selectedItem);
                    player.itemTime = player.inventory[player.selectedItem].useTime;
                }
                else if (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid < 200 &&
                         (!Main.tile[Player.tileTargetX, Player.tileTargetY].HasUnactuatedTile ||
                          !Main.tileSolid[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type] ||
                          Main.tileSolidTop[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type]))
                {
                    if (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid == 0 || Main.tile[Player.tileTargetX, Player.tileTargetY].liquidType() == 0)
                    {
                        Main.PlaySound(SoundID.Splash, (int)player.position.X, (int)player.position.Y, 1);
                        for (int num259 = Player.tileTargetX - 1; num259 <= Player.tileTargetX + 1; num259++)
                        {
                            for (int num260 = Player.tileTargetY - 1; num260 <= Player.tileTargetY + 1; num260++)
                            {
                                Main.tile[num259, num260].liquidType(0);
                                Main.tile[num259, num260].liquid = 255;
                                WorldGen.SquareTileFrame(num259, num260, true);
                                if (Main.netMode == NetmodeID.MultiplayerClient)
                                {
                                    NetMessage.sendWater(num259, num260);
                                }
                            }
                        }
                        player.inventory[player.selectedItem].stack--;
                        player.PutItemInInventory(ModContent.ItemType<EmptyXeradonBucket>(), player.selectedItem);
                        player.itemTime = player.inventory[player.selectedItem].useTime;
                    }
                }
            }

            return false;
        }
    }
}
