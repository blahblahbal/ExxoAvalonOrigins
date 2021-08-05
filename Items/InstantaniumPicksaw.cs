using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Items
{
	class InstantaniumPicksaw : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Instantanium Picksaw");
			Tooltip.SetDefault("'The ultimate tool'");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/InstantaniumPicksaw");
			item.damage = 30;
			item.autoReuse = true;
			item.useTurn = true;
			item.scale = 1.15f;
			item.axe = 35;
			item.pick = 350;
			item.rare = 9;
			item.width = dims.Width;
			item.useTime = 5;
			item.knockBack = 5.5f;
			item.melee = true;
			item.tileBoost += 4;
			item.useStyle = 1;
			item.value = 416000;
			item.useAnimation = 11;
			item.height = dims.Height;
            item.UseSound = SoundID.Item1;
		}

        public override void HoldItem(Player player)
        {
            if (player.inventory[player.selectedItem].type == mod.ItemType("InstantaniumPicksaw"))
            {
                player.pickSpeed -= 0.5f;
            }
        }

/*        public override bool UseItem(Player player)
        {
            if (Main.netMode != NetmodeID.Server && player.whoAmI == Main.myPlayer)
            {
                if (Main.tile[Player.tileTargetX, Player.tileTargetY].active())
                {
                    int tileId = player.hitTile.HitObject(Player.tileTargetX, Player.tileTargetY, 1);
                    if (player.inventory[player.selectedItem].pick >= Main.pick[Main.tile[Player.tileTargetX, Player.tileTargetY].type])
                        player.hitTile.AddDamage(tileId, player.inventory[player.selectedItem].pick, true);
                    return true;
                }
            }
            return false;
        }*/
    }
}