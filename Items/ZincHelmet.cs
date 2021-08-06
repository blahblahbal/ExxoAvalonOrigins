using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{
    [AutoloadEquip(EquipType.Head)]
    class ZincHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zinc Helmet");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/ZincHelmet");
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
    }}