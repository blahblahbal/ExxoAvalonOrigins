using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
	class RhodiumPickaxe : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rhodium Pickaxe");
			Tooltip.SetDefault("Can mine Hellstone");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.damage = 11;
			item.autoReuse = true;
			item.useTurn = true;
			item.crit += 5;
			item.pick = 65;
			item.rare = ItemRarityID.Orange;
			item.width = dims.Width;
			item.useTime = 13;
			item.knockBack = 2f;
			item.melee = true;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = 50000;
			item.useAnimation = 15;
			item.height = dims.Height;
            item.UseSound = SoundID.Item1;
        }

        public override void HoldItem(Player player)
        {
            if (player.inventory[player.selectedItem].type == mod.ItemType("RhodiumPickaxe"))
            {
                player.pickSpeed -= 0.5f;
            }
        }
    }
}
