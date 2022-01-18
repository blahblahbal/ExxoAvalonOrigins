using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    class BlahsHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blah's Helmet");
            Tooltip.SetDefault("29% increased damage\n10% increased critical strike chance");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.defense = 50;
            item.rare = ItemRarityID.Red;
            item.width = dims.Width;
            item.value = Item.sellPrice(1, 0, 0, 0);
            item.height = dims.Height;
        }

        public override void UpdateEquip(Player player)
        {
            player.meleeDamage += 0.29f;
            player.magicDamage += 0.29f;
            player.rangedDamage += 0.29f;
            player.meleeCrit += 10;
            player.rangedCrit += 10;
            player.magicCrit += 10;
        }
    }
}
