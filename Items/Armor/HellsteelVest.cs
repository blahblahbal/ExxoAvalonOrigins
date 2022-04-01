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
            Item.defense = 29;
            Item.rare = ItemRarityID.Cyan;
            Item.width = dims.Width;
            Item.value = Item.sellPrice(0, 12, 0, 0);
            Item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ModContent.ItemType<Material.HellsteelPlate>(), 25).AddIngredient(ModContent.ItemType<FleshWrappings>()).AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();
        }
        public override void UpdateEquip(Player player)
        {
            player.minionKB += 0.25f;
            player.maxMinions++;
        }
    }
}
