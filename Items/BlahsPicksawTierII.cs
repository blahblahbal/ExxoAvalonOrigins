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
	class BlahsPicksawTierII : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blah's Picksaw (Tier II)");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/BlahsPicksawTierII");
			item.damage = 55;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.scale = 1.15f;
			item.axe = 60;
			item.pick = 700;
			item.rare = 12;
			item.width = dims.Width;
			item.useTime = 6;
			item.knockBack = 5.5f;
			item.melee = true;
			item.tileBoost += 8;
			item.useStyle = 1;
			item.value = 5016000;
			item.useAnimation = 6;
			item.height = dims.Height;
		}

        public override void HoldItem(Player player)
        {
            if (player.inventory[player.selectedItem].type == mod.ItemType("BlahsPicksawTierII"))
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
                    if (player.inventory[player.selectedItem].pick >= ExxoAvalonOrigins.minPick[Main.tile[Player.tileTargetX, Player.tileTargetY].type])
                        player.hitTile.AddDamage(tileId, player.inventory[player.selectedItem].pick, true);
                    return true;
                }
            }
            return false;
        }*/
    }
}