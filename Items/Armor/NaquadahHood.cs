using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    class NaquadahHood : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Naquadah Hood");
            Tooltip.SetDefault("8% increased magic damage\n7% decreased mana usage");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.defense = 6;
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
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().auraThorns = true;
        }

        public override void UpdateEquip(Player player)
        {
            player.magicDamage += 0.08f;
            player.manaCost -= 0.07f;
        }
    }
}
