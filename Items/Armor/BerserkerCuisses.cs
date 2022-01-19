using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    class BerserkerCuisses : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Berserker Cuisses");
            Tooltip.SetDefault("Melee stealth when standing still\nLightning strikes when damaged");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.defense = 32;
            item.rare = ItemRarityID.Red;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 65, 0, 0);
            item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Bar.BerserkerBar>(), 17);
            recipe.AddIngredient(ModContent.ItemType<AncientLeggings>());
            recipe.AddIngredient(ModContent.ItemType<Placeable.Tile.Onyx>(), 15);
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void UpdateEquip(Player player)
        {
            player.Avalon().LightningInABottle = true;
            player.Avalon().meleeStealth = true;
        }
    }
}
