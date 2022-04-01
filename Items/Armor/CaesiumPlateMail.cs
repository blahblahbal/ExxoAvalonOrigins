using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    class CaesiumPlateMail : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Caesium Plate Mail");
            Tooltip.SetDefault("5% increased melee critical strike chance\nMelee attacks inflict On Fire!");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.defense = 25;
            Item.rare = ItemRarityID.Lime;
            Item.width = dims.Width;
            Item.value = Item.sellPrice(0, 9, 0, 0);
            Item.height = dims.Height;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetCritChance(DamageClass.Melee) += 5;
            player.magmaStone = true;
        }
    }
}
