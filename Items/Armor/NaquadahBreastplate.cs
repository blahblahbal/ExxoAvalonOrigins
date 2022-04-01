using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    class NaquadahBreastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Naquadah Breastplate");
            Tooltip.SetDefault("6% increased damage");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.defense = 14;
            Item.rare = ItemRarityID.LightRed;
            Item.width = dims.Width;
            Item.value = Item.sellPrice(0, 2, 60, 0);
            Item.height = dims.Height;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Magic) += 0.06f;
            player.GetDamage(DamageClass.Ranged) += 0.06f;
            player.GetDamage(DamageClass.Summon) += 0.06f;
            player.GetDamage(DamageClass.Melee) += 0.06f;
        }
    }
}
