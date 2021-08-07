using Microsoft.Xna.Framework;
    [AutoloadEquip(EquipType.Head)]
    class BronzeHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bronze Helmet");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/BronzeHelmet");
            item.defense = 2;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 0, 0, 40);
            item.height = dims.Height;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<BronzeChainmail>() && legs.type == ModContent.ItemType<BronzeGreaves>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "+1 defense";
            player.statDefense++;
        }
    }