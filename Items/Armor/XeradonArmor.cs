using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    class XeradonArmor : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xeradon Armor");
            Tooltip.SetDefault("10% increased mining speed\n10% increased block placement speed\nReduces enemy spawn rate and aggression");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.defense = 20;
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
            player.calmed = true;
            player.aggro -= 500;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ItemID.MiningShirt).AddIngredient(ItemID.AdamantiteBar, 4).AddIngredient(ItemID.TitaniumBar, 4).AddIngredient(ModContent.ItemType<Placeable.Bar.TroxiniumBar>(), 4).AddTile(TileID.MythrilAnvil).Register();
        }
    }
}
