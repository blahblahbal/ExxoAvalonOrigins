using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
	class FeroziumPickaxe : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ferozium Pickaxe");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.damage = 17;
			item.autoReuse = true;
			item.useTurn = true;
			item.crit += 6;
			item.pick = 195;
			item.rare = ItemRarityID.Lime;
			item.width = dims.Width;
			item.useTime = 15;
			item.knockBack = 3f;
			item.melee = true;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = 250000;
			item.useAnimation = 15;
			item.height = dims.Height;
            item.UseSound = SoundID.Item1;
        }

        public override void HoldItem(Player player)
        {
            if (player.inventory[player.selectedItem].type == mod.ItemType("FeroziumPickaxe"))
            {
                player.pickSpeed -= 0.5f;
            }
        }
    }
}
