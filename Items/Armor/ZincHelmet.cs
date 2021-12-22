using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    class ZincHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zinc Helmet");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.defense = 4;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 0, 1, 75);
            item.height = dims.Height;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<ZincChainmail>() && legs.type == ModContent.ItemType<ZincGreaves>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "+3 defense";
            player.statDefense += 3;
        }
    }
}
