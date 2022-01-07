using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    class BismuthHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bismuth Helmet");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.defense = 5;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 0, 9, 75);
            item.height = dims.Height;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<BismuthChainmail>() && legs.type == ModContent.ItemType<BismuthGreaves>();
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Bar.BismuthBar>(), 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "+4 defense";
            player.statDefense += 4;
        }
    }
}
