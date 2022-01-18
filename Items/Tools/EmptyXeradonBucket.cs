using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
    class EmptyXeradonBucket : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Empty Xeradon Bucket");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.autoReuse = true;
            item.width = dims.Width;
            item.useTurn = true;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.maxStack = 99;
            item.useAnimation = 15;
            item.height = dims.Height;
        }

        public override bool UseItem(Player player)
        {
            if (player.position.X / 16f - (float)Player.tileRangeX - (float)player.inventory[player.selectedItem].tileBoost <= (float)Player.tileTargetX && (player.position.X + (float)player.width) / 16f + (float)Player.tileRangeX + (float)player.inventory[player.selectedItem].tileBoost - 1f >= (float)Player.tileTargetX && player.position.Y / 16f - (float)Player.tileRangeY - (float)player.inventory[player.selectedItem].tileBoost <= (float)Player.tileTargetY && (player.position.Y + (float)player.height) / 16f + (float)Player.tileRangeY + (float)player.inventory[player.selectedItem].tileBoost - 2f >= (float)Player.tileTargetY)
            {
                player.showItemIcon = true;
                if (player.itemTime == 0 && player.itemAnimation > 0 && player.controlUseItem)
                {
                    int num247 = (int)Main.tile[Player.tileTargetX, Player.tileTargetY].liquidType();
                    int num248 = 0;
                    for (int num249 = Player.tileTargetX - 1; num249 <= Player.tileTargetX + 1; num249++)
                    {
                        for (int num250 = Player.tileTargetY - 1; num250 <= Player.tileTargetY + 1; num250++)
                        {
                            if ((int)Main.tile[num249, num250].liquidType() == num247)
                            {
                                num248 += (int)Main.tile[num249, num250].liquid;
                            }
                        }
                    }
                    if (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid > 0 && num248 > 100)
                    {
                        int liquidType2 = (int)Main.tile[Player.tileTargetX, Player.tileTargetY].liquidType();
                        if (!Main.tile[Player.tileTargetX, Player.tileTargetY].lava())
                        {
                            if (Main.tile[Player.tileTargetX, Player.tileTargetY].honey())
                            {
                                player.inventory[player.selectedItem].stack--;
                                player.PutItemInInventory(ModContent.ItemType<HoneyXeradonBucket>(), player.selectedItem);
                            }
                            else
                            {
                                player.inventory[player.selectedItem].stack--;
                                player.PutItemInInventory(ModContent.ItemType<WaterXeradonBucket>(), player.selectedItem);
                            }
                        }
                        else
                        {
                            player.inventory[player.selectedItem].stack--;
                            player.PutItemInInventory(ModContent.ItemType<LavaXeradonBucket>(), player.selectedItem);
                        }
                        Main.PlaySound(SoundID.Splash, (int)player.position.X, (int)player.position.Y, 1);
                        player.itemTime = player.inventory[player.selectedItem].useTime;
                        int num251 = (int)Main.tile[Player.tileTargetX, Player.tileTargetY].liquid;
                        for (int num252 = Player.tileTargetX - 1; num252 <= Player.tileTargetX + 1; num252++)
                        {
                            for (int num253 = Player.tileTargetY - 1; num253 <= Player.tileTargetY + 1; num253++)
                            {
                                Main.tile[num252, num253].liquid = 0;
                                Main.tile[num252, num253].lava(false);
                                Main.tile[num252, num253].honey(false);
                                WorldGen.SquareTileFrame(num252, num253, false);
                                if (Main.netMode == NetmodeID.MultiplayerClient)
                                {
                                    NetMessage.sendWater(num252, num253);
                                }
                                else
                                {
                                    Liquid.AddWater(num252, num253);
                                }
                            }
                        }
                        for (int num254 = Player.tileTargetX - 1; num254 <= Player.tileTargetX + 1; num254++)
                        {
                            for (int num255 = Player.tileTargetY - 1; num255 <= Player.tileTargetY + 1; num255++)
                            {
                                if (num251 < 256 && (int)Main.tile[num254, num255].liquidType() == num247)
                                {
                                    int num256 = (int)Main.tile[num254, num255].liquid;
                                    if (num256 + num251 > 255)
                                    {
                                        num256 = 255 - num251;
                                    }
                                    num251 += num256;
                                    Tile tile3 = Main.tile[num254, num255];
                                    Tile expr_AD6A = tile3;
                                    expr_AD6A.liquid -= (byte)num256;
                                    Main.tile[num254, num255].liquidType(liquidType2);
                                    if (Main.tile[num254, num255].liquid == 0)
                                    {
                                        Main.tile[num254, num255].lava(false);
                                        Main.tile[num254, num255].honey(false);
                                    }
                                    WorldGen.SquareTileFrame(num254, num255, false);
                                    if (Main.netMode == NetmodeID.MultiplayerClient)
                                    {
                                        NetMessage.sendWater(num254, num255);
                                    }
                                    else
                                    {
                                        Liquid.AddWater(num254, num255);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
    }
}
