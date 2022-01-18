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
            item.autoReuse = true;
            item.width = dims.Width;
            item.useTurn = true;
            item.useTime = 15;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 15;
            item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronBar, 6);
            recipe.AddIngredient(ItemID.Sapphire);
            recipe.AddIngredient(ItemID.Ruby);
            recipe.AddIngredient(ItemID.Emerald);
            recipe.AddIngredient(ItemID.Topaz);
            recipe.AddIngredient(ItemID.Amethyst);
            recipe.AddIngredient(ItemID.Diamond);
            recipe.anyIronBar = true;
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool UseItem(Player player)
        {
            if (Main.myPlayer == player.whoAmI)
            {
                for (int q = 0; q < player.inventory.Length; q++)
                {
                    int t = player.inventory[q].type;
                    bool inrange = (player.position.X / 16f - Player.tileRangeX - player.inventory[player.selectedItem].tileBoost - player.blockRange <= Player.tileTargetX &&
                        (player.position.X + player.width) / 16f + Player.tileRangeX + player.inventory[player.selectedItem].tileBoost - 1f + player.blockRange >= Player.tileTargetX &&
                        player.position.Y / 16f - Player.tileRangeY - player.inventory[player.selectedItem].tileBoost - player.blockRange <= Player.tileTargetY &&
                        (player.position.Y + player.height) / 16f + Player.tileRangeY + player.inventory[player.selectedItem].tileBoost - 2f + player.blockRange >= Player.tileTargetY);
                    if (ExxoAvalonOriginsGlobalItem.gems.Contains(t) && t != 0)
                    {
                        if (!Main.tile[Player.tileTargetX, Player.tileTargetY].active() && inrange)
                        {
                            bool subtractFromStack = WorldGen.PlaceTile(Player.tileTargetX, Player.tileTargetY, ExxoAvalonOriginsGlobalItem.GemToTile(t));
                            if (Main.tile[Player.tileTargetX, Player.tileTargetY].active() && Main.netMode != NetmodeID.SinglePlayer && subtractFromStack)
                            {
                                NetMessage.SendData(MessageID.TileChange, -1, -1, null, 1, Player.tileTargetX, Player.tileTargetY, ExxoAvalonOriginsGlobalItem.GemToTile(t));
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
