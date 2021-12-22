using ExxoAvalonOrigins.Items.Material;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class MeditationsFlame : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Meditation's Flame");
            Tooltip.SetDefault("Tome\n+5% magic damage, -10% mana cost\n+60 mana");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.LightRed;
            item.width = dims.Width;
            item.value = 5000;
            item.height = dims.Height;
            item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().tome = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.magicDamage += 0.05f;
            player.manaCost -= 0.1f;
            player.statManaMax2 += 60;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<RubybeadHerb>(), 5);
            recipe.AddIngredient(ModContent.ItemType<FineLumber>(), 20);
            recipe.AddIngredient(ItemID.FallenStar, 60);
            recipe.AddIngredient(ItemID.MeteoriteBar, 10);
            recipe.AddIngredient(ModContent.ItemType<MysticalTomePage>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
