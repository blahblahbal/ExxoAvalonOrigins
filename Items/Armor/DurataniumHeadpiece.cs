using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    class DurataniumHeadpiece : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Duratanium Headpiece");
            Tooltip.SetDefault("7% increased ranged damage");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.defense = 7;
            Item.rare = ItemRarityID.LightRed;
            Item.width = dims.Width;
            Item.value = Item.sellPrice(0, 1, 40, 0);
            Item.height = dims.Height;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<DurataniumChainmail>() && legs.type == ModContent.ItemType<DurataniumGreaves>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Defense is increased by 12 while you are affected by a debuff";
            player.Avalon().defDebuff = true;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Ranged) += 0.07f;
        }
    }
}
