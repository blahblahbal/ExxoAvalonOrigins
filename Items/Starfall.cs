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
	class Starfall : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Starfall");
			Tooltip.SetDefault("'The power of the stars consumes your mana'");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/Starfall");
			item.magic = true;
			item.damage = 1000;
			item.mana = 400;
			item.noMelee = true;
			item.rare = ItemRarityID.Yellow;
			item.width = dims.Width;
			item.knockBack = 16f;
			item.useTime = 35;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.value = Item.sellPrice(0, 40, 0, 0);
			item.useAnimation = 35;
			item.height = dims.Height;
		}

        public override bool UseItem(Player player)
        {
            if (player.itemTime == 0)
            {
                player.itemTime = player.inventory[player.selectedItem].useTime;
            }
            else
            {
                if (player.itemTime == player.inventory[player.selectedItem].useTime / 2)
                {
                    float x = (float)(Main.mouseX + Main.screenPosition.X);
                    float y = (float)(Main.mouseY + Main.screenPosition.Y) - (float)Main.rand.Next(500, 800);
                    float speedX = 0;
                    float speedY = 14.9f;
                    int type = 12;
                    int damage = (int)(player.inventory[player.selectedItem].damage * player.magicDamage);
                    float knockback = 16f;
                    int owner = player.whoAmI;
                    int projID = Projectile.NewProjectile(x, y, speedX, speedY, type, damage, knockback, owner);
                }
            }
            return true;
        }
    }
}