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
            Tooltip.SetDefault("14% increased ranged damage\nIncreases maximum mana by 40");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.defense = 7;
            Item.rare = ItemRarityID.Orange;
            Item.width = dims.Width;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ModContent.ItemType<Placeable.Bar.RhodiumBar>(), 15).AddIngredient(ModContent.ItemType<Material.DesertFeather>(), 4).AddTile(TileID.Anvils).Register();
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<RhodiumPlateMail>() && legs.type == ModContent.ItemType<RhodiumGreaves>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "9% increased damage";
            player.allDamage += 0.09f;
        }

        public override void UpdateEquip(Player player)
        {
            player.statManaMax2 += 40;
            player.GetDamage(DamageClass.Ranged) += 0.14f;
        }
    }
}
