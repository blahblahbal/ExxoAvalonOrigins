using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    class NaquadahMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Naquadah Mask");
            Tooltip.SetDefault("8% increased melee damage and speed\nEnemies are more likely to target you");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.defense = 18;
            item.rare = ItemRarityID.LightRed;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 2, 40, 0);
            item.height = dims.Height;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<NaquadahBreastplate>() && legs.type == ModContent.ItemType<NaquadahShinguards>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Nearby enemies receive damage when you are damaged";
            player.Avalon().auraThorns = true;
        }

        public override void UpdateEquip(Player player)
        {
            player.meleeDamage += 0.08f;
            player.meleeSpeed += 0.08f;
            player.aggro += 150;
        }
    }
}
