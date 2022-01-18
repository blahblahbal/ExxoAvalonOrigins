using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    class TroxiniumBodyarmor : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Troxinium Bodyarmor");
            Tooltip.SetDefault("8% increased damage");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.defense = 15;
            item.rare = ItemRarityID.Pink;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 2, 60, 0);
            item.height = dims.Height;
        }

        public override void UpdateEquip(Player player)
        {
            player.magicDamage += 0.08f;
            player.rangedDamage += 0.08f;
            player.minionDamage += 0.08f;
            player.meleeDamage += 0.08f;
        }
    }
}
