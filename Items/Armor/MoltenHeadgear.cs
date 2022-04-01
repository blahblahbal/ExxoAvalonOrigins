using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    class MoltenHeadgear : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Molten Headgear");
            Tooltip.SetDefault("Ranged helmet");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.defense = 5;
            Item.rare = ItemRarityID.Orange;
            Item.width = dims.Width;
            Item.value = 30000;
            Item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ItemID.HellstoneBar, 10).AddIngredient(ModContent.ItemType<Items.Material.FireShard>()).AddTile(TileID.Anvils).Register();
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.MoltenBreastplate && legs.type == ItemID.MoltenGreaves;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "17% increased ranged damage and 20% chance to not consume ammo";
            player.GetDamage(DamageClass.Ranged) += 0.17f;
            player.ammoCost80 = true;
        }
    }
}
