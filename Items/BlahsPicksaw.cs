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
	class BlahsPicksaw : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blah's Picksaw");
			Tooltip.SetDefault("The user can mine at warp speed");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/BlahsPicksaw");
			item.UseSound = SoundID.Item1;
			item.damage = 50;
			item.autoReuse = true;
			item.useTurn = true;
			item.scale = 1.15f;
			item.axe = 50;
			item.pick = 425;
			item.rare = ItemRarityID.Red;
			item.width = dims.Width;
			item.useTime = 7;
			item.knockBack = 7f;
			item.melee = true;
			item.tileBoost += 6;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = 1016000;
			item.useAnimation = 7;
			item.height = dims.Height;
		}

        public override void HoldItem(Player player)
        {
            if (player.inventory[player.selectedItem].type == mod.ItemType("BlahsPicksaw"))
            {
                player.pickSpeed -= 0.5f;
            }
        }

/*        public override bool UseItem(Player player)
        {
            if (Main.netMode != NetmodeID.Server)
            {
                if (Main.tile[Player.tileTargetX, Player.tileTargetY].active())
                {
                    int tileId = player.hitTile.HitObject(Player.tileTargetX, Player.tileTargetY, 1);
                    if (player.inventory[player.selectedItem].pick >= ExxoAvalonOrigins.minPick[Main.tile[Player.tileTargetX, Player.tileTargetY].type])
                        player.hitTile.AddDamage(tileId, player.inventory[player.selectedItem].pick, true);
                    return true;
                }
            }
            return false;
        }*/
    }
}