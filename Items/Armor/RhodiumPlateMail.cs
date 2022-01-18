using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    class RhodiumPlateMail : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rhodium Plate Mail");
            Tooltip.SetDefault("10% increased melee damage and speed");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.defense = 7;
            item.rare = ItemRarityID.Orange;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Bar.RhodiumBar>(), 20);
            recipe.AddIngredient(ModContent.ItemType<Material.DesertFeather>(), 6);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void UpdateEquip(Player player)
        {
            player.meleeDamage += 0.1f;
            player.meleeSpeed += 0.1f;
        }
    }
}
