using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	class TourmalineRobe : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tourmaline Robe");
			Tooltip.SetDefault("Increases maximum mana by 100\nReduces mana usage by 15%");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.defense = 5;
			item.rare = ItemRarityID.Green;
			item.width = dims.Width;
			item.value = Item.sellPrice(0, 0, 50, 0) * 3;
			item.height = dims.Height;
		}
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<TourmalineRobe>() && (head.type == ItemID.WizardHat || head.type == ItemID.MagicHat);
        }
        public override void UpdateArmorSet(Player player)
        {
            if (player.head == 14)
            {
                player.setBonus = "10% increased magic critical strike chance";
                player.magicCrit += 10;
            }
            else if (player.head == 159)
            {
                player.setBonus = "Increases maximum mana by 60";
                player.statManaMax2 += 60;
            }
        }
        public override void UpdateEquip(Player player)
		{
			player.statManaMax2 += 100;
			player.manaCost -= 0.15f;
		}
	}
}
