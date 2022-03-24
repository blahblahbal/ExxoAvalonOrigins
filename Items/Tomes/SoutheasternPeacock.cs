using ExxoAvalonOrigins.Items.Material;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tomes
{
    class SoutheasternPeacock : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Southeastern Peacock");
            Tooltip.SetDefault("Tome\n+3% critical strike chance, -5% mana cost\n8% increased minion damage, 5% increased minion knockback");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.LightPurple;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 0, 40);
            item.height = dims.Height;
            item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().tome = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.meleeCrit += 3;
            player.rangedCrit += 3;
            player.thrownCrit += 3;
            player.magicCrit += 3;
            player.minionKB += 0.05f;
            player.minionDamage += 0.08f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<TomorrowsPhoenix>());
            recipe.AddIngredient(ModContent.ItemType<ChristmasTome>());
            recipe.AddIngredient(ModContent.ItemType<MysticalTomePage>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
