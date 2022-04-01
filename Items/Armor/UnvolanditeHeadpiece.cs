using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    class UnvolanditeHeadpiece : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Unvolandite Headpiece");
            Tooltip.SetDefault("16% increased damage\n6% increased critical strike chance");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.defense = 32;
            Item.rare = ItemRarityID.Cyan;
            Item.width = dims.Width;
            Item.value = Item.sellPrice(0, 50, 0, 0);
            Item.height = dims.Height;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<UnvolanditeBodyplate>() && legs.type == ModContent.ItemType<UnvolanditeLeggings>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.onHitPetal = true;
            player.Avalon().hyperMelee = true;
            player.Avalon().hyperMagic = true;
            player.Avalon().hyperRanged = true;
            player.setBonus = "Petals attack your enemies and Hyper Damage";
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Ranged) += 0.16f;
            player.GetDamage(DamageClass.Melee) += 0.16f;
            player.GetDamage(DamageClass.Summon) += 0.16f;
            player.GetDamage(DamageClass.Magic) += 0.16f;
            player.GetCritChance(DamageClass.Magic) += 6;
            player.GetCritChance(DamageClass.Melee) += 6;
            player.GetCritChance(DamageClass.Ranged) += 6;
        }
    }
}
