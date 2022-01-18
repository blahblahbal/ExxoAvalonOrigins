using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    class AwakenedRoseSubligar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Awakened Rose Subligar");
            Tooltip.SetDefault("10% increased movement speed"
                + "\n10% decreased mana cost");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.defense = 20;
            item.rare = ItemRarityID.Red;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 40, 0, 0);
            item.height = dims.Height;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.1f;
            player.manaCost -= 0.1f;
        }
    }
}
