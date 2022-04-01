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
            Item.defense = 32;
            Item.rare = ItemRarityID.Red;
            Item.width = dims.Width;
            Item.value = Item.sellPrice(0, 65, 0, 0);
            Item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ModContent.ItemType<Placeable.Bar.BerserkerBar>(), 17).AddIngredient(ModContent.ItemType<AncientLeggings>()).AddIngredient(ModContent.ItemType<Placeable.Tile.Onyx>(), 15).AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();
        }
        public override void UpdateEquip(Player player)
        {
            player.Avalon().LightningInABottle = true;
            player.Avalon().meleeStealth = true;
        }
    }
}
