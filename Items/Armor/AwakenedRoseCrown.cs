using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    class AwakenedRoseCrown : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Awakened Rose Crown");
            Tooltip.SetDefault("20% increased magic damage"
                + "\n5% increased magic critical strike chance"
                + "\nOccasionally summons a leaf storm when damaged");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.defense = 25;
            item.rare = ItemRarityID.Red;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 40, 0, 0);
            item.height = dims.Height;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<AwakenedRosePlateMail>() && legs.type == ModContent.ItemType<AwakenedRoseSubligar>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "On hitting enemies with magic weapons, rosebuds have a chance to spawn around them. Picking up rosebuds restores 10-15 hp";
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().roseMagic = true;
        }

        public override void UpdateEquip(Player player)
        {
            player.magicDamage += 0.2f;
            player.magicCrit += 5;
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().leafStorm = true;
        }
    }
}
