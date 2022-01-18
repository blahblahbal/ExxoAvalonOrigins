using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    class HellsteelVest : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hellsteel Vest");
            Tooltip.SetDefault("25% increased minion knockback\nIncreases your max number of minions by 1");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.defense = 29;
            item.rare = ItemRarityID.Cyan;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 12, 0, 0);
            item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Material.HellsteelPlate>(), 25);
            recipe.AddIngredient(ModContent.ItemType<FleshWrappings>());
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void UpdateEquip(Player player)
        {
            player.minionKB += 0.25f;
            player.maxMinions++;
        }
    }
}
