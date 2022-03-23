using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class AmuletofPower : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Amulet of Power");
            Tooltip.SetDefault("Increases all stats");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.LightRed;
            item.width = dims.Width;
            item.accessory = true;
            item.value = Item.sellPrice(0, 0, 90);
            item.height = dims.Height;
            item.defense = 3;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.allDamage += 0.07f;
            player.AllCrit(5);
            player.statManaMax2 += 40;
            player.statLifeMax2 += 40;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<AmethystAmulet>());
            recipe.AddIngredient(ModContent.ItemType<TopazAmulet>());
            recipe.AddIngredient(ModContent.ItemType<SapphireAmulet>());
            recipe.AddIngredient(ModContent.ItemType<EmeraldAmulet>());
            recipe.AddIngredient(ModContent.ItemType<RubyAmulet>());
            recipe.AddIngredient(ModContent.ItemType<DiamondAmulet>());
            recipe.AddIngredient(ModContent.ItemType<TourmalineAmulet>());
            recipe.AddIngredient(ModContent.ItemType<PeridotAmulet>());
            recipe.AddIngredient(ModContent.ItemType<ZirconAmulet>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
