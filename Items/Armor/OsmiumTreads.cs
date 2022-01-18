using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    class OsmiumTreads : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Osmium Treads");
            Tooltip.SetDefault("15% increased magic damage");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.defense = 8;
            item.rare = ItemRarityID.Orange;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 1, 20, 0);
            item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Bar.OsmiumBar>(), 17);
            recipe.AddIngredient(ModContent.ItemType<Material.DesertFeather>(), 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void UpdateEquip(Player player)
        {
            player.magicDamage += 0.15f;
        }
    }
}
