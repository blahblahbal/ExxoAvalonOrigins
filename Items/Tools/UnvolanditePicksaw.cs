using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
    class UnvolanditePicksaw : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Unvolandite Picksaw");
            Tooltip.SetDefault("Can mine Oblivion Ore");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.damage = 30;
            item.autoReuse = true;
            item.useTurn = true;
            item.scale = 1.15f;
            item.axe = 22;
            item.pick = 300;
            item.rare = ItemRarityID.Cyan;
            item.width = dims.Width;
            item.useTime = 9;
            item.knockBack = 5.5f;
            item.melee = true;
            item.tileBoost += 5;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = 416000;
            item.useAnimation = 11;
            item.height = dims.Height;
        }
        public override void HoldItem(Player player)
        {
            if (player.inventory[player.selectedItem].type == item.type)
            {
                player.pickSpeed -= 0.35f;
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Bar.UnvolanditeBar>(), 20);
            recipe.AddIngredient(ModContent.ItemType<Material.SoulofBlight>(), 5);
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
