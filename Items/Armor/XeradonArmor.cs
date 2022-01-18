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
            item.defense = 20;
            item.rare = ItemRarityID.Pink;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 2);
            item.height = dims.Height;
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
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ItemID.MiningShirt);
            r.AddIngredient(ItemID.AdamantiteBar, 4);
            r.AddIngredient(ItemID.TitaniumBar, 4);
            r.AddIngredient(ModContent.ItemType<Placeable.Bar.TroxiniumBar>(), 4);
            r.AddTile(TileID.MythrilAnvil);
            r.SetResult(this);
            r.AddRecipe();
        }
    }
}
