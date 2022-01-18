using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    class BerserkerBodyarmor : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Berserker Bodyarmor");
            Tooltip.SetDefault("Enemies are more likely to target you"
                + "\nTaking heavy damage will give you the 'Berserk!' buff"
                + "\n'Berserk!' gives a massive buff to the critical strike damage of true melee weapons");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.defense = 42;
            item.rare = ItemRarityID.Red;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 60, 0, 0);
            item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Bar.BerserkerBar>(), 23);
            recipe.AddIngredient(ModContent.ItemType<AncientBodyplate>());
            recipe.AddIngredient(ModContent.ItemType<Placeable.Tile.Onyx>(), 15);
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void UpdateEquip(Player player)
        {
            player.aggro += 600;
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().goBerserk = true;
        }
    }
}
