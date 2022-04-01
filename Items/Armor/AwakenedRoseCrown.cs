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
            Item.defense = 25;
            Item.rare = ItemRarityID.Red;
            Item.width = dims.Width;
            Item.value = Item.sellPrice(0, 40, 0, 0);
            Item.height = dims.Height;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<AwakenedRosePlateMail>() && legs.type == ModContent.ItemType<AwakenedRoseSubligar>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "On hitting enemies with magic weapons, rosebuds have a chance to spawn around them. Picking up rosebuds restores 10-15 hp";
            player.Avalon().roseMagic = true;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Magic) += 0.2f;
            player.GetCritChance(DamageClass.Magic) += 5;
            player.Avalon().leafStorm = true;
        }
    }
}
