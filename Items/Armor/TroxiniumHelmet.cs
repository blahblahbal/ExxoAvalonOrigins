using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    class TroxiniumHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Troxinium Helmet");
            Tooltip.SetDefault("11% increased melee damage and speed\nEnemies are more likely to target you");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.defense = 23;
            item.rare = ItemRarityID.Pink;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 3, 40, 0);
            item.height = dims.Height;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<TroxiniumBodyarmor>() && legs.type == ModContent.ItemType<TroxiniumCuisses>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Hit mobs 15 times to trigger melee crits for 10 hits";
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().hyperMelee = true;
        }

        public override void UpdateEquip(Player player)
        {
            player.meleeDamage += 0.11f;
            player.meleeSpeed += 0.11f;
            player.aggro += 200;
        }
    }
}
