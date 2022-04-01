using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
    class GemWand : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gem Wand");
            Tooltip.SetDefault("Places ore-form gems");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.autoReuse = true;
            Item.width = dims.Width;
            Item.useTurn = true;
            Item.useTime = 15;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 15;
            Item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ItemID.IronBar, 6).AddIngredient(ItemID.Sapphire).AddIngredient(ItemID.Ruby).AddIngredient(ItemID.Emerald).AddIngredient(ItemID.Topaz).AddIngredient(ItemID.Amethyst).AddIngredient(ItemID.Diamond).AddTile(TileID.TinkerersWorkbench).Register();
        }
        public override bool? UseItem(Player player)
        {
            Vector2 mousePosition = Main.MouseWorld;
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                player.Avalon().MousePosition = mousePosition;
                Network.CursorPosition.SendPacket(mousePosition, player.whoAmI);
            }
            else if (Main.netMode == NetmodeID.SinglePlayer)
            {
                player.Avalon().MousePosition = mousePosition;
            }
            Point mpTile = player.Avalon().MousePosition.ToTileCoordinates();
            if (Main.myPlayer == player.whoAmI)
            {
                for (int q = 0; q < player.inventory.Length; q++)
                {
                    int t = player.inventory[q].type;
                    bool inrange = (player.position.X / 16f - Player.tileRangeX - player.inventory[player.selectedItem].tileBoost - player.blockRange <= mpTile.X &&
                        (player.position.X + player.width) / 16f + Player.tileRangeX + player.inventory[player.selectedItem].tileBoost - 1f + player.blockRange >= mpTile.X &&
                        player.position.Y / 16f - Player.tileRangeY - player.inventory[player.selectedItem].tileBoost - player.blockRange <= mpTile.Y &&
                        (player.position.Y + player.height) / 16f + Player.tileRangeY + player.inventory[player.selectedItem].tileBoost - 2f + player.blockRange >= mpTile.Y);
                    if (ExxoAvalonOriginsGlobalItem.gems.Contains(t) && t != 0)
                    {
                        if (!Main.tile[mpTile.X, mpTile.Y].HasTile && inrange)
                        {
                            bool subtractFromStack = WorldGen.PlaceTile(mpTile.X, mpTile.Y, ExxoAvalonOriginsGlobalItem.GemToTile(t));
                            if (Main.tile[mpTile.X, mpTile.Y].HasTile && Main.netMode != NetmodeID.SinglePlayer && subtractFromStack)
                            {
                                NetMessage.SendData(MessageID.TileChange, -1, -1, null, 1, mpTile.X, mpTile.Y, ExxoAvalonOriginsGlobalItem.GemToTile(t));
                            }
                            if (subtractFromStack)
                            {
                                player.inventory[q].stack--;
                                if (player.inventory[q].stack <= 0)
                                {
                                    player.inventory[q] = new Item();
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
            }
            return true;
        }
    }
}
