using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    class AncientTitaniumGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Titanium Greaves");
            Tooltip.SetDefault("10% increased magic damage");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.defense = 7;
            item.rare = ItemRarityID.Orange;
            item.width = dims.Width;
            item.value = 100000;
            item.height = dims.Height;
        }

        public override void UpdateEquip(Player player)
        {
            player.magicDamage += 0.1f;
        }
    }
}
