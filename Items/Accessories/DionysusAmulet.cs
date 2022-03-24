using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class DionysusAmulet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dionysus Amulet");
            Tooltip.SetDefault("Increases your max number of minions by 2\n8% increased minion damage\nIncreases armor penetration by 5");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Pink;
            item.width = dims.Width;
            item.accessory = true;
            item.value = Item.sellPrice(0, 2);
            item.height = dims.Height;
            item.defense = 3;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.maxMinions += 2;
            player.minionDamage += 0.08f;
            player.armorPenetration += 5;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<PygmyShield>());
            recipe.AddIngredient(ModContent.ItemType<PeridotAmulet>());
            recipe.AddIngredient(ItemID.SharkToothNecklace);
            recipe.SetResult(this);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.AddRecipe();
        }
    }
}
