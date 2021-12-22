using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    class IridiumPants : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Iridium Pants");
            Tooltip.SetDefault("15% increased magic damage");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.defense = 8;
            item.rare = ItemRarityID.LightRed;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 0, 9, 75);
            item.height = dims.Height;
        }
        public override void UpdateEquip(Player player)
        {
            player.magicDamage += 0.15f;
        }
    }
}
