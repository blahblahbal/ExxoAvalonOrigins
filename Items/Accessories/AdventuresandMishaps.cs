using ExxoAvalonOrigins.Items.Material;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    public class AdventuresandMishaps : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Adventures and Mishaps");
            Tooltip.SetDefault("+60 HP, +5% damage\n-10% mana cost");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Lime;
            item.width = dims.Width;
            item.value = 20000;
            item.height = dims.Height;
            item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().tome = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statLifeMax2 += 60;
            player.magicDamage += 0.05f;
            player.minionDamage += 0.05f;
            player.meleeDamage += 0.05f;
            player.rangedDamage += 0.05f;
            player.thrownDamage += 0.05f;
            player.manaCost -= 0.1f;
        }

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LifeCrystal, 2);
            recipe.AddIngredient(ModContent.ItemType<FineLumber>(), 10);
            recipe.AddIngredient(ModContent.ItemType<CarbonSteel>(), 5);
            recipe.AddIngredient(ModContent.ItemType<RubybeadHerb>(), 10);
            recipe.AddIngredient(ModContent.ItemType<MysticalTomePage>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
