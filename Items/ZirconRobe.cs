using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Items
{
	[AutoloadEquip(EquipType.Body)]
	class ZirconRobe : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Zircon Robe");
			Tooltip.SetDefault("Increases maximum mana by 120\nReduces mana usage by 18%");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/ZirconRobe");
			item.defense = 6;
			item.rare = 2;
			item.width = dims.Width;
			item.value = Item.sellPrice(0, 0, 50, 0) * 4;
			item.height = dims.Height;
		}

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<ZirconRobe>() && (head.type == ItemID.WizardHat || head.type == ItemID.MagicHat);
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
			player.statManaMax2 += 120;
			player.manaCost -= 0.18f;
		}
	}
}