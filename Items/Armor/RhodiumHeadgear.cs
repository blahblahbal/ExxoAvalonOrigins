using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    class RhodiumHeadgear : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rhodium Headgear");
            Tooltip.SetDefault("10% increased ranged damage\nIncreases maximum mana by 20");
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
            recipe.AddIngredient(ModContent.ItemType<Placeable.Bar.RhodiumBar>(), 15);
            recipe.AddIngredient(ModContent.ItemType<Material.DesertFeather>(), 4);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<RhodiumPlateMail>() && legs.type == ModContent.ItemType<RhodiumGreaves>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "20% increased melee speed";
            player.meleeSpeed += 0.2f;
        }

        public override void UpdateEquip(Player player)
        {
            player.statManaMax2 += 20;
            player.rangedDamage += 0.1f;
        }
    }
}
