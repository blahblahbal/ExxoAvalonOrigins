using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    class ZincHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zinc Helmet");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.defense = 4;
            Item.width = dims.Width;
            Item.value = Item.sellPrice(0, 0, 20);
            Item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ModContent.ItemType<Placeable.Bar.ZincBar>(), 15).AddTile(TileID.Anvils).Register();
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<ZincChainmail>() && legs.type == ModContent.ItemType<ZincGreaves>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "+3 defense";
            player.statDefense += 3;
        }
    }
}
