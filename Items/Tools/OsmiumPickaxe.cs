using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
	class OsmiumPickaxe : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Osmium Pickaxe");
			Tooltip.SetDefault("Can mine Hellstone");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.damage = 13;
			item.autoReuse = true;
			item.useTurn = true;
			item.crit += 6;
			item.pick = 82;
			item.rare = ItemRarityID.Orange;
			item.width = dims.Width;
			item.useTime = 13;
			item.knockBack = 3f;
			item.melee = true;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = 50000;
			item.useAnimation = 13;
			item.height = dims.Height;
            item.UseSound = SoundID.Item1;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Bar.OsmiumBar>(), 13);
            recipe.AddIngredient(ModContent.ItemType<Material.DesertFeather>(), 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void HoldItem(Player player)
        {
            if (player.inventory[player.selectedItem].type == mod.ItemType("OsmiumPickaxe"))
            {
                player.pickSpeed -= 0.5f;
            }
        }
    }
}
