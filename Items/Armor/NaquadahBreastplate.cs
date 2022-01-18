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
            item.defense = 14;
            item.rare = ItemRarityID.LightRed;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 2, 60, 0);
            item.height = dims.Height;
        }

        public override void UpdateEquip(Player player)
        {
            player.magicDamage += 0.06f;
            player.rangedDamage += 0.06f;
            player.minionDamage += 0.06f;
            player.meleeDamage += 0.06f;
        }
    }
}
