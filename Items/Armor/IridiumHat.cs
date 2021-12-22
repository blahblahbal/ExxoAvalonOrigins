using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    class IridiumHat : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Iridium Hat");
            Tooltip.SetDefault("14% increased melee damage and speed\n11% increased ranged damage");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.defense = 7;
            item.rare = ItemRarityID.LightRed;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 1, 20);
            item.height = dims.Height;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<IridiumPlateMail>() && legs.type == ModContent.ItemType<IridiumPants>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "20% increased melee speed";
            player.meleeSpeed += 0.2f;
        }
        public override void UpdateEquip(Player player)
        {
            player.meleeDamage += 0.14f;
            player.meleeSpeed += 0.14f;
            player.rangedDamage += 0.11f;
        }
    }
}
