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
            Tooltip.SetDefault("11% increased melee damage and speed\n11% increased ranged damage");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.defense = 7;
            Item.rare = ItemRarityID.LightRed;
            Item.width = dims.Width;
            Item.value = Item.sellPrice(0, 1, 20);
            Item.height = dims.Height;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<IridiumPlateMail>() && legs.type == ModContent.ItemType<IridiumPants>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "9% increased critical strike chance";
            player.AllCrit(9);
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Melee) += 0.11f;
            player.meleeSpeed += 0.11f;
            player.GetDamage(DamageClass.Ranged) += 0.11f;
        }
    }
}
