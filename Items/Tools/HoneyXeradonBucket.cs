using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Items.Tools;

class HoneyXeradonBucket : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Honey Xeradon Bucket");
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
        if (player.whoAmI == Main.myPlayer)
        {
            if (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid < 200 &&
                (!Main.tile[Player.tileTargetX, Player.tileTargetY].HasUnactuatedTile ||
                 !Main.tileSolid[Main.tile[Player.tileTargetX, Player.tileTargetY].type] ||
                 Main.tileSolidTop[Main.tile[Player.tileTargetX, Player.tileTargetY].type]))
            {

                if (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid == 0 || Main.tile[Player.tileTargetX, Player.tileTargetY].liquidType() == 2)
                {
                    Main.PlaySound(SoundID.Splash, (int)player.position.X, (int)player.position.Y, 1);
                    for (int num257 = Player.tileTargetX - 1; num257 <= Player.tileTargetX + 1; num257++)
                    {
                        for (int num258 = Player.tileTargetY - 1; num258 <= Player.tileTargetY + 1; num258++)
                        {
                            Main.tile[num257, num258].liquidType(2);
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
            }
            else if (player.position.X / 16f - Player.tileRangeX -
                     player.inventory[player.selectedItem].tileBoost <= Player.tileTargetX &&
                     (player.position.X + player.width) / 16f + Player.tileRangeX +
                     player.inventory[player.selectedItem].tileBoost - 1f >= Player.tileTargetX &&
                     player.position.Y / 16f - Player.tileRangeY -
                     player.inventory[player.selectedItem].tileBoost <= Player.tileTargetY &&
                     (player.position.Y + player.height) / 16f + Player.tileRangeY +
                     player.inventory[player.selectedItem].tileBoost - 2f >= Player.tileTargetY)
            {
                player.showItemIcon = true;
                if (player.itemTime == 0 && player.itemAnimation > 0 && player.controlUseItem)
                {
                    if (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid < 200 && (!Main.tile[Player.tileTargetX, Player.tileTargetY].HasUnactuatedTile || !Main.tileSolid[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type] || Main.tileSolidTop[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type]))
                    {
                        if (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid == 0 || Main.tile[Player.tileTargetX, Player.tileTargetY].liquidType() == 2)
                        {
                            Main.PlaySound(SoundID.Splash, (int)player.position.X, (int)player.position.Y, 1);
                            for (int num261 = Player.tileTargetX - 1; num261 <= Player.tileTargetX + 1; num261++)
                            {
                                for (int num262 = Player.tileTargetY - 1; num262 <= Player.tileTargetY + 1; num262++)
                                {
                                    Main.tile[num261, num262].liquidType(2);
                                    Main.tile[num261, num262].liquid = 255;
                                    WorldGen.SquareTileFrame(num261, num262, true);
                                    if (Main.netMode == NetmodeID.MultiplayerClient)
                                    {
                                        NetMessage.sendWater(num261, num262);
                                    }
                                }
                            }
                            player.inventory[player.selectedItem].stack--;
                            player.PutItemInInventory(ModContent.ItemType<EmptyXeradonBucket>(), player.selectedItem);
                            player.itemTime = player.inventory[player.selectedItem].useTime;
                        }
                    }
                }
            }
        }
        return false;
    }
}