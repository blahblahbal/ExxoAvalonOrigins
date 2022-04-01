using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    class XeradonLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xeradon Leggings");
            Tooltip.SetDefault("10% increased mining speed\n10% increased block placement speed");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.defense = 10;
            Item.rare = ItemRarityID.Pink;
            Item.width = dims.Width;
            Item.value = Item.sellPrice(0, 2);
            Item.height = dims.Height;
        }

        public override void UpdateEquip(Player player)
        {
            player.wallSpeed += 0.1f;
            player.tileSpeed += 0.1f;
            player.pickSpeed -= 0.1f;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ItemID.MiningPants).AddIngredient(ItemID.AdamantiteBar, 3).AddIngredient(ItemID.TitaniumBar, 3).AddIngredient(ModContent.ItemType<Placeable.Bar.TroxiniumBar>(), 3).AddTile(TileID.MythrilAnvil).Register();
        }
    }
}
