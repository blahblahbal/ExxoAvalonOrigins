﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
	class PinkDungeonWand : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pink Dungeon Wand");
			Tooltip.SetDefault("Places unsafe pink dungeon walls");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.autoReuse = true;
			item.rare = ItemRarityID.Blue;
			item.width = dims.Width;
			item.useTurn = true;
			item.useTime = 7;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 15;
			item.height = dims.Height;
		}
        public override bool UseItem(Player player)
        {
            if (Main.myPlayer == player.whoAmI)
            {
                for (int q = 0; q < player.inventory.Length; q++)
                {
                    int type = player.inventory[q].type;
                    bool inrange = (player.position.X / 16f - Player.tileRangeX - player.inventory[player.selectedItem].tileBoost - player.blockRange <= Player.tileTargetX &&
                        (player.position.X + player.width) / 16f + Player.tileRangeX + player.inventory[player.selectedItem].tileBoost - 1f + player.blockRange >= Player.tileTargetX &&
                        player.position.Y / 16f - Player.tileRangeY - player.inventory[player.selectedItem].tileBoost - player.blockRange <= Player.tileTargetY &&
                        (player.position.Y + player.height) / 16f + Player.tileRangeY + player.inventory[player.selectedItem].tileBoost - 2f + player.blockRange >= Player.tileTargetY);
                    if (type == ItemID.PinkTiledWall || type == ItemID.PinkBrickWall || type == ItemID.PinkSlabWall)
                    {
                        if (Main.tile[Player.tileTargetX, Player.tileTargetY].wall == 0 && inrange)
                        {
                            WorldGen.PlaceWall(Player.tileTargetX, Player.tileTargetY, ExxoAvalonOriginsGlobalItem.DungeonWallItemToBackwallID(type));
                            if (Main.tile[Player.tileTargetX, Player.tileTargetY].wall != 0 && Main.netMode != NetmodeID.SinglePlayer)
                            {
                                NetMessage.SendData(MessageID.TileChange, -1, -1, null, 3, Player.tileTargetX, Player.tileTargetY, ExxoAvalonOriginsGlobalItem.DungeonWallItemToBackwallID(type));
                            }
                            player.inventory[q].stack--;
                            if (player.inventory[q].stack <= 0)
                            {
                                player.inventory[q] = new Item();
                                break;
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
