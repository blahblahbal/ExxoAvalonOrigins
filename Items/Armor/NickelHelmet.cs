using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    class NickelHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nickel Helmet");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.defense = 3;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 0, 0, 60);
            item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Bar.BismuthBar>(), 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<NickelChainmail>() && legs.type == ModContent.ItemType<NickelGreaves>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "+2 defense";
            player.statDefense += 2;
        }
    }
}
