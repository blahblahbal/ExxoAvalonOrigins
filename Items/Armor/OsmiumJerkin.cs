using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    class OsmiumJerkin : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Osmium Jerkin");
            Tooltip.SetDefault("12% increased melee damage and speed");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.defense = 8;
            Item.rare = ItemRarityID.Orange;
            Item.width = dims.Width;
            Item.value = Item.sellPrice(0, 1, 20, 0);
            Item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ModContent.ItemType<Placeable.Bar.OsmiumBar>(), 20).AddIngredient(ModContent.ItemType<Material.DesertFeather>(), 6).AddTile(TileID.Anvils).Register();
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Melee) += 0.12f;
            player.meleeSpeed += 0.12f;
        }
    }
}
