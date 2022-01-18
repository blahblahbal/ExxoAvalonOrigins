using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    class OsmiumHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Osmium Helmet");
            Tooltip.SetDefault("15% increased ranged damage\nIncreases maximum mana by 40");
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
            recipe.AddIngredient(ModContent.ItemType<Placeable.Bar.OsmiumBar>(), 15);
            recipe.AddIngredient(ModContent.ItemType<Material.DesertFeather>(), 4);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<OsmiumJerkin>() && legs.type == ModContent.ItemType<OsmiumTreads>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "+3 defense and 20% increased melee speed";
            player.meleeSpeed += 0.2f;
        }

        public override void UpdateEquip(Player player)
        {
            player.statManaMax2 += 40;
            player.rangedDamage += 0.15f;
        }
    }
}
